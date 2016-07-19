using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace TLLib
{
    public class Video
    {
        string connectionString = Common.ConnectionString;
        DBNull dbNULL = DBNull.Value;

        public int VideoInsert(
            string Title,
            string Description,
            string TitleEn,
            string DescriptionEn,
            string ConvertedTitle,
            string ImagePath,
            string VideoPath,
            string GLobalEmbedScript,
            string VideoCategoryID,
            string IsAvailable,
            string Priority
        )
        {
            try
            {
                var scon = new SqlConnection(connectionString);
                var cmd = new SqlCommand("usp_Video_Insert", scon);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Title", string.IsNullOrEmpty(Title) ? dbNULL : (object)Title);
                cmd.Parameters.AddWithValue("@Description", string.IsNullOrEmpty(Description) ? dbNULL : (object)Description);
                cmd.Parameters.AddWithValue("@TitleEn", string.IsNullOrEmpty(TitleEn) ? dbNULL : (object)TitleEn);
                cmd.Parameters.AddWithValue("@DescriptionEn", string.IsNullOrEmpty(DescriptionEn) ? dbNULL : (object)DescriptionEn);
                cmd.Parameters.AddWithValue("@ConvertedTitle", string.IsNullOrEmpty(ConvertedTitle) ? dbNULL : (object)ConvertedTitle);
                cmd.Parameters.AddWithValue("@ImagePath", string.IsNullOrEmpty(ImagePath) ? dbNULL : (object)ImagePath);
                cmd.Parameters.AddWithValue("@VideoPath", string.IsNullOrEmpty(VideoPath) ? dbNULL : (object)VideoPath);
                cmd.Parameters.AddWithValue("@GLobalEmbedScript", string.IsNullOrEmpty(GLobalEmbedScript) ? dbNULL : (object)GLobalEmbedScript);
                cmd.Parameters.AddWithValue("@VideoCategoryID", string.IsNullOrEmpty(VideoCategoryID) ? dbNULL : (object)VideoCategoryID);
                cmd.Parameters.AddWithValue("@IsAvailable", string.IsNullOrEmpty(IsAvailable) ? dbNULL : (object)IsAvailable);
                cmd.Parameters.AddWithValue("@Priority", string.IsNullOrEmpty(Priority) ? dbNULL : (object)Priority);
                
                SqlParameter videoIDParam = new SqlParameter("@OutVideoID", null);
                SqlParameter errorCodeParam = new SqlParameter("@ErrorCode", null);
                errorCodeParam.Size = videoIDParam.Size = 4;
                errorCodeParam.Direction = videoIDParam.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(videoIDParam);
                cmd.Parameters.Add(errorCodeParam);
                scon.Open();
                cmd.ExecuteNonQuery();
                scon.Close();

                if (errorCodeParam.Value.ToString() != "0")
                    throw new Exception("Stored Procedure 'usp_Video_Insert' reported the ErrorCode : " + errorCodeParam.Value.ToString());

                return Convert.ToInt32(videoIDParam.Value);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public int VideoUpdate(
            string VideoID,
            string Title,
            string Description,
            string TitleEn,
            string DescriptionEn,
            string ConvertedTitle,
            string ImagePath,
            string VideoPath,
            string GLobalEmbedScript,
            string VideoCategoryID,
            string IsAvailable,
            string Priority
        )
        {
            try
            {
                var scon = new SqlConnection(connectionString);
                var cmd = new SqlCommand("usp_Video_Update", scon);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@VideoID", string.IsNullOrEmpty(VideoID) ? dbNULL : (object)VideoID);
                cmd.Parameters.AddWithValue("@Title", string.IsNullOrEmpty(Title) ? dbNULL : (object)Title);
                cmd.Parameters.AddWithValue("@Description", string.IsNullOrEmpty(Description) ? dbNULL : (object)Description);
                cmd.Parameters.AddWithValue("@TitleEn", string.IsNullOrEmpty(TitleEn) ? dbNULL : (object)TitleEn);
                cmd.Parameters.AddWithValue("@DescriptionEn", string.IsNullOrEmpty(DescriptionEn) ? dbNULL : (object)DescriptionEn);
                cmd.Parameters.AddWithValue("@ConvertedTitle", string.IsNullOrEmpty(ConvertedTitle) ? dbNULL : (object)ConvertedTitle);
                cmd.Parameters.AddWithValue("@ImagePath", string.IsNullOrEmpty(ImagePath) ? dbNULL : (object)ImagePath);
                cmd.Parameters.AddWithValue("@VideoPath", string.IsNullOrEmpty(VideoPath) ? dbNULL : (object)VideoPath);
                cmd.Parameters.AddWithValue("@GLobalEmbedScript", string.IsNullOrEmpty(GLobalEmbedScript) ? dbNULL : (object)GLobalEmbedScript);
                cmd.Parameters.AddWithValue("@VideoCategoryID", string.IsNullOrEmpty(VideoCategoryID) ? dbNULL : (object)VideoCategoryID);
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
                    throw new Exception("Stored Procedure 'usp_Video_Update' reported the ErrorCode : " + errorCodeParam.Value.ToString());

                return success;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public int VideoQuickUpdate(
            string VideoID,
            string IsAvailable,
            string Priority
        )
        {
            try
            {
                var scon = new SqlConnection(connectionString);
                var cmd = new SqlCommand("usp_Video_QuickUpdate", scon);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@VideoID", string.IsNullOrEmpty(VideoID) ? dbNULL : (object)VideoID);
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
                    throw new Exception("Stored Procedure 'usp_Video_QuickUpdate' reported the ErrorCode : " + errorCodeParam.Value.ToString());

                return success;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public int VideoDelete(
            string VideoID
        )
        {
            try
            {
                var scon = new SqlConnection(connectionString);
                var cmd = new SqlCommand("usp_Video_Delete", scon);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@VideoID", string.IsNullOrEmpty(VideoID) ? dbNULL : (object)VideoID);
                SqlParameter errorCodeParam = new SqlParameter("@ErrorCode", null);
                errorCodeParam.Size = 4;
                errorCodeParam.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(errorCodeParam);
                scon.Open();
                int success = cmd.ExecuteNonQuery();
                scon.Close();

                if (errorCodeParam.Value.ToString() != "0")
                    throw new Exception("Stored Procedure 'usp_Video_Delete' reported the ErrorCode : " + errorCodeParam.Value.ToString());

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

        public DataTable VideoSelectAll(
            string Title,
            string Description,
            string VideoCategoryID,
            string IsAvailable,
            string Priority,
            string SortByPriority
        )
        {
            try
            {
                var dt = new DataTable();
                var scon = new SqlConnection(connectionString);
                var cmd = new SqlCommand("usp_Video_SelectAll", scon);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Title", string.IsNullOrEmpty(Title) ? dbNULL : (object)Title);
                cmd.Parameters.AddWithValue("@Description", string.IsNullOrEmpty(Description) ? dbNULL : (object)Description);
                cmd.Parameters.AddWithValue("@VideoCategoryID", string.IsNullOrEmpty(VideoCategoryID) ? dbNULL : (object)VideoCategoryID);
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
                    throw new Exception("Stored Procedure 'usp_Video_SelectAll' reported the ErrorCode : " + errorCodeParam.Value.ToString());

                return dt;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public DataTable VideoSelectOne(
            string VideoID
        )
        {
            try
            {
                var dt = new DataTable();
                var scon = new SqlConnection(connectionString);
                var cmd = new SqlCommand("usp_Video_SelectOne", scon);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@VideoID", string.IsNullOrEmpty(VideoID) ? dbNULL : (object)VideoID);
                SqlParameter errorCodeParam = new SqlParameter("@ErrorCode", null);
                errorCodeParam.Size = 4;
                errorCodeParam.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(errorCodeParam);
                var sda = new SqlDataAdapter(cmd);
                sda.Fill(dt);

                if (errorCodeParam.Value.ToString() != "0")
                    throw new Exception("Stored Procedure 'usp_Video_SelectOne' reported the ErrorCode : " + errorCodeParam.Value.ToString());

                return dt;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public string VideoSelectMaxID()
        {
            try
            {
                var dt = new DataTable();
                var scon = new SqlConnection(connectionString);
                var cmd = new SqlCommand("usp_Video_SelectMaxID", scon);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter videoIDParam = new SqlParameter("@VideoID", null);
                SqlParameter errorCodeParam = new SqlParameter("@ErrorCode", null);
                errorCodeParam.Size = videoIDParam.Size = 4;
                errorCodeParam.Direction = videoIDParam.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(videoIDParam);
                cmd.Parameters.Add(errorCodeParam);
                var sda = new SqlDataAdapter(cmd);
                sda.Fill(dt);

                if (errorCodeParam.Value.ToString() != "0")
                    throw new Exception("Stored Procedure 'usp_Video_SelectMaxID' reported the ErrorCode : " + errorCodeParam.Value.ToString());

                return videoIDParam.Value.ToString();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public int VideoImageDelete(
            string VideoID
        )
        {
            try
            {
                var scon = new SqlConnection(connectionString);
                var cmd = new SqlCommand("usp_VideoImage_Delete", scon);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@VideoID", string.IsNullOrEmpty(VideoID) ? dbNULL : (object)VideoID);
                SqlParameter errorCodeParam = new SqlParameter("@ErrorCode", null);
                errorCodeParam.Size = 4;
                errorCodeParam.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(errorCodeParam);
                scon.Open();
                int success = cmd.ExecuteNonQuery();
                scon.Close();

                if (errorCodeParam.Value.ToString() != "0")
                    throw new Exception("Stored Procedure 'usp_VideoImage_Delete' reported the ErrorCode : " + errorCodeParam.Value.ToString());

                return success;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}

