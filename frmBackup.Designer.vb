<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmBackup
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
        Me.components = New System.ComponentModel.Container
        Me.pbTKPC = New System.Windows.Forms.ProgressBar
        Me.lblTKPC = New System.Windows.Forms.Label
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.btnClose = New System.Windows.Forms.Button
        Me.Label1 = New System.Windows.Forms.Label
        Me.lblPath = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.SuspendLayout()
        '
        'pbTKPC
        '
        Me.pbTKPC.Location = New System.Drawing.Point(61, 102)
        Me.pbTKPC.Name = "pbTKPC"
        Me.pbTKPC.Size = New System.Drawing.Size(403, 23)
        Me.pbTKPC.TabIndex = 0
        '
        'lblTKPC
        '
        Me.lblTKPC.AutoSize = True
        Me.lblTKPC.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTKPC.Location = New System.Drawing.Point(58, 143)
        Me.lblTKPC.Name = "lblTKPC"
        Me.lblTKPC.Size = New System.Drawing.Size(47, 14)
        Me.lblTKPC.TabIndex = 1
        Me.lblTKPC.Text = "Label1"
        '
        'btnClose
        '
        Me.btnClose.Location = New System.Drawing.Point(402, 178)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(62, 28)
        Me.btnClose.TabIndex = 2
        Me.btnClose.Text = "Close"
        Me.btnClose.UseVisualStyleBackColor = True
        Me.btnClose.Visible = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(58, 24)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(243, 14)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "The Database backup file is located at "
        '
        'lblPath
        '
        Me.lblPath.AutoSize = True
        Me.lblPath.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPath.Location = New System.Drawing.Point(58, 47)
        Me.lblPath.Name = "lblPath"
        Me.lblPath.Size = New System.Drawing.Size(410, 14)
        Me.lblPath.TabIndex = 4
        Me.lblPath.Text = "C:\Program Files\Microsoft SQL Server\MSSQL.2\MSSQL\Backup."
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(58, 72)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(332, 14)
        Me.Label3.TabIndex = 5
        Me.Label3.Text = "Please go to the location and backup for emergency."
        '
        'frmBackup
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(526, 233)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.lblPath)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.btnClose)
        Me.Controls.Add(Me.lblTKPC)
        Me.Controls.Add(Me.pbTKPC)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmBackup"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Backing up TKPC database..."
        Me.TopMost = True
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents pbTKPC As System.Windows.Forms.ProgressBar
    Friend WithEvents lblTKPC As System.Windows.Forms.Label
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents btnClose As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents lblPath As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
End Class
