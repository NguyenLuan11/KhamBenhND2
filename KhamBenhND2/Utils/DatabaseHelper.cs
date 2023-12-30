using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;

namespace KhamBenhND2.Utils
{
    internal class DatabaseHelper
    {
        public static string serverName;
        public static string databaseName;
        public static string userId;
        public static string password;

        public static SqlConnection getConnection()
        {
            string strConnect = "server =" + serverName +
                "; Initial Catalog = " + databaseName +
                "; uid = " + userId +
                "; pwd = " + password +
                "; TrustServerCertificate=True; Encrypt=false;";
            return new SqlConnection(strConnect);
        }
    }
}
