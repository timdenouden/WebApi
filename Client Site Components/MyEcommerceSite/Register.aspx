<%@ Page Async="true" Title="" Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="Register.aspx.vb" Inherits="Account_Register" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">


</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="col-md-10 col-md-offset-1">
        <div class="well">
            <!-- This is the table to capture text fields -->
            <table class="table table-bordered">
                <thead>
                    <tr class="success">
                        <td colspan="2">
                            New User Registration
                        </td>
                    </tr>
                </thead>
                <tbody>
                    <tr>
                        <td>Registration Code</td>
                        <td>
                            <input type="text" id="txtCode" placeholder="Registration Code" runat="server"/>
                        </td>
                    </tr>
                    <tr>
                        <td>Email</td>
                        <td>
                            <input type="text" id="txtEmail" placeholder="Email" runat="server"/>
                        </td>
                    </tr>
                     <tr>
                        <td>Password</td>
                        <td>
                            <input type="password" id="txtPassword" placeholder="Password" runat="server"/>
                        </td>
                    </tr>
                     <tr>
                        <td>Confirm Password</td>
                        <td>
                            <input type="password" id="txtConfirmPassword" placeholder="Confirm Password" runat="server"/>

                        </td>
                    </tr>
                    <tr >
                        <td>
                            <asp:Button ID="btnRegister" runat="server" Text="Register" />
                        </td>
                    </tr>
                </tbody>
            </table>

            <asp:Label ID="lblRegisterResult" runat="server" Font-Bold="true" Text="" Visible="false" CssClass="alignCenter"></asp:Label>

        </div>

    </div> 
    

</asp:Content>
