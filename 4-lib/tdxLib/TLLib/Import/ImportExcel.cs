using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;

namespace TLLib
{
    public class ImportExcel
    {
        #region Class Member Declaration
        private string m_ProductID;
        #endregion
        string connectionString = Common.ConnectionString;
        DBNull dbNULL = DBNull.Value;

        //Import
        public DataTable ExelDataSelectAll(string sFileName)
        {
            var dt = new DataTable();
            string strEcelConn;
            if (sFileName.Contains(".xlsx"))
            {
                strEcelConn = "Provider=Microsoft.ACE.OLEDB.12.0;data source={0};Extended Properties='Excel 12.0 Xml;HDR=YES;IMEX=1';";
            }
            else
            {
                strEcelConn = "Provider=Microsoft.Jet.OLEDB.4.0;data source={0};Extended Properties='Excel 8.0;HDR=Yes;IMEX=1';";
            }
            strEcelConn = string.Format(strEcelConn, sFileName);
            string strQuery = "Select * from [Sheet1$]";

            var cn = new OleDbConnection(strEcelConn);
            var sda = new OleDbDataAdapter(strQuery, cn);
            sda.Fill(dt);
            return dt;
        }
        //---Product ---
        public string ProductImport(
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
                var cmd = new SqlCommand("usp_Product_Import", scon);
                cmd.CommandType = CommandType.StoredProcedure;

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
                
                SqlParameter productIDParam = new SqlParameter("@OutProductID", null);
                SqlParameter errorCodeParam = new SqlParameter("@ErrorCode", null);

                errorCodeParam.Size = productIDParam.Size = 4;
                errorCodeParam.Direction = productIDParam.Direction = ParameterDirection.Output;

                cmd.Parameters.Add(productIDParam);
                cmd.Parameters.Add(errorCodeParam);
                scon.Open();
                int success = cmd.ExecuteNonQuery();
                scon.Close();

                if (errorCodeParam.Value.ToString() != "0")
                    throw new Exception("Stored Procedure 'usp_Product_Import' reported the ErrorCode : " + errorCodeParam.Value.ToString());

                m_ProductID = productIDParam.Value.ToString();

                return m_ProductID;
            }
            //catch (SqlException ex)
            //{
            //    throw new Exception(ex.Number.ToString());
            //}
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public string ObjectIDByObjectNameSelectOne(
            string ProductCategoryName
        )
        {
            try
            {
                var dt = new DataTable();
                var scon = new SqlConnection(connectionString);
                var cmd = new SqlCommand("usp_ObjectID_By_ObjectName_SelectOne", scon);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@ProductCategoryName", string.IsNullOrEmpty(ProductCategoryName) ? dbNULL : (object)ProductCategoryName);

                var errorCodeParam = new SqlParameter("@ErrorCode", null);
                errorCodeParam.Size = 4;
                errorCodeParam.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(errorCodeParam);
                var sda = new SqlDataAdapter(cmd);
                sda.Fill(dt);

                if (errorCodeParam.Value.ToString() != "0")
                    throw new Exception("Stored Procedure 'usp_ObjectID_By_ObjectName_SelectOne' reported the ErrorCode : " + errorCodeParam.Value.ToString());

                string ObjectID = dt.Rows.Count == 0 ? "" : dt.Rows[0][0].ToString();

                return ObjectID;
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
        #region Properties

        public string ProductID
        {
            get { return m_ProductID; }
            set { m_ProductID = value; }
        }
        #endregion
        //End Import
    }
}
