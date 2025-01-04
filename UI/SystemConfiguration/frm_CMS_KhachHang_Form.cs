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
using System.Linq;
using DevExpress.XtraGrid.Views.Grid;

namespace CMSUI.SystemConfiguration
{
    public partial class frm_CMS_KhachHang_Form : DevExpress.XtraEditors.XtraForm
    {
        #region Variables
        DataTable _dtData = new DataTable();
        string _luoiHienThi = string.Empty;
        int tiepNhan = 0, hoanThanh = 0, nhanFile = 0, lanDau = 0;
        public string MaKH = string.Empty, TenKH = string.Empty;

        ResourceManager rm;
        #endregion

        #region Inits
        public frm_CMS_KhachHang_Form()
        {
            InitializeComponent();
            
            SetLanguage();
        }

        private void frm_CMS_GridColumn_Load(object sender, EventArgs e)
        {
            #region Phân quyền
            if(CMSUser._UserGroup == "AM")
            {
                layoutControlItemSave.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
                layoutControlItemDelete.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
                layoutControlItem15.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
                layoutControlItem7.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
                layoutControlItem8.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
                layoutControlItem2.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
                layoutControlItemTrangThai.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
                layoutControlItem1.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
                layoutControlItemThoiGian.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
                layoutControlItem5.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
                layoutControlItem3.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
                layoutControlItem4.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
                layoutControlItem6.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
                gridViewData.OptionsBehavior.Editable = true;
            }else
            {
                gridViewData.OptionsBehavior.Editable = false;
            }
     

            CommonFunctions.SetFormPermiss(this);
            #endregion
            PopulateLookUpEdit();
            PopulateLookUpEditNam();
            GetTrangThai();
            gridViewData.NewItemRowText = "Mới";
            dateEditThoiGian.EditValue = DateTime.Now;
            dateEditThoiGian.Properties.EditMask = "HH:mm dd-MM-yyyy"; // Định dạng ngày giờ: Năm-Tháng-Ngày Giờ:Phút
            dateEditThoiGian.Properties.DisplayFormat.FormatString = "HH:mm dd-MM-yyyy";
            dateEditThoiGian.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            dateEditThoiGian.Properties.EditFormat.FormatString = "HH:mm dd-MM-yyyy";
            dateEditThoiGian.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;

            // Bật chế độ chọn giờ
            dateEditThoiGian.Properties.VistaDisplayMode = DevExpress.Utils.DefaultBoolean.True;
            dateEditThoiGian.Properties.VistaEditTime = DevExpress.Utils.DefaultBoolean.True; // Hiển thị giao diện chọn giờ
            btnFilter_Click(null, null);
        }
        #endregion

