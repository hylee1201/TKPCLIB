<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmBarcodeMain
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmBarcodeMain))
        Me.PrintDialog1 = New System.Windows.Forms.PrintDialog
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip
        Me.ToolStrip_StatusLabel = New System.Windows.Forms.ToolStripStatusLabel
        Me.printingProgressBar = New System.Windows.Forms.ToolStripProgressBar
        Me.returnToBoxScanTimer = New System.Windows.Forms.Timer(Me.components)
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip
        Me.tsbtLoad = New System.Windows.Forms.ToolStripButton
        Me.tsbtPrint = New System.Windows.Forms.ToolStripButton
        Me.btnExit = New System.Windows.Forms.ToolStripButton
        Me.tsbtPrintSetup = New System.Windows.Forms.ToolStripButton
        Me.tsbtSave = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator
        Me.tsbtRefresh = New System.Windows.Forms.ToolStripButton
        Me.tsbtPurge = New System.Windows.Forms.ToolStripButton
        Me.tslTotal = New System.Windows.Forms.ToolStripLabel
        Me.txtCustomBarcode = New System.Windows.Forms.TextBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.pnCanvas = New System.Windows.Forms.Panel
        Me.StatusStrip1.SuspendLayout()
        Me.ToolStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'PrintDialog1
        '
        Me.PrintDialog1.AllowCurrentPage = True
        Me.PrintDialog1.AllowSelection = True
        Me.PrintDialog1.AllowSomePages = True
        Me.PrintDialog1.PrintToFile = True
        Me.PrintDialog1.ShowHelp = True
        Me.PrintDialog1.UseEXDialog = True
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStrip_StatusLabel, Me.printingProgressBar})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 680)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(1366, 22)
        Me.StatusStrip1.TabIndex = 21
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'ToolStrip_StatusLabel
        '
        Me.ToolStrip_StatusLabel.Name = "ToolStrip_StatusLabel"
        Me.ToolStrip_StatusLabel.Size = New System.Drawing.Size(26, 17)
        Me.ToolStrip_StatusLabel.Text = "Idle"
        '
        'printingProgressBar
        '
        Me.printingProgressBar.Name = "printingProgressBar"
        Me.printingProgressBar.Size = New System.Drawing.Size(300, 17)
        Me.printingProgressBar.Visible = False
        '
        'returnToBoxScanTimer
        '
        Me.returnToBoxScanTimer.Interval = 1000
        '
        'ToolStrip1
        '
        Me.ToolStrip1.AutoSize = False
        Me.ToolStrip1.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ToolStrip1.ImageScalingSize = New System.Drawing.Size(18, 18)
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsbtLoad, Me.tsbtPrint, Me.btnExit, Me.tsbtPrintSetup, Me.tsbtSave, Me.ToolStripSeparator2, Me.tsbtRefresh, Me.tsbtPurge, Me.tslTotal})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(1366, 40)
        Me.ToolStrip1.TabIndex = 28
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'tsbtLoad
        '
        Me.tsbtLoad.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tsbtLoad.Image = Global.TKPC.My.Resources.Resources._return
        Me.tsbtLoad.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbtLoad.Name = "tsbtLoad"
        Me.tsbtLoad.Size = New System.Drawing.Size(59, 37)
        Me.tsbtLoad.Text = "Load"
        '
        'tsbtPrint
        '
        Me.tsbtPrint.Enabled = False
        Me.tsbtPrint.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tsbtPrint.Image = Global.TKPC.My.Resources.Resources.print
        Me.tsbtPrint.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.tsbtPrint.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbtPrint.Name = "tsbtPrint"
        Me.tsbtPrint.Size = New System.Drawing.Size(59, 37)
        Me.tsbtPrint.Text = "Print"
        '
        'btnExit
        '
        Me.btnExit.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.btnExit.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnExit.Image = CType(resources.GetObject("btnExit.Image"), System.Drawing.Image)
        Me.btnExit.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnExit.Name = "btnExit"
        Me.btnExit.Size = New System.Drawing.Size(52, 37)
        Me.btnExit.Text = "Exit"
        '
        'tsbtPrintSetup
        '
        Me.tsbtPrintSetup.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tsbtPrintSetup.Image = Global.TKPC.My.Resources.Resources.tool2
        Me.tsbtPrintSetup.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbtPrintSetup.Name = "tsbtPrintSetup"
        Me.tsbtPrintSetup.Size = New System.Drawing.Size(100, 37)
        Me.tsbtPrintSetup.Text = "Print Setup"
        '
        'tsbtSave
        '
        Me.tsbtSave.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tsbtSave.Image = Global.TKPC.My.Resources.Resources.save
        Me.tsbtSave.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.tsbtSave.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbtSave.Name = "tsbtSave"
        Me.tsbtSave.Size = New System.Drawing.Size(56, 37)
        Me.tsbtSave.Text = "Save"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 40)
        '
        'tsbtRefresh
        '
        Me.tsbtRefresh.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tsbtRefresh.Image = Global.TKPC.My.Resources.Resources.refresh
        Me.tsbtRefresh.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.tsbtRefresh.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbtRefresh.Name = "tsbtRefresh"
        Me.tsbtRefresh.Size = New System.Drawing.Size(75, 37)
        Me.tsbtRefresh.Text = "Refresh"
        '
        'tsbtPurge
        '
        Me.tsbtPurge.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tsbtPurge.Image = Global.TKPC.My.Resources.Resources.check
        Me.tsbtPurge.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.tsbtPurge.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.tsbtPurge.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbtPurge.Name = "tsbtPurge"
        Me.tsbtPurge.Size = New System.Drawing.Size(60, 37)
        Me.tsbtPurge.Text = "Purge"
        '
        'tslTotal
        '
        Me.tslTotal.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tslTotal.Name = "tslTotal"
        Me.tslTotal.Size = New System.Drawing.Size(38, 37)
        Me.tslTotal.Text = "Total"
        '
        'txtCustomBarcode
        '
        Me.txtCustomBarcode.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtCustomBarcode.BackColor = System.Drawing.SystemColors.Window
        Me.txtCustomBarcode.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCustomBarcode.Location = New System.Drawing.Point(11, 41)
        Me.txtCustomBarcode.Multiline = True
        Me.txtCustomBarcode.Name = "txtCustomBarcode"
        Me.txtCustomBarcode.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtCustomBarcode.Size = New System.Drawing.Size(1348, 48)
        Me.txtCustomBarcode.TabIndex = 30
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(607, 64)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(0, 13)
        Me.Label5.TabIndex = 32
        '
        'pnCanvas
        '
        Me.pnCanvas.AutoScroll = True
        Me.pnCanvas.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.pnCanvas.Location = New System.Drawing.Point(12, 90)
        Me.pnCanvas.Name = "pnCanvas"
        Me.pnCanvas.Size = New System.Drawing.Size(1346, 587)
        Me.pnCanvas.TabIndex = 33
        '
        'frmBarcodeMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1366, 702)
        Me.Controls.Add(Me.pnCanvas)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.txtCustomBarcode)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MinimumSize = New System.Drawing.Size(774, 726)
        Me.Name = "frmBarcodeMain"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Barcode Generation Screen"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents PrintDialog1 As System.Windows.Forms.PrintDialog
    Friend WithEvents StatusStrip1 As System.Windows.Forms.StatusStrip
    Friend WithEvents ToolStrip_StatusLabel As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents returnToBoxScanTimer As System.Windows.Forms.Timer
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents tsbtPrint As System.Windows.Forms.ToolStripButton
    Friend WithEvents btnExit As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsbtPrintSetup As System.Windows.Forms.ToolStripButton
    Friend WithEvents printingProgressBar As System.Windows.Forms.ToolStripProgressBar
    Friend WithEvents txtCustomBarcode As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents tsbtSave As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents tsbtRefresh As System.Windows.Forms.ToolStripButton
    Friend WithEvents pnCanvas As System.Windows.Forms.Panel
    Friend WithEvents tslTotal As System.Windows.Forms.ToolStripLabel
    Friend WithEvents tsbtPurge As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsbtLoad As System.Windows.Forms.ToolStripButton
End Class
