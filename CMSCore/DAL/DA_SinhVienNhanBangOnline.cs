using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMSCore.DAL
{
    public class DA_SinhVienNhanBangOnline
    {
        private static DbConnection dbConn = Provider.GetConnection();

        internal static DataTable GetSinhVienTrongDotDangKyLeTotNghiep(int dotDangKy)
        {
            try
            {
                DbCommand dbCmd = dbConn.CreateCommand();
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.CommandText = "cust_CMS_Sel_psc_CMS_DanhSachSinhVienDotThamGiaLeTotNghiep";

                dbCmd.Parameters.Add(DACommon.CreateInputParameter(dbCmd, "@DotDangKy", DbType.Int16, dotDangKy));

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

        internal static DataTable GetDotDangKyLeTotNghiepOnline(int _templateTypeID, string _UserID)
        {
            try
            {
                DbCommand dbCmd = dbConn.CreateCommand();
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.CommandText = "cust_CMS_Sel_psc_CMS_DotThamGiaLeTotNghiep";

                dbCmd.Parameters.Add(DACommon.CreateInputParameter(dbCmd, "@TemplateTypeID", DbType.Int16, _templateTypeID));
                dbCmd.Parameters.Add(DACommon.CreateInputParameter(dbCmd, "@UserID", DbType.String, _UserID));

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

        internal static int CapNhatSinhVienDotDangKyLeTotNghiep(string xmlData, int dotDangKy, bool isDel, string _UserID)
        {
            try
            {
                DbCommand dbCmd = dbConn.CreateCommand();
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.CommandText = "cust_CMS_Save_psc_CMS_DanhSachSinhVienDotThamGiaLeTotNghiep";

                dbCmd.Parameters.Add(DACommon.CreateInputParameter(dbCmd, "@XmlData", DbType.String, xmlData));
                dbCmd.Parameters.Add(DACommon.CreateInputParameter(dbCmd, "@DotDangKy", DbType.Int16, dotDangKy));
                dbCmd.Parameters.Add(DACommon.CreateInputParameter(dbCmd, "@IsDel", DbType.Boolean, isDel));
                dbCmd.Parameters.Add(DACommon.CreateInputParameter(dbCmd, "@NguoiCapNhat", DbType.String, _UserID));

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

        internal static DataTable GetSinhVienNgoaiDotDangKyLeTotNghiep(int dotDangKy, int dotCap)
        {
            try
            {
                DbCommand dbCmd = dbConn.CreateCommand();
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.CommandText = "cust_CMS_Sel_psc_CMS_DanhSachCapVanBangChungChi_ChuaNhanBang";

                dbCmd.Parameters.Add(DACommon.CreateInputParameter(dbCmd, "@DotDangKy", DbType.Int16, dotDangKy));
                dbCmd.Parameters.Add(DACommon.CreateInputParameter(dbCmd, "@DotCap", DbType.Int16, dotCap));

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

        internal static int SaveDotDangKyLeTotNghiepOnline(string strXml, int _templateTypeID, bool isDel, string _UserID)
        {
            try
            {
                DbCommand dbCmd = dbConn.CreateCommand();
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.CommandText = "cust_CMS_Save_psc_CMS_DotThamGiaLeTotNghiep";

                dbCmd.Parameters.Add(DACommon.CreateInputParameter(dbCmd, "@XmlData", DbType.String, strXml));
                dbCmd.Parameters.Add(DACommon.CreateInputParameter(dbCmd, "@TemplateTypeID", DbType.Int16, _templateTypeID));
                dbCmd.Parameters.Add(DACommon.CreateInputParameter(dbCmd, "@IsDel", DbType.Boolean, isDel));
                dbCmd.Parameters.Add(DACommon.CreateInputParameter(dbCmd, "@NguoiCapNhat", DbType.String, _UserID));

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

        internal static DataTable GetDotDangKyLeTotNghiepChiTiet(int _dotDangKy, string _UserID)
        {
            try
            {
                DbCommand dbCmd = dbConn.CreateCommand();
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.CommandText = "cust_CMS_Sel_psc_CMS_DotThamGiaLeTotNghiepChiTiet";

                dbCmd.Parameters.Add(DACommon.CreateInputParameter(dbCmd, "@DotDangKy", DbType.Int16, _dotDangKy));
                dbCmd.Parameters.Add(DACommon.CreateInputParameter(dbCmd, "@UserID", DbType.String, _UserID));

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
        public static DataTable GetReportSinhVienDangKyThamGiaLeTotNghiep(string maLoaiChungChi, int dotDangKy,string LoaiReport, string xmlData)
        {
            try
            {
                DataTable dt = new DataTable();
                DbCommand dbCmd = dbConn.CreateCommand();
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.CommandText = "cust_CMS_Sel_CTIM_ThongKeDanhSachSinhVienDKLTN";

                dbCmd.Parameters.Add(DACommon.CreateInputParameter(dbCmd, "@MaLoaiChungChi", DbType.String, maLoaiChungChi));
                dbCmd.Parameters.Add(DACommon.CreateInputParameter(dbCmd, "@DotDangKy", DbType.Int16, dotDangKy));
                dbCmd.Parameters.Add(DACommon.CreateInputParameter(dbCmd, "@LoaiReport", DbType.String, LoaiReport));
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
        internal static int SaveDotDangKyLeTotNghiepChiTiet(string strXml, bool isDel, int _dotDangKy, string _UserID)
        {
            try
            {
                DbCommand dbCmd = dbConn.CreateCommand();
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.CommandText = "cust_CMS_Save_psc_CMS_DotThamGiaLeTotNghiepChiTiet";

                dbCmd.Parameters.Add(DACommon.CreateInputParameter(dbCmd, "@XmlData", DbType.String, strXml));
                dbCmd.Parameters.Add(DACommon.CreateInputParameter(dbCmd, "@DotDangKy", DbType.Int16, _dotDangKy));
                dbCmd.Parameters.Add(DACommon.CreateInputParameter(dbCmd, "@IsDel", DbType.Boolean, isDel));
                dbCmd.Parameters.Add(DACommon.CreateInputParameter(dbCmd, "@NguoiCapNhat", DbType.String, _UserID));

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

        internal static DataTable GetSinhVienDangKyLeTotNghiepOnline(string maDot, string _UserID)
        {
            try
            {
                DbCommand dbCmd = dbConn.CreateCommand();
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.CommandText = "cust_CMS_Sel_psc_CMS_DanhSachSinhVienDangKyThamGiaLeTotNghiep";

                dbCmd.Parameters.Add(DACommon.CreateInputParameter(dbCmd, "@MaDot", DbType.String, maDot));
                dbCmd.Parameters.Add(DACommon.CreateInputParameter(dbCmd, "@UserID", DbType.String, _UserID));

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

        internal static int SaveSinhVienDangKyThamGiaLeTotNghiep(string strXml, bool isDel, string _UserID)
        {
            try
            {
                DbCommand dbCmd = dbConn.CreateCommand();
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.CommandText = "cust_CMS_Save_psc_CMS_DanhSachSinhVienDangKyThamGiaLeTotNghiep";

                dbCmd.Parameters.Add(DACommon.CreateInputParameter(dbCmd, "@XmlData", DbType.String, strXml));
                dbCmd.Parameters.Add(DACommon.CreateInputParameter(dbCmd, "@IsDel", DbType.Boolean, isDel));
                dbCmd.Parameters.Add(DACommon.CreateInputParameter(dbCmd, "@NguoiCapNhat", DbType.String, _UserID));

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

        public static DataTable LayDanhSachDangKyDuLeTotNghiep(string maLoaiChungChi, string maBacDaoTao, string maSinhVien, string hoVaTen, string ngaySinh, string noiSinh, string namTN, string soHieu, int maDotCap, bool apDungDotCap, int maDotDangKy, bool foreignLanguage)
        {
            try
            {
                DbCommand dbCmd = dbConn.CreateCommand();
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.CommandText = "cust_CMS_Sel_psc_CMS_DanhSachCapVanBangChungChi_DangKyDuLeTotNghiep";

                dbCmd.Parameters.Add(DACommon.CreateInputParameter(dbCmd, "@MaLoaiChungChi", DbType.String, maLoaiChungChi));
                dbCmd.Parameters.Add(DACommon.CreateInputParameter(dbCmd, "@MaBacDaoTao", DbType.String, maBacDaoTao));
                dbCmd.Parameters.Add(DACommon.CreateInputParameter(dbCmd, "@MaSinhVien", DbType.String, maSinhVien));
                dbCmd.Parameters.Add(DACommon.CreateInputParameter(dbCmd, "@HoVaTen", DbType.String, hoVaTen));
                dbCmd.Parameters.Add(DACommon.CreateInputParameter(dbCmd, "@NgaySinh", DbType.String, ngaySinh));
                dbCmd.Parameters.Add(DACommon.CreateInputParameter(dbCmd, "@NoiSinh", DbType.String, noiSinh));
                dbCmd.Parameters.Add(DACommon.CreateInputParameter(dbCmd, "@NamTN", DbType.String, namTN));
                dbCmd.Parameters.Add(DACommon.CreateInputParameter(dbCmd, "@SoHieu", DbType.String, soHieu));
                dbCmd.Parameters.Add(DACommon.CreateInputParameter(dbCmd, "@MaDotCap", DbType.Int32, maDotCap));
                dbCmd.Parameters.Add(DACommon.CreateInputParameter(dbCmd, "@ApDungDotCap", DbType.Boolean, apDungDotCap));
                dbCmd.Parameters.Add(DACommon.CreateInputParameter(dbCmd, "@MaDotDangKy", DbType.Int32, maDotDangKy));
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

        internal static int LuuDanhSachSinhVienDangKyTotNghiep(string strXml, string updateStaff)
        {
            try
            {
                DbCommand dbCmd = dbConn.CreateCommand();
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.CommandText = "cust_CMS_Ins_psc_CMS_DanhSachSinhVienDangKyThamGiaLeTotNghiep";

                dbCmd.Parameters.Add(DACommon.CreateInputParameter(dbCmd, "@XmlData", DbType.String, strXml));
                dbCmd.Parameters.Add(DACommon.CreateInputParameter(dbCmd, "@NguoiCapNhat", DbType.String, updateStaff));

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
    }
}
