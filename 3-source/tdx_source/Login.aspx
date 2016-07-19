<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="createusers" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link href="assets/styles/login.css" rel="stylesheet" type="text/css" />
    <title>Log In</title>
</head>
<body>
    <form id="form1" runat="server">
    <div id="formLogin">
        <h1>Log In</h1>
        <div class="wrap-login">
            <asp:Login ID="Login1" runat="server" OnLoggedIn="Login1_LoggedIn">
                <LayoutTemplate>
                    <asp:Panel ID="Panel1" runat="server" DefaultButton="LoginButton">
                        <table class="tb-login" cellpadding="0" cellspacing="0">
                            <tr>
                                <td>
                                    <table cellpadding="0" cellspacing="5">
                                        <tr>
                                            <td class="login-col-1">
                                                <asp:Label ID="UserNameLabel" CssClass="login-lb" runat="server" AssociatedControlID="UserName">User Name:</asp:Label>
                                            </td>
                                            <td class="login-col-2">
                                                <asp:TextBox ID="UserName" CssClass="login-text" runat="server"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="UserNameRequired" CssClass="login-error" runat="server" ControlToValidate="UserName"
                                                    ErrorMessage="User Name is required." ToolTip="User Name is required." ValidationGroup="Login1">*</asp:RequiredFieldValidator>
                                                    
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="login-col-1">
                                                <asp:Label ID="PasswordLabel" CssClass="login-lb" runat="server" AssociatedControlID="Password">Password:</asp:Label>
                                            </td>
                                            <td class="login-col-2">
                                                <asp:TextBox ID="Password" CssClass="login-text" runat="server" TextMode="Password"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="PasswordRequired" CssClass="login-error" runat="server" ControlToValidate="Password"
                                                    ErrorMessage="Password is required." ToolTip="Password is required." ValidationGroup="Login1">*</asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="login-col-1">
                                            </td>
                                            <td class="login-col-2">
                                                <asp:CheckBox ID="RememberMe" CssClass="login-check" runat="server" Text="Remember me next time." />
                                            </td>
                                        </tr>
                                       <%-- <tr>
                                            <td colspan="2">
                                                <asp:Literal ID="FailureText" runat="server" EnableViewState="False"></asp:Literal>
                                            </td>
                                        </tr>--%>
                                        <tr>
                                            <td class="login-col-1">
                                            </td>
                                            <td class="login-col-2 login-btn">
                                                <asp:Button ID="LoginButton" runat="server" CommandName="Login" Text="Log In" ValidationGroup="Login1" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="login-col-1">
                                            </td>
                                            <td class="login-col-2 forgot-link">
                                                <a href="recovery-password.aspx">Forgot Your Password?</a>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                        </table>
                    </asp:Panel>
                </LayoutTemplate>
            </asp:Login>
        </div>
        <div class="clr">
        </div>
    </div>
    </form>
</body>
</html>
