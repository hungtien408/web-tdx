using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;

public partial class createusers : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        
    }
    protected void Login1_LoggedIn(object sender, EventArgs e)
    {
        //string UserName = Login1.UserName;
        //MembershipUser mu = Membership.GetUser(UserName);
        ////Session["PWD"] = Login1.Password;
        //if (UserName != null)
        //{
        //    string[] roleUser = Roles.GetRolesForUser(UserName.ToString());
        //    for (int i = 0; i < roleUser.Length; i++)
        //    {
        //        if (roleUser[i] == "admin")
        //        {
        //            Response.Redirect("ad/single/");
        //        }
        //        else
        //        {
        //            Response.Redirect("ad/member/ongoing-project.aspx");
        //        }
        //    }
        //}
        if (Request.QueryString["ReturnURL"] != null)
        {
            Response.Redirect(Request.QueryString["ReturnURL"]);
        }
        else
        {
            Response.Redirect("~/");
        }
    }
}
