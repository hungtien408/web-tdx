using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace TLLib
{
    public class OrderDetail
    {
        string connectionString = Common.ConnectionString;
        DBNull dbNULL = DBNull.Value;

        public int OrderDetailInsert(
            string OrderID,
            string ProductID,
            string Quantity,
            string Price,
            string CreateBy,
            string ProductColorName,
            string ProductColorNameEn
        )
        {
            try
            {
                var scon = new SqlConnection(connectionString);
                var cmd = new SqlCommand("usp_OrderDetail_Insert", scon);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@OrderID", string.IsNullOrEmpty(OrderID) ? dbNULL : (object)OrderID);
                cmd.Parameters.AddWithValue("@ProductID", string.IsNullOrEmpty(ProductID) ? dbNULL : (object)ProductID);
                cmd.Parameters.AddWithValue("@Quantity", string.IsNullOrEmpty(Quantity) ? dbNULL : (object)Quantity);
                cmd.Parameters.AddWithValue("@Price", string.IsNullOrEmpty(Price) ? dbNULL : (object)Price);
                cmd.Parameters.AddWithValue("@CreateBy", string.IsNullOrEmpty(CreateBy) ? dbNULL : (object)CreateBy);
                cmd.Parameters.AddWithValue("@ProductColorName", string.IsNullOrEmpty(ProductColorName) ? dbNULL : (object)ProductColorName);
                cmd.Parameters.AddWithValue("@ProductColorNameEn", string.IsNullOrEmpty(ProductColorNameEn) ? dbNULL : (object)ProductColorNameEn);
                
                SqlParameter errorCodeParam = new SqlParameter("@ErrorCode", null);
                errorCodeParam.Size = 4;
                errorCodeParam.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(errorCodeParam);
                scon.Open();
                int success = cmd.ExecuteNonQuery();
                scon.Close();

                if (errorCodeParam.Value.ToString() != "0")
                    throw new Exception("Stored Procedure 'usp_OrderDetail_Insert' reported the ErrorCode : " + errorCodeParam.Value.ToString());

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

        public int OrderDetailInsert1(
            string OrderID,
            string ProductID,
            string Quantity,
            string Price,
            string CreateBy,
            string ProductColorName,
            string ProductColorNameEn,
            string Email
        )
        {
            try
            {
                var scon = new SqlConnection(connectionString);
                var cmd = new SqlCommand("usp_OrderDetail_Insert1", scon);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@OrderID", string.IsNullOrEmpty(OrderID) ? dbNULL : (object)OrderID);
                cmd.Parameters.AddWithValue("@ProductID", string.IsNullOrEmpty(ProductID) ? dbNULL : (object)ProductID);
                cmd.Parameters.AddWithValue("@Quantity", string.IsNullOrEmpty(Quantity) ? dbNULL : (object)Quantity);
                cmd.Parameters.AddWithValue("@Price", string.IsNullOrEmpty(Price) ? dbNULL : (object)Price);
                cmd.Parameters.AddWithValue("@CreateBy", string.IsNullOrEmpty(CreateBy) ? dbNULL : (object)CreateBy);
                cmd.Parameters.AddWithValue("@ProductColorName", string.IsNullOrEmpty(ProductColorName) ? dbNULL : (object)ProductColorName);
                cmd.Parameters.AddWithValue("@ProductColorNameEn", string.IsNullOrEmpty(ProductColorNameEn) ? dbNULL : (object)ProductColorNameEn);
                cmd.Parameters.AddWithValue("@Email", string.IsNullOrEmpty(Email) ? dbNULL : (object)Email);

                SqlParameter errorCodeParam = new SqlParameter("@ErrorCode", null);
                errorCodeParam.Size = 4;
                errorCodeParam.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(errorCodeParam);
                scon.Open();
                int success = cmd.ExecuteNonQuery();
                scon.Close();

                if (errorCodeParam.Value.ToString() != "0")
                    throw new Exception("Stored Procedure 'usp_OrderDetail_Insert1' reported the ErrorCode : " + errorCodeParam.Value.ToString());

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

        public int OrderDetailUpdate(
            string OrderDetailID,
            string OrderID,
            string ProductID,
            string Quantity,
            string Price,
            string CreateBy
        )
        {
            try
            {
                var scon = new SqlConnection(connectionString);
                var cmd = new SqlCommand("usp_OrderDetail_Update", scon);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@OrderDetailID", string.IsNullOrEmpty(OrderDetailID) ? dbNULL : (object)OrderDetailID);
                cmd.Parameters.AddWithValue("@OrderID", string.IsNullOrEmpty(OrderID) ? dbNULL : (object)OrderID);
                cmd.Parameters.AddWithValue("@ProductID", string.IsNullOrEmpty(ProductID) ? dbNULL : (object)ProductID);
                cmd.Parameters.AddWithValue("@Quantity", string.IsNullOrEmpty(Quantity) ? dbNULL : (object)Quantity);
                cmd.Parameters.AddWithValue("@Price", string.IsNullOrEmpty(Price) ? dbNULL : (object)Price);
                
                
                SqlParameter errorCodeParam = new SqlParameter("@ErrorCode", null);
                errorCodeParam.Size = 4;
                errorCodeParam.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(errorCodeParam);
                scon.Open();
                int success = cmd.ExecuteNonQuery();
                scon.Close();

                if (errorCodeParam.Value.ToString() != "0")
                    throw new Exception("Stored Procedure 'usp_OrderDetail_Update' reported the ErrorCode : " + errorCodeParam.Value.ToString());

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

        public int OrderDetailDelete(
            string OrderDetailID
        )
        {
            try
            {
                var scon = new SqlConnection(connectionString);
                var cmd = new SqlCommand("usp_OrderDetail_Delete", scon);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@OrderDetailID", string.IsNullOrEmpty(OrderDetailID) ? dbNULL : (object)OrderDetailID);
                SqlParameter errorCodeParam = new SqlParameter("@ErrorCode", null);
                errorCodeParam.Size = 4;
                errorCodeParam.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(errorCodeParam);
                scon.Open();
                int success = cmd.ExecuteNonQuery();
                scon.Close();

                if (errorCodeParam.Value.ToString() != "0")
                    throw new Exception("Stored Procedure 'usp_OrderDetail_Delete' reported the ErrorCode : " + errorCodeParam.Value.ToString());

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

        public DataTable OrderDetailSelectAll(
            string OrderDetailID,
            string OrderID,
            string ProductID,
            string ProductName,
            string Description,
            string Quantity,
            string Price,
            //string Type,
            string CreateBy,
            string CreateDate
        )
        {
            try
            {
                var dt = new DataTable();
                var scon = new SqlConnection(connectionString);
                var cmd = new SqlCommand("usp_OrderDetail_SelectAll", scon);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@OrderDetailID", string.IsNullOrEmpty(OrderDetailID) ? dbNULL : (object)OrderDetailID);
                cmd.Parameters.AddWithValue("@OrderID", string.IsNullOrEmpty(OrderID) ? dbNULL : (object)OrderID);
                cmd.Parameters.AddWithValue("@ProductID", string.IsNullOrEmpty(ProductID) ? dbNULL : (object)ProductID);
                cmd.Parameters.AddWithValue("@ProductName", string.IsNullOrEmpty(ProductName) ? dbNULL : (object)ProductName);
                cmd.Parameters.AddWithValue("@Description", string.IsNullOrEmpty(Description) ? dbNULL : (object)Description);
                cmd.Parameters.AddWithValue("@Quantity", string.IsNullOrEmpty(Quantity) ? dbNULL : (object)Quantity);
                cmd.Parameters.AddWithValue("@Price", string.IsNullOrEmpty(Price) ? dbNULL : (object)Price);
                //cmd.Parameters.AddWithValue("@Type", string.IsNullOrEmpty(Type) ? dbNULL : (object)Type);
                cmd.Parameters.AddWithValue("@CreateBy", string.IsNullOrEmpty(CreateBy) ? dbNULL : (object)CreateBy);
                cmd.Parameters.AddWithValue("@CreateDate", string.IsNullOrEmpty(CreateDate) ? dbNULL : (object)CreateDate);
                SqlParameter errorCodeParam = new SqlParameter("@ErrorCode", null);
                errorCodeParam.Size = 4;
                errorCodeParam.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(errorCodeParam);
                var sda = new SqlDataAdapter(cmd);
                sda.Fill(dt);

                if (errorCodeParam.Value.ToString() != "0")
                    throw new Exception("Stored Procedure 'usp_OrderDetail_SelectAll' reported the ErrorCode : " + errorCodeParam.Value.ToString());

                return dt;
            }
            //catch (SqlException ex)
            //{
            //    throw new Exception(ex.Number.ToString());
            //}
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public DataTable OrderDetailSelectAll1(
            string OrderDetailID,
            string OrderID,
            string ProductID,
            string ProductName,
            string Description,
            string Quantity,
            string Price,
            //string Type,
            string CreateBy,
            string CreateDate,
            string Email
        )
        {
            try
            {
                var dt = new DataTable();
                var scon = new SqlConnection(connectionString);
                var cmd = new SqlCommand("usp_OrderDetail_SelectAll1", scon);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@OrderDetailID", string.IsNullOrEmpty(OrderDetailID) ? dbNULL : (object)OrderDetailID);
                cmd.Parameters.AddWithValue("@OrderID", string.IsNullOrEmpty(OrderID) ? dbNULL : (object)OrderID);
                cmd.Parameters.AddWithValue("@ProductID", string.IsNullOrEmpty(ProductID) ? dbNULL : (object)ProductID);
                cmd.Parameters.AddWithValue("@ProductName", string.IsNullOrEmpty(ProductName) ? dbNULL : (object)ProductName);
                cmd.Parameters.AddWithValue("@Description", string.IsNullOrEmpty(Description) ? dbNULL : (object)Description);
                cmd.Parameters.AddWithValue("@Quantity", string.IsNullOrEmpty(Quantity) ? dbNULL : (object)Quantity);
                cmd.Parameters.AddWithValue("@Price", string.IsNullOrEmpty(Price) ? dbNULL : (object)Price);
                //cmd.Parameters.AddWithValue("@Type", string.IsNullOrEmpty(Type) ? dbNULL : (object)Type);
                cmd.Parameters.AddWithValue("@CreateBy", string.IsNullOrEmpty(CreateBy) ? dbNULL : (object)CreateBy);
                cmd.Parameters.AddWithValue("@CreateDate", string.IsNullOrEmpty(CreateDate) ? dbNULL : (object)CreateDate);
                cmd.Parameters.AddWithValue("@Email", string.IsNullOrEmpty(Email) ? dbNULL : (object)Email);

                SqlParameter errorCodeParam = new SqlParameter("@ErrorCode", null);
                errorCodeParam.Size = 4;
                errorCodeParam.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(errorCodeParam);
                var sda = new SqlDataAdapter(cmd);
                sda.Fill(dt);

                if (errorCodeParam.Value.ToString() != "0")
                    throw new Exception("Stored Procedure 'usp_OrderDetail_SelectAll1' reported the ErrorCode : " + errorCodeParam.Value.ToString());

                return dt;
            }
            //catch (SqlException ex)
            //{
            //    throw new Exception(ex.Number.ToString());
            //}
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public DataTable OrderDetailSelectOne(
            string OrderDetailID
        )
        {
            try
            {
                var dt = new DataTable();
                var scon = new SqlConnection(connectionString);
                var cmd = new SqlCommand("usp_OrderDetail_SelectOne", scon);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@OrderDetailID", string.IsNullOrEmpty(OrderDetailID) ? dbNULL : (object)OrderDetailID);
                SqlParameter errorCodeParam = new SqlParameter("@ErrorCode", null);
                errorCodeParam.Size = 4;
                errorCodeParam.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(errorCodeParam);
                var sda = new SqlDataAdapter(cmd);
                sda.Fill(dt);

                if (errorCodeParam.Value.ToString() != "0")
                    throw new Exception("Stored Procedure 'usp_OrderDetail_SelectOne' reported the ErrorCode : " + errorCodeParam.Value.ToString());

                return dt;
            }
            //catch (SqlException ex)
            //{
            //    throw new Exception(ex.Number.ToString());
            //}
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

    }
}

