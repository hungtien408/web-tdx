<%@ Page Title="" Language="C#" MasterPageFile="~/site.master" AutoEventWireup="true"
    CodeFile="RecoveryPassword.aspx.cs" Inherits="RecoveryPassword" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphBody" runat="Server">
    <div align="center" style="margin: 0; padding: 0">
        <asp:PasswordRecovery ID="PasswordRecovery1" runat="server" 
            onsendingmail="PasswordRecovery1_SendingMail">
            <QuestionTemplate>
                <table class="log_in" cellpadding="0" cellspacing="0" style="border-collapse: collapse;">
                    <tr>
                        <td>
                            <table cellpadding="5" cellspacing="5">
                                <tr>
                                    <td class="title_login" align="center" colspan="2">
                                        <b>Identity Confirmation</b>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left" colspan="2">
                                        Answer the following question to receive your password.
                                        <br />
                                        <br />
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left">
                                        User Name:
                                    </td>
                                    <td>
                                        <asp:Literal ID="UserName" runat="server"></asp:Literal>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left">
                                        Question:
                                    </td>
                                    <td>
                                        <asp:Literal ID="Question" runat="server"></asp:Literal>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left">
                                        <asp:Label ID="AnswerLabel" runat="server" AssociatedControlID="Answer">Answer:</asp:Label>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="Answer" Width="250" runat="server" CssClass="textbox"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="AnswerRequired" runat="server" ControlToValidate="Answer"
                                            ErrorMessage="Answer is required." ToolTip="Answer is required." ValidationGroup="PasswordRecovery1">*</asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="center" colspan="2" style="color: Red;">
                                        <asp:Literal ID="FailureText" runat="server" EnableViewState="False"></asp:Literal>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="right" colspan="2">
                                        <asp:Button ID="SubmitButton" runat="server" CommandName="Submit" Height="30" 
                                            Width="70" Text="Submit" ValidationGroup="PasswordRecovery1" 
                                            CssClass="button" />
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
            </QuestionTemplate>
            <SuccessTemplate>
                <table cellpadding="1" cellspacing="0" style="border-collapse:collapse;">
                    <tr>
                        <td>
                            <table cellpadding="0">
                                <tr>
                                    <td>
                                        Your password has been sent to you via email.</td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
            </SuccessTemplate>
            <UserNameTemplate>
                <table class="log_in" cellpadding="0" cellspacing="0" style="border-collapse: collapse;">
                    <tr>
                        <td>
                            <table cellpadding="5" cellspacing="5">
                                <tr>
                                    <td class="title" align="center" colspan="2">
                                        <b>Forgot Your Password?</b>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left" colspan="2">
                                        Enter your User Name to receive your password.
                                        <br />
                                        <br />
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left" style="width: 100px;">
                                        <asp:Label ID="UserNameLabel" runat="server" AssociatedControlID="UserName">User Name:</asp:Label>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="UserName" Width="250" runat="server" CssClass="textbox"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="UserNameRequired" runat="server" ControlToValidate="UserName"
                                            ErrorMessage="User Name is required." ToolTip="User Name is required." ValidationGroup="PasswordRecovery1">*</asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="center" colspan="2" style="color: Red;">
                                        <asp:Literal ID="FailureText" runat="server" EnableViewState="False"></asp:Literal>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="right" colspan="2">
                                        <asp:Button ID="SubmitButton" runat="server" Width="70" Height="30" CommandName="Submit"
                                            Text="Submit" ValidationGroup="PasswordRecovery1" CssClass="button" />
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
            </UserNameTemplate>
        </asp:PasswordRecovery>
    </div>
</asp:Content>
