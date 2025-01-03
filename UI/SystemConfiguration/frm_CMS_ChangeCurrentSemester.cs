using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using System.Resources;
using CMSDevExpressCommon;

namespace CMSUI.SystemConfiguration
{
    public partial class frm_CMS_ChangeCurrentSemester : DevExpress.XtraEditors.XtraForm
    {
        #region Variables
        public string _currentYearStudy;
        public string _currentTermID;
        public string _currentTerm;
        public bool _isSubmitted = false;
        ResourceManager rm;
        #endregion

        #region Inits
        public frm_CMS_ChangeCurrentSemester()
        {
            InitializeComponent();

            SetLanguage();
        }

        private void frm_CMS_ChangeCurrentSemester_Load(object sender, EventArgs e)
        {
            #region Phân quyền
            CommonFunctions.SetFormPermiss(this); 
            #endregion

            try
            {
                GetYearStudy();
                lookUpEditAcademicYear.EditValue = CMSUser._CurrentYearStudy;
                lookUpEditAcademicSemester.EditValue = CMSUser._CurrentTerm;
            }
            catch { }
        }
        #endregion

        #region Functions
        private void SetLanguage()
        {
            rm = new ResourceManager("CMSUI.Lang.MyResource", typeof(frm_CMS_ChangeCurrentSemester).Assembly);

            this.Text = rm.GetString("DoiHocKyHienTai", CMSUser._culture);
            btnAgree.Text = rm.GetString("btnAgree", CMSUser._culture);
            btnClose.Text = rm.GetString("btnClose", CMSUser._culture);
            layoutControlItemAcademicSemester.Text = rm.GetString("Term", CMSUser._culture);
            layoutControlItemAcademicYear.Text = rm.GetString("YearStudy", CMSUser._culture);
        }

        private void GetYearStudy()
        {
            try
            {
                DataTable dtYearStudy = CMSUser.GetDataYearStudy();
                AppDevExpressEditControl.InitLookUpEdit(lookUpEditAcademicYear, dtYearStudy, "YearStudy", "YearStudyID", string.Empty, "YearStudy", rm.GetString("YearStudy", CMSUser._culture), 0);
            }
            catch { }
        }

        public void GetTerms(string yearStudy)
        {
            try
            {
                DataTable dtTerm = CMSUser.GetDataTerm(yearStudy);
                AppDevExpressEditControl.InitLookUpEdit(lookUpEditAcademicSemester, dtTerm, "TermName", "TermID", string.Empty, "TermName", rm.GetString("Term", CMSUser._culture), 0);
            }
            catch { }
        }
        #endregion

        #region Events
        private void lookUpEdit_YearStudy_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                GetTerms(lookUpEditAcademicYear.EditValue.ToString());                
            }
            catch { }
        }

        private void btn_DongY_Click(object sender, EventArgs e)
        {
            try
            {
                _currentYearStudy = lookUpEditAcademicYear.EditValue.ToString();
                _currentTermID = lookUpEditAcademicSemester.EditValue.ToString();
                _currentTerm = lookUpEditAcademicSemester.Text;
                _isSubmitted = true;
                this.Close();
            }
            catch { }
        }

        private void btn_Close_Click(object sender, EventArgs e)
        {
            _isSubmitted = false;
            this.Close();
        } 
        #endregion
    }
}
