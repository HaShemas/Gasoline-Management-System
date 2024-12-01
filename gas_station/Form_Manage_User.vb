Public Class Form_Manage_User
    Private Sub manage_user_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub btnUserSales_Click(sender As Object, e As EventArgs) Handles btnUserSales.Click
        If dgvUser.SelectedRows.Count > 0 Then
            Dim selectedRow As DataGridViewRow = dgvUser.SelectedRows(0)
            Dim user_id As Integer = CInt(selectedRow.Cells("ID").Value)
            Load_User_Sales(Form_User_Sales.dgvUserSales, user_id)
            Form_User_Sales.ShowDialog()
        End If
    End Sub

    Private Sub btnBackMain_Click(sender As Object, e As EventArgs) Handles btnBackMain.Click
        Me.Close()
    End Sub

    Private Sub btnToggle_Click(sender As Object, e As EventArgs) Handles btnToggle.Click
        If dgvUser.SelectedRows.Count > 0 Then
            Dim selectedRow As DataGridViewRow = dgvUser.SelectedRows(0)
            Dim user_ids As Integer = CInt(selectedRow.Cells(0).Value)
            If user_ids > 0 Then
                Toggle_User_Status(user_ids)
                Load_User()
            Else
                MessageBox.Show("Please select a user to toggle.")
            End If
        End If
    End Sub
End Class