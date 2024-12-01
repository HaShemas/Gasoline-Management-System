<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Form_Login
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
        Dim resources As ComponentModel.ComponentResourceManager = New ComponentModel.ComponentResourceManager(GetType(Form_Login))
        Panel2 = New Panel()
        PictureBox2 = New PictureBox()
        txtUsername = New TextBox()
        Panel3 = New Panel()
        PictureBox3 = New PictureBox()
        txtPassword = New TextBox()
        btnLogin = New Button()
        btnCancel = New Button()
        chkPass = New CheckBox()
        PictureBox1 = New PictureBox()
        Panel2.SuspendLayout()
        CType(PictureBox2, ComponentModel.ISupportInitialize).BeginInit()
        Panel3.SuspendLayout()
        CType(PictureBox3, ComponentModel.ISupportInitialize).BeginInit()
        CType(PictureBox1, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' Panel2
        ' 
        Panel2.BackColor = Color.Red
        Panel2.Controls.Add(PictureBox2)
        Panel2.Controls.Add(txtUsername)
        Panel2.Location = New Point(83, 189)
        Panel2.Name = "Panel2"
        Panel2.Size = New Size(298, 53)
        Panel2.TabIndex = 2
        ' 
        ' PictureBox2
        ' 
        PictureBox2.BackColor = Color.White
        PictureBox2.Image = CType(resources.GetObject("PictureBox2.Image"), Image)
        PictureBox2.Location = New Point(5, 3)
        PictureBox2.Name = "PictureBox2"
        PictureBox2.Size = New Size(56, 48)
        PictureBox2.SizeMode = PictureBoxSizeMode.StretchImage
        PictureBox2.TabIndex = 0
        PictureBox2.TabStop = False
        ' 
        ' txtUsername
        ' 
        txtUsername.Font = New Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point)
        txtUsername.Location = New Point(65, 7)
        txtUsername.Multiline = True
        txtUsername.Name = "txtUsername"
        txtUsername.PlaceholderText = "Enter username"
        txtUsername.Size = New Size(225, 40)
        txtUsername.TabIndex = 1
        ' 
        ' Panel3
        ' 
        Panel3.BackColor = Color.Red
        Panel3.Controls.Add(PictureBox3)
        Panel3.Controls.Add(txtPassword)
        Panel3.Location = New Point(83, 261)
        Panel3.Name = "Panel3"
        Panel3.Size = New Size(298, 53)
        Panel3.TabIndex = 3
        ' 
        ' PictureBox3
        ' 
        PictureBox3.BackColor = Color.White
        PictureBox3.Image = CType(resources.GetObject("PictureBox3.Image"), Image)
        PictureBox3.Location = New Point(5, 3)
        PictureBox3.Name = "PictureBox3"
        PictureBox3.Size = New Size(56, 48)
        PictureBox3.SizeMode = PictureBoxSizeMode.StretchImage
        PictureBox3.TabIndex = 0
        PictureBox3.TabStop = False
        ' 
        ' txtPassword
        ' 
        txtPassword.Font = New Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point)
        txtPassword.Location = New Point(65, 7)
        txtPassword.Multiline = True
        txtPassword.Name = "txtPassword"
        txtPassword.PasswordChar = "*"c
        txtPassword.PlaceholderText = "Enter password"
        txtPassword.Size = New Size(225, 40)
        txtPassword.TabIndex = 1
        ' 
        ' btnLogin
        ' 
        btnLogin.BackColor = Color.Silver
        btnLogin.Location = New Point(87, 371)
        btnLogin.Name = "btnLogin"
        btnLogin.Size = New Size(111, 51)
        btnLogin.TabIndex = 4
        btnLogin.Text = "LOGIN"
        btnLogin.UseVisualStyleBackColor = False
        ' 
        ' btnCancel
        ' 
        btnCancel.BackColor = Color.DarkGray
        btnCancel.Location = New Point(261, 371)
        btnCancel.Name = "btnCancel"
        btnCancel.Size = New Size(110, 51)
        btnCancel.TabIndex = 5
        btnCancel.Text = "CANCEL"
        btnCancel.UseVisualStyleBackColor = False
        ' 
        ' chkPass
        ' 
        chkPass.AutoSize = True
        chkPass.Location = New Point(99, 325)
        chkPass.Name = "chkPass"
        chkPass.Size = New Size(134, 24)
        chkPass.TabIndex = 6
        chkPass.Text = "Show password"
        chkPass.UseVisualStyleBackColor = True
        ' 
        ' PictureBox1
        ' 
        PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), Image)
        PictureBox1.Location = New Point(129, 45)
        PictureBox1.Name = "PictureBox1"
        PictureBox1.Size = New Size(207, 128)
        PictureBox1.SizeMode = PictureBoxSizeMode.StretchImage
        PictureBox1.TabIndex = 7
        PictureBox1.TabStop = False
        ' 
        ' Form_Login
        ' 
        AutoScaleDimensions = New SizeF(8F, 20F)
        AutoScaleMode = AutoScaleMode.Font
        BackgroundImage = CType(resources.GetObject("$this.BackgroundImage"), Image)
        ClientSize = New Size(464, 467)
        Controls.Add(PictureBox1)
        Controls.Add(chkPass)
        Controls.Add(btnCancel)
        Controls.Add(btnLogin)
        Controls.Add(Panel3)
        Controls.Add(Panel2)
        FormBorderStyle = FormBorderStyle.None
        Name = "Form_Login"
        StartPosition = FormStartPosition.CenterScreen
        Text = "Login"
        Panel2.ResumeLayout(False)
        Panel2.PerformLayout()
        CType(PictureBox2, ComponentModel.ISupportInitialize).EndInit()
        Panel3.ResumeLayout(False)
        Panel3.PerformLayout()
        CType(PictureBox3, ComponentModel.ISupportInitialize).EndInit()
        CType(PictureBox1, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
        PerformLayout()
    End Sub
    Friend WithEvents Panel2 As Panel
    Friend WithEvents PictureBox2 As PictureBox
    Friend WithEvents txtUsername As TextBox
    Friend WithEvents Panel3 As Panel
    Friend WithEvents PictureBox3 As PictureBox
    Friend WithEvents txtPassword As TextBox
    Friend WithEvents btnLogin As Button
    Friend WithEvents btnCancel As Button
    Friend WithEvents chkPass As CheckBox
    Friend WithEvents PictureBox1 As PictureBox
End Class
