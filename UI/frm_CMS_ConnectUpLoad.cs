using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using System.IO;
using CMSCore.BLL;
using System.Resources;

namespace CMSUI
{
    public partial class frm_CMS_ConnectUpLoad : DevExpress.XtraEditors.XtraForm
    {
        #region Variables
        public string _configType = string.Empty;

        ResourceManager rm;
        #endregion

        #region Inits
        public frm_CMS_ConnectUpLoad()
        {
            InitializeComponent();

            SetLanguage();
        }

        private void frm_CMS_ConnectUpLoad_Load(object sender, EventArgs e)
        {
            switch (_configType)
            {
                case "PhuLuc":
                    txtDomain.Text = CMSUser._DomainName;
                    txtServerName.Text = CMSUser._IPLocalServer;
                    txtTenDangNhap.Text = CMSUser._UserNameLocalServer;
                    txtMatKhau.Text = CMSUser._PasswordLocalServer;
                    txtThuMuc.Text = CMSUser._LocationLocalServer;
                    break;
                case "QuyetDinh":
                    txtDomain.Text = CMSUser._DomainNameDecision;
                    txtServerName.Text = CMSUser._IPLocalServerDecision;
                    txtTenDangNhap.Text = CMSUser._UserNameLocalServerDecision;
                    txtMatKhau.Text = CMSUser._PasswordLocalServerDecision;
                    txtThuMuc.Text = CMSUser._LocationLocalServerDecision;
                    break;
                default:
                    txtDomain.Text = CMSUser._DomainNameCertificate;
                    txtServerName.Text = CMSUser._IPLocalServerCertificate;
                    txtTenDangNhap.Text = CMSUser._UserNameLocalServerCertificate;
                    txtMatKhau.Text = CMSUser._PasswordLocalServerCertificate;
                    txtThuMuc.Text = CMSUser._LocationLocalServerCertificate;
                    break;
            }
        }
        #endregion

        #region Functions
        private void SetLanguage()
        {
            rm = new ResourceManager("CMSUI.Lang.MyResource", typeof(frm_CMS_ConnectUpLoad).Assembly);

            btnClose.Text = rm.GetString("btnClose", CMSUser._culture);
            btnSave.Text = rm.GetString("btnSave", CMSUser._culture);

            layoutControlItemProvider.Text = rm.GetString("layoutControlItemProvider", CMSUser._culture);
            layoutControlItemServerName.Text = rm.GetString("layoutControlItemServerName", CMSUser._culture);
            layoutControlItemUserName.Text = rm.GetString("layoutControlItemUserName", CMSUser._culture);
            layoutControlItemPassword.Text = rm.GetString("layoutControlItemPassword", CMSUser._culture);
            layoutControlItemFolder.Text = rm.GetString("layoutControlItemFolder", CMSUser._culture);
        }
        #endregion

        #region Events
        private void btn_finish_Click(object sender, EventArgs e)
        {
            try
            {
                switch (_configType)
                {
                    case "PhuLuc":
                        BL_System.UpdateSystemConfig("DomainName", txtDomain.Text, CMSUser._UserID);
                        BL_System.UpdateSystemConfig("IPLocalServer", txtServerName.Text, CMSUser._UserID);
                        BL_System.UpdateSystemConfig("UserNameLocalServer", txtTenDangNhap.Text, CMSUser._UserID);
                        BL_System.UpdateSystemConfig("PasswordLocalServer", CommonFunctions.EncodeString(txtMatKhau.Text), CMSUser._UserID);
                        BL_System.UpdateSystemConfig("LocationLocalServer", txtThuMuc.Text, CMSUser._UserID);

                        CMSUser._DomainName = txtDomain.Text;
                        CMSUser._IPLocalServer = txtServerName.Text;
                        CMSUser._UserNameLocalServer = txtTenDangNhap.Text;
                        CMSUser._PasswordLocalServer = txtMatKhau.Text;
                        CMSUser._LocationLocalServer = txtThuMuc.Text;
                        break;
                    case "QuyetDinh":
                        BL_System.UpdateSystemConfig("DomainNameDecision", txtDomain.Text, CMSUser._UserID);
                        BL_System.UpdateSystemConfig("IPLocalServerDecision", txtServerName.Text, CMSUser._UserID);
                        BL_System.UpdateSystemConfig("UserNameLocalServerDecision", txtTenDangNhap.Text, CMSUser._UserID);
                        BL_System.UpdateSystemConfig("PasswordLocalServerDecision", CommonFunctions.EncodeString(txtMatKhau.Text), CMSUser._UserID);
                        BL_System.UpdateSystemConfig("LocationLocalServerDecision", txtThuMuc.Text, CMSUser._UserID);

                        CMSUser._DomainNameDecision = txtDomain.Text;
                        CMSUser._IPLocalServerDecision = txtServerName.Text;
                        CMSUser._UserNameLocalServerDecision = txtTenDangNhap.Text;
                        CMSUser._PasswordLocalServerDecision = txtMatKhau.Text;
                        CMSUser._LocationLocalServerDecision = txtThuMuc.Text;
                        break;
                    default:
                        BL_System.UpdateSystemConfig("DomainNameCertificate", txtDomain.Text, CMSUser._UserID);
                        BL_System.UpdateSystemConfig("IPLocalServerCertificate", txtServerName.Text, CMSUser._UserID);
                        BL_System.UpdateSystemConfig("UserNameLocalServerCertificate", txtTenDangNhap.Text, CMSUser._UserID);
                        BL_System.UpdateSystemConfig("PasswordLocalServerCertificate", CommonFunctions.EncodeString(txtMatKhau.Text), CMSUser._UserID);
                        BL_System.UpdateSystemConfig("LocationLocalServerCertificate", txtThuMuc.Text, CMSUser._UserID);

                        CMSUser._DomainNameCertificate = txtDomain.Text;
                        CMSUser._IPLocalServerCertificate = txtServerName.Text;
                        CMSUser._UserNameLocalServerCertificate = txtTenDangNhap.Text;
                        CMSUser._PasswordLocalServerCertificate = txtMatKhau.Text;
                        CMSUser._LocationLocalServerCertificate = txtThuMuc.Text;
                        break;
                }

                
                XtraMessageBox.Show(rm.GetString("ThanhCong", CMSUser._culture), rm.GetString("TieuDeThongBao", CMSUser._culture), MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch { }
        }

        private void btn_close_Click(object sender, EventArgs e)
        {
            this.Close();
        }        
        #endregion
    }
}