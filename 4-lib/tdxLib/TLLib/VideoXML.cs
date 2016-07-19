using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Web;
using System.Xml;
using System.IO;
using System.Collections;
using System.Text.RegularExpressions;

namespace TLLib
{
    public class VideoXML
    {
        public DataTable VideoSelectAll(string xmlFilePath, string keyWord)
        {
            if (!xmlFilePath.StartsWith("~/"))
            {
                xmlFilePath = "~/" + xmlFilePath;
            }
            DataSet ds1 = new DataSet();
            ds1.ReadXml(HttpContext.Current.Server.MapPath(xmlFilePath), XmlReadMode.Auto);
            DataTable dt = new DataTable();
            DataTable dt1 = new DataTable();
            dt.Columns.Add("ide");
            dt.Columns.Add("title");
            dt.Columns.Add("abstract");
            dt.Columns.Add("ref");
            dt.Columns.Add("param");

            DataRow dr;
            if (ds1.Tables.Count != 1)
            {
                for (int i = 0; i < ds1.Tables[1].Rows.Count; i++)
                {
                    dr = dt.NewRow();
                    dr["ide"] = ds1.Tables[1].Rows[i][3].ToString();
                    dr["title"] = ds1.Tables[1].Rows[i][0].ToString();
                    dr["abstract"] = ds1.Tables[1].Rows[i][1].ToString();
                    dr["ref"] = ds1.Tables[2].Rows[i][0].ToString();
                    dr["param"] = ds1.Tables[3].Rows[i][1].ToString();
                    dt.Rows.Add(dr);
                }
            }

            keyWord = keyWord == null || string.IsNullOrEmpty(keyWord.Trim()) ? "" : Common.ChangeToNoSymBol(Common.ReplaceRegex(keyWord.Trim().ToLower(), @"\")).Replace("_", @"\w");

            var searchedRows = from DataRow row in dt.Rows
                               where Regex.IsMatch(row["title"].ToString().ToLower(), keyWord) || Regex.IsMatch(row["abstract"].ToString().ToLower(), keyWord)
                               select row;

            var obj = new object[dt.Columns.Count];

            foreach (DataColumn dc in dt.Columns)
            {
                dt1.Columns.Add(dc.ColumnName);
            }

            foreach (DataRow row in searchedRows)
            {
                for (int i = 0; i < obj.Length; i++)
                {
                    obj[i] = row[i];
                }
                dt1.Rows.Add(obj);
            }

            return dt1;
        }

        public DataTable VideoSelectOne(string xmlFilePath, string ide)
        {
            if (!xmlFilePath.StartsWith("~/"))
            {
                xmlFilePath = "~/" + xmlFilePath;
            }
            XmlDocument doc = new XmlDocument();
            doc.Load(HttpContext.Current.Server.MapPath(xmlFilePath));
            XmlElement xroot = doc.DocumentElement;
            XmlNode nodeToSelect = xroot.SelectSingleNode("/asx/entry[@ide='" + ide + "']");
            string vTitle = nodeToSelect.SelectSingleNode("title").InnerText;
            string vAbstract = nodeToSelect.SelectSingleNode("abstract").InnerText;
            string vRef = nodeToSelect.SelectSingleNode("ref").Attributes["href"].Value;
            string vParam = nodeToSelect.SelectSingleNode("param").Attributes["value"].Value;

            DataTable dt = new DataTable();
            DataColumn dide = new DataColumn("ide", typeof(System.String));
            DataColumn title = new DataColumn("title", typeof(System.String));
            DataColumn abs = new DataColumn("abstract", typeof(System.String));
            DataColumn re = new DataColumn("ref", typeof(System.String));
            DataColumn param = new DataColumn("param", typeof(System.String));
            dt.Columns.Add(dide);
            dt.Columns.Add(title);
            dt.Columns.Add(abs);
            dt.Columns.Add(re);
            dt.Columns.Add(param);
            DataRow dr = dt.NewRow();
            dr["ide"] = ide;
            dr["title"] = vTitle;
            dr["abstract"] = vAbstract;
            dr["ref"] = vRef;
            dr["param"] = vParam;
            dt.Rows.Add(dr);
            return dt;
        }
        public string VideoInsert(string xmlFilePath, string title, string abstracts, string videoPath, string imagePath)
        {
            if (!xmlFilePath.StartsWith("~/"))
            {
                xmlFilePath = "~/" + xmlFilePath;
            }
            XmlDocument doc = new XmlDocument();
            doc.Load(HttpContext.Current.Server.MapPath(xmlFilePath));
            XmlElement xroot = doc.DocumentElement;
            XmlElement xEntry, xtitle, xabstract, xref, xparam;
            XmlText txtTitle, txtAbstract;
            if (xroot.ChildNodes.Count != 0)
            {
                XmlNode xmlnode0 = xroot.FirstChild;
                int id = Int32.Parse(xmlnode0.Attributes["ide"].Value);

                string strVideoID = VideoSelectTopID(xmlFilePath);

                xEntry = doc.CreateElement("", "entry", "");
                xtitle = doc.CreateElement("", "title", "");
                xabstract = doc.CreateElement("", "abstract", "");
                xref = doc.CreateElement("", "ref", "");
                xparam = doc.CreateElement("", "param", "");

                txtTitle = doc.CreateTextNode(title);
                xtitle.AppendChild(txtTitle);
                txtAbstract = doc.CreateTextNode(abstracts);
                xabstract.AppendChild(txtAbstract);

                xEntry.SetAttribute("ide", strVideoID);
                xref.SetAttribute("href", "res/videoxml/video_" + strVideoID + Path.GetExtension(videoPath));
                xparam.SetAttribute("name", "image");
                xparam.SetAttribute("value", !string.IsNullOrEmpty(imagePath) ? "res/videoxml/thumbs/video_" + strVideoID + Path.GetExtension(imagePath) : "");

                xEntry.AppendChild(xtitle);
                xEntry.AppendChild(xabstract);
                xEntry.AppendChild(xref);
                xEntry.AppendChild(xparam);

                xroot.InsertBefore(xEntry, xmlnode0);
                doc.Save(HttpContext.Current.Server.MapPath(xmlFilePath));
                return "video_" + strVideoID;
            }
            else
            {
                xEntry = doc.CreateElement("", "entry", "");
                xtitle = doc.CreateElement("", "title", "");
                xabstract = doc.CreateElement("", "abstract", "");
                xref = doc.CreateElement("", "ref", "");
                xparam = doc.CreateElement("", "param", "");

                txtTitle = doc.CreateTextNode(title);
                xtitle.AppendChild(txtTitle);
                txtAbstract = doc.CreateTextNode(abstracts);
                xabstract.AppendChild(txtAbstract);

                xEntry.SetAttribute("ide", "1");
                xref.SetAttribute("href", "res/videoxml/video_1" + Path.GetExtension(videoPath));
                xparam.SetAttribute("name", "image");
                xparam.SetAttribute("value", "res/videoxml/thumbs/video_1" + Path.GetExtension(imagePath));

                xEntry.AppendChild(xtitle);
                xEntry.AppendChild(xabstract);
                xEntry.AppendChild(xref);
                xEntry.AppendChild(xparam);
                xroot.AppendChild(xEntry);
                doc.Save(HttpContext.Current.Server.MapPath(xmlFilePath));
                return "video_1";
            }
        }
        public string VideoUpdate(string xmlFilePath, string ide, string title, string abstracts, string videoPath, string imagePath)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(HttpContext.Current.Server.MapPath(xmlFilePath));
            XmlElement xroot = doc.DocumentElement;
            XmlNode nodeToUpdate = xroot.SelectSingleNode("/asx/entry[@ide='" + ide + "']");
            XmlNode xtitle, xabstract, xref, xparam;
            xtitle = nodeToUpdate.SelectSingleNode("title");
            xabstract = nodeToUpdate.SelectSingleNode("abstract");
            xref = nodeToUpdate.SelectSingleNode("ref");
            xparam = nodeToUpdate.SelectSingleNode("param");
            xtitle.InnerText = title;
            xabstract.InnerText = abstracts;
            if (videoPath != "")
            {
                xref.Attributes["href"].Value = "res/videoxml/video_" + ide + Path.GetExtension(videoPath);
            }
            if (imagePath != "")
            {
                xparam.Attributes["value"].Value = "res/videoxml/thumbs/video_" + ide + Path.GetExtension(imagePath);
            }
            doc.Save(HttpContext.Current.Server.MapPath(xmlFilePath));
            return "video_" + ide + Path.GetExtension(imagePath);
        }

        public bool VideoDelete(string xmlFilePath, string ide)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(HttpContext.Current.Server.MapPath(xmlFilePath));
            XmlElement xroot = doc.DocumentElement;
            XmlNode nodeToDelete = xroot.SelectSingleNode("/asx/entry[@ide='" + ide + "']");
            xroot.RemoveChild(nodeToDelete);
            doc.Save(HttpContext.Current.Server.MapPath(xmlFilePath));
            return true;
        }

