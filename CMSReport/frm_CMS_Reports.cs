using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraBars;
using DevExpress.XtraReports.UI;
using System.IO;
using DevExpress.XtraEditors;
using DevExpress.XtraPrinting;
using DevExpress.XtraReports.UserDesigner;
using XtraReportsDemos;
using System.Resources;
using CMSCore.BLL;
using DevExpress.XtraReports.Parameters;
using CMSDevExpressCommon;
using DevExpress.XtraCharts.GLGraphics;

namespace CMSReport
{
    public partial class frm_CMS_Report : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        #region Variables
        private XtraReport XReport;

        public string _sTieuDe1 = string.Empty, _sTieuDe2 = string.Empty, _sTieuDe3 = string.Empty, _sTieuDe4 = string.Empty,
            _sTieuDe5 = string.Empty, _sTieuDe6 = string.Empty, _sTieuDe7 = string.Empty;

        public string _sKyThay1 = string.Empty, _sKyThay2 = string.Empty, _sKyThay3 = string.Empty, _sKyThay4 = string.Empty;
        public string _sCapBac1 = string.Empty, _sCapBac2 = string.Empty, _sCapBac3 = string.Empty, _sCapBac4 = string.Empty;

        public string _sNguoiKy1 = string.Empty, _sNguoiKy2 = string.Empty, _sNguoiKy3 = string.Empty, _sNguoiKy4 = string.Empty, 
            _sNguoiLapBang = string.Empty;

        public string _sKyThayTiengAnh1 = string.Empty, _sKyThayTiengAnh2 = string.Empty, _sKyThayTiengAnh3 = string.Empty, _sKyThayTiengAnh4 = string.Empty;
        public string _sCapBacTiengAnh1 = string.Empty, _sCapBacTiengAnh2 = string.Empty, _sCapBacTiengAnh3 = string.Empty, _sCapBacTiengAnh4 = string.Empty;

        public string _sNguoiKyTiengAnh1 = string.Empty, _sNguoiKyTiengAnh2 = string.Empty, _sNguoiKyTiengAnh3 = string.Empty, _sNguoiKyTiengAnh4 = string.Empty,
            _sNguoiLapBangTiengAnh = string.Empty;

        public string _sNgayKy = string.Empty;
        public string _sNgayKyTiengAnh = string.Empty;

        public byte[] _arrayByteData = { };
        public string _sReportID = string.Empty, _sReportName = string.Empty, _sParentReportID = string.Empty;
        public int _iReportID = 0;
        public string _updateStaff = string.Empty;

        public string _sCollegeName = string.Empty;
        public string _sEnglishCollegeName = string.Empty;
        public string _sAdministrativeUnitName = string.Empty;
        public string _sEnglishAdministrativeUnitName = string.Empty;
        public byte[] _bCollegeLogo;

        public DataTable _dtDataSource = new DataTable();
        public DataSet _dsDataSource = new DataSet();
        string _loaiReportCanIn = string.Empty;
        public string _academicLevelID = "";
        public bool _inDL = true;

        public float fHeight = 23;
        public float fFont = 10;
        #endregion

        #region Inits
        public frm_CMS_Report()
        {
            InitializeComponent();
        }

