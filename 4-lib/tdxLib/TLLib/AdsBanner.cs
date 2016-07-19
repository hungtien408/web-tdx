using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace TLLib
{
    public class AdsBanner
    {
        string connectionString = Common.ConnectionString;
        DBNull dbNULL = DBNull.Value;

        public string AdsBannerInsert(
            string FileName,
            string ConvertedAdsBannerName,
            string AdsCategoryID,
            string CompanyName,
            string Website,
            string FromDate,
            string ToDate,
            string Priority,
            string IsAvailable,
            string Ratio
        )
        {
            try
            {
                var scon = new SqlConnection(connectionString);
                var cmd = new SqlCommand("usp_AdsBanner_Insert", scon);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@FileName", string.IsNullOrEmpty(FileName) ? dbNULL : (object)FileName);
                cmd.Parameters.AddWithValue("@ConvertedAdsBannerName", string.IsNullOrEmpty(ConvertedAdsBannerName) ? dbNULL : (object)ConvertedAdsBannerName);
                cmd.Parameters.AddWithValue("@AdsCategoryID", string.IsNullOrEmpty(AdsCategoryID) ? dbNULL : (object)AdsCategoryID);
                cmd.Parameters.AddWithValue("@CompanyName", string.IsNullOrEmpty(CompanyName) ? dbNULL : (object)CompanyName);
                cmd.Parameters.AddWithValue("@Website", string.IsNullOrEmpty(Website) ? dbNULL : (object)(Website.ToLower().StartsWith("http://") ? Website.ToLower() : "http://" + Website.ToLower()));
                cmd.Parameters.AddWithValue("@FromDate", string.IsNullOrEmpty(FromDate) ? dbNULL : (object)FromDate);
                cmd.Parameters.AddWithValue("@ToDate", string.IsNullOrEmpty(ToDate) ? dbNULL : (object)ToDate);
                cmd.Parameters.AddWithValue("@Priority", string.IsNullOrEmpty(Priority) ? dbNULL : (object)Priority);
                cmd.Parameters.AddWithValue("@IsAvailable", string.IsNullOrEmpty(IsAvailable) ? dbNULL : (object)IsAvailable);
                cmd.Parameters.AddWithValue("@Ratio", string.IsNullOrEmpty(Ratio) ? dbNULL : (object)Ratio);

                SqlParameter imageNameParam = new SqlParameter("@OutFileName", null);
                SqlParameter errorCodeParam = new SqlParameter("@ErrorCode", null);
                imageNameParam.Size = 100;
                errorCodeParam.Size = 4;
                errorCodeParam.Direction = imageNameParam.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(imageNameParam);
                cmd.Parameters.Add(errorCodeParam);
                scon.Open();
                int success = cmd.ExecuteNonQuery();
                scon.Close();

                if (errorCodeParam.Value.ToString() != "0")
                    throw new Exception("Stored Procedure 'usp_AdsBanner_Insert' reported the ErrorCode : " + errorCodeParam.Value.ToString());

                return imageNameParam.Value.ToString();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public int AdsBannerUpdate(
            string AdsBannerID,
            string FileName,
            string ConvertedAdsBannerName,
            string AdsCategoryID,
            string CompanyName,
            string Website,
            string FromDate,
            string ToDate,
            string Priority,
            string IsAvailable,
            string Ratio
        )
        {
            try
            {
                var scon = new SqlConnection(connectionString);
                var cmd = new SqlCommand("usp_AdsBanner_Update", scon);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@AdsBannerID", string.IsNullOrEmpty(AdsBannerID) ? dbNULL : (object)AdsBannerID);
                cmd.Parameters.AddWithValue("@FileName", string.IsNullOrEmpty(FileName) ? dbNULL : (object)FileName);
                cmd.Parameters.AddWithValue("@ConvertedAdsBannerName", string.IsNullOrEmpty(ConvertedAdsBannerName) ? dbNULL : (object)ConvertedAdsBannerName);
                cmd.Parameters.AddWithValue("@AdsCategoryID", string.IsNullOrEmpty(AdsCategoryID) ? dbNULL : (object)AdsCategoryID);
                cmd.Parameters.AddWithValue("@CompanyName", string.IsNullOrEmpty(CompanyName) ? dbNULL : (object)CompanyName);
                cmd.Parameters.AddWithValue("@Website", string.IsNullOrEmpty(Website) ? dbNULL : (object)(Website.ToLower().StartsWith("http://") ? Website.ToLower() : "http://" + Website.ToLower()));
                cmd.Parameters.AddWithValue("@FromDate", string.IsNullOrEmpty(FromDate) ? dbNULL : (object)FromDate);
                cmd.Parameters.AddWithValue("@ToDate", string.IsNullOrEmpty(ToDate) ? dbNULL : (object)ToDate);
                cmd.Parameters.AddWithValue("@Priority", string.IsNullOrEmpty(Priority) ? dbNULL : (object)Priority);
                cmd.Parameters.AddWithValue("@IsAvailable", string.IsNullOrEmpty(IsAvailable) ? dbNULL : (object)IsAvailable);
                cmd.Parameters.AddWithValue("@Ratio", string.IsNullOrEmpty(Ratio) ? dbNULL : (object)Ratio);

                SqlParameter errorCodeParam = new SqlParameter("@ErrorCode", null);
                errorCodeParam.Size = 4;
                errorCodeParam.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(errorCodeParam);
                scon.Open();
                int success = cmd.ExecuteNonQuery();
                scon.Close();

                if (errorCodeParam.Value.ToString() != "0")
                    throw new Exception("Stored Procedure 'usp_AdsBanner_Update' reported the ErrorCode : " + errorCodeParam.Value.ToString());

                return success;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public int AdsBannerQuickUpdate(
            string AdsBannerID,
            string Priority,
            string IsAvailable
        )
        {
            try
            {
                var scon = new SqlConnection(connectionString);
                var cmd = new SqlCommand("usp_AdsBanner_QuickUpdate", scon);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@AdsBannerID", string.IsNullOrEmpty(AdsBannerID) ? dbNULL : (object)AdsBannerID);
                cmd.Parameters.AddWithValue("@Priority", string.IsNullOrEmpty(Priority) ? dbNULL : (object)Priority);
                cmd.Parameters.AddWithValue("@IsAvailable", string.IsNullOrEmpty(IsAvailable) ? dbNULL : (object)IsAvailable);

                SqlParameter errorCodeParam = new SqlParameter("@ErrorCode", null);
                errorCodeParam.Size = 4;
                errorCodeParam.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(errorCodeParam);
                scon.Open();
                int success = cmd.ExecuteNonQuery();
                scon.Close();

                if (errorCodeParam.Value.ToString() != "0")
                    throw new Exception("Stored Procedure 'usp_AdsBanner_QuickUpdate' reported the ErrorCode : " + errorCodeParam.Value.ToString());

                return success;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public int AdsBannerDelete(
            string AdsBannerID
        )
        {
            try
            {
                var scon = new SqlConnection(connectionString);
                var cmd = new SqlCommand("usp_AdsBanner_Delete", scon);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@AdsBannerID", string.IsNullOrEmpty(AdsBannerID) ? dbNULL : (object)AdsBannerID);
                SqlParameter errorCodeParam = new SqlParameter("@ErrorCode", null);
                errorCodeParam.Size = 4;
                errorCodeParam.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(errorCodeParam);
                scon.Open();
                int success = cmd.ExecuteNonQuery();
                scon.Close();

                if (errorCodeParam.Value.ToString() != "0")
                    throw new Exception("Stored Procedure 'usp_AdsBanner_Delete' reported the ErrorCode : " + errorCodeParam.Value.ToString());

                return success;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public DataTable AdsBannerSelectAll(
            string StartRowIndex,
            string EndRowIndex,
            string AdsCategoryID,
            string CompanyName,
            string Website,
            string FromDate,
            string ToDate,
            string IsAvailable,
            string Priority,
            string SortByPriority
        )
        {
            try
            {
                var dt = new DataTable();
                var scon = new SqlConnection(connectionString);
                var cmd = new SqlCommand("usp_AdsBanner_SelectAll", scon);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@StartRowIndex", string.IsNullOrEmpty(StartRowIndex) ? dbNULL : (object)StartRowIndex);
                cmd.Parameters.AddWithValue("@EndRowIndex", string.IsNullOrEmpty(EndRowIndex) ? dbNULL : (object)EndRowIndex);
                cmd.Parameters.AddWithValue("@AdsCategoryID", string.IsNullOrEmpty(AdsCategoryID) ? dbNULL : (object)AdsCategoryID);
                cmd.Parameters.AddWithValue("@CompanyName", string.IsNullOrEmpty(CompanyName) ? dbNULL : (object)CompanyName.Trim());
                cmd.Parameters.AddWithValue("@Website", string.IsNullOrEmpty(Website) ? dbNULL : (object)Website);
                cmd.Parameters.AddWithValue("@FromDate", string.IsNullOrEmpty(FromDate) ? dbNULL : (object)FromDate);
                cmd.Parameters.AddWithValue("@ToDate", string.IsNullOrEmpty(ToDate) ? dbNULL : (object)ToDate);
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
                    throw new Exception("Stored Procedure 'usp_AdsBanner_SelectAll' reported the ErrorCode : " + errorCodeParam.Value.ToString());

                return dt;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public DataTable AdsBannerSelectOne(
            string AdsBannerID
        )
        {
            try
            {
                var dt = new DataTable();
                var scon = new SqlConnection(connectionString);
                var cmd = new SqlCommand("usp_AdsBanner_SelectOne", scon);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@AdsBannerID", string.IsNullOrEmpty(AdsBannerID) ? dbNULL : (object)AdsBannerID);
                SqlParameter errorCodeParam = new SqlParameter("@ErrorCode", null);
                errorCodeParam.Size = 4;
                errorCodeParam.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(errorCodeParam);
                var sda = new SqlDataAdapter(cmd);
                sda.Fill(dt);

                if (errorCodeParam.Value.ToString() != "0")
                    throw new Exception("Stored Procedure 'usp_AdsBanner_SelectOne' reported the ErrorCode : " + errorCodeParam.Value.ToString());

                return dt;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public int AdsBannerImagesDelete(
            string AdsBannerID
        )
        {
            try
            {
                var scon = new SqlConnection(connectionString);
                var cmd = new SqlCommand("usp_AdsBannerImages_Delete", scon);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@AdsBannerID", string.IsNullOrEmpty(AdsBannerID) ? dbNULL : (object)AdsBannerID);
                SqlParameter errorCodeParam = new SqlParameter("@ErrorCode", null);
                errorCodeParam.Size = 4;
                errorCodeParam.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(errorCodeParam);
                scon.Open();
                int success = cmd.ExecuteNonQuery();
                scon.Close();

                if (errorCodeParam.Value.ToString() != "0")
                    throw new Exception("Stored Procedure 'usp_AdsBannerImages_Delete' reported the ErrorCode : " + errorCodeParam.Value.ToString());

                return success;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}

