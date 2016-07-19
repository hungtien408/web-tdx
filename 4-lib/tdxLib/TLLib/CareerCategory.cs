using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace TLLib
{
    public class CareerCategory
    {
        string connectionString = Common.ConnectionString;
        DBNull dbNULL = DBNull.Value;

        public string CareerCategoryInsert(
            string CareerCategoryName,
            string CareerCategoryNameEn,
            string ConvertedCareerCategoryName,
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
                var cmd = new SqlCommand("usp_CareerCategory_Insert", scon);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@CareerCategoryName", string.IsNullOrEmpty(CareerCategoryName) ? dbNULL : (object)CareerCategoryName);
                cmd.Parameters.AddWithValue("@CareerCategoryNameEn", string.IsNullOrEmpty(CareerCategoryNameEn) ? dbNULL : (object)CareerCategoryNameEn);
                cmd.Parameters.AddWithValue("@ConvertedCareerCategoryName", string.IsNullOrEmpty(ConvertedCareerCategoryName) ? dbNULL : (object)ConvertedCareerCategoryName);
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
                    throw new Exception("Stored Procedure 'usp_CareerCategory_Insert' reported the ErrorCode : " + errorCodeParam.Value.ToString());

                return imageNameParam.Value.ToString();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public int CareerCategoryUpdate(
            string CareerCategoryID,
            string CareerCategoryName,
            string CareerCategoryNameEn,
            string ConvertedCareerCategoryName,
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
                var cmd = new SqlCommand("usp_CareerCategory_Update", scon);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@CareerCategoryID", string.IsNullOrEmpty(CareerCategoryID) ? dbNULL : (object)CareerCategoryID);
                cmd.Parameters.AddWithValue("@CareerCategoryName", string.IsNullOrEmpty(CareerCategoryName) ? dbNULL : (object)CareerCategoryName);
                cmd.Parameters.AddWithValue("@CareerCategoryNameEn", string.IsNullOrEmpty(CareerCategoryNameEn) ? dbNULL : (object)CareerCategoryNameEn);
                cmd.Parameters.AddWithValue("@ConvertedCareerCategoryName", string.IsNullOrEmpty(ConvertedCareerCategoryName) ? dbNULL : (object)ConvertedCareerCategoryName);
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
                    throw new Exception("Stored Procedure 'usp_CareerCategory_Update' reported the ErrorCode : " + errorCodeParam.Value.ToString());

                return success;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public int CareerCategoryQuickUpdate(
            string CareerCategoryID,
            string IsShowOnMenu,
            string IsShowOnHomePage,
            string IsAvailable
        )
        {
            try
            {
                var scon = new SqlConnection(connectionString);
                var cmd = new SqlCommand("usp_CareerCategory_QuickUpdate", scon);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@CareerCategoryID", string.IsNullOrEmpty(CareerCategoryID) ? dbNULL : (object)CareerCategoryID);
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
                    throw new Exception("Stored Procedure 'usp_CareerCategory_QuickUpdate' reported the ErrorCode : " + errorCodeParam.Value.ToString());

                return success;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public int CareerCategoryDelete(
            string CareerCategoryID
        )
        {
            try
            {
                var scon = new SqlConnection(connectionString);
                var cmd = new SqlCommand("usp_CareerCategory_Delete", scon);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@CareerCategoryID", string.IsNullOrEmpty(CareerCategoryID) ? dbNULL : (object)CareerCategoryID);
                SqlParameter errorCodeParam = new SqlParameter("@ErrorCode", null);
                errorCodeParam.Size = 4;
                errorCodeParam.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(errorCodeParam);
                scon.Open();
                int success = cmd.ExecuteNonQuery();
                scon.Close();

                if (errorCodeParam.Value.ToString() != "0")
                    throw new Exception("Stored Procedure 'usp_CareerCategory_Delete' reported the ErrorCode : " + errorCodeParam.Value.ToString());

                return success;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public int CareerCategoryImageDelete(
            string CareerCategoryID
        )
        {
            try
            {
                var scon = new SqlConnection(connectionString);
                var cmd = new SqlCommand("usp_CareerCategoryImage_Delete", scon);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@CareerCategoryID", string.IsNullOrEmpty(CareerCategoryID) ? dbNULL : (object)CareerCategoryID);
                SqlParameter errorCodeParam = new SqlParameter("@ErrorCode", null);
                errorCodeParam.Size = 4;
                errorCodeParam.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(errorCodeParam);
                scon.Open();
                int success = cmd.ExecuteNonQuery();
                scon.Close();

                if (errorCodeParam.Value.ToString() != "0")
                    throw new Exception("Stored Procedure 'usp_CareerCategoryImage_Delete' reported the ErrorCode : " + errorCodeParam.Value.ToString());

                return success;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public DataTable CareerCategorySelectAll()
        {
            try
            {
                var dt = new DataTable();
                var scon = new SqlConnection(connectionString);
                var cmd = new SqlCommand("usp_CareerCategory_SelectAll", scon);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter errorCodeParam = new SqlParameter("@ErrorCode", null);
                errorCodeParam.Size = 4;
                errorCodeParam.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(errorCodeParam);
                var sda = new SqlDataAdapter(cmd);
                sda.Fill(dt);

                if (errorCodeParam.Value.ToString() != "0")
                    throw new Exception("Stored Procedure 'usp_CareerCategory_SelectAll' reported the ErrorCode : " + errorCodeParam.Value.ToString());

                Common oCommon = new Common();

                oCommon.RecursiveFillTree(dt, 0, "ParentID", "CareerCategoryName", "CareerCategoryID", "-");

                return oCommon.Tree;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public DataTable CareerCategorySelectAll(int parentID, int increaseLevelCount, string IsShowOnMenu, string IsShowOnHomePage)
        {
            try
            {
                var dt = new DataTable();
                var scon = new SqlConnection(connectionString);
                var cmd = new SqlCommand("usp_CareerCategory_SelectAll", scon);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter errorCodeParam = new SqlParameter("@ErrorCode", null);
                errorCodeParam.Size = 4;
                errorCodeParam.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(errorCodeParam);
                var sda = new SqlDataAdapter(cmd);
                sda.Fill(dt);

                if (errorCodeParam.Value.ToString() != "0")
                    throw new Exception("Stored Procedure 'usp_CareerCategory_SelectAll' reported the ErrorCode : " + errorCodeParam.Value.ToString());

                Common oCommon = new Common();

                oCommon.RecursiveFillTree(dt, parentID, "ParentID", "CareerCategoryName", "CareerCategoryID", increaseLevelCount, IsShowOnMenu, IsShowOnHomePage);

                return oCommon.Tree;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public string CareerCategoryMenuSelectAll(string href, string queryStringName, string parentID, int increaseLevelCount, bool useForeignLanguage)
        {
            try
            {
                var dt = new DataTable();
                var scon = new SqlConnection(connectionString);
                var cmd = new SqlCommand("usp_CareerCategory_SelectAll", scon);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter errorCodeParam = new SqlParameter("@ErrorCode", null);
                errorCodeParam.Size = 4;
                errorCodeParam.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(errorCodeParam);
                var sda = new SqlDataAdapter(cmd);
                sda.Fill(dt);

                if (errorCodeParam.Value.ToString() != "0")
                    throw new Exception("Stored Procedure 'usp_CareerCategory_SelectAll' reported the ErrorCode : " + errorCodeParam.Value.ToString());

                Common oCommon = new Common();

                oCommon.RecursiveFillMenuTree(
                    href,
                    queryStringName,
                    dt,
                    parentID,
                    "ParentID",
                    !useForeignLanguage ? "CareerCategoryName" : "CareerCategoryNameEn",
                    "CareerCategoryID",
                    increaseLevelCount);

                return oCommon.Menu;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public string CareerCategoryMenuSelectAll(string href, string queryStringName, string parentID, int increaseLevelCount, bool useForeignLanguage, string rootHmtlTag)
        {
            try
            {
                var dt = new DataTable();
                var scon = new SqlConnection(connectionString);
                var cmd = new SqlCommand("usp_CareerCategory_SelectAll", scon);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter errorCodeParam = new SqlParameter("@ErrorCode", null);
                errorCodeParam.Size = 4;
                errorCodeParam.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(errorCodeParam);
                var sda = new SqlDataAdapter(cmd);
                sda.Fill(dt);

                if (errorCodeParam.Value.ToString() != "0")
                    throw new Exception("Stored Procedure 'usp_CareerCategory_SelectAll' reported the ErrorCode : " + errorCodeParam.Value.ToString());

                Common oCommon = new Common();

                oCommon.RecursiveFillMenuTree(
                    href,
                    queryStringName,
                    dt,
                    parentID,
                    "ParentID",
                    !useForeignLanguage ? "CareerCategoryName" : "CareerCategoryNameEn",
                    "CareerCategoryID",
                    increaseLevelCount,
                    rootHmtlTag);

                return oCommon.Menu;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public string CareerCategoryMenuSelectAll(string href, string queryStringName, string parentID, int increaseLevelCount, bool useForeignLanguage, bool showImage, string imageFolderPath)
        {
            try
            {
                var dt = new DataTable();
                var scon = new SqlConnection(connectionString);
                var cmd = new SqlCommand("usp_CareerCategory_SelectAll", scon);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter errorCodeParam = new SqlParameter("@ErrorCode", null);
                errorCodeParam.Size = 4;
                errorCodeParam.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(errorCodeParam);
                var sda = new SqlDataAdapter(cmd);
                sda.Fill(dt);

                if (errorCodeParam.Value.ToString() != "0")
                    throw new Exception("Stored Procedure 'usp_CareerCategory_SelectAll' reported the ErrorCode : " + errorCodeParam.Value.ToString());

                Common oCommon = new Common();

                oCommon.RecursiveFillMenuTree(
                    href,
                    queryStringName,
                    dt,
                    parentID,
                    "ParentID",
                    !useForeignLanguage ? "CareerCategoryName" : "CareerCategoryNameEn",
                    "CareerCategoryID",
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

        public string CareerCategoryMenuSelectAll(string href, string queryStringName, string parentID, int increaseLevelCount, bool useForeignLanguage, string rootHmtlTag, bool showImage, string imageFolderPath)
        {
            try
            {
                var dt = new DataTable();
                var scon = new SqlConnection(connectionString);
                var cmd = new SqlCommand("usp_CareerCategory_SelectAll", scon);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter errorCodeParam = new SqlParameter("@ErrorCode", null);
                errorCodeParam.Size = 4;
                errorCodeParam.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(errorCodeParam);
                var sda = new SqlDataAdapter(cmd);
                sda.Fill(dt);

                if (errorCodeParam.Value.ToString() != "0")
                    throw new Exception("Stored Procedure 'usp_CareerCategory_SelectAll' reported the ErrorCode : " + errorCodeParam.Value.ToString());

                Common oCommon = new Common();

                oCommon.RecursiveFillMenuTree(
                    href,
                    queryStringName,
                    dt,
                    parentID,
                    "ParentID",
                    !useForeignLanguage ? "CareerCategoryName" : "CareerCategoryNameEn",
                    "CareerCategoryID",
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

        public DataTable CareerCategoryForEditSelectAll(
            string CareerCategoryID
        )
        {
            try
            {
                var dt = new DataTable();
                var scon = new SqlConnection(connectionString);
                var cmd = new SqlCommand("usp_CareerCategoryForEdit_SelectAll", scon);
                cmd.Parameters.AddWithValue("@CareerCategoryID", string.IsNullOrEmpty(CareerCategoryID) ? dbNULL : (object)CareerCategoryID);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter errorCodeParam = new SqlParameter("@ErrorCode", null);
                errorCodeParam.Size = 4;
                errorCodeParam.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(errorCodeParam);
                var sda = new SqlDataAdapter(cmd);
                sda.Fill(dt);

                if (errorCodeParam.Value.ToString() != "0")
                    throw new Exception("Stored Procedure 'usp_CareerCategoryForEdit_SelectAll' reported the ErrorCode : " + errorCodeParam.Value.ToString());

                Common oCommon = new Common();

                oCommon.RecursiveFillTree(dt, 0, "ParentID", "CareerCategoryName", "CareerCategoryID", "-");

                return oCommon.Tree;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public DataTable CareerCategorySelectOne(
            string CareerCategoryID
        )
        {
            try
            {
                var dt = new DataTable();
                var scon = new SqlConnection(connectionString);
                var cmd = new SqlCommand("usp_CareerCategory_SelectOne", scon);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@CareerCategoryID", string.IsNullOrEmpty(CareerCategoryID) ? dbNULL : (object)CareerCategoryID);
                SqlParameter errorCodeParam = new SqlParameter("@ErrorCode", null);
                errorCodeParam.Size = 4;
                errorCodeParam.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(errorCodeParam);
                var sda = new SqlDataAdapter(cmd);
                sda.Fill(dt);

                if (errorCodeParam.Value.ToString() != "0")
                    throw new Exception("Stored Procedure 'usp_CareerCategory_SelectOne' reported the ErrorCode : " + errorCodeParam.Value.ToString());

                return dt;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public DataTable CareerCategoryUpOrder(
            string CareerCategoryID
        )
        {
            try
            {
                var dt = new DataTable();
                var scon = new SqlConnection(connectionString);
                var cmd = new SqlCommand("usp_CareerCategory_UpOrder", scon);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@CareerCategoryID", string.IsNullOrEmpty(CareerCategoryID) ? dbNULL : (object)CareerCategoryID);
                SqlParameter errorCodeParam = new SqlParameter("@ErrorCode", null);
                errorCodeParam.Size = 4;
                errorCodeParam.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(errorCodeParam);
                var sda = new SqlDataAdapter(cmd);
                sda.Fill(dt);

                if (errorCodeParam.Value.ToString() != "0")
                    throw new Exception("Stored Procedure 'usp_CareerCategory_UpOrder' reported the ErrorCode : " + errorCodeParam.Value.ToString());

                return dt;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public DataTable CareerCategoryDownOrder(
            string CareerCategoryID
        )
        {
            try
            {
                var dt = new DataTable();
                var scon = new SqlConnection(connectionString);
                var cmd = new SqlCommand("usp_CareerCategory_DownOrder", scon);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@CareerCategoryID", string.IsNullOrEmpty(CareerCategoryID) ? dbNULL : (object)CareerCategoryID);
                SqlParameter errorCodeParam = new SqlParameter("@ErrorCode", null);
                errorCodeParam.Size = 4;
                errorCodeParam.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(errorCodeParam);
                var sda = new SqlDataAdapter(cmd);
                sda.Fill(dt);

                if (errorCodeParam.Value.ToString() != "0")
                    throw new Exception("Stored Procedure 'usp_CareerCategory_DownOrder' reported the ErrorCode : " + errorCodeParam.Value.ToString());

                return dt;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public bool CareerCategoryIsChildrenExist(
            string CareerCategoryID
        )
        {
            try
            {
                var scon = new SqlConnection(connectionString);
                var cmd = new SqlCommand("usp_CareerCategory_IsChildrenExist", scon);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@CareerCategoryID", string.IsNullOrEmpty(CareerCategoryID) ? dbNULL : (object)CareerCategoryID);
                SqlParameter errorCodeParam = new SqlParameter("@ErrorCode", null);
                errorCodeParam.Size = 4;
                errorCodeParam.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(errorCodeParam);
                scon.Open();
                bool isExists = Convert.ToBoolean(cmd.ExecuteScalar());
                scon.Close();

                if (errorCodeParam.Value.ToString() != "0")
                    throw new Exception("Stored Procedure 'usp_CareerCategory_IsChildrenExist' reported the ErrorCode : " + errorCodeParam.Value.ToString());

                return isExists;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public DataTable CareerCategoryHierarchyToTopSelectAll(
            string CurrentCareerCategoryID
        )
        {
            try
            {
                var dt = new DataTable();
                var scon = new SqlConnection(connectionString);
                var cmd = new SqlCommand("usp_CareerCategoryHierarchyToTop_SelectAll", scon);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@CurrentCareerCategoryID", string.IsNullOrEmpty(CurrentCareerCategoryID) ? dbNULL : (object)CurrentCareerCategoryID);
                SqlParameter errorCodeParam = new SqlParameter("@ErrorCode", null);
                errorCodeParam.Size = 4;
                errorCodeParam.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(errorCodeParam);
                var sda = new SqlDataAdapter(cmd);
                sda.Fill(dt);

                if (errorCodeParam.Value.ToString() != "0")
                    throw new Exception("Stored Procedure 'usp_CareerCategoryHierarchyToTop_SelectAll' reported the ErrorCode : " + errorCodeParam.Value.ToString());

                return dt;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}