        private void frm_CMS_Report_Load(object sender, EventArgs e)
        {
            this.Text = _sReportID + " - " + _sReportName;

            if (_sParentReportID != string.Empty)
                _loaiReportCanIn = _sParentReportID;
            else
                _loaiReportCanIn = _sReportID;

            switch (_loaiReportCanIn)
            {
                //case "SoGocCapVanBangCuNhan":
                //    PSC.SoGocCapVanBangCuNhan _xrSoGocCapVanBangCuNhan = new PSC.SoGocCapVanBangCuNhan();
                //    _xrSoGocCapVanBangCuNhan.InitReport(this._dtDataSource);
                //    XReport = _xrSoGocCapVanBangCuNhan;
                //    break;
                //case "SoGocCapVanBangThacSi":
                //    PSC.SoGocCapVanBangThacSi _xrSoGocCapVanBangThacSi = new PSC.SoGocCapVanBangThacSi();
                //    _xrSoGocCapVanBangThacSi.InitReport(this._dtDataSource);
                //    XReport = _xrSoGocCapVanBangThacSi;
                //    break;
                //case "SoCapBanSaoVanBang":
                //    PSC.SoGocCapBanSaoVanBang _xrSoGocBanSao = new PSC.SoGocCapBanSaoVanBang();
                //    _xrSoGocBanSao.Init(this._dtDataSource, _sTieuDe1, _sNgayKy, _sCapBac1, _sNguoiLapBang);
                //    XReport = _xrSoGocBanSao;
                //    break;
                //case "BienBanHuyPhoi":
                //    PSC.BienBanHuyPhoi _xrBienBanHuyPhoi = new PSC.BienBanHuyPhoi();
                //    _xrBienBanHuyPhoi.InitData(this._dtDataSource);
                //    XReport = _xrBienBanHuyPhoi;
                //    break;
                //case "XacMinhVanBangChungChi":
                //    PSC.XacMinhVanBangChungChi _xrXacMinhVanBangChungChi = new PSC.XacMinhVanBangChungChi();
                //    _xrXacMinhVanBangChungChi.InitReport(this._dtDataSource);
                //    XReport = _xrXacMinhVanBangChungChi;
                //    break;
                //case "BienBanNghiemThuPhoi":
                //    PSC.BienBanNghiemThuPhoi _xrBienBanNghiemThuPhoi = new PSC.BienBanNghiemThuPhoi();
                //    _xrBienBanNghiemThuPhoi.InitReport(this._dtDataSource);
                //    XReport = _xrBienBanNghiemThuPhoi;
                //    break;
                //#region CTIM
                //case "CTIM_BienBanHuyPhoi":
                //    CTIM.CTIM_BienBanHuyPhoi CTIM_BienBanHuyPhoi = new CTIM.CTIM_BienBanHuyPhoi();
                //    CTIM_BienBanHuyPhoi.InitReport(this._dsDataSource);
                //    CTIM_BienBanHuyPhoi.Parameters["paraNgayKy"].Value = _sNgayKy;
                //    CTIM_BienBanHuyPhoi._dtData = _dsDataSource.Tables[0];
                //    CTIM_BienBanHuyPhoi._dtText = _dsDataSource.Tables[1];
                //    CTIM_BienBanHuyPhoi._dtNguoiThamGia = _dsDataSource.Tables[2];
                //    XReport = CTIM_BienBanHuyPhoi;
                //    break;
                //case "CTIM_QuyetDinhHuyPhoi":
                //    CTIM.CTIM_QuyetDinhHuyPhoi CTIM_QuyetDinhHuyPhoi = new CTIM.CTIM_QuyetDinhHuyPhoi();
                //    CTIM_QuyetDinhHuyPhoi.InitReport(this._dsDataSource);
                //    CTIM_QuyetDinhHuyPhoi.Parameters["paraNgayKy"].Value = _sNgayKy;
                //    CTIM_QuyetDinhHuyPhoi._dtData = _dsDataSource.Tables[0];
                //    CTIM_QuyetDinhHuyPhoi._dtText = _dsDataSource.Tables[1];
                //    CTIM_QuyetDinhHuyPhoi._dtNguoiThamGia = _dsDataSource.Tables[2];
                //    XReport = CTIM_QuyetDinhHuyPhoi;
                //    break;
                //case "CTIM_ThongKeSoLuongPhoiBang":
                //    CTIM.CTIM_ThongKeSoLuongPhoiBang CTIM_ThongKeSoLuongPhoiBang = new CTIM.CTIM_ThongKeSoLuongPhoiBang();
                //    CTIM_ThongKeSoLuongPhoiBang.InitReport(this._dtDataSource);
                //    CTIM_ThongKeSoLuongPhoiBang.Parameters["paraNgayKy"].Value = _sNgayKy;
                //    XReport = CTIM_ThongKeSoLuongPhoiBang;
                //    break;
                //case "CTIM_ThongKeDanhSachSinhVienDKLTN":
                //    CTIM.CTIM_ThongKeDanhSachSinhVienDKLTN CTIM_ThongKeDanhSachSinhVienDKLTN = new CTIM.CTIM_ThongKeDanhSachSinhVienDKLTN();
                //    CTIM_ThongKeDanhSachSinhVienDKLTN.InitReport(this._dtDataSource);
                //    CTIM_ThongKeDanhSachSinhVienDKLTN.Parameters["paraNgayKy"].Value = _sNgayKy;
                //    XReport = CTIM_ThongKeDanhSachSinhVienDKLTN;
                //    break;
                //case "CTIM_ThongKeSoLuongSinhVienDKLTN":
                //    CTIM.CTIM_ThongKeSoLuongSinhVienDKLTN CTIM_ThongKeSoLuongSinhVienDKLTN = new CTIM.CTIM_ThongKeSoLuongSinhVienDKLTN();
                //    CTIM_ThongKeSoLuongSinhVienDKLTN.InitReport(this._dtDataSource);
                //    XReport = CTIM_ThongKeSoLuongSinhVienDKLTN;
                //    break;
                //case "CTIM_ThongKeDanhSachSinhVienTNConNo":
                //    CTIM.CTIM_ThongKeDanhSachSinhVienTNConNo CTIM_ThongKeDanhSachSinhVienTNConNo = new CTIM.CTIM_ThongKeDanhSachSinhVienTNConNo();
                //    CTIM_ThongKeDanhSachSinhVienTNConNo.InitReport(this._dtDataSource);
                //    CTIM_ThongKeDanhSachSinhVienTNConNo.Parameters["paraNgayKy"].Value = _sNgayKy;
                //    XReport = CTIM_ThongKeDanhSachSinhVienTNConNo;
                //    break;
                //case "CTIM_KyXacNhanVanBangKhoaCNTT":
                //    CTIM.CTIM_KyXacNhanVanBangKhoaCNTT CTIM_KyXacNhanVanBangKhoaCNTT = new CTIM.CTIM_KyXacNhanVanBangKhoaCNTT();
                //    CTIM_KyXacNhanVanBangKhoaCNTT.InitReport(this._dtDataSource);
                //    CTIM_KyXacNhanVanBangKhoaCNTT.Parameters["paraNgayKy"].Value = _sNgayKy;
                //    XReport = CTIM_KyXacNhanVanBangKhoaCNTT;
                //    break;
                //case "CTIM_KyXacNhanVanBangKhoaCN":
                //    CTIM.CTIM_KyXacNhanVanBangKhoaCN CTIM_KyXacNhanVanBangKhoaCN = new CTIM.CTIM_KyXacNhanVanBangKhoaCN();
                //    CTIM_KyXacNhanVanBangKhoaCN.InitReport(this._dtDataSource);
                //    CTIM_KyXacNhanVanBangKhoaCN.Parameters["paraNgayKy"].Value = _sNgayKy;
                //    XReport = CTIM_KyXacNhanVanBangKhoaCN;
                //    break;
                //case "CTIM_KyXacNhanVanBangKhoaKT":
                //    CTIM.CTIM_KyXacNhanVanBangKhoaKT CTIM_KyXacNhanVanBangKhoaKT = new CTIM.CTIM_KyXacNhanVanBangKhoaKT();
                //    CTIM_KyXacNhanVanBangKhoaKT.InitReport(this._dtDataSource);
                //    CTIM_KyXacNhanVanBangKhoaKT.Parameters["paraNgayKy"].Value = _sNgayKy;
                //    XReport = CTIM_KyXacNhanVanBangKhoaKT;
                //    break;
                //case "CTIM_KyXacNhanVanBangKhoaNN":
                //    CTIM.CTIM_KyXacNhanVanBangKhoaNN CTIM_KyXacNhanVanBangKhoaNN = new CTIM.CTIM_KyXacNhanVanBangKhoaNN();
                //    CTIM_KyXacNhanVanBangKhoaNN.InitReport(this._dtDataSource);
                //    CTIM_KyXacNhanVanBangKhoaNN.Parameters["paraNgayKy"].Value = _sNgayKy;
                //    XReport = CTIM_KyXacNhanVanBangKhoaNN;
                //    break;
                //case "CTIM_ToTrinhKyBangTotNghiep":
                //    CTIM.CTIM_ToTrinhKyBangTotNghiep CTIM_ToTrinhKyBangTotNghiep = new CTIM.CTIM_ToTrinhKyBangTotNghiep();
                //    CTIM_ToTrinhKyBangTotNghiep.InitReport(this._dsDataSource);
                //    CTIM_ToTrinhKyBangTotNghiep.Parameters["paraNgayKy"].Value = _sNgayKy;
                //    XReport = CTIM_ToTrinhKyBangTotNghiep;
                //    break;
                //case "CTIM_XacMinhVanBangTotNghiep":
                //    CTIM.CTIM_XacMinhVanBangTotNghiep CTIM_XacMinhVanBangTotNghiep = new CTIM.CTIM_XacMinhVanBangTotNghiep();
                //    CTIM_XacMinhVanBangTotNghiep.InitReport(this._dtDataSource);
                //    CTIM_XacMinhVanBangTotNghiep.Parameters["paraNgayKy"].Value = _sNgayKy;
                //    XReport = CTIM_XacMinhVanBangTotNghiep;
                //    break;
                //case "CTIM_BaoCaoViecInVaSuDungPhoiBang":
                //    CTIM.CTIM_BaoCaoViecInVaSuDungPhoiBang CTIM_BaoCaoViecInVaSuDungPhoiBang = new CTIM.CTIM_BaoCaoViecInVaSuDungPhoiBang();
                //    CTIM_BaoCaoViecInVaSuDungPhoiBang.InitReport(this._dtDataSource);
                //    CTIM_BaoCaoViecInVaSuDungPhoiBang.Parameters["paraNgayKy"].Value = _sNgayKy;
                //    CTIM_BaoCaoViecInVaSuDungPhoiBang.Parameters["paraNgayCongVan"].Value = _sNgayKy;
                //    XReport = CTIM_BaoCaoViecInVaSuDungPhoiBang;
                //    break;
                //case "CTIM_SoTheoBoLaoDong":
                //    CTIM.CTIM_SoTheoBoLaoDong CTIM_SoTheoBoLaoDong = new CTIM.CTIM_SoTheoBoLaoDong();
                //    CTIM_SoTheoBoLaoDong.InitReport(this._dtDataSource);
                //    CTIM_SoTheoBoLaoDong.Parameters["paraNgayKy"].Value = _sNgayKy;
                //    XReport = CTIM_SoTheoBoLaoDong;
                //    break;
                //case "CTIM_SoGocCapVanBangCuNhan":
                //    CTIM.CTIM_SoGocCapVanBangCuNhan CTIM_SoGocCapVanBangCuNhan = new CTIM.CTIM_SoGocCapVanBangCuNhan();
                //    CTIM_SoGocCapVanBangCuNhan.InitReport(this._dtDataSource);
                //    CTIM_SoGocCapVanBangCuNhan.Parameters["paraNgayKy"].Value = _sNgayKy;
                //    XReport = CTIM_SoGocCapVanBangCuNhan;
                //    break;
                //case "CTIM_GiayChungNhanTotNghiepTamTHoi":
                //    CTIM.CTIM_GiayChungNhanTotNghiepTamTHoi CTIM_GiayChungNhanTotNghiepTamThoi = new CTIM.CTIM_GiayChungNhanTotNghiepTamTHoi();
                //    CTIM_GiayChungNhanTotNghiepTamThoi.InitReport(this._dtDataSource);
                //    CTIM_GiayChungNhanTotNghiepTamThoi.Parameters["paraNgayKy"].Value = _sNgayKy;
                //    XReport = CTIM_GiayChungNhanTotNghiepTamThoi;
                //    break;
                //case "CTIM_GiayChungNhanHoanThanhCTDT":
                //    CTIM.CTIM_GiayChungNhanHoanThanhCTDT CTIM_GiayChungNhanHoanThanhCTDT = new CTIM.CTIM_GiayChungNhanHoanThanhCTDT();
                //    CTIM_GiayChungNhanHoanThanhCTDT.InitReport(this._dtDataSource);
                //    CTIM_GiayChungNhanHoanThanhCTDT.Parameters["paraNgayKy"].Value = _sNgayKy;
                //    XReport = CTIM_GiayChungNhanHoanThanhCTDT;
                //    break;
                //case "CTIM_TuChoiXacMinhVanBangTotNghiep":
                //    CTIM.CTIM_TuChoiXacMinhVanBangTotNghiep CTIM_TuChoiXacMinhVanBangTotNghiep = new CTIM.CTIM_TuChoiXacMinhVanBangTotNghiep();
                //    CTIM_TuChoiXacMinhVanBangTotNghiep.InitReport(this._dtDataSource);
                //    //CTIM_TuChoiXacMinhVanBangTotNghiep.Parameters["paraNgayKy"].Value = _sNgayKy;
                //    XReport = CTIM_TuChoiXacMinhVanBangTotNghiep;
                //    break;
                //#endregion
                //#region HCMUE
                //case "HCMUM_BienBanHuyPhoi":
                //    HCMUM.HCMUM_BienBanHuyPhoi HCMUM_BienBanHuyPhoi = new HCMUM.HCMUM_BienBanHuyPhoi();
                //    HCMUM_BienBanHuyPhoi.InitReport(this._dtDataSource);
                //    //HCMUM_BienBanHuyPhoi.Parameters["paraNgayKy"].Value = _sNgayKy;
                //    XReport = HCMUM_BienBanHuyPhoi;
                //    break;
                //case "HCMUM_SoCapBanSaoVanBangCuNhan":
                //    HCMUM.HCMUM_SoCapBanSaoVanBangCuNhan HCMUM_SoCapBanSaoVanBangCuNhan = new HCMUM.HCMUM_SoCapBanSaoVanBangCuNhan();
                //    HCMUM_SoCapBanSaoVanBangCuNhan.InitReport(this._dtDataSource);
                //    HCMUM_SoCapBanSaoVanBangCuNhan.Parameters["paraNgayKy"].Value = _sNgayKy;
                //    XReport = HCMUM_SoCapBanSaoVanBangCuNhan;
                //    break;
                //case "HCMUM_SoCapBanSaoVanBangThacSi":
                //    HCMUM.HCMUM_SoCapBanSaoVanBangThacSi HCMUM_SoCapBanSaoVanBangThacSi = new HCMUM.HCMUM_SoCapBanSaoVanBangThacSi();
                //    HCMUM_SoCapBanSaoVanBangThacSi.InitReport(this._dtDataSource);
                //    HCMUM_SoCapBanSaoVanBangThacSi.Parameters["paraNgayKy"].Value = _sNgayKy;
                //    XReport = HCMUM_SoCapBanSaoVanBangThacSi;
                //    break;
                //case "HCMUM_SoGocCapVanBangCuNhan":
                //    HCMUM.HCMUM_SoGocCapVanBangCuNhan HCMUM_SoGocCapVanBangCuNhan = new HCMUM.HCMUM_SoGocCapVanBangCuNhan();
                //    HCMUM_SoGocCapVanBangCuNhan.InitReport(this._dtDataSource);
                //    HCMUM_SoGocCapVanBangCuNhan.Parameters["paraNgayKy"].Value = _sNgayKy;
                //    XReport = HCMUM_SoGocCapVanBangCuNhan;
                //    break;
                //case "HCMUM_MauDeXuatCapPhoi":
                //    HCMUM.HCMUM_MauDeXuatCapPhoi HCMUM_MauDeXuatCapPhoi = new HCMUM.HCMUM_MauDeXuatCapPhoi();
                //    HCMUM_MauDeXuatCapPhoi.InitReport(this._dtDataSource);
                //    HCMUM_MauDeXuatCapPhoi.Parameters["paraNgayKy"].Value = _sNgayKy;
                //    XReport = HCMUM_MauDeXuatCapPhoi;
                //    break;
                //case "HCMUM_XacMinhVanBangTotNghiep":
                //    HCMUM.HCMUM_XacMinhVanBangTotNghiep HCMUM_XacMinhVanBangTotNghiep = new HCMUM.HCMUM_XacMinhVanBangTotNghiep();
                //    HCMUM_XacMinhVanBangTotNghiep.InitReport(this._dtDataSource);
                //    HCMUM_XacMinhVanBangTotNghiep.Parameters["paraNgayKy"].Value = _sNgayKy;
                //    HCMUM_XacMinhVanBangTotNghiep.Parameters["paraNguoiKy1"].Value = _sNguoiKy1;
                //    HCMUM_XacMinhVanBangTotNghiep.Parameters["paraCapBac1"].Value = _sCapBac1;
                //    XReport = HCMUM_XacMinhVanBangTotNghiep;
                //    break;
                //#endregion
                //#region UAH
                //case "UAH_XacMinhVanBangTotNghiep":
                //    UAH.UAH_XacMinhVanBangTotNghiep UAH_XacMinhVanBangTotNghiep = new UAH.UAH_XacMinhVanBangTotNghiep();
                //    UAH_XacMinhVanBangTotNghiep.InitReport(this._dtDataSource);
                //    UAH_XacMinhVanBangTotNghiep.Parameters["paraNgayKy"].Value = _sNgayKy;
                //    XReport = UAH_XacMinhVanBangTotNghiep;
                //    break;
                //case "UAH_SoTheoDoiCapBanSao":
                //    UAH.UAH_SoTheoDoiCapBanSao UAH_SoTheoDoiCapBanSao = new UAH.UAH_SoTheoDoiCapBanSao();
                //    UAH_SoTheoDoiCapBanSao.InitReport(this._dtDataSource);
                //    XReport = UAH_SoTheoDoiCapBanSao;
                //    break;
                //case "UAH_SoGocCapVanBang":
                //    UAH.UAH_SoGocCapVanBang UAH_SoGocCapVanBang = new UAH.UAH_SoGocCapVanBang();
                //    UAH_SoGocCapVanBang.InitReport(this._dtDataSource);
                //    UAH_SoGocCapVanBang.Parameters["paraNgayKy"].Value = _sNgayKy;
                //    XReport = UAH_SoGocCapVanBang;
                //    break;
                //#endregion
                //#region TTQP
                //case "TTQP_PhuLucSoGoc":
                //    TTQP.TTQP_PhuLucSoGoc TTQP_PhuLucSoGoc = new TTQP.TTQP_PhuLucSoGoc();
                //    TTQP_PhuLucSoGoc.InitReport(this._dtDataSource);
                //    TTQP_PhuLucSoGoc.Parameters["paraNgayKy"].Value = _sNgayKy;
                //    XReport = TTQP_PhuLucSoGoc;
                //    break;
                //case "TTQP_SoGocCapChungChiCD":
                //    TTQP.TTQP_SoGocCapChungChiCD TTQP_SoGocCapChungChiCD = new TTQP.TTQP_SoGocCapChungChiCD();
                //    TTQP_SoGocCapChungChiCD.InitReport(this._dtDataSource);
                //    TTQP_SoGocCapChungChiCD.Parameters["paraNgayKy"].Value = _sNgayKy;
                //    XReport = TTQP_SoGocCapChungChiCD;
                //    break;
                //case "TTQP_SoGocCapChungChiDH":
                //    TTQP.TTQP_SoGocCapChungChiDH TTQP_SoGocCapChungChiDH = new TTQP.TTQP_SoGocCapChungChiDH();
                //    TTQP_SoGocCapChungChiDH.InitReport(this._dtDataSource);
                //    TTQP_SoGocCapChungChiDH.Parameters["paraNgayKy"].Value = _sNgayKy;
                //    XReport = TTQP_SoGocCapChungChiDH;
                //    break;
                //#endregion
                //#region UKH
                //case "UKH_SoGocCapVanBangCuNhan":
                //    UKH.UKH_SoGocCapVanBangCuNhan UKH_SoGocCapVanBangCuNhan = new UKH.UKH_SoGocCapVanBangCuNhan();
                //    UKH_SoGocCapVanBangCuNhan.InitReport(this._dtDataSource);
                //    UKH_SoGocCapVanBangCuNhan.Parameters["paraNgayKy"].Value = _sNgayKy;
                //    UKH_SoGocCapVanBangCuNhan.Parameters["paraCapBac1"].Value = _sCapBac1;
                //    UKH_SoGocCapVanBangCuNhan.Parameters["paraNguoiKy1"].Value = _sNguoiKy1;
                //    UKH_SoGocCapVanBangCuNhan.Parameters["paraDonViTrucThuoc"].Value = _sAdministrativeUnitName;
                //    UKH_SoGocCapVanBangCuNhan.Parameters["paraDonVi"].Value = _sCollegeName;
                //    XReport = UKH_SoGocCapVanBangCuNhan;
                //    break;
                //case "UKH_PhuLucSoGoc":
                //    UKH.UKH_PhuLucSoGoc UKH_PhuLucSoGoc = new UKH.UKH_PhuLucSoGoc();
                //    UKH_PhuLucSoGoc.InitReport(this._dtDataSource);
                //    UKH_PhuLucSoGoc.Parameters["paraNgayKy"].Value = _sNgayKy;
                //    UKH_PhuLucSoGoc.Parameters["paraCapBac1"].Value = _sCapBac1;
                //    UKH_PhuLucSoGoc.Parameters["paraNguoiKy1"].Value = _sNguoiKy1;
                //    UKH_PhuLucSoGoc.Parameters["paraDonViTrucThuoc"].Value = _sAdministrativeUnitName;
                //    UKH_PhuLucSoGoc.Parameters["paraDonVi"].Value = _sCollegeName;
                //    XReport = UKH_PhuLucSoGoc;
                //    break;
                //case "UKH_SoCapBanSao":
                //    UKH.UKH_SoCapBanSao UKH_SoCapBanSao = new UKH.UKH_SoCapBanSao();
                //    UKH_SoCapBanSao.InitReport(this._dtDataSource);
                //    UKH_SoCapBanSao.Parameters["paraNgayKy"].Value = _sNgayKy;
                //    UKH_SoCapBanSao.Parameters["paraCapBac1"].Value = _sCapBac1;
                //    UKH_SoCapBanSao.Parameters["paraNguoiKy1"].Value = _sNguoiKy1;
                //    UKH_SoCapBanSao.Parameters["paraDonViTrucThuoc"].Value = _sAdministrativeUnitName;
                //    UKH_SoCapBanSao.Parameters["paraDonVi"].Value = _sCollegeName;
                //    XReport = UKH_SoCapBanSao;
                //    break;
                //case "UKH_BaoCaoQuanLyPhoi":
                //    UKH.UKH_BaoCaoQuanLyPhoi UKH_BaoCaoQuanLyPhoi = new UKH.UKH_BaoCaoQuanLyPhoi();
                //    UKH_BaoCaoQuanLyPhoi.InitReport(this._dtDataSource);
                //    UKH_BaoCaoQuanLyPhoi.Parameters["paraNgayKy"].Value = _sNgayKy;
                //    UKH_BaoCaoQuanLyPhoi.Parameters["paraCapBac1"].Value = _sCapBac1;
                //    UKH_BaoCaoQuanLyPhoi.Parameters["paraNguoiKy1"].Value = _sNguoiKy1;
                //    UKH_BaoCaoQuanLyPhoi.Parameters["paraDonViTrucThuoc"].Value = _sAdministrativeUnitName;
                //    UKH_BaoCaoQuanLyPhoi.Parameters["paraDonVi"].Value = _sCollegeName;
                //    XReport = UKH_BaoCaoQuanLyPhoi;
                //    break;
                //case "UKH_BaoCaoNhapPhoi":
                //    UKH.UKH_BaoCaoNhapPhoi UKH_BaoCaoNhapPhoi = new UKH.UKH_BaoCaoNhapPhoi();
                //    UKH_BaoCaoNhapPhoi.InitReport(this._dtDataSource);
                //    UKH_BaoCaoNhapPhoi.Parameters["paraNgayKy"].Value = _sNgayKy;
                //    UKH_BaoCaoNhapPhoi.Parameters["paraCapBac1"].Value = _sCapBac1;
                //    UKH_BaoCaoNhapPhoi.Parameters["paraNguoiKy1"].Value = _sNguoiKy1;
                //    UKH_BaoCaoNhapPhoi.Parameters["paraCapBac2"].Value = _sCapBac2;
                //    UKH_BaoCaoNhapPhoi.Parameters["paraNguoiKy2"].Value = _sNguoiKy2;
                //    UKH_BaoCaoNhapPhoi.Parameters["paraDonViTrucThuoc"].Value = _sAdministrativeUnitName;
                //    UKH_BaoCaoNhapPhoi.Parameters["paraDonVi"].Value = _sCollegeName;
                //    XReport = UKH_BaoCaoNhapPhoi;
                //    break;

                    
                //    #endregion
            }

            OpenLayout();

                foreach (Parameter p in XReport.Parameters)
                {
                    if (p.Name.Contains("paraDonViTrucThuoc"))
                        XReport.Parameters["paraDonViTrucThuoc"].Value = _sAdministrativeUnitName;

                    if (p.Name.Contains("paraDonVi"))
                        XReport.Parameters["paraDonVi"].Value = _sCollegeName.ToUpper();

                    if (p.Name.Contains("paraDonViThucHien"))
                        XReport.Parameters["paraDonViThucHien"].Value = _sCollegeName;

                    if (p.Name.Contains("paraTieuDe1"))
                        XReport.Parameters["paraTieuDe1"].Value = _sTieuDe1;

                    if (p.Name.Contains("paraTieuDe1"))
                        XReport.Parameters["paraTieuDe1"].Value = _sTieuDe1;

                    if (p.Name.Contains("paraTieuDe2"))
                        XReport.Parameters["paraTieuDe2"].Value = _sTieuDe2;

                    if (p.Name.Contains("paraTieuDe3"))
                        XReport.Parameters["paraTieuDe3"].Value = _sTieuDe3;

                    if (p.Name.Contains("paraTieuDe4"))
                        XReport.Parameters["paraTieuDe4"].Value = _sTieuDe4;

                    if (p.Name.Contains("paraTieuDe5"))
                        XReport.Parameters["paraTieuDe5"].Value = _sTieuDe5;

                    if (p.Name.Contains("paraTieuDe6"))
                        XReport.Parameters["paraTieuDe6"].Value = _sTieuDe6;

                    if (p.Name.Contains("paraTieuDe7"))
                        XReport.Parameters["paraTieuDe7"].Value = _sTieuDe7;

                    if (p.Name.Contains("paraNgayKy"))
                        XReport.Parameters["paraNgayKy"].Value = _sNgayKy;

                    if (p.Name.Contains("paraHeight"))
                        XReport.Parameters["paraHeight"].Value = fHeight;

                    if (p.Name.Contains("paraFont"))
                        XReport.Parameters["paraFont"].Value = fFont;

                    if (p.Name.Contains("paraCapBac1"))
                        XReport.Parameters["paraCapBac1"].Value = _sCapBac1.Replace("#", "\n");

                    if (p.Name.Contains("paraNguoiKy1"))
                        XReport.Parameters["paraNguoiKy1"].Value = _sNguoiKy1;

                    if (p.Name.Contains("paraCapBac2"))
                        XReport.Parameters["paraCapBac2"].Value = _sCapBac2.Replace("#", "\n");

                    if (p.Name.Contains("paraNguoiKy2"))
                        XReport.Parameters["paraNguoiKy2"].Value = _sNguoiKy2;

                    if (p.Name.Contains("paraCapBac3"))
                        XReport.Parameters["paraCapBac3"].Value = _sCapBac3.Replace("#", "\n");

                    if (p.Name.Contains("paraNguoiKy3"))
                        XReport.Parameters["paraNguoiKy3"].Value = _sNguoiKy3;

                    if (p.Name.Contains("paraCapBac4"))
                        XReport.Parameters["paraCapBac4"].Value = _sCapBac4.Replace("#", "\n");

                    if (p.Name.Contains("paraNguoiKy4"))
                        XReport.Parameters["paraNguoiKy4"].Value = _sNguoiKy4;

                    if (p.Name.Contains("paraCapBac1_TA"))
                        XReport.Parameters["paraCapBac1_TA"].Value = _sCapBacTiengAnh1.Replace("#", "\n");

                    if (p.Name.Contains("paraCapBac2_TA"))
                        XReport.Parameters["paraCapBac2_TA"].Value = _sCapBacTiengAnh2.Replace("#", "\n");

                    if (p.Name.Contains("paraNguoiKy1_TA"))
                        XReport.Parameters["paraNguoiKy1_TA"].Value = _sNguoiKyTiengAnh1;

                    if (p.Name.Contains("paraNguoiKy2_TA"))
                        XReport.Parameters["paraNguoiKy2_TA"].Value = _sNguoiKyTiengAnh2;

                    if (p.Name.Contains("paraNguoiLapBang"))
                        XReport.Parameters["paraNguoiLapBang"].Value = _sNguoiLapBang;

                    if (p.Name.Contains("paraNguoiLap"))
                        XReport.Parameters["paraNguoiLap"].Value = _sNguoiLapBang;
                documentViewer.PrintingSystem = XReport.PrintingSystem;
                XReport.CreateDocument();
            }
                  
        }
        #endregion

