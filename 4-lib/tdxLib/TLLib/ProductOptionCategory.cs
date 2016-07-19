using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace TLLib
{
    public class ProductOptionCategory
    {
        string connectionString = Common.ConnectionString;
        DBNull dbNULL = DBNull.Value;

        public string ProductOptionCategoryInsert(
            string ProductOptionCategoryName,
            string ProductOptionCategoryNameEn,
            string ConvertedProductOptionCategoryName,
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
            string IsAvailable,
            string ProductID
        )
        {
            try
            {
                var scon = new SqlConnection(connectionString);
                var cmd = new SqlCommand("usp_ProductOptionCategory_Insert", scon);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ProductOptionCategoryName", string.IsNullOrEmpty(ProductOptionCategoryName) ? dbNULL : (object)ProductOptionCategoryName);
                cmd.Parameters.AddWithValue("@ProductOptionCategoryNameEn", string.IsNullOrEmpty(ProductOptionCategoryNameEn) ? dbNULL : (object)ProductOptionCategoryNameEn);
                cmd.Parameters.AddWithValue("@ConvertedProductOptionCategoryName", string.IsNullOrEmpty(ConvertedProductOptionCategoryName) ? dbNULL : (object)ConvertedProductOptionCategoryName);
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
                cmd.Parameters.AddWithValue("@ProductID", string.IsNullOrEmpty(ProductID) ? dbNULL : (object)ProductID);

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
                    throw new Exception("Stored Procedure 'usp_ProductOptionCategory_Insert' reported the ErrorCode : " + errorCodeParam.Value.ToString());

                return imageNameParam.Value.ToString();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public int ProductOptionCategoryUpdate(
            string ProductOptionCategoryID,
            string ProductOptionCategoryName,
            string ProductOptionCategoryNameEn,
            string ConvertedProductOptionCategoryName,
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
            string IsAvailable,
            string ProductID
        )
        {
            try
            {
                var scon = new SqlConnection(connectionString);
                var cmd = new SqlCommand("usp_ProductOptionCategory_Update", scon);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ProductOptionCategoryID", string.IsNullOrEmpty(ProductOptionCategoryID) ? dbNULL : (object)ProductOptionCategoryID);
                cmd.Parameters.AddWithValue("@ProductOptionCategoryName", string.IsNullOrEmpty(ProductOptionCategoryName) ? dbNULL : (object)ProductOptionCategoryName);
                cmd.Parameters.AddWithValue("@ProductOptionCategoryNameEn", string.IsNullOrEmpty(ProductOptionCategoryNameEn) ? dbNULL : (object)ProductOptionCategoryNameEn);
                cmd.Parameters.AddWithValue("@ConvertedProductOptionCategoryName", string.IsNullOrEmpty(ConvertedProductOptionCategoryName) ? dbNULL : (object)ConvertedProductOptionCategoryName);
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
                cmd.Parameters.AddWithValue("@ProductID", string.IsNullOrEmpty(ProductID) ? dbNULL : (object)ProductID);

                SqlParameter errorCodeParam = new SqlParameter("@ErrorCode", null);
                errorCodeParam.Size = 4;
                errorCodeParam.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(errorCodeParam);
                scon.Open();
                int success = cmd.ExecuteNonQuery();
                scon.Close();

                if (errorCodeParam.Value.ToString() != "0")
                    throw new Exception("Stored Procedure 'usp_ProductOptionCategory_Update' reported the ErrorCode : " + errorCodeParam.Value.ToString());

                return success;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public int ProductOptionCategoryQuickUpdate(
            string ProductOptionCategoryID,
            string IsShowOnMenu,
            string IsShowOnHomePage,
            string IsAvailable
        )
        {
            try
            {
                var scon = new SqlConnection(connectionString);
                var cmd = new SqlCommand("usp_ProductOptionCategory_QuickUpdate", scon);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ProductOptionCategoryID", string.IsNullOrEmpty(ProductOptionCategoryID) ? dbNULL : (object)ProductOptionCategoryID);
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
                    throw new Exception("Stored Procedure 'usp_ProductOptionCategory_QuickUpdate' reported the ErrorCode : " + errorCodeParam.Value.ToString());

                return success;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public int ProductOptionCategoryDelete(
            string ProductOptionCategoryID
        )
        {
            try
            {
                var scon = new SqlConnection(connectionString);
                var cmd = new SqlCommand("usp_ProductOptionCategory_Delete", scon);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ProductOptionCategoryID", string.IsNullOrEmpty(ProductOptionCategoryID) ? dbNULL : (object)ProductOptionCategoryID);
                SqlParameter errorCodeParam = new SqlParameter("@ErrorCode", null);
                errorCodeParam.Size = 4;
                errorCodeParam.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(errorCodeParam);
                scon.Open();
                int success = cmd.ExecuteNonQuery();
                scon.Close();

                if (errorCodeParam.Value.ToString() != "0")
                    throw new Exception("Stored Procedure 'usp_ProductOptionCategory_Delete' reported the ErrorCode : " + errorCodeParam.Value.ToString());

                return success;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public int ProductOptionCategoryImageDelete(
            string ProductOptionCategoryID
        )
        {
            try
            {
                var scon = new SqlConnection(connectionString);
                var cmd = new SqlCommand("usp_ProductOptionCategoryImage_Delete", scon);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ProductOptionCategoryID", string.IsNullOrEmpty(ProductOptionCategoryID) ? dbNULL : (object)ProductOptionCategoryID);
                SqlParameter errorCodeParam = new SqlParameter("@ErrorCode", null);
                errorCodeParam.Size = 4;
                errorCodeParam.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(errorCodeParam);
                scon.Open();
                int success = cmd.ExecuteNonQuery();
                scon.Close();

                if (errorCodeParam.Value.ToString() != "0")
                    throw new Exception("Stored Procedure 'usp_ProductOptionCategoryImage_Delete' reported the ErrorCode : " + errorCodeParam.Value.ToString());

                return success;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public DataTable ProductOptionCategorySelectAll1(
            string IsShowOnMenu,
            string IsShowOnHomePage,
            string IsAvailable,
            string ProductID
        )
        {
            try
            {
                var dt = new DataTable();
                var scon = new SqlConnection(connectionString);
                var cmd = new SqlCommand("usp_ProductOptionCategory_SelectAll1", scon);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@IsShowOnMenu", string.IsNullOrEmpty(IsShowOnMenu) ? dbNULL : (object)IsShowOnMenu);
                cmd.Parameters.AddWithValue("@IsShowOnHomePage", string.IsNullOrEmpty(IsShowOnHomePage) ? dbNULL : (object)IsShowOnHomePage);
                cmd.Parameters.AddWithValue("@IsAvailable", string.IsNullOrEmpty(IsAvailable) ? dbNULL : (object)IsAvailable);
                cmd.Parameters.AddWithValue("@ProductID", string.IsNullOrEmpty(ProductID) ? dbNULL : (object)ProductID);

                SqlParameter errorCodeParam = new SqlParameter("@ErrorCode", null);
                errorCodeParam.Size = 4;
                errorCodeParam.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(errorCodeParam);
                var sda = new SqlDataAdapter(cmd);
                sda.Fill(dt);

                if (errorCodeParam.Value.ToString() != "0")
                    throw new Exception("Stored Procedure 'usp_ProductOptionCategory_SelectAll1' reported the ErrorCode : " + errorCodeParam.Value.ToString());

                return dt;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public DataTable ProductOptionCategorySelectAll(int parentID, int increaseLevelCount, string IsShowOnMenu, string IsShowOnHomePage, string ProductID)
        {
            try
            {
                var dt = new DataTable();
                var scon = new SqlConnection(connectionString);
                var cmd = new SqlCommand("usp_ProductOptionCategory_SelectAll", scon);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter errorCodeParam = new SqlParameter("@ErrorCode", null);
                errorCodeParam.Size = 4;
                errorCodeParam.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(errorCodeParam);
                var sda = new SqlDataAdapter(cmd);
                sda.Fill(dt);

                if (errorCodeParam.Value.ToString() != "0")
                    throw new Exception("Stored Procedure 'usp_ProductOptionCategory_SelectAll' reported the ErrorCode : " + errorCodeParam.Value.ToString());

                Common oCommon = new Common();

                oCommon.RecursiveFillTree(dt, parentID, "ParentID", "ProductOptionCategoryName", "ProductOptionCategoryID", increaseLevelCount, IsShowOnMenu, IsShowOnHomePage, ProductID);

                return oCommon.Tree;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public DataTable ProductOptionCategorySelectAll()
        {
            try
            {
                var dt = new DataTable();
                var scon = new SqlConnection(connectionString);
                var cmd = new SqlCommand("usp_ProductOptionCategory_SelectAll", scon);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter errorCodeParam = new SqlParameter("@ErrorCode", null);
                errorCodeParam.Size = 4;
                errorCodeParam.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(errorCodeParam);
                var sda = new SqlDataAdapter(cmd);
                sda.Fill(dt);

                if (errorCodeParam.Value.ToString() != "0")
                    throw new Exception("Stored Procedure 'usp_ProductOptionCategory_SelectAll' reported the ErrorCode : " + errorCodeParam.Value.ToString());

                Common oCommon = new Common();

                oCommon.RecursiveFillTree(dt, 0, "ParentID", "ProductOptionCategoryName", "ProductOptionCategoryID", "-");

                return oCommon.Tree;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public DataTable ProductOptionCategorySelectAll(int parentID, int increaseLevelCount, string IsShowOnMenu, string IsShowOnHomePage)
        {
            try
            {
                var dt = new DataTable();
                var scon = new SqlConnection(connectionString);
                var cmd = new SqlCommand("usp_ProductOptionCategory_SelectAll", scon);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter errorCodeParam = new SqlParameter("@ErrorCode", null);
                errorCodeParam.Size = 4;
                errorCodeParam.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(errorCodeParam);
                var sda = new SqlDataAdapter(cmd);
                sda.Fill(dt);

                if (errorCodeParam.Value.ToString() != "0")
                    throw new Exception("Stored Procedure 'usp_ProductOptionCategory_SelectAll' reported the ErrorCode : " + errorCodeParam.Value.ToString());

                Common oCommon = new Common();

                oCommon.RecursiveFillTree(dt, parentID, "ParentID", "ProductOptionCategoryName", "ProductOptionCategoryID", increaseLevelCount, IsShowOnMenu, IsShowOnHomePage);

                return oCommon.Tree;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public string ProductOptionCategoryMenuSelectAll(string href, string queryStringName, string parentID, int increaseLevelCount, bool useForeignLanguage)
        {
            try
            {
                var dt = new DataTable();
                var scon = new SqlConnection(connectionString);
                var cmd = new SqlCommand("usp_ProductOptionCategory_SelectAll", scon);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter errorCodeParam = new SqlParameter("@ErrorCode", null);
                errorCodeParam.Size = 4;
                errorCodeParam.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(errorCodeParam);
                var sda = new SqlDataAdapter(cmd);
                sda.Fill(dt);

                if (errorCodeParam.Value.ToString() != "0")
                    throw new Exception("Stored Procedure 'usp_ProductOptionCategory_SelectAll' reported the ErrorCode : " + errorCodeParam.Value.ToString());

                Common oCommon = new Common();

                oCommon.RecursiveFillMenuTree(
                    href,
                    queryStringName,
                    dt,
                    parentID,
                    "ParentID",
                    !useForeignLanguage ? "ProductOptionCategoryName" : "ProductOptionCategoryNameEn",
                    "ProductOptionCategoryID",
                    increaseLevelCount);

                return oCommon.Menu;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public string ProductOptionCategoryMenuSelectAll(string href, string queryStringName, string parentID, int increaseLevelCount, bool useForeignLanguage, string rootHmtlTag)
        {
            try
            {
                var dt = new DataTable();
                var scon = new SqlConnection(connectionString);
                var cmd = new SqlCommand("usp_ProductOptionCategory_SelectAll", scon);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter errorCodeParam = new SqlParameter("@ErrorCode", null);
                errorCodeParam.Size = 4;
                errorCodeParam.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(errorCodeParam);
                var sda = new SqlDataAdapter(cmd);
                sda.Fill(dt);

                if (errorCodeParam.Value.ToString() != "0")
                    throw new Exception("Stored Procedure 'usp_ProductOptionCategory_SelectAll' reported the ErrorCode : " + errorCodeParam.Value.ToString());

                Common oCommon = new Common();

                oCommon.RecursiveFillMenuTree(
                    href,
                    queryStringName,
                    dt,
                    parentID,
                    "ParentID",
                    !useForeignLanguage ? "ProductOptionCategoryName" : "ProductOptionCategoryNameEn",
                    "ProductOptionCategoryID",
                    increaseLevelCount,
                    rootHmtlTag);

                return oCommon.Menu;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public string ProductOptionCategoryMenuSelectAll(string href, string queryStringName, string parentID, int increaseLevelCount, bool useForeignLanguage, bool showImage, string imageFolderPath)
        {
            try
            {
                var dt = new DataTable();
                var scon = new SqlConnection(connectionString);
                var cmd = new SqlCommand("usp_ProductOptionCategory_SelectAll", scon);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter errorCodeParam = new SqlParameter("@ErrorCode", null);
                errorCodeParam.Size = 4;
                errorCodeParam.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(errorCodeParam);
                var sda = new SqlDataAdapter(cmd);
                sda.Fill(dt);

                if (errorCodeParam.Value.ToString() != "0")
                    throw new Exception("Stored Procedure 'usp_ProductOptionCategory_SelectAll' reported the ErrorCode : " + errorCodeParam.Value.ToString());

                Common oCommon = new Common();

                oCommon.RecursiveFillMenuTree(
                    href,
                    queryStringName,
                    dt,
                    parentID,
                    "ParentID",
                    !useForeignLanguage ? "ProductOptionCategoryName" : "ProductOptionCategoryNameEn",
                    "ProductOptionCategoryID",
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

        public string ProductOptionCategoryMenuSelectAll(string href, string queryStringName, string parentID, int increaseLevelCount, bool useForeignLanguage, string rootHmtlTag, bool showImage, string imageFolderPath)
        {
            try
            {
                var dt = new DataTable();
                var scon = new SqlConnection(connectionString);
                var cmd = new SqlCommand("usp_ProductOptionCategory_SelectAll", scon);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter errorCodeParam = new SqlParameter("@ErrorCode", null);
                errorCodeParam.Size = 4;
                errorCodeParam.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(errorCodeParam);
                var sda = new SqlDataAdapter(cmd);
                sda.Fill(dt);

                if (errorCodeParam.Value.ToString() != "0")
                    throw new Exception("Stored Procedure 'usp_ProductOptionCategory_SelectAll' reported the ErrorCode : " + errorCodeParam.Value.ToString());

                Common oCommon = new Common();

                oCommon.RecursiveFillMenuTree(
                    href,
                    queryStringName,
                    dt,
                    parentID,
                    "ParentID",
                    !useForeignLanguage ? "ProductOptionCategoryName" : "ProductOptionCategoryNameEn",
                    "ProductOptionCategoryID",
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

        public DataTable ProductOptionCategoryForEditSelectAll(
            string ProductOptionCategoryID
        )
        {
            try
            {
                var dt = new DataTable();
                var scon = new SqlConnection(connectionString);
                var cmd = new SqlCommand("usp_ProductOptionCategoryForEdit_SelectAll", scon);
                cmd.Parameters.AddWithValue("@ProductOptionCategoryID", string.IsNullOrEmpty(ProductOptionCategoryID) ? dbNULL : (object)ProductOptionCategoryID);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter errorCodeParam = new SqlParameter("@ErrorCode", null);
                errorCodeParam.Size = 4;
                errorCodeParam.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(errorCodeParam);
                var sda = new SqlDataAdapter(cmd);
                sda.Fill(dt);

                if (errorCodeParam.Value.ToString() != "0")
                    throw new Exception("Stored Procedure 'usp_ProductOptionCategoryForEdit_SelectAll' reported the ErrorCode : " + errorCodeParam.Value.ToString());

                Common oCommon = new Common();

                oCommon.RecursiveFillTree(dt, 0, "ParentID", "ProductOptionCategoryName", "ProductOptionCategoryID", "-");

                return oCommon.Tree;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public DataTable ProductOptionCategorySelectOne(
            string ProductOptionCategoryID
        )
        {
            try
            {
                var dt = new DataTable();
                var scon = new SqlConnection(connectionString);
                var cmd = new SqlCommand("usp_ProductOptionCategory_SelectOne", scon);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ProductOptionCategoryID", string.IsNullOrEmpty(ProductOptionCategoryID) ? dbNULL : (object)ProductOptionCategoryID);
                SqlParameter errorCodeParam = new SqlParameter("@ErrorCode", null);
                errorCodeParam.Size = 4;
                errorCodeParam.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(errorCodeParam);
                var sda = new SqlDataAdapter(cmd);
                sda.Fill(dt);

                if (errorCodeParam.Value.ToString() != "0")
                    throw new Exception("Stored Procedure 'usp_ProductOptionCategory_SelectOne' reported the ErrorCode : " + errorCodeParam.Value.ToString());

                return dt;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public DataTable ProductOptionCategoryUpOrder(
            string ProductOptionCategoryID
        )
        {
            try
            {
                var dt = new DataTable();
                var scon = new SqlConnection(connectionString);
                var cmd = new SqlCommand("usp_ProductOptionCategory_UpOrder", scon);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ProductOptionCategoryID", string.IsNullOrEmpty(ProductOptionCategoryID) ? dbNULL : (object)ProductOptionCategoryID);
                SqlParameter errorCodeParam = new SqlParameter("@ErrorCode", null);
                errorCodeParam.Size = 4;
                errorCodeParam.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(errorCodeParam);
                var sda = new SqlDataAdapter(cmd);
                sda.Fill(dt);

                if (errorCodeParam.Value.ToString() != "0")
                    throw new Exception("Stored Procedure 'usp_ProductOptionCategory_UpOrder' reported the ErrorCode : " + errorCodeParam.Value.ToString());

                return dt;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public DataTable ProductOptionCategoryDownOrder(
            string ProductOptionCategoryID
        )
        {
            try
            {
                var dt = new DataTable();
                var scon = new SqlConnection(connectionString);
                var cmd = new SqlCommand("usp_ProductOptionCategory_DownOrder", scon);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ProductOptionCategoryID", string.IsNullOrEmpty(ProductOptionCategoryID) ? dbNULL : (object)ProductOptionCategoryID);
                SqlParameter errorCodeParam = new SqlParameter("@ErrorCode", null);
                errorCodeParam.Size = 4;
                errorCodeParam.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(errorCodeParam);
                var sda = new SqlDataAdapter(cmd);
                sda.Fill(dt);

                if (errorCodeParam.Value.ToString() != "0")
                    throw new Exception("Stored Procedure 'usp_ProductOptionCategory_DownOrder' reported the ErrorCode : " + errorCodeParam.Value.ToString());

                return dt;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public bool ProductOptionCategoryIsChildrenExist(
            string ProductOptionCategoryID
        )
        {
            try
            {
                var scon = new SqlConnection(connectionString);
                var cmd = new SqlCommand("usp_ProductOptionCategory_IsChildrenExist", scon);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ProductOptionCategoryID", string.IsNullOrEmpty(ProductOptionCategoryID) ? dbNULL : (object)ProductOptionCategoryID);
                SqlParameter errorCodeParam = new SqlParameter("@ErrorCode", null);
                errorCodeParam.Size = 4;
                errorCodeParam.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(errorCodeParam);
                scon.Open();
                bool isExists = Convert.ToBoolean(cmd.ExecuteScalar());
                scon.Close();

                if (errorCodeParam.Value.ToString() != "0")
                    throw new Exception("Stored Procedure 'usp_ProductOptionCategory_IsChildrenExist' reported the ErrorCode : " + errorCodeParam.Value.ToString());

                return isExists;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public DataTable ProductOptionCategoryHierarchyToTopSelectAll(
            string CurrentProductOptionCategoryID
        )
        {
            try
            {
                var dt = new DataTable();
                var scon = new SqlConnection(connectionString);
                var cmd = new SqlCommand("usp_ProductOptionCategoryHierarchyToTop_SelectAll", scon);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@CurrentProductOptionCategoryID", string.IsNullOrEmpty(CurrentProductOptionCategoryID) ? dbNULL : (object)CurrentProductOptionCategoryID);
                SqlParameter errorCodeParam = new SqlParameter("@ErrorCode", null);
                errorCodeParam.Size = 4;
                errorCodeParam.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(errorCodeParam);
                var sda = new SqlDataAdapter(cmd);
                sda.Fill(dt);

                if (errorCodeParam.Value.ToString() != "0")
                    throw new Exception("Stored Procedure 'usp_ProductOptionCategoryHierarchyToTop_SelectAll' reported the ErrorCode : " + errorCodeParam.Value.ToString());

                return dt;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}

