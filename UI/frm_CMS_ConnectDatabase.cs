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

namespace CMSUI
{
    public partial class frm_CMS_ConnectDatabase : DevExpress.XtraEditors.XtraForm
    {
        #region Variables
        string _provider = "System.Data.SqlClient", _authType = string.Empty;
        #endregion

        #region Inits
        public frm_CMS_ConnectDatabase()
        {
            InitializeComponent();
        }

        private void frm_CMS_ConnectDatabase_Load(object sender, EventArgs e)
        {
            GetProviders();
            lkuProvider.EditValue = "System.Data.SqlClient";

            string pathApp = Application.StartupPath;
            if (System.IO.File.Exists(pathApp + "\\CMS_Config.xml"))
                GetConfig();
        }
        #endregion

        #region Functions
        private void GetConfig()
        {
            try
            {
                string str2;
                string path = "./CMS_Config.xml";
                using (StreamReader reader = new StreamReader(path))
                {
                    str2 = reader.ReadToEnd();
                }
                string[] strArray = str2.Split(new char[] { '"' });

                lkuProvider.EditValue = strArray[3];

                bool phanQuyenMoi = false;
                bool.TryParse(strArray[5].ToString(), out phanQuyenMoi);

                bool english = false;
                bool.TryParse(strArray[7].ToString(), out english);

                string connect = CommonFunctions.DecodeString(strArray[1], true);

                strArray = connect.Split(new char[] { ';' });

                txtServerName.Text = strArray[0].Split(new char[] { '=' })[1];
                txtDatabase1.Text = strArray[1].Split(new char[] { '=' })[1];

                if (strArray.Length == 5)
                {
                    lkuAuthenticationType.EditValue = "ServerAuth";
                    txtUserName.Text = strArray[3].Split(new char[] { '=' })[1];
                    txtPassword.Text = strArray[4].Split(new char[] { '=' })[1];
                }
                else
                {
                    lkuAuthenticationType.EditValue = "WinAuth";
                    txtUserName.Text = string.Empty;
                    txtPassword.Text = string.Empty;
                }

                chkPhanQuyenMoi.Checked = phanQuyenMoi;
                chkEnglish.Checked = english;
            }
            catch { }
        }

        private void GetProviders()
        {
            try
            {
                DataTable dtProviders = new DataTable();
                dtProviders.Columns.Add("ID", typeof(string));
                dtProviders.Columns.Add("Name", typeof(string));

                dtProviders.Rows.Add("System.Data.SqlClient", "Microsoft SQL Server");

                lkuProvider.Properties.DataSource = dtProviders;
                lkuProvider.Properties.DisplayMember = "Name";
                lkuProvider.Properties.ValueMember = "ID";

                LookUpColumnInfoCollection coll = lkuProvider.Properties.Columns;
                coll.Clear();
                coll.Add(new LookUpColumnInfo("Name", 0, "Providers"));

                lkuProvider.Properties.BestFitMode = BestFitMode.BestFitResizePopup;
                lkuProvider.Properties.SearchMode = SearchMode.AutoComplete;
                lkuProvider.Properties.AutoSearchColumnIndex = 0;
            }
            catch { }
        }

        private void GetAuthentications()
        {
            try
            {
                DataTable dtAuthentications = new DataTable();
                dtAuthentications.Columns.Add("ID", typeof(string));
                dtAuthentications.Columns.Add("Name", typeof(string));

                dtAuthentications.Rows.Add("WinAuth", "Windows authentication");
                dtAuthentications.Rows.Add("ServerAuth", "Server authentication");

                lkuAuthenticationType.Properties.DataSource = dtAuthentications;
                lkuAuthenticationType.Properties.DisplayMember = "Name";
                lkuAuthenticationType.Properties.ValueMember = "ID";

                LookUpColumnInfoCollection coll = lkuAuthenticationType.Properties.Columns;
                coll.Clear();
                coll.Add(new LookUpColumnInfo("Name", 0, "Authentications"));

                lkuAuthenticationType.Properties.BestFitMode = BestFitMode.BestFitResizePopup;
                lkuAuthenticationType.Properties.SearchMode = SearchMode.AutoComplete;
                lkuAuthenticationType.Properties.AutoSearchColumnIndex = 0;
            }
            catch { }
        }

