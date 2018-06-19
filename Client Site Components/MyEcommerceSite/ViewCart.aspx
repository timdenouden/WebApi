<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="ViewCart.aspx.vb" Inherits="ViewCart" EnableEventValidation="false" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
          <asp:Label ID="lblCartError"  class="alert alert-danger" runat="server" Text="CartError"></asp:Label>

    <asp:SqlDataSource ID="sqlDSCart" runat="server" 
                ConnectionString="<%$ ConnectionStrings:ConnectionStringOnlineStore %>"> 
            </asp:SqlDataSource>
            <asp:ListView ID="lvCart" runat="server" DataSourceID="sqlDSCart"
                OnItemCommand="lvCart_OnItemCommand" CellPadding="3" DataKeyField="ID"
                CellSpacing="0" RepeatColumns="1" DataKeyNames="ID">
                <LayoutTemplate>              
                    <div style="float: right; margin: 0 30px 5px 0;">
                        <asp:Label ID="lblPage" runat="server" Text="" Font-Size="14px"></asp:Label>
                    </div><br />
    
      <div class="ps-content pt-80 pb-80">
        <div class="ps-container">
          <div class="ps-cart-listing">
            <table class="table ps-cart__table">
              <thead>
                <tr>
                  <th>All Products</th>
                  <th>Price</th>
                  <th>Quantity</th>
                  <th>Subtotal</th>
                  <th></th>
                </tr>
              </thead>
              <tbody>
                  <asp:PlaceHolder runat="server" ID="groupPlaceHolder" />
              </tbody>
                </table>
                </LayoutTemplate>
                <GroupTemplate>
                    <asp:PlaceHolder runat="server" id="itemPlaceholder"></asp:PlaceHolder>
                </GroupTemplate>
                <ItemTemplate>
                <tr>
                  <td><a class="ps-product__preview" href="product-detail.html"><img class="mr-15" src="images/product/cart-preview/1.jpg" alt=""><%# Eval("ProductName")%> // Web ID: <%# Eval("ProductID")%></a></td>
                    
                  <td>$<%# Eval("Price")%></td>
                  <td>
                    <div class="form-group--number">
                        <asp:TextBox ID="tbQuantity" Text='<%# Eval("Quantity")%>' Width="50px" CssClass="" runat="server"></asp:TextBox>
                        <asp:LinkButton class="ps-btn--gray" runat="server" ID="lbUpdate" Text='Update'
                             CommandName="cmdUpdate" CommandArgument='<%# Eval("ProductID")%>' />
                    </div>
                  </td>
                  <td>$<%# Eval("LineTotal")%></td>
                  <td>
                    	<asp:LinkButton class="ps-remove" runat="server" ID="lbDelete" Text=''
                        CommandName="cmdDelete" CommandArgument='<%# Eval("ProductID")%>' />
                  </td>
                </tr>
           </ItemTemplate>
            </asp:ListView>    
         <div>
             <asp:Button ID="btnClearCart"  runat="server" Text="Clear Cart" /></div>
              <div class="ps-cart__total">
                <h3>Total Price: $<asp:Label ID="lblTotal" runat="server" Text="Label"></asp:Label><span> </span></h3><a class="ps-btn" href="checkout.html">Proceed to checkout<i class="ps-icon-next"></i></a>
              </div>


    <div style="padding: 8px;width: 100%;text-align: center;">
        <div style="display: inline-block; margin-top: 5px">
        <asp:Button runat="server" Text="&laquo;" id="show_prev" CssClass="show_prevx"></asp:Button>
        <asp:DataPager ID="DataPager1" runat="server" PagedControlID="lvCart" PageSize="3">
            <Fields>        
            <asp:NumericPagerField NextPageText='&raquo;' PreviousPageText='&laquo;' ButtonCount="3" 
                ButtonType="Button" NextPreviousButtonCssClass="next_prevx" NumericButtonCssClass="numericx" 
                CurrentPageLabelCssClass="currentx" RenderNonBreakingSpacesBetweenControls="False" />
            </Fields>
        </asp:DataPager>
        <asp:Button runat="server" Text="&raquo;" id="show_next" CssClass="show_nextx"></asp:Button>
        </div>
    </div>

</asp:Content>

