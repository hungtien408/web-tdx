using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace TLLib
{
    public class Rating
    {
        string connectionString = Common.ConnectionString;
        DBNull dbNULL = DBNull.Value;

        public int[] RatingSelectAll(
            string ProductID
        )
        {
            try
            {
                var rateValues = new int[] { 0, 0, 0, 0, 0 };
                var dt = new DataTable();
                var scon = new SqlConnection(connectionString);
                var cmd = new SqlCommand("usp_Rating_SelectAll", scon);
                var sda = new SqlDataAdapter(cmd);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ProductID", string.IsNullOrEmpty(ProductID) ? dbNULL : (object)ProductID);
                sda.Fill(dt);

                if (dt.Rows.Count > 0)
                {
                    for(int i=0;i<dt.Columns.Count;i++)
                    {
                        rateValues[i] = Convert.ToInt32(dt.Rows[0][i]);
                    }
                }

                return rateValues;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public int RatingUpdate(
            string ProductID,
            string RateID
        )
        {
            try
            {
                var scon = new SqlConnection(connectionString);
                var cmd = new SqlCommand("usp_Rating_Update", scon);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ProductID", string.IsNullOrEmpty(ProductID) ? dbNULL : (object)ProductID);
                cmd.Parameters.AddWithValue("@RateID", string.IsNullOrEmpty(RateID) ? dbNULL : (object)RateID);
                scon.Open();
                int success = cmd.ExecuteNonQuery();
                scon.Close();

                return success;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}

