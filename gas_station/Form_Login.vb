Imports System.Drawing.Text

Public Class Form_Login

    Dim username, password As String
    Private Sub btnLogin_Click(sender As Object, e As EventArgs) Handles btnLogin.Click
        username = txtUsername.Text
        password = txtPassword.Text
        If ValidateLogin(username, password) Then
            If LoggedInuserstatus = 1 Then
                If LoggedInusertypeId = 1 Then
                    If IsAdminUser(username) Then

                        Form_Main.txtUsertype.Text = LoggedInusertype

                        MessageBox.Show("Welcome, Admin!", "SUCCESS!", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    End If
                ElseIf LoggedInusertypeId = 2 Then

                    Form_Main.btnManageUser.Hide()


                    Form_Main.txtUsertype.Text = LoggedInusertype
                    MessageBox.Show("Welcome, User!", "SUCCESS!", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If
                Load_User()
                Me.Hide()
                Form_Main.Show()
            End If

        Else
            MessageBox.Show("Invalid username or password. Please try again.", "INVALID!", MessageBoxButtons.OK, MessageBoxIcon.Warning)

        End If
        txtUsername.Text = ""
        txtPassword.Text = ""
    End Sub

    Private Sub Form_Login_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub chkPass_CheckedChanged(sender As Object, e As EventArgs) Handles chkPass.CheckedChanged
        If chkPass.Checked Then

            txtPassword.UseSystemPasswordChar = True
        Else

            txtPassword.UseSystemPasswordChar = False
        End If

    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Environment.Exit(0)
        Me.Close()
    End Sub
End Class
