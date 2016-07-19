using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace TLLib
{
    public class Partner
    {
        string connectionString = Common.ConnectionString;
        DBNull dbNULL = DBNull.Value;

        public string PartnerInsert(
            string PartnerName,
            string PartnerNameEn,
            string ConvertedPartnerName,
            string PartnerImage,
            string Address,
            string LinkWebsite,
            string IsAvailable,
            string Priority
        )
        {
            try
            {
                var scon = new SqlConnection(connectionString);
                var cmd = new SqlCommand("usp_Partner_Insert", scon);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@PartnerName", string.IsNullOrEmpty(PartnerName) ? dbNULL : (object)PartnerName);
                cmd.Parameters.AddWithValue("@PartnerNameEn", string.IsNullOrEmpty(PartnerNameEn) ? dbNULL : (object)PartnerNameEn);
                cmd.Parameters.AddWithValue("@ConvertedPartnerName", string.IsNullOrEmpty(ConvertedPartnerName) ? dbNULL : (object)ConvertedPartnerName);
                cmd.Parameters.AddWithValue("@PartnerImage", string.IsNullOrEmpty(PartnerImage) ? dbNULL : (object)PartnerImage);
                cmd.Parameters.AddWithValue("@Address", string.IsNullOrEmpty(Address) ? dbNULL : (object)Address);
                cmd.Parameters.AddWithValue("@LinkWebsite", string.IsNullOrEmpty(LinkWebsite) ? dbNULL : (object)(LinkWebsite.ToLower().StartsWith("http://") ? LinkWebsite.ToLower() : "http://" + LinkWebsite.ToLower()));
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
                cmd.ExecuteNonQuery();
                scon.Close();

                if (errorCodeParam.Value.ToString() != "0")
                    throw new Exception("Stored Procedure 'usp_Partner_Insert' reported the ErrorCode : " + errorCodeParam.Value.ToString());

                return imageNameParam.Value.ToString();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public int PartnerUpdate(
            string PartnerID,
            string PartnerName,
            string PartnerNameEn,
            string ConvertedPartnerName,
            string PartnerImage,
            string Address,
            string LinkWebsite,
            string IsAvailable,
            string Priority
        )
        {
            try
            {
                var scon = new SqlConnection(connectionString);
                var cmd = new SqlCommand("usp_Partner_Update", scon);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@PartnerID", string.IsNullOrEmpty(PartnerID) ? dbNULL : (object)PartnerID);
                cmd.Parameters.AddWithValue("@PartnerName", string.IsNullOrEmpty(PartnerName) ? dbNULL : (object)PartnerName);
                cmd.Parameters.AddWithValue("@PartnerNameEn", string.IsNullOrEmpty(PartnerNameEn) ? dbNULL : (object)PartnerNameEn);
                cmd.Parameters.AddWithValue("@ConvertedPartnerName", string.IsNullOrEmpty(ConvertedPartnerName) ? dbNULL : (object)ConvertedPartnerName);
                cmd.Parameters.AddWithValue("@PartnerImage", string.IsNullOrEmpty(PartnerImage) ? dbNULL : (object)PartnerImage);
                cmd.Parameters.AddWithValue("@Address", string.IsNullOrEmpty(Address) ? dbNULL : (object)Address);
                cmd.Parameters.AddWithValue("@LinkWebsite", string.IsNullOrEmpty(LinkWebsite) ? dbNULL : (object)(LinkWebsite.ToLower().StartsWith("http://") ? LinkWebsite.ToLower() : "http://" + LinkWebsite.ToLower()));
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
                    throw new Exception("Stored Procedure 'usp_Partner_Update' reported the ErrorCode : " + errorCodeParam.Value.ToString());

                return success;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public int PartnerQuickUpdate(
            string PartnerID,
            string IsAvailable,
            string Priority
        )
        {
            try
            {
                var scon = new SqlConnection(connectionString);
                var cmd = new SqlCommand("usp_Partner_QuickUpdate", scon);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@PartnerID", string.IsNullOrEmpty(PartnerID) ? dbNULL : (object)PartnerID);
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
                    throw new Exception("Stored Procedure 'usp_Partner_QuickUpdate' reported the ErrorCode : " + errorCodeParam.Value.ToString());

                return success;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public int PartnerDelete(
            string PartnerID
        )
        {
            try
            {
                var scon = new SqlConnection(connectionString);
                var cmd = new SqlCommand("usp_Partner_Delete", scon);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@PartnerID", string.IsNullOrEmpty(PartnerID) ? dbNULL : (object)PartnerID);
                SqlParameter errorCodeParam = new SqlParameter("@ErrorCode", null);
                errorCodeParam.Size = 4;
                errorCodeParam.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(errorCodeParam);
                scon.Open();
                int success = cmd.ExecuteNonQuery();
                scon.Close();

                if (errorCodeParam.Value.ToString() != "0")
                    throw new Exception("Stored Procedure 'usp_Partner_Delete' reported the ErrorCode : " + errorCodeParam.Value.ToString());

                return success;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public DataTable PartnerSelectAll(
            string Keyword,
            string PartnerName,
            string Address,
            string LinkWebsite,
            string IsAvailable,
            string Priority,
            string SortByPriority
        )
        {
            try
            {
                var dt = new DataTable();
                var scon = new SqlConnection(connectionString);
                var cmd = new SqlCommand("usp_Partner_SelectAll", scon);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Keyword", string.IsNullOrEmpty(Keyword) ? dbNULL : (object)Keyword);
                cmd.Parameters.AddWithValue("@PartnerName", string.IsNullOrEmpty(PartnerName) ? dbNULL : (object)PartnerName);
                cmd.Parameters.AddWithValue("@Address", string.IsNullOrEmpty(Address) ? dbNULL : (object)Address);
                cmd.Parameters.AddWithValue("@LinkWebsite", string.IsNullOrEmpty(LinkWebsite) ? dbNULL : (object)LinkWebsite);
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
                    throw new Exception("Stored Procedure 'usp_Partner_SelectAll' reported the ErrorCode : " + errorCodeParam.Value.ToString());

                return dt;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public DataTable PartnerSelectOne(
            string PartnerID
        )
        {
            try
            {
                var dt = new DataTable();
                var scon = new SqlConnection(connectionString);
                var cmd = new SqlCommand("usp_Partner_SelectOne", scon);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@PartnerID", string.IsNullOrEmpty(PartnerID) ? dbNULL : (object)PartnerID);
                SqlParameter errorCodeParam = new SqlParameter("@ErrorCode", null);
                errorCodeParam.Size = 4;
                errorCodeParam.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(errorCodeParam);
                var sda = new SqlDataAdapter(cmd);
                sda.Fill(dt);

                if (errorCodeParam.Value.ToString() != "0")
                    throw new Exception("Stored Procedure 'usp_Partner_SelectOne' reported the ErrorCode : " + errorCodeParam.Value.ToString());

                return dt;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public int PartnerImageDelete(
            string PartnerID
        )
        {
            try
            {
                var scon = new SqlConnection(connectionString);
                var cmd = new SqlCommand("usp_PartnerImage_Delete", scon);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@PartnerID", string.IsNullOrEmpty(PartnerID) ? dbNULL : (object)PartnerID);
                SqlParameter errorCodeParam = new SqlParameter("@ErrorCode", null);
                errorCodeParam.Size = 4;
                errorCodeParam.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(errorCodeParam);
                scon.Open();
                int success = cmd.ExecuteNonQuery();
                scon.Close();

                if (errorCodeParam.Value.ToString() != "0")
                    throw new Exception("Stored Procedure 'usp_PartnerImage_Delete' reported the ErrorCode : " + errorCodeParam.Value.ToString());

                return success;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}