        #region Functions
        private static string GetReportPath(XtraReport fReport, string ext)
        {
            System.Reflection.Assembly asm = System.Reflection.Assembly.GetExecutingAssembly();
            string repName = fReport.Name;
            if (repName.Length == 0)
                repName = fReport.GetType().Name;
            string dirName = Path.GetDirectoryName(asm.Location);
            return Path.Combine(dirName, String.Format("{0}.{1}", repName, ext));
        }

        private static void ShowDesignerForm(Form designForm, Form parentForm)
        {
            try
            {
                designForm.MinimumSize = parentForm.MinimumSize;
                if (parentForm.WindowState == FormWindowState.Normal)
                    designForm.Bounds = parentForm.Bounds;
                designForm.WindowState = parentForm.WindowState;
                parentForm.Visible = false;
                designForm.ShowDialog();
                parentForm.Visible = true;
            }
            catch { }
        }

        private void OpenLayout()
        {
            DataTable _dtTemplateReports = BL_Report.GetTemplateReports(_iReportID);

            if (_dtTemplateReports.Rows.Count > 0)
            {
                if (_dtTemplateReports.Rows[0]["Data"] != DBNull.Value)
                {
                    XReport.DataSource = _dtDataSource;
                    XReport.LoadLayout(new MemoryStream((byte[])_dtTemplateReports.Rows[0]["Data"]));
                }
            }

            if (_inDL == false) printPreviewRibbonPageGroup2.Visible = false;
        }
        #endregion

