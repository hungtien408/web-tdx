using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using System.Data;
using System.Web;
using System.Collections;
using System.Net;
using System.Net.Mail;
using System.Web.UI;
using System.Text.RegularExpressions;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.IO;

namespace TLLib
{
    public enum ErrorNumber
    {
        ConstraintConflicted = 547
    }
    public class Common
    {
        int level = -1;
        DataTable dt;
        StringBuilder m_strMenu;


        public Common()
        {
            dt = new DataTable();
            m_strMenu = new StringBuilder();
        }

        #region Common Method

        public static string ConnectionString
        {
            get
            {
                //Remote lock website
                if (WebsiteChecker.IsValidWebsite)
                    return ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
                else
                    return null;
                //return ConfigurationManager.ConnectionStrings[1].ConnectionString;
            }
        }

        public static void ShowAlert(string Message)
        {
            string strBuilder = "<script type='text/javascript'>alert('";
            strBuilder += Message;
            strBuilder += "')</script>";
            //return strBuilder;

            System.Web.UI.Page page = HttpContext.Current.Handler as System.Web.UI.Page;

            if (page != null)
            {
                page.RegisterStartupScript("runtime", strBuilder);
            }

        }

        public static void RunStartUpScript(string script)
        {
            string strBuilder = "<script type='text/javascript'>";
            strBuilder += script;
            strBuilder += "</script>";
            //return strBuilder;

            System.Web.UI.Page page = HttpContext.Current.Handler as System.Web.UI.Page;

            if (page != null)
            {
                page.RegisterStartupScript("runtime", strBuilder);
            }

        }

        //chuyển thành ko dấu để add động meta title, meta description
        public static string ChangeSymBol(string inputString)
        {
            inputString = inputString.ToLower();
            var specialCharList = new Dictionary<char[], char>();

            specialCharList.Add(new char[] { 'é', 'è', 'ẻ', 'ẽ', 'ẹ', 'ê', 'ế', 'ề', 'ể', 'ễ', 'ệ' }, 'e');
            specialCharList.Add(new char[] { 'ý', 'ỳ', 'ỷ', 'ỹ', 'ỵ' }, 'y');
            specialCharList.Add(new char[] { 'ú', 'ù', 'ủ', 'ũ', 'ụ', 'ư', 'ứ', 'ừ', 'ử', 'ữ', 'ự' }, 'u');
            specialCharList.Add(new char[] { 'í', 'ì', 'ỉ', 'ĩ', 'ị' }, 'i');
            specialCharList.Add(new char[] { 'ó', 'ò', 'ỏ', 'õ', 'ọ', 'ô', 'ố', 'ồ', 'ổ', 'ỗ', 'ộ', 'ơ', 'ớ', 'ờ', 'ở', 'ỡ', 'ợ' }, 'o');
            specialCharList.Add(new char[] { 'á', 'à', 'ả', 'ã', 'ạ', 'â', 'ấ', 'ầ', 'ẩ', 'ẫ', 'ậ', 'ă', 'ắ', 'ằ', 'ẳ', 'ẵ', 'ặ' }, 'a');
            specialCharList.Add(new char[] { 'đ' }, 'd');

            foreach (var key in specialCharList)
            {
                foreach (var c in key.Key)
                {
                    if (inputString.Contains(c))
                        inputString = inputString.Replace(c, key.Value);
                }
            }

            return inputString;
        }

        public static string ChangeToNoSymBol(string inputString)
        {
            string[] specWrd = { "e", "y", "u", "i", "o", "a", "d" };

            var containList = from string s in specWrd where inputString.ToLower().Contains(s) select s;

            foreach (string s in containList)
            {
                inputString = inputString.Replace(s, "_");
            }

            return inputString;
        }

