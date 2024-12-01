<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Form_CRUD_Del
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim resources As ComponentModel.ComponentResourceManager = New ComponentModel.ComponentResourceManager(GetType(Form_CRUD_Del))
        Label2 = New Label()
        txtSuppID = New TextBox()
        delDiesel = New PictureBox()
        delPremium = New PictureBox()
        delRegular = New PictureBox()
        txtdelLprice = New TextBox()
        lblLitersAmnt = New Label()
        Label13 = New Label()
        Label12 = New Label()
        txtdelLiters = New TextBox()
        Label11 = New Label()
        btnAddDel = New Button()
        btnUpdateDel = New Button()
        dgvDelCart = New DataGridView()
        btnDelCancel = New Button()
        btnDelConfirm = New Button()
        txtDelDiscnt = New TextBox()
        Label18 = New Label()
        Label16 = New Label()
        lbltotalAmount = New Label()
        btnDeletedel = New Button()
        cmbSupplier = New ComboBox()
        txtPhone = New TextBox()
        Label1 = New Label()
        Label3 = New Label()
        btnOK = New Button()
        txtAddress = New TextBox()
        Label4 = New Label()
        CType(delDiesel, ComponentModel.ISupportInitialize).BeginInit()
        CType(delPremium, ComponentModel.ISupportInitialize).BeginInit()
        CType(delRegular, ComponentModel.ISupportInitialize).BeginInit()
        CType(dgvDelCart, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.Font = New Font("Arial Narrow", 13.8F, FontStyle.Regular, GraphicsUnit.Point)
        Label2.Location = New Point(65, 23)
        Label2.Name = "Label2"
        Label2.Size = New Size(85, 23)
        Label2.TabIndex = 6
        Label2.Text = "Supplier ID"
        ' 
        ' txtSuppID
        ' 
        txtSuppID.Enabled = False
        txtSuppID.Location = New Point(65, 48)
        txtSuppID.Margin = New Padding(3, 2, 3, 2)
        txtSuppID.Multiline = True
        txtSuppID.Name = "txtSuppID"
        txtSuppID.Size = New Size(142, 26)
        txtSuppID.TabIndex = 7
        ' 
        ' delDiesel
        ' 
        delDiesel.Image = My.Resources.Resources.Diesel
        delDiesel.Location = New Point(52, 171)
        delDiesel.Margin = New Padding(3, 2, 3, 2)
        delDiesel.Name = "delDiesel"
        delDiesel.Size = New Size(169, 107)
        delDiesel.SizeMode = PictureBoxSizeMode.StretchImage
        delDiesel.TabIndex = 9
        delDiesel.TabStop = False
        ' 
        ' delPremium
        ' 
        delPremium.Image = My.Resources.Resources.Premium
        delPremium.Location = New Point(279, 171)
        delPremium.Margin = New Padding(3, 2, 3, 2)
        delPremium.Name = "delPremium"
        delPremium.Size = New Size(169, 107)
        delPremium.SizeMode = PictureBoxSizeMode.StretchImage
        delPremium.TabIndex = 10
        delPremium.TabStop = False
        ' 
        ' delRegular
        ' 
        delRegular.Image = My.Resources.Resources.Unleaded
        delRegular.Location = New Point(504, 171)
        delRegular.Margin = New Padding(3, 2, 3, 2)
        delRegular.Name = "delRegular"
        delRegular.Size = New Size(169, 107)
        delRegular.SizeMode = PictureBoxSizeMode.StretchImage
        delRegular.TabIndex = 11
        delRegular.TabStop = False
        ' 
        ' txtdelLprice
        ' 
        txtdelLprice.Location = New Point(301, 346)
        txtdelLprice.Margin = New Padding(3, 2, 3, 2)
        txtdelLprice.Multiline = True
        txtdelLprice.Name = "txtdelLprice"
        txtdelLprice.Size = New Size(142, 26)
        txtdelLprice.TabIndex = 19
        ' 
        ' lblLitersAmnt
        ' 
        lblLitersAmnt.AutoSize = True
        lblLitersAmnt.Font = New Font("Arial Narrow", 13.8F, FontStyle.Regular, GraphicsUnit.Point)
        lblLitersAmnt.Location = New Point(547, 349)
        lblLitersAmnt.Name = "lblLitersAmnt"
        lblLitersAmnt.Size = New Size(41, 23)
        lblLitersAmnt.TabIndex = 18
        lblLitersAmnt.Text = "0.00"
        ' 
        ' Label13
        ' 
        Label13.AutoSize = True
        Label13.Font = New Font("Arial Narrow", 13.8F, FontStyle.Regular, GraphicsUnit.Point)
        Label13.Location = New Point(538, 322)
        Label13.Name = "Label13"
        Label13.Size = New Size(63, 23)
        Label13.TabIndex = 16
        Label13.Text = "Amount"
        ' 
        ' Label12
        ' 
        Label12.AutoSize = True
        Label12.Font = New Font("Arial Narrow", 13.8F, FontStyle.Regular, GraphicsUnit.Point)
        Label12.Location = New Point(301, 322)
        Label12.Name = "Label12"
        Label12.Size = New Size(45, 23)
        Label12.TabIndex = 15
        Label12.Text = "Price"
        ' 
        ' txtdelLiters
        ' 
        txtdelLiters.Location = New Point(93, 346)
        txtdelLiters.Margin = New Padding(3, 2, 3, 2)
        txtdelLiters.Multiline = True
        txtdelLiters.Name = "txtdelLiters"
        txtdelLiters.Size = New Size(142, 26)
        txtdelLiters.TabIndex = 14
        ' 
        ' Label11
        ' 
        Label11.AutoSize = True
        Label11.Font = New Font("Arial Narrow", 13.8F, FontStyle.Regular, GraphicsUnit.Point)
        Label11.Location = New Point(93, 322)
        Label11.Name = "Label11"
        Label11.Size = New Size(47, 23)
        Label11.TabIndex = 13
        Label11.Text = "Liters"
        ' 
        ' btnAddDel
        ' 
        btnAddDel.Location = New Point(181, 426)
        btnAddDel.Margin = New Padding(3, 2, 3, 2)
        btnAddDel.Name = "btnAddDel"
        btnAddDel.Size = New Size(113, 33)
        btnAddDel.TabIndex = 16
        btnAddDel.Text = "ADD"
        btnAddDel.UseVisualStyleBackColor = True
        ' 
        ' btnUpdateDel
        ' 
        btnUpdateDel.Location = New Point(319, 423)
        btnUpdateDel.Margin = New Padding(3, 2, 3, 2)
        btnUpdateDel.Name = "btnUpdateDel"
        btnUpdateDel.Size = New Size(113, 36)
        btnUpdateDel.TabIndex = 17
        btnUpdateDel.Text = "UPDATE"
        btnUpdateDel.UseVisualStyleBackColor = True
        ' 
        ' dgvDelCart
        ' 
        dgvDelCart.AllowUserToAddRows = False
        dgvDelCart.AllowUserToDeleteRows = False
        dgvDelCart.AllowUserToOrderColumns = True
        dgvDelCart.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        dgvDelCart.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        dgvDelCart.Location = New Point(65, 472)
        dgvDelCart.Margin = New Padding(3, 2, 3, 2)
        dgvDelCart.Name = "dgvDelCart"
        dgvDelCart.ReadOnly = True
        dgvDelCart.RowHeadersWidth = 51
        dgvDelCart.RowTemplate.Height = 29
        dgvDelCart.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        dgvDelCart.Size = New Size(584, 122)
        dgvDelCart.TabIndex = 18
        ' 
        ' btnDelCancel
        ' 
        btnDelCancel.Location = New Point(408, 715)
        btnDelCancel.Margin = New Padding(3, 2, 3, 2)
        btnDelCancel.Name = "btnDelCancel"
        btnDelCancel.Size = New Size(113, 33)
        btnDelCancel.TabIndex = 39
        btnDelCancel.Text = "CANCEL"
        btnDelCancel.UseVisualStyleBackColor = True
        ' 
        ' btnDelConfirm
        ' 
        btnDelConfirm.Location = New Point(170, 715)
        btnDelConfirm.Margin = New Padding(3, 2, 3, 2)
        btnDelConfirm.Name = "btnDelConfirm"
        btnDelConfirm.Size = New Size(113, 33)
        btnDelConfirm.TabIndex = 37
        btnDelConfirm.Text = "CONFIRM"
        btnDelConfirm.UseVisualStyleBackColor = True
        ' 
        ' txtDelDiscnt
        ' 
        txtDelDiscnt.Location = New Point(147, 639)
        txtDelDiscnt.Margin = New Padding(3, 2, 3, 2)
        txtDelDiscnt.Multiline = True
        txtDelDiscnt.Name = "txtDelDiscnt"
        txtDelDiscnt.Size = New Size(142, 26)
        txtDelDiscnt.TabIndex = 32
        ' 
        ' Label18
        ' 
        Label18.AutoSize = True
        Label18.Font = New Font("Arial Narrow", 13.8F, FontStyle.Regular, GraphicsUnit.Point)
        Label18.Location = New Point(171, 615)
        Label18.Name = "Label18"
        Label18.Size = New Size(86, 23)
        Label18.TabIndex = 31
        Label18.Text = "Discount %"
        ' 
        ' Label16
        ' 
        Label16.AutoSize = True
        Label16.Font = New Font("Arial Narrow", 13.8F, FontStyle.Regular, GraphicsUnit.Point)
        Label16.Location = New Point(453, 615)
        Label16.Name = "Label16"
        Label16.Size = New Size(91, 23)
        Label16.TabIndex = 29
        Label16.Text = "Grand Total"
        ' 
        ' lbltotalAmount
        ' 
        lbltotalAmount.AutoSize = True
        lbltotalAmount.Font = New Font("Arial Narrow", 13.8F, FontStyle.Regular, GraphicsUnit.Point)
        lbltotalAmount.Location = New Point(468, 639)
        lbltotalAmount.Name = "lbltotalAmount"
        lbltotalAmount.Size = New Size(41, 23)
        lbltotalAmount.TabIndex = 40
        lbltotalAmount.Text = "0.00"
        ' 
        ' btnDeletedel
        ' 
        btnDeletedel.Location = New Point(474, 423)
        btnDeletedel.Margin = New Padding(3, 2, 3, 2)
        btnDeletedel.Name = "btnDeletedel"
        btnDeletedel.Size = New Size(113, 36)
        btnDeletedel.TabIndex = 42
        btnDeletedel.Text = "DELETE"
        btnDeletedel.UseVisualStyleBackColor = True
        ' 
        ' cmbSupplier
        ' 
        cmbSupplier.DropDownStyle = ComboBoxStyle.DropDownList
        cmbSupplier.FormattingEnabled = True
        cmbSupplier.Items.AddRange(New Object() {"Royal Dutch Shell", "ExxonMobil"})
        cmbSupplier.Location = New Point(289, 51)
        cmbSupplier.Name = "cmbSupplier"
        cmbSupplier.Size = New Size(169, 23)
        cmbSupplier.TabIndex = 43
        ' 
        ' txtPhone
        ' 
        txtPhone.Enabled = False
        txtPhone.Location = New Point(65, 121)
        txtPhone.Margin = New Padding(3, 2, 3, 2)
        txtPhone.Multiline = True
        txtPhone.Name = "txtPhone"
        txtPhone.Size = New Size(142, 26)
        txtPhone.TabIndex = 45
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Font = New Font("Arial Narrow", 13.8F, FontStyle.Regular, GraphicsUnit.Point)
        Label1.Location = New Point(65, 96)
        Label1.Name = "Label1"
        Label1.Size = New Size(56, 23)
        Label1.TabIndex = 44
        Label1.Text = "Phone"
        ' 
        ' Label3
        ' 
        Label3.AutoSize = True
        Label3.Font = New Font("Arial Narrow", 13.8F, FontStyle.Regular, GraphicsUnit.Point)
        Label3.Location = New Point(289, 25)
        Label3.Name = "Label3"
        Label3.Size = New Size(71, 23)
        Label3.TabIndex = 46
        Label3.Text = "Supplier "
        ' 
        ' btnOK
        ' 
        btnOK.Location = New Point(289, 715)
        btnOK.Margin = New Padding(3, 2, 3, 2)
        btnOK.Name = "btnOK"
        btnOK.Size = New Size(113, 33)
        btnOK.TabIndex = 47
        btnOK.Text = "OK"
        btnOK.UseVisualStyleBackColor = True
        ' 
        ' txtAddress
        ' 
        txtAddress.Enabled = False
        txtAddress.Location = New Point(289, 121)
        txtAddress.Margin = New Padding(3, 2, 3, 2)
        txtAddress.Multiline = True
        txtAddress.Name = "txtAddress"
        txtAddress.Size = New Size(142, 26)
        txtAddress.TabIndex = 49
        ' 
        ' Label4
        ' 
        Label4.AutoSize = True
        Label4.Font = New Font("Arial Narrow", 13.8F, FontStyle.Regular, GraphicsUnit.Point)
        Label4.Location = New Point(289, 96)
        Label4.Name = "Label4"
        Label4.Size = New Size(68, 23)
        Label4.TabIndex = 48
        Label4.Text = "Address"
        ' 
        ' Form_CRUD_Del
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        BackgroundImage = CType(resources.GetObject("$this.BackgroundImage"), Image)
        ClientSize = New Size(740, 767)
        Controls.Add(txtAddress)
        Controls.Add(Label4)
        Controls.Add(btnOK)
        Controls.Add(Label3)
        Controls.Add(txtPhone)
        Controls.Add(Label1)
        Controls.Add(cmbSupplier)
        Controls.Add(txtdelLprice)
        Controls.Add(btnDeletedel)
        Controls.Add(lblLitersAmnt)
        Controls.Add(Label13)
        Controls.Add(lbltotalAmount)
        Controls.Add(Label12)
        Controls.Add(btnDelCancel)
        Controls.Add(txtdelLiters)
        Controls.Add(Label11)
        Controls.Add(btnDelConfirm)
        Controls.Add(txtDelDiscnt)
        Controls.Add(Label18)
        Controls.Add(Label16)
        Controls.Add(dgvDelCart)
        Controls.Add(btnUpdateDel)
        Controls.Add(btnAddDel)
        Controls.Add(delRegular)
        Controls.Add(delPremium)
        Controls.Add(delDiesel)
        Controls.Add(txtSuppID)
        Controls.Add(Label2)
        FormBorderStyle = FormBorderStyle.None
        Margin = New Padding(3, 2, 3, 2)
        Name = "Form_CRUD_Del"
        StartPosition = FormStartPosition.CenterScreen
        Text = "adding_update_delivery_"
        CType(delDiesel, ComponentModel.ISupportInitialize).EndInit()
        CType(delPremium, ComponentModel.ISupportInitialize).EndInit()
        CType(delRegular, ComponentModel.ISupportInitialize).EndInit()
        CType(dgvDelCart, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
        PerformLayout()
    End Sub
    Friend WithEvents Label2 As Label
    Friend WithEvents txtSuppID As TextBox
    Friend WithEvents delDiesel As PictureBox
    Friend WithEvents delPremium As PictureBox
    Friend WithEvents delRegular As PictureBox
    Friend WithEvents lblLitersAmnt As Label
    Friend WithEvents Label13 As Label
    Friend WithEvents Label12 As Label
    Friend WithEvents txtdelLiters As TextBox
    Friend WithEvents Label11 As Label
    Friend WithEvents btnAddDel As Button
    Friend WithEvents btnUpdateDel As Button
    Friend WithEvents dgvDelCart As DataGridView
    Friend WithEvents btnDelCancel As Button
    Friend WithEvents btnDelConfirm As Button
    Friend WithEvents txtDelDiscnt As TextBox
    Friend WithEvents Label18 As Label
    Friend WithEvents Label16 As Label
    Friend WithEvents txtdelLprice As TextBox
    Friend WithEvents lbltotalAmount As Label
    Friend WithEvents btnDeletedel As Button
    Friend WithEvents cmbSupplier As ComboBox
    Friend WithEvents txtPhone As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents btnOK As Button
    Friend WithEvents txtAddress As TextBox
    Friend WithEvents Label4 As Label
End Class
