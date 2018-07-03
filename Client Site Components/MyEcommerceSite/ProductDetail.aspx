<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="ProductDetail.aspx.vb" Inherits="ProductDetail" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="ps-product--detail pt-60">
        <asp:Label ID="lblError" class="alert alert-danger" runat="server" Text="Error"></asp:Label>
        <div class="ps-container">
          <div class="row">
                <div class="ps-product__thumbnail">
                    <div class="ps-product__image">
                      <div class="item"><img class="zoom" src="imgProduct" id="imgProduct" runat="server"></div>
                    </div>
                </div>
                
              <div class="ps-product__thumbnail--mobile">
                <div class="ps-product__main-img"><img src="images/shoe-detail/1.jpg" alt=""></div>
                <div class="ps-product__preview owl-slider" data-owl-auto="true" data-owl-loop="true" data-owl-speed="5000" data-owl-gap="20" data-owl-nav="true" data-owl-dots="false" data-owl-item="3" data-owl-item-xs="3" data-owl-item-sm="3" data-owl-item-md="3" data-owl-item-lg="3" data-owl-duration="1000" data-owl-mousedrag="on"><img src="images/shoe-detail/1.jpg" alt=""><img src="images/shoe-detail/2.jpg" alt=""><img src="images/shoe-detail/3.jpg" alt=""></div>
              </div>
              <div class="ps-product__info">
                
                <h1><asp:Label ID="lblProductName" runat="server" Text=""></asp:Label></h1>
                <p class="ps-product__category">Web ID: <asp:Label ID="lblProductNo" runat="server" Text=""></asp:Label></p>
                <h3 class="ps-product__price">$ <asp:Label ID="lblPrice" runat="server" Text=""></asp:Label></h3>
                <div class="ps-product__block ps-product__quickview">

                  <p><asp:Label ID="lblProductDescription" runat="server" Text=""></asp:Label></p>
                </div>
                
                <div class="ps-product__block ps-product__size">
                        <label>Quantity:</label>
                        <input type="text" id="tbQuantity" runat="server" />                  
                        <asp:Button class="ps-btn mb-10" ID="btnAdd" runat="server" Text="Add to Cart" />
                </div>
 
              </div>
            </div>
          </div>
        </div>
      <div class="ps-section ps-section--top-sales ps-owl-root pt-40 pb-80">
        <div class="ps-container">
          <div class="ps-section__header mb-50">
            <div class="row">
                  <div class="col-lg-9 col-md-9 col-sm-12 col-xs-12 ">
                    <h3 class="ps-section__title" data-mask="Related item">- COMPARE WITH SIMILAR ITEMS</h3>
                  </div>
                  <div class="col-lg-3 col-md-3 col-sm-12 col-xs-12 ">
                    <div class="ps-owl-actions"><a class="ps-prev" href="#"><i class="ps-icon-arrow-right"></i>Prev</a><a class="ps-next" href="#">Next<i class="ps-icon-arrow-left"></i></a></div>
                  </div>
            </div>
          </div>
          <div class="ps-section__content" style="margin-bottom:50px;">
            <div class="row">
                <!-- START OF CARD see ProductDetail.aspx.vb to see how to populate data -->
                <div class="col-md-2">
                    <div class="card">
                        <div class="card-body">
                            <img src="images/product/1.jpg" />
                            <h5 class="card-title">
                                <asp:Label ID="lblProductTitle1" runat="server" Text="Label"></asp:Label>
                            </h5>
                            <h6 class="card-subtitle mb-2 text-muted">
                                <asp:Label ID="lblProductPrice1" runat="server" Text="Label"></asp:Label>
                            </h6>
                            <p class="card-text">
                                <asp:Label ID="lblProductDescription1" runat="server" Text="Label"></asp:Label>
                            </p>
                            <asp:HyperLink CssClass="btn btn-primary" ID="hplProduct1" runat="server">View</asp:HyperLink>
                        </div>
                    </div>
                </div>
                <!-- END OF CARD, recreate three more times replacing the dummy data below -->

                <div class="col-md-2">
                    <div class="card">
                        <div class="card-body">
                            <img src="images/product/1.jpg" />
                            <h5 class="card-title">
                                <asp:Label ID="lblProductTitle2" runat="server" Text="Label"></asp:Label>
                            </h5>
                            <h6 class="card-subtitle mb-2 text-muted">Card subtitle</h6>
                            <p class="card-text">Some quick example text to build on the card title and make up the bulk of the card's content.</p>
                            <a href="#" class="btn btn-primary">Card link</a>
                        </div>
                    </div>
                </div>
                <div class="col-md-2">
                    <div class="card">
                        <div class="card-body">
                            <img src="images/product/1.jpg" />
                            <h5 class="card-title">Card title</h5>
                            <h6 class="card-subtitle mb-2 text-muted">Card subtitle</h6>
                            <p class="card-text">Some quick example text to build on the card title and make up the bulk of the card's content.</p>
                            <a href="#" class="btn btn-primary">Card link</a>
                        </div>
                    </div>
                </div>
                <div class="col-md-2">
                    <div class="card">
                        <div class="card-body">
                            <img src="images/product/1.jpg" />
                            <h5 class="card-title">Card title</h5>
                            <h6 class="card-subtitle mb-2 text-muted">Card subtitle</h6>
                            <p class="card-text">Some quick example text to build on the card title and make up the bulk of the card's content.</p>
                            <a href="#" class="btn btn-primary">Card link</a>
                        </div>
                    </div>
                </div>
            </div>
          </div>
        </div>
      </div>
</asp:Content>

