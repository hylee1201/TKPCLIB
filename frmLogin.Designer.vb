<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmLogin
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
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.ulblStatus = New Infragistics.Win.Misc.UltraLabel
        Me.PictureBox2 = New System.Windows.Forms.PictureBox
        Me.btCancel = New System.Windows.Forms.Button
        Me.btEnter = New System.Windows.Forms.Button
        Me.UltraGroupBox1 = New Infragistics.Win.Misc.UltraGroupBox
        Me.txtID = New System.Windows.Forms.TextBox
        Me.txtPWD = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Panel1.SuspendLayout()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.UltraGroupBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UltraGroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Panel1.Controls.Add(Me.ulblStatus)
        Me.Panel1.Controls.Add(Me.PictureBox2)
        Me.Panel1.Controls.Add(Me.btCancel)
        Me.Panel1.Controls.Add(Me.btEnter)
        Me.Panel1.Controls.Add(Me.UltraGroupBox1)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(493, 380)
        Me.Panel1.TabIndex = 0
        '
        'ulblStatus
        '
        Me.ulblStatus.Location = New System.Drawing.Point(23, 345)
        Me.ulblStatus.Name = "ulblStatus"
        Me.ulblStatus.Size = New System.Drawing.Size(446, 23)
        Me.ulblStatus.TabIndex = 9
        '
        'PictureBox2
        '
        Me.PictureBox2.BackgroundImage = Global.TKPC.My.Resources.Resources.tkpc2009_04
        Me.PictureBox2.Location = New System.Drawing.Point(93, 23)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(307, 82)
        Me.PictureBox2.TabIndex = 8
        Me.PictureBox2.TabStop = False
        '
        'btCancel
        '
        Me.btCancel.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btCancel.Location = New System.Drawing.Point(267, 299)
        Me.btCancel.Name = "btCancel"
        Me.btCancel.Size = New System.Drawing.Size(81, 35)
        Me.btCancel.TabIndex = 6
        Me.btCancel.Text = "Cancel"
        Me.btCancel.UseVisualStyleBackColor = True
        '
        'btEnter
        '
        Me.btEnter.Enabled = False
        Me.btEnter.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btEnter.Location = New System.Drawing.Point(143, 299)
        Me.btEnter.Name = "btEnter"
        Me.btEnter.Size = New System.Drawing.Size(81, 35)
        Me.btEnter.TabIndex = 5
        Me.btEnter.Text = "Login"
        Me.btEnter.UseVisualStyleBackColor = True
        '
        'UltraGroupBox1
        '
        Me.UltraGroupBox1.Controls.Add(Me.txtID)
        Me.UltraGroupBox1.Controls.Add(Me.txtPWD)
        Me.UltraGroupBox1.Controls.Add(Me.Label1)
        Me.UltraGroupBox1.Controls.Add(Me.Label2)
        Me.UltraGroupBox1.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.UltraGroupBox1.ForeColor = System.Drawing.SystemColors.Desktop
        Me.UltraGroupBox1.Location = New System.Drawing.Point(93, 126)
        Me.UltraGroupBox1.Name = "UltraGroupBox1"
        Me.UltraGroupBox1.Size = New System.Drawing.Size(307, 148)
        Me.UltraGroupBox1.TabIndex = 4
        '
        'txtID
        '
        Me.txtID.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtID.Location = New System.Drawing.Point(148, 41)
        Me.txtID.MaxLength = 10
        Me.txtID.Name = "txtID"
        Me.txtID.Size = New System.Drawing.Size(100, 23)
        Me.txtID.TabIndex = 0
        '
        'txtPWD
        '
        Me.txtPWD.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPWD.Location = New System.Drawing.Point(148, 85)
        Me.txtPWD.MaxLength = 10
        Me.txtPWD.Name = "txtPWD"
        Me.txtPWD.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtPWD.Size = New System.Drawing.Size(100, 23)
        Me.txtPWD.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(114, 41)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(31, 18)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "ID:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(59, 85)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(86, 18)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Password:"
        '
        'frmLogin
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(493, 380)
        Me.Controls.Add(Me.Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmLogin"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "토론토 한인 장로 교회 도서실에 오신 걸 환영합니다."
        Me.Panel1.ResumeLayout(False)
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.UltraGroupBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UltraGroupBox1.ResumeLayout(False)
        Me.UltraGroupBox1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents UltraGroupBox1 As Infragistics.Win.Misc.UltraGroupBox
    Friend WithEvents txtID As System.Windows.Forms.TextBox
    Friend WithEvents txtPWD As System.Windows.Forms.TextBox
    Friend WithEvents btCancel As System.Windows.Forms.Button
    Friend WithEvents btEnter As System.Windows.Forms.Button
    Friend WithEvents PictureBox2 As System.Windows.Forms.PictureBox
    Friend WithEvents ulblStatus As Infragistics.Win.Misc.UltraLabel
End Class
