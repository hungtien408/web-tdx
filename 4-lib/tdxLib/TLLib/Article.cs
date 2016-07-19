using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace TLLib
{
    public class Article
    {
        string connectionString = Common.ConnectionString;
        DBNull dbNULL = DBNull.Value;

        public string ArticleInsert(
            string ImageName,
            string MetaTittle,
	        string MetaDescription,
            string ArticleTitle,
            string ConvertedArticleTitle,
            string Description,
            string Content,
            string Tag,
            string MetaTittleEn,
            string MetaDescriptionEn,
            string ArticleTitleEn,
            string DescriptionEn,
            string ContentEn,
            string TagEn,
            string ArticleCategoryID,
            string IsShowOnHomePage,
            string IsHot,
            string IsNew,
            string IsAvailable,
            string Priority
        )
        {
            try
            {
                var scon = new SqlConnection(connectionString);
                var cmd = new SqlCommand("usp_Article_Insert", scon);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ImageName", string.IsNullOrEmpty(ImageName) ? dbNULL : (object)ImageName);
                cmd.Parameters.AddWithValue("@MetaTittle", string.IsNullOrEmpty(MetaTittle) ? dbNULL : (object)MetaTittle);
                cmd.Parameters.AddWithValue("@MetaDescription", string.IsNullOrEmpty(MetaDescription) ? dbNULL : (object)MetaDescription);
                cmd.Parameters.AddWithValue("@ArticleTitle", string.IsNullOrEmpty(ArticleTitle) ? dbNULL : (object)ArticleTitle);
                cmd.Parameters.AddWithValue("@ConvertedArticleTitle", string.IsNullOrEmpty(ConvertedArticleTitle) ? dbNULL : (object)ConvertedArticleTitle);
                cmd.Parameters.AddWithValue("@Description", string.IsNullOrEmpty(Description) ? dbNULL : (object)Description);
                cmd.Parameters.AddWithValue("@Content", string.IsNullOrEmpty(Content) ? dbNULL : (object)Content);
                cmd.Parameters.AddWithValue("@Tag", string.IsNullOrEmpty(Tag) ? dbNULL : (object)Tag);
                cmd.Parameters.AddWithValue("@MetaTittleEn", string.IsNullOrEmpty(MetaTittleEn) ? dbNULL : (object)MetaTittleEn);
                cmd.Parameters.AddWithValue("@MetaDescriptionEn", string.IsNullOrEmpty(MetaDescriptionEn) ? dbNULL : (object)MetaDescriptionEn);
                cmd.Parameters.AddWithValue("@ArticleTitleEn", string.IsNullOrEmpty(ArticleTitleEn) ? dbNULL : (object)ArticleTitleEn);
                cmd.Parameters.AddWithValue("@DescriptionEn", string.IsNullOrEmpty(DescriptionEn) ? dbNULL : (object)DescriptionEn);
                cmd.Parameters.AddWithValue("@ContentEn", string.IsNullOrEmpty(ContentEn) ? dbNULL : (object)ContentEn);
                cmd.Parameters.AddWithValue("@TagEn", string.IsNullOrEmpty(TagEn) ? dbNULL : (object)TagEn);
                cmd.Parameters.AddWithValue("@ArticleCategoryID", string.IsNullOrEmpty(ArticleCategoryID) ? dbNULL : (object)ArticleCategoryID);
                cmd.Parameters.AddWithValue("@IsShowOnHomePage", string.IsNullOrEmpty(IsShowOnHomePage) ? dbNULL : (object)IsShowOnHomePage);
                cmd.Parameters.AddWithValue("@IsHot", string.IsNullOrEmpty(IsHot) ? dbNULL : (object)IsHot);
                cmd.Parameters.AddWithValue("@IsNew", string.IsNullOrEmpty(IsNew) ? dbNULL : (object)IsNew);
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
                    throw new Exception("Stored Procedure 'usp_Article_Insert' reported the ErrorCode : " + errorCodeParam.Value.ToString());

                return imageNameParam.Value.ToString();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public int ArticleUpdate(
            string ImageName,
            string ArticleID,
            string MetaTittle,
            string MetaDescription,
            string ArticleTitle,
            string ConvertedArticleTitle,
            string Description,
            string Content,
            string Tag,
            string MetaTittleEn,
            string MetaDescriptionEn,
            string ArticleTitleEn,
            string DescriptionEn,
            string ContentEn,
            string TagEn,
            string ArticleCategoryID,
            string IsShowOnHomePage,
            string IsHot,
            string IsNew,
            string IsAvailable,
            string Priority
        )
        {
            try
            {
                var scon = new SqlConnection(connectionString);
                var cmd = new SqlCommand("usp_Article_Update", scon);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ArticleID", string.IsNullOrEmpty(ArticleID) ? dbNULL : (object)ArticleID);
                cmd.Parameters.AddWithValue("@MetaTittle", string.IsNullOrEmpty(MetaTittle) ? dbNULL : (object)MetaTittle);
                cmd.Parameters.AddWithValue("@MetaDescription", string.IsNullOrEmpty(MetaDescription) ? dbNULL : (object)MetaDescription);
                cmd.Parameters.AddWithValue("@ArticleTitle", string.IsNullOrEmpty(ArticleTitle) ? dbNULL : (object)ArticleTitle);
                cmd.Parameters.AddWithValue("@ConvertedArticleTitle", string.IsNullOrEmpty(ConvertedArticleTitle) ? dbNULL : (object)ConvertedArticleTitle);
                cmd.Parameters.AddWithValue("@ImageName", string.IsNullOrEmpty(ImageName) ? dbNULL : (object)ImageName);
                cmd.Parameters.AddWithValue("@Description", string.IsNullOrEmpty(Description) ? dbNULL : (object)Description);
                cmd.Parameters.AddWithValue("@Content", string.IsNullOrEmpty(Content) ? dbNULL : (object)Content);
                cmd.Parameters.AddWithValue("@Tag", string.IsNullOrEmpty(Tag) ? dbNULL : (object)Tag);
                cmd.Parameters.AddWithValue("@MetaTittleEn", string.IsNullOrEmpty(MetaTittleEn) ? dbNULL : (object)MetaTittleEn);
                cmd.Parameters.AddWithValue("@MetaDescriptionEn", string.IsNullOrEmpty(MetaDescriptionEn) ? dbNULL : (object)MetaDescriptionEn);
                cmd.Parameters.AddWithValue("@ArticleTitleEn", string.IsNullOrEmpty(ArticleTitleEn) ? dbNULL : (object)ArticleTitleEn);
                cmd.Parameters.AddWithValue("@DescriptionEn", string.IsNullOrEmpty(DescriptionEn) ? dbNULL : (object)DescriptionEn);
                cmd.Parameters.AddWithValue("@ContentEn", string.IsNullOrEmpty(ContentEn) ? dbNULL : (object)ContentEn);
                cmd.Parameters.AddWithValue("@TagEn", string.IsNullOrEmpty(TagEn) ? dbNULL : (object)TagEn);
                cmd.Parameters.AddWithValue("@ArticleCategoryID", string.IsNullOrEmpty(ArticleCategoryID) ? dbNULL : (object)ArticleCategoryID);
                cmd.Parameters.AddWithValue("@IsShowOnHomePage", string.IsNullOrEmpty(IsShowOnHomePage) ? dbNULL : (object)IsShowOnHomePage);
                cmd.Parameters.AddWithValue("@IsHot", string.IsNullOrEmpty(IsHot) ? dbNULL : (object)IsHot);
                cmd.Parameters.AddWithValue("@IsNew", string.IsNullOrEmpty(IsNew) ? dbNULL : (object)IsNew);
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
                    throw new Exception("Stored Procedure 'usp_Article_Update' reported the ErrorCode : " + errorCodeParam.Value.ToString());

                return success;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public int ArticleQuickUpdate(
            string ArticleID,
            string IsShowOnHomePage,
            string IsHot,
            string IsNew,
            string IsAvailable,
            string Priority
        )
        {
            try
            {
                var scon = new SqlConnection(connectionString);
                var cmd = new SqlCommand("usp_Article_QuickUpdate", scon);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ArticleID", string.IsNullOrEmpty(ArticleID) ? dbNULL : (object)ArticleID);
                cmd.Parameters.AddWithValue("@IsShowOnHomePage", string.IsNullOrEmpty(IsShowOnHomePage) ? dbNULL : (object)IsShowOnHomePage);
                cmd.Parameters.AddWithValue("@IsHot", string.IsNullOrEmpty(IsHot) ? dbNULL : (object)IsHot);
                cmd.Parameters.AddWithValue("@IsNew", string.IsNullOrEmpty(IsNew) ? dbNULL : (object)IsNew);
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
                    throw new Exception("Stored Procedure 'usp_Article_QuickUpdate' reported the ErrorCode : " + errorCodeParam.Value.ToString());

                return success;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public int ArticleDelete(
            string ArticleID
        )
        {
            try
            {
                var scon = new SqlConnection(connectionString);
                var cmd = new SqlCommand("usp_Article_Delete", scon);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ArticleID", string.IsNullOrEmpty(ArticleID) ? dbNULL : (object)ArticleID);
                SqlParameter errorCodeParam = new SqlParameter("@ErrorCode", null);
                errorCodeParam.Size = 4;
                errorCodeParam.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(errorCodeParam);
                scon.Open();
                int success = cmd.ExecuteNonQuery();
                scon.Close();

                if (errorCodeParam.Value.ToString() != "0")
                    throw new Exception("Stored Procedure 'usp_Article_Delete' reported the ErrorCode : " + errorCodeParam.Value.ToString());

                return success;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public DataTable ArticleSelectAll(
            string StartRowIndex,
            string EndRowIndex,
            string Keyword,
            string ArticleTitle,
            string Description,
            string ArticleCategoryID,
            string Tag,
            string IsShowOnHomePage,
            string IsHot,
            string IsNew,
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
                var cmd = new SqlCommand("usp_Article_SelectAll", scon);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@StartRowIndex", string.IsNullOrEmpty(StartRowIndex) ? dbNULL : (object)StartRowIndex);
                cmd.Parameters.AddWithValue("@EndRowIndex", string.IsNullOrEmpty(EndRowIndex) ? dbNULL : (object)EndRowIndex);
                cmd.Parameters.AddWithValue("@Keyword", string.IsNullOrEmpty(Keyword) ? dbNULL : (object)Keyword);
                cmd.Parameters.AddWithValue("@ArticleTitle", string.IsNullOrEmpty(ArticleTitle) ? dbNULL : (object)ArticleTitle.Trim());
                cmd.Parameters.AddWithValue("@Description", string.IsNullOrEmpty(Description) ? dbNULL : (object)Description.Trim());
                cmd.Parameters.AddWithValue("@ArticleCategoryID", string.IsNullOrEmpty(ArticleCategoryID) ? dbNULL : (object)ArticleCategoryID);
                cmd.Parameters.AddWithValue("@Tag", string.IsNullOrEmpty(Tag) ? dbNULL : (object)Tag);
                cmd.Parameters.AddWithValue("@IsShowOnHomePage", string.IsNullOrEmpty(IsShowOnHomePage) ? dbNULL : (object)IsShowOnHomePage);
                cmd.Parameters.AddWithValue("@IsHot", string.IsNullOrEmpty(IsHot) ? dbNULL : (object)IsHot);
                cmd.Parameters.AddWithValue("@IsNew", string.IsNullOrEmpty(IsNew) ? dbNULL : (object)IsNew);
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
                    throw new Exception("Stored Procedure 'usp_Article_SelectAll' reported the ErrorCode : " + errorCodeParam.Value.ToString());

                return dt;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public DataTable ArticleSameSelectAll(
            string RerultCount,
            string ArticleID
        )
        {
            try
            {
                var dt = new DataTable();
                var scon = new SqlConnection(connectionString);
                var cmd = new SqlCommand("usp_SameArticle_SelectAll", scon);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@RerultCount", string.IsNullOrEmpty(RerultCount) ? dbNULL : (object)RerultCount);
                cmd.Parameters.AddWithValue("@ArticleID", string.IsNullOrEmpty(ArticleID) ? dbNULL : (object)ArticleID);

                SqlParameter errorCodeParam = new SqlParameter("@ErrorCode", null);
                errorCodeParam.Size = 4;
                errorCodeParam.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(errorCodeParam);
                var sda = new SqlDataAdapter(cmd);
                sda.Fill(dt);

                if (errorCodeParam.Value.ToString() != "0")
                    throw new Exception("Stored Procedure 'usp_SameArticle_SelectAll' reported the ErrorCode : " + errorCodeParam.Value.ToString());

                return dt;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public DataTable ArticleSelectOne(
            string ArticleID
        )
        {
            try
            {
                var dt = new DataTable();
                var scon = new SqlConnection(connectionString);
                var cmd = new SqlCommand("usp_Article_SelectOne", scon);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ArticleID", string.IsNullOrEmpty(ArticleID) ? dbNULL : (object)ArticleID);
                SqlParameter errorCodeParam = new SqlParameter("@ErrorCode", null);
                errorCodeParam.Size = 4;
                errorCodeParam.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(errorCodeParam);
                var sda = new SqlDataAdapter(cmd);
                sda.Fill(dt);

                if (errorCodeParam.Value.ToString() != "0")
                    throw new Exception("Stored Procedure 'usp_Article_SelectOne' reported the ErrorCode : " + errorCodeParam.Value.ToString());

                return dt;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public int ArticleImageDelete(
            string ArticleID
        )
        {
            try
            {
                var scon = new SqlConnection(connectionString);
                var cmd = new SqlCommand("usp_ArticleImage_Delete", scon);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ArticleID", string.IsNullOrEmpty(ArticleID) ? dbNULL : (object)ArticleID);
                SqlParameter errorCodeParam = new SqlParameter("@ErrorCode", null);
                errorCodeParam.Size = 4;
                errorCodeParam.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(errorCodeParam);
                scon.Open();
                int success = cmd.ExecuteNonQuery();
                scon.Close();

                if (errorCodeParam.Value.ToString() != "0")
                    throw new Exception("Stored Procedure 'usp_ArticleImage_Delete' reported the ErrorCode : " + errorCodeParam.Value.ToString());

                return success;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public DataTable ArticleNewerSelectAll(
            string RerultCount,
            string ArticleID
        )
        {
            try
            {
                var dt = new DataTable();
                var scon = new SqlConnection(connectionString);
                var cmd = new SqlCommand("usp_NewerArticle_SelectAll", scon);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@RerultCount", string.IsNullOrEmpty(RerultCount) ? dbNULL : (object)RerultCount);
                cmd.Parameters.AddWithValue("@ArticleID", string.IsNullOrEmpty(ArticleID) ? dbNULL : (object)ArticleID);

                SqlParameter errorCodeParam = new SqlParameter("@ErrorCode", null);
                errorCodeParam.Size = 4;
                errorCodeParam.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(errorCodeParam);
                var sda = new SqlDataAdapter(cmd);
                sda.Fill(dt);

                if (errorCodeParam.Value.ToString() != "0")
                    throw new Exception("Stored Procedure 'usp_NewerArticle_SelectAll' reported the ErrorCode : " + errorCodeParam.Value.ToString());

                return dt;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public DataTable ArticleOlderSelectAll(
            string RerultCount,
            string ArticleID
        )
        {
            try
            {
                var dt = new DataTable();
                var scon = new SqlConnection(connectionString);
                var cmd = new SqlCommand("usp_OlderArticle_SelectAll", scon);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@RerultCount", string.IsNullOrEmpty(RerultCount) ? dbNULL : (object)RerultCount);
                cmd.Parameters.AddWithValue("@ArticleID", string.IsNullOrEmpty(ArticleID) ? dbNULL : (object)ArticleID);

                SqlParameter errorCodeParam = new SqlParameter("@ErrorCode", null);
                errorCodeParam.Size = 4;
                errorCodeParam.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(errorCodeParam);
                var sda = new SqlDataAdapter(cmd);
                sda.Fill(dt);

                if (errorCodeParam.Value.ToString() != "0")
                    throw new Exception("Stored Procedure 'usp_OlderArticle_SelectAll' reported the ErrorCode : " + errorCodeParam.Value.ToString());

                return dt;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}

