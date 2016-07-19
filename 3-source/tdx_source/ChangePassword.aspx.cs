using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;

public partial class Changepass_ChangePassword : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void ChangePassword1_ContinueButtonClick(object sender, EventArgs e)
    {
        var roles = Roles.GetRolesForUser(User.Identity.Name);
        if (roles[0] == "admin")
            Response.Redirect("~/ad/");
        else if (roles[0] == "student")

            Response.Redirect("~/dkmhol/");

        else
            Response.Redirect("~/tn/");
    }
}