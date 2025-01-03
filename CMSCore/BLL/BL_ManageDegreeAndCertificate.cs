using CMSCore.DAL;
using DevExpress.XtraSpreadsheet.Model.CopyOperation;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMSCore.BLL
{
    public class BL_ManageDegreeAndCertificate
    {
        public static DataTable GetTemplateType(string UserID)
        {
            try
            {
                return DA_ManageDegreeAndCertificate.GetTemplateType(UserID);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public static DataTable GetNhom(string UserID)
        {
            try
            {
                return DA_ManageDegreeAndCertificate.GetNhom(UserID);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static int DeleteTemplateType(string strXml, string updateStaff)
        {
            try
            {
                return DA_ManageDegreeAndCertificate.DeleteTemplateType(strXml, updateStaff);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public static int DeleteNhanVien(string strXml, string updateStaff)
        {
            try
            {
                return DA_ManageDegreeAndCertificate.DeleteNhanVien(strXml, updateStaff);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public static int DeleteKhachHang(string strXml, string updateStaff)
        {
            try
            {
                return DA_ManageDegreeAndCertificate.DeleteKhachHang(strXml, updateStaff);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public static int DeleteNguoiDung(string stafff, string updateStaff)
        {
            try
            {
                return DA_ManageDegreeAndCertificate.DeleteNguoiDung(stafff, updateStaff);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public static DataTable LayPhoiVaDotHuy(string maDotHuy, bool foreignLangugeData, int trongDot, string templateTypeID)
        {
            try
            {
                return DA_ManageDegreeAndCertificate.LayPhoiVaDotHuy(maDotHuy, foreignLangugeData, trongDot, templateTypeID);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public static DataSet BienBanHuyPhoi(string xmlData)
        {
            try
            {
                return DA_ManageDegreeAndCertificate.BienBanHuyPhoi(xmlData);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
       

        public static int SaveTemplateType(string strXml, string updateStaff)
        {
            try
            {
                return DA_ManageDegreeAndCertificate.SaveTemplateType(strXml, updateStaff);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public static DataTable LoaiBaoCao(string MaLoaiXet)
        {
            try
            {
                return DA_ManageDegreeAndCertificate.LoaiBaoCao(MaLoaiXet);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public static DataTable HCMUM_BienBanHuyPhoi(string strXml, string _UserID)
        {
            try
            {
                return DA_ManageDegreeAndCertificate.HCMUM_BienBanHuyPhoi(strXml, _UserID);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public static DataTable GetTemplateSession(string templateTypeID, bool fullData)
        {
            try
            {
                return DA_ManageDegreeAndCertificate.GetTemplateSession(templateTypeID, fullData);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        
        public static int SaveTemplateSession(string strXml, string updateStaff)
        {
            try
            {
                return DA_ManageDegreeAndCertificate.SaveTemplateSession(strXml, updateStaff);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public static int SaveDonHang(string maKH, string kyTuDau, int soLuong, string updateStaff)
        {
            try
            {
                return DA_ManageDegreeAndCertificate.SaveDonHang(maKH, kyTuDau, soLuong, updateStaff);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public static int SaveTrungDonHang(string maKH, string maDH, int soLuong, string updateStaff)
        {
            try
            {
                return DA_ManageDegreeAndCertificate.SaveTrungDonHang(maKH, maDH, soLuong, updateStaff);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        
        public static int SaveNhanVien(string strXml, string updateStaff)
        {
            try
            {
                return DA_ManageDegreeAndCertificate.SaveNhanVien(strXml, updateStaff);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public static int SaveKhachHang(string strXml, string updateStaff)
        {
            try
            {
                return DA_ManageDegreeAndCertificate.SaveKhachHang(strXml, updateStaff);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public static int SaveNguoiDung(string taiKhoan, string matKhau, string hoVaTen, string nhom, string updateStaff, string khachHang)
        {
            try
            {
                return DA_ManageDegreeAndCertificate.SaveNguoiDung(taiKhoan,  matKhau, hoVaTen, nhom, updateStaff, khachHang);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
      

        public static DataTable GetTemplateBatch(string templateSessionID)
        {
            try
            {
                return DA_ManageDegreeAndCertificate.GetTemplateBatch(templateSessionID);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static int SaveTemplateBatch(string xmlData, string updateStaff)
        {
            try
            {
                return DA_ManageDegreeAndCertificate.SaveTemplateBatch(xmlData, updateStaff);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static int DeleteTemplateBatch(string xmlData, string updateStaff)
        {
            try
            {
                return DA_ManageDegreeAndCertificate.DeleteTemplateBatch(xmlData, updateStaff);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static DataTable GetTemplate(string templateBatchID, bool foreignLanguage)
        {
            try
            {
                return DA_ManageDegreeAndCertificate.GetTemplate(templateBatchID, foreignLanguage);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static int CancelTemplate(string reason, int templateID, string updateStaff)
        {
            try
            {
                return DA_ManageDegreeAndCertificate.CancelTemplate(reason, templateID, updateStaff);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static int RevokeTemplate(int templateID, string updateStaff)
        {
            try
            {
                return DA_ManageDegreeAndCertificate.RevokeTemplate(templateID, updateStaff);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static DataTable GetDesignTemplate(int templateTypeID)
        {
            try
            {
                return DA_ManageDegreeAndCertificate.GetDesignTemplate(templateTypeID);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public static DataTable GetDesignTemplate_IsInused(int templateTypeID, string UserID)
        {
            try
            {
                return DA_ManageDegreeAndCertificate.GetDesignTemplate_IsInused(templateTypeID, UserID);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static int SaveDesignTemplate(string xmlData, string updateStaff)
        {
            try
            {
                return DA_ManageDegreeAndCertificate.SaveDesignTemplate(xmlData, updateStaff);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static int DeleteDesignTemplate(string xmlData, string updateStaff)
        {
            try
            {
                return DA_ManageDegreeAndCertificate.DeleteDesignTemplate(xmlData, updateStaff);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static int CopyDesignTemplate(int sourceDesignTemplateID, int targetDesignTemplateID, string updateStaff)
        {
            try
            {
                return DA_ManageDegreeAndCertificate.CopyDesignTemplate(sourceDesignTemplateID, targetDesignTemplateID, updateStaff);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static DataTable GetTemplateReports(int designTemplateID)
        {
            try
            {
                return DA_ManageDegreeAndCertificate.GetTemplateReports(designTemplateID);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static int SaveTemplateReports(byte[] reportData, int designTemplateID, string updateStaff)
        {
            try
            {
                return DA_ManageDegreeAndCertificate.SaveTemplateReports(reportData, designTemplateID, updateStaff);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static DataTable GetIssueSession(int templateTypeID)
        {
            try
            {
                return DA_ManageDegreeAndCertificate.GetIssueSession(templateTypeID);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static DataTable GetIssueSession_StringTemplateType(string templateTypeID, string userID)
        {
            try
            {
                return DA_ManageDegreeAndCertificate.GetIssueSession_StringTemplateType(templateTypeID, userID);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static DataTable GetIssueSession(string userID)
        {
            try
            {
                return DA_ManageDegreeAndCertificate.GetIssueSession(userID);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public static DataTable GetQuanLyFile(string maKH, string userID)
        {
            try
            {
                return DA_ManageDegreeAndCertificate.GetQuanLyFile(maKH, userID);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public static DataTable GetQuanLyFile_KH(string maKH, string ngayThang, string user)
        {
            try
            {
                return DA_ManageDegreeAndCertificate.GetQuanLyFile_KH(maKH, ngayThang, user);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        
            public static DataTable GetNhanVien()
            {
                try
                {
                    return DA_ManageDegreeAndCertificate.GetNhanVien();
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }
        public static DataTable GetKhachHang()
        {
            try
            {
                return DA_ManageDegreeAndCertificate.GetKhachHang();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public static DataTable GetNguoiDung()
        {
            try
            {
                return DA_ManageDegreeAndCertificate.GetNguoiDung();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public static DataTable GetDetailNhanVien(string maNV, int soLuong, string tuNgay, string denNgay)
        {
            try
            {
                return DA_ManageDegreeAndCertificate.GetDetailNhanVien(maNV, soLuong, tuNgay, denNgay);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public static DataTable GetThongKeSoLuong(string maNV, int soLuong, string tuNgay, string denNgay)
        {
            try
            {
                return DA_ManageDegreeAndCertificate.GetThongKeSoLuong(maNV, soLuong, tuNgay, denNgay);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public static DataTable GetIssueSession_Student(string studentID, string userID)
        {
            try
            {
                return DA_ManageDegreeAndCertificate.GetIssueSession_Student(studentID, userID);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public static int SaveIssueSession(string xmlData, string updateStaff)
        {
            try
            {
                return DA_ManageDegreeAndCertificate.SaveIssueSession(xmlData, updateStaff);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static int DeleteIssueSession(string xmlData, string updateStaff)
        {
            try
            {
                return DA_ManageDegreeAndCertificate.DeleteIssueSession(xmlData, updateStaff);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static DataTable GetDecisions(int templateTypeID)
        {
            try
            {
                return DA_ManageDegreeAndCertificate.GetDecisions(templateTypeID);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static DataTable GetStudentInIssueSession(int issueSessionID)
        {
            try
            {
                return DA_ManageDegreeAndCertificate.GetStudentInIssueSession(issueSessionID);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static DataTable GetStudentNotInIssueSession(string maDotCap, bool trungTamDaoTao, string decisionNumber)
        {
            try
            {
                return DA_ManageDegreeAndCertificate.GetStudentNotInIssueSession(maDotCap, trungTamDaoTao, decisionNumber);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static int SaveStudentIntoIssueSession(string xmlData, string updateStaff, bool trungTamDaoTao, bool isUpdate)
        {
            try
            {
                return DA_ManageDegreeAndCertificate.SaveStudentIntoIssueSession(xmlData, updateStaff, trungTamDaoTao, isUpdate);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public static int SaveStudentIntoIssueSession_CapLai(string xmlData, string updateStaff, bool trungTamDaoTao, bool isUpdate)
        {
            try
            {
                return DA_ManageDegreeAndCertificate.SaveStudentIntoIssueSession_CapLai(xmlData, updateStaff, trungTamDaoTao, isUpdate);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public static int DeleteStudentOutOfIssueSession(string xmlData, string updateStaff)
        {
            try
            {
                return DA_ManageDegreeAndCertificate.DeleteStudentOutOfIssueSession(xmlData, updateStaff);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static int SynchStudentInfomation(string xmlData, string updateStaff, bool trungTamDaoTao)
        {
            try
            {
                return DA_ManageDegreeAndCertificate.SynchStudentInfomation(xmlData, updateStaff, trungTamDaoTao);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static int ConfirmStudentNeedIssueDegreeOrCertificate(string xmlData, string updateStaff)
        {
            try
            {
                return DA_ManageDegreeAndCertificate.ConfirmStudentNeedIssueDegreeOrCertificate(xmlData, updateStaff);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static int IssueTemplate(int issueSessionID, string updateStaff)
        {
            try
            {
                return DA_ManageDegreeAndCertificate.IssueTemplate(issueSessionID, updateStaff);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static DataTable GetIssueSessionTemplate(int issueSessionID, bool _foreignLanguage, bool capPhatPhoi)
        {
            try
            {
                return DA_ManageDegreeAndCertificate.GetIssueSessionTemplate(issueSessionID, _foreignLanguage, capPhatPhoi);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static DataTable DanhSachDuocCapBangChungChi(string maDotCapBang, string updateStaff)
        {
            try
            {
                return DA_ManageDegreeAndCertificate.DanhSachDuocCapBangChungChi(maDotCapBang, updateStaff);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static DataTable DanhSachDuocCapLaiBangChungChi(string maDotCapBang, string updateStaff)
        {
            try
            {
                return DA_ManageDegreeAndCertificate.DanhSachDuocCapLaiBangChungChi(maDotCapBang, updateStaff);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public static DataTable DanhSachDuocCapBangChungChiBanSao(int maDotCapBanSao, string updateStaff)
        {
            try
            {
                return DA_ManageDegreeAndCertificate.DanhSachDuocCapBangChungChiBanSao(maDotCapBanSao, updateStaff);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static int SaveReferenceNumber(string xmlData, string updateStaff)
        {
            try
            {
                return DA_ManageDegreeAndCertificate.SaveReferenceNumber(xmlData, updateStaff);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public static int SaveReferenceNumber_CapLai(string xmlData, string updateStaff)
        {
            try
            {
                return DA_ManageDegreeAndCertificate.SaveReferenceNumber_CapLai(xmlData, updateStaff);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static int CapNhatTraCuuVanBangChungChi(string xmlData, bool traCuu, string updateStaff)
        {
            try
            {
                return DA_ManageDegreeAndCertificate.CapNhatTraCuuVanBangChungChi(xmlData, traCuu, updateStaff);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public static int CapNhatTraCuuVanBangChungChi_CapLai(string xmlData, bool traCuu, string updateStaff)
        {
            try
            {
                return DA_ManageDegreeAndCertificate.CapNhatTraCuuVanBangChungChi_CapLai(xmlData, traCuu, updateStaff);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public static DataSet ThongTinCapBangChungChiPhoiBang(string xmlData, int issueSessionID, string tenForm)
        {
            try
            {
                return DA_ManageDegreeAndCertificate.ThongTinCapBangChungChiPhoiBang(xmlData, issueSessionID, tenForm);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
      
        public static DataSet ThongTinCapBangChungChiPhoiBang_CapLai(string xmlData, int issueSessionID)
        {
            try
            {
                return DA_ManageDegreeAndCertificate.ThongTinCapBangChungChiPhoiBang_CapLai(xmlData, issueSessionID);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public static int SavePrintedTemplate(string xmlData, string updateStaff)
        {
            try
            {
                return DA_ManageDegreeAndCertificate.SavePrintedTemplate(xmlData, updateStaff);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public static int SavePrintedTemplate_CapLai(string xmlData, string updateStaff)
        {
            try
            {
                return DA_ManageDegreeAndCertificate.SavePrintedTemplate_CapLai(xmlData, updateStaff);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public static DataTable PhuLucVanBangChungChi(string xmlData)
        {
            try
            {
                return DA_ManageDegreeAndCertificate.PhuLucVanBangChungChi(xmlData);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static DataSet PhuLucVanBangChungChi_LuanVan(string xmlData)
        {
            try
            {
                return DA_ManageDegreeAndCertificate.PhuLucVanBangChungChi_LuanVan(xmlData);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public static DataTable UAH_PhuLucVanBang(string xmlData, string username, int TemplateTypeID)
        {
            try
            {
                return DA_ManageDegreeAndCertificate.UAH_PhuLucVanBang(xmlData, username, TemplateTypeID);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static int CapSoHieuVanBangChungChi(int degreeAndCertificateID, int issueSessionID, string updateStaff)
        {
            try
            {
                return DA_ManageDegreeAndCertificate.CapSoHieuVanBangChungChi(degreeAndCertificateID, issueSessionID, updateStaff);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public static int CapLaiSoHieuVanBangChungChi(int degreeAndCertificateID, int issueSessionID, string updateStaff)
        {
            try
            {
                return DA_ManageDegreeAndCertificate.CapLaiSoHieuVanBangChungChi(degreeAndCertificateID, issueSessionID, updateStaff);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public static int CancelTemplate(string reason, int degreeAndCertificateID, string serialNumber, string updateStaff, int LoaiHuy)
        {
            try
            {
                return DA_ManageDegreeAndCertificate.CancelTemplate(reason, degreeAndCertificateID, serialNumber, updateStaff, LoaiHuy);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public static int CancelTemplate_CapLai(string reason, int degreeAndCertificateID, string serialNumber, string updateStaff)
        {
            try
            {
                return DA_ManageDegreeAndCertificate.CancelTemplate_CapLai(reason, degreeAndCertificateID, serialNumber, updateStaff);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static int RevokeTemplate(int degreeAndCertificateID, string serialNumber, string updateStaff)
        {
            try
            {
                return DA_ManageDegreeAndCertificate.RevokeTemplate(degreeAndCertificateID, serialNumber, updateStaff);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public static int RevokeTemplate_CapLai(int degreeAndCertificateID, string serialNumber, string updateStaff)
        {
            try
            {
                return DA_ManageDegreeAndCertificate.RevokeTemplate_CapLai(degreeAndCertificateID, serialNumber, updateStaff);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public static int SavePrintedTemplateXml(string xmlData, string updateStaff)
        {
            try
            {
                return DA_ManageDegreeAndCertificate.SavePrintedTemplate(xmlData, updateStaff);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static DataTable GetManageReferenceNumber(int templateTypeID)
        {
            try
            {
                return DA_ManageDegreeAndCertificate.GetManageReferenceNumber(templateTypeID);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static int SaveManageReferenceNumber(int templateTypeID, int referenceNumber, string updateStaff)
        {
            try
            {
                return DA_ManageDegreeAndCertificate.SaveManageReferenceNumber(templateTypeID, referenceNumber, updateStaff);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static DataTable SoGocCapVanChungChungChi(string xmlData)
        {
            try
            {
                return DA_ManageDegreeAndCertificate.SoGocCapVanChungChungChi(xmlData);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public static DataTable TrinhKyVaXacNhanVanBang(string maDotCap, string loaiVanBang, string loaiReport)
        {
            try
            {
                return DA_ManageDegreeAndCertificate.TrinhKyVaXacNhanVanBang(maDotCap, loaiVanBang, loaiReport);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public static DataTable TrinhKyVaXacNhanVanBang_CapLai(string maDotCap, string loaiVanBang, string loaiReport)
        {
            try
            {
                return DA_ManageDegreeAndCertificate.TrinhKyVaXacNhanVanBang(maDotCap, loaiVanBang, loaiReport);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public static DataSet TrinhKyXacNhan(string maDotCap, string loaiVanBang)
        {
            try
            {
                return DA_ManageDegreeAndCertificate.TrinhKyXacNhan(maDotCap, loaiVanBang);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public static DataSet TrinhKyXacNhan_CapLai(string maDotCap, string loaiVanBang)
        {
            try
            {
                return DA_ManageDegreeAndCertificate.TrinhKyXacNhan_CapLai(maDotCap, loaiVanBang);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public static DataTable TMU_TheoDoiNhanQDTN(string xmlData, int templateTypeID, string UpdateStaff)
        {
            try
            {
                return DA_ManageDegreeAndCertificate.TMU_TheoDoiNhanQDTN(xmlData, templateTypeID, UpdateStaff);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public static DataTable SoGocCapVanBangCuNhan(string xmlData)
        {
            try
            {
                return DA_ManageDegreeAndCertificate.SoGocCapVanBangCuNhan(xmlData);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static DataTable TMU_DanhSachVanBangChungChi(string xmlData, int loai)
        {
            try
            {
                return DA_ManageDegreeAndCertificate.TMU_DanhSachVanBangChungChi(xmlData,loai);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public static DataTable SoGocCapVanBangThacSi(string xmlData)
        {
            try
            {
                return DA_ManageDegreeAndCertificate.SoGocCapVanBangThacSi(xmlData);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static DataTable SoGocCapVanBangTienSi(string xmlData)
        {
            try
            {
                return DA_ManageDegreeAndCertificate.SoGocCapVanBangTienSi(xmlData);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public static DataTable SoGocCapVanBangCCNN(string xmlData)
        {
            try
            {
                return DA_ManageDegreeAndCertificate.SoGocCapVanBangCCNN(xmlData);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        
        public static int CancelIsPrinted(string reason, int degreeAndCertificateID, string serialNumber, string updateStaff)
        {
            try
            {
                return DA_ManageDegreeAndCertificate.CancelIsPrinted(reason, degreeAndCertificateID, serialNumber, updateStaff);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public static int CancelIsPrinted_CapLai(string reason, int degreeAndCertificateID, string serialNumber, string updateStaff)
        {
            try
            {
                return DA_ManageDegreeAndCertificate.CancelIsPrinted_CapLai(reason, degreeAndCertificateID, serialNumber, updateStaff);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public static int CancelIsDuplicatePrinted(string reason, int degreeAndCertificateID, string updateStaff)
        {
            try
            {
                return DA_ManageDegreeAndCertificate.CancelIsDuplicatePrinted(reason, degreeAndCertificateID, updateStaff);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static DataTable DanhSachSVDuocCapBangChungChi(string XmlDotCap)
        {
            try
            {
                return DA_ManageDegreeAndCertificate.DanhSachSVDuocCapBangChungChi(XmlDotCap);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static int LuuThongTinBangChungChi(string xmlData, string updateStaff)
        {
            try
            {
                return DA_ManageDegreeAndCertificate.LuuThongTinBangChungChi(xmlData, updateStaff);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public static int LuuThongTinBangChungChi_CapLai(string xmlData, string updateStaff)
        {
            try
            {
                return DA_ManageDegreeAndCertificate.LuuThongTinBangChungChi_CapLai(xmlData, updateStaff);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public static DataTable SinhVienNhanBangChungChi(string maLoaiChungChi, string maBacDaoTao, string maSinhVien, string hoVaTen,
            string ngaySinh, string noiSinh, string namTN, string soHieu, bool isKiemTraBacDT, bool foreignLanguage)
        {
            try
            {
                return DA_ManageDegreeAndCertificate.SinhVienNhanBangChungChi(maLoaiChungChi, maBacDaoTao, maSinhVien, hoVaTen, ngaySinh, noiSinh, namTN, soHieu, isKiemTraBacDT, foreignLanguage);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static int LuuDuLieuExcel(string xmlData, string updateStaff)
        {
            try
            {
                return DA_ManageDegreeAndCertificate.LuuDuLieuExcel(xmlData, updateStaff);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static DataTable GetDuplicateIssueSession(int templateTypeID, string userID)
        {
            try
            {
                return DA_ManageDegreeAndCertificate.GetDuplicateIssueSession(templateTypeID, userID);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static DataTable GetDuplicateIssueSession_StringTemplateType(string templateTypeID, string userID)
        {
            try
            {
                return DA_ManageDegreeAndCertificate.GetDuplicateIssueSession_StringTemplateType(templateTypeID, userID);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static int SaveDuplicateIssueSession(string xmlData, string updateStaff)
        {
            try
            {
                return DA_ManageDegreeAndCertificate.SaveDuplicateIssueSession(xmlData, updateStaff);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static int DeleteDuplicateIssueSession(string xmlData, string updateStaff)
        {
            try
            {
                return DA_ManageDegreeAndCertificate.DeleteDuplicateIssueSession(xmlData, updateStaff);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static DataTable DuplicateNumber(int templateTypeID)
        {
            try
            {
                return DA_ManageDegreeAndCertificate.DuplicateNumber(templateTypeID);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static int SaveDuplicateNumber(int templateTypeID, string xmlData, string updateStaff)
        {
            try
            {
                return DA_ManageDegreeAndCertificate.SaveDuplicateNumber(templateTypeID, xmlData, updateStaff);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static DataTable DanhSachDuocCapBangChungChiCanCapBanSao(string maDotCapBang, string thongTinSinhVien)
        {
            try
            {
                return DA_ManageDegreeAndCertificate.DanhSachDuocCapBangChungChiCanCapBanSao(maDotCapBang, thongTinSinhVien);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static int CapSoVaoSoBanSao(string xmlData, int maDotCapBanSao, int numberCopy, string updateStaff, int templateTypeID)
        {
            try
            {
                return DA_ManageDegreeAndCertificate.CapSoVaoSoBanSao(xmlData, maDotCapBanSao, numberCopy, updateStaff, templateTypeID);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public static int CapSoVaoSoBanSao_Import(string xmlData, int maDotCapBanSao, int numberCopy, string updateStaff, int templateTypeID)
        {
            try
            {
                return DA_ManageDegreeAndCertificate.CapSoVaoSoBanSao_Import(xmlData, maDotCapBanSao, numberCopy, updateStaff, templateTypeID);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static int XoaDanhSachCapBanSao(string xmlData, int maDotCapBanSao, string updateStaff)
        {
            try
            {
                return DA_ManageDegreeAndCertificate.XoaDanhSachCapBanSao(xmlData, maDotCapBanSao, updateStaff);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static DataTable ThongTinCapBangSao(string xmlData)
        {
            try
            {
                return DA_ManageDegreeAndCertificate.ThongTinCapBangSao(xmlData);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public static DataTable ThongTinCapBangSao(string xmlData, string capBac, string nguoiCap, string hieuTruong)
        {
            try
            {
                return DA_ManageDegreeAndCertificate.ThongTinCapBangSao(xmlData, capBac,  nguoiCap,  hieuTruong);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public static DataTable ThongTinCapBangSao_Review(string xmlData)
        {
            try
            {
                return DA_ManageDegreeAndCertificate.ThongTinCapBangSao_Review(xmlData);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public static DataTable ThongTinCapBangSao_Review(string xmlData, string CapBac, string NguoiCap, string HieuTruong)
        {
            try
            {
                return DA_ManageDegreeAndCertificate.ThongTinCapBangSao_Review(xmlData, CapBac, NguoiCap, HieuTruong);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public static DataTable SoGocCapBanSaoVanChungChungChi(string xmlData)
        {
            try
            {
                return DA_ManageDegreeAndCertificate.SoGocCapBanSaoVanChungChungChi(xmlData);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public static DataTable BaoCaoViecInVaSuDungPhoiBang(int templateType, int fromYear, int toYear)
        {
            try
            {
                return DA_ManageDegreeAndCertificate.BaoCaoViecInVaSuDungPhoiBang(templateType, fromYear, toYear);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static DataTable MauInAn(int templateTypeID, bool foreignLanguage)
        {
            try
            {
                return DA_ManageDegreeAndCertificate.MauInAn(templateTypeID, foreignLanguage);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static int LuuMauInAn(string xmlData, int templateTypeID, string updateStaff)
        {
            try
            {
                return DA_ManageDegreeAndCertificate.LuuMauInAn(xmlData, templateTypeID, updateStaff);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static int XoaMauInAn(string xmlData, string updateStaff)
        {
            try
            {
                return DA_ManageDegreeAndCertificate.XoaMauInAn(xmlData, updateStaff);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static int DanhSachCapVanBangChungChi_CapNhatTinhTrang(string xmlData, string updateStaff)
        {
            try
            {
                return DA_ManageDegreeAndCertificate.DanhSachCapVanBangChungChi_CapNhatTinhTrang(xmlData, updateStaff);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public static DataTable CheckStudentName(string strXml, string updateStaff)
        {
            try
            {
                return DA_ManageDegreeAndCertificate.CheckStudentName(strXml, updateStaff);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public static DataTable CheckStudentName_CapLai(string strXml, string updateStaff)
        {
            try
            {
                return DA_ManageDegreeAndCertificate.CheckStudentName_CapLai(strXml, updateStaff);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public static DataTable BangDiemTotNghiep1Cot(string strXml, string nhomBieuMau)
        {
            try
            {
                return DA_ManageDegreeAndCertificate.BangDiemTotNghiep1Cot(strXml, nhomBieuMau);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static DataTable BangDiemTotNghiep2Cot(string strXml, string nhomBieuMau)
        {
            try
            {
                return DA_ManageDegreeAndCertificate.BangDiemTotNghiep2Cot(strXml, nhomBieuMau);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public static DataTable MKU_PhuLucBangCuNhan(string strXml)
        {
            try
            {
                return DA_ManageDegreeAndCertificate.MKU_PhuLucBangCuNhan(strXml);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static DataTable InBangDiemChungChi(string strXml, string nhomBieuMau)
        {
            try
            {
                return DA_ManageDegreeAndCertificate.InBangDiemChungChi(strXml, nhomBieuMau);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static DataTable LayDotHuyPhoi(string _UserID)
        {
            try
            {
                return DA_ManageDegreeAndCertificate.LayDotHuyPhoi(_UserID);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static int CapNhatDotHuyPhoi(string strXml, bool isDel, string _UserID)
        {
            try
            {
                return DA_ManageDegreeAndCertificate.CapNhatDotHuyPhoi(strXml, isDel, _UserID);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static DataTable LayPhoiVaDotHuy(string maDotHuy, bool foreignLangugeData, int trongDot)
        {
            try
            {
                return DA_ManageDegreeAndCertificate.LayPhoiVaDotHuy(maDotHuy, foreignLangugeData, trongDot);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static int CapNhatPhoiVaDotHuyPhoi(string xmlData, bool isDel, string _UserID)
        {
            try
            {
                return DA_ManageDegreeAndCertificate.CapNhatPhoiVaDotHuyPhoi(xmlData, isDel, _UserID);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static DataTable TMU_BienBanHuyPhoi(string strXml, string _UserID)
        {
            try
            {
                return DA_ManageDegreeAndCertificate.TMU_BienBanHuyPhoi(strXml, _UserID);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static DataSet LAW_BienBanHuyPhoi(string strXml)
        {
            try
            {
                return DA_ManageDegreeAndCertificate.LAW_BienBanHuyPhoi(strXml);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static DataTable LAW_QuanLyXuatNhapTonPhoi(string TemplateTypeID, string reportID, string strXml)
        {
            try
            {
                return DA_ManageDegreeAndCertificate.LAW_QuanLyXuatNhapTonPhoi(TemplateTypeID, reportID, strXml);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }



        public static DataTable LAW_QuanLyXuatNhapTonPhoiBanSao(string TemplateTypeID, string reportID, string strXml)
        {
            try
            {
                return DA_ManageDegreeAndCertificate.LAW_QuanLyXuatNhapTonPhoiBanSao(TemplateTypeID, reportID, strXml);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static int CapNhatTinhTrangPhoi(string strXml, string reason, int status, string _UserID)
        {
            try
            {
                return DA_ManageDegreeAndCertificate.CapNhatTinhTrangPhoi(strXml, reason, status, _UserID);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static DataTable SoGocCapVanBangChungChi(string strXml, string reportID)
        {
            try
            {
                return DA_ManageDegreeAndCertificate.SoGocCapVanBangChungChi(strXml, reportID);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public static DataTable ChungNhanTotNghiepVaCTDT(string strXml)
        {
            try
            {
                return DA_ManageDegreeAndCertificate.ChungNhanTotNghiepVaCTDT(strXml);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public static DataTable GetTemplateStatus(string _UserID, bool foreignLanguage)
        {
            try
            {
                return DA_ManageDegreeAndCertificate.GetTemplateStatus(_UserID, foreignLanguage);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static DataTable XacNhanVanBangChungChi_TheoFile(string strXml, string maLoaiChungChi)
        {
            try
            {
                return DA_ManageDegreeAndCertificate.XacNhanVanBangChungChi_TheoFile(strXml, maLoaiChungChi);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static DataSet XacNhanVanBangChungChi_TheoFile_InXacNhan(string strXml, string maLoaiChungChi)
        {
            try
            {
                return DA_ManageDegreeAndCertificate.XacNhanVanBangChungChi_TheoFile_InXacNhan(strXml, maLoaiChungChi);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static DataTable BienBanGhiNhanPhoiHong(string strXml)
        {
            try
            {
                return DA_ManageDegreeAndCertificate.BienBanGhiNhanPhoiHong(strXml);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static DataTable BienBanNghiemThuPhoi(string strXml)
        {
            try
            {
                return DA_ManageDegreeAndCertificate.BienBanNghiemThuPhoi(strXml);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static DataTable HNUE_QuyetDinhCapChungChi(string strXml, int maLoaiChungChi, string type)
        {
            try
            {
                return DA_ManageDegreeAndCertificate.HNUE_QuyetDinhCapChungChi(strXml, maLoaiChungChi, type);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static DataTable GiayDeNghiCapPhoi(string strXml, int _templateTypeID, string _reportName, string _UserID)
        {
            try
            {
                return DA_ManageDegreeAndCertificate.GiayDeNghiCapPhoi(strXml, _templateTypeID, _reportName, _UserID);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static DataTable QuyetDinhThanhLapHoiDongHuyPhoi(string dotHuyPhoi, string _UserID)
        {
            try
            {
                return DA_ManageDegreeAndCertificate.QuyetDinhThanhLapHoiDongHuyPhoi(dotHuyPhoi, _UserID);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static DataTable XacMinhVanBangChungChi(string templateType)
        {
            try
            {
                return DA_ManageDegreeAndCertificate.XacMinhVanBangChungChi(templateType);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static int XoaXacMinhVanBangChungChi(string strXml, string _UserID)
        {
            try
            {
                return DA_ManageDegreeAndCertificate.XoaXacMinhVanBangChungChi(strXml, _UserID);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public static DataTable ThongKeXacMinh_Excel(string strXml, string report)
        {
            try
            {
                return DA_ManageDegreeAndCertificate.ThongKeXacMinh_Excel(strXml, report);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public static int LuuXacMinhVanBangChungChi(int templateTypeID, string strXml, string _UserID)
        {
            try
            {
                return DA_ManageDegreeAndCertificate.LuuXacMinhVanBangChungChi(templateTypeID, strXml, _UserID);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


        public static DataSet InXacNhanVanBangChungChi(string strXml, string maLoaiChungChi)
        {
            try
            {
                return DA_ManageDegreeAndCertificate.XacNhanVanBangChungChi_TheoFile_InXacNhan(strXml, maLoaiChungChi);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static DataTable DanhSachCanXacMinhVanBang(int xacMinhID)
        {
            try
            {
                return DA_ManageDegreeAndCertificate.DanhSachCanXacMinhVanBang(xacMinhID);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


        public static DataTable DanhSachCanXacMinhVBCC_XMLID(string xmlTemplateTypeID)
        {
            try
            {
                return DA_ManageDegreeAndCertificate.DanhSachCanXacMinhVBCC_XMLID(xmlTemplateTypeID);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static DataTable DanhSachCanXacMinhVBCC(string xmlData, string reportID, string capBac, string nguoiKy)
        {
            try
            {
                return DA_ManageDegreeAndCertificate.DanhSachCanXacMinhVBCC(xmlData, reportID, capBac, nguoiKy);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static int XoaDanhSachXacMinhVanBangChungChi(string strXml, string updateStaff)
        {
            try
            {
                return DA_ManageDegreeAndCertificate.XoaDanhSachXacMinhVanBangChungChi(strXml, updateStaff);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static int LuuDanhSachXacMinhVanBangChungChi(string strXml, string _UserID)
        {
            try
            {
                return DA_ManageDegreeAndCertificate.LuuDanhSachXacMinhVanBangChungChi(strXml, _UserID);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static int KiemTraDanhSachXacMinhVanBangChungChi(string strXml, string _UserID)
        {
            try
            {
                return DA_ManageDegreeAndCertificate.KiemTraDanhSachXacMinhVanBangChungChi(strXml, _UserID);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static int KhoaDuLieuPhoiHuy(string dotHuyPhoi, bool locked, string _UserID)
        {
            try
            {
                return DA_ManageDegreeAndCertificate.KhoaDuLieuPhoiHuy(dotHuyPhoi, locked, _UserID);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static int LuuThongTinChuyenNganh(string xmlData, string updateStaff)
        {
            try
            {
                return DA_ManageDegreeAndCertificate.LuuThongTinChuyenNganh(xmlData, updateStaff);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static int LuuFileCongVan(int ID, string updateStaff, string file)
        {
            try
            {
                return DA_ManageDegreeAndCertificate.LuuFileCongVan(ID, updateStaff, file);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static DataTable GetFile(int loaiChucNang, int maDot)
        {
            try
            {
                return DA_ManageDegreeAndCertificate.GetFile(loaiChucNang, maDot);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public static DataTable DanhSachCanSuaThongTinSinhVien(string strXml, string updateStaff)
        {
            try
            {
                return DA_ManageDegreeAndCertificate.DanhSachCanSuaThongTinSinhVien(strXml, updateStaff);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public static DataTable DanhSachCanSuaThongTinSinhVien_SauLuu(string strXml, string updateStaff)
        {
            try
            {
                return DA_ManageDegreeAndCertificate.DanhSachCanSuaThongTinSinhVien_SauLuu(strXml, updateStaff);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public static DataTable LayThanhPhanThamDu(int idForm, int maDot)
        {
            try
            {
                return DA_ManageDegreeAndCertificate.LayThanhPhanThamDu(idForm, maDot);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static int DeleteFile(int loaiChucNang, string xmlData, string updateStaff)
        {
            try
            {
                return DA_ManageDegreeAndCertificate.DeleteFile(loaiChucNang, xmlData, updateStaff);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public static int XoaThanhPhanThamDu(string xmlData, string updateStaff)
        {
            try
            {
                return DA_ManageDegreeAndCertificate.XoaThanhPhanThamDu( xmlData, updateStaff);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public static int SaveFile(int loaiChucNang, string xmlData, string updateStaff)
        {
            try
            {
                return DA_ManageDegreeAndCertificate.SaveFile(loaiChucNang, xmlData, updateStaff);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public static int LuuThongTinSinhVienCanCap(string xmlData, string updateStaff)
        {
            try
            {
                return DA_ManageDegreeAndCertificate.LuuThongTinSinhVienCanCap(xmlData, updateStaff);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public static int LuuThanhPhanThamDu(string xmlData, string updateStaff, int idForm, int maDot)
        {
            try
            {
                return DA_ManageDegreeAndCertificate.LuuThanhPhanThamDu(xmlData, updateStaff, idForm, maDot);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static DataTable LayQuyetDinhDotHuyPhoi(string maDotHuyPhoi)
        {
            try
            {
                return DA_ManageDegreeAndCertificate.LayQuyetDinhDotHuyPhoi(maDotHuyPhoi);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static DataTable LayQuyetDinhDotCap(string maDotCap)
        {
            try
            {
                return DA_ManageDegreeAndCertificate.LayQuyetDinhDotCap(maDotCap);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static int LuuFileQuyetDinhDotHuyPhoi(int ID, string updateStaff, string file)
        {
            try
            {
                return DA_ManageDegreeAndCertificate.LuuFileQuyetDinhDotHuyPhoi(ID, updateStaff, file);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static int LuuQuyetDinhDotHuyPhoi(string xmlData, string updateStaff)
        {
            try
            {
                return DA_ManageDegreeAndCertificate.LuuQuyetDinhDotHuyPhoi(xmlData, updateStaff);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static int LuuNgayNhanBang(string xmlData, string updateStaff)
        {
            try
            {
                return DA_ManageDegreeAndCertificate.LuuNgayNhanBang(xmlData, updateStaff);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static int CreateQRCode(string xmlData, string updateStaff)
        {
            try
            {
                return DA_ManageDegreeAndCertificate.CreateQRCode(xmlData, updateStaff);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public static int CreateQRCode_CapLai(string xmlData, string updateStaff)
        {
            try
            {
                return DA_ManageDegreeAndCertificate.CreateQRCode_CapLai(xmlData, updateStaff);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
