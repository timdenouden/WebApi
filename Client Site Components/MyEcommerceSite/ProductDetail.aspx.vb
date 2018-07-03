Imports System.Data
Imports System.Data.SqlClient
Imports System.Net.Http
Imports Newtonsoft.Json

Partial Class ProductDetail
    Inherits System.Web.UI.Page
    Dim httpClient As New HttpClient

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        lblError.Visible = False

        If Request.QueryString("ProductID") <> "" Then
            Dim uri As String = "https://localhost:44338/api/product/" & CInt(Request.QueryString("ProductID"))
            Dim task = httpClient.GetStringAsync(uri)
            task.Wait()
            Dim jsonString As String = task.Result
            Try
                Dim productList As List(Of Product) = JsonConvert.DeserializeObject(Of List(Of Product))(jsonString)
                Dim product = productList.First
                lblProductName.Text = product.productName
                lblProductDescription.Text = product.productDescription
                lblPrice.Text = Convert.ToString(product.price)
                lblProductNo.Text = Convert.ToString(product.productNo)
            Catch ex As Exception
                Console.WriteLine("An error occurred")
                Response.Redirect("http://localhost:53384/")
            End Try
        Else
            Response.Redirect("http://localhost:53384/")
        End If

        'In this area we need to call the backend "api/category/{categoryId} we will create to get the product information

        'The code below sets the text on the page of the first card
        'The other three cards need to be set up in the same way
        lblProductTitle1.Text = "Product 1 Title"
        lblProductPrice1.Text = "$99.99"
        lblProductDescription1.Text = "This is where the description goes."
        hplProduct1.NavigateUrl = "ProductDetail.aspx?ProductId=" + Convert.ToString(6) 'This is how we will link to other products i.e. this is for product 6

    End Sub

    Protected Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        Dim drCartLine As SqlDataReader
        Dim strSQLStatement As String
        Dim cmdSQL As SqlCommand
        Dim strConnectionString As String = System.Configuration.ConfigurationManager.ConnectionStrings("ConnectionStringOnlineStore").ConnectionString
        Dim conn As New SqlConnection(strConnectionString)
        conn.Open()
        ' *** get product price
        strSQLStatement = "SELECT * FROM Product WHERE ProductNo = '" & lblProductNo.Text & "'"
        cmdSQL = New SqlCommand(strSQLStatement, conn)
        drCartLine = cmdSQL.ExecuteReader()
        Dim sngPrice As Single
        If drCartLine.Read() Then
            sngPrice = drCartLine.Item("Price")
        End If
        '*** get CartID
        Dim strCartID As String
        If HttpContext.Current.Request.Cookies("CartID") Is Nothing Then
            strCartID = GetRandomCartIDUsingGUID(10)
            Dim CookieTo As New HttpCookie("CartID", strCartID)
            HttpContext.Current.Response.AppendCookie(CookieTo)
        Else
            Dim CookieBack As HttpCookie
            CookieBack = HttpContext.Current.Request.Cookies("CartID")
            strCartID = CookieBack.Value
        End If
        conn.Close()

        ' figure out if this product already exits in the cart
        strSQLStatement = "Select * FROM Cart WHERE CartID = '" & strCartID & "' AND ProductID = '" & lblProductNo.Text & "'"
        cmdSQL = New SqlCommand(strSQLStatement, conn)
        conn.Open()
        drCartLine = cmdSQL.ExecuteReader()
        If Integer.TryParse(tbQuantity.Value, 0) Then
            If tbQuantity.Value > 0 Then

                If drCartLine.Read() Then

                    'Show error msg if product already in cart
                    'lblError.Visible = True
                    'lblError.Text = "This Product is Already In Your Cart"

                    'Update And add qty if product already in cart
                    conn.Close()
                    strSQLStatement = "Update Cart set Quantity = Quantity + '" & CInt(tbQuantity.Value) & "' where ProductID = '" & lblProductNo.Text & "' and CartID = '" & strCartID & "'"
                    cmdSQL = New SqlCommand(strSQLStatement, conn)
                    conn.Open()
                    drCartLine = cmdSQL.ExecuteReader(CommandBehavior.CloseConnection)
                    Response.Redirect("ViewCart.aspx")
                Else

                    conn.Close()
                    strSQLStatement = "INSERT INTO Cart (CartID, ProductID, ProductName, Quantity, Price) values('" & strCartID & "', '" & Trim(lblProductNo.Text) & "', '" & lblProductName.Text & "', " & CInt(tbQuantity.Value) & ", " & sngPrice & ")"
                    cmdSQL = New SqlCommand(strSQLStatement, conn)
                    conn.Open()
                    drCartLine = cmdSQL.ExecuteReader(CommandBehavior.CloseConnection)
                    Response.Redirect("ViewCart.aspx")
                End If
                conn.Close()
            End If
        Else
            lblError.Visible = True
            lblError.Text = "Quantity Entered is Invalid"
        End If
    End Sub



    Public Function GetRandomCartIDUsingGUID(ByVal length As Integer) As String
        'Get the GUID
        Dim guidResult As String = System.Guid.NewGuid().ToString()
        'Remove the hyphens
        guidResult = guidResult.Replace("-", String.Empty)
        'Make sure length is valid
        If length <= 0 OrElse length > guidResult.Length Then
            Throw New ArgumentException("Length must be between 1 and " & guidResult.Length)
        End If
        'Return the first length bytes
        Return guidResult.Substring(0, length)
    End Function
End Class
