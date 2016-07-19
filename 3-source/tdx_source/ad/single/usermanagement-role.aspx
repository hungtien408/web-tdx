<%@ Page Title="" Language="C#" MasterPageFile="~/ad/template/adminRole.master" AutoEventWireup="true"
    CodeFile="usermanagement-role.aspx.cs" Inherits="ad_single_usermanagement" %>

<%@ Register TagPrefix="asp" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" runat="Server">
    <link href="../assets/styles/sreenshort.css" rel="stylesheet" type="text/css" />
    <script src="../assets/js/sreenshort.js" type="text/javascript"></script>
    <script type="text/javascript">
        var tableView = null;
        function RowDblClick(sender, eventArgs) {
            sender.get_masterTableView().editItem(eventArgs.get_itemIndexHierarchical());
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
    <script language="javascript" type="text/javascript">
        function pageLoad() {
            var label = $("label:contains('admin')");
            var checkboxadmin = label.prev();
            checkboxadmin.click(function () {
                if (checkboxadmin.is(':checked'))
                    $('[id$="chkRoles"]').attr("checked", "checked");
                else
                    $('[id$="chkRoles"]').removeAttr("checked");
            });
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphBody" runat="Server">
    <h3 class="mainTitle">
        <img alt="" src="../assets/images/user.png" class="vam" />
        Tài Khoản
    </h3>
    <br />
    <asp:RadAjaxPanel ID="RadAjaxPanel1" runat="server" ClientEvents-OnRequestStart="conditionalPostback">
        <asp:Panel ID="pnlSearch" DefaultButton="btnSearch" runat="server">
            <table class="search">
                <tr>
                    <td class="left">
                        Tài khoản
                    </td>
                    <td>
                        <asp:RadTextBox ID="txtSearchUserName" runat="server" Width="130px">
                        </asp:RadTextBox>
                    </td>
                    <td class="left">
                        Email
                    </td>
                    <td>
                        <asp:RadTextBox ID="txtSearchEmail" runat="server" Width="130px">
                        </asp:RadTextBox>
                    </td>
                    <td class="left">
                        Quyền
                    </td>
                    <td>
                        <asp:RadComboBox Filter="Contains" ID="ddlSearchRole" CssClass="dropdownlist" Width="134px"
                            runat="server" DataSourceID="ObjectDataSource2" OnDataBound="DropDownList_DataBound">
                        </asp:RadComboBox>
                    </td>
                    <td class="left">
                        Di động
                    </td>
                    <td>
                        <asp:RadTextBox ID="txtSearchCellPhone" runat="server" Width="130px">
                        </asp:RadTextBox>
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
            AllowAutomaticDeletes="True" ShowStatusBar="True" OnItemCommand="RadGrid1_ItemCommand"
            OnItemDataBound="RadGrid1_ItemDataBound" CssClass="grid" AllowPaging="True" AllowSorting="True"
            AllowAutomaticInserts="True" CellSpacing="0">
            <ClientSettings EnableRowHoverStyle="true">
                <Selecting AllowRowSelect="True" UseClientSelectColumnOnly="True" />
                <ClientEvents OnRowDblClick="RowDblClick" />
                <Selecting AllowRowSelect="True" UseClientSelectColumnOnly="True" />
                <ClientEvents OnRowDblClick="RowDblClick" />
                <Resizing AllowColumnResize="true" ClipCellContentOnResize="False" />
            </ClientSettings>
            <ExportSettings IgnorePaging="true" OpenInNewWindow="true" ExportOnlyData="true"
                Excel-Format="ExcelML" Pdf-AllowCopy="true">
                <Pdf AllowCopy="True" />
                <Excel Format="ExcelML" />
            </ExportSettings>
            <MasterTableView CommandItemDisplay="TopAndBottom" DataSourceID="ObjectDataSource1"
                InsertItemPageIndexAction="ShowItemOnCurrentPage" AllowMultiColumnSorting="True"
                DataKeyNames="UserID">
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
                            CssClass="item">
              <img class="vam" alt="" src="../assets/images/add.png" /> Thêm mới
                        </asp:LinkButton>|
                        <%--<asp:LinkButton ID="LinkButton3" runat="server" CommandName="PerformInsert" Visible='<%# RadGrid1.MasterTableView.IsItemInserted %>'><img class="vam" alt="" src="../assets/images/accept.png" /> Thêm</asp:LinkButton>&nbsp;&nbsp;
            <asp:LinkButton ID="btnCancel" runat="server" CommandName="CancelAll" Visible='<%# RadGrid1.EditIndexes.Count > 0 || RadGrid1.MasterTableView.IsItemInserted %>'><img class="vam" alt="" src="../assets/images/delete-icon.png" /> Hủy</asp:LinkButton>&nbsp;&nbsp;--%>
                        <asp:LinkButton ID="btnEditSelected" runat="server" CommandName="EditSelected" Visible='<%# RadGrid1.EditIndexes.Count == 0 %>'
                            CssClass="item">
              <img width="12px" class="vam" alt="" src="../assets/images/tools.png" /> Sửa
                        </asp:LinkButton>|
                        <%--<asp:LinkButton ID="btnUpdateEdited" runat="server" CommandName="UpdateEdited" Visible='<%# RadGrid1.EditIndexes.Count > 0 %>'><img class="vam" alt="" src="../assets/images/accept.png" /> Cập nhật</asp:LinkButton>&nbsp;&nbsp;--%>
                        <asp:LinkButton ID="LinkButton1" OnClientClick="javascript:return confirm('Xóa tất cả dòng đã chọn?')"
                            runat="server" CommandName="DeleteSelected" CssClass="item">
              <img class="vam" alt="" title="Xóa tất cả dòng được chọn" src="../assets/images/delete-icon.png" /> Xóa
                        </asp:LinkButton>|
                        <asp:LinkButton ID="LinkButton6" runat="server" CommandName="QuickUpdate" Visible='<%# RadGrid1.EditIndexes.Count == 0 %>'
                            CssClass="item">
              <img class="vam" alt="" src="../assets/images/accept.png" /> Sửa nhanh
                        </asp:LinkButton>|
                        <asp:LinkButton ID="LinkButton4" runat="server" CommandName="RebindGrid" CssClass="item">
              <img class="vam" alt="" src="../assets/images/reload.png" /> Làm mới
                        </asp:LinkButton>
                    </div>
                    <div class="clear">
                    </div>
                    <asp:PlaceHolder ID="PlaceHolder1" runat="server"></asp:PlaceHolder>
                </CommandItemTemplate>
                <CommandItemSettings ExportToPdfText="Export to Pdf" />
                <Columns>
                    <asp:GridClientSelectColumn FooterText="CheckBoxSelect footer" HeaderStyle-Width="1%"
                        UniqueName="CheckboxSelectColumn">
                        <HeaderStyle Width="1%" />
                    </asp:GridClientSelectColumn>
                    <asp:GridTemplateColumn HeaderStyle-Width="1%" HeaderText="STT">
                        <ItemTemplate>
                            <%# Container.DataSetIndex + 1 %>
                            <asp:HiddenField ID="hdnAvatarImage" runat="server" Value='<%# Eval("ImageName") %>' />
                        </ItemTemplate>
                        <HeaderStyle Width="1%" />
                    </asp:GridTemplateColumn>
                    <asp:GridBoundColumn DataField="UserName" HeaderText="Tài khoản" SortExpression="UserName" />
                    <asp:GridBoundColumn DataField="Email" HeaderText="Email" SortExpression="Email" />
                    <asp:GridBoundColumn DataField="Company" HeaderText="Tên Phòng Ban" SortExpression="Company" />
                    <asp:GridBoundColumn DataField="FirstName" HeaderText="Họ tên" SortExpression="FirstName" />
                    <asp:GridBoundColumn DataField="Address1" HeaderText="Địa chỉ" SortExpression="Address1" />
                    <asp:GridTemplateColumn HeaderText="Online" SortExpression="IsOnline">
                        <ItemTemplate>
                            <asp:Image ID="imgIsOnline" runat="server" ImageUrl='<%# string.IsNullOrEmpty(Eval("UserName").ToString()) ? "" : (Membership.GetUser(Eval("UserName").ToString()).IsOnline == true ? "../assets/images/online.jpg" : "../assets/images/not_online.jpg") %>' />
                        </ItemTemplate>
                    </asp:GridTemplateColumn>
                    <asp:GridTemplateColumn DataField="LastLoginDate" HeaderText="Lần đăng nhập cuối"
                        SortExpression="LastLoginDate">
                        <ItemTemplate>
                            <%# string.Format("{0:dd/MM/yyyy hh:mm tt}", Eval("LastLoginDate"))%>
                        </ItemTemplate>
                    </asp:GridTemplateColumn>
                    <asp:GridTemplateColumn DataField="CreateDate" HeaderText="Ngày tạo" SortExpression="CreateDate">
                        <ItemTemplate>
                            <%# string.Format("{0:dd/MM/yyyy hh:mm tt}", Eval("CreateDate"))%>
                        </ItemTemplate>
                    </asp:GridTemplateColumn>
                    <asp:GridTemplateColumn  HeaderText="Ảnh">
                        <ItemTemplate>
                            <asp:Panel ID="Panel1" runat="server" Visible='<%# string.IsNullOrEmpty( Eval("ImageName").ToString()) ? false : true %>'>
                                <img id="Img1" alt="" src='<%# "~/res/userprofile/" + Eval("ImageName") %>' width="80" runat="server"
                                    visible='<%# string.IsNullOrEmpty(Eval("ImageName").ToString()) ? false : true %>' />
                            </asp:Panel>
                        </ItemTemplate>
                    </asp:GridTemplateColumn>
                    <asp:GridTemplateColumn>
                        <ItemTemplate>
                            <a onclick="openWindow('changepassword1.aspx?usn=<%# Eval("UserName") %>','Đổi mật khẩu')"
                                style="cursor: pointer">Đổi mật khẩu </a>
                        </ItemTemplate>
                    </asp:GridTemplateColumn>
                </Columns>
                <EditFormSettings EditFormType="Template">
                    <FormTemplate>
                        <asp:Panel ID="Panel1" runat="server" DefaultButton="lnkUpdate">
                            <h3 class="searchTitle">
                                Thông Tin Tài Khoản
                            </h3>
                            <asp:HiddenField ID="hdnUserID" runat="server" Value='<%# Bind("UserID") %>' />
                            <asp:HiddenField ID="hdnAddressBookID" runat="server" Value='<%# Bind("AddressBookID") %>' />
                            <table runat="server" class="search" visible="<%# (Container is GridEditFormInsertItem) ? true : false %>">
                                <tr>
                                    <td class="left" valign="top">
                                        Tên đăng nhập
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtUserName" runat="server" AutoPostBack="True" OnTextChanged="txtUserName_TextChanged"
                                            Width="500px"></asp:TextBox>
                                        <asp:CustomValidator ID="CustomValidator1" ValidationGroup="AddNewUser" runat="server"
                                            ControlToValidate="txtUserName" Display="Dynamic" ErrorMessage="Tài khoản đã tồn tại!"></asp:CustomValidator>
                                        <asp:Label ID="lblUserNameMessage" runat="server" ForeColor="Green"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="left" valign="top">
                                        Email
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtEmail" runat="server" AutoPostBack="True" OnTextChanged="txtEmail_TextChanged"
                                            Width="500px"></asp:TextBox>
                                        <asp:Label ID="lblEmailMessage" runat="server" ForeColor="Green"></asp:Label>
                                        <asp:CustomValidator ID="CustomValidator2" ValidationGroup="AddNewUser" runat="server"
                                            ControlToValidate="txtEmail" Display="Dynamic"></asp:CustomValidator>
                                        <asp:RegularExpressionValidator ValidationGroup="AddNewUser" ID="RegularExpressionValidator1"
                                            runat="server" ControlToValidate="txtEmail" Display="Dynamic" ErrorMessage="Sai định dạng email."
                                            ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="left">
                                        Mật khẩu
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtPassword" runat="server" TextMode="Password" Width="500px"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="left">
                                        Xác nhận mật khẩu
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtConfirmPassword" runat="server" TextMode="Password" Width="500px"></asp:TextBox>
                                        <asp:CompareValidator ID="CompareValidator2" ValidationGroup="AddNewUser" runat="server"
                                            ControlToCompare="txtPassword" ControlToValidate="txtConfirmPassword" Display="Dynamic"
                                            ErrorMessage="Xác nhận mật khẩu sai."></asp:CompareValidator>
                                    </td>
                                </tr>
                                <%-- <tr>
                                    <td class="left">Quyền
                                    </td>
                                    <td>
                                         <asp:RadComboBox ID="ddlRole" runat="server" DataSourceID="ObjectDataSource2" Filter="Contains"
                                            OnDataBound="DropDownList_DataBound" Width="504px">
                                        </asp:RadComboBox>
                                    </td>
                                </tr>--%>
                            </table>
                            <table class="search">
                                <asp:HiddenField ID="hdnUserName" runat="server" Value='<%# Bind("UserName") %>' />
                                <asp:HiddenField ID="hdnEmail" runat="server" Value='<%# Bind("Email") %>' />
                                <tr>
                                    <td class="left" valign="top">
                                        Tên Phòng Ban
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtCompanyName" runat="server" Text='<%# Bind("Company") %>'
                                            Width="500px"></asp:TextBox>
                                    </td>
                                    <td rowspan="7" valign="top">
                                        <%-- <asp:RadBinaryImage ID="RadBinaryImage1" runat="server" ImageUrl='<%# "~/res/userprofile/" + Eval("AvatarImage") %>'
                                            ResizeMode="Fit" Style="display: block;" />--%>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="left" valign="top">
                                        Họ tên
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtFullName" runat="server" Text='<%# Bind("FirstName") %>' Width="500px"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="left" valign="top">
                                        Địa chỉ
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtAddress" runat="server" Text='<%# Bind("Address1") %>' Width="500px"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr class="invisible">
                                    <td class="left" valign="top">
                                        Điện thoại
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtHomePhone" runat="server" Text='<%# Bind("HomePhone") %>' Width="500px"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="left" valign="top">
                                        Di động
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtCellPhone" runat="server" Text='<%# Bind("HomePhone") %>' Width="500px"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="left">
                                        Quyền
                                    </td>
                                    <td>
                                        <asp:ListView ID="lvListViewRoles" runat="server" DataSourceID="ObjectDataSource2"
                                            GroupItemCount="6" EnableModelValidation="True">
                                            <GroupTemplate>
                                                <tr id="itemPlaceholderContainer" runat="server">
                                                    <td id="itemPlaceholder" runat="server">
                                                    </td>
                                                </tr>
                                            </GroupTemplate>
                                            <ItemTemplate>
                                                <td valign="top" align="left">
                                                    <asp:CheckBox ID="chkRoles" runat="server" Text='<%# Container.DataItem%>' />
                                                </td>
                                            </ItemTemplate>
                                            <LayoutTemplate>
                                                <table>
                                                    <tr id="groupPlaceholderContainer" runat="server">
                                                        <td id="groupPlaceholder" runat="server">
                                                        </td>
                                                    </tr>
                                                </table>
                                            </LayoutTemplate>
                                        </asp:ListView>
                                    </td>
                                </tr>
                                <tr class="invisible">
                                    <td class="left" valign="top">
                                        Fax
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtFax" runat="server" Text='<%# Bind("Fax") %>' Width="500px"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr class="invisible">
                                    <td class="left" valign="top">
                                        Ảnh đại diện
                                        <asp:HiddenField ID="hdnOldImageName" runat="server" Value='<%# Eval("ImageName") %>' />
                                    </td>
                                    <td>
                                        <asp:RadUpload ID="FileAvatarImage" runat="server" AllowedFileExtensions=".jpg,.jpeg,.gif"
                                            ControlObjectsVisibility="None" Culture="vi-VN" InputSize="69" Language="vi-VN" />
                                        <asp:CustomValidator ID="CustomValidator3" runat="server" ClientValidationFunction="validateRadUpload"
                                            Display="Dynamic" ErrorMessage="Sai định dạng ảnh (*.jpg, *.jpeg, *.gif)"></asp:CustomValidator>
                                    </td>
                                </tr>
                            </table>
                            <div class="edit">
                                <hr />
                                <asp:RadButton ID="lnkUpdate" ValidationGroup="AddNewUser" runat="server" CommandName='<%# (Container is GridEditFormInsertItem) ? "PerformInsert" : "Update" %>'
                                    Text='<%# (Container is GridEditFormInsertItem) ? "Thêm" : "Cập nhật" %>'>
                                    <Icon PrimaryIconUrl="~/ad/assets/images/ok.png" />
                                </asp:RadButton>
                                &nbsp;&nbsp;
                                <asp:RadButton ID="btnCancel" runat="server" CommandName='Cancel' ValidationGroup="Cancel"
                                    Text='Hủy'>
                                    <Icon PrimaryIconUrl="~/ad/assets/images/cancel.png" />
                                </asp:RadButton>
                            </div>
                        </asp:Panel>
                    </FormTemplate>
                </EditFormSettings>
            </MasterTableView>
            <HeaderStyle Font-Bold="True" />
            <HeaderContextMenu EnableImageSprites="True" CssClass="GridContextMenu GridContextMenu_Default">
            </HeaderContextMenu>
        </asp:RadGrid>
        <asp:RadInputManager ID="RadInputManager1" runat="server">
            <asp:TextBoxSetting EmptyMessage="Tên đăng nhập ..." Validation-IsRequired="True">
                <TargetControls>
                    <asp:TargetInput ControlID="txtUserName" />
                </TargetControls>
            </asp:TextBoxSetting>
            <asp:TextBoxSetting EmptyMessage="Email ..." Validation-IsRequired="True">
                <TargetControls>
                    <asp:TargetInput ControlID="txtEmail" />
                </TargetControls>
            </asp:TextBoxSetting>
            <asp:TextBoxSetting EmptyMessage="Mật khẩu ..." Validation-IsRequired="True">
                <TargetControls>
                    <asp:TargetInput ControlID="txtPassword" />
                </TargetControls>
            </asp:TextBoxSetting>
            <asp:TextBoxSetting EmptyMessage="Xác nhận mật khẩu ..." Validation-IsRequired="True">
                <TargetControls>
                    <asp:TargetInput ControlID="txtConfirmPassword" />
                </TargetControls>
            </asp:TextBoxSetting>
            <asp:TextBoxSetting EmptyMessage="Tên phòng ban ...">
                <TargetControls>
                    <asp:TargetInput ControlID="txtCompanyName" />
                </TargetControls>
            </asp:TextBoxSetting>
            <asp:TextBoxSetting EmptyMessage="Họ tên ...">
                <TargetControls>
                    <asp:TargetInput ControlID="txtFullName" />
                </TargetControls>
            </asp:TextBoxSetting>
            <asp:TextBoxSetting EmptyMessage="Địa chỉ ...">
                <TargetControls>
                    <asp:TargetInput ControlID="txtAddress" />
                </TargetControls>
            </asp:TextBoxSetting>
            <asp:TextBoxSetting EmptyMessage="Điện thoại ...">
                <TargetControls>
                    <asp:TargetInput ControlID="txtHomePhone" />
                </TargetControls>
            </asp:TextBoxSetting>
            <asp:TextBoxSetting EmptyMessage="Di động ...">
                <TargetControls>
                    <asp:TargetInput ControlID="txtCellPhone" />
                </TargetControls>
            </asp:TextBoxSetting>
            <asp:TextBoxSetting EmptyMessage="Fax ...">
                <TargetControls>
                    <asp:TargetInput ControlID="txtFax" />
                </TargetControls>
            </asp:TextBoxSetting>
        </asp:RadInputManager>
    </asp:RadAjaxPanel>
    <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" SelectMethod="UserProfileSelectAll_AddressBook"
        TypeName="TLLib.AddressBook">
        <SelectParameters>
            <asp:ControlParameter ControlID="txtSearchUserName" Name="UserName" PropertyName="Text"
                Type="String" />
            <asp:ControlParameter ControlID="txtSearchEmail" Name="Email" PropertyName="Text"
                Type="String" />
            <asp:Parameter Name="RoleName" Type="String" />
            <asp:Parameter Name="Company" Type="String" />
            <asp:Parameter Name="FirstName" Type="String" />
            <asp:Parameter Name="LastName" Type="String" />
            <asp:Parameter Name="Address1" Type="String" />
            <asp:Parameter Name="Address2" Type="String" />
            <asp:Parameter Name="HomePhone" Type="String" />
            <asp:ControlParameter ControlID="txtSearchCellPhone" Name="CellPhone" PropertyName="Text"
                Type="String" />
            <asp:Parameter Name="Fax" Type="String" />
            <asp:Parameter Name="CountryID" Type="String" />
            <asp:Parameter Name="ProvinceID" Type="String" />
            <asp:Parameter Name="DistrictID" Type="String" />
            <asp:Parameter Name="IsPrimary" Type="String" />
            <asp:Parameter Name="IsPrimaryBilling" Type="String" />
            <asp:Parameter Name="IsPrimaryShipping" Type="String" />
        </SelectParameters>
    </asp:ObjectDataSource>
    <asp:ObjectDataSource ID="ObjectDataSource2" runat="server" SelectMethod="RoleSelectAll"
        TypeName="TLLib.User"></asp:ObjectDataSource>
    <asp:RadProgressManager ID="RadProgressManager1" runat="server" />
    <asp:RadProgressArea ID="ProgressArea1" runat="server" Culture="vi-VN" DisplayCancelButton="True"
        HeaderText="Đang tải" Skin="Office2007" Style="position: fixed; top: 50% !important;
        left: 50% !important; margin: -93px 0 0 -188px;" />
</asp:Content>