        #region Functions
        private void SetLanguage()
        {
            rm = new ResourceManager("CMSUI.Lang.MyResource", typeof(frm_CMS_GridColumn).Assembly);

            btnClose.Text = rm.GetString("btnClose", CMSUser._culture);
            btnSave.Text = rm.GetString("btnSave", CMSUser._culture);
            btnDelete.Text = rm.GetString("btnDelete", CMSUser._culture);
            btnExcel.Text = rm.GetString("ExportExcel", CMSUser._culture);
        }
        private void PopulateLookUpEdit()
        {
            // Tạo danh sách dữ liệu từ 1 đến 12, định dạng dưới dạng "01", "02", ...
            var dataSource = Enumerable.Range(1, 12)
                                       .Select(x => new { DisplayValue = x.ToString("D2"), Value = x }) // D2 để hiển thị dưới dạng 01, 02, ...
                                       .ToList();

            // Gắn dữ liệu vào LookUpEdit
            lookUpEditThang.Properties.DataSource = dataSource;
            lookUpEditThang.Properties.DisplayMember = "DisplayValue"; // Cột hiển thị
            lookUpEditThang.Properties.ValueMember = "Value";         // Cột giá trị

            // Cấu hình cột hiển thị
            lookUpEditThang.Properties.Columns.Clear(); // Xóa các cột cũ (nếu có)
            lookUpEditThang.Properties.Columns.Add(new DevExpress.XtraEditors.Controls.LookUpColumnInfo("DisplayValue", "Tháng"));

            // Điều chỉnh chiều rộng của popup
            lookUpEditThang.Properties.PopupWidth = 100;

            // Thiết lập giá trị mặc định (nếu cần)
            lookUpEditThang.EditValue = DateTime.Now.Month; // Giá trị ban đầu là tháng hiện tại
        }
        private void PopulateLookUpEditNam()
        {
            int currentYear = DateTime.Now.Year;

            // Tạo danh sách dữ liệu từ 1 đến 12, định dạng dưới dạng "01", "02", ...
            var dataSource = Enumerable.Range(2024, 4) // 2024 -> 2027
                             .Select(x => new { DisplayValue = x.ToString(), Value = x })
                             .ToList();

            // Gắn dữ liệu vào LookUpEdit
            lookUpEditNam.Properties.DataSource = dataSource;
            lookUpEditNam.Properties.DisplayMember = "DisplayValue"; // Cột hiển thị
            lookUpEditNam.Properties.ValueMember = "Value";         // Cột giá trị

            // Cấu hình cột hiển thị
            lookUpEditNam.Properties.Columns.Clear(); // Xóa các cột cũ (nếu có)
            lookUpEditNam.Properties.Columns.Add(new DevExpress.XtraEditors.Controls.LookUpColumnInfo("DisplayValue", "Năm"));

            // Điều chỉnh chiều rộng của popup
            lookUpEditNam.Properties.PopupWidth = 100;

            // Thiết lập giá trị mặc định (nếu cần)
            lookUpEditNam.EditValue = currentYear; // Giá trị ban đầu là năm hiện tại
        }
        private void GetTrangThai()
        {
            try
            {
                DataTable dtTinhTrang = BL_System.GetTinhTrangFile();
                AppDevExpressEditControl.InitLookUpEdit(lookUpEditTrangThai, dtTinhTrang, "TenTinhTrang", "MaTinhTrang", string.Empty, "TenTinhTrang", rm.GetString("layoutControlItemTinhTrang", CMSUser._culture), 0);
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, rm.GetString("TieuDeThongBao", CMSUser._culture), MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                string _ngayThang = lookUpEditThang.Text + '/' + lookUpEditNam.Text;
                _dtData = BL_ManageDegreeAndCertificate.GetQuanLyFile_KH(MaKH, _ngayThang, CMSUser._UserID);
                if (CMSUser._UserGroup == "AM")
                {
                    _dtData.Columns.Add("DetailFile", typeof(string));
                }

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
                if (CMSUser._UserGroup == "AM")
                {
                    gridViewData.Columns["DetailFile"].ColumnEdit = repositoryItemButtonEditThemFile;

                }
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
                AppDevExpressEditControl.InitRepositoryItemLookUpEdit(repositoryItemLookUpEditTinhTrang, dtTinhTrang, "TenTinhTrang", "MaTinhTrang", string.Empty, "TenTinhTrang", rm.GetString("TinhTrang", CMSUser._culture), 0);
                gridViewData.Columns["MaTT"].ColumnEdit = repositoryItemLookUpEditTinhTrang;
                #endregion
                DiemGridView();

                // 1: Trống, 2: Hủy, 3: Gấp
                StyleFormatCondition FileTrong = new StyleFormatCondition();
                FileTrong.Appearance.BackColor = Color.Yellow;
                FileTrong.Appearance.Options.UseBackColor = true;
                FileTrong.Condition = FormatConditionEnum.Expression;
                FileTrong.Expression = "[MaTinhT] = 'T'";
                gridViewData.FormatConditions.Add(FileTrong);

                StyleFormatCondition FileHuy = new StyleFormatCondition();
                FileHuy.Appearance.BackColor = Color.DarkOrchid;
                FileHuy.Appearance.Options.UseBackColor = true;
                FileHuy.Condition = FormatConditionEnum.Expression;
                FileHuy.Expression = "[MaTT] = 'H'";
                gridViewData.FormatConditions.Add(FileHuy);

                StyleFormatCondition FileGap = new StyleFormatCondition();
                FileGap.Appearance.BackColor = Color.Chocolate;
                FileGap.Appearance.Options.UseBackColor = true;
                FileGap.Condition = FormatConditionEnum.Expression;
                FileGap.Expression = "[MaTT] = 'G'";
                gridViewData.FormatConditions.Add(FileGap);



                if (_drGrids["ColumnAutoWidth"].ToString() == "True")
                    gridViewData.OptionsView.ColumnAutoWidth = true;
                else
                    gridViewData.OptionsView.ColumnAutoWidth = false;

                if (_drGrids["BestFitColumns"].ToString() == "True")
                    gridViewData.BestFitColumns();

                // 1. Tổng số dòng trong lưới
                textEditTongFile.Text = _dtData.Rows.Count.ToString();

                // 2. Đếm tất cả dòng trừ những dòng có MaTT = 'H'
                textEditFileThucNhan.Text = _dtData.Select("(MaTT IS NULL OR MaTT = '') OR (MaTT <> 'H' AND MaTT <> 'T')").Length.ToString();
                textEditTongFileTH.Text = _dtData.Select("MaTT = 'H' OR MaTT = 'T'").Length.ToString();

                // 3. Đếm tất cả dòng trừ những dòng có MaTT = 'H' và HoanThanh = 1
                textEditFileHoanThanh.Text = _dtData.Select("((MaTT IS NULL OR MaTT = '') OR (MaTT <> 'H' AND MaTT <> 'T')) AND HoanThanh = 1").Length.ToString();

                // 4. Đếm tất cả dòng trừ những dòng có MaTT = 'H' và HoanThanh = 0
                textEditFileChuaHoanThanh.Text = _dtData.Select("((MaTT IS NULL OR MaTT = '') OR (MaTT <> 'H' AND MaTT <> 'T')) AND HoanThanh = 0").Length.ToString();

                gridViewData.ClearColumnsFilter();
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
                string nam = new string(lookUpEditNam.Text.Reverse().Take(2).Reverse().ToArray());
                string thang = lookUpEditThang.Text;

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
                            //+ "\" MaDH = \"" + MaKH + nam + thang +  dr["MaDH"].ToString().PadLeft(4, '0')
                            + "\" MaDH = \"" + dr["MaDH"].ToString()
                            + "\" MaKH = \"" + MaKH
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

                //switch (result)
                //{
                //    case 0:
                //        GetData();
                //        XtraMessageBox.Show(rm.GetString("ThanhCong", CMSUser._culture), rm.GetString("TieuDeThongBao", CMSUser._culture), MessageBoxButtons.OK, MessageBoxIcon.Information);
                //        break;
                //    case 1:
                //        XtraMessageBox.Show(rm.GetString("TonTai", CMSUser._culture), rm.GetString("TieuDeThongBao", CMSUser._culture), MessageBoxButtons.OK, MessageBoxIcon.Warning);
                //        break;
                //    default:
                //        XtraMessageBox.Show(rm.GetString("KhongThanhCong", CMSUser._culture), rm.GetString("TieuDeThongBao", CMSUser._culture), MessageBoxButtons.OK, MessageBoxIcon.Error);
                //        break;
                //}
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "Trùng mã đơn hàng", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DeleteData()
        {
            try
            {
              
                    if (XtraMessageBox.Show(rm.GetString("XoaDuLieu?", CMSUser._culture),
                                rm.GetString("TieuDeThongBao", CMSUser._culture), MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.Cancel)
                        return;
       
                    SystemConfiguration.frm_CMS_ConfirmPassword frm = new SystemConfiguration.frm_CMS_ConfirmPassword();
                    frm.ShowDialog();

                    if (frm._confirm == false)
                        return;
                

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
            //GetData();
            Ngaythang();
        }

        private void gridViewData_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            if (e.RowHandle >= 0)
                e.Info.DisplayText = (e.RowHandle + 1).ToString();
            GridView view = sender as GridView;

            // Kiểm tra nếu là dòng gợi ý để thêm mới
            if (view.IsNewItemRow(e.RowHandle))
            {
                // Vẽ nền tùy chỉnh
                e.Appearance.BackColor = Color.LightPink;  // Màu nền
                e.Appearance.ForeColor = Color.DarkRed;    // Màu chữ
                e.Appearance.Font = new Font(e.Appearance.Font, FontStyle.Bold); // Font chữ đậm

                // Vẽ lại dòng
                e.Appearance.DrawBackground(e.Cache, e.Bounds);
                e.Appearance.DrawString(e.Cache, view.NewItemRowText, e.Bounds);

                // Hủy vẽ mặc định
                e.Handled = true;
            }
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
                    btnFilter_Click(null, null);

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

                        //newRow["MaKH"] = lookUpEditKhachHang.EditValue.ToString();

                        _dtData.Rows.Add(newRow);
                    }
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, rm.GetString("TieuDeThongBao", CMSUser._culture), MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void checkEditTiepNhan_CheckedChanged(object sender, EventArgs e)
        {
            if (checkEditTiepNhan.Checked == true)
            {
                tiepNhan = 1;
            }
            else
            {
                tiepNhan = 0;
            }
        }

        private void checkButtonDongY_Click(object sender, EventArgs e)
        {
            DateTime selectedDateTime = (DateTime)dateEditThoiGian.EditValue;

            string ngayThangNam = selectedDateTime.ToString("dd-MM-yyyy");
            string gioPhut = selectedDateTime.ToString("HH:mm");
            try
            {
                dateEditThoiGian.EditValue.ToString();
                foreach (int i in gridViewData.GetSelectedRows())
                {
                    if (hoanThanh == 1)
                    {
                        gridViewData.GetDataRow(i)["NgayHoanThanhCty"] = ngayThangNam;
                        gridViewData.GetDataRow(i)["ThoiGianHoanThanhCty"] = gioPhut;
                    }
                    if (nhanFile == 1)
                    {
                        gridViewData.GetDataRow(i)["NgayTiepNhanKH"] = ngayThangNam;
                        gridViewData.GetDataRow(i)["ThoiGianTiepNhanKH"] = gioPhut;
                    }
                    if (tiepNhan == 1)
                    {
                        gridViewData.GetDataRow(i)["NgayTiepNhanCty"] = ngayThangNam;
                        gridViewData.GetDataRow(i)["ThoiGianTiepNhanCty"] = gioPhut;
                    }
                    if (lanDau == 1)
                    {
                        gridViewData.GetDataRow(i)["NgayHoanThanh_L1"] = ngayThangNam;
                        gridViewData.GetDataRow(i)["ThoiGianHoanThanh_L1"] = gioPhut;
                    }
                }

                gridViewData.RefreshData();
            }
            catch { }
        }

        private void checkButtonHuy_Click(object sender, EventArgs e)
        {
            try
            {
                dateEditThoiGian.EditValue.ToString();
                foreach (int i in gridViewData.GetSelectedRows())
                {
                    if (hoanThanh == 1)
                    {
                        gridViewData.GetDataRow(i)["NgayHoanThanhCty"] = DBNull.Value;
                        gridViewData.GetDataRow(i)["ThoiGianHoanThanhCty"] = DBNull.Value;
                    }
                    if (nhanFile == 1)
                    {
                        gridViewData.GetDataRow(i)["NgayTiepNhanKH"] = DBNull.Value;
                        gridViewData.GetDataRow(i)["ThoiGianTiepNhanKH"] = DBNull.Value;
                    }
                    if (tiepNhan == 1)
                    {
                        gridViewData.GetDataRow(i)["NgayTiepNhanCty"] = DBNull.Value;
                        gridViewData.GetDataRow(i)["ThoiGianTiepNhanCty"] = DBNull.Value;
                    }
                    if (lanDau == 1)
                    {
                        gridViewData.GetDataRow(i)["NgayHoanThanh_L1"] = DBNull.Value;
                        gridViewData.GetDataRow(i)["ThoiGianHoanThanh_L1"] = DBNull.Value;
                    }
                }

                gridViewData.RefreshData();
            }
            catch { }
        }

        private void checkButtonDongY1_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                foreach (int i in gridViewData.GetSelectedRows())
                {

                    gridViewData.GetDataRow(i)["MaTT"] = lookUpEditTrangThai.EditValue.ToString();

                }

                gridViewData.RefreshData();
            }
            catch { }
        }

        private void checkButtonHuy1_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                foreach (int i in gridViewData.GetSelectedRows())
                {

                    gridViewData.GetDataRow(i)["MaTT"] = DBNull.Value;

                }

                gridViewData.RefreshData();
            }
            catch { }
        }

