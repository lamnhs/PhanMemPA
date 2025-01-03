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
using DevExpress.XtraGrid;
using DevExpress.XtraEditors.Repository;

namespace CMSUI.SystemConfiguration
{
    public partial class frm_CMS_File : DevExpress.XtraEditors.XtraForm
    {
        #region Variables
        DataTable _dtData = new DataTable();
        string _luoiHienThi = string.Empty;
        int tiepNhan = 0, hoanThanh = 0, nhanFile = 0, lanDau = 0;

        ResourceManager rm;
        #endregion

        #region Inits
        public frm_CMS_File()
        {
            InitializeComponent();
            
            SetLanguage();
        }

        private void frm_CMS_GridColumn_Load(object sender, EventArgs e)
        {
            #region Phân quyền
            CommonFunctions.SetFormPermiss(this);
            #endregion

            GetTemplateType();
           

        }
        #endregion

        #region Functions
        private void SetLanguage()
        {
            rm = new ResourceManager("CMSUI.Lang.MyResource", typeof(frm_CMS_GridColumn).Assembly);

            btnClose.Text = rm.GetString("btnClose", CMSUser._culture);
            layoutControlItemKhachHang.Text = rm.GetString("layoutControlItemKhachHang", CMSUser._culture);
            btnFilter.Text = rm.GetString("btnFilter", CMSUser._culture);
        }
        private void GetTemplateType()
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

      

        private void OpenMaDonForm(string maKH, string tenKH)
        {
            // Lấy đối tượng form cha rfrm_CMS_Main
            var mainForm = Application.OpenForms["rfrm_CMS_Main"] as rfrm_CMS_Main;
            if (mainForm != null)
            {
                // Kiểm tra xem form có mở hay không trong MdiChildren của rfrm_CMS_Main
                foreach (Form frm in mainForm.MdiChildren)
                {
                    // Kiểm tra nếu form đã mở và mã đơn giống nhau
                    if (frm is SystemConfiguration.frm_CMS_KhachHang_Form && frm.Text.Contains(tenKH))
                    {
                        // Nếu form đã mở và mã đơn giống nhau, lấy lại focus
                        frm.Focus();
                        return;
                    }
                }

                // Nếu form chưa mở, tạo mới form
                SystemConfiguration.frm_CMS_KhachHang_Form f = new SystemConfiguration.frm_CMS_KhachHang_Form();
                f.Text = "Khách hàng - " + tenKH;  // Đặt tiêu đề cho form với mã đơn
                f.MdiParent = mainForm;  // Đặt form cha là rfrm_CMS_Main instance
                f.MaKH = maKH;  // Truyền mã đơn vào form (ví dụ là một thuộc tính)
                f.Show();  // Hiển thị form
            }
            else
            {
                MessageBox.Show("Form rfrm_CMS_Main không mở.");
            }
        }




        private void DiemGridView()
        {
            // Tạo đối tượng RepositoryItemTextEdit
            RepositoryItemTextEdit repositoryItemTextEdit = new RepositoryItemTextEdit();

            // Thiết lập Mask
            repositoryItemTextEdit.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            repositoryItemTextEdit.Mask.EditMask = "0.0"; // Cho phép nhập số thập phân có 1 chữ số sau dấu phẩy
            repositoryItemTextEdit.Mask.UseMaskAsDisplayFormat = true;

            // Gắn RepositoryItemTextEdit vào cột cụ thể trong GridView
            gridViewData.Columns["Diem"].ColumnEdit = repositoryItemTextEdit;
        }

