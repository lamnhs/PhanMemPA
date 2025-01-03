using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Resources;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraBars;
using DevExpress.XtraEditors;
using System.IO;
using System.Xml;
using System.Globalization;
using CMSCore.BLL;
using CMSDevExpressCommon;

namespace CMSUI
{
    public partial class rfrm_CMS_Main : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        #region Variables
        public static rfrm_CMS_Main me;

        public static int _pageCount;
        public static string _userName = string.Empty, _passwordUser = string.Empty;

        public DataTable dtGroup = new DataTable();
        private bool _firstGraduateLevels = true, _firstStudyTypes = true;
        static ResourceManager rm;
        #endregion

        #region Inits
        public rfrm_CMS_Main()
        {
            InitializeComponent();
            LoadConfig();
        }

        private void rfrm_CMS_Main_Load(object sender, EventArgs e)
        {
            LoadConfig();

            if (CMSUser._UserID.Length > 0)
               Login(true);

        }
        #endregion

        #region Functions
        private void SetLanguage()
        {
            rm = new ResourceManager("CMSUI.Lang.MyResource", typeof(rfrm_CMS_Main).Assembly);

            #region Menu and BarButtonItem
            foreach (DevExpress.XtraBars.Ribbon.RibbonPage rPage in ribbonCMSControl.Pages)
            {
                rPage.Text = rm.GetString(rPage.Name, CMSUser._culture);
                foreach (DevExpress.XtraBars.Ribbon.RibbonPageGroup gPage in rPage.Groups)
                {
                    gPage.Text = rm.GetString(gPage.Name, CMSUser._culture);
                    foreach (BarItemLink barItemLink in gPage.ItemLinks)
                        barItemLink.Item.Caption = rm.GetString(barItemLink.Item.Name, CMSUser._culture);
                }
            }
            #endregion

            #region Layout, Button And Menu
            barToggleSwitchItemVietnamese.Caption = rm.GetString("TiengViet", CMSUser._culture);
            barStaticItemEnglish.Caption = rm.GetString("TiengAnh", CMSUser._culture);
            skinRibbonGalleryBarItemInterfate.Caption = rm.GetString("skinRibbonGalleryBarItemInterfate", CMSUser._culture);

            layoutControlItemUserName.Text = rm.GetString("TenDangNhap", CMSUser._culture);
            layoutControlItemPassword.Text = rm.GetString("MatKhau", CMSUser._culture);
            btnLogin.Text = rm.GetString("DangNhap", CMSUser._culture);
            btnExitApplication.Text = rm.GetString("ThoatUngDung", CMSUser._culture);

            layoutControlItemCurrentUser.Text = rm.GetString("TenDangNhap", CMSUser._culture);
            layoutControlItemDate.Text = rm.GetString("NgayHienTai", CMSUser._culture);
           

            FileInfo f = new FileInfo(Application.StartupPath + @"\XIN_FANG_YIN.exe");
            //this.Text = String.Format("{0} - {2} ({1:dd/MM/yyyy HH:mm:ss})", rm.GetString("rfrm_CMS_Main", CMSUser._culture), f.LastWriteTime, CMSUser._foreignLanguageInterface == true ? CMSUser._EnglishCollegeName.ToUpper() : CMSUser._CollegeName.ToUpper());

            this.Text = String.Format("{0} - {1}", rm.GetString("rfrm_CMS_Main", CMSUser._culture), "V24.4");

            mnuCloseAll.Text = rm.GetString("DongTatCa", CMSUser._culture);
            mnuCloseAllButThis.Text = rm.GetString("DongCuaSoKhac", CMSUser._culture);
            mnuCloseThis.Text = rm.GetString("DongCuaSoNay", CMSUser._culture);

            butCauHinhUpLoad.Caption = rm.GetString("butCauHinhUpLoad", CMSUser._culture);
            barButtonItemQuyetDinh.Caption = rm.GetString("barButtonItemQuyetDinh", CMSUser._culture);
            barButtonItemVanBang.Caption = rm.GetString("barButtonItemVanBang", CMSUser._culture);
            #endregion
        }

        public void LoadConfig()
        {
            try
            {
                //Lay thong tin cau hinh may
                string pathApp = Application.StartupPath;
                if (System.IO.File.Exists(pathApp + "\\CMS_Config.xml"))
                {
                    XmlDocument doc = new XmlDocument();
                    XmlNode node;
                    doc.Load(pathApp + "\\CMS_Config.xml");
                    node = doc.SelectSingleNode("appSettings");

                    //Phân Quyền mới
                    bool phanQuyenMoi = false;
                    bool.TryParse(node.Attributes["PhanQuyenMoi"].Value.ToString(), out phanQuyenMoi);
                    CMSUser._TCT_DungModulePhanQuyenMoi = phanQuyenMoi;
                    //-----------------------------------------------------------------------------------------------

                    //Code multi languages
                    bool english = false;
                    bool.TryParse(node.Attributes["English"].Value.ToString(), out english);
                    CMSUser._foreignLanguageInterface = english;
                    barToggleSwitchItemVietnamese.Checked = !english;
                    SetLanguage();
                    //-----------------------------------------------------------------------------------------------

                    CMSCore.Provider._connectionString = CommonFunctions.DecodeString(node.Attributes["ConnectionString"].Value.ToString(), true);
                    CMSCore.Provider._provider = node.Attributes["ProviderName"].Value.ToString();
                    CMSCore.Provider._userID = CMSUser._UserID;

                    CMSCore.SqlHelper help = new CMSCore.SqlHelper(CMSCore.Provider._connectionString);
                    if (!help.CheckConnection())
                    {
                        frm_CMS_ConnectDatabase frm = new frm_CMS_ConnectDatabase();
                        frm.ShowDialog();
                    }
                }
                else
                {
                    frm_CMS_ConnectDatabase frm = new frm_CMS_ConnectDatabase();
                    frm.ShowDialog();
                }
            }
            catch { }
        }

