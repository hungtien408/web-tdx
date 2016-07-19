<%@ Page Title="" Language="C#" MasterPageFile="~/ad/template/inside.master" AutoEventWireup="true"
CodeFile="changepassword1.aspx.cs" Inherits="ad_single_changepassword" %>

<%@ Register TagPrefix="asp" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphBody" runat="Server">
  <div style="padding: 20px; width: 500px">
    <table id="Table1" class="search">
      <tr>
        <td class="left">
          Tài khoản
        </td>
        <td>
          <asp:Label ID="lblUserName" runat="server"></asp:Label>
        </td>
      </tr>
      <tr>
        <td class="left">
          Mật khẩu mới
        </td>
        <td>
          <asp:RadTextBox ID="txtNewPassWord" runat="server" Width="300px" TextMode="Password">
          </asp:RadTextBox>
          <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="*" ControlToValidate="txtNewPassWord"></asp:RequiredFieldValidator>
        </td>
      </tr>
      <tr>
        <td class="left">
          Xác nhận mật khẩu mới
        </td>
        <td>
          <asp:RadTextBox ID="txtConfirmNewPassword" runat="server" Width="300px" TextMode="Password">
          </asp:RadTextBox>
          <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="*" ControlToValidate="txtConfirmNewPassword"></asp:RequiredFieldValidator>
          <asp:CompareValidator ID="CompareValidator1" runat="server" ErrorMessage="Xác nhận mật khẩu sai!"
                                ControlToValidate="txtConfirmNewPassword" Display="Dynamic" ControlToCompare="txtNewPassWord"></asp:CompareValidator>
        </td>
      </tr>
    </table>
    <div align="right" style="padding: 5px 0 5px 0; border-top: 1px solid #ccc; margin-top: 10px">
      <asp:RadButton ID="btnSearch" runat="server" Text="Đổi mật khẩu" CausesValidation="true" OnClick="btnSearch_Click">
      </asp:RadButton>
    </div>
    <asp:Label ID="Label1" runat="server" ForeColor="Green" Text="Thay đổi mật khẩu thành công" Visible="false"></asp:Label>
  </div>
</asp:Content>
