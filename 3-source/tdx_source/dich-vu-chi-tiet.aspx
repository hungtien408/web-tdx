<%@ Page Title="" Language="C#" MasterPageFile="~/site-sub.master" AutoEventWireup="true" CodeFile="dich-vu-chi-tiet.aspx.cs" Inherits="dich_vu_chi_tiet" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphSite" Runat="Server">
    <a href="dich-vu.aspx">Dịch vụ</a>/<span><asp:Label ID="lblTitle" runat="server"></asp:Label></span>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
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
            <asp:QueryStringParameter Name="ArticleID" QueryStringField="dv" Type="String" />
        </SelectParameters>
    </asp:ObjectDataSource>
</asp:Content>

