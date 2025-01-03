using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMSCore.DAL
{
    public class DA_Report
    {
        private static DbConnection dbConn = Provider.GetConnection();

        public static int SaveTemplateReports(int id, byte[] reportData, string updateStaff)
        {
            try
            {
                DbCommand dbCmd = dbConn.CreateCommand();
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.CommandText = "cust_CMS_Save_psc_CMS_MauReportInAn";

                dbCmd.Parameters.Add(DACommon.CreateInputParameter(dbCmd, "@ID", DbType.Int32, id));
                dbCmd.Parameters.Add(DACommon.CreateInputParameter(dbCmd, "@Data", DbType.Binary, reportData));
                dbCmd.Parameters.Add(DACommon.CreateInputParameter(dbCmd, "@UpdateStaff", DbType.String, updateStaff));

                DbParameter dbReVal = dbCmd.CreateParameter();
                dbReVal = DACommon.CreateOutputParameter(dbCmd, "@ReVal", DbType.Int32, 4);
                dbCmd.Parameters.Add(dbReVal);

                DataAccessHelper.ExecuteNonQuery(dbCmd);
                return int.Parse(dbReVal.Value.ToString());
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
                DbCommand dbCmd = dbConn.CreateCommand();
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.CommandText = "cust_CMS_SaveAs_psc_CMS_MauReportInAn";

                dbCmd.Parameters.Add(DACommon.CreateInputParameter(dbCmd, "@ParentID", DbType.String, parentID));
                dbCmd.Parameters.Add(DACommon.CreateInputParameter(dbCmd, "@Data", DbType.Binary, reportData));
                dbCmd.Parameters.Add(DACommon.CreateInputParameter(dbCmd, "@UpdateStaff", DbType.String, updateStaff));
                dbCmd.Parameters.Add(DACommon.CreateInputParameter(dbCmd, "@ReportName", DbType.String, reportName));

                DbParameter dbReVal = dbCmd.CreateParameter();
                dbReVal = DACommon.CreateOutputParameter(dbCmd, "@ReVal", DbType.Int32, 4);
                dbCmd.Parameters.Add(dbReVal);

                DataAccessHelper.ExecuteNonQuery(dbCmd);
                return int.Parse(dbReVal.Value.ToString());
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
                DbCommand dbCmd = dbConn.CreateCommand();
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.CommandText = "cust_CMS_Sel_psc_CMS_MauReportInAn_ID";

                dbCmd.Parameters.Add(DACommon.CreateInputParameter(dbCmd, "@ID", DbType.Int32, ID));

                DataTable dt = new DataTable();
                DbDataReader dr = DataAccessHelper.ExecuteReader(dbCmd);
                dt.Load(dr);
                return dt;
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
                DbCommand dbCmd = dbConn.CreateCommand();
                DataTable dt = new DataTable();
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.CommandText = "cust_CMS_Sel_psc_CMS_LoaiBaoCaoVanBangChungChi";

                DbDataReader dr = DAL.DataAccessHelper.ExecuteReader(dbCmd);
                dt.Load(dr);
                return dt;
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
                DbCommand dbCmd = dbConn.CreateCommand();
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.CommandText = "cust_CMS_Save_psc_CMS_LoaiBaoCaoVanBangChungChi";

                dbCmd.Parameters.Add(DAL.DACommon.CreateInputParameter(dbCmd, "@XmlData", DbType.String, xmlData));
                dbCmd.Parameters.Add(DAL.DACommon.CreateInputParameter(dbCmd, "@UpdateStaff", DbType.String, updateStaff));

                DbParameter dbReVal = dbCmd.CreateParameter();
                dbReVal = DAL.DACommon.CreateOutputParameter(dbCmd, "@ReVal", DbType.Int32, 4);
                dbCmd.Parameters.Add(dbReVal);

                DAL.DataAccessHelper.ExecuteNonQuery(dbCmd);
                return int.Parse(dbReVal.Value.ToString());
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static int XoaLoaiBaoCao(string xmlData, string updateStaff)
        {
            try
            {
                DbCommand dbCmd = dbConn.CreateCommand();
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.CommandText = "cust_CMS_Del_psc_CMS_LoaiBaoCaoVanBangChungChi";

                dbCmd.Parameters.Add(DACommon.CreateInputParameter(dbCmd, "@XmlData", DbType.String, xmlData));
                dbCmd.Parameters.Add(DACommon.CreateInputParameter(dbCmd, "@UpdateStaff", DbType.String, updateStaff));
                DbParameter dbReVal = dbCmd.CreateParameter();
                dbReVal = DACommon.CreateOutputParameter(dbCmd, "@ReVal", DbType.Int32, 4);
                dbCmd.Parameters.Add(dbReVal);

                DataAccessHelper.ExecuteNonQuery(dbCmd);
                return int.Parse(dbReVal.Value.ToString());
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
                DbCommand dbCmd = dbConn.CreateCommand();
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.CommandText = "cust_CMS_Sel_BaoCaoThongKeVanBangChungChi";

                dbCmd.Parameters.Add(DACommon.CreateInputParameter(dbCmd, "@TemplateTypeID", DbType.String, templateTypeID));
                dbCmd.Parameters.Add(DACommon.CreateInputParameter(dbCmd, "@IssueSessionID", DbType.String, issueSession));
                dbCmd.Parameters.Add(DACommon.CreateInputParameter(dbCmd, "@DuplicateIssueSessionID", DbType.String, duplicateIssueSession));
                dbCmd.Parameters.Add(DACommon.CreateInputParameter(dbCmd, "@SearchStudent", DbType.String, searchStudent));
                dbCmd.Parameters.Add(DACommon.CreateInputParameter(dbCmd, "@GraduateLevelID", DbType.String, graduateLevelID));
                dbCmd.Parameters.Add(DACommon.CreateInputParameter(dbCmd, "@StudyTypeID", DbType.String, stduyTypeID));
                dbCmd.Parameters.Add(DACommon.CreateInputParameter(dbCmd, "@DepartmentID", DbType.String, departmentID));
                dbCmd.Parameters.Add(DACommon.CreateInputParameter(dbCmd, "@CourseID", DbType.String, courseID));
                dbCmd.Parameters.Add(DACommon.CreateInputParameter(dbCmd, "@OlogyID", DbType.String, ologyID));
                dbCmd.Parameters.Add(DACommon.CreateInputParameter(dbCmd, "@StudyProgramID", DbType.String, studyProgramID));
                dbCmd.Parameters.Add(DACommon.CreateInputParameter(dbCmd, "@ClassStudentID", DbType.String, classStudentID));
                dbCmd.Parameters.Add(DACommon.CreateInputParameter(dbCmd, "@FromYear", DbType.Int16, nFromYear));
                dbCmd.Parameters.Add(DACommon.CreateInputParameter(dbCmd, "@ToYear", DbType.Int16, nToYear));
                dbCmd.Parameters.Add(DACommon.CreateInputParameter(dbCmd, "@TermID", DbType.String, termID));
                dbCmd.Parameters.Add(DACommon.CreateInputParameter(dbCmd, "@YearStudy", DbType.String, yearStudy));
                dbCmd.Parameters.Add(DACommon.CreateInputParameter(dbCmd, "@LoaiBaoCao", DbType.String, loaiBaoCao));

                DataTable dt = new DataTable();
                DbDataReader dr = DataAccessHelper.ExecuteReader(dbCmd);
                dt.Load(dr);
                return dt;
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
                DbCommand dbCmd = dbConn.CreateCommand();
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.CommandText = "cust_CMS_Sel_BaoCaoThongKeTheoDoiPhoiBang";

                dbCmd.Parameters.Add(DACommon.CreateInputParameter(dbCmd, "@TemplateTypeID", DbType.String, templateTypeID));
                dbCmd.Parameters.Add(DACommon.CreateInputParameter(dbCmd, "@FromYear", DbType.Int16, nFromYear));
                dbCmd.Parameters.Add(DACommon.CreateInputParameter(dbCmd, "@ToYear", DbType.Int16, nToYear));
                dbCmd.Parameters.Add(DACommon.CreateInputParameter(dbCmd, "@LoaiBaoCao", DbType.String, loaiBaoCao));
                dbCmd.Parameters.Add(DACommon.CreateInputParameter(dbCmd, "@ForeignLanguage", DbType.Boolean, foreignLanguage));

                DataTable dt = new DataTable();
                DbDataReader dr = DataAccessHelper.ExecuteReader(dbCmd);
                dt.Load(dr);
                return dt;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
