using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace TLLib
{
    public class Download
    {
        string connectionString = Common.ConnectionString;
        DBNull dbNULL = DBNull.Value;

        public int DownloadInsert(
            string DownloadName,
            string DownloadNameEn,
            string ConvertedDownloadName,
            string ImageName,
            string FilePath,
            string DownloadCategoryID,
            string IsAvailable,
            string Priority
        )
        {
            try
            {
                var scon = new SqlConnection(connectionString);
                var cmd = new SqlCommand("usp_Download_Insert", scon);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@DownloadName", string.IsNullOrEmpty(DownloadName) ? dbNULL : (object)DownloadName);
                cmd.Parameters.AddWithValue("@DownloadNameEn", string.IsNullOrEmpty(DownloadNameEn) ? dbNULL : (object)DownloadNameEn);
                cmd.Parameters.AddWithValue("@ConvertedDownloadName", string.IsNullOrEmpty(ConvertedDownloadName) ? dbNULL : (object)ConvertedDownloadName);
                cmd.Parameters.AddWithValue("@ImageName", string.IsNullOrEmpty(ImageName) ? dbNULL : (object)ImageName);
                cmd.Parameters.AddWithValue("@FilePath", string.IsNullOrEmpty(FilePath) ? dbNULL : (object)FilePath);
                cmd.Parameters.AddWithValue("@DownloadCategoryID", string.IsNullOrEmpty(DownloadCategoryID) ? dbNULL : (object)DownloadCategoryID);
                cmd.Parameters.AddWithValue("@IsAvailable", string.IsNullOrEmpty(IsAvailable) ? dbNULL : (object)IsAvailable);
                cmd.Parameters.AddWithValue("@Priority", string.IsNullOrEmpty(Priority) ? dbNULL : (object)Priority);

                SqlParameter DownloadIDParam = new SqlParameter("@OutDownloadID", null);
                SqlParameter errorCodeParam = new SqlParameter("@ErrorCode", null);
                errorCodeParam.Size = DownloadIDParam.Size = 4;
                errorCodeParam.Direction = DownloadIDParam.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(DownloadIDParam);
                cmd.Parameters.Add(errorCodeParam);
                scon.Open();
                cmd.ExecuteNonQuery();
                scon.Close();

                if (errorCodeParam.Value.ToString() != "0")
                    throw new Exception("Stored Procedure 'usp_Download_Insert' reported the ErrorCode : " + errorCodeParam.Value.ToString());

                return Convert.ToInt32(DownloadIDParam.Value);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public int DownloadUpdate(
            string DownloadID,
            string DownloadName,
            string DownloadNameEn,
            string ConvertedDownloadName,
            string ImageName,
            string FilePath,
            string DownloadCategoryID,
            string IsAvailable,
            string Priority
        )
        {
            try
            {
                var scon = new SqlConnection(connectionString);
                var cmd = new SqlCommand("usp_Download_Update", scon);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@DownloadID", string.IsNullOrEmpty(DownloadID) ? dbNULL : (object)DownloadID);
                cmd.Parameters.AddWithValue("@DownloadName", string.IsNullOrEmpty(DownloadName) ? dbNULL : (object)DownloadName);
                cmd.Parameters.AddWithValue("@DownloadNameEn", string.IsNullOrEmpty(DownloadNameEn) ? dbNULL : (object)DownloadNameEn);
                cmd.Parameters.AddWithValue("@ConvertedDownloadName", string.IsNullOrEmpty(ConvertedDownloadName) ? dbNULL : (object)ConvertedDownloadName);
                cmd.Parameters.AddWithValue("@ImageName", string.IsNullOrEmpty(ImageName) ? dbNULL : (object)ImageName);
                cmd.Parameters.AddWithValue("@FilePath", string.IsNullOrEmpty(FilePath) ? dbNULL : (object)FilePath);
                cmd.Parameters.AddWithValue("@DownloadCategoryID", string.IsNullOrEmpty(DownloadCategoryID) ? dbNULL : (object)DownloadCategoryID);
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
                    throw new Exception("Stored Procedure 'usp_Download_Update' reported the ErrorCode : " + errorCodeParam.Value.ToString());

                return success;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public int DownloadQuickUpdate(
            string DownloadID,
            string IsAvailable,
            string Priority
        )
        {
            try
            {
                var scon = new SqlConnection(connectionString);
                var cmd = new SqlCommand("usp_Download_QuickUpdate", scon);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@DownloadID", string.IsNullOrEmpty(DownloadID) ? dbNULL : (object)DownloadID);
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
                    throw new Exception("Stored Procedure 'usp_Download_QuickUpdate' reported the ErrorCode : " + errorCodeParam.Value.ToString());

                return success;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public int DownloadDelete(
            string DownloadID
        )
        {
            try
            {
                var scon = new SqlConnection(connectionString);
                var cmd = new SqlCommand("usp_Download_Delete", scon);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@DownloadID", string.IsNullOrEmpty(DownloadID) ? dbNULL : (object)DownloadID);
                SqlParameter errorCodeParam = new SqlParameter("@ErrorCode", null);
                errorCodeParam.Size = 4;
                errorCodeParam.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(errorCodeParam);
                scon.Open();
                int success = cmd.ExecuteNonQuery();
                scon.Close();

                if (errorCodeParam.Value.ToString() != "0")
                    throw new Exception("Stored Procedure 'usp_Download_Delete' reported the ErrorCode : " + errorCodeParam.Value.ToString());

                return success;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public DataTable DownloadSelectAll(
            string Keyword,
            string DownloadName,
            string DownloadCategoryID,
            string IsAvailable,
            string Priority,
            string SortByPriority
        )
        {
            try
            {
                var dt = new DataTable();
                var scon = new SqlConnection(connectionString);
                var cmd = new SqlCommand("usp_Download_SelectAll", scon);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Keyword", string.IsNullOrEmpty(Keyword) ? dbNULL : (object)Keyword);
                cmd.Parameters.AddWithValue("@DownloadName", string.IsNullOrEmpty(DownloadName) ? dbNULL : (object)DownloadName);
                cmd.Parameters.AddWithValue("@DownloadCategoryID", string.IsNullOrEmpty(DownloadCategoryID) ? dbNULL : (object)DownloadCategoryID);
                cmd.Parameters.AddWithValue("@IsAvailable", string.IsNullOrEmpty(IsAvailable) ? dbNULL : (object)IsAvailable);
                cmd.Parameters.AddWithValue("@Priority", string.IsNullOrEmpty(Priority) ? dbNULL : (object)Priority);
                cmd.Parameters.AddWithValue("@SortByPriority", string.IsNullOrEmpty(SortByPriority) ? dbNULL : (object)SortByPriority);

                SqlParameter errorCodeParam = new SqlParameter("@ErrorCode", null);
                errorCodeParam.Size = 4;
                errorCodeParam.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(errorCodeParam);
                var sda = new SqlDataAdapter(cmd);
                sda.Fill(dt);

                if (errorCodeParam.Value.ToString() != "0")
                    throw new Exception("Stored Procedure 'usp_Download_SelectAll' reported the ErrorCode : " + errorCodeParam.Value.ToString());

                return dt;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public DataTable DownloadSelectOne(
            string DownloadID
        )
        {
            try
            {
                var dt = new DataTable();
                var scon = new SqlConnection(connectionString);
                var cmd = new SqlCommand("usp_Download_SelectOne", scon);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@DownloadID", string.IsNullOrEmpty(DownloadID) ? dbNULL : (object)DownloadID);
                SqlParameter errorCodeParam = new SqlParameter("@ErrorCode", null);
                errorCodeParam.Size = 4;
                errorCodeParam.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(errorCodeParam);
                var sda = new SqlDataAdapter(cmd);
                sda.Fill(dt);

                if (errorCodeParam.Value.ToString() != "0")
                    throw new Exception("Stored Procedure 'usp_Download_SelectOne' reported the ErrorCode : " + errorCodeParam.Value.ToString());

                return dt;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public string DownloadSelectMaxID()
        {
            try
            {
                var dt = new DataTable();
                var scon = new SqlConnection(connectionString);
                var cmd = new SqlCommand("usp_Download_SelectMaxID", scon);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter DownloadIDParam = new SqlParameter("@DownloadID", null);
                SqlParameter errorCodeParam = new SqlParameter("@ErrorCode", null);
                errorCodeParam.Size = DownloadIDParam.Size = 4;
                errorCodeParam.Direction = DownloadIDParam.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(DownloadIDParam);
                cmd.Parameters.Add(errorCodeParam);
                var sda = new SqlDataAdapter(cmd);
                sda.Fill(dt);

                if (errorCodeParam.Value.ToString() != "0")
                    throw new Exception("Stored Procedure 'usp_Download_SelectMaxID' reported the ErrorCode : " + errorCodeParam.Value.ToString());

                return DownloadIDParam.Value.ToString();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public int DownloadImageDelete(
            string DownloadID
        )
        {
            try
            {
                var scon = new SqlConnection(connectionString);
                var cmd = new SqlCommand("usp_DownloadImage_Delete", scon);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@DownloadID", string.IsNullOrEmpty(DownloadID) ? dbNULL : (object)DownloadID);
                SqlParameter errorCodeParam = new SqlParameter("@ErrorCode", null);
                errorCodeParam.Size = 4;
                errorCodeParam.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(errorCodeParam);
                scon.Open();
                int success = cmd.ExecuteNonQuery();
                scon.Close();

                if (errorCodeParam.Value.ToString() != "0")
                    throw new Exception("Stored Procedure 'usp_DownloadImage_Delete' reported the ErrorCode : " + errorCodeParam.Value.ToString());

                return success;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}

