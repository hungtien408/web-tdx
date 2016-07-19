using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net;
using System.Net.Mail;

public partial class RecoveryPassword : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void PasswordRecovery1_SendingMail(object sender, MailMessageEventArgs e)
    {
        //e.Cancel = true;
        //NetworkCredential loginInfo = new NetworkCredential("online_registration@cie.edu.vn", "online@cie");
        //SmtpClient client = new SmtpClient("smtp.gmail.com", 25);
        //client.EnableSsl = true;
        //client.UseDefaultCredentials = false;
        //client.Credentials = loginInfo;
        //using (MailMessage msg = new MailMessage())
        //{
        //    msg.From = new MailAddress("online_registration@cie.edu.vn");
        //    msg.To.Add(new MailAddress(e.Message.To.ToString()));
        //    msg.Subject = e.Message.Subject;
        //    msg.Body = e.Message.Body;
        //    msg.IsBodyHtml = true;
        //    client.Send(msg);
        //}

        e.Cancel = true;

        SmtpClient client = new SmtpClient();

        //enable SSL for gmail
        client.EnableSsl = true;

        //sending message
        client.Send(e.Message);
    }
}