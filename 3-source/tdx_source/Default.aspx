<%@ Page Title="" Language="C#" MasterPageFile="~/site.master" AutoEventWireup="true"
    CodeFile="Default.aspx.cs" Inherits="_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <title>TDX</title>
    <meta name="description" content="TDX" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="container">
        <section id="thu-mua" class="row">
            <h3 class="title-name cl-orange">Thu mua phế liệu GIÁ CAO TẬN NƠI</h3>
            <div class="row">
                <div class="content-left col-md-6">
                    <asp:ListView ID="lstCategoryPheLieu" runat="server" DataSourceID="odsCategoryPheLieu"
                    EnableModelValidation="True">
                        <ItemTemplate>
                            <asp:Label ID="Label1" runat="server" Text='<%# Eval("Content") %>'></asp:Label>
                        </ItemTemplate>
                        <EmptyDataTemplate>
                            <p><span>Thu mua phế liệu Trái Đất Xanh</span> là cơ sở thu mua phế liệu hoạt động lâu đời trên toàn quốc, với uy tín cao, chúng tôi luôn đáp ứng mọi nhu cầu của khách hàng tận nơi, 24/24h.</p>
                            <p>Chuyên thu mua phế liệu <span>Sắt, Thép, Đồng, Nhôm, Chì, Kẽm, Giấy, Nhựa, Vải</span>…tại TP Hồ Chí Minh, Bình Phước, Bình Dương, Vĩnh Long, Đồng Nai, Long An, các tỉnh lân cận TP Hồ Chí Minh.</p>
                            <h3>dịch vụ</h3>
                            <ul>
                              <li>Nhận tháo dỡ kho xưởng, thu mua xác nhà uy tín nhanh gọn lẹ.</li>
                              <li>Có xe tải riêng để chuyên chở</li>
                              <li>Hỗ trợ dọn dẹp sau mua bán</li>
                              <li>Mua sắt thép công trình số lượng lớn.
                              <br />
                              Mua giá hợp lý, không ép giá.</li>
                              <li class="special-text">Có hoa hồng cho người giới thiệu</li>
                              <li>Cam kết khách hàng sẽ nhận được mức giá tốt nhất - phương thức thanh toán nhanh gọn cùng với sự phục vụ chu đáo nhiệt tình nhất</li>
                            </ul>   
                        </EmptyDataTemplate>
                        <LayoutTemplate>
                        <span runat="server" id="itemPlaceholder" />
                        </LayoutTemplate>   
                    </asp:ListView>
                    <asp:ObjectDataSource ID="odsCategoryPheLieu" runat="server" 
                        SelectMethod="ArticleCategorySelectOne" TypeName="TLLib.ArticleCategory">
                        <SelectParameters>
                            <asp:Parameter DefaultValue="4" Name="ArticleCategoryID" Type="String" />
                        </SelectParameters>
                    </asp:ObjectDataSource>
                </div>
                <div class="content-right col-md-6">
                    <div class="slider two-rows-slide">
                        <asp:ListView ID="lstDVPheLieu" runat="server" DataSourceID="odsDVPheLieu" EnableModelValidation="True">
                            <ItemTemplate>
                                <div class="items">
                                    <a href='<%# progressTitle(Eval("ArticleTitle")) + "-dv-" + Eval("ArticleID") + ".aspx" %>'>
                                       <img alt='<%# Eval("ArticleTitle") %>' src='<%# !string.IsNullOrEmpty(Eval("ImageName").ToString()) ? "~/res/article/" + Eval("ImageName") : "~/assets/images/tm1.png" %>'
                                        runat="server" />
                                       <p><%# Eval("ArticleTitle")%></p>
                                     </a>
                                 </div>
                            </ItemTemplate>
                            <LayoutTemplate>
                            <span runat="server" id="itemPlaceholder" />
                            </LayoutTemplate>   
                         </asp:ListView>
                         <asp:ObjectDataSource ID="odsDVPheLieu" runat="server" 
                            SelectMethod="ArticleSelectAll" TypeName="TLLib.Article">
                             <SelectParameters>
                                 <asp:Parameter Name="StartRowIndex" Type="String" />
                                 <asp:Parameter Name="EndRowIndex" Type="String" />
                                 <asp:Parameter Name="Keyword" Type="String" />
                                 <asp:Parameter Name="ArticleTitle" Type="String" />
                                 <asp:Parameter Name="Description" Type="String" />
                                 <asp:Parameter DefaultValue="4" Name="ArticleCategoryID" Type="String" />
                                 <asp:Parameter Name="Tag" Type="String" />
                                 <asp:Parameter DefaultValue="True" Name="IsShowOnHomePage" Type="String" />
                                 <asp:Parameter Name="IsHot" Type="String" />
                                 <asp:Parameter Name="IsNew" Type="String" />
                                 <asp:Parameter Name="FromDate" Type="String" />
                                 <asp:Parameter Name="ToDate" Type="String" />
                                 <asp:Parameter DefaultValue="True" Name="IsAvailable" Type="String" />
                                 <asp:Parameter Name="Priority" Type="String" />
                                 <asp:Parameter DefaultValue="True" Name="SortByPriority" Type="String" />
                             </SelectParameters>
                        </asp:ObjectDataSource> 
                    </div>
                    <div class="clr"></div>
                    <div class="img-special">
                        <img src="assets/images/h6.jpg" alt="" />
                    </div>
                </div>
                <div class="clr"></div>
                <div class="col-md-12">
                    <div class="lienhe">
                        <div class="slider lh-slide">
                            <div>
                                <img src="assets/images/slide.png" alt="" />
                                <div class="slide-info">
                                    <p>thu mua</p>
                                    <h3>phế liệu sắt</h3>
                                </div>
                            </div>
                            <div>
                                <img src="assets/images/slide.png" alt="" />
                                <div class="slide-info">
                                    <p>thu mua</p>
                                    <h3>phế liệu đồng</h3>
                                </div>
                            </div>
                            <div>
                                <img src="assets/images/slide.png" alt="" />
                                <div class="slide-info">
                                    <p>thu mua</p>
                                    <h3>phế liệu nhôm</h3>
                                </div>
                            </div>
                        </div>
                        <div class="lh">
                            <div class="lh-info">
                                <p>liên hệ: <a href="tel:0977921239" class="phone-call"><span>097 792 1239</span></a></p>
                                <h3>Công ty cổ phần công nghệ Trái Đất Xanh</h3>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </section>
        <section id="xu-ly" class="row">
            <div class="content-left col-md-6 pull-right">
                <h3 class="title-name cl-green">xử lý môi trường</h3>
                <asp:ListView ID="ListView1" runat="server" DataSourceID="odsCategoryMoiTruong"
                    EnableModelValidation="True">
                        <ItemTemplate>
                            <asp:Label ID="Label1" runat="server" Text='<%# Eval("Content") %>'></asp:Label>
                        </ItemTemplate>
                        <EmptyDataTemplate>
                            <p>
                                Sau 5 năm xây dựng và phát triển,
                                <br />
                                <span>Công ty cổ phần công nghệ Trái Đất Xanh</span> không ngừng nâng cao chất lượng dịch vụ nhằm đáp ứng được nhu cầu khắt khe nhất từ Quý Khách Hàng, và trở thành một trong những công ty uy tín hàng đầu về cung cấp các dịch vụ chuyên môn trong lĩnh vực môi trường.
                            </p>
                            <h3>dịch vụ</h3>
                            <ul>
                                <li>Tư vấn hồ sơ thủ tục Môi trường</li>
                                <li>Vận chuyển và xử lý chất thải nguy hại, không nguy hại</li>
                                <li>Tư vấn, thiết kế, thi công và vận hành hệ thống xử lý nước thải</li>
                                <li>Kinh doanh vải lau công nghiệp.</li>
                                <li>Thu mua phế liệu, nguyên phụ liệu, hàng tồn kho ngành dệt may, ba lô, túi xách,…</li>   
                            </ul>
                            <p>Với phương châm “Lấy Uy tín và chất lượng làm nền tảng”, Công ty cổ phần công nghệ Trái Đất Xanh cam kết mang đến Quý Khách Hàng những dịch vụ Môi trường tốt nhất .</p>   
                        </EmptyDataTemplate>
                        <LayoutTemplate>
                        <span runat="server" id="itemPlaceholder" />
                        </LayoutTemplate>   
                    </asp:ListView>
                    <asp:ObjectDataSource ID="odsCategoryMoiTruong" runat="server" 
                        SelectMethod="ArticleCategorySelectOne" TypeName="TLLib.ArticleCategory">
                        <SelectParameters>
                            <asp:Parameter DefaultValue="5" Name="ArticleCategoryID" Type="String" />
                        </SelectParameters>
                    </asp:ObjectDataSource>
            </div>
            <div class="content-right col-md-6 pull-left">
                <div class="items-circle">
                    <asp:ListView ID="lstDVMoiTruong" runat="server" DataSourceID="odsDVMoiTruong" EnableModelValidation="True">
                        <ItemTemplate>
                            <div class='<%# "items area-" + Container.DataItemIndex + 1 %>'>
                                <a href='<%# progressTitle(Eval("ArticleTitle")) + "-dv-" + Eval("ArticleID") + ".aspx" %>'>
                                    <img alt='<%# Eval("ArticleTitle") %>' src='<%# !string.IsNullOrEmpty(Eval("ImageName").ToString()) ? "~/res/article/" + Eval("ImageName") : "~/assets/images/xl1.png" %>'
                                    runat="server" />
                                    <p><%# Eval("ArticleTitle")%></p>
                                 </a>
                             </div>
                        </ItemTemplate>
                        <LayoutTemplate>
                        <span runat="server" id="itemPlaceholder" />
                        </LayoutTemplate>   
                    </asp:ListView>
                    <asp:ObjectDataSource ID="odsDVMoiTruong" runat="server" 
                        SelectMethod="ArticleSelectAll" TypeName="TLLib.Article">
                         <SelectParameters>
                             <asp:Parameter DefaultValue="1" Name="StartRowIndex" Type="String" />
                             <asp:Parameter DefaultValue="5" Name="EndRowIndex" Type="String" />
                             <asp:Parameter Name="Keyword" Type="String" />
                             <asp:Parameter Name="ArticleTitle" Type="String" />
                             <asp:Parameter Name="Description" Type="String" />
                             <asp:Parameter DefaultValue="5" Name="ArticleCategoryID" Type="String" />
                             <asp:Parameter Name="Tag" Type="String" />
                             <asp:Parameter DefaultValue="True" Name="IsShowOnHomePage" Type="String" />
                             <asp:Parameter Name="IsHot" Type="String" />
                             <asp:Parameter Name="IsNew" Type="String" />
                             <asp:Parameter Name="FromDate" Type="String" />
                             <asp:Parameter Name="ToDate" Type="String" />
                             <asp:Parameter DefaultValue="True" Name="IsAvailable" Type="String" />
                             <asp:Parameter Name="Priority" Type="String" />
                             <asp:Parameter DefaultValue="True" Name="SortByPriority" Type="String" />
                         </SelectParameters>
                    </asp:ObjectDataSource> 
                </div>
                <div class="clr"></div>
                <div class="img-special">
                    <img src="assets/images/plvn.jpg" alt="" />
                </div>
            </div>
            <div class="clr"></div>
            <div class="col-md-12">
                <div class="lienhe">
                    <div class="lh">
                        <div class="lh-info">
                            <p>liên hệ: <a href="tel:0977921239" class="phone-call"><span>097 792 1239</span></a></p>
                            <h3>Công ty cổ phần công nghệ Trái Đất Xanh</h3>
                        </div>
                    </div>
                </div>
            </div>
        </section>
    </div>
</asp:Content>
