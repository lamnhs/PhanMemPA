using CMSCore.DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMSCore.BLL
{
    public class BL_SinhVienNhanBangOnline
    {
        public static DataTable GetSinhVienTrongDotDangKyLeTotNghiep(int dotDangKy)
        {
            try
            {
                return DA_SinhVienNhanBangOnline.GetSinhVienTrongDotDangKyLeTotNghiep(dotDangKy);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static DataTable GetDotDangKyLeTotNghiepOnline(int _templateTypeID, string _UserID)
        {
            try
            {
                return DA_SinhVienNhanBangOnline.GetDotDangKyLeTotNghiepOnline(_templateTypeID, _UserID);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static int SaveDotDangKyLeTotNghiepOnline(string strXml, int _templateTypeID, bool isDel, string _UserID)
        {
            try
            {
                return DA_SinhVienNhanBangOnline.SaveDotDangKyLeTotNghiepOnline(strXml, _templateTypeID, isDel, _UserID);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static DataTable GetSinhVienNgoaiDotDangKyLeTotNghiep(int dotDangKy, int dotCap)
        {
            try
            {
                return DA_SinhVienNhanBangOnline.GetSinhVienNgoaiDotDangKyLeTotNghiep(dotDangKy, dotCap);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static int CapNhatSinhVienDotDangKyLeTotNghiep(string xmlData, int dotDangKy, bool isDel, string _UserID)
        {
            try
            {
                return DA_SinhVienNhanBangOnline.CapNhatSinhVienDotDangKyLeTotNghiep(xmlData, dotDangKy, isDel, _UserID);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static DataTable GetDotDangKyLeTotNghiepChiTiet(int _dotDangKy, string _UserID)
        {
            try
            {
                return DA_SinhVienNhanBangOnline.GetDotDangKyLeTotNghiepChiTiet(_dotDangKy, _UserID);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static int SaveDotDangKyLeTotNghiepChiTiet(string strXml, bool isDel, int _dotDangKy, string _UserID)
        {
            try
            {
                return DA_SinhVienNhanBangOnline.SaveDotDangKyLeTotNghiepChiTiet(strXml, isDel, _dotDangKy, _UserID);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static DataTable GetSinhVienDangKyLeTotNghiepOnline(string maDot, string _UserID)
        {
            try
            {
                return DA_SinhVienNhanBangOnline.GetSinhVienDangKyLeTotNghiepOnline(maDot, _UserID);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public static DataTable GetReportSinhVienDangKyThamGiaLeTotNghiep(string maLoaiChungChi, int dotDangKy, string LoaiReport, string xmlData)
        {
            try
            {
                return DA_SinhVienNhanBangOnline.GetReportSinhVienDangKyThamGiaLeTotNghiep(maLoaiChungChi, dotDangKy, LoaiReport, xmlData);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public static int SaveSinhVienDangKyThamGiaLeTotNghiep(string strXml, bool isDel, string _UserID)
        {
            try
            {
                return DA_SinhVienNhanBangOnline.SaveSinhVienDangKyThamGiaLeTotNghiep(strXml, isDel, _UserID);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static int LuuDanhSachSinhVienDangKyTotNghiep(string xmlData, string updateStaff)
        {
            try
            {
                return DA_SinhVienNhanBangOnline.LuuDanhSachSinhVienDangKyTotNghiep(xmlData, updateStaff);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static DataTable LayDanhSachDangKyDuLeTotNghiep(string maLoaiChungChi, string maBacDaoTao, string maSinhVien, string hoVaTen, string ngaySinh, string noiSinh, string namTN, string soHieu, int maDotCap, bool apDungDotCap, int maDotDangKy, bool foreignLanguage)
        {
            try
            {
                return DA_SinhVienNhanBangOnline.LayDanhSachDangKyDuLeTotNghiep(maLoaiChungChi, maBacDaoTao, maSinhVien, hoVaTen, ngaySinh, noiSinh, namTN, soHieu, maDotCap, apDungDotCap, maDotDangKy, foreignLanguage);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
