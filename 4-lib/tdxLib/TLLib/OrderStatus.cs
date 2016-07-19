using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace TLLib
{
    public class OrderStatus
    {
        string connectionString = Common.ConnectionString;
        DBNull dbNULL = DBNull.Value;

        public int OrderStatusInsert(
            string OrderStatusName,
            string OrderStatusNameEn,
            string IsAvailable
        )
        {
            try
            {
                var scon = new SqlConnection(connectionString);
                var cmd = new SqlCommand("usp_OrderStatus_Insert", scon);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@OrderStatusName", string.IsNullOrEmpty(OrderStatusName) ? dbNULL : (object)OrderStatusName);
                cmd.Parameters.AddWithValue("@OrderStatusNameEn", string.IsNullOrEmpty(OrderStatusNameEn) ? dbNULL : (object)OrderStatusNameEn);
                cmd.Parameters.AddWithValue("@IsAvailable", string.IsNullOrEmpty(IsAvailable) ? dbNULL : (object)IsAvailable);
                SqlParameter errorCodeParam = new SqlParameter("@ErrorCode", null);
                errorCodeParam.Size = 4;
                errorCodeParam.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(errorCodeParam);
                scon.Open();
                int success = cmd.ExecuteNonQuery();
                scon.Close();

                if (errorCodeParam.Value.ToString() != "0")
                    throw new Exception("Stored Procedure 'usp_OrderStatus_Insert' reported the ErrorCode : " + errorCodeParam.Value.ToString());

                return success;
            }
            catch (SqlException ex)
            {
                throw new Exception(ex.Number.ToString());
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public int OrderStatusUpdate(
            string OrderStatusID,
            string OrderStatusName,
            string OrderStatusNameEn,
            string IsAvailable
        )
        {
            try
            {
                var scon = new SqlConnection(connectionString);
                var cmd = new SqlCommand("usp_OrderStatus_Update", scon);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@OrderStatusID", string.IsNullOrEmpty(OrderStatusID) ? dbNULL : (object)OrderStatusID);
                cmd.Parameters.AddWithValue("@OrderStatusName", string.IsNullOrEmpty(OrderStatusName) ? dbNULL : (object)OrderStatusName);
                cmd.Parameters.AddWithValue("@OrderStatusNameEn", string.IsNullOrEmpty(OrderStatusNameEn) ? dbNULL : (object)OrderStatusNameEn);
                cmd.Parameters.AddWithValue("@IsAvailable", string.IsNullOrEmpty(IsAvailable) ? dbNULL : (object)IsAvailable);
                SqlParameter errorCodeParam = new SqlParameter("@ErrorCode", null);
                errorCodeParam.Size = 4;
                errorCodeParam.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(errorCodeParam);
                scon.Open();
                int success = cmd.ExecuteNonQuery();
                scon.Close();

                if (errorCodeParam.Value.ToString() != "0")
                    throw new Exception("Stored Procedure 'usp_OrderStatus_Update' reported the ErrorCode : " + errorCodeParam.Value.ToString());

                return success;
            }
            catch (SqlException ex)
            {
                throw new Exception(ex.Number.ToString());
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public int OrderStatusDelete(
            string OrderStatusID
        )
        {
            try
            {
                var scon = new SqlConnection(connectionString);
                var cmd = new SqlCommand("usp_OrderStatus_Delete", scon);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@OrderStatusID", string.IsNullOrEmpty(OrderStatusID) ? dbNULL : (object)OrderStatusID);
                SqlParameter errorCodeParam = new SqlParameter("@ErrorCode", null);
                errorCodeParam.Size = 4;
                errorCodeParam.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(errorCodeParam);
                scon.Open();
                int success = cmd.ExecuteNonQuery();
                scon.Close();

                if (errorCodeParam.Value.ToString() != "0")
                    throw new Exception("Stored Procedure 'usp_OrderStatus_Delete' reported the ErrorCode : " + errorCodeParam.Value.ToString());

                return success;
            }
            catch (SqlException ex)
            {
                throw new Exception(ex.Number.ToString());
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public DataTable OrderStatusSelectAll(
            string OrderStatusID,
            string OrderStatusName,
            string OrderStatusNameEn,
            string IsAvailable
        )
        {
            try
            {
                var dt = new DataTable();
                var scon = new SqlConnection(connectionString);
                var cmd = new SqlCommand("usp_OrderStatus_SelectAll", scon);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@OrderStatusID", string.IsNullOrEmpty(OrderStatusID) ? dbNULL : (object)OrderStatusID);
                cmd.Parameters.AddWithValue("@OrderStatusName", string.IsNullOrEmpty(OrderStatusName) ? dbNULL : (object)OrderStatusName);
                cmd.Parameters.AddWithValue("@OrderStatusNameEn", string.IsNullOrEmpty(OrderStatusNameEn) ? dbNULL : (object)OrderStatusNameEn);
                cmd.Parameters.AddWithValue("@IsAvailable", string.IsNullOrEmpty(IsAvailable) ? dbNULL : (object)IsAvailable);
                SqlParameter errorCodeParam = new SqlParameter("@ErrorCode", null);
                errorCodeParam.Size = 4;
                errorCodeParam.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(errorCodeParam);
                var sda = new SqlDataAdapter(cmd);
                sda.Fill(dt);

                if (errorCodeParam.Value.ToString() != "0")
                    throw new Exception("Stored Procedure 'usp_OrderStatus_SelectAll' reported the ErrorCode : " + errorCodeParam.Value.ToString());

                return dt;
            }
            catch (SqlException ex)
            {
                throw new Exception(ex.Number.ToString());
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public DataTable OrderStatusSelectOne(
            string OrderStatusID
        )
        {
            try
            {
                var dt = new DataTable();
                var scon = new SqlConnection(connectionString);
                var cmd = new SqlCommand("usp_OrderStatus_SelectOne", scon);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@OrderStatusID", string.IsNullOrEmpty(OrderStatusID) ? dbNULL : (object)OrderStatusID);
                SqlParameter errorCodeParam = new SqlParameter("@ErrorCode", null);
                errorCodeParam.Size = 4;
                errorCodeParam.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(errorCodeParam);
                var sda = new SqlDataAdapter(cmd);
                sda.Fill(dt);

                if (errorCodeParam.Value.ToString() != "0")
                    throw new Exception("Stored Procedure 'usp_OrderStatus_SelectOne' reported the ErrorCode : " + errorCodeParam.Value.ToString());

                return dt;
            }
            catch (SqlException ex)
            {
                throw new Exception(ex.Number.ToString());
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

    }
}

