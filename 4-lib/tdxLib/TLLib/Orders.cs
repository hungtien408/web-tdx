using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace TLLib
{
    public class Orders
    {

        #region Class Member Declaration
        private string m_OrderID;
        #endregion
        string connectionString = Common.ConnectionString;
        DBNull dbNULL = DBNull.Value;

        public int OrdersInsert(
            string OrderID,
            string UserName,
            string OrderStatusID,
            string ShippingStatusID,
            string PaymentMethodID,
            string BillingAddressID,
            string ShippingAddressID,
            string Notes,
            string Commission,
            string DeliveryMethodsID,
            string DeliveryDate,
            string DeliveryAddress,
            string ServiceID
        )
        {
            try
            {
                var scon = new SqlConnection(connectionString);
                var cmd = new SqlCommand("usp_Orders_Insert", scon);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@OrderID", string.IsNullOrEmpty(OrderID) ? dbNULL : (object)OrderID);
                cmd.Parameters.AddWithValue("@UserName", string.IsNullOrEmpty(UserName) ? dbNULL : (object)UserName);
                cmd.Parameters.AddWithValue("@OrderStatusID", string.IsNullOrEmpty(OrderStatusID) ? dbNULL : (object)OrderStatusID);
                cmd.Parameters.AddWithValue("@ShippingStatusID", string.IsNullOrEmpty(ShippingStatusID) ? dbNULL : (object)ShippingStatusID);
                cmd.Parameters.AddWithValue("@PaymentMethodID", string.IsNullOrEmpty(PaymentMethodID) ? dbNULL : (object)PaymentMethodID);
                cmd.Parameters.AddWithValue("@BillingAddressID", string.IsNullOrEmpty(BillingAddressID) ? dbNULL : (object)BillingAddressID);
                cmd.Parameters.AddWithValue("@ShippingAddressID", string.IsNullOrEmpty(ShippingAddressID) ? dbNULL : (object)ShippingAddressID);
                cmd.Parameters.AddWithValue("@Notes", string.IsNullOrEmpty(Notes) ? dbNULL : (object)Notes);
                cmd.Parameters.AddWithValue("@Commission", string.IsNullOrEmpty(Commission) ? dbNULL : (object)Commission);
                cmd.Parameters.AddWithValue("@DeliveryMethodsID", string.IsNullOrEmpty(DeliveryMethodsID) ? dbNULL : (object)DeliveryMethodsID);
                cmd.Parameters.AddWithValue("@DeliveryDate", string.IsNullOrEmpty(DeliveryDate) ? dbNULL : (object)DeliveryDate);
                cmd.Parameters.AddWithValue("@DeliveryAddress", string.IsNullOrEmpty(DeliveryAddress) ? dbNULL : (object)DeliveryAddress);
                cmd.Parameters.AddWithValue("@ServiceID", string.IsNullOrEmpty(ServiceID) ? dbNULL : (object)ServiceID);

                SqlParameter errorCodeParam = new SqlParameter("@ErrorCode", null);
                errorCodeParam.Size = 4;
                errorCodeParam.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(errorCodeParam);
                scon.Open();
                int success = cmd.ExecuteNonQuery();
                scon.Close();

                if (errorCodeParam.Value.ToString() != "0")
                    throw new Exception("Stored Procedure 'usp_Orders_Insert' reported the ErrorCode : " + errorCodeParam.Value.ToString());

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

        public int OrdersInsert1(
            string OrderID,
            string UserName,
            string OrderStatusID,
            string ShippingStatusID,
            string PaymentMethodID,
            string BillingAddressID,
            string ShippingAddressID,
            string Notes,
            string Commission,
            string DeliveryMethodsID,
            string DeliveryDate,
            string DeliveryAddress,
            string ServiceID,
            string Email
        )
        {
            try
            {
                var scon = new SqlConnection(connectionString);
                var cmd = new SqlCommand("usp_Orders_Insert1", scon);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@OrderID", string.IsNullOrEmpty(OrderID) ? dbNULL : (object)OrderID);
                cmd.Parameters.AddWithValue("@UserName", string.IsNullOrEmpty(UserName) ? dbNULL : (object)UserName);
                cmd.Parameters.AddWithValue("@OrderStatusID", string.IsNullOrEmpty(OrderStatusID) ? dbNULL : (object)OrderStatusID);
                cmd.Parameters.AddWithValue("@ShippingStatusID", string.IsNullOrEmpty(ShippingStatusID) ? dbNULL : (object)ShippingStatusID);
                cmd.Parameters.AddWithValue("@PaymentMethodID", string.IsNullOrEmpty(PaymentMethodID) ? dbNULL : (object)PaymentMethodID);
                cmd.Parameters.AddWithValue("@BillingAddressID", string.IsNullOrEmpty(BillingAddressID) ? dbNULL : (object)BillingAddressID);
                cmd.Parameters.AddWithValue("@ShippingAddressID", string.IsNullOrEmpty(ShippingAddressID) ? dbNULL : (object)ShippingAddressID);
                cmd.Parameters.AddWithValue("@Notes", string.IsNullOrEmpty(Notes) ? dbNULL : (object)Notes);
                cmd.Parameters.AddWithValue("@Commission", string.IsNullOrEmpty(Commission) ? dbNULL : (object)Commission);
                cmd.Parameters.AddWithValue("@DeliveryMethodsID", string.IsNullOrEmpty(DeliveryMethodsID) ? dbNULL : (object)DeliveryMethodsID);
                cmd.Parameters.AddWithValue("@DeliveryDate", string.IsNullOrEmpty(DeliveryDate) ? dbNULL : (object)DeliveryDate);
                cmd.Parameters.AddWithValue("@DeliveryAddress", string.IsNullOrEmpty(DeliveryAddress) ? dbNULL : (object)DeliveryAddress);
                cmd.Parameters.AddWithValue("@ServiceID", string.IsNullOrEmpty(ServiceID) ? dbNULL : (object)ServiceID);
                cmd.Parameters.AddWithValue("@Email", string.IsNullOrEmpty(Email) ? dbNULL : (object)Email);

                SqlParameter errorCodeParam = new SqlParameter("@ErrorCode", null);
                SqlParameter orderIDParam = new SqlParameter("@OutOrderID", null);

                errorCodeParam.Size = 4;
                orderIDParam.Size = 10;

                errorCodeParam.Direction = orderIDParam.Direction = ParameterDirection.Output;

                cmd.Parameters.Add(errorCodeParam);
                cmd.Parameters.Add(orderIDParam);

                scon.Open();
                int success = cmd.ExecuteNonQuery();
                scon.Close();

                if (errorCodeParam.Value.ToString() != "0")
                    throw new Exception("Stored Procedure 'usp_Orders_Insert1' reported the ErrorCode : " + errorCodeParam.Value.ToString());

                m_OrderID = orderIDParam.Value.ToString();

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

        public int OrdersUpdate(
            string OrderID,
            string UserName,
            string OrderStatusID,
            string ShippingStatusID,
            string PaymentMethodID,
            string BillingAddressID,
            string ShippingAddressID,
            string Notes,
            string DeliveryMethodsID,
            string DeliveryDate,
            string DeliveryAddress,
            string ServiceID
        )
        {
            try
            {
                var scon = new SqlConnection(connectionString);
                var cmd = new SqlCommand("usp_Orders_Update", scon);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@OrderID", string.IsNullOrEmpty(OrderID) ? dbNULL : (object)OrderID);
                cmd.Parameters.AddWithValue("@UserName", string.IsNullOrEmpty(UserName) ? dbNULL : (object)UserName);
                cmd.Parameters.AddWithValue("@OrderStatusID", string.IsNullOrEmpty(OrderStatusID) ? dbNULL : (object)OrderStatusID);
                cmd.Parameters.AddWithValue("@ShippingStatusID", string.IsNullOrEmpty(ShippingStatusID) ? dbNULL : (object)ShippingStatusID);
                cmd.Parameters.AddWithValue("@PaymentMethodID", string.IsNullOrEmpty(PaymentMethodID) ? dbNULL : (object)PaymentMethodID);
                cmd.Parameters.AddWithValue("@BillingAddressID", string.IsNullOrEmpty(BillingAddressID) ? dbNULL : (object)BillingAddressID);
                cmd.Parameters.AddWithValue("@ShippingAddressID", string.IsNullOrEmpty(ShippingAddressID) ? dbNULL : (object)ShippingAddressID);
                cmd.Parameters.AddWithValue("@Notes", string.IsNullOrEmpty(Notes) ? dbNULL : (object)Notes);
                cmd.Parameters.AddWithValue("@DeliveryMethodsID", string.IsNullOrEmpty(DeliveryMethodsID) ? dbNULL : (object)DeliveryMethodsID);
                cmd.Parameters.AddWithValue("@DeliveryDate", string.IsNullOrEmpty(DeliveryDate) ? dbNULL : (object)DeliveryDate);
                cmd.Parameters.AddWithValue("@DeliveryAddress", string.IsNullOrEmpty(DeliveryAddress) ? dbNULL : (object)DeliveryAddress);

                SqlParameter errorCodeParam = new SqlParameter("@ErrorCode", null);
                errorCodeParam.Size = 4;
                errorCodeParam.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(errorCodeParam);
                scon.Open();
                int success = cmd.ExecuteNonQuery();
                scon.Close();

                if (errorCodeParam.Value.ToString() != "0")
                    throw new Exception("Stored Procedure 'usp_Orders_Update' reported the ErrorCode : " + errorCodeParam.Value.ToString());

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

        public int OrdersUpdate(
            string OrderID,
            string UserName,
            string OrderStatusID,
            string ShippingStatusID,
            string PaymentMethodID,
            string BillingAddressID,
            string ShippingAddressID,
            string Notes,
            string DeliveryMethodsID,
            string DeliveryDate,
            string DeliveryAddress,
            string ServiceID,
            string Email
        )
        {
            try
            {
                var scon = new SqlConnection(connectionString);
                var cmd = new SqlCommand("usp_Orders_Update1", scon);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@OrderID", string.IsNullOrEmpty(OrderID) ? dbNULL : (object)OrderID);
                cmd.Parameters.AddWithValue("@UserName", string.IsNullOrEmpty(UserName) ? dbNULL : (object)UserName);
                cmd.Parameters.AddWithValue("@OrderStatusID", string.IsNullOrEmpty(OrderStatusID) ? dbNULL : (object)OrderStatusID);
                cmd.Parameters.AddWithValue("@ShippingStatusID", string.IsNullOrEmpty(ShippingStatusID) ? dbNULL : (object)ShippingStatusID);
                cmd.Parameters.AddWithValue("@PaymentMethodID", string.IsNullOrEmpty(PaymentMethodID) ? dbNULL : (object)PaymentMethodID);
                cmd.Parameters.AddWithValue("@BillingAddressID", string.IsNullOrEmpty(BillingAddressID) ? dbNULL : (object)BillingAddressID);
                cmd.Parameters.AddWithValue("@ShippingAddressID", string.IsNullOrEmpty(ShippingAddressID) ? dbNULL : (object)ShippingAddressID);
                cmd.Parameters.AddWithValue("@Notes", string.IsNullOrEmpty(Notes) ? dbNULL : (object)Notes);
                cmd.Parameters.AddWithValue("@DeliveryMethodsID", string.IsNullOrEmpty(DeliveryMethodsID) ? dbNULL : (object)DeliveryMethodsID);
                cmd.Parameters.AddWithValue("@DeliveryDate", string.IsNullOrEmpty(DeliveryDate) ? dbNULL : (object)DeliveryDate);
                cmd.Parameters.AddWithValue("@DeliveryAddress", string.IsNullOrEmpty(DeliveryAddress) ? dbNULL : (object)DeliveryAddress);
                cmd.Parameters.AddWithValue("@Email", string.IsNullOrEmpty(Email) ? dbNULL : (object)Email);

                SqlParameter errorCodeParam = new SqlParameter("@ErrorCode", null);
                errorCodeParam.Size = 4;
                errorCodeParam.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(errorCodeParam);
                scon.Open();
                int success = cmd.ExecuteNonQuery();
                scon.Close();

                if (errorCodeParam.Value.ToString() != "0")
                    throw new Exception("Stored Procedure 'usp_Orders_Update1' reported the ErrorCode : " + errorCodeParam.Value.ToString());

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

        public int OrdersQuickUpdate(
            string OrderID,
            string UserName,
            string OrderStatusID,
            string ShippingStatusID,
            string PaymentMethodID,
            string BillingAddressID,
            string ShippingAddressID,
            string Notes
        )
        {
            try
            {
                var scon = new SqlConnection(connectionString);
                var cmd = new SqlCommand("usp_Orders_QuickUpdate", scon);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@OrderID", string.IsNullOrEmpty(OrderID) ? dbNULL : (object)OrderID);
                cmd.Parameters.AddWithValue("@UserName", string.IsNullOrEmpty(UserName) ? dbNULL : (object)UserName);
                cmd.Parameters.AddWithValue("@OrderStatusID", string.IsNullOrEmpty(OrderStatusID) ? dbNULL : (object)OrderStatusID);
                cmd.Parameters.AddWithValue("@ShippingStatusID", string.IsNullOrEmpty(ShippingStatusID) ? dbNULL : (object)ShippingStatusID);
                cmd.Parameters.AddWithValue("@PaymentMethodID", string.IsNullOrEmpty(PaymentMethodID) ? dbNULL : (object)PaymentMethodID);
                cmd.Parameters.AddWithValue("@BillingAddressID", string.IsNullOrEmpty(BillingAddressID) ? dbNULL : (object)BillingAddressID);
                cmd.Parameters.AddWithValue("@ShippingAddressID", string.IsNullOrEmpty(ShippingAddressID) ? dbNULL : (object)ShippingAddressID);
                cmd.Parameters.AddWithValue("@Notes", string.IsNullOrEmpty(Notes) ? dbNULL : (object)Notes);

                SqlParameter errorCodeParam = new SqlParameter("@ErrorCode", null);
                errorCodeParam.Size = 4;
                errorCodeParam.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(errorCodeParam);
                scon.Open();
                int success = cmd.ExecuteNonQuery();
                scon.Close();

                if (errorCodeParam.Value.ToString() != "0")
                    throw new Exception("Stored Procedure 'usp_Orders_QuickUpdate' reported the ErrorCode : " + errorCodeParam.Value.ToString());

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

        public int OrdersQuickUpdate1(
            string OrderID,
            string UserName,
            string OrderStatusID,
            string ShippingStatusID,
            string PaymentMethodID,
            string BillingAddressID,
            string ShippingAddressID,
            string Notes,
            string PayStatusID
        )
        {
            try
            {
                var scon = new SqlConnection(connectionString);
                var cmd = new SqlCommand("usp_Orders_QuickUpdate1", scon);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@OrderID", string.IsNullOrEmpty(OrderID) ? dbNULL : (object)OrderID);
                cmd.Parameters.AddWithValue("@UserName", string.IsNullOrEmpty(UserName) ? dbNULL : (object)UserName);
                cmd.Parameters.AddWithValue("@OrderStatusID", string.IsNullOrEmpty(OrderStatusID) ? dbNULL : (object)OrderStatusID);
                cmd.Parameters.AddWithValue("@ShippingStatusID", string.IsNullOrEmpty(ShippingStatusID) ? dbNULL : (object)ShippingStatusID);
                cmd.Parameters.AddWithValue("@PaymentMethodID", string.IsNullOrEmpty(PaymentMethodID) ? dbNULL : (object)PaymentMethodID);
                cmd.Parameters.AddWithValue("@BillingAddressID", string.IsNullOrEmpty(BillingAddressID) ? dbNULL : (object)BillingAddressID);
                cmd.Parameters.AddWithValue("@ShippingAddressID", string.IsNullOrEmpty(ShippingAddressID) ? dbNULL : (object)ShippingAddressID);
                cmd.Parameters.AddWithValue("@Notes", string.IsNullOrEmpty(Notes) ? dbNULL : (object)Notes);
                cmd.Parameters.AddWithValue("@PayStatusID", string.IsNullOrEmpty(PayStatusID) ? dbNULL : (object)PayStatusID);

                SqlParameter errorCodeParam = new SqlParameter("@ErrorCode", null);
                errorCodeParam.Size = 4;
                errorCodeParam.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(errorCodeParam);
                scon.Open();
                int success = cmd.ExecuteNonQuery();
                scon.Close();

                if (errorCodeParam.Value.ToString() != "0")
                    throw new Exception("Stored Procedure 'usp_Orders_QuickUpdate1' reported the ErrorCode : " + errorCodeParam.Value.ToString());

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

        public int OrdersQuickUpdate_PayStatusID(
            string OrderID,
            string PayStatusID
        )
        {
            try
            {
                var scon = new SqlConnection(connectionString);
                var cmd = new SqlCommand("usp_Orders_QuickUpdate_PayStatus", scon);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@OrderID", string.IsNullOrEmpty(OrderID) ? dbNULL : (object)OrderID);
                cmd.Parameters.AddWithValue("@PayStatusID", string.IsNullOrEmpty(PayStatusID) ? dbNULL : (object)PayStatusID);

                SqlParameter errorCodeParam = new SqlParameter("@ErrorCode", null);
                errorCodeParam.Size = 4;
                errorCodeParam.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(errorCodeParam);
                scon.Open();
                int success = cmd.ExecuteNonQuery();
                scon.Close();

                if (errorCodeParam.Value.ToString() != "0")
                    throw new Exception("Stored Procedure 'usp_Orders_QuickUpdate_PayStatus' reported the ErrorCode : " + errorCodeParam.Value.ToString());

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

        public int OrdersIsCancel(
            string OrderID,
            string OrderStatusID
        )
        {
            try
            {
                var scon = new SqlConnection(connectionString);
                var cmd = new SqlCommand("usp_Orders_IsCancel", scon);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@OrderID", string.IsNullOrEmpty(OrderID) ? dbNULL : (object)OrderID);
                cmd.Parameters.AddWithValue("@OrderStatusID", string.IsNullOrEmpty(OrderStatusID) ? dbNULL : (object)OrderStatusID);

                SqlParameter errorCodeParam = new SqlParameter("@ErrorCode", null);
                errorCodeParam.Size = 4;
                errorCodeParam.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(errorCodeParam);
                scon.Open();
                int success = cmd.ExecuteNonQuery();
                scon.Close();

                if (errorCodeParam.Value.ToString() != "0")
                    throw new Exception("Stored Procedure 'usp_Orders_IsCancel' reported the ErrorCode : " + errorCodeParam.Value.ToString());

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

        public int OrdersDelete(
            string OrderID
        )
        {
            try
            {
                var scon = new SqlConnection(connectionString);
                var cmd = new SqlCommand("usp_Orders_Delete", scon);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@OrderID", string.IsNullOrEmpty(OrderID) ? dbNULL : (object)OrderID);
                SqlParameter errorCodeParam = new SqlParameter("@ErrorCode", null);
                errorCodeParam.Size = 4;
                errorCodeParam.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(errorCodeParam);
                scon.Open();
                int success = cmd.ExecuteNonQuery();
                scon.Close();

                if (errorCodeParam.Value.ToString() != "0")
                    throw new Exception("Stored Procedure 'usp_Orders_Delete' reported the ErrorCode : " + errorCodeParam.Value.ToString());

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

        public DataTable OrdersSelectAll(
            string OrderID,
            string UserName,
            string OrderStatusID,
            string ShippingStatusID,
            string PaymentMethodID,
            string BillingAddressID,
            string ShippingAddressID,
            string Notes,
            string FromDate,
            string ToDate,
            string ProvinceID,
            string DistrictID
        )
        {
            try
            {
                var dt = new DataTable();
                var scon = new SqlConnection(connectionString);
                var cmd = new SqlCommand("usp_Orders_SelectAll", scon);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@OrderID", string.IsNullOrEmpty(OrderID) ? dbNULL : (object)OrderID);
                cmd.Parameters.AddWithValue("@UserName", string.IsNullOrEmpty(UserName) ? dbNULL : (object)UserName);
                cmd.Parameters.AddWithValue("@OrderStatusID", string.IsNullOrEmpty(OrderStatusID) ? dbNULL : (object)OrderStatusID);
                cmd.Parameters.AddWithValue("@ShippingStatusID", string.IsNullOrEmpty(ShippingStatusID) ? dbNULL : (object)ShippingStatusID);
                cmd.Parameters.AddWithValue("@PaymentMethodID", string.IsNullOrEmpty(PaymentMethodID) ? dbNULL : (object)PaymentMethodID);
                cmd.Parameters.AddWithValue("@BillingAddressID", string.IsNullOrEmpty(BillingAddressID) ? dbNULL : (object)BillingAddressID);
                cmd.Parameters.AddWithValue("@ShippingAddressID", string.IsNullOrEmpty(ShippingAddressID) ? dbNULL : (object)ShippingAddressID);
                cmd.Parameters.AddWithValue("@Notes", string.IsNullOrEmpty(Notes) ? dbNULL : (object)Notes);
                cmd.Parameters.AddWithValue("@FromDate", string.IsNullOrEmpty(FromDate) ? dbNULL : (object)FromDate);
                cmd.Parameters.AddWithValue("@ToDate", string.IsNullOrEmpty(ToDate) ? dbNULL : (object)ToDate);
                cmd.Parameters.AddWithValue("@ProvinceID", string.IsNullOrEmpty(ProvinceID) ? dbNULL : (object)ProvinceID);
                cmd.Parameters.AddWithValue("@DistrictID", string.IsNullOrEmpty(DistrictID) ? dbNULL : (object)DistrictID);

                SqlParameter errorCodeParam = new SqlParameter("@ErrorCode", null);
                errorCodeParam.Size = 4;
                errorCodeParam.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(errorCodeParam);
                var sda = new SqlDataAdapter(cmd);
                sda.Fill(dt);

                if (errorCodeParam.Value.ToString() != "0")
                    throw new Exception("Stored Procedure 'usp_Orders_SelectAll' reported the ErrorCode : " + errorCodeParam.Value.ToString());

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

        public DataTable OrdersSelectAll1(
            string OrderID,
            string UserName,
            string OrderStatusID,
            string ShippingStatusID,
            string PaymentMethodID,
            string BillingAddressID,
            string ShippingAddressID,
            string Notes,
            string FromDate,
            string ToDate,
            string ProvinceID,
            string DistrictID,
            string Email
        )
        {
            try
            {
                var dt = new DataTable();
                var scon = new SqlConnection(connectionString);
                var cmd = new SqlCommand("usp_Orders_SelectAll1", scon);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@OrderID", string.IsNullOrEmpty(OrderID) ? dbNULL : (object)OrderID);
                cmd.Parameters.AddWithValue("@UserName", string.IsNullOrEmpty(UserName) ? dbNULL : (object)UserName);
                cmd.Parameters.AddWithValue("@OrderStatusID", string.IsNullOrEmpty(OrderStatusID) ? dbNULL : (object)OrderStatusID);
                cmd.Parameters.AddWithValue("@ShippingStatusID", string.IsNullOrEmpty(ShippingStatusID) ? dbNULL : (object)ShippingStatusID);
                cmd.Parameters.AddWithValue("@PaymentMethodID", string.IsNullOrEmpty(PaymentMethodID) ? dbNULL : (object)PaymentMethodID);
                cmd.Parameters.AddWithValue("@BillingAddressID", string.IsNullOrEmpty(BillingAddressID) ? dbNULL : (object)BillingAddressID);
                cmd.Parameters.AddWithValue("@ShippingAddressID", string.IsNullOrEmpty(ShippingAddressID) ? dbNULL : (object)ShippingAddressID);
                cmd.Parameters.AddWithValue("@Notes", string.IsNullOrEmpty(Notes) ? dbNULL : (object)Notes);
                cmd.Parameters.AddWithValue("@FromDate", string.IsNullOrEmpty(FromDate) ? dbNULL : (object)FromDate);
                cmd.Parameters.AddWithValue("@ToDate", string.IsNullOrEmpty(ToDate) ? dbNULL : (object)ToDate);
                cmd.Parameters.AddWithValue("@ProvinceID", string.IsNullOrEmpty(ProvinceID) ? dbNULL : (object)ProvinceID);
                cmd.Parameters.AddWithValue("@DistrictID", string.IsNullOrEmpty(DistrictID) ? dbNULL : (object)DistrictID);
                cmd.Parameters.AddWithValue("@Email", string.IsNullOrEmpty(Email) ? dbNULL : (object)Email);

                SqlParameter errorCodeParam = new SqlParameter("@ErrorCode", null);
                errorCodeParam.Size = 4;
                errorCodeParam.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(errorCodeParam);
                var sda = new SqlDataAdapter(cmd);
                sda.Fill(dt);

                if (errorCodeParam.Value.ToString() != "0")
                    throw new Exception("Stored Procedure 'usp_Orders_SelectAll1' reported the ErrorCode : " + errorCodeParam.Value.ToString());

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

        public DataTable OrdersSelectAllNoUser(
            string OrderID,
            string UserName,
            string OrderStatusID,
            string ShippingStatusID,
            string PaymentMethodID,
            string BillingAddressID,
            string ShippingAddressID,
            string Notes,
            string FromDate,
            string ToDate,
            string ProvinceID,
            string DistrictID,
            string Email
        )
        {
            try
            {
                var dt = new DataTable();
                var scon = new SqlConnection(connectionString);
                var cmd = new SqlCommand("usp_Orders_SelectAll_NoUser", scon);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@OrderID", string.IsNullOrEmpty(OrderID) ? dbNULL : (object)OrderID);
                cmd.Parameters.AddWithValue("@UserName", string.IsNullOrEmpty(UserName) ? dbNULL : (object)UserName);
                cmd.Parameters.AddWithValue("@OrderStatusID", string.IsNullOrEmpty(OrderStatusID) ? dbNULL : (object)OrderStatusID);
                cmd.Parameters.AddWithValue("@ShippingStatusID", string.IsNullOrEmpty(ShippingStatusID) ? dbNULL : (object)ShippingStatusID);
                cmd.Parameters.AddWithValue("@PaymentMethodID", string.IsNullOrEmpty(PaymentMethodID) ? dbNULL : (object)PaymentMethodID);
                cmd.Parameters.AddWithValue("@BillingAddressID", string.IsNullOrEmpty(BillingAddressID) ? dbNULL : (object)BillingAddressID);
                cmd.Parameters.AddWithValue("@ShippingAddressID", string.IsNullOrEmpty(ShippingAddressID) ? dbNULL : (object)ShippingAddressID);
                cmd.Parameters.AddWithValue("@Notes", string.IsNullOrEmpty(Notes) ? dbNULL : (object)Notes);
                cmd.Parameters.AddWithValue("@FromDate", string.IsNullOrEmpty(FromDate) ? dbNULL : (object)FromDate);
                cmd.Parameters.AddWithValue("@ToDate", string.IsNullOrEmpty(ToDate) ? dbNULL : (object)ToDate);
                cmd.Parameters.AddWithValue("@ProvinceID", string.IsNullOrEmpty(ProvinceID) ? dbNULL : (object)ProvinceID);
                cmd.Parameters.AddWithValue("@DistrictID", string.IsNullOrEmpty(DistrictID) ? dbNULL : (object)DistrictID);
                cmd.Parameters.AddWithValue("@Email", string.IsNullOrEmpty(Email) ? dbNULL : (object)Email);

                SqlParameter errorCodeParam = new SqlParameter("@ErrorCode", null);
                errorCodeParam.Size = 4;
                errorCodeParam.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(errorCodeParam);
                var sda = new SqlDataAdapter(cmd);
                sda.Fill(dt);

                if (errorCodeParam.Value.ToString() != "0")
                    throw new Exception("Stored Procedure 'usp_Orders_SelectAll_NoUser' reported the ErrorCode : " + errorCodeParam.Value.ToString());

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

        public DataTable OrdersSelectOne(
            string OrderID
        )
        {
            try
            {
                var dt = new DataTable();
                var scon = new SqlConnection(connectionString);
                var cmd = new SqlCommand("usp_Orders_SelectOne", scon);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@OrderID", string.IsNullOrEmpty(OrderID) ? dbNULL : (object)OrderID);
                SqlParameter errorCodeParam = new SqlParameter("@ErrorCode", null);
                errorCodeParam.Size = 4;
                errorCodeParam.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(errorCodeParam);
                var sda = new SqlDataAdapter(cmd);
                sda.Fill(dt);

                if (errorCodeParam.Value.ToString() != "0")
                    throw new Exception("Stored Procedure 'usp_Orders_SelectOne' reported the ErrorCode : " + errorCodeParam.Value.ToString());

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

        #region Properties

        public string OrderID
        {
            get { return m_OrderID; }
            set { m_OrderID = value; }
        }

        #endregion
    }
}

