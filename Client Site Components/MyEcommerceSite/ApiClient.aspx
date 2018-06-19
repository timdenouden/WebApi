<%@ Page Async="true" Title="" Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="ApiClient.aspx.vb" Inherits="ApiClient" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">


</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <style>
        .gvDesign
        {
              width: 100%;
              background-color: #fff;
              margin: 5px 0 10px 0;
              border: solid 1px #525252;
              border-collapse:collapse;
        }
        /*data elements*/
        .gvDesign td {
          padding: 2px;
          border: solid 1px #c1c1c1;
          color: #717171;
        }

        /*header elements*/
        .gvDesign th {
          padding: 4px 2px;
          color: #fff;
          background: #424242;
          border-left: solid 1px #525252;
          font-size: 0.9em;
        }

        /*this will be the color of even row*/
        .gvDesign .myAltRowClass { background: #fcfcfc repeat-x top; }

        .alignCenter {
            display: flex;
            align-items: center;
            justify-content: center;
            margin-left: auto;
            margin-right: auto;
            text-align: center;
        }

        .row {
            display: flex;
        }

        .column {
            flex: 50%;
            display: grid;
            grid-template-columns: 1fr 3fr;
        }

    </style>
    
    <div>
    <br />
        <!--API Login Credentials-->
        <div id="loginDiv" runat="server" class="alignCenter">
            <label>Email:</label>
            <input type="text" id="tbEmail" runat="server" />
            <label>Password:</label>
            <input type="password" id="tbPassword" runat="server" />
            <asp:Button ID="btnApiLogin" runat="server" Text="Login" />     
        </div>
        <a href="Register.aspx">Register for API Access</a>
            <asp:Label ID="lblLoginResult" runat="server" Font-Bold="true" Text="" Visible="false" CssClass="alignCenter"></asp:Label>
            <asp:Button ID="btnApiLogout" runat="server" Text="Logout" Visible="false"/>


    <br />
    <br />

        <!--Get All Products-->
        <asp:Button ID="btnAllProducts" CssClass="alignCenter" runat="server" Text="Get All Products" />
        <asp:GridView ID="gvAllProducts" CssClass="gvDesign" runat="server" HorizontalAlign="Center" autogeneratecolumns="False">
            <Columns>
                <asp:BoundField DataField="ProductID" HeaderText="ProductID" SortExpression="ProductID"/>
                <asp:BoundField DataField="ProductNo" HeaderText="Product No" SortExpression="ProductNo"/>
                <asp:BoundField DataField="ProductName" HeaderText="Product Name" SortExpression="ProductName"/>
                <asp:BoundField DataField="ProductDescription" HeaderText="Product Description" SortExpression="ProductDescription"/>
                <asp:BoundField DataField="Price" HeaderText="Price" SortExpression="Price"/>
                <asp:BoundField DataField="SubCategoryID" HeaderText="Sub Category ID" SortExpression="SubCategoryID"/>
                <asp:BoundField DataField="Featured" HeaderText="Featured" SortExpression="Featured"/>
                <asp:BoundField DataField="MainCategoryID" HeaderText="Main Category ID" SortExpression="MainCategoryID"/>
            </Columns>
            <AlternatingRowStyle CssClass="myAltRowClass" />
        </asp:GridView>
        <br />
        <br />
        
        <div class="alignCenter">
            <!--Get Product by ID-->
            <label>Get Product ID:</label>
            <input type="text" id="tbProductID" runat="server" />
            <asp:Button ID="btnProductID" runat="server" Text="Get Product by ID" />
        </div>
        <asp:GridView ID="gvProductID" CssClass="gvDesign" runat="server" HorizontalAlign="Center" autogeneratecolumns="False">
            <Columns>
                <asp:BoundField DataField="ProductID" HeaderText="ProductID" SortExpression="DateField" />
                <asp:BoundField DataField="ProductNo" HeaderText="Product No" SortExpression="ProductNo" />
                <asp:BoundField DataField="ProductName" HeaderText="Product Name" SortExpression="ProductName" />
                <asp:BoundField DataField="ProductDescription" HeaderText="Product Description" SortExpression="ProductDescription" />
                <asp:BoundField DataField="Price" HeaderText="Price" SortExpression="Price" />
                <asp:BoundField DataField="SubCategoryID" HeaderText="Sub Category ID" SortExpression="SubCategoryID" />
                <asp:BoundField DataField="Featured" HeaderText="Featured" SortExpression="Featured" />
                <asp:BoundField DataField="MainCategoryID" HeaderText="Main Category ID" SortExpression="MainCategoryID" />
            </Columns>

            <AlternatingRowStyle CssClass="myAltRowClass" />
        </asp:GridView>
        <br />
        <br />

        <div class="row">
            <div class="column">
                <!--Add and Update Product Inputs-->
                <label for="tbProductNo">ProductNo:</label>
                <input type="text" id="tbProductNo" runat="server" />

                <label for="tbProductName">ProductName:</label>
                <input type="text" id="tbProductName" runat="server" />

                <label for="tbProductDescription">ProductDescription:</label>
                <input type="text" id="tbProductDescription" runat="server" />

                <label for="tbPrice">Price:</label>
                <input type="text" id="tbPrice" runat="server" />

                <label for="tbSubCategoryID">SubCategoryID:</label>
                <input type="text" id="tbSubCategoryID" runat="server" />

                <label for="tbFeatured">Featured:</label>
                <input type="text" id="tbFeatured" runat="server" />

                <label for="tbMainCategoryID">MainCategoryID:</label>
                <input type="text" id="tbMainCategoryID" runat="server" />

            </div>
            <div>
                <br />
                <br />
                <!--Create Product-->
                    <asp:Button ID="btnCreateProduct" CssClass="alignCenter" runat="server" Text="Add New Product"/>
                <br />
                <br />
                <!--Update Product by ID-->
                <div  style="padding-left: 10px">
                    <label for="tbUpdateProductID" style="padding-left: 10px">Update Product ID:</label>
                    <input type="text" id="tbUpdateProductID" runat="server" />
                    <asp:Button ID="btnUpdateProduct" CssClass="alignCenter" runat="server" Text="Update Existing Product"/>
                </div>

            </div>
        </div> 
        
        <br />
        <br />

        <div class="alignCenter">
            <!--Delete Product by ID-->
            <label>Delete Product ID:</label>
            <input type="text" id="tbDeleteProductID" runat="server" />
            <asp:Button ID="btnDeleteProductID" runat="server" Text="Delete Product by ID" />
        </div>


        <br />
        <br />        
        <br />
        <br />


        <!--Get All Cart Info-->
        <asp:Button ID="btnAllCarts" class="alignCenter" runat="server" Text="Get All Cart Info" />
        <asp:GridView ID="gvAllCarts" CssClass="gvDesign" runat="server" HorizontalAlign="Center" autogeneratecolumns="False">
            <Columns>
                <asp:BoundField DataField="ID" HeaderText="ID" SortExpression="ID" />
                <asp:BoundField DataField="CartID" HeaderText="Cart ID" SortExpression="CartID" />
                <asp:BoundField DataField="ProductID" HeaderText="Product ID" SortExpression="ProductID" />
                <asp:BoundField DataField="ProductName" HeaderText="Product Name" SortExpression="ProductName" />
                <asp:BoundField DataField="Price" HeaderText="Price" SortExpression="Price" />
                <asp:BoundField DataField="Quantity" HeaderText="Quantity" SortExpression="Quantity" />
                <asp:BoundField DataField="LineTotal" HeaderText="Line Total" SortExpression="LineTotal" />
            </Columns>

            <AlternatingRowStyle CssClass="myAltRowClass" />
        </asp:GridView>
        <br />
        <br />

        <!--Delete Cart Line-->
        <div class="alignCenter">
            <label>Delete Cart Row (id):</label>
            <input type="text" id="tbDeleteCartLineID" runat="server" />
            <asp:Button ID="btnDeleteCartLineID" runat="server" Text="Delete Cart Line By ID" />
        </div>
        <br />
        <br />
        <br />

        <!--Get Cart by CartID-->
        <div class="alignCenter">
            <label>Get Entire Cart (CartID):</label>
            <input type="text" id="tbGetCartID" runat="server" />
            <asp:Button ID="btnCartByID" runat="server" Text="Get Cart by CartID" />
        </div>
        <asp:GridView ID="gvCartByID" CssClass="gvDesign" runat="server" HorizontalAlign="Center" autogeneratecolumns="False">
            <Columns>
                <asp:BoundField DataField="CartID" HeaderText="Cart ID" SortExpression="CartID" />
                <asp:BoundField DataField="ProductID" HeaderText="Product ID" SortExpression="ProductID" />
                <asp:BoundField DataField="ProductName" HeaderText="Product Name" SortExpression="ProductName" />
                <asp:BoundField DataField="Price" HeaderText="Price" SortExpression="Price" />
                <asp:BoundField DataField="Quantity" HeaderText="Quantity" SortExpression="Quantity" />
                <asp:BoundField DataField="ID" HeaderText="ID" SortExpression="ID" />
                <asp:BoundField DataField="LineTotal" HeaderText="Line Total" SortExpression="LineTotal" />
            </Columns>

            <AlternatingRowStyle CssClass="myAltRowClass" />
        </asp:GridView>
        <br />
        <br />

        <!--Get Current Cart using Cookie-->
        <asp:Button ID="btnCurrentCart" CssClass="alignCenter" runat="server" Text="Get Current Cart" />
        <asp:GridView ID="gvCurrentCart" CssClass="gvDesign" runat="server" HorizontalAlign="Center" autogeneratecolumns="False">
                        <Columns>
                <asp:BoundField DataField="CartID" HeaderText="Cart ID" SortExpression="CartID" />
                <asp:BoundField DataField="ProductID" HeaderText="Product ID" SortExpression="ProductID" />
                <asp:BoundField DataField="ProductName" HeaderText="Product Name" SortExpression="ProductName" />
                <asp:BoundField DataField="Price" HeaderText="Price" SortExpression="Price" />
                <asp:BoundField DataField="Quantity" HeaderText="Quantity" SortExpression="Quantity" />
                <asp:BoundField DataField="ID" HeaderText="ID" SortExpression="ID" />
                <asp:BoundField DataField="LineTotal" HeaderText="Line Total" SortExpression="LineTotal" />
            </Columns>
            <AlternatingRowStyle CssClass="myAltRowClass" />
        </asp:GridView>
        <br />
        <br />

        <!--Change Cart Qty-->
        <div class="alignCenter">
            <label>Cart Line to Update (id):</label>
            <input type="text" id="tbUpdateQtyCartLineID" runat="server" />
            <label style="padding-left: 10px">New Quantity:</label>
            <input type="text" id="tbUpdateQtyAmt" runat="server" />
            <asp:Button ID="btnUpdateCartQty" runat="server" Text="Update Quantity" />
        </div>
        <br />
        <br />

        <!--Import All Products-->
        <asp:button runat="server" id="btnImportAllProducts" text="Import All Products to Ecommerce DB" />
        <br />
        <br />

        <!--Import Product by ID-->

        <label>Product ID:</label>
        <input type="text" id="tbImportProductID" runat="server" />
        <asp:button runat="server" id="btnImportProductID" text="Import Product to Ecommerce DB" />

    </div>
</asp:Content>