        public string VideoSelectTopID(string xmlFilePath)
        {
            //if (!xmlFilePath.StartsWith("~/"))
            //{
            //    xmlFilePath = "~/" + xmlFilePath;
            //}

            //DataSet ds1 = new DataSet();
            //ArrayList arr = new ArrayList();

            //ds1.ReadXml(HttpContext.Current.Server.MapPath(xmlFilePath), XmlReadMode.Auto);

            //if (ds1.Tables.Count != 1)
            //{
            //    for (int i = 0; i < ds1.Tables[1].Rows.Count; i++)
            //    {
            //        var strVideoID = Convert.ToInt32(ds1.Tables[1].Rows[i][3]);
            //        arr.Add(strVideoID);
            //    }
            //}

            //arr.Sort();

            //var newIDs = from int newID in arr where !arr.Contains(newID + 1) select newID + 1;

            //return newIDs.Count() != 0 ? newIDs.First().ToString() : "1";

            if (!xmlFilePath.StartsWith("~/"))
            {
                xmlFilePath = "~/" + xmlFilePath;
            }

            string strVideoID = "1";
            int counter = 0;
            DataSet ds1 = new DataSet();

            ds1.ReadXml(HttpContext.Current.Server.MapPath(xmlFilePath), XmlReadMode.Auto);

            if (ds1.Tables.Count != 1)
            {
                counter = ds1.Tables[1].Rows.Count;
                strVideoID = (counter + 1).ToString();
            }

            return strVideoID;
        }
    }
}
