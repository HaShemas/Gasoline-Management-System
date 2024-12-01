Imports System.Data.SQLite

Module Mod_User_Sales
    Public sqliteDataAdapter As SQLiteDataAdapter
    Public dataSet As DataSet

    Public Sub Load_User_Sales(ByVal dataGridView As DataGridView, ByVal user_id As Integer)

        Try

            SQLite_Open_Connection()
            Dim dataTable As New DataTable


            Dim query As String = "SELECT tbl_sales.sale_id AS 'ID', tbl_customer.customername AS 'ATTENDANT',tbl_sales.sale_grandtotal AS 'GRAND TOTAL',tbl_sales.received_amount AS 'AMOUNT',
            tbl_sales.sale_discount AS 'DISCOUNT',tbl_sales.change AS 'CHANGE',tbl_sales.sale_date AS 'DATE' FROM tbl_customer 
			INNER JOIN tbl_sales ON tbl_sales.customer_id = tbl_customer.customer_id 
			INNER JOIN tbl_user ON tbl_user.user_id = tbl_customer.user_id
			WHERE tbl_user.user_id = @user_id"
            Using command As New SQLiteCommand(query, sqliteConnection)
                command.Parameters.AddWithValue("@user_id", user_id)
                Dim adapter As New SQLiteDataAdapter(command)
                adapter.Fill(dataTable)
            End Using
            dataGridView.DataSource = dataTable

        Catch ex As SQLiteException

            MessageBox.Show("Error: " & ex.Message)
            SQLite_Close_Connection()
        End Try

    End Sub

End Module
