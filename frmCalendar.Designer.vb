<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCalendar
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmCalendar))
        Dim Appearance1 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance2 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance3 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance4 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance5 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip
        Me.btnExit = New System.Windows.Forms.ToolStripButton
        Me.tsbtPrint = New System.Windows.Forms.ToolStripButton
        Me.pnTop = New System.Windows.Forms.Panel
        Me.umCalMulti = New Infragistics.Win.UltraWinSchedule.UltraMonthViewMulti
        Me.uclCal = New Infragistics.Win.UltraWinSchedule.UltraCalendarLook(Me.components)
        Me.uspgCal = New Infragistics.Win.UltraWinSchedule.UltraSchedulePrintDocument(Me.components)
        Me.uppdCal = New Infragistics.Win.Printing.UltraPrintPreviewDialog(Me.components)
        Me.ToolStrip1.SuspendLayout()
        Me.pnTop.SuspendLayout()
        CType(Me.umCalMulti, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ToolStrip1
        '
        Me.ToolStrip1.AutoSize = False
        Me.ToolStrip1.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ToolStrip1.ImageScalingSize = New System.Drawing.Size(25, 25)
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btnExit, Me.tsbtPrint})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(1157, 40)
        Me.ToolStrip1.TabIndex = 15
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'btnExit
        '
        Me.btnExit.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.btnExit.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnExit.Image = CType(resources.GetObject("btnExit.Image"), System.Drawing.Image)
        Me.btnExit.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnExit.Name = "btnExit"
        Me.btnExit.Size = New System.Drawing.Size(59, 37)
        Me.btnExit.Text = "Exit"
        '
        'tsbtPrint
        '
        Me.tsbtPrint.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tsbtPrint.Image = Global.TKPC.My.Resources.Resources.print
        Me.tsbtPrint.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.tsbtPrint.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbtPrint.Name = "tsbtPrint"
        Me.tsbtPrint.Size = New System.Drawing.Size(59, 37)
        Me.tsbtPrint.Text = "Print"
        '
        'pnTop
        '
        Me.pnTop.Controls.Add(Me.umCalMulti)
        Me.pnTop.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnTop.Location = New System.Drawing.Point(0, 40)
        Me.pnTop.Name = "pnTop"
        Me.pnTop.Size = New System.Drawing.Size(1157, 621)
        Me.pnTop.TabIndex = 16
        '
        'umCalMulti
        '
        Me.umCalMulti.BackColor = System.Drawing.SystemColors.Window
        Me.umCalMulti.BorderStyle = Infragistics.Win.UIElementBorderStyle.TwoColor
        Me.umCalMulti.BorderStyleCalendar = Infragistics.Win.UIElementBorderStyle.WindowsVista
        Me.umCalMulti.CalendarLook = Me.uclCal
        Me.umCalMulti.DayDisplayStyle = Infragistics.Win.UltraWinSchedule.DayDisplayStyle.DayNumberAndImage
        Me.umCalMulti.DayOfWeekCaptionStyle = Infragistics.Win.UltraWinSchedule.DayOfWeekCaptionStyle.FirstTwoLetters
        Me.umCalMulti.Dock = System.Windows.Forms.DockStyle.Fill
        Me.umCalMulti.Location = New System.Drawing.Point(0, 0)
        Me.umCalMulti.Margin = New System.Windows.Forms.Padding(5)
        Me.umCalMulti.MonthDimensions = New System.Drawing.Size(5, 5)
        Me.umCalMulti.MonthPadding = New System.Drawing.Size(0, 6)
        Me.umCalMulti.Name = "umCalMulti"
        Me.umCalMulti.ResizeMode = Infragistics.Win.UltraWinSchedule.ResizeMode.BaseOnControlSize
        Me.umCalMulti.Size = New System.Drawing.Size(1157, 621)
        Me.umCalMulti.TabIndex = 0
        Me.umCalMulti.TipStyle = CType((Infragistics.Win.UltraWinSchedule.TipStyleDay.Appointments Or Infragistics.Win.UltraWinSchedule.TipStyleDay.Holidays), Infragistics.Win.UltraWinSchedule.TipStyleDay)
        Me.umCalMulti.UseAlternateMonthAppearances = True
        Me.umCalMulti.UseAlternateSelectedDateRanges = True
        Me.umCalMulti.UseOsThemes = Infragistics.Win.DefaultableBoolean.[False]
        '
        'uclCal
        '
        Appearance1.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.uclCal.DayHeaderAppearance = Appearance1
        Appearance2.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.uclCal.DayWithActivityAppearance = Appearance2
        Appearance3.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.uclCal.HolidayAppearance = Appearance3
        Appearance4.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.uclCal.SelectedDayAppearance = Appearance4
        Appearance5.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.uclCal.TodayAppearance = Appearance5
        '
        'uspgCal
        '
        Me.uspgCal.CalendarLook = Me.uclCal
        Me.uspgCal.PrintStyle = Infragistics.Win.UltraWinSchedule.SchedulePrintStyle.Yearly
        Me.uspgCal.TemplateDateHeaderMonthViewMulti = Me.umCalMulti
        '
        'uppdCal
        '
        Me.uppdCal.Document = Me.uspgCal
        Me.uppdCal.Name = "uppdCal"
        '
        'frmCalendar
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1157, 661)
        Me.Controls.Add(Me.pnTop)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Name = "frmCalendar"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "달력창"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.pnTop.ResumeLayout(False)
        CType(Me.umCalMulti, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents btnExit As System.Windows.Forms.ToolStripButton
    Friend WithEvents pnTop As System.Windows.Forms.Panel
    Friend WithEvents umCalMulti As Infragistics.Win.UltraWinSchedule.UltraMonthViewMulti
    Friend WithEvents uclCal As Infragistics.Win.UltraWinSchedule.UltraCalendarLook
    Friend WithEvents uspgCal As Infragistics.Win.UltraWinSchedule.UltraSchedulePrintDocument
    Friend WithEvents tsbtPrint As System.Windows.Forms.ToolStripButton
    Friend WithEvents uppdCal As Infragistics.Win.Printing.UltraPrintPreviewDialog
End Class
