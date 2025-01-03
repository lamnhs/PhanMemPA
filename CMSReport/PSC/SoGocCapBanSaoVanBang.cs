using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using System.Data;

namespace CMSReport.PSC
{
    public partial class SoGocCapBanSaoVanBang : DevExpress.XtraReports.UI.XtraReport
    {
        public SoGocCapBanSaoVanBang()
        {
            InitializeComponent();
        }

        public void Init(DataTable dtData, string _sTieuDe, string _sNgayIn, string _sPosition, string _sName)
        {
            this.DataSource = dtData;
            paraNgayKy.Value = _sNgayIn;
            paraCapBac1.Value = _sPosition;
            paraNguoiKy1.Value = _sName;
            paraTieuDeCap1.Value = _sTieuDe;
        }
    }
}
