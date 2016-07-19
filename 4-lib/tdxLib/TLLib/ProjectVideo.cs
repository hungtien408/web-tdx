using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace TLLib
{
    public class ProjectVideo
    {
        string connectionString = Common.ConnectionString;
        DBNull dbNULL = DBNull.Value;

        public int ProjectVideoInsert(
            string Title,
            string Description,
            string TitleEn,
            string DescriptionEn,
            string ConvertedTitle,
            string ImagePath,
            string ProjectVideoPath,
            string ProjectID,
            string IsAvailable,
            string Priority
        )
        {
            try
            {
                var scon = new SqlConnection(connectionString);
                var cmd = new SqlCommand("usp_ProjectVideo_Insert", scon);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Title", string.IsNullOrEmpty(Title) ? dbNULL : (object)Title);
                cmd.Parameters.AddWithValue("@Description", string.IsNullOrEmpty(Description) ? dbNULL : (object)Description);
                cmd.Parameters.AddWithValue("@TitleEn", string.IsNullOrEmpty(TitleEn) ? dbNULL : (object)TitleEn);
                cmd.Parameters.AddWithValue("@DescriptionEn", string.IsNullOrEmpty(DescriptionEn) ? dbNULL : (object)DescriptionEn);
                cmd.Parameters.AddWithValue("@ConvertedTitle", string.IsNullOrEmpty(ConvertedTitle) ? dbNULL : (object)ConvertedTitle);
                cmd.Parameters.AddWithValue("@ImagePath", string.IsNullOrEmpty(ImagePath) ? dbNULL : (object)ImagePath);
                cmd.Parameters.AddWithValue("@ProjectVideoPath", string.IsNullOrEmpty(ProjectVideoPath) ? dbNULL : (object)ProjectVideoPath);
                cmd.Parameters.AddWithValue("@ProjectID", string.IsNullOrEmpty(ProjectID) ? dbNULL : (object)ProjectID);
                cmd.Parameters.AddWithValue("@IsAvailable", string.IsNullOrEmpty(IsAvailable) ? dbNULL : (object)IsAvailable);
                cmd.Parameters.AddWithValue("@Priority", string.IsNullOrEmpty(Priority) ? dbNULL : (object)Priority);

                SqlParameter ProjectVideoIDParam = new SqlParameter("@OutProjectVideoID", null);
                SqlParameter errorCodeParam = new SqlParameter("@ErrorCode", null);
                errorCodeParam.Size = ProjectVideoIDParam.Size = 4;
                errorCodeParam.Direction = ProjectVideoIDParam.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(ProjectVideoIDParam);
                cmd.Parameters.Add(errorCodeParam);
                scon.Open();
                cmd.ExecuteNonQuery();
                scon.Close();

                if (errorCodeParam.Value.ToString() != "0")
                    throw new Exception("Stored Procedure 'usp_ProjectVideo_Insert' reported the ErrorCode : " + errorCodeParam.Value.ToString());

                return Convert.ToInt32(ProjectVideoIDParam.Value);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public int ProjectVideoUpdate(
            string ProjectVideoID,
            string Title,
            string Description,
            string TitleEn,
            string DescriptionEn,
            string ConvertedTitle,
            string ImagePath,
            string ProjectVideoPath,
            string ProjectID,
            string IsAvailable,
            string Priority
        )
        {
            try
            {
                var scon = new SqlConnection(connectionString);
                var cmd = new SqlCommand("usp_ProjectVideo_Update", scon);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ProjectVideoID", string.IsNullOrEmpty(ProjectVideoID) ? dbNULL : (object)ProjectVideoID);
                cmd.Parameters.AddWithValue("@Title", string.IsNullOrEmpty(Title) ? dbNULL : (object)Title);
                cmd.Parameters.AddWithValue("@Description", string.IsNullOrEmpty(Description) ? dbNULL : (object)Description);
                cmd.Parameters.AddWithValue("@TitleEn", string.IsNullOrEmpty(TitleEn) ? dbNULL : (object)TitleEn);
                cmd.Parameters.AddWithValue("@DescriptionEn", string.IsNullOrEmpty(DescriptionEn) ? dbNULL : (object)DescriptionEn);
                cmd.Parameters.AddWithValue("@ConvertedTitle", string.IsNullOrEmpty(ConvertedTitle) ? dbNULL : (object)ConvertedTitle);
                cmd.Parameters.AddWithValue("@ImagePath", string.IsNullOrEmpty(ImagePath) ? dbNULL : (object)ImagePath);
                cmd.Parameters.AddWithValue("@ProjectVideoPath", string.IsNullOrEmpty(ProjectVideoPath) ? dbNULL : (object)ProjectVideoPath);
                cmd.Parameters.AddWithValue("@ProjectID", string.IsNullOrEmpty(ProjectID) ? dbNULL : (object)ProjectID);
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
                    throw new Exception("Stored Procedure 'usp_ProjectVideo_Update' reported the ErrorCode : " + errorCodeParam.Value.ToString());

                return success;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public int ProjectVideoQuickUpdate(
            string ProjectVideoID,
            string IsAvailable,
            string Priority
        )
        {
            try
            {
                var scon = new SqlConnection(connectionString);
                var cmd = new SqlCommand("usp_ProjectVideo_QuickUpdate", scon);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ProjectVideoID", string.IsNullOrEmpty(ProjectVideoID) ? dbNULL : (object)ProjectVideoID);
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
                    throw new Exception("Stored Procedure 'usp_ProjectVideo_QuickUpdate' reported the ErrorCode : " + errorCodeParam.Value.ToString());

                return success;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public int ProjectVideoDelete(
            string ProjectVideoID
        )
        {
            try
            {
                var scon = new SqlConnection(connectionString);
                var cmd = new SqlCommand("usp_ProjectVideo_Delete", scon);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ProjectVideoID", string.IsNullOrEmpty(ProjectVideoID) ? dbNULL : (object)ProjectVideoID);
                SqlParameter errorCodeParam = new SqlParameter("@ErrorCode", null);
                errorCodeParam.Size = 4;
                errorCodeParam.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(errorCodeParam);
                scon.Open();
                int success = cmd.ExecuteNonQuery();
                scon.Close();

                if (errorCodeParam.Value.ToString() != "0")
                    throw new Exception("Stored Procedure 'usp_ProjectVideo_Delete' reported the ErrorCode : " + errorCodeParam.Value.ToString());

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

        public DataTable ProjectVideoSelectAll(
            string Keyword,
            string Title,
            string Description,
            string ProjectID,
            string IsAvailable,
            string Priority,
            string SortByPriority
        )
        {
            try
            {
                var dt = new DataTable();
                var scon = new SqlConnection(connectionString);
                var cmd = new SqlCommand("usp_ProjectVideo_SelectAll", scon);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Keyword", string.IsNullOrEmpty(Keyword) ? dbNULL : (object)Keyword);
                cmd.Parameters.AddWithValue("@Title", string.IsNullOrEmpty(Title) ? dbNULL : (object)Title.Trim());
                cmd.Parameters.AddWithValue("@Description", string.IsNullOrEmpty(Description) ? dbNULL : (object)Description.Trim());
                cmd.Parameters.AddWithValue("@ProjectID", string.IsNullOrEmpty(ProjectID) ? dbNULL : (object)ProjectID);
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
                    throw new Exception("Stored Procedure 'usp_ProjectVideo_SelectAll' reported the ErrorCode : " + errorCodeParam.Value.ToString());

                return dt;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public DataTable ProjectVideoSelectOne(
            string ProjectVideoID
        )
        {
            try
            {
                var dt = new DataTable();
                var scon = new SqlConnection(connectionString);
                var cmd = new SqlCommand("usp_ProjectVideo_SelectOne", scon);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ProjectVideoID", string.IsNullOrEmpty(ProjectVideoID) ? dbNULL : (object)ProjectVideoID);
                SqlParameter errorCodeParam = new SqlParameter("@ErrorCode", null);
                errorCodeParam.Size = 4;
                errorCodeParam.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(errorCodeParam);
                var sda = new SqlDataAdapter(cmd);
                sda.Fill(dt);

                if (errorCodeParam.Value.ToString() != "0")
                    throw new Exception("Stored Procedure 'usp_ProjectVideo_SelectOne' reported the ErrorCode : " + errorCodeParam.Value.ToString());

                return dt;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public string ProjectVideoSelectMaxID()
        {
            try
            {
                var dt = new DataTable();
                var scon = new SqlConnection(connectionString);
                var cmd = new SqlCommand("usp_ProjectVideo_SelectMaxID", scon);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ProjectVideoIDParam = new SqlParameter("@ProjectVideoID", null);
                SqlParameter errorCodeParam = new SqlParameter("@ErrorCode", null);
                errorCodeParam.Size = ProjectVideoIDParam.Size = 4;
                errorCodeParam.Direction = ProjectVideoIDParam.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(ProjectVideoIDParam);
                cmd.Parameters.Add(errorCodeParam);
                var sda = new SqlDataAdapter(cmd);
                sda.Fill(dt);

                if (errorCodeParam.Value.ToString() != "0")
                    throw new Exception("Stored Procedure 'usp_ProjectVideo_SelectMaxID' reported the ErrorCode : " + errorCodeParam.Value.ToString());

                return ProjectVideoIDParam.Value.ToString();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public int ProjectVideoImageDelete(
            string ProjectVideoID
        )
        {
            try
            {
                var scon = new SqlConnection(connectionString);
                var cmd = new SqlCommand("usp_ProjectVideoImage_Delete", scon);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ProjectVideoID", string.IsNullOrEmpty(ProjectVideoID) ? dbNULL : (object)ProjectVideoID);
                SqlParameter errorCodeParam = new SqlParameter("@ErrorCode", null);
                errorCodeParam.Size = 4;
                errorCodeParam.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(errorCodeParam);
                scon.Open();
                int success = cmd.ExecuteNonQuery();
                scon.Close();

                if (errorCodeParam.Value.ToString() != "0")
                    throw new Exception("Stored Procedure 'usp_ProjectVideoImage_Delete' reported the ErrorCode : " + errorCodeParam.Value.ToString());

                return success;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}

