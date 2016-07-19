using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace TLLib
{
    public class Service
    {
        string connectionString = Common.ConnectionString;
        DBNull dbNULL = DBNull.Value;

        public string ServiceInsert(
            string ImageName,
            string MetaTittle,
	        string MetaDescription,
            string ServiceTitle,
            string ConvertedServiceTitle,
            string Description,
            string Content,
            string Tag,
            string MetaTittleEn,
            string MetaDescriptionEn,
            string ServiceTitleEn,
            string DescriptionEn,
            string ContentEn,
            string TagEn,
            string ServiceCategoryID,
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
                var cmd = new SqlCommand("usp_Service_Insert", scon);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ImageName", string.IsNullOrEmpty(ImageName) ? dbNULL : (object)ImageName);
                cmd.Parameters.AddWithValue("@MetaTittle", string.IsNullOrEmpty(MetaTittle) ? dbNULL : (object)MetaTittle);
                cmd.Parameters.AddWithValue("@MetaDescription", string.IsNullOrEmpty(MetaDescription) ? dbNULL : (object)MetaDescription);
                cmd.Parameters.AddWithValue("@ServiceTitle", string.IsNullOrEmpty(ServiceTitle) ? dbNULL : (object)ServiceTitle);
                cmd.Parameters.AddWithValue("@ConvertedServiceTitle", string.IsNullOrEmpty(ConvertedServiceTitle) ? dbNULL : (object)ConvertedServiceTitle);
                cmd.Parameters.AddWithValue("@Description", string.IsNullOrEmpty(Description) ? dbNULL : (object)Description);
                cmd.Parameters.AddWithValue("@Content", string.IsNullOrEmpty(Content) ? dbNULL : (object)Content);
                cmd.Parameters.AddWithValue("@Tag", string.IsNullOrEmpty(Tag) ? dbNULL : (object)Tag);
                cmd.Parameters.AddWithValue("@MetaTittleEn", string.IsNullOrEmpty(MetaTittleEn) ? dbNULL : (object)MetaTittleEn);
                cmd.Parameters.AddWithValue("@MetaDescriptionEn", string.IsNullOrEmpty(MetaDescriptionEn) ? dbNULL : (object)MetaDescriptionEn);
                cmd.Parameters.AddWithValue("@ServiceTitleEn", string.IsNullOrEmpty(ServiceTitleEn) ? dbNULL : (object)ServiceTitleEn);
                cmd.Parameters.AddWithValue("@DescriptionEn", string.IsNullOrEmpty(DescriptionEn) ? dbNULL : (object)DescriptionEn);
                cmd.Parameters.AddWithValue("@ContentEn", string.IsNullOrEmpty(ContentEn) ? dbNULL : (object)ContentEn);
                cmd.Parameters.AddWithValue("@TagEn", string.IsNullOrEmpty(TagEn) ? dbNULL : (object)TagEn);
                cmd.Parameters.AddWithValue("@ServiceCategoryID", string.IsNullOrEmpty(ServiceCategoryID) ? dbNULL : (object)ServiceCategoryID);
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
                    throw new Exception("Stored Procedure 'usp_Service_Insert' reported the ErrorCode : " + errorCodeParam.Value.ToString());

                return imageNameParam.Value.ToString();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public int ServiceUpdate(
            string ImageName,
            string ServiceID,
            string MetaTittle,
            string MetaDescription,
            string ServiceTitle,
            string ConvertedServiceTitle,
            string Description,
            string Content,
            string Tag,
            string MetaTittleEn,
            string MetaDescriptionEn,
            string ServiceTitleEn,
            string DescriptionEn,
            string ContentEn,
            string TagEn,
            string ServiceCategoryID,
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
                var cmd = new SqlCommand("usp_Service_Update", scon);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ServiceID", string.IsNullOrEmpty(ServiceID) ? dbNULL : (object)ServiceID);
                cmd.Parameters.AddWithValue("@MetaTittle", string.IsNullOrEmpty(MetaTittle) ? dbNULL : (object)MetaTittle);
                cmd.Parameters.AddWithValue("@MetaDescription", string.IsNullOrEmpty(MetaDescription) ? dbNULL : (object)MetaDescription);
                cmd.Parameters.AddWithValue("@ServiceTitle", string.IsNullOrEmpty(ServiceTitle) ? dbNULL : (object)ServiceTitle);
                cmd.Parameters.AddWithValue("@ConvertedServiceTitle", string.IsNullOrEmpty(ConvertedServiceTitle) ? dbNULL : (object)ConvertedServiceTitle);
                cmd.Parameters.AddWithValue("@ImageName", string.IsNullOrEmpty(ImageName) ? dbNULL : (object)ImageName);
                cmd.Parameters.AddWithValue("@Description", string.IsNullOrEmpty(Description) ? dbNULL : (object)Description);
                cmd.Parameters.AddWithValue("@Content", string.IsNullOrEmpty(Content) ? dbNULL : (object)Content);
                cmd.Parameters.AddWithValue("@Tag", string.IsNullOrEmpty(Tag) ? dbNULL : (object)Tag);
                cmd.Parameters.AddWithValue("@MetaTittleEn", string.IsNullOrEmpty(MetaTittleEn) ? dbNULL : (object)MetaTittleEn);
                cmd.Parameters.AddWithValue("@MetaDescriptionEn", string.IsNullOrEmpty(MetaDescriptionEn) ? dbNULL : (object)MetaDescriptionEn);
                cmd.Parameters.AddWithValue("@ServiceTitleEn", string.IsNullOrEmpty(ServiceTitleEn) ? dbNULL : (object)ServiceTitleEn);
                cmd.Parameters.AddWithValue("@DescriptionEn", string.IsNullOrEmpty(DescriptionEn) ? dbNULL : (object)DescriptionEn);
                cmd.Parameters.AddWithValue("@ContentEn", string.IsNullOrEmpty(ContentEn) ? dbNULL : (object)ContentEn);
                cmd.Parameters.AddWithValue("@TagEn", string.IsNullOrEmpty(TagEn) ? dbNULL : (object)TagEn);
                cmd.Parameters.AddWithValue("@ServiceCategoryID", string.IsNullOrEmpty(ServiceCategoryID) ? dbNULL : (object)ServiceCategoryID);
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
                    throw new Exception("Stored Procedure 'usp_Service_Update' reported the ErrorCode : " + errorCodeParam.Value.ToString());

                return success;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public int ServiceQuickUpdate(
            string ServiceID,
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
                var cmd = new SqlCommand("usp_Service_QuickUpdate", scon);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ServiceID", string.IsNullOrEmpty(ServiceID) ? dbNULL : (object)ServiceID);
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
                    throw new Exception("Stored Procedure 'usp_Service_QuickUpdate' reported the ErrorCode : " + errorCodeParam.Value.ToString());

                return success;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public int ServiceDelete(
            string ServiceID
        )
        {
            try
            {
                var scon = new SqlConnection(connectionString);
                var cmd = new SqlCommand("usp_Service_Delete", scon);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ServiceID", string.IsNullOrEmpty(ServiceID) ? dbNULL : (object)ServiceID);
                SqlParameter errorCodeParam = new SqlParameter("@ErrorCode", null);
                errorCodeParam.Size = 4;
                errorCodeParam.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(errorCodeParam);
                scon.Open();
                int success = cmd.ExecuteNonQuery();
                scon.Close();

                if (errorCodeParam.Value.ToString() != "0")
                    throw new Exception("Stored Procedure 'usp_Service_Delete' reported the ErrorCode : " + errorCodeParam.Value.ToString());

                return success;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public DataTable ServiceSelectAll(
            string StartRowIndex,
            string EndRowIndex,
            string Keyword,
            string ServiceTitle,
            string Description,
            string ServiceCategoryID,
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
                var cmd = new SqlCommand("usp_Service_SelectAll", scon);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@StartRowIndex", string.IsNullOrEmpty(StartRowIndex) ? dbNULL : (object)StartRowIndex);
                cmd.Parameters.AddWithValue("@EndRowIndex", string.IsNullOrEmpty(EndRowIndex) ? dbNULL : (object)EndRowIndex);
                cmd.Parameters.AddWithValue("@Keyword", string.IsNullOrEmpty(Keyword) ? dbNULL : (object)Keyword);
                cmd.Parameters.AddWithValue("@ServiceTitle", string.IsNullOrEmpty(ServiceTitle) ? dbNULL : (object)ServiceTitle.Trim());
                cmd.Parameters.AddWithValue("@Description", string.IsNullOrEmpty(Description) ? dbNULL : (object)Description.Trim());
                cmd.Parameters.AddWithValue("@ServiceCategoryID", string.IsNullOrEmpty(ServiceCategoryID) ? dbNULL : (object)ServiceCategoryID);
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
                    throw new Exception("Stored Procedure 'usp_Service_SelectAll' reported the ErrorCode : " + errorCodeParam.Value.ToString());

                return dt;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public DataTable ServiceSameSelectAll(
            string RerultCount,
            string ServiceID
        )
        {
            try
            {
                var dt = new DataTable();
                var scon = new SqlConnection(connectionString);
                var cmd = new SqlCommand("usp_SameService_SelectAll", scon);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@RerultCount", string.IsNullOrEmpty(RerultCount) ? dbNULL : (object)RerultCount);
                cmd.Parameters.AddWithValue("@ServiceID", string.IsNullOrEmpty(ServiceID) ? dbNULL : (object)ServiceID);

                SqlParameter errorCodeParam = new SqlParameter("@ErrorCode", null);
                errorCodeParam.Size = 4;
                errorCodeParam.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(errorCodeParam);
                var sda = new SqlDataAdapter(cmd);
                sda.Fill(dt);

                if (errorCodeParam.Value.ToString() != "0")
                    throw new Exception("Stored Procedure 'usp_SameService_SelectAll' reported the ErrorCode : " + errorCodeParam.Value.ToString());

                return dt;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public DataTable ServiceSelectOne(
            string ServiceID
        )
        {
            try
            {
                var dt = new DataTable();
                var scon = new SqlConnection(connectionString);
                var cmd = new SqlCommand("usp_Service_SelectOne", scon);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ServiceID", string.IsNullOrEmpty(ServiceID) ? dbNULL : (object)ServiceID);
                SqlParameter errorCodeParam = new SqlParameter("@ErrorCode", null);
                errorCodeParam.Size = 4;
                errorCodeParam.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(errorCodeParam);
                var sda = new SqlDataAdapter(cmd);
                sda.Fill(dt);

                if (errorCodeParam.Value.ToString() != "0")
                    throw new Exception("Stored Procedure 'usp_Service_SelectOne' reported the ErrorCode : " + errorCodeParam.Value.ToString());

                return dt;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public int ServiceImageDelete(
            string ServiceID
        )
        {
            try
            {
                var scon = new SqlConnection(connectionString);
                var cmd = new SqlCommand("usp_ServiceImage_Delete", scon);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ServiceID", string.IsNullOrEmpty(ServiceID) ? dbNULL : (object)ServiceID);
                SqlParameter errorCodeParam = new SqlParameter("@ErrorCode", null);
                errorCodeParam.Size = 4;
                errorCodeParam.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(errorCodeParam);
                scon.Open();
                int success = cmd.ExecuteNonQuery();
                scon.Close();

                if (errorCodeParam.Value.ToString() != "0")
                    throw new Exception("Stored Procedure 'usp_ServiceImage_Delete' reported the ErrorCode : " + errorCodeParam.Value.ToString());

                return success;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public DataTable ServiceNewerSelectAll(
            string RerultCount,
            string ServiceID
        )
        {
            try
            {
                var dt = new DataTable();
                var scon = new SqlConnection(connectionString);
                var cmd = new SqlCommand("usp_NewerService_SelectAll", scon);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@RerultCount", string.IsNullOrEmpty(RerultCount) ? dbNULL : (object)RerultCount);
                cmd.Parameters.AddWithValue("@ServiceID", string.IsNullOrEmpty(ServiceID) ? dbNULL : (object)ServiceID);

                SqlParameter errorCodeParam = new SqlParameter("@ErrorCode", null);
                errorCodeParam.Size = 4;
                errorCodeParam.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(errorCodeParam);
                var sda = new SqlDataAdapter(cmd);
                sda.Fill(dt);

                if (errorCodeParam.Value.ToString() != "0")
                    throw new Exception("Stored Procedure 'usp_NewerService_SelectAll' reported the ErrorCode : " + errorCodeParam.Value.ToString());

                return dt;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public DataTable ServiceOlderSelectAll(
            string RerultCount,
            string ServiceID
        )
        {
            try
            {
                var dt = new DataTable();
                var scon = new SqlConnection(connectionString);
                var cmd = new SqlCommand("usp_OlderService_SelectAll", scon);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@RerultCount", string.IsNullOrEmpty(RerultCount) ? dbNULL : (object)RerultCount);
                cmd.Parameters.AddWithValue("@ServiceID", string.IsNullOrEmpty(ServiceID) ? dbNULL : (object)ServiceID);

                SqlParameter errorCodeParam = new SqlParameter("@ErrorCode", null);
                errorCodeParam.Size = 4;
                errorCodeParam.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(errorCodeParam);
                var sda = new SqlDataAdapter(cmd);
                sda.Fill(dt);

                if (errorCodeParam.Value.ToString() != "0")
                    throw new Exception("Stored Procedure 'usp_OlderService_SelectAll' reported the ErrorCode : " + errorCodeParam.Value.ToString());

                return dt;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}