        public static string ConvertTitle(string text)
        {
            for (int i = 33; i < 48; i++)
                text = text.Replace(((char)i).ToString(), "");

            for (int i = 58; i < 65; i++)
                text = text.Replace(((char)i).ToString(), "");

            for (int i = 91; i < 97; i++)
                text = text.Replace(((char)i).ToString(), "");

            for (int i = 123; i < 127; i++)
                text = text.Replace(((char)i).ToString(), "");

            text = text.Replace(" ", "-");

            Regex regex = new Regex(@"\p{IsCombiningDiacriticalMarks}+");

            string strFormD = text.Normalize(System.Text.NormalizationForm.FormD);
            strFormD = regex.Replace(strFormD, String.Empty).Replace('\u0111', 'd').Replace('\u0110', 'D');

            regex = new Regex("[^0-9a-zA-Z-]+");
            strFormD = regex.Replace(strFormD, String.Empty);

            while (strFormD.Contains("--"))
                strFormD = strFormD.Replace("--", "-");

            strFormD = strFormD.StartsWith("-") ? strFormD.Remove(0, 1) : (strFormD.EndsWith("-") ? strFormD.Remove(strFormD.Length - 1) : strFormD);

            return strFormD.ToLower();
        }

        public void RecursiveFillTree(DataTable dtParent, int parentID, string parentColumnName, string displayColumnName, string valueColumnName, string SeparatorCharacter)
        {
            if (dt.Columns.Count == 0)
            {
                foreach (DataColumn dc in dtParent.Columns)
                    dt.Columns.Add(dc.ColumnName);

                dt.Columns.Add("Level");
            }

            level++; //on the each call level increment 1
            System.Text.StringBuilder appender = new System.Text.StringBuilder();

            for (int j = 0; j < level; j++)
                appender.Append(SeparatorCharacter);

            var dv = new DataView(dtParent);

            dv.RowFilter = string.Format(parentColumnName + " = {0}", parentID);

            if (dv.Count > 0)
            {
                foreach (DataRowView drv in dv)
                {
                    var columnLength = dt.Columns.Count;
                    object[] obj = new object[columnLength];
                    for (int i = 0; i < dtParent.Columns.Count; i++)
                    {
                        if (dtParent.Columns[i].ColumnName == displayColumnName)
                            obj[i] = HttpContext.Current.Server.HtmlDecode(appender.ToString() + drv[i]);
                        else
                            obj[i] = drv[i];
                    }
                    obj[columnLength - 1] = level;
                    dt.Rows.Add(obj);
                    RecursiveFillTree(dtParent, int.Parse(drv[valueColumnName].ToString()), parentColumnName, displayColumnName, valueColumnName, SeparatorCharacter);
                }
            }

            level--; //on the each function end level will decrement by 1
        }

        public void RecursiveFillTree(DataTable dtParent, int parentID, string parentColumnName, string displayColumnName, string valueColumnName, int increaseLevelCount, string IsShowOnMenu, string IsShowOnHomePage)
        {
            if (dt.Columns.Count == 0)
            {
                foreach (DataColumn dc in dtParent.Columns)
                {
                    dt.Columns.Add(dc.ColumnName);
                }
                dt.Columns.Add("Level");
            }

            level++; //on the each call level increment 1
            System.Text.StringBuilder appender = new System.Text.StringBuilder();
            var dv = new DataView(dtParent);

            dv.RowFilter = string.Format(parentColumnName + " = {0} AND IsAvailable = 1 " +
                (string.IsNullOrEmpty(IsShowOnMenu) ? "" : " AND IsShowOnMenu = " + IsShowOnMenu) +
                (string.IsNullOrEmpty(IsShowOnHomePage) ? "" : " AND IsShowOnHomePage = " + IsShowOnHomePage)
            , parentID);

            if (dv.Count > 0 && (level <= increaseLevelCount - 1 || increaseLevelCount == -1))
            {
                foreach (DataRowView drv in dv)
                {
                    var columnLength = dt.Columns.Count;
                    object[] obj = new object[columnLength];
                    for (int i = 0; i < dtParent.Columns.Count; i++)
                    {
                        if (dtParent.Columns[i].ColumnName == displayColumnName)
                            obj[i] = HttpContext.Current.Server.HtmlDecode(appender.ToString() + drv[i]);
                        else
                            obj[i] = drv[i];
                    }
                    obj[columnLength - 1] = level;
                    dt.Rows.Add(obj);
                    RecursiveFillTree(dtParent, int.Parse(drv[valueColumnName].ToString()), parentColumnName, displayColumnName, valueColumnName, increaseLevelCount, IsShowOnMenu, IsShowOnHomePage);
                }
            }

            level--; //on the each function end level will decrement by 1
        }

