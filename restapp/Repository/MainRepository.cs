using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace RestApp.Repository
{
    public class MainRepository
    {
        protected Guid GetNewId()
        {
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["HotelConnectionString"].ConnectionString);
            var query = "select newid()";
            conn.Open();
            SqlCommand com = new SqlCommand(query, conn);
            var guid = new Guid(com.ExecuteScalar().ToString());
            conn.Close();
            return guid;
        }
    }
}