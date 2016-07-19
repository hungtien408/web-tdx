<%@ Page Title="" Language="C#" MasterPageFile="~/site-sub.master" AutoEventWireup="true"
    CodeFile="tin-tuc-chi-tiet.aspx.cs" Inherits="tin_tuc_chi_tiet" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphSite" runat="Server">
    <a href="tin-tuc.aspx">Tin tức</a>/<span><asp:Label ID="lblTitle" runat="server"></asp:Label></span>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:ListView ID="lstNewDetails" runat="server" DataSourceID="odsNewDetails" EnableModelValidation="True">
        <ItemTemplate>
            <div class="wrapper-text about-us">
                <h4 class="text-uppercase title mo-640">
                    <%# Eval("ArticleTitle")%></h4>
                <div class="about-img">
                    <img class="img-responsive" src="assets/images/about-img.jpg" alt="" /></div>
                <h4 class="text-uppercase title tit-640">
                    <%# Eval("ArticleTitle")%></h4>
                <asp:Label ID="Label1" runat="server" Text='<%# Eval("Content") %>'></asp:Label>
            </div>
        </ItemTemplate>
        <LayoutTemplate>
            <span runat="server" id="itemPlaceholder" />
        </LayoutTemplate>
    </asp:ListView>
    <asp:ObjectDataSource ID="odsNewDetails" runat="server" SelectMethod="ArticleSelectOne"
        TypeName="TLLib.Article">
        <SelectParameters>
            <asp:QueryStringParameter Name="ArticleID" QueryStringField="tt" Type="String" />
        </SelectParameters>
    </asp:ObjectDataSource>
</asp:Content>
