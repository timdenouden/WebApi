Imports Microsoft.VisualBasic

Public Class Product
    Private _productID As Integer
    Public Property productID() As Integer
        Get
            Return _productID
        End Get
        Set(ByVal value As Integer)
            _productID = value
        End Set
    End Property

    Private _productNo As String
    Public Property productNo() As String
        Get
            Return _productNo
        End Get
        Set(value As String)
            _productNo = value
        End Set
    End Property

    Private _productName As String
    Public Property productName() As String
        Get
            Return _productName
        End Get
        Set(value As String)
            _productName = value
        End Set
    End Property

    Private _productDescription As String
    Public Property productDescription() As String
        Get
            Return _productDescription
        End Get
        Set(value As String)
            _productDescription = value
        End Set
    End Property

    Private _price As Decimal
    Public Property price() As Decimal
        Get
            Return _price
        End Get
        Set(value As Decimal)
            _price = value
        End Set
    End Property

    Private _subCategoryID As Integer
    Public Property subCategoryID() As Integer
        Get
            Return _subCategoryID
        End Get
        Set(value As Integer)
            _subCategoryID = value
        End Set
    End Property

    Private _featured As String
    Public Property featured() As String
        Get
            Return _featured
        End Get
        Set(value As String)
            _featured = value
        End Set
    End Property

    Private _mainCategoryId As Integer
    Public Property mainCategoryId() As Integer
        Get
            Return _mainCategoryId
        End Get
        Set(value As Integer)
            _mainCategoryId = value
        End Set
    End Property
End Class
