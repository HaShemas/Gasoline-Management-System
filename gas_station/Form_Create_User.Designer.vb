<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form_Create_User
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
        Dim resources As ComponentModel.ComponentResourceManager = New ComponentModel.ComponentResourceManager(GetType(Form_Create_User))
        Label1 = New Label()
        txtCfname = New TextBox()
        btnCreateAcc = New Button()
        Panel1 = New Panel()
        Panel2 = New Panel()
        Label2 = New Label()
        txtClname = New TextBox()
        Panel3 = New Panel()
        Label3 = New Label()
        txtCusername = New TextBox()
        Panel4 = New Panel()
        Label4 = New Label()
        txtCpassword = New TextBox()
        btnAcancel = New Button()
        Panel1.SuspendLayout()
        Panel2.SuspendLayout()
        Panel3.SuspendLayout()
        Panel4.SuspendLayout()
        SuspendLayout()
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Font = New Font("Arial Narrow", 13.8F, FontStyle.Regular, GraphicsUnit.Point)
        Label1.Location = New Point(10, 14)
        Label1.Name = "Label1"
        Label1.Size = New Size(94, 27)
        Label1.TabIndex = 0
        Label1.Text = "Firstname"
        ' 
        ' txtCfname
        ' 
        txtCfname.Location = New Point(112, 8)
        txtCfname.Margin = New Padding(3, 4, 3, 4)
        txtCfname.Multiline = True
        txtCfname.Name = "txtCfname"
        txtCfname.Size = New Size(225, 40)
        txtCfname.TabIndex = 1
        ' 
        ' btnCreateAcc
        ' 
        btnCreateAcc.Location = New Point(86, 348)
        btnCreateAcc.Margin = New Padding(3, 4, 3, 4)
        btnCreateAcc.Name = "btnCreateAcc"
        btnCreateAcc.Size = New Size(94, 32)
        btnCreateAcc.TabIndex = 2
        btnCreateAcc.Text = "CREATE"
        btnCreateAcc.UseVisualStyleBackColor = True
        ' 
        ' Panel1
        ' 
        Panel1.BackColor = Color.Maroon
        Panel1.Controls.Add(Label1)
        Panel1.Controls.Add(txtCfname)
        Panel1.ForeColor = Color.Gold
        Panel1.Location = New Point(53, 69)
        Panel1.Name = "Panel1"
        Panel1.Size = New Size(354, 56)
        Panel1.TabIndex = 3
        ' 
        ' Panel2
        ' 
        Panel2.BackColor = Color.Maroon
        Panel2.Controls.Add(Label2)
        Panel2.Controls.Add(txtClname)
        Panel2.ForeColor = Color.Gold
        Panel2.Location = New Point(53, 131)
        Panel2.Name = "Panel2"
        Panel2.Size = New Size(354, 56)
        Panel2.TabIndex = 4
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.Font = New Font("Arial Narrow", 13.8F, FontStyle.Regular, GraphicsUnit.Point)
        Label2.Location = New Point(10, 14)
        Label2.Name = "Label2"
        Label2.Size = New Size(92, 27)
        Label2.TabIndex = 0
        Label2.Text = "Lastname"
        ' 
        ' txtClname
        ' 
        txtClname.Location = New Point(112, 8)
        txtClname.Margin = New Padding(3, 4, 3, 4)
        txtClname.Multiline = True
        txtClname.Name = "txtClname"
        txtClname.Size = New Size(225, 40)
        txtClname.TabIndex = 1
        ' 
        ' Panel3
        ' 
        Panel3.BackColor = Color.Maroon
        Panel3.Controls.Add(Label3)
        Panel3.Controls.Add(txtCusername)
        Panel3.ForeColor = Color.Gold
        Panel3.Location = New Point(53, 193)
        Panel3.Name = "Panel3"
        Panel3.Size = New Size(354, 56)
        Panel3.TabIndex = 4
        ' 
        ' Label3
        ' 
        Label3.AutoSize = True
        Label3.Font = New Font("Arial Narrow", 13.8F, FontStyle.Regular, GraphicsUnit.Point)
        Label3.Location = New Point(10, 14)
        Label3.Name = "Label3"
        Label3.Size = New Size(97, 27)
        Label3.TabIndex = 0
        Label3.Text = "Username"
        ' 
        ' txtCusername
        ' 
        txtCusername.Location = New Point(112, 8)
        txtCusername.Margin = New Padding(3, 4, 3, 4)
        txtCusername.Multiline = True
        txtCusername.Name = "txtCusername"
        txtCusername.Size = New Size(225, 40)
        txtCusername.TabIndex = 1
        ' 
        ' Panel4
        ' 
        Panel4.BackColor = Color.Maroon
        Panel4.Controls.Add(Label4)
        Panel4.Controls.Add(txtCpassword)
        Panel4.ForeColor = Color.Gold
        Panel4.Location = New Point(53, 255)
        Panel4.Name = "Panel4"
        Panel4.Size = New Size(354, 56)
        Panel4.TabIndex = 4
        ' 
        ' Label4
        ' 
        Label4.AutoSize = True
        Label4.Font = New Font("Arial Narrow", 13.8F, FontStyle.Regular, GraphicsUnit.Point)
        Label4.Location = New Point(10, 14)
        Label4.Name = "Label4"
        Label4.Size = New Size(93, 27)
        Label4.TabIndex = 0
        Label4.Text = "Password"
        ' 
        ' txtCpassword
        ' 
        txtCpassword.Location = New Point(112, 8)
        txtCpassword.Margin = New Padding(3, 4, 3, 4)
        txtCpassword.Multiline = True
        txtCpassword.Name = "txtCpassword"
        txtCpassword.PasswordChar = "*"c
        txtCpassword.Size = New Size(225, 40)
        txtCpassword.TabIndex = 1
        ' 
        ' btnAcancel
        ' 
        btnAcancel.Location = New Point(280, 348)
        btnAcancel.Margin = New Padding(3, 4, 3, 4)
        btnAcancel.Name = "btnAcancel"
        btnAcancel.Size = New Size(94, 32)
        btnAcancel.TabIndex = 5
        btnAcancel.Text = "CANCEL"
        btnAcancel.UseVisualStyleBackColor = True
        ' 
        ' Form_Create_User
        ' 
        AutoScaleDimensions = New SizeF(8F, 22F)
        AutoScaleMode = AutoScaleMode.Font
        BackgroundImage = CType(resources.GetObject("$this.BackgroundImage"), Image)
        ClientSize = New Size(459, 420)
        Controls.Add(btnAcancel)
        Controls.Add(Panel4)
        Controls.Add(Panel3)
        Controls.Add(Panel2)
        Controls.Add(Panel1)
        Controls.Add(btnCreateAcc)
        Font = New Font("Arial Narrow", 10.2F, FontStyle.Regular, GraphicsUnit.Point)
        FormBorderStyle = FormBorderStyle.None
        Margin = New Padding(3, 4, 3, 4)
        Name = "Form_Create_User"
        StartPosition = FormStartPosition.CenterScreen
        Text = "crud_user"
        Panel1.ResumeLayout(False)
        Panel1.PerformLayout()
        Panel2.ResumeLayout(False)
        Panel2.PerformLayout()
        Panel3.ResumeLayout(False)
        Panel3.PerformLayout()
        Panel4.ResumeLayout(False)
        Panel4.PerformLayout()
        ResumeLayout(False)
    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents txtCfname As TextBox
    Friend WithEvents btnCreateAcc As Button
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Panel2 As Panel
    Friend WithEvents Label2 As Label
    Friend WithEvents txtClname As TextBox
    Friend WithEvents Panel3 As Panel
    Friend WithEvents Label3 As Label
    Friend WithEvents txtCusername As TextBox
    Friend WithEvents Panel4 As Panel
    Friend WithEvents Label4 As Label
    Friend WithEvents txtCpassword As TextBox
    Friend WithEvents btnAcancel As Button
End Class
