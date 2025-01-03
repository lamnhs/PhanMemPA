using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using System.Data;

namespace CMSReport.PSC
{
    public partial class SoGocCapVanBangThacSi : DevExpress.XtraReports.UI.XtraReport
    {
        public SoGocCapVanBangThacSi()
        {
            InitializeComponent();
        }

        public void InitReport(DataTable dtData)
        {
            this.DataSource = dtData;
        }
    }
}
