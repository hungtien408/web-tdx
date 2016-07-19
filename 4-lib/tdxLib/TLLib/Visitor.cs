using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace TLLib
{
    public class Visitor
    {
        string connectionString = Common.ConnectionString;
        public DataTable Visitors()
        {
            DataTable dt = new DataTable();
            SqlConnection scon = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand("usp_Visitor_Edit", scon);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            sda.Fill(dt);
            return dt;
        }

    }
}

