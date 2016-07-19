using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web.Security;
using System.Text.RegularExpressions;

namespace TLLib
{
    public class User
    {
        string connectionString = Common.ConnectionString;
        DBNull dbNULL = DBNull.Value;

        public void UserDelete(string UserName)
        {
            try
            {
                Membership.DeleteUser(UserName, true);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void UserInsert(string UserName, string Email, string Password, string Role)
        {
            try
            {
                Membership.CreateUser(UserName, Password, Email);

                if (!string.IsNullOrEmpty(Role))
                    Roles.AddUserToRole(UserName, Role);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void ChangeRole(string UserName, string NewRole)
        {
            try
            {
                var roles = Roles.GetRolesForUser(UserName);

                if (roles.Length > 0)
                    Roles.RemoveUserFromRoles(UserName, roles);

                if (!string.IsNullOrEmpty(NewRole))
                    Roles.AddUserToRole(UserName, NewRole);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void ChangePassword(string UserName, string NewPassword)
        {
            try
            {
                MembershipUser mu = Membership.GetUser(UserName);
                mu.ChangePassword(mu.ResetPassword(), NewPassword);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public DataTable UserSelectAll(
            string UserName,
            string Email,
            string Role
        )
        {
            try
            {
                var dt = new DataTable();
                var scon = new SqlConnection(connectionString);
                var cmd = new SqlCommand("usp_User_SelectAll", scon);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@UserName", string.IsNullOrEmpty(UserName) ? dbNULL : (object)UserName.Trim());
                cmd.Parameters.AddWithValue("@Email", string.IsNullOrEmpty(Email) ? dbNULL : (object)Email.Trim());
                cmd.Parameters.AddWithValue("@Role", string.IsNullOrEmpty(Role) ? dbNULL : (object)Role);

                SqlParameter errorCodeParam = new SqlParameter("@ErrorCode", null);
                errorCodeParam.Size = 4;
                errorCodeParam.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(errorCodeParam);
                var sda = new SqlDataAdapter(cmd);
                sda.Fill(dt);

                if (errorCodeParam.Value.ToString() != "0")
                    throw new Exception("Stored Procedure 'usp_User_SelectAll' reported the ErrorCode : " + errorCodeParam.Value.ToString());

                return dt;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        //public DataTable UserSelectAll(
        //    string UserName,
        //    string Email,
        //    string Role
        //    )
        //{
        //    try
        //    {
        //        var dt = new DataTable();
        //        dt.Columns.Add("UserName");
        //        dt.Columns.Add("Email");
        //        dt.Columns.Add("IsOnline");
        //        dt.Columns.Add("LastLoginDate");
        //        dt.Columns.Add("CreationDate");
        //        dt.Columns.Add("Role");

        //        UserName = UserName == null ? "" : Common.ReplaceRegex(UserName.Trim().ToLower(), @"\")).Replace("_", @"\w");
        //        Email = Email == null ? "" : Common.ReplaceRegex(Email.Trim().ToLower(), @"\")).Replace("_", @"\w");
        //        Role = Role == null ? "" : Role.Trim();

        //        var userCollection = !string.IsNullOrEmpty(Role) ? Roles.GetUsersInRole(Role) : from MembershipUser mu in Membership.GetAllUsers() select mu.UserName;

        //        var usersFounded = from string user in userCollection
        //                           where
        //                               (!string.IsNullOrEmpty(UserName) ? Regex.IsMatch(user, UserName) : !string.IsNullOrEmpty(user)) //&&
        //                               !string.IsNullOrEmpty(Email) ? Regex.IsMatch(Membership.GetUser(user).Email, Email) : !string.IsNullOrEmpty(Membership.GetUser(user).Email)
        //                           select user;

        //        var newUserCollection = new MembershipUserCollection();

        //        foreach (string user in usersFounded)
        //        {
        //            var mu = Membership.GetUser(user);

        //            var strUserName = mu.UserName;
        //            var strEmail = mu.Email;
        //            var strIsOnline = mu.IsOnline;
        //            var strLastLoginDate = mu.LastLoginDate;
        //            var strCreationDate = mu.CreationDate;
        //            var userRoles = Roles.GetRolesForUser(user);
        //            var strRole = userRoles.Length == 0 ? "" : userRoles[0];

        //            dt.Rows.Add(new object[] { strUserName, strEmail, strIsOnline, strLastLoginDate, strCreationDate, strRole });
        //        }

        //        return dt;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw new Exception(ex.Message);
        //    }
        //}

        public string[] RoleSelectAll()
        {
            var roleCollection = Roles.GetAllRoles();
            return roleCollection;
        }
    }
}

