<%@ Page Language="C#" AutoEventWireup="true" CodeFile="register.aspx.cs" Inherits="register" %>

<%@ Register TagPrefix="asp" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .validation_summary
        {
            margin: 5px 0px 0px 0px;
            padding: 8px;
            background: #FFFFCC;
            border: solid 2px red;
            color: #ff0000;
        }
        
        .validation_summary li
        {
            list-style: none;
        }
    </style>
    <script type="text/javascript">
        function copy() {
            $(".usn").val($(".email").val());
        };

        function openwindow(URL, width, height) {
            var left = (screen.width / 2) - (width / 2);
            var top = (screen.height / 2) - (height / 2);
            var childWindow = window.open(URL, "mywindow", "menubar=0,scrollbars=1,resizable=1,copyhistory=0,location=0,width=" + width + ",height=" + height + ",top=" + top + ",left=" + left);
            childWindow.focus();
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:ValidationSummary ID="ValidationSummary1" runat="server" CssClass="validation_summary" />
        <center>
            <br />
            <h4>
                Nếu bạn đã đăng ký tài khoản thành viên tại www.abc.com?<a style="color: red;" href="login.aspx">
                    hãy nhấn vào đây để đăng nhập </a>
            </h4>
        </center>
        <br />
        <asp:Panel ID="Panel1" DefaultButton="btnUpdate" runat="server">
            <div class="info-lienlac">
                <h2>
                    THÔNG TIN LIÊN LẠC
                </h2>
                <table cellpadding="0" cellspacing="0" style="font-family: Verdana; font-size: 12px;
                    margin-left: 100px" width="100%">
                    <tr>
                        <td style="height: 30px; width: 140px;">
                            Họ và tên:<span style="color: Red">*</span>
                        </td>
                        <td>
                            <asp:TextBox ID="txtFullName" runat="server" Width="300px"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="+ Hãy điền vào Họ và tên phải lớn hơn 5 ký tự"
                                Display="None" ControlToValidate="txtFullName"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td style="height: 30px;">
                            Địa chỉ liên lạc:<span style="color: Red">*</span>
                        </td>
                        <td>
                            <asp:TextBox ID="txtAddress" runat="server" Width="300px"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="+ Hãy điền vào địa chỉ liên lạc phải lớn hơn 10 ký tự"
                                Display="None" ControlToValidate="txtAddress"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td style="height: 30px;">
                            Điện thoại: <span style="color: Red">*</span>
                        </td>
                        <td>
                            <asp:TextBox ID="txtHomePhone" runat="server" Width="115px"></asp:TextBox>&nbsp;
                            Di động:
                            <asp:TextBox ID="txtCellPhone" runat="server" Width="116px"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="+ Hãy điền vào số điện thoại, chỉ nhập vào là số không dùng khoảng trắng, dấu chấm, dấu phẩy..."
                                Display="None" ControlToValidate="txtHomePhone"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td style="height: 30px;">
                            E-mail liên lạc:<span style="color: Red">*</span>
                        </td>
                        <td>
                            <asp:TextBox ID="txtEmail" runat="server" Width="300px" onkeyup="copy()" CssClass="email"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="+ Hãy điền vào email liên lạc"
                                Display="None" ControlToValidate="txtEmail"></asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="+ Địa chỉ Email sai"
                                ControlToValidate="txtEmail" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"
                                Display="None"></asp:RegularExpressionValidator>
                            <asp:CustomValidator ID="CustomValidator2" runat="server" ControlToValidate="txtEmail"
                                Display="None"></asp:CustomValidator>
                        </td>
                    </tr>
                </table>
            </div>
            <div class="info-taikhoan">
                <h2>
                    THÔNG TIN TÀI KHOẢN TRUY CẬP
                </h2>
                <table cellpadding="0" cellspacing="0" style="font-family: Verdana; font-size: 12px;
                    margin-left: 100px" width="100%">
                    <tr>
                        <td style="height: 30px; width: 140px;">
                            Tên truy cập:<span style="color: Red">*</span>
                        </td>
                        <td>
                            <asp:TextBox ID="txtUserName" runat="server" Width="300px" CssClass="usn"></asp:TextBox>
                            <br />
                            <span style="font-size: 10px;">Tên truy cập phải lớn hơn 5 và nhỏ hơn 50 ký tự </span>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="+ Hãy điền vào Tên truy cập, tên truy cập phải lớn hơn 5 ký tự"
                                Display="None" ControlToValidate="txtUserName"></asp:RequiredFieldValidator>
                            <asp:CustomValidator ID="CustomValidator1" runat="server" ControlToValidate="txtUserName"
                                Display="None"></asp:CustomValidator>
                            <br />
                            <br />
                        </td>
                    </tr>
                    <tr>
                        <td style="height: 30px;">
                            Mật khẩu:<span style="color: Red">*</span>
                        </td>
                        <td>
                            <asp:TextBox ID="txtPassWord" runat="server" Width="300px" TextMode="Password"></asp:TextBox>
                            <br />
                            <span style="font-size: 10px;">Mật khẩu truy cập phải lớn hơn 5 và nhỏ hơn 50 ký tự
                            </span>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ErrorMessage="+ Hãy điền vào mật khẩu truy cập, mật khẩu truy cập phải lớn hơn 5 ký tự"
                                Display="None" ControlToValidate="txtPassWord"></asp:RequiredFieldValidator>
                            <br />
                            <br />
                        </td>
                    </tr>
                    <tr>
                        <td style="height: 30px;">
                            Nhập lại mật khẩu: <span style="color: Red">*</span>
                        </td>
                        <td>
                            <asp:TextBox ID="txtConfirmPassWord" runat="server" Width="300px" TextMode="Password"></asp:TextBox>
                            <asp:CompareValidator ID="CompareValidator1" runat="server" ErrorMessage="+ Xác nhận mật khẩu sai"
                                ControlToCompare="txtPassWord" ControlToValidate="txtConfirmPassWord" Display="None"></asp:CompareValidator>
                            <br />
                            <span style="font-size: 10px;">Nhập lại mật khẩu như đã điền ở ô trên </span>
                            <br />
                            <br />
                        </td>
                    </tr>
                    <tr>
                        <td style="height: 30px;">
                            Mã an toàn: <span style="color: Red">*</span>
                        </td>
                        <td>
                        <asp:TextBox ID="txtVerifyCode" runat="server" CssClass="textbox" Width="300"></asp:TextBox>
                            <asp:RadCaptcha ID="RadCaptcha1" runat="server" ErrorMessage="* Mã an toàn không chính xác."
                                ValidatedTextBoxID="txtVerifyCode" Display="None" ValidationGroup="PasswordRecovery1">
                                <CaptchaImage Width="155" RenderImageOnly="True" />
                            </asp:RadCaptcha>
                        </td>
                    </tr>
                    <tr>
                        <td style="height: 30px;">
                        </td>
                        <td>
                            <input id="chkAgree" type="checkbox" checked="checked" onchange="if ($(this).attr('checked') == false) $('.btnAgree').attr('disabled', 'disabled'); else $('.btnAgree').removeAttr('disabled');" />
                            <span style="color: Red">*</span> <a href="javascript:openwindow('quy-dinh-su-dung.aspx',800,600);">
                                Tôi đồng ý với các quy định của www.abc.com </a>
                        </td>
                    </tr>
                    <tr>
                        <td style="height: 30px;">
                        </td>
                        <td>
                            <asp:Button ID="btnUpdate" runat="server" Text="Đăng kí thành viên" CssClass="btnAgree button"
                                OnClick="btnUpdate_Click" />
                        </td>
                    </tr>
                </table>
            </div>
        </asp:Panel>
    </div>
    </form>
</body>
</html>
