using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Threading;
using System.Globalization;
using Telerik.Web.UI;

public partial class ad_template_admin : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Page.Header.DataBind();
            Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture("vi-VN");
            Thread.CurrentThread.CurrentUICulture = new CultureInfo("vi-VN");
            string strURL = Request.Url.AbsolutePath.ToLower();

            RadMenuItem currentItem = RadMenu1.FindItemByUrl(strURL);

            if (currentItem == null)
                RadMenu1.Items[0].HighlightPath();
            else
                currentItem.HighlightPath();
        }
    }
}
