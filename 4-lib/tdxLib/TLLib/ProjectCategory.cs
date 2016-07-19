using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace TLLib
{
    public class ProjectCategory
    {
        string connectionString = Common.ConnectionString;
        DBNull dbNULL = DBNull.Value;

        public string ProjectCategoryInsert(
            string ProjectCategoryName,
            string ProjectCategoryNameEn,
            string ConvertedProjectCategoryName,
            string Description,
            string DescriptionEn,
            string Content,
            string ContentEn,
            string MetaTitle,
            string MetaTitleEn,
            string MetaDescription,
            string MetaDescriptionEn,
            string ImageName,
            string ParentID,
            string IsShowOnMenu,
            string IsShowOnHomePage,
            string IsAvailable
        )
        {
            try
            {
                var scon = new SqlConnection(connectionString);
                var cmd = new SqlCommand("usp_ProjectCategory_Insert", scon);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ProjectCategoryName", string.IsNullOrEmpty(ProjectCategoryName) ? dbNULL : (object)ProjectCategoryName);
                cmd.Parameters.AddWithValue("@ProjectCategoryNameEn", string.IsNullOrEmpty(ProjectCategoryNameEn) ? dbNULL : (object)ProjectCategoryNameEn);
                cmd.Parameters.AddWithValue("@ConvertedProjectCategoryName", string.IsNullOrEmpty(ConvertedProjectCategoryName) ? dbNULL : (object)ConvertedProjectCategoryName);
                cmd.Parameters.AddWithValue("@Description", string.IsNullOrEmpty(Description) ? dbNULL : (object)Description);
                cmd.Parameters.AddWithValue("@DescriptionEn", string.IsNullOrEmpty(DescriptionEn) ? dbNULL : (object)DescriptionEn);
                cmd.Parameters.AddWithValue("@Content", string.IsNullOrEmpty(Content) ? dbNULL : (object)Content);
                cmd.Parameters.AddWithValue("@ContentEn", string.IsNullOrEmpty(ContentEn) ? dbNULL : (object)ContentEn);
                cmd.Parameters.AddWithValue("@MetaTitle", string.IsNullOrEmpty(MetaTitle) ? dbNULL : (object)MetaTitle);
                cmd.Parameters.AddWithValue("@MetaTitleEn", string.IsNullOrEmpty(MetaTitleEn) ? dbNULL : (object)MetaTitleEn);
                cmd.Parameters.AddWithValue("@MetaDescription", string.IsNullOrEmpty(MetaDescription) ? dbNULL : (object)MetaDescription);
                cmd.Parameters.AddWithValue("@MetaDescriptionEn", string.IsNullOrEmpty(MetaDescriptionEn) ? dbNULL : (object)MetaDescriptionEn);
                cmd.Parameters.AddWithValue("@ImageName", string.IsNullOrEmpty(ImageName) ? dbNULL : (object)ImageName);
                cmd.Parameters.AddWithValue("@ParentID", string.IsNullOrEmpty(ParentID) ? dbNULL : (object)ParentID);
                cmd.Parameters.AddWithValue("@IsShowOnMenu", string.IsNullOrEmpty(IsShowOnMenu) ? dbNULL : (object)IsShowOnMenu);
                cmd.Parameters.AddWithValue("@IsShowOnHomePage", string.IsNullOrEmpty(IsShowOnHomePage) ? dbNULL : (object)IsShowOnHomePage);
                cmd.Parameters.AddWithValue("@IsAvailable", string.IsNullOrEmpty(IsAvailable) ? dbNULL : (object)IsAvailable);

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
                    throw new Exception("Stored Procedure 'usp_ProjectCategory_Insert' reported the ErrorCode : " + errorCodeParam.Value.ToString());

                return imageNameParam.Value.ToString();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public int ProjectCategoryUpdate(
            string ProjectCategoryID,
            string ProjectCategoryName,
            string ProjectCategoryNameEn,
            string ConvertedProjectCategoryName,
            string Description,
            string DescriptionEn,
            string Content,
            string ContentEn,
            string MetaTitle,
            string MetaTitleEn,
            string MetaDescription,
            string MetaDescriptionEn,
            string ImageName,
            string ParentID,
            string IsShowOnMenu,
            string IsShowOnHomePage,
            string IsAvailable
        )
        {
            try
            {
                var scon = new SqlConnection(connectionString);
                var cmd = new SqlCommand("usp_ProjectCategory_Update", scon);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ProjectCategoryID", string.IsNullOrEmpty(ProjectCategoryID) ? dbNULL : (object)ProjectCategoryID);
                cmd.Parameters.AddWithValue("@ProjectCategoryName", string.IsNullOrEmpty(ProjectCategoryName) ? dbNULL : (object)ProjectCategoryName);
                cmd.Parameters.AddWithValue("@ProjectCategoryNameEn", string.IsNullOrEmpty(ProjectCategoryNameEn) ? dbNULL : (object)ProjectCategoryNameEn);
                cmd.Parameters.AddWithValue("@ConvertedProjectCategoryName", string.IsNullOrEmpty(ConvertedProjectCategoryName) ? dbNULL : (object)ConvertedProjectCategoryName);
                cmd.Parameters.AddWithValue("@Description", string.IsNullOrEmpty(Description) ? dbNULL : (object)Description);
                cmd.Parameters.AddWithValue("@DescriptionEn", string.IsNullOrEmpty(DescriptionEn) ? dbNULL : (object)DescriptionEn);
                cmd.Parameters.AddWithValue("@Content", string.IsNullOrEmpty(Content) ? dbNULL : (object)Content);
                cmd.Parameters.AddWithValue("@ContentEn", string.IsNullOrEmpty(ContentEn) ? dbNULL : (object)ContentEn);
                cmd.Parameters.AddWithValue("@MetaTitle", string.IsNullOrEmpty(MetaTitle) ? dbNULL : (object)MetaTitle);
                cmd.Parameters.AddWithValue("@MetaTitleEn", string.IsNullOrEmpty(MetaTitleEn) ? dbNULL : (object)MetaTitleEn);
                cmd.Parameters.AddWithValue("@MetaDescription", string.IsNullOrEmpty(MetaDescription) ? dbNULL : (object)MetaDescription);
                cmd.Parameters.AddWithValue("@MetaDescriptionEn", string.IsNullOrEmpty(MetaDescriptionEn) ? dbNULL : (object)MetaDescriptionEn);
                cmd.Parameters.AddWithValue("@ImageName", string.IsNullOrEmpty(ImageName) ? dbNULL : (object)ImageName);
                cmd.Parameters.AddWithValue("@ParentID", string.IsNullOrEmpty(ParentID) ? dbNULL : (object)ParentID);
                cmd.Parameters.AddWithValue("@IsShowOnMenu", string.IsNullOrEmpty(IsShowOnMenu) ? dbNULL : (object)IsShowOnMenu);
                cmd.Parameters.AddWithValue("@IsShowOnHomePage", string.IsNullOrEmpty(IsShowOnHomePage) ? dbNULL : (object)IsShowOnHomePage);
                cmd.Parameters.AddWithValue("@IsAvailable", string.IsNullOrEmpty(IsAvailable) ? dbNULL : (object)IsAvailable);
                SqlParameter errorCodeParam = new SqlParameter("@ErrorCode", null);
                errorCodeParam.Size = 4;
                errorCodeParam.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(errorCodeParam);
                scon.Open();
                int success = cmd.ExecuteNonQuery();
                scon.Close();

                if (errorCodeParam.Value.ToString() != "0")
                    throw new Exception("Stored Procedure 'usp_ProjectCategory_Update' reported the ErrorCode : " + errorCodeParam.Value.ToString());

                return success;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public int ProjectCategoryQuickUpdate(
            string ProjectCategoryID,
            string IsShowOnMenu,
            string IsShowOnHomePage,
            string IsAvailable
        )
        {
            try
            {
                var scon = new SqlConnection(connectionString);
                var cmd = new SqlCommand("usp_ProjectCategory_QuickUpdate", scon);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ProjectCategoryID", string.IsNullOrEmpty(ProjectCategoryID) ? dbNULL : (object)ProjectCategoryID);
                cmd.Parameters.AddWithValue("@IsShowOnMenu", string.IsNullOrEmpty(IsShowOnMenu) ? dbNULL : (object)IsShowOnMenu);
                cmd.Parameters.AddWithValue("@IsShowOnHomePage", string.IsNullOrEmpty(IsShowOnHomePage) ? dbNULL : (object)IsShowOnHomePage);
                cmd.Parameters.AddWithValue("@IsAvailable", string.IsNullOrEmpty(IsAvailable) ? dbNULL : (object)IsAvailable);
                SqlParameter errorCodeParam = new SqlParameter("@ErrorCode", null);
                errorCodeParam.Size = 4;
                errorCodeParam.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(errorCodeParam);
                scon.Open();
                int success = cmd.ExecuteNonQuery();
                scon.Close();

                if (errorCodeParam.Value.ToString() != "0")
                    throw new Exception("Stored Procedure 'usp_ProjectCategory_QuickUpdate' reported the ErrorCode : " + errorCodeParam.Value.ToString());

                return success;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public int ProjectCategoryDelete(
            string ProjectCategoryID
        )
        {
            try
            {
                var scon = new SqlConnection(connectionString);
                var cmd = new SqlCommand("usp_ProjectCategory_Delete", scon);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ProjectCategoryID", string.IsNullOrEmpty(ProjectCategoryID) ? dbNULL : (object)ProjectCategoryID);
                SqlParameter errorCodeParam = new SqlParameter("@ErrorCode", null);
                errorCodeParam.Size = 4;
                errorCodeParam.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(errorCodeParam);
                scon.Open();
                int success = cmd.ExecuteNonQuery();
                scon.Close();

                if (errorCodeParam.Value.ToString() != "0")
                    throw new Exception("Stored Procedure 'usp_ProjectCategory_Delete' reported the ErrorCode : " + errorCodeParam.Value.ToString());

                return success;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public int ProjectCategoryImageDelete(
            string ProjectCategoryID
        )
        {
            try
            {
                var scon = new SqlConnection(connectionString);
                var cmd = new SqlCommand("usp_ProjectCategoryImage_Delete", scon);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ProjectCategoryID", string.IsNullOrEmpty(ProjectCategoryID) ? dbNULL : (object)ProjectCategoryID);
                SqlParameter errorCodeParam = new SqlParameter("@ErrorCode", null);
                errorCodeParam.Size = 4;
                errorCodeParam.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(errorCodeParam);
                scon.Open();
                int success = cmd.ExecuteNonQuery();
                scon.Close();

                if (errorCodeParam.Value.ToString() != "0")
                    throw new Exception("Stored Procedure 'usp_ProjectCategoryImage_Delete' reported the ErrorCode : " + errorCodeParam.Value.ToString());

                return success;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public DataTable ProjectCategorySelectAll()
        {
            try
            {
                var dt = new DataTable();
                var scon = new SqlConnection(connectionString);
                var cmd = new SqlCommand("usp_ProjectCategory_SelectAll", scon);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter errorCodeParam = new SqlParameter("@ErrorCode", null);
                errorCodeParam.Size = 4;
                errorCodeParam.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(errorCodeParam);
                var sda = new SqlDataAdapter(cmd);
                sda.Fill(dt);

                if (errorCodeParam.Value.ToString() != "0")
                    throw new Exception("Stored Procedure 'usp_ProjectCategory_SelectAll' reported the ErrorCode : " + errorCodeParam.Value.ToString());

                Common oCommon = new Common();

                oCommon.RecursiveFillTree(dt, 0, "ParentID", "ProjectCategoryName", "ProjectCategoryID", "-");

                return oCommon.Tree;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public DataTable ProjectCategorySelectAll(int parentID, int increaseLevelCount, string IsShowOnMenu, string IsShowOnHomePage)
        {
            try
            {
                var dt = new DataTable();
                var scon = new SqlConnection(connectionString);
                var cmd = new SqlCommand("usp_ProjectCategory_SelectAll", scon);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter errorCodeParam = new SqlParameter("@ErrorCode", null);
                errorCodeParam.Size = 4;
                errorCodeParam.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(errorCodeParam);
                var sda = new SqlDataAdapter(cmd);
                sda.Fill(dt);

                if (errorCodeParam.Value.ToString() != "0")
                    throw new Exception("Stored Procedure 'usp_ProjectCategory_SelectAll' reported the ErrorCode : " + errorCodeParam.Value.ToString());

                Common oCommon = new Common();

                oCommon.RecursiveFillTree(dt, parentID, "ParentID", "ProjectCategoryName", "ProjectCategoryID", increaseLevelCount, IsShowOnMenu, IsShowOnHomePage);

                return oCommon.Tree;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public string ProjectCategoryMenuSelectAll(string href, string queryStringName, string parentID, int increaseLevelCount, bool useForeignLanguage)
        {
            try
            {
                var dt = new DataTable();
                var scon = new SqlConnection(connectionString);
                var cmd = new SqlCommand("usp_ProjectCategory_SelectAll", scon);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter errorCodeParam = new SqlParameter("@ErrorCode", null);
                errorCodeParam.Size = 4;
                errorCodeParam.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(errorCodeParam);
                var sda = new SqlDataAdapter(cmd);
                sda.Fill(dt);

                if (errorCodeParam.Value.ToString() != "0")
                    throw new Exception("Stored Procedure 'usp_ProjectCategory_SelectAll' reported the ErrorCode : " + errorCodeParam.Value.ToString());

                Common oCommon = new Common();

                oCommon.RecursiveFillMenuTree(
                    href,
                    queryStringName,
                    dt,
                    parentID,
                    "ParentID",
                    !useForeignLanguage ? "ProjectCategoryName" : "ProjectCategoryNameEn",
                    "ProjectCategoryID",
                    increaseLevelCount);

                return oCommon.Menu;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public string ProjectCategoryMenuSelectAll(string href, string queryStringName, string parentID, int increaseLevelCount, bool useForeignLanguage, string rootHmtlTag)
        {
            try
            {
                var dt = new DataTable();
                var scon = new SqlConnection(connectionString);
                var cmd = new SqlCommand("usp_ProjectCategory_SelectAll", scon);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter errorCodeParam = new SqlParameter("@ErrorCode", null);
                errorCodeParam.Size = 4;
                errorCodeParam.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(errorCodeParam);
                var sda = new SqlDataAdapter(cmd);
                sda.Fill(dt);

                if (errorCodeParam.Value.ToString() != "0")
                    throw new Exception("Stored Procedure 'usp_ProjectCategory_SelectAll' reported the ErrorCode : " + errorCodeParam.Value.ToString());

                Common oCommon = new Common();

                oCommon.RecursiveFillMenuTree(
                    href,
                    queryStringName,
                    dt,
                    parentID,
                    "ParentID",
                    !useForeignLanguage ? "ProjectCategoryName" : "ProjectCategoryNameEn",
                    "ProjectCategoryID",
                    increaseLevelCount,
                    rootHmtlTag);

                return oCommon.Menu;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public string ProjectCategoryMenuSelectAll(string href, string queryStringName, string parentID, int increaseLevelCount, bool useForeignLanguage, bool showImage, string imageFolderPath)
        {
            try
            {
                var dt = new DataTable();
                var scon = new SqlConnection(connectionString);
                var cmd = new SqlCommand("usp_ProjectCategory_SelectAll", scon);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter errorCodeParam = new SqlParameter("@ErrorCode", null);
                errorCodeParam.Size = 4;
                errorCodeParam.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(errorCodeParam);
                var sda = new SqlDataAdapter(cmd);
                sda.Fill(dt);

                if (errorCodeParam.Value.ToString() != "0")
                    throw new Exception("Stored Procedure 'usp_ProjectCategory_SelectAll' reported the ErrorCode : " + errorCodeParam.Value.ToString());

                Common oCommon = new Common();

                oCommon.RecursiveFillMenuTree(
                    href,
                    queryStringName,
                    dt,
                    parentID,
                    "ParentID",
                    !useForeignLanguage ? "ProjectCategoryName" : "ProjectCategoryNameEn",
                    "ProjectCategoryID",
                    increaseLevelCount,
                    showImage,
                    imageFolderPath,
                    "ImageName"
                    );

                return oCommon.Menu;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public string ProjectCategoryMenuSelectAll(string href, string queryStringName, string parentID, int increaseLevelCount, bool useForeignLanguage, string rootHmtlTag, bool showImage, string imageFolderPath)
        {
            try
            {
                var dt = new DataTable();
                var scon = new SqlConnection(connectionString);
                var cmd = new SqlCommand("usp_ProjectCategory_SelectAll", scon);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter errorCodeParam = new SqlParameter("@ErrorCode", null);
                errorCodeParam.Size = 4;
                errorCodeParam.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(errorCodeParam);
                var sda = new SqlDataAdapter(cmd);
                sda.Fill(dt);

                if (errorCodeParam.Value.ToString() != "0")
                    throw new Exception("Stored Procedure 'usp_ProjectCategory_SelectAll' reported the ErrorCode : " + errorCodeParam.Value.ToString());

                Common oCommon = new Common();

                oCommon.RecursiveFillMenuTree(
                    href,
                    queryStringName,
                    dt,
                    parentID,
                    "ParentID",
                    !useForeignLanguage ? "ProjectCategoryName" : "ProjectCategoryNameEn",
                    "ProjectCategoryID",
                    increaseLevelCount,
                    rootHmtlTag,
                    showImage,
                    imageFolderPath,
                    "ImageName"
                    );

                return oCommon.Menu;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public DataTable ProjectCategoryForEditSelectAll(
            string ProjectCategoryID
        )
        {
            try
            {
                var dt = new DataTable();
                var scon = new SqlConnection(connectionString);
                var cmd = new SqlCommand("usp_ProjectCategoryForEdit_SelectAll", scon);
                cmd.Parameters.AddWithValue("@ProjectCategoryID", string.IsNullOrEmpty(ProjectCategoryID) ? dbNULL : (object)ProjectCategoryID);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter errorCodeParam = new SqlParameter("@ErrorCode", null);
                errorCodeParam.Size = 4;
                errorCodeParam.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(errorCodeParam);
                var sda = new SqlDataAdapter(cmd);
                sda.Fill(dt);

                if (errorCodeParam.Value.ToString() != "0")
                    throw new Exception("Stored Procedure 'usp_ProjectCategoryForEdit_SelectAll' reported the ErrorCode : " + errorCodeParam.Value.ToString());

                Common oCommon = new Common();

                oCommon.RecursiveFillTree(dt, 0, "ParentID", "ProjectCategoryName", "ProjectCategoryID", "-");

                return oCommon.Tree;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public DataTable ProjectCategorySelectOne(
            string ProjectCategoryID
        )
        {
            try
            {
                var dt = new DataTable();
                var scon = new SqlConnection(connectionString);
                var cmd = new SqlCommand("usp_ProjectCategory_SelectOne", scon);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ProjectCategoryID", string.IsNullOrEmpty(ProjectCategoryID) ? dbNULL : (object)ProjectCategoryID);
                SqlParameter errorCodeParam = new SqlParameter("@ErrorCode", null);
                errorCodeParam.Size = 4;
                errorCodeParam.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(errorCodeParam);
                var sda = new SqlDataAdapter(cmd);
                sda.Fill(dt);

                if (errorCodeParam.Value.ToString() != "0")
                    throw new Exception("Stored Procedure 'usp_ProjectCategory_SelectOne' reported the ErrorCode : " + errorCodeParam.Value.ToString());

                return dt;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public DataTable ProjectCategoryUpOrder(
            string ProjectCategoryID
        )
        {
            try
            {
                var dt = new DataTable();
                var scon = new SqlConnection(connectionString);
                var cmd = new SqlCommand("usp_ProjectCategory_UpOrder", scon);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ProjectCategoryID", string.IsNullOrEmpty(ProjectCategoryID) ? dbNULL : (object)ProjectCategoryID);
                SqlParameter errorCodeParam = new SqlParameter("@ErrorCode", null);
                errorCodeParam.Size = 4;
                errorCodeParam.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(errorCodeParam);
                var sda = new SqlDataAdapter(cmd);
                sda.Fill(dt);

                if (errorCodeParam.Value.ToString() != "0")
                    throw new Exception("Stored Procedure 'usp_ProjectCategory_UpOrder' reported the ErrorCode : " + errorCodeParam.Value.ToString());

                return dt;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public DataTable ProjectCategoryDownOrder(
            string ProjectCategoryID
        )
        {
            try
            {
                var dt = new DataTable();
                var scon = new SqlConnection(connectionString);
                var cmd = new SqlCommand("usp_ProjectCategory_DownOrder", scon);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ProjectCategoryID", string.IsNullOrEmpty(ProjectCategoryID) ? dbNULL : (object)ProjectCategoryID);
                SqlParameter errorCodeParam = new SqlParameter("@ErrorCode", null);
                errorCodeParam.Size = 4;
                errorCodeParam.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(errorCodeParam);
                var sda = new SqlDataAdapter(cmd);
                sda.Fill(dt);

                if (errorCodeParam.Value.ToString() != "0")
                    throw new Exception("Stored Procedure 'usp_ProjectCategory_DownOrder' reported the ErrorCode : " + errorCodeParam.Value.ToString());

                return dt;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public bool ProjectCategoryIsChildrenExist(
            string ProjectCategoryID
        )
        {
            try
            {
                var scon = new SqlConnection(connectionString);
                var cmd = new SqlCommand("usp_ProjectCategory_IsChildrenExist", scon);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ProjectCategoryID", string.IsNullOrEmpty(ProjectCategoryID) ? dbNULL : (object)ProjectCategoryID);
                SqlParameter errorCodeParam = new SqlParameter("@ErrorCode", null);
                errorCodeParam.Size = 4;
                errorCodeParam.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(errorCodeParam);
                scon.Open();
                bool isExists = Convert.ToBoolean(cmd.ExecuteScalar());
                scon.Close();

                if (errorCodeParam.Value.ToString() != "0")
                    throw new Exception("Stored Procedure 'usp_ProjectCategory_IsChildrenExist' reported the ErrorCode : " + errorCodeParam.Value.ToString());

                return isExists;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public DataTable ProjectCategoryHierarchyToTopSelectAll(
            string CurrentProjectCategoryID
        )
        {
            try
            {
                var dt = new DataTable();
                var scon = new SqlConnection(connectionString);
                var cmd = new SqlCommand("usp_ProjectCategoryHierarchyToTop_SelectAll", scon);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@CurrentProjectCategoryID", string.IsNullOrEmpty(CurrentProjectCategoryID) ? dbNULL : (object)CurrentProjectCategoryID);
                SqlParameter errorCodeParam = new SqlParameter("@ErrorCode", null);
                errorCodeParam.Size = 4;
                errorCodeParam.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(errorCodeParam);
                var sda = new SqlDataAdapter(cmd);
                sda.Fill(dt);

                if (errorCodeParam.Value.ToString() != "0")
                    throw new Exception("Stored Procedure 'usp_ProjectCategoryHierarchyToTop_SelectAll' reported the ErrorCode : " + errorCodeParam.Value.ToString());

                return dt;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}

