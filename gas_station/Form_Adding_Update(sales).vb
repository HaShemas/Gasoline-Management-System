Imports System.Data.SQLite

Public Class Form_CRUD_sale
    Public disableCellClick As Boolean = False
    Public dprice, diesel, pprice, rprice As Double
    Public Sales, lastClickedPictureBox As PictureBox
    Dim selectedTabIndex As Integer
    Dim Samount, totalSamount, sLiters, Sprice, inpLiters, litersPriceAmount, SgrandTotal As Double

    Public valuesList As New List(Of String)()
    Dim customerName As String
    Dim sales_id As Integer = Mod_Add_Sales.insertedCustomerId
    Dim product, tblproduct As String
    Dim rcvdAmount, sLamount, salDiscount, totalgrand, dscnt, grandTotal, change, delLiters, delLprice, totalLiters, litersAmount, sdc As Double
    Dim finaltotal, grand As Double
    Public originalTotalAmount, SalesAmount, amprice, SalesLiters, sLprice As Double

    Public Sub btnSdel_Click(sender As Object, e As EventArgs) Handles btnSdel.Click

        If dgvCsale.SelectedRows.Count = 1 Then
            Dim selectedRow As DataGridViewRow = dgvCsale.SelectedRows(0)
            Dim Amount As Double = CDbl(selectedRow.Cells("Amount").Value)

            dgvCsale.Rows.Remove(selectedRow)
            litersAmount = CalculateLitersAmount() ' Recalculate the total amount
            UpdateTotalAmount()
            ClearInputFields()

        End If
    End Sub
    Public Function CalculateLitersAmount() As Double
        Dim total As Double = 0

        For Each row As DataGridViewRow In dgvCsale.Rows
            Dim rowAmount As Double = CDbl(row.Cells("Amount").Value)
            total += rowAmount
        Next

        Return total
    End Function

    Dim selectedRow As DataGridViewRow
    Dim tblLiters, tblPrice, tblAmount As Double

    Public Sub dgvCsale_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvCsale.CellClick
        If e.RowIndex >= 0 AndAlso e.RowIndex < dgvCsale.Rows.Count Then
            If disableCellClick = True Then
                If dgvCsale.SelectedRows.Count > 0 Then
                    selectedRow = dgvCsale.SelectedRows(0)

                    ' Check if selectedRow is not Nothing
                    If selectedRow IsNot Nothing Then
                        Dim Index As Integer = CInt(selectedRow.Cells("Index").Value)
                        tblproduct = selectedRow.Cells("Product").Value?.ToString()
                        tblLiters = CDbl(selectedRow.Cells("Liters").Value)
                        tblPrice = CDbl(selectedRow.Cells("Price").Value)
                        tblAmount = CDbl(selectedRow.Cells("Amount").Value)
                        Select Case tblproduct
                            Case "Diesel"
                                Sale_Click(SaleDiesel, New EventArgs())
                            Case "Premium"
                                Sale_Click(SalePremium, New EventArgs())
                            Case "Regular"
                                Sale_Click(SaleRegular, New EventArgs())
                        End Select
                        If Index = 0 Then
                            lblAmprice.Text = tblPrice
                            txtSamount.Text = tblAmount
                            lblsLiters.Text = tblLiters
                        ElseIf Index = 1 Then
                            txtSliters.Text = tblLiters
                            lblLprice.Text = tblPrice
                            lblLamount.Text = tblAmount
                        End If
                    Else
                        ' Handle the case when selectedRow is Nothing
                        MessageBox.Show("Selected row is null.")
                    End If
                End If
            End If
        End If
    End Sub

    Public Sub btnScancel_Click(sender As Object, e As EventArgs) Handles btnScancel.Click
        Form_Main.Form_CreateSale.dgvCsale.Columns.Clear()
        Form_Main.Form_CreateSale.dgvCsale.Rows.Clear()
        Form_Main.Form_CreateSale.Close()

    End Sub

    Public Sub btnSupdate_Click(sender As Object, e As EventArgs) Handles btnSupdate.Click
        If dgvCsale.SelectedRows.Count = 1 Then
            Dim selectedRow As DataGridViewRow = dgvCsale.SelectedRows(0)
            Dim updproduct As String = Sales.Tag
            Dim Index As Integer = CInt(selectedRow.Cells("Index").Value)
            If Index = 0 Then
                'selectedRow.Cells("Product").Value = updproduct
                selectedRow.Cells("Liters").Value = sLiters
                selectedRow.Cells("Price").Value = Sprice
                selectedRow.Cells("Amount").Value = Samount
            ElseIf Index = 1 Then
                'selectedRow.Cells("Product").Value = updproduct
                selectedRow.Cells("Liters").Value = inpLiters
                selectedRow.Cells("Price").Value = Sprice
                selectedRow.Cells("Amount").Value = sLamount
            End If
            UpdateTotalAmount()
            'ClearInputFields()
        End If
    End Sub



    Public Sub txtSliters_TextChanged(sender As Object, e As EventArgs) Handles txtSliters.TextChanged
        Try
            If Double.TryParse(txtSliters.Text, inpLiters) AndAlso Double.TryParse(lblLprice.Text, Sprice) Then
                Dim amount As Double = Math.Round((inpLiters * Sprice), 2)
                lblLamount.Text = amount
                sLamount = amount
            Else

            End If
        Catch ex As Exception
            MessageBox.Show($"Error in AmountPriceCalculation: {ex.Message}")
        End Try
    End Sub

    Dim selectedTab As TabPage


    Public Sub txtSamount_TextChanged(sender As Object, e As EventArgs) Handles txtSamount.TextChanged
        Try
            If txtSamount.Text IsNot Nothing Then
                If Double.TryParse(txtSamount.Text, Samount) AndAlso Double.TryParse(lblLprice.Text, Sprice) Then
                    Dim litro As Double = Math.Round((Samount / Sprice), 2)
                    lblsLiters.Text = litro
                    sLiters = litro
                End If
            Else
                lblsLiters.Text = 0
            End If
        Catch ex As Exception
            MessageBox.Show($"Error in AmountPriceCalculation: {ex.Message}")
        End Try
    End Sub

    Public Sub btnSconfirm_Click(sender As Object, e As EventArgs) Handles btnSconfirm.Click
        SQLite_Open_Connection()
        Using transaction As SQLiteTransaction = sqliteConnection.BeginTransaction()
            Try
                If String.IsNullOrWhiteSpace(txtcustName.Text) Then
                    MessageBox.Show("Please enter customer name.")
                ElseIf lastClickedPictureBox Is Nothing Then
                    MessageBox.Show("Please select a product.")
                ElseIf Form_Main.Form_CreateSale.dgvCsale.Rows.Count = 0 Then
                    MessageBox.Show("No Existing DATA!")
                    Form_Main.Form_CreateSale.txtSdscnt.Clear()
                Else
                    Dim liters As Double
                    Dim price As Double
                    Dim amounts As Double
                    Dim category_id, inventory_id As Integer
                    Dim litersAndCategoryList As New List(Of Tuple(Of Double, Integer)) ' Create a new list to store all liters values and their corresponding category_id
                    For Each row As DataGridViewRow In Form_Main.Form_CreateSale.dgvCsale.Rows
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

                                Dim values As String = $"({liters}, {price}, {amounts}, {category_id}, {inventory_id}, {sales_id})"
                                Form_Main.Form_CreateSale.valuesList.Add(values)
                                litersAndCategoryList.Add(New Tuple(Of Double, Integer)(liters, category_id)) ' Add the liters value and its corresponding category_id to the litersAndCategoryList

                            Else
                                MessageBox.Show("Error: One or more values in the DataGridView are not valid numbers.")
                            End If

                        End If
                    Next

                    If Form_Main.Form_CreateSale.valuesList.Count > 0 Then
                        Dim allUpdatesSuccessful As Boolean = True
                        Dim custname As String = txtcustName.Text
                        For Each item In litersAndCategoryList
                            Dim curLiters = item.Item1
                            Dim curCategory_id = item.Item2

                            Dim curStocks As Integer = Mod_Inventory.CheckStocksBeforeUpdate(curCategory_id)


                            If curStocks >= curLiters Then
                                Mod_Inventory.UpdateStocks(curLiters, curCategory_id)
                            Else
                                MessageBox.Show("Insufficient Stock!")
                                allUpdatesSuccessful = False
                                Exit For
                            End If
                        Next


                        If allUpdatesSuccessful Then
                            Insert_Sales_Data(custname, litersAmount, rcvdAmount, dscnt, change, valuesList)
                            valuesList.Clear()
                            Form_Main.Form_CreateSale.valuesList.Clear()
                            Form_Main.Form_CreateSale.dgvCsale.Rows.Clear()
                            Form_Main.Form_CreateSale.dgvCsale.Columns.Clear()
                            Form_Main.Form_CreateSale.txtSamount.Clear()
                            Form_Main.Form_CreateSale.txtRamount.Clear()
                            Form_Main.Form_CreateSale.txtSdscnt.Clear()
                            Form_Main.Form_CreateSale.txtSliters.Clear()
                            Form_Main.Form_CreateSale.lblSchange.Text = 0.00
                            Form_Main.Form_CreateSale.lblSgrandTotal.Text = 0.00
                            Form_Main.Form_CreateSale.txtcustName.Clear()
                            Form_Main.Form_CreateSale.Close()
                        End If
                    End If
                    transaction.Commit()
                    Load_Sales_Data()
                    Load_Inventory_Data()
                    getPrice()
                    Sales_Report()


                End If

            Catch ex As Exception
                transaction.Rollback()
                MessageBox.Show($"Error: {ex.Message}")
                SQLite_Close_Connection()

            End Try
        End Using
    End Sub



    Public Sub New()
        InitializeComponent()
        selectedTabIndex = SaleTab.SelectedIndex
    End Sub
    Public Sub adding_update_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim DieselPrice As Double = Mod_Add_Sales.dieselPrice
        Dim PremiumPrice As Double = Mod_Add_Sales.premiumPrice
        Dim RegularPrice As Double = Mod_Add_Sales.regularPrice
        diesel = Math.Round(DieselPrice + (DieselPrice * 0.06), 2)
        dprice = diesel
        PremiumPrice = Math.Round(PremiumPrice + (PremiumPrice * 0.06), 2)
        pprice = PremiumPrice

        RegularPrice = Math.Round(RegularPrice + (RegularPrice * 0.06), 2)
        rprice = RegularPrice

    End Sub
    Public Sub SaleTab_SelectedIndexChanged(sender As Object, e As EventArgs) Handles SaleTab.SelectedIndexChanged
        selectedTab = SaleTab.SelectedTab
        selectedTabIndex = SaleTab.SelectedIndex

    End Sub
    Public Sub btnSadd_Click(sender As Object, e As EventArgs) Handles btnSadd.Click
        ' Get product information
        If lastClickedPictureBox Is Nothing Then
            MessageBox.Show("Please select a product.")

        Else
            product = Sales.Tag
            If selectedTabIndex = 0 Then
                ' Adding sales by amount
                If Not Double.TryParse(txtSamount.Text, Nothing) OrElse lblAmprice.Text = 0 Then
                    MessageBox.Show("Please enter a valid number.")

                Else
                    If Double.TryParse(txtSamount.Text, SalesAmount) Then
                        ' Check if the product already exists in the DataGridView
                        Dim existingRow As DataGridViewRow = Nothing
                        For Each row As DataGridViewRow In dgvCsale.Rows
                            If row.Cells("Product").Value IsNot Nothing AndAlso
                            CStr(row.Cells("Product").Value) = product Then
                                existingRow = row
                                Exit For
                            End If
                        Next

                        ' If the product exists, update the existing row
                        If existingRow IsNot Nothing Then
                            existingRow.Cells("Amount").Value = CDbl(existingRow.Cells("Amount").Value) + SalesAmount
                            existingRow.Cells("Liters").Value = CDbl(existingRow.Cells("Liters").Value) + lblsLiters.Text
                        Else
                            ' If the product doesn't exist, add a new row
                            UpdateDataGridView(selectedTabIndex, product, CDbl(lblsLiters.Text), CDbl(lblLprice.Text), CDbl(txtSamount.Text))
                        End If

                        ' Update total amount
                        UpdateTotalAmount()
                    End If
                End If
            ElseIf selectedTabIndex = 1 Then
                ' Adding sales by liters
                If Not Double.TryParse(txtSliters.Text, Nothing) OrElse lblLprice.Text = 0 Then

                    MessageBox.Show("Please enter a valid number.")

                Else
                    If Double.TryParse(txtSliters.Text, SalesLiters) Then
                        ' Check if the product already exists in the DataGridView
                        Dim existingRow As DataGridViewRow = Nothing
                        For Each row As DataGridViewRow In dgvCsale.Rows
                            If row.Cells("Product").Value IsNot Nothing AndAlso
                            CStr(row.Cells("Product").Value) = product Then
                                existingRow = row
                                Exit For
                            End If
                        Next

                        ' If the product exists, add SalesLiters to existing value and update price and amount
                        If existingRow IsNot Nothing Then
                            existingRow.Cells("Liters").Value = CDbl(existingRow.Cells("Liters").Value) + SalesLiters
                            existingRow.Cells("Amount").Value = CDbl(existingRow.Cells("Liters").Value) * CDbl(existingRow.Cells("Price").Value)
                        Else
                            ' If the product doesn't exist, add a new row
                            UpdateDataGridView(selectedTabIndex, product, SalesLiters, CDbl(lblLprice.Text), CDbl(lblLprice.Text) * SalesLiters)
                        End If

                        ' Update total amount
                        UpdateTotalAmount()
                    End If
                End If
            End If
            Form_Main.Form_CreateSale.txtSamount.Clear()
            Form_Main.Form_CreateSale.txtSliters.Clear()
            Form_Main.Form_CreateSale.lblLamount.Text = 0.00
            Form_Main.Form_CreateSale.lblsLiters.Text = 0.00
        End If

    End Sub
    Public Sub UpdateDataGridView(tabIndex As Integer, product As String, liters As Double, price As Double, amount As Double)
        dgvCsale.Rows.Add(tabIndex, product, liters, price, amount)
    End Sub

    Public Sub UpdateTotalAmount()
        ' Calculate total amount based on the amounts of rows in the DataGridView
        litersAmount = CalculateLitersAmount()
        grand = Math.Round(finaltotal + litersAmount, 2)
        Form_Main.Form_CreateSale.lblSgrandTotal.Text = grand.ToString()
    End Sub


    Public Sub ClearInputFields()
        ' Clear input fields after adding a row
        txtSamount.Clear()
        txtSliters.Clear()
        txtSdscnt.Clear()
        txtRamount.Clear()
        lblsLiters.Text = 0
        lblLamount.Text = 0

    End Sub

    Private Sub Sale_Click(sender As Object, e As EventArgs) Handles SaleDiesel.Click, SalePremium.Click, SaleRegular.Click
        HandlePictureBoxClick(DirectCast(sender, PictureBox))
    End Sub

    Private Sub HandlePictureBoxClick(pictureBox As PictureBox)
        Form_Main.Form_CreateSale.Sales = pictureBox
        Form_Main.Form_CreateSale.SaleDiesel.BorderStyle = BorderStyle.None
        Form_Main.Form_CreateSale.SalePremium.BorderStyle = BorderStyle.None
        Form_Main.Form_CreateSale.SaleRegular.BorderStyle = BorderStyle.None
        Form_Main.Form_CreateSale.Sales.BorderStyle = BorderStyle.Fixed3D
        Form_Main.Form_CreateSale.lblsLiters.Text = 0.00
        Form_Main.Form_CreateSale.txtSamount.Clear()
        Form_Main.Form_CreateSale.lblLamount.Text = 0.00
        Form_Main.Form_CreateSale.txtSliters.Clear()

        If pictureBox Is SaleDiesel Then
            Form_Main.Form_CreateSale.lblLprice.Text = dprice
            Form_Main.Form_CreateSale.lblAmprice.Text = dprice
            Form_Main.Form_CreateSale.Sales.Tag = "Diesel"

        ElseIf pictureBox Is SalePremium Then
            Form_Main.Form_CreateSale.lblLprice.Text = pprice
            Form_Main.Form_CreateSale.lblAmprice.Text = pprice
            Form_Main.Form_CreateSale.Sales.Tag = "Premium"
        ElseIf pictureBox Is SaleRegular Then
            Form_Main.Form_CreateSale.lblLprice.Text = rprice
            Form_Main.Form_CreateSale.lblAmprice.Text = rprice
            Form_Main.Form_CreateSale.Sales.Tag = "Regular"
        End If

        Form_Main.Form_CreateSale.lastClickedPictureBox = pictureBox
    End Sub

    Public Sub txtSdscnt_TextChanged(sender As Object, e As EventArgs) Handles txtSdscnt.TextChanged
        Try

            If String.IsNullOrWhiteSpace(txtSdscnt.Text) Then
                lblSgrandTotal.Text = grand.ToString()
                change = Math.Round((rcvdAmount - grand), 2)
                lblSchange.Text = change
            Else

                Dim totalAmount As Double = grand ' Use the original total amount
                Dim delDscnt As Double = txtSdscnt.Text

                dscnt = Math.Round(delDscnt / 100, 2)
                grandTotal = totalAmount - Math.Round((totalAmount * dscnt), 2)
                lblSgrandTotal.Text = grandTotal.ToString()
                change = Math.Round((rcvdAmount - grandTotal), 2)
                lblSchange.Text = change
            End If

        Catch ex As Exception
            MessageBox.Show($"Error in totalAmountChangeCalculation: {ex.Message}")
        End Try
    End Sub

    Public Sub txtRamount_TextChanged(sender As Object, e As EventArgs) Handles txtRamount.TextChanged
        If Not String.IsNullOrEmpty(txtRamount.Text) AndAlso Double.TryParse(txtRamount.Text, rcvdAmount) Then
            rcvdAmount = txtRamount.Text
            If String.IsNullOrWhiteSpace(txtSdscnt.Text) Then
                lblSgrandTotal.Text = grand.ToString()
                change = Math.Round((rcvdAmount - grand), 2)
                lblSchange.Text = change

                'change = Math.Round((rcvdAmount - grandTotal), 2)
                'lblSchange.Text = change
            Else
                change = Math.Round((rcvdAmount - grandTotal), 2)
                lblSchange.Text = change
            End If
        End If
    End Sub

    Private Sub btnSreceipt_Click(sender As Object, e As EventArgs) Handles btnSreceipt.Click
        If Form_Main.dgvSale.SelectedRows.Count > 0 Then
            Dim selectedRow As DataGridViewRow = Form_Main.dgvSale.SelectedRows(0)
            Dim ID As Integer = CInt(selectedRow.Cells("ID").Value)
            PrintCustReceipt(ID)
        End If

    End Sub

    Private Sub btnSOK_Click(sender As Object, e As EventArgs) Handles btnSOK.Click
        Me.Close()
    End Sub
End Class