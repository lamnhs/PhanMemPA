﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.Export;
using DevExpress.XtraPrinting;
using System.Resources;
using CMSCore.BLL;
using CMSDevExpressCommon;

namespace CMSUI.SystemConfiguration
{
    public partial class frm_CMS_GridColumn : DevExpress.XtraEditors.XtraForm
    {
        #region Variables
        DataTable _dtData = new DataTable();
        string _luoiHienThi = string.Empty;

        ResourceManager rm;
        #endregion

        #region Inits
        public frm_CMS_GridColumn()
        {
            InitializeComponent();

            SetLanguage();
        }

        private void frm_CMS_GridColumn_Load(object sender, EventArgs e)
        {
            #region Phân quyền
            CommonFunctions.SetFormPermiss(this);
            #endregion

            LuoiHienThi();
            lookUpEditGrids.ItemIndex = 0;
        }
        #endregion

        #region Functions
        private void SetLanguage()
        {
            rm = new ResourceManager("CMSUI.Lang.MyResource", typeof(frm_CMS_GridColumn).Assembly);

            btnClose.Text = rm.GetString("btnClose", CMSUser._culture);
            btnSave.Text = rm.GetString("btnSave", CMSUser._culture);
            btnDelete.Text = rm.GetString("btnDelete", CMSUser._culture);
            layoutControlItemGrids.Text = rm.GetString("layoutControlItemGrids", CMSUser._culture);
            btnFilter.Text = rm.GetString("btnFilter", CMSUser._culture);
            btnExcel.Text = rm.GetString("ExportExcel", CMSUser._culture);
        }

