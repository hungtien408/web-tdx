using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace TLLib
{
    public class Product
    {
        #region Class Member Declaration
        private string m_ProductID;
        #endregion

        string connectionString = Common.ConnectionString;
        DBNull dbNULL = DBNull.Value;

        public string ProductInsert(
            string ImageName,
            string MetaTittle,
            string MetaDescription,
            string ProductName,
            string ConvertedProductName,
            string Description,
            string Content,
            string Tag,
            string MetaTittleEn,
            string MetaDescriptionEn,
            string ProductNameEn,
            string DescriptionEn,
            string ContentEn,
            string TagEn,
            string Price,
            string OtherPrice,
            string SavePrice,
            string Discount,
            string CategoryID,
            string ManufacturerID,
            string OriginID,
            string InStock,
            string IsHot,
            string IsNew,
            string IsBestSeller,
            string IsSaleOff,
            string IsShowOnHomePage,
            string Priority,
            string IsAvailable
        )
        {
            try
            {
                var scon = new SqlConnection(connectionString);
                var cmd = new SqlCommand("usp_Product_Insert", scon);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ImageName", string.IsNullOrEmpty(ImageName) ? dbNULL : (object)ImageName);
                cmd.Parameters.AddWithValue("@MetaTittle", string.IsNullOrEmpty(MetaTittle) ? dbNULL : (object)MetaTittle);
                cmd.Parameters.AddWithValue("@MetaDescription", string.IsNullOrEmpty(MetaDescription) ? dbNULL : (object)MetaDescription);
                cmd.Parameters.AddWithValue("@ProductName", string.IsNullOrEmpty(ProductName) ? dbNULL : (object)ProductName);
                cmd.Parameters.AddWithValue("@ConvertedProductName", string.IsNullOrEmpty(ConvertedProductName) ? dbNULL : (object)ConvertedProductName);
                cmd.Parameters.AddWithValue("@Description", string.IsNullOrEmpty(Description) ? dbNULL : (object)Description);
                cmd.Parameters.AddWithValue("@Content", string.IsNullOrEmpty(Content) ? dbNULL : (object)Content);
                cmd.Parameters.AddWithValue("@Tag", string.IsNullOrEmpty(Tag) ? dbNULL : (object)Tag);
                cmd.Parameters.AddWithValue("@MetaTittleEn", string.IsNullOrEmpty(MetaTittleEn) ? dbNULL : (object)MetaTittleEn);
                cmd.Parameters.AddWithValue("@MetaDescriptionEn", string.IsNullOrEmpty(MetaDescriptionEn) ? dbNULL : (object)MetaDescriptionEn);
                cmd.Parameters.AddWithValue("@ProductNameEn", string.IsNullOrEmpty(ProductNameEn) ? dbNULL : (object)ProductNameEn);
                cmd.Parameters.AddWithValue("@DescriptionEn", string.IsNullOrEmpty(DescriptionEn) ? dbNULL : (object)DescriptionEn);
                cmd.Parameters.AddWithValue("@ContentEn", string.IsNullOrEmpty(ContentEn) ? dbNULL : (object)ContentEn);
                cmd.Parameters.AddWithValue("@TagEn", string.IsNullOrEmpty(TagEn) ? dbNULL : (object)TagEn);
                cmd.Parameters.AddWithValue("@Price", string.IsNullOrEmpty(Price) ? dbNULL : (object)Price);
                cmd.Parameters.AddWithValue("@OtherPrice", string.IsNullOrEmpty(OtherPrice) ? dbNULL : (object)OtherPrice);
                cmd.Parameters.AddWithValue("@SavePrice", string.IsNullOrEmpty(SavePrice) ? dbNULL : (object)SavePrice);
                cmd.Parameters.AddWithValue("@Discount", string.IsNullOrEmpty(Discount) ? dbNULL : (object)Discount);
                cmd.Parameters.AddWithValue("@CategoryID", string.IsNullOrEmpty(CategoryID) ? dbNULL : (object)CategoryID);
                cmd.Parameters.AddWithValue("@ManufacturerID", string.IsNullOrEmpty(ManufacturerID) ? dbNULL : (object)ManufacturerID);
                cmd.Parameters.AddWithValue("@OriginID", string.IsNullOrEmpty(OriginID) ? dbNULL : (object)OriginID);
                cmd.Parameters.AddWithValue("@InStock", string.IsNullOrEmpty(InStock) ? dbNULL : (object)InStock);
                cmd.Parameters.AddWithValue("@IsHot", string.IsNullOrEmpty(IsHot) ? dbNULL : (object)IsHot);
                cmd.Parameters.AddWithValue("@IsNew", string.IsNullOrEmpty(IsNew) ? dbNULL : (object)IsNew);
                cmd.Parameters.AddWithValue("@IsBestSeller", string.IsNullOrEmpty(IsBestSeller) ? dbNULL : (object)IsBestSeller);
                cmd.Parameters.AddWithValue("@IsSaleOff", string.IsNullOrEmpty(IsSaleOff) ? dbNULL : (object)IsSaleOff);
                cmd.Parameters.AddWithValue("@IsShowOnHomePage", string.IsNullOrEmpty(IsShowOnHomePage) ? dbNULL : (object)IsShowOnHomePage);
                cmd.Parameters.AddWithValue("@Priority", string.IsNullOrEmpty(Priority) ? dbNULL : (object)Priority);
                cmd.Parameters.AddWithValue("@IsAvailable", string.IsNullOrEmpty(IsAvailable) ? dbNULL : (object)IsAvailable);

                SqlParameter imageNameParam = new SqlParameter("@OutImageName", null);
                SqlParameter productIDParam = new SqlParameter("@OutProductID", null);
                SqlParameter errorCodeParam = new SqlParameter("@ErrorCode", null);
                imageNameParam.Size = 100;
                errorCodeParam.Size = productIDParam.Size = 4;
                errorCodeParam.Direction = imageNameParam.Direction = productIDParam.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(imageNameParam);
                cmd.Parameters.Add(productIDParam);
                cmd.Parameters.Add(errorCodeParam);
                scon.Open();
                int success = cmd.ExecuteNonQuery();
                scon.Close();

                if (errorCodeParam.Value.ToString() != "0")
                    throw new Exception("Stored Procedure 'usp_Product_Insert' reported the ErrorCode : " + errorCodeParam.Value.ToString());

                m_ProductID = productIDParam.Value.ToString();

                return imageNameParam.Value.ToString();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public int ProductUpdate(
            string ProductID,
            string ImageName,
            string MetaTittle,
            string MetaDescription,
            string ProductName,
            string ConvertedProductName,
            string Description,
            string Content,
            string Tag,
            string MetaTittleEn,
            string MetaDescriptionEn,
            string ProductNameEn,
            string DescriptionEn,
            string ContentEn,
            string TagEn,
            string Price,
            string OtherPrice,
            string SavePrice,
            string Discount,
            string CategoryID,
            string ManufacturerID,
            string OriginID,
            string InStock,
            string IsHot,
            string IsNew,
            string IsBestSeller,
            string IsSaleOff,
            string IsShowOnHomePage,
            string Priority,
            string IsAvailable
        )
        {
            try
            {
                var scon = new SqlConnection(connectionString);
                var cmd = new SqlCommand("usp_Product_Update", scon);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ProductID", string.IsNullOrEmpty(ProductID) ? dbNULL : (object)ProductID);
                cmd.Parameters.AddWithValue("@ImageName", string.IsNullOrEmpty(ImageName) ? dbNULL : (object)ImageName);
                cmd.Parameters.AddWithValue("@MetaTittle", string.IsNullOrEmpty(MetaTittle) ? dbNULL : (object)MetaTittle);
                cmd.Parameters.AddWithValue("@MetaDescription", string.IsNullOrEmpty(MetaDescription) ? dbNULL : (object)MetaDescription);
                cmd.Parameters.AddWithValue("@ProductName", string.IsNullOrEmpty(ProductName) ? dbNULL : (object)ProductName);
                cmd.Parameters.AddWithValue("@ConvertedProductName", string.IsNullOrEmpty(ConvertedProductName) ? dbNULL : (object)ConvertedProductName);
                cmd.Parameters.AddWithValue("@Description", string.IsNullOrEmpty(Description) ? dbNULL : (object)Description);
                cmd.Parameters.AddWithValue("@Content", string.IsNullOrEmpty(Content) ? dbNULL : (object)Content);
                cmd.Parameters.AddWithValue("@Tag", string.IsNullOrEmpty(Tag) ? dbNULL : (object)Tag);
                cmd.Parameters.AddWithValue("@MetaTittleEn", string.IsNullOrEmpty(MetaTittleEn) ? dbNULL : (object)MetaTittleEn);
                cmd.Parameters.AddWithValue("@MetaDescriptionEn", string.IsNullOrEmpty(MetaDescriptionEn) ? dbNULL : (object)MetaDescriptionEn);
                cmd.Parameters.AddWithValue("@ProductNameEn", string.IsNullOrEmpty(ProductNameEn) ? dbNULL : (object)ProductNameEn);
                cmd.Parameters.AddWithValue("@DescriptionEn", string.IsNullOrEmpty(DescriptionEn) ? dbNULL : (object)DescriptionEn);
                cmd.Parameters.AddWithValue("@ContentEn", string.IsNullOrEmpty(ContentEn) ? dbNULL : (object)ContentEn);
                cmd.Parameters.AddWithValue("@TagEn", string.IsNullOrEmpty(TagEn) ? dbNULL : (object)TagEn);
                cmd.Parameters.AddWithValue("@Price", string.IsNullOrEmpty(Price) ? dbNULL : (object)Price);
                cmd.Parameters.AddWithValue("@OtherPrice", string.IsNullOrEmpty(OtherPrice) ? dbNULL : (object)OtherPrice);
                cmd.Parameters.AddWithValue("@SavePrice", string.IsNullOrEmpty(SavePrice) ? dbNULL : (object)SavePrice);
                cmd.Parameters.AddWithValue("@Discount", string.IsNullOrEmpty(Discount) ? dbNULL : (object)Discount);
                cmd.Parameters.AddWithValue("@CategoryID", string.IsNullOrEmpty(CategoryID) ? dbNULL : (object)CategoryID);
                cmd.Parameters.AddWithValue("@ManufacturerID", string.IsNullOrEmpty(ManufacturerID) ? dbNULL : (object)ManufacturerID);
                cmd.Parameters.AddWithValue("@OriginID", string.IsNullOrEmpty(OriginID) ? dbNULL : (object)OriginID);
                cmd.Parameters.AddWithValue("@InStock", string.IsNullOrEmpty(InStock) ? dbNULL : (object)InStock);
                cmd.Parameters.AddWithValue("@IsHot", string.IsNullOrEmpty(IsHot) ? dbNULL : (object)IsHot);
                cmd.Parameters.AddWithValue("@IsNew", string.IsNullOrEmpty(IsNew) ? dbNULL : (object)IsNew);
                cmd.Parameters.AddWithValue("@IsBestSeller", string.IsNullOrEmpty(IsBestSeller) ? dbNULL : (object)IsBestSeller);
                cmd.Parameters.AddWithValue("@IsSaleOff", string.IsNullOrEmpty(IsSaleOff) ? dbNULL : (object)IsSaleOff);
                cmd.Parameters.AddWithValue("@IsShowOnHomePage", string.IsNullOrEmpty(IsShowOnHomePage) ? dbNULL : (object)IsShowOnHomePage);
                cmd.Parameters.AddWithValue("@Priority", string.IsNullOrEmpty(Priority) ? dbNULL : (object)Priority);
                cmd.Parameters.AddWithValue("@IsAvailable", string.IsNullOrEmpty(IsAvailable) ? dbNULL : (object)IsAvailable);
                SqlParameter errorCodeParam = new SqlParameter("@ErrorCode", null);
                errorCodeParam.Size = 4;
                errorCodeParam.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(errorCodeParam);
                scon.Open();
                int success = cmd.ExecuteNonQuery();
                scon.Close();

                if (errorCodeParam.Value.ToString() != "0")
                    throw new Exception("Stored Procedure 'usp_Product_Update' reported the ErrorCode : " + errorCodeParam.Value.ToString());

                return success;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public int ProductQuickUpdate(
            string ProductID,
            string InStock,
            string IsHot,
            string IsNew,
            string IsBestSeller,
            string IsSaleOff,
            string IsShowOnHomePage,
            string Priority,
            string IsAvailable
        )
        {
            try
            {
                var scon = new SqlConnection(connectionString);
                var cmd = new SqlCommand("usp_Product_QuickUpdate", scon);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ProductID", string.IsNullOrEmpty(ProductID) ? dbNULL : (object)ProductID);
                cmd.Parameters.AddWithValue("@InStock", string.IsNullOrEmpty(InStock) ? dbNULL : (object)InStock);
                cmd.Parameters.AddWithValue("@IsHot", string.IsNullOrEmpty(IsHot) ? dbNULL : (object)IsHot);
                cmd.Parameters.AddWithValue("@IsNew", string.IsNullOrEmpty(IsNew) ? dbNULL : (object)IsNew);
                cmd.Parameters.AddWithValue("@IsBestSeller", string.IsNullOrEmpty(IsBestSeller) ? dbNULL : (object)IsBestSeller);
                cmd.Parameters.AddWithValue("@IsSaleOff", string.IsNullOrEmpty(IsSaleOff) ? dbNULL : (object)IsSaleOff);
                cmd.Parameters.AddWithValue("@IsShowOnHomePage", string.IsNullOrEmpty(IsShowOnHomePage) ? dbNULL : (object)IsShowOnHomePage);
                cmd.Parameters.AddWithValue("@Priority", string.IsNullOrEmpty(Priority) ? dbNULL : (object)Priority);
                cmd.Parameters.AddWithValue("@IsAvailable", string.IsNullOrEmpty(IsAvailable) ? dbNULL : (object)IsAvailable);
                SqlParameter errorCodeParam = new SqlParameter("@ErrorCode", null);
                errorCodeParam.Size = 4;
                errorCodeParam.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(errorCodeParam);
                scon.Open();
                int success = cmd.ExecuteNonQuery();
                scon.Close();

                if (errorCodeParam.Value.ToString() != "0")
                    throw new Exception("Stored Procedure 'usp_Product_QuickUpdate' reported the ErrorCode : " + errorCodeParam.Value.ToString());

                return success;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public int ProductDelete(
            string ProductID
        )
        {
            try
            {
                var scon = new SqlConnection(connectionString);
                var cmd = new SqlCommand("usp_Product_Delete", scon);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ProductID", string.IsNullOrEmpty(ProductID) ? dbNULL : (object)ProductID);
                SqlParameter errorCodeParam = new SqlParameter("@ErrorCode", null);
                errorCodeParam.Size = 4;
                errorCodeParam.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(errorCodeParam);
                scon.Open();
                int success = cmd.ExecuteNonQuery();
                scon.Close();

                if (errorCodeParam.Value.ToString() != "0")
                    throw new Exception("Stored Procedure 'usp_Product_Delete' reported the ErrorCode : " + errorCodeParam.Value.ToString());

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

        public DataTable ProductSelectAll(
            string StartRowIndex,
            string EndRowIndex,
            string Keyword,
            string ProductName,
            string Description,
            string PriceFrom,
            string PriceTo,
            string CategoryID,
            string ManufacturerID,
            string OriginID,
            string Tag,
            string InStock,
            string IsHot,
            string IsNew,
            string IsBestSeller,
            string IsSaleOff,
            string IsShowOnHomePage,
            string FromDate,
            string ToDate,
            string Priority,
            string IsAvailable,
            string SortByPriority
        )
        {
            try
            {
                var dt = new DataTable();
                var scon = new SqlConnection(connectionString);
                var cmd = new SqlCommand("usp_Product_SelectAll", scon);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@StartRowIndex", string.IsNullOrEmpty(StartRowIndex) ? dbNULL : (object)StartRowIndex);
                cmd.Parameters.AddWithValue("@EndRowIndex", string.IsNullOrEmpty(EndRowIndex) ? dbNULL : (object)EndRowIndex);
                cmd.Parameters.AddWithValue("@Keyword", string.IsNullOrEmpty(Keyword) ? dbNULL : (object)Keyword);
                cmd.Parameters.AddWithValue("@ProductName", string.IsNullOrEmpty(ProductName) ? dbNULL : (object)ProductName.Trim());
                cmd.Parameters.AddWithValue("@Description", string.IsNullOrEmpty(Description) ? dbNULL : (object)Description.Trim());
                cmd.Parameters.AddWithValue("@PriceFrom", string.IsNullOrEmpty(PriceFrom) ? dbNULL : (object)PriceFrom);
                cmd.Parameters.AddWithValue("@PriceTo", string.IsNullOrEmpty(PriceTo) ? dbNULL : (object)PriceTo);
                cmd.Parameters.AddWithValue("@CategoryID", string.IsNullOrEmpty(CategoryID) ? dbNULL : (object)CategoryID);
                cmd.Parameters.AddWithValue("@ManufacturerID", string.IsNullOrEmpty(ManufacturerID) ? dbNULL : (object)ManufacturerID);
                cmd.Parameters.AddWithValue("@OriginID", string.IsNullOrEmpty(OriginID) ? dbNULL : (object)OriginID);
                cmd.Parameters.AddWithValue("@Tag", string.IsNullOrEmpty(Tag) ? dbNULL : (object)Tag);
                cmd.Parameters.AddWithValue("@InStock", string.IsNullOrEmpty(InStock) ? dbNULL : (object)InStock);
                cmd.Parameters.AddWithValue("@IsHot", string.IsNullOrEmpty(IsHot) ? dbNULL : (object)IsHot);
                cmd.Parameters.AddWithValue("@IsNew", string.IsNullOrEmpty(IsNew) ? dbNULL : (object)IsNew);
                cmd.Parameters.AddWithValue("@IsBestSeller", string.IsNullOrEmpty(IsBestSeller) ? dbNULL : (object)IsBestSeller);
                cmd.Parameters.AddWithValue("@IsSaleOff", string.IsNullOrEmpty(IsSaleOff) ? dbNULL : (object)IsSaleOff);
                cmd.Parameters.AddWithValue("@IsShowOnHomePage", string.IsNullOrEmpty(IsShowOnHomePage) ? dbNULL : (object)IsShowOnHomePage);
                cmd.Parameters.AddWithValue("@FromDate", string.IsNullOrEmpty(FromDate) ? dbNULL : (object)FromDate);
                cmd.Parameters.AddWithValue("@ToDate", string.IsNullOrEmpty(ToDate) ? dbNULL : (object)ToDate);
                cmd.Parameters.AddWithValue("@Priority", string.IsNullOrEmpty(Priority) ? dbNULL : (object)Priority);
                cmd.Parameters.AddWithValue("@IsAvailable", string.IsNullOrEmpty(IsAvailable) ? dbNULL : (object)IsAvailable);
                cmd.Parameters.AddWithValue("@SortByPriority", string.IsNullOrEmpty(SortByPriority) ? dbNULL : (object)SortByPriority);

                SqlParameter errorCodeParam = new SqlParameter("@ErrorCode", null);
                errorCodeParam.Size = 4;
                errorCodeParam.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(errorCodeParam);
                var sda = new SqlDataAdapter(cmd);
                sda.Fill(dt);

                if (errorCodeParam.Value.ToString() != "0")
                    throw new Exception("Stored Procedure 'usp_Product_SelectAll' reported the ErrorCode : " + errorCodeParam.Value.ToString());

                return dt;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public DataTable ProductForDisplaySelectAll(
            string StartRowIndex,
            string EndRowIndex,
            string ProductName,
            string Description,
            string PriceFrom,
            string PriceTo,
            string CategoryID,
            string ManufacturerID,
            string OriginID,
            string Tag,
            string InStock,
            string IsHot,
            string IsNew,
            string IsBestSeller,
            string IsShowOnHomePage,
            string FromDate,
            string ToDate,
            string Priority,
            string IsAvailable
        )
        {
            try
            {
                var dt = new DataTable();
                var scon = new SqlConnection(connectionString);
                var cmd = new SqlCommand("usp_ProductForDisplay_SelectAll", scon);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@StartRowIndex", string.IsNullOrEmpty(StartRowIndex) ? dbNULL : (object)StartRowIndex);
                cmd.Parameters.AddWithValue("@EndRowIndex", string.IsNullOrEmpty(EndRowIndex) ? dbNULL : (object)EndRowIndex);
                cmd.Parameters.AddWithValue("@ProductName", string.IsNullOrEmpty(ProductName) ? dbNULL : (object)ProductName.Trim());
                cmd.Parameters.AddWithValue("@Description", string.IsNullOrEmpty(Description) ? dbNULL : (object)Description.Trim());
                cmd.Parameters.AddWithValue("@PriceFrom", string.IsNullOrEmpty(PriceFrom) ? dbNULL : (object)PriceFrom);
                cmd.Parameters.AddWithValue("@PriceTo", string.IsNullOrEmpty(PriceTo) ? dbNULL : (object)PriceTo);
                cmd.Parameters.AddWithValue("@CategoryID", string.IsNullOrEmpty(CategoryID) ? dbNULL : (object)CategoryID);
                cmd.Parameters.AddWithValue("@ManufacturerID", string.IsNullOrEmpty(ManufacturerID) ? dbNULL : (object)ManufacturerID);
                cmd.Parameters.AddWithValue("@OriginID", string.IsNullOrEmpty(OriginID) ? dbNULL : (object)OriginID);
                cmd.Parameters.AddWithValue("@Tag", string.IsNullOrEmpty(Tag) ? dbNULL : (object)Tag);
                cmd.Parameters.AddWithValue("@InStock", string.IsNullOrEmpty(InStock) ? dbNULL : (object)InStock);
                cmd.Parameters.AddWithValue("@IsHot", string.IsNullOrEmpty(IsHot) ? dbNULL : (object)IsHot);
                cmd.Parameters.AddWithValue("@IsNew", string.IsNullOrEmpty(IsNew) ? dbNULL : (object)IsNew);
                cmd.Parameters.AddWithValue("@IsBestSeller", string.IsNullOrEmpty(IsBestSeller) ? dbNULL : (object)IsBestSeller);
                cmd.Parameters.AddWithValue("@IsShowOnHomePage", string.IsNullOrEmpty(IsShowOnHomePage) ? dbNULL : (object)IsShowOnHomePage);
                cmd.Parameters.AddWithValue("@FromDate", string.IsNullOrEmpty(FromDate) ? dbNULL : (object)FromDate);
                cmd.Parameters.AddWithValue("@ToDate", string.IsNullOrEmpty(ToDate) ? dbNULL : (object)ToDate);
                cmd.Parameters.AddWithValue("@Priority", string.IsNullOrEmpty(Priority) ? dbNULL : (object)Priority);
                cmd.Parameters.AddWithValue("@IsAvailable", string.IsNullOrEmpty(IsAvailable) ? dbNULL : (object)IsAvailable);

                SqlParameter errorCodeParam = new SqlParameter("@ErrorCode", null);
                errorCodeParam.Size = 4;
                errorCodeParam.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(errorCodeParam);
                var sda = new SqlDataAdapter(cmd);
                sda.Fill(dt);

                if (errorCodeParam.Value.ToString() != "0")
                    throw new Exception("Stored Procedure 'usp_ProductForDisplay_SelectAll' reported the ErrorCode : " + errorCodeParam.Value.ToString());

                return dt;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public DataTable ProductSelectOne(
            string ProductID
        )
        {
            try
            {
                var dt = new DataTable();
                var scon = new SqlConnection(connectionString);
                var cmd = new SqlCommand("usp_Product_SelectOne", scon);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ProductID", string.IsNullOrEmpty(ProductID) ? dbNULL : (object)ProductID);
                SqlParameter errorCodeParam = new SqlParameter("@ErrorCode", null);
                errorCodeParam.Size = 4;
                errorCodeParam.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(errorCodeParam);
                var sda = new SqlDataAdapter(cmd);
                sda.Fill(dt);

                if (errorCodeParam.Value.ToString() != "0")
                    throw new Exception("Stored Procedure 'usp_Product_SelectOne' reported the ErrorCode : " + errorCodeParam.Value.ToString());

                return dt;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public bool ProductIsChildrenExist(
            string ProductID
        )
        {
            try
            {
                var scon = new SqlConnection(connectionString);
                var cmd = new SqlCommand("usp_Product_IsChildrenExist", scon);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ProductID", string.IsNullOrEmpty(ProductID) ? dbNULL : (object)ProductID);
                SqlParameter errorCodeParam = new SqlParameter("@ErrorCode", null);
                errorCodeParam.Size = 4;
                errorCodeParam.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(errorCodeParam);
                scon.Open();
                bool isExists = Convert.ToBoolean(cmd.ExecuteScalar());
                scon.Close();

                if (errorCodeParam.Value.ToString() != "0")
                    throw new Exception("Stored Procedure 'usp_Product_IsChildrenExist' reported the ErrorCode : " + errorCodeParam.Value.ToString());

                return isExists;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public DataTable ProductSameSelectAll(
            string RerultCount,
            string ProductID
        )
        {
            try
            {
                var dt = new DataTable();
                var scon = new SqlConnection(connectionString);
                var cmd = new SqlCommand("usp_SameProduct_SelectAll", scon);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@RerultCount", string.IsNullOrEmpty(RerultCount) ? dbNULL : (object)RerultCount);
                cmd.Parameters.AddWithValue("@ProductID", string.IsNullOrEmpty(ProductID) ? dbNULL : (object)ProductID);

                SqlParameter errorCodeParam = new SqlParameter("@ErrorCode", null);
                errorCodeParam.Size = 4;
                errorCodeParam.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(errorCodeParam);
                var sda = new SqlDataAdapter(cmd);
                sda.Fill(dt);

                if (errorCodeParam.Value.ToString() != "0")
                    throw new Exception("Stored Procedure 'usp_SameProduct_SelectAll' reported the ErrorCode : " + errorCodeParam.Value.ToString());

                return dt;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public int ProductImageDelete(
            string ProductID
        )
        {
            try
            {
                var scon = new SqlConnection(connectionString);
                var cmd = new SqlCommand("usp_ProductImages_Delete", scon);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ProductID", string.IsNullOrEmpty(ProductID) ? dbNULL : (object)ProductID);
                SqlParameter errorCodeParam = new SqlParameter("@ErrorCode", null);
                errorCodeParam.Size = 4;
                errorCodeParam.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(errorCodeParam);
                scon.Open();
                int success = cmd.ExecuteNonQuery();
                scon.Close();

                if (errorCodeParam.Value.ToString() != "0")
                    throw new Exception("Stored Procedure 'usp_ProductImages_Delete' reported the ErrorCode : " + errorCodeParam.Value.ToString());

                return success;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        #region Properties

        public string ProductID
        {
            get { return m_ProductID; }
            set { m_ProductID = value; }
        }

        #endregion
    }
}

