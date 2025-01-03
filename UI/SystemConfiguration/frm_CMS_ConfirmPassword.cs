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
using System.Resources;

namespace CMSUI.SystemConfiguration
{
    public partial class frm_CMS_ConfirmPassword : DevExpress.XtraEditors.XtraForm
    {
        #region Variables
        ResourceManager rm;
        public bool _confirm = false;
        int _soLanSaiMatKhau = 0;
        #endregion

        #region Inits
        public frm_CMS_ConfirmPassword()
        {
            InitializeComponent();
            SetLanguage();
        } 
        #endregion

        #region Functions
        private void SetLanguage()
        {
            rm = new ResourceManager("CMSUI.Lang.MyResource", typeof(frm_CMS_ConfirmPassword).Assembly);

            btnConfirm.Text = rm.GetString("btnConfirm", CMSUser._culture);
            btnClose.Text = rm.GetString("btnClose", CMSUser._culture);
            layoutControlItemMatKhau.Text = rm.GetString("MatKhau", CMSUser._culture);
        }
        #endregion

        #region Events
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            if (txtMatKhau.Text != CMSUser._UserPass)
            {
                XtraMessageBox.Show(rm.GetString("SaiMatKhau", CMSUser._culture), 
                    rm.GetString("TieuDeThongBao", CMSUser._culture), MessageBoxButtons.OK, MessageBoxIcon.Error);

                txtMatKhau.Focus();
                _soLanSaiMatKhau++;

                if (_soLanSaiMatKhau == 3)
                {
                    _confirm = false;
                    this.Close();
                }
            }
            else
            {
                _confirm = true;
                this.Close();
            }
        } 
        #endregion
    }
}