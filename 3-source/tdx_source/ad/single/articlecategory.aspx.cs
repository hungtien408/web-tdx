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


public partial class ad_single_articlecategory : System.Web.UI.Page
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
            string strOldImagePath = Server.MapPath("~/res/articlecategory/" + strImageName);
            if (File.Exists(strOldImagePath))
                File.Delete(strOldImagePath);
        }
    }

    #endregion

    #region Event

    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void RadGrid1_ItemCommand(object sender, GridCommandEventArgs e)
    {
        if (e.CommandName == "QuickUpdate")
        {
            string ArticleCategoryID, IsShowOnMenu, IsShowOnHomePage, IsAvailable;
            var oArticleCategory = new ArticleCategory();

            foreach (GridDataItem item in RadGrid1.Items)
            {
                ArticleCategoryID = item.GetDataKeyValue("ArticleCategoryID").ToString();
                IsShowOnMenu = ((CheckBox)item.FindControl("chkIsShowOnMenu")).Checked.ToString();
                IsShowOnHomePage = ((CheckBox)item.FindControl("chkIsShowOnHomePage")).Checked.ToString();
                IsAvailable = ((CheckBox)item.FindControl("chkIsAvailable")).Checked.ToString();

                oArticleCategory.ArticleCategoryQuickUpdate(
                    ArticleCategoryID,
                    IsShowOnMenu,
                    IsShowOnHomePage,
                    IsAvailable
                );
            }
        }
        else if (e.CommandName == "DeleteSelected")
        {
            var oArticleCategory = new ArticleCategory();
            var errorList = "";

            foreach (GridDataItem item in RadGrid1.SelectedItems)
            {
                var isChildCategoryExist = oArticleCategory.ArticleCategoryIsChildrenExist(item.GetDataKeyValue("ArticleCategoryID").ToString());
                var ArticleCategoryName = ((Label)item.FindControl("lblArticleCategoryName")).Text;
                var ArticleCategoryNameEn = ((Label)item.FindControl("lblArticleCategoryNameEn")).Text;
                if (isChildCategoryExist)
                {
                    errorList += ", " + ArticleCategoryName;
                }
                else
                {
                    string strImageName = ((HiddenField)item.FindControl("hdnImageName")).Value;

                    if (!string.IsNullOrEmpty(strImageName))
                    {
                        string strSavePath = Server.MapPath("~/res/articlecategory/" + strImageName);
                        if (File.Exists(strSavePath))
                            File.Delete(strSavePath);
                    }
                }
            }
            if (!string.IsNullOrEmpty(errorList))
            {
                e.Canceled = true;
                string strAlertMessage = "Danh mục <b>\"" + errorList.Remove(0, 1).Trim() + "\"</b> đang có danh mục con hoặc sản phẩm.<br /> Xin xóa danh mục con hoặc sản phẩm trong danh mục này hoặc thiết lập hiển thị = \"không\".";
                lblError.Text = strAlertMessage;
            }
        }
        else if (e.CommandName == "PerformInsert" || e.CommandName == "Update")
        {
            var command = e.CommandName;
            var row = command == "PerformInsert" ? (GridEditFormInsertItem)e.Item : (GridEditFormItem)e.Item;
            var FileImageName = (RadUpload)row.FindControl("FileImageName");

            string strArticleCategoryName = ((RadTextBox)row.FindControl("txtArticleCategoryName")).Text.Trim();
            string strArticleCategoryNameEn = ((RadTextBox)row.FindControl("txtArticleCategoryNameEn")).Text.Trim();
            string strConvertedArticleCategoryName = Common.ConvertTitle(strArticleCategoryName);
            string strDescription = HttpUtility.HtmlDecode(FCKEditorFix.Fix(((RadEditor)row.FindControl("txtDescription")).Content.Trim()));
            string strDescriptionEn = HttpUtility.HtmlDecode(FCKEditorFix.Fix(((RadEditor)row.FindControl("txtDescriptionEn")).Content.Trim()));
            string strContent = HttpUtility.HtmlDecode(FCKEditorFix.Fix(((RadEditor)row.FindControl("txtContent")).Content.Trim()));
            string strContentEn = HttpUtility.HtmlDecode(FCKEditorFix.Fix(((RadEditor)row.FindControl("txtContentEn")).Content.Trim()));
            string strMetaTitle = ((RadTextBox)row.FindControl("txtMetaTitle")).Text.Trim();
            string strMetaTitleEn = ((RadTextBox)row.FindControl("txtMetaTitleEn")).Text.Trim();
            string strMetaDescription = ((RadTextBox)row.FindControl("txtMetaDescription")).Text.Trim();
            string strMetaDescriptionEn = ((RadTextBox)row.FindControl("txtMetaDescriptionEn")).Text.Trim();
            string strImageName = FileImageName.UploadedFiles.Count > 0 ? FileImageName.UploadedFiles[0].GetName() : "";
            string strParentID = ((RadComboBox)row.FindControl("ddlParent")).SelectedValue;
            string strIsAvailable = ((CheckBox)row.FindControl("chkIsAvailable")).Checked.ToString();
            string strIsShowOnMenu = ((CheckBox)row.FindControl("chkIsShowOnMenu")).Checked.ToString();
            string strIsShowOnHomePage = ((CheckBox)row.FindControl("chkIsShowOnHomePage")).Checked.ToString();


            var oArticleCategory = new ArticleCategory();

            if (e.CommandName == "PerformInsert")
            {
                strImageName = oArticleCategory.ArticleCategoryInsert(
                    strArticleCategoryName,
                    strArticleCategoryNameEn,
                    strConvertedArticleCategoryName,
                    strDescription,
                    strDescriptionEn,
                    strContent,
                    strContentEn,
                    strMetaTitle,
                    strMetaTitleEn,
                    strMetaDescription,
                    strMetaDescriptionEn,
                    strImageName,
                    strParentID,
                    strIsShowOnMenu,
                    strIsShowOnHomePage,
                    strIsAvailable
                );

                string strFullPath = "~/res/articlecategory/" + strImageName;

                if (!string.IsNullOrEmpty(strImageName))
                {
                    FileImageName.UploadedFiles[0].SaveAs(Server.MapPath(strFullPath));
                    ResizeCropImage.ResizeByCondition(strFullPath, 40, 40);
                }
                RadGrid1.Rebind();
            }
            else
            {
                var dsUpdateParam = ObjectDataSource1.UpdateParameters;
                var strArticleCategoryID = row.GetDataKeyValue("ArticleCategoryID").ToString();
                var strOldImageName = ((HiddenField)row.FindControl("hdnImageName")).Value;
                var strOldImagePath = Server.MapPath("~/res/articlecategory/" + strOldImageName);

                dsUpdateParam["ArticleCategoryName"].DefaultValue = strArticleCategoryName;
                dsUpdateParam["ArticleCategoryNameEn"].DefaultValue = strArticleCategoryNameEn;
                dsUpdateParam["ConvertedArticleCategoryName"].DefaultValue = strConvertedArticleCategoryName;
                dsUpdateParam["Description"].DefaultValue = strDescription;
                dsUpdateParam["DescriptionEn"].DefaultValue = strDescriptionEn;
                dsUpdateParam["Content"].DefaultValue = strContent;
                dsUpdateParam["ContentEn"].DefaultValue = strContentEn;
                dsUpdateParam["ImageName"].DefaultValue = strImageName;
                dsUpdateParam["ParentID"].DefaultValue = strParentID;
                dsUpdateParam["IsShowOnMenu"].DefaultValue = strIsShowOnMenu;
                dsUpdateParam["IsShowOnHomePage"].DefaultValue = strIsShowOnHomePage;
                dsUpdateParam["IsAvailable"].DefaultValue = strIsAvailable;

                if (!string.IsNullOrEmpty(strImageName))
                {
                    var strFullPath = "~/res/articlecategory/" + strConvertedArticleCategoryName + "-" + strArticleCategoryID + strImageName.Substring(strImageName.LastIndexOf('.'));

                    if (File.Exists(strOldImagePath))
                        File.Delete(strOldImagePath);

                    FileImageName.UploadedFiles[0].SaveAs(Server.MapPath(strFullPath));
                    ResizeCropImage.ResizeByCondition(strFullPath, 40, 40);
                }
            }
        }
        if (e.CommandName == "DeleteImage")
        {
            var oArticleCategory = new ArticleCategory();
            var lnkDeleteImage = (LinkButton)e.CommandSource;
            var s = lnkDeleteImage.Attributes["rel"].ToString().Split('#');
            var strArticleCategoryID = s[0];
            var strImageName = s[1];

            oArticleCategory.ArticleCategoryImageDelete(strArticleCategoryID);
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
            var ArticleCategoryID = ((HiddenField)row.FindControl("hdnArticleCategoryID")).Value;
            var dv = (DataView)ObjectDataSource1.Select();
            var ddlParent = (RadComboBox)row.FindControl("ddlParent");

            if (!string.IsNullOrEmpty(ArticleCategoryID))
            {
                dv.RowFilter = "ArticleCategoryID = " + ArticleCategoryID;

                if (!string.IsNullOrEmpty(dv[0]["ParentID"].ToString()))
                    ddlParent.SelectedValue = dv[0]["ParentID"].ToString();
            }

            RadAjaxPanel1.ResponseScripts.Add(string.Format("window['UploadId'] = '{0}';", FileImageName.ClientID));
        }
    }

    protected void lnkUpOrder_Click(object sender, EventArgs e)
    {
        var lnkUpOrder = (LinkButton)sender;
        var strArticleCategoryID = lnkUpOrder.Attributes["rel"];
        var oArticleCategory = new ArticleCategory();
        oArticleCategory.ArticleCategoryUpOrder(strArticleCategoryID);
        RadGrid1.Rebind();

    }
    protected void lnkDownOrder_Click(object sender, EventArgs e)
    {
        var lnkDownOrder = (LinkButton)sender;
        var strArticleCategoryID = lnkDownOrder.Attributes["rel"];
        var oArticleCategory = new ArticleCategory();
        oArticleCategory.ArticleCategoryDownOrder(strArticleCategoryID);
        RadGrid1.Rebind();
    }
    #endregion
}