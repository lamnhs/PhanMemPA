using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using System.Data;

namespace CMSReport.PSC
{
    public partial class XacMinhVanBangChungChi: DevExpress.XtraReports.UI.XtraReport
    {
        public XacMinhVanBangChungChi()
        {
            InitializeComponent();
        }
        public void InitReport(DataTable dtData)
        {
            this.DataSource = dtData;
        }
    }
}
