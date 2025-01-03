using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CMSCore.BLL;
using DevExpress.XtraEditors;
using System.Resources;

namespace CMSUI.SystemConfiguration
{
    public partial class frm_CMS_ChangePassword : Form
    {
        #region Variable
        public string _UserID = string.Empty;
        public string _UserPass = string.Empty;
        ResourceManager rm;
        #endregion

        #region Inits
        public frm_CMS_ChangePassword()
        {
            InitializeComponent();

            SetLanguage();
        } 

        private void frm_CMS_ChangePassword_Load(object sender, EventArgs e)
        {
            #region Phân quyền
            CommonFunctions.SetFormPermiss(this);
            #endregion

            try
            {
                txtUserName.Text = CMSUser._UserName;
                txtOldPassword.Focus();
            }
            catch { }
        }
        #endregion

        #region Functions
        private void SetLanguage()
        {
            rm = new ResourceManager("CMSUI.Lang.MyResource", typeof(frm_CMS_ChangePassword).Assembly);

            this.Text = rm.GetString("DoiMatKhau", CMSUser._culture);
            btnSaveAndClose.Text = rm.GetString("btnSaveAndClose", CMSUser._culture);
            btnClose.Text = rm.GetString("btnClose", CMSUser._culture);
            layoutControlItemUserName.Text = rm.GetString("TenDangNhap", CMSUser._culture);
            layoutControlItemOldPassword.Text = rm.GetString("MatKhauCu", CMSUser._culture);
            layoutControlItemNewPassword.Text = rm.GetString("MatKhau", CMSUser._culture);
            layoutControlItemConfirmPassword.Text = rm.GetString("XacNhanMatKhau", CMSUser._culture);
        }

        public void ChangePassword()
        {
            try
            {
                string OldPassword = txtOldPassword.Text.Trim();
                string NewPassword = txtNewPassword.Text.Trim();
                string ConfirmNewPassword = txtConfirmPassword.Text.Trim();

                if (NewPassword != ConfirmNewPassword)
                {
                    XtraMessageBox.Show(rm.GetString("KhongKhopXacNhanMatKhau", CMSUser._culture), rm.GetString("TieuDeThongBao", CMSUser._culture), MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    string result = BL_System.ChangePassword(CMSUser._UserID, CommonFunctions.EncodeMD5(CMSUser._UserID, NewPassword), CommonFunctions.EncodeMD5(CMSUser._UserID, OldPassword));

                    if (result.Contains("..."))
                    {
                        CMSUser._UserPass = NewPassword;
                        XtraMessageBox.Show(rm.GetString("ThanhCong", CMSUser._culture), rm.GetString("TieuDeThongBao", CMSUser._culture), MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close();
                    }
                    else
                    {
                        XtraMessageBox.Show(rm.GetString(result, CMSUser._culture), rm.GetString("TieuDeThongBao", CMSUser._culture), MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch(Exception ex)
            {
                XtraMessageBox.Show(ex.Message, rm.GetString("TieuDeThongBao", CMSUser._culture), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion

        #region Events
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            ChangePassword();
        }
        #endregion
    }
}