<%@ Page Title="" Language="C#" MasterPageFile="~/ad/template/inside.master" AutoEventWireup="true"
    CodeFile="changepassword.aspx.cs" Inherits="ad_single_productphotoalbum" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" runat="Server">
    <style type="text/css">
        .myClass:hover
        {
            background-color: #a1da29 !important;
        }
        .txt
        {
            border: 0px !important;
            background: #eeeeee !important;
            color: Black !important;
            margin-left: 25%;
            margin-right: auto;
            width: 100%;
            filter: alpha(opacity=50); /* IE's opacity*/
            opacity: 0.50;
            text-align: center;
            display: block;
        }
    </style>
    <script type="text/javascript">
        // <![CDATA[
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

        function containerMouseover(sender) {
            sender.getElementsByTagName("div")[0].style.display = "";
        }
        function containerMouseout(sender) {
            sender.getElementsByTagName("div")[0].style.display = "none";
        }
            // ]]>
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphBody" runat="Server">
    <fieldset>
        <h3 class="searchTitle">
            Change Password</h3>
        <asp:ChangePassword ID="ChangePassword1" runat="server" OnContinueButtonClick="ChangePassword1_ContinueButtonClick">
            <ChangePasswordTemplate>
                <div class="accountInfo" align="center">
                    <table class="search" width="100%" cellpadding="1" cellspacing="0" style="border-collapse: collapse;">
                        <tr>
                            <td align="left" class="left">
                                <asp:Label ID="CurrentPasswordLabel" runat="server" AssociatedControlID="CurrentPassword">Password:</asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="CurrentPassword" runat="server" TextMode="Password" Width="250"
                                    CssClass="textbox"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="CurrentPasswordRequired" runat="server" ControlToValidate="CurrentPassword"
                                    ErrorMessage="Password is required." ToolTip="Password is required." ValidationGroup="ChangePassword1">*</asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td align="left" class="left">
                                <asp:Label ID="NewPasswordLabel" runat="server" AssociatedControlID="NewPassword">New Password:</asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="NewPassword" runat="server" TextMode="Password" Width="250" CssClass="textbox"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="NewPasswordRequired" runat="server" ControlToValidate="NewPassword"
                                    ErrorMessage="New Password is required." ToolTip="New Password is required."
                                    ValidationGroup="ChangePassword1">*</asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td align="left" class="left">
                                <asp:Label ID="ConfirmNewPasswordLabel" runat="server" AssociatedControlID="ConfirmNewPassword">Confirm New Password:</asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="ConfirmNewPassword" runat="server" TextMode="Password" Width="250"
                                    CssClass="textbox"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="ConfirmNewPasswordRequired" runat="server" ControlToValidate="ConfirmNewPassword"
                                    ErrorMessage="Confirm New Password is required." ToolTip="Confirm New Password is required."
                                    ValidationGroup="ChangePassword1">*</asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td align="center" colspan="2">
                                <asp:CompareValidator ID="NewPasswordCompare" runat="server" ControlToCompare="NewPassword"
                                    ControlToValidate="ConfirmNewPassword" Display="Dynamic" ErrorMessage="The Confirm New Password must match the New Password entry."
                                    ValidationGroup="ChangePassword1"></asp:CompareValidator>
                            </td>
                        </tr>
                        <tr>
                            <td align="center" colspan="2" style="color: Red;">
                                <asp:Literal ID="FailureText" runat="server" EnableViewState="False"></asp:Literal>
                            </td>
                        </tr>
                        <tr>
                            <td align="left">
                                <br />
                                <asp:Button ID="ChangePasswordPushButton" runat="server" CommandName="ChangePassword"
                                    Text="Change Password" ValidationGroup="ChangePassword1" CssClass="button" />
                            </td>
                            <%--<td align="right">
                                <br />
                                <asp:Button ID="CancelPushButton" runat="server" CausesValidation="False" CommandName="Cancel"
                                    Text="Cancel" CssClass="button" />
                            </td>--%>
                        </tr>
                    </table>
                </div>
            </ChangePasswordTemplate>
            <SuccessTemplate>
                <div class="accountInfo">
                    <table cellpadding="2" width="100%" cellspacing="2" style="border-collapse: collapse;">
                        <tr>
                            <td>
                                <table cellpadding="0">
                                    <tr>
                                        <td>
                                            Your password has been successfully changed.
                                        </td>
                                    </tr>
                                    <%--<tr>
                                        <td align="right">
                                            <br />
                                            <asp:Button ID="ContinuePushButton" runat="server" CausesValidation="False" CommandName="Continue"
                                                Text="Continue" CssClass="button" />
                                        </td>
                                    </tr>--%>
                                </table>
                            </td>
                        </tr>
                    </table>
                </div>
            </SuccessTemplate>
        </asp:ChangePassword>
    </fieldset>
    <br />
    <asp:RadProgressManager ID="RadProgressManager1" runat="server" />
    <asp:RadProgressArea ID="ProgressArea1" runat="server" Culture="vi-VN" DisplayCancelButton="True"
        HeaderText="Đang tải" Skin="Office2007" Style="position: fixed; top: 50% !important;
        left: 50% !important; margin: -93px 0 0 -188px;" />
</asp:Content>
