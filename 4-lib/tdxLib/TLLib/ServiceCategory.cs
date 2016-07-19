using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace TLLib
{
    public class ServiceCategory
    {
        string connectionString = Common.ConnectionString;
        DBNull dbNULL = DBNull.Value;

        public string ServiceCategoryInsert(
            string ServiceCategoryName,
            string ServiceCategoryNameEn,
            string ConvertedServiceCategoryName,
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
                var cmd = new SqlCommand("usp_ServiceCategory_Insert", scon);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ServiceCategoryName", string.IsNullOrEmpty(ServiceCategoryName) ? dbNULL : (object)ServiceCategoryName);
                cmd.Parameters.AddWithValue("@ServiceCategoryNameEn", string.IsNullOrEmpty(ServiceCategoryNameEn) ? dbNULL : (object)ServiceCategoryNameEn);
                cmd.Parameters.AddWithValue("@ConvertedServiceCategoryName", string.IsNullOrEmpty(ConvertedServiceCategoryName) ? dbNULL : (object)ConvertedServiceCategoryName);
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
                    throw new Exception("Stored Procedure 'usp_ServiceCategory_Insert' reported the ErrorCode : " + errorCodeParam.Value.ToString());

                return imageNameParam.Value.ToString();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public int ServiceCategoryUpdate(
            string ServiceCategoryID,
            string ServiceCategoryName,
            string ServiceCategoryNameEn,
            string ConvertedServiceCategoryName,
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
                var cmd = new SqlCommand("usp_ServiceCategory_Update", scon);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ServiceCategoryID", string.IsNullOrEmpty(ServiceCategoryID) ? dbNULL : (object)ServiceCategoryID);
                cmd.Parameters.AddWithValue("@ServiceCategoryName", string.IsNullOrEmpty(ServiceCategoryName) ? dbNULL : (object)ServiceCategoryName);
                cmd.Parameters.AddWithValue("@ServiceCategoryNameEn", string.IsNullOrEmpty(ServiceCategoryNameEn) ? dbNULL : (object)ServiceCategoryNameEn);
                cmd.Parameters.AddWithValue("@ConvertedServiceCategoryName", string.IsNullOrEmpty(ConvertedServiceCategoryName) ? dbNULL : (object)ConvertedServiceCategoryName);
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
                    throw new Exception("Stored Procedure 'usp_ServiceCategory_Update' reported the ErrorCode : " + errorCodeParam.Value.ToString());

                return success;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public int ServiceCategoryQuickUpdate(
            string ServiceCategoryID,
            string IsShowOnMenu,
            string IsShowOnHomePage,
            string IsAvailable
        )
        {
            try
            {
                var scon = new SqlConnection(connectionString);
                var cmd = new SqlCommand("usp_ServiceCategory_QuickUpdate", scon);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ServiceCategoryID", string.IsNullOrEmpty(ServiceCategoryID) ? dbNULL : (object)ServiceCategoryID);
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
                    throw new Exception("Stored Procedure 'usp_ServiceCategory_QuickUpdate' reported the ErrorCode : " + errorCodeParam.Value.ToString());

                return success;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public int ServiceCategoryDelete(
            string ServiceCategoryID
        )
        {
            try
            {
                var scon = new SqlConnection(connectionString);
                var cmd = new SqlCommand("usp_ServiceCategory_Delete", scon);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ServiceCategoryID", string.IsNullOrEmpty(ServiceCategoryID) ? dbNULL : (object)ServiceCategoryID);
                SqlParameter errorCodeParam = new SqlParameter("@ErrorCode", null);
                errorCodeParam.Size = 4;
                errorCodeParam.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(errorCodeParam);
                scon.Open();
                int success = cmd.ExecuteNonQuery();
                scon.Close();

                if (errorCodeParam.Value.ToString() != "0")
                    throw new Exception("Stored Procedure 'usp_ServiceCategory_Delete' reported the ErrorCode : " + errorCodeParam.Value.ToString());

                return success;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public int ServiceCategoryImageDelete(
            string ServiceCategoryID
        )
        {
            try
            {
                var scon = new SqlConnection(connectionString);
                var cmd = new SqlCommand("usp_ServiceCategoryImage_Delete", scon);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ServiceCategoryID", string.IsNullOrEmpty(ServiceCategoryID) ? dbNULL : (object)ServiceCategoryID);
                SqlParameter errorCodeParam = new SqlParameter("@ErrorCode", null);
                errorCodeParam.Size = 4;
                errorCodeParam.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(errorCodeParam);
                scon.Open();
                int success = cmd.ExecuteNonQuery();
                scon.Close();

                if (errorCodeParam.Value.ToString() != "0")
                    throw new Exception("Stored Procedure 'usp_ServiceCategoryImage_Delete' reported the ErrorCode : " + errorCodeParam.Value.ToString());

                return success;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public DataTable ServiceCategorySelectAll()
        {
            try
            {
                var dt = new DataTable();
                var scon = new SqlConnection(connectionString);
                var cmd = new SqlCommand("usp_ServiceCategory_SelectAll", scon);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter errorCodeParam = new SqlParameter("@ErrorCode", null);
                errorCodeParam.Size = 4;
                errorCodeParam.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(errorCodeParam);
                var sda = new SqlDataAdapter(cmd);
                sda.Fill(dt);

                if (errorCodeParam.Value.ToString() != "0")
                    throw new Exception("Stored Procedure 'usp_ServiceCategory_SelectAll' reported the ErrorCode : " + errorCodeParam.Value.ToString());

                Common oCommon = new Common();

                oCommon.RecursiveFillTree(dt, 0, "ParentID", "ServiceCategoryName", "ServiceCategoryID", "-");

                return oCommon.Tree;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public DataTable ServiceCategorySelectAll(int parentID, int increaseLevelCount, string IsShowOnMenu, string IsShowOnHomePage)
        {
            try
            {
                var dt = new DataTable();
                var scon = new SqlConnection(connectionString);
                var cmd = new SqlCommand("usp_ServiceCategory_SelectAll", scon);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter errorCodeParam = new SqlParameter("@ErrorCode", null);
                errorCodeParam.Size = 4;
                errorCodeParam.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(errorCodeParam);
                var sda = new SqlDataAdapter(cmd);
                sda.Fill(dt);

                if (errorCodeParam.Value.ToString() != "0")
                    throw new Exception("Stored Procedure 'usp_ServiceCategory_SelectAll' reported the ErrorCode : " + errorCodeParam.Value.ToString());

                Common oCommon = new Common();

                oCommon.RecursiveFillTree(dt, parentID, "ParentID", "ServiceCategoryName", "ServiceCategoryID", increaseLevelCount, IsShowOnMenu, IsShowOnHomePage);

                return oCommon.Tree;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public string ServiceCategoryMenuSelectAll(string href, string queryStringName, string parentID, int increaseLevelCount, bool useForeignLanguage)
        {
            try
            {
                var dt = new DataTable();
                var scon = new SqlConnection(connectionString);
                var cmd = new SqlCommand("usp_ServiceCategory_SelectAll", scon);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter errorCodeParam = new SqlParameter("@ErrorCode", null);
                errorCodeParam.Size = 4;
                errorCodeParam.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(errorCodeParam);
                var sda = new SqlDataAdapter(cmd);
                sda.Fill(dt);

                if (errorCodeParam.Value.ToString() != "0")
                    throw new Exception("Stored Procedure 'usp_ServiceCategory_SelectAll' reported the ErrorCode : " + errorCodeParam.Value.ToString());

                Common oCommon = new Common();

                oCommon.RecursiveFillMenuTree(
                    href,
                    queryStringName,
                    dt,
                    parentID,
                    "ParentID",
                    !useForeignLanguage ? "ServiceCategoryName" : "ServiceCategoryNameEn",
                    "ServiceCategoryID",
                    increaseLevelCount);

                return oCommon.Menu;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public string ServiceCategoryMenuSelectAll(string href, string queryStringName, string parentID, int increaseLevelCount, bool useForeignLanguage, string rootHmtlTag)
        {
            try
            {
                var dt = new DataTable();
                var scon = new SqlConnection(connectionString);
                var cmd = new SqlCommand("usp_ServiceCategory_SelectAll", scon);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter errorCodeParam = new SqlParameter("@ErrorCode", null);
                errorCodeParam.Size = 4;
                errorCodeParam.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(errorCodeParam);
                var sda = new SqlDataAdapter(cmd);
                sda.Fill(dt);

                if (errorCodeParam.Value.ToString() != "0")
                    throw new Exception("Stored Procedure 'usp_ServiceCategory_SelectAll' reported the ErrorCode : " + errorCodeParam.Value.ToString());

                Common oCommon = new Common();

                oCommon.RecursiveFillMenuTree(
                    href,
                    queryStringName,
                    dt,
                    parentID,
                    "ParentID",
                    !useForeignLanguage ? "ServiceCategoryName" : "ServiceCategoryNameEn",
                    "ServiceCategoryID",
                    increaseLevelCount,
                    rootHmtlTag);

                return oCommon.Menu;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public string ServiceCategoryMenuSelectAll(string href, string queryStringName, string parentID, int increaseLevelCount, bool useForeignLanguage, bool showImage, string imageFolderPath)
        {
            try
            {
                var dt = new DataTable();
                var scon = new SqlConnection(connectionString);
                var cmd = new SqlCommand("usp_ServiceCategory_SelectAll", scon);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter errorCodeParam = new SqlParameter("@ErrorCode", null);
                errorCodeParam.Size = 4;
                errorCodeParam.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(errorCodeParam);
                var sda = new SqlDataAdapter(cmd);
                sda.Fill(dt);

                if (errorCodeParam.Value.ToString() != "0")
                    throw new Exception("Stored Procedure 'usp_ServiceCategory_SelectAll' reported the ErrorCode : " + errorCodeParam.Value.ToString());

                Common oCommon = new Common();

                oCommon.RecursiveFillMenuTree(
                    href,
                    queryStringName,
                    dt,
                    parentID,
                    "ParentID",
                    !useForeignLanguage ? "ServiceCategoryName" : "ServiceCategoryNameEn",
                    "ServiceCategoryID",
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

        public string ServiceCategoryMenuSelectAll(string href, string queryStringName, string parentID, int increaseLevelCount, bool useForeignLanguage, string rootHmtlTag, bool showImage, string imageFolderPath)
        {
            try
            {
                var dt = new DataTable();
                var scon = new SqlConnection(connectionString);
                var cmd = new SqlCommand("usp_ServiceCategory_SelectAll", scon);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter errorCodeParam = new SqlParameter("@ErrorCode", null);
                errorCodeParam.Size = 4;
                errorCodeParam.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(errorCodeParam);
                var sda = new SqlDataAdapter(cmd);
                sda.Fill(dt);

                if (errorCodeParam.Value.ToString() != "0")
                    throw new Exception("Stored Procedure 'usp_ServiceCategory_SelectAll' reported the ErrorCode : " + errorCodeParam.Value.ToString());

                Common oCommon = new Common();

                oCommon.RecursiveFillMenuTree(
                    href,
                    queryStringName,
                    dt,
                    parentID,
                    "ParentID",
                    !useForeignLanguage ? "ServiceCategoryName" : "ServiceCategoryNameEn",
                    "ServiceCategoryID",
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

        public DataTable ServiceCategoryForEditSelectAll(
            string ServiceCategoryID
        )
        {
            try
            {
                var dt = new DataTable();
                var scon = new SqlConnection(connectionString);
                var cmd = new SqlCommand("usp_ServiceCategoryForEdit_SelectAll", scon);
                cmd.Parameters.AddWithValue("@ServiceCategoryID", string.IsNullOrEmpty(ServiceCategoryID) ? dbNULL : (object)ServiceCategoryID);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter errorCodeParam = new SqlParameter("@ErrorCode", null);
                errorCodeParam.Size = 4;
                errorCodeParam.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(errorCodeParam);
                var sda = new SqlDataAdapter(cmd);
                sda.Fill(dt);

                if (errorCodeParam.Value.ToString() != "0")
                    throw new Exception("Stored Procedure 'usp_ServiceCategoryForEdit_SelectAll' reported the ErrorCode : " + errorCodeParam.Value.ToString());

                Common oCommon = new Common();

                oCommon.RecursiveFillTree(dt, 0, "ParentID", "ServiceCategoryName", "ServiceCategoryID", "-");

                return oCommon.Tree;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public DataTable ServiceCategorySelectOne(
            string ServiceCategoryID
        )
        {
            try
            {
                var dt = new DataTable();
                var scon = new SqlConnection(connectionString);
                var cmd = new SqlCommand("usp_ServiceCategory_SelectOne", scon);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ServiceCategoryID", string.IsNullOrEmpty(ServiceCategoryID) ? dbNULL : (object)ServiceCategoryID);
                SqlParameter errorCodeParam = new SqlParameter("@ErrorCode", null);
                errorCodeParam.Size = 4;
                errorCodeParam.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(errorCodeParam);
                var sda = new SqlDataAdapter(cmd);
                sda.Fill(dt);

                if (errorCodeParam.Value.ToString() != "0")
                    throw new Exception("Stored Procedure 'usp_ServiceCategory_SelectOne' reported the ErrorCode : " + errorCodeParam.Value.ToString());

                return dt;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public DataTable ServiceCategoryUpOrder(
            string ServiceCategoryID
        )
        {
            try
            {
                var dt = new DataTable();
                var scon = new SqlConnection(connectionString);
                var cmd = new SqlCommand("usp_ServiceCategory_UpOrder", scon);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ServiceCategoryID", string.IsNullOrEmpty(ServiceCategoryID) ? dbNULL : (object)ServiceCategoryID);
                SqlParameter errorCodeParam = new SqlParameter("@ErrorCode", null);
                errorCodeParam.Size = 4;
                errorCodeParam.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(errorCodeParam);
                var sda = new SqlDataAdapter(cmd);
                sda.Fill(dt);

                if (errorCodeParam.Value.ToString() != "0")
                    throw new Exception("Stored Procedure 'usp_ServiceCategory_UpOrder' reported the ErrorCode : " + errorCodeParam.Value.ToString());

                return dt;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public DataTable ServiceCategoryDownOrder(
            string ServiceCategoryID
        )
        {
            try
            {
                var dt = new DataTable();
                var scon = new SqlConnection(connectionString);
                var cmd = new SqlCommand("usp_ServiceCategory_DownOrder", scon);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ServiceCategoryID", string.IsNullOrEmpty(ServiceCategoryID) ? dbNULL : (object)ServiceCategoryID);
                SqlParameter errorCodeParam = new SqlParameter("@ErrorCode", null);
                errorCodeParam.Size = 4;
                errorCodeParam.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(errorCodeParam);
                var sda = new SqlDataAdapter(cmd);
                sda.Fill(dt);

                if (errorCodeParam.Value.ToString() != "0")
                    throw new Exception("Stored Procedure 'usp_ServiceCategory_DownOrder' reported the ErrorCode : " + errorCodeParam.Value.ToString());

                return dt;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public bool ServiceCategoryIsChildrenExist(
            string ServiceCategoryID
        )
        {
            try
            {
                var scon = new SqlConnection(connectionString);
                var cmd = new SqlCommand("usp_ServiceCategory_IsChildrenExist", scon);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ServiceCategoryID", string.IsNullOrEmpty(ServiceCategoryID) ? dbNULL : (object)ServiceCategoryID);
                SqlParameter errorCodeParam = new SqlParameter("@ErrorCode", null);
                errorCodeParam.Size = 4;
                errorCodeParam.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(errorCodeParam);
                scon.Open();
                bool isExists = Convert.ToBoolean(cmd.ExecuteScalar());
                scon.Close();

                if (errorCodeParam.Value.ToString() != "0")
                    throw new Exception("Stored Procedure 'usp_ServiceCategory_IsChildrenExist' reported the ErrorCode : " + errorCodeParam.Value.ToString());

                return isExists;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public DataTable ServiceCategoryHierarchyToTopSelectAll(
            string CurrentServiceCategoryID
        )
        {
            try
            {
                var dt = new DataTable();
                var scon = new SqlConnection(connectionString);
                var cmd = new SqlCommand("usp_ServiceCategoryHierarchyToTop_SelectAll", scon);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@CurrentServiceCategoryID", string.IsNullOrEmpty(CurrentServiceCategoryID) ? dbNULL : (object)CurrentServiceCategoryID);
                SqlParameter errorCodeParam = new SqlParameter("@ErrorCode", null);
                errorCodeParam.Size = 4;
                errorCodeParam.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(errorCodeParam);
                var sda = new SqlDataAdapter(cmd);
                sda.Fill(dt);

                if (errorCodeParam.Value.ToString() != "0")
                    throw new Exception("Stored Procedure 'usp_ServiceCategoryHierarchyToTop_SelectAll' reported the ErrorCode : " + errorCodeParam.Value.ToString());

                return dt;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}

