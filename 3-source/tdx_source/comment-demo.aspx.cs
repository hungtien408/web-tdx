using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TLLib;

public partial class Default2 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            var oSelectParams = ObjectDataSource1.SelectParameters;
            string strLink = Request.Url.Scheme + "://" + Request.Url.Host + Request.RawUrl;

            oSelectParams["Link"].DefaultValue = strLink;
        }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        var oComment = new Comment();
        string strUserName = User.Identity.Name;
        string strLink = Request.Url.Scheme + "://" + Request.Url.Host + Request.RawUrl;
        string strPriority = "";
        string strIsApproved = "True";
        string strIsAvailable = "True";

        //Sửa chỗ này, các phần trên để nguyên
        string strTitle = Page.Title;
        string strContent = TextBox1.Text.Trim();
        //End

        oComment.CommentInsert(
            strUserName,
            strLink,
            strTitle,
            strContent,
            strPriority,
            strIsApproved,
            strIsAvailable
        );
    }
}