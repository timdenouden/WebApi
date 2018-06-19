Imports System.Data
Imports System.Net.Http
Imports Newtonsoft.Json
Imports System.Runtime.CompilerServices
Imports System.Net.Http.Headers
Imports System.Drawing
Imports System.Data.SqlClient
Imports System.Text.RegularExpressions

Partial Class Account_Register
    Inherits System.Web.UI.Page
    Dim httpClient As New HttpClient
    Private sError As String

    Private Sub Account_Register_Load(sender As Object, e As EventArgs) Handles Me.Load

    End Sub

    Private Async Sub btnRegister_Click(sender As Object, e As EventArgs) Handles btnRegister.Click
        If ValidatePassword(txtPassword.Value) = True Then
            If txtPassword.Value = txtConfirmPassword.Value Then
                Dim myJson As String
                myJson = ("{'email': '" & txtEmail.Value & "', 'password': '" & txtPassword.Value & "', 'RegistrationCode': '" & txtCode.Value.ToUpper & "'}")

                Dim uri As String = "https://localhost:44338/account/register"
                Dim task = Await httpClient.PostAsync(uri, New StringContent(myJson, Encoding.UTF8, "application/json"))
                Dim jwtToken As String

                If task.IsSuccessStatusCode Then
                    jwtToken = Await task.Content.ReadAsStringAsync()
                    lblRegisterResult.Text = "Successful Registration"
                    lblRegisterResult.ForeColor = Color.Green
                    lblRegisterResult.Visible = True

                    Dim tokenCookie As New HttpCookie("JwtCookie")
                    tokenCookie.HttpOnly = True
                    'tokenCookie.Secure = True //use if HTTPS for added security
                    tokenCookie("JWT") = jwtToken
                    tokenCookie.Expires = Now.AddHours(1)
                    Response.Cookies.Add(tokenCookie)
                Else
                    lblRegisterResult.Text = "Incorrect Registration Code"
                    lblRegisterResult.ForeColor = Color.Red
                    lblRegisterResult.Visible = True
                End If
            Else
                lblRegisterResult.Text = "Passwords don't match"
                lblRegisterResult.ForeColor = Color.Red
                lblRegisterResult.Visible = True
            End If
        Else
            lblRegisterResult.Text = "Password needs to be at least 6 characters with 1 number, 1 upper case, 1 lower case, and 1 special character"
            lblRegisterResult.ForeColor = Color.Red
            lblRegisterResult.Visible = True
        End If



    End Sub

    Function ValidatePassword(ByVal pwd As String,
        Optional ByVal minLength As Integer = 6,
        Optional ByVal numUpper As Integer = 1,
        Optional ByVal numLower As Integer = 1,
        Optional ByVal numNumbers As Integer = 1,
        Optional ByVal numSpecial As Integer = 1) As Boolean

        ' Replace [A-Z] with \p{Lu}, to allow for Unicode uppercase letters.
        Dim upper As New System.Text.RegularExpressions.Regex("[A-Z]")
        Dim lower As New System.Text.RegularExpressions.Regex("[a-z]")
        Dim number As New System.Text.RegularExpressions.Regex("[0-9]")
        ' Special is "none of the above".
        Dim special As New System.Text.RegularExpressions.Regex("[^a-zA-Z0-9]")

        ' Check the length.
        If Len(pwd) < minLength Then Return False
        ' Check for minimum number of occurrences.
        If upper.Matches(pwd).Count < numUpper Then Return False
        If lower.Matches(pwd).Count < numLower Then Return False
        If number.Matches(pwd).Count < numNumbers Then Return False
        If special.Matches(pwd).Count < numSpecial Then Return False

        ' Passed all checks.
        Return True
    End Function

End Class