        public void RecursiveFillMenuTree(string href, string queryStringName, DataTable dtParent, string parentID, string parentColumnName, string displayColumnName, string valueColumnName, int increaseLevelCount)
        {
            level++; //on the each call level increment 1

            var dv = new DataView(dtParent);

            dv.RowFilter = string.Format(parentColumnName + " = {0} AND IsAvailable = 1 AND IsShowOnMenu = 1", parentID);

            if (dv.Count > 0 && (level <= increaseLevelCount - 1 || increaseLevelCount == -1))
            {
                m_strMenu.Append("\n<ul>");
                foreach (DataRowView drv in dv)
                {
                    m_strMenu.Append("\n<li><a href='" + href + "?" + queryStringName + "=" + drv[valueColumnName] + "' class='level" + level + "'>" + drv[displayColumnName] + "</a>");
                    RecursiveFillMenuTree(href, queryStringName, dtParent, drv[valueColumnName].ToString(), parentColumnName, displayColumnName, valueColumnName, increaseLevelCount);
                    m_strMenu.Append("\n</li>");
                }
                m_strMenu.Append("\n</ul>");
            }

            level--; //on the each function end level will decrement by 1
        }

        public void RecursiveFillMenuTree(string href, string queryStringName, DataTable dtParent, string parentID, string parentColumnName, string displayColumnName, string valueColumnName, int increaseLevelCount, string rootHmtlTag)
        {
            level++; //on the each call level increment 1

            var dv = new DataView(dtParent);
            var pattern = @"<";
            var replacement = "</";
            var rgx = new Regex(pattern);
            var endRootHtmlTag = rgx.Replace(rootHmtlTag, replacement);

            dv.RowFilter = string.Format(parentColumnName + " = {0} AND IsAvailable = 1 AND IsShowOnMenu = 1", parentID);


            if (dv.Count > 0 && (level <= increaseLevelCount - 1 || increaseLevelCount == -1))
            {
                if (level > 0)
                    m_strMenu.Append("\n<ul>");

                foreach (DataRowView drv in dv)
                {
                    if (level == 0)
                        m_strMenu.Append("\n" + rootHmtlTag);
                    else
                        m_strMenu.Append("\n<li>");

                    m_strMenu.Append("<a href='" + href + "?" + queryStringName + "=" + drv[valueColumnName] + "' class='level" + level + "'>" + drv[displayColumnName] + "</a>");
                    RecursiveFillMenuTree(href, queryStringName, dtParent, drv[valueColumnName].ToString(), parentColumnName, displayColumnName, valueColumnName, increaseLevelCount, rootHmtlTag);

                    if (level == 0)
                        m_strMenu.Append("\n" + endRootHtmlTag);
                    else
                        m_strMenu.Append("\n</li>");
                }

                if (level > 0)
                    m_strMenu.Append("\n</ul>");
            }

            level--; //on the each function end level will decrement by 1
        }

        public void RecursiveFillMenuTree(string href, string queryStringName, DataTable dtParent, string parentID, string parentColumnName, string displayColumnName, string valueColumnName, int increaseLevelCount, bool showImage, string imageFolderPath, string imageFieldName)
        {
            level++; //on the each call level increment 1

            if (!imageFolderPath.EndsWith("/"))
                imageFolderPath = imageFolderPath + "/";

            var dv = new DataView(dtParent);

            dv.RowFilter = string.Format(parentColumnName + " = {0} AND IsAvailable = 1 AND IsShowOnMenu = 1", parentID);

            if (dv.Count > 0 && (level <= increaseLevelCount - 1 || increaseLevelCount == -1))
            {
                m_strMenu.Append("\n<ul>");
                foreach (DataRowView drv in dv)
                {
                    m_strMenu.Append("\n<li>" + (string.IsNullOrEmpty(drv[imageFieldName].ToString()) ? "" : "<img alt='' src='" + imageFolderPath + drv[imageFieldName] + "' />") + "<a href='" + href + "?" + queryStringName + "=" + drv[valueColumnName] + "' class='level" + level + "'>" + drv[displayColumnName] + "</a>");
                    RecursiveFillMenuTree(href, queryStringName, dtParent, drv[valueColumnName].ToString(), parentColumnName, displayColumnName, valueColumnName, increaseLevelCount, showImage, imageFolderPath, imageFieldName);
                    m_strMenu.Append("\n</li>");
                }
                m_strMenu.Append("\n</ul>");
            }

            level--; //on the each function end level will decrement by 1
        }

