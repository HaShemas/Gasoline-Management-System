Imports System.Data.SQLite

Module Mod_Report
    Public Sub Sales_Report()
        Try
            SQLite_Open_Connection()
            Dim selectedDate As Date = Form_Main.dtpDay.Value

            Dim cmd As SQLiteCommand = New SQLiteCommand("SELECT tbl_sales.sale_id AS 'ID', tbl_customer.customername AS 'CUSTOMER NAME', tbl_user.firstname AS 'CASHIER', tbl_sales.sale_grandtotal AS 'GRAND TOTAL', tbl_sales.received_amount AS 'RECEIVED AMOUNT', tbl_sales.sale_discount AS 'DISCOUNT', tbl_sales.change AS 'CHANGE', tbl_sales.sale_date AS 'DATE'
                                    FROM tbl_sales INNER JOIN tbl_customer ON tbl_customer.customer_id = tbl_sales.customer_id 
                                    INNER JOIN tbl_user ON tbl_user.user_id = tbl_customer.user_id 
                                    WHERE tbl_sales.sale_date BETWEEN @startDate AND @endDate;", sqliteConnection)

            ' Format the date in ISO 8601 format ("YYYY-MM-DD")
            cmd.Parameters.AddWithValue("@startDate", selectedDate.ToString("yyyy-MM-dd"))
            cmd.Parameters.AddWithValue("@endDate", selectedDate.AddDays(0).ToString("yyyy-MM-dd"))

            Dim adapter As New SQLiteDataAdapter(cmd)
            Dim dataTable As New DataTable()
            adapter.Fill(dataTable)


            Form_Main.dgvReport.DataSource = Nothing


            If dataTable.Rows.Count > 0 Then
                Form_Main.dgvReport.DataSource = dataTable
            Else

            End If
        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message)
        End Try
    End Sub
End Module
