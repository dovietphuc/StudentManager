using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Data.SqlClient;

namespace StudentManager.Areas.Admin.Models
{
    public class DBConnection
    {
        string strCon;
        public DBConnection() {
            strCon = ConfigurationManager.ConnectionStrings["dbconnect"].ConnectionString;
        }

        public SqlConnection getConnection()
        {
            return new SqlConnection(strCon);
        }
    }
}