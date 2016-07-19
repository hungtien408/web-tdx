using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace TLLib
{
    public class Comment
    {
        string connectionString = Common.ConnectionString;
        DBNull dbNULL = DBNull.Value;

        public int CommentInsert(
            string UserName,
            string Link,
            string Title,
            string Content,
            string Priority,
            string IsApproved,
            string IsAvailable
        )
        {
            try
            {
                var scon = new SqlConnection(connectionString);
                var cmd = new SqlCommand("usp_Comment_Insert", scon);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@UserName", string.IsNullOrEmpty(UserName) ? dbNULL : (object)UserName);
                cmd.Parameters.AddWithValue("@Link", string.IsNullOrEmpty(Link) ? dbNULL : (object)Link);
                cmd.Parameters.AddWithValue("@Title", string.IsNullOrEmpty(Title) ? dbNULL : (object)Title);
                cmd.Parameters.AddWithValue("@Content", string.IsNullOrEmpty(Content) ? dbNULL : (object)Content);
                cmd.Parameters.AddWithValue("@Priority", string.IsNullOrEmpty(Priority) ? dbNULL : (object)Priority);
                cmd.Parameters.AddWithValue("@IsApproved", string.IsNullOrEmpty(IsApproved) ? dbNULL : (object)IsApproved);
                cmd.Parameters.AddWithValue("@IsAvailable", string.IsNullOrEmpty(IsAvailable) ? dbNULL : (object)IsAvailable);
                SqlParameter errorCodeParam = new SqlParameter("@ErrorCode", null);
                errorCodeParam.Size = 4;
                errorCodeParam.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(errorCodeParam);
                scon.Open();
                int success = cmd.ExecuteNonQuery();
                scon.Close();

                if (errorCodeParam.Value.ToString() != "0")
                    throw new Exception("Stored Procedure 'usp_Comment_Insert' reported the ErrorCode : " + errorCodeParam.Value.ToString());

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

        public int CommentUpdate(
            string CommentID,
            string UserName,
            string Link,
            string Title,
            string Content,
            string Priority,
            string IsApproved,
            string IsAvailable
        )
        {
            try
            {
                var scon = new SqlConnection(connectionString);
                var cmd = new SqlCommand("usp_Comment_Update", scon);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@CommentID", string.IsNullOrEmpty(CommentID) ? dbNULL : (object)CommentID);
                cmd.Parameters.AddWithValue("@UserName", string.IsNullOrEmpty(UserName) ? dbNULL : (object)UserName);
                cmd.Parameters.AddWithValue("@Link", string.IsNullOrEmpty(Link) ? dbNULL : (object)Link);
                cmd.Parameters.AddWithValue("@Title", string.IsNullOrEmpty(Title) ? dbNULL : (object)Title);
                cmd.Parameters.AddWithValue("@Content", string.IsNullOrEmpty(Content) ? dbNULL : (object)Content);
                cmd.Parameters.AddWithValue("@Priority", string.IsNullOrEmpty(Priority) ? dbNULL : (object)Priority);
                cmd.Parameters.AddWithValue("@IsApproved", string.IsNullOrEmpty(IsApproved) ? dbNULL : (object)IsApproved);
                cmd.Parameters.AddWithValue("@IsAvailable", string.IsNullOrEmpty(IsAvailable) ? dbNULL : (object)IsAvailable);
                SqlParameter errorCodeParam = new SqlParameter("@ErrorCode", null);
                errorCodeParam.Size = 4;
                errorCodeParam.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(errorCodeParam);
                scon.Open();
                int success = cmd.ExecuteNonQuery();
                scon.Close();

                if (errorCodeParam.Value.ToString() != "0")
                    throw new Exception("Stored Procedure 'usp_Comment_Update' reported the ErrorCode : " + errorCodeParam.Value.ToString());

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

        public int CommentDelete(
            string CommentID
        )
        {
            try
            {
                var scon = new SqlConnection(connectionString);
                var cmd = new SqlCommand("usp_Comment_Delete", scon);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@CommentID", string.IsNullOrEmpty(CommentID) ? dbNULL : (object)CommentID);
                SqlParameter errorCodeParam = new SqlParameter("@ErrorCode", null);
                errorCodeParam.Size = 4;
                errorCodeParam.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(errorCodeParam);
                scon.Open();
                int success = cmd.ExecuteNonQuery();
                scon.Close();

                if (errorCodeParam.Value.ToString() != "0")
                    throw new Exception("Stored Procedure 'usp_Comment_Delete' reported the ErrorCode : " + errorCodeParam.Value.ToString());

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

        public int CommentQuickUpdate(
            string CommentID,
            string IsApproved,
            string IsAvailable,
            string Priority
        )
        {
            try
            {
                var scon = new SqlConnection(connectionString);
                var cmd = new SqlCommand("usp_Comment_QuickUpdate", scon);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@CommentID", string.IsNullOrEmpty(CommentID) ? dbNULL : (object)CommentID);
                cmd.Parameters.AddWithValue("@IsApproved", string.IsNullOrEmpty(IsApproved) ? dbNULL : (object)IsApproved);
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
                    throw new Exception("Stored Procedure 'usp_Comment_QuickUpdate' reported the ErrorCode : " + errorCodeParam.Value.ToString());

                return success;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public DataTable CommentSelectAll(
            string CommentID,
            string UserName,
            string Keyword,
            string Link,
            string Title,
            string Content,
            string CreateDate,
            string UpdateDate,
            string FromDate,
            string ToDate,
            string Priority,
            string IsApproved,
            string IsAvailable
        )
        {
            try
            {
                var dt = new DataTable();
                var scon = new SqlConnection(connectionString);
                var cmd = new SqlCommand("usp_Comment_SelectAll", scon);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@CommentID", string.IsNullOrEmpty(CommentID) ? dbNULL : (object)CommentID);
                cmd.Parameters.AddWithValue("@UserName", string.IsNullOrEmpty(UserName) ? dbNULL : (object)UserName);
                cmd.Parameters.AddWithValue("@Keyword", string.IsNullOrEmpty(Keyword) ? dbNULL : (object)Keyword);
                cmd.Parameters.AddWithValue("@Link", string.IsNullOrEmpty(Link) ? dbNULL : (object)Link);
                cmd.Parameters.AddWithValue("@Title", string.IsNullOrEmpty(Title) ? dbNULL : (object)Title);
                cmd.Parameters.AddWithValue("@Content", string.IsNullOrEmpty(Content) ? dbNULL : (object)Content);
                cmd.Parameters.AddWithValue("@CreateDate", string.IsNullOrEmpty(CreateDate) ? dbNULL : (object)CreateDate);
                cmd.Parameters.AddWithValue("@UpdateDate", string.IsNullOrEmpty(UpdateDate) ? dbNULL : (object)UpdateDate);
                cmd.Parameters.AddWithValue("@FromDate", string.IsNullOrEmpty(FromDate) ? dbNULL : (object)FromDate);
                cmd.Parameters.AddWithValue("@ToDate", string.IsNullOrEmpty(ToDate) ? dbNULL : (object)ToDate);
                cmd.Parameters.AddWithValue("@Priority", string.IsNullOrEmpty(Priority) ? dbNULL : (object)Priority);
                cmd.Parameters.AddWithValue("@IsApproved", string.IsNullOrEmpty(IsApproved) ? dbNULL : (object)IsApproved);
                cmd.Parameters.AddWithValue("@IsAvailable", string.IsNullOrEmpty(IsAvailable) ? dbNULL : (object)IsAvailable);
                SqlParameter errorCodeParam = new SqlParameter("@ErrorCode", null);
                errorCodeParam.Size = 4;
                errorCodeParam.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(errorCodeParam);
                var sda = new SqlDataAdapter(cmd);
                sda.Fill(dt);

                if (errorCodeParam.Value.ToString() != "0")
                    throw new Exception("Stored Procedure 'usp_Comment_SelectAll' reported the ErrorCode : " + errorCodeParam.Value.ToString());

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

        public DataTable CommentSelectOne(
            string CommentID
        )
        {
            try
            {
                var dt = new DataTable();
                var scon = new SqlConnection(connectionString);
                var cmd = new SqlCommand("usp_Comment_SelectOne", scon);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@CommentID", string.IsNullOrEmpty(CommentID) ? dbNULL : (object)CommentID);
                SqlParameter errorCodeParam = new SqlParameter("@ErrorCode", null);
                errorCodeParam.Size = 4;
                errorCodeParam.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(errorCodeParam);
                var sda = new SqlDataAdapter(cmd);
                sda.Fill(dt);

                if (errorCodeParam.Value.ToString() != "0")
                    throw new Exception("Stored Procedure 'usp_Comment_SelectOne' reported the ErrorCode : " + errorCodeParam.Value.ToString());

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

