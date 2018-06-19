Imports System.Data
Imports System.Data.SqlClient
Partial Class ViewCart
    Inherits System.Web.UI.Page
    ' Public strCartID As String
    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        lblCartError.Visible = False

        Dim CookieBack As HttpCookie
        CookieBack = HttpContext.Current.Request.Cookies("CartID")
        Dim strCartID As String = CookieBack.Value
        ' if strCarID is null?????
        sqlDSCart.SelectCommand = "Select * From Cart Where CartID = '" & strCartID & "'"
        updateTotal()


    End Sub
    Protected Sub lvCart_OnItemCommand(ByVal sender As Object, ByVal e As ListViewCommandEventArgs)
        If e.CommandName = "cmdUpdate" Then
            ' get cartid from cookies, productid, and quantity
            Dim strCartID As String
            Dim CookieBack As HttpCookie
            CookieBack = HttpContext.Current.Request.Cookies("CartID")
            strCartID = CookieBack.Value
            Dim strProductID As String = e.CommandArgument
            Dim tbQuantity As TextBox = CType(e.Item.FindControl("tbQuantity"), TextBox)

            If Integer.TryParse(tbQuantity.Text, 0) Then
                If tbQuantity.Text > 0 Then

                    Dim strSQL As String = "Update Cart set Quantity = '" & CInt(tbQuantity.Text) & "' where ProductID = '" & strProductID & "' and CartID = '" & strCartID & "'"
                    ' update
                    Dim strConn As String = "Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\OnlineStore.mdf;Integrated Security=True"
                    Dim connCart As SqlConnection
                    Dim cmdCart As SqlCommand
                    Dim drCart As SqlDataReader
                    connCart = New SqlConnection(strConn)
                    cmdCart = New SqlCommand(strSQL, connCart)
                    connCart.Open()
                    drCart = cmdCart.ExecuteReader(CommandBehavior.CloseConnection)
                    sqlDSCart.DataBind()
                    lvCart.DataBind()
                    updateTotal()
                Else
                    lblCartError.Text = "Quantity Entered is Invalid"
                    lblCartError.Visible = True
                End If
            Else
                lblCartError.Text = "Quantity Entered is Invalid"
                lblCartError.Visible = True
            End If
        ElseIf e.CommandName = "cmdDelete" Then
                Dim strCartID As String
            Dim CookieBack As HttpCookie
            CookieBack = HttpContext.Current.Request.Cookies("CartID")
            strCartID = CookieBack.Value
            Dim strProductID As String = e.CommandArgument
            Dim strSQL As String = "Delete From Cart where ProductID = '" & strProductID & "' and CartID = '" & strCartID & "'"
            Dim strConn As String = "Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\OnlineStore.mdf;Integrated Security=True"
            Dim connCart As SqlConnection
            Dim cmdCart As SqlCommand
            Dim drCart As SqlDataReader
            connCart = New SqlConnection(strConn)
            cmdCart = New SqlCommand(strSQL, connCart)
            connCart.Open()
            drCart = cmdCart.ExecuteReader(CommandBehavior.CloseConnection)
            sqlDSCart.DataBind()
            lvCart.DataBind()
            updateTotal()

        End If
    End Sub

    Protected Sub DataPager1_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles DataPager1.PreRender
        Dim total_pages As Integer
        Dim current_page As Integer
        'sqlDSCart.SelectCommand = "Select * from cart"
        lvCart.DataBind()
        total_pages = DataPager1.TotalRowCount / DataPager1.PageSize
        current_page = DataPager1.StartRowIndex / DataPager1.PageSize + 1
        If DataPager1.TotalRowCount Mod DataPager1.PageSize <> 0 Then
            total_pages = total_pages + 1
        End If
        If CInt(lvCart.Items.Count) <> 0 Then
            Dim lbl As Label = lvCart.FindControl("lblPage")
            lbl.Text = "Page " + CStr(current_page) + " of " + CStr(total_pages) + " (Total items: " + CStr(DataPager1.TotalRowCount) + ")"
        End If
        If CInt(lvCart.Items.Count) = 0 Then
            DataPager1.Visible = False
            show_next.Visible = False
            show_prev.Visible = False
        End If
    End Sub

    Protected Sub show_prev_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles show_prev.Click
        Dim pagesize As Integer = DataPager1.PageSize
        Dim current_page As Integer = DataPager1.StartRowIndex / DataPager1.PageSize + 1
        Dim total_pages As Integer = DataPager1.TotalRowCount / DataPager1.PageSize
        Dim last As Integer = total_pages \ 3
        last = last * 3
        Do While current_page < last
            last = last - 3
        Loop
        If last < 3 Then
            last = 0
        Else
            last = last - 3
        End If
        DataPager1.SetPageProperties(last * pagesize, pagesize, True)
    End Sub

    Protected Sub show_next_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles show_next.Click
        Dim last As Integer = 3
        Dim pagesize As Integer = DataPager1.PageSize
        Dim current_page As Integer = DataPager1.StartRowIndex / DataPager1.PageSize + 1
        Dim total_pages As Integer = DataPager1.TotalRowCount / DataPager1.PageSize
        Do While current_page > last
            last = last + 3
        Loop
        If last > total_pages Then
            last = total_pages
        End If
        DataPager1.SetPageProperties(last * pagesize, pagesize, True)
    End Sub

    Private Sub btnClearCart_Click(sender As Object, e As EventArgs) Handles btnClearCart.Click
        Dim strCartID As String
        Dim CookieBack As HttpCookie
        CookieBack = HttpContext.Current.Request.Cookies("CartID")
        strCartID = CookieBack.Value
        Dim strSQL As String = "Delete From Cart where CartID = '" & strCartID & "'"
        Dim strConn As String = "Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\OnlineStore.mdf;Integrated Security=True"
        Dim connCart As SqlConnection
        Dim cmdCart As SqlCommand
        Dim drCart As SqlDataReader
        connCart = New SqlConnection(strConn)
        cmdCart = New SqlCommand(strSQL, connCart)
        connCart.Open()
        drCart = cmdCart.ExecuteReader(CommandBehavior.CloseConnection)
        sqlDSCart.DataBind()
        lvCart.DataBind()
        updateTotal()

    End Sub

    Public Function updateTotal()
        Dim intLineAmnt As Integer
        Dim strCartID As String
        Dim CookieBack As HttpCookie
        CookieBack = HttpContext.Current.Request.Cookies("CartID")
        strCartID = CookieBack.Value
        Dim strSQL As String = "Select COUNT(LineTotal) From Cart where CartID = '" & strCartID & "'"
        Dim strConn As String = "Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\OnlineStore.mdf;Integrated Security=True"
        Dim connCart As SqlConnection
        Dim cmdCart As SqlCommand
        connCart = New SqlConnection(strConn)
        cmdCart = New SqlCommand(strSQL, connCart)
        connCart.Open()
        intLineAmnt = (cmdCart.ExecuteScalar)
        connCart.Close()
        If (intLineAmnt) > 0 Then
            Dim strTotal2 As String
            Dim strCartID2 As String
            Dim CookieBack2 As HttpCookie
            CookieBack2 = HttpContext.Current.Request.Cookies("CartID")
            strCartID2 = CookieBack2.Value
            Dim strSQL2 As String = "Select SUM(LineTotal) From Cart where CartID = '" & strCartID2 & "'"
            Dim strConn2 As String = "Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\OnlineStore.mdf;Integrated Security=True"
            Dim connCart2 As SqlConnection
            Dim cmdCart2 As SqlCommand
            connCart2 = New SqlConnection(strConn2)
            cmdCart2 = New SqlCommand(strSQL2, connCart2)
            connCart2.Open()
            strTotal2 = (cmdCart2.ExecuteScalar).ToString
            lblTotal.Text = strTotal2
        Else
            lblTotal.Text = 0

        End If

    End Function
End Class
