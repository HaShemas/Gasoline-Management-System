Imports System.Data.SQLite
Imports System.Text

Module Mod_Sales
    Public sqliteDataAdapter As SQLiteDataAdapter
    Public dataSet As DataSet
    Public Sub Load_Sales_Data()

        Try

            SQLite_Open_Connection()

            dataSet = New DataSet

            sqliteDataAdapter = New SQLiteDataAdapter("SELECT tbl_sales.sale_id AS 'ID', tbl_customer.customername AS 'CUSTOMER NAME',tbl_sales.sale_grandtotal AS 'GRAND TOTAL',tbl_sales.received_amount AS 'AMOUNT',
            tbl_sales.sale_discount AS 'DISCOUNT',tbl_sales.change AS 'CHANGE',tbl_sales.sale_date AS 'DATE' FROM tbl_customer INNER JOIN tbl_sales 
            ON tbl_sales.customer_id = tbl_customer.customer_id", sqliteConnection)

            sqliteDataAdapter.Fill(dataSet, "tbl_sales")

            Form_Main.dgvSale.DataSource = dataSet.Tables(0)

        Catch ex As SQLiteException

            MessageBox.Show("Error: " & ex.Message)
            SQLite_Close_Connection()
        End Try

    End Sub
    Public Sub Search_Sales_Data(ByVal searchSales As String)
        Try
            SQLite_Open_Connection()

            Dim searchResultsTable As New DataTable()

            Dim searchColumns As New List(Of String) From {"tbl_customer.customername"}

            Dim searchVariable As String = searchSales

            Dim whereClause As New StringBuilder()
            For Each column As String In searchColumns
                whereClause.Append("LOWER(" & column & ") LIKE @search OR ")
            Next

            whereClause.Length -= 4

            Dim query As String = "SELECT tbl_sales.sale_id AS 'ID', tbl_customer.customername AS 'CUSTOMER NAME',tbl_sales.sale_grandtotal AS 'GRAND TOTAL',tbl_sales.received_amount AS 'AMOUNT',
            tbl_sales.sale_discount AS 'DISCOUNT',tbl_sales.change AS 'CHANGE',tbl_sales.sale_date AS 'DATE' FROM tbl_customer INNER JOIN tbl_sales 
            ON tbl_sales.customer_id = tbl_customer.customer_id WHERE (" & whereClause.ToString() & ") " &
                  "COLLATE NOCASE;"

            Using adapter As New SQLiteDataAdapter(query, sqliteConnection)
                adapter.SelectCommand.Parameters.AddWithValue("@search", searchVariable & "%")
                adapter.Fill(searchResultsTable)
                Form_Main.dgvSale.DataSource = searchResultsTable
            End Using
        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message)
        End Try
    End Sub
End Module
