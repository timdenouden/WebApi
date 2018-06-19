
Partial Class Category
    Inherits System.Web.UI.Page
    Public intMainCategoryID As Integer
    Public strMainCategoryName As String
    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        If Request.QueryString("MainCategoryID") <> "" And Request.QueryString("MainCategoryName") <> "" Then
            intMainCategoryID = CInt(Request.QueryString("MainCategoryID"))
            strMainCategoryName = Request.QueryString("MainCategoryName")
            sqlDSSubCategory.SelectCommand = "Select * From Category Where parent = " & intMainCategoryID
            lblMainCategoryName.Text = strMainCategoryName
        Else
            Response.Redirect("Default.aspx")
        End If
        If Request.QueryString("SubCategoryID") <> "" Then
            SqlDSProductList.SelectCommand = "Select * From Product Where SubCategoryID = " & CInt(Request.QueryString("SubCategoryID"))
            lblProductList.Text = Request.QueryString("SubCategoryName")
        Else
            SqlDSProductList.SelectCommand = "Select * From Product Where MainCategoryID = " & intMainCategoryID & " And Featured = 'Y'"
        End If

    End Sub
End Class