        public void Login(bool auto)
        {
            if (auto)
            {
                txtUserName.Text = CMSUser._UserID;
                txtPassword.Text = CMSUser._UserPass;
            }

            if (txtUserName.Text == String.Empty)
            {
                XtraMessageBox.Show(rm.GetString("ChuaNhapTenDangNhap", CMSUser._culture), rm.GetString("TieuDeThongBao", CMSUser._culture), MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
                LoadLock();
        }

        public void LoadLock()
        {
            string strFalse = "";

            try
            {
                CMSCore.Provider._userID = txtUserName.Text.Trim();

                string rv = BL_System.LockUser(txtUserName.Text);

                if (!rv.Contains("..."))
                {
                    txtUserName.Focus();
                    strFalse = rm.GetString(rv, CMSUser._culture) + "\n" + rm.GetString("LienHeQuanTri", CMSUser._culture);
                    XtraMessageBox.Show(strFalse, rm.GetString("TieuDeThongBao", CMSUser._culture), MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    dtGroup = BL_System.GetGroupUserByStaffID(txtUserName.Text);
                    if (dtGroup.Rows.Count == 0)
                    {
                        txtUserName.Focus();
                        XtraMessageBox.Show(rm.GetString("KhongCoNhom", CMSUser._culture) + "\n" + rm.GetString("LienHeQuanTri", CMSUser._culture),
                            rm.GetString("TieuDeThongBao", CMSUser._culture), MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                    if (dtGroup.Rows.Count != 0)
                    {
                        string password = CommonFunctions.EncodeMD5(txtUserName.Text.Trim(), txtPassword.Text.Trim());
                        int result = BL_System.Login(txtUserName.Text, password);
                        if (result != 0)
                        {
                            txtUserName.Focus();
                            XtraMessageBox.Show(rm.GetString("KhongThanhCong", CMSUser._culture) + "\n" + rm.GetString("LienHeQuanTri", CMSUser._culture),
                                rm.GetString("TieuDeThongBao", CMSUser._culture), MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        else
                        {
                            DataTable dtUserInfo = BL_System.GetStaffs(txtUserName.Text.Trim());
                            CMSUser._UserID = txtUserName.Text.Trim();
                            CMSUser._dtUserGroups = dtGroup.Copy();

                            foreach (DataRow dr in dtGroup.Rows)
                            {
                                if (CMSUser._UserGroup == string.Empty)
                                    CMSUser._UserGroup = dr["GroupID"].ToString();
                                else
                                    CMSUser._UserGroup = CMSUser._UserGroup + ";" + dr["GroupID"].ToString();
                            }

                            CMSCore.Provider._userID = txtUserName.Text.Trim();
                            CMSUser._UserName = CMSUser._foreignLanguageData == true ? dtUserInfo.Rows[0]["EnglishStaffName"].ToString() : dtUserInfo.Rows[0]["StaffName"].ToString();
                            CMSUser._UserPass = txtPassword.Text;
                            Init();
                            groupControlLogin.Dispose();
                        }
                    }
                }
                if (CMSUser._UserGroup == "AM")
                {
                    barButtonItemGrid.Visibility = BarItemVisibility.Always;
                    barButtonItemGridColumn.Visibility = BarItemVisibility.Always;
                    barButtonItemNhanVien.Visibility = BarItemVisibility.Always;
                    barButtonItemKhachHang.Visibility = BarItemVisibility.Always;
                    barButtonItemQuanLyFile.Visibility = BarItemVisibility.Always;
                    barButtonItemThongKeSoLuong.Visibility = BarItemVisibility.Always;
                    barButtonItemQuanLyNguoiDung.Visibility = BarItemVisibility.Always;
                }
                else
                {
                    barButtonItemQuanLyFile.Visibility = BarItemVisibility.Always;
                }

            }
            catch (Exception err)       
            {
                XtraMessageBox.Show(err.Message, rm.GetString("TieuDeThongBao", CMSUser._culture), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void LoadLockPhanQuyenMoi()
        {
            XtraMessageBox.Show(rm.GetString("DangXuLy", CMSUser._culture), rm.GetString("TieuDeThongBao", CMSUser._culture), MessageBoxButtons.OK, MessageBoxIcon.Error);
            Application.Exit();
        }

        public static void GetDataSet()
        {
            try
            {
                CMSUser._dsDataDictionaries = new DataSet();
                DataSet ds = new DataSet();

                if (CMSUser._TCT_DungModulePhanQuyenMoi == true)
                {
                    XtraMessageBox.Show(rm.GetString("DangXuLy", CMSUser._culture), rm.GetString("TieuDeThongBao", CMSUser._culture), MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Application.Exit();
                }
                else
                {
                    ds = BL_System.GetDataSetDataDictionary(CMSUser._UserID);
                }

                if (ds.Tables.Count == 0)
                {
                    XtraMessageBox.Show(rm.GetString("KhongTheKetNoi", CMSUser._culture), rm.GetString("TieuDeThongBao", CMSUser._culture), MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                DataTable dtSystemConfig = ds.Tables[0].Copy();
                dtSystemConfig.TableName = "SystemConfig";
                CMSUser._dsDataDictionaries.Tables.Add(dtSystemConfig);
                
                #region Phân quyền các đối tượng trên Forms
                try
                {
                    CommonFunctions._dtDecentralizations = ds.Tables[5];
                }
                catch { }
                #endregion

                #region table "GraduateLevels"
                try
                {
                    DataTable dtGraduateLevels = ds.Tables[1].Copy();
                    dtGraduateLevels.TableName = "GraduateLevels";
                    CMSUser._dsDataDictionaries.Tables.Add(dtGraduateLevels);
                }
                catch { }
                #endregion

                #region table "StudyTypes"
                try
                {
                    DataTable dtStudyTypes = ds.Tables[2].Copy();
                    dtStudyTypes.TableName = "StudyTypes";
                    CMSUser._dsDataDictionaries.Tables.Add(dtStudyTypes);
                }
                catch { }
                #endregion

                #region table "Departments"
                try
                {
                    DataTable dtDepartments = ds.Tables[3].Copy();
                    dtDepartments.TableName = "Departments";
                    CMSUser._dsDataDictionaries.Tables.Add(dtDepartments);
                }
                catch { }
                #endregion

                #region table "Terms"
                try
                {
                    DataTable dtTerms = ds.Tables[4].Copy();
                    dtTerms.TableName = "Terms";
                    CMSUser._dsDataDictionaries.Tables.Add(dtTerms);
                }
                catch { }
                #endregion

                #region table "SystemConfigs"
                try
                {
                    DataRow[] drSelect;

                    #region CurrentYearStudy 
                    try
                    {
                        drSelect = ds.Tables[0].Select("SettingName = 'CurrentYearStudy'");
                        if (drSelect.Length != 0)
                        {
                            CMSUser._CurrentYearStudy = drSelect[0]["SettingStringData"].ToString();
                        }
                    }
                    catch
                    {
                        CMSUser._CurrentYearStudy = string.Empty;
                    }
                    #endregion

                    #region CurrentTerm
                    try
                    {
                        drSelect = ds.Tables[0].Select("SettingName = 'CurrentTerm'");
                        if (drSelect.Length != 0)
                        {
                            CMSUser._CurrentTerm = drSelect[0]["SettingStringData"].ToString();
                        }
                    }
                    catch
                    {
                        CMSUser._CurrentTerm = string.Empty;
                    }
                    #endregion

                    #region GraduateLevelID
                    try
                    {
                        drSelect = ds.Tables[0].Select("SettingName = 'GraduateLevelID'");
                        if (drSelect.Length != 0)
                        {
                            CMSUser._CurrentGraduateLevelID = drSelect[0]["SettingStringData"].ToString();
                        }
                    }
                    catch
                    {
                        CMSUser._CurrentGraduateLevelID = string.Empty;
                    }
                    #endregion

                    #region StudyTypeID
                    try
                    {
                        drSelect = ds.Tables[0].Select("SettingName = 'StudyTypeID'");
                        if (drSelect.Length != 0)
                        {
                            CMSUser._CurrentStudyTypeID = drSelect[0]["SettingStringData"].ToString();
                        }
                    }
                    catch
                    {
                        CMSUser._CurrentStudyTypeID = string.Empty;
                    }
                    #endregion

                    #region CollegeName
                    try
                    {
                        drSelect = ds.Tables[0].Select("SettingName = 'TenTruong'");
                        if (drSelect.Length != 0)
                            CMSUser._CollegeName = drSelect[0]["SettingStringData"].ToString();
                    }
                    catch
                    {
                        CMSUser._CollegeName = string.Empty;
                    }
                    #endregion

                    #region EnglishCollegeName
                    try
                    {
                        drSelect = ds.Tables[0].Select("SettingName = 'TenTruongTiengAnh'");
                        if (drSelect.Length != 0)
                            CMSUser._EnglishCollegeName = drSelect[0]["SettingStringData"].ToString();
                    }
                    catch
                    {
                        CMSUser._EnglishCollegeName = string.Empty;
                    }
                    #endregion

                    #region AdministrativeUnitName
                    try
                    {
                        drSelect = ds.Tables[0].Select("SettingName = 'AdministrativeUnit'");
                        if (drSelect.Length != 0)
                            CMSUser._AdministrativeUnitName = drSelect[0]["SettingStringData"].ToString();
                    }
                    catch
                    {
                        CMSUser._AdministrativeUnitName = string.Empty;
                    }
                    #endregion

                    #region EnglishAdministrativeUnitName
                    try
                    {
                        drSelect = ds.Tables[0].Select("SettingName = 'EnglishAdministrativeUnit'");
                        if (drSelect.Length != 0)
                            CMSUser._EnglishAdministrativeUnitName = drSelect[0]["SettingStringData"].ToString();
                    }
                    catch
                    {
                        CMSUser._EnglishAdministrativeUnitName = string.Empty;
                    }
                    #endregion

                    #region CollegeLogo
                    try
                    {
                        drSelect = ds.Tables[0].Select("SettingName = 'CollegeLogo'");
                        if (drSelect.Length != 0)
                            CMSUser._CollegeLogo = (byte[]) drSelect[0]["SettingStringData"];
                    }
                    catch
                    {
                        CMSUser._CollegeLogo = null;
                    }
                    #endregion

                    #region HoiLaiKhiLuu
                    try
                    {
                        drSelect = ds.Tables[0].Select("SettingName = 'HoiLaiKhiLuu'");
                        if (drSelect.Length != 0)
                        {
                            CMSUser._HoiLaiKhiLuu =  bool.Parse(drSelect[0]["SettingStringData"].ToString());
                        }
                    }
                    catch
                    {
                        CMSUser._HoiLaiKhiLuu = true;
                    }
                    #endregion

                    #region HoiLaiKhiXoa
                    try
                    {
                        drSelect = ds.Tables[0].Select("SettingName = 'HoiLaiKhiXoa'");
                        if (drSelect.Length != 0)
                        {
                            CMSUser._HoiLaiKhiXoa = bool.Parse(drSelect[0]["SettingStringData"].ToString());
                        }
                    }
                    catch
                    {
                        CMSUser._HoiLaiKhiXoa = true;
                    }
                    #endregion

                    #region XacNhanMatKhauKhiLuu
                    try
                    {
                        drSelect = ds.Tables[0].Select("SettingName = 'XacNhanMatKhauKhiLuu'");
                        if (drSelect.Length != 0)
                        {
                            CMSUser._XacNhanMatKhauKhiLuu = bool.Parse(drSelect[0]["SettingStringData"].ToString());
                        }
                    }
                    catch
                    {
                        CMSUser._XacNhanMatKhauKhiLuu = true;
                    }
                    #endregion

                    #region XacNhanMatKhauKhiXoa
                    try
                    {
                        drSelect = ds.Tables[0].Select("SettingName = 'XacNhanMatKhauKhiXoa'");
                        if (drSelect.Length != 0)
                        {
                            CMSUser._XacNhanMatKhauKhiXoa = bool.Parse(drSelect[0]["SettingStringData"].ToString());
                        }
                    }
                    catch
                    {
                        CMSUser._XacNhanMatKhauKhiXoa = true;
                    }
                    #endregion

                    #region Lưu file phụ lục văn bằng
                    #region IPLocalServer 
                    try
                    {
                        drSelect = ds.Tables[0].Select("SettingName = 'IPLocalServer'");
                        if (drSelect.Length != 0)
                        {
                            CMSUser._IPLocalServer = drSelect[0]["SettingStringData"].ToString();
                        }
                    }
                    catch
                    {
                        CMSUser._IPLocalServer = string.Empty;
                    }
                    #endregion

                    #region DomainName 
                    try
                    {
                        drSelect = ds.Tables[0].Select("SettingName = 'DomainName'");
                        if (drSelect.Length != 0)
                        {
                            CMSUser._DomainName = drSelect[0]["SettingStringData"].ToString();
                        }
                    }
                    catch
                    {
                        CMSUser._DomainName = string.Empty;
                    }
                    #endregion

                    #region UserNameLocalServer 
                    try
                    {
                        drSelect = ds.Tables[0].Select("SettingName = 'UserNameLocalServer'");
                        if (drSelect.Length != 0)
                        {
                            CMSUser._UserNameLocalServer = drSelect[0]["SettingStringData"].ToString();
                        }
                    }
                    catch
                    {
                        CMSUser._UserNameLocalServer = string.Empty;
                    }
                    #endregion

                    #region PasswordLocalServer 
                    try
                    {
                        drSelect = ds.Tables[0].Select("SettingName = 'PasswordLocalServer'");
                        if (drSelect.Length != 0)
                        {
                            CMSUser._PasswordLocalServer = CommonFunctions.DecodeString(drSelect[0]["SettingStringData"].ToString());
                        }
                    }
                    catch
                    {
                        CMSUser._PasswordLocalServer = string.Empty;
                    }
                    #endregion

                    #region LocationLocalServer 
                    try
                    {
                        drSelect = ds.Tables[0].Select("SettingName = 'LocationLocalServer'");
                        if (drSelect.Length != 0)
                        {
                            CMSUser._LocationLocalServer = drSelect[0]["SettingStringData"].ToString();
                        }
                    }
                    catch
                    {
                        CMSUser._LocationLocalServer = string.Empty;
                    }
                    #endregion
                    #endregion

                    #region Lưu file quyết định
                    #region IPLocalServerDecision 
                    try
                    {
                        drSelect = ds.Tables[0].Select("SettingName = 'IPLocalServerDecision'");
                        if (drSelect.Length != 0)
                        {
                            CMSUser._IPLocalServerDecision = drSelect[0]["SettingStringData"].ToString();
                        }
                    }
                    catch
                    {
                        CMSUser._IPLocalServerDecision = string.Empty;
                    }
                    #endregion

                    #region DomainNameDecision
                    try
                    {
                        drSelect = ds.Tables[0].Select("SettingName = 'DomainNameDecision'");
                        if (drSelect.Length != 0)
                        {
                            CMSUser._DomainNameDecision = drSelect[0]["SettingStringData"].ToString();
                        }
                    }
                    catch
                    {
                        CMSUser._DomainNameDecision = string.Empty;
                    }
                    #endregion

                    #region UserNameLocalServerDecision
                    try
                    {
                        drSelect = ds.Tables[0].Select("SettingName = 'UserNameLocalServerDecision'");
                        if (drSelect.Length != 0)
                        {
                            CMSUser._UserNameLocalServerDecision = drSelect[0]["SettingStringData"].ToString();
                        }
                    }
                    catch
                    {
                        CMSUser._UserNameLocalServerDecision = string.Empty;
                    }
                    #endregion

                    #region PasswordLocalServerDecision 
                    try
                    {
                        drSelect = ds.Tables[0].Select("SettingName = 'PasswordLocalServerDecision'");
                        if (drSelect.Length != 0)
                        {
                            CMSUser._PasswordLocalServerDecision = CommonFunctions.DecodeString(drSelect[0]["SettingStringData"].ToString());
                        }
                    }
                    catch
                    {
                        CMSUser._PasswordLocalServerDecision = string.Empty;
                    }
                    #endregion

                    #region LocationLocalServerDecision 
                    try
                    {
                        drSelect = ds.Tables[0].Select("SettingName = 'LocationLocalServerDecision'");
                        if (drSelect.Length != 0)
                        {
                            CMSUser._LocationLocalServerDecision = drSelect[0]["SettingStringData"].ToString();
                        }
                    }
                    catch
                    {
                        CMSUser._LocationLocalServerDecision = string.Empty;
                    }
                    #endregion 
                    #endregion

                    #region Lưu file bằng, chứng chỉ
                    #region IPLocalServerCertificate 
                    try
                    {
                        drSelect = ds.Tables[0].Select("SettingName = 'IPLocalServerCertificate'");
                        if (drSelect.Length != 0)
                        {
                            CMSUser._IPLocalServerCertificate = drSelect[0]["SettingStringData"].ToString();
                        }
                    }
                    catch
                    {
                        CMSUser._IPLocalServerCertificate = string.Empty;
                    }
                    #endregion

                    #region DomainNameCertificate
                    try
                    {
                        drSelect = ds.Tables[0].Select("SettingName = 'DomainNameCertificate'");
                        if (drSelect.Length != 0)
                        {
                            CMSUser._DomainNameCertificate = drSelect[0]["SettingStringData"].ToString();
                        }
                    }
                    catch
                    {
                        CMSUser._DomainNameCertificate = string.Empty;
                    }
                    #endregion

                    #region UserNameLocalServerCertificate
                    try
                    {
                        drSelect = ds.Tables[0].Select("SettingName = 'UserNameLocalServerCertificate'");
                        if (drSelect.Length != 0)
                        {
                            CMSUser._UserNameLocalServerCertificate = drSelect[0]["SettingStringData"].ToString();
                        }
                    }
                    catch
                    {
                        CMSUser._UserNameLocalServerCertificate = string.Empty;
                    }
                    #endregion

                    #region PasswordLocalServerCertificate
                    try
                    {
                        drSelect = ds.Tables[0].Select("SettingName = 'PasswordLocalServerCertificate'");
                        if (drSelect.Length != 0)
                        {
                            CMSUser._PasswordLocalServerCertificate = CommonFunctions.DecodeString(drSelect[0]["SettingStringData"].ToString());
                        }
                    }
                    catch
                    {
                        CMSUser._PasswordLocalServerCertificate = string.Empty;
                    }
                    #endregion

                    #region LocationLocalServerCertificate 
                    try
                    {
                        drSelect = ds.Tables[0].Select("SettingName = 'LocationLocalServerCertificate'");
                        if (drSelect.Length != 0)
                        {
                            CMSUser._LocationLocalServerCertificate = drSelect[0]["SettingStringData"].ToString();
                        }
                    }
                    catch
                    {
                        CMSUser._LocationLocalServerCertificate = string.Empty;
                    }
                    #endregion 

                    #region FormatDateOfSign
                    try
                    {
                        drSelect = ds.Tables[0].Select("SettingName = 'ConvertNgayKyVN'");
                        if (drSelect.Length != 0)
                        {
                            CMSUser._FormatDateOfSign = drSelect[0]["SettingStringData"].ToString();
                        }
                    }
                    catch
                    {
                        CMSUser._FormatDateOfSign = "dd/MM/yyyy";
                    }
                    #endregion

                    #region FormatDate
                    try
                    {
                        drSelect = ds.Tables[0].Select("SettingName = 'ConvertNgaySinhVN'");
                        if (drSelect.Length != 0)
                        {
                            CMSUser._FormatDate = drSelect[0]["SettingStringData"].ToString();
                        }
                    }
                    catch
                    {
                        CMSUser._FormatDate = "dd/MM/yyyy";
                    }
                    #endregion

                    #region FormatEngDate
                    try
                    {
                        drSelect = ds.Tables[0].Select("SettingName = 'ConvertNgaySinhEng'");
                        if (drSelect.Length != 0)
                        {
                            CMSUser._FormatEngDate = drSelect[0]["SettingStringData"].ToString();
                        }
                    }
                    catch
                    {
                        CMSUser._FormatEngDate = "dd MMMM yyyy";
                    }
                    #endregion
                    #endregion
                }
                catch { }
                #endregion

                #region table "Khoa"
                DataTable dtKhoa = new DataTable();

                try
                {
                    dtKhoa.Columns.Add("DepartmentID", typeof(string));
                    dtKhoa.Columns.Add("DepartmentName", typeof(string));
                    foreach (DataRow dr in CMSUser._dsDataDictionaries.Tables["Departments"].Rows)
                    {
                        if (dr["Parent"].ToString() == string.Empty)
                            dtKhoa.Rows.Add(new object[] { dr["DepartmentID"].ToString(), dr["DepartmentName"].ToString() });
                    }
                }
                catch
                {
                    dtKhoa = new DataTable();
                }

                dtKhoa.TableName = "Khoa";
                CMSUser._dsDataDictionaries.Tables.Add(dtKhoa);
                #endregion
            }
            catch { }
        }

        //private void GetGraduateLevels()
        //{
        //    try
        //    {
        //        DataTable _dtGraduateLevels = CMSUser._dsDataDictionaries.Tables["GraduateLevels"].Copy();
        //        AppDevExpressEditControl.InitCheckedComboBoxEdit(checkedComboBoxEditAcademicLevel, _dtGraduateLevels, "GraduateLevelName", "GraduateLevelID", string.Empty, rm.GetString("ChonTatCa", CMSUser._culture), ';', false);
        //    }
        //    catch { }
        //}

        //private void GetStudyTypes()
        // {
        //    try
        //    {
        //        DataTable _dtStudyTypes = CMSUser._dsDataDictionaries.Tables["StudyTypes"].Copy();
        //        AppDevExpressEditControl.InitCheckedComboBoxEdit(checkedComboBoxEditModeOfStudy, _dtStudyTypes, "StudyTypeName", "StudyTypeID", string.Empty, rm.GetString("ChonTatCa", CMSUser._culture), ';', false);
        //    }
        //    catch { }
        //}

        void LayThongTin()
        {
            try
            {
                
                txtDate.Text = string.Empty;
                txtUserName.Text = string.Empty;
                barButtonItemCurrentUserName.Caption = string.Empty;
                barButtonItemChangeYearStudyAndTerms.Caption = string.Empty;

              
         

                try
                {
                    switch (DateTime.Now.DayOfWeek)
                    {
                        case DayOfWeek.Monday:
                            txtDate.Text = rm.GetString("ThuHai", CMSUser._culture) + ", " + DateTime.Now.Day.ToString() + " /" + DateTime.Now.Month.ToString() + "/" + DateTime.Now.Year.ToString();
                            break;
                        case DayOfWeek.Tuesday:
                            txtDate.Text = rm.GetString("ThuBa", CMSUser._culture) + ", " + DateTime.Now.Day.ToString() + "/" + DateTime.Now.Month.ToString() + "/" + DateTime.Now.Year.ToString();
                            break;
                        case DayOfWeek.Wednesday:
                            txtDate.Text = rm.GetString("ThuTu", CMSUser._culture) + ", " + DateTime.Now.Day.ToString() + "/" + DateTime.Now.Month.ToString() + "/" + DateTime.Now.Year.ToString();
                            break;
                        case DayOfWeek.Thursday:
                            txtDate.Text = rm.GetString("ThuNam", CMSUser._culture) + ", " + DateTime.Now.Day.ToString() + "/" + DateTime.Now.Month.ToString() + "/" + DateTime.Now.Year.ToString();
                            break;
                        case DayOfWeek.Friday:
                            txtDate.Text = rm.GetString("ThuSau", CMSUser._culture) + ", " + DateTime.Now.Day.ToString() + "/" + DateTime.Now.Month.ToString() + "/" + DateTime.Now.Year.ToString();
                            break;
                        case DayOfWeek.Saturday:
                            txtDate.Text = rm.GetString("ThuBay", CMSUser._culture) + ", " + DateTime.Now.Day.ToString() + "/" + DateTime.Now.Month.ToString() + "/" + DateTime.Now.Year.ToString();
                            break;
                        case DayOfWeek.Sunday:
                            txtDate.Text = rm.GetString("ChuNhat", CMSUser._culture) + ", " + DateTime.Now.Day.ToString() + "/" + DateTime.Now.Month.ToString() + "/" + DateTime.Now.Year.ToString();
                            break;
                    }
                }
                catch { }

                try
                {
                    barButtonItemCurrentUserName.Visibility = BarItemVisibility.Always;
                    barButtonItemCurrentUserName.Enabled = true;
                    txtCurrentUser.Text = CMSUser._UserName;
                    barButtonItemCurrentUserName.Caption = CMSUser._UserName;
                }
                catch { }

                FileInfo f = new FileInfo(Application.StartupPath + @"\CMS.exe");
                //this.Text = String.Format("{0} - {2} ({1:dd/MM/yyyy HH:mm:ss})", rm.GetString("rfrm_CMS_Main", CMSUser._culture), f.LastWriteTime, CMSUser._foreignLanguageInterface == true ? CMSUser._EnglishCollegeName.ToUpper() : CMSUser._CollegeName.ToUpper());
                this.Text = String.Format("{0} - {1}", rm.GetString("rfrm_CMS_Main", CMSUser._culture), "V24.4");
            }
            catch { }
        }

        private void Init()
        {
         


            #region Phân quyền
            CommonFunctions.SetFormPermiss(ribbonCMSControl);
            #endregion

            groupControlCommonInfo.Visible = true;

            barButtonItemDefaultSave.Visibility = BarItemVisibility.Always;
            barButtonItemLogOut.Visibility = BarItemVisibility.Always;
            barButtonItemChangePassword.Visibility = BarItemVisibility.Always;

            barButtonItemDefaultSave.Enabled = true;
            barButtonItemLogOut.Enabled = true;
            barButtonItemChangePassword.Enabled = true;
            barButtonItemChangeYearStudyAndTerms.Enabled = true;
            barToggleSwitchItemVietnamese.Enabled = false;

            LayThongTin();

            #region Config form main
            if (CMSUser._UserID.ToUpper() == "UISTEAM" || CMSUser._UserID.ToUpper() == "ADMIN")
            {
                cmsRibbonPageSystem.Visible = true;

                //cmsRibbonPageExtModule.Visible = true;

            }
            else
            {
                cmsRibbonPageSystem.Visible = true;
            }
            #endregion

            //Ribbon.SelectPage(cmsRibbonPageCertificateManagement);

            me = this;
            _pageCount = 0;
        }
        #endregion

        #region Form Main Events
        private void btnExitApplication_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void txtUserName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                txtPassword.Focus();
        }

        private void txtPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                btnLogin_Click(null, null);
        }



        private void xtraTabbedMdiManager_PageAdded(object sender, DevExpress.XtraTabbedMdi.MdiTabPageEventArgs e)
        {
            try
            {
                _pageCount++;
                groupControlCommonInfo.Visible = (_pageCount == 0);

                barButtonItemChangeYearStudyAndTerms.Enabled = false;
                barButtonItemDefaultSave.Enabled = false;
                tableLayoutPanel.Visible = (_pageCount == 0);
            }
            catch { }
        }

        private void xtraTabbedMdiManager_PageRemoved(object sender, DevExpress.XtraTabbedMdi.MdiTabPageEventArgs e)
        {
            try
            {
                _pageCount--;
                tableLayoutPanel.Visible = (_pageCount == 0);

                groupControlCommonInfo.Visible = (_pageCount == 0);
                barButtonItemChangeYearStudyAndTerms.Enabled = true;
                barButtonItemDefaultSave.Enabled = true;
            }
            catch { }
        }

        private void xtraTabbedMdiManager_MouseUp(object sender, MouseEventArgs e)
        {
            try
            {
                if (e != null)
                {
                    if (e.Button == MouseButtons.Right && xtraTabbedMdiManager.SelectedPage != null)
                    {
                        Rectangle rec = xtraTabbedMdiManager.SelectedPage.TabControl.ViewInfo.SelectedTabPageViewInfo.Bounds;
                        if (e.X > rec.Left && e.X < rec.Right && e.Y > rec.Top && e.Y < rec.Bottom)
                        {
                            if (xtraTabbedMdiManager.Pages.Count == 1)
                                mnuCloseAllButThis.Enabled = false;
                            else
                                mnuCloseAllButThis.Enabled = true;
                            cmsCloseTab.Show(new Point(MousePosition.X + 3, MousePosition.Y + 3));
                        }
                    }
                }
            }
            catch { }
        }

        private void barButtonItemChangeYearStudyAndTerms_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                SystemConfiguration.frm_CMS_ChangeCurrentSemester frm = new SystemConfiguration.frm_CMS_ChangeCurrentSemester();
                frm._currentYearStudy = CMSUser._CurrentYearStudy;
                frm._currentTermID = CMSUser._CurrentTerm;
                frm.ShowDialog();
                if (frm._isSubmitted)
                {
                    CMSUser._CurrentYearStudy = frm._currentYearStudy;
                    CMSUser._CurrentTerm = frm._currentTermID;

               
                    LayThongTin();
                }
            }
            catch { }
        }

        private void mnuCloseThis_Click(object sender, EventArgs e)
        {
            try
            {
                Form frm = xtraTabbedMdiManager.SelectedPage.MdiChild as Form;
                if (frm != null)
                {
                    frm.Close();
                }
            }
            catch { }
        }

        private void mnuCloseButThis_Click(object sender, EventArgs e)
        {
            try
            {
                Form frm = xtraTabbedMdiManager.SelectedPage.MdiChild as Form;
                foreach (Form frmOther in xtraTabbedMdiManager.MdiParent.MdiChildren)
                    if (frmOther != frm)
                        frmOther.Close();
            }
            catch { }
        }

        private void mnuCloseAll_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (Form frmOther in xtraTabbedMdiManager.MdiParent.MdiChildren)
                    frmOther.Close();
            }
            catch { }
        }

        private void barToggleSwitchItemVietnamese_CheckedChanged(object sender, ItemClickEventArgs e)
        {
            if (barToggleSwitchItemVietnamese.Checked)
                CMSUser._cultureName = "vi-VN";
            else
                CMSUser._cultureName = "en-US";

            CMSUser._foreignLanguageInterface = !barToggleSwitchItemVietnamese.Checked;
            CMSUser._culture = CultureInfo.CreateSpecificCulture(CMSUser._cultureName);

            SetLanguage();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            Login(false);
        }
        #endregion

        #region Ribbon Events
        #region Hệ thống
        private void barButtonItemConfigureSystem_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (!CommonFunctions.IsFocusForm(typeof(SystemConfiguration.frm_CMS_ConfigSystem), this))
            {
                SystemConfiguration.frm_CMS_ConfigSystem f = new SystemConfiguration.frm_CMS_ConfigSystem();
                f.Text = "UIS - " + barButtonItemConfigureSystem.Caption;
                f.MdiParent = this;
                f.Show();
            }
        }

        private void barButtonItemDefaultSave_ItemClick(object sender, ItemClickEventArgs e)
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

                int result = BL_System.UpdateCurrentValues(CMSUser._UserID, CMSUser._CurrentTerm, CMSUser._CurrentYearStudy, CMSUser._CurrentGraduateLevelID, CMSUser._CurrentStudyTypeID);
                if (result == 0)
                    XtraMessageBox.Show(rm.GetString("ThanhCong", CMSUser._culture), rm.GetString("TieuDeThongBao", CMSUser._culture), MessageBoxButtons.OK, MessageBoxIcon.Information);
                else
                    XtraMessageBox.Show(rm.GetString("KhongThanhCong", CMSUser._culture), rm.GetString("TieuDeThongBao", CMSUser._culture), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, rm.GetString("TieuDeThongBao", CMSUser._culture), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void barButtonItemChangePassword_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (!CommonFunctions.IsFocusForm(typeof(SystemConfiguration.frm_CMS_ChangePassword), this))
            {
                SystemConfiguration.frm_CMS_ChangePassword f = new SystemConfiguration.frm_CMS_ChangePassword();
                f.Text = "UIS - " + barButtonItemChangePassword.Caption;
                f.MdiParent = this;
                f.Show();
            }
        }

        private void barButtonItemLogout_ItemClick(object sender, ItemClickEventArgs e)
        {
            System.Diagnostics.Process.Start(Application.ExecutablePath);
            this.Close();
        }

        private void butCauHinhUpLoad_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (!CommonFunctions.IsFocusForm(typeof(frm_CMS_ConnectUpLoad), this))
            {
                frm_CMS_ConnectUpLoad f = new frm_CMS_ConnectUpLoad();
                f.Text = "UIS - " + butCauHinhUpLoad.Caption;
                f._configType = "PhuLuc";
                f.MdiParent = this;
                f.Show();
            }
        }

        private void barButtonItemQuyetDinh_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (!CommonFunctions.IsFocusForm(typeof(frm_CMS_ConnectUpLoad), this))
            {
                frm_CMS_ConnectUpLoad f = new frm_CMS_ConnectUpLoad();
                f.Text = "UIS - " + barButtonItemQuyetDinh.Caption;
                f._configType = "QuyetDinh";
                f.MdiParent = this;
                f.Show();
            }
        }

        private void barButtonItemVanBang_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (!CommonFunctions.IsFocusForm(typeof(frm_CMS_ConnectUpLoad), this))
            {
                frm_CMS_ConnectUpLoad f = new frm_CMS_ConnectUpLoad();
                f.Text = "UIS - " + barButtonItemVanBang.Caption;
                f._configType = "VanBang";
                f.MdiParent = this;
                f.Show();
            }
        }

        private void barButtonItemObjectSource_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (!CommonFunctions.IsFocusForm(typeof(SystemConfiguration.frm_CMS_MainObjectSource), this))
            {
                SystemConfiguration.frm_CMS_MainObjectSource f = new SystemConfiguration.frm_CMS_MainObjectSource();
                f.Text = "UIS - " + barButtonItemObjectSource.Caption;
                f.MdiParent = this;
                f.Show();
            }
        }

        private void barButtonItemViewObject_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (!CommonFunctions.IsFocusForm(typeof(SystemConfiguration.frm_CMS_FormObjects), this))
            {
                SystemConfiguration.frm_CMS_FormObjects f = new SystemConfiguration.frm_CMS_FormObjects();
                f.Text = "UIS - " + barButtonItemViewObject.Caption;
                f.MdiParent = this;
                f.Show();
            }
        }

        private void barButtonItemGrid_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (!CommonFunctions.IsFocusForm(typeof(SystemConfiguration.frm_CMS_Grid), this))
            {
                SystemConfiguration.frm_CMS_Grid f = new SystemConfiguration.frm_CMS_Grid();
                f.Text = "UIS - " + barButtonItemGrid.Caption;
                f.MdiParent = this;
                f.Show();
            }
        }