        private void GetData()
        {
            try
            {
            _dtData = BL_ManageDegreeAndCertificate.GetQuanLyFile(lookUpEditKhachHang.EditValue.ToString(), CMSUser._UserID);


                 foreach (DataColumn dc in _dtData.Columns)
                {
                    dc.ReadOnly = false;
                    dc.AllowDBNull = true;
                }

                gridControlData.DataSource = _dtData;

                #region Định nghĩa lưới
                DataTable dtGrid = BL_System.GetGrid();
                DataRow _drGrids = (DataRow)dtGrid.Select("GridID = 'QLVBCC-QLVBCC-QuanLyFile'").GetValue(0);
                DataTable _dtGridColumns = BL_System.GetGridColumn(_drGrids["ID"].ToString());
                #endregion

                AppGridView.InitGridView(gridViewData, _drGrids, _dtGridColumns, CMSUser._foreignLanguageInterface);

                if (_drGrids["ReadOnlyAllGrid"].ToString() == "True")
                    AppGridView.ReadOnlyColumn(gridViewData);


                #region Nhân viên làm chính
                DataTable dtNhanVien = BL_System.GetNhanVien();
                AppDevExpressEditControl.InitRepositoryItemLookUpEdit(repositoryItemLookUpEditNhanVien, dtNhanVien, "TenNV", "MaNV", string.Empty, "TenNV", rm.GetString("NhanVien", CMSUser._culture), 0);
                gridViewData.Columns["MaNV"].ColumnEdit = repositoryItemLookUpEditNhanVien;
                #endregion

                #region Nhân viên làm phụ
                DataTable dtNhanVienPhu = BL_System.GetNhanVien();
                AppDevExpressEditControl.InitRepositoryItemCheckedComboBoxEdit(repositoryItemCheckedComboBoxEditLamPhu, dtNhanVienPhu, "TenNV", "MaNV", string.Empty, rm.GetString("ChonTatCa", CMSUser._culture), ';');
                gridViewData.Columns["NguoiLamPhu"].ColumnEdit = repositoryItemCheckedComboBoxEditLamPhu;
                #endregion

                #region Tình trạng File
                DataTable dtTinhTrang = BL_System.GetTinhTrangFile();
                AppDevExpressEditControl.InitRepositoryItemLookUpEdit(repositoryItemLookUpEditTinhTrang, dtTinhTrang, "TenTinhTrang", "MaTT", string.Empty, "TenTinhTrang", rm.GetString("TinhTrang", CMSUser._culture), 0);
                gridViewData.Columns["MaTT"].ColumnEdit = repositoryItemLookUpEditTinhTrang;
                #endregion
                DiemGridView();

                // 1: Trống, 2: Hủy, 3: Gấp
                StyleFormatCondition FileTrong = new StyleFormatCondition();
                FileTrong.Appearance.BackColor = Color.Aqua;
                FileTrong.Appearance.Options.UseBackColor = true;
                FileTrong.Condition = FormatConditionEnum.Expression;
                FileTrong.Expression = "[MaTT] = 1";
                gridViewData.FormatConditions.Add(FileTrong);

                StyleFormatCondition FileHuy = new StyleFormatCondition();
                FileHuy.Appearance.BackColor = Color.DarkOrchid;
                FileHuy.Appearance.Options.UseBackColor = true;
                FileHuy.Condition = FormatConditionEnum.Expression;
                FileHuy.Expression = "[MaTT] = 2";
                gridViewData.FormatConditions.Add(FileHuy);

                StyleFormatCondition FileGap = new StyleFormatCondition();
                FileGap.Appearance.BackColor = Color.Yellow;
                FileGap.Appearance.Options.UseBackColor = true;
                FileGap.Condition = FormatConditionEnum.Expression;
                FileGap.Expression = "[MaTT] = 3";
                gridViewData.FormatConditions.Add(FileGap);


                //gridViewData.Columns["DetailFile"].ColumnEdit = repositoryItemButtonEditFile;

                //gridViewData.Columns["DispatchDate"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
                //gridViewData.Columns["DispatchDate"].DisplayFormat.FormatString = "dd/MM/yyyy";

                //gridViewData.Columns["ConfirmDate"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
                //gridViewData.Columns["ConfirmDate"].DisplayFormat.FormatString = "dd/MM/yyyy HH:mm:ss";

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
        private void Ngaythang()
        {
            // Tạo và cấu hình RepositoryItemTextEdit
            RepositoryItemTextEdit timeEdit = new RepositoryItemTextEdit();
            timeEdit.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Simple;
            timeEdit.Mask.EditMask = "99:99"; // Định dạng hh:mm (2 chữ số, dấu ":" ở giữa)
            timeEdit.Mask.UseMaskAsDisplayFormat = true; // Hiển thị theo định dạng đã chỉ định

            // Cấm nhập ký tự không phải số hoặc dấu ":"
            timeEdit.KeyPress += (s, e) =>
            {
                // Chỉ cho phép nhập các ký tự số và dấu ":"
                if (!Char.IsDigit(e.KeyChar) && e.KeyChar != ':')
                {
                    e.Handled = true; // Ngừng xử lý nếu nhập ký tự không hợp lệ
                }
            };

            // Áp dụng RepositoryItemTextEdit cho cột trong GridView
            gridViewData.Columns["ThoiGianTiepNhanCty"].ColumnEdit = timeEdit;
            gridViewData.Columns["ThoiGianHoanThanhCty"].ColumnEdit = timeEdit;
            gridViewData.Columns["ThoiGianTiepNhanKH"].ColumnEdit = timeEdit;
            gridViewData.Columns["ThoiGianHoanThanh_L1"].ColumnEdit = timeEdit;
            gridViewData.Columns["ThoiGianHoanThanh_L2"].ColumnEdit = timeEdit;
            gridViewData.Columns["ThoiGianHoanThanh_L3"].ColumnEdit = timeEdit;
            gridViewData.Columns["ThoiGianHoanThanh_L4"].ColumnEdit = timeEdit;
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
                        strXml += "<QuanLyFile ID = \"" + dr["ID"].ToString()
                            + "\" MaDH = \"" + dr["MaDH"].ToString()
                            + "\" MaKH = \"" + lookUpEditKhachHang.EditValue.ToString()
                            + "\" MaNV = \"" + dr["MaNV"].ToString()
                            + "\" NgayTiepNhanCty = \"" + (dr["NgayTiepNhanCty"] == DBNull.Value ? string.Empty : Convert.ToDateTime(dr["NgayTiepNhanCty"]).ToString("dd/MM/yyyy"))
                            + "\" ThoiGianTiepNhanCty = \"" + dr["ThoiGianTiepNhanCty"].ToString()
                            + "\" NgayHoanThanhCty = \"" + (dr["NgayHoanThanhCty"] == DBNull.Value ? string.Empty : Convert.ToDateTime(dr["NgayHoanThanhCty"]).ToString("dd/MM/yyyy"))
                            + "\" ThoiGianHoanThanhCty = \"" + dr["ThoiGianHoanThanhCty"].ToString()
                            + "\" NgayTiepNhanKH = \"" + (dr["NgayTiepNhanKH"] == DBNull.Value ? string.Empty : Convert.ToDateTime(dr["NgayTiepNhanKH"]).ToString("dd/MM/yyyy"))
                            + "\" ThoiGianTiepNhanKH = \"" + dr["ThoiGianTiepNhanKH"].ToString()
                            + "\" NgayHoanThanh_L1 = \"" + (dr["NgayHoanThanh_L1"] == DBNull.Value ? string.Empty : Convert.ToDateTime(dr["NgayHoanThanh_L1"]).ToString("dd/MM/yyyy"))
                            + "\" ThoiGianHoanThanh_L1 = \"" + dr["ThoiGianHoanThanh_L1"].ToString()
                            + "\" NgayHoanThanh_L2 = \"" + (dr["NgayHoanThanh_L2"] == DBNull.Value ? string.Empty : Convert.ToDateTime(dr["NgayHoanThanh_L2"]).ToString("dd/MM/yyyy"))
                            + "\" ThoiGianHoanThanh_L2 = \"" + dr["ThoiGianHoanThanh_L2"].ToString()
                            + "\" NgayHoanThanh_L3 = \"" + (dr["NgayHoanThanh_L3"] == DBNull.Value ? string.Empty : Convert.ToDateTime(dr["NgayHoanThanh_L3"]).ToString("dd/MM/yyyy"))
                            + "\" ThoiGianHoanThanh_L3 = \"" + dr["ThoiGianHoanThanh_L3"].ToString()
                            + "\" NgayHoanThanh_L4 = \"" + (dr["NgayHoanThanh_L4"] == DBNull.Value ? string.Empty : Convert.ToDateTime(dr["NgayHoanThanh_L4"]).ToString("dd/MM/yyyy"))
                            + "\" ThoiGianHoanThanh_L4 = \"" + dr["ThoiGianHoanThanh_L4"].ToString()
                            + "\" TenNV_Import = \"" + dr["TenNV_Import"].ToString()
                            + "\" HoanThanh = \"" + dr["HoanThanh"].ToString()
                            + "\" TinhTrang = \"" + dr["MaTT"].ToString()
                            + "\" NguoiLamPhu = \"" + dr["NguoiLamPhu"].ToString()
                            + "\" Diem = \"" + dr["Diem"].ToString()
                            + "\"/>";
                    }
                }

                if (strXml == "")
                    return;

                strXml = "<Root>" + strXml + "</Root>";

                int result = BL_ManageDegreeAndCertificate.SaveTemplateSession(strXml, CMSUser._UserID);

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
                    strXml += "<QuanLyFile ID = \"" + gridViewData.GetDataRow(i)["ID"].ToString()
                            + "\"/>";
                }
                strXml = "<Root>" + strXml + "</Root>";

