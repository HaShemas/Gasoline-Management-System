<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Form_Main
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
        Dim resources As ComponentModel.ComponentResourceManager = New ComponentModel.ComponentResourceManager(GetType(Form_Main))
        Label1 = New Label()
        Panel1 = New Panel()
        TabControl1 = New TabControl()
        TabPage1 = New TabPage()
        dgvSale = New DataGridView()
        btncreate = New Button()
        txtSaleSearch = New TextBox()
        btnSview = New Button()
        TabPage2 = New TabPage()
        detReport = New Button()
        dgvReport = New DataGridView()
        dtpDay = New DateTimePicker()
        TabPage3 = New TabPage()
        Label7 = New Label()
        Label6 = New Label()
        btnUpdateInv = New Button()
        dgvpInventory = New DataGridView()
        dgvInventory = New DataGridView()
        TabPage4 = New TabPage()
        dgvDelivery = New DataGridView()
        btnCreateDel = New Button()
        txtDelSearch = New TextBox()
        btnViewDel = New Button()
        btnManageUser = New Button()
        Panel2 = New Panel()
        Button6 = New Button()
        Label2 = New Label()
        Label3 = New Label()
        txtUserID = New TextBox()
        txtUsertype = New TextBox()
        Label4 = New Label()
        Label5 = New Label()
        txtFname = New TextBox()
        txtLname = New TextBox()
        btnCreateAcc = New Button()
        TabControl1.SuspendLayout()
        TabPage1.SuspendLayout()
        CType(dgvSale, ComponentModel.ISupportInitialize).BeginInit()
        TabPage2.SuspendLayout()
        CType(dgvReport, ComponentModel.ISupportInitialize).BeginInit()
        TabPage3.SuspendLayout()
        CType(dgvpInventory, ComponentModel.ISupportInitialize).BeginInit()
        CType(dgvInventory, ComponentModel.ISupportInitialize).BeginInit()
        TabPage4.SuspendLayout()
        CType(dgvDelivery, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.BackColor = Color.Maroon
        Label1.Font = New Font("Elephant", 18F, FontStyle.Bold, GraphicsUnit.Point)
        Label1.ForeColor = Color.Gold
        Label1.Location = New Point(74, 29)
        Label1.Name = "Label1"
        Label1.Size = New Size(975, 38)
        Label1.TabIndex = 0
        Label1.Text = "SHELL GASOLINE STATION MANAGEMENT SYSTEM" & vbCrLf
        ' 
        ' Panel1
        ' 
        Panel1.BackColor = Color.Gray
        Panel1.Location = New Point(3, 88)
        Panel1.Name = "Panel1"
        Panel1.Size = New Size(1157, 3)
        Panel1.TabIndex = 1
        ' 
        ' TabControl1
        ' 
        TabControl1.Controls.Add(TabPage1)
        TabControl1.Controls.Add(TabPage2)
        TabControl1.Controls.Add(TabPage3)
        TabControl1.Controls.Add(TabPage4)
        TabControl1.Location = New Point(11, 96)
        TabControl1.Name = "TabControl1"
        TabControl1.SelectedIndex = 0
        TabControl1.Size = New Size(1141, 531)
        TabControl1.TabIndex = 2
        ' 
        ' TabPage1
        ' 
        TabPage1.Controls.Add(dgvSale)
        TabPage1.Controls.Add(btncreate)
        TabPage1.Controls.Add(txtSaleSearch)
        TabPage1.Controls.Add(btnSview)
        TabPage1.Font = New Font("Arial Narrow", 13.8F, FontStyle.Regular, GraphicsUnit.Point)
        TabPage1.Location = New Point(4, 29)
        TabPage1.Name = "TabPage1"
        TabPage1.Padding = New Padding(3)
        TabPage1.Size = New Size(1133, 498)
        TabPage1.TabIndex = 0
        TabPage1.Text = "SALES"
        TabPage1.UseVisualStyleBackColor = True
        ' 
        ' dgvSale
        ' 
        dgvSale.AllowUserToAddRows = False
        dgvSale.AllowUserToDeleteRows = False
        dgvSale.AllowUserToOrderColumns = True
        dgvSale.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        dgvSale.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        dgvSale.Location = New Point(25, 104)
        dgvSale.Name = "dgvSale"
        dgvSale.ReadOnly = True
        dgvSale.RowHeadersWidth = 51
        dgvSale.RowTemplate.Height = 29
        dgvSale.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        dgvSale.Size = New Size(1073, 272)
        dgvSale.TabIndex = 0
        ' 
        ' btncreate
        ' 
        btncreate.Location = New Point(1009, 24)
        btncreate.Name = "btncreate"
        btncreate.Size = New Size(107, 43)
        btncreate.TabIndex = 4
        btncreate.Text = "CREATE +"
        btncreate.UseVisualStyleBackColor = True
        ' 
        ' txtSaleSearch
        ' 
        txtSaleSearch.Font = New Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point)
        txtSaleSearch.Location = New Point(437, 56)
        txtSaleSearch.Multiline = True
        txtSaleSearch.Name = "txtSaleSearch"
        txtSaleSearch.PlaceholderText = "Search . . ."
        txtSaleSearch.Size = New Size(249, 41)
        txtSaleSearch.TabIndex = 3
        ' 
        ' btnSview
        ' 
        btnSview.Location = New Point(489, 417)
        btnSview.Name = "btnSview"
        btnSview.Size = New Size(165, 43)
        btnSview.TabIndex = 5
        btnSview.Text = "VIEW DETAILS"
        btnSview.UseVisualStyleBackColor = True
        ' 
        ' TabPage2
        ' 
        TabPage2.Controls.Add(detReport)
        TabPage2.Controls.Add(dgvReport)
        TabPage2.Controls.Add(dtpDay)
        TabPage2.Font = New Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point)
        TabPage2.Location = New Point(4, 29)
        TabPage2.Name = "TabPage2"
        TabPage2.Padding = New Padding(3)
        TabPage2.Size = New Size(1133, 498)
        TabPage2.TabIndex = 1
        TabPage2.Text = "SALES REPORT"
        TabPage2.UseVisualStyleBackColor = True
        ' 
        ' detReport
        ' 
        detReport.Location = New Point(489, 417)
        detReport.Name = "detReport"
        detReport.Size = New Size(165, 43)
        detReport.TabIndex = 6
        detReport.Text = "VIEW DETAILS"
        detReport.UseVisualStyleBackColor = True
        ' 
        ' dgvReport
        ' 
        dgvReport.AllowUserToAddRows = False
        dgvReport.AllowUserToDeleteRows = False
        dgvReport.AllowUserToOrderColumns = True
        dgvReport.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        dgvReport.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        dgvReport.Location = New Point(30, 108)
        dgvReport.Name = "dgvReport"
        dgvReport.ReadOnly = True
        dgvReport.RowHeadersWidth = 51
        dgvReport.RowTemplate.Height = 29
        dgvReport.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        dgvReport.Size = New Size(1073, 277)
        dgvReport.TabIndex = 2
        ' 
        ' dtpDay
        ' 
        dtpDay.Location = New Point(454, 24)
        dtpDay.Margin = New Padding(3, 4, 3, 4)
        dtpDay.Name = "dtpDay"
        dtpDay.Size = New Size(228, 34)
        dtpDay.TabIndex = 1
        ' 
        ' TabPage3
        ' 
        TabPage3.Controls.Add(Label7)
        TabPage3.Controls.Add(Label6)
        TabPage3.Controls.Add(btnUpdateInv)
        TabPage3.Controls.Add(dgvpInventory)
        TabPage3.Controls.Add(dgvInventory)
        TabPage3.Font = New Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point)
        TabPage3.Location = New Point(4, 29)
        TabPage3.Name = "TabPage3"
        TabPage3.Padding = New Padding(3)
        TabPage3.Size = New Size(1133, 498)
        TabPage3.TabIndex = 2
        TabPage3.Text = "INVENTORY"
        TabPage3.UseVisualStyleBackColor = True
        ' 
        ' Label7
        ' 
        Label7.AutoSize = True
        Label7.Font = New Font("Arial Narrow", 13.8F, FontStyle.Bold, GraphicsUnit.Point)
        Label7.Location = New Point(528, 233)
        Label7.Name = "Label7"
        Label7.Size = New Size(110, 27)
        Label7.TabIndex = 17
        Label7.Text = "PHYSICAL"
        ' 
        ' Label6
        ' 
        Label6.AutoSize = True
        Label6.Font = New Font("Arial Narrow", 13.8F, FontStyle.Bold, GraphicsUnit.Point)
        Label6.Location = New Point(528, 15)
        Label6.Name = "Label6"
        Label6.Size = New Size(92, 27)
        Label6.TabIndex = 16
        Label6.Text = "SYSTEM"
        ' 
        ' btnUpdateInv
        ' 
        btnUpdateInv.Location = New Point(520, 431)
        btnUpdateInv.Name = "btnUpdateInv"
        btnUpdateInv.Size = New Size(107, 43)
        btnUpdateInv.TabIndex = 5
        btnUpdateInv.Text = "UPDATE"
        btnUpdateInv.UseVisualStyleBackColor = True
        ' 
        ' dgvpInventory
        ' 
        dgvpInventory.AllowUserToAddRows = False
        dgvpInventory.AllowUserToDeleteRows = False
        dgvpInventory.AllowUserToOrderColumns = True
        dgvpInventory.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        dgvpInventory.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        dgvpInventory.Location = New Point(99, 267)
        dgvpInventory.Name = "dgvpInventory"
        dgvpInventory.ReadOnly = True
        dgvpInventory.RowHeadersWidth = 51
        dgvpInventory.RowTemplate.Height = 29
        dgvpInventory.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        dgvpInventory.Size = New Size(913, 159)
        dgvpInventory.TabIndex = 2
        ' 
        ' dgvInventory
        ' 
        dgvInventory.AllowUserToAddRows = False
        dgvInventory.AllowUserToDeleteRows = False
        dgvInventory.AllowUserToOrderColumns = True
        dgvInventory.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        dgvInventory.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        dgvInventory.Location = New Point(99, 48)
        dgvInventory.Name = "dgvInventory"
        dgvInventory.ReadOnly = True
        dgvInventory.RowHeadersWidth = 51
        dgvInventory.RowTemplate.Height = 29
        dgvInventory.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        dgvInventory.Size = New Size(913, 159)
        dgvInventory.TabIndex = 1
        ' 
        ' TabPage4
        ' 
        TabPage4.Controls.Add(dgvDelivery)
        TabPage4.Controls.Add(btnCreateDel)
        TabPage4.Controls.Add(txtDelSearch)
        TabPage4.Controls.Add(btnViewDel)
        TabPage4.Font = New Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point)
        TabPage4.Location = New Point(4, 29)
        TabPage4.Name = "TabPage4"
        TabPage4.Size = New Size(1133, 498)
        TabPage4.TabIndex = 3
        TabPage4.Text = "DELIVERY"
        TabPage4.UseVisualStyleBackColor = True
        ' 
        ' dgvDelivery
        ' 
        dgvDelivery.AllowUserToAddRows = False
        dgvDelivery.AllowUserToDeleteRows = False
        dgvDelivery.AllowUserToOrderColumns = True
        dgvDelivery.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        dgvDelivery.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        dgvDelivery.Location = New Point(53, 104)
        dgvDelivery.Name = "dgvDelivery"
        dgvDelivery.ReadOnly = True
        dgvDelivery.RowHeadersWidth = 51
        dgvDelivery.RowTemplate.Height = 29
        dgvDelivery.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        dgvDelivery.Size = New Size(1027, 272)
        dgvDelivery.TabIndex = 8
        ' 
        ' btnCreateDel
        ' 
        btnCreateDel.Location = New Point(1009, 19)
        btnCreateDel.Name = "btnCreateDel"
        btnCreateDel.Size = New Size(107, 43)
        btnCreateDel.TabIndex = 10
        btnCreateDel.Text = "CREATE +"
        btnCreateDel.UseVisualStyleBackColor = True
        ' 
        ' txtDelSearch
        ' 
        txtDelSearch.Font = New Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point)
        txtDelSearch.Location = New Point(454, 44)
        txtDelSearch.Multiline = True
        txtDelSearch.Name = "txtDelSearch"
        txtDelSearch.PlaceholderText = "Search . . ."
        txtDelSearch.Size = New Size(249, 41)
        txtDelSearch.TabIndex = 9
        ' 
        ' btnViewDel
        ' 
        btnViewDel.Location = New Point(519, 419)
        btnViewDel.Name = "btnViewDel"
        btnViewDel.Size = New Size(165, 43)
        btnViewDel.TabIndex = 11
        btnViewDel.Text = "VIEW DETAILS"
        btnViewDel.UseVisualStyleBackColor = True
        ' 
        ' btnManageUser
        ' 
        btnManageUser.BackColor = Color.Maroon
        btnManageUser.ForeColor = Color.Gold
        btnManageUser.Location = New Point(984, 657)
        btnManageUser.Name = "btnManageUser"
        btnManageUser.Size = New Size(149, 43)
        btnManageUser.TabIndex = 8
        btnManageUser.Text = "MANAGE USER SALES"
        btnManageUser.UseVisualStyleBackColor = False
        ' 
        ' Panel2
        ' 
        Panel2.BackColor = SystemColors.ActiveCaptionText
        Panel2.Location = New Point(3, 627)
        Panel2.Name = "Panel2"
        Panel2.Size = New Size(1157, 3)
        Panel2.TabIndex = 2
        ' 
        ' Button6
        ' 
        Button6.BackColor = Color.Maroon
        Button6.ForeColor = Color.Gold
        Button6.Location = New Point(521, 773)
        Button6.Name = "Button6"
        Button6.Size = New Size(149, 43)
        Button6.TabIndex = 10
        Button6.Text = "LOGOUT"
        Button6.UseVisualStyleBackColor = False
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.BackColor = Color.Maroon
        Label2.Font = New Font("Arial Narrow", 13.8F, FontStyle.Bold, GraphicsUnit.Point)
        Label2.ForeColor = Color.Gold
        Label2.Location = New Point(19, 657)
        Label2.Name = "Label2"
        Label2.Size = New Size(70, 27)
        Label2.TabIndex = 11
        Label2.Text = "userID"
        ' 
        ' Label3
        ' 
        Label3.AutoSize = True
        Label3.BackColor = Color.Maroon
        Label3.Font = New Font("Elephant", 10.2F, FontStyle.Bold, GraphicsUnit.Point)
        Label3.ForeColor = Color.Gold
        Label3.Location = New Point(27, 715)
        Label3.Name = "Label3"
        Label3.Size = New Size(54, 22)
        Label3.TabIndex = 12
        Label3.Text = "User"
        Label3.TextAlign = ContentAlignment.TopCenter
        ' 
        ' txtUserID
        ' 
        txtUserID.BackColor = Color.White
        txtUserID.Enabled = False
        txtUserID.Location = New Point(101, 645)
        txtUserID.Multiline = True
        txtUserID.Name = "txtUserID"
        txtUserID.Size = New Size(198, 44)
        txtUserID.TabIndex = 13
        ' 
        ' txtUsertype
        ' 
        txtUsertype.BackColor = Color.WhiteSmoke
        txtUsertype.Enabled = False
        txtUsertype.Location = New Point(99, 700)
        txtUsertype.Multiline = True
        txtUsertype.Name = "txtUsertype"
        txtUsertype.Size = New Size(198, 44)
        txtUsertype.TabIndex = 14
        ' 
        ' Label4
        ' 
        Label4.AutoSize = True
        Label4.BackColor = Color.Maroon
        Label4.Font = New Font("Arial Narrow", 13.8F, FontStyle.Bold, GraphicsUnit.Point)
        Label4.ForeColor = Color.Gold
        Label4.Location = New Point(345, 655)
        Label4.Name = "Label4"
        Label4.Size = New Size(101, 27)
        Label4.TabIndex = 15
        Label4.Text = "Firstname"
        ' 
        ' Label5
        ' 
        Label5.AutoSize = True
        Label5.BackColor = Color.Maroon
        Label5.Font = New Font("Arial Narrow", 13.8F, FontStyle.Bold, GraphicsUnit.Point)
        Label5.ForeColor = Color.Gold
        Label5.Location = New Point(345, 709)
        Label5.Name = "Label5"
        Label5.Size = New Size(99, 27)
        Label5.TabIndex = 16
        Label5.Text = "Lastname"
        ' 
        ' txtFname
        ' 
        txtFname.BackColor = Color.WhiteSmoke
        txtFname.Enabled = False
        txtFname.Location = New Point(453, 645)
        txtFname.Multiline = True
        txtFname.Name = "txtFname"
        txtFname.Size = New Size(198, 44)
        txtFname.TabIndex = 17
        ' 
        ' txtLname
        ' 
        txtLname.BackColor = Color.WhiteSmoke
        txtLname.Enabled = False
        txtLname.Location = New Point(453, 700)
        txtLname.Multiline = True
        txtLname.Name = "txtLname"
        txtLname.Size = New Size(198, 44)
        txtLname.TabIndex = 18
        ' 
        ' btnCreateAcc
        ' 
        btnCreateAcc.BackColor = Color.Maroon
        btnCreateAcc.ForeColor = Color.Gold
        btnCreateAcc.Location = New Point(984, 715)
        btnCreateAcc.Name = "btnCreateAcc"
        btnCreateAcc.Size = New Size(149, 43)
        btnCreateAcc.TabIndex = 19
        btnCreateAcc.Text = "CREATE USER"
        btnCreateAcc.UseVisualStyleBackColor = False
        ' 
        ' Form_Main
        ' 
        AutoScaleDimensions = New SizeF(8F, 20F)
        AutoScaleMode = AutoScaleMode.Font
        BackgroundImage = CType(resources.GetObject("$this.BackgroundImage"), Image)
        ClientSize = New Size(1165, 829)
        Controls.Add(btnCreateAcc)
        Controls.Add(txtLname)
        Controls.Add(txtFname)
        Controls.Add(Label5)
        Controls.Add(Label4)
        Controls.Add(txtUsertype)
        Controls.Add(txtUserID)
        Controls.Add(Label3)
        Controls.Add(Label2)
        Controls.Add(Button6)
        Controls.Add(Panel2)
        Controls.Add(btnManageUser)
        Controls.Add(TabControl1)
        Controls.Add(Panel1)
        Controls.Add(Label1)
        FormBorderStyle = FormBorderStyle.None
        Name = "Form_Main"
        StartPosition = FormStartPosition.CenterScreen
        Text = "main"
        TabControl1.ResumeLayout(False)
        TabPage1.ResumeLayout(False)
        TabPage1.PerformLayout()
        CType(dgvSale, ComponentModel.ISupportInitialize).EndInit()
        TabPage2.ResumeLayout(False)
        CType(dgvReport, ComponentModel.ISupportInitialize).EndInit()
        TabPage3.ResumeLayout(False)
        TabPage3.PerformLayout()
        CType(dgvpInventory, ComponentModel.ISupportInitialize).EndInit()
        CType(dgvInventory, ComponentModel.ISupportInitialize).EndInit()
        TabPage4.ResumeLayout(False)
        TabPage4.PerformLayout()
        CType(dgvDelivery, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents Panel1 As Panel
    Friend WithEvents TabControl1 As TabControl
    Friend WithEvents TabPage1 As TabPage
    Friend WithEvents TabPage2 As TabPage
    Friend WithEvents TabPage3 As TabPage
    Friend WithEvents TabPage4 As TabPage
    Friend WithEvents txtSaleSearch As TextBox
    Friend WithEvents btncreate As Button
    Friend WithEvents btnSview As Button
    Friend WithEvents btnManageUser As Button
    Friend WithEvents Panel2 As Panel
    Friend WithEvents Button6 As Button
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents txtUserID As TextBox
    Friend WithEvents txtUsertype As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents txtFname As TextBox
    Friend WithEvents txtLname As TextBox
    Friend WithEvents dgvSale As DataGridView
    Friend WithEvents dgvpInventory As DataGridView
    Friend WithEvents dgvInventory As DataGridView
    Friend WithEvents dgvDelivery As DataGridView
    Friend WithEvents btnCreateDel As Button
    Friend WithEvents txtDelSearch As TextBox
    Friend WithEvents btnViewDel As Button
    Friend WithEvents dgvReport As DataGridView
    Friend WithEvents dtpDay As DateTimePicker
    Friend WithEvents detReport As Button
    Friend WithEvents Label7 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents btnUpdateInv As Button
    Friend WithEvents btnCreateAcc As Button
End Class
