using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Web.UI;
using TLLib;
using System.Web.UI.HtmlControls;
using System.IO;
using System.Data;
using System.Web.Security;

public partial class ad_single_usermanagement : System.Web.UI.Page
{
    #region Common Method
    protected void DropDownList_DataBound(object sender, EventArgs e)
    {
        var cbo = (RadComboBox)sender;
        cbo.Items.Insert(0, new RadComboBoxItem(""));
    }

    void DeleteImage(string strAvatarImage)
    {
        if (!string.IsNullOrEmpty(strAvatarImage))
        {
            var strImagePath = Server.MapPath("~/res/userprofile/" + strAvatarImage);

            if (File.Exists(strImagePath))
                File.Delete(strImagePath);
        }
    }

    #endregion

    #region Event

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!HttpContext.Current.User.IsInRole("admin"))
        {
            Response.Redirect("~/ad/bilingual/");
            //Response.Redirect("~/ad/bilingual/access-denied.aspx");
        }
    }

    public void RadGrid1_ItemCreated(object sender, Telerik.Web.UI.GridItemEventArgs e)
    {
        if (e.Item is GridCommandItem)
        {
            GridCommandItem commandItem = (e.Item as GridCommandItem);
            PlaceHolder container = (PlaceHolder)commandItem.FindControl("PlaceHolder1");
            Label label = new Label();
            label.Text = "&nbsp;&nbsp;";

            container.Controls.Add(label);

            for (int i = 65; i <= 65 + 25; i++)
            {
                LinkButton linkButton1 = new LinkButton();

                LiteralControl lc = new LiteralControl("&nbsp;&nbsp;");

                linkButton1.Text = "" + (char)i;

                linkButton1.CommandName = "alpha";
                linkButton1.CommandArgument = "" + (char)i;

                container.Controls.Add(linkButton1);
                container.Controls.Add(lc);
            }

            LiteralControl lcLast = new LiteralControl("&nbsp;");
            container.Controls.Add(lcLast);

            LinkButton linkButtonAll = new LinkButton();
            linkButtonAll.Text = "Tất cả";
            linkButtonAll.CommandName = "NoFilter";
            container.Controls.Add(linkButtonAll);
        }
    }

    protected void RadGrid1_ItemCommand(object sender, GridCommandEventArgs e)
    {

        if (e.CommandName == "alpha" || e.CommandName == "NoFilter")
        {
            String value = null;
            switch (e.CommandName)
            {
                case ("alpha"):
                    {
                        value = string.Format("{0}%", e.CommandArgument);
                        break;
                    }
                case ("NoFilter"):
                    {
                        value = "%";
                        break;
                    }
            }
            ObjectDataSource1.SelectParameters["UserName"].DefaultValue = value;
            ObjectDataSource1.DataBind();
            RadGrid1.Rebind();
        }
        else if (e.CommandName == "QuickUpdate")
        {
            string UserName, Role;
            var oUser = new User();

            foreach (GridDataItem item in RadGrid1.Items)
            {
                UserName = item["UserName"].Text;
                Role = ((RadComboBox)item.FindControl("ddlRole")).SelectedValue;
                oUser.ChangeRole(UserName, Role);
            }
        }
        else if (e.CommandName == "PerformInsert" || e.CommandName == "Update")
        {
            try
            {
                var command = e.CommandName;
                var row = command == "PerformInsert" ? (GridEditFormInsertItem)e.Item : (GridEditFormItem)e.Item;
                var FileAvatarImage = (RadUpload)row.FindControl("FileAvatarImage");
                string strAvatarImage = FileAvatarImage.UploadedFiles.Count > 0 ? FileAvatarImage.UploadedFiles[0].FileName : "";
                var strUserID = ((HiddenField)row.FindControl("hdnUserID")).Value;
                //var oUser = new User();

                var AddressBookID = ((HiddenField)row.FindControl("hdnAddressBookID")).Value.ToString().Trim();
                var hdnUserName = ((HiddenField)row.FindControl("hdnUserName")).Value.ToString().Trim();
                var hdnEmail = ((HiddenField)row.FindControl("hdnEmail")).Value.ToString().Trim();
                var strUserName = ((TextBox)row.FindControl("txtUserName")).Text;
                if (strUserName == "")
                    strUserName = hdnUserName;
                string ConvertedFirstName = Common.ConvertTitle(strUserName);
                var strEmail = ((TextBox)row.FindControl("txtEmail")).Text;
                if (strEmail == "")
                    strEmail = hdnEmail;
                var strPassword = ((TextBox)row.FindControl("txtPassword")).Text;
                var strCompanyName = ((TextBox)row.FindControl("txtCompanyName")).Text;
                var strAddress1 = ((TextBox)row.FindControl("txtAddress")).Text;
                var strFullName = ((TextBox)row.FindControl("txtFullName")).Text;
                var strCellPhone = ((TextBox)row.FindControl("txtCellPhone")).Text;
                string strOldImageName = ((HiddenField)row.FindControl("hdnOldImageName")).Value;

                if (e.CommandName == "PerformInsert")
                {
                    var ListViewRoles = (ListView)row.FindControl("lvListViewRoles");
                    string[] dsRoles = Roles.GetRolesForUser(strUserName);

                    Membership.CreateUser(strUserName, strPassword, strEmail);

                    if (string.IsNullOrEmpty(strUserID))
                        strUserID = Membership.GetUser(strUserName).ProviderUserKey.ToString();

                    foreach (ListViewItem item in ListViewRoles.Items)
                    {
                        var check = (CheckBox)item.FindControl("chkRoles");
                        if (check.Checked == true)
                        {
                            Roles.AddUserToRole(strUserName, check.Text);
                        }
                    }
                    var oUserProfile = new AddressBook();
                    oUserProfile.AddressBookInsert2(
                        strFullName,
                        "",
                        strEmail,
                        strCellPhone,
                        "",
                        "",
                        strUserName,
                        strCompanyName,
                        strAddress1,
                        "",
                        "",
                        "",
                        "",
                        "",
                        "",
                        "",
                        "",
                        "",
                        "",
                        "",
                        ""
                        );
                    //var oUserProfile = new UserProfile();
                    //oUserProfile.UserProfileInsert(strUserID, strCompanyName, strFullName, "", "", strCellPhone, "", "", "true");
                }
                else
                {
                    var UserName = ((HiddenField)row.FindControl("hdnUserName")).Value.ToString().Trim();
                    var ListViewRoles = (ListView)row.FindControl("lvListViewRoles");
                    string[] dsRoles = Roles.GetRolesForUser(UserName);

                    Roles.RemoveUserFromRoles(UserName, dsRoles);

                    foreach (ListViewItem item in ListViewRoles.Items)
                    {
                        var check = (CheckBox)item.FindControl("chkRoles");
                        if (check.Checked == true)
                        {
                            Roles.AddUserToRole(UserName, check.Text);
                        }
                    }

                    var oUserProfile = new AddressBook();
                    oUserProfile.AddressBookUpdate2(
                        AddressBookID,
                        strFullName,
                        "",
                        strEmail,
                        strCellPhone,
                        "",
                        "",
                        strUserName,
                        strCompanyName,
                        strAddress1,
                        "",
                        "",
                        "",
                        "",
                        "",
                        "",
                        "",
                        "",
                        "",
                        "",
                        "",
                        ""
                        );

                    //var oUserProfile = new UserProfile();
                    //oUserProfile.UserProfileUpdate(
                    //    strUserID,
                    //    strCompanyName,
                    //    strFullName,
                    //    "",
                    //    "",
                    //    strCellPhone,
                    //    "",
                    //    strAvatarImage,
                    //    "true"
                    //    );
                }
                var strOldImagePath = Server.MapPath("~/res/userprofile/" + strOldImageName);

                if (!string.IsNullOrEmpty(strAvatarImage))
                {
                    if (File.Exists(strOldImagePath))
                        File.Delete(strOldImagePath);
                    string strFullPath = "~/res/userprofile/" + (string.IsNullOrEmpty(ConvertedFirstName) ? "" : ConvertedFirstName) + strAvatarImage.Substring(strAvatarImage.LastIndexOf('.'));

                    FileAvatarImage.UploadedFiles[0].SaveAs(Server.MapPath(strFullPath));
                    ResizeCropImage.ResizeByCondition(strFullPath, 100, 100);
                }
                RadGrid1.Rebind();
            }
            catch (Exception ex)
            {
                lblError.Text = ex.Message;
            }
        }
        else if (e.CommandName == "DeleteSelected")
        {
            string OldAvatarImage;
            var oUserProfile = new AddressBook();
            var oUser = new User();

            string errorList = "", UserName = "";

            foreach (GridDataItem item in RadGrid1.SelectedItems)
            {
                try
                {
                    var UserID = item.GetDataKeyValue("UserID").ToString();
                    UserName = item["UserName"].Text;
                    oUserProfile.AddressBookDeleteByUserName(UserName);
                    oUser.UserDelete(UserName);

                    OldAvatarImage = ((HiddenField)item.FindControl("hdnAvatarImage")).Value;
                    DeleteImage(OldAvatarImage);
                }
                catch (Exception ex)
                {
                    lblError.Text = ex.Message;
                    if (ex.Message == ((int)ErrorNumber.ConstraintConflicted).ToString())
                        errorList += ", " + UserName;
                }
            }
            if (!string.IsNullOrEmpty(errorList))
            {
                e.Canceled = true;
                string strAlertMessage = "Tài khoản <b>\"" + errorList.Remove(0, 1).Trim() + " \"</b> đang có tin đăng BĐS .<br /> Xin xóa tin đăng hoặc sử dụng chức năng khoá tài khoản.";
                lblError.Text = strAlertMessage;
            }
            RadGrid1.Rebind();
        }
    }

    protected void RadGrid1_ItemDataBound(object sender, GridItemEventArgs e)
    {
        if (e.Item is GridEditableItem && e.Item.IsInEditMode)
        {
            var itemtype = e.Item.ItemType;
            var row = itemtype == GridItemType.EditFormItem ? (GridEditFormItem)e.Item : (GridEditFormInsertItem)e.Item;
            var FileAvatarImage = (RadUpload)row.FindControl("FileAvatarImage");

            var UserName = ((HiddenField)row.FindControl("hdnUserName")).Value.ToString().Trim();
            var ListViewRoles = (ListView)row.FindControl("lvListViewRoles");
            string[] dsRoles = Roles.GetRolesForUser(UserName);

            foreach (ListViewItem item in ListViewRoles.Items)
            {
                var check = (CheckBox)item.FindControl("chkRoles");
                if (dsRoles.Contains(check.Text))
                {
                    check.Checked = true;
                }
            }
            //var dv = (DataView)ObjectDataSource1.Select();
            //var UserName = ((Label)row.FindControl("lblUserName")).Text;
            //var ddlRole = (RadComboBox)row.FindControl("ddlRole");

            //if (!string.IsNullOrEmpty(UserName))
            //{
            //    dv.RowFilter = "UserName = '" + UserName + "'";

            //    if (!string.IsNullOrEmpty(dv[0]["Role"].ToString()))
            //        ddlRole.SelectedValue = dv[0]["Role"].ToString();
            //}
            RadAjaxPanel1.ResponseScripts.Add(string.Format("window['UploadId'] = '{0}';", FileAvatarImage.ClientID));
        }
        //else if (e.Item is GridDataItem)
        //{
        //    try
        //    {
        //        var row = (GridDataItem)e.Item;
        //        var ddlRole = (RadComboBox)row.FindControl("ddlRole");
        //        var selectedRole = ((HiddenField)row.FindControl("hdnRole")).Value;

        //        if (!string.IsNullOrEmpty(selectedRole))
        //            ddlRole.SelectedValue = selectedRole;
        //    }
        //    catch (Exception ex)
        //    {
        //        lblError.Text = ex.Message;
        //    }
        //}
    }

    protected void txtUserName_TextChanged(object sender, EventArgs e)
    {
        var txtUserName = (TextBox)sender;
        var strUserName = txtUserName.Text;
        var CustomValidator1 = (CustomValidator)txtUserName.Parent.FindControl("CustomValidator1");
        var lblMessage = (Label)txtUserName.Parent.FindControl("lblUserNameMessage");

        if (!string.IsNullOrEmpty(strUserName))
        {
            if (Membership.GetUser(strUserName) != null)
            {
                CustomValidator1.ErrorMessage = "Tài khoản <b>\"" + strUserName + "\"</b> đã tồn tại!";
                CustomValidator1.IsValid = false;
                lblMessage.Text = "";
            }
            else
            {
                CustomValidator1.IsValid = true;
                lblMessage.Text = "Tài khoản <b>\"" + strUserName + "\"</b> có thể sử dụng.";
            }
        }
    }

    protected void txtEmail_TextChanged(object sender, EventArgs e)
    {
        var txtEmail = (TextBox)sender;
        var strEmail = txtEmail.Text;
        var CustomValidator2 = (CustomValidator)txtEmail.Parent.FindControl("CustomValidator2");
        var lblMessage = (Label)txtEmail.Parent.FindControl("lblEmailMessage");

        if (!string.IsNullOrEmpty(strEmail))
        {
            if (Membership.FindUsersByEmail(strEmail).Count > 0)
            {
                CustomValidator2.ErrorMessage = "Email <b>\"" + strEmail + "\"</b> đã tồn tại!";
                CustomValidator2.IsValid = false;
                lblMessage.Text = "";
            }
            else
            {
                CustomValidator2.IsValid = true;
                lblMessage.Text = "Email <b>\"" + strEmail + "\"</b> có thể sử dụng.";
            }
        }
    }
    #endregion
    //protected void lvListViewRoles_ItemCommand(object sender, ListViewCommandEventArgs e)
    //{
    //    var listViewRoles = (ListView)sender;
    //    ListViewItem item = e.Item;
    //    CheckBox check = (CheckBox)item.FindControl("chkRoles");
    //    if (check.Text.ToString() == "admin")
    //    {
    //        if (check.Checked == true)
    //        {
    //            foreach (ListViewItem items in listViewRoles.Items)
    //            {
    //                CheckBox checks = (CheckBox)items.FindControl("chkRoles");
    //                checks.Checked = true;
    //            }
    //        }
    //        else
    //        {
    //            foreach (ListViewItem items in listViewRoles.Items)
    //            {
    //                CheckBox checks = (CheckBox)items.FindControl("chkRoles");
    //                checks.Checked = false;
    //            }
    //        }
    //    }

    //}
}