using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace CA
{
    class DatabaseConnection
    {
        public static SqlConnection myConnection = new SqlConnection("user id = ;" + "password = ;" + "server=(LocalDB)\\MSSQLLocalDB;" + "Trusted_Connection = yes;" + "database = CA;" + "connection timeout = 30;");
        

        public static void OpenConnection()
        {
            if (myConnection.State == ConnectionState.Closed)
            {
                myConnection.Open();
            }
        }
        
        public static void CloseConnection()
        {
            if (myConnection.State == ConnectionState.Open)
            {
                myConnection.Close();
            }
        }
            
    }
}
