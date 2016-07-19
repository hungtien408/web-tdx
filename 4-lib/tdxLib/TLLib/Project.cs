using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace TLLib
{
    public class Project
    {
        string connectionString = Common.ConnectionString;
        DBNull dbNULL = DBNull.Value;

        public string ProjectInsert(
            string ImageName,
            string MetaTittle,
	        string MetaDescription,
            string ProjectTitle,
            string ConvertedProjectTitle,
            string Description,
            string Content,
            string Tag,
            string MetaTittleEn,
            string MetaDescriptionEn,
            string ProjectTitleEn,
            string DescriptionEn,
            string ContentEn,
            string TagEn,
            string ProjectCategoryID,
            string IsShowOnHomePage,
            string IsAvailable,
            string Priority
        )
        {
            try
            {
                var scon = new SqlConnection(connectionString);
                var cmd = new SqlCommand("usp_Project_Insert", scon);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ImageName", string.IsNullOrEmpty(ImageName) ? dbNULL : (object)ImageName);
                cmd.Parameters.AddWithValue("@MetaTittle", string.IsNullOrEmpty(MetaTittle) ? dbNULL : (object)MetaTittle);
                cmd.Parameters.AddWithValue("@MetaDescription", string.IsNullOrEmpty(MetaDescription) ? dbNULL : (object)MetaDescription);
                cmd.Parameters.AddWithValue("@ProjectTitle", string.IsNullOrEmpty(ProjectTitle) ? dbNULL : (object)ProjectTitle);
                cmd.Parameters.AddWithValue("@ConvertedProjectTitle", string.IsNullOrEmpty(ConvertedProjectTitle) ? dbNULL : (object)ConvertedProjectTitle);
                cmd.Parameters.AddWithValue("@Description", string.IsNullOrEmpty(Description) ? dbNULL : (object)Description);
                cmd.Parameters.AddWithValue("@Content", string.IsNullOrEmpty(Content) ? dbNULL : (object)Content);
                cmd.Parameters.AddWithValue("@Tag", string.IsNullOrEmpty(Tag) ? dbNULL : (object)Tag);
                cmd.Parameters.AddWithValue("@MetaTittleEn", string.IsNullOrEmpty(MetaTittleEn) ? dbNULL : (object)MetaTittleEn);
                cmd.Parameters.AddWithValue("@MetaDescriptionEn", string.IsNullOrEmpty(MetaDescriptionEn) ? dbNULL : (object)MetaDescriptionEn);
                cmd.Parameters.AddWithValue("@ProjectTitleEn", string.IsNullOrEmpty(ProjectTitleEn) ? dbNULL : (object)ProjectTitleEn);
                cmd.Parameters.AddWithValue("@DescriptionEn", string.IsNullOrEmpty(DescriptionEn) ? dbNULL : (object)DescriptionEn);
                cmd.Parameters.AddWithValue("@ContentEn", string.IsNullOrEmpty(ContentEn) ? dbNULL : (object)ContentEn);
                cmd.Parameters.AddWithValue("@TagEn", string.IsNullOrEmpty(TagEn) ? dbNULL : (object)TagEn);
                cmd.Parameters.AddWithValue("@ProjectCategoryID", string.IsNullOrEmpty(ProjectCategoryID) ? dbNULL : (object)ProjectCategoryID);
                cmd.Parameters.AddWithValue("@IsShowOnHomePage", string.IsNullOrEmpty(IsShowOnHomePage) ? dbNULL : (object)IsShowOnHomePage);
                cmd.Parameters.AddWithValue("@IsAvailable", string.IsNullOrEmpty(IsAvailable) ? dbNULL : (object)IsAvailable);
                cmd.Parameters.AddWithValue("@Priority", string.IsNullOrEmpty(Priority) ? dbNULL : (object)Priority);

                SqlParameter imageNameParam = new SqlParameter("@OutImageName", null);
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
                    throw new Exception("Stored Procedure 'usp_Project_Insert' reported the ErrorCode : " + errorCodeParam.Value.ToString());

                return imageNameParam.Value.ToString();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public int ProjectUpdate(
            string ImageName,
            string ProjectID,
            string MetaTittle,
            string MetaDescription,
            string ProjectTitle,
            string ConvertedProjectTitle,
            string Description,
            string Content,
            string Tag,
            string MetaTittleEn,
            string MetaDescriptionEn,
            string ProjectTitleEn,
            string DescriptionEn,
            string ContentEn,
            string TagEn,
            string ProjectCategoryID,
            string IsShowOnHomePage,
            string IsAvailable,
            string Priority
        )
        {
            try
            {
                var scon = new SqlConnection(connectionString);
                var cmd = new SqlCommand("usp_Project_Update", scon);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ProjectID", string.IsNullOrEmpty(ProjectID) ? dbNULL : (object)ProjectID);
                cmd.Parameters.AddWithValue("@MetaTittle", string.IsNullOrEmpty(MetaTittle) ? dbNULL : (object)MetaTittle);
                cmd.Parameters.AddWithValue("@MetaDescription", string.IsNullOrEmpty(MetaDescription) ? dbNULL : (object)MetaDescription);
                cmd.Parameters.AddWithValue("@ProjectTitle", string.IsNullOrEmpty(ProjectTitle) ? dbNULL : (object)ProjectTitle);
                cmd.Parameters.AddWithValue("@ConvertedProjectTitle", string.IsNullOrEmpty(ConvertedProjectTitle) ? dbNULL : (object)ConvertedProjectTitle);
                cmd.Parameters.AddWithValue("@ImageName", string.IsNullOrEmpty(ImageName) ? dbNULL : (object)ImageName);
                cmd.Parameters.AddWithValue("@Description", string.IsNullOrEmpty(Description) ? dbNULL : (object)Description);
                cmd.Parameters.AddWithValue("@Content", string.IsNullOrEmpty(Content) ? dbNULL : (object)Content);
                cmd.Parameters.AddWithValue("@Tag", string.IsNullOrEmpty(Tag) ? dbNULL : (object)Tag);
                cmd.Parameters.AddWithValue("@MetaTittleEn", string.IsNullOrEmpty(MetaTittleEn) ? dbNULL : (object)MetaTittleEn);
                cmd.Parameters.AddWithValue("@MetaDescriptionEn", string.IsNullOrEmpty(MetaDescriptionEn) ? dbNULL : (object)MetaDescriptionEn);
                cmd.Parameters.AddWithValue("@ProjectTitleEn", string.IsNullOrEmpty(ProjectTitleEn) ? dbNULL : (object)ProjectTitleEn);
                cmd.Parameters.AddWithValue("@DescriptionEn", string.IsNullOrEmpty(DescriptionEn) ? dbNULL : (object)DescriptionEn);
                cmd.Parameters.AddWithValue("@ContentEn", string.IsNullOrEmpty(ContentEn) ? dbNULL : (object)ContentEn);
                cmd.Parameters.AddWithValue("@TagEn", string.IsNullOrEmpty(TagEn) ? dbNULL : (object)TagEn);
                cmd.Parameters.AddWithValue("@ProjectCategoryID", string.IsNullOrEmpty(ProjectCategoryID) ? dbNULL : (object)ProjectCategoryID);
                cmd.Parameters.AddWithValue("@IsShowOnHomePage", string.IsNullOrEmpty(IsShowOnHomePage) ? dbNULL : (object)IsShowOnHomePage);
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
                    throw new Exception("Stored Procedure 'usp_Project_Update' reported the ErrorCode : " + errorCodeParam.Value.ToString());

                return success;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public int ProjectQuickUpdate(
            string ProjectID,
            string IsShowOnHomePage,
            string IsAvailable,
            string Priority
        )
        {
            try
            {
                var scon = new SqlConnection(connectionString);
                var cmd = new SqlCommand("usp_Project_QuickUpdate", scon);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ProjectID", string.IsNullOrEmpty(ProjectID) ? dbNULL : (object)ProjectID);
                cmd.Parameters.AddWithValue("@IsShowOnHomePage", string.IsNullOrEmpty(IsShowOnHomePage) ? dbNULL : (object)IsShowOnHomePage);
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
                    throw new Exception("Stored Procedure 'usp_Project_QuickUpdate' reported the ErrorCode : " + errorCodeParam.Value.ToString());

                return success;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public int ProjectDelete(
            string ProjectID
        )
        {
            try
            {
                var scon = new SqlConnection(connectionString);
                var cmd = new SqlCommand("usp_Project_Delete", scon);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ProjectID", string.IsNullOrEmpty(ProjectID) ? dbNULL : (object)ProjectID);
                SqlParameter errorCodeParam = new SqlParameter("@ErrorCode", null);
                errorCodeParam.Size = 4;
                errorCodeParam.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(errorCodeParam);
                scon.Open();
                int success = cmd.ExecuteNonQuery();
                scon.Close();

                if (errorCodeParam.Value.ToString() != "0")
                    throw new Exception("Stored Procedure 'usp_Project_Delete' reported the ErrorCode : " + errorCodeParam.Value.ToString());

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

        public DataTable ProjectSelectAll(
            string StartRowIndex,
            string EndRowIndex,
            string Keyword,
            string ProjectTitle,
            string Description,
            string ProjectCategoryID,
            string Tag,
            string IsShowOnHomePage,
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
                var cmd = new SqlCommand("usp_Project_SelectAll", scon);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@StartRowIndex", string.IsNullOrEmpty(StartRowIndex) ? dbNULL : (object)StartRowIndex);
                cmd.Parameters.AddWithValue("@EndRowIndex", string.IsNullOrEmpty(EndRowIndex) ? dbNULL : (object)EndRowIndex);
                cmd.Parameters.AddWithValue("@Keyword", string.IsNullOrEmpty(Keyword) ? dbNULL : (object)Keyword);
                cmd.Parameters.AddWithValue("@ProjectTitle", string.IsNullOrEmpty(ProjectTitle) ? dbNULL : (object)ProjectTitle.Trim());
                cmd.Parameters.AddWithValue("@Description", string.IsNullOrEmpty(Description) ? dbNULL : (object)Description.Trim());
                cmd.Parameters.AddWithValue("@ProjectCategoryID", string.IsNullOrEmpty(ProjectCategoryID) ? dbNULL : (object)ProjectCategoryID);
                cmd.Parameters.AddWithValue("@Tag", string.IsNullOrEmpty(Tag) ? dbNULL : (object)Tag);
                cmd.Parameters.AddWithValue("@IsShowOnHomePage", string.IsNullOrEmpty(IsShowOnHomePage) ? dbNULL : (object)IsShowOnHomePage);
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
                    throw new Exception("Stored Procedure 'usp_Project_SelectAll' reported the ErrorCode : " + errorCodeParam.Value.ToString());

                return dt;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public DataTable ProjectSameSelectAll(
            string RerultCount,
            string ProjectID
        )
        {
            try
            {
                var dt = new DataTable();
                var scon = new SqlConnection(connectionString);
                var cmd = new SqlCommand("usp_SameProject_SelectAll", scon);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@RerultCount", string.IsNullOrEmpty(RerultCount) ? dbNULL : (object)RerultCount);
                cmd.Parameters.AddWithValue("@ProjectID", string.IsNullOrEmpty(ProjectID) ? dbNULL : (object)ProjectID);

                SqlParameter errorCodeParam = new SqlParameter("@ErrorCode", null);
                errorCodeParam.Size = 4;
                errorCodeParam.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(errorCodeParam);
                var sda = new SqlDataAdapter(cmd);
                sda.Fill(dt);

                if (errorCodeParam.Value.ToString() != "0")
                    throw new Exception("Stored Procedure 'usp_SameProject_SelectAll' reported the ErrorCode : " + errorCodeParam.Value.ToString());

                return dt;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public DataTable ProjectSelectOne(
            string ProjectID
        )
        {
            try
            {
                var dt = new DataTable();
                var scon = new SqlConnection(connectionString);
                var cmd = new SqlCommand("usp_Project_SelectOne", scon);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ProjectID", string.IsNullOrEmpty(ProjectID) ? dbNULL : (object)ProjectID);
                SqlParameter errorCodeParam = new SqlParameter("@ErrorCode", null);
                errorCodeParam.Size = 4;
                errorCodeParam.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(errorCodeParam);
                var sda = new SqlDataAdapter(cmd);
                sda.Fill(dt);

                if (errorCodeParam.Value.ToString() != "0")
                    throw new Exception("Stored Procedure 'usp_Project_SelectOne' reported the ErrorCode : " + errorCodeParam.Value.ToString());

                return dt;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public int ProjectImageDelete(
            string ProjectID
        )
        {
            try
            {
                var scon = new SqlConnection(connectionString);
                var cmd = new SqlCommand("usp_ProjectImages_Delete", scon);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ProjectID", string.IsNullOrEmpty(ProjectID) ? dbNULL : (object)ProjectID);
                SqlParameter errorCodeParam = new SqlParameter("@ErrorCode", null);
                errorCodeParam.Size = 4;
                errorCodeParam.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(errorCodeParam);
                scon.Open();
                int success = cmd.ExecuteNonQuery();
                scon.Close();

                if (errorCodeParam.Value.ToString() != "0")
                    throw new Exception("Stored Procedure 'usp_ProjectImages_Delete' reported the ErrorCode : " + errorCodeParam.Value.ToString());

                return success;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public DataTable ProjectNewerSelectAll(
            string RerultCount,
            string ProjectID
        )
        {
            try
            {
                var dt = new DataTable();
                var scon = new SqlConnection(connectionString);
                var cmd = new SqlCommand("usp_NewerProject_SelectAll", scon);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@RerultCount", string.IsNullOrEmpty(RerultCount) ? dbNULL : (object)RerultCount);
                cmd.Parameters.AddWithValue("@ProjectID", string.IsNullOrEmpty(ProjectID) ? dbNULL : (object)ProjectID);

                SqlParameter errorCodeParam = new SqlParameter("@ErrorCode", null);
                errorCodeParam.Size = 4;
                errorCodeParam.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(errorCodeParam);
                var sda = new SqlDataAdapter(cmd);
                sda.Fill(dt);

                if (errorCodeParam.Value.ToString() != "0")
                    throw new Exception("Stored Procedure 'usp_NewerProject_SelectAll' reported the ErrorCode : " + errorCodeParam.Value.ToString());

                return dt;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public DataTable ProjectOlderSelectAll(
            string RerultCount,
            string ProjectID
        )
        {
            try
            {
                var dt = new DataTable();
                var scon = new SqlConnection(connectionString);
                var cmd = new SqlCommand("usp_OlderProject_SelectAll", scon);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@RerultCount", string.IsNullOrEmpty(RerultCount) ? dbNULL : (object)RerultCount);
                cmd.Parameters.AddWithValue("@ProjectID", string.IsNullOrEmpty(ProjectID) ? dbNULL : (object)ProjectID);

                SqlParameter errorCodeParam = new SqlParameter("@ErrorCode", null);
                errorCodeParam.Size = 4;
                errorCodeParam.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(errorCodeParam);
                var sda = new SqlDataAdapter(cmd);
                sda.Fill(dt);

                if (errorCodeParam.Value.ToString() != "0")
                    throw new Exception("Stored Procedure 'usp_OlderProject_SelectAll' reported the ErrorCode : " + errorCodeParam.Value.ToString());

                return dt;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}

