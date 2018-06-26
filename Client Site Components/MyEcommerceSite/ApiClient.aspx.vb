Imports System.Data
Imports System.Data.SqlClient
Imports System.Drawing
Imports System.Net.Http
Imports System.Net.Http.Headers
Imports Newtonsoft.Json

Partial Class ApiClient
    Inherits System.Web.UI.Page

    Dim httpClient As New HttpClient
    Dim strCartID As String

    Private Async Sub btnAllProducts_ClickAsync(sender As Object, e As EventArgs) Handles btnAllProducts.Click
        Dim uri As String = "https://localhost:44338/api/product"
        Dim task = Await httpClient.GetAsync(uri)
        Dim jsonString = Await task.Content.ReadAsStringAsync()
        If task.IsSuccessStatusCode Then
            Dim table As DataTable = JsonConvert.DeserializeObject(Of DataTable)(jsonString)
            gvAllProducts.DataSource = table
            gvAllProducts.DataBind()
        End If

    End Sub

    Public Async Sub btnProductID_ClickAsync(sender As Object, e As EventArgs) Handles btnProductID.Click

        Dim uri As String = "https://localhost:44338/api/product/" & tbProductID.Value
        Dim task = Await httpClient.GetAsync(uri)
        Dim jsonString As String = Await task.Content.ReadAsStringAsync()
        If task.IsSuccessStatusCode Then
            Dim table As DataTable = JsonConvert.DeserializeObject(Of DataTable)(jsonString)
            gvProductID.DataSource = table
            gvProductID.DataBind()
        End If

    End Sub

    Private Async Sub btnCreateProduct_ClickAsync(sender As Object, e As EventArgs) Handles btnCreateProduct.Click
        Dim myJson As String = ("{'ProductNo': '" & tbProductNo.Value & "', 'ProductName': '" & tbProductName.Value & "', 'ProductDescription': '" _
            & tbProductDescription.Value & "', 'Price': '" & tbPrice.Value & "', 'SubCategoryID': '" & tbSubCategoryID.Value _
            & "', 'Featured': '" & tbFeatured.Value & "', 'MainCategoryID': '" & tbMainCategoryID.Value & "'}")

        httpClient.DefaultRequestHeaders.Authorization = New AuthenticationHeaderValue("Bearer", getToken())
        Dim uri As String = "https://localhost:44338/api/product/"
        Dim response = Await httpClient.PostAsync(uri, New StringContent(myJson, Encoding.UTF8, "application/json"))
        btnAllProducts_ClickAsync(btnAllProducts, EventArgs.Empty)
    End Sub

    Private Async Sub btnUpdateProduct_ClickAsync(sender As Object, e As EventArgs) Handles btnUpdateProduct.Click
        Dim myJson As String = ("{'ProductNo': '" & tbProductNo.Value & "', 'ProductName': '" & tbProductName.Value & "', 'ProductDescription': '" _
            & tbProductDescription.Value & "', 'Price': '" & tbPrice.Value & "', 'SubCategoryID': '" & tbSubCategoryID.Value _
            & "', 'Featured': '" & tbFeatured.Value & "', 'MainCategoryID': '" & tbMainCategoryID.Value & "'}")

        httpClient.DefaultRequestHeaders.Authorization = New AuthenticationHeaderValue("Bearer", getToken())
        Dim uri As String = "https://localhost:44338/api/product/" & tbUpdateProductID.Value
        Dim response = Await httpClient.PutAsync(uri, New StringContent(myJson, Encoding.UTF8, "application/json"))
        btnAllProducts_ClickAsync(btnAllProducts, EventArgs.Empty)
        btnProductID_ClickAsync(btnProductID, EventArgs.Empty)
    End Sub

    Private Async Sub btnDeleteProductID_ClickAsync(sender As Object, e As EventArgs) Handles btnDeleteProductID.Click
        httpClient.DefaultRequestHeaders.Authorization = New AuthenticationHeaderValue("Bearer", getToken())
        Dim uri As String = "https://localhost:44338/api/product/" & tbDeleteProductID.Value
        Await httpClient.DeleteAsync(uri)
        btnAllProducts_ClickAsync(btnAllProducts, EventArgs.Empty)
        btnProductID_ClickAsync(btnProductID, EventArgs.Empty)

    End Sub

    Private Async Sub btnAllCarts_ClickAsync(sender As Object, e As EventArgs) Handles btnAllCarts.Click

        Dim uri As String = "https://localhost:44338/api/cart"
        Dim task = Await httpClient.GetAsync(uri)
        Dim jsonString = Await task.Content.ReadAsStringAsync()
        If task.IsSuccessStatusCode Then
            Dim table As DataTable = JsonConvert.DeserializeObject(Of DataTable)(jsonString)
            gvAllCarts.DataSource = table
            gvAllCarts.DataBind()
        End If
    End Sub

    Private Async Sub btnDeleteCartLineID_ClickAsync(sender As Object, e As EventArgs) Handles btnDeleteCartLineID.Click
        httpClient.DefaultRequestHeaders.Authorization = New AuthenticationHeaderValue("Bearer", getToken())
        Dim uri As String = "https://localhost:44338/api/cart/" & tbDeleteCartLineID.Value
        Await httpClient.DeleteAsync(uri)
        btnAllCarts_ClickAsync(btnAllCarts, EventArgs.Empty)
        btnCartByID_ClickAsync(btnCartByID, EventArgs.Empty)

    End Sub

    Private Async Sub btnCartByID_ClickAsync(sender As Object, e As EventArgs) Handles btnCartByID.Click

        Dim uri As String = "https://localhost:44338/api/cart/" & tbGetCartID.Value
        Dim task = Await httpClient.GetAsync(uri)
        Dim jsonString = Await task.Content.ReadAsStringAsync()
        If task.IsSuccessStatusCode Then
            Dim table As DataTable = JsonConvert.DeserializeObject(Of DataTable)(jsonString)
            gvCartByID.DataSource = table
            gvCartByID.DataBind()
        End If
    End Sub

    Private Async Sub btnCurrentCart_ClickAsync(sender As Object, e As EventArgs) Handles btnCurrentCart.Click
        If strCartID IsNot Nothing Then

            Dim uri As String = "https://localhost:44338/api/cart/" & strCartID
            Dim task = Await httpClient.GetAsync(uri)
            Dim jsonString As String = Await task.Content.ReadAsStringAsync()
            If task.IsSuccessStatusCode Then
                Dim table As DataTable = JsonConvert.DeserializeObject(Of DataTable)(jsonString)
                gvCurrentCart.DataSource = table
                gvCurrentCart.DataBind()
            End If
        End If
    End Sub

    Private Sub ApiClient_Load(sender As Object, e As EventArgs) Handles Me.Load
        If (HttpContext.Current.Request.Cookies("CartID") IsNot Nothing) Then
            Dim CookieBack As HttpCookie = HttpContext.Current.Request.Cookies("CartID")
            strCartID = CookieBack.Value
        End If
        If (HttpContext.Current.Request.Cookies("JwtCookie") IsNot Nothing) Then
            loginDiv.Visible = False
            btnApiLogout.Visible = True
        End If

    End Sub

    Private Async Sub btnUpdateCartQty_ClickAsync(sender As Object, e As EventArgs) Handles btnUpdateCartQty.Click
        Dim myJson As String = ("[{'op': 'replace', 'path': '/quantity', 'value': '" & tbUpdateQtyAmt.Value & "'}]")
        'Note [ ] in JSON'

        httpClient.DefaultRequestHeaders.Authorization = New AuthenticationHeaderValue("Bearer", getToken())
        Dim uri As String = "https://localhost:44338/api/cart/" & tbUpdateQtyCartLineID.Value
        'HttpClient does not have a PatchAsync helper method but does support Patch HttpMethod so we build our own HttpRequestMethod and use SendAsync'
        Dim httpPatchMethod As New HttpMethod("PATCH")
        Dim request As New HttpRequestMessage(httpPatchMethod, uri)
        request.Content = New StringContent(myJson, Encoding.UTF8, "application/json")
        Dim response = Await httpClient.SendAsync(request)

        btnAllCarts_ClickAsync(btnAllCarts, EventArgs.Empty)
        btnCartByID_ClickAsync(btnCartByID, EventArgs.Empty)
        btnCurrentCart_ClickAsync(btnCurrentCart, EventArgs.Empty)

    End Sub

    Private Async Sub btnImportAllProducts_ClickAsync(sender As Object, e As EventArgs) Handles btnImportAllProducts.Click
        Dim uri As String = "https://localhost:44338/api/product"
        Dim task = Await httpClient.GetAsync(uri)
        Dim jsonString = Await task.Content.ReadAsStringAsync()

        Dim sqlDr As SqlDataReader
        Dim strSQLStatement As String
        Dim cmdSQL As SqlCommand
        Dim strConnectionString As String = System.Configuration.ConfigurationManager.ConnectionStrings("ConnectionStringOnlineStore").ConnectionString
        Dim conn As New SqlConnection(strConnectionString)
        conn.Open()
        strSQLStatement = "DECLARE @json NVARCHAR(max) SET @json = N'" & jsonString & "'; INSERT INTO Product  SELECT * FROM OPENJSON(@json) WITH (productNo varchar(30), productName varchar(100), productDescription varchar(200), price numeric(7,2), subCategoryID int, featured char(1), mainCategoryID int)"
        cmdSQL = New SqlCommand(strSQLStatement, conn)
        sqlDr = cmdSQL.ExecuteReader()
        conn.Close()
    End Sub

    Private Async Sub btnImportProductID_ClickAsync(sender As Object, e As EventArgs) Handles btnImportProductID.Click
        Dim uri As String = "https://localhost:44338/api/product/" & tbImportProductID.Value
        Dim task = Await httpClient.GetAsync(uri)
        Dim jsonString = Await task.Content.ReadAsStringAsync()


        Dim sqlDr As SqlDataReader
        Dim strSQLStatement As String
        Dim cmdSQL As SqlCommand
        Dim strConnectionString As String = System.Configuration.ConfigurationManager.ConnectionStrings("ConnectionStringOnlineStore").ConnectionString
        Dim conn As New SqlConnection(strConnectionString)
        conn.Open()
        strSQLStatement = "DECLARE @json NVARCHAR(max) SET @json = N'" & jsonString & "'; INSERT INTO Product  SELECT * FROM OPENJSON(@json) WITH (productNo varchar(30), productName varchar(100), productDescription varchar(200), price numeric(7,2), subCategoryID int, featured char(1), mainCategoryID int)"
        cmdSQL = New SqlCommand(strSQLStatement, conn)
        sqlDr = cmdSQL.ExecuteReader()
        conn.Close()
    End Sub

    Private Async Sub btnApiLogin_ClickAsync(sender As Object, e As EventArgs) Handles btnApiLogin.Click
        Dim myJson As String
        myJson = ("{'email': '" & tbEmail.Value & "', 'password': '" & tbPassword.Value & "'}")

        Dim uri As String = "https://localhost:44338/account/login"
        Dim task = Await httpClient.PostAsync(uri, New StringContent(myJson, Encoding.UTF8, "application/json"))
        Dim jwtToken As String
        If task.IsSuccessStatusCode Then
            jwtToken = Await task.Content.ReadAsStringAsync()
            lblLoginResult.Text = "Successful Login"
            lblLoginResult.ForeColor = Color.Green
            lblLoginResult.Visible = True
            loginDiv.Visible = False
            btnApiLogout.Visible = True

            Dim tokenCookie As New HttpCookie("JwtCookie")
            tokenCookie.HttpOnly = True
            'tokenCookie.Secure = True //use if HTTPS for added security. Current ApiClient page is HTTP only
            tokenCookie("JWT") = jwtToken
            tokenCookie.Expires = Now.AddHours(1)
            Response.Cookies.Add(tokenCookie)
        Else
            lblLoginResult.Text = "Failed Login"
            lblLoginResult.ForeColor = Color.Red
            lblLoginResult.Visible = True
        End If
    End Sub

    Private Sub btnApiLogout_Click(sender As Object, e As EventArgs) Handles btnApiLogout.Click
        If (Not Request.Cookies("JwtCookie") Is Nothing) Then
            Dim tokenCookie As HttpCookie
            tokenCookie = New HttpCookie("JwtCookie")
            tokenCookie.Expires = DateTime.Now.AddDays(-1D)
            Response.Cookies.Add(tokenCookie)
            lblLoginResult.Visible = False
            loginDiv.Visible = True
            btnApiLogout.Visible = False

        End If
    End Sub

    Function getToken() As String
        Dim jwtToken As String
        If (Request.Cookies("JwtCookie") IsNot Nothing) Then
            If (Request.Cookies("JwtCookie")("JWT") IsNot Nothing) Then
                jwtToken = Request.Cookies("JwtCookie")("JWT")
                Return jwtToken
            End If
        End If
        Return Nothing
    End Function
End Class
