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
    public partial class frm_CMS_QuanLyNguoiDung : DevExpress.XtraEditors.XtraForm
    {
        #region Variables
        DataTable _dtData = new DataTable();
        string _luoiHienThi = string.Empty;
        string _khachHang = string.Empty;


        ResourceManager rm;
        #endregion

        #region Inits
        public frm_CMS_QuanLyNguoiDung()
        {
            InitializeComponent();

            SetLanguage();
        }

        private void frm_CMS_GridColumn_Load(object sender, EventArgs e)
        {
            #region Phân quyền
            CommonFunctions.SetFormPermiss(this);
            #endregion
            GetNhom();
            GetData();
            GetKhachHang();


        }
        #endregion

        #region Functions
        private void SetLanguage()
        {
            rm = new ResourceManager("CMSUI.Lang.MyResource", typeof(frm_CMS_GridColumn).Assembly);

            btnClose.Text = rm.GetString("btnClose", CMSUser._culture);
            btnSave.Text = rm.GetString("btnSave", CMSUser._culture);
            btnDelete.Text = rm.GetString("btnDelete", CMSUser._culture);
        }
        private void GetKhachHang()
        {
            try
            {
                DataTable dtTemplateType = BL_ManageDegreeAndCertificate.GetTemplateType(CMSUser._UserID);
                AppDevExpressEditControl.InitLookUpEdit(lookUpEditKhachHang, dtTemplateType, "TenKH", "MaKH", string.Empty, "TenKH", rm.GetString("layoutControlItemTemplateType", CMSUser._culture), 0);
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, rm.GetString("TieuDeThongBao", CMSUser._culture), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void GetNhom()
        {
            try
            {
                DataTable dtTemplateType = BL_ManageDegreeAndCertificate.GetNhom(CMSUser._UserID);
                AppDevExpressEditControl.InitLookUpEdit(lookUpEditNhom, dtTemplateType, "GroupName", "GroupID", string.Empty, "GroupName", rm.GetString("layoutControlItemNhom", CMSUser._culture), 0);
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
            _dtData = BL_ManageDegreeAndCertificate.GetNguoiDung();


                foreach (DataColumn dc in _dtData.Columns)
                {
                    dc.ReadOnly = false;
                    dc.AllowDBNull = true;
                }

                gridControlData.DataSource = _dtData;

                #region Định nghĩa lưới
                DataTable dtGrid = BL_System.GetGrid();
                DataRow _drGrids = (DataRow)dtGrid.Select("GridID = 'QLVBCC-QLVBCC-NguoiDung'").GetValue(0);
                DataTable _dtGridColumns = BL_System.GetGridColumn(_drGrids["ID"].ToString());
                #endregion

                AppGridView.InitGridView(gridViewData, _drGrids, _dtGridColumns, CMSUser._foreignLanguageInterface);

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

                string password = CommonFunctions.EncodeMD5(textEditTaiKhoan.Text.Trim(), textEditMatKhau.Text.Trim());

                int result = BL_ManageDegreeAndCertificate.SaveNguoiDung(textEditTaiKhoan.Text, password, textEditHoVaTen.Text, lookUpEditNhom.EditValue.ToString(), CMSUser._UserID, _khachHang);

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
                //if (CMSUser._HoiLaiKhiXoa == false)
                //{
                    if (XtraMessageBox.Show(rm.GetString("XoaDuLieu?", CMSUser._culture),
                                rm.GetString("TieuDeThongBao", CMSUser._culture), MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.Cancel)
                        return;

                    SystemConfiguration.frm_CMS_ConfirmPassword frm = new SystemConfiguration.frm_CMS_ConfirmPassword();
                    frm.ShowDialog();

                    if (frm._confirm == false)
                        return;
                //}


                int result = BL_ManageDegreeAndCertificate.DeleteNguoiDung(textEditTaiKhoan.Text, CMSUser._UserID);

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

        private void gridViewData_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            // Lấy GridView
            var view = sender as DevExpress.XtraGrid.Views.Grid.GridView;

            // Lấy dữ liệu của dòng được click
            if (view != null)
            {
                string MaNV = view.GetRowCellValue(e.RowHandle, "MaNV").ToString();
                string HoVaTen = view.GetRowCellValue(e.RowHandle, "HoVaTen").ToString();
                string GroupID = view.GetRowCellValue(e.RowHandle, "GroupID").ToString();
                string Pass = view.GetRowCellValue(e.RowHandle, "Password").ToString();
                string KH = view.GetRowCellValue(e.RowHandle, "MaKH").ToString();
                textEditTaiKhoan.Text = MaNV;
                textEditHoVaTen.Text = HoVaTen;
                lookUpEditNhom.EditValue = GroupID;
                textEditMatKhau.Text = Pass;
                lookUpEditKhachHang.EditValue = KH;
            }
        }

        private void simpleButtonMoi_Click(object sender, EventArgs e)
        {
            textEditHoVaTen.Text = "";
            textEditTaiKhoan.Text = "";
            textEditMatKhau.Text = "";
        }

        private void frm_CMS_QuanLyNguoiDung_KeyDown(object sender, KeyEventArgs e)
        {
            // Kiểm tra tổ hợp phím Ctrl + S
            if (e.Control && e.KeyCode == Keys.S)
            {
                e.SuppressKeyPress = true; // Ngăn không cho hành động mặc định xảy ra
                btnSave.PerformClick();   // Gọi sự kiện Click của nút "Lưu"
            }
        }

        private void gridViewData_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.S) // Kiểm tra Ctrl + S
            {
                e.SuppressKeyPress = true; // Ngăn hành động mặc định của tổ hợp phím
                SaveData(); // Gọi hàm lưu dữ liệu
            }
        }

        private void lookUpEditNhom_EditValueChanged(object sender, EventArgs e)
        {
            if(lookUpEditNhom.EditValue.ToString() == "KH")
            {
                layoutControlItemKhachHang.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
            }
            else
            {
                layoutControlItemKhachHang.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
            }
        }

        private void lookUpEditKhachHang_EditValueChanged(object sender, EventArgs e)
        {
            _khachHang = lookUpEditKhachHang.EditValue.ToString();
        }
    }
}