        public void RecursiveFillMenuTree(string href, string queryStringName, DataTable dtParent, string parentID, string parentColumnName, string displayColumnName, string valueColumnName, int increaseLevelCount, string rootHmtlTag, bool showImage, string imageFolderPath, string imageFieldName)
        {
            level++; //on the each call level increment 1

            if (!imageFolderPath.EndsWith("/"))
                imageFolderPath = imageFolderPath + "/";

            var dv = new DataView(dtParent);
            var pattern = @"<";
            var replacement = "</";
            var rgx = new Regex(pattern);
            var endRootHtmlTag = rgx.Replace(rootHmtlTag, replacement);

            dv.RowFilter = string.Format(parentColumnName + " = {0} AND IsAvailable = 1 AND IsShowOnMenu = 1", parentID);

            if (dv.Count > 0 && (level <= increaseLevelCount - 1 || increaseLevelCount == -1))
            {
                if (level > 0)
                    m_strMenu.Append("\n<ul>");

                foreach (DataRowView drv in dv)
                {
                    if (level == 0)
                        m_strMenu.Append("\n" + rootHmtlTag);
                    else
                        m_strMenu.Append("\n<li>");

                    m_strMenu.Append((string.IsNullOrEmpty(drv[imageFieldName].ToString()) ? "" : "<img alt='' src='" + imageFolderPath + drv[imageFieldName] + "' />") + "<a href='" + href + "?" + queryStringName + "=" + drv[valueColumnName] + "' class='level" + level + "'>" + drv[displayColumnName] + "</a>");
                    RecursiveFillMenuTree(href, queryStringName, dtParent, drv[valueColumnName].ToString(), parentColumnName, displayColumnName, valueColumnName, increaseLevelCount, rootHmtlTag, showImage, imageFolderPath, imageFieldName);

                    if (level == 0)
                        m_strMenu.Append("\n" + endRootHtmlTag);
                    else
                        m_strMenu.Append("\n</li>");
                }

                if (level > 0)
                    m_strMenu.Append("\n</ul>");
            }

            level--; //on the each function end level will decrement by 1
        }

        public static bool SendMail(string strHost, int iPort, string strMailFrom, string strPassword, string strMailTo, string strCC, string strSubject, string strBody, bool bEnableSsl)
        {
            bool SendSuccess = false;
            try
            {
                var lstMailTo = strMailTo.Replace(';', ',').Split(',');
                var lstCC = strCC.Replace(';', ',').Split(',');

                NetworkCredential loginInfo = new NetworkCredential(strMailFrom, strPassword);
                SmtpClient client = new SmtpClient(strHost, iPort);
                client.EnableSsl = false;
                client.UseDefaultCredentials = false;
                client.Credentials = loginInfo;
                client.EnableSsl = bEnableSsl;
                using (MailMessage msg = new MailMessage())
                {
                    msg.From = new MailAddress(strMailFrom);

                    foreach (string strTo in lstMailTo)
                        if (!string.IsNullOrEmpty(strTo.Trim()))
                            msg.To.Add(new MailAddress(strTo));

                    foreach (string strCC1 in lstCC)
                        if (!string.IsNullOrEmpty(strCC1.Trim()))
                            msg.CC.Add(new MailAddress(strCC1));

                    msg.Subject = strSubject;
                    msg.Body = strBody;
                    msg.IsBodyHtml = true;
                    client.Send(msg);
                }
                SendSuccess = true;
            }
            catch
            {
                SendSuccess = false;
            }
            return SendSuccess;
        }

