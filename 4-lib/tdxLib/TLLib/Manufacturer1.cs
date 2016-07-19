using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace TLLib
{
    public class Manufacturer1
    {
        string connectionString = Common.ConnectionString;
        DBNull dbNULL = DBNull.Value;

        public string ManufacturerInsert(
            string ManufacturerName,
            string ManufacturerNameEn,
            string ConvertedManufacturerName,
            string ManufacturerImage,
            string IsAvailable,
            string Priority,
            string ProductID,
            string Content,
            string ContentEn
        )
        {
            try
            {
                var scon = new SqlConnection(connectionString);
                var cmd = new SqlCommand("usp_Manufacturer_Insert1", scon);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ManufacturerName", string.IsNullOrEmpty(ManufacturerName) ? dbNULL : (object)ManufacturerName);
                cmd.Parameters.AddWithValue("@ManufacturerNameEn", string.IsNullOrEmpty(ManufacturerNameEn) ? dbNULL : (object)ManufacturerNameEn);
                cmd.Parameters.AddWithValue("@ConvertedManufacturerName", string.IsNullOrEmpty(ConvertedManufacturerName) ? dbNULL : (object)ConvertedManufacturerName);
                cmd.Parameters.AddWithValue("@ManufacturerImage", string.IsNullOrEmpty(ManufacturerImage) ? dbNULL : (object)ManufacturerImage);
                cmd.Parameters.AddWithValue("@IsAvailable", string.IsNullOrEmpty(IsAvailable) ? dbNULL : (object)IsAvailable);
                cmd.Parameters.AddWithValue("@Priority", string.IsNullOrEmpty(Priority) ? dbNULL : (object)Priority);
                cmd.Parameters.AddWithValue("@ProductID", string.IsNullOrEmpty(ProductID) ? dbNULL : (object)ProductID);
                cmd.Parameters.AddWithValue("@Content", string.IsNullOrEmpty(Content) ? dbNULL : (object)Content);
                cmd.Parameters.AddWithValue("@ContentEn", string.IsNullOrEmpty(ContentEn) ? dbNULL : (object)ContentEn);

                SqlParameter imageNameParam = new SqlParameter("@OutImageName", null);
                SqlParameter errorCodeParam = new SqlParameter("@ErrorCode", null);
                imageNameParam.Size = 100;
                errorCodeParam.Size = 4;
                errorCodeParam.Direction = imageNameParam.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(imageNameParam);
                cmd.Parameters.Add(errorCodeParam);
                scon.Open();
                cmd.ExecuteNonQuery();
                scon.Close();

                if (errorCodeParam.Value.ToString() != "0")
                    throw new Exception("Stored Procedure 'usp_Manufacturer_Insert1' reported the ErrorCode : " + errorCodeParam.Value.ToString());

                return imageNameParam.Value.ToString();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public int ManufacturerUpdate(
            string ManufacturerID,
            string ManufacturerName,
            string ManufacturerNameEn,
            string ConvertedManufacturerName,
            string ManufacturerImage,
            string IsAvailable,
            string Priority,
            string ProductID,
            string Content,
            string ContentEn
        )
        {
            try
            {
                var scon = new SqlConnection(connectionString);
                var cmd = new SqlCommand("usp_Manufacturer_Update1", scon);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ManufacturerID", string.IsNullOrEmpty(ManufacturerID) ? dbNULL : (object)ManufacturerID);
                cmd.Parameters.AddWithValue("@ManufacturerName", string.IsNullOrEmpty(ManufacturerName) ? dbNULL : (object)ManufacturerName);
                cmd.Parameters.AddWithValue("@ManufacturerNameEn", string.IsNullOrEmpty(ManufacturerNameEn) ? dbNULL : (object)ManufacturerNameEn);
                cmd.Parameters.AddWithValue("@ConvertedManufacturerName", string.IsNullOrEmpty(ConvertedManufacturerName) ? dbNULL : (object)ConvertedManufacturerName);
                cmd.Parameters.AddWithValue("@ManufacturerImage", string.IsNullOrEmpty(ManufacturerImage) ? dbNULL : (object)ManufacturerImage);
                cmd.Parameters.AddWithValue("@IsAvailable", string.IsNullOrEmpty(IsAvailable) ? dbNULL : (object)IsAvailable);
                cmd.Parameters.AddWithValue("@Priority", string.IsNullOrEmpty(Priority) ? dbNULL : (object)Priority);
                cmd.Parameters.AddWithValue("@ProductID", string.IsNullOrEmpty(ProductID) ? dbNULL : (object)ProductID);
                cmd.Parameters.AddWithValue("@Content", string.IsNullOrEmpty(Content) ? dbNULL : (object)Content);
                cmd.Parameters.AddWithValue("@ContentEn", string.IsNullOrEmpty(ContentEn) ? dbNULL : (object)ContentEn);

                SqlParameter errorCodeParam = new SqlParameter("@ErrorCode", null);
                errorCodeParam.Size = 4;
                errorCodeParam.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(errorCodeParam);
                scon.Open();
                int success = cmd.ExecuteNonQuery();
                scon.Close();

                if (errorCodeParam.Value.ToString() != "0")
                    throw new Exception("Stored Procedure 'usp_Manufacturer_Update1' reported the ErrorCode : " + errorCodeParam.Value.ToString());

                return success;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public int ManufacturerQuickUpdate(
            string ManufacturerID,
            string IsAvailable,
            string Priority
        )
        {
            try
            {
                var scon = new SqlConnection(connectionString);
                var cmd = new SqlCommand("usp_Manufacturer_QuickUpdate1", scon);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ManufacturerID", string.IsNullOrEmpty(ManufacturerID) ? dbNULL : (object)ManufacturerID);
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
                    throw new Exception("Stored Procedure 'usp_Manufacturer_QuickUpdate1' reported the ErrorCode : " + errorCodeParam.Value.ToString());

                return success;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public int ManufacturerDelete(
            string ManufacturerID
        )
        {
            try
            {
                var scon = new SqlConnection(connectionString);
                var cmd = new SqlCommand("usp_Manufacturer_Delete1", scon);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ManufacturerID", string.IsNullOrEmpty(ManufacturerID) ? dbNULL : (object)ManufacturerID);
                SqlParameter errorCodeParam = new SqlParameter("@ErrorCode", null);
                errorCodeParam.Size = 4;
                errorCodeParam.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(errorCodeParam);
                scon.Open();
                int success = cmd.ExecuteNonQuery();
                scon.Close();

                if (errorCodeParam.Value.ToString() != "0")
                    throw new Exception("Stored Procedure 'usp_Manufacturer_Delete1' reported the ErrorCode : " + errorCodeParam.Value.ToString());

                return success;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public DataTable ManufacturerSelectAll(
            string ManufacturerName,
            string IsAvailable,
            string Priority,
            string SortByPriority,
            string ProductID
        )
        {
            try
            {
                var dt = new DataTable();
                var scon = new SqlConnection(connectionString);
                var cmd = new SqlCommand("usp_Manufacturer_SelectAll1", scon);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ManufacturerName", string.IsNullOrEmpty(ManufacturerName) ? dbNULL : (object)ManufacturerName);
                cmd.Parameters.AddWithValue("@IsAvailable", string.IsNullOrEmpty(IsAvailable) ? dbNULL : (object)IsAvailable);
                cmd.Parameters.AddWithValue("@Priority", string.IsNullOrEmpty(Priority) ? dbNULL : (object)Priority);
                cmd.Parameters.AddWithValue("@SortByPriority", string.IsNullOrEmpty(SortByPriority) ? dbNULL : (object)SortByPriority);
                cmd.Parameters.AddWithValue("@ProductID", string.IsNullOrEmpty(ProductID) ? dbNULL : (object)ProductID);

                SqlParameter errorCodeParam = new SqlParameter("@ErrorCode", null);
                errorCodeParam.Size = 4;
                errorCodeParam.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(errorCodeParam);
                var sda = new SqlDataAdapter(cmd);
                sda.Fill(dt);

                if (errorCodeParam.Value.ToString() != "0")
                    throw new Exception("Stored Procedure 'usp_Manufacturer_SelectAll1' reported the ErrorCode : " + errorCodeParam.Value.ToString());

                return dt;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public DataTable ManufacturerSelectOne(
            string ManufacturerID
        )
        {
            try
            {
                var dt = new DataTable();
                var scon = new SqlConnection(connectionString);
                var cmd = new SqlCommand("usp_Manufacturer_SelectOne1", scon);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ManufacturerID", string.IsNullOrEmpty(ManufacturerID) ? dbNULL : (object)ManufacturerID);
                SqlParameter errorCodeParam = new SqlParameter("@ErrorCode", null);
                errorCodeParam.Size = 4;
                errorCodeParam.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(errorCodeParam);
                var sda = new SqlDataAdapter(cmd);
                sda.Fill(dt);

                if (errorCodeParam.Value.ToString() != "0")
                    throw new Exception("Stored Procedure 'usp_Manufacturer_SelectOne1' reported the ErrorCode : " + errorCodeParam.Value.ToString());

                return dt;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public int ManufacturerImageDelete(
            string ManufacturerID
        )
        {
            try
            {
                var scon = new SqlConnection(connectionString);
                var cmd = new SqlCommand("usp_ManufacturerImage_Delete", scon);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ManufacturerID", string.IsNullOrEmpty(ManufacturerID) ? dbNULL : (object)ManufacturerID);
                SqlParameter errorCodeParam = new SqlParameter("@ErrorCode", null);
                errorCodeParam.Size = 4;
                errorCodeParam.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(errorCodeParam);
                scon.Open();
                int success = cmd.ExecuteNonQuery();
                scon.Close();

                if (errorCodeParam.Value.ToString() != "0")
                    throw new Exception("Stored Procedure 'usp_ManufacturerImage_Delete' reported the ErrorCode : " + errorCodeParam.Value.ToString());

                return success;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}

