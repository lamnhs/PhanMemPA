using System;
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
    public partial class frm_CMS_ThongKeSoLuong : DevExpress.XtraEditors.XtraForm
    {
        #region Variables
        DataTable _dtData = new DataTable();
        string _luoiHienThi = string.Empty;
        DataTable _dtNhanVien = new DataTable();


        ResourceManager rm;
        #endregion

        #region Inits
        public frm_CMS_ThongKeSoLuong()
        {
            InitializeComponent();

            SetLanguage();
        }

        private void frm_CMS_GridColumn_Load(object sender, EventArgs e)
        {
            #region Phân quyền
            CommonFunctions.SetFormPermiss(this);
            #endregion

           
            //từ ngày
            dateEditTuNgay.EditValue = DateTime.Now.Date;
            dateEditTuNgay.Properties.EditMask = "dd-MM-yyyy"; // Định dạng ngày giờ: Năm-Tháng-Ngày Giờ:Phút
            dateEditTuNgay.Properties.DisplayFormat.FormatString = "dd-MM-yyyy";
            dateEditTuNgay.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            dateEditTuNgay.Properties.EditFormat.FormatString = "dd-MM-yyyy";
            dateEditTuNgay.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            //đến ngày
            dateEditDenNgay.EditValue = DateTime.Now.Date;
            dateEditDenNgay.Properties.EditMask = "dd-MM-yyyy"; // Định dạng ngày giờ: Năm-Tháng-Ngày Giờ:Phút
            dateEditDenNgay.Properties.DisplayFormat.FormatString = "dd-MM-yyyy";
            dateEditDenNgay.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            dateEditDenNgay.Properties.EditFormat.FormatString = "dd-MM-yyyy";
            dateEditDenNgay.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            //điều kiện
            textEditDieuKien.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            textEditDieuKien.Properties.Mask.EditMask = "d"; // Chỉ cho phép nhập số nguyên
            textEditDieuKien.Properties.Mask.UseMaskAsDisplayFormat = true; // Hiển thị theo định dạng mask
            //Nhân viên
            GetNhanVien();


        }
        #endregion

        #region Functions
        private void SetLanguage()
        {
            rm = new ResourceManager("CMSUI.Lang.MyResource", typeof(frm_CMS_GridColumn).Assembly);

            btnClose.Text = rm.GetString("btnClose", CMSUser._culture);
            btnExcel.Text = rm.GetString("ExportExcel", CMSUser._culture);
        }
        private void GetNhanVien()
        {
            try
            {
                checkedComboBoxEditNhanVien.Properties.DataSource = null;

                _dtNhanVien = BL_System.GetNhanVien();
                AppDevExpressEditControl.InitCheckedComboBoxEdit(checkedComboBoxEditNhanVien, _dtNhanVien, "TenNV", "MaNV", string.Empty, rm.GetString("ChonTatCa", CMSUser._culture), ';', true);
            }
            catch { }
        }
        private void GetData()
        {
            try
            {
            _dtData = BL_ManageDegreeAndCertificate.GetThongKeSoLuong(checkedComboBoxEditNhanVien.EditValue.ToString(), Int16.Parse(textEditDieuKien.Text), dateEditTuNgay.EditValue.ToString(), dateEditDenNgay.EditValue.ToString());
            _dtData.Columns.Add("DetailFile", typeof(string));

                foreach (DataColumn dc in _dtData.Columns)
                {
                    dc.ReadOnly = false;
                    dc.AllowDBNull = true;
                }

                gridControlData.DataSource = _dtData;

                #region Định nghĩa lưới
                DataTable dtGrid = BL_System.GetGrid();
                DataRow _drGrids = (DataRow)dtGrid.Select("GridID = 'QLVBCC-QLVBCC-ThongKeSL'").GetValue(0);
                DataTable _dtGridColumns = BL_System.GetGridColumn(_drGrids["ID"].ToString());
                #endregion

                AppGridView.InitGridView(gridViewData, _drGrids, _dtGridColumns, CMSUser._foreignLanguageInterface);

                gridViewData.Columns["DetailFile"].ColumnEdit = repositoryItemButtonEditFile;

                if (_drGrids["ReadOnlyAllGrid"].ToString() == "True")
                    AppGridView.ReadOnlyColumn(gridViewData);

                if (_drGrids["ColumnAutoWidth"].ToString() == "True")
                    gridViewData.OptionsView.ColumnAutoWidth = true;
                else
                    gridViewData.OptionsView.ColumnAutoWidth = false;

                if (_drGrids["BestFitColumns"].ToString() == "True")
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
                    SystemConfiguration.frm_CMS_ConfirmPassword frm = new SystemConfiguration.frm_CMS_ConfirmPassword();
                    frm.ShowDialog();

                    if (frm._confirm == false)
                        return;
                }

                string strXml = string.Empty;
                foreach (DataRow dr in _dtData.Rows)
                {
                    if (dr.RowState == DataRowState.Added || dr.RowState == DataRowState.Modified)
                    {
                        strXml += "<NhanVien ID = \"" + dr["ID"].ToString()
                            + "\" MaNV = \"" + dr["MaNV"].ToString()
                            + "\" TenNV = \"" + dr["TenNV"].ToString()
                            + "\" ChucVu = \"" + dr["ChucVu"].ToString()
                            + "\"/>";
                    }
                }

                if (strXml == "")
                    return;

                strXml = "<Root>" + strXml + "</Root>";

                int result = BL_ManageDegreeAndCertificate.SaveNhanVien(strXml, CMSUser._UserID);

                switch (result)
                {
                    case 0:
                        GetData();
                        XtraMessageBox.Show(rm.GetString("ThanhCong", CMSUser._culture), rm.GetString("TieuDeThongBao", CMSUser._culture), MessageBoxButtons.OK, MessageBoxIcon.Information);
                        break;
                    case 1:
                        XtraMessageBox.Show(rm.GetString("DaDuyet", CMSUser._culture), rm.GetString("TieuDeThongBao", CMSUser._culture), MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        break;
                    default:
                        XtraMessageBox.Show(rm.GetString("KhongThanhCong", CMSUser._culture), rm.GetString("TieuDeThongBao", CMSUser._culture), MessageBoxButtons.OK, MessageBoxIcon.Error);
                        break;
                }
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
                    SystemConfiguration.frm_CMS_ConfirmPassword frm = new SystemConfiguration.frm_CMS_ConfirmPassword();
                    frm.ShowDialog();

                    if (frm._confirm == false)
                        return;
                }

                string strXml = string.Empty;
                foreach (int i in gridViewData.GetSelectedRows())
                {
                    strXml += "<NhanVien ID = \"" + gridViewData.GetDataRow(i)["ID"].ToString()
                            + "\"/>";
                }
                strXml = "<Root>" + strXml + "</Root>";

                int result = BL_ManageDegreeAndCertificate.DeleteNhanVien(strXml, CMSUser._UserID);

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

        private void btnFilter_Click(object sender, EventArgs e)
        {
            if(textEditDieuKien.Text == "")
            {
                XtraMessageBox.Show(rm.GetString("ChuaNhapSL", CMSUser._culture), rm.GetString("TieuDeThongBao", CMSUser._culture), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                GetData();
            }
        }

        private void repositoryItemButtonEditFile_ButtonClick(object sender, ButtonPressedEventArgs e)
        {
            frm_CMS_DetailFile frm = new frm_CMS_DetailFile();
            frm._MaNV = gridViewData.GetFocusedDataRow()["MaNV"].ToString();
            frm._SoLuong = Int16.Parse(textEditDieuKien.Text);
            frm._TuNgay = dateEditTuNgay.EditValue.ToString();
            frm._DenNgay = dateEditDenNgay.EditValue.ToString();

            frm.ShowDialog();
        }
    }
}