        private void FinishConfig()
        {
            try
            {
                if (MessageBox.Show("Save your changes?", "PSC Message", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    string pathApp = Application.StartupPath;
                    if (!System.IO.File.Exists(pathApp + "\\CMS_Config.xml"))
                    {
                        System.IO.FileStream fs = new System.IO.FileStream(pathApp + "\\CMS_Config.xml", System.IO.FileMode.Create);
                        fs.Close();

                        string strTemp = "<appSettings\r\nConnectionString = \"\"\r\nProviderName = \"\"\r\nPhanQuyenMoi = \"\"\r\nEnglish = \"\"/>";
                        using (StreamWriter writer = new StreamWriter(pathApp + "\\CMS_Config.xml"))
                        {
                            writer.Write(strTemp);
                        }
                    }

                    string str2;
                    string[] strArray2;
                    string path = "./CMS_Config.xml";
                    using (StreamReader reader = new StreamReader(path))
                    {
                        str2 = reader.ReadToEnd();
                    }
                    string[] strArray = str2.Split(new char[] { '"' });
                    if (_authType != "WinAuth")
                    {
                        strArray[1] = "Data Source=" + txtServerName.Text.Trim() + ";Initial Catalog=" + txtDatabase1.Text.Trim() + ";Persist Security Info=True;User ID=" + txtUserName.Text.Trim() + "; Password=";
                        if (txtPassword.Text.Trim() == string.Empty)
                        {
                            (strArray2 = strArray)[1] = strArray2[1] + "''";
                        }
                        else
                        {
                            (strArray2 = strArray)[1] = strArray2[1] + txtPassword.Text.Trim();
                        }
                    }
                    else
                    {
                        strArray[1] = "Server=" + txtServerName.Text.Trim() + ";Database=" + txtDatabase1.Text.Trim() + ";Trusted_Connection=True;";
                    }
                    strArray[1] = CommonFunctions.EncodeString(strArray[1], true);
                    strArray[3] = _provider;
                    strArray[5] = chkPhanQuyenMoi.Checked.ToString();
                    strArray[7] = chkEnglish.Checked.ToString();

                    string str3 = strArray[0];
                    for (int i = 1; i < strArray.Length; i++)
                    {
                        str3 = str3 + "\"" + strArray[i];
                    }
                    using (StreamWriter writer = new StreamWriter(path))
                    {
                        writer.Write(str3);
                    }

                    XtraMessageBox.Show("Successful", "PSC Message", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    Application.Exit();
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "PSC Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion

        #region Events
        private void lookUpEdit_provider_EditValueChanged(object sender, EventArgs e)
        {
            _provider = lkuProvider.EditValue.ToString();

            switch (_provider)
            {
                case "System.Data.SqlClient":
                    layoutControlItem_authenticationType.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;

                    GetAuthentications();
                    lkuAuthenticationType.EditValue = "WinAuth";
                    break;
                default:
                    layoutControlItem_authenticationType.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
                    break;
            }
        }

        private void lookUpEdit_authenticationType_EditValueChanged(object sender, EventArgs e)
        {
            _authType = lkuAuthenticationType.EditValue.ToString();

            if (_provider == "System.Data.SqlClient")
            {
                layoutControlItem_userName.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
                layoutControlItem_password.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;

                txtUserName.Text = string.Empty;
                txtPassword.Text = string.Empty;

                if (_authType == "WinAuth")
                {
                    txtUserName.ReadOnly = true;
                    txtPassword.ReadOnly = true;
                }
                else
                {
                    txtUserName.ReadOnly = false;
                    txtPassword.ReadOnly = false;
                }
            }
            else
            {
                layoutControlItem_userName.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
                layoutControlItem_password.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
            }
        }

        private void btn_finish_Click(object sender, EventArgs e)
        {
            FinishConfig();
        }

        private void btn_close_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }        
        #endregion
    }
}