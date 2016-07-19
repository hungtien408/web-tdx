<%@ Page Title="" Language="C#" MasterPageFile="~/ad/template/adminEn.master" AutoEventWireup="true"
    CodeFile="article.aspx.cs" Inherits="ad_single_article" %>

<%@ Register TagPrefix="asp" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" runat="Server">
    <link href="../assets/styles/rating.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript">
        var tableView = null;
        function RowDblClick(sender, eventArgs) {
            sender.get_masterTableView().editItem(eventArgs.get_itemIndexHierarchical());
        }

        function RowMouseOver(sender, eventArgs) {
            var selectedRows = sender.get_masterTableView().get_selectedItems();
            var elem = $get(eventArgs.get_id());
            if (selectedRows.length > 0)
                for (var i = 0; i < selectedRows.length; i++) {
                    var selectedID = selectedRows[i].get_id();

                    if (selectedID != eventArgs.get_id())
                        elem.className += (" rgSelectedRow");
                }
            else
                elem.className += (" rgSelectedRow");
        }

        function RowMouseOut(sender, eventArgs) {
            var className = "rgSelectedRow";
            var elem = $get(eventArgs.get_id());

            var selectedRows = sender.get_masterTableView().get_selectedItems();

            if (selectedRows.length > 0)
                for (var i = 0; i < selectedRows.length; i++) {
                    var selectedID = selectedRows[i].get_id();
                    if (selectedID != eventArgs.get_id())
                        removeCssClass(className, elem);
                }
            else
                removeCssClass(className, elem);
        }

        function removeCssClass(className, element) {
            element.className = element.className.replace(className, "").replace(/^\s+/, '').replace(/\s+$/, '');
        }

        function pageLoad(sender, args) {
            tableView = $find("<%= RadGrid1.ClientID %>").get_masterTableView();
        }

        function RadComboBox1_SelectedIndexChanged(sender, args) {
            tableView.set_pageSize(sender.get_value());
        }

        function changePage(argument) {
            tableView.page(argument);
        }

        function RadNumericTextBox1_ValueChanged(sender, args) {
            tableView.page(sender.get_value());
        }

        //On insert and update buttons click temporarily disables ajax to perform upload actions
        function conditionalPostback(sender, eventArgs) {
            var theRegexp = new RegExp("\.lnkUpdate$|\.lnkUpdateTop$|\.PerformInsertButton$", "ig");
            if (eventArgs.get_eventTarget().match(theRegexp)) {
                var upload = $find(window['UploadId']);

                //AJAX is disabled only if file is selected for upload
                if (upload.getFileInputs()[0].value != "") {
                    eventArgs.set_enableAjax(false);
                }
            }
            else if (eventArgs.get_eventTarget().indexOf("ExportToExcelButton") >= 0 || eventArgs.get_eventTarget().indexOf("ExportToWordButton") >= 0 || eventArgs.get_eventTarget().indexOf("ExportToPdfButton") >= 0)
                eventArgs.set_enableAjax(false);
        }

        function validateRadUpload(source, e) {
            e.IsValid = false;

            var upload = $find(source.parentNode.getElementsByTagName('div')[0].id);
            var inputs = upload.getFileInputs();
            for (var i = 0; i < inputs.length; i++) {
                //check for empty string or invalid extension
                if (upload.isExtensionValid(inputs[i].value)) {
                    e.IsValid = true;
                    break;
                }
            }
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphBody" runat="Server">
    <h3 class="mainTitle">
        <img alt="" src="../assets/images/product.png" class="vam" />
        Tin Tức
    </h3>
    <asp:RadAjaxPanel ID="RadAjaxPanel1" runat="server" ClientEvents-OnRequestStart="conditionalPostback">
        <asp:Panel ID="pnlSearch" DefaultButton="btnSearch" runat="server">
            <h4 class="searchTitle">
                Tìm kiếm
            </h4>
            <table class="search">
                <tr>
                    <td class="left">
                        Tiêu đề
                    </td>
                    <td>
                        <asp:RadTextBox ID="txtSearchArticleTitle" runat="server" Width="130px">
                        </asp:RadTextBox>
                    </td>
                    <td class="left">
                        Mô tả
                    </td>
                    <td>
                        <asp:RadTextBox ID="txtSearchDescription" runat="server" Width="130px">
                        </asp:RadTextBox>
                    </td>
                    <td class="left">
                        Từ ngày
                    </td>
                    <td>
                        <asp:RadDatePicker ShowPopupOnFocus="True" ID="dpFromDate" runat="server" Culture="vi-VN"
                            Calendar-CultureInfo="vi-VN" Width="138px">
                            <Calendar runat="server">
                                <SpecialDays>
                                    <asp:RadCalendarDay Repeatable="Today">
                                        <ItemStyle CssClass="rcToday" />
                                    </asp:RadCalendarDay>
                                </SpecialDays>
                            </Calendar>
                        </asp:RadDatePicker>
                    </td>
                    <td class="left">
                        Đến ngày
                    </td>
                    <td>
                        <asp:RadDatePicker ShowPopupOnFocus="True" ID="dpToDate" runat="server" Culture="vi-VN"
                            Calendar-CultureInfo="vi-VN" Width="138px">
                            <Calendar runat="server">
                                <SpecialDays>
                                    <asp:RadCalendarDay Repeatable="Today">
                                        <ItemStyle CssClass="rcToday" />
                                    </asp:RadCalendarDay>
                                </SpecialDays>
                            </Calendar>
                        </asp:RadDatePicker>
                    </td>
                </tr>
                <tr>
                    <td class="left">
                        Danh mục
                    </td>
                    <td>
                        <asp:RadComboBox Filter="Contains" ID="ddlSearchCategory" runat="server" DataSourceID="ObjectDataSource2"
                            DataTextField="ArticleCategoryName" DataValueField="ArticleCategoryID" OnDataBound="DropDownList_DataBound"
                            Width="134px">
                        </asp:RadComboBox>
                    </td>
                    <td class="left">
                        Tag
                    </td>
                    <td>
                        <asp:RadTextBox ID="txtSearchTag" runat="server" Width="130px">
                        </asp:RadTextBox>
                    </td>
                    <td class="left">
                        Xem trên trang chủ
                    </td>
                    <td>
                        <asp:RadComboBox Filter="Contains" ID="ddlSearchIsShowOnHomePage" runat="server"
                            Width="134px">
                            <Items>
                                <asp:RadComboBoxItem Value="" />
                                <asp:RadComboBoxItem Value="True" Text="Có" />
                                <asp:RadComboBoxItem Value="False" Text="Không" />
                            </Items>
                        </asp:RadComboBox>
                    </td>
                    <td class="left">
                        Hiển thị
                    </td>
                    <td>
                        <asp:RadComboBox Filter="Contains" ID="ddlSearchIsAvailable" runat="server" Width="134px">
                            <Items>
                                <asp:RadComboBoxItem Value="" />
                                <asp:RadComboBoxItem Value="True" Text="Có" />
                                <asp:RadComboBoxItem Value="False" Text="Không" />
                            </Items>
                        </asp:RadComboBox>
                    </td>
                </tr>
                <tr>
                    <td class="left">
                        Thứ tự
                    </td>
                    <td>
                        <asp:RadComboBox Filter="Contains" ID="ddlSearchPriority" runat="server" Width="134px">
                            <Items>
                                <asp:RadComboBoxItem Value="" />
                                <asp:RadComboBoxItem Value="True" Text="Có" />
                                <asp:RadComboBoxItem Value="False" Text="Không" />
                            </Items>
                        </asp:RadComboBox>
                    </td>
                    <td class="left">
                        Tin Hot
                    </td>
                    <td>
                        <asp:RadComboBox Filter="Contains" ID="ddlSearchIsHot" runat="server" Width="134px">
                            <Items>
                                <asp:RadComboBoxItem Value="" />
                                <asp:RadComboBoxItem Value="True" Text="Có" />
                                <asp:RadComboBoxItem Value="False" Text="Không" />
                            </Items>
                        </asp:RadComboBox>
                    </td>
                    <td class="left">
                        Tin Mới
                    </td>
                    <td>
                        <asp:RadComboBox Filter="Contains" ID="ddlSearchIsNew" runat="server" Width="134px">
                            <Items>
                                <asp:RadComboBoxItem Value="" />
                                <asp:RadComboBoxItem Value="True" Text="Có" />
                                <asp:RadComboBoxItem Value="False" Text="Không" />
                            </Items>
                        </asp:RadComboBox>
                    </td>
                    <td class="left">
                        &nbsp;
                    </td>
                    <td>
                        &nbsp;
                    </td>
                </tr>
            </table>
            <div align="right" style="padding: 5px 0 5px 0; border-bottom: 1px solid #ccc; margin-bottom: 10px">
                <asp:RadButton ID="btnSearch" runat="server" Text="Tìm kiếm">
                    <Icon PrimaryIconUrl="~/ad/assets/images/find.png" />
                </asp:RadButton>
            </div>
        </asp:Panel>
        <asp:Label ID="lblError" ForeColor="Red" runat="server"></asp:Label>
        <asp:RadGrid ID="RadGrid1" AllowMultiRowSelection="True" runat="server" Culture="vi-VN" AllowPaging="True" 
            AllowSorting="True" DataSourceID="ObjectDataSource1" GridLines="Horizontal" AutoGenerateColumns="False"
            AllowAutomaticDeletes="True" ShowStatusBar="True" OnItemCommand="RadGrid1_ItemCommand"
            OnItemDataBound="RadGrid1_ItemDataBound" CssClass="grid" AllowAutomaticUpdates="True"
            CellSpacing="0">
            <ClientSettings EnableRowHoverStyle="true">
                <Selecting AllowRowSelect="True" UseClientSelectColumnOnly="True" />
                <ClientEvents OnRowDblClick="RowDblClick" />
                <Resizing AllowColumnResize="true" ClipCellContentOnResize="False" />
            </ClientSettings>
            <ExportSettings IgnorePaging="true" OpenInNewWindow="true" ExportOnlyData="true"
                Excel-Format="ExcelML" Pdf-AllowCopy="true">
            </ExportSettings>
            <MasterTableView CommandItemDisplay="TopAndBottom" DataSourceID="ObjectDataSource1"
                InsertItemPageIndexAction="ShowItemOnCurrentPage" AllowMultiColumnSorting="True"
                DataKeyNames="ArticleID">
                <PagerStyle AlwaysVisible="true" Mode="NextPrevNumericAndAdvanced" PageButtonCount="10"
                    FirstPageToolTip="Trang đầu" LastPageToolTip="Trang cuối" NextPagesToolTip="Trang kế"
                    NextPageToolTip="Trang kế" PagerTextFormat="Đổi trang: {4} &nbsp;Trang <strong>{0}</strong> / <strong>{1}</strong>, Kết quả <strong>{2}</strong> - <strong>{3}</strong> trong <strong>{5}</strong>."
                    PageSizeLabelText="Kết quả mỗi trang:" PrevPagesToolTip="Trang trước" PrevPageToolTip="Trang trước" />
                <CommandItemTemplate>
                    <div class="command">
                        <div style="float: right">
                            <asp:Button ID="ExportToExcelButton" runat="server" CssClass="rgExpXLS" CommandName="ExportToExcel"
                                AlternateText="Excel" ToolTip="Xuất ra Excel" />
                            <asp:Button ID="ExportToPdfButton" runat="server" CssClass="rgExpPDF" CommandName="ExportToPdf"
                                AlternateText="PDF" ToolTip="Xuất ra PDF" />
                            <asp:Button ID="ExportToWordButton" runat="server" CssClass="rgExpDOC" CommandName="ExportToWord"
                                AlternateText="Word" ToolTip="Xuất ra Word" />
                        </div>
                        <asp:LinkButton ID="LinkButton2" runat="server" CommandName="InitInsert" Visible='<%# !RadGrid1.MasterTableView.IsItemInserted %>'
                            CssClass="item"><img class="vam" alt="" src="../assets/images/add.png" /> Thêm mới</asp:LinkButton>|
                        <%--<asp:LinkButton ID="LinkButton3" runat="server" CommandName="PerformInsert" Visible='<%# RadGrid1.MasterTableView.IsItemInserted %>'><img class="vam" alt="" src="../assets/images/accept.png" /> Thêm</asp:LinkButton>&nbsp;&nbsp;
                        <asp:LinkButton ID="btnCancel" runat="server" CommandName="CancelAll" Visible='<%# RadGrid1.EditIndexes.Count > 0 || RadGrid1.MasterTableView.IsItemInserted %>'><img class="vam" alt="" src="../assets/images/delete-icon.png" /> Hủy</asp:LinkButton>&nbsp;&nbsp;--%>
                        <asp:LinkButton ID="btnEditSelected" runat="server" CommandName="EditSelected" Visible='<%# RadGrid1.EditIndexes.Count == 0 %>'
                            CssClass="item"><img width="12px" class="vam" alt="" src="../assets/images/tools.png" /> Sửa</asp:LinkButton>|
                        <%--<asp:LinkButton ID="btnUpdateEdited" runat="server" CommandName="UpdateEdited" Visible='<%# RadGrid1.EditIndexes.Count > 0 %>'><img class="vam" alt="" src="../assets/images/accept.png" /> Cập nhật</asp:LinkButton>&nbsp;&nbsp;--%>
                        <asp:LinkButton ID="LinkButton1" OnClientClick="javascript:return confirm('Xóa tất cả dòng đã chọn?')"
                            runat="server" CommandName="DeleteSelected" CssClass="item"><img class="vam" alt="" title="Xóa tất cả dòng được chọn" src="../assets/images/delete-icon.png" /> Xóa</asp:LinkButton>|
                        <asp:LinkButton ID="LinkButton6" runat="server" CommandName="QuickUpdate" Visible='<%# RadGrid1.EditIndexes.Count == 0 %>'
                            CssClass="item"><img class="vam" alt="" src="../assets/images/accept.png" /> Sửa nhanh</asp:LinkButton>|
                        <asp:LinkButton ID="LinkButton4" runat="server" CommandName="RebindGrid" CssClass="item"><img class="vam" alt="" src="../assets/images/reload.png" /> Làm mới</asp:LinkButton>
                    </div>
                    <div class="clear">
                    </div>
                    <asp:PlaceHolder ID="PlaceHolder1" runat="server"></asp:PlaceHolder>
                </CommandItemTemplate>
                <Columns>
                    <asp:GridClientSelectColumn FooterText="CheckBoxSelect footer" HeaderStyle-Width="1%"
                        UniqueName="CheckboxSelectColumn" />
                    <asp:GridTemplateColumn HeaderStyle-Width="1%" HeaderText="STT">
                        <ItemTemplate>
                            <%# Container.DataSetIndex + 1 %>
                            <asp:HiddenField ID="hdnImageName" runat="server" Value='<%# Eval("ImageName") %>' />
                        </ItemTemplate>
                    </asp:GridTemplateColumn>
                    <asp:GridBoundColumn HeaderText="ID" DataField="ArticleID" SortExpression="ArticleID">
                    </asp:GridBoundColumn>
                    <asp:GridBoundColumn DataField="ArticleTitle" HeaderText="Tiêu đề" SortExpression="ArticleTitle" />
                    <asp:GridBoundColumn DataField="ArticleCategoryName" HeaderText="Danh mục" SortExpression="ArticleCategoryName" />
                    <asp:GridTemplateColumn DataField="Priority" HeaderStyle-Width="1%" HeaderText="Thứ tự"
                        SortExpression="Priority">
                        <ItemTemplate>
                            <asp:RadNumericTextBox ID="txtPriority" runat="server" Width="70px" Text='<%# Bind("Priority") %>'
                                ShowSpinButtons="true" MinValue="0" EmptyMessage="Thứ tự..." Type="Number">
                                <NumberFormat AllowRounding="false" DecimalDigits="0" GroupSeparator="." />
                            </asp:RadNumericTextBox>
                        </ItemTemplate>
                    </asp:GridTemplateColumn>
                    <asp:GridTemplateColumn HeaderText="Tin mới" SortExpression="IsNew">
                        <ItemTemplate>
                            <asp:CheckBox ID="chkIsNew" runat="server" Checked='<%# string.IsNullOrEmpty(Eval("IsNew").ToString()) ? false : Eval("IsNew") %>'
                                CssClass="checkbox" />
                        </ItemTemplate>
                    </asp:GridTemplateColumn>
                    <asp:GridTemplateColumn HeaderText="Tin Hot" SortExpression="IsHot">
                        <ItemTemplate>
                            <asp:CheckBox ID="chkIsHot" runat="server" Checked='<%# string.IsNullOrEmpty(Eval("IsHot").ToString()) ? false : Eval("IsHot") %>'
                                CssClass="checkbox" />
                        </ItemTemplate>
                    </asp:GridTemplateColumn>
                    <asp:GridTemplateColumn HeaderText="Xem trên trang chủ" SortExpression="IsShowOnHomePage">
                        <ItemTemplate>
                            <asp:CheckBox ID="chkIsShowOnHomePage" runat="server" Checked='<%# string.IsNullOrEmpty(Eval("IsShowOnHomePage").ToString()) ? false : Eval("IsShowOnHomePage") %>'
                                CssClass="checkbox" />
                        </ItemTemplate>
                    </asp:GridTemplateColumn>
                    <asp:GridTemplateColumn DataField="IsAvailable" HeaderText="Hiển thị" SortExpression="IsAvailable">
                        <ItemTemplate>
                            <asp:CheckBox ID="chkIsAvailable" runat="server" Checked='<%# string.IsNullOrEmpty(Eval("IsAvailable").ToString()) ? false : Eval("IsAvailable") %>'
                                CssClass="checkbox" />
                        </ItemTemplate>
                    </asp:GridTemplateColumn>
                    <asp:GridTemplateColumn HeaderText="Ngày tạo" SortExpression="CreateDate" HeaderStyle-Width="1%">
                        <ItemTemplate>
                            <%# string.Format("{0:dd/MM/yyyy hh:mm tt}", Eval("CreateDate"))%>
                        </ItemTemplate>
                    </asp:GridTemplateColumn>
                    <asp:GridTemplateColumn DataField="ImageName" HeaderText="Ảnh" SortExpression="ImageName">
                        <ItemTemplate>
                            <asp:Panel ID="Panel1" runat="server" Visible='<%# string.IsNullOrEmpty( Eval("ImageName").ToString()) ? false : true %>'>
                                <img alt="" src='<%# "~/res/article/thumbs/" + Eval("ImageName") %>' width="80" runat="server"
                                    visible='<%# string.IsNullOrEmpty(Eval("ImageName").ToString()) ? false : true %>' />
                                <asp:LinkButton ID="lnkDeleteImage" runat="server" rel='<%#  Eval("ArticleID") + "#" + Eval("ImageName") %>'
                                    CommandName="DeleteImage" OnClientClick="return confirm('Xóa ảnh này ?')">
                                <img alt="Xóa ảnh" title="Xóa ảnh" src="../assets/images/delete-icon.png" />
                                </asp:LinkButton>
                            </asp:Panel>
                        </ItemTemplate>
                    </asp:GridTemplateColumn>
                </Columns>
                <EditFormSettings EditFormType="Template">
                    <FormTemplate>
                        <asp:Panel ID="Panel1" runat="server" DefaultButton="lnkUpdate">
                            <h3 class="searchTitle">
                                Thông Tin Tin Tức</h3>
                            <asp:HiddenField ID="hdnArticleID" runat="server" Value='<%# Eval("ArticleID") %>' />
                            <asp:HiddenField ID="hdnOldImageName" runat="server" Value='<%# Eval("ImageName") %>' />
                            <div class="edit">
                                <asp:RadButton ID="lnkUpdateTop" runat="server" CommandName='<%# (Container is GridEditFormInsertItem) ? "PerformInsert" : "Update" %>'
                                    Text='<%# (Container is GridEditFormInsertItem) ? "Thêm" : "Cập nhật" %>'>
                                    <Icon PrimaryIconUrl="~/ad/assets/images/ok.png" />
                                </asp:RadButton>
                                &nbsp;&nbsp;
                                <asp:RadButton ID="btnCancel" runat="server" CommandName='Cancel' Text='Hủy'>
                                    <Icon PrimaryIconUrl="~/ad/assets/images/cancel.png" />
                                </asp:RadButton>
                                <hr />
                            </div>
                            <table class="search">
                                <tr>
                                    <td class="left" valign="top">
                                        Ảnh đại diện
                                    </td>
                                    <td runat="server">
                                        <asp:RadUpload ID="FileImageName" runat="server" ControlObjectsVisibility="None"
                                            Culture="vi-VN" Language="vi-VN" InputSize="69" AllowedFileExtensions=".jpg,.jpeg,.gif,.png" />
                                        <asp:CustomValidator ID="CustomValidator1" runat="server" ErrorMessage="Sai định dạng ảnh (*.jpg, *.jpeg, *.gif, *.png)"
                                            ClientValidationFunction="validateRadUpload" Display="Dynamic"></asp:CustomValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="left" colspan="2">
                                        <asp:CheckBox ID="chkIsHot" runat="server" CssClass="checkbox" Text=" Tin Hot" Checked='<%# (Container is GridEditFormInsertItem) ? false : (string.IsNullOrEmpty(Eval("IsHot").ToString()) ? false : Eval("IsHot"))%>' />
                                        &nbsp;&nbsp;
                                        <asp:CheckBox ID="chkIsNew" runat="server" CssClass="checkbox" Text=" Tin mới" Checked='<%# (Container is GridEditFormInsertItem) ? false : (string.IsNullOrEmpty(Eval("IsNew").ToString()) ? false : Eval("IsNew"))%>' />
                                        &nbsp;&nbsp;
                                        <asp:CheckBox ID="chkIsShowOnHomePage" runat="server" CssClass="checkbox" Text=" Xem trên trang chủ"
                                            Checked='<%# (Container is GridEditFormInsertItem) ? true : (string.IsNullOrEmpty(Eval("IsShowOnHomePage").ToString()) ? false : Eval("IsShowOnHomePage"))%>' />
                                        &nbsp;&nbsp;
                                        <asp:CheckBox ID="chkIsAvailable" runat="server" CssClass="checkbox" Text=" Hiển thị"
                                            Checked='<%# (Container is GridEditFormInsertItem) ? true : (string.IsNullOrEmpty(Eval("IsAvailable").ToString()) ? false : Eval("IsAvailable")) %>' />
                                    </td>
                                </tr>
                                <tr>
                                    <td class="left">
                                        Danh mục
                                    </td>
                                    <td>
                                        <asp:RadComboBox Filter="Contains" ID="ddlCategory" runat="server" DataSourceID="ObjectDataSource2"
                                            DataTextField="ArticleCategoryName" DataValueField="ArticleCategoryID" Width="504px"
                                            OnDataBound="DropDownList_DataBound">
                                        </asp:RadComboBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="left">
                                        Thứ tự
                                    </td>
                                    <td>
                                        <asp:RadNumericTextBox ID="txtPriority" runat="server" Width="500px" Text='<%# Bind("Priority") %>'
                                            EmptyMessage="Thứ tự..." Type="Number">
                                            <NumberFormat AllowRounding="false" DecimalDigits="0" GroupSeparator="." />
                                        </asp:RadNumericTextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2">
                                        <h3>
                                            (Ngôn Ngữ Tiếng Việt)</h3>
                                        <hr />
                                    </td>
                                </tr>
                                <tr>
                                    <td class="left">
                                        Tag
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtTag" runat="server" Width="500px" Text='<%# Bind("Tag") %>'></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="left">
                                        Meta Title
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtMetaTittle" runat="server" Width="500px" Text='<%# Bind("MetaTittle") %>'></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="left">
                                        Meta Description
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtMetaDescription" runat="server" Width="500px" Text='<%# Bind("MetaDescription") %>'></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="left">
                                        Tiêu đề
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtArticleTitle" runat="server" Text='<%# Bind("ArticleTitle") %>'
                                            Width="500px"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="left" valign="top">
                                        Mô tả
                                    </td>
                                    <td>
                                        <asp:RadEditor ID="txtDescription" StripFormattingOptions="MSWordRemoveAll,ConvertWordLists,MSWordNoFonts,Font,Css,Span" ContentFilters="ConvertCharactersToEntities,ConvertToXhtml,OptimizeSpans,IndentHTMLContent,ConvertFontToSpan,IECleanAnchors,FixUlBoldItalic,RemoveScripts,FixEnclosingP" runat="server" Height="200" Language="vi-VN" Skin="Office2007"
                                            Width="98%" Content='<%# Bind("Description") %>'>
                                            <ImageManager DeletePaths="~/Uploads/Image/" UploadPaths="~/Uploads/Image/" ViewPaths="~/Uploads/Image/" MaxUploadFileSize="1024000" />
                                            <FlashManager DeletePaths="~/Uploads/Video/" UploadPaths="~/Uploads/Video/" ViewPaths="~/Uploads/Video/" />
                                            <DocumentManager DeletePaths="~/Uploads/File/" UploadPaths="~/Uploads/File/" ViewPaths="~/Uploads/File/" MaxUploadFileSize="1024000" />
                                            <MediaManager DeletePaths="~/Uploads/Media/" UploadPaths="~/Uploads/Media/" ViewPaths="~/Uploads/Media/" />
                                            <TemplateManager DeletePaths="~/Uploads/Template/" UploadPaths="~/Uploads/Template/"
                                                ViewPaths="~/Uploads/Template/" />
                                            <Tools>
                                                <asp:EditorToolGroup>
                                                    <asp:EditorTool Name="Copy" />
                                                    <asp:EditorTool Name="Cut" />
                                                    <asp:EditorTool Name="Paste" />
                                                    <asp:EditorTool Name="Bold" />
                                                    <asp:EditorTool Name="Italic" />
                                                    <asp:EditorTool Name="Underline" />
                                                    <asp:EditorTool Name="InsertLink" />
                                                    <asp:EditorTool Name="ForeColor" />
                                                </asp:EditorToolGroup>
                                            </Tools>
                                        </asp:RadEditor>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="left" valign="top">
                                        Nội dung
                                    </td>
                                    <td>
                                        <asp:RadEditor ID="txtContent" ContentFilters="ConvertCharactersToEntities,ConvertToXhtml,OptimizeSpans,IndentHTMLContent,ConvertFontToSpan,IECleanAnchors,FixUlBoldItalic,RemoveScripts,FixEnclosingP" runat="server" Language="vi-VN" Skin="Office2007"
                                            Width="98%" Content='<%# Bind("Content") %>'>
                                            <ImageManager DeletePaths="~/Uploads/Image/" UploadPaths="~/Uploads/Image/" ViewPaths="~/Uploads/Image/" MaxUploadFileSize="1024000" />
                                            <FlashManager DeletePaths="~/Uploads/Video/" UploadPaths="~/Uploads/Video/" ViewPaths="~/Uploads/Video/" />
                                            <DocumentManager DeletePaths="~/Uploads/File/" UploadPaths="~/Uploads/File/" ViewPaths="~/Uploads/File/" MaxUploadFileSize="1024000" />
                                            <MediaManager DeletePaths="~/Uploads/Media/" UploadPaths="~/Uploads/Media/" ViewPaths="~/Uploads/Media/" />
                                            <TemplateManager DeletePaths="~/Uploads/Template/" UploadPaths="~/Uploads/Template/"
                                                ViewPaths="~/Uploads/Template/" />
                                        </asp:RadEditor>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2">
                                        <h3>
                                            (Ngôn Ngữ Tiếng Anh)</h3>
                                        <hr />
                                    </td>
                                </tr>
                                <tr>
                                    <td class="left">
                                        Tag
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtTagEn" runat="server" Width="500px" Text='<%# Bind("TagEn") %>'></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="left">
                                        Meta Title
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtMetaTittleEn" runat="server" Width="500px" Text='<%# Bind("MetaTittleEn") %>'></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="left">
                                        Meta Description
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtMetaDescriptionEn" runat="server" Width="500px" Text='<%# Bind("MetaDescriptionEn") %>'></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="left">
                                        Tiêu đề
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtArticleTitleEn" runat="server" Text='<%# Bind("ArticleTitleEn") %>'
                                            Width="500px"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="left" valign="top">
                                        Mô tả
                                    </td>
                                    <td>
                                        <asp:RadEditor ID="txtDescriptionEn" ContentFilters="ConvertCharactersToEntities,ConvertToXhtml,OptimizeSpans,IndentHTMLContent,ConvertFontToSpan,IECleanAnchors,FixUlBoldItalic,RemoveScripts,FixEnclosingP" runat="server" Height="200" Language="vi-VN"
                                            Skin="Office2007" Width="98%" Content='<%# Bind("DescriptionEn") %>'>
                                            <ImageManager DeletePaths="~/Uploads/Image/" UploadPaths="~/Uploads/Image/" ViewPaths="~/Uploads/Image/" MaxUploadFileSize="1024000" />
                                            <FlashManager DeletePaths="~/Uploads/Video/" UploadPaths="~/Uploads/Video/" ViewPaths="~/Uploads/Video/" />
                                            <DocumentManager DeletePaths="~/Uploads/File/" UploadPaths="~/Uploads/File/" ViewPaths="~/Uploads/File/" MaxUploadFileSize="1024000" />
                                            <MediaManager DeletePaths="~/Uploads/Media/" UploadPaths="~/Uploads/Media/" ViewPaths="~/Uploads/Media/" />
                                            <TemplateManager DeletePaths="~/Uploads/Template/" UploadPaths="~/Uploads/Template/"
                                                ViewPaths="~/Uploads/Template/" />
                                            <Tools>
                                                <asp:EditorToolGroup>
                                                    <asp:EditorTool Name="Copy" />
                                                    <asp:EditorTool Name="Cut" />
                                                    <asp:EditorTool Name="Paste" />
                                                    <asp:EditorTool Name="Bold" />
                                                    <asp:EditorTool Name="Italic" />
                                                    <asp:EditorTool Name="Underline" />
                                                    <asp:EditorTool Name="InsertLink" />
                                                    <asp:EditorTool Name="ForeColor" />
                                                </asp:EditorToolGroup>
                                            </Tools>
                                        </asp:RadEditor>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="left" valign="top">
                                        Nội dung
                                    </td>
                                    <td>
                                        <asp:RadEditor ID="txtContentEn" ContentFilters="ConvertCharactersToEntities,ConvertToXhtml,OptimizeSpans,IndentHTMLContent,ConvertFontToSpan,IECleanAnchors,FixUlBoldItalic,RemoveScripts,FixEnclosingP" runat="server" Language="vi-VN" Skin="Office2007"
                                            Width="98%" Content='<%# Bind("ContentEn") %>'>
                                            <ImageManager DeletePaths="~/Uploads/Image/" UploadPaths="~/Uploads/Image/" ViewPaths="~/Uploads/Image/" MaxUploadFileSize="1024000" />
                                            <FlashManager DeletePaths="~/Uploads/Video/" UploadPaths="~/Uploads/Video/" ViewPaths="~/Uploads/Video/" />
                                            <DocumentManager DeletePaths="~/Uploads/File/" UploadPaths="~/Uploads/File/" ViewPaths="~/Uploads/File/" MaxUploadFileSize="1024000" />
                                            <MediaManager DeletePaths="~/Uploads/Media/" UploadPaths="~/Uploads/Media/" ViewPaths="~/Uploads/Media/" />
                                            <TemplateManager DeletePaths="~/Uploads/Template/" UploadPaths="~/Uploads/Template/"
                                                ViewPaths="~/Uploads/Template/" />
                                        </asp:RadEditor>
                                    </td>
                                </tr>
                            </table>
                            <div class="edit">
                                <hr />
                                <asp:RadButton ID="lnkUpdate" runat="server" CommandName='<%# (Container is GridEditFormInsertItem) ? "PerformInsert" : "Update" %>'
                                    Text='<%# (Container is GridEditFormInsertItem) ? "Thêm" : "Cập nhật" %>'>
                                    <Icon PrimaryIconUrl="~/ad/assets/images/ok.png" />
                                </asp:RadButton>
                                &nbsp;&nbsp;
                                <asp:RadButton ID="RadButton1" runat="server" CommandName='Cancel' Text='Hủy'>
                                    <Icon PrimaryIconUrl="~/ad/assets/images/cancel.png" />
                                </asp:RadButton>
                            </div>
                        </asp:Panel>
                        <asp:RadInputManager ID="RadInputManager2" runat="server">
                            <asp:NumericTextBoxSetting AllowRounding="False" Culture="vi-VN" EmptyMessage="Thứ tự ..."
                                Type="Number" DecimalDigits="0">
                                <TargetControls>
                                    <asp:TargetInput ControlID="txtPriority" />
                                </TargetControls>
                            </asp:NumericTextBoxSetting>
                        </asp:RadInputManager>
                    </FormTemplate>
                </EditFormSettings>
            </MasterTableView>
            <HeaderStyle Font-Bold="True" />
            <HeaderContextMenu EnableImageSprites="True" CssClass="GridContextMenu GridContextMenu_Default">
            </HeaderContextMenu>
        </asp:RadGrid>
        <asp:RadInputManager ID="RadInputManager1" runat="server">
            <asp:NumericTextBoxSetting AllowRounding="False" Culture="vi-VN" EmptyMessage="Thứ tự ..."
                Type="Number" DecimalDigits="0">
                <TargetControls>
                    <asp:TargetInput ControlID="txtPriority" />
                </TargetControls>
            </asp:NumericTextBoxSetting>
            <asp:TextBoxSetting EmptyMessage="Tag ...">
                <TargetControls>
                    <asp:TargetInput ControlID="txtTag" />
                </TargetControls>
            </asp:TextBoxSetting>
            <asp:TextBoxSetting EmptyMessage="Meta Title ...">
                <TargetControls>
                    <asp:TargetInput ControlID="txtMetaTittle" />
                </TargetControls>
            </asp:TextBoxSetting>
            <asp:TextBoxSetting EmptyMessage="Meta Description ...">
                <TargetControls>
                    <asp:TargetInput ControlID="txtMetaDescription" />
                </TargetControls>
            </asp:TextBoxSetting>
            <asp:TextBoxSetting EmptyMessage="Tiêu đề ...">
                <TargetControls>
                    <asp:TargetInput ControlID="txtArticleTitle" />
                </TargetControls>
            </asp:TextBoxSetting>
            <%-- Tiếng Anh--%>
            <asp:TextBoxSetting EmptyMessage="Tag(En) ...">
                <TargetControls>
                    <asp:TargetInput ControlID="txtTagEn" />
                </TargetControls>
            </asp:TextBoxSetting>
            <asp:TextBoxSetting EmptyMessage="Meta Title(En) ...">
                <TargetControls>
                    <asp:TargetInput ControlID="txtMetaTittleEn" />
                </TargetControls>
            </asp:TextBoxSetting>
            <asp:TextBoxSetting EmptyMessage="Meta Description(En) ...">
                <TargetControls>
                    <asp:TargetInput ControlID="txtMetaDescriptionEn" />
                </TargetControls>
            </asp:TextBoxSetting>
            <asp:TextBoxSetting EmptyMessage="Tiêu đề(En) ...">
                <TargetControls>
                    <asp:TargetInput ControlID="txtArticleTitleEn" />
                </TargetControls>
            </asp:TextBoxSetting>
        </asp:RadInputManager>
    </asp:RadAjaxPanel>
    <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" SelectMethod="ArticleSelectAll"
        TypeName="TLLib.Article" DeleteMethod="ArticleDelete" UpdateMethod="ArticleUpdate"
        InsertMethod="ArticleInsert">
        <DeleteParameters>
            <asp:Parameter Name="ArticleID" Type="String" />
        </DeleteParameters>
        <InsertParameters>
            <asp:Parameter Name="ImageName" Type="String" />
            <asp:Parameter Name="MetaTittle" Type="String" />
            <asp:Parameter Name="MetaDescription" Type="String" />
            <asp:Parameter Name="ArticleTitle" Type="String" />
            <asp:Parameter Name="ConvertedArticleTitle" Type="String" />
            <asp:Parameter Name="Description" Type="String" />
            <asp:Parameter Name="Content" Type="String" />
            <asp:Parameter Name="Tag" Type="String" />
            <asp:Parameter Name="MetaTittleEn" Type="String" />
            <asp:Parameter Name="MetaDescriptionEn" Type="String" />
            <asp:Parameter Name="ArticleTitleEn" Type="String" />
            <asp:Parameter Name="DescriptionEn" Type="String" />
            <asp:Parameter Name="ContentEn" Type="String" />
            <asp:Parameter Name="TagEn" Type="String" />
            <asp:Parameter Name="ArticleCategoryID" Type="String" />
            <asp:Parameter Name="IsShowOnHomePage" Type="String" />
            <asp:Parameter Name="IsHot" Type="String" />
            <asp:Parameter Name="IsNew" Type="String" />
            <asp:Parameter Name="IsAvailable" Type="String" />
            <asp:Parameter Name="Priority" Type="String" />
        </InsertParameters>
        <SelectParameters>
            <asp:Parameter Name="StartRowIndex" Type="String" />
            <asp:Parameter Name="EndRowIndex" Type="String" />
            <asp:Parameter Name="Keyword" Type="String" />
            <asp:ControlParameter ControlID="txtSearchArticleTitle" Name="ArticleTitle" PropertyName="Text"
                Type="String" />
            <asp:ControlParameter ControlID="txtSearchDescription" Name="Description" PropertyName="Text"
                Type="String" />
            <asp:ControlParameter ControlID="ddlSearchCategory" Name="ArticleCategoryID" PropertyName="SelectedValue"
                Type="String" />
            <asp:ControlParameter ControlID="txtSearchTag" Name="Tag" PropertyName="Text" Type="String" />
            <asp:ControlParameter ControlID="ddlSearchIsShowOnHomePage" Name="IsShowOnHomePage"
                PropertyName="SelectedValue" Type="String" />
            <asp:ControlParameter ControlID="ddlSearchIsHot" Name="IsHot" PropertyName="SelectedValue"
                Type="String" />
            <asp:ControlParameter ControlID="ddlSearchIsNew" Name="IsNew" PropertyName="SelectedValue"
                Type="String" />
            <asp:ControlParameter ControlID="dpFromDate" Name="FromDate" PropertyName="SelectedDate"
                Type="String" />
            <asp:ControlParameter ControlID="dpToDate" Name="ToDate" PropertyName="SelectedDate"
                Type="String" />
            <asp:ControlParameter ControlID="ddlSearchIsAvailable" Name="IsAvailable" PropertyName="SelectedValue"
                Type="String" />
            <asp:ControlParameter ControlID="ddlSearchPriority" Name="Priority" PropertyName="SelectedValue"
                Type="String" />
            <asp:Parameter Name="SortByPriority" Type="String" />
        </SelectParameters>
        <UpdateParameters>
            <asp:Parameter Name="ImageName" Type="String" />
            <asp:Parameter Name="ArticleID" Type="String" />
            <asp:Parameter Name="MetaTittle" Type="String" />
            <asp:Parameter Name="MetaDescription" Type="String" />
            <asp:Parameter Name="ArticleTitle" Type="String" />
            <asp:Parameter Name="ConvertedArticleTitle" Type="String" />
            <asp:Parameter Name="Description" Type="String" />
            <asp:Parameter Name="Content" Type="String" />
            <asp:Parameter Name="Tag" Type="String" />
            <asp:Parameter Name="MetaTittleEn" Type="String" />
            <asp:Parameter Name="MetaDescriptionEn" Type="String" />
            <asp:Parameter Name="ArticleTitleEn" Type="String" />
            <asp:Parameter Name="DescriptionEn" Type="String" />
            <asp:Parameter Name="ContentEn" Type="String" />
            <asp:Parameter Name="TagEn" Type="String" />
            <asp:Parameter Name="ArticleCategoryID" Type="String" />
            <asp:Parameter Name="IsShowOnHomePage" Type="String" />
            <asp:Parameter Name="IsHot" Type="String" />
            <asp:Parameter Name="IsNew" Type="String" />
            <asp:Parameter Name="IsAvailable" Type="String" />
            <asp:Parameter Name="Priority" Type="String" />
        </UpdateParameters>
    </asp:ObjectDataSource>
    <asp:ObjectDataSource ID="ObjectDataSource2" runat="server" SelectMethod="ArticleCategorySelectAll"
        TypeName="TLLib.ArticleCategory"></asp:ObjectDataSource>
    <asp:RadProgressManager ID="RadProgressManager1" runat="server" />
    <asp:RadProgressArea ID="ProgressArea1" runat="server" Culture="vi-VN" DisplayCancelButton="True"
        HeaderText="Đang tải" Skin="Office2007" Style="position: fixed; top: 50% !important;
        left: 50% !important; margin: -93px 0 0 -188px;" />
</asp:Content>
