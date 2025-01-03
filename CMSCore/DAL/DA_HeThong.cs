using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMSCore.DAL
{
    public class DA_HeThong
    {
        private static DbConnection dbConn = Provider.GetConnection();

        #region Lưới hiển thị
        internal static DataTable LuoiHienThi()
        {
            try
            {
                DbCommand dbCmd = dbConn.CreateCommand();
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.CommandText = "cust_CMS_Sel_SYNONYMS_DynamicGrids";

                dbCmd.Parameters.Add(DAL.DACommon.CreateInputParameter(dbCmd, "@ModuleID", DbType.String, "CMS"));

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

        internal static string LuuLuoiHienThi(string strXml, string updateStaff)
        {
            try
            {
                DbCommand dbCmd = dbConn.CreateCommand();
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.CommandText = "cust_GRD_Save_SYNONYMS_DynamicGrids";

                dbCmd.Parameters.Add(DAL.DACommon.CreateInputParameter(dbCmd, "@ModuleID", DbType.String, "GRD"));
                dbCmd.Parameters.Add(DAL.DACommon.CreateInputParameter(dbCmd, "@UpdateStaff", DbType.String, updateStaff));
                dbCmd.Parameters.Add(DAL.DACommon.CreateInputParameter(dbCmd, "@XmlData", DbType.String, strXml));
                DbParameter dbReVal = dbCmd.CreateParameter();
                dbReVal = DAL.DACommon.CreateOutputParameter(dbCmd, "@ReVal", DbType.Int32, 4);
                dbCmd.Parameters.Add(dbReVal);

                DAL.DataAccessHelper.ExecuteNonQuery(dbCmd);

                string result = string.Empty;
                if (Convert.ToInt32(dbReVal.Value.ToString()) == 0)
                    result = "Lưu thành công...";
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        internal static string XoaLuoiHienThi(string strXml, string updateStaff)
        {
            try
            {
                DbCommand dbCmd = dbConn.CreateCommand();
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.CommandText = "cust_GRD_Del_SYNONYMS_DynamicGrids";

                dbCmd.Parameters.Add(DAL.DACommon.CreateInputParameter(dbCmd, "@ModuleID", DbType.String, "GRD"));
                dbCmd.Parameters.Add(DAL.DACommon.CreateInputParameter(dbCmd, "@UpdateStaff", DbType.String, updateStaff));
                dbCmd.Parameters.Add(DAL.DACommon.CreateInputParameter(dbCmd, "@XmlData", DbType.String, strXml));
                DbParameter dbReVal = dbCmd.CreateParameter();
                dbReVal = DAL.DACommon.CreateOutputParameter(dbCmd, "@ReVal", DbType.Int32, 4);
                dbCmd.Parameters.Add(dbReVal);

                DAL.DataAccessHelper.ExecuteNonQuery(dbCmd);

                string result = string.Empty;
                if (Convert.ToInt32(dbReVal.Value.ToString()) == 0)
                    result = "Xóa thành công...";
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        #endregion

        #region Cột hiển thị trên lưới
        internal static DataTable CotLuoiHienThi(string gridID)
        {
            try
            {
                DbCommand dbCmd = dbConn.CreateCommand();
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.CommandText = "cust_GRD_Sel_SYNONYMS_DynamicGridColumns_GridID";

                dbCmd.Parameters.Add(DAL.DACommon.CreateInputParameter(dbCmd, "@GridID", DbType.String, gridID));

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

        internal static string LuuCotLuoiHienThi(string gridID, string strXml, string updateStaff)
        {
            try
            {
                DbCommand dbCmd = dbConn.CreateCommand();
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.CommandText = "cust_GRD_Save_SYNONYMS_DynamicGridColumns_GridID";

                dbCmd.Parameters.Add(DAL.DACommon.CreateInputParameter(dbCmd, "@GridID", DbType.String, gridID));
                dbCmd.Parameters.Add(DAL.DACommon.CreateInputParameter(dbCmd, "@UpdateStaff", DbType.String, updateStaff));
                dbCmd.Parameters.Add(DAL.DACommon.CreateInputParameter(dbCmd, "@XmlData", DbType.String, strXml));
                DbParameter dbReVal = dbCmd.CreateParameter();
                dbReVal = DAL.DACommon.CreateOutputParameter(dbCmd, "@ReVal", DbType.Int32, 4);
                dbCmd.Parameters.Add(dbReVal);

                DAL.DataAccessHelper.ExecuteNonQuery(dbCmd);

                string result = string.Empty;
                if (Convert.ToInt32(dbReVal.Value.ToString()) == 0)
                    result = "Lưu thành công...";
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        internal static string XoaCotLuoiHienThi(string gridID, string strXml, string updateStaff)
        {
            try
            {
                DbCommand dbCmd = dbConn.CreateCommand();
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.CommandText = "cust_GRD_Del_SYNONYMS_DynamicGridColumns_GridID";

                dbCmd.Parameters.Add(DAL.DACommon.CreateInputParameter(dbCmd, "@GridID", DbType.String, gridID));
                dbCmd.Parameters.Add(DAL.DACommon.CreateInputParameter(dbCmd, "@UpdateStaff", DbType.String, updateStaff));
                dbCmd.Parameters.Add(DAL.DACommon.CreateInputParameter(dbCmd, "@XmlData", DbType.String, strXml));
                DbParameter dbReVal = dbCmd.CreateParameter();
                dbReVal = DAL.DACommon.CreateOutputParameter(dbCmd, "@ReVal", DbType.Int32, 4);
                dbCmd.Parameters.Add(dbReVal);

                DAL.DataAccessHelper.ExecuteNonQuery(dbCmd);

                string result = string.Empty;
                if (Convert.ToInt32(dbReVal.Value.ToString()) == 0)
                    result = "Xóa thành công...";
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        #endregion

        #region Đóng dấu, ký tên
        internal static DataTable ThongTinDongDauKyTen()
        {
            try
            {
                DbCommand dbCmd = dbConn.CreateCommand();
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.CommandText = "cust_GRD_Sel_SYNONYMS_ThongTinNguoiKyTheoKhoa";

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

        internal static string LuuThongTinDongDauKyTen(string strXml, string updateStaff)
        {
            try
            {
                DbCommand dbCmd = dbConn.CreateCommand();
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.CommandText = "cust_GRD_Save_SYNONYMS_ThongTinNguoiKyTheoKhoa";

                dbCmd.Parameters.Add(DAL.DACommon.CreateInputParameter(dbCmd, "@UpdateStaff", DbType.String, updateStaff));
                dbCmd.Parameters.Add(DAL.DACommon.CreateInputParameter(dbCmd, "@XmlData", DbType.String, strXml));
                DbParameter dbPrmRe = dbCmd.CreateParameter(); dbPrmRe = DAL.DACommon.CreateOutputParameter(dbCmd, "@ReVal", DbType.Int32, 4); dbCmd.Parameters.Add(dbPrmRe);

                DAL.DataAccessHelper.ExecuteNonQuery(dbCmd);
                if (Convert.ToInt32(dbPrmRe.Value.ToString()) == 0)
                    return "Lưu thành công...";

                return "Lưu không thành công.";
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        #endregion

        #region Hình thức xét
        internal static DataTable HinhThucXet()
        {
            try
            {
                DbCommand dbCmd = dbConn.CreateCommand();
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.CommandText = "cust_GRD_Sel_SYNONYMS_HinhThucCap";

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

        internal static string LuuHinhThucXet(string strXml, string updateStaff)
        {
            try
            {
                DbCommand dbCmd = dbConn.CreateCommand();
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.CommandText = "cust_GRD_Save_SYNONYMS_HinhThucCap";

                dbCmd.Parameters.Add(DAL.DACommon.CreateInputParameter(dbCmd, "@UpdateStaff", DbType.String, updateStaff));
                dbCmd.Parameters.Add(DAL.DACommon.CreateInputParameter(dbCmd, "@XmlData", DbType.String, strXml));
                DbParameter dbReVal = dbCmd.CreateParameter();
                dbReVal = DAL.DACommon.CreateOutputParameter(dbCmd, "@ReVal", DbType.Int32, 4);
                dbCmd.Parameters.Add(dbReVal);

                DAL.DataAccessHelper.ExecuteNonQuery(dbCmd);

                string result = string.Empty;
                if (Convert.ToInt32(dbReVal.Value.ToString()) == 0)
                    result = "Lưu thành công...";
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        internal static string XoaHinhThucXet(string strXml, string updateStaff)
        {
            try
            {
                DbCommand dbCmd = dbConn.CreateCommand();
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.CommandText = "cust_GRD_Del_SYNONYMS_HinhThucCap";

                dbCmd.Parameters.Add(DAL.DACommon.CreateInputParameter(dbCmd, "@UpdateStaff", DbType.String, updateStaff));
                dbCmd.Parameters.Add(DAL.DACommon.CreateInputParameter(dbCmd, "@XmlData", DbType.String, strXml));
                DbParameter dbReVal = dbCmd.CreateParameter();
                dbReVal = DAL.DACommon.CreateOutputParameter(dbCmd, "@ReVal", DbType.Int32, 4);
                dbCmd.Parameters.Add(dbReVal);

                DAL.DataAccessHelper.ExecuteNonQuery(dbCmd);

                string result = string.Empty;
                if (Convert.ToInt32(dbReVal.Value.ToString()) == 0)
                    result = "Xóa thành công...";
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        #endregion

        #region Loại xét
        internal static DataTable LoaiXet()
        {
            try
            {
                DbCommand dbCmd = dbConn.CreateCommand();
                DataTable dt = new DataTable();
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.CommandText = "cust_GRD_Sel_SYNONYMS_LoaiXet";

                DbDataReader dr = DAL.DataAccessHelper.ExecuteReader(dbCmd);
                dt.Load(dr);
                return dt;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        internal static int LuuLoaiXet(string XmlData, string updateStaff)
        {
            try
            {
                DbCommand dbCmd = dbConn.CreateCommand();
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.CommandText = "cust_GRD_Save_SYNONYMS_LoaiXet";

                dbCmd.Parameters.Add(DACommon.CreateInputParameter(dbCmd, "@xmlData", DbType.String, XmlData));
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

        internal static int XoaLoaiXet(string XmlData, string updateStaff)
        {
            try
            {
                DbCommand dbCmd = dbConn.CreateCommand();
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.CommandText = "cust_GRD_Del_SYNONYMS_LoaiXet";

                dbCmd.Parameters.Add(DACommon.CreateInputParameter(dbCmd, "@xmlData", DbType.String, XmlData));
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
        #endregion

        internal static DataTable NhomMonHoc()
        {
            try
            {
                DataTable dt = new DataTable();
                DbCommand dbCmd = dbConn.CreateCommand();
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.CommandText = "cust_GRD_Sel_SYNONYMS_CurriculumGroups";

                DbDataReader dr = DAL.DataAccessHelper.ExecuteReader(dbCmd);
                dt.Load(dr);
                return dt;
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
                DbCommand dbCmd = dbConn.CreateCommand();
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.CommandText = "sp_Score_Upd_psc_Scr_ThongTinNguoiDongDauKyTen";

                dbCmd.Parameters.Add(DACommon.CreateInputParameter(dbCmd, "@UpdateStaff", DbType.String, updateStaff));
                dbCmd.Parameters.Add(DACommon.CreateInputParameter(dbCmd, "@XmlData", DbType.String, strXml));
                DbParameter dbPrmRe = dbCmd.CreateParameter(); dbPrmRe = DACommon.CreateOutputParameter(dbCmd, "@ReVal", DbType.Int32, 4); dbCmd.Parameters.Add(dbPrmRe);

                DataAccessHelper.ExecuteNonQuery(dbCmd);
                if (Convert.ToInt32(dbPrmRe.Value.ToString()) == 0)
                    return "Cập nhật thành công...";

                return "Cập nhật không thành công.";
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
                DbCommand dbCmd = dbConn.CreateCommand();
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.CommandText = "sp_Score_Upd_psc_Scr_ThongTinNguoiDongDauKyTen_ChuKy";

                dbCmd.Parameters.Add(DACommon.CreateInputParameter(dbCmd, "@Id", DbType.Int16, Int16.Parse(Id)));
                dbCmd.Parameters.Add(DACommon.CreateInputParameter(dbCmd, "@SettingBinaryData", DbType.Binary, image));
                dbCmd.Parameters.Add(DACommon.CreateInputParameter(dbCmd, "@UpdateStaff", DbType.String, updateStaff));

                DbParameter dbReVal = dbCmd.CreateParameter();
                dbReVal = DACommon.CreateOutputParameter(dbCmd, "@ReVal", DbType.Int32, 0);
                dbCmd.Parameters.Add(dbReVal);

                DataAccessHelper.ExecuteNonQuery(dbCmd);
                return int.Parse(dbReVal.Value.ToString());
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
                DbCommand dbCmd = dbConn.CreateCommand();
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.CommandText = "sp_Score_Del_psc_Scr_ThongTinNguoiDongDauKyTen";

                dbCmd.Parameters.Add(DACommon.CreateInputParameter(dbCmd, "@UpdateStaff", DbType.String, updateStaff));
                dbCmd.Parameters.Add(DACommon.CreateInputParameter(dbCmd, "@XmlData", DbType.String, strXml));
                DbParameter dbPrmRe = dbCmd.CreateParameter(); dbPrmRe = DACommon.CreateOutputParameter(dbCmd, "@ReVal", DbType.Int32, 4); dbCmd.Parameters.Add(dbPrmRe);

                DataAccessHelper.ExecuteNonQuery(dbCmd);
                if (Convert.ToInt32(dbPrmRe.Value.ToString()) == 0)
                    return "Xóa thành công...";

                return "Xóa không thành công.";
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
                DbCommand dbCmd = dbConn.CreateCommand();
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.CommandText = "sp_Score_Sel_psc_Scr_ThongTinNguoiDongDauKyTen_StaffID";

                dbCmd.Parameters.Add(DACommon.CreateInputParameter(dbCmd, "@StaffID", DbType.String, staffID));

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

        #region Cấu hình tình trạng
        internal static DataTable CauHinhTinhTrang(string maLoaiXet)
        {
            try
            {
                DbCommand dbCmd = dbConn.CreateCommand();
                DataTable dt = new DataTable();
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.CommandText = "cust_GRD_Sel_SYNONYMS_CauHinhTinhTrang";

                dbCmd.Parameters.Add(DACommon.CreateInputParameter(dbCmd, "@MaLoaiXet", DbType.String, maLoaiXet));

                DbDataReader dr = DAL.DataAccessHelper.ExecuteReader(dbCmd);
                dt.Load(dr);
                return dt;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        internal static int LuuCauHinhTinhTrang(string XmlData, string updateStaff)
        {
            try
            {
                DbCommand dbCmd = dbConn.CreateCommand();
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.CommandText = "cust_GRD_Save_SYNONYMS_CauHinhTinhTrang";

                dbCmd.Parameters.Add(DACommon.CreateInputParameter(dbCmd, "@xmlData", DbType.String, XmlData));
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
        #endregion

        #region Phân quyền loại xét
        internal static DataTable PhanQuyenLoaiXet(string maLoaiXet)
        {
            try
            {
                DbCommand dbCmd = dbConn.CreateCommand();
                DataTable dt = new DataTable();
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.CommandText = "cust_GRD_Sel_SYNONYMS_PhanQuyenLoaiXet";

                dbCmd.Parameters.Add(DACommon.CreateInputParameter(dbCmd, "@MaLoaiXet", DbType.String, maLoaiXet));

                DbDataReader dr = DAL.DataAccessHelper.ExecuteReader(dbCmd);
                dt.Load(dr);
                return dt;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        internal static int LuuPhanQuyenLoaiXet(string XmlData, string updateStaff)
        {
            try
            {
                DbCommand dbCmd = dbConn.CreateCommand();
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.CommandText = "cust_GRD_Save_SYNONYMS_PhanQuyenLoaiXet";

                dbCmd.Parameters.Add(DACommon.CreateInputParameter(dbCmd, "@xmlData", DbType.String, XmlData));
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
        #endregion

        #region Phân quyền đơn vị
        internal static DataTable PhanQuyenDonVi(string maLoaiXet, string nguoiDung)
        {
            try
            {
                DbCommand dbCmd = dbConn.CreateCommand();
                DataTable dt = new DataTable();
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.CommandText = "cust_GRD_Sel_SYNONYMS_PhanQuyenDonVi";

                dbCmd.Parameters.Add(DACommon.CreateInputParameter(dbCmd, "@MaLoaiXet", DbType.String, maLoaiXet));
                dbCmd.Parameters.Add(DACommon.CreateInputParameter(dbCmd, "@MaNguoiDung", DbType.String, nguoiDung));

                DbDataReader dr = DAL.DataAccessHelper.ExecuteReader(dbCmd);
                dt.Load(dr);
                return dt;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        internal static int LuuPhanQuyenDonVi(string XmlData, string updateStaff)
        {
            try
            {
                DbCommand dbCmd = dbConn.CreateCommand();
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.CommandText = "cust_GRD_Save_SYNONYMS_PhanQuyenDonVi";

                dbCmd.Parameters.Add(DACommon.CreateInputParameter(dbCmd, "@xmlData", DbType.String, XmlData));
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
        #endregion

        internal static DataTable KhoaHoc(string StudyTypeID, string GraduateLevelID)
        {
            try
            {
                DataTable dt = new DataTable();

                DbCommand dbCmd = dbConn.CreateCommand();
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.CommandText = "cust_CMS_Sel_synCourses_GraduateLevelID_StudyTypeID";

                dbCmd.Parameters.Add(DACommon.CreateInputParameter(dbCmd, "@StudyTypeID", DbType.String, StudyTypeID));
                dbCmd.Parameters.Add(DACommon.CreateInputParameter(dbCmd, "@GraduateLevelID", DbType.String, GraduateLevelID));

                DbDataReader dr = DAL.DataAccessHelper.ExecuteReader(dbCmd);
                dt.Load(dr);
                return dt;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static DataTable DanhSachLop(string khoa, string bacDaoTao, string LHDT, string khoaCQ, string nganh, string CTDT)
        {
            try
            {
                DbCommand dbCmd = dbConn.CreateCommand();
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.CommandText = "cust_CMS_Sel_synClassStudents";

                dbCmd.Parameters.Add(DACommon.CreateInputParameter(dbCmd, "@CourseID", DbType.String, khoa));
                dbCmd.Parameters.Add(DACommon.CreateInputParameter(dbCmd, "@OlogyID", DbType.String, nganh));
                dbCmd.Parameters.Add(DACommon.CreateInputParameter(dbCmd, "@GraduateLevelID", DbType.String, bacDaoTao));
                dbCmd.Parameters.Add(DACommon.CreateInputParameter(dbCmd, "@StudyTypeID", DbType.String, LHDT));
                dbCmd.Parameters.Add(DACommon.CreateInputParameter(dbCmd, "@DepartmentID", DbType.String, khoaCQ));
                dbCmd.Parameters.Add(DACommon.CreateInputParameter(dbCmd, "@StudyProgramID", DbType.String, CTDT));

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

        internal static DataTable NganhDaoTao(string khoa, string bacDaoTao, string LHDT)
        {
            try
            {
                DataTable dt = new DataTable();

                DbCommand dbCmd = dbConn.CreateCommand();
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.CommandText = "cust_CMS_Sel_synOlogies";

                dbCmd.Parameters.Add(DACommon.CreateInputParameter(dbCmd, "@DepartmentID", DbType.String, khoa));
                dbCmd.Parameters.Add(DACommon.CreateInputParameter(dbCmd, "@StudyTypeID", DbType.String, LHDT));
                dbCmd.Parameters.Add(DACommon.CreateInputParameter(dbCmd, "@GraduateLevelID", DbType.String, bacDaoTao));

                DbDataReader dr = DAL.DataAccessHelper.ExecuteReader(dbCmd);
                dt.Load(dr);
                return dt;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        internal static DataTable ChuongTrinhDaoTao(string khoa, string nganh, string bacDaoTao, string LHDT, string khoaChuQuan)
        {
            try
            {
                DbCommand dbCmd = dbConn.CreateCommand();
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.CommandText = "cust_CMS_Sel_synStudyPrograms";

                dbCmd.Parameters.Add(DACommon.CreateInputParameter(dbCmd, "@CourseID", DbType.String, khoa));
                dbCmd.Parameters.Add(DACommon.CreateInputParameter(dbCmd, "@OlogyID", DbType.String, nganh));
                dbCmd.Parameters.Add(DACommon.CreateInputParameter(dbCmd, "@GraduateLevelID", DbType.String, bacDaoTao));
                dbCmd.Parameters.Add(DACommon.CreateInputParameter(dbCmd, "@StudyTypeID", DbType.String, LHDT));
                dbCmd.Parameters.Add(DACommon.CreateInputParameter(dbCmd, "@DepartmentID", DbType.String, khoaChuQuan));

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

        internal static DataTable DanhHieu()
        {
            try
            {
                DbCommand dbCmd = dbConn.CreateCommand();
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.CommandText = "cust_Grd_Sel_SYNONYMS_GraduationDegrees";

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

        internal static int LuuDanhHieu(string xmlData, string updateStaff)
        {
            try
            {
                DbCommand dbCmd = dbConn.CreateCommand();
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.CommandText = "cust_Grd_Save_SYNONYMS_GraduationDegrees";

                dbCmd.Parameters.Add(DAL.DACommon.CreateInputParameter(dbCmd, "@XmlData", DbType.String, xmlData));
                dbCmd.Parameters.Add(DAL.DACommon.CreateInputParameter(dbCmd, "@NguoiCapNhat", DbType.String, updateStaff));

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

        internal static int XoaDanhHieu(string xmlData, string updateStaff)
        {
            try
            {
                DbCommand dbCmd = dbConn.CreateCommand();
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.CommandText = "cust_Grd_Del_SYNONYMS_GraduationDegrees";

                dbCmd.Parameters.Add(DAL.DACommon.CreateInputParameter(dbCmd, "@XmlData", DbType.String, xmlData));
                dbCmd.Parameters.Add(DAL.DACommon.CreateInputParameter(dbCmd, "@NguoiCapNhat", DbType.String, updateStaff));

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

        #region Mẫu in ấn
        internal static DataTable MauInAn(string maLoaiXet, bool user)
        {
            try
            {
                DbCommand dbCmd = dbConn.CreateCommand();
                DataTable dt = new DataTable();
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.CommandText = "cust_Grd_Sel_psc_Graduate_QuanLyMauInAn";

                dbCmd.Parameters.Add(DACommon.CreateInputParameter(dbCmd, "@MaLoaiChungChi", DbType.String, maLoaiXet));
                dbCmd.Parameters.Add(DACommon.CreateInputParameter(dbCmd, "@User", DbType.Boolean, user));

                DbDataReader dr = DAL.DataAccessHelper.ExecuteReader(dbCmd);
                dt.Load(dr);
                return dt;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        internal static DataTable ChucNangCoInAn()
        {
            try
            {
                DbCommand dbCmd = dbConn.CreateCommand();
                DataTable dt = new DataTable();
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.CommandText = "cust_Grd_Sel_psc_Grd_Forms_EnableConfigPrinted";

                DbDataReader dr = DAL.DataAccessHelper.ExecuteReader(dbCmd);
                dt.Load(dr);
                return dt;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        internal static int LuuMauInAn(string xmlData, string maLoaiXet, string updateStaff)
        {
            try
            {
                DbCommand dbCmd = dbConn.CreateCommand();
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.CommandText = "cust_Grd_Save_psc_Graduate_QuanLyMauInAn";

                dbCmd.Parameters.Add(DAL.DACommon.CreateInputParameter(dbCmd, "@XmlData", DbType.String, xmlData));
                dbCmd.Parameters.Add(DAL.DACommon.CreateInputParameter(dbCmd, "@UpdateStaff", DbType.String, updateStaff));
                dbCmd.Parameters.Add(DAL.DACommon.CreateInputParameter(dbCmd, "@MaLoaiChungChi", DbType.String, maLoaiXet));

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

        internal static int XoaMauInAn(string xmlData, string updateStaff)
        {
            try
            {
                DbCommand dbCmd = dbConn.CreateCommand();
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.CommandText = "cust_Grd_Del_psc_Graduate_QuanLyMauInAn";

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

        internal static int SaveTemplateReports(string reportID, string parentReportID, byte[] reportData, string updateStaff)
        {
            try
            {
                DbCommand dbCmd = dbConn.CreateCommand();
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.CommandText = "cust_Grd_Save_psc_Graduate_QuanLyMauInAn_Data";

                dbCmd.Parameters.Add(DACommon.CreateInputParameter(dbCmd, "@ReportID", DbType.String, reportID));
                dbCmd.Parameters.Add(DACommon.CreateInputParameter(dbCmd, "@ParentReportID", DbType.String, parentReportID));
                dbCmd.Parameters.Add(DACommon.CreateInputParameter(dbCmd, "@Data", DbType.Binary, reportData));
                dbCmd.Parameters.Add(DACommon.CreateInputParameter(dbCmd, "@UpdateStaff", DbType.String, updateStaff));

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

        internal static DataTable MauInAn(string maLoaiXet, string chucNang)
        {
            try
            {
                DbCommand dbCmd = dbConn.CreateCommand();
                DataTable dt = new DataTable();
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.CommandText = "cust_Grd_Sel_psc_Graduate_QuanLyMauInAn_ChucNang";

                dbCmd.Parameters.Add(DACommon.CreateInputParameter(dbCmd, "@MaLoaiChungChi", DbType.String, maLoaiXet));
                dbCmd.Parameters.Add(DACommon.CreateInputParameter(dbCmd, "@FormID", DbType.String, chucNang));

                DbDataReader dr = DAL.DataAccessHelper.ExecuteReader(dbCmd);
                dt.Load(dr);
                return dt;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        #endregion

        #region Ngành theo khóa
        internal static DataTable NganhTheoKhoa(string courseID)
        {
            try
            {
                DbCommand dbCmd = dbConn.CreateCommand();
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.CommandText = "cust_Grd_Sel_SYNONYMS_NganhTheoKhoa";

                dbCmd.Parameters.Add(DACommon.CreateInputParameter(dbCmd, "@CourseID", DbType.String, courseID));

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

        internal static int LuuNganhTheoKhoa(string courseID, string xmlData, string updateStaff)
        {
            try
            {
                DbCommand dbCmd = dbConn.CreateCommand();
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.CommandText = "cust_Grd_Save_SYNONYMS_NganhTheoKhoa";

                dbCmd.Parameters.Add(DACommon.CreateInputParameter(dbCmd, "@CourseID", DbType.String, courseID));
                dbCmd.Parameters.Add(DACommon.CreateInputParameter(dbCmd, "@XmlData", DbType.String, xmlData));
                dbCmd.Parameters.Add(DACommon.CreateInputParameter(dbCmd, "@UpdateStaff", DbType.String, updateStaff));

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

        internal static int XoaNganhTheoKhoa(string courseID, string xmlData, string updateStaff)
        {
            try
            {
                DbCommand dbCmd = dbConn.CreateCommand();
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.CommandText = "cust_Grd_Del_SYNONYMS_NganhTheoKhoa";

                dbCmd.Parameters.Add(DACommon.CreateInputParameter(dbCmd, "@CourseID", DbType.String, courseID));
                dbCmd.Parameters.Add(DACommon.CreateInputParameter(dbCmd, "@XmlData", DbType.String, xmlData));
                dbCmd.Parameters.Add(DACommon.CreateInputParameter(dbCmd, "@UpdateStaff", DbType.String, updateStaff));

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
        #endregion

        internal static DataTable MauInAn_UserID(string loaiXet, string formName, string _UserID)
        {
            try
            {
                DbCommand dbCmd = dbConn.CreateCommand();
                DataTable dt = new DataTable();
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.CommandText = "cust_Grd_Sel_psc_Graduate_QuanLyMauInAn_ChucNang_UserID";

                dbCmd.Parameters.Add(DACommon.CreateInputParameter(dbCmd, "@MaLoaiChungChi", DbType.String, loaiXet));
                dbCmd.Parameters.Add(DACommon.CreateInputParameter(dbCmd, "@FormID", DbType.String, formName));
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

        internal static string CapNhatThongTinTuDienDuLieu(string strXml, string _loaiDuLieu, string _UserID)
        {
            try
            {
                DbCommand dbCmd = dbConn.CreateCommand();
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.CommandText = "cust_Grd_Upd_SYNONYMS_CapNhatThongTinTuDienDuLieu";

                dbCmd.Parameters.Add(DAL.DACommon.CreateInputParameter(dbCmd, "@XmlData", DbType.String, strXml));
                dbCmd.Parameters.Add(DAL.DACommon.CreateInputParameter(dbCmd, "@NguoiCapNhat", DbType.String, _UserID));
                dbCmd.Parameters.Add(DAL.DACommon.CreateInputParameter(dbCmd, "@LoaiDuLieu", DbType.String, _loaiDuLieu));

                DbParameter dbReVal = dbCmd.CreateParameter();
                dbReVal = DAL.DACommon.CreateOutputParameter(dbCmd, "@ReVal", DbType.String, int.MaxValue);
                dbCmd.Parameters.Add(dbReVal);

                DAL.DataAccessHelper.ExecuteNonQuery(dbCmd);
                return dbReVal.Value.ToString();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        internal static DataTable LayThongTinTuDienDuLieu(string _loaiDuLieu)
        {
            try
            {
                DbCommand dbCmd = dbConn.CreateCommand();
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.CommandText = "cust_Grd_Sel_SYNONYMS_LayThongTinTuDienDuLieu";

                dbCmd.Parameters.Add(DACommon.CreateInputParameter(dbCmd, "@LoaiDuLieu", DbType.String, _loaiDuLieu));

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

        internal static DataTable LoaiTuDienDuLieu(string formID)
        {
            try
            {
                DbCommand dbCmd = dbConn.CreateCommand();
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.CommandText = "cust_Grd_Sel_SYNONYMS_LoaiTuDienDuLieu";

                dbCmd.Parameters.Add(DACommon.CreateInputParameter(dbCmd, "@FormID", DbType.String, formID));

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

        public static DataTable TimKiemThongTinSinhVien(string search, bool foreignLanguage)
        {
            try
            {
                DataTable dt = new DataTable();
                DbCommand dbCmd = dbConn.CreateCommand();
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.CommandText = "sp_Score_Sel_vw_Score_StudentInfos_Search";

                dbCmd.Parameters.Add(DACommon.CreateInputParameter(dbCmd, "@StrSearch", DbType.String, search));
                dbCmd.Parameters.Add(DACommon.CreateInputParameter(dbCmd, "@ForeignLanguage", DbType.Boolean, foreignLanguage));

                DbDataReader dr = DataAccessHelper.ExecuteReader(dbCmd);
                dt.Load(dr);
                return dt;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        internal static void SaveListOfForms(string moduleID, string formID, string formName, string formPathInProject)
        {
            try
            {
                DbCommand dbCmd = dbConn.CreateCommand();
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.CommandText = "cust_CMS_Save_psc_CMS_Forms";

                dbCmd.Parameters.Add(DACommon.CreateInputParameter(dbCmd, "@ModuleID", DbType.String, moduleID));
                dbCmd.Parameters.Add(DACommon.CreateInputParameter(dbCmd, "@FormID", DbType.String, formID));
                dbCmd.Parameters.Add(DACommon.CreateInputParameter(dbCmd, "@FormName", DbType.String, formName));
                dbCmd.Parameters.Add(DACommon.CreateInputParameter(dbCmd, "@Namespace", DbType.String, formPathInProject));

                DataAccessHelper.ExecuteNonQuery(dbCmd);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        internal static void SaveListOfFormObjects(string moduleID, string formID, string controlID, string objectName, string typeObject, string parentOject)
        {
            try
            {
                DbCommand dbCmd = dbConn.CreateCommand();
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.CommandText = "cust_CMS_Save_psc_CMS_FormObjects";

                dbCmd.Parameters.Add(DACommon.CreateInputParameter(dbCmd, "@ModuleID", DbType.String, moduleID));
                dbCmd.Parameters.Add(DACommon.CreateInputParameter(dbCmd, "@FormID", DbType.String, formID));
                dbCmd.Parameters.Add(DACommon.CreateInputParameter(dbCmd, "@ControlID", DbType.String, controlID));
                dbCmd.Parameters.Add(DACommon.CreateInputParameter(dbCmd, "@ObjectName", DbType.String, objectName));
                dbCmd.Parameters.Add(DACommon.CreateInputParameter(dbCmd, "@TypeObject", DbType.String, typeObject));
                dbCmd.Parameters.Add(DACommon.CreateInputParameter(dbCmd, "@ParentObject", DbType.String, parentOject));

                DataAccessHelper.ExecuteNonQuery(dbCmd);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        internal static DataTable GetForm()
        {
            try
            {
                DbCommand dbCmd = dbConn.CreateCommand();
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.CommandText = "cust_CMS_Sel_psc_CMS_Forms";

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

        internal static DataTable GetFormObject(string formID)
        {
            try
            {
                DataTable dt = new DataTable();
                DbCommand dbCmd = dbConn.CreateCommand();
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.CommandText = "cust_CMS_Sel_psc_CMS_FormObjects";

                dbCmd.Parameters.Add(DACommon.CreateInputParameter(dbCmd, "@FormID", DbType.String, formID));

                DbDataReader dr = DataAccessHelper.ExecuteReader(dbCmd);
                dt.Load(dr);
                return dt;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        internal static int LuuFileCongVan(int ID, string updateStaff, string File)
        {
            try
            {
                DbCommand dbCmd = dbConn.CreateCommand();
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.CommandText = "cust_CMS_Save_psc_CMS_CongVanPDF";

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
    }
}