using CMSCore.DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMSCore.BLL
{
    public class BL_HeThong
    {
        #region Lưới hiển thị
        public static DataTable LuoiHienThi()
        {
            try
            {
                return DA_HeThong.LuoiHienThi();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static string LuuLuoiHienThi(string strXml, string updateStaff)
        {
            try
            {
                return DA_HeThong.LuuLuoiHienThi(strXml, updateStaff);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static string XoaLuoiHienThi(string strXml, string updateStaff)
        {
            try
            {
                return DA_HeThong.XoaLuoiHienThi(strXml, updateStaff);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        #endregion

        #region Cột hiển thị trên lưới
        public static DataTable CotLuoiHienThi(string gridID)
        {
            try
            {
                return DA_HeThong.CotLuoiHienThi(gridID);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static string LuuCotLuoiHienThi(string gridID, string strXml, string updateStaff)
        {
            try
            {
                return DA_HeThong.LuuCotLuoiHienThi(gridID, strXml, updateStaff);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static string XoaCotLuoiHienThi(string gridID, string strXml, string updateStaff)
        {
            try
            {
                return DA_HeThong.XoaCotLuoiHienThi(gridID, strXml, updateStaff);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        #endregion

        #region Đóng dấu, ký tên
        public static DataTable ThongTinDongDauKyTen()
        {
            try
            {
                return DA_HeThong.ThongTinDongDauKyTen();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static string LuuThongTinDongDauKyTen(string strXml, string updateStaff)
        {
            try
            {
                return DA_HeThong.LuuThongTinDongDauKyTen(strXml, updateStaff);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        #endregion

        #region Hình thức xét
        public static DataTable HinhThucXet()
        {
            try
            {
                return DA_HeThong.HinhThucXet();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static string LuuHinhThucXet(string strXml, string updateStaff)
        {
            try
            {
                return DA_HeThong.LuuHinhThucXet(strXml, updateStaff);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static string XoaHinhThucXet(string strXml, string updateStaff)
        {
            try
            {
                return DA_HeThong.XoaHinhThucXet(strXml, updateStaff);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        #endregion

        #region Loại xét
        public static DataTable LoaiXet()
        {
            try
            {
                return DA_HeThong.LoaiXet();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static int LuuLoaiXet(string XmlData, string updateStaff)
        {
            try
            {
                return DA_HeThong.LuuLoaiXet(XmlData, updateStaff);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static int XoaLoaiXet(string XmlData, string updateStaff)
        {
            try
            {
                return DA_HeThong.XoaLoaiXet(XmlData, updateStaff);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        #endregion

        public static DataTable NhomMonHoc()
        {
            try
            {
                return DA_HeThong.NhomMonHoc();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public static int UpdateChuKy_Image(string Id, byte[] image, string updateStaff)
        {
            try
            {
                return DA_HeThong.UpdateChuKy_Image(Id, image, updateStaff);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public static string XoaThongTinNguoiDongDauKyTen(string strXml, string updateStaff)
        {
            try
            {
                return DA_HeThong.XoaThongTinNguoiDongDauKyTen(strXml, updateStaff);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public static string LuuThongTinNguoiDongDauKyTen(string strXml, string updateStaff)
        {
            try
            {
                return DA_HeThong.LuuThongTinNguoiDongDauKyTen(strXml, updateStaff);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public static DataTable ThongTinNguoiDongDauKyTen(string staffID)
        {
            try
            {
                return DA_HeThong.ThongTinNguoiDongDauKyTen(staffID);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        #region Cấu hình tình trạng
        public static DataTable CauHinhTinhTrang(string maLoaiXet)
        {
            try
            {
                return DA_HeThong.CauHinhTinhTrang(maLoaiXet);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static int LuuCauHinhTinhTrang(string XmlData, string updateStaff)
        {
            try
            {
                return DA_HeThong.LuuCauHinhTinhTrang(XmlData, updateStaff);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        #endregion

        #region Phân quyền loại xét
        public static DataTable PhanQuyenLoaiXet(string maLoaiXet)
        {
            try
            {
                return DA_HeThong.PhanQuyenLoaiXet(maLoaiXet);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static int LuuPhanQuyenLoaiXet(string XmlData, string updateStaff)
        {
            try
            {
                return DA_HeThong.LuuPhanQuyenLoaiXet(XmlData, updateStaff);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        #endregion

        #region Phân quyền loại xét
        public static DataTable PhanQuyenDonVi(string maLoaiXet, string nguoiDung)
        {
            try
            {
                return DA_HeThong.PhanQuyenDonVi(maLoaiXet, nguoiDung);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static int LuuPhanQuyenDonVi(string XmlData, string updateStaff)
        {
            try
            {
                return DA_HeThong.LuuPhanQuyenDonVi(XmlData, updateStaff);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        #endregion

        public static DataTable KhoaHoc(string StudyTypeID, string GraduateLevelID)
        {
            try
            {
                return DA_HeThong.KhoaHoc(StudyTypeID, GraduateLevelID);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static DataTable DanhSachLop(string khoa, string bcDaoTao, string LHDT, string khoaCQ, string nganh, string CTDT)
        {
            try
            {
                return DA_HeThong.DanhSachLop(khoa, bcDaoTao, LHDT, khoaCQ, nganh, CTDT);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static DataTable NganhDaoTao(string Khoa, string bacDaoTao, string LHDT)
        {
            try
            {
                return DA_HeThong.NganhDaoTao(Khoa, bacDaoTao, LHDT);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static DataTable ChuongTrinhDaoTao(string khoa, string nganh, string bacDaoTao, string LHDT, string khoaChuQuan)
        {
            try
            {
                return DA_HeThong.ChuongTrinhDaoTao(khoa, nganh, bacDaoTao, LHDT, khoaChuQuan);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static DataTable DanhHieu()
        {
            try
            {
                return DA_HeThong.DanhHieu();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static int LuuDanhHieu(string xmlData, string updateStaff)
        {
            try
            {
                return DA_HeThong.LuuDanhHieu(xmlData, updateStaff);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static int XoaDanhHieu(string xmlData, string updateStaff)
        {
            try
            {
                return DA_HeThong.XoaDanhHieu(xmlData, updateStaff);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        #region Mẫu in ấn
        public static DataTable MauInAn(string maLoaiXet, bool user)
        {
            try
            {
                return DA_HeThong.MauInAn(maLoaiXet, user);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static DataTable ChucNangCoInAn()
        {
            try
            {
                return DA_HeThong.ChucNangCoInAn();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static int LuuMauInAn(string xmlData, string maLoaiXet, string updateStaff)
        {
            try
            {
                return DA_HeThong.LuuMauInAn(xmlData, maLoaiXet, updateStaff);
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
                return DA_HeThong.XoaMauInAn(xmlData, updateStaff);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static int SaveTemplateReports(string reportID, string parentReportID, byte[] reportData, string updateStaff)
        {
            try
            {
                return DA_HeThong.SaveTemplateReports(reportID, parentReportID, reportData, updateStaff);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static DataTable MauInAn(string maLoaiXet, string chucNang)
        {
            try
            {
                return DA_HeThong.MauInAn(maLoaiXet, chucNang);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        #endregion

        #region Ngành theo khóa
        public static DataTable NganhTheoKhoa(string courseID)
        {
            try
            {
                return DA_HeThong.NganhTheoKhoa(courseID);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static int LuuNganhTheoKhoa(string courseID, string xmlData, string updateStaff)
        {
            try
            {
                return DA_HeThong.LuuNganhTheoKhoa(courseID, xmlData, updateStaff);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static int XoaNganhTheoKhoa(string courseID, string xmlData, string updateStaff)
        {
            try
            {
                return DA_HeThong.XoaNganhTheoKhoa(courseID, xmlData, updateStaff);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        #endregion

        public static DataTable MauInAn_UserID(string loaiXet, string formName, string _UserID)
        {
            try
            {
                return DA_HeThong.MauInAn_UserID(loaiXet, formName, _UserID);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static DataTable LoaiTuDienDuLieu(string formID)
        {
            try
            {
                return DA_HeThong.LoaiTuDienDuLieu(formID);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static DataTable LayThongTinTuDienDuLieu(string _loaiDuLieu)
        {
            try
            {
                return DA_HeThong.LayThongTinTuDienDuLieu(_loaiDuLieu);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static string CapNhatThongTinTuDienDuLieu(string strXml, string _loaiDuLieu, string _UserID)
        {
            try
            {
                return DA_HeThong.CapNhatThongTinTuDienDuLieu(strXml, _loaiDuLieu, _UserID);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static DataTable TimKiemThongTinSinhVien(string search, bool foreignLanguage)
        {
            try
            {
                return DA_HeThong.TimKiemThongTinSinhVien(search, foreignLanguage);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static void SaveListOfForms(string moduleID, string formID, string formName, string userID)
        {
            try
            {
                DA_HeThong.SaveListOfForms(moduleID, formID, formName, userID);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static void SaveListOfFormObjects(string moduleID, string formID, string controlID, string objectName, string typeObject, string parentObject)
        {
            try
            {
                DA_HeThong.SaveListOfFormObjects(moduleID, formID, controlID, objectName, typeObject, parentObject);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static DataTable GetForm()
        {
            try
            {
                return DA_HeThong.GetForm();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static DataTable GetFormObject(string formID)
        {
            try
            {
                return DA_HeThong.GetFormObject(formID);
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
                return DA_HeThong.LuuFileCongVan(ID, updateStaff, file);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
