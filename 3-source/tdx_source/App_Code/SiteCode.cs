using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;
using System.Data;

/// <summary>
/// Summary description for SiteCode
/// </summary>
public class SiteCode
{
    int level = -1;
    StringBuilder m_strMenu = new StringBuilder();

    public void BuilMenu(DataTable dtParent, string ParentID, string DisplayFieldName, string LinkFieldName, string ImageFieldName)
    {
        var page = HttpContext.Current.Handler as System.Web.UI.Page;
        string rootPath = page.ResolveClientUrl("~/");
        var newLine = Environment.NewLine;
        level++;

        var dv = new DataView(dtParent);

        dv.RowFilter = string.Format("ParentID = {0}", ParentID);
        
        if (dv.Count > 0)
        {
            //Nếu ở cấp 0 hiển thị:
            if (level == 0)
            {
                //Sửa thẻ HTML của menu ở đây
                m_strMenu.Append(newLine + "<div>");

                foreach (DataRowView drv in dv)
                {
                    string strLink = ResolveUrl(drv[LinkFieldName].ToString());

                    m_strMenu.Append(newLine + "<p>");

                    m_strMenu.Append(newLine + "<a href='" + strLink + "' class='tmenuitem level" + level + "'>" + drv[DisplayFieldName] + "</a>");
                    BuilMenu(dtParent, drv["MenuID"].ToString(), DisplayFieldName, LinkFieldName, ImageFieldName);

                    m_strMenu.Append(newLine + "</p>");
                }

                m_strMenu.Append(newLine + "</div>");

                //End
            }
            //Nếu ở cấp > 0 hiển thị:
            else if (level > 0)
            {
                //Sửa thẻ HTML của menu ở đây
                m_strMenu.Append(newLine + "<ul>");

                foreach (DataRowView drv in dv)
                {
                    string strLink = ResolveUrl(drv[LinkFieldName].ToString());
                    string strImageName = (rootPath + "/res/menu/" + drv[LinkFieldName]).Replace("//", "/");
                    strImageName = LinkFieldName == "" ? newLine + "<img src='" + strImageName + "' class='tmenuimg' />" : "";

                    m_strMenu.Append(newLine + "<li>");
                    m_strMenu.Append(strImageName);
                    m_strMenu.Append(newLine + "<a href='" + strLink + "' class='tmenuitem level" + level + "'>" + drv[DisplayFieldName] + "</a>");
                    BuilMenu(dtParent, drv["MenuID"].ToString(), DisplayFieldName, LinkFieldName, ImageFieldName);
                    m_strMenu.Append(newLine + "</li>");
                }

                m_strMenu.Append(newLine + "</ul>");
                //End
            }
        }

        level--;
    }

    string ResolveUrl(string url)
    {
        var page = HttpContext.Current.Handler as System.Web.UI.Page;
        string rootPath = page.ResolveClientUrl("~/");

        if (url.StartsWith("www"))
            url = "http://" + url;
        else if (!url.StartsWith("http"))
            url = (rootPath + "/" + url).Replace("//", "/");

        return url;
    }

    public string Menu
    {
        get { return m_strMenu.ToString(); }
    }
}