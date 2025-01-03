using CMSCore.BLL;
using DevExpress.XtraEditors;
using System;
using System.Data;
using System.Drawing;
using System.IO;
using System.Resources;
using System.Windows.Forms;

namespace CMSUI.SystemConfiguration
{
    public partial class frm_CMS_ConfigSystem : DevExpress.XtraEditors.XtraForm
    {
        #region Variables
        string _TinhThanh = string.Empty, _TenTruong = string.Empty, _DVChuQuan = string.Empty;
        string _TinhThanhTiengAnh = string.Empty, _TenTruongTiengAnh = string.Empty, _DVChuQuanTiengAnh = string.Empty;
        byte[] _Image; Image Logo;
        bool _HoiLaiKhiLuu = false;
        bool _HoiLaiKhiXoa = false;
        bool _XacNhanMatKhauKhiXoa = false;
        bool _XacNhanMatKhauKhiLuu = false;
        string _ConvertNgayKyVN = string.Empty, _ConvertNgaySinhEng = string.Empty, _ConvertNgaySinhVN = string.Empty;
        bool _TraCuuKhongInBang = false;
        bool _InBanSaoKhongInBang = false;

        ResourceManager rm;
        #endregion

        #region Inits
        public frm_CMS_ConfigSystem()
        {
            InitializeComponent();

            SetLanguage();
        }

        private void frm_CMS_ConfigSystem_Load(object sender, EventArgs e)
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
            rm = new ResourceManager("CMSUI.Lang.MyResource", typeof(frm_CMS_ConfigSystem).Assembly);

            btnSave.Text = rm.GetString("btnSave", CMSUser._culture);
            btnClose.Text = rm.GetString("btnClose", CMSUser._culture);
            layoutControlItemProvince.Text = rm.GetString("TinhThanh", CMSUser._culture);
            layoutControlItemAdminUnit.Text = rm.GetString("DonViQuanLy", CMSUser._culture);
            layoutControlItemName.Text = rm.GetString("TenTruong", CMSUser._culture);
            layoutControlItemDinhDangNgayKy.Text = rm.GetString("layoutControlItemDinhDangNgayKy", CMSUser._culture);
            layoutControlItemDinhDangNgay.Text = rm.GetString("layoutControlItemDinhDangNgay", CMSUser._culture);
            layoutControlItemDinhDangNgayTiengAnh.Text = rm.GetString("layoutControlItemDinhDangNgayTiengAnh", CMSUser._culture);
            checkEdit_hoiKhiLuu.Text = rm.GetString("HoiLaiKhiLuu", CMSUser._culture);
            checkEdit_xacNhanMatKhauKhiLuu.Text = rm.GetString("XacNhanMatKhauKhiLuu", CMSUser._culture);
            checkEdit_hoiLaiKhiXoa.Text = rm.GetString("HoiLaiKhiXoa", CMSUser._culture);
            checkEdit_xacNhanMatKhauKhiXoa.Text = rm.GetString("XacNhanMatKhauKhiXoa", CMSUser._culture);
            checkEdit_TraCuuKhongCanIn.Text = rm.GetString("checkEdit_TraCuuKhongCanIn", CMSUser._culture);
        }

