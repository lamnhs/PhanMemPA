using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using System.Data;

namespace CMSReport.PSC
{
    public partial class BienBanHuyPhoi : DevExpress.XtraReports.UI.XtraReport
    {
        public BienBanHuyPhoi()
        {
            InitializeComponent();
        }

        public void InitData(DataTable dt)
        {
            this.DataSource = dt;
        }
    }
}
