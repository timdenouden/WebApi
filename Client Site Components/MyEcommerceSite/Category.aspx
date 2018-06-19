<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="Category.aspx.vb" Inherits="Category" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <main class="ps-main">
        <div class="ps-products-wrap pt-80 pb-80">
            <div class="ps-products" data-mh="product-listing">
              <div class="ps-product-action">
                <div class="ps-product__filter">
                  <select class="ps-select selectpicker">
                    <option value="1">Shortby</option>
                    <option value="2">Name</option>
                    <option value="3">Price (Low to High)</option>
                    <option value="3">Price (High to Low)</option>
                  </select>
                </div>
                <div class="ps-pagination">
                  <ul class="pagination">
                    <li><a href="#"><i class="fa fa-angle-left"></i></a></li>
                    <li class="active"><a href="#">1</a></li>
                    <li><a href="#">2</a></li>
                    <li><a href="#">3</a></li>
                    <li><a href="#">...</a></li>
                    <li><a href="#"><i class="fa fa-angle-right"></i></a></li>
                  </ul>
                </div>
              </div>

                  <h2 class="title text-center mb-60"><asp:Label ID="lblProductList" runat="server" Text="Featured Products"></asp:Label></h2>
                   <asp:SqlDataSource ID="SqlDSProductList" runat="server" ConnectionString='<%$ ConnectionStrings:ConnectionStringOnlineStore %>' SelectCommand=""></asp:SqlDataSource>
                    <asp:DataList ID="dlProductList" runat="server" DataSourceID="SqlDSProductList" RepeatColumns="4"
                        RepeatDirection="Horizontal">
                        <ItemTemplate>
                            <div class="col-sm-8">
                            <div class="ps-product__columns">
                                <div class="ps-shoe">
                                <div class="ps-shoe__thumbnail"><a class="ps-shoe__favorite" href="#"><i class="ps-icon-heart"></i></a><img src="images/shoe/3.jpg" alt=""><a class="ps-shoe__overlay" href="ProductDetail.aspx?ProductID=<%# Eval("ProductID")%>"></a>
                                </div>
                                <div class="ps-shoe__content">
                                    <div class="ps-shoe__variants">
                                    <div class="ps-shoe__variant normal"><img src="images/shoe/2.jpg" alt=""><img src="images/shoe/3.jpg" alt=""><img src="images/shoe/4.jpg" alt=""><img src="images/shoe/5.jpg" alt=""></div>
                                    
                                    </div>
                                    <div class="ps-shoe__detail text-center"><a class="ps-shoe__name" href="ProductDetail.aspx?ProductID=<%# Eval("ProductID")%>"><%# Eval("ProductName")%></a>
                                        <span class="ps-shoe__price"> $<%# Eval("Price")%></span>
                                    </div>
                                </div>
                                </div>
                            </div>
                            </div>
                        </ItemTemplate>
                    </asp:DataList>
            
             
              <div class="ps-product-action">
                <div class="ps-product__filter">
                  <select class="ps-select selectpicker">
                    <option value="1">Shortby</option>
                    <option value="2">Name</option>
                    <option value="3">Price (Low to High)</option>
                    <option value="3">Price (High to Low)</option>
                  </select>
                </div>
                <div class="ps-pagination">
                  <ul class="pagination">
                    <li><a href="#"><i class="fa fa-angle-left"></i></a></li>
                    <li class="active"><a href="#">1</a></li>
                    <li><a href="#">2</a></li>
                    <li><a href="#">3</a></li>
                    <li><a href="#">...</a></li>
                    <li><a href="#"><i class="fa fa-angle-right"></i></a></li>
                  </ul>
                </div>
              </div>
            </div>
            <div class="ps-sidebar" data-mh="product-listing">
              <aside class="ps-widget--sidebar ps-widget--category">
                <div class="ps-widget__header">
                  <h3><asp:Label ID="lblMainCategoryName" runat="server" Text="Label"></asp:Label></h3>
                </div>
                <div class="ps-widget__content">
                  <ul class="ps-list--checked">
                      <asp:SqlDataSource ID="sqlDSSubCategory" runat="server" ConnectionString='<%$ ConnectionStrings:ConnectionStringOnlineStore %>' SelectCommand="SELECT * FROM [Category]"></asp:SqlDataSource>
                      <asp:DataList ID="dlSubCategory" runat="server" DataSourceID="sqlDSSubCategory">
                          <ItemTemplate>
                            <li><a href="Category.aspx?SubCategoryId=<%# Eval("CategoryID")%>&SubCategoryName=<%# Eval("CategoryName")%>&MainCategoryID=<% = Request.QueryString("MainCategoryID")%>&&MainCategoryName=<% = Request.QueryString("MainCategoryName")%>"><%# Trim(Eval("CategoryName"))%></a></li>
                          </ItemTemplate>
                      </asp:DataList>

                  </ul>
                </div>
              </aside>
              <aside class="ps-widget--sidebar ps-widget--filter">
                <div class="ps-widget__header">
                  <h3>Category</h3>
                </div>
                <div class="ps-widget__content">
                  <div class="ac-slider" data-default-min="300" data-default-max="2000" data-max="3450" data-step="50" data-unit="$"></div>
                  <p class="ac-slider__meta">Price:<span class="ac-slider__value ac-slider__min"></span>-<span class="ac-slider__value ac-slider__max"></span></p><a class="ac-slider__filter ps-btn" href="#">Filter</a>
                </div>
              </aside>
              <aside class="ps-widget--sidebar ps-widget--category">
                <div class="ps-widget__header">
                  <h3>Shoe Brand</h3>
                </div>
                <div class="ps-widget__content">
                  <ul class="ps-list--checked">
                    <li class="current"><a href="product-listing.html">Nike(521)</a></li>
                    <li><a href="product-listing.html">Adidas(76)</a></li>
                    <li><a href="product-listing.html">Baseball(69)</a></li>
                    <li><a href="product-listing.html">Gucci(36)</a></li>
                    <li><a href="product-listing.html">Dior(108)</a></li>
                    <li><a href="product-listing.html">B&G(108)</a></li>
                    <li><a href="product-listing.html">Louis Vuiton(47)</a></li>
                  </ul>
                </div>
              </aside>
              <aside class="ps-widget--sidebar ps-widget--category">
                <div class="ps-widget__header">
                  <h3>Width</h3>
                </div>
                <div class="ps-widget__content">
                  <ul class="ps-list--checked">
                    <li class="current"><a href="product-listing.html">Narrow</a></li>
                    <li><a href="product-listing.html">Regular</a></li>
                    <li><a href="product-listing.html">Wide</a></li>
                    <li><a href="product-listing.html">Extra Wide</a></li>
                  </ul>
                </div>
              </aside>
              <div class="ps-sticky desktop">
                <aside class="ps-widget--sidebar">
                  <div class="ps-widget__header">
                    <h3>Size</h3>
                  </div>
                  <div class="ps-widget__content">
                    <table class="table ps-table--size">
                      <tbody>
                        <tr>
                          <td class="active">3</td>
                          <td>5.5</td>
                          <td>8</td>
                          <td>10.5</td>
                          <td>13</td>
                        </tr>
                        <tr>
                          <td>3.5</td>
                          <td>6</td>
                          <td>8.5</td>
                          <td>11</td>
                          <td>13.5</td>
                        </tr>
                        <tr>
                          <td>4</td>
                          <td>6.5</td>
                          <td>9</td>
                          <td>11.5</td>
                          <td>14</td>
                        </tr>
                        <tr>
                          <td>4.5</td>
                          <td>7</td>
                          <td>9.5</td>
                          <td>12</td>
                          <td>14.5</td>
                        </tr>
                        <tr>
                          <td>5</td>
                          <td>7.5</td>
                          <td>10</td>
                          <td>12.5</td>
                          <td>15</td>
                        </tr>
                      </tbody>
                    </table>
                  </div>
                </aside>
                <aside class="ps-widget--sidebar">
                  <div class="ps-widget__header">
                    <h3>Color</h3>
                  </div>
                  <div class="ps-widget__content">
                    <ul class="ps-list--color">
                      <li><a href="#"></a></li>
                      <li><a href="#"></a></li>
                      <li><a href="#"></a></li>
                      <li><a href="#"></a></li>
                      <li><a href="#"></a></li>
                      <li><a href="#"></a></li>
                      <li><a href="#"></a></li>
                      <li><a href="#"></a></li>
                      <li><a href="#"></a></li>
                      <li><a href="#"></a></li>
                      <li><a href="#"></a></li>
                      <li><a href="#"></a></li>
                      <li><a href="#"></a></li>
                    </ul>
                  </div>
                </aside>
              </div>
            </div>
          </div>
      </main>
      
</asp:Content>