        private void GetData()
        {
            try
            {
                DataTable tb = new DataTable();
                tb = BL_System.GetSystemConfig();

                //Cấu hình logo trường
                try
                {
                    _Image = (byte[])(((DataRow)tb.Select("SettingName = 'CollegeLogo'").GetValue(0))["SettingBinaryData"]);
                    MemoryStream MemoryInmage = new MemoryStream(_Image);
                    pictureEditLogo.Image = Image.FromStream(MemoryInmage);
                }
                catch { }

                //Cấu hình tên trường
                try
                {
                    _TenTruong = ((DataRow)tb.Select("SettingName = 'TenTruong'").GetValue(0))["SettingStringData"].ToString();
                }
                catch { }
                txtCollegeName.Text = _TenTruong;

                try
                {
                    _TenTruongTiengAnh = ((DataRow)tb.Select("SettingName = 'TenTruongTiengAnh'").GetValue(0))["SettingStringData"].ToString();
                }
                catch { }
                txtCollegeNameEnglish.Text = _TenTruongTiengAnh;

                //Cấu hình đơn vị chủ quản
                try
                {
                    _DVChuQuan = ((DataRow)tb.Select("SettingName = 'AdministrativeUnit'").GetValue(0))["SettingStringData"].ToString();
                }
                catch { }
                txtAdminUnit.Text = _DVChuQuan;

                try
                {
                    _DVChuQuanTiengAnh = ((DataRow)tb.Select("SettingName = 'EnglishAdministrativeUnit'").GetValue(0))["SettingStringData"].ToString();
                }
                catch { }
                txtAdminUnitEnglish.Text = _DVChuQuanTiengAnh;

                //Cấu hình tỉnh thành
                try
                {
                    _TinhThanh = ((DataRow)tb.Select("SettingName = 'TinhThanh'").GetValue(0))["SettingStringData"].ToString();
                }
                catch { }
                txtProvince.Text = _TinhThanh;

                try
                {
                    _TinhThanhTiengAnh = ((DataRow)tb.Select("SettingName = 'TinhThanhTiengAnh'").GetValue(0))["SettingStringData"].ToString();
                }
                catch { }
                txtProvinceEnglish.Text = _TinhThanhTiengAnh;

                //Hỏi lại khi lưu
                try
                {
                    _HoiLaiKhiLuu = Convert.ToBoolean(((DataRow)tb.Select("SettingName = 'HoiLaiKhiLuu'").GetValue(0))["SettingStringData"].ToString());
                }
                catch { }
                checkEdit_hoiKhiLuu.Checked = _HoiLaiKhiLuu;

                //Hỏi lại mật khẩu khi lưu
                try
                {
                    _XacNhanMatKhauKhiLuu = Convert.ToBoolean(((DataRow)tb.Select("SettingName = 'XacNhanMatKhauKhiLuu'").GetValue(0))["SettingStringData"].ToString());
                }
                catch { }
                checkEdit_xacNhanMatKhauKhiLuu.Checked = _XacNhanMatKhauKhiLuu;

                //Hỏi lại khi xóa
                try
                {
                    _HoiLaiKhiXoa = Convert.ToBoolean(((DataRow)tb.Select("SettingName = 'HoiLaiKhiXoa'").GetValue(0))["SettingStringData"].ToString());
                }
                catch { }
                checkEdit_hoiLaiKhiXoa.Checked = _HoiLaiKhiXoa;

                //Hỏi lại mật khẩu khi xóa
                try
                {
                    _XacNhanMatKhauKhiXoa = Convert.ToBoolean(((DataRow)tb.Select("SettingName = 'XacNhanMatKhauKhiXoa'").GetValue(0))["SettingStringData"].ToString());
                }
                catch { }
                checkEdit_xacNhanMatKhauKhiXoa.Checked = _XacNhanMatKhauKhiXoa;

                //Định dạng ngày ký
                try
                {
                    _ConvertNgayKyVN = ((DataRow)tb.Select("SettingName = 'ConvertNgayKyVN'").GetValue(0))["SettingStringData"].ToString();
                }
                catch { }
                txtDinhDangNgayKy.Text = _ConvertNgayKyVN;

                //Định dạng ngày
                try
                {
                    _ConvertNgaySinhVN = ((DataRow)tb.Select("SettingName = 'ConvertNgaySinhVN'").GetValue(0))["SettingStringData"].ToString();
                }
                catch { }
                txtDinhDangNgay.Text = _ConvertNgaySinhVN;

                //Định dạng ngày tiếng Anh
                try
                {
                    _ConvertNgaySinhEng = ((DataRow)tb.Select("SettingName = 'ConvertNgaySinhEng '").GetValue(0))["SettingStringData"].ToString();
                }
                catch { }
                txtDinhDangNgayTiengAnh.Text = _ConvertNgaySinhEng;

                //Cho phép tra cứu không cần đã in bằng
                try
                {
                    _TraCuuKhongInBang = Convert.ToBoolean(((DataRow)tb.Select("SettingName = 'TraCuuKhongInBang'").GetValue(0))["SettingStringData"].ToString());
                }
                catch { }
                checkEdit_TraCuuKhongCanIn.Checked = _TraCuuKhongInBang;

                //Cho phép in bản sao không cần đã in bằng
                try
                {
                    _InBanSaoKhongInBang = Convert.ToBoolean(((DataRow)tb.Select("SettingName = 'InBanSaoKhongInBang'").GetValue(0))["SettingStringData"].ToString());
                }
                catch { }
                checkEdit_InBanSaoKhongCanIn.Checked = _InBanSaoKhongInBang;
            }
            catch { }
        }

