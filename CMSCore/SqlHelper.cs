using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMSCore
{
    public class SqlHelper
    {
        private SqlConnection cn;

        public SqlHelper(string connectionString)
        {
            cn = new SqlConnection(connectionString);
        }

        private void OpenConnection()
        {
            if (cn.State == ConnectionState.Closed)
                cn.Open();
        }

        private void CloseConnection()
        {
            if (cn.State == ConnectionState.Open)
                cn.Close();
        }

        public bool CheckConnection()
        {
            try
            {
                OpenConnection();
                if (cn.State == ConnectionState.Open)
                    return true;
            }
            catch (SqlException)
            {
                return false;
            }
            finally
            {
                CloseConnection();
            }
            return false;
        }
    }
}
