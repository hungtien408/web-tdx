using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace TLLib
{
    public class ProductCategory
    {
        string connectionString = Common.ConnectionString;
        DBNull dbNULL = DBNull.Value;

        public string ProductCategoryInsert(
            string ProductCategoryName,
            string ProductCategoryNameEn,
            string ConvertedProductCategoryName,
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
                var cmd = new SqlCommand("usp_ProductCategory_Insert", scon);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ProductCategoryName", string.IsNullOrEmpty(ProductCategoryName) ? dbNULL : (object)ProductCategoryName);
                cmd.Parameters.AddWithValue("@ProductCategoryNameEn", string.IsNullOrEmpty(ProductCategoryNameEn) ? dbNULL : (object)ProductCategoryNameEn);
                cmd.Parameters.AddWithValue("@ConvertedProductCategoryName", string.IsNullOrEmpty(ConvertedProductCategoryName) ? dbNULL : (object)ConvertedProductCategoryName);
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
                    throw new Exception("Stored Procedure 'usp_ProductCategory_Insert' reported the ErrorCode : " + errorCodeParam.Value.ToString());

                return imageNameParam.Value.ToString();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public int ProductCategoryUpdate(
            string ProductCategoryID,
            string ProductCategoryName,
            string ProductCategoryNameEn,
            string ConvertedProductCategoryName,
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
                var cmd = new SqlCommand("usp_ProductCategory_Update", scon);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ProductCategoryID", string.IsNullOrEmpty(ProductCategoryID) ? dbNULL : (object)ProductCategoryID);
                cmd.Parameters.AddWithValue("@ProductCategoryName", string.IsNullOrEmpty(ProductCategoryName) ? dbNULL : (object)ProductCategoryName);
                cmd.Parameters.AddWithValue("@ProductCategoryNameEn", string.IsNullOrEmpty(ProductCategoryNameEn) ? dbNULL : (object)ProductCategoryNameEn);
                cmd.Parameters.AddWithValue("@ConvertedProductCategoryName", string.IsNullOrEmpty(ConvertedProductCategoryName) ? dbNULL : (object)ConvertedProductCategoryName);
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
                    throw new Exception("Stored Procedure 'usp_ProductCategory_Update' reported the ErrorCode : " + errorCodeParam.Value.ToString());

                return success;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public int ProductCategoryQuickUpdate(
            string ProductCategoryID,
            string IsShowOnMenu,
            string IsShowOnHomePage,
            string IsAvailable
        )
        {
            try
            {
                var scon = new SqlConnection(connectionString);
                var cmd = new SqlCommand("usp_ProductCategory_QuickUpdate", scon);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ProductCategoryID", string.IsNullOrEmpty(ProductCategoryID) ? dbNULL : (object)ProductCategoryID);
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
                    throw new Exception("Stored Procedure 'usp_ProductCategory_QuickUpdate' reported the ErrorCode : " + errorCodeParam.Value.ToString());

                return success;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public int ProductCategoryDelete(
            string ProductCategoryID
        )
        {
            try
            {
                var scon = new SqlConnection(connectionString);
                var cmd = new SqlCommand("usp_ProductCategory_Delete", scon);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ProductCategoryID", string.IsNullOrEmpty(ProductCategoryID) ? dbNULL : (object)ProductCategoryID);
                SqlParameter errorCodeParam = new SqlParameter("@ErrorCode", null);
                errorCodeParam.Size = 4;
                errorCodeParam.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(errorCodeParam);
                scon.Open();
                int success = cmd.ExecuteNonQuery();
                scon.Close();

                if (errorCodeParam.Value.ToString() != "0")
                    throw new Exception("Stored Procedure 'usp_ProductCategory_Delete' reported the ErrorCode : " + errorCodeParam.Value.ToString());

                return success;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public int ProductCategoryImageDelete(
            string ProductCategoryID
        )
        {
            try
            {
                var scon = new SqlConnection(connectionString);
                var cmd = new SqlCommand("usp_ProductCategoryImage_Delete", scon);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ProductCategoryID", string.IsNullOrEmpty(ProductCategoryID) ? dbNULL : (object)ProductCategoryID);
                SqlParameter errorCodeParam = new SqlParameter("@ErrorCode", null);
                errorCodeParam.Size = 4;
                errorCodeParam.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(errorCodeParam);
                scon.Open();
                int success = cmd.ExecuteNonQuery();
                scon.Close();

                if (errorCodeParam.Value.ToString() != "0")
                    throw new Exception("Stored Procedure 'usp_ProductCategoryImage_Delete' reported the ErrorCode : " + errorCodeParam.Value.ToString());

                return success;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public DataTable ProductCategorySelectAll()
        {
            try
            {
                var dt = new DataTable();
                var scon = new SqlConnection(connectionString);
                var cmd = new SqlCommand("usp_ProductCategory_SelectAll", scon);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter errorCodeParam = new SqlParameter("@ErrorCode", null);
                errorCodeParam.Size = 4;
                errorCodeParam.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(errorCodeParam);
                var sda = new SqlDataAdapter(cmd);
                sda.Fill(dt);

                if (errorCodeParam.Value.ToString() != "0")
                    throw new Exception("Stored Procedure 'usp_ProductCategory_SelectAll' reported the ErrorCode : " + errorCodeParam.Value.ToString());

                Common oCommon = new Common();

                oCommon.RecursiveFillTree(dt, 0, "ParentID", "ProductCategoryName", "ProductCategoryID", "-");

                return oCommon.Tree;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public DataTable ProductCategorySelectAll(int parentID, int increaseLevelCount, string IsShowOnMenu, string IsShowOnHomePage)
        {
            try
            {
                var dt = new DataTable();
                var scon = new SqlConnection(connectionString);
                var cmd = new SqlCommand("usp_ProductCategory_SelectAll", scon);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter errorCodeParam = new SqlParameter("@ErrorCode", null);
                errorCodeParam.Size = 4;
                errorCodeParam.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(errorCodeParam);
                var sda = new SqlDataAdapter(cmd);
                sda.Fill(dt);

                if (errorCodeParam.Value.ToString() != "0")
                    throw new Exception("Stored Procedure 'usp_ProductCategory_SelectAll' reported the ErrorCode : " + errorCodeParam.Value.ToString());

                Common oCommon = new Common();

                oCommon.RecursiveFillTree(dt, parentID, "ParentID", "ProductCategoryName", "ProductCategoryID", increaseLevelCount, IsShowOnMenu, IsShowOnHomePage);

                return oCommon.Tree;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public string ProductCategoryMenuSelectAll(string href, string queryStringName, string parentID, int increaseLevelCount, bool useForeignLanguage)
        {
            try
            {
                var dt = new DataTable();
                var scon = new SqlConnection(connectionString);
                var cmd = new SqlCommand("usp_ProductCategory_SelectAll", scon);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter errorCodeParam = new SqlParameter("@ErrorCode", null);
                errorCodeParam.Size = 4;
                errorCodeParam.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(errorCodeParam);
                var sda = new SqlDataAdapter(cmd);
                sda.Fill(dt);

                if (errorCodeParam.Value.ToString() != "0")
                    throw new Exception("Stored Procedure 'usp_ProductCategory_SelectAll' reported the ErrorCode : " + errorCodeParam.Value.ToString());

                Common oCommon = new Common();

                oCommon.RecursiveFillMenuTree(
                    href,
                    queryStringName,
                    dt,
                    parentID,
                    "ParentID",
                    !useForeignLanguage ? "ProductCategoryName" : "ProductCategoryNameEn",
                    "ProductCategoryID",
                    increaseLevelCount);

                return oCommon.Menu;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public string ProductCategoryMenuSelectAll(string href, string queryStringName, string parentID, int increaseLevelCount, bool useForeignLanguage, string rootHmtlTag)
        {
            try
            {
                var dt = new DataTable();
                var scon = new SqlConnection(connectionString);
                var cmd = new SqlCommand("usp_ProductCategory_SelectAll", scon);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter errorCodeParam = new SqlParameter("@ErrorCode", null);
                errorCodeParam.Size = 4;
                errorCodeParam.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(errorCodeParam);
                var sda = new SqlDataAdapter(cmd);
                sda.Fill(dt);

                if (errorCodeParam.Value.ToString() != "0")
                    throw new Exception("Stored Procedure 'usp_ProductCategory_SelectAll' reported the ErrorCode : " + errorCodeParam.Value.ToString());

                Common oCommon = new Common();

                oCommon.RecursiveFillMenuTree(
                    href,
                    queryStringName,
                    dt,
                    parentID,
                    "ParentID",
                    !useForeignLanguage ? "ProductCategoryName" : "ProductCategoryNameEn",
                    "ProductCategoryID",
                    increaseLevelCount,
                    rootHmtlTag);

                return oCommon.Menu;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public string ProductCategoryMenuSelectAll(string href, string queryStringName, string parentID, int increaseLevelCount, bool useForeignLanguage, bool showImage, string imageFolderPath)
        {
            try
            {
                var dt = new DataTable();
                var scon = new SqlConnection(connectionString);
                var cmd = new SqlCommand("usp_ProductCategory_SelectAll", scon);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter errorCodeParam = new SqlParameter("@ErrorCode", null);
                errorCodeParam.Size = 4;
                errorCodeParam.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(errorCodeParam);
                var sda = new SqlDataAdapter(cmd);
                sda.Fill(dt);

                if (errorCodeParam.Value.ToString() != "0")
                    throw new Exception("Stored Procedure 'usp_ProductCategory_SelectAll' reported the ErrorCode : " + errorCodeParam.Value.ToString());

                Common oCommon = new Common();

                oCommon.RecursiveFillMenuTree(
                    href,
                    queryStringName,
                    dt,
                    parentID,
                    "ParentID",
                    !useForeignLanguage ? "ProductCategoryName" : "ProductCategoryNameEn",
                    "ProductCategoryID",
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

        public string ProductCategoryMenuSelectAll(string href, string queryStringName, string parentID, int increaseLevelCount, bool useForeignLanguage, string rootHmtlTag, bool showImage, string imageFolderPath)
        {
            try
            {
                var dt = new DataTable();
                var scon = new SqlConnection(connectionString);
                var cmd = new SqlCommand("usp_ProductCategory_SelectAll", scon);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter errorCodeParam = new SqlParameter("@ErrorCode", null);
                errorCodeParam.Size = 4;
                errorCodeParam.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(errorCodeParam);
                var sda = new SqlDataAdapter(cmd);
                sda.Fill(dt);

                if (errorCodeParam.Value.ToString() != "0")
                    throw new Exception("Stored Procedure 'usp_ProductCategory_SelectAll' reported the ErrorCode : " + errorCodeParam.Value.ToString());

                Common oCommon = new Common();

                oCommon.RecursiveFillMenuTree(
                    href,
                    queryStringName,
                    dt,
                    parentID,
                    "ParentID",
                    !useForeignLanguage ? "ProductCategoryName" : "ProductCategoryNameEn",
                    "ProductCategoryID",
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

        public DataTable ProductCategoryForEditSelectAll(
            string ProductCategoryID
        )
        {
            try
            {
                var dt = new DataTable();
                var scon = new SqlConnection(connectionString);
                var cmd = new SqlCommand("usp_ProductCategoryForEdit_SelectAll", scon);
                cmd.Parameters.AddWithValue("@ProductCategoryID", string.IsNullOrEmpty(ProductCategoryID) ? dbNULL : (object)ProductCategoryID);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter errorCodeParam = new SqlParameter("@ErrorCode", null);
                errorCodeParam.Size = 4;
                errorCodeParam.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(errorCodeParam);
                var sda = new SqlDataAdapter(cmd);
                sda.Fill(dt);

                if (errorCodeParam.Value.ToString() != "0")
                    throw new Exception("Stored Procedure 'usp_ProductCategoryForEdit_SelectAll' reported the ErrorCode : " + errorCodeParam.Value.ToString());

                Common oCommon = new Common();

                oCommon.RecursiveFillTree(dt, 0, "ParentID", "ProductCategoryName", "ProductCategoryID", "-");

                return oCommon.Tree;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public DataTable ProductCategorySelectOne(
            string ProductCategoryID
        )
        {
            try
            {
                var dt = new DataTable();
                var scon = new SqlConnection(connectionString);
                var cmd = new SqlCommand("usp_ProductCategory_SelectOne", scon);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ProductCategoryID", string.IsNullOrEmpty(ProductCategoryID) ? dbNULL : (object)ProductCategoryID);
                SqlParameter errorCodeParam = new SqlParameter("@ErrorCode", null);
                errorCodeParam.Size = 4;
                errorCodeParam.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(errorCodeParam);
                var sda = new SqlDataAdapter(cmd);
                sda.Fill(dt);

                if (errorCodeParam.Value.ToString() != "0")
                    throw new Exception("Stored Procedure 'usp_ProductCategory_SelectOne' reported the ErrorCode : " + errorCodeParam.Value.ToString());

                return dt;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public DataTable ProductCategoryUpOrder(
            string ProductCategoryID
        )
        {
            try
            {
                var dt = new DataTable();
                var scon = new SqlConnection(connectionString);
                var cmd = new SqlCommand("usp_ProductCategory_UpOrder", scon);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ProductCategoryID", string.IsNullOrEmpty(ProductCategoryID) ? dbNULL : (object)ProductCategoryID);
                SqlParameter errorCodeParam = new SqlParameter("@ErrorCode", null);
                errorCodeParam.Size = 4;
                errorCodeParam.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(errorCodeParam);
                var sda = new SqlDataAdapter(cmd);
                sda.Fill(dt);

                if (errorCodeParam.Value.ToString() != "0")
                    throw new Exception("Stored Procedure 'usp_ProductCategory_UpOrder' reported the ErrorCode : " + errorCodeParam.Value.ToString());

                return dt;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public DataTable ProductCategoryDownOrder(
            string ProductCategoryID
        )
        {
            try
            {
                var dt = new DataTable();
                var scon = new SqlConnection(connectionString);
                var cmd = new SqlCommand("usp_ProductCategory_DownOrder", scon);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ProductCategoryID", string.IsNullOrEmpty(ProductCategoryID) ? dbNULL : (object)ProductCategoryID);
                SqlParameter errorCodeParam = new SqlParameter("@ErrorCode", null);
                errorCodeParam.Size = 4;
                errorCodeParam.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(errorCodeParam);
                var sda = new SqlDataAdapter(cmd);
                sda.Fill(dt);

                if (errorCodeParam.Value.ToString() != "0")
                    throw new Exception("Stored Procedure 'usp_ProductCategory_DownOrder' reported the ErrorCode : " + errorCodeParam.Value.ToString());

                return dt;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public bool ProductCategoryIsChildrenExist(
            string ProductCategoryID
        )
        {
            try
            {
                var scon = new SqlConnection(connectionString);
                var cmd = new SqlCommand("usp_ProductCategory_IsChildrenExist", scon);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ProductCategoryID", string.IsNullOrEmpty(ProductCategoryID) ? dbNULL : (object)ProductCategoryID);
                SqlParameter errorCodeParam = new SqlParameter("@ErrorCode", null);
                errorCodeParam.Size = 4;
                errorCodeParam.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(errorCodeParam);
                scon.Open();
                bool isExists = Convert.ToBoolean(cmd.ExecuteScalar());
                scon.Close();

                if (errorCodeParam.Value.ToString() != "0")
                    throw new Exception("Stored Procedure 'usp_ProductCategory_IsChildrenExist' reported the ErrorCode : " + errorCodeParam.Value.ToString());

                return isExists;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public DataTable ProductCategoryHierarchyToTopSelectAll(
            string CurrentProductCategoryID
        )
        {
            try
            {
                var dt = new DataTable();
                var scon = new SqlConnection(connectionString);
                var cmd = new SqlCommand("usp_ProductCategoryHierarchyToTop_SelectAll", scon);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@CurrentProductCategoryID", string.IsNullOrEmpty(CurrentProductCategoryID) ? dbNULL : (object)CurrentProductCategoryID);
                SqlParameter errorCodeParam = new SqlParameter("@ErrorCode", null);
                errorCodeParam.Size = 4;
                errorCodeParam.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(errorCodeParam);
                var sda = new SqlDataAdapter(cmd);
                sda.Fill(dt);

                if (errorCodeParam.Value.ToString() != "0")
                    throw new Exception("Stored Procedure 'usp_ProductCategoryHierarchyToTop_SelectAll' reported the ErrorCode : " + errorCodeParam.Value.ToString());

                return dt;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}

