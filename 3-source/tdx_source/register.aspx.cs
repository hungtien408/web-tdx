using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TLLib;
using System.Web.Security;

public partial class register : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        
    }
    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        if (Page.IsValid)
        {
            string strUserName = txtUserName.Text.Trim();
            string strPassWord = txtPassWord.Text;
            string strEmail = txtEmail.Text.Trim();
            string strFullName = txtFullName.Text.Trim();
            string strAddress = txtAddress.Text.Trim();
            string strHomePhone = txtHomePhone.Text.Trim();
            string strCellPhone = txtCellPhone.Text.Trim();
            bool bError = false;

            if (!string.IsNullOrEmpty(strUserName))
            {
                if (Membership.GetUser(strUserName) != null)
                {
                    CustomValidator1.ErrorMessage = "<b>+ Tên truy cập " + strUserName + " đã được đăng ký sử dụng, vui lòng chọn tên khác</b>";
                    CustomValidator1.IsValid = false;
                    bError = true;
                }
                else
                    CustomValidator1.IsValid = true;
            }

            if (Membership.FindUsersByEmail(strEmail).Count > 0)
            {
                CustomValidator2.ErrorMessage = "<b>+ Email " + strEmail + " đã được đăng ký sử dụng, vui lòng chọn Email khác</b>";
                CustomValidator2.IsValid = false;
                bError = true;
            }
            else
                CustomValidator2.IsValid = true;

            if (!bError)
            {
                var oUser = new User();
                var oUserProfile = new UserProfile();

                oUser.UserInsert(strUserName, strEmail, strPassWord, "");

                string strUserID = Membership.GetUser(strUserName).ProviderUserKey.ToString();

                oUserProfile.UserProfileInsert(
                    strUserID,
                    "",
                    strFullName,
                    strAddress,
                    strHomePhone,
                    strCellPhone,
                    "",
                    "",
                    "True");
                FormsAuthentication.SetAuthCookie(strUserName, true);
                Common.ShowAlert("Đăng ký thành công.");
            }
        }
    }
}