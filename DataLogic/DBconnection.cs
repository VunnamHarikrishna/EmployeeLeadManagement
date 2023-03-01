using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLogic
{
   public class DBconnection
    {
        private static string str = ConfigurationManager.ConnectionStrings["DBcon"].ConnectionString;

        private static SqlConnection cons = new SqlConnection(str);

        public SqlConnection getConnection()
        {
            return cons;
        }
        public void OpenConnection()
        {

            cons.Open();
            Console.WriteLine("connection established");
        }
        public void CloseConnection()
        {
            cons.Close();
           Console.WriteLine("connection closed");
        }

    }
}

