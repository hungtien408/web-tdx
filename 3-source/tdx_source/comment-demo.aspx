<%@ Page Language="C#" AutoEventWireup="true" CodeFile="comment-demo.aspx.cs" Inherits="Default2" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>test</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:TextBox ID="TextBox1" runat="server" TextMode ="MultiLine" Height="100"></asp:TextBox>
        <br />
        <asp:Button ID="Button1" runat="server" Text="Button" onclick="Button1_Click" />
        <asp:GridView ID="GridView1" runat="server" DataSourceID="ObjectDataSource1" 
            EnableModelValidation="True">
        </asp:GridView>
        <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" 
            SelectMethod="CommentSelectAll" TypeName="TLLib.Comment">
            <SelectParameters>
                <asp:Parameter Name="CommentID" Type="String" />
                <asp:Parameter Name="UserName" Type="String" />
                <asp:Parameter Name="Keyword" Type="String" />
                <asp:Parameter Name="Link" Type="String" />
                <asp:Parameter Name="Title" Type="String" />
                <asp:Parameter Name="Content" Type="String" />
                <asp:Parameter Name="CreateDate" Type="String" />
                <asp:Parameter Name="UpdateDate" Type="String" />
                <asp:Parameter Name="FromDate" Type="String" />
                <asp:Parameter Name="ToDate" Type="String" />
                <asp:Parameter Name="Priority" Type="String" />
                <asp:Parameter DefaultValue="True" Name="IsApproved" Type="String" />
                <asp:Parameter DefaultValue="True" Name="IsAvailable" Type="String" />
            </SelectParameters>
        </asp:ObjectDataSource>
    </div>
    </form>
</body>
</html>