        public static Control GetPostBackControl(Page page)
        {
            Control postbackControlInstance = null;

            string postbackControlName = page.Request.Params.Get("__EVENTTARGET");

            if (postbackControlName != null && postbackControlName != string.Empty)
            {
                postbackControlInstance = page.FindControl(postbackControlName);
            }
            else
            {
                // handle the Button control postbacks
                for (int i = 0; i < page.Request.Form.Keys.Count; i++)
                {
                    postbackControlInstance = page.FindControl(page.Request.Form.Keys[i]);

                    if (postbackControlInstance is System.Web.UI.WebControls.Button)
                    {
                        return postbackControlInstance;
                    }
                }
            }

            // handle the ImageButton postbacks

            if (postbackControlInstance == null)
            {
                for (int i = 0; i < page.Request.Form.Count; i++)
                {
                    if ((page.Request.Form.Keys[i].EndsWith(".x")) || (page.Request.Form.Keys[i].EndsWith(".y")))
                    {
                        postbackControlInstance = page.FindControl(page.Request.Form.Keys[i].Substring(0, page.Request.Form.Keys[i].Length - 2));

                        return postbackControlInstance;
                    }
                }
            }

            return postbackControlInstance;
        }

        public static string ReplaceRegex(string inputString, string replaceCharacter)
        {
            var specialRegexCharacter = new char[] { '~', '`', '@', '#', '$', '%', '^', '&', '*', '(', ')', '|', '\\', '{', '}', '[', ']', '<', '>', ',', '.', '?', '/' };

            var containCharacters = from char c in inputString where specialRegexCharacter.Contains(c) select c;

            foreach (char c in containCharacters)
            {
                inputString = inputString.Replace(c.ToString(), replaceCharacter + c);
            }

            return inputString;
        }

        public static string SplitSummary(string input, int length)
        {
            if (input.Length > length)
            {
                input = input.Substring(0, length);

                if (input.Contains(" "))
                    input = input.Substring(0, input.LastIndexOf(' ')) + "...";
            }
            return input;
        }

        public static string ChangeDate(object inputDate)
        {
            string strOutput = "";
            var date = Convert.ToDateTime(inputDate);
            var today = DateTime.Now;

            var iTotalYears = today.Year - date.Year;
            var iTotalMonths = today.Month - date.Month;
            var iTotalDays = (today - date).Days;
            var iTotalHours = (today - date).Hours;
            var iTotalMinutes = (today - date).Minutes;
            var iTotalSeconds = (today - date).Seconds;

            if (iTotalYears > 0)
                strOutput = iTotalYears + " năm trước";
            else if (iTotalYears == 0 && iTotalMonths > 0)
                strOutput = iTotalMonths + " tháng trước";
            else if (iTotalYears == 0 && iTotalMonths == 0 && iTotalDays > 0)
                strOutput = iTotalDays + " ngày trước";
            else if (iTotalYears == 0 && iTotalMonths == 0 && iTotalDays == 0 && iTotalHours > 0)
                strOutput = iTotalHours + " giờ trước";
            else if (iTotalYears == 0 && iTotalMonths == 0 && iTotalDays == 0 && iTotalHours == 0 && iTotalMinutes > 0)
                strOutput = iTotalMinutes + " phút trước";
            else
                strOutput = iTotalSeconds + " giây trước";

            return strOutput;
        }

        public void BuilMenu(DataTable dtParent, string ParentID, string ParentColumnName, string DisplayFieldName, string LinkFieldName, string ImageFieldName, int increaseLevelCount)
        {
            var page = HttpContext.Current.Handler as Page;
            string rootPath = page.ResolveClientUrl("~/");
            level++; //on the each call level increment 1

            var dv = new DataView(dtParent);

            dv.RowFilter = string.Format(ParentColumnName + " = {0}", ParentID);

            if (dv.Count > 0 && (level <= increaseLevelCount - 1 || increaseLevelCount == -1))
            {
                m_strMenu.Append("\n<ul>");
                foreach (DataRowView drv in dv)
                {
                    string strLink = drv[LinkFieldName].ToString();
                    string strImageName = (rootPath + "/res/menu/" + drv[LinkFieldName]).Replace("//", "/");
                    strImageName = LinkFieldName == "" ? "\n<img src='" + strImageName + "' class='tmenuimg' />" : "";
                    if (strLink.StartsWith("www"))
                        strLink = "http://" + strLink;
                    else if (!strLink.StartsWith("http"))
                        strLink = (rootPath + "/" + strLink).Replace("//", "/");

                    m_strMenu.Append("\n<li>");
                    m_strMenu.Append(strImageName);
                    m_strMenu.Append("\n<a href='" + strLink + "' class='tmenuitem level" + level + "'>" + drv[DisplayFieldName] + "</a>");
                    BuilMenu(dtParent, drv["MenuID"].ToString(), ParentColumnName, DisplayFieldName, LinkFieldName, ImageFieldName, increaseLevelCount);
                    m_strMenu.Append("\n</li>");
                }
                m_strMenu.Append("\n</ul>");
            }

            level--; //on the each function end level will decrement by 1
        }

