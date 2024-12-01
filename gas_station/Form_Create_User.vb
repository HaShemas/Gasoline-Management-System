Public Class Form_Create_User
    Private Sub btnCreateAcc_Click(sender As Object, e As EventArgs) Handles btnCreateAcc.Click
        Dim fname As String = txtCfname.Text
        Dim lname As String = txtClname.Text
        Dim username As String = txtCusername.Text
        Dim password As String = txtCpassword.Text
        Dim status_id As Integer = 1
        Dim usertype_id As Integer = 2
        Create_Account(fname, lname, username, password, usertype_id, status_id)
        Load_User()

        Me.Close()
    End Sub

    Private Sub btnAcancel_Click(sender As Object, e As EventArgs) Handles btnAcancel.Click
        Me.Close()
    End Sub

    Private Sub Form_Create_User_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class