        private void LuoiHienThi()
        {
            try
            {
                DataTable _dtLuoiHienThi = BL_System.GetGrid();
                AppDevExpressEditControl.InitLookUpEdit(lookUpEditGrids, _dtLuoiHienThi, "GridName", "ID", string.Empty, "GridID,GridName"
                    , rm.GetString("GridID", CMSUser._culture) + "," + rm.GetString("GridName", CMSUser._culture), 0);
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, rm.GetString("TieuDeThongBao", CMSUser._culture), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void GetData()
        {
            try
            {
                #region Định nghĩa lưới
                DataTable dtGrid = BL_System.GetGrid();
                DataRow drGrids = (DataRow)dtGrid.Select("GridID = 'HT-HT-CacCotHienThiTrenLuoi'").GetValue(0);
                DataTable dtGridColumns = BL_System.GetGridColumn(drGrids["ID"].ToString());
                #endregion

                _luoiHienThi = lookUpEditGrids.EditValue.ToString();

                _dtData = BL_System.GetGridColumn(_luoiHienThi);

                foreach (DataColumn dc in _dtData.Columns)
                    dc.ReadOnly = false;

                _dtData.Columns["OldID"].AllowDBNull = true;
                _dtData.Columns["GridID"].AllowDBNull = true;

                gridControlData.DataSource = _dtData;

                AppGridView.InitGridView(gridViewData, drGrids, dtGridColumns, CMSUser._foreignLanguageInterface);

                if (drGrids["ReadOnlyAllGrid"].ToString() == "True")
                    AppGridView.ReadOnlyColumn(gridViewData);

                #region SummaryType
                DataTable dtSummaryType = BL_System.GetSummaryType();
                AppDevExpressEditControl.InitRepositoryItemLookUpEdit(repositoryItemLookUpEditSummaryType, dtSummaryType, "Description", "ID", string.Empty, "Description", rm.GetString("DienGiai", CMSUser._culture), 0);
                gridViewData.Columns["SummaryType"].ColumnEdit = repositoryItemLookUpEditSummaryType;
                #endregion

                #region Align
                DataTable dtAlign = BL_System.GetAlignType();
                AppDevExpressEditControl.InitRepositoryItemLookUpEdit(repositoryItemLookUpEditAlignHeader, dtAlign, "Description", "ID", string.Empty, "Description", rm.GetString("DienGiai", CMSUser._culture), 0);
                gridViewData.Columns["HeaderAlign"].ColumnEdit = repositoryItemLookUpEditAlignHeader;

                //------------------------------------------------------------

                AppDevExpressEditControl.InitRepositoryItemLookUpEdit(repositoryItemLookUpEditAlignData, dtAlign, "Description", "ID", string.Empty, "Description", rm.GetString("DienGiai", CMSUser._culture), 0);
                gridViewData.Columns["DataAlign"].ColumnEdit = repositoryItemLookUpEditAlignData;
                #endregion

                #region Fixed
                DataTable dtFixed = BL_System.GetFixedType();
                AppDevExpressEditControl.InitRepositoryItemLookUpEdit(repositoryItemLookUpEditFixed, dtFixed, "Description", "ID", string.Empty, "Description", rm.GetString("DienGiai", CMSUser._culture), 0);
                gridViewData.Columns["Fixed"].ColumnEdit = repositoryItemLookUpEditFixed;
                #endregion

                if (drGrids["ColumnAutoWidth"].ToString() == "True")
                    gridViewData.OptionsView.ColumnAutoWidth = true;
                else
                    gridViewData.OptionsView.ColumnAutoWidth = false;

                if (drGrids["BestFitColumns"].ToString() == "True")
                    gridViewData.BestFitColumns();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, rm.GetString("TieuDeThongBao", CMSUser._culture), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SaveData()
        {
            try
            {
                if (CMSUser._HoiLaiKhiLuu)
                {
                    if (XtraMessageBox.Show(rm.GetString("LuuDuLieu?", CMSUser._culture),
                                rm.GetString("TieuDeThongBao", CMSUser._culture), MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.Cancel)
                        return;
                }

                if (CMSUser._XacNhanMatKhauKhiLuu)
                {
                    frm_CMS_ConfirmPassword frm = new frm_CMS_ConfirmPassword();
                    frm.ShowDialog();

                    if (frm._confirm == false)
                        return;
                }

                string strXml = string.Empty;
                foreach (DataRow dr in _dtData.Rows)
                {
                    if (dr.RowState == DataRowState.Added || dr.RowState == DataRowState.Modified)
                        strXml += "<GridColumns ID = \"" + dr["ID"].ToString()
                                + "\" ColumnName = \"" + dr["ColumnName"].ToString()
                                + "\" ForeignColumnName = \"" + dr["ForeignColumnName"].ToString()
                                + "\" Visible = \"" + dr["Visible"].ToString()
                                + "\" VisibleIndex = \"" + dr["VisibleIndex"].ToString()
                                + "\" ReadOnly = \"" + dr["ReadOnly"].ToString()
                                + "\" Width = \"" + dr["Width"].ToString()
                                + "\" SummaryType = \"" + dr["SummaryType"].ToString()
                                + "\" HeaderAlign = \"" + dr["HeaderAlign"].ToString()
                                + "\" DataAlign = \"" + dr["DataAlign"].ToString()
                                + "\" Fixed = \"" + dr["Fixed"].ToString()
                                + "\" Sorted = \"" + dr["Sorted"].ToString()
                                + "\" OldID = \"" + dr["OldID"].ToString() + "\"/>";
                }

                if (strXml == string.Empty)
                    return;

                strXml = "<Root>" + strXml + "</Root>";

                int result = BL_System.SaveGridColumn(_luoiHienThi, strXml, CMSUser._UserID);

                if (result == 0)
                {
                    GetData();
                    XtraMessageBox.Show(rm.GetString("ThanhCong", CMSUser._culture), rm.GetString("TieuDeThongBao", CMSUser._culture), MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                    XtraMessageBox.Show(rm.GetString("KhongThanhCong", CMSUser._culture), rm.GetString("TieuDeThongBao", CMSUser._culture), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, rm.GetString("TieuDeThongBao", CMSUser._culture), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DeleteData()
        {
            try
            {
                if (CMSUser._HoiLaiKhiXoa)
                {
                    if (XtraMessageBox.Show(rm.GetString("XoaDuLieu?", CMSUser._culture),
                                rm.GetString("TieuDeThongBao", CMSUser._culture), MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.Cancel)
                        return;
                }

                if (CMSUser._XacNhanMatKhauKhiXoa)
                {
                    frm_CMS_ConfirmPassword frm = new frm_CMS_ConfirmPassword();
                    frm.ShowDialog();

                    if (frm._confirm == false)
                        return;
                }

                string strXml = string.Empty;
                foreach (int i in gridViewData.GetSelectedRows())
                {
                    if (!(gridViewData.GetDataRow(i)["OldID"] == DBNull.Value || gridViewData.GetDataRow(i)["OldID"].ToString() == string.Empty))
                        strXml += "<GridColumns ID = \"" + gridViewData.GetDataRow(i)["OldID"].ToString() + "\"/>";
                }

                if (strXml == string.Empty)
                    return;

                strXml = "<Root>" + strXml + "</Root>";

                int result = BL_System.DeleteGridColumn(_luoiHienThi, strXml, CMSUser._UserID);

                if (result == 0)
                {
                    GetData();
                    XtraMessageBox.Show(rm.GetString("ThanhCong", CMSUser._culture), rm.GetString("TieuDeThongBao", CMSUser._culture), MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                    XtraMessageBox.Show(rm.GetString("KhongThanhCong", CMSUser._culture), rm.GetString("TieuDeThongBao", CMSUser._culture), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, rm.GetString("TieuDeThongBao", CMSUser._culture), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion

        #region Events
        private void btn_Thoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_LuuDuLieu_Click(object sender, EventArgs e)
        {
            SaveData();
        }

        private void bbtnDelete_Click(object sender, EventArgs e)
        {
            DeleteData();
        }

        private void btn_refresh_Click(object sender, EventArgs e)
        {
            frm_CMS_GridColumn_Load(null, null);
        }

        private void btn_LocDuLieu_Click(object sender, EventArgs e)
        {
            GetData();
        }

        private void gridViewData_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            if (e.RowHandle >= 0)
                e.Info.DisplayText = (e.RowHandle + 1).ToString();
        }

        private void btnExcel_Click(object sender, EventArgs e)
        {
            try
            {
                SaveFileDialog sfdFiles = new SaveFileDialog();

                sfdFiles.Filter = "Excel Workbook|*.xlsx";

                if (sfdFiles.ShowDialog() == DialogResult.OK && sfdFiles.FileName != string.Empty)
                {
                    AppGridView.GridViewExportExcel(gridViewData, gridControlData, sfdFiles.FileName, true);

                    XtraMessageBox.Show(rm.GetString("ThanhCong", CMSUser._culture), rm.GetString("TieuDeThongBao", CMSUser._culture), MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, rm.GetString("TieuDeThongBao", CMSUser._culture), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion
    }
}