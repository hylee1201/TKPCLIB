<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmLoginAdd
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
        Me.lblPersonID = New System.Windows.Forms.Label
        Me.btClose = New System.Windows.Forms.Button
        Me.btSave = New System.Windows.Forms.Button
        Me.UltraGroupBox1 = New Infragistics.Win.Misc.UltraGroupBox
        Me.txtPWD2 = New System.Windows.Forms.TextBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.cbLevel = New System.Windows.Forms.ComboBox
        Me.txtID = New System.Windows.Forms.TextBox
        Me.txtPWD = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Panel1.SuspendLayout()
        CType(Me.UltraGroupBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UltraGroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.lblPersonID)
        Me.Panel1.Controls.Add(Me.btClose)
        Me.Panel1.Controls.Add(Me.btSave)
        Me.Panel1.Controls.Add(Me.UltraGroupBox1)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(433, 376)
        Me.Panel1.TabIndex = 0
        '
        'lblPersonID
        '
        Me.lblPersonID.AutoSize = True
        Me.lblPersonID.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPersonID.Location = New System.Drawing.Point(45, 22)
        Me.lblPersonID.Name = "lblPersonID"
        Me.lblPersonID.Size = New System.Drawing.Size(22, 16)
        Me.lblPersonID.TabIndex = 8
        Me.lblPersonID.Text = "ID"
        Me.lblPersonID.Visible = False
        '
        'btClose
        '
        Me.btClose.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btClose.Location = New System.Drawing.Point(236, 288)
        Me.btClose.Name = "btClose"
        Me.btClose.Size = New System.Drawing.Size(104, 34)
        Me.btClose.TabIndex = 7
        Me.btClose.Text = "Close"
        Me.btClose.UseVisualStyleBackColor = True
        '
        'btSave
        '
        Me.btSave.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btSave.Location = New System.Drawing.Point(92, 288)
        Me.btSave.Name = "btSave"
        Me.btSave.Size = New System.Drawing.Size(104, 34)
        Me.btSave.TabIndex = 6
        Me.btSave.Text = "Save"
        Me.btSave.UseVisualStyleBackColor = True
        '
        'UltraGroupBox1
        '
        Me.UltraGroupBox1.Controls.Add(Me.txtPWD2)
        Me.UltraGroupBox1.Controls.Add(Me.Label4)
        Me.UltraGroupBox1.Controls.Add(Me.Label3)
        Me.UltraGroupBox1.Controls.Add(Me.cbLevel)
        Me.UltraGroupBox1.Controls.Add(Me.txtID)
        Me.UltraGroupBox1.Controls.Add(Me.txtPWD)
        Me.UltraGroupBox1.Controls.Add(Me.Label1)
        Me.UltraGroupBox1.Controls.Add(Me.Label2)
        Me.UltraGroupBox1.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.UltraGroupBox1.ForeColor = System.Drawing.SystemColors.Desktop
        Me.UltraGroupBox1.Location = New System.Drawing.Point(48, 55)
        Me.UltraGroupBox1.Name = "UltraGroupBox1"
        Me.UltraGroupBox1.Size = New System.Drawing.Size(337, 201)
        Me.UltraGroupBox1.TabIndex = 5
        '
        'txtPWD2
        '
        Me.txtPWD2.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPWD2.Location = New System.Drawing.Point(186, 153)
        Me.txtPWD2.MaxLength = 10
        Me.txtPWD2.Name = "txtPWD2"
        Me.txtPWD2.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtPWD2.Size = New System.Drawing.Size(100, 23)
        Me.txtPWD2.TabIndex = 3
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(51, 156)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(129, 16)
        Me.Label4.TabIndex = 4
        Me.Label4.Text = "Confirm Password:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(83, 29)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(97, 16)
        Me.Label3.TabIndex = 3
        Me.Label3.Text = "Access Level:"
        '
        'cbLevel
        '
        Me.cbLevel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbLevel.FormattingEnabled = True
        Me.cbLevel.Items.AddRange(New Object() {"User", "Admin"})
        Me.cbLevel.Location = New System.Drawing.Point(186, 26)
        Me.cbLevel.Name = "cbLevel"
        Me.cbLevel.Size = New System.Drawing.Size(100, 24)
        Me.cbLevel.TabIndex = 0
        '
        'txtID
        '
        Me.txtID.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtID.Location = New System.Drawing.Point(186, 69)
        Me.txtID.MaxLength = 10
        Me.txtID.Name = "txtID"
        Me.txtID.Size = New System.Drawing.Size(100, 23)
        Me.txtID.TabIndex = 1
        '
        'txtPWD
        '
        Me.txtPWD.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPWD.Location = New System.Drawing.Point(186, 111)
        Me.txtPWD.MaxLength = 10
        Me.txtPWD.Name = "txtPWD"
        Me.txtPWD.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtPWD.Size = New System.Drawing.Size(100, 23)
        Me.txtPWD.TabIndex = 2
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(153, 72)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(27, 16)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "ID:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(104, 115)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(76, 16)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Password:"
        '
        'frmLoginAdd
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(433, 376)
        Me.Controls.Add(Me.Panel1)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmLoginAdd"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "로그인 설정 "
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.UltraGroupBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UltraGroupBox1.ResumeLayout(False)
        Me.UltraGroupBox1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents UltraGroupBox1 As Infragistics.Win.Misc.UltraGroupBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents cbLevel As System.Windows.Forms.ComboBox
    Friend WithEvents txtID As System.Windows.Forms.TextBox
    Friend WithEvents txtPWD As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtPWD2 As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents btClose As System.Windows.Forms.Button
    Friend WithEvents btSave As System.Windows.Forms.Button
    Friend WithEvents lblPersonID As System.Windows.Forms.Label
End Class
