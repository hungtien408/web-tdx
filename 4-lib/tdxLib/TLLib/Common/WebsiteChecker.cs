using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.IO;

namespace TLLib
{
    public class WebsiteChecker
    {
        public static bool IsValidWebsite
        {
            get
            {
                try
                {
                    var text = File.ReadAllText(HttpContext.Current.Server.MapPath("~/config/config.ash")).Trim();
                    return Convert.ToBoolean(text);
                }
                catch { return false; }
            }
        }

        public static void LockWebsite()
        {
            File.WriteAllText(HttpContext.Current.Server.MapPath("~/config/config.ash"), "False");
        }

        public static void UnLockWebsite()
        {
            File.WriteAllText(HttpContext.Current.Server.MapPath("~/config/config.ash"), "True");
        }
    }
}
