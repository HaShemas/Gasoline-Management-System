Imports System.Data.Entity.Core
Imports System.Data.SQLite

Module Mod_Inventory
    Public sqliteDataAdapter As SQLiteDataAdapter
    Public dataSet As DataSet
    Public currentStocks As Double
    Public Sub Load_Inventory_Data()

        Try

            SQLite_Open_Connection()

            dataSet = New DataSet

            sqliteDataAdapter = New SQLiteDataAdapter("SELECT tbl_inventory.inventory_id AS 'ID',tbl_category.gasType AS 'TYPE', ROUND(tbl_inventory.stock_liters, 2) AS 'STOCKS',tbl_inventory.date_updated AS 'DATE UPDATED' FROM tbl_inventory INNER JOIN tbl_category ON tbl_category.category_id = tbl_inventory.category_id", sqliteConnection)

            sqliteDataAdapter.Fill(dataSet, "tbl_inventory")

            Form_Main.dgvInventory.DataSource = dataSet.Tables(0)

        Catch ex As SQLiteException

            MessageBox.Show("Error: " & ex.Message)
            SQLite_Close_Connection()

        End Try

    End Sub

    Public Sub UpdateStocksBasedOnLiters(ByVal liters As Double, ByVal category_id As Integer)
        Try
            SQLite_Open_Connection()

            ' Assuming you have a column named "category_id" in your tbl_inventory table
            Using updateStocksCmd As New SQLiteCommand("UPDATE tbl_inventory SET stock_liters = stock_liters + @liters, date_updated = date() WHERE category_id = @category_id;", sqliteConnection)
                updateStocksCmd.Parameters.AddWithValue("@liters", liters)
                updateStocksCmd.Parameters.AddWithValue("@category_id", category_id)
                updateStocksCmd.ExecuteNonQuery()
            End Using

        Catch ex As Exception
            MessageBox.Show("Error updating stocks: " & ex.Message)
            SQLite_Close_Connection()
        End Try
    End Sub

    ''STOCK OUT
    Public Sub UpdateStocks(ByVal liters As Double, ByVal category_id As Integer)
        Try
            ' Ensure the connection is open
            SQLite_Open_Connection()

            ' Check if there are sufficient stocks before updating
            Dim currentStocks As Double = CheckStocksBeforeUpdate(category_id)

            ' Check if subtracting the liters will result in negative stocks
            If currentStocks >= liters Then
                ' Update stocks
                Using updateStocksCmd As New SQLiteCommand("UPDATE tbl_inventory SET stock_liters = stock_liters - @liters WHERE category_id = @category_id;", sqliteConnection)
                    updateStocksCmd.Parameters.AddWithValue("@liters", liters)
                    updateStocksCmd.Parameters.AddWithValue("@category_id", category_id)
                    updateStocksCmd.ExecuteNonQuery()
                End Using
            Else
                MessageBox.Show("Insufficient stocks.")
            End If
        Catch ex As Exception
            MessageBox.Show($"Error in UpdateStocks: {ex.Message}")
        Finally
            ' Close the connection
            'SQLite_Close_Connection()
        End Try
    End Sub

    Public Function CheckStocksBeforeUpdate(ByVal category_id As Integer) As Double
        Try
            ' Ensure the connection is open
            SQLite_Open_Connection()

            Dim query As String = "SELECT stock_liters FROM tbl_inventory WHERE category_id = @category_id;"
            Using cmd As New SQLiteCommand(query, sqliteConnection)
                cmd.Parameters.AddWithValue("@category_id", category_id)
                Return Convert.ToDouble(cmd.ExecuteScalar())
            End Using
        Catch ex As Exception
            MessageBox.Show($"Error in CheckStocksBeforeUpdate: {ex.Message}")
            Return 0 ' Return a default value or handle the error accordingly
        Finally
            ' Close the connection
            'SQLite_Close_Connection()
        End Try
    End Function


    Public Sub Load_pInventory_Data()

        Try

            SQLite_Open_Connection()

            dataSet = New DataSet

            sqliteDataAdapter = New SQLiteDataAdapter("SELECT tbl_pInventory.pInventory_id AS 'ID',tbl_category.gasType AS 'TYPE',tbl_pInventory.physical_stocks AS 'PHYSICAL STOCKS',tbl_pInventory.date_measured AS 'DATE MEASURED' FROM tbl_pInventory 
                INNER JOIN tbl_category ON tbl_category.category_id = tbl_pInventory.category_id", sqliteConnection)

            sqliteDataAdapter.Fill(dataSet, "tbl_pInventory")

            Form_Main.dgvpInventory.DataSource = dataSet.Tables(0)

        Catch ex As SQLiteException

            MessageBox.Show("Error: " & ex.Message)
            SQLite_Close_Connection()

        End Try

    End Sub
    Public Function Update_pInventory(ByVal pStocks As Double, ByVal pInventory_id As Integer) As Double
        Dim updatedValue As Double = 0 ' Default value if something goes wrong

        Try
            SQLite_Open_Connection()

            Dim query As String = "UPDATE tbl_pInventory SET physical_stocks = @pStocks, date_measured = date() WHERE pInventory_id = @pInventory_id"

            Using cmd As New SQLiteCommand(query, sqliteConnection)
                cmd.Parameters.AddWithValue("@pStocks", pStocks)
                cmd.Parameters.AddWithValue("@pInventory_id", pInventory_id)

                cmd.ExecuteNonQuery()
            End Using

            ' After the update, query the updated value
            query = "SELECT physical_stocks FROM tbl_pInventory WHERE pInventory_id = @pInventory_id"

            Using cmd As New SQLiteCommand(query, sqliteConnection)
                cmd.Parameters.AddWithValue("@pInventory_id", pInventory_id)

                Dim result As Object = cmd.ExecuteScalar()
                If result IsNot Nothing AndAlso Not IsDBNull(result) Then
                    updatedValue = Convert.ToDouble(result)
                End If
            End Using

        Catch ex As SQLiteException
            MessageBox.Show("Error: " & ex.Message)
        Finally
            SQLite_Close_Connection()
        End Try

        Return updatedValue
    End Function


    'Public Sub compare(ByVal updatedValue As Double, ByVal ID As Integer)
    '    Try
    '        SQLite_Open_Connection()

    '        ' Query the system value from the database
    '        Dim query As String = "SELECT stock_liters FROM tbl_inventory WHERE inventory_id = @ID"

    '        Using cmd As New SQLiteCommand(query, sqliteConnection)
    '            cmd.Parameters.AddWithValue("@ID", ID)

    '            Dim systemValue As Object = cmd.ExecuteScalar()

    '            If systemValue IsNot Nothing AndAlso Not IsDBNull(systemValue) Then
    '                Dim systemStocks As Double = Convert.ToDouble(systemValue)

    '                ' Compare the updated physical value with the system value
    '                Dim stocksDifference As Double = updatedValue - systemStocks

    '                If stocksDifference > 0 Then
    '                    MessageBox.Show($"Physical stocks are greater than the system stocks." & vbCrLf & $" Difference: {Math.Abs(stocksDifference)} liters.", "Stocks Comparison", MessageBoxButtons.OK, MessageBoxIcon.Stop)
    '                ElseIf stocksDifference < 0 Then
    '                    MessageBox.Show($"System stocks are greater than the physical stocks." & vbCrLf & $" Difference: {Math.Abs(stocksDifference)} liters.", "Stocks Comparison", MessageBoxButtons.OK, MessageBoxIcon.Stop)
    '                Else
    '                    MessageBox.Show($"System stocks are equal to the physical stocks.", "Stocks Comparison", MessageBoxButtons.OK, MessageBoxIcon.Information)
    '                End If
    '            Else
    '                MessageBox.Show("No corresponding row found in the system stocks.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
    '            End If
    '        End Using
    '    Catch ex As Exception
    '        Console.WriteLine($"Error in compare: {ex.Message}")
    '    Finally
    '        SQLite_Close_Connection()
    '    End Try
    'End Sub
    Public Sub Compare(ByVal updatedValue As Double, ByVal inventoryID As Integer)
        Try
            SQLite_Open_Connection()

            ' Query the system value and gasType from the database
            Dim query As String = "SELECT tbl_inventory.stock_liters, tbl_category.gasType " &
                              "FROM tbl_inventory " &
                              "INNER JOIN tbl_category ON tbl_inventory.category_id = tbl_category.category_id " &
                              "WHERE tbl_inventory.inventory_id = @ID"

            Using cmd As New SQLiteCommand(query, sqliteConnection)
                cmd.Parameters.AddWithValue("@ID", inventoryID)

                Using reader As SQLiteDataReader = cmd.ExecuteReader()
                    If reader.Read() Then
                        ' Get the stock_liters and gasType values from the query result
                        Dim systemStocks As Double = Convert.ToDouble(reader("stock_liters"))
                        Dim gasType As String = reader("gasType").ToString()

                        ' Compare the updated physical value with the system value
                        Dim stocksDifference As Double = updatedValue - systemStocks

                        If stocksDifference > 0 Then
                            MessageBox.Show($"Physical stock of {gasType} is greater than the system stock of {gasType}." & vbCrLf & $" Difference: {Math.Abs(stocksDifference)} liters.", "Inventory Reconciliation", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                        ElseIf stocksDifference < 0 Then
                            MessageBox.Show($"System stock of {gasType} are greater than the physical stock  of {gasType}." & vbCrLf & $" Difference: {Math.Abs(stocksDifference)} liters.", "Inventory Reconciliation", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                        Else
                            MessageBox.Show($"No Discrepancy.", "Inventory Reconciliation", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        End If
                    Else
                        MessageBox.Show("No corresponding row found in the system stocks.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    End If
                End Using
            End Using
        Catch ex As Exception
            Console.WriteLine($"Error in Compare: {ex.Message}")
            ' Log the exception details here if needed
        Finally
            SQLite_Close_Connection()
        End Try
    End Sub

End Module