        private void SaveData()
        {
            try
            {
                if (XtraMessageBox.Show(rm.GetString("LuuDuLieu?", CMSUser._culture),
                            rm.GetString("TieuDeThongBao", CMSUser._culture), MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.Cancel)
                    return;

                frm_CMS_ConfirmPassword frm = new frm_CMS_ConfirmPassword();
                frm.ShowDialog();

                if (frm._confirm == false)
                    return;

                int result = 0;

                try
                {
                    // Cập nhật logo
                    MemoryStream ms = new MemoryStream();
                    result = BL_System.UpdateSystemConfig_Logo("CollegeLogo", "CollegeLogo", _Image, CMSUser._UserID);
                    if (result != 0)
                    {
                        XtraMessageBox.Show(rm.GetString("KhongThanhCong", CMSUser._culture),
                            rm.GetString("TieuDeThongBao", CMSUser._culture), MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
                catch { }

                // Cập nhật tên trường
                if (txtCollegeName.Text != _TenTruong || txtCollegeNameEnglish.Text != _TenTruongTiengAnh)
                {
                    result = BL_System.UpdateSystemConfig("TenTruong", txtCollegeName.Text, CMSUser._UserID);
                    result = BL_System.UpdateSystemConfig("TenTruongTiengAnh", txtCollegeNameEnglish.Text, CMSUser._UserID);
                    if (result != 0)
                    {
                        XtraMessageBox.Show(rm.GetString("KhongThanhCong", CMSUser._culture),
                            rm.GetString("TieuDeThongBao", CMSUser._culture), MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    else
                    {
                        CMSUser._CollegeName = txtCollegeName.Text;
                        CMSUser._EnglishCollegeName = txtCollegeNameEnglish.Text;
                    }
                }

                // Cập nhật đơn vị chủ quản
                if (txtAdminUnit.Text != _DVChuQuan || txtAdminUnitEnglish.Text != _DVChuQuanTiengAnh)
                {
                    result = BL_System.UpdateSystemConfig("AdministrativeUnit", txtAdminUnit.Text, CMSUser._UserID);
                    result = BL_System.UpdateSystemConfig("EnglishAdministrativeUnit", txtAdminUnitEnglish.Text, CMSUser._UserID);
                    if (result != 0)
                    {
                        XtraMessageBox.Show(rm.GetString("KhongThanhCong", CMSUser._culture),
                            rm.GetString("TieuDeThongBao", CMSUser._culture), MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }

                // Cập nhật tỉnh thành
                if (txtProvince.Text != _TinhThanh || txtProvinceEnglish.Text != _TinhThanhTiengAnh)
                {
                    result = BL_System.UpdateSystemConfig("TinhThanhTiengAnh", txtProvinceEnglish.Text, CMSUser._UserID);
                    result = BL_System.UpdateSystemConfig("TinhThanh", txtProvince.Text, CMSUser._UserID);
                    if (result != 0)
                    {
                        XtraMessageBox.Show(rm.GetString("KhongThanhCong", CMSUser._culture),
                            rm.GetString("TieuDeThongBao", CMSUser._culture), MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }

                //Hỏi lại khi lưu
                if (checkEdit_hoiKhiLuu.Checked != _HoiLaiKhiLuu)
                {
                    result = BL_System.UpdateSystemConfig("HoiLaiKhiLuu", checkEdit_hoiKhiLuu.Checked.ToString(), CMSUser._UserID);
                    if (result != 0)
                    {
                        XtraMessageBox.Show(rm.GetString("KhongThanhCong", CMSUser._culture),
                            rm.GetString("TieuDeThongBao", CMSUser._culture), MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    else
                        CMSUser._HoiLaiKhiLuu = checkEdit_hoiKhiLuu.Checked;
                }

                //Hỏi lại mật khẩu khi lưu
                if (checkEdit_xacNhanMatKhauKhiLuu.Checked != _XacNhanMatKhauKhiLuu)
                {
                    result = BL_System.UpdateSystemConfig("XacNhanMatKhauKhiLuu", checkEdit_xacNhanMatKhauKhiLuu.Checked.ToString(), CMSUser._UserID);
                    if (result != 0)
                    {
                        XtraMessageBox.Show(rm.GetString("KhongThanhCong", CMSUser._culture),
                            rm.GetString("TieuDeThongBao", CMSUser._culture), MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    else
                        CMSUser._XacNhanMatKhauKhiLuu = checkEdit_xacNhanMatKhauKhiLuu.Checked;
                }

                //Hỏi lại khi xóa
                if (checkEdit_hoiLaiKhiXoa.Checked != _HoiLaiKhiXoa)
                {
                    result = BL_System.UpdateSystemConfig("HoiLaiKhiXoa", checkEdit_hoiLaiKhiXoa.Checked.ToString(), CMSUser._UserID);
                    if (result != 0)
                    {
                        XtraMessageBox.Show(rm.GetString("KhongThanhCong", CMSUser._culture),
                            rm.GetString("TieuDeThongBao", CMSUser._culture), MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    else
                        CMSUser._HoiLaiKhiXoa = checkEdit_hoiLaiKhiXoa.Checked;
                }

                //Hỏi lại mật khẩu khi xóa
                if (checkEdit_xacNhanMatKhauKhiXoa.Checked != _XacNhanMatKhauKhiXoa)
                {
                    result = BL_System.UpdateSystemConfig("XacNhanMatKhauKhiXoa", checkEdit_xacNhanMatKhauKhiXoa.Checked.ToString(), CMSUser._UserID);
                    if (result != 0)
                    {
                        XtraMessageBox.Show(rm.GetString("KhongThanhCong", CMSUser._culture),
                            rm.GetString("TieuDeThongBao", CMSUser._culture), MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    else
                        CMSUser._XacNhanMatKhauKhiXoa = checkEdit_xacNhanMatKhauKhiXoa.Checked;
                }

                // Định dạng ngày ký
                if (txtDinhDangNgayKy.Text != _ConvertNgayKyVN)
                {
                    result = BL_System.UpdateSystemConfig("ConvertNgayKyVN", txtDinhDangNgayKy.Text, CMSUser._UserID);
                    if (result != 0)
                    {
                        XtraMessageBox.Show(rm.GetString("KhongThanhCong", CMSUser._culture),
                            rm.GetString("TieuDeThongBao", CMSUser._culture), MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    else
                        CMSUser._FormatDateOfSign = txtDinhDangNgayKy.Text;
                }

                // Định dạng ngày
                if (txtDinhDangNgay.Text != _ConvertNgaySinhVN)
                {
                    result = BL_System.UpdateSystemConfig("ConvertNgaySinhVN", txtDinhDangNgay.Text, CMSUser._UserID);
                    if (result != 0)
                    {
                        XtraMessageBox.Show(rm.GetString("KhongThanhCong", CMSUser._culture),
                            rm.GetString("TieuDeThongBao", CMSUser._culture), MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    else
                        CMSUser._FormatDate = txtDinhDangNgay.Text;
                }

                // Định dạng ngày tiếng Anh
                if (txtDinhDangNgayTiengAnh.Text != _ConvertNgaySinhEng)
                {
                    result = BL_System.UpdateSystemConfig("ConvertNgaySinhEng", txtDinhDangNgayTiengAnh.Text, CMSUser._UserID);
                    if (result != 0)
                    {
                        XtraMessageBox.Show(rm.GetString("KhongThanhCong", CMSUser._culture),
                            rm.GetString("TieuDeThongBao", CMSUser._culture), MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    else
                        CMSUser._FormatEngDate = txtDinhDangNgayTiengAnh.Text;
                }

                //Cho phép tra cứu không cần đã in bằng
                if (checkEdit_TraCuuKhongCanIn.Checked != _TraCuuKhongInBang)
                {
                    result = BL_System.UpdateSystemConfig("TraCuuKhongInBang", checkEdit_TraCuuKhongCanIn.Checked.ToString(), CMSUser._UserID);
                    if (result != 0)
                    {
                        XtraMessageBox.Show(rm.GetString("KhongThanhCong", CMSUser._culture),
                            rm.GetString("TieuDeThongBao", CMSUser._culture), MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }

                //Cho phép in bản sao không cần đã in bằng
                if (checkEdit_InBanSaoKhongCanIn.Checked != _InBanSaoKhongInBang)
                {
                    result = BL_System.UpdateSystemConfig("InBanSaoKhongInBang", checkEdit_InBanSaoKhongCanIn.Checked.ToString(), CMSUser._UserID);
                    if (result != 0)
                    {
                        XtraMessageBox.Show(rm.GetString("KhongThanhCong", CMSUser._culture),
                            rm.GetString("TieuDeThongBao", CMSUser._culture), MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }

                GetData();
                XtraMessageBox.Show(rm.GetString("ThanhCong", CMSUser._culture), rm.GetString("TieuDeThongBao", CMSUser._culture), MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, rm.GetString("TieuDeThongBao", CMSUser._culture), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion

        #region Events
        private void btn_thoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pictureEdit_Logo_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog_Logo = new OpenFileDialog();

            openFileDialog_Logo.InitialDirectory = "C:\\";
            openFileDialog_Logo.Filter = "Image files (*.gif, *.png, *.jpg)|*.gif; *.png; *.jpg|All files (*.*)|*.*";
            openFileDialog_Logo.FilterIndex = 2;
            openFileDialog_Logo.RestoreDirectory = true;

            if (openFileDialog_Logo.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    Logo = Image.FromFile(openFileDialog_Logo.FileName);
                    pictureEditLogo.Image = Logo;
                    MemoryStream mStream = new MemoryStream();
                    Logo.Save(mStream, Logo.RawFormat);
                    _Image = mStream.ToArray();
                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show(ex.Message, rm.GetString("TieuDeThongBao", CMSUser._culture), MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btn_luuDuLieu_Click(object sender, EventArgs e)
        {
            SaveData();
        }

        private void btn_thoat_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                if (CMSUser._UserID.ToUpper() == "UISTEAM")
                {
                    string s = CMSCore.Provider._connectionString;
                    int index = s.LastIndexOf("=");
                    string s1 = s.Substring(index + 1);

                    string newstring = s.Replace(s1, "******");
                    XtraMessageBox.Show(newstring, rm.GetString("TieuDeThongBao", CMSUser._culture), MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }
        #endregion
    }
}