                int result = BL_ManageDegreeAndCertificate.DeleteTemplateType(strXml, CMSUser._UserID);

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
            string selectedMaDon = lookUpEditKhachHang.Text;  // Lấy mã đơn được chọn từ giao diện người dùng
            OpenMaDonForm(lookUpEditKhachHang.EditValue.ToString() ,lookUpEditKhachHang.Text);
        }

        private void gridViewData_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            if (e.RowHandle >= 0)
                e.Info.DisplayText = (e.RowHandle + 1).ToString();
        }

        private void btnExcel_Click(object sender, EventArgs e)
        {
            cmsExcel.Show(Cursor.Position.X, Cursor.Position.Y);
        }

        private void xToolStripMenuItemXuatExcel_Click(object sender, EventArgs e)
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



        private void importExcelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                SystemConfiguration.frm_CMS_ImportExcel f = new SystemConfiguration.frm_CMS_ImportExcel();
                f._sChucNang = "QLVBCC-QLVBCC-QuanLyFile";
                f.ShowDialog();

                if (f._isAccepted == true)
                {
                    btn_LocDuLieu_Click(null, null);

                    DataTable dtExcelMapping = f._dtExcelMapping.Copy();

                    foreach (DataRow dr in f._dtResult.Rows)
                    {
                        DataRow newRow = _dtData.NewRow();

                        foreach (DataRow drE in dtExcelMapping.Rows)
                        {
                            try
                            {
                                if (_dtData.Columns[drE["ID"].ToString()].DataType.Name.ToString() == "Boolean")
                                {
                                    if (dr[drE["ColumnMapping"].ToString()].ToString() == "x" || dr[drE["ColumnMapping"].ToString()].ToString() == "1")
                                        newRow[drE["ID"].ToString()] = true;
                                    else
                                        newRow[drE["ID"].ToString()] = false;
                                }
                                else
                                {
                                    newRow[drE["ID"].ToString()] = dr[drE["ColumnMapping"].ToString()];
                                }
                            }
                            catch { }
                        }

                        newRow["MaKH"] = lookUpEditKhachHang.EditValue.ToString();

                        _dtData.Rows.Add(newRow);
                    }
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, rm.GetString("TieuDeThongBao", CMSUser._culture), MessageBoxButtons.OK, MessageBoxIcon.Information);
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
        #endregion
    }
}