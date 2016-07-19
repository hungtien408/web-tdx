using System;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Default : System.Web.UI.Page 
{
    protected void Page_PreRender(object sender, EventArgs e)
    {
        //// initial page setup
        //if (!IsPostBack)
        //{
        //    // set control text
        //    ValidateCaptchaButton.Text = "Validate";
        //    CaptchaCorrectLabel.Text = "Correct!";
        //    CaptchaIncorrectLabel.Text = "Incorrect!";

        //    // these messages are shown only after validation
        //    CaptchaCorrectLabel.Visible = false;
        //    CaptchaIncorrectLabel.Visible = false;
        //}

        //// setup client-side input processing
        //SampleCaptcha.UserInputClientID = CaptchaCodeTextBox.ClientID;

        //if (IsPostBack)
        //{
        //    // validate the Captcha to check we're not dealing with a bot
        //    string code = CaptchaCodeTextBox.Text.Trim().ToUpper();
        //    bool isHuman = SampleCaptcha.Validate(code);
        //    CaptchaCodeTextBox.Text = null; // clear previous user input

        //    if (isHuman)
        //    {
        //        CaptchaCorrectLabel.Visible = true;
        //        CaptchaIncorrectLabel.Visible = false;
        //    }
        //    else
        //    {
        //        CaptchaCorrectLabel.Visible = false;
        //        CaptchaIncorrectLabel.Visible = true;
        //    }
        //}
    }
}