        #region Events
        private void barButtonItemDesignReport_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                string saveFileName = GetReportPath(XReport, "repx");
                XReport.PrintingSystem.ExecCommand(PrintingSystemCommand.StopPageBuilding);
                XReport.SaveLayout(saveFileName);

                using (XtraReport newReport = XtraReport.FromFile(saveFileName, true))
                {
                    XRDesignFormExBase designForm = new CustomDesignForm();

                    if (newReport.DataSource is DataSet)
                    {
                        var set = newReport.DataSource as DataSet;
                        set.Clear();
                        set.Tables.Clear();

                        set.Tables.Add(_dtDataSource.Copy());
                        set.Tables[0].TableName = "DataColumns";

                        if (newReport.DataMember != null && newReport.DataMember.Length > 0)
                            newReport.DataSource = set.Tables[newReport.DataMember];
                        else
                            newReport.DataSource = set.Tables[0];
                        newReport.DataMember = null;
                    }


                    designForm.OpenReport(newReport);
                    designForm.FileName = saveFileName;
                    ShowDesignerForm(designForm, FindForm());
                    if (designForm.FileName != saveFileName && File.Exists(designForm.FileName))
                        File.Copy(designForm.FileName, saveFileName, true);

                    designForm.OpenReport((XtraReport)null);
                    designForm.Dispose();
                }
                if (File.Exists(saveFileName))
                {
                    XReport.LoadLayout(saveFileName);
                    File.Delete(saveFileName);
                    XReport.CreateDocument(true);
                }

