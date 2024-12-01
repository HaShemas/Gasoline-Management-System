
Imports System.Data.SqlClient
Imports System.Data.SQLite
Imports System.Transactions

Public Class Form_CRUD_Del
    Public disableCellClick As Boolean = False
    Public Deliveries, lastClickedPictureBox As PictureBox
    Dim selectedTabIndex As Integer
    Dim selectedTab As TabPage
    Dim liters, amount, price As Double
    Dim totalamount = 0
    Public valuesList As New List(Of String)()
    Dim deliveryId As Integer = Mod_Add_Delivery.insertedDeliveryId

    Dim supplierName, tabpages, tblproduct, product As String
    Dim paidAmount, delDiscount, grandTotal, change, delLiters, delLprice, totalLiters, litersAmount As Double
    Dim dscnt, tblLiters, tblPrice, tblAmount As Double
    Dim selectedRow As DataGridViewRow
    Dim finaltotal, grand As Double
    Public originalTotalAmount As Double

    Public Sub adding_update_delivery__Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Load_Inventory_Data()

    End Sub
    Public Sub Delivery_Click(sender As Object, e As EventArgs) Handles delDiesel.Click, delPremium.Click, delRegular.Click
        If TypeOf sender Is PictureBox Then
            Deliveries = DirectCast(sender, PictureBox)
            delDiesel.BorderStyle = BorderStyle.None
            delPremium.BorderStyle = BorderStyle.None
            delRegular.BorderStyle = BorderStyle.None
            Deliveries.BorderStyle = BorderStyle.Fixed3D
            If Deliveries Is delDiesel Then
                Deliveries.Tag = "Diesel"
            ElseIf Deliveries Is delPremium Then
                Deliveries.Tag = "Premium"
            ElseIf Deliveries Is delRegular Then
                Deliveries.Tag = "Regular"
            End If
            lastClickedPictureBox = Deliveries
        Else
            MessageBox.Show("Please select a product.")
        End If
    End Sub

    Public Sub dgvDelCart_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvDelCart.CellClick
        If e.RowIndex >= 0 AndAlso e.RowIndex < dgvDelCart.Rows.Count Then
            If disableCellClick = True Then
                If dgvDelCart.SelectedRows.Count > 0 Then
                    selectedRow = dgvDelCart.SelectedRows(0)

                    ' Check if selectedRow is not Nothing
                    If selectedRow IsNot Nothing Then
                        tblproduct = selectedRow.Cells("Product").Value?.ToString()
                        tblLiters = CDbl(selectedRow.Cells("Liters").Value)
                        tblPrice = CDbl(selectedRow.Cells("Price").Value)
                        tblAmount = CDbl(selectedRow.Cells("Amount").Value)

                        Select Case tblproduct
                            Case "Diesel"
                                Delivery_Click(delDiesel, New EventArgs())
                            Case "Premium"
                                Delivery_Click(delPremium, New EventArgs())
                            Case "Regular"
                                Delivery_Click(delRegular, New EventArgs())
                        End Select
                        txtdelLiters.Text = tblLiters
                        txtdelLprice.Text = tblPrice

                    Else
                        ' Handle the case when selectedRow is Nothing
                        MessageBox.Show("Selected row is null.")
                    End If
                End If
            End If
        End If
    End Sub

    'Public Sub btnReceiptDel_Click(sender As Object, e As EventArgs) Handles btnOK.Click
    '    If Form_Main.dgvDelivery.SelectedRows.Count > 0 Then
    '        Dim selectedRow As DataGridViewRow = Form_Main.dgvDelivery.SelectedRows(0)
    '        Dim ID As Integer = CInt(selectedRow.Cells("ID").Value)
    '        PrintReceipt(ID)
    '    End If


    'End Sub

    Public Sub btnDeletedel_Click(sender As Object, e As EventArgs) Handles btnDeletedel.Click
        If dgvDelCart.SelectedRows.Count = 1 Then
            Dim selectedRow As DataGridViewRow = dgvDelCart.SelectedRows(0)
            Dim Amount As Double = CDbl(selectedRow.Cells("Amount").Value)

            dgvDelCart.Rows.Remove(selectedRow)
            litersAmount = CalculateLitersAmount() ' Recalculate the total amount
            UpdateTotalAmount()
            ClearInputFields()

        End If
    End Sub

    Public Function CalculateLitersAmount() As Double
        Dim total As Double = 0

        For Each row As DataGridViewRow In dgvDelCart.Rows
            Dim rowAmount As Double = CDbl(row.Cells("Amount").Value)
            total += rowAmount
        Next

        Return total
    End Function

    Public Sub btnAddDel_Click(sender As Object, e As EventArgs) Handles btnAddDel.Click
        ' Get product information
        If lastClickedPictureBox Is Nothing Then
            MessageBox.Show("Please select a product.")
        ElseIf String.IsNullOrWhiteSpace(txtdelLiters.Text) OrElse String.IsNullOrWhiteSpace(txtdelLprice.Text) Then
            MessageBox.Show("Put valid number.")
        ElseIf Not Double.TryParse(txtdelLiters.Text, Nothing) AndAlso Not Double.TryParse(txtdelLprice.Text, Nothing) Then
            MessageBox.Show("Put a number.")
        Else

            product = Deliveries.Tag
            delLiters = CDbl(txtdelLiters.Text)
            delLprice = CDbl(txtdelLprice.Text)
            totalLiters = delLprice * delLiters

            ' Check if the product already exists in the DataGridView
            Dim existingRow As DataGridViewRow = Nothing
            For Each row As DataGridViewRow In dgvDelCart.Rows
                If row.Cells("Product").Value IsNot Nothing AndAlso
           CStr(row.Cells("Product").Value) = product Then
                    existingRow = row
                    Exit For
                End If
            Next

            ' If the product exists, add delLiters to existing value and update price and amount
            If existingRow IsNot Nothing Then
                Dim existingLiters As Double = CDbl(existingRow.Cells("Liters").Value)
                existingRow.Cells("Liters").Value = existingLiters + delLiters
                existingRow.Cells("Price").Value = delLprice
                existingRow.Cells("Amount").Value = delLprice * (existingLiters + delLiters)
            Else
                ' If the product doesn't exist, add a new row
                dgvDelCart.Rows.Add(product, delLiters, delLprice, totalLiters)
            End If

            ' Update total amount
            UpdateTotalAmount()
        End If

        ' Clear input fields
        txtdelLiters.Clear()
        txtdelLprice.Clear()
        lblLitersAmnt.Text = "0" ' Assuming lblLitersAmnt is a label to display liters amount
    End Sub

    Public Sub UpdateTotalAmount()
        ' Calculate total amount based on the amounts of rows in the DataGridView
        litersAmount = CalculateLitersAmount()
        grand = finaltotal + litersAmount
        lbltotalAmount.Text = grand.ToString()
    End Sub



    Public Sub ClearInputFields()
        ' Clear input fields after adding a row

        txtDelDiscnt.Clear()
        txtdelLiters.Clear()
        txtdelLprice.Clear()

    End Sub


    Public Sub btnDelCancel_Click(sender As Object, e As EventArgs) Handles btnDelCancel.Click
        Form_Main.Form_CreateDel.dgvDelCart.Columns.Clear()
        Form_Main.Form_CreateDel.dgvDelCart.Rows.Clear()
        Form_Main.Form_CreateDel.Close()

    End Sub

    Public Sub btnUpdateDel_Click(sender As Object, e As EventArgs) Handles btnUpdateDel.Click
        If dgvDelCart.SelectedRows.Count = 1 Then
            Dim selectedRow As DataGridViewRow = dgvDelCart.SelectedRows(0)
            Dim updproduct As String = Deliveries.Tag

            ' Get the current values in the selected row
            Dim currentLiters As Double = CDbl(selectedRow.Cells("Liters").Value)
            Dim currentPrice As Double = CDbl(selectedRow.Cells("Price").Value)

            ' Update the selected row with new values
            'selectedRow.Cells("Product").Value = updproduct
            selectedRow.Cells("Liters").Value = delLiters ' Update Liters directly
            selectedRow.Cells("Price").Value = delLprice
            selectedRow.Cells("Amount").Value = delLprice * delLiters ' Recalculate Amount based on new Liters and Price

        End If

        ' Recalculate the total amount after the update
        UpdateTotalAmount()

        ' Clear input fields
        ClearInputFields()
    End Sub




    Public Sub btnDelConfirm_Click(sender As Object, e As EventArgs) Handles btnDelConfirm.Click
        SQLite_Open_Connection()
        Using transaction As SQLiteTransaction = sqliteConnection.BeginTransaction()
            Try


                If String.IsNullOrWhiteSpace(cmbSupplier.Text) Then
                    MessageBox.Show("Please choose a supplier.")
                ElseIf lastClickedPictureBox Is Nothing Then
                    MessageBox.Show("Please select a product.")
                ElseIf Form_Main.Form_CreateDel.dgvDelCart.Rows.Count = 0 Then
                    MessageBox.Show("No Existing DATA!")
                    Form_Main.Form_CreateDel.txtDelDiscnt.Clear()
                Else
                    Dim liters As Double
                    Dim price As Double
                    Dim amounts As Double
                    Dim category_id, inventory_id As Integer
                    For Each row As DataGridViewRow In Form_Main.Form_CreateDel.dgvDelCart.Rows
                        If row.Cells("Product") IsNot Nothing AndAlso row.Cells("Product").Value IsNot Nothing Then
                            Dim product As String = row.Cells("Product").Value.ToString()


                            If Double.TryParse(row.Cells("Liters").Value.ToString(), liters) AndAlso
                                    Double.TryParse(row.Cells("Price").Value.ToString(), price) AndAlso
                                    Double.TryParse(row.Cells("Amount").Value.ToString(), amounts) Then

                                If product = "Diesel" Then
                                    category_id = 1
                                    inventory_id = 1
                                ElseIf product = "Premium" Then
                                    category_id = 2
                                    inventory_id = 2
                                ElseIf product = "Regular" Then
                                    category_id = 3
                                    inventory_id = 3
                                Else

                                End If

                                Dim values As String = $"({liters}, {price}, {amounts}, {category_id}, {inventory_id}, {deliveryId})"
                                Form_Main.Form_CreateDel.valuesList.Add(values)
                                UpdateStocksBasedOnLiters(liters, category_id)
                            Else
                                MessageBox.Show("Error: One or more values in the DataGridView are not valid numbers.")
                            End If
                        End If
                    Next

                    If Form_Main.Form_CreateDel.valuesList.Count > 0 Then
                        supplierName = txtSuppID.Text
                        'tbl_delivery
                        Insert_DeliveryData(litersAmount, dscnt, valuesList)
                    End If
                    transaction.Commit()
                    Load_Delivery_Data()
                    Load_Inventory_Data()
                    getPrice()
                    valuesList.Clear()
                    Form_Main.Form_CreateDel.valuesList.Clear()
                    Form_Main.Form_CreateDel.dgvDelCart.Columns.Clear()
                    Form_Main.Form_CreateDel.dgvDelCart.Rows.Clear()
                    Form_Main.Form_CreateDel.txtDelDiscnt.Clear()
                    Form_Main.Form_CreateDel.txtdelLiters.Clear()
                    Form_Main.Form_CreateDel.lbltotalAmount.Text = ""
                    Form_Main.Form_CreateDel.Close()
                End If

            Catch ex As Exception
                transaction.Rollback()
                MessageBox.Show($"Error: {ex.Message}")
                SQLite_Close_Connection()
            End Try
        End Using
    End Sub

    Public Sub txtdelLiters_TextChanged(sender As Object, e As EventArgs) Handles txtdelLiters.TextChanged
        LiterPriceCalculation()
    End Sub

    Public Sub txtdelLprice_TextChanged(sender As Object, e As EventArgs) Handles txtdelLprice.TextChanged
        LiterPriceCalculation()
    End Sub
    Public Sub LiterPriceCalculation()

        Try
            If Double.TryParse(txtdelLiters.Text, delLiters) AndAlso Double.TryParse(txtdelLprice.Text, delLprice) Then
                Dim result As Double = Math.Round((delLiters * delLprice), 2)
                lblLitersAmnt.Text = result
            Else

            End If
        Catch ex As Exception
            MessageBox.Show($"Error in AmountPriceCalculation: {ex.Message}")
        End Try
    End Sub
    Public Sub txtDelDiscnt_TextChanged(sender As Object, e As EventArgs) Handles txtDelDiscnt.TextChanged
        Try

            If String.IsNullOrWhiteSpace(txtDelDiscnt.Text) Then
                lbltotalAmount.Text = grand.ToString()



            Else
                Dim totalAmount As Double = grand
                Dim delDscnt As Double = txtDelDiscnt.Text
                dscnt = delDscnt / 100
                grandTotal = Math.Round(totalAmount - (totalAmount * dscnt), 2)
                lbltotalAmount.Text = grandTotal.ToString()


            End If


        Catch ex As Exception
            MessageBox.Show($"Error in totalAmountChangeCalculation: {ex.Message}")
        End Try
    End Sub

    Public Sub cmbSupplier_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbSupplier.SelectedIndexChanged
        Dim cmbSupp As String = cmbSupplier.Text

        SelectSupplier(cmbSupp)
    End Sub

    Private Sub btnOK_Click(sender As Object, e As EventArgs) Handles btnOK.Click

        Me.Close()
    End Sub

End Class