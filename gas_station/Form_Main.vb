Imports System.Windows.Forms.VisualStyles.VisualStyleElement

Public Class Form_Main
    Public userInput As String
    Public delivery_id, pInventory_id As Integer
    Public Form_CreateDel As New Form_CRUD_Del()
    Public Form_CreateSale As New Form_CRUD_sale()
    Private Sub Form_Main_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Load_Delivery_Data()
        Load_Inventory_Data()
        Load_pInventory_Data()
        Load_Sales_Data()
        getPrice()
        Sales_Report()
        Load_User()
    End Sub

    Private Sub btnCreateDel_Click(sender As Object, e As EventArgs) Handles btnCreateDel.Click


        Form_CreateDel.dgvDelCart.Columns.Add("Product", "Product")
        Form_CreateDel.dgvDelCart.Columns.Add("Liters", "Liters")
        Form_CreateDel.dgvDelCart.Columns.Add("Price", "Price")
        Form_CreateDel.dgvDelCart.Columns.Add("Amount", "Amount")


        Form_CreateDel.dgvDelCart.AutoGenerateColumns = False
        Form_CreateDel.disableCellClick = True
        Form_CreateDel.btnOK.Visible = False

        Form_CreateDel.ShowDialog()
    End Sub


    'Private Sub btnViewDel_Click(sender As Object, e As EventArgs) Handles btnViewDel.Click

    '    If dgvDelivery.SelectedRows.Count > 0 Then
    '        Dim selectedRow As DataGridViewRow = dgvDelivery.SelectedRows(0)
    '        Dim delivery_id As Integer = CInt(selectedRow.Cells("delivery_id").Value)

    '        Form_CRUD_Del.ShowDialog()

    '        Load_Adding_Data(delivery_id)
    '    End If
    'End Sub
    Private Sub btnViewDel_Click(sender As Object, e As EventArgs) Handles btnViewDel.Click
        RemoveHandler Form_CRUD_Del.cmbSupplier.SelectedIndexChanged, AddressOf Form_CRUD_Del.cmbSupplier_SelectedIndexChanged
        RemoveHandler Form_CRUD_Del.txtDelDiscnt.TextChanged, AddressOf Form_CRUD_Del.txtDelDiscnt_TextChanged
        RemoveHandler Form_CRUD_Del.txtdelLiters.TextChanged, AddressOf Form_CRUD_Del.txtdelLiters_TextChanged


        If dgvDelivery.SelectedRows.Count > 0 Then
            Dim selectedRow As DataGridViewRow = dgvDelivery.SelectedRows(0)
            delivery_id = CInt(selectedRow.Cells("ID").Value)


            Form_CRUD_Del.btnAddDel.Visible = False
            Form_CRUD_Del.btnDelConfirm.Visible = False
            Form_CRUD_Del.txtSuppID.Enabled = False
            Form_CRUD_Del.txtPhone.Enabled = False
            Form_CRUD_Del.txtAddress.Enabled = False
            Form_CRUD_Del.cmbSupplier.Enabled = False
            Form_CRUD_Del.txtDelDiscnt.Enabled = False
            Form_CRUD_Del.txtdelLiters.Enabled = False
            Form_CRUD_Del.txtdelLprice.Enabled = False
            Form_CRUD_Del.btnDelCancel.Visible = False
            Form_CRUD_Del.btnDeletedel.Visible = False
            Form_CRUD_Del.btnUpdateDel.Visible = False
            Form_CRUD_Del.disableCellClick = False

            Load_Adding_Data(Form_CRUD_Del.dgvDelCart, delivery_id)
            Form_CRUD_Del.ShowDialog()

        End If
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        Me.Close()
        Form_Login.Show()
    End Sub

    Private Sub btncreate_Click(sender As Object, e As EventArgs) Handles btncreate.Click


        Form_CreateSale.dgvCsale.Columns.Add("Index", "Index")
        Form_CreateSale.dgvCsale.Columns.Add("Product", "Product")
        Form_CreateSale.dgvCsale.Columns.Add("Liters", "Liters")
        Form_CreateSale.dgvCsale.Columns.Add("Price", "Price")
        Form_CreateSale.dgvCsale.Columns.Add("Amount", "Amount")


        Form_CreateSale.dgvCsale.AutoGenerateColumns = False

        Form_CreateSale.btnSreceipt.Visible = False
        Form_CreateSale.disableCellClick = True
        Form_CreateSale.btnSOK.Visible = False
        Form_CreateSale.ShowDialog()
    End Sub

    Private Sub btnSview_Click(sender As Object, e As EventArgs) Handles btnSview.Click
        RemoveHandler Form_CRUD_sale.txtRamount.TextChanged, AddressOf Form_CRUD_sale.txtRamount_TextChanged
        RemoveHandler Form_CRUD_sale.txtSamount.TextChanged, AddressOf Form_CRUD_sale.txtSamount_TextChanged
        RemoveHandler Form_CRUD_sale.txtSdscnt.TextChanged, AddressOf Form_CRUD_sale.txtSdscnt_TextChanged
        RemoveHandler Form_CRUD_sale.txtSliters.TextChanged, AddressOf Form_CRUD_sale.txtSliters_TextChanged

        If dgvSale.SelectedRows.Count > 0 Then
            Dim selectedRow As DataGridViewRow = dgvSale.SelectedRows(0)
            Dim sale_id As Integer = CInt(selectedRow.Cells("ID").Value)
            Form_CRUD_sale.txtcustName.Enabled = False
            Form_CRUD_sale.txtRamount.Enabled = False
            Form_CRUD_sale.txtSamount.Enabled = False
            Form_CRUD_sale.txtSdscnt.Enabled = False
            Form_CRUD_sale.txtSliters.Enabled = False
            Form_CRUD_sale.btnSadd.Visible = False
            Form_CRUD_sale.btnSdel.Visible = False
            Form_CRUD_sale.btnScancel.Visible = False
            Form_CRUD_sale.btnSupdate.Visible = False
            Form_CRUD_sale.btnSconfirm.Visible = False
            Load_Adding_Sales_Data(Form_CRUD_sale.dgvCsale, sale_id)
            'MessageBox.Show(sale_id)
            Form_CRUD_sale.ShowDialog()

        End If
    End Sub

    Private Sub txtSaleSearch_TextChanged(sender As Object, e As EventArgs) Handles txtSaleSearch.TextChanged
        Dim saleSearch As String = txtSaleSearch.Text.Trim()
        Search_Sales_Data(saleSearch)
    End Sub

    Private Sub txtDelSearch_TextChanged(sender As Object, e As EventArgs) Handles txtDelSearch.TextChanged
        Dim delSearch As String = txtDelSearch.Text.Trim()
        Search_Delivery_Data(delSearch)
    End Sub

    Private Sub btnUpdateInv_Click(sender As Object, e As EventArgs) Handles btnUpdateInv.Click
        If dgvpInventory.SelectedRows.Count > 0 Then
            Dim selectedRow As DataGridViewRow = dgvpInventory.SelectedRows(0)
            pInventory_id = CInt(selectedRow.Cells("ID").Value)
            Dim userInput As String
            Dim userValue As Double

            userInput = InputBox("Enter Measured Stock:", "STOCKS", "0")

            If Double.TryParse(userInput, userValue) Then
                ' Pass the user input directly to Update_pInventory
                Dim updatedValue As Double = Update_pInventory(userInput, pInventory_id)
                Load_pInventory_Data()
                ' Use the updated value for comparison
                Compare(updatedValue, pInventory_id)
            End If


        End If
    End Sub

    Private Sub dtpDay_ValueChanged(sender As Object, e As EventArgs) Handles dtpDay.ValueChanged
        Sales_Report()
    End Sub

    Private Sub detReport_Click(sender As Object, e As EventArgs) Handles detReport.Click
        RemoveHandler Form_CRUD_sale.txtRamount.TextChanged, AddressOf Form_CRUD_sale.txtRamount_TextChanged
        RemoveHandler Form_CRUD_sale.txtSamount.TextChanged, AddressOf Form_CRUD_sale.txtSamount_TextChanged
        RemoveHandler Form_CRUD_sale.txtSdscnt.TextChanged, AddressOf Form_CRUD_sale.txtSdscnt_TextChanged
        RemoveHandler Form_CRUD_sale.txtSliters.TextChanged, AddressOf Form_CRUD_sale.txtSliters_TextChanged

        If dgvReport.SelectedRows.Count > 0 Then
            Dim selectedRow As DataGridViewRow = dgvSale.SelectedRows(0)
            Dim sale_id As Integer = CInt(selectedRow.Cells("ID").Value)
            Form_CRUD_sale.txtcustName.Enabled = False
            Form_CRUD_sale.txtRamount.Enabled = False
            Form_CRUD_sale.txtSamount.Enabled = False
            Form_CRUD_sale.txtSdscnt.Enabled = False
            Form_CRUD_sale.txtSliters.Enabled = False
            Form_CRUD_sale.btnSadd.Visible = False
            Form_CRUD_sale.btnSdel.Visible = False
            Form_CRUD_sale.btnSupdate.Visible = False
            Form_CRUD_sale.btnSconfirm.Visible = False
            Load_Adding_Sales_Data(Form_CRUD_sale.dgvCsale, sale_id)
            'MessageBox.Show(sale_id)
            Form_CRUD_sale.ShowDialog()
        End If
    End Sub

    Private Sub btnManageUser_Click(sender As Object, e As EventArgs) Handles btnManageUser.Click
        Form_Manage_User.ShowDialog()
        Load_User()
    End Sub

    Private Sub btnCreateAcc_Click(sender As Object, e As EventArgs) Handles btnCreateAcc.Click
        Form_Create_User.ShowDialog()
    End Sub
End Class