        private void frm_CMS_File_KeyDown(object sender, KeyEventArgs e)
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

        private void textEdit1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true; // Chặn ký tự không hợp lệ
            }
        }


        private void simpleButtonThemMoi_Click(object sender, EventArgs e)
        {
                string nam = new string(lookUpEditNam.Text.Reverse().Take(2).Reverse().ToArray());
                string thang = lookUpEditThang.Text;
                string kytudau = MaKH + nam + thang;
                frm_CMS_ThemMoiDonHang frm = new frm_CMS_ThemMoiDonHang();
                frm.ShowDialog();
                if (frm._confirm == true)
                {

                    int result = BL_ManageDegreeAndCertificate.SaveDonHang(MaKH, kytudau, Int16.Parse(frm.SoLuong), CMSUser._UserID);
                    try
                    {
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

            }

        private void repositoryItemButtonEditThemFile_ButtonClick(object sender, ButtonPressedEventArgs e)
        {
            frm_CMS_ThemMoiDonHang frm = new frm_CMS_ThemMoiDonHang();
            frm.ShowDialog();
            if (frm._confirm == true)
            {

                int result = BL_ManageDegreeAndCertificate.SaveTrungDonHang(MaKH, gridViewData.GetFocusedDataRow()["MaDH"].ToString(), Int16.Parse(frm.SoLuong), CMSUser._UserID);
                try
                {
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
        }

        private void gridViewData_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            SaveData();
        }

        private void checkButton1_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (int i in gridViewData.GetSelectedRows())
                {

                    gridViewData.GetDataRow(i)["MaTT"] = lookUpEditTrangThai.EditValue.ToString();

                }

                gridViewData.RefreshData();
            }
            catch { }
        }

        private void btnFilter_Click(object sender, EventArgs e)
        {
            GetData();
            Ngaythang();
        }

        private void checkEditHoanThanh_CheckedChanged(object sender, EventArgs e)
        {
            if (checkEditHoanThanh.Checked == true)
            {
                hoanThanh = 1;
            }
            else
            {
                hoanThanh = 0;
            }
        }
        private void checkEditLanDau_CheckedChanged(object sender, EventArgs e)
        {
            if (checkEditLanDau.Checked == true)
            {
                lanDau = 1;
            }
            else
            {
                lanDau = 0;
            }
        }
        private void checkEditNhanFile_CheckedChanged(object sender, EventArgs e)
        {
            if (checkEditNhanFile.Checked == true)
            {
                nhanFile = 1;
            }
            else
            {
                nhanFile = 0;
            }
        }
        #endregion


    }
}