using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.Common;

namespace CMSCore.DAL
{
    public class DA_ManageDegreeAndCertificate
    {
        private static DbConnection dbConn = Provider.GetConnection();

        public static DataTable GetTemplateType(string UserID)
        {
            try
            {
                DbCommand dbCmd = dbConn.CreateCommand();
                DataTable dt = new DataTable();
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.CommandText = "cust_CMS_Sel_psc_CMS_KhachHang";
                dbCmd.Parameters.Add(DACommon.CreateInputParameter(dbCmd, "@UserID", DbType.String, UserID));

                DbDataReader dr = DataAccessHelper.ExecuteReader(dbCmd);
                dt.Load(dr);
                return dt;
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
                DbCommand dbCmd = dbConn.CreateCommand();
                DataTable dt = new DataTable();
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.CommandText = "cust_CMS_Sel_psc_CMS_Nhom";
                dbCmd.Parameters.Add(DACommon.CreateInputParameter(dbCmd, "@UserID", DbType.String, UserID));

                DbDataReader dr = DataAccessHelper.ExecuteReader(dbCmd);
                dt.Load(dr);
                return dt;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        internal static DataTable LayPhoiVaDotHuy(string maDotHuy, bool foreignLangugeData, int trongDot, string templateTypeID)
        {
            try
            {
                DbCommand dbCmd = dbConn.CreateCommand();
                DataTable dt = new DataTable();
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.CommandText = "cust_CMS_Sel_LayPhoiVaDotHuy";

                dbCmd.Parameters.Add(DACommon.CreateInputParameter(dbCmd, "@MaDotHuy", DbType.String, maDotHuy));
                dbCmd.Parameters.Add(DACommon.CreateInputParameter(dbCmd, "@TrongDot", DbType.Int16, trongDot));
                dbCmd.Parameters.Add(DACommon.CreateInputParameter(dbCmd, "@ForeignLanguage", DbType.Boolean, foreignLangugeData));
                dbCmd.Parameters.Add(DACommon.CreateInputParameter(dbCmd, "@TemplateTypeID", DbType.String, templateTypeID));

                DbDataReader dr = DAL.DataAccessHelper.ExecuteReader(dbCmd);
                dt.Load(dr);
                return dt;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public static int DeleteTemplateType(string xmlData, string updateStaff)
        {
            try
            {
                DbCommand dbCmd = dbConn.CreateCommand();
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.CommandText = "cust_CMS_Del_QuanLyFile";

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
        public static int DeleteNhanVien(string xmlData, string updateStaff)
        {
            try
            {
                DbCommand dbCmd = dbConn.CreateCommand();
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.CommandText = "cust_CMS_Del_NhanVien";

                DbParameter dbReVal = dbCmd.CreateParameter();

                dbCmd.Parameters.Add(DACommon.CreateInputParameter(dbCmd, "@XmlData", DbType.String, xmlData));
                dbCmd.Parameters.Add(DACommon.CreateInputParameter(dbCmd, "@UpdateStaff", DbType.String, updateStaff));
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
        public static int DeleteKhachHang(string xmlData, string updateStaff)
        {
            try
            {
                DbCommand dbCmd = dbConn.CreateCommand();
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.CommandText = "cust_CMS_Del_KhachHang";

                DbParameter dbReVal = dbCmd.CreateParameter();

                dbCmd.Parameters.Add(DACommon.CreateInputParameter(dbCmd, "@XmlData", DbType.String, xmlData));
                dbCmd.Parameters.Add(DACommon.CreateInputParameter(dbCmd, "@UpdateStaff", DbType.String, updateStaff));
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
        public static int DeleteNguoiDung(string staff, string updateStaff)
        {
            try
            {
                DbCommand dbCmd = dbConn.CreateCommand();
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.CommandText = "cust_CMS_Del_NguoiDung";

                DbParameter dbReVal = dbCmd.CreateParameter();

                dbCmd.Parameters.Add(DACommon.CreateInputParameter(dbCmd, "@Staff", DbType.String, staff));
                dbCmd.Parameters.Add(DACommon.CreateInputParameter(dbCmd, "@UpdateStaff", DbType.String, updateStaff));
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

        public static DataTable LoaiBaoCao(string maLoaiXet)
        {
            try
            {
                DbCommand dbCmd = dbConn.CreateCommand();
                DataTable dt = new DataTable();
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.CommandText = "cust_CMS_Sel_psc_CMS_LocLoaiBaoCaoVanBangChungChi";

                dbCmd.Parameters.Add(DACommon.CreateInputParameter(dbCmd, "@TemplateTypeID", DbType.String, maLoaiXet));

                DbDataReader dr = DAL.DataAccessHelper.ExecuteReader(dbCmd);
                dt.Load(dr);
                return dt;
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
                DataSet ds = new DataSet();

                DbCommand dbCmd = dbConn.CreateCommand();
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.CommandText = "cust_CMS_Sel_CTIM_BienBanHuyPhoi";

                dbCmd.Parameters.Add(DACommon.CreateInputParameter(dbCmd, "@XmlData", DbType.String, xmlData));
             

                DbDataReader dr = DataAccessHelper.ExecuteReader(dbCmd);
                string ArrTable = "Data|Text|ThamGia";
                string[] TableName = ArrTable.Split('|');
                ds.Load(dr, LoadOption.PreserveChanges, TableName);
                dbCmd.Parameters.Clear();
                return ds;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static int SaveTemplateType(string xmlData, string updateStaff)
        {
            try
            {
                DbCommand dbCmd = dbConn.CreateCommand();
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.CommandText = "cust_CMS_Save_psc_CMS_TemplateType";

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

        public static DataTable GetTemplateSession(string templateTypeID, bool fullData)
        {
            try
            {
                DbCommand dbCmd = dbConn.CreateCommand();
                DataTable dt = new DataTable();
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.CommandText = "cust_CMS_Sel_psc_CMS_TemplateSession";

                dbCmd.Parameters.Add(DACommon.CreateInputParameter(dbCmd, "@TemplateTypeID", DbType.String, templateTypeID));
                dbCmd.Parameters.Add(DACommon.CreateInputParameter(dbCmd, "@FullData", DbType.Boolean, fullData));

                DbDataReader dr = DataAccessHelper.ExecuteReader(dbCmd);
                dt.Load(dr);
                return dt;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public static int SaveNhanVien(string xmlData, string updateStaff)
        {
            try
            {
                DbCommand dbCmd = dbConn.CreateCommand();
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.CommandText = "cust_CMS_Save_NhanVien";

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
        public static int SaveKhachHang(string xmlData, string updateStaff)
        {
            try
            {
                DbCommand dbCmd = dbConn.CreateCommand();
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.CommandText = "cust_CMS_Save_KhachHang";

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
        public static int SaveNguoiDung(string taiKhoan, string matKhau, string hoVaTen, string nhom, string updateStaff, string khachHang)
        {
            try
            {
                DbCommand dbCmd = dbConn.CreateCommand();
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.CommandText = "cust_CMS_Save_NguoiDung";

                dbCmd.Parameters.Add(DACommon.CreateInputParameter(dbCmd, "@TaiKhoan", DbType.String, taiKhoan));
                dbCmd.Parameters.Add(DACommon.CreateInputParameter(dbCmd, "@MatKhau", DbType.String, matKhau));
                dbCmd.Parameters.Add(DACommon.CreateInputParameter(dbCmd, "@HoVaTen", DbType.String, hoVaTen));
                dbCmd.Parameters.Add(DACommon.CreateInputParameter(dbCmd, "@Nhom", DbType.String, nhom));
                dbCmd.Parameters.Add(DACommon.CreateInputParameter(dbCmd, "@UpdateStaff", DbType.String, updateStaff));
                dbCmd.Parameters.Add(DACommon.CreateInputParameter(dbCmd, "@MaKH", DbType.String, khachHang));
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
        public static int SaveTemplateSession(string xmlData, string updateStaff)
        {
            try
            {
                DbCommand dbCmd = dbConn.CreateCommand();
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.CommandText = "cust_CMS_Save_QuanLyFile";

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
        public static int SaveDonHang(string maKH, string kyTuDau, int soLuong, string updateStaff)
        {
            try
            {
                DbCommand dbCmd = dbConn.CreateCommand();
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.CommandText = "cust_CMS_Save_DonHang";

                dbCmd.Parameters.Add(DACommon.CreateInputParameter(dbCmd, "@MaKH", DbType.String, maKH));
                dbCmd.Parameters.Add(DACommon.CreateInputParameter(dbCmd, "@KyTuDau", DbType.String, kyTuDau));
                dbCmd.Parameters.Add(DACommon.CreateInputParameter(dbCmd, "@SoLuong", DbType.Int16, soLuong));
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
        public static int SaveTrungDonHang(string maKH, string maDH, int soLuong, string updateStaff)
        {
            try
            {
                DbCommand dbCmd = dbConn.CreateCommand();
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.CommandText = "cust_CMS_Save_TrungDonHang";

                dbCmd.Parameters.Add(DACommon.CreateInputParameter(dbCmd, "@MaKH", DbType.String, maKH));
                dbCmd.Parameters.Add(DACommon.CreateInputParameter(dbCmd, "@MaDH", DbType.String, maDH));
                dbCmd.Parameters.Add(DACommon.CreateInputParameter(dbCmd, "@SoLuong", DbType.Int16, soLuong));
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

        public static int DeleteTemplateSession(string xmlData, string updateStaff)
        {
            try
            {
                DbCommand dbCmd = dbConn.CreateCommand();
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.CommandText = "cust_CMS_Del_psc_CMS_TemplateSession";

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

        public static int AcceptTemplateSession(string xmlData, string updateStaff)
        {
            try
            {
                DbCommand dbCmd = dbConn.CreateCommand();
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.CommandText = "cust_CMS_Upd_psc_CMS_TemplateSession_Accepted";

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

        public static DataTable GetTemplateBatch(int templateSessionID)
        {
            try
            {
                DbCommand dbCmd = dbConn.CreateCommand();
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.CommandText = "cust_CMS_Sel_psc_CMS_TemplateBatch_TemplateSessionID";

                dbCmd.Parameters.Add(DACommon.CreateInputParameter(dbCmd, "@TemplateSessionID", DbType.Int32, templateSessionID));

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

        public static DataTable GetTemplateBatch(string templateSessionID)
        {
            try
            {
                DbCommand dbCmd = dbConn.CreateCommand();
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.CommandText = "cust_CMS_Sel_psc_CMS_TemplateBatch_XmlTemplateSessionID";

                dbCmd.Parameters.Add(DACommon.CreateInputParameter(dbCmd, "@TemplateSessionID", DbType.String, templateSessionID));

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

        public static int SaveTemplateBatch(string xmlData, string updateStaff)
        {
            try
            {
                DbCommand dbCmd = dbConn.CreateCommand();
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.CommandText = "cust_CMS_Save_psc_CMS_TemplateBatch";

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

        public static int DeleteTemplateBatch(string xmlData, string updateStaff)
        {
            try
            {
                DbCommand dbCmd = dbConn.CreateCommand();
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.CommandText = "cust_CMS_Del_psc_CMS_TemplateBatch";

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

        public static DataTable GetTemplate(string templateBatchID, bool foreignLanguage)
        {
            try
            {
                DbCommand dbCmd = dbConn.CreateCommand();
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.CommandText = "cust_CMS_Sel_psc_CMS_Template_TemplateBatchID";

                dbCmd.Parameters.Add(DACommon.CreateInputParameter(dbCmd, "@TemplateBatchID", DbType.String, templateBatchID));
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
        public static int CancelTemplate(string reason, int templateID, string updateStaff)
        {
            try
            {
                DbCommand dbCmd = dbConn.CreateCommand();
                DbParameter dbPrmRe = dbCmd.CreateParameter();
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.CommandText = "cust_CMS_Del_psc_CMS_Template_Cancel";

                dbCmd.Parameters.Add(DACommon.CreateInputParameter(dbCmd, "@Reason", DbType.String, reason));
                dbCmd.Parameters.Add(DACommon.CreateInputParameter(dbCmd, "@TemplateID", DbType.Int32, templateID));
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
        public static int CancelTemplate(string reason, int degreeAndCertificateID, string serialNumber, string updateStaff, int LoaiHuy)
        {
            try
            {
                DbCommand dbCmd = dbConn.CreateCommand();
                DbParameter dbPrmRe = dbCmd.CreateParameter();
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.CommandText = "cust_CMS_Del_psc_CMS_Template_Cancel_SerialNumber_DegreeAndCertificateID";

                dbCmd.Parameters.Add(DACommon.CreateInputParameter(dbCmd, "@ID", DbType.Int32, degreeAndCertificateID));
                dbCmd.Parameters.Add(DACommon.CreateInputParameter(dbCmd, "@Reason", DbType.String, reason));
                dbCmd.Parameters.Add(DACommon.CreateInputParameter(dbCmd, "@SerialNumber", DbType.String, serialNumber));
                dbCmd.Parameters.Add(DACommon.CreateInputParameter(dbCmd, "@UpdateStaff", DbType.String, updateStaff));
                dbCmd.Parameters.Add(DACommon.CreateInputParameter(dbCmd, "@LoaiHuy", DbType.Int16, LoaiHuy));

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

        public static int RevokeTemplate(int templateID, string updateStaff)
        {
            try
            {
                DbCommand dbCmd = dbConn.CreateCommand();
                DbParameter dbPrmRe = dbCmd.CreateParameter();
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.CommandText = "cust_CMS_Save_psc_CMS_Template_Revoke";

                dbCmd.Parameters.Add(DACommon.CreateInputParameter(dbCmd, "@TemplateID", DbType.Int32, templateID));
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

        public static DataTable GetDesignTemplate(int templateTypeID)
        {
            try
            {
                DbCommand dbCmd = dbConn.CreateCommand();
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.CommandText = "cust_CMS_Sel_psc_CMS_DesignTemplate";

                dbCmd.Parameters.Add(DACommon.CreateInputParameter(dbCmd, "@TemplateTypeID", DbType.Int32, templateTypeID));

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
        public static DataTable GetDesignTemplate_IsInused(int templateTypeID, string UserID)
        {
            try
            {
                DbCommand dbCmd = dbConn.CreateCommand();
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.CommandText = "cust_CMS_Sel_psc_CMS_DesignTemplate_IsInused";

                dbCmd.Parameters.Add(DACommon.CreateInputParameter(dbCmd, "@TemplateTypeID", DbType.Int32, templateTypeID));
                dbCmd.Parameters.Add(DACommon.CreateInputParameter(dbCmd, "@UserID", DbType.String, UserID));

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

        public static int SaveDesignTemplate(string xmlData, string updateStaff)
        {
            try
            {
                DbCommand dbCmd = dbConn.CreateCommand();
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.CommandText = "cust_CMS_Save_psc_CMS_DesignTemplate";

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

        public static int DeleteDesignTemplate(string xmlData, string updateStaff)
        {
            try
            {
                DbCommand dbCmd = dbConn.CreateCommand();
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.CommandText = "cust_CMS_Del_psc_CMS_DesignTemplate";

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

        public static int CopyDesignTemplate(int sourceDesignTemplateID, int targetDesignTemplateID, string updateStaff)
        {
            try
            {
                DbCommand dbCmd = dbConn.CreateCommand();
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.CommandText = "cust_CMS_Save_psc_CMS_DesignTemplate_Copy";

                dbCmd.Parameters.Add(DACommon.CreateInputParameter(dbCmd, "@SourceDesignTemplateID", DbType.Int32, sourceDesignTemplateID));
                dbCmd.Parameters.Add(DACommon.CreateInputParameter(dbCmd, "@TargetDesignTemplateID", DbType.Int32, targetDesignTemplateID));
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

        public static DataTable GetTemplateReports(int designTemplateID)
        {
            try
            {
                DbCommand dbCmd = dbConn.CreateCommand();
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.CommandText = "cust_CMS_Sel_psc_CMS_DesignTemplate_DesignTemplateID";

                dbCmd.Parameters.Add(DACommon.CreateInputParameter(dbCmd, "@DesignTemplateID", DbType.Int32, designTemplateID));

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

        public static int SaveTemplateReports(byte[] reportData, int designTemplateID, string updateStaff)
        {
            try
            {
                DbCommand dbCmd = dbConn.CreateCommand();
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.CommandText = "cust_CMS_Save_psc_CMS_DesignTemplate_DesignTemplateID";

                dbCmd.Parameters.Add(DACommon.CreateInputParameter(dbCmd, "@DesignTemplateID", DbType.Int32, designTemplateID));
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

        public static DataTable GetIssueSession(int templateTypeID)
        {
            try
            {
                DbCommand dbCmd = dbConn.CreateCommand();
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.CommandText = "cust_CMS_Sel_psc_CMS_IssueSession";

                dbCmd.Parameters.Add(DACommon.CreateInputParameter(dbCmd, "@TemplateTypeID", DbType.Int32, templateTypeID));

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
        public static DataTable GetQuanLyFile(string maKH, string user)
        {
            try
            {
                DbCommand dbCmd = dbConn.CreateCommand();
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.CommandText = "cust_CMS_Sel_QuanLyFile";

                dbCmd.Parameters.Add(DACommon.CreateInputParameter(dbCmd, "@UserID", DbType.String, user));
                dbCmd.Parameters.Add(DACommon.CreateInputParameter(dbCmd, "@MaKH", DbType.String, maKH));

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
        public static DataTable GetQuanLyFile_KH(string maKH, string ngayThang, string user)
        {
            try
            {
                DbCommand dbCmd = dbConn.CreateCommand();
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.CommandText = "cust_CMS_Sel_QuanLyFile_KhachHang";

                dbCmd.Parameters.Add(DACommon.CreateInputParameter(dbCmd, "@UserID", DbType.String, user));
                dbCmd.Parameters.Add(DACommon.CreateInputParameter(dbCmd, "@MaKH", DbType.String, maKH));
                dbCmd.Parameters.Add(DACommon.CreateInputParameter(dbCmd, "@NgayThang", DbType.String, ngayThang));

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
        public static DataTable GetNhanVien()
        {
            try
            {
                DbCommand dbCmd = dbConn.CreateCommand();
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.CommandText = "cust_CMS_Sel_NhanVien";


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
        public static DataTable GetKhachHang()
        {
            try
            {
                DbCommand dbCmd = dbConn.CreateCommand();
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.CommandText = "cust_CMS_Sel_KhachHang";


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
        public static DataTable GetNguoiDung()
        {
            try
            {
                DbCommand dbCmd = dbConn.CreateCommand();
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.CommandText = "cust_CMS_Sel_psc_CMS_NguoiDungNhom";


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
        public static DataTable GetDetailNhanVien(string maNV, int soLuong, string tuNgay, string denNgay)
        {
            try
            {
                DbCommand dbCmd = dbConn.CreateCommand();
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.CommandText = "cust_CMS_Sel_ThongKeSoLuongFile_Detail";

                dbCmd.Parameters.Add(DACommon.CreateInputParameter(dbCmd, "@MaNV", DbType.String, maNV));
                dbCmd.Parameters.Add(DACommon.CreateInputParameter(dbCmd, "@SL", DbType.Int16, soLuong));
                dbCmd.Parameters.Add(DACommon.CreateInputParameter(dbCmd, "@TuNgay", DbType.String, tuNgay));
                dbCmd.Parameters.Add(DACommon.CreateInputParameter(dbCmd, "@DenNgay", DbType.String, denNgay));

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
        public static DataTable GetThongKeSoLuong(string maNV, int soLuong, string tuNgay, string denNgay)
        {
            try
            {
                DbCommand dbCmd = dbConn.CreateCommand();
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.CommandText = "cust_CMS_Sel_ThongKeSoLuongFile";

                dbCmd.Parameters.Add(DACommon.CreateInputParameter(dbCmd, "@MaNV", DbType.String, maNV));
                dbCmd.Parameters.Add(DACommon.CreateInputParameter(dbCmd, "@SL", DbType.Int16, soLuong));
                dbCmd.Parameters.Add(DACommon.CreateInputParameter(dbCmd, "@TuNgay", DbType.String, tuNgay));
                dbCmd.Parameters.Add(DACommon.CreateInputParameter(dbCmd, "@DenNgay", DbType.String, denNgay));

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
        public static DataTable GetIssueSession_StringTemplateType(string templateTypeID, string userID)
        {
            try
            {
                DbCommand dbCmd = dbConn.CreateCommand();
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.CommandText = "cust_CMS_Sel_psc_CMS_IssueSession_SringTemplateTypeID_UserID";

                dbCmd.Parameters.Add(DACommon.CreateInputParameter(dbCmd, "@TemplateTypeID", DbType.Int32, templateTypeID));
                dbCmd.Parameters.Add(DACommon.CreateInputParameter(dbCmd, "@UserID", DbType.String, userID));

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

        public static DataTable GetIssueSession(string userID)
        {
            try
            {
                DbCommand dbCmd = dbConn.CreateCommand();
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.CommandText = "cust_CMS_Sel_psc_CMS_KhachHang";

                dbCmd.Parameters.Add(DACommon.CreateInputParameter(dbCmd, "@UserID", DbType.String, userID));

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
        public static DataTable GetIssueSession_Student(string studentID, string userID)
        {
            try
            {
                DbCommand dbCmd = dbConn.CreateCommand();
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.CommandText = "cust_CMS_Sel_psc_CMS_IssueSession_StudentID_UserID";

                dbCmd.Parameters.Add(DACommon.CreateInputParameter(dbCmd, "@StudentID", DbType.String, studentID));
                dbCmd.Parameters.Add(DACommon.CreateInputParameter(dbCmd, "@UserID", DbType.String, userID));

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
        
        public static int SaveIssueSession(string xmlData, string updateStaff)
        {
            try
            {
                DbCommand dbCmd = dbConn.CreateCommand();
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.CommandText = "cust_CMS_Save_psc_CMS_IssueSession";

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

        public static int DeleteIssueSession(string xmlData, string updateStaff)
        {
            try
            {
                DbCommand dbCmd = dbConn.CreateCommand();
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.CommandText = "cust_CMS_Del_psc_CMS_IssueSession";

                dbCmd.Parameters.Add(DACommon.CreateInputParameter(dbCmd, "@UpdateStaff", DbType.String, updateStaff));
                dbCmd.Parameters.Add(DACommon.CreateInputParameter(dbCmd, "@XmlData", DbType.String, xmlData));

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
        
        public static DataTable GetDecisions(int templateTypeID)
        {
            try
            {
                DbCommand dbCmd = dbConn.CreateCommand();
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.CommandText = "cust_CMS_Sel_vw_CMS_Decisons_TemplateTypeID";

                dbCmd.Parameters.Add(DACommon.CreateInputParameter(dbCmd, "@TemplateTypeID", DbType.Int32, templateTypeID));

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

        public static DataTable GetStudentInIssueSession(int issueSessionID)
        {
            try
            {
                DbCommand dbCmd = dbConn.CreateCommand();
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.CommandText = "cust_CMS_Sel_psc_CMS_DanhSachCapVanBangChungChi_MaDotCap";

                dbCmd.Parameters.Add(DACommon.CreateInputParameter(dbCmd, "@IssueSessionID", DbType.Int32, issueSessionID));

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

        public static DataTable GetStudentNotInIssueSession(string maDotCap, bool trungTamDaoTao, string decisionNumber)
        {
            try
            {
                DbCommand dbCmd = dbConn.CreateCommand();
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.CommandText = "cust_CMS_Sel_synStudentInfomation_DecisionNumber";

                dbCmd.Parameters.Add(DACommon.CreateInputParameter(dbCmd, "@MaDotCap", DbType.String, maDotCap));
                dbCmd.Parameters.Add(DACommon.CreateInputParameter(dbCmd, "@TrungTamDaoTao", DbType.Boolean, trungTamDaoTao));
                dbCmd.Parameters.Add(DACommon.CreateInputParameter(dbCmd, "@DecisionNumber", DbType.String, decisionNumber));

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

        public static int SaveStudentIntoIssueSession(string xmlData, string updateStaff, bool trungTamDaoTao, bool isUpdate)
        {
            try
            {
                DbCommand dbCmd = dbConn.CreateCommand();
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.CommandText = "cust_CMS_Save_psc_CMS_DanhSachCapVanBangChungChi";

                dbCmd.Parameters.Add(DACommon.CreateInputParameter(dbCmd, "@UpdateStaff", DbType.String, updateStaff));
                dbCmd.Parameters.Add(DACommon.CreateInputParameter(dbCmd, "@XmlData", DbType.String, xmlData));
                dbCmd.Parameters.Add(DACommon.CreateInputParameter(dbCmd, "@TrungTamDaoTao", DbType.Boolean, trungTamDaoTao));
                dbCmd.Parameters.Add(DACommon.CreateInputParameter(dbCmd, "@IsUpdate", DbType.Boolean, isUpdate));

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
        public static int SaveStudentIntoIssueSession_CapLai(string xmlData, string updateStaff, bool trungTamDaoTao, bool isUpdate)
        {
            try
            {
                DbCommand dbCmd = dbConn.CreateCommand();
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.CommandText = "cust_CMS_Save_psc_CMS_DanhSachCapLaiVanBangChungChi_CapLai";

                dbCmd.Parameters.Add(DACommon.CreateInputParameter(dbCmd, "@UpdateStaff", DbType.String, updateStaff));
                dbCmd.Parameters.Add(DACommon.CreateInputParameter(dbCmd, "@XmlData", DbType.String, xmlData));
                dbCmd.Parameters.Add(DACommon.CreateInputParameter(dbCmd, "@TrungTamDaoTao", DbType.Boolean, trungTamDaoTao));
                dbCmd.Parameters.Add(DACommon.CreateInputParameter(dbCmd, "@IsUpdate", DbType.Boolean, isUpdate));

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
        public static int DeleteStudentOutOfIssueSession(string xmlData, string updateStaff)
        {
            try
            {
                DbCommand dbCmd = dbConn.CreateCommand();
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.CommandText = "cust_CMS_Del_psc_CMS_DanhSachCapVanBangChungChi";

                dbCmd.Parameters.Add(DACommon.CreateInputParameter(dbCmd, "@UpdateStaff", DbType.String, updateStaff));
                dbCmd.Parameters.Add(DACommon.CreateInputParameter(dbCmd, "@XmlData", DbType.String, xmlData));

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

        public static int SynchStudentInfomation(string xmlData, string updateStaff, bool trungTamDaoTao)
        {
            try
            {
                DbCommand dbCmd = dbConn.CreateCommand();
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.CommandText = "cust_CMS_Upd_psc_CMS_DanhSachCapVanBangChungChi";

                dbCmd.Parameters.Add(DACommon.CreateInputParameter(dbCmd, "@UpdateStaff", DbType.String, updateStaff));
                dbCmd.Parameters.Add(DACommon.CreateInputParameter(dbCmd, "@XmlData", DbType.String, xmlData));
                dbCmd.Parameters.Add(DACommon.CreateInputParameter(dbCmd, "@TrungTamDaoTao", DbType.Boolean, trungTamDaoTao));

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

        public static int ConfirmStudentNeedIssueDegreeOrCertificate(string xmlData, string updateStaff)
        {
            try
            {
                DbCommand dbCmd = dbConn.CreateCommand();
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.CommandText = "cust_CMS_Upd_psc_CMS_DanhSachCapVanBangChungChi_Confirm";

                dbCmd.Parameters.Add(DACommon.CreateInputParameter(dbCmd, "@UpdateStaff", DbType.String, updateStaff));
                dbCmd.Parameters.Add(DACommon.CreateInputParameter(dbCmd, "@XmlData", DbType.String, xmlData));

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

        public static int IssueTemplate(int issueSessionID, string updateStaff)
        {
            try
            {
                DbCommand dbCmd = dbConn.CreateCommand();
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.CommandText = "cust_CMS_Upd_psc_CMS_Template_IssueTemplate";

                dbCmd.Parameters.Add(DACommon.CreateInputParameter(dbCmd, "@IssueSessionID", DbType.Int32, issueSessionID));
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

        public static DataTable GetIssueSessionTemplate(int issueSessionID, bool _foreignLanguage, bool capPhatPhoi)
        {
            try
            {
                DbCommand dbCmd = dbConn.CreateCommand();
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.CommandText = "cust_CMS_Sel_psc_CMS_Template_IssueSessionID";

                dbCmd.Parameters.Add(DACommon.CreateInputParameter(dbCmd, "@IssueSessionID", DbType.Int32, issueSessionID));
                dbCmd.Parameters.Add(DACommon.CreateInputParameter(dbCmd, "@ForeignLanguage", DbType.Boolean, _foreignLanguage));
                dbCmd.Parameters.Add(DACommon.CreateInputParameter(dbCmd, "@CapPhatPhoi", DbType.Boolean, capPhatPhoi));

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

        public static DataTable DanhSachDuocCapBangChungChi(string maDotCapBang, string updateStaff)
        {
            try
            {
                DataTable dt = new DataTable();

                DbCommand dbCmd = dbConn.CreateCommand();
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.CommandText = "cust_CMS_Sel_psc_CMS_DanhSachCapVanBangChungChi";

                dbCmd.Parameters.Add(DACommon.CreateInputParameter(dbCmd, "@MaDotCap", DbType.String, maDotCapBang));
                dbCmd.Parameters.Add(DACommon.CreateInputParameter(dbCmd, "@UserID", DbType.String, updateStaff));

                DbDataReader dr = DataAccessHelper.ExecuteReader(dbCmd);
                dt.Load(dr);

                return dt;
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
                DataTable dt = new DataTable();

                DbCommand dbCmd = dbConn.CreateCommand();
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.CommandText = "cust_CMS_Sel_psc_CMS_DanhSachCapLaiVanBangChungChi";

                dbCmd.Parameters.Add(DACommon.CreateInputParameter(dbCmd, "@MaDotCap", DbType.String, maDotCapBang));
                dbCmd.Parameters.Add(DACommon.CreateInputParameter(dbCmd, "@UserID", DbType.String, updateStaff));

                DbDataReader dr = DataAccessHelper.ExecuteReader(dbCmd);
                dt.Load(dr);

                return dt;
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
                DbCommand dbCmd = dbConn.CreateCommand();
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.CommandText = "cust_CMS_Upd_psc_CMS_DanhSachCapVanBangChungChi_SoVaoSo";

                dbCmd.Parameters.Add(DACommon.CreateInputParameter(dbCmd, "@UpdateStaff", DbType.String, updateStaff));
                dbCmd.Parameters.Add(DACommon.CreateInputParameter(dbCmd, "@XmlData", DbType.String, xmlData));

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
        public static int SaveReferenceNumber_CapLai(string xmlData, string updateStaff)
        {
            try
            {
                DbCommand dbCmd = dbConn.CreateCommand();
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.CommandText = "cust_CMS_Upd_psc_CMS_DanhSachCapVanBangChungChi_SoVaoSo_CapLai";

                dbCmd.Parameters.Add(DACommon.CreateInputParameter(dbCmd, "@UpdateStaff", DbType.String, updateStaff));
                dbCmd.Parameters.Add(DACommon.CreateInputParameter(dbCmd, "@XmlData", DbType.String, xmlData));

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

        public static int CapNhatTraCuuVanBangChungChi(string xmlData, bool traCuu, string updateStaff)
        {
            try
            {
                DbCommand dbCmd = dbConn.CreateCommand();
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.CommandText = "cust_CMS_Upd_psc_CMS_DanhSachCapVanBangChungChi_TraCuu";

                dbCmd.Parameters.Add(DACommon.CreateInputParameter(dbCmd, "@UpdateStaff", DbType.String, updateStaff));
                dbCmd.Parameters.Add(DACommon.CreateInputParameter(dbCmd, "@XmlData", DbType.String, xmlData));
                dbCmd.Parameters.Add(DACommon.CreateInputParameter(dbCmd, "@TraCuu", DbType.String, traCuu));

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
        public static int CapNhatTraCuuVanBangChungChi_CapLai(string xmlData, bool traCuu, string updateStaff)
        {
            try
            {
                DbCommand dbCmd = dbConn.CreateCommand();
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.CommandText = "cust_CMS_Upd_psc_CMS_DanhSachCapLaiVanBangChungChi_TraCuu";

                dbCmd.Parameters.Add(DACommon.CreateInputParameter(dbCmd, "@UpdateStaff", DbType.String, updateStaff));
                dbCmd.Parameters.Add(DACommon.CreateInputParameter(dbCmd, "@XmlData", DbType.String, xmlData));
                dbCmd.Parameters.Add(DACommon.CreateInputParameter(dbCmd, "@TraCuu", DbType.String, traCuu));

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
        public static DataSet ThongTinCapBangChungChiPhoiBang(string xmlData, int issueSessionID, string tenForm)
        {
            try
            {
                DataSet ds = new DataSet();

                DbCommand dbCmd = dbConn.CreateCommand();
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.CommandText = "cust_CMS_Sel_psc_CMS_DanhSachCapVanBangChungChi_XmlData";

                dbCmd.Parameters.Add(DACommon.CreateInputParameter(dbCmd, "@XmlData", DbType.String, xmlData));
                dbCmd.Parameters.Add(DACommon.CreateInputParameter(dbCmd, "@IssueSessionID", DbType.Int32, issueSessionID));
                dbCmd.Parameters.Add(DACommon.CreateInputParameter(dbCmd, "@TenForm", DbType.String, tenForm));

                DbDataReader dr = DataAccessHelper.ExecuteReader(dbCmd);
                string ArrTable = "DanhSach|Phoi";
                string[] TableName = ArrTable.Split('|');
                ds.Load(dr, LoadOption.PreserveChanges, TableName);
                dbCmd.Parameters.Clear();
                return ds;
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
                DataSet ds = new DataSet();

                DbCommand dbCmd = dbConn.CreateCommand();
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.CommandText = "cust_CMS_Sel_psc_CMS_DanhSachCapLaiVanBangChungChi_XmlData_CapLai";

                dbCmd.Parameters.Add(DACommon.CreateInputParameter(dbCmd, "@XmlData", DbType.String, xmlData));
                dbCmd.Parameters.Add(DACommon.CreateInputParameter(dbCmd, "@IssueSessionID", DbType.Int32, issueSessionID));

                DbDataReader dr = DataAccessHelper.ExecuteReader(dbCmd);
                string ArrTable = "DanhSach|Phoi";
                string[] TableName = ArrTable.Split('|');
                ds.Load(dr, LoadOption.PreserveChanges, TableName);
                dbCmd.Parameters.Clear();
                return ds;
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
                DbCommand dbCmd = dbConn.CreateCommand();
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.CommandText = "cust_CMS_Upd_psc_CMS_Template_Status";

                dbCmd.Parameters.Add(DACommon.CreateInputParameter(dbCmd, "@UpdateStaff", DbType.String, updateStaff));
                dbCmd.Parameters.Add(DACommon.CreateInputParameter(dbCmd, "@XmlData", DbType.String, xmlData));

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
        public static int SavePrintedTemplate_CapLai(string xmlData, string updateStaff)
        {
            try
            {
                DbCommand dbCmd = dbConn.CreateCommand();
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.CommandText = "cust_CMS_Upd_psc_CMS_Template_Status_CapLai";

                dbCmd.Parameters.Add(DACommon.CreateInputParameter(dbCmd, "@UpdateStaff", DbType.String, updateStaff));
                dbCmd.Parameters.Add(DACommon.CreateInputParameter(dbCmd, "@XmlData", DbType.String, xmlData));

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
        public static DataTable PhuLucVanBang(string xmlData)
        {
            try
            {
                DataTable dt = new DataTable();

                DbCommand dbCmd = dbConn.CreateCommand();
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.CommandText = "cust_CMS_Sel_psc_CMS_DanhSachCapVanBangChungChi";

                dbCmd.Parameters.Add(DACommon.CreateInputParameter(dbCmd, "@XmlData", DbType.String, xmlData));

                DbDataReader dr = DataAccessHelper.ExecuteReader(dbCmd);
                dt.Load(dr);

                return dt;
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
                DbCommand dbCmd = dbConn.CreateCommand();
                DataTable dt = new DataTable();
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.CommandText = "cust_CMS_Sel_PhuLucVanBangChungChi";

                dbCmd.Parameters.Add(DACommon.CreateInputParameter(dbCmd, "@XmlData", DbType.String, xmlData));

                DbDataReader dr = DataAccessHelper.ExecuteReader(dbCmd);
                dt.Load(dr);
                return dt;
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
                DbCommand dbCmd = dbConn.CreateCommand();
                DataSet ds = new DataSet();
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.CommandText = "cust_CMS_Sel_PhuLucVanBangChungChi_LuanVan";

                dbCmd.Parameters.Add(DACommon.CreateInputParameter(dbCmd, "@XmlData", DbType.String, xmlData));
                
                DbDataReader dr = DataAccessHelper.ExecuteReader(dbCmd);
                string ArrTable = "PhuLuc|LuanVan";
                string[] TableName = ArrTable.Split('|');
                ds.Load(dr, LoadOption.PreserveChanges, TableName);
                dbCmd.Parameters.Clear();
                return ds;

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
                DbCommand dbCmd = dbConn.CreateCommand();
                DataTable dt = new DataTable();
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.CommandText = "cust_CMS_Sel_UAH_PhuLucVanBang";

                dbCmd.Parameters.Add(DACommon.CreateInputParameter(dbCmd, "@XmlData", DbType.String, xmlData));
                dbCmd.Parameters.Add(DACommon.CreateInputParameter(dbCmd, "@UserName", DbType.String, username));
                dbCmd.Parameters.Add(DACommon.CreateInputParameter(dbCmd, "@TemplateTypeID", DbType.Int16, TemplateTypeID));

                DbDataReader dr = DataAccessHelper.ExecuteReader(dbCmd);
                dt.Load(dr);
                return dt;
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
                DbCommand dbCmd = dbConn.CreateCommand();
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.CommandText = "cust_CMS_Upd_CapSoHieuVanBangChungChi";

                dbCmd.Parameters.Add(DACommon.CreateInputParameter(dbCmd, "@UpdateStaff", DbType.String, updateStaff));
                dbCmd.Parameters.Add(DACommon.CreateInputParameter(dbCmd, "@ID", DbType.Int32, degreeAndCertificateID));
                dbCmd.Parameters.Add(DACommon.CreateInputParameter(dbCmd, "@IssueSessionID", DbType.Int32, issueSessionID));

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
        public static int CapLaiSoHieuVanBangChungChi(int degreeAndCertificateID, int issueSessionID, string updateStaff)
        {
            try
            {
                DbCommand dbCmd = dbConn.CreateCommand();
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.CommandText = "cust_CMS_Upd_CapLaiSoHieuVanBangChungChi";

                dbCmd.Parameters.Add(DACommon.CreateInputParameter(dbCmd, "@UpdateStaff", DbType.String, updateStaff));
                dbCmd.Parameters.Add(DACommon.CreateInputParameter(dbCmd, "@ID", DbType.Int32, degreeAndCertificateID));
                dbCmd.Parameters.Add(DACommon.CreateInputParameter(dbCmd, "@IssueSessionID", DbType.Int32, issueSessionID));

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
        public static int CancelTemplate(string reason, int degreeAndCertificateID, string serialNumber, string updateStaff)
        {
            try
            {
                DbCommand dbCmd = dbConn.CreateCommand();
                DbParameter dbPrmRe = dbCmd.CreateParameter();
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.CommandText = "cust_CMS_Del_psc_CMS_Template_Cancel_SerialNumber_DegreeAndCertificateID";

                dbCmd.Parameters.Add(DACommon.CreateInputParameter(dbCmd, "@ID", DbType.Int32, degreeAndCertificateID));
                dbCmd.Parameters.Add(DACommon.CreateInputParameter(dbCmd, "@Reason", DbType.String, reason));
                dbCmd.Parameters.Add(DACommon.CreateInputParameter(dbCmd, "@SerialNumber", DbType.String, serialNumber));
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
        public static int CancelTemplate_CapLai(string reason, int degreeAndCertificateID, string serialNumber, string updateStaff)
        {
            try
            {
                DbCommand dbCmd = dbConn.CreateCommand();
                DbParameter dbPrmRe = dbCmd.CreateParameter();
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.CommandText = "cust_CMS_Del_psc_CMS_Template_Cancel_SerialNumber_DegreeAndCertificateID_CapLai";

                dbCmd.Parameters.Add(DACommon.CreateInputParameter(dbCmd, "@ID", DbType.Int32, degreeAndCertificateID));
                dbCmd.Parameters.Add(DACommon.CreateInputParameter(dbCmd, "@Reason", DbType.String, reason));
                dbCmd.Parameters.Add(DACommon.CreateInputParameter(dbCmd, "@SerialNumber", DbType.String, serialNumber));
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
        public static int RevokeTemplate(int degreeAndCertificateID, string serialNumber, string updateStaff)
        {
            try
            {
                DbCommand dbCmd = dbConn.CreateCommand();
                DbParameter dbPrmRe = dbCmd.CreateParameter();
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.CommandText = "cust_CMS_Save_psc_CMS_Template_Revoke_SerialNumber_DegreeAndCertificateID";

                dbCmd.Parameters.Add(DACommon.CreateInputParameter(dbCmd, "@ID", DbType.Int32, degreeAndCertificateID));
                dbCmd.Parameters.Add(DACommon.CreateInputParameter(dbCmd, "@SerialNumber", DbType.String, serialNumber));
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
        public static int RevokeTemplate_CapLai(int degreeAndCertificateID, string serialNumber, string updateStaff)
        {
            try
            {
                DbCommand dbCmd = dbConn.CreateCommand();
                DbParameter dbPrmRe = dbCmd.CreateParameter();
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.CommandText = "cust_CMS_Save_psc_CMS_Template_Revoke_SerialNumber_DegreeAndCertificateID_CapLai";

                dbCmd.Parameters.Add(DACommon.CreateInputParameter(dbCmd, "@ID", DbType.Int32, degreeAndCertificateID));
                dbCmd.Parameters.Add(DACommon.CreateInputParameter(dbCmd, "@SerialNumber", DbType.String, serialNumber));
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
        public static int SavePrintedTemplateXml(string xmlData, string updateStaff)
        {
            try
            {
                DbCommand dbCmd = dbConn.CreateCommand();
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.CommandText = "cust_CMS_Upd_psc_CMS_Template_Status_XxmlData";

                dbCmd.Parameters.Add(DACommon.CreateInputParameter(dbCmd, "@UpdateStaff", DbType.String, updateStaff));
                dbCmd.Parameters.Add(DACommon.CreateInputParameter(dbCmd, "@XmlData", DbType.String, xmlData));

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

        public static int SaveManageReferenceNumber(int templateTypeID, int referenceNumber, string updateStaff)
        {
            try
            {
                DbCommand dbCmd = dbConn.CreateCommand();
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.CommandText = "cust_CMS_Save_psc_CMS_ManageReferenceNumber";

                dbCmd.Parameters.Add(DACommon.CreateInputParameter(dbCmd, "@TemplateTypeID", DbType.Int32, templateTypeID));
                dbCmd.Parameters.Add(DACommon.CreateInputParameter(dbCmd, "@ReferenceNumber", DbType.Int32, referenceNumber));
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

        public static DataTable GetManageReferenceNumber(int templateTypeID)
        {
            try
            {
                DbCommand dbCmd = dbConn.CreateCommand();
                dbCmd.CommandType = CommandType.StoredProcedure;                
                dbCmd.CommandText = "cust_CMS_Sel_psc_CMS_ManageReferenceNumber";

                dbCmd.Parameters.Add(DACommon.CreateInputParameter(dbCmd, "@TemplateTypeID", DbType.Int32, templateTypeID));

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

        public static DataTable SoGocCapVanChungChungChi(string xmlData)
        {
            try
            {
                DbCommand dbCmd = dbConn.CreateCommand();
                DataTable dt = new DataTable();
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.CommandText = "cust_CMS_Sel_SoGocCapVanBangChungChi";

                dbCmd.Parameters.Add(DACommon.CreateInputParameter(dbCmd, "@XmlData", DbType.String, xmlData));

                DbDataReader dr = DataAccessHelper.ExecuteReader(dbCmd);
                dt.Load(dr);
                return dt;
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
                DbCommand dbCmd = dbConn.CreateCommand();
                DataTable dt = new DataTable();
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.CommandText = "cust_CMS_Sel_CTIM_TrinhKyVaXacNhanVanBangTheoKhoa";

                dbCmd.Parameters.Add(DACommon.CreateInputParameter(dbCmd, "@MaDotCap", DbType.String, maDotCap));
                dbCmd.Parameters.Add(DACommon.CreateInputParameter(dbCmd, "@LoaiVanBang", DbType.String, loaiVanBang));
                dbCmd.Parameters.Add(DACommon.CreateInputParameter(dbCmd, "@LoaiReport", DbType.String, loaiReport));

                DbDataReader dr = DataAccessHelper.ExecuteReader(dbCmd);
                dt.Load(dr);
                return dt;
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
                DbCommand dbCmd = dbConn.CreateCommand();
                DataTable dt = new DataTable();
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.CommandText = "cust_CMS_Sel_CTIM_TrinhKyVaXacNhanVanBangTheoKhoa_CapLai";

                dbCmd.Parameters.Add(DACommon.CreateInputParameter(dbCmd, "@MaDotCap", DbType.String, maDotCap));
                dbCmd.Parameters.Add(DACommon.CreateInputParameter(dbCmd, "@LoaiVanBang", DbType.String, loaiVanBang));
                dbCmd.Parameters.Add(DACommon.CreateInputParameter(dbCmd, "@LoaiReport", DbType.String, loaiReport));

                DbDataReader dr = DataAccessHelper.ExecuteReader(dbCmd);
                dt.Load(dr);
                return dt;
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
                DbCommand dbCmd = dbConn.CreateCommand();
                DataTable dt = new DataTable();
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.CommandText = "cust_CMS_Sel_TMU_TheoDoiNhanQDTN";

                dbCmd.Parameters.Add(DACommon.CreateInputParameter(dbCmd, "@XmlData", DbType.String, xmlData));
                dbCmd.Parameters.Add(DACommon.CreateInputParameter(dbCmd, "@templateTypeID", DbType.Int16, templateTypeID));
                dbCmd.Parameters.Add(DACommon.CreateInputParameter(dbCmd, "@UserID", DbType.String, UpdateStaff));

                DbDataReader dr = DataAccessHelper.ExecuteReader(dbCmd);
                dt.Load(dr);
                return dt;
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
                DbCommand dbCmd = dbConn.CreateCommand();
                DataTable dt = new DataTable();
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.CommandText = "cust_CMS_Sel_SoGocCapVanBangCuNhan";

                dbCmd.Parameters.Add(DACommon.CreateInputParameter(dbCmd, "@XmlData", DbType.String, xmlData));

                DbDataReader dr = DataAccessHelper.ExecuteReader(dbCmd);
                dt.Load(dr);
                return dt;
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
                DbCommand dbCmd = dbConn.CreateCommand();
                DataTable dt = new DataTable();
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.CommandText = "cust_CMS_Sel_TMU_DanhSachVanBangChungChi";

                dbCmd.Parameters.Add(DACommon.CreateInputParameter(dbCmd, "@XmlData", DbType.String, xmlData));
                dbCmd.Parameters.Add(DACommon.CreateInputParameter(dbCmd, "@Type", DbType.Int16, loai));

                DbDataReader dr = DataAccessHelper.ExecuteReader(dbCmd);
                dt.Load(dr);
                return dt;
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
                DbCommand dbCmd = dbConn.CreateCommand();
                DataTable dt = new DataTable();
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.CommandText = "cust_CMS_Sel_SoGocCapVanBangThacSi";

                dbCmd.Parameters.Add(DACommon.CreateInputParameter(dbCmd, "@XmlData", DbType.String, xmlData));

                DbDataReader dr = DataAccessHelper.ExecuteReader(dbCmd);
                dt.Load(dr);
                return dt;
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
                DbCommand dbCmd = dbConn.CreateCommand();
                DataTable dt = new DataTable();
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.CommandText = "cust_CMS_Sel_SoGocCapVanBangTienSi";

                dbCmd.Parameters.Add(DACommon.CreateInputParameter(dbCmd, "@XmlData", DbType.String, xmlData));

                DbDataReader dr = DataAccessHelper.ExecuteReader(dbCmd);
                dt.Load(dr);
                return dt;
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
                DbCommand dbCmd = dbConn.CreateCommand();
                DataTable dt = new DataTable();
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.CommandText = "cust_CMS_Sel_SoGocCapVanBangCCNN";

                dbCmd.Parameters.Add(DACommon.CreateInputParameter(dbCmd, "@XmlData", DbType.String, xmlData));

                DbDataReader dr = DataAccessHelper.ExecuteReader(dbCmd);
                dt.Load(dr);
                return dt;
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
                DbCommand dbCmd = dbConn.CreateCommand();
                DbParameter dbPrmRe = dbCmd.CreateParameter();
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.CommandText = "cust_CMS_Del_psc_CMS_Template_CancelIsPrinted_SerialNumber_DegreeAndCertificateID";

                dbCmd.Parameters.Add(DACommon.CreateInputParameter(dbCmd, "@ID", DbType.Int32, degreeAndCertificateID));
                dbCmd.Parameters.Add(DACommon.CreateInputParameter(dbCmd, "@Reason", DbType.String, reason));
                dbCmd.Parameters.Add(DACommon.CreateInputParameter(dbCmd, "@SerialNumber", DbType.String, serialNumber));
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
        public static int CancelIsPrinted_CapLai(string reason, int degreeAndCertificateID, string serialNumber, string updateStaff)
        {
            try
            {
                DbCommand dbCmd = dbConn.CreateCommand();
                DbParameter dbPrmRe = dbCmd.CreateParameter();
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.CommandText = "cust_CMS_Del_psc_CMS_Template_CancelIsPrinted_SerialNumber_DegreeAndCertificateID_CapLai";

                dbCmd.Parameters.Add(DACommon.CreateInputParameter(dbCmd, "@ID", DbType.Int32, degreeAndCertificateID));
                dbCmd.Parameters.Add(DACommon.CreateInputParameter(dbCmd, "@Reason", DbType.String, reason));
                dbCmd.Parameters.Add(DACommon.CreateInputParameter(dbCmd, "@SerialNumber", DbType.String, serialNumber));
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
        public static int CancelIsDuplicatePrinted(string reason, int degreeAndCertificateID, string updateStaff)
        {
            try
            {
                DbCommand dbCmd = dbConn.CreateCommand();
                DbParameter dbPrmRe = dbCmd.CreateParameter();
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.CommandText = "cust_CMS_Del_psc_CMS_Template_CancelIsDuplicatePrinted_SerialNumber_DegreeAndCertificateID";

                dbCmd.Parameters.Add(DACommon.CreateInputParameter(dbCmd, "@ID", DbType.Int32, degreeAndCertificateID));
                dbCmd.Parameters.Add(DACommon.CreateInputParameter(dbCmd, "@Reason", DbType.String, reason));
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

        public static DataTable DanhSachSVDuocCapBangChungChi(string XmlDotCap)
        {
            try
            {
                DataTable dt = new DataTable();

                DbCommand dbCmd = dbConn.CreateCommand();
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.CommandText = "cust_CMS_Sel_psc_CMS_SVDuocCap";

                dbCmd.Parameters.Add(DACommon.CreateInputParameter(dbCmd, "@XmlData", DbType.String, XmlDotCap));
                DbDataReader dr = DataAccessHelper.ExecuteReader(dbCmd);
                dt.Load(dr);

                return dt;
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
                DbCommand dbCmd = dbConn.CreateCommand();
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.CommandText = "cust_CMS_Save_psc_CMS_DanhSachCapVanBangChungChi_SoHieuBang_SoVaoSo";

                dbCmd.Parameters.Add(DACommon.CreateInputParameter(dbCmd, "@UpdateStaff", DbType.String, updateStaff));
                dbCmd.Parameters.Add(DACommon.CreateInputParameter(dbCmd, "@XmlData", DbType.String, xmlData));

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
        public static int LuuThongTinBangChungChi_CapLai(string xmlData, string updateStaff)
        {
            try
            {
                DbCommand dbCmd = dbConn.CreateCommand();
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.CommandText = "cust_CMS_Save_psc_CMS_DanhSachCapVanBangChungChi_SoHieuBang_SoVaoSo_CapLai";

                dbCmd.Parameters.Add(DACommon.CreateInputParameter(dbCmd, "@UpdateStaff", DbType.String, updateStaff));
                dbCmd.Parameters.Add(DACommon.CreateInputParameter(dbCmd, "@XmlData", DbType.String, xmlData));

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
        public static DataTable SinhVienNhanBangChungChi(string maLoaiChungChi, string maBacDaoTao, string maSinhVien, string hoVaTen,
            string ngaySinh, string noiSinh, string namTN, string soHieu, bool isKiemTraBacDT, bool foreignLanguage)
        {
            try
            {
                DbCommand dbCmd = dbConn.CreateCommand();
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.CommandText = "cust_CMS_Sel_psc_CMS_DanhSachCapVanBangChungChi_TraCuuVanBangChungChi";

                dbCmd.Parameters.Add(DACommon.CreateInputParameter(dbCmd, "@MaLoaiChungChi", DbType.String, maLoaiChungChi));
                dbCmd.Parameters.Add(DACommon.CreateInputParameter(dbCmd, "@MaBacDaoTao", DbType.String, maBacDaoTao));
                dbCmd.Parameters.Add(DACommon.CreateInputParameter(dbCmd, "@MaSinhVien", DbType.String, maSinhVien));
                dbCmd.Parameters.Add(DACommon.CreateInputParameter(dbCmd, "@HoVaTen", DbType.String, hoVaTen));
                dbCmd.Parameters.Add(DACommon.CreateInputParameter(dbCmd, "@NgaySinh", DbType.String, ngaySinh));
                dbCmd.Parameters.Add(DACommon.CreateInputParameter(dbCmd, "@NoiSinh", DbType.String, noiSinh));
                dbCmd.Parameters.Add(DACommon.CreateInputParameter(dbCmd, "@NamTN", DbType.String, namTN));
                dbCmd.Parameters.Add(DACommon.CreateInputParameter(dbCmd, "@SoHieu", DbType.String, soHieu));
                dbCmd.Parameters.Add(DACommon.CreateInputParameter(dbCmd, "@IsKiemTraBacDT", DbType.Boolean, isKiemTraBacDT));
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

        public static int LuuDuLieuExcel(string xmlData, string updateStaff)
        {
            try
            {
                DbCommand dbCmd = dbConn.CreateCommand();
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.CommandText = "cust_CMS_Save_psc_CMS_DanhSachCapVanBangChungChi_ImportExcel";

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

        public static DataTable GetDuplicateIssueSession(int templateTypeID, string userID)
        {
            try
            {
                DbCommand dbCmd = dbConn.CreateCommand();
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.CommandText = "cust_CMS_Sel_psc_CMS_DuplicateIssueSession";

                dbCmd.Parameters.Add(DACommon.CreateInputParameter(dbCmd, "@TemplateTypeID", DbType.Int32, templateTypeID));
                dbCmd.Parameters.Add(DACommon.CreateInputParameter(dbCmd, "@UpdateStaff", DbType.String, userID));

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

        public static DataTable GetDuplicateIssueSession_StringTemplateType(string templateTypeID, string userID)
        {
            try
            {
                DbCommand dbCmd = dbConn.CreateCommand();
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.CommandText = "cust_CMS_Sel_psc_CMS_DuplicateIssueSession_StringTemplateType";

                dbCmd.Parameters.Add(DACommon.CreateInputParameter(dbCmd, "@TemplateTypeID", DbType.String, templateTypeID));
                dbCmd.Parameters.Add(DACommon.CreateInputParameter(dbCmd, "@UpdateStaff", DbType.String, userID));

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

        public static int SaveDuplicateIssueSession(string xmlData, string updateStaff)
        {
            try
            {
                DbCommand dbCmd = dbConn.CreateCommand();
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.CommandText = "cust_CMS_Save_psc_CMS_DuplicateIssueSession";

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

        public static int DeleteDuplicateIssueSession(string xmlData, string updateStaff)
        {
            try
            {
                DbCommand dbCmd = dbConn.CreateCommand();
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.CommandText = "cust_CMS_Del_psc_CMS_DuplicateIssueSession";

                dbCmd.Parameters.Add(DACommon.CreateInputParameter(dbCmd, "@UpdateStaff", DbType.String, updateStaff));
                dbCmd.Parameters.Add(DACommon.CreateInputParameter(dbCmd, "@XmlData", DbType.String, xmlData));

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

        public static DataTable DuplicateNumber(int templateTypeID)
        {
            try
            {
                DbCommand dbCmd = dbConn.CreateCommand();
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.CommandText = "cust_CMS_Sel_psc_CMS_DuplicateNumber";

                dbCmd.Parameters.Add(DAL.DACommon.CreateInputParameter(dbCmd, "@TemplateTypeID", DbType.Int32, templateTypeID));

                DataTable dt = new DataTable();
                DbDataReader dr = DAL.DataAccessHelper.ExecuteReader(dbCmd);
                dt.Load(dr);
                return dt;
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
                DbCommand dbCmd = dbConn.CreateCommand();
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.CommandText = "cust_CMS_Save_psc_CMS_DuplicateNumber";

                dbCmd.Parameters.Add(DAL.DACommon.CreateInputParameter(dbCmd, "@TemplateTypeID", DbType.Int32, templateTypeID));
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

        public static DataTable DanhSachDuocCapBangChungChiBanSao(int maDotCapBanSao, string updateStaff)
        {
            try
            {
                DataTable dt = new DataTable();

                DbCommand dbCmd = dbConn.CreateCommand();
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.CommandText = "cust_CMS_Sel_psc_CMS_DanhSachCapBanSao";

                dbCmd.Parameters.Add(DACommon.CreateInputParameter(dbCmd, "@MaDotCapBanSao", DbType.String, maDotCapBanSao));
                dbCmd.Parameters.Add(DACommon.CreateInputParameter(dbCmd, "@UserID", DbType.String, updateStaff));

                DbDataReader dr = DataAccessHelper.ExecuteReader(dbCmd);
                dt.Load(dr);

                return dt;
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
                DataTable dt = new DataTable();

                DbCommand dbCmd = dbConn.CreateCommand();
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.CommandText = "cust_CMS_Sel_psc_CMS_DanhSachCapVanBangChungChi_MaDotCap_ThongTinSinhVien";

                dbCmd.Parameters.Add(DACommon.CreateInputParameter(dbCmd, "@MaDotCap", DbType.String, maDotCapBang));
                dbCmd.Parameters.Add(DACommon.CreateInputParameter(dbCmd, "@ThongTinSinhVien", DbType.String, thongTinSinhVien));

                DbDataReader dr = DataAccessHelper.ExecuteReader(dbCmd);
                dt.Load(dr);

                return dt;
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
                DbCommand dbCmd = dbConn.CreateCommand();
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.CommandText = "cust_CMS_Ins_psc_CMS_DanhSachCapBanSao";

                dbCmd.Parameters.Add(DACommon.CreateInputParameter(dbCmd, "@MaDotCapBanSao", DbType.Int32, maDotCapBanSao));
                dbCmd.Parameters.Add(DACommon.CreateInputParameter(dbCmd, "@NumberCopy", DbType.Int32, numberCopy));
                dbCmd.Parameters.Add(DACommon.CreateInputParameter(dbCmd, "@XmlData", DbType.String, xmlData));
                dbCmd.Parameters.Add(DACommon.CreateInputParameter(dbCmd, "@UpdateStaff", DbType.String, updateStaff));
                dbCmd.Parameters.Add(DACommon.CreateInputParameter(dbCmd, "@TemplateTypeID", DbType.Int32, templateTypeID));
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
        public static int CapSoVaoSoBanSao_Import(string xmlData, int maDotCapBanSao, int numberCopy, string updateStaff, int templateTypeID)
        {
            try
            {
                DbCommand dbCmd = dbConn.CreateCommand();
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.CommandText = "cust_CMS_Ins_psc_CMS_DanhSachCapBanSao_Import";

                dbCmd.Parameters.Add(DACommon.CreateInputParameter(dbCmd, "@MaDotCapBanSao", DbType.Int32, maDotCapBanSao));
                dbCmd.Parameters.Add(DACommon.CreateInputParameter(dbCmd, "@NumberCopy", DbType.Int32, numberCopy));
                dbCmd.Parameters.Add(DACommon.CreateInputParameter(dbCmd, "@XmlData", DbType.String, xmlData));
                dbCmd.Parameters.Add(DACommon.CreateInputParameter(dbCmd, "@UpdateStaff", DbType.String, updateStaff));
                dbCmd.Parameters.Add(DACommon.CreateInputParameter(dbCmd, "@TemplateTypeID", DbType.Int32, templateTypeID));
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
        public static int XoaDanhSachCapBanSao(string xmlData, int maDotCapBanSao, string updateStaff)
        {
            try
            {
                DbCommand dbCmd = dbConn.CreateCommand();
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.CommandText = "cust_CMS_Del_psc_CMS_DanhSachCapBanSao";

                dbCmd.Parameters.Add(DACommon.CreateInputParameter(dbCmd, "@MaDotCapBanSao", DbType.Int32, maDotCapBanSao));
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

        public static DataTable ThongTinCapBangSao(string xmlData)
        {
            try
            {
                DataTable dt = new DataTable();

                DbCommand dbCmd = dbConn.CreateCommand();
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.CommandText = "cust_CMS_Sel_psc_CMS_DanhSachCapBanSao_XmlData";

                dbCmd.Parameters.Add(DACommon.CreateInputParameter(dbCmd, "@XmlData", DbType.String, xmlData));
                DbDataReader dr = DAL.DataAccessHelper.ExecuteReader(dbCmd);
                dt.Load(dr);

                return dt;
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
                DataTable dt = new DataTable();

                DbCommand dbCmd = dbConn.CreateCommand();
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.CommandText = "cust_CMS_Sel_psc_CMS_DanhSachCapBanSao_XmlData_CTIM";

                dbCmd.Parameters.Add(DACommon.CreateInputParameter(dbCmd, "@XmlData", DbType.String, xmlData));
                dbCmd.Parameters.Add(DACommon.CreateInputParameter(dbCmd, "@CapBac", DbType.String, capBac));
                dbCmd.Parameters.Add(DACommon.CreateInputParameter(dbCmd, "@NguoiCap", DbType.String, nguoiCap));
                dbCmd.Parameters.Add(DACommon.CreateInputParameter(dbCmd, "@HieuTruong", DbType.String, hieuTruong));
                DbDataReader dr = DAL.DataAccessHelper.ExecuteReader(dbCmd);
                dt.Load(dr);

                return dt;
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
                DataTable dt = new DataTable();

                DbCommand dbCmd = dbConn.CreateCommand();
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.CommandText = "cust_CMS_Sel_psc_CMS_DanhSachCapBanSao_XmlData_Review";

                dbCmd.Parameters.Add(DACommon.CreateInputParameter(dbCmd, "@XmlData", DbType.String, xmlData));
                DbDataReader dr = DAL.DataAccessHelper.ExecuteReader(dbCmd);
                dt.Load(dr);

                return dt;
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
                DataTable dt = new DataTable();

                DbCommand dbCmd = dbConn.CreateCommand();
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.CommandText = "cust_CMS_Sel_psc_CMS_DanhSachCapBanSao_XmlData_Review_CTIM";

                dbCmd.Parameters.Add(DACommon.CreateInputParameter(dbCmd, "@XmlData", DbType.String, xmlData));
                dbCmd.Parameters.Add(DACommon.CreateInputParameter(dbCmd, "@CapBac", DbType.String, CapBac));
                dbCmd.Parameters.Add(DACommon.CreateInputParameter(dbCmd, "@NguoiCap", DbType.String, NguoiCap));
                dbCmd.Parameters.Add(DACommon.CreateInputParameter(dbCmd, "@HieuTruong", DbType.String, HieuTruong));

                DbDataReader dr = DAL.DataAccessHelper.ExecuteReader(dbCmd);
                dt.Load(dr);

                return dt;
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
                DbCommand dbCmd = dbConn.CreateCommand();
                DataTable dt = new DataTable();
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.CommandText = "cust_CMS_Sel_psc_CMS_DanhSachCapBanSao_LoaiLocDuLieu";

                dbCmd.Parameters.Add(DACommon.CreateInputParameter(dbCmd, "@XmlData", DbType.String, xmlData));

                DbDataReader dr = DataAccessHelper.ExecuteReader(dbCmd);
                dt.Load(dr);
                return dt;
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
                DbCommand dbCmd = dbConn.CreateCommand();
                DataTable dt = new DataTable();
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.CommandText = "cust_CMS_Sel_BaoCaoInVaSuDungPhoiBang";

                dbCmd.Parameters.Add(DACommon.CreateInputParameter(dbCmd, "@TemplateTypeID", DbType.Int16, templateType));
                dbCmd.Parameters.Add(DACommon.CreateInputParameter(dbCmd, "@FromYear", DbType.Int16, fromYear));
                dbCmd.Parameters.Add(DACommon.CreateInputParameter(dbCmd, "@ToYear", DbType.Int16, toYear));

                DbDataReader dr = DataAccessHelper.ExecuteReader(dbCmd);
                dt.Load(dr);
                return dt;
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
                DbCommand dbCmd = dbConn.CreateCommand();
                DataTable dt = new DataTable();
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.CommandText = "cust_CMS_Sel_psc_Graduate_QuanLyMauInAn";

                dbCmd.Parameters.Add(DACommon.CreateInputParameter(dbCmd, "@TemplateTypeID", DbType.Int32, templateTypeID));
                dbCmd.Parameters.Add(DACommon.CreateInputParameter(dbCmd, "@ForeignLanguage", DbType.Boolean, foreignLanguage));

                DbDataReader dr = DAL.DataAccessHelper.ExecuteReader(dbCmd);
                dt.Load(dr);
                return dt;
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
                DbCommand dbCmd = dbConn.CreateCommand();
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.CommandText = "cust_CMS_Save_psc_CMS_MauReportInAn_Parameter";

                dbCmd.Parameters.Add(DAL.DACommon.CreateInputParameter(dbCmd, "@XmlData", DbType.String, xmlData));
                dbCmd.Parameters.Add(DAL.DACommon.CreateInputParameter(dbCmd, "@UpdateStaff", DbType.String, updateStaff));
                dbCmd.Parameters.Add(DAL.DACommon.CreateInputParameter(dbCmd, "@TemplateTypeID", DbType.Int32, templateTypeID));

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

        public static int XoaMauInAn(string xmlData, string updateStaff)
        {
            try
            {
                DbCommand dbCmd = dbConn.CreateCommand();
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.CommandText = "cust_CMS_Del_psc_CMS_MauReportInAn";

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

        public static int DanhSachCapVanBangChungChi_CapNhatTinhTrang(string xmlData, string updateStaff)
        {
            try
            {
                DbCommand dbCmd = dbConn.CreateCommand();
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.CommandText = "cust_CMS_Update_psc_CMS_DanhSachCapVanBangChungChi_Status";

                dbCmd.Parameters.Add(DACommon.CreateInputParameter(dbCmd, "@UpdateStaff", DbType.String, updateStaff));
                dbCmd.Parameters.Add(DACommon.CreateInputParameter(dbCmd, "@XmlData", DbType.String, xmlData));

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

        internal static DataTable BangDiemTotNghiep1Cot(string strXml, string nhomBieuMau)
        {
            try
            {
                DbCommand dbCmd = dbConn.CreateCommand();
                DataTable dt = new DataTable();
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.CommandText = "cust_CMS_Sel_BangDiemTotNghiep1Cot";

                dbCmd.Parameters.Add(DACommon.CreateInputParameter(dbCmd, "@XmlData", DbType.String, strXml));
                dbCmd.Parameters.Add(DACommon.CreateInputParameter(dbCmd, "@NhomBieuMau", DbType.String, nhomBieuMau));

                DbDataReader dr = DAL.DataAccessHelper.ExecuteReader(dbCmd);
                dt.Load(dr);
                return dt;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        internal static DataTable CheckStudentName(string strXml, string updateStaff)
        {
            try
            {
                DbCommand dbCmd = dbConn.CreateCommand();
                DataTable dt = new DataTable();
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.CommandText = "cust_CMS_Sel_CheckStudentName";

                dbCmd.Parameters.Add(DACommon.CreateInputParameter(dbCmd, "@XmlData", DbType.String, strXml));
                dbCmd.Parameters.Add(DACommon.CreateInputParameter(dbCmd, "@UpdateStaff", DbType.String, updateStaff));

                DbDataReader dr = DAL.DataAccessHelper.ExecuteReader(dbCmd);
                dt.Load(dr);
                return dt;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        internal static DataTable CheckStudentName_CapLai(string strXml, string updateStaff)
        {
            try
            {
                DbCommand dbCmd = dbConn.CreateCommand();
                DataTable dt = new DataTable();
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.CommandText = "cust_CMS_Sel_CheckStudentName_CapLai";

                dbCmd.Parameters.Add(DACommon.CreateInputParameter(dbCmd, "@XmlData", DbType.String, strXml));
                dbCmd.Parameters.Add(DACommon.CreateInputParameter(dbCmd, "@UpdateStaff", DbType.String, updateStaff));

                DbDataReader dr = DAL.DataAccessHelper.ExecuteReader(dbCmd);
                dt.Load(dr);
                return dt;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        internal static DataTable DanhSachCanSuaThongTinSinhVien(string strXml, string updateStaff)
        {
            try
            {
                DbCommand dbCmd = dbConn.CreateCommand();
                DataTable dt = new DataTable();
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.CommandText = "cust_CMS_Sel_DieuChinhThongTinSinhVien";

                dbCmd.Parameters.Add(DACommon.CreateInputParameter(dbCmd, "@XmlData", DbType.String, strXml));
                dbCmd.Parameters.Add(DACommon.CreateInputParameter(dbCmd, "@UpdateStaff", DbType.String, updateStaff));

                DbDataReader dr = DAL.DataAccessHelper.ExecuteReader(dbCmd);
                dt.Load(dr);
                return dt;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        internal static DataTable DanhSachCanSuaThongTinSinhVien_SauLuu(string strXml, string updateStaff)
        {
            try
            {
                DbCommand dbCmd = dbConn.CreateCommand();
                DataTable dt = new DataTable();
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.CommandText = "cust_CMS_Sel_DieuChinhThongTinSinhVien_SauKhiLuu";

                dbCmd.Parameters.Add(DACommon.CreateInputParameter(dbCmd, "@XmlData", DbType.String, strXml));
                dbCmd.Parameters.Add(DACommon.CreateInputParameter(dbCmd, "@UpdateStaff", DbType.String, updateStaff));

                DbDataReader dr = DAL.DataAccessHelper.ExecuteReader(dbCmd);
                dt.Load(dr);
                return dt;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        internal static DataTable BangDiemTotNghiep2Cot(string strXml, string nhomBieuMau)
        {
            try
            {
                DbCommand dbCmd = dbConn.CreateCommand();
                DataTable dt = new DataTable();
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.CommandText = "cust_CMS_Sel_BangDiemTotNghiep2Cot";

                dbCmd.Parameters.Add(DACommon.CreateInputParameter(dbCmd, "@XmlData", DbType.String, strXml));
                dbCmd.Parameters.Add(DACommon.CreateInputParameter(dbCmd, "@NhomBieuMau", DbType.String, nhomBieuMau));

                DbDataReader dr = DAL.DataAccessHelper.ExecuteReader(dbCmd);
                dt.Load(dr);
                return dt;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        internal static DataTable MKU_PhuLucBangCuNhan(string strXml)
        {
            try
            {
                DbCommand dbCmd = dbConn.CreateCommand();
                DataTable dt = new DataTable();
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.CommandText = "cust_CMS_Sel_MKU_PhuLucBangCuNhan";

                dbCmd.Parameters.Add(DACommon.CreateInputParameter(dbCmd, "@XmlData", DbType.String, strXml));

                DbDataReader dr = DAL.DataAccessHelper.ExecuteReader(dbCmd);
                dt.Load(dr);
                return dt;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        internal static DataTable InBangDiemChungChi(string strXml, string nhomBieuMau)
        {
            try
            {
                DbCommand dbCmd = dbConn.CreateCommand();
                DataTable dt = new DataTable();
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.CommandText = "cust_CMS_Sel_InBangDiemChungChi";

                dbCmd.Parameters.Add(DACommon.CreateInputParameter(dbCmd, "@XmlData", DbType.String, strXml));
                dbCmd.Parameters.Add(DACommon.CreateInputParameter(dbCmd, "@NhomBieuMau", DbType.String, nhomBieuMau));

                DbDataReader dr = DAL.DataAccessHelper.ExecuteReader(dbCmd);
                dt.Load(dr);
                return dt;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        internal static DataTable LayDotHuyPhoi(string _UserID)
        {
            try
            {
                DbCommand dbCmd = dbConn.CreateCommand();
                DataTable dt = new DataTable();
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.CommandText = "cust_CMS_Sel_LayDotHuyPhoi";

                dbCmd.Parameters.Add(DACommon.CreateInputParameter(dbCmd, "@UserID", DbType.String, _UserID));

                DbDataReader dr = DAL.DataAccessHelper.ExecuteReader(dbCmd);
                dt.Load(dr);
                return dt;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        internal static int CapNhatDotHuyPhoi(string strXml, bool isDel, string updateStaff)
        {
            try
            {
                DbCommand dbCmd = dbConn.CreateCommand();
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.CommandText = "cust_CMS_Update_CapNhatDotHuyPhoi";

                dbCmd.Parameters.Add(DACommon.CreateInputParameter(dbCmd, "@XmlData", DbType.String, strXml));
                dbCmd.Parameters.Add(DACommon.CreateInputParameter(dbCmd, "@UpdateStaff", DbType.String, updateStaff));
                dbCmd.Parameters.Add(DACommon.CreateInputParameter(dbCmd, "@IsDel", DbType.Boolean, isDel));

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

        internal static DataTable LayPhoiVaDotHuy(string maDotHuy, bool foreignLangugeData, int trongDot)
        {
            try
            {
                DbCommand dbCmd = dbConn.CreateCommand();
                DataTable dt = new DataTable();
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.CommandText = "cust_CMS_Sel_LayPhoiVaDotHuy";

                dbCmd.Parameters.Add(DACommon.CreateInputParameter(dbCmd, "@MaDotHuy", DbType.String, maDotHuy));
                dbCmd.Parameters.Add(DACommon.CreateInputParameter(dbCmd, "@TrongDot", DbType.Int16, trongDot));
                dbCmd.Parameters.Add(DACommon.CreateInputParameter(dbCmd, "@ForeignLanguage", DbType.Boolean, foreignLangugeData));

                DbDataReader dr = DAL.DataAccessHelper.ExecuteReader(dbCmd);
                dt.Load(dr);
                return dt;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        internal static int CapNhatPhoiVaDotHuyPhoi(string strXml, bool isDel, string updateStaff)
        {
            try
            {
                DbCommand dbCmd = dbConn.CreateCommand();
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.CommandText = "cust_CMS_Update_CapNhatPhoiVaDotHuyPhoi";

                dbCmd.Parameters.Add(DACommon.CreateInputParameter(dbCmd, "@XmlData", DbType.String, strXml));
                dbCmd.Parameters.Add(DACommon.CreateInputParameter(dbCmd, "@UpdateStaff", DbType.String, updateStaff));
                dbCmd.Parameters.Add(DACommon.CreateInputParameter(dbCmd, "@IsDel", DbType.Boolean, isDel));

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

        internal static DataTable TMU_BienBanHuyPhoi(string strXml, string _UserID)
        {
            try
            {
                DbCommand dbCmd = dbConn.CreateCommand();
                DataTable dt = new DataTable();
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.CommandText = "cust_CMS_Sel_TMU_BienBanHuyPhoi";

                dbCmd.Parameters.Add(DACommon.CreateInputParameter(dbCmd, "@XmlData", DbType.String, strXml));
                dbCmd.Parameters.Add(DACommon.CreateInputParameter(dbCmd, "@UserID", DbType.String, _UserID));

                DbDataReader dr = DAL.DataAccessHelper.ExecuteReader(dbCmd);
                dt.Load(dr);
                return dt;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        internal static DataSet LAW_BienBanHuyPhoi(string strXml)
        {
            try
            {
                DbCommand dbCmd = dbConn.CreateCommand();
                DataSet ds = new DataSet();
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.CommandText = "cust_CMS_Sel_LAW_BienBanHuyPhoi";

                dbCmd.Parameters.Add(DACommon.CreateInputParameter(dbCmd, "@XmlData", DbType.String, strXml));


                DbDataReader dr = DataAccessHelper.ExecuteReader(dbCmd);
                string ArrTable = "ChiTiet|PhuLuc";
                string[] TableName = ArrTable.Split('|');
                ds.Load(dr, LoadOption.PreserveChanges, TableName);
                return ds;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        internal static DataSet TrinhKyXacNhan(string maDotCap, string loaiVanBang)
        {
            try
            {
                DbCommand dbCmd = dbConn.CreateCommand();
                DataSet ds = new DataSet();
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.CommandText = "cust_CMS_Sel_CTIM_TrinhKyVaXacNhanVanBang";

                dbCmd.Parameters.Add(DACommon.CreateInputParameter(dbCmd, "@MaDotCap", DbType.String, maDotCap));
                dbCmd.Parameters.Add(DACommon.CreateInputParameter(dbCmd, "@LoaiVanBang", DbType.String, loaiVanBang));


                DbDataReader dr = DataAccessHelper.ExecuteReader(dbCmd);
                string ArrTable = "ChiTiet|Data";
                string[] TableName = ArrTable.Split('|');
                ds.Load(dr, LoadOption.PreserveChanges, TableName);
                return ds;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        internal static DataSet TrinhKyXacNhan_CapLai(string maDotCap, string loaiVanBang)
        {
            try
            {
                DbCommand dbCmd = dbConn.CreateCommand();
                DataSet ds = new DataSet();
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.CommandText = "cust_CMS_Sel_CTIM_TrinhKyVaXacNhanVanBang_CapLai";

                dbCmd.Parameters.Add(DACommon.CreateInputParameter(dbCmd, "@MaDotCap", DbType.String, maDotCap));
                dbCmd.Parameters.Add(DACommon.CreateInputParameter(dbCmd, "@LoaiVanBang", DbType.String, loaiVanBang));


                DbDataReader dr = DataAccessHelper.ExecuteReader(dbCmd);
                string ArrTable = "ChiTiet|Data";
                string[] TableName = ArrTable.Split('|');
                ds.Load(dr, LoadOption.PreserveChanges, TableName);
                return ds;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        internal static DataTable LAW_QuanLyXuatNhapTonPhoi(string TemplateTypeID, string reportID, string strXml)
        {
            try
            {
                DbCommand dbCmd = dbConn.CreateCommand();
                DataTable dt = new DataTable();
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.CommandText = "cust_CMS_Sel_LAW_QuanLyXuatNhapTonPhoi";

                dbCmd.Parameters.Add(DACommon.CreateInputParameter(dbCmd, "@TemplateTypeID", DbType.String, TemplateTypeID));
                dbCmd.Parameters.Add(DACommon.CreateInputParameter(dbCmd, "@ReportID", DbType.String, reportID));                
                dbCmd.Parameters.Add(DACommon.CreateInputParameter(dbCmd, "@XmlData", DbType.String, strXml));
                
                DbDataReader dr = DataAccessHelper.ExecuteReader(dbCmd);
                dt.Load(dr);
                return dt;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        internal static DataTable LAW_QuanLyXuatNhapTonPhoiBanSao(string TemplateTypeID, string reportID, string strXml)
        {
            try
            {
                DbCommand dbCmd = dbConn.CreateCommand();
                DataTable dt = new DataTable();
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.CommandText = "cust_CMS_Sel_LAW_QuanLyXuatNhapTonPhoiBanSao";

                dbCmd.Parameters.Add(DACommon.CreateInputParameter(dbCmd, "@TemplateTypeID", DbType.String, TemplateTypeID));
                dbCmd.Parameters.Add(DACommon.CreateInputParameter(dbCmd, "@ReportID", DbType.String, reportID));
                dbCmd.Parameters.Add(DACommon.CreateInputParameter(dbCmd, "@XmlData", DbType.String, strXml));

                DbDataReader dr = DataAccessHelper.ExecuteReader(dbCmd);
                dt.Load(dr);
                return dt;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        internal static int CapNhatTinhTrangPhoi(string strXml, string reason, int status, string _UserID)
        {
            try
            {
                DbCommand dbCmd = dbConn.CreateCommand();
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.CommandText = "cust_CMS_Upd_CapNhatTinhTrangPhoi";

                dbCmd.Parameters.Add(DACommon.CreateInputParameter(dbCmd, "@XmlData", DbType.String, strXml));
                dbCmd.Parameters.Add(DACommon.CreateInputParameter(dbCmd, "@Reason", DbType.String, reason));
                dbCmd.Parameters.Add(DACommon.CreateInputParameter(dbCmd, "@Status", DbType.Int16, status));
                dbCmd.Parameters.Add(DACommon.CreateInputParameter(dbCmd, "@UpdateStaff", DbType.String, _UserID));

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

        internal static DataTable SoGocCapVanBangChungChi(string strXml, string reportID)
        {
            try
            {
                DbCommand dbCmd = dbConn.CreateCommand();
                DataTable dt = new DataTable();
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.CommandText = "cust_CMS_Sel_SoGocCapVanBangChungChi";

                dbCmd.Parameters.Add(DACommon.CreateInputParameter(dbCmd, "@XmlData", DbType.String, strXml));
                dbCmd.Parameters.Add(DACommon.CreateInputParameter(dbCmd, "@ReportID", DbType.String, reportID));

                DbDataReader dr = DAL.DataAccessHelper.ExecuteReader(dbCmd);
                dt.Load(dr);
                return dt;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        internal static DataTable ChungNhanTotNghiepVaCTDT(string strXml)
        {
            try
            {
                DbCommand dbCmd = dbConn.CreateCommand();
                DataTable dt = new DataTable();
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.CommandText = "cust_CMS_Sel_GiayChungNhanTotNghiepTamThoi";

                dbCmd.Parameters.Add(DACommon.CreateInputParameter(dbCmd, "@XmlData", DbType.String, strXml));

                DbDataReader dr = DAL.DataAccessHelper.ExecuteReader(dbCmd);
                dt.Load(dr);
                return dt;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        internal static DataTable GetTemplateStatus(string _UserID, bool foreignLanguage)
        {
            try
            {
                DbCommand dbCmd = dbConn.CreateCommand();
                DataTable dt = new DataTable();
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.CommandText = "cust_CMS_Sel_GetTemplateStatus";

                dbCmd.Parameters.Add(DACommon.CreateInputParameter(dbCmd, "@UserID", DbType.String, _UserID));
                dbCmd.Parameters.Add(DACommon.CreateInputParameter(dbCmd, "@ForeignLanguage", DbType.Boolean, foreignLanguage));

                DbDataReader dr = DAL.DataAccessHelper.ExecuteReader(dbCmd);
                dt.Load(dr);
                return dt;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        internal static DataTable XacNhanVanBangChungChi_TheoFile(string strXml, string maLoaiChungChi)
        {
            try
            {
                DbCommand dbCmd = dbConn.CreateCommand();
                DataTable dt = new DataTable();
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.CommandText = "cust_CMS_Sel_XacNhanVanBangChungChi_TheoFile";

                dbCmd.Parameters.Add(DACommon.CreateInputParameter(dbCmd, "@XmlData", DbType.String, strXml));
                dbCmd.Parameters.Add(DACommon.CreateInputParameter(dbCmd, "@MaLoaiChungChi", DbType.String, maLoaiChungChi));

                DbDataReader dr = DAL.DataAccessHelper.ExecuteReader(dbCmd);
                dt.Load(dr);
                return dt;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        internal static DataSet XacNhanVanBangChungChi_TheoFile_InXacNhan(string strXml, string maLoaiChungChi)
        {
            try
            {
                DataSet ds = new DataSet();

                DbCommand dbCmd = dbConn.CreateCommand();
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.CommandText = "cust_CMS_Sel_XacNhanVanBangChungChi_TheoFile_InXacNhan";

                dbCmd.Parameters.Add(DACommon.CreateInputParameter(dbCmd, "@XmlData", DbType.String, strXml));
                dbCmd.Parameters.Add(DACommon.CreateInputParameter(dbCmd, "@MaLoaiChungChi", DbType.String, maLoaiChungChi));

                DbDataReader dr = DataAccessHelper.ExecuteReader(dbCmd);
                string ArrTable = "DaCap|KhongCap";
                string[] TableName = ArrTable.Split('|');
                ds.Load(dr, LoadOption.PreserveChanges, TableName);
                dbCmd.Parameters.Clear();
                return ds;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        internal static DataTable BienBanGhiNhanPhoiHong(string strXml)
        {
            try
            {
                DbCommand dbCmd = dbConn.CreateCommand();
                DataTable dt = new DataTable();
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.CommandText = "cust_CMS_Sel_BienBanGhiNhanPhoiHong";

                dbCmd.Parameters.Add(DACommon.CreateInputParameter(dbCmd, "@XmlData", DbType.String, strXml));

                DbDataReader dr = DAL.DataAccessHelper.ExecuteReader(dbCmd);
                dt.Load(dr);
                return dt;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        internal static DataTable BienBanNghiemThuPhoi(string strXml)
        {
            try
            {
                DbCommand dbCmd = dbConn.CreateCommand();
                DataTable dt = new DataTable();
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.CommandText = "cust_CMS_Sel_BienBanNghiemThuPhoi";

                dbCmd.Parameters.Add(DACommon.CreateInputParameter(dbCmd, "@XmlData", DbType.String, strXml));

                DbDataReader dr = DAL.DataAccessHelper.ExecuteReader(dbCmd);
                dt.Load(dr);
                return dt;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        internal static DataTable HNUE_QuyetDinhCapChungChi(string strXml, int maLoaiChungChi, string type)
        {
            try
            {
                DbCommand dbCmd = dbConn.CreateCommand();
                DataTable dt = new DataTable();
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.CommandText = "cust_CMS_Sel_HNUE_QuyetDinhCapChungChi";

                dbCmd.Parameters.Add(DACommon.CreateInputParameter(dbCmd, "@XmlData", DbType.String, strXml));
                dbCmd.Parameters.Add(DACommon.CreateInputParameter(dbCmd, "@MaLoaiChungChi", DbType.String, maLoaiChungChi));
                dbCmd.Parameters.Add(DACommon.CreateInputParameter(dbCmd, "@ReportName", DbType.String, type));

                DbDataReader dr = DAL.DataAccessHelper.ExecuteReader(dbCmd);
                dt.Load(dr);
                return dt;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        internal static DataTable GiayDeNghiCapPhoi(string strXml, int _templateTypeID, string _reportName, string _UserID)
        {
            try
            {
                DbCommand dbCmd = dbConn.CreateCommand();
                DataTable dt = new DataTable();
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.CommandText = "cust_CMS_Sel_GiayDeNghiCapPhoi";

                dbCmd.Parameters.Add(DACommon.CreateInputParameter(dbCmd, "@XmlData", DbType.String, strXml));
                dbCmd.Parameters.Add(DACommon.CreateInputParameter(dbCmd, "@MaLoaiChungChi", DbType.String, _templateTypeID));
                dbCmd.Parameters.Add(DACommon.CreateInputParameter(dbCmd, "@ReportName", DbType.String, _reportName));
                dbCmd.Parameters.Add(DACommon.CreateInputParameter(dbCmd, "@UserID", DbType.String, _UserID));

                DbDataReader dr = DAL.DataAccessHelper.ExecuteReader(dbCmd);
                dt.Load(dr);
                return dt;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        internal static DataTable QuyetDinhThanhLapHoiDongHuyPhoi(string dotHuyPhoi, string _UserID)
        {
            try
            {
                DbCommand dbCmd = dbConn.CreateCommand();
                DataTable dt = new DataTable();
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.CommandText = "cust_CMS_Sel_QuyetDinhThanhLapHoiDongHuyPhoi";

                dbCmd.Parameters.Add(DACommon.CreateInputParameter(dbCmd, "@DotHuyPhoi", DbType.String, dotHuyPhoi));
                dbCmd.Parameters.Add(DACommon.CreateInputParameter(dbCmd, "@UserID", DbType.String, _UserID));

                DbDataReader dr = DAL.DataAccessHelper.ExecuteReader(dbCmd);
                dt.Load(dr);
                return dt;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        internal static DataTable XacMinhVanBangChungChi(string templateType)
        {
            try
            {
                DbCommand dbCmd = dbConn.CreateCommand();
                DataTable dt = new DataTable();
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.CommandText = "cust_CMS_Sel_psc_CMS_CongVanXacMinhVBCC";

                dbCmd.Parameters.Add(DACommon.CreateInputParameter(dbCmd, "@TemplateTypeID", DbType.String, templateType));

                DbDataReader dr = DAL.DataAccessHelper.ExecuteReader(dbCmd);
                dt.Load(dr);
                return dt;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        internal static int XoaXacMinhVanBangChungChi(string strXml, string updateStaff)
        {
            try
            {
                DbCommand dbCmd = dbConn.CreateCommand();
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.CommandText = "cust_CMS_Del_psc_CMS_CongVanXacMinhVBCC";

                dbCmd.Parameters.Add(DACommon.CreateInputParameter(dbCmd, "@XmlData", DbType.String, strXml));
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

        internal static DataTable ThongKeXacMinh_Excel(string xmlData, string reportID)
        {
            try
            {
                DbCommand dbCmd = dbConn.CreateCommand();
                DataTable dt = new DataTable();
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.CommandText = "cust_CMS_Sel_psc_CMS_CongVanXacMinhVBCC_ThongKeTheoNam_Excel";

                dbCmd.Parameters.Add(DACommon.CreateInputParameter(dbCmd, "@XmlData", DbType.String, xmlData));
                dbCmd.Parameters.Add(DACommon.CreateInputParameter(dbCmd, "@LoaiReport", DbType.String, reportID));

                DbDataReader dr = DAL.DataAccessHelper.ExecuteReader(dbCmd);
                dt.Load(dr);
                return dt;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        internal static int LuuXacMinhVanBangChungChi(int templateTypeID, string strXml, string updateStaff)
        {
            try
            {
                DbCommand dbCmd = dbConn.CreateCommand();
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.CommandText = "cust_CMS_Save_psc_CMS_CongVanXacMinhVBCC";

                dbCmd.Parameters.Add(DACommon.CreateInputParameter(dbCmd, "@TemplateTypeID", DbType.Int32, templateTypeID));
                dbCmd.Parameters.Add(DACommon.CreateInputParameter(dbCmd, "@XmlData", DbType.String, strXml));
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

        internal static DataSet InXacNhanVanBangChungChi(int idDotXacMinh, string maLoaiChungChi)
        {
            try
            {
                DataSet ds = new DataSet();

                DbCommand dbCmd = dbConn.CreateCommand();
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.CommandText = "cust_CMS_Sel_XacNhanVanBangChungChi_TheoFile_InXacNhan";

                dbCmd.Parameters.Add(DACommon.CreateInputParameter(dbCmd, "@IdDotXacMinh", DbType.Int32, idDotXacMinh));
                dbCmd.Parameters.Add(DACommon.CreateInputParameter(dbCmd, "@MaLoaiChungChi", DbType.String, maLoaiChungChi));

                DbDataReader dr = DataAccessHelper.ExecuteReader(dbCmd);
                string ArrTable = "DaCap|KhongCap";
                string[] TableName = ArrTable.Split('|');
                ds.Load(dr, LoadOption.PreserveChanges, TableName);
                dbCmd.Parameters.Clear();
                return ds;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        internal static DataTable DanhSachCanXacMinhVanBang(int xacMinhID)
        {
            try
            {
                DbCommand dbCmd = dbConn.CreateCommand();
                DataTable dt = new DataTable();
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.CommandText = "cust_CMS_Sel_psc_CMS_DanhSachCanXacMinhVBCC";

                dbCmd.Parameters.Add(DACommon.CreateInputParameter(dbCmd, "@ID", DbType.Int32, xacMinhID));

                DbDataReader dr = DAL.DataAccessHelper.ExecuteReader(dbCmd);
                dt.Load(dr);
                return dt;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        internal static DataTable DanhSachCanXacMinhVBCC_XMLID(string xmlTemplateTypeID)
        {
            try
            {
                DbCommand dbCmd = dbConn.CreateCommand();
                DataTable dt = new DataTable();
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.CommandText = "cust_CMS_Sel_psc_CMS_DanhSachCanXacMinhVBCC_XMLID";

                dbCmd.Parameters.Add(DACommon.CreateInputParameter(dbCmd, "@XMLID", DbType.String, xmlTemplateTypeID));

                DbDataReader dr = DAL.DataAccessHelper.ExecuteReader(dbCmd);
                dt.Load(dr);
                return dt;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        internal static DataTable DanhSachCanXacMinhVBCC(string xmlData, string reportID, string capBac, string nguoiKy)
        {
            try
            {
                DbCommand dbCmd = dbConn.CreateCommand();
                DataTable dt = new DataTable();
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.CommandText = "cust_CMS_Sel_XacMinhVanBangTotNghiep";

                dbCmd.Parameters.Add(DACommon.CreateInputParameter(dbCmd, "@XmlData", DbType.String, xmlData));
                dbCmd.Parameters.Add(DACommon.CreateInputParameter(dbCmd, "@ReportID", DbType.String, reportID));
                dbCmd.Parameters.Add(DACommon.CreateInputParameter(dbCmd, "@CapBacNguoiKy", DbType.String, capBac));
                dbCmd.Parameters.Add(DACommon.CreateInputParameter(dbCmd, "@NguoiKy", DbType.String, nguoiKy));

                DbDataReader dr = DAL.DataAccessHelper.ExecuteReader(dbCmd);
                dt.Load(dr);
                return dt;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        
        internal static int XoaDanhSachXacMinhVanBangChungChi(string strXml, string updateStaff)
        {
            try
            {
                DbCommand dbCmd = dbConn.CreateCommand();
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.CommandText = "cust_CMS_Del_psc_CMS_DanhSachCanXacMinhVBCC";

                dbCmd.Parameters.Add(DACommon.CreateInputParameter(dbCmd, "@XmlData", DbType.String, strXml));
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

        internal static int LuuDanhSachXacMinhVanBangChungChi(string strXml, string updateStaff)
        {
            try
            {
                DbCommand dbCmd = dbConn.CreateCommand();
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.CommandText = "cust_CMS_Save_psc_CMS_DanhSachCanXacMinhVBCC";

                dbCmd.Parameters.Add(DACommon.CreateInputParameter(dbCmd, "@XmlData", DbType.String, strXml));
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

        internal static int KiemTraDanhSachXacMinhVanBangChungChi(string strXml, string updateStaff)
        {
            try
            {
                DbCommand dbCmd = dbConn.CreateCommand();
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.CommandText = "cust_CMS_Upd_psc_CMS_DanhSachCanXacMinhVBCC_DoTruongCap";

                dbCmd.Parameters.Add(DACommon.CreateInputParameter(dbCmd, "@XmlData", DbType.String, strXml));
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

        internal static int KhoaDuLieuPhoiHuy(string dotHuyPhoi, bool locked, string _UserID)
        {
            try
            {
                DbCommand dbCmd = dbConn.CreateCommand();
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.CommandText = "cust_CMS_Upd_KhoaDuLieuPhoiHuy";

                dbCmd.Parameters.Add(DACommon.CreateInputParameter(dbCmd, "@DotHuyPhoi", DbType.String, dotHuyPhoi));
                dbCmd.Parameters.Add(DACommon.CreateInputParameter(dbCmd, "@Locked", DbType.Boolean, locked));
                dbCmd.Parameters.Add(DACommon.CreateInputParameter(dbCmd, "@UpdateStaff", DbType.String, _UserID));

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

        public static int LuuThongTinChuyenNganh(string xmlData, string updateStaff)
        {
            try
            {
                DbCommand dbCmd = dbConn.CreateCommand();
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.CommandText = "cust_CMS_Save_psc_CMS_DanhSachCapVanBangChungChi_LuuChuyenNganh";

                dbCmd.Parameters.Add(DACommon.CreateInputParameter(dbCmd, "@UpdateStaff", DbType.String, updateStaff));
                dbCmd.Parameters.Add(DACommon.CreateInputParameter(dbCmd, "@XmlData", DbType.String, xmlData));

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

        public static int LuuFileCongVan(int ID, string updateStaff, string File)
        {
            try
            {
                DbCommand dbCmd = dbConn.CreateCommand();
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.CommandText = "cust_CMS_Upd_psc_CMS_File";

                dbCmd.Parameters.Add(DACommon.CreateInputParameter(dbCmd, "@ID", DbType.Int16, ID));
                dbCmd.Parameters.Add(DACommon.CreateInputParameter(dbCmd, "@UpdateStaff", DbType.String, updateStaff));
                dbCmd.Parameters.Add(DACommon.CreateInputParameter(dbCmd, "@FILEPATH", DbType.String, File));

                DataAccessHelper.ExecuteNonQuery(dbCmd);
                return 1;
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
                DbCommand dbCmd = dbConn.CreateCommand();
                DataTable dt = new DataTable();
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.CommandText = "cust_CMS_Sel_psc_CMS_File";

                dbCmd.Parameters.Add(DACommon.CreateInputParameter(dbCmd, "@MaDot", DbType.Int32, maDot));
                dbCmd.Parameters.Add(DACommon.CreateInputParameter(dbCmd, "@LoaiChucNang", DbType.Int32, loaiChucNang));

                DbDataReader dr = DataAccessHelper.ExecuteReader(dbCmd);
                dt.Load(dr);
                return dt;
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
                DbCommand dbCmd = dbConn.CreateCommand();
                DataTable dt = new DataTable();
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.CommandText = "cust_CMS_Sel_psc_CMS_ThanhPhanThamDu";

                dbCmd.Parameters.Add(DACommon.CreateInputParameter(dbCmd, "@IDForm", DbType.Int32, idForm));
                dbCmd.Parameters.Add(DACommon.CreateInputParameter(dbCmd, "@MaDot", DbType.Int32, maDot));

                DbDataReader dr = DataAccessHelper.ExecuteReader(dbCmd);
                dt.Load(dr);
                return dt;
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
                DbCommand dbCmd = dbConn.CreateCommand();
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.CommandText = "cust_CMS_Del_psc_CMS_File";

                dbCmd.Parameters.Add(DACommon.CreateInputParameter(dbCmd, "@XmlData", DbType.String, xmlData));
                dbCmd.Parameters.Add(DACommon.CreateInputParameter(dbCmd, "@UpdateStaff", DbType.String, updateStaff));
                dbCmd.Parameters.Add(DACommon.CreateInputParameter(dbCmd, "@LoaiChucNang", DbType.Int32, loaiChucNang));

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
        public static int XoaThanhPhanThamDu(string xmlData, string updateStaff)
        {
            try
            {
                DbCommand dbCmd = dbConn.CreateCommand();
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.CommandText = "cust_CMS_Del_frm_CMS_ThanhPhanThamDu";

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
        
        public static int SaveFile(int loaiChucNang, string xmlData, string updateStaff)
        {
            try
            {
                DbCommand dbCmd = dbConn.CreateCommand();
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.CommandText = "cust_CMS_Save_psc_CMS_File";

                dbCmd.Parameters.Add(DACommon.CreateInputParameter(dbCmd, "@XmlData", DbType.String, xmlData));
                dbCmd.Parameters.Add(DACommon.CreateInputParameter(dbCmd, "@UpdateStaff", DbType.String, updateStaff));
                dbCmd.Parameters.Add(DACommon.CreateInputParameter(dbCmd, "@LoaiChucNang", DbType.Int32, loaiChucNang));

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
        public static int LuuThongTinSinhVienCanCap(string xmlData, string updateStaff)
        {
            try
            {
                DbCommand dbCmd = dbConn.CreateCommand();
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.CommandText = "cust_CMS_Save_psc_CMS_ThongTinSinhVienCanSua";

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
        public static int LuuThanhPhanThamDu(string xmlData, string updateStaff, int idForm, int maDot)
        {
            try
            {
                DbCommand dbCmd = dbConn.CreateCommand();
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.CommandText = "cust_CMS_Save_frm_CMS_ThanhPhanThamDu";

                dbCmd.Parameters.Add(DACommon.CreateInputParameter(dbCmd, "@XmlData", DbType.String, xmlData));
                dbCmd.Parameters.Add(DACommon.CreateInputParameter(dbCmd, "@UpdateStaff", DbType.String, updateStaff));
                dbCmd.Parameters.Add(DACommon.CreateInputParameter(dbCmd, "@idForm", DbType.Int32, idForm));
                dbCmd.Parameters.Add(DACommon.CreateInputParameter(dbCmd, "@maDot", DbType.Int32, maDot));

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
        
        public static DataTable LayQuyetDinhDotHuyPhoi(string maDotHuyPhoi)
        {
            try
            {
                DbCommand dbCmd = dbConn.CreateCommand();
                DataTable dt = new DataTable();
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.CommandText = "cust_CMS_Sel_psc_CMS_QuyetDinhDotHuyPhoi";
                dbCmd.Parameters.Add(DACommon.CreateInputParameter(dbCmd, "@MaDotHuyPhoi", DbType.String, maDotHuyPhoi));

                DbDataReader dr = DataAccessHelper.ExecuteReader(dbCmd);
                dt.Load(dr);
                return dt;
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
                DbCommand dbCmd = dbConn.CreateCommand();
                DataTable dt = new DataTable();
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.CommandText = "cust_CMS_Sel_psc_CMS_QuyetDinhDotCap";

                dbCmd.Parameters.Add(DACommon.CreateInputParameter(dbCmd, "@IssueSessionID", DbType.String, maDotCap));

                DbDataReader dr = DataAccessHelper.ExecuteReader(dbCmd);
                dt.Load(dr);
                return dt;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static int LuuFileQuyetDinhDotHuyPhoi(int ID, string updateStaff, string File)
        {
            try
            {
                DbCommand dbCmd = dbConn.CreateCommand();
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.CommandText = "cust_CMS_Save_psc_CMS_QuyetDinhDotHuyPhoi_File";

                dbCmd.Parameters.Add(DACommon.CreateInputParameter(dbCmd, "@ID", DbType.Int16, ID));
                dbCmd.Parameters.Add(DACommon.CreateInputParameter(dbCmd, "@UpdateStaff", DbType.String, updateStaff));
                dbCmd.Parameters.Add(DACommon.CreateInputParameter(dbCmd, "@FILEPATH", DbType.String, File));

                DataAccessHelper.ExecuteNonQuery(dbCmd);
                return 1;
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
                DbCommand dbCmd = dbConn.CreateCommand();
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.CommandText = "cust_CMS_Save_psc_CMS_QuyetDinhDotHuyPhoi";

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

        public static int LuuNgayNhanBang(string xmlData, string updateStaff)
        {
            try
            {
                DbCommand dbCmd = dbConn.CreateCommand();
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.CommandText = "cust_CMS_Upd_psc_CMS_DanhSachCapVanBangChungChi_NgayNhanBang";

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

        public static int CreateQRCode(string xmlData, string updateStaff)
        {
            try
            {
                DbCommand dbCmd = dbConn.CreateCommand();
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.CommandText = "cust_CMS_Upd_psc_CMS_DanhSachCapVanBangChungChi_QRCode";

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
        public static int CreateQRCode_CapLai(string xmlData, string updateStaff)
        {
            try
            {
                DbCommand dbCmd = dbConn.CreateCommand();
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.CommandText = "cust_CMS_Upd_psc_CMS_DanhSachCapLaiVanBangChungChi_QRCode_CapLai";

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
        internal static DataTable HCMUM_BienBanHuyPhoi(string strXml, string _UserID)
        {
            try
            {
                DbCommand dbCmd = dbConn.CreateCommand();
                DataTable dt = new DataTable();
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.CommandText = "cust_CMS_Sel_HCMUP_BienBanHuyPhoi";

                dbCmd.Parameters.Add(DACommon.CreateInputParameter(dbCmd, "@XmlData", DbType.String, strXml));
                dbCmd.Parameters.Add(DACommon.CreateInputParameter(dbCmd, "@UserID", DbType.String, _UserID));

                DbDataReader dr = DAL.DataAccessHelper.ExecuteReader(dbCmd);
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
