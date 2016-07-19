<%@ Page Title="" Language="C#" MasterPageFile="~/ad/template/adminEn.master" AutoEventWireup="true"
    CodeFile="advertisement.aspx.cs" Inherits="ad_single_advertisement" %>

<%@ Register TagPrefix="asp" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" runat="Server">
    <link href="../assets/styles/sreenshort.css" rel="stylesheet" type="text/css" />
    <script src="../assets/js/sreenshort.js" type="text/javascript"></script>
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
        <img alt="" src="../assets/images/advertisement.png" class="vam" />
        Quảng cáo</h3>
    <br />
    <asp:RadAjaxPanel ID="RadAjaxPanel1" runat="server" ClientEvents-OnRequestStart="conditionalPostback">
        <asp:Panel ID="pnlSearch" DefaultButton="btnSearch" runat="server">
            <table class="search">
                <tr>
                    <td class="left">
                        Tên công ty
                    </td>
                    <td>
                        <asp:RadTextBox ID="txtSearchCompanyName" runat="server" Width="200px">
                        </asp:RadTextBox>
                    </td>
                    <td class="left">
                        Website
                    </td>
                    <td>
                        <asp:RadTextBox ID="txtSearchWebsite" runat="server" Width="200px">
                        </asp:RadTextBox>
                    </td>
                    <td class="left">
                        Vị trí
                    </td>
                    <td>
                        <asp:RadComboBox Filter="Contains" ID="ddlSearchCategory" runat="server" CssClass="dropdownlist"
                            DataTextField="AdsCategoryName" DataValueField="AdsCategoryID" DataSourceID="ObjectDataSource2"
                            OnDataBound="DropDownList_DataBound" Width="204px">
                        </asp:RadComboBox>
                    </td>
                </tr>
                <tr>
                    <td class="left">
                        Từ ngày
                    </td>
                    <td>
                        <asp:RadDatePicker ShowPopupOnFocus="True" ID="dpFromDate" runat="server" Culture="vi-VN"
                            Calendar-CultureInfo="vi-VN" Width="208px">
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
                            Calendar-CultureInfo="vi-VN" Width="208px">
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
                        Hiển thị
                    </td>
                    <td>
                        <asp:RadComboBox Filter="Contains" ID="ddlSearchIsAvailable" runat="server" CssClass="dropdownlist"
                            Width="204px">
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
                        <asp:RadComboBox Filter="Contains" ID="ddlSearchPriority" runat="server" CssClass="dropdownlist"
                            Width="204px">
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
                    <td class="left">
                        &nbsp;
                    </td>
                    <td>
                        &nbsp;
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
        <asp:RadGrid ID="RadGrid1" AllowMultiRowSelection="True" runat="server" Culture="vi-VN" 
            DataSourceID="ObjectDataSource1" GridLines="Horizontal" AutoGenerateColumns="False"
            AllowAutomaticDeletes="True" ShowStatusBar="True" Skin="Default" OnItemCommand="RadGrid1_ItemCommand"
            OnItemDataBound="RadGrid1_ItemDataBound" CssClass="grid" AllowAutomaticUpdates="True"
            AllowSorting="True">
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
                DataKeyNames="AdsBannerID">
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
                            <asp:HiddenField ID="hdnAdsBannerID" runat="server" Value='<%# Eval("AdsBannerID") %>' />
                            <asp:HiddenField ID="hdnFileName" runat="server" Value='<%# Eval("FileName") %>' />
                        </ItemTemplate>
                    </asp:GridTemplateColumn>
                    <asp:GridBoundColumn HeaderText="ID" DataField="AdsBannerID" SortExpression="AdsBannerID">
                    </asp:GridBoundColumn>
                    <asp:GridTemplateColumn HeaderText="Tên công ty" DataField="CompanyName" SortExpression="CompanyName">
                        <ItemTemplate>
                            <%# Eval("CompanyName")%>
                        </ItemTemplate>
                    </asp:GridTemplateColumn>
                    <asp:GridTemplateColumn HeaderText="Website" DataField="Website" SortExpression="Website">
                        <ItemTemplate>
                            <a href='<%# Eval("Website")%>' target="_blank">
                                <%# Eval("Website")%></a>
                        </ItemTemplate>
                    </asp:GridTemplateColumn>
                    <asp:GridTemplateColumn HeaderText="Từ ngày" DataField="FromDate" SortExpression="FromDate">
                        <ItemTemplate>
                            <%# string.Format("{0:dd/MM/yyyy}", Eval("FromDate"))%>
                        </ItemTemplate>
                    </asp:GridTemplateColumn>
                    <asp:GridTemplateColumn HeaderText="Đến ngày" DataField="ToDate" SortExpression="ToDate">
                        <ItemTemplate>
                            <%# string.Format("{0:dd/MM/yyyy}", Eval("ToDate"))%>
                        </ItemTemplate>
                    </asp:GridTemplateColumn>
                    <asp:GridTemplateColumn HeaderText="Vị trí" DataField="AdsCategoryName" SortExpression="AdsCategoryName">
                        <ItemTemplate>
                            <%# Eval("AdsCategoryName")%>
                        </ItemTemplate>
                    </asp:GridTemplateColumn>
                    <asp:GridTemplateColumn HeaderText="Thứ tự" DataField="Priority" SortExpression="Priority">
                        <ItemTemplate>
                            <asp:RadNumericTextBox ID="txtPriority" runat="server" Width="70px" Text='<%# Bind("Priority") %>'
                                ShowSpinButtons="true" MinValue="0" EmptyMessage="Thứ tự..." Type="Number">
                                <NumberFormat AllowRounding="false" DecimalDigits="0" GroupSeparator="." />
                            </asp:RadNumericTextBox>
                        </ItemTemplate>
                    </asp:GridTemplateColumn>
                    <asp:GridTemplateColumn HeaderText="Hiển thị" DataField="IsAvailable" SortExpression="IsAvailable">
                        <ItemTemplate>
                            <asp:CheckBox ID="chkIsAvailable" runat="server" Checked='<%# Eval("IsAvailable") == DBNull.Value ? false : Convert.ToBoolean(Eval("IsAvailable"))%>'
                                CssClass="checkbox" />
                        </ItemTemplate>
                    </asp:GridTemplateColumn>
                    <asp:GridTemplateColumn HeaderText="Banner">
                        <ItemTemplate>
                            <div style="position: relative">
                                <div style="position: absolute">
                                    <asp:Image runat="server" ImageUrl="~/ad/assets/images/het-han.gif" Visible='<%# string.IsNullOrEmpty(Eval("IsDeadLine").ToString()) ? false : Eval("IsDeadLine")%>' />
                                    <asp:Image runat="server" ImageUrl="~/ad/assets/images/sap-het-han.gif" Visible='<%# string.IsNullOrEmpty(Eval("BeginDeadLine").ToString()) ? false : (Convert.ToBoolean(Eval("IsDeadLine")) ? false : Eval("BeginDeadLine")) %>' />
                                </div>
                                <div runat="server" visible='<%# string.IsNullOrEmpty(Eval("FileName").ToString()) ? false : (!Eval("FileName").ToString().ToLower().EndsWith(".swf") ? true : false) %>'>
                                    <img id="Img2" alt="" height="100" width='<%# string.IsNullOrEmpty(Eval("Ratio").ToString()) ? "100%" : (100*Convert.ToDouble( Eval("Ratio"))).ToString() %>'
                                        src='<%# "../../res/advertisement/" + Eval("FileName") %>' />
                                </div>
                                <div runat="server" visible='<%# Eval("FileName").ToString() == "" ? false : (Eval("FileName").ToString().ToLower().EndsWith(".swf") ? true : false) %>'>
                                    <object id="Object1" height="100" width='<%# string.IsNullOrEmpty(Eval("Ratio").ToString()) ? "100%" : (100*Convert.ToDouble( Eval("Ratio"))).ToString() %>'
                                        style="z-index: 0;" name="player" classid="clsid:D27CDB6E-AE6D-11cf-96B8-444553540000">
                                        <param value='../../res/advertisement/<%# Eval("FileName") %>' name="movie">
                                        <param value="true" name="allowfullscreen">
                                        <param value="always" name="allowscriptaccess">
                                        <param value="opaque" name="wmode">
                                        <embed id="player2" height="100" width='<%# string.IsNullOrEmpty(Eval("Ratio").ToString()) ? "100%" : (100*Convert.ToDouble( Eval("Ratio"))).ToString() %>'
                                            style="z-index: 0;" wmode="opaque" allowfullscreen="false" allowscriptaccess="always"
                                            src="../../res/advertisement/<%# Eval("FileName") %>" name="player2" type="application/x-shockwave-flash">
                                    </object>
                                </div>
                            </div>
                            <%--<div style="position: relative">
                                <div style="position: absolute">
                                    <asp:Image ID="Image1" runat="server" ImageUrl="~/ad/assets/images/het-han.gif" Visible='<%# string.IsNullOrEmpty(Eval("IsDeadLine").ToString()) ? false : Eval("IsDeadLine")%>' />
                                    <asp:Image ID="Image2" runat="server" ImageUrl="~/ad/assets/images/sap-het-han.gif"
                                        Visible='<%# string.IsNullOrEmpty(Eval("BeginDeadLine").ToString()) ? false : (Convert.ToBoolean(Eval("IsDeadLine")) ? false : Eval("BeginDeadLine")) %>' />
                                </div>
                                <img id="Img1" alt="" src='<%# "~/res/advertisement/" + Eval("FileName") %>' style="max-width: 100px;
                                    max-height: 100px" runat="server" visible='<%# string.IsNullOrEmpty(Eval("FileName").ToString()) ? false : (!Eval("FileName").ToString().ToLower().EndsWith(".swf") ? true : false) %>' />
                                <span id="Span1" runat="server" visible='<%# Eval("FileName").ToString() == "" ? false : (Eval("FileName").ToString().ToLower().EndsWith(".swf") ? true : false) %>'>
                                    <object style="max-height: 100px" id="player" width="100px" name="player" classid="clsid:D27CDB6E-AE6D-11cf-96B8-444553540000">
                                        <param value='../../res/advertisement/<%# Eval("FileName") %>' name="movie">
                                        <param value="true" name="allowfullscreen">
                                        <param value="always" name="allowscriptaccess">
                                        <param value="opaque" name="wmode">
                                        <embed style="max-height: 100px" id="player2" width="100px" wmode="opaque" allowfullscreen="false"
                                            allowscriptaccess="always" src="../../res/advertisement/<%# Eval("FileName") %>"
                                            name="player2" type="application/x-shockwave-flash">
                                    </object>
                                </span>
                            </div>--%>
                        </ItemTemplate>
                    </asp:GridTemplateColumn>
                </Columns>
                <EditFormSettings EditFormType="Template">
                    <FormTemplate>
                        <asp:Panel ID="Panel1" runat="server" DefaultButton="lnkUpdate">
                            <h3 class="searchTitle">
                                Thông Tin Quảng Cáo</h3>
                            <table class="search">
                                <tr>
                                    <td class="left" valign="top">
                                        Banner file
                                    </td>
                                    <td>
                                        <asp:HiddenField ID="hdnAdsBannerID" runat="server" Value='<%# Eval("AdsBannerID") %>' />
                                        <asp:HiddenField ID="hdnFileName" runat="server" Value='<%# Eval("FileName") %>' />
                                        <asp:RadUpload ID="FileFileName" runat="server" ControlObjectsVisibility="None" Culture="vi-VN"
                                            Language="vi-VN" InputSize="69" AllowedFileExtensions=".jpg,.jpeg,.gif,.png,.swf"
                                            TargetFolder="~/res/Temp/" />
                                        <asp:CustomValidator ID="CustomValidator1" runat="server" ErrorMessage="Sai định dạng ảnh (*.jpg, *.jpeg, *.gif, *.png, *.swf)"
                                            ClientValidationFunction="validateRadUpload" Display="Dynamic"></asp:CustomValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="left">
                                        Vị trí
                                    </td>
                                    <td>
                                        <asp:RadComboBox Filter="Contains" ID="ddlCategory" runat="server" DataSourceID="ObjectDataSource2"
                                            DataTextField="AdsCategoryName" DataValueField="AdsCategoryID" Width="504px"
                                            OnDataBound="DropDownList_DataBound">
                                        </asp:RadComboBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="left" valign="top">
                                        Tên công ty
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtCompanyName" runat="server" Text='<%# Bind("CompanyName") %>'
                                            Width="500px"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="left" valign="top">
                                        Website
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtWebsite" runat="server" Text='<%# Bind("Website") %>' Width="500px"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="left">
                                        Từ ngày
                                    </td>
                                    <td>
                                        <asp:RadDatePicker ShowPopupOnFocus="True" ID="dpFromDate" runat="server" Culture="vi-VN"
                                            Calendar-CultureInfo="vi-VN" Width="508px">
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
                                        Đến ngày
                                    </td>
                                    <td>
                                        <asp:RadDatePicker ShowPopupOnFocus="True" ID="dpToDate" runat="server" Culture="vi-VN"
                                            Calendar-CultureInfo="vi-VN" Width="508px">
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
                                    <td class="left" colspan="2">
                                        <asp:CheckBox ID="chkIsAvailable" runat="server" CssClass="checkbox" Text=" Hiển thị"
                                            Checked='<%# (Container is GridEditFormInsertItem) ? true : (Eval("IsAvailable") == DBNull.Value ? false : Convert.ToBoolean(Eval("IsAvailable"))) %>' />
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
                                <asp:RadButton ID="btnCancel" runat="server" CommandName='Cancel' Text='Hủy'>
                                    <Icon PrimaryIconUrl="~/ad/assets/images/cancel.png" />
                                </asp:RadButton>
                            </div>
                        </asp:Panel>
                        <asp:RadInputManager ID="RadInputManager1" runat="server">
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
            <asp:TextBoxSetting EmptyMessage="Tên công ty ...">
                <TargetControls>
                    <asp:TargetInput ControlID="txtCompanyName" />
                </TargetControls>
            </asp:TextBoxSetting>
            <asp:TextBoxSetting EmptyMessage="Website ...">
                <TargetControls>
                    <asp:TargetInput ControlID="txtWebsite" />
                </TargetControls>
            </asp:TextBoxSetting>
            <asp:NumericTextBoxSetting AllowRounding="False" Culture="vi-VN" EmptyMessage="Thứ tự ..."
                Type="Number" DecimalDigits="0">
                <TargetControls>
                    <asp:TargetInput ControlID="txtPriority" />
                </TargetControls>
            </asp:NumericTextBoxSetting>
        </asp:RadInputManager>
    </asp:RadAjaxPanel>
    <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" DeleteMethod="AdsBannerDelete"
        SelectMethod="AdsBannerSelectAll" TypeName="TLLib.AdsBanner" UpdateMethod="AdsBannerUpdate">
        <DeleteParameters>
            <asp:Parameter Name="AdsBannerID" Type="String" />
        </DeleteParameters>
        <SelectParameters>
            <asp:Parameter Name="StartRowIndex" Type="String" />
            <asp:Parameter Name="EndRowIndex" Type="String" />
            <asp:ControlParameter ControlID="ddlSearchCategory" Name="AdsCategoryID" PropertyName="SelectedValue"
                Type="String" />
            <asp:ControlParameter ControlID="txtSearchCompanyName" Name="CompanyName" PropertyName="Text"
                Type="String" />
            <asp:ControlParameter ControlID="txtSearchWebsite" Name="Website" PropertyName="Text"
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
            <asp:Parameter Name="AdsBannerID" Type="String" />
            <asp:Parameter Name="FileName" Type="String" />
            <asp:Parameter Name="ConvertedAdsBannerName" Type="String" />
            <asp:Parameter Name="AdsCategoryID" Type="String" />
            <asp:Parameter Name="CompanyName" Type="String" />
            <asp:Parameter Name="Website" Type="String" />
            <asp:Parameter Name="FromDate" Type="String" />
            <asp:Parameter Name="ToDate" Type="String" />
            <asp:Parameter Name="Priority" Type="String" />
            <asp:Parameter Name="IsAvailable" Type="String" />
            <asp:Parameter Name="Ratio" Type="String" />
        </UpdateParameters>
    </asp:ObjectDataSource>
    <asp:ObjectDataSource ID="ObjectDataSource2" runat="server" SelectMethod="AdsCategorySelectAll"
        TypeName="TLLib.AdsCategory"></asp:ObjectDataSource>
    <asp:RadProgressManager ID="RadProgressManager1" runat="server" />
    <asp:RadProgressArea ID="ProgressArea1" runat="server" Culture="vi-VN" DisplayCancelButton="True"
        HeaderText="Đang tải" Skin="Office2007" Style="position: fixed; top: 50% !important;
        left: 50% !important; margin: -93px 0 0 -188px;" />
</asp:Content>
