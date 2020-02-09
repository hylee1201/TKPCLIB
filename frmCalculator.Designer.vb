<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCalculator
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
        Dim Appearance1 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Me.ucTKPC = New Infragistics.Win.UltraWinEditors.UltraWinCalc.UltraCalculator
        CType(Me.ucTKPC, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ucTKPC
        '
        Me.ucTKPC.Dock = System.Windows.Forms.DockStyle.Fill
        Appearance1.FontData.BoldAsString = "True"
        Appearance1.FontData.Name = "Tahoma"
        Appearance1.FontData.SizeInPoints = 14.0!
        Me.ucTKPC.EditAppearance = Appearance1
        Me.ucTKPC.Location = New System.Drawing.Point(0, 0)
        Me.ucTKPC.Name = "ucTKPC"
        Me.ucTKPC.Size = New System.Drawing.Size(394, 325)
        Me.ucTKPC.TabIndex = 0
        Me.ucTKPC.Text = "0."
        '
        'frmCalculator
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(394, 325)
        Me.Controls.Add(Me.ucTKPC)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmCalculator"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "계산기"
        Me.TopMost = True
        CType(Me.ucTKPC, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ucTKPC As Infragistics.Win.UltraWinEditors.UltraWinCalc.UltraCalculator
End Class
