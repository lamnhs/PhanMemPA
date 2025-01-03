using CMSCore.DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMSCore.BLL
{
    public class BL_Report
    {
        public static int SaveTemplateReports(int id, byte[] reportData, string updateStaff)
        {
            try
            {
                return DA_Report.SaveTemplateReports(id, reportData, updateStaff);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static int SaveAsTemplateReports(byte[] reportData, int parentID, string updateStaff, string reportName)
        {
            try
            {
                return DA_Report.SaveAsTemplateReports(reportData, parentID, updateStaff, reportName);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static DataTable GetTemplateReports(int ID)
        {
            try
            {
                return DA_Report.GetTemplateReports(ID);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public static DataTable LoaiBaoCao()
        {
            try
            {
                return DA_Report.LoaiBaoCao();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static int LuuLoaiBaoCao(string xmlData, string updateStaff)
        {
            try
            {
                return DA_Report.LuuLoaiBaoCao(xmlData, updateStaff);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static int XoaLoaiBaoCao(string strXml, string updateStaff)
        {
            try
            {
                return DA_Report.XoaLoaiBaoCao(strXml, updateStaff);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static DataTable ThongKeBaoCao(string templateTypeID, string issueSession, string duplicateIssueSession, string searchStudent,
                string graduateLevelID, string stduyTypeID, string courseID, string departmentID, string ologyID,
                string studyProgramID, string classStudentID, int nFromYear, int nToYear, string termID, string yearStudy, string loaiBaoCao)
        {
            try
            {
                return DA_Report.ThongKeBaoCao(templateTypeID, issueSession, duplicateIssueSession, searchStudent,
                    graduateLevelID, stduyTypeID, courseID, departmentID, ologyID,
                    studyProgramID, classStudentID, nFromYear, nToYear, termID, yearStudy, loaiBaoCao);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public static DataTable ThongKeBaoCaoPhoiBang(string templateTypeID, int nFromYear, int nToYear, string loaiBaoCao, bool foreignLanguage)
        {
            try
            {
                return DA_Report.ThongKeBaoCaoPhoiBang(templateTypeID, nFromYear, nToYear, loaiBaoCao, foreignLanguage);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
