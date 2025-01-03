using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.Odbc;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMSCore
{
    public class Provider
    {
        public static string _provider;
        public static string _userID;
        public static string _connectionString;

        public static DbConnection GetConnection()
        {
            switch (_provider)
            {
                case "System.Data.SqlClient":
                    {
                        return new SqlConnection(_connectionString);
                    }
                case "OleDb":
                    {
                        return new OleDbConnection(_connectionString);
                    }
                case "Odbc":
                    {
                        return new OdbcConnection(_connectionString);
                    }
                default:
                    {
                        throw new Exception("Not support this provider type.");
                    }
            }
        }
    }
}
