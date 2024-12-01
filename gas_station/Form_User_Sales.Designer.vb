<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form_User_Sales
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
        Dim resources As ComponentModel.ComponentResourceManager = New ComponentModel.ComponentResourceManager(GetType(Form_User_Sales))
        btnBackMain = New Button()
        dgvUserSales = New DataGridView()
        CType(dgvUserSales, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' btnBackMain
        ' 
        btnBackMain.BackColor = Color.Maroon
        btnBackMain.FlatStyle = FlatStyle.Flat
        btnBackMain.Font = New Font("Arial Narrow", 12F, FontStyle.Regular, GraphicsUnit.Point)
        btnBackMain.Location = New Point(293, 233)
        btnBackMain.Margin = New Padding(3, 2, 3, 2)
        btnBackMain.Name = "btnBackMain"
        btnBackMain.Size = New Size(95, 29)
        btnBackMain.TabIndex = 5
        btnBackMain.Text = "BACK"
        btnBackMain.UseVisualStyleBackColor = False
        ' 
        ' dgvUserSales
        ' 
        dgvUserSales.AllowUserToAddRows = False
        dgvUserSales.AllowUserToDeleteRows = False
        dgvUserSales.AllowUserToOrderColumns = True
        dgvUserSales.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells
        dgvUserSales.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        dgvUserSales.Location = New Point(12, 19)
        dgvUserSales.Margin = New Padding(3, 2, 3, 2)
        dgvUserSales.Name = "dgvUserSales"
        dgvUserSales.ReadOnly = True
        dgvUserSales.RowHeadersWidth = 51
        dgvUserSales.RowTemplate.Height = 29
        dgvUserSales.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        dgvUserSales.Size = New Size(621, 169)
        dgvUserSales.TabIndex = 4
        ' 
        ' Form_User_Sales
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        BackgroundImage = CType(resources.GetObject("$this.BackgroundImage"), Image)
        ClientSize = New Size(654, 289)
        Controls.Add(btnBackMain)
        Controls.Add(dgvUserSales)
        Name = "Form_User_Sales"
        Text = "Form_User_Sales"
        CType(dgvUserSales, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
    End Sub

    Friend WithEvents btnBackMain As Button
    Friend WithEvents dgvUserSales As DataGridView
End Class
