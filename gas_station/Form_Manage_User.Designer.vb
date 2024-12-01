<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form_Manage_User
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
        Dim resources As ComponentModel.ComponentResourceManager = New ComponentModel.ComponentResourceManager(GetType(Form_Manage_User))
        dgvUser = New DataGridView()
        btnUserSales = New Button()
        btnBackMain = New Button()
        btnToggle = New Button()
        CType(dgvUser, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' dgvUser
        ' 
        dgvUser.AllowUserToAddRows = False
        dgvUser.AllowUserToDeleteRows = False
        dgvUser.AllowUserToOrderColumns = True
        dgvUser.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells
        dgvUser.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        dgvUser.Location = New Point(14, 37)
        dgvUser.Name = "dgvUser"
        dgvUser.ReadOnly = True
        dgvUser.RowHeadersWidth = 51
        dgvUser.RowTemplate.Height = 29
        dgvUser.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        dgvUser.Size = New Size(418, 196)
        dgvUser.TabIndex = 1
        ' 
        ' btnUserSales
        ' 
        btnUserSales.FlatStyle = FlatStyle.Flat
        btnUserSales.Font = New Font("Arial Narrow", 12F, FontStyle.Regular, GraphicsUnit.Point)
        btnUserSales.Location = New Point(29, 272)
        btnUserSales.Name = "btnUserSales"
        btnUserSales.Size = New Size(161, 39)
        btnUserSales.TabIndex = 2
        btnUserSales.Text = "VIEW USER SALES"
        btnUserSales.UseVisualStyleBackColor = True
        ' 
        ' btnBackMain
        ' 
        btnBackMain.FlatStyle = FlatStyle.Flat
        btnBackMain.Font = New Font("Arial Narrow", 12F, FontStyle.Regular, GraphicsUnit.Point)
        btnBackMain.Location = New Point(168, 336)
        btnBackMain.Name = "btnBackMain"
        btnBackMain.Size = New Size(109, 39)
        btnBackMain.TabIndex = 3
        btnBackMain.Text = "BACK"
        btnBackMain.UseVisualStyleBackColor = True
        ' 
        ' btnToggle
        ' 
        btnToggle.FlatStyle = FlatStyle.Flat
        btnToggle.Font = New Font("Arial Narrow", 12F, FontStyle.Regular, GraphicsUnit.Point)
        btnToggle.Location = New Point(255, 272)
        btnToggle.Name = "btnToggle"
        btnToggle.Size = New Size(161, 39)
        btnToggle.TabIndex = 4
        btnToggle.Text = "TOGGLE"
        btnToggle.UseVisualStyleBackColor = True
        ' 
        ' Form_Manage_User
        ' 
        AutoScaleDimensions = New SizeF(8F, 20F)
        AutoScaleMode = AutoScaleMode.Font
        BackgroundImage = CType(resources.GetObject("$this.BackgroundImage"), Image)
        ClientSize = New Size(449, 389)
        Controls.Add(btnToggle)
        Controls.Add(btnBackMain)
        Controls.Add(btnUserSales)
        Controls.Add(dgvUser)
        FormBorderStyle = FormBorderStyle.None
        Name = "Form_Manage_User"
        StartPosition = FormStartPosition.CenterScreen
        Text = "manage_user"
        CType(dgvUser, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
    End Sub
    Friend WithEvents dgvUser As DataGridView
    Friend WithEvents btnUserSales As Button
    Friend WithEvents btnBackMain As Button
    Friend WithEvents btnToggle As Button
End Class