        private void barButtonItemGridColumn_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (!CommonFunctions.IsFocusForm(typeof(SystemConfiguration.frm_CMS_GridColumn), this))
            {
                SystemConfiguration.frm_CMS_GridColumn f = new SystemConfiguration.frm_CMS_GridColumn();
                f.Text = "UIS - " + barButtonItemGridColumn.Caption;
                f.MdiParent = this;
                f.Show();
            }
        }

        private void barButtonItemPrintField_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (!CommonFunctions.IsFocusForm(typeof(SystemConfiguration.frm_CMS_DataField), this))
            {
                SystemConfiguration.frm_CMS_DataField f = new SystemConfiguration.frm_CMS_DataField();
                f.Text = "UIS - " + barButtonItemDataField.Caption;
                f.MdiParent = this;
                f.Show();
            }
        }      

        private void barButtonItemDegreeAndCertidicateType_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (!CommonFunctions.IsFocusForm(typeof(SystemConfiguration.frm_CMS_File), this))
            {
                SystemConfiguration.frm_CMS_File f = new SystemConfiguration.frm_CMS_File();
                f.Text = "PA - " + barButtonItemQuanLyFile.Caption;
                f.MdiParent = this;
                f.Show();
            }
        }
        #endregion

        #region Mở rộng module
        private void barButtonItemTitle_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (!CommonFunctions.IsFocusForm(typeof(Extension.frm_CMS_Title), this))
            {
                Extension.frm_CMS_Title f = new Extension.frm_CMS_Title();
                f.Text = "UIS - " + barButtonItemTitle.Caption;
                f.MdiParent = this;
                f.Show();
            }
        }

        private void barButtonItemLanguage_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (!CommonFunctions.IsFocusForm(typeof(Extension.frm_CMS_Language), this))
            {
                Extension.frm_CMS_Language f = new Extension.frm_CMS_Language();
                f.Text = "UIS - " + barButtonItemLanguage.Caption;
                f.MdiParent = this;
                f.Show();
            }
        }

        private void barButtonItemQualityStandard_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (!CommonFunctions.IsFocusForm(typeof(Extension.frm_CMS_QualityStandard), this))
            {
                Extension.frm_CMS_QualityStandard f = new Extension.frm_CMS_QualityStandard();
                f.Text = "UIS - " + barButtonItemQualityStandard.Caption;
                f.MdiParent = this;
                f.Show();
            }
        }

        private void barButtonItemNhanVien_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (!CommonFunctions.IsFocusForm(typeof(SystemConfiguration.frm_CMS_NhanVien), this))
            {
                SystemConfiguration.frm_CMS_NhanVien f = new SystemConfiguration.frm_CMS_NhanVien();
                f.Text = "PA - " + barButtonItemNhanVien.Caption;
                f.MdiParent = this;
                f.Show();
            }
        }

        private void barButtonItemThongKeSoLuong_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (!CommonFunctions.IsFocusForm(typeof(SystemConfiguration.frm_CMS_ThongKeSoLuong), this))
            {
                SystemConfiguration.frm_CMS_ThongKeSoLuong f = new SystemConfiguration.frm_CMS_ThongKeSoLuong();
                f.Text = "PA - " + barButtonItemThongKeSoLuong.Caption;
                f.MdiParent = this;
                f.Show();
            }
        }

        private void barButtonItemKhachHang_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (!CommonFunctions.IsFocusForm(typeof(SystemConfiguration.frm_CMS_KhachHang), this))
            {
                SystemConfiguration.frm_CMS_KhachHang f = new SystemConfiguration.frm_CMS_KhachHang();
                f.Text = "PA - " + barButtonItemKhachHang.Caption;
                f.MdiParent = this;
                f.Show();
            }
        }

        private void barButtonItemQuanLyNguoiDung_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (!CommonFunctions.IsFocusForm(typeof(SystemConfiguration.frm_CMS_QuanLyNguoiDung), this))
            {
                SystemConfiguration.frm_CMS_QuanLyNguoiDung f = new SystemConfiguration.frm_CMS_QuanLyNguoiDung();
                f.Text = "PA - " + barButtonItemKhachHang.Caption;
                f.MdiParent = this;
                f.Show();
            }
        }

        private void barButtonItemProgramAndTitle_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (!CommonFunctions.IsFocusForm(typeof(Extension.frm_CMS_ModifiedProgram), this))
            {
                Extension.frm_CMS_ModifiedProgram f = new Extension.frm_CMS_ModifiedProgram();
                f.Text = "UIS - " + barButtonItemProgram.Caption;
                f.MdiParent = this;
                f.Show();
            }
        }

        private void barButtonItemDanhHieuChuanXet_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (!CommonFunctions.IsFocusForm(typeof(Extension.frm_CMS_DanhHieuChuanXet), this))
            {
                Extension.frm_CMS_DanhHieuChuanXet f = new Extension.frm_CMS_DanhHieuChuanXet();
                f.Text = "UIS - " + barButtonItemDanhHieuChuanXet.Caption;
                f.MdiParent = this;
                f.Show();
            }
        }
        #endregion

        #endregion
    }
}
