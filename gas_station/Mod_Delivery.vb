Imports System.Data.SQLite
Imports System.Text

Module Mod_Delivery
    Public sqliteDataAdapter As SQLiteDataAdapter
    Public dataSet As DataSet
    Public Sub Load_Delivery_Data()

        Try

            SQLite_Open_Connection()

            dataSet = New DataSet

            sqliteDataAdapter = New SQLiteDataAdapter("SELECT tbl_delivery.delivery_id AS 'ID', tbl_supplier.companyname AS 'COMPANY',tbl_delivery.delivered_grandtotal AS 'GRAND TOTAL',
            tbl_delivery.delivery_discount AS 'DISCOUNT',tbl_delivery.delivered_date AS 'DATE' FROM tbl_supplier INNER JOIN tbl_delivery 
            ON tbl_delivery.supplier_id = tbl_supplier.supplier_id", sqliteConnection)

            sqliteDataAdapter.Fill(dataSet, "tbl_delivery")

            Form_Main.dgvDelivery.DataSource = dataSet.Tables(0)

        Catch ex As SQLiteException

            MessageBox.Show("Error: " & ex.Message)
            SQLite_Close_Connection()
        End Try

    End Sub
    Public Sub Search_Delivery_Data(ByVal searchDelivery As String)
        Try
            SQLite_Open_Connection()

            Dim searchResultsTable As New DataTable()

            Dim searchColumns As New List(Of String) From {"tbl_supplier.companyname"}

            Dim searchVariable As String = searchDelivery

            Dim whereClause As New StringBuilder()
            For Each column As String In searchColumns
                whereClause.Append("LOWER(" & column & ") LIKE @search OR ")
            Next

            whereClause.Length -= 4

            Dim query As String = "SELECT tbl_delivery.delivery_id AS 'ID', tbl_supplier.companyname AS 'COMPANY',tbl_delivery.delivered_grandtotal AS 'GRAND TOTAL', tbl_delivery.delivery_discount AS 'DISCOUNT',tbl_delivery.delivered_date AS 'DATE' FROM tbl_supplier 
            INNER JOIN tbl_delivery ON tbl_delivery.supplier_id = tbl_supplier.supplier_id 
            WHERE (" & whereClause.ToString() & ") " &
                  "COLLATE NOCASE;"

            Using adapter As New SQLiteDataAdapter(query, sqliteConnection)
                adapter.SelectCommand.Parameters.AddWithValue("@search", searchVariable & "%")
                adapter.Fill(searchResultsTable)
                Form_Main.dgvDelivery.DataSource = searchResultsTable
            End Using
        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message)
        End Try
    End Sub

End Module
