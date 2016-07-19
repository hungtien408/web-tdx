using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

/// <summary>
/// Summary description for CartItem
/// </summary>
public class ShoppingCart
{
    public void CreateCart(
        string ProductID,
        string ImageName,
        string ProductName,
        string ProductNameEn,
        string ProductCode,
        string ProductOptionCategoryID,
        string ProductOptionCategoryName,
        string ProductLengthID,
        string ProductLengthName,
        string ProductSizeColorID,
        string Quantity,
        string QuantityList,
        double Price,
        bool autoIncreaseQuantity
        )
    {
        var sessionCart = HttpContext.Current.Session["Cart"];
        DataTable dtCart;
        if (sessionCart == null)
        {
            dtCart = new DataTable();
            dtCart.Columns.Add("ProductID");
            dtCart.Columns.Add("ImageName");
            dtCart.Columns.Add("ProductName");
            dtCart.Columns.Add("ProductNameEn");
            dtCart.Columns.Add("Tag");
            dtCart.Columns.Add("ProductOptionCategoryID");
            dtCart.Columns.Add("ProductOptionCategoryName");
            dtCart.Columns.Add("ProductLengthID");
            dtCart.Columns.Add("ProductLengthName");
            dtCart.Columns.Add("ProductSizeColorID");
            dtCart.Columns.Add("Quantity");
            dtCart.Columns.Add("QuantityList");
            dtCart.Columns.Add("Price", typeof(double));

            dtCart.Rows.Add(new object[] { 
                ProductID,
                ImageName,
                ProductName,
                ProductNameEn,
                ProductCode,
                ProductOptionCategoryID,
                ProductOptionCategoryName,
                ProductLengthID,
                ProductLengthName,
                ProductSizeColorID,
                Quantity,
                QuantityList,
                Price
            });
        }
        else
        {
            dtCart = sessionCart as DataTable;

            var existRow = (from DataRow dr in dtCart.Rows
                            where dr["ProductID"].ToString() == ProductID
                            && dr["ProductOptionCategoryID"].ToString() == ProductOptionCategoryID
                            && dr["ProductLengthID"].ToString() == ProductLengthID
                            select dr).FirstOrDefault();

            if (existRow == null)
                dtCart.Rows.Add(new object[] { 
                    ProductID,
                    ImageName,
                    ProductName,
                    ProductNameEn,
                    ProductCode,
                    ProductOptionCategoryID,
                    ProductOptionCategoryName,
                    ProductLengthID,
                    ProductLengthName,
                    ProductSizeColorID,
                    Quantity,
                    QuantityList,
                    Price
                });
            else
            {
                var iQuantity = Convert.ToInt32(existRow["Quantity"]);
                if (autoIncreaseQuantity)
                    existRow["Quantity"] = iQuantity + Convert.ToInt32(Quantity);
                else
                    existRow["Quantity"] = Quantity;
            }
        }
        HttpContext.Current.Session["Cart"] = dtCart;
    }

    public bool HasItem(string ProductID)
    {
        var isExist = false;

        if (HttpContext.Current.Session["Cart"] != null)
        {
            var dtCart = (HttpContext.Current.Session["Cart"] as DataTable).DefaultView;

            dtCart.RowFilter = "ProductID = " + ProductID;

            if (dtCart.Count == 0)
                isExist = false;
        }
        return isExist;
    }

    public void DeleteItem(string ProductID, string ProductOptionCategoryID, string ProductLengthID)
    {
        if (HttpContext.Current.Session["Cart"] != null)
        {
            var dtCart = (HttpContext.Current.Session["Cart"] as DataTable).DefaultView;

            var firstOrDefault = (from DataRowView dr in dtCart
                                  where dr["ProductID"].ToString() == ProductID
                                  && dr["ProductOptionCategoryID"].ToString() == ProductOptionCategoryID
                                  && dr["ProductLengthID"].ToString() == ProductLengthID
                                  select dr).FirstOrDefault();
            if (firstOrDefault != null)
                firstOrDefault.Delete();

            HttpContext.Current.Session["Cart"] = dtCart.ToTable();
        }
    }

    public void DeleteAllItem()
    {
        if (HttpContext.Current.Session["Cart"] != null)
        {
            var dtCart = (HttpContext.Current.Session["Cart"] as DataTable).DefaultView;
            foreach (DataRowView dr in dtCart)
            {
                dr.Delete();
            }
            HttpContext.Current.Session["Cart"] = dtCart.ToTable();
        }
    }

    public void UpdateQuantity(string ProductID, string ProductLengthID, string ProductOptionCategoryID, string Quantity)
    {
        if (HttpContext.Current.Session["Cart"] != null)
        {
            var dtCart = HttpContext.Current.Session["Cart"] as DataTable;

            (from DataRow dr in dtCart.Rows
             where dr["ProductID"].ToString() == ProductID
             && dr["ProductLengthID"].ToString() == ProductLengthID
             && dr["ProductOptionCategoryID"].ToString() == ProductOptionCategoryID
             select dr).FirstOrDefault()["Quantity"] = Quantity;

            HttpContext.Current.Session["Cart"] = dtCart;
        }
    }

    public void UpdateQuantityList(string ProductID, string ProductLengthID, string ProductOptionCategoryID, string Quantity, string QuantityList)
    {
        if (HttpContext.Current.Session["Cart"] != null)
        {
            var dtCart = HttpContext.Current.Session["Cart"] as DataTable;

           var existRow = (from DataRow dr in dtCart.Rows
             where dr["ProductID"].ToString() == ProductID
             //&& dr["ProductLengthID"].ToString() == ProductLengthID
             && dr["ProductOptionCategoryID"].ToString() == ProductOptionCategoryID
             select dr).FirstOrDefault();

           
            if (existRow != null)
            {
                existRow["ProductLengthID"] = ProductLengthID;
                existRow["Quantity"] = Quantity;
                existRow["QuantityList"] = QuantityList;
            }
            HttpContext.Current.Session["Cart"] = dtCart;
        }
    }

    public DataTable Cart()
    {
        if (HttpContext.Current.Session["Cart"] != null)
            return HttpContext.Current.Session["Cart"] as DataTable;

        return null;
    }
}