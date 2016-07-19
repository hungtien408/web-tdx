using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace TLLib
{
    public class ProductOfLength
    {
        string connectionString = Common.ConnectionString;
        DBNull dbNULL = DBNull.Value;

        public int ProductOfLengthInsert(
            string IsAvailable,
            string Priority,
            string ProductID,
            string ProductLengthID
        )
        {
            try
            {
                var scon = new SqlConnection(connectionString);
                var cmd = new SqlCommand("usp_ProductOfLength_Insert", scon);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@IsAvailable", string.IsNullOrEmpty(IsAvailable) ? dbNULL : (object)IsAvailable);
                cmd.Parameters.AddWithValue("@Priority", string.IsNullOrEmpty(Priority) ? dbNULL : (object)Priority);
                cmd.Parameters.AddWithValue("@ProductID", string.IsNullOrEmpty(ProductID) ? dbNULL : (object)ProductID);
                cmd.Parameters.AddWithValue("@ProductLengthID", string.IsNullOrEmpty(ProductLengthID) ? dbNULL : (object)ProductLengthID);

                SqlParameter errorCodeParam = new SqlParameter("@ErrorCode", null);
                errorCodeParam.Size = 4;
                errorCodeParam.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(errorCodeParam);
                scon.Open();
                int success = cmd.ExecuteNonQuery();
                scon.Close();

                if (errorCodeParam.Value.ToString() != "0")
                    throw new Exception("Stored Procedure 'usp_ProductOfLength_Insert' reported the ErrorCode : " + errorCodeParam.Value.ToString());

                return success;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public int ProductOfLengthUpdate(
            string ProductOfLengthID,
            string IsAvailable,
            string Priority,
            string ProductID,
            string ProductLengthID
        )
        {
            try
            {
                var scon = new SqlConnection(connectionString);
                var cmd = new SqlCommand("usp_ProductOfLength_Update", scon);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ProductOfLengthID", string.IsNullOrEmpty(ProductOfLengthID) ? dbNULL : (object)ProductOfLengthID);
                cmd.Parameters.AddWithValue("@IsAvailable", string.IsNullOrEmpty(IsAvailable) ? dbNULL : (object)IsAvailable);
                cmd.Parameters.AddWithValue("@Priority", string.IsNullOrEmpty(Priority) ? dbNULL : (object)Priority);
                cmd.Parameters.AddWithValue("@ProductID", string.IsNullOrEmpty(ProductID) ? dbNULL : (object)ProductID);
                cmd.Parameters.AddWithValue("@ProductLengthID", string.IsNullOrEmpty(ProductLengthID) ? dbNULL : (object)ProductLengthID);

                SqlParameter errorCodeParam = new SqlParameter("@ErrorCode", null);
                errorCodeParam.Size = 4;
                errorCodeParam.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(errorCodeParam);
                scon.Open();
                int success = cmd.ExecuteNonQuery();
                scon.Close();

                if (errorCodeParam.Value.ToString() != "0")
                    throw new Exception("Stored Procedure 'usp_ProductOfLength_Update' reported the ErrorCode : " + errorCodeParam.Value.ToString());

                return success;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public int ProductOfLengthQuickUpdate(
            string ProductOfLengthID,
            string IsAvailable,
            string Priority
        )
        {
            try
            {
                var scon = new SqlConnection(connectionString);
                var cmd = new SqlCommand("usp_ProductOfLength_QuickUpdate", scon);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ProductOfLengthID", string.IsNullOrEmpty(ProductOfLengthID) ? dbNULL : (object)ProductOfLengthID);
                cmd.Parameters.AddWithValue("@IsAvailable", string.IsNullOrEmpty(IsAvailable) ? dbNULL : (object)IsAvailable);
                cmd.Parameters.AddWithValue("@Priority", string.IsNullOrEmpty(Priority) ? dbNULL : (object)Priority);

                SqlParameter errorCodeParam = new SqlParameter("@ErrorCode", null);
                errorCodeParam.Size = 4;
                errorCodeParam.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(errorCodeParam);
                scon.Open();
                int success = cmd.ExecuteNonQuery();
                scon.Close();

                if (errorCodeParam.Value.ToString() != "0")
                    throw new Exception("Stored Procedure 'usp_ProductOfLength_QuickUpdate' reported the ErrorCode : " + errorCodeParam.Value.ToString());

                return success;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public int ProductOfLengthDelete(
            string ProductOfLengthID
        )
        {
            try
            {
                var scon = new SqlConnection(connectionString);
                var cmd = new SqlCommand("usp_ProductOfLength_Delete", scon);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ProductOfLengthID", string.IsNullOrEmpty(ProductOfLengthID) ? dbNULL : (object)ProductOfLengthID);
                SqlParameter errorCodeParam = new SqlParameter("@ErrorCode", null);
                errorCodeParam.Size = 4;
                errorCodeParam.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(errorCodeParam);
                scon.Open();
                int success = cmd.ExecuteNonQuery();
                scon.Close();

                if (errorCodeParam.Value.ToString() != "0")
                    throw new Exception("Stored Procedure 'usp_ProductOfLength_Delete' reported the ErrorCode : " + errorCodeParam.Value.ToString());

                return success;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public DataTable ProductOfLengthSelectAll(
            string IsAvailable,
            string Priority,
            string SortByPriority,
            string ProductID,
            string ProductLengthID
        )
        {
            try
            {
                var dt = new DataTable();
                var scon = new SqlConnection(connectionString);
                var cmd = new SqlCommand("usp_ProductOfLength_SelectAll", scon);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@IsAvailable", string.IsNullOrEmpty(IsAvailable) ? dbNULL : (object)IsAvailable);
                cmd.Parameters.AddWithValue("@Priority", string.IsNullOrEmpty(Priority) ? dbNULL : (object)Priority);
                cmd.Parameters.AddWithValue("@SortByPriority", string.IsNullOrEmpty(SortByPriority) ? dbNULL : (object)SortByPriority);
                cmd.Parameters.AddWithValue("@ProductID", string.IsNullOrEmpty(ProductID) ? dbNULL : (object)ProductID);
                cmd.Parameters.AddWithValue("@ProductLengthID", string.IsNullOrEmpty(ProductLengthID) ? dbNULL : (object)ProductLengthID);


                SqlParameter errorCodeParam = new SqlParameter("@ErrorCode", null);
                errorCodeParam.Size = 4;
                errorCodeParam.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(errorCodeParam);
                var sda = new SqlDataAdapter(cmd);
                sda.Fill(dt);

                if (errorCodeParam.Value.ToString() != "0")
                    throw new Exception("Stored Procedure 'usp_ProductOfLength_SelectAll' reported the ErrorCode : " + errorCodeParam.Value.ToString());

                return dt;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public DataTable ProductOfLengthSelectOne(
            string ProductOfLengthID
        )
        {
            try
            {
                var dt = new DataTable();
                var scon = new SqlConnection(connectionString);
                var cmd = new SqlCommand("usp_ProductOfLength_SelectOne", scon);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ProductOfLengthID", string.IsNullOrEmpty(ProductOfLengthID) ? dbNULL : (object)ProductOfLengthID);
                SqlParameter errorCodeParam = new SqlParameter("@ErrorCode", null);
                errorCodeParam.Size = 4;
                errorCodeParam.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(errorCodeParam);
                var sda = new SqlDataAdapter(cmd);
                sda.Fill(dt);

                if (errorCodeParam.Value.ToString() != "0")
                    throw new Exception("Stored Procedure 'usp_ProductOfLength_SelectOne' reported the ErrorCode : " + errorCodeParam.Value.ToString());

                return dt;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

    }
}

