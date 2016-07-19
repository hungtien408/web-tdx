<%@ Application Language="C#" %>
<%@ Import Namespace="System.Xml" %>
<%@ Import Namespace="System.IO" %>
<%@ Import Namespace="System.IO.Compression" %> 
<%@ Import Namespace="System.Data" %>
<%@ Import Namespace="TLLib" %>
<script RunAt="server">

    void Application_Start(object sender, EventArgs e)
    {
        // Code that runs on application startup
        //Application["HomNay"] = 0;
        //Application["ThangNay"] = 0;
        //Application["TatCa"] = 0;
        //Application["visitors_online"] = 0;
    }

    void Application_End(object sender, EventArgs e)
    {
        //  Code that runs on application shutdown
    }

    void Application_Error(object sender, EventArgs e)
    {
        // Code that runs when an unhandled error occurs
    }

    void Session_Start(object sender, EventArgs e)
    {
        // Code that runs when a new session is started
        //XmlDocument doc = new XmlDocument();
        //doc.Load(Server.MapPath("~/users.xml"));
        //XmlNode nodetoEdit = doc.SelectSingleNode("users/total");
        //nodetoEdit.InnerText = (Int32.Parse(nodetoEdit.InnerText) + 1).ToString();
        //Application["activeUser"] = nodetoEdit.InnerText;
        //doc.Save(Server.MapPath("~/users.xml"));
        //Session.Timeout = 150;

        //Application.Lock();
        //Application["visitors_online"] = Convert.ToInt32(Application["visitors_online"]) + 1;
        //Application.UnLock();
        try
        {
            //Visitor mthongke = new Visitor();
            //DataTable dt = mthongke.Visitors();

            //if (dt.Rows.Count > 0)
            //{
            //    Application["HomNay"] = long.Parse("0" + dt.Rows[0]["HomNay"]).ToString("#,###");
            //    Application["ThangNay"] = long.Parse("0" + dt.Rows[0]["ThangNay"]).ToString("#,###");
            //    Application["TatCa"] = long.Parse("0" + dt.Rows[0]["TatCa"]).ToString("#,###");
            //}
            //dt.Dispose();
            //mthongke = null;
        }
        catch
        {
        }
    }

    void Session_End(object sender, EventArgs e)
    {
        // Code that runs when a session ends. 
        // Note: The Session_End event is raised only when the sessionstate mode
        // is set to InProc in the Web.config file. If session mode is set to StateServer 
        // or SQLServer, the event is not raised.
        //OnlineActiveUsers.OnlineUsersInstance.OnlineUsers.UpdateForUserLeave();
        //Application.Lock();
        //Application["visitors_online"] = Convert.ToUInt32(Application["visitors_online"]) - 1;
        //Application.UnLock();
    }

    protected void Application_BeginRequest(Object sender, EventArgs e)
    {
        var app = sender as HttpApplication;

        if (app != null)
        {
            string host = app.Request.Url.Host.ToLower();

            if (!host.StartsWith("www") && !host.StartsWith("localhost"))
            {
                string requestUrl = app.Request.RawUrl.ToLower();
                string scheme = app.Request.Url.Scheme;
                requestUrl = requestUrl.EndsWith("default.aspx") ? "" : requestUrl;
                string newURL = scheme + "://www." + host + requestUrl;

                app.Context.Response.RedirectLocation = newURL;
                app.Context.Response.StatusCode = 301;
                app.Context.Response.End();
            }
        }
    }
</script>
