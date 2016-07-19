using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Threading;
using System.Globalization;

public partial class ad_template_inside : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Page.Header.DataBind();
            Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture("vi-VN");
            Thread.CurrentThread.CurrentUICulture = new CultureInfo("vi-VN");
        }
        Response.Cache.SetCacheability(HttpCacheability.NoCache);
        Response.Cache.SetAllowResponseInBrowserHistory(false);
    }
}
