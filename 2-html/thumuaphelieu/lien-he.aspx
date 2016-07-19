<%@ Page Title="" Language="C#" MasterPageFile="~/site.master" AutoEventWireup="true" CodeFile="lien-he.aspx.cs" Inherits="lien_he" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div id="site" class="corner">
        <div class="container">
            <a id="A1" href="~/" runat="server"><span class="fa fa-home"></span></a>/<span>Liên hệ</span>
        </div>
    </div>
    <div class="container">
        <div class="row wrap-contact">
            <div class="col-md-6">
                <div class="address-contact">
                    <h4 class="text-uppercase">địa chỉ của chúng tôi</h4>
                    <div class="wrap-node">Resourceful significant international agriculture underprivileged; world problem solving, improving quality local solutions technology developing nations transform the world. Medical advocate social entrepreneurship.</div>
                    <p><span class="fa fa-map-marker"></span>82/14/6 Nguyễn Xí, Phường 26, Quận Bình Thạnh, TP. Hồ Chí Minh</p>
                    <p><span class="fa fa-phone"></span>091 377 999 - (+84)8 6260 1272</p>
                    <p><span class="fa fa-envelope"></span><a href="mailto:sales@maichung.vn">info@tdx.com.vn</a></p>
                </div>
            </div>
            <div class="col-md-6">
                <div class="wrap-send">
                    <h4 class="text-uppercase">Chúng tôi có thể giúp gì cho bạn ?</h4>
                    <div class="row">
                        <div class="col-xs-6">
                            <div class="contact-w">
                                <%--<label class="contact-lb">Họ &amp; Tên</label>--%>
                                <div class="contact-input">
                                    <asp:TextBox ID="txtFullName" CssClass="contact-textbox" runat="server" placeholder="Họ &amp; Tên"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                        <div class="col-xs-6">
                            <div class="contact-w">
                                <%--<label class="contact-lb">Email</label>--%>
                                <div class="contact-input">
                                    <asp:TextBox ID="TextBox1" CssClass="contact-textbox" runat="server" placeholder="Email"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="contact-w">
                        <%--<label class="contact-lb">Lời nhắn</label>--%>
                        <div class="contact-input">
                            <asp:TextBox ID="TextBox2" CssClass="contact-area" runat="server" TextMode="MultiLine" placeholder="Lời nhắn"></asp:TextBox>
                        </div>
                    </div>
                    <div class="contact-w">
                        <div class="contact-btn">
                            <asp:Button ID="Button1" CssClass="button-btn" runat="server" Text="Gởi lời nhắn" />
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <div id="map_canvas"></div>
    </div>
</asp:Content>