        public void ExportPDF(string FileName, string FontName, string html, string header, string footer)
        {
            var page = HttpContext.Current.Handler as Page;

            //Init export
            page.Response.ContentType = "application/pdf";
            page.Response.AddHeader("content-disposition", "attachment;filename=" + FileName);
            page.Response.Cache.SetCacheability(HttpCacheability.NoCache);

            Document pdfDoc = new Document(PageSize.A4);
            PdfWriter.GetInstance(pdfDoc, page.Response.OutputStream);

            //Import Unicode Font
            BaseFont bF = BaseFont.CreateFont(HttpContext.Current.Server.MapPath("~/" + FontName), iTextSharp.text.pdf.BaseFont.IDENTITY_H, true);
            Font f = new Font(bF, 12f, Font.NORMAL);
            Font hdf = new Font(bF, 12f, Font.NORMAL, Color.GRAY);
            //End Import font

            //Create PDF header
            var headPhrase = new Phrase(header, hdf);
            var head = new HeaderFooter(headPhrase, false);
            head.BorderColor = Color.GRAY;
            //End

            //Create PDF footer
            var footPhrase = new Phrase(footer, hdf);
            var foot = new HeaderFooter(footPhrase, false);
            foot.BorderColor = Color.GRAY;
            //End

            pdfDoc.Header = head;
            pdfDoc.Footer = foot;

            pdfDoc.Open();
            ParseHtml(html, pdfDoc, f);
            pdfDoc.Close();
        }

        void ParseHtml(string html, Document doc, Font f)
        {
            var tempHtml = html;
            int index = 0;

            //Parse Html to normal text and clean
            html = Regex.Replace(html, @"<img[^>]*>", "Џ" + Environment.NewLine);
            html = Regex.Replace(html, @"<[^>]*>", String.Empty);

            while (html.Contains("  ") || html.Contains(Environment.NewLine + " ") || html.Contains(" " + Environment.NewLine) || html.Contains(Environment.NewLine + Environment.NewLine + Environment.NewLine))
                html = html.Replace("  ", " ").Replace(Environment.NewLine + " ", Environment.NewLine).Replace(" " + Environment.NewLine, Environment.NewLine).Replace(Environment.NewLine + Environment.NewLine + Environment.NewLine, Environment.NewLine + Environment.NewLine);
            //end Parse Html

            //Write pdf
            if (html.Contains("Џ"))
            {
                var splitHtml = html.Split('Џ');

                var myRegex = new Regex(@"src=['|""]([^>]*?)['|""]", RegexOptions.Compiled);

                foreach (Match iMatch in myRegex.Matches(tempHtml))
                {
                    bool isInternalImage = false;
                    string src = iMatch.Groups[1].Value;

                    if (src.StartsWith("www"))
                    {
                        if (!src.StartsWith("http"))
                            src = "http://" + src;
                    }
                    else if (!src.StartsWith("http"))
                    {
                        src = HttpContext.Current.Server.MapPath("~/" + src);
                        isInternalImage = true;
                    }

                    doc.Add(new Paragraph(splitHtml[index].Trim(), f));

                    if ((isInternalImage && File.Exists(src)) || !isInternalImage)
                    {
                        var image = iTextSharp.text.Image.GetInstance(src);
                        image.Alignment = iTextSharp.text.Image.ALIGN_CENTER;

                        doc.Add(image);
                    }

                    doc.Add(new Paragraph(Environment.NewLine));
                    index++;
                }

                doc.Add(new Paragraph(splitHtml[index].Trim(), f));
            }
            else
                doc.Add(new Paragraph(html, f));
        }

        #endregion

        #region Class Member Declaration

        public DataTable Tree
        {
            get { return dt; }
        }

        public string Menu
        {
            get { return m_strMenu.ToString(); }
        }

        public static object VSPageSize
        {
            get { return HttpContext.Current.Session["PageSize"]; }
            set { HttpContext.Current.Session["PageSize"] = value; }
        }

        #endregion
    }
}
