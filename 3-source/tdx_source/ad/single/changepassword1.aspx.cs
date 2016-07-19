using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;
using TLLib;

public partial class ad_single_changepassword : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
            lblUserName.Text = Request.QueryString["usn"];
    }

    protected void btnSearch_Click(object sender, EventArgs e)
    {
        var oUser = new User();
        oUser.ChangePassword(lblUserName.Text, txtNewPassWord.Text);
        Label1.Visible = true;
    }
}