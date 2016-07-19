using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace TLLib
{
    public class AddressBook
    {
        string connectionString = Common.ConnectionString;
        DBNull dbNULL = DBNull.Value;

        public int AddressBookInsert(
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
                var cmd = new SqlCommand("usp_AddressBook_Insert", scon);
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
                    throw new Exception("Stored Procedure 'usp_AddressBook_Insert' reported the ErrorCode : " + errorCodeParam.Value.ToString());

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

        public string AddressBookInsert2(
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
            string RoleName,
            //string FaceBookID,
            //string FaceBookLinks,
            //string Password,
            string ImageName,
            string ConvertedFirstName
        )
        {
            try
            {
                var scon = new SqlConnection(connectionString);
                var cmd = new SqlCommand("usp_AddressBook_Insert2", scon);
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
                //cmd.Parameters.AddWithValue("@FaceBookID", string.IsNullOrEmpty(FaceBookID) ? dbNULL : (object)FaceBookID);
                //cmd.Parameters.AddWithValue("@FaceBookLinks", string.IsNullOrEmpty(FaceBookLinks) ? dbNULL : (object)FaceBookLinks);
                //cmd.Parameters.AddWithValue("@Password", string.IsNullOrEmpty(Password) ? dbNULL : (object)Password);
                cmd.Parameters.AddWithValue("@ImageName", string.IsNullOrEmpty(ImageName) ? dbNULL : (object)ImageName);
                cmd.Parameters.AddWithValue("@ConvertedFirstName", string.IsNullOrEmpty(ConvertedFirstName) ? dbNULL : (object)ConvertedFirstName);

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
                    throw new Exception("Stored Procedure 'usp_AddressBook_Insert2' reported the ErrorCode : " + errorCodeParam.Value.ToString());

                return imageNameParam.Value.ToString();
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

        public int AddressBookUpdate(
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
                var cmd = new SqlCommand("usp_AddressBook_Update", scon);
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
                    throw new Exception("Stored Procedure 'usp_AddressBook_Update' reported the ErrorCode : " + errorCodeParam.Value.ToString());

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

        public int AddressBookUpdate2(
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
            string RoleName,
            //string FaceBookID,
            //string FaceBookLinks,
            //string Password,
            string ImageName,
            string ConvertedFirstName
        )
        {
            try
            {
                var scon = new SqlConnection(connectionString);
                var cmd = new SqlCommand("usp_AddressBook_Update2", scon);
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
                //cmd.Parameters.AddWithValue("@FaceBookID", string.IsNullOrEmpty(FaceBookID) ? dbNULL : (object)FaceBookID);
                //cmd.Parameters.AddWithValue("@FaceBookLinks", string.IsNullOrEmpty(FaceBookLinks) ? dbNULL : (object)FaceBookLinks);
                //cmd.Parameters.AddWithValue("@Password", string.IsNullOrEmpty(Password) ? dbNULL : (object)Password);
                cmd.Parameters.AddWithValue("@ImageName", string.IsNullOrEmpty(ImageName) ? dbNULL : (object)ImageName);
                cmd.Parameters.AddWithValue("@ConvertedFirstName", string.IsNullOrEmpty(ConvertedFirstName) ? dbNULL : (object)ConvertedFirstName);

                SqlParameter errorCodeParam = new SqlParameter("@ErrorCode", null);
                errorCodeParam.Size = 4;
                errorCodeParam.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(errorCodeParam);
                scon.Open();
                int success = cmd.ExecuteNonQuery();
                scon.Close();

                if (errorCodeParam.Value.ToString() != "0")
                    throw new Exception("Stored Procedure 'usp_AddressBook_Update2' reported the ErrorCode : " + errorCodeParam.Value.ToString());

                return success;
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

        public int AddressBookDelete(
            string AddressBookID
        )
        {
            try
            {
                var scon = new SqlConnection(connectionString);
                var cmd = new SqlCommand("usp_AddressBook_Delete", scon);
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
                    throw new Exception("Stored Procedure 'usp_AddressBook_Delete' reported the ErrorCode : " + errorCodeParam.Value.ToString());

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

        public int AddressBookDeleteByUserName(
            string UserName
        )
        {
            try
            {
                var scon = new SqlConnection(connectionString);
                var cmd = new SqlCommand("usp_AddressBook_Delete_ByUserName", scon);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@UserName", string.IsNullOrEmpty(UserName) ? dbNULL : (object)UserName);
                SqlParameter errorCodeParam = new SqlParameter("@ErrorCode", null);
                errorCodeParam.Size = 4;
                errorCodeParam.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(errorCodeParam);
                scon.Open();
                int success = cmd.ExecuteNonQuery();
                scon.Close();

                if (errorCodeParam.Value.ToString() != "0")
                    throw new Exception("Stored Procedure 'usp_AddressBook_Delete_ByUserName' reported the ErrorCode : " + errorCodeParam.Value.ToString());

                return success;
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

        public DataTable AddressBookSelectAll(
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
                var cmd = new SqlCommand("usp_AddressBook_SelectAll", scon);
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
                    throw new Exception("Stored Procedure 'usp_AddressBook_SelectAll' reported the ErrorCode : " + errorCodeParam.Value.ToString());

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

        public DataTable AddressBookSelectAll2(
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
                var cmd = new SqlCommand("usp_AddressBook_SelectAll2", scon);
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
                    throw new Exception("Stored Procedure 'usp_AddressBook_SelectAll2' reported the ErrorCode : " + errorCodeParam.Value.ToString());

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

        public DataTable AddressBookSelectOne(
            string AddressBookID
        )
        {
            try
            {
                var dt = new DataTable();
                var scon = new SqlConnection(connectionString);
                var cmd = new SqlCommand("usp_AddressBook_SelectOne", scon);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@AddressBookID", string.IsNullOrEmpty(AddressBookID) ? dbNULL : (object)AddressBookID);
                SqlParameter errorCodeParam = new SqlParameter("@ErrorCode", null);
                errorCodeParam.Size = 4;
                errorCodeParam.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(errorCodeParam);
                var sda = new SqlDataAdapter(cmd);
                sda.Fill(dt);

                if (errorCodeParam.Value.ToString() != "0")
                    throw new Exception("Stored Procedure 'usp_AddressBook_SelectOne' reported the ErrorCode : " + errorCodeParam.Value.ToString());

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

        public DataTable UserProfileSelectAll_AddressBook(
            string UserName,
            string Email,
            string RoleName,
            string Company,
            string FirstName,
            string LastName,
            //string ReceiveEmail,
            string Address1,
            string Address2,
            string HomePhone,
            string CellPhone,
            string Fax,
            string CountryID,
            string ProvinceID,
            string DistrictID,
            string IsPrimary,
            string IsPrimaryBilling,
            string IsPrimaryShipping
        )
        {
            try
            {
                var dt = new DataTable();
                var scon = new SqlConnection(connectionString);
                var cmd = new SqlCommand("usp_UserProfile_SelectAll_AddressBook", scon);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@UserName", string.IsNullOrEmpty(UserName) ? dbNULL : (object)UserName);
                cmd.Parameters.AddWithValue("@Email", string.IsNullOrEmpty(Email) ? dbNULL : (object)Email);
                cmd.Parameters.AddWithValue("@RoleName", string.IsNullOrEmpty(RoleName) ? dbNULL : (object)RoleName);
                cmd.Parameters.AddWithValue("@FirstName", string.IsNullOrEmpty(FirstName) ? dbNULL : (object)FirstName);
                cmd.Parameters.AddWithValue("@LastName", string.IsNullOrEmpty(LastName) ? dbNULL : (object)LastName);
                cmd.Parameters.AddWithValue("@HomePhone", string.IsNullOrEmpty(HomePhone) ? dbNULL : (object)HomePhone);
                cmd.Parameters.AddWithValue("@CellPhone", string.IsNullOrEmpty(CellPhone) ? dbNULL : (object)CellPhone);
                cmd.Parameters.AddWithValue("@Fax", string.IsNullOrEmpty(Fax) ? dbNULL : (object)Fax);
                //cmd.Parameters.AddWithValue("@ReceiveEmail", string.IsNullOrEmpty(ReceiveEmail) ? dbNULL : (object)ReceiveEmail);
                cmd.Parameters.AddWithValue("@Company", string.IsNullOrEmpty(Company) ? dbNULL : (object)Company);
                cmd.Parameters.AddWithValue("@Address1", string.IsNullOrEmpty(Address1) ? dbNULL : (object)Address1);
                cmd.Parameters.AddWithValue("@Address2", string.IsNullOrEmpty(Address2) ? dbNULL : (object)Address2);

                cmd.Parameters.AddWithValue("@CountryID", string.IsNullOrEmpty(CountryID) ? dbNULL : (object)CountryID);
                cmd.Parameters.AddWithValue("@ProvinceID", string.IsNullOrEmpty(ProvinceID) ? dbNULL : (object)ProvinceID);
                cmd.Parameters.AddWithValue("@DistrictID", string.IsNullOrEmpty(DistrictID) ? dbNULL : (object)DistrictID);
                cmd.Parameters.AddWithValue("@IsPrimary", string.IsNullOrEmpty(IsPrimary) ? dbNULL : (object)IsPrimary);
                cmd.Parameters.AddWithValue("@IsPrimaryBilling", string.IsNullOrEmpty(IsPrimaryBilling) ? dbNULL : (object)IsPrimaryBilling);
                cmd.Parameters.AddWithValue("@IsPrimaryShipping", string.IsNullOrEmpty(IsPrimaryShipping) ? dbNULL : (object)IsPrimaryShipping);

                SqlParameter errorCodeParam = new SqlParameter("@ErrorCode", null);
                errorCodeParam.Size = 4;
                errorCodeParam.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(errorCodeParam);
                var sda = new SqlDataAdapter(cmd);
                sda.Fill(dt);

                if (errorCodeParam.Value.ToString() != "0")
                    throw new Exception("Stored Procedure 'usp_UserProfile_SelectAll_AddressBook' reported the ErrorCode : " + errorCodeParam.Value.ToString());

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
    }
}

