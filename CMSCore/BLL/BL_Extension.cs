using CMSCore.DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMSCore.BLL
{
    public class BL_Extension
    {
        public static DataTable GetTitle()
        {
            try
            {
                return DA_Extension.GetTitle();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static DataTable viewGetTitle()
        {
            try
            {
                return DA_Extension.viewGetTitle();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static int SaveTitle(string xmlData, string updateStaff)
        {
            try
            {
                return DA_Extension.SaveTitle(xmlData, updateStaff);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static int DeleteTitle(string xmlData, string updateStaff)
        {
            try
            {
                return DA_Extension.DeleteTitle(xmlData, updateStaff);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static DataTable GetStudyPrograms(string courseID, bool foreignLanguage)
        {
            try
            {
                return DA_Extension.GetStudyPrograms(courseID, foreignLanguage);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public static DataTable GetStudyPrograms_DHCX(string courseID, bool foreignLanguage, string LoaiXet)
        {
            try
            {
                return DA_Extension.GetStudyPrograms_DHCX(courseID, foreignLanguage, LoaiXet);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public static int SaveStudyPrograms(string xmlData, string updateStaff)
        {
            try
            {
                return DA_Extension.SaveStudyPrograms(xmlData, updateStaff);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public static int SaveStudyPrograms_DHCX(string xmlData, string updateStaff)
        {
            try
            {
                return DA_Extension.SaveStudyPrograms_DHCX(xmlData, updateStaff);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static DataTable GetLanguage()
        {
            try
            {
                return DA_Extension.GetLanguage();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static int SaveLanguage(string xmlData, string updateStaff)
        {
            try
            {
                return DA_Extension.SaveLanguage(xmlData, updateStaff);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static int DeleteLanguage(string xmlData, string updateStaff)
        {
            try
            {
                return DA_Extension.DeleteLanguage(xmlData, updateStaff);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static DataTable GetQualityStandard()
        {
            try
            {
                return DA_Extension.GetQualityStandard();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static int SaveQualityStandard(string xmlData, string updateStaff)
        {
            try
            {
                return DA_Extension.SaveQualityStandard(xmlData, updateStaff);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static int DeleteQualityStandard(string xmlData, string updateStaff)
        {
            try
            {
                return DA_Extension.DeleteQualityStandard(xmlData, updateStaff);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static DataTable GetSemester()
        {
            try
            {
                return DA_Extension.GetSemester();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static int SaveSemester(string xmlData, string updateStaff)
        {
            try
            {
                return DA_Extension.SaveSemester(xmlData, updateStaff);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static DataTable GetGraduationClassificationType()
        {
            try
            {
                return DA_Extension.GetGraduationClassificationType();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static int SaveGraduationClassificationType(string xmlData, string updateStaff)
        {
            try
            {
                return DA_Extension.SaveGraduationClassificationType(xmlData, updateStaff);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static DataTable GetModeOfStudy(string xmlData)
        {
            try
            {
                return DA_Extension.GetModeOfStudy(xmlData);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static int SaveModeOfStudy(string xmlData, string updateStaff)
        {
            try
            {
                return DA_Extension.SaveModeOfStudy(xmlData, updateStaff);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static DataTable GetOlogyNumberOrder()
        {
            try
            {
                return DA_Extension.GetOlogyNumberOrder();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static int SaveOlogyNumberOrder(string xmlData, string updateStaff)
        {
            try
            {
                return DA_Extension.SaveOlogyNumberOrder(xmlData, updateStaff);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static DataTable NganhTheoKhoa(string courseID)
        {
            try
            {
                return DA_Extension.NganhTheoKhoa(courseID);
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
                return DA_Extension.LuuNganhTheoKhoa(courseID, xmlData, updateStaff);
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
                return DA_Extension.XoaNganhTheoKhoa(courseID, xmlData, updateStaff);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static int LuuDanhMucKhoaHoc(string xmlData, string updateStaff)
        {
            try
            {
                return DA_Extension.LuuDanhMucKhoaHoc(xmlData, updateStaff);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static int XoaDanhMucKhoaHoc(string xmlData, string updateStaff)
        {
            try
            {
                return DA_Extension.XoaDanhMucKhoaHoc(xmlData, updateStaff);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static DataTable DanhMucLoaiNgonNgu(bool foreignLanguage)
        {
            try
            {
                return DA_Extension.DanhMucLoaiNgonNgu(foreignLanguage);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
