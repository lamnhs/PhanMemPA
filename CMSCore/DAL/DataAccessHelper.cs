using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.Net;
using System.Windows.Forms;

namespace CMSCore.DAL
{
    class DataAccessHelper
    {
        public static void ExecuteNonQuery(DbCommand dbCmd)
        {
            try
            {
                if (dbCmd.Connection.State != ConnectionState.Open)
                {
                    try
                    {
                        dbCmd.Connection.Open();
                    }
                    catch (Exception ex) { throw new Exception(ex.Message); }
                }
                dbCmd.CommandTimeout = 5000;
                dbCmd.ExecuteNonQuery();

                //Chay phan Log
                try
                {
                    ExecuteForLog(dbCmd);
                }
                catch { }

                dbCmd.Parameters.Clear();
                dbCmd.Connection.Close();
            }
            catch (SqlException ex)
            {
                dbCmd.Parameters.Clear();
                dbCmd.Connection.Close();
                throw new Exception(ex.Message);
            }
            catch (Exception ex)
            {
                dbCmd.Parameters.Clear();
                dbCmd.Connection.Close();
                throw new Exception(ex.Message);
            }
        }

        public static DbDataReader ExecuteReader(DbCommand dbCmd)
        {
            try
            {
                if (dbCmd.Connection.State != ConnectionState.Closed)
                {
                    dbCmd.Connection.Close();
                }

                if (dbCmd.Connection.State != ConnectionState.Open)
                {
                    try
                    {
                        dbCmd.Connection.Open();

                    }
                    catch (Exception ex) { throw new Exception(ex.Message); }
                }

                dbCmd.CommandTimeout = 5000;

                //Chay phan Log
                try
                {
                    ExecuteForLog(dbCmd);
                }
                catch { }

                DbDataReader rv = dbCmd.ExecuteReader(CommandBehavior.CloseConnection);
                dbCmd.Parameters.Clear();
                return rv;
            }
            catch (Exception ex)
            {
                dbCmd.Connection.Close();
                throw new Exception(ex.Message);
            }
        }

        public static void ExecuteForLog(DbCommand dbCmd)
        {
            System.Data.SqlClient.SqlCommand sqlComm = null;
            try
            {
                string strConn = dbCmd.Connection.ConnectionString;
                string strComm = dbCmd.CommandText;
                string hostName = Dns.GetHostName();
                string userID = Provider._userID;
                string value = "<Root>";
                foreach (System.Data.Common.DbParameter para in dbCmd.Parameters)
                {
                    value += "<Error " + para.ParameterName + " = \"" + para.Value.ToString()
                            + "\"/>";
                }
                value += "</Root>";
                string ip = Dns.GetHostByName(hostName).AddressList[0].ToString();
                SqlConnection sqlConn = new SqlConnection(strConn);
                sqlConn.Open();
                sqlComm = new SqlCommand(strComm, sqlConn);
                sqlComm.CommandText = "insert into UIS_CMS_Log.dbo.psc_CMS_SystemLog (HostName,UserID,Command,Value,UpdateDate,UpdateStaff,IPAddress,DataBaseName) values "
                                    + "('" + hostName + "','" + SystemInformation.UserName + "','" + strComm + "','" + value + "', getdate() ,'" + userID + "','" + ip + "','UIS_CMS')";

                sqlComm.CommandType = CommandType.Text;
                sqlComm.ExecuteNonQuery();
                sqlComm.Connection.Close();
            }
            catch
            {
                sqlComm.Connection.Close();
            }
        }
    }
}
