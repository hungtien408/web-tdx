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

public partial class ad_single_article : System.Web.UI.Page
{

    #region Common Method

    protected void DropDownList_DataBound(object sender, EventArgs e)
    {
        var cbo = (RadComboBox)sender;
        cbo.Items.Insert(0, new RadComboBoxItem(""));
    }

    void DeleteImage(string strImageName)
    {
        if (!string.IsNullOrEmpty(strImageName))
        {
            var strImagePath = Server.MapPath("~/res/article/" + strImageName);
            var strThumbImagePath = Server.MapPath("~/res/article/thumbs/" + strImageName);

            if (File.Exists(strImagePath))
                File.Delete(strImagePath);
            if (File.Exists(strThumbImagePath))
                File.Delete(strThumbImagePath);
        }
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
            ObjectDataSource1.SelectParameters["ArticleTitle"].DefaultValue = value;
            ObjectDataSource1.DataBind();
            RadGrid1.Rebind();
        }
        else if (e.CommandName == "QuickUpdate")
        {
            string ArticleID, Priority, IsShowOnHomePage, IsHot, IsNew, IsAvailable;
            var oArticle = new Article();

            foreach (GridDataItem item in RadGrid1.Items)
            {
                ArticleID = item.GetDataKeyValue("ArticleID").ToString();
                Priority = ((RadNumericTextBox)item.FindControl("txtPriority")).Text.Trim();
                IsShowOnHomePage = ((CheckBox)item.FindControl("chkIsShowOnHomePage")).Checked.ToString();
                IsHot = ((CheckBox)item.FindControl("chkIsHot")).Checked.ToString();
                IsNew = ((CheckBox)item.FindControl("chkIsNew")).Checked.ToString();
                IsAvailable = ((CheckBox)item.FindControl("chkIsAvailable")).Checked.ToString();

                oArticle.ArticleQuickUpdate(
                    ArticleID,
                    IsShowOnHomePage,
                    IsHot,
                    IsNew,
                    IsAvailable,
                    Priority
                );
            }
        }
        else if (e.CommandName == "DeleteSelected")
        {
            string OldImageName;
            var oArticle = new Article();

            foreach (GridDataItem item in RadGrid1.SelectedItems)
            {
                OldImageName = ((HiddenField)item.FindControl("hdnImageName")).Value;
                DeleteImage(OldImageName);
            }
        }
        else if (e.CommandName == "PerformInsert" || e.CommandName == "Update")
        {
            var command = e.CommandName;
            var row = command == "PerformInsert" ? (GridEditFormInsertItem)e.Item : (GridEditFormItem)e.Item;
            var FileImageName = (RadUpload)row.FindControl("FileImageName");
            var oArticle = new Article();

            string strArticleID = ((HiddenField)row.FindControl("hdnArticleID")).Value;
            string strOldImageName = ((HiddenField)row.FindControl("hdnOldImageName")).Value;
            string strImageName = FileImageName.UploadedFiles.Count > 0 ? FileImageName.UploadedFiles[0].GetName() : "";
            string strPriority = ((RadNumericTextBox)row.FindControl("txtPriority")).Text.Trim();
            string strMetaTittle = ((TextBox)row.FindControl("txtMetaTittle")).Text.Trim();
            string strMetaDescription = ((TextBox)row.FindControl("txtMetaDescription")).Text.Trim();
            string strArticleTitle = ((TextBox)row.FindControl("txtArticleTitle")).Text.Trim();
            string strConvertedArticleTitle = Common.ConvertTitle(strArticleTitle);
            string strDescription = HttpUtility.HtmlDecode(FCKEditorFix.Fix(((RadEditor)row.FindControl("txtDescription")).Content.Trim()));
            string strContent = HttpUtility.HtmlDecode(FCKEditorFix.Fix(((RadEditor)row.FindControl("txtContent")).Content.Trim()));
            string strTag = ((TextBox)row.FindControl("txtTag")).Text.Trim();
            string strArticleCategoryID = ((RadComboBox)row.FindControl("ddlCategory")).SelectedValue;
            string strIsShowOnHomePage = ((CheckBox)row.FindControl("chkIsShowOnHomePage")).Checked.ToString();
            string strIsHot = ((CheckBox)row.FindControl("chkIsHot")).Checked.ToString();
            string strIsNew = ((CheckBox)row.FindControl("chkIsNew")).Checked.ToString();
            string strIsAvailable = ((CheckBox)row.FindControl("chkIsAvailable")).Checked.ToString();
            string strMetaTittleEn = ((TextBox)row.FindControl("txtMetaTittleEn")).Text.Trim();
            string strMetaDescriptionEn = ((TextBox)row.FindControl("txtMetaDescriptionEn")).Text.Trim();
            string strArticleTitleEn = ((TextBox)row.FindControl("txtArticleTitleEn")).Text.Trim();
            string strDescriptionEn = ((RadEditor)row.FindControl("txtDescriptionEn")).Content.Trim();
            string strContentEn = ((RadEditor)row.FindControl("txtContentEn")).Content.Trim();
            string strTagEn = ((TextBox)row.FindControl("txtTagEn")).Text.Trim();


            if (e.CommandName == "PerformInsert")
            {
                strImageName = oArticle.ArticleInsert(
                strImageName,
                strMetaTittle,
	            strMetaDescription,
                strArticleTitle,
                strConvertedArticleTitle,
                strDescription,
                strContent,
                strTag,
                strMetaTittleEn,
                strMetaDescriptionEn,
                strArticleTitleEn,
                strDescriptionEn,
                strContentEn,
                strTagEn,
                strArticleCategoryID,
                strIsShowOnHomePage,
                strIsHot,
                strIsNew,
                strIsAvailable,
                strPriority
                    );

                string strFullPath = "~/res/article/" + strImageName;
                if (!string.IsNullOrEmpty(strImageName))
                {
                    FileImageName.UploadedFiles[0].SaveAs(Server.MapPath(strFullPath));
                    ResizeCropImage.ResizeByCondition(strFullPath, 800, 800);
                    ResizeCropImage.CreateThumbNailByCondition("~/res/article/", "~/res/article/thumbs/", strImageName, 120, 120);
                }
                RadGrid1.Rebind();
            }
            else
            {
                var dsUpdateParam = ObjectDataSource1.UpdateParameters;
                var strOldImagePath = Server.MapPath("~/res/article/" + strOldImageName);
                var strOldThumbImagePath = Server.MapPath("~/res/article/thumbs/" + strOldImageName);

                dsUpdateParam["ArticleTitle"].DefaultValue = strArticleTitle;
                dsUpdateParam["ConvertedArticleTitle"].DefaultValue = strConvertedArticleTitle;
                dsUpdateParam["ImageName"].DefaultValue = strImageName;
                dsUpdateParam["ArticleCategoryID"].DefaultValue = strArticleCategoryID;
                dsUpdateParam["IsShowOnHomePage"].DefaultValue = strIsShowOnHomePage;
                dsUpdateParam["IsHot"].DefaultValue = strIsHot;
                dsUpdateParam["IsNew"].DefaultValue = strIsNew;
                dsUpdateParam["IsAvailable"].DefaultValue = strIsAvailable;

                if (!string.IsNullOrEmpty(strImageName))
                {
                    if (File.Exists(strOldImagePath))
                        File.Delete(strOldImagePath);
                    if (File.Exists(strOldThumbImagePath))
                        File.Delete(strOldThumbImagePath);

                    strImageName = (string.IsNullOrEmpty(strConvertedArticleTitle) ? "" : strConvertedArticleTitle + "-") + strArticleID + strImageName.Substring(strImageName.LastIndexOf('.'));

                    string strFullPath = "~/res/article/" + strImageName;

                    FileImageName.UploadedFiles[0].SaveAs(Server.MapPath(strFullPath));
                    ResizeCropImage.ResizeByCondition(strFullPath, 800, 800);
                    ResizeCropImage.CreateThumbNailByCondition("~/res/article/", "~/res/article/thumbs/", strImageName, 120, 120);
                }
            }
        }
        if (e.CommandName == "DeleteImage")
        {
            var oArticle = new Article();
            var lnkDeleteImage = (LinkButton)e.CommandSource;
            var s = lnkDeleteImage.Attributes["rel"].ToString().Split('#');
            var strArticleID = s[0];
            var strImageName = s[1];

            oArticle.ArticleImageDelete(strArticleID);
            DeleteImage(strImageName);
            RadGrid1.Rebind();
        }
    }
    protected void RadGrid1_ItemDataBound(object sender, GridItemEventArgs e)
    {
        if (e.Item is GridEditableItem && e.Item.IsInEditMode)
        {
            var itemtype = e.Item.ItemType;
            var row = itemtype == GridItemType.EditFormItem ? (GridEditFormItem)e.Item : (GridEditFormInsertItem)e.Item;
            var FileImageName = (RadUpload)row.FindControl("FileImageName");
            var dv = (DataView)ObjectDataSource1.Select();
            var ArticleID = ((HiddenField)row.FindControl("hdnArticleID")).Value;
            var ddlCategory = (RadComboBox)row.FindControl("ddlCategory");

            if (!string.IsNullOrEmpty(ArticleID))
            {
                dv.RowFilter = "ArticleID = " + ArticleID;

                if (!string.IsNullOrEmpty(dv[0]["ArticleCategoryID"].ToString()))
                    ddlCategory.SelectedValue = dv[0]["ArticleCategoryID"].ToString();
            }
            RadAjaxPanel1.ResponseScripts.Add(string.Format("window['UploadId'] = '{0}';", FileImageName.ClientID));
        }
    }

    #endregion

}