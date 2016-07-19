using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace TLLib
{
    public class WishList
    {
        string connectionString = Common.ConnectionString;
        DBNull dbNULL = DBNull.Value;

        public int WishListInsert(
            string ProductID,
            string UserName,
            string Quantity,
            string Price
        )
        {
            try
            {
                var scon = new SqlConnection(connectionString);
                var cmd = new SqlCommand("usp_WishList_Insert", scon);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ProductID", string.IsNullOrEmpty(ProductID) ? dbNULL : (object)ProductID);
                cmd.Parameters.AddWithValue("@UserName", string.IsNullOrEmpty(UserName) ? dbNULL : (object)UserName);
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
                    throw new Exception("Stored Procedure 'usp_WishList_Insert' reported the ErrorCode : " + errorCodeParam.Value.ToString());

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

        public int WishListInsert1(
            string ProductID,
            string UserName,
            string Quantity,
            string Price,
            string ImageName,
	        string ProductName,
	        string ProductNameEn,
	        string ProductCode,
	        string ProductOptionCategoryID,
	        string ProductOptionCategoryName,
	        string ProductLengthID,
	        string ProductLengthName,
	        string ProductSizeColorID,
	        string QuantityList
        )
        {
            try
            {
                var scon = new SqlConnection(connectionString);
                var cmd = new SqlCommand("usp_WishList_Insert1", scon);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ProductID", string.IsNullOrEmpty(ProductID) ? dbNULL : (object)ProductID);
                cmd.Parameters.AddWithValue("@UserName", string.IsNullOrEmpty(UserName) ? dbNULL : (object)UserName);
                cmd.Parameters.AddWithValue("@Quantity", string.IsNullOrEmpty(Quantity) ? dbNULL : (object)Quantity);
                cmd.Parameters.AddWithValue("@Price", string.IsNullOrEmpty(Price) ? dbNULL : (object)Price);

                cmd.Parameters.AddWithValue("@ImageName", string.IsNullOrEmpty(ImageName) ? dbNULL : (object)ImageName);
                cmd.Parameters.AddWithValue("@ProductName", string.IsNullOrEmpty(ProductName) ? dbNULL : (object)ProductName);
                cmd.Parameters.AddWithValue("@ProductNameEn", string.IsNullOrEmpty(ProductNameEn) ? dbNULL : (object)ProductNameEn);
                cmd.Parameters.AddWithValue("@ProductCode", string.IsNullOrEmpty(ProductCode) ? dbNULL : (object)ProductCode);
                cmd.Parameters.AddWithValue("@ProductOptionCategoryID", string.IsNullOrEmpty(ProductOptionCategoryID) ? dbNULL : (object)ProductOptionCategoryID);
                cmd.Parameters.AddWithValue("@ProductOptionCategoryName", string.IsNullOrEmpty(ProductOptionCategoryName) ? dbNULL : (object)ProductOptionCategoryName);
                cmd.Parameters.AddWithValue("@ProductLengthID", string.IsNullOrEmpty(ProductLengthID) ? dbNULL : (object)ProductLengthID);
                cmd.Parameters.AddWithValue("@ProductLengthName", string.IsNullOrEmpty(ProductLengthName) ? dbNULL : (object)ProductLengthName);
                cmd.Parameters.AddWithValue("@ProductSizeColorID", string.IsNullOrEmpty(ProductSizeColorID) ? dbNULL : (object)ProductSizeColorID);
                cmd.Parameters.AddWithValue("@QuantityList", string.IsNullOrEmpty(QuantityList) ? dbNULL : (object)QuantityList);


                SqlParameter errorCodeParam = new SqlParameter("@ErrorCode", null);
                errorCodeParam.Size = 4;
                errorCodeParam.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(errorCodeParam);
                scon.Open();
                int success = cmd.ExecuteNonQuery();
                scon.Close();

                if (errorCodeParam.Value.ToString() != "0")
                    throw new Exception("Stored Procedure 'usp_WishList_Insert1' reported the ErrorCode : " + errorCodeParam.Value.ToString());

                return success;
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

        public int WishListUpdate(
            string ProductID,
            string UserName,
            string Quantity,
            string Price
        )
        {
            try
            {
                var scon = new SqlConnection(connectionString);
                var cmd = new SqlCommand("usp_WishList_Update", scon);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ProductID", string.IsNullOrEmpty(ProductID) ? dbNULL : (object)ProductID);
                cmd.Parameters.AddWithValue("@UserName", string.IsNullOrEmpty(UserName) ? dbNULL : (object)UserName);
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
                    throw new Exception("Stored Procedure 'usp_WishList_Update' reported the ErrorCode : " + errorCodeParam.Value.ToString());

                return success;
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

        public int WishListUpdate1(
            string ProductID,
            string UserName,
            string Quantity,
            string Price,
            string ImageName,
            string ProductName,
            string ProductNameEn,
            string ProductCode,
            string ProductOptionCategoryID,
            string ProductOptionCategoryName,
            string ProductLengthID,
            string ProductLengthName,
            string ProductSizeColorID,
            string QuantityList
        )
        {
            try
            {
                var scon = new SqlConnection(connectionString);
                var cmd = new SqlCommand("usp_WishList_Update1", scon);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ProductID", string.IsNullOrEmpty(ProductID) ? dbNULL : (object)ProductID);
                cmd.Parameters.AddWithValue("@UserName", string.IsNullOrEmpty(UserName) ? dbNULL : (object)UserName);
                cmd.Parameters.AddWithValue("@Quantity", string.IsNullOrEmpty(Quantity) ? dbNULL : (object)Quantity);
                cmd.Parameters.AddWithValue("@Price", string.IsNullOrEmpty(Price) ? dbNULL : (object)Price);

                cmd.Parameters.AddWithValue("@ImageName", string.IsNullOrEmpty(ImageName) ? dbNULL : (object)ImageName);
                cmd.Parameters.AddWithValue("@ProductName", string.IsNullOrEmpty(ProductName) ? dbNULL : (object)ProductName);
                cmd.Parameters.AddWithValue("@ProductNameEn", string.IsNullOrEmpty(ProductNameEn) ? dbNULL : (object)ProductNameEn);
                cmd.Parameters.AddWithValue("@ProductCode", string.IsNullOrEmpty(ProductCode) ? dbNULL : (object)ProductCode);
                cmd.Parameters.AddWithValue("@ProductOptionCategoryID", string.IsNullOrEmpty(ProductOptionCategoryID) ? dbNULL : (object)ProductOptionCategoryID);
                cmd.Parameters.AddWithValue("@ProductOptionCategoryName", string.IsNullOrEmpty(ProductOptionCategoryName) ? dbNULL : (object)ProductOptionCategoryName);
                cmd.Parameters.AddWithValue("@ProductLengthID", string.IsNullOrEmpty(ProductLengthID) ? dbNULL : (object)ProductLengthID);
                cmd.Parameters.AddWithValue("@ProductLengthName", string.IsNullOrEmpty(ProductLengthName) ? dbNULL : (object)ProductLengthName);
                cmd.Parameters.AddWithValue("@ProductSizeColorID", string.IsNullOrEmpty(ProductSizeColorID) ? dbNULL : (object)ProductSizeColorID);
                cmd.Parameters.AddWithValue("@QuantityList", string.IsNullOrEmpty(QuantityList) ? dbNULL : (object)QuantityList);

                SqlParameter errorCodeParam = new SqlParameter("@ErrorCode", null);
                errorCodeParam.Size = 4;
                errorCodeParam.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(errorCodeParam);
                scon.Open();
                int success = cmd.ExecuteNonQuery();
                scon.Close();

                if (errorCodeParam.Value.ToString() != "0")
                    throw new Exception("Stored Procedure 'usp_WishList_Update1' reported the ErrorCode : " + errorCodeParam.Value.ToString());

                return success;
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

        public int WishListDelete(
            string ProductID,
            string UserName
        )
        {
            try
            {
                var scon = new SqlConnection(connectionString);
                var cmd = new SqlCommand("usp_WishList_Delete", scon);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ProductID", string.IsNullOrEmpty(ProductID) ? dbNULL : (object)ProductID);
                cmd.Parameters.AddWithValue("@UserName", string.IsNullOrEmpty(UserName) ? dbNULL : (object)UserName);
                SqlParameter errorCodeParam = new SqlParameter("@ErrorCode", null);
                errorCodeParam.Size = 4;
                errorCodeParam.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(errorCodeParam);
                scon.Open();
                int success = cmd.ExecuteNonQuery();
                scon.Close();

                if (errorCodeParam.Value.ToString() != "0")
                    throw new Exception("Stored Procedure 'usp_WishList_Delete' reported the ErrorCode : " + errorCodeParam.Value.ToString());

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

        public DataTable WishListSelectAll(
            string Keyword,
            string ProductID,
            string UserName,
            string Quantity,
            string Price,
            string FromDate,
            string ToDate
        )
        {
            try
            {
                var dt = new DataTable();
                var scon = new SqlConnection(connectionString);
                var cmd = new SqlCommand("usp_WishList_SelectAll", scon);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Keyword", string.IsNullOrEmpty(Keyword) ? dbNULL : (object)Keyword);
                cmd.Parameters.AddWithValue("@ProductID", string.IsNullOrEmpty(ProductID) ? dbNULL : (object)ProductID);
                cmd.Parameters.AddWithValue("@UserName", string.IsNullOrEmpty(UserName) ? dbNULL : (object)UserName);
                cmd.Parameters.AddWithValue("@Quantity", string.IsNullOrEmpty(Quantity) ? dbNULL : (object)Quantity);
                cmd.Parameters.AddWithValue("@Price", string.IsNullOrEmpty(Price) ? dbNULL : (object)Price);
                cmd.Parameters.AddWithValue("@FromDate", string.IsNullOrEmpty(FromDate) ? dbNULL : (object)FromDate);
                cmd.Parameters.AddWithValue("@ToDate", string.IsNullOrEmpty(ToDate) ? dbNULL : (object)ToDate);
                var errorCodeParam = new SqlParameter("@ErrorCode", null);
                errorCodeParam.Size = 4;
                errorCodeParam.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(errorCodeParam);
                var sda = new SqlDataAdapter(cmd);
                sda.Fill(dt);

                if (errorCodeParam.Value.ToString() != "0")
                    throw new Exception("Stored Procedure 'usp_WishList_SelectAll' reported the ErrorCode : " + errorCodeParam.Value.ToString());

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

        public DataTable WishListSelectOne(
            string ProductID
        )
        {
            try
            {
                var dt = new DataTable();
                var scon = new SqlConnection(connectionString);
                var cmd = new SqlCommand("usp_WishList_SelectOne", scon);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ProductID", string.IsNullOrEmpty(ProductID) ? dbNULL : (object)ProductID);
                SqlParameter errorCodeParam = new SqlParameter("@ErrorCode", null);
                errorCodeParam.Size = 4;
                errorCodeParam.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(errorCodeParam);
                var sda = new SqlDataAdapter(cmd);
                sda.Fill(dt);

                if (errorCodeParam.Value.ToString() != "0")
                    throw new Exception("Stored Procedure 'usp_WishList_SelectOne' reported the ErrorCode : " + errorCodeParam.Value.ToString());

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

