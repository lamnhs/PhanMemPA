using CMSCore.BLL;
using CMSDevExpressCommon;
using DevExpress.XtraEditors;
using System;
using System.Data;
using System.Resources;
using System.Windows.Forms;

namespace CMSUI.SystemConfiguration
{
    public partial class frm_CMS_Grid : DevExpress.XtraEditors.XtraForm
    {
        #region Variables
        DataTable _dtData = new DataTable();

        ResourceManager rm;
        #endregion

        #region Inits
        public frm_CMS_Grid()
        {
            InitializeComponent();

            SetLanguage();
        }

        private void frm_CMS_Grid_Load(object sender, EventArgs e)
        {
            #region Phân quyền
            CommonFunctions.SetFormPermiss(this);
            #endregion

            GetData();
        }
        #endregion

        #region Functions
        private void SetLanguage()
        {
            rm = new ResourceManager("CMSUI.Lang.MyResource", typeof(frm_CMS_Grid).Assembly);

            btnClose.Text = rm.GetString("btnClose", CMSUser._culture);
            btnSave.Text = rm.GetString("btnSave", CMSUser._culture);
            btnDelete.Text = rm.GetString("btnDelete", CMSUser._culture);
            btnExcel.Text = rm.GetString("ExportExcel", CMSUser._culture);
        }

        private void GetData()
        {
            try
            {
                #region Định nghĩa lưới
                DataTable dtGrid = BL_System.GetGrid();
                DataRow drGrids = (DataRow)dtGrid.Select("GridID = 'HT-HT-LuoiHienThi'").GetValue(0);
                DataTable dtGridColumns = BL_System.GetGridColumn(drGrids["ID"].ToString());
                #endregion

                gridViewData.Columns.Clear();

                _dtData = BL_System.GetGrid();
                _dtData.Columns["ModuleID"].AllowDBNull = true;

                gridControlData.DataSource = _dtData;

                AppGridView.InitGridView(gridViewData, drGrids, dtGridColumns, CMSUser._foreignLanguageInterface);

                if (drGrids["ReadOnlyAllGrid"].ToString() == "True")
                    AppGridView.ReadOnlyColumn(gridViewData);

                #region MultiSelectMode
                DataTable dtMultiSelectMode = BL_System.GetMultiSelectMode();
                AppDevExpressEditControl.InitRepositoryItemLookUpEdit(repositoryItemLookUpEditMultiMode, dtMultiSelectMode, "Description", "ID", string.Empty, "Description", rm.GetString("DienGiai", CMSUser._culture), 0);

                gridViewData.Columns["MultiSelectMode"].ColumnEdit = repositoryItemLookUpEditMultiMode;
                #endregion

                #region NewItemRowPosition
                DataTable dtNewRow = BL_System.GetNewItemRowPosition();
                AppDevExpressEditControl.InitRepositoryItemLookUpEdit(repositoryItemLookUpEditNewRow, dtNewRow, "Description", "ID", string.Empty, "Description", rm.GetString("DienGiai", CMSUser._culture), 0);

                gridViewData.Columns["NewItemRowPosition"].ColumnEdit = repositoryItemLookUpEditNewRow;
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
                        strXml += "<Grids ID = \"" + dr["ID"].ToString()
                            + "\" GridID = \"" + dr["GridID"].ToString()
                            + "\" GridName = \"" + dr["GridName"].ToString()
                            + "\" ForeignGridName = \"" + dr["ForeignGridName"].ToString()
                            + "\" ShowAutoFilterRow = \"" + dr["ShowAutoFilterRow"].ToString()
                            + "\" MultiSelect = \"" + dr["MultiSelect"].ToString()
                            + "\" MultiSelectMode = \"" + dr["MultiSelectMode"].ToString()
                            + "\" ShowGroupPanel = \"" + dr["ShowGroupPanel"].ToString()
                            + "\" NewItemRowPosition = \"" + dr["NewItemRowPosition"].ToString()
                            + "\" ColumnAutoWidth = \"" + dr["ColumnAutoWidth"].ToString()
                            + "\" ShowViewCaption = \"" + dr["ShowViewCaption"].ToString()
                            + "\" IsInUsed = \"" + dr["IsInUsed"].ToString()
                            + "\" ReadOnlyAllGrid = \"" + dr["ReadOnlyAllGrid"].ToString()
                            + "\" BestFitColumns = \"" + dr["BestFitColumns"].ToString() + "\"/>";
                }

                if (strXml == string.Empty)
                    return;

                strXml = "<Root>" + strXml + "</Root>";

                int result = BL_System.SaveGrid(strXml, CMSUser._UserID);

                if (result == 0)
                {
                    GetData();
                    XtraMessageBox.Show(rm.GetString("ThanhCong", CMSUser._culture),
                        rm.GetString("TieuDeThongBao", CMSUser._culture), MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                    XtraMessageBox.Show(rm.GetString("ThanhCong", CMSUser._culture),
                        rm.GetString("TieuDeThongBao", CMSUser._culture), MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                    strXml += "<Grids ID = \"" + gridViewData.GetDataRow(i)["ID"].ToString() + "\"/>";
                }

                if (strXml == string.Empty)
                    return;

                strXml = "<Root>" + strXml + "</Root>";

                int result = BL_System.DeleteGrid(strXml, CMSUser._UserID);

                if (result == 0)
                {
                    GetData();
                    XtraMessageBox.Show(rm.GetString("ThanhCong", CMSUser._culture),
                        rm.GetString("TieuDeThongBao", CMSUser._culture), MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                    XtraMessageBox.Show(rm.GetString("ThanhCong", CMSUser._culture),
                        rm.GetString("TieuDeThongBao", CMSUser._culture), MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private void btn_refresh_Click(object sender, EventArgs e)
        {
            frm_CMS_Grid_Load(null, null);
        }

        private void btn_LuuDuLieu_Click(object sender, EventArgs e)
        {
            SaveData();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DeleteData();
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

                    XtraMessageBox.Show(rm.GetString("ThanhCong", CMSUser._culture),
                        rm.GetString("TieuDeThongBao", CMSUser._culture), MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message,
                        rm.GetString("TieuDeThongBao", CMSUser._culture), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion
    }
}