                File.Delete(saveFileName);
                Cursor.Current = Cursors.Default;
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "PSC Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void barButtonItemSaveReport_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                string mess = "Save your change ?";

                if (XtraMessageBox.Show(mess, "PSC Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    using (MemoryStream ms = new MemoryStream())
                    {
                        XReport.SaveLayout(ms);

                        int result = BL_Report.SaveTemplateReports(_iReportID, ms.ToArray(), _updateStaff);

                        if (result == 0)
                            XtraMessageBox.Show("Successful", "PSC Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        else
                            XtraMessageBox.Show("Unsuccessful", "PSC Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "PSC Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void barButtonItemSaveAs_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                string mess = "Save your change ?";
                if (XtraMessageBox.Show(mess, "PSC Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                    return;

                frm_CMS_ReportName frm = new frm_CMS_ReportName();
                frm.ShowDialog(this);

                if (frm._bIsAccepted == false)
                    return;                

                using (MemoryStream ms = new MemoryStream())
                {
                    XReport.SaveLayout(ms);

                    int result = BL_Report.SaveAsTemplateReports(ms.ToArray(), _iReportID, _updateStaff, frm._sReportName);

                    if (result == 0)
                        XtraMessageBox.Show("Successful", "PSC Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    else
                        XtraMessageBox.Show("Unsuccessful", "PSC Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "PSC Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion
    }
}