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
using System.Drawing;


public partial class ad_single_advertisement : System.Web.UI.Page
{
    #region Common Method

    protected void DropDownList_DataBound(object sender, EventArgs e)
    {
        var cbo = (RadComboBox)sender;
        cbo.Items.Insert(0, new RadComboBoxItem(""));
    }

    void DeleteImage(string strFileName)
    {
        if (!string.IsNullOrEmpty(strFileName))
        {
            string strOldImagePath = Server.MapPath("~/res/advertisement/" + strFileName);
            if (File.Exists(strOldImagePath))
                File.Delete(strOldImagePath);
        }
    }

    bool IsImageFormat(string strFileName)
    {
        bool isImgFormat = false;
        string strExtention = Path.GetExtension(strFileName).ToLower();

        switch (strExtention)
        {
            case ".jpg":
                isImgFormat = true;
                break;
            case ".jpeg":
                isImgFormat = true;
                break;
            case ".gif":
                isImgFormat = true;
                break;
            case ".png":
                isImgFormat = true;
                break;
        }
        return isImgFormat;
    }

    #endregion

    #region Event

    protected void Page_Load(object sender, EventArgs e)
    {

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
            ObjectDataSource1.SelectParameters["CompanyName"].DefaultValue = value;
            ObjectDataSource1.DataBind();
            RadGrid1.Rebind();
        }
        else if (e.CommandName == "QuickUpdate")
        {
            string AdsBannerID, Priority, IsAvailable;
            var oAdsBanner = new AdsBanner();

            foreach (GridDataItem item in RadGrid1.Items)
            {
                AdsBannerID = item.GetDataKeyValue("AdsBannerID").ToString();
                Priority = ((RadNumericTextBox)item.FindControl("txtPriority")).Text.Trim();
                IsAvailable = ((CheckBox)item.FindControl("chkIsAvailable")).Checked.ToString();

                oAdsBanner.AdsBannerQuickUpdate(
                    AdsBannerID,
                    Priority,
                    IsAvailable
                );
            }
        }
        else if (e.CommandName == "DeleteSelected")
        {
            var oAdsBanner = new AdsBanner();

            foreach (GridDataItem item in RadGrid1.SelectedItems)
            {
                string strFileName = ((HiddenField)item.FindControl("hdnFileName")).Value;

                if (!string.IsNullOrEmpty(strFileName))
                {
                    string strSavePath = Server.MapPath("~/res/advertisement/" + strFileName);
                    if (File.Exists(strSavePath))
                        File.Delete(strSavePath);
                }
            }
        }
        else if (e.CommandName == "PerformInsert" || e.CommandName == "Update")
        {
            var command = e.CommandName;
            var row = command == "PerformInsert" ? (GridEditFormInsertItem)e.Item : (GridEditFormItem)e.Item;
            var FileFileName = (RadUpload)row.FindControl("FileFileName");
            var dpFromDate = (RadDatePicker)row.FindControl("dpFromDate");
            var dpToDate = (RadDatePicker)row.FindControl("dpToDate");

            string strCompanyName = ((TextBox)row.FindControl("txtCompanyName")).Text.Trim();
            string strConvertedAdsBannerName = Common.ConvertTitle(strCompanyName);
            string strFileName = FileFileName.UploadedFiles.Count > 0 ? FileFileName.UploadedFiles[0].GetName() : "";
            string strIsAvailable = ((CheckBox)row.FindControl("chkIsAvailable")).Checked.ToString();
            string strPriority = ((RadNumericTextBox)row.FindControl("txtPriority")).Text.Trim();
            string strFromDate = dpFromDate.SelectedDate.HasValue ? dpFromDate.SelectedDate.Value.ToString("MM/dd/yyyy") : "";
            string strToDate = dpToDate.SelectedDate.HasValue ? dpToDate.SelectedDate.Value.ToString("MM/dd/yyyy") : "";
            string strAdsCategoryID = ((RadComboBox)row.FindControl("ddlCategory")).SelectedValue;
            string strWebsite = ((TextBox)row.FindControl("txtWebsite")).Text.Trim();
            double ratio = 0;

            if (!string.IsNullOrEmpty(strFileName))
            {
                string strTempPath = Server.MapPath(FileFileName.TargetFolder + strFileName);
                if (IsImageFormat(strFileName))
                {
                    System.Drawing.Image img = System.Drawing.Image.FromFile(strTempPath);
                    ratio = (double)img.Width / (img.Height == 0 ? 1 : img.Height);
                    img.Dispose();
                }
                else
                {
                    SwfParser swfParser = new SwfParser();
                    Rectangle rectangle = swfParser.GetDimensions(strTempPath);
                    ratio = (double)rectangle.Width / (rectangle.Height == 0 ? 1 : rectangle.Height);
                }
                string[] files = Directory.GetFiles(Server.MapPath(FileFileName.TargetFolder));

                foreach (string filePath in files)
                    File.Delete(filePath);
            }

            var oAdsBanner = new AdsBanner();

            if (e.CommandName == "PerformInsert")
            {
                strFileName = oAdsBanner.AdsBannerInsert(
                    strFileName,
                    strConvertedAdsBannerName,
                    strAdsCategoryID,
                    strCompanyName,
                    strWebsite,
                    strFromDate,
                    strToDate,
                    strPriority,
                    strIsAvailable,
                    ratio == 0 ? "" : ratio.ToString().Replace(',', '.')
                    );

                string strFullPath = "~/res/advertisement/" + strFileName;

                if (!string.IsNullOrEmpty(strFileName))
                {
                    FileFileName.UploadedFiles[0].SaveAs(Server.MapPath(strFullPath));
                    if (IsImageFormat(strFileName))
                    {
                        ResizeCropImage.ResizeByCondition(strFullPath, 800, 800);
                    }
                }
                RadGrid1.Rebind();
            }
            else
            {
                var dsUpdateParam = ObjectDataSource1.UpdateParameters;
                var strAdsBannerID = row.GetDataKeyValue("AdsBannerID").ToString();
                var strOldFileName = ((HiddenField)row.FindControl("hdnFileName")).Value;
                var strOldImagePath = Server.MapPath("~/res/advertisement/" + strOldFileName);

                dsUpdateParam["FileName"].DefaultValue = strFileName;
                dsUpdateParam["ConvertedAdsBannerName"].DefaultValue = strConvertedAdsBannerName;
                dsUpdateParam["AdsCategoryID"].DefaultValue = strAdsCategoryID;
                dsUpdateParam["FromDate"].DefaultValue = strFromDate;
                dsUpdateParam["ToDate"].DefaultValue = strToDate;
                dsUpdateParam["IsAvailable"].DefaultValue = strIsAvailable;
                dsUpdateParam["Ratio"].DefaultValue = ratio == 0 ? "" : ratio.ToString().Replace(',', '.');

                if (!string.IsNullOrEmpty(strFileName))
                {
                    var strFullPath = "~/res/advertisement/" + (string.IsNullOrEmpty(strConvertedAdsBannerName) ? "" : strConvertedAdsBannerName + "-") + strAdsBannerID + strFileName.Substring(strFileName.LastIndexOf('.'));

                    if (File.Exists(strOldImagePath))
                        File.Delete(strOldImagePath);

                    FileFileName.UploadedFiles[0].SaveAs(Server.MapPath(strFullPath));
                    if (IsImageFormat(strFileName))
                    {
                        ResizeCropImage.ResizeByCondition(strFullPath, 654, 654);
                    }
                }
            }
        }
        if (e.CommandName == "DeleteImage")
        {
            var oAdsBanner = new AdsBanner();
            var lnkDeleteImage = (LinkButton)e.CommandSource;
            var s = lnkDeleteImage.Attributes["rel"].ToString().Split('#');
            var strAdsBannerID = s[0];
            var strFileName = s[1];

            oAdsBanner.AdsBannerDelete(strAdsBannerID);
            DeleteImage(strFileName);
            RadGrid1.Rebind();
        }
    }
    protected void RadGrid1_ItemDataBound(object sender, GridItemEventArgs e)
    {
        if (e.Item is GridEditableItem && e.Item.IsInEditMode)
        {
            var itemtype = e.Item.ItemType;
            var row = itemtype == GridItemType.EditFormItem ? (GridEditFormItem)e.Item : (GridEditFormInsertItem)e.Item;
            var FileFileName = (RadUpload)row.FindControl("FileFileName");
            var dpFromDate = (RadDatePicker)row.FindControl("dpFromDate");
            var dpToDate = (RadDatePicker)row.FindControl("dpToDate");
            var dv = (DataView)ObjectDataSource1.Select();
            var AdsBannerID = ((HiddenField)row.FindControl("hdnAdsBannerID")).Value;
            var ddlCategory = (RadComboBox)row.FindControl("ddlCategory");

            if (!string.IsNullOrEmpty(AdsBannerID))
            {
                dv.RowFilter = "AdsBannerID = " + AdsBannerID;

                if (!string.IsNullOrEmpty(dv[0]["AdsCategoryID"].ToString()))
                    ddlCategory.SelectedValue = dv[0]["AdsCategoryID"].ToString();
                if (!string.IsNullOrEmpty(dv[0]["FromDate"].ToString()))
                    dpFromDate.SelectedDate = Convert.ToDateTime(dv[0]["FromDate"]);
                if (!string.IsNullOrEmpty(dv[0]["ToDate"].ToString()))
                    dpToDate.SelectedDate = Convert.ToDateTime(dv[0]["ToDate"]);
            }

            RadAjaxPanel1.ResponseScripts.Add(string.Format("window['UploadId'] = '{0}';", FileFileName.ClientID));
        }
    }
    #endregion
}