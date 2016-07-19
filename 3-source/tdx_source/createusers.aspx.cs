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
        if (!IsPostBack)
        {
            string[] roles = Roles.GetAllRoles();
            for (int i = 0; i < roles.Length; i++)
            {
                ddlrole.Items.Add(roles[i]);
                ddlrole.Items[i].Value = roles[i];
            }
        }
    }
    protected void CreateUserWizard1_CreatedUser(object sender, EventArgs e)
    {
        Roles.AddUserToRole(CreateUserWizard1.UserName, ddlrole.SelectedValue);
    }
    protected void btnCreateRole_Click(object sender, EventArgs e)
    {
        Roles.CreateRole(txtRole.Text.Trim());
        Response.Redirect(Request.Url.PathAndQuery);
    }
    protected void btnDelrole_Click(object sender, EventArgs e)
    {
        Roles.DeleteRole(ddlrole.SelectedValue);
        Response.Redirect(Request.Url.PathAndQuery);
    }
    protected void btnDelUser_Click(object sender, EventArgs e)
    {
        Membership.DeleteUser(User.Identity.Name);
    }
}
