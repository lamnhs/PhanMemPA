using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using System.Data;

namespace CMSReport.PSC
{
    public partial class SoGocCapVanBangCuNhan : DevExpress.XtraReports.UI.XtraReport
    {
        public SoGocCapVanBangCuNhan()
        {
            InitializeComponent();
        }
        public void InitReport(DataTable dtData)
        {
            this.DataSource = dtData;
        }
    }
}
