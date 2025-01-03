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

namespace CMSReport
{
    public partial class frm_CMS_ReportName : DevExpress.XtraEditors.XtraForm
    {
        public string _sReportName = string.Empty;
        public bool _bIsAccepted = false;

        public frm_CMS_ReportName()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            _bIsAccepted = true;
            _sReportName = textEditReportName.Text.Trim();
            this.Close();
        }
    }
}