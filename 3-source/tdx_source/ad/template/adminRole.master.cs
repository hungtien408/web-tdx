using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Threading;
using System.Globalization;
using Telerik.Web.UI;
using System.Web.Security;

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

            //RadMenuItem currentItem = RadMenu1.FindItemByUrl(strURL);

            //if (currentItem == null)
            //    RadMenu1.Items[0].HighlightPath();
            //else
            //    currentItem.HighlightPath();

            RadMenuItem currentItem = RadMenu1.FindItemByUrl(strURL);

            if (currentItem == null)
                RadMenu1.Items[0].HighlightPath();
            else
                currentItem.HighlightPath();
            string userName = Page.User.Identity.Name;
            string[] dsRole = Roles.GetRolesForUser(userName);

            foreach (RadMenuItem item in RadMenu1.Items)
            {
                if (!dsRole.Contains(item.Value.ToString()))
                {
                    if (item.Value.ToString() != "Trang Chủ")
                    {
                        item.Visible = false;
                    }
                }
            }
        }
    }
}
