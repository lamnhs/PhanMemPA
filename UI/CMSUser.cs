using CMSDevExpressCommon;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading.Tasks;

namespace CMSUI
{
    public class CMSUser
    {
        public static string _UserID;
        public static string _UserName;
        public static string _UserGroup = "";
        public static string _UserPass = "";
        public static string[] _ParaFromUIS = null;

        public static string _IPLocalServer, _DomainName, _UserNameLocalServer, _PasswordLocalServer, _LocationLocalServer;
        public static string _IPLocalServerDecision, _DomainNameDecision, _UserNameLocalServerDecision, _PasswordLocalServerDecision, _LocationLocalServerDecision;
        public static string _IPLocalServerCertificate, _DomainNameCertificate, _UserNameLocalServerCertificate, _PasswordLocalServerCertificate, _LocationLocalServerCertificate;

        public static DataTable _dtUserGroups = new DataTable();

        public static DataSet _dsDataDictionaries = new DataSet();

        public static bool _foreignLanguageInterface = false;
        public static string _cultureName = "vi-VN";

        public static bool _foreignLanguageData = false;
        public static string _cultureNameData = "vi-VN";

        public static CultureInfo _culture = CultureInfo.CreateSpecificCulture(_cultureName);
        public static CultureInfo _cultureData = CultureInfo.CreateSpecificCulture(_cultureNameData);

        public static bool _TCT_DungModulePhanQuyenMoi = false;

        public static string _FormatDateOfSign = string.Empty;
        public static string _FormatDate = string.Empty;
        public static string _FormatEngDate = string.Empty;

        public static string _CurrentYearStudy = string.Empty;
        public static string _CurrentTerm = string.Empty;
        public static string _CurrentGraduateLevelID = string.Empty;
        public static string _MaLoaiVbcc = string.Empty;
        public static string _CurrentStudyTypeID = string.Empty;
        public static string _CollegeName = string.Empty;
        public static string _EnglishCollegeName = string.Empty;
        public static string _AdministrativeUnitName = string.Empty;
        public static string _EnglishAdministrativeUnitName = string.Empty;
        public static string _TinhThanh = string.Empty;
        public static string _TinhThanhTiengAnh = string.Empty;
        public static bool _HoiLaiKhiLuu = false;
        public static bool _HoiLaiKhiXoa = false;
        public static bool _XacNhanMatKhauKhiLuu = false;
        public static bool _XacNhanMatKhauKhiXoa = false;
        public static byte[] _CollegeLogo;

        public static DataTable GetDataYearStudy()
        {
            DataTable dtData = new DataTable();
            dtData.Columns.Add("YearStudy", typeof(string));
            dtData.Columns.Add("YearStudyID", typeof(string));

            foreach (DataRow dr in CMSUser._dsDataDictionaries.Tables["Terms"].Rows)
                if (dtData.Select("YearStudy = '" + dr["YearStudy"].ToString() + "'").Length == 0)
                    dtData.Rows.Add(new object[] { dr["YearStudy"].ToString(), dr["YearStudy"].ToString() });

            DataView myDataView = new DataView(dtData);
            myDataView.Sort = "YearStudy DESC";

            return myDataView.ToTable();
        }

        public static DataTable GetDataTerm(string yearStudy) 
        {
            DataTable dtData = new DataTable();
            dtData.Columns.Add("TermID", typeof(string));
            dtData.Columns.Add("TermName", typeof(string));

            DataRow[] drSelect = CMSUser._dsDataDictionaries.Tables["Terms"].Select("YearStudy = '" + yearStudy + "'");
            foreach (DataRow dr in drSelect)
                dtData.Rows.Add(new object[] { dr["TermID"].ToString(), dr["TermName"].ToString() });

            DataView dv = new DataView(dtData);
            dv.Sort = "TermName";

            return dv.ToTable();
        }
    }
}
