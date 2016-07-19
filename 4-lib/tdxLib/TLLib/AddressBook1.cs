using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace TLLib
{
    public class AddressBook1
    {
        string connectionString = Common.ConnectionString;
        DBNull dbNULL = DBNull.Value;

        public int AddressBook1Insert(
            string FirstName,
            string LastName,
            string Email,
            string HomePhone,
            string CellPhone,
            string Fax,
            //string ReceiveEmail,
            string UserName,
            string Company,
            string Address1,
            string Address2,
            string ZipCode,
            string City,
            string CountryID,
            string ProvinceID,
            string DistrictID,
            string IsPrimary,
            string IsPrimaryBilling,
            string IsPrimaryShipping,
            string RoleName
        )
        {
            try
            {
                var scon = new SqlConnection(connectionString);
                var cmd = new SqlCommand("usp_AddressBook1_Insert", scon);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@FirstName", string.IsNullOrEmpty(FirstName) ? dbNULL : (object)FirstName);
                cmd.Parameters.AddWithValue("@LastName", string.IsNullOrEmpty(LastName) ? dbNULL : (object)LastName);
                cmd.Parameters.AddWithValue("@Email", string.IsNullOrEmpty(Email) ? dbNULL : (object)Email);
                cmd.Parameters.AddWithValue("@HomePhone", string.IsNullOrEmpty(HomePhone) ? dbNULL : (object)HomePhone);
                cmd.Parameters.AddWithValue("@CellPhone", string.IsNullOrEmpty(CellPhone) ? dbNULL : (object)CellPhone);
                cmd.Parameters.AddWithValue("@Fax", string.IsNullOrEmpty(Fax) ? dbNULL : (object)Fax);
                //cmd.Parameters.AddWithValue("@ReceiveEmail", string.IsNullOrEmpty(ReceiveEmail) ? dbNULL : (object)ReceiveEmail);
                cmd.Parameters.AddWithValue("@UserName", string.IsNullOrEmpty(UserName) ? dbNULL : (object)UserName);
                cmd.Parameters.AddWithValue("@Company", string.IsNullOrEmpty(Company) ? dbNULL : (object)Company);
                cmd.Parameters.AddWithValue("@Address1", string.IsNullOrEmpty(Address1) ? dbNULL : (object)Address1);
                cmd.Parameters.AddWithValue("@Address2", string.IsNullOrEmpty(Address2) ? dbNULL : (object)Address2);
                cmd.Parameters.AddWithValue("@ZipCode", string.IsNullOrEmpty(ZipCode) ? dbNULL : (object)ZipCode);
                cmd.Parameters.AddWithValue("@City", string.IsNullOrEmpty(City) ? dbNULL : (object)City);
                cmd.Parameters.AddWithValue("@CountryID", string.IsNullOrEmpty(CountryID) ? dbNULL : (object)CountryID);
                cmd.Parameters.AddWithValue("@ProvinceID", string.IsNullOrEmpty(ProvinceID) ? dbNULL : (object)ProvinceID);
                cmd.Parameters.AddWithValue("@DistrictID", string.IsNullOrEmpty(DistrictID) ? dbNULL : (object)DistrictID);
                cmd.Parameters.AddWithValue("@IsPrimary", string.IsNullOrEmpty(IsPrimary) ? dbNULL : (object)IsPrimary);
                cmd.Parameters.AddWithValue("@IsPrimaryBilling", string.IsNullOrEmpty(IsPrimaryBilling) ? dbNULL : (object)IsPrimaryBilling);
                cmd.Parameters.AddWithValue("@IsPrimaryShipping", string.IsNullOrEmpty(IsPrimaryShipping) ? dbNULL : (object)IsPrimaryShipping);
                cmd.Parameters.AddWithValue("@RoleName", string.IsNullOrEmpty(RoleName) ? dbNULL : (object)RoleName);
                SqlParameter errorCodeParam = new SqlParameter("@ErrorCode", null);
                errorCodeParam.Size = 4;
                errorCodeParam.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(errorCodeParam);
                scon.Open();
                int success = cmd.ExecuteNonQuery();
                scon.Close();

                if (errorCodeParam.Value.ToString() != "0")
                    throw new Exception("Stored Procedure 'usp_AddressBook1_Insert' reported the ErrorCode : " + errorCodeParam.Value.ToString());

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

        public int AddressBook1Update(
            string AddressBookID,
            string FirstName,
            string LastName,
            string Email,
            string HomePhone,
            string CellPhone,
            string Fax,
            //string ReceiveEmail,
            string UserName,
            string Company,
            string Address1,
            string Address2,
            string ZipCode,
            string City,
            string CountryID,
            string ProvinceID,
            string DistrictID,
            string IsPrimary,
            string IsPrimaryBilling,
            string IsPrimaryShipping,
            string RoleName
        )
        {
            try
            {
                var scon = new SqlConnection(connectionString);
                var cmd = new SqlCommand("usp_AddressBook1_Update", scon);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@AddressBookID", string.IsNullOrEmpty(AddressBookID) ? dbNULL : (object)AddressBookID);
                cmd.Parameters.AddWithValue("@FirstName", string.IsNullOrEmpty(FirstName) ? dbNULL : (object)FirstName);
                cmd.Parameters.AddWithValue("@LastName", string.IsNullOrEmpty(LastName) ? dbNULL : (object)LastName);
                cmd.Parameters.AddWithValue("@Email", string.IsNullOrEmpty(Email) ? dbNULL : (object)Email);
                cmd.Parameters.AddWithValue("@HomePhone", string.IsNullOrEmpty(HomePhone) ? dbNULL : (object)HomePhone);
                cmd.Parameters.AddWithValue("@CellPhone", string.IsNullOrEmpty(CellPhone) ? dbNULL : (object)CellPhone);
                cmd.Parameters.AddWithValue("@Fax", string.IsNullOrEmpty(Fax) ? dbNULL : (object)Fax);
                //cmd.Parameters.AddWithValue("@ReceiveEmail", string.IsNullOrEmpty(ReceiveEmail) ? dbNULL : (object)ReceiveEmail);
                cmd.Parameters.AddWithValue("@UserName", string.IsNullOrEmpty(UserName) ? dbNULL : (object)UserName);
                cmd.Parameters.AddWithValue("@Company", string.IsNullOrEmpty(Company) ? dbNULL : (object)Company);
                cmd.Parameters.AddWithValue("@Address1", string.IsNullOrEmpty(Address1) ? dbNULL : (object)Address1);
                cmd.Parameters.AddWithValue("@Address2", string.IsNullOrEmpty(Address2) ? dbNULL : (object)Address2);
                cmd.Parameters.AddWithValue("@ZipCode", string.IsNullOrEmpty(ZipCode) ? dbNULL : (object)ZipCode);
                cmd.Parameters.AddWithValue("@City", string.IsNullOrEmpty(City) ? dbNULL : (object)City);
                cmd.Parameters.AddWithValue("@CountryID", string.IsNullOrEmpty(CountryID) ? dbNULL : (object)CountryID);
                cmd.Parameters.AddWithValue("@ProvinceID", string.IsNullOrEmpty(ProvinceID) ? dbNULL : (object)ProvinceID);
                cmd.Parameters.AddWithValue("@DistrictID", string.IsNullOrEmpty(DistrictID) ? dbNULL : (object)DistrictID);
                cmd.Parameters.AddWithValue("@IsPrimary", string.IsNullOrEmpty(IsPrimary) ? dbNULL : (object)IsPrimary);
                cmd.Parameters.AddWithValue("@IsPrimaryBilling", string.IsNullOrEmpty(IsPrimaryBilling) ? dbNULL : (object)IsPrimaryBilling);
                cmd.Parameters.AddWithValue("@IsPrimaryShipping", string.IsNullOrEmpty(IsPrimaryShipping) ? dbNULL : (object)IsPrimaryShipping);
                cmd.Parameters.AddWithValue("@RoleName", string.IsNullOrEmpty(RoleName) ? dbNULL : (object)RoleName);
                SqlParameter errorCodeParam = new SqlParameter("@ErrorCode", null);
                errorCodeParam.Size = 4;
                errorCodeParam.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(errorCodeParam);
                scon.Open();
                int success = cmd.ExecuteNonQuery();
                scon.Close();

                if (errorCodeParam.Value.ToString() != "0")
                    throw new Exception("Stored Procedure 'usp_AddressBook1_Update' reported the ErrorCode : " + errorCodeParam.Value.ToString());

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

        public int AddressBook1Delete(
            string AddressBookID
        )
        {
            try
            {
                var scon = new SqlConnection(connectionString);
                var cmd = new SqlCommand("usp_AddressBook1_Delete", scon);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@AddressBookID", string.IsNullOrEmpty(AddressBookID) ? dbNULL : (object)AddressBookID);
                SqlParameter errorCodeParam = new SqlParameter("@ErrorCode", null);
                errorCodeParam.Size = 4;
                errorCodeParam.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(errorCodeParam);
                scon.Open();
                int success = cmd.ExecuteNonQuery();
                scon.Close();

                if (errorCodeParam.Value.ToString() != "0")
                    throw new Exception("Stored Procedure 'usp_AddressBook1_Delete' reported the ErrorCode : " + errorCodeParam.Value.ToString());

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

        public DataTable AddressBook1SelectAll(
            string AddressBookID,
            string FirstName,
            string LastName,
            string Email,
            string HomePhone,
            string CellPhone,
            string Fax,
            //string ReceiveEmail,
            string UserName,
            string Company,
            string Address1,
            string Address2,
            string ZipCode,
            string City,
            string CountryID,
            string ProvinceID,
            string DistrictID,
            string IsPrimary,
            string IsPrimaryBilling,
            string IsPrimaryShipping,
            string RoleName
        )
        {
            try
            {
                var dt = new DataTable();
                var scon = new SqlConnection(connectionString);
                var cmd = new SqlCommand("usp_AddressBook1_SelectAll", scon);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@AddressBookID", string.IsNullOrEmpty(AddressBookID) ? dbNULL : (object)AddressBookID);
                cmd.Parameters.AddWithValue("@FirstName", string.IsNullOrEmpty(FirstName) ? dbNULL : (object)FirstName);
                cmd.Parameters.AddWithValue("@LastName", string.IsNullOrEmpty(LastName) ? dbNULL : (object)LastName);
                cmd.Parameters.AddWithValue("@Email", string.IsNullOrEmpty(Email) ? dbNULL : (object)Email);
                cmd.Parameters.AddWithValue("@HomePhone", string.IsNullOrEmpty(HomePhone) ? dbNULL : (object)HomePhone);
                cmd.Parameters.AddWithValue("@CellPhone", string.IsNullOrEmpty(CellPhone) ? dbNULL : (object)CellPhone);
                cmd.Parameters.AddWithValue("@Fax", string.IsNullOrEmpty(Fax) ? dbNULL : (object)Fax);
                //cmd.Parameters.AddWithValue("@ReceiveEmail", string.IsNullOrEmpty(ReceiveEmail) ? dbNULL : (object)ReceiveEmail);
                cmd.Parameters.AddWithValue("@UserName", string.IsNullOrEmpty(UserName) ? dbNULL : (object)UserName);
                cmd.Parameters.AddWithValue("@Company", string.IsNullOrEmpty(Company) ? dbNULL : (object)Company);
                cmd.Parameters.AddWithValue("@Address1", string.IsNullOrEmpty(Address1) ? dbNULL : (object)Address1);
                cmd.Parameters.AddWithValue("@Address2", string.IsNullOrEmpty(Address2) ? dbNULL : (object)Address2);
                cmd.Parameters.AddWithValue("@ZipCode", string.IsNullOrEmpty(ZipCode) ? dbNULL : (object)ZipCode);
                cmd.Parameters.AddWithValue("@City", string.IsNullOrEmpty(City) ? dbNULL : (object)City);
                cmd.Parameters.AddWithValue("@CountryID", string.IsNullOrEmpty(CountryID) ? dbNULL : (object)CountryID);
                cmd.Parameters.AddWithValue("@ProvinceID", string.IsNullOrEmpty(ProvinceID) ? dbNULL : (object)ProvinceID);
                cmd.Parameters.AddWithValue("@DistrictID", string.IsNullOrEmpty(DistrictID) ? dbNULL : (object)DistrictID);
                cmd.Parameters.AddWithValue("@IsPrimary", string.IsNullOrEmpty(IsPrimary) ? dbNULL : (object)IsPrimary);
                cmd.Parameters.AddWithValue("@IsPrimaryBilling", string.IsNullOrEmpty(IsPrimaryBilling) ? dbNULL : (object)IsPrimaryBilling);
                cmd.Parameters.AddWithValue("@IsPrimaryShipping", string.IsNullOrEmpty(IsPrimaryShipping) ? dbNULL : (object)IsPrimaryShipping);
                cmd.Parameters.AddWithValue("@RoleName", string.IsNullOrEmpty(RoleName) ? dbNULL : (object)RoleName);
                SqlParameter errorCodeParam = new SqlParameter("@ErrorCode", null);
                errorCodeParam.Size = 4;
                errorCodeParam.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(errorCodeParam);
                var sda = new SqlDataAdapter(cmd);
                sda.Fill(dt);

                if (errorCodeParam.Value.ToString() != "0")
                    throw new Exception("Stored Procedure 'usp_AddressBook1_SelectAll' reported the ErrorCode : " + errorCodeParam.Value.ToString());

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

        public DataTable AddressBook1SelectOne(
            string AddressBookID
        )
        {
            try
            {
                var dt = new DataTable();
                var scon = new SqlConnection(connectionString);
                var cmd = new SqlCommand("usp_AddressBook1_SelectOne", scon);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@AddressBookID", string.IsNullOrEmpty(AddressBookID) ? dbNULL : (object)AddressBookID);
                SqlParameter errorCodeParam = new SqlParameter("@ErrorCode", null);
                errorCodeParam.Size = 4;
                errorCodeParam.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(errorCodeParam);
                var sda = new SqlDataAdapter(cmd);
                sda.Fill(dt);

                if (errorCodeParam.Value.ToString() != "0")
                    throw new Exception("Stored Procedure 'usp_AddressBook1_SelectOne' reported the ErrorCode : " + errorCodeParam.Value.ToString());

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
    }
}

