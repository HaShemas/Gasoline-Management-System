<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form_CRUD_sale
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As ComponentModel.ComponentResourceManager = New ComponentModel.ComponentResourceManager(GetType(Form_CRUD_sale))
        SaleDiesel = New PictureBox()
        btnSadd = New Button()
        SaleTab = New TabControl()
        SaleAmount = New TabPage()
        lblsLiters = New Label()
        lblAmprice = New Label()
        txtSamount = New TextBox()
        Label8 = New Label()
        Label7 = New Label()
        Label6 = New Label()
        SaleLiters = New TabPage()
        lblLamount = New Label()
        lblLprice = New Label()
        Label13 = New Label()
        Label12 = New Label()
        txtSliters = New TextBox()
        Label11 = New Label()
        Label2 = New Label()
        txtcustName = New TextBox()
        SalePremium = New PictureBox()
        SaleRegular = New PictureBox()
        Label3 = New Label()
        Label4 = New Label()
        Label5 = New Label()
        btnSupdate = New Button()
        dgvCsale = New DataGridView()
        Label16 = New Label()
        lblSgrandTotal = New Label()
        Label18 = New Label()
        txtSdscnt = New TextBox()
        Label19 = New Label()
        txtRamount = New TextBox()
        Label20 = New Label()
        lblSchange = New Label()
        btnSconfirm = New Button()
        btnScancel = New Button()
        btnSdel = New Button()
        btnSreceipt = New Button()
        btnSOK = New Button()
        CType(SaleDiesel, ComponentModel.ISupportInitialize).BeginInit()
        SaleTab.SuspendLayout()
        SaleAmount.SuspendLayout()
        SaleLiters.SuspendLayout()
        CType(SalePremium, ComponentModel.ISupportInitialize).BeginInit()
        CType(SaleRegular, ComponentModel.ISupportInitialize).BeginInit()
        CType(dgvCsale, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' SaleDiesel
        ' 
        SaleDiesel.Image = My.Resources.Resources.Diesel
        SaleDiesel.Location = New Point(62, 100)
        SaleDiesel.Margin = New Padding(3, 2, 3, 2)
        SaleDiesel.Name = "SaleDiesel"
        SaleDiesel.Size = New Size(169, 107)
        SaleDiesel.SizeMode = PictureBoxSizeMode.StretchImage
        SaleDiesel.TabIndex = 2
        SaleDiesel.TabStop = False
        ' 
        ' btnSadd
        ' 
        btnSadd.Location = New Point(142, 375)
        btnSadd.Margin = New Padding(3, 2, 3, 2)
        btnSadd.Name = "btnSadd"
        btnSadd.Size = New Size(113, 33)
        btnSadd.TabIndex = 3
        btnSadd.Text = "ADD"
        btnSadd.UseVisualStyleBackColor = True
        ' 
        ' SaleTab
        ' 
        SaleTab.Controls.Add(SaleAmount)
        SaleTab.Controls.Add(SaleLiters)
        SaleTab.Location = New Point(79, 257)
        SaleTab.Margin = New Padding(3, 2, 3, 2)
        SaleTab.Name = "SaleTab"
        SaleTab.SelectedIndex = 0
        SaleTab.Size = New Size(591, 103)
        SaleTab.TabIndex = 4
        ' 
        ' SaleAmount
        ' 
        SaleAmount.Controls.Add(lblsLiters)
        SaleAmount.Controls.Add(lblAmprice)
        SaleAmount.Controls.Add(txtSamount)
        SaleAmount.Controls.Add(Label8)
        SaleAmount.Controls.Add(Label7)
        SaleAmount.Controls.Add(Label6)
        SaleAmount.Font = New Font("Arial Narrow", 13.8F, FontStyle.Regular, GraphicsUnit.Point)
        SaleAmount.Location = New Point(4, 24)
        SaleAmount.Margin = New Padding(3, 2, 3, 2)
        SaleAmount.Name = "SaleAmount"
        SaleAmount.Padding = New Padding(3, 2, 3, 2)
        SaleAmount.Size = New Size(583, 75)
        SaleAmount.TabIndex = 0
        SaleAmount.Text = "AMOUNT"
        SaleAmount.UseVisualStyleBackColor = True
        ' 
        ' lblsLiters
        ' 
        lblsLiters.AutoSize = True
        lblsLiters.Font = New Font("Arial Narrow", 13.8F, FontStyle.Regular, GraphicsUnit.Point)
        lblsLiters.Location = New Point(447, 37)
        lblsLiters.Name = "lblsLiters"
        lblsLiters.Size = New Size(115, 23)
        lblsLiters.TabIndex = 16
        lblsLiters.Text = "auto generated"
        ' 
        ' lblAmprice
        ' 
        lblAmprice.AutoSize = True
        lblAmprice.Font = New Font("Arial Narrow", 13.8F, FontStyle.Regular, GraphicsUnit.Point)
        lblAmprice.Location = New Point(218, 37)
        lblAmprice.Name = "lblAmprice"
        lblAmprice.Size = New Size(115, 23)
        lblAmprice.TabIndex = 15
        lblAmprice.Text = "auto generated"
        ' 
        ' txtSamount
        ' 
        txtSamount.Location = New Point(16, 32)
        txtSamount.Margin = New Padding(3, 2, 3, 2)
        txtSamount.Multiline = True
        txtSamount.Name = "txtSamount"
        txtSamount.Size = New Size(142, 26)
        txtSamount.TabIndex = 12
        ' 
        ' Label8
        ' 
        Label8.AutoSize = True
        Label8.Font = New Font("Arial Narrow", 13.8F, FontStyle.Regular, GraphicsUnit.Point)
        Label8.Location = New Point(483, 10)
        Label8.Name = "Label8"
        Label8.Size = New Size(47, 23)
        Label8.TabIndex = 14
        Label8.Text = "Liters"
        ' 
        ' Label7
        ' 
        Label7.AutoSize = True
        Label7.Font = New Font("Arial Narrow", 13.8F, FontStyle.Regular, GraphicsUnit.Point)
        Label7.Location = New Point(252, 10)
        Label7.Name = "Label7"
        Label7.Size = New Size(45, 23)
        Label7.TabIndex = 13
        Label7.Text = "Price"
        ' 
        ' Label6
        ' 
        Label6.AutoSize = True
        Label6.Font = New Font("Arial Narrow", 13.8F, FontStyle.Regular, GraphicsUnit.Point)
        Label6.Location = New Point(16, 10)
        Label6.Name = "Label6"
        Label6.Size = New Size(63, 23)
        Label6.TabIndex = 12
        Label6.Text = "Amount"
        ' 
        ' SaleLiters
        ' 
        SaleLiters.Controls.Add(lblLamount)
        SaleLiters.Controls.Add(lblLprice)
        SaleLiters.Controls.Add(Label13)
        SaleLiters.Controls.Add(Label12)
        SaleLiters.Controls.Add(txtSliters)
        SaleLiters.Controls.Add(Label11)
        SaleLiters.Font = New Font("Arial Narrow", 13.8F, FontStyle.Regular, GraphicsUnit.Point)
        SaleLiters.Location = New Point(4, 24)
        SaleLiters.Margin = New Padding(3, 2, 3, 2)
        SaleLiters.Name = "SaleLiters"
        SaleLiters.Padding = New Padding(3, 2, 3, 2)
        SaleLiters.Size = New Size(583, 75)
        SaleLiters.TabIndex = 1
        SaleLiters.Text = "LITERS"
        SaleLiters.UseVisualStyleBackColor = True
        ' 
        ' lblLamount
        ' 
        lblLamount.AutoSize = True
        lblLamount.Font = New Font("Arial Narrow", 13.8F, FontStyle.Regular, GraphicsUnit.Point)
        lblLamount.Location = New Point(438, 39)
        lblLamount.Name = "lblLamount"
        lblLamount.Size = New Size(115, 23)
        lblLamount.TabIndex = 18
        lblLamount.Text = "auto generated"
        ' 
        ' lblLprice
        ' 
        lblLprice.AutoSize = True
        lblLprice.Font = New Font("Arial Narrow", 13.8F, FontStyle.Regular, GraphicsUnit.Point)
        lblLprice.Location = New Point(228, 36)
        lblLprice.Name = "lblLprice"
        lblLprice.Size = New Size(115, 23)
        lblLprice.TabIndex = 17
        lblLprice.Text = "auto generated"
        ' 
        ' Label13
        ' 
        Label13.AutoSize = True
        Label13.Font = New Font("Arial Narrow", 13.8F, FontStyle.Regular, GraphicsUnit.Point)
        Label13.Location = New Point(472, 11)
        Label13.Name = "Label13"
        Label13.Size = New Size(63, 23)
        Label13.TabIndex = 16
        Label13.Text = "Amount"
        ' 
        ' Label12
        ' 
        Label12.AutoSize = True
        Label12.Font = New Font("Arial Narrow", 13.8F, FontStyle.Regular, GraphicsUnit.Point)
        Label12.Location = New Point(263, 11)
        Label12.Name = "Label12"
        Label12.Size = New Size(45, 23)
        Label12.TabIndex = 15
        Label12.Text = "Price"
        ' 
        ' txtSliters
        ' 
        txtSliters.Location = New Point(13, 36)
        txtSliters.Margin = New Padding(3, 2, 3, 2)
        txtSliters.Multiline = True
        txtSliters.Name = "txtSliters"
        txtSliters.Size = New Size(142, 26)
        txtSliters.TabIndex = 14
        ' 
        ' Label11
        ' 
        Label11.AutoSize = True
        Label11.Font = New Font("Arial Narrow", 13.8F, FontStyle.Regular, GraphicsUnit.Point)
        Label11.Location = New Point(21, 11)
        Label11.Name = "Label11"
        Label11.Size = New Size(47, 23)
        Label11.TabIndex = 13
        Label11.Text = "Liters"
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.Font = New Font("Arial Narrow", 13.8F, FontStyle.Regular, GraphicsUnit.Point)
        Label2.Location = New Point(55, 22)
        Label2.Name = "Label2"
        Label2.Size = New Size(123, 23)
        Label2.TabIndex = 5
        Label2.Text = "Customer Name"
        ' 
        ' txtcustName
        ' 
        txtcustName.Location = New Point(55, 47)
        txtcustName.Margin = New Padding(3, 2, 3, 2)
        txtcustName.Multiline = True
        txtcustName.Name = "txtcustName"
        txtcustName.Size = New Size(161, 26)
        txtcustName.TabIndex = 6
        ' 
        ' SalePremium
        ' 
        SalePremium.Image = My.Resources.Resources.Premium
        SalePremium.Location = New Point(296, 100)
        SalePremium.Margin = New Padding(3, 2, 3, 2)
        SalePremium.Name = "SalePremium"
        SalePremium.Size = New Size(169, 107)
        SalePremium.SizeMode = PictureBoxSizeMode.StretchImage
        SalePremium.TabIndex = 7
        SalePremium.TabStop = False
        ' 
        ' SaleRegular
        ' 
        SaleRegular.Image = My.Resources.Resources.Unleaded
        SaleRegular.Location = New Point(514, 100)
        SaleRegular.Margin = New Padding(3, 2, 3, 2)
        SaleRegular.Name = "SaleRegular"
        SaleRegular.Size = New Size(169, 107)
        SaleRegular.SizeMode = PictureBoxSizeMode.StretchImage
        SaleRegular.TabIndex = 8
        SaleRegular.TabStop = False
        ' 
        ' Label3
        ' 
        Label3.AutoSize = True
        Label3.Font = New Font("Arial Narrow", 13.8F, FontStyle.Regular, GraphicsUnit.Point)
        Label3.Location = New Point(107, 218)
        Label3.Name = "Label3"
        Label3.Size = New Size(63, 23)
        Label3.TabIndex = 9
        Label3.Text = "DIESEL"
        ' 
        ' Label4
        ' 
        Label4.AutoSize = True
        Label4.Font = New Font("Arial Narrow", 13.8F, FontStyle.Regular, GraphicsUnit.Point)
        Label4.Location = New Point(336, 218)
        Label4.Name = "Label4"
        Label4.Size = New Size(81, 23)
        Label4.TabIndex = 10
        Label4.Text = "PREMIUM"
        ' 
        ' Label5
        ' 
        Label5.AutoSize = True
        Label5.Font = New Font("Arial Narrow", 13.8F, FontStyle.Regular, GraphicsUnit.Point)
        Label5.Location = New Point(554, 218)
        Label5.Name = "Label5"
        Label5.Size = New Size(84, 23)
        Label5.TabIndex = 11
        Label5.Text = "REGULAR"
        ' 
        ' btnSupdate
        ' 
        btnSupdate.Location = New Point(306, 375)
        btnSupdate.Margin = New Padding(3, 2, 3, 2)
        btnSupdate.Name = "btnSupdate"
        btnSupdate.Size = New Size(113, 36)
        btnSupdate.TabIndex = 12
        btnSupdate.Text = "UPDATE"
        btnSupdate.UseVisualStyleBackColor = True
        ' 
        ' dgvCsale
        ' 
        dgvCsale.AllowUserToAddRows = False
        dgvCsale.AllowUserToDeleteRows = False
        dgvCsale.AllowUserToOrderColumns = True
        dgvCsale.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        dgvCsale.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        dgvCsale.Location = New Point(79, 426)
        dgvCsale.Margin = New Padding(3, 2, 3, 2)
        dgvCsale.Name = "dgvCsale"
        dgvCsale.ReadOnly = True
        dgvCsale.RowHeadersWidth = 51
        dgvCsale.RowTemplate.Height = 29
        dgvCsale.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        dgvCsale.Size = New Size(584, 122)
        dgvCsale.TabIndex = 13
        ' 
        ' Label16
        ' 
        Label16.AutoSize = True
        Label16.Font = New Font("Arial Narrow", 13.8F, FontStyle.Regular, GraphicsUnit.Point)
        Label16.Location = New Point(155, 571)
        Label16.Name = "Label16"
        Label16.Size = New Size(91, 23)
        Label16.TabIndex = 14
        Label16.Text = "Grand Total"
        ' 
        ' lblSgrandTotal
        ' 
        lblSgrandTotal.AutoSize = True
        lblSgrandTotal.Font = New Font("Arial Narrow", 13.8F, FontStyle.Regular, GraphicsUnit.Point)
        lblSgrandTotal.Location = New Point(148, 591)
        lblSgrandTotal.Name = "lblSgrandTotal"
        lblSgrandTotal.Size = New Size(115, 23)
        lblSgrandTotal.TabIndex = 19
        lblSgrandTotal.Text = "auto generated"
        ' 
        ' Label18
        ' 
        Label18.AutoSize = True
        Label18.Font = New Font("Arial Narrow", 13.8F, FontStyle.Regular, GraphicsUnit.Point)
        Label18.Location = New Point(435, 571)
        Label18.Name = "Label18"
        Label18.Size = New Size(86, 23)
        Label18.TabIndex = 20
        Label18.Text = "DIscount %"
        ' 
        ' txtSdscnt
        ' 
        txtSdscnt.Location = New Point(411, 593)
        txtSdscnt.Margin = New Padding(3, 2, 3, 2)
        txtSdscnt.Multiline = True
        txtSdscnt.Name = "txtSdscnt"
        txtSdscnt.Size = New Size(142, 26)
        txtSdscnt.TabIndex = 21
        ' 
        ' Label19
        ' 
        Label19.AutoSize = True
        Label19.Font = New Font("Arial Narrow", 13.8F, FontStyle.Regular, GraphicsUnit.Point)
        Label19.Location = New Point(136, 632)
        Label19.Name = "Label19"
        Label19.Size = New Size(132, 23)
        Label19.TabIndex = 22
        Label19.Text = "Amount Received"
        ' 
        ' txtRamount
        ' 
        txtRamount.Location = New Point(132, 654)
        txtRamount.Margin = New Padding(3, 2, 3, 2)
        txtRamount.Multiline = True
        txtRamount.Name = "txtRamount"
        txtRamount.Size = New Size(142, 26)
        txtRamount.TabIndex = 23
        ' 
        ' Label20
        ' 
        Label20.AutoSize = True
        Label20.Font = New Font("Arial Narrow", 13.8F, FontStyle.Regular, GraphicsUnit.Point)
        Label20.Location = New Point(443, 632)
        Label20.Name = "Label20"
        Label20.Size = New Size(66, 23)
        Label20.TabIndex = 24
        Label20.Text = "Change"
        ' 
        ' lblSchange
        ' 
        lblSchange.AutoSize = True
        lblSchange.Font = New Font("Arial Narrow", 13.8F, FontStyle.Regular, GraphicsUnit.Point)
        lblSchange.Location = New Point(419, 652)
        lblSchange.Name = "lblSchange"
        lblSchange.Size = New Size(115, 23)
        lblSchange.TabIndex = 25
        lblSchange.Text = "auto generated"
        ' 
        ' btnSconfirm
        ' 
        btnSconfirm.Location = New Point(186, 714)
        btnSconfirm.Margin = New Padding(3, 2, 3, 2)
        btnSconfirm.Name = "btnSconfirm"
        btnSconfirm.Size = New Size(113, 33)
        btnSconfirm.TabIndex = 26
        btnSconfirm.Text = "CONFIRM"
        btnSconfirm.UseVisualStyleBackColor = True
        ' 
        ' btnScancel
        ' 
        btnScancel.Location = New Point(423, 714)
        btnScancel.Margin = New Padding(3, 2, 3, 2)
        btnScancel.Name = "btnScancel"
        btnScancel.Size = New Size(113, 33)
        btnScancel.TabIndex = 28
        btnScancel.Text = "CANCEL"
        btnScancel.UseVisualStyleBackColor = True
        ' 
        ' btnSdel
        ' 
        btnSdel.Location = New Point(443, 375)
        btnSdel.Margin = New Padding(3, 2, 3, 2)
        btnSdel.Name = "btnSdel"
        btnSdel.Size = New Size(113, 36)
        btnSdel.TabIndex = 29
        btnSdel.Text = "DELETE"
        btnSdel.UseVisualStyleBackColor = True
        ' 
        ' btnSreceipt
        ' 
        btnSreceipt.Location = New Point(232, 714)
        btnSreceipt.Margin = New Padding(3, 2, 3, 2)
        btnSreceipt.Name = "btnSreceipt"
        btnSreceipt.Size = New Size(113, 33)
        btnSreceipt.TabIndex = 39
        btnSreceipt.Text = "CREATE RECEIPT"
        btnSreceipt.UseVisualStyleBackColor = True
        ' 
        ' btnSOK
        ' 
        btnSOK.Location = New Point(423, 714)
        btnSOK.Margin = New Padding(3, 2, 3, 2)
        btnSOK.Name = "btnSOK"
        btnSOK.Size = New Size(113, 33)
        btnSOK.TabIndex = 40
        btnSOK.Text = "OK"
        btnSOK.UseVisualStyleBackColor = True
        ' 
        ' Form_CRUD_sale
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        BackgroundImage = CType(resources.GetObject("$this.BackgroundImage"), Image)
        ClientSize = New Size(740, 791)
        Controls.Add(btnSOK)
        Controls.Add(btnSreceipt)
        Controls.Add(btnSdel)
        Controls.Add(btnScancel)
        Controls.Add(btnSconfirm)
        Controls.Add(lblSchange)
        Controls.Add(Label20)
        Controls.Add(txtRamount)
        Controls.Add(Label19)
        Controls.Add(txtSdscnt)
        Controls.Add(Label18)
        Controls.Add(lblSgrandTotal)
        Controls.Add(Label16)
        Controls.Add(dgvCsale)
        Controls.Add(btnSupdate)
        Controls.Add(Label5)
        Controls.Add(Label4)
        Controls.Add(Label3)
        Controls.Add(SaleRegular)
        Controls.Add(SalePremium)
        Controls.Add(txtcustName)
        Controls.Add(Label2)
        Controls.Add(SaleTab)
        Controls.Add(btnSadd)
        Controls.Add(SaleDiesel)
        Margin = New Padding(3, 2, 3, 2)
        Name = "Form_CRUD_sale"
        StartPosition = FormStartPosition.CenterScreen
        Text = "adding_update"
        CType(SaleDiesel, ComponentModel.ISupportInitialize).EndInit()
        SaleTab.ResumeLayout(False)
        SaleAmount.ResumeLayout(False)
        SaleAmount.PerformLayout()
        SaleLiters.ResumeLayout(False)
        SaleLiters.PerformLayout()
        CType(SalePremium, ComponentModel.ISupportInitialize).EndInit()
        CType(SaleRegular, ComponentModel.ISupportInitialize).EndInit()
        CType(dgvCsale, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
        PerformLayout()
    End Sub
    Friend WithEvents SaleDiesel As PictureBox
    Friend WithEvents btnSadd As Button
    Friend WithEvents SaleTab As TabControl
    Friend WithEvents SaleAmount As TabPage
    Friend WithEvents SaleLiters As TabPage
    Friend WithEvents Label2 As Label
    Friend WithEvents txtcustName As TextBox
    Friend WithEvents SalePremium As PictureBox
    Friend WithEvents SaleRegular As PictureBox
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents lblsLiters As Label
    Friend WithEvents lblAmprice As Label
    Friend WithEvents txtSamount As TextBox
    Friend WithEvents Label8 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents Label13 As Label
    Friend WithEvents Label12 As Label
    Friend WithEvents txtSliters As TextBox
    Friend WithEvents Label11 As Label
    Friend WithEvents lblLamount As Label
    Friend WithEvents lblLprice As Label
    Friend WithEvents btnSupdate As Button
    Friend WithEvents dgvCsale As DataGridView
    Friend WithEvents Label16 As Label
    Friend WithEvents lblSgrandTotal As Label
    Friend WithEvents Label18 As Label
    Friend WithEvents txtSdscnt As TextBox
    Friend WithEvents Label19 As Label
    Friend WithEvents txtRamount As TextBox
    Friend WithEvents Label20 As Label
    Friend WithEvents lblSchange As Label
    Friend WithEvents btnSconfirm As Button
    Friend WithEvents btnScancel As Button
    Friend WithEvents btnSdel As Button
    Friend WithEvents btnSreceipt As Button
    Friend WithEvents btnSOK As Button
End Class
