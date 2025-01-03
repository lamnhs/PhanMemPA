using CMSCore.DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMSCore.BLL
{
    public class BL_System
    {
        public static string LockUser(string StaffID)
        {
            try
            {
                return DA_System.LockUser(StaffID);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static DataTable GetGroupUserByStaffID(string staffID)
        {
            try
            {
                return DA_System.GetGroupUserByStaffID(staffID);
            }
            catch (Exception err)
            {
                throw new Exception(err.Message);
            }
        }

        public static int Login(string staffID, string password)
        {
            try
            {
                return DA_System.Login(staffID, password);
            }
            catch (Exception err)
            {
                throw new Exception(err.Message);
            }
        }

        public static DataTable GetStaffs(string userID)
        {
            try
            {
                return DA_System.GetStaffs(userID);
            }
            catch (Exception err)
            {
                throw new Exception(err.Message);
            }
        }

        public static DataSet GetDataSetDataDictionary(string staffID)
        {
            try
            {
                return DA_System.GetDataSetDataDictionary(staffID);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static int UpdateCurrentValues(string userID, string currentTerm, string currentYearStudy, string currentGraduateLevelID, string currentStudyTypeID)
        {
            try
            {
                return DA_System.UpdateCurrentValues(userID, currentTerm, currentYearStudy, currentGraduateLevelID, currentStudyTypeID);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static string ChangePassword(string staffID, string newPassword, string oldPassword)
        {
            try
            {
                return DA_System.ChangePassword(staffID, newPassword, oldPassword);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static DataTable GetSystemConfig()
        {
            try
            {
                return DA_System.GetSystemConfig();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static int UpdateSystemConfig(string ConfigID, string ConfigName, string updateStaff)
        {
            try
            {
                return DA_System.UpdateSystemConfig(ConfigID, ConfigName, updateStaff);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static int UpdateSystemConfig_Logo(string ConfigID, string ConfigName, byte[] image, string updateStaff)
        {
            try
            {
                return DA_System.UpdateSystemConfig_Logo(ConfigID, ConfigName, image, updateStaff);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static DataTable GetGrid()
        {
            try
            {
                return DA_System.GetGrid();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static DataTable GetNewItemRowPosition()
        {
            try
            {
                return DA_System.GetNewItemRowPosition();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static DataTable GetMultiSelectMode()
        {
            try
            {
                return DA_System.GetMultiSelectMode();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static int SaveGrid(string strXml, string updateStaff)
        {
            try
            {
                return DA_System.SaveGrid(strXml, updateStaff);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static int DeleteGrid(string strXml, string updateStaff)
        {
            try
            {
                return DA_System.DeleteGrid(strXml, updateStaff);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static DataTable GetGridColumn(string gridID)
        {
            try
            {
                return DA_System.GetGridColumn(gridID);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static DataTable GetSummaryType()
        {
            try
            {
                return DA_System.GetSummaryType();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static DataTable GetAlignType()
        {
            try
            {
                return DA_System.GetAlignType();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static DataTable GetFixedType()
        {
            try
            {
                return DA_System.GetFixedType();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static int SaveGridColumn(string gridID, string strXml, string updateStaff)
        {
            try
            {
                return DA_System.SaveGridColumn(gridID, strXml, updateStaff);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static int DeleteGridColumn(string gridID, string strXml, string updateStaff)
        {
            try
            {
                return DA_System.DeleteGridColumn(gridID, strXml, updateStaff);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static DataTable GetReport()
        {
            try
            {
                return DA_System.GetReport();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static int SaveReport(string strXml, string updateStaff)
        {
            try
            {
                return DA_System.SaveReport(strXml, updateStaff);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static int DeleteReport(string strXml, string updateStaff)
        {
            try
            {
                return DA_System.DeleteReport(strXml, updateStaff);
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
                return DA_System.GetNhanVien();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public static DataTable GetTinhTrangFile()
        {
            try
            {
                return DA_System.GetTinhTrangFile();
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
                return DA_System.GetKhachHang();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static int SaveDegreeAndCertificateType(string strXml, string updateStaff)
        {
            try
            {
                return DA_System.SaveDegreeAndCertificateType(strXml, updateStaff);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static int DeleteDegreeAndCertificateType(string strXml, string updateStaff)
        {
            try
            {
                return DA_System.DeleteDegreeAndCertificateType(strXml, updateStaff);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static DataTable GetAuditType()
        {
            try
            {
                return DA_System.GetAuditType();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static DataSet GetPermissionOfUser(string templateTypeID, bool foreignLanguage)
        {
            try
            {
                return DA_System.GetPermissionOfUser(templateTypeID, foreignLanguage);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static int SavePermissionOfUser(string templateTypeID, string nhomNguoiDung, string nguoiDung, string updateStaff)
        {
            try
            {
                return DA_System.SavePermissionOfUser(templateTypeID, nhomNguoiDung, nguoiDung, updateStaff);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static DataTable GetDataField()
        {
            try
            {
                return DA_System.GetDataField();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static int SaveDataField(string xmlData, string updateStaff)
        {
            try
            {
                return DA_System.SaveDataField(xmlData, updateStaff);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static int DeleteDataField(string xmlData, string updateStaff)
        {
            try
            {
                return DA_System.DeleteDataField(xmlData, updateStaff);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static DataTable GetCourse(string graduateLevelID, string studyTypeID)
        {
            try
            {
                return DA_System.GetCourse(graduateLevelID, studyTypeID);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static DataTable GetSignBy(string staffID)
        {
            try
            {
                return DA_System.GetSignBy(staffID);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static int SaveSignBy(string strXml, string updateStaff)
        {
            try
            {
                return DA_System.SaveSignBy(strXml, updateStaff);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static int DeteleSignBy(string strXml, string updateStaff)
        {
            try
            {
                return DA_System.DeteleSignBy(strXml, updateStaff);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static DataTable MauReportInAn(int templateTypeID, string formID)
        {
            try
            {
                return DA_System.MauReportInAn(templateTypeID, formID);
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
                return DA_System.LoaiTuDienDuLieu(formID);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static DataTable LayThongTinTuDienDuLieu(string _loaiDuLieu, string _UserID)
        {
            try
            {
                return DA_System.LayThongTinTuDienDuLieu(_loaiDuLieu, _UserID);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static int CapNhatThongTinTuDienDuLieu(string strXml, string _loaiDuLieu, string _UserID)
        {
            try
            {
                return DA_System.CapNhatThongTinTuDienDuLieu(strXml, _loaiDuLieu, _UserID);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
