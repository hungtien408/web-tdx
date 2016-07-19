using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace TLLib
{
    public class UserProfile
    {
        string connectionString = Common.ConnectionString;
        DBNull dbNULL = DBNull.Value;

        public int UserProfileInsert(
            string UserID,
            string CompanyName,
            string FullName,
            string Address,
            string HomePhone,
            string CellPhone,
            string Fax,
            string AvatarImage,
            string IsAvailable
        )
        {
            try
            {
                var scon = new SqlConnection(connectionString);
                var cmd = new SqlCommand("usp_UserProfile_Insert", scon);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("UserID", string.IsNullOrEmpty(UserID) ? dbNULL : (object)UserID);
                cmd.Parameters.AddWithValue("CompanyName", string.IsNullOrEmpty(CompanyName) ? dbNULL : (object)CompanyName);
                cmd.Parameters.AddWithValue("FullName", string.IsNullOrEmpty(FullName) ? dbNULL : (object)FullName);
                cmd.Parameters.AddWithValue("Address", string.IsNullOrEmpty(Address) ? dbNULL : (object)Address);
                cmd.Parameters.AddWithValue("HomePhone", string.IsNullOrEmpty(HomePhone) ? dbNULL : (object)HomePhone);
                cmd.Parameters.AddWithValue("CellPhone", string.IsNullOrEmpty(CellPhone) ? dbNULL : (object)CellPhone);
                cmd.Parameters.AddWithValue("Fax", string.IsNullOrEmpty(Fax) ? dbNULL : (object)Fax);
                cmd.Parameters.AddWithValue("AvatarImage", string.IsNullOrEmpty(AvatarImage) ? dbNULL : (object)AvatarImage);
                cmd.Parameters.AddWithValue("IsAvailable", string.IsNullOrEmpty(IsAvailable) ? dbNULL : (object)IsAvailable);
                SqlParameter errorCodeParam = new SqlParameter("ErrorCode", null);
                errorCodeParam.Size = 4;
                errorCodeParam.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(errorCodeParam);
                scon.Open();
                int success = cmd.ExecuteNonQuery();
                scon.Close();

                if (errorCodeParam.Value.ToString() != "0")
                    throw new Exception("Stored Procedure 'usp_UserProfile_Insert' reported the ErrorCode : " + errorCodeParam.Value.ToString());

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

        public int UserProfileUpdate(
            string UserID,
            string CompanyName,
            string FullName,
            string Address,
            string HomePhone,
            string CellPhone,
            string Fax,
            string AvatarImage,
            string IsAvailable
        )
        {
            try
            {
                var scon = new SqlConnection(connectionString);
                var cmd = new SqlCommand("usp_UserProfile_Update", scon);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("UserID", string.IsNullOrEmpty(UserID) ? dbNULL : (object)UserID);
                cmd.Parameters.AddWithValue("CompanyName", string.IsNullOrEmpty(CompanyName) ? dbNULL : (object)CompanyName);
                cmd.Parameters.AddWithValue("FullName", string.IsNullOrEmpty(FullName) ? dbNULL : (object)FullName);
                cmd.Parameters.AddWithValue("Address", string.IsNullOrEmpty(Address) ? dbNULL : (object)Address);
                cmd.Parameters.AddWithValue("HomePhone", string.IsNullOrEmpty(HomePhone) ? dbNULL : (object)HomePhone);
                cmd.Parameters.AddWithValue("CellPhone", string.IsNullOrEmpty(CellPhone) ? dbNULL : (object)CellPhone);
                cmd.Parameters.AddWithValue("Fax", string.IsNullOrEmpty(Fax) ? dbNULL : (object)Fax);
                cmd.Parameters.AddWithValue("AvatarImage", string.IsNullOrEmpty(AvatarImage) ? dbNULL : (object)AvatarImage);
                cmd.Parameters.AddWithValue("IsAvailable", string.IsNullOrEmpty(IsAvailable) ? dbNULL : (object)IsAvailable);
                SqlParameter errorCodeParam = new SqlParameter("ErrorCode", null);
                errorCodeParam.Size = 4;
                errorCodeParam.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(errorCodeParam);
                scon.Open();
                int success = cmd.ExecuteNonQuery();
                scon.Close();

                if (errorCodeParam.Value.ToString() != "0")
                    throw new Exception("Stored Procedure 'usp_UserProfile_Update' reported the ErrorCode : " + errorCodeParam.Value.ToString());

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

        public int UserProfileDelete(
            string UserID
        )
        {
            try
            {
                var scon = new SqlConnection(connectionString);
                var cmd = new SqlCommand("usp_UserProfile_Delete", scon);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("UserID", string.IsNullOrEmpty(UserID) ? dbNULL : (object)UserID);
                SqlParameter errorCodeParam = new SqlParameter("ErrorCode", null);
                errorCodeParam.Size = 4;
                errorCodeParam.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(errorCodeParam);
                scon.Open();
                int success = cmd.ExecuteNonQuery();
                scon.Close();

                if (errorCodeParam.Value.ToString() != "0")
                    throw new Exception("Stored Procedure 'usp_UserProfile_Delete' reported the ErrorCode : " + errorCodeParam.Value.ToString());

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

        public DataTable UserProfileSelectAll(
            string Keyword,
            string UserName,
            string Email,
            string Role,
            string CompanyName,
            string FullName,
            string Address,
            string HomePhone,
            string CellPhone,
            string Fax
        )
        {
            try
            {
                var dt = new DataTable();
                var scon = new SqlConnection(connectionString);
                var cmd = new SqlCommand("usp_UserProfile_SelectAll", scon);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("Keyword", string.IsNullOrEmpty(Keyword) ? dbNULL : (object)Keyword);
                cmd.Parameters.AddWithValue("UserName", string.IsNullOrEmpty(UserName) ? dbNULL : (object)UserName);
                cmd.Parameters.AddWithValue("Email", string.IsNullOrEmpty(Email) ? dbNULL : (object)Email);
                cmd.Parameters.AddWithValue("Role", string.IsNullOrEmpty(Role) ? dbNULL : (object)Role);
                cmd.Parameters.AddWithValue("CompanyName", string.IsNullOrEmpty(CompanyName) ? dbNULL : (object)CompanyName);
                cmd.Parameters.AddWithValue("FullName", string.IsNullOrEmpty(FullName) ? dbNULL : (object)FullName);
                cmd.Parameters.AddWithValue("Address", string.IsNullOrEmpty(Address) ? dbNULL : (object)Address);
                cmd.Parameters.AddWithValue("HomePhone", string.IsNullOrEmpty(HomePhone) ? dbNULL : (object)HomePhone);
                cmd.Parameters.AddWithValue("CellPhone", string.IsNullOrEmpty(CellPhone) ? dbNULL : (object)CellPhone);
                cmd.Parameters.AddWithValue("Fax", string.IsNullOrEmpty(Fax) ? dbNULL : (object)Fax);
                SqlParameter errorCodeParam = new SqlParameter("ErrorCode", null);
                errorCodeParam.Size = 4;
                errorCodeParam.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(errorCodeParam);
                var sda = new SqlDataAdapter(cmd);
                sda.Fill(dt);

                if (errorCodeParam.Value.ToString() != "0")
                    throw new Exception("Stored Procedure 'usp_UserProfile_SelectAll' reported the ErrorCode : " + errorCodeParam.Value.ToString());

                return dt;
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

        public DataTable UserProfileSelectAll1(
            string Keyword,
            string UserName,
            string Email,
            string Role,
            string CompanyName,
            string FullName,
            string Address,
            string HomePhone,
            string CellPhone,
            string Fax
        )
        {
            try
            {
                var dt = new DataTable();
                var scon = new SqlConnection(connectionString);
                var cmd = new SqlCommand("usp_UserProfile_SelectAll1", scon);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("Keyword", string.IsNullOrEmpty(Keyword) ? dbNULL : (object)Keyword);
                cmd.Parameters.AddWithValue("UserName", string.IsNullOrEmpty(UserName) ? dbNULL : (object)UserName);
                cmd.Parameters.AddWithValue("Email", string.IsNullOrEmpty(Email) ? dbNULL : (object)Email);
                cmd.Parameters.AddWithValue("Role", string.IsNullOrEmpty(Role) ? dbNULL : (object)Role);
                cmd.Parameters.AddWithValue("CompanyName", string.IsNullOrEmpty(CompanyName) ? dbNULL : (object)CompanyName);
                cmd.Parameters.AddWithValue("FullName", string.IsNullOrEmpty(FullName) ? dbNULL : (object)FullName);
                cmd.Parameters.AddWithValue("Address", string.IsNullOrEmpty(Address) ? dbNULL : (object)Address);
                cmd.Parameters.AddWithValue("HomePhone", string.IsNullOrEmpty(HomePhone) ? dbNULL : (object)HomePhone);
                cmd.Parameters.AddWithValue("CellPhone", string.IsNullOrEmpty(CellPhone) ? dbNULL : (object)CellPhone);
                cmd.Parameters.AddWithValue("Fax", string.IsNullOrEmpty(Fax) ? dbNULL : (object)Fax);
                SqlParameter errorCodeParam = new SqlParameter("ErrorCode", null);
                errorCodeParam.Size = 4;
                errorCodeParam.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(errorCodeParam);
                var sda = new SqlDataAdapter(cmd);
                sda.Fill(dt);

                if (errorCodeParam.Value.ToString() != "0")
                    throw new Exception("Stored Procedure 'usp_UserProfile_SelectAll1' reported the ErrorCode : " + errorCodeParam.Value.ToString());

                return dt;
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

        public DataTable UserProfileSelectOne(
            string UserID
        )
        {
            try
            {
                var dt = new DataTable();
                var scon = new SqlConnection(connectionString);
                var cmd = new SqlCommand("usp_UserProfile_SelectOne", scon);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("UserID", string.IsNullOrEmpty(UserID) ? dbNULL : (object)UserID);
                SqlParameter errorCodeParam = new SqlParameter("ErrorCode", null);
                errorCodeParam.Size = 4;
                errorCodeParam.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(errorCodeParam);
                var sda = new SqlDataAdapter(cmd);
                sda.Fill(dt);

                if (errorCodeParam.Value.ToString() != "0")
                    throw new Exception("Stored Procedure 'usp_UserProfile_SelectOne' reported the ErrorCode : " + errorCodeParam.Value.ToString());

                return dt;
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

        public int UserProfileImageDelete(
            string UserID
        )
        {
            try
            {
                var scon = new SqlConnection(connectionString);
                var cmd = new SqlCommand("usp_UserProfileImage_Delete", scon);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@UserID", string.IsNullOrEmpty(UserID) ? dbNULL : (object)UserID);
                SqlParameter errorCodeParam = new SqlParameter("@ErrorCode", null);
                errorCodeParam.Size = 4;
                errorCodeParam.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(errorCodeParam);
                scon.Open();
                int success = cmd.ExecuteNonQuery();
                scon.Close();

                if (errorCodeParam.Value.ToString() != "0")
                    throw new Exception("Stored Procedure 'usp_UserProfileImage_Delete' reported the ErrorCode : " + errorCodeParam.Value.ToString());

                return success;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}

