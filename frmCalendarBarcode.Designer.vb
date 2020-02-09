<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCalendarBarcode
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
        Dim Appearance4 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance1 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance2 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance3 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmCalendarBarcode))
        Dim Appearance37 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraGridBand1 As Infragistics.Win.UltraWinGrid.UltraGridBand = New Infragistics.Win.UltraWinGrid.UltraGridBand("Band 0", -1)
        Dim UltraGridColumn1 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Barcode", -1, Nothing, 0, Infragistics.Win.UltraWinGrid.SortIndicator.Ascending, False)
        Dim Appearance42 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraGridColumn2 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Created Date")
        Dim Appearance43 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraGridColumn3 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Book Title")
        Dim Appearance44 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraGridColumn4 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Author")
        Dim Appearance45 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraGridColumn5 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Publisher")
        Dim Appearance46 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance38 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance39 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance40 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance29 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance30 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance31 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance32 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance33 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance34 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance35 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance36 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Me.ultraMonthView = New Infragistics.Win.UltraWinSchedule.UltraMonthViewMulti
        Me.ultraCalInfo = New Infragistics.Win.UltraWinSchedule.UltraCalendarInfo(Me.components)
        Me.ultraCalLook = New Infragistics.Win.UltraWinSchedule.UltraCalendarLook(Me.components)
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip
        Me.tsbtDelete = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator
        Me.btnExit = New System.Windows.Forms.ToolStripButton
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.ugList = New Infragistics.Win.UltraWinGrid.UltraGrid
        CType(Me.ultraMonthView, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ToolStrip1.SuspendLayout()
        Me.Panel1.SuspendLayout()
        CType(Me.ugList, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ultraMonthView
        '
        Me.ultraMonthView.BackColor = System.Drawing.SystemColors.Window
        Me.ultraMonthView.CalendarInfo = Me.ultraCalInfo
        Me.ultraMonthView.CalendarLook = Me.ultraCalLook
        Me.ultraMonthView.Dock = System.Windows.Forms.DockStyle.Left
        Me.ultraMonthView.Location = New System.Drawing.Point(0, 0)
        Me.ultraMonthView.MonthDimensions = New System.Drawing.Size(1, 4)
        Me.ultraMonthView.Name = "ultraMonthView"
        Me.ultraMonthView.Size = New System.Drawing.Size(146, 508)
        Me.ultraMonthView.TabIndex = 0
        '
        'ultraCalInfo
        '
        Me.ultraCalInfo.DataBindingsForAppointments.BindingContextControl = Me
        Me.ultraCalInfo.DataBindingsForOwners.BindingContextControl = Me
        Me.ultraCalInfo.ReminderImage = CType(resources.GetObject("ultraCalInfo.ReminderImage"), System.Drawing.Image)
        Me.ultraCalInfo.SaveSettings = True
        Me.ultraCalInfo.SettingsKey = "frmCalendarBarcode.ultraCalInfo"
        Me.ultraCalInfo.WeekRule = System.Globalization.CalendarWeekRule.FirstFourDayWeek
        '
        'ultraCalLook
        '
        Appearance4.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.ultraCalLook.SelectedDayAppearance = Appearance4
        Appearance1.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer))
        Appearance1.FontData.BoldAsString = "True"
        Me.ultraCalLook.TodayAppearance = Appearance1
        Appearance2.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.ultraCalLook.TodayHeaderAppearance = Appearance2
        Appearance3.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.ultraCalLook.WeekAppearance = Appearance3
        '
        'ToolStrip1
        '
        Me.ToolStrip1.AutoSize = False
        Me.ToolStrip1.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ToolStrip1.ImageScalingSize = New System.Drawing.Size(18, 18)
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsbtDelete, Me.ToolStripSeparator1, Me.btnExit})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(788, 40)
        Me.ToolStrip1.TabIndex = 18
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'tsbtDelete
        '
        Me.tsbtDelete.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tsbtDelete.Image = Global.TKPC.My.Resources.Resources.delete2
        Me.tsbtDelete.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.tsbtDelete.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbtDelete.Name = "tsbtDelete"
        Me.tsbtDelete.Size = New System.Drawing.Size(65, 37)
        Me.tsbtDelete.Text = "Delete"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 40)
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
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.ugList)
        Me.Panel1.Controls.Add(Me.ultraMonthView)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(0, 40)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(788, 517)
        Me.Panel1.TabIndex = 19
        '
        'ugList
        '
        Appearance37.BackColor = System.Drawing.SystemColors.Window
        Appearance37.BorderColor = System.Drawing.SystemColors.InactiveCaption
        Me.ugList.DisplayLayout.Appearance = Appearance37
        UltraGridColumn1.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
        Appearance42.FontData.BoldAsString = "False"
        UltraGridColumn1.Header.Appearance = Appearance42
        UltraGridColumn1.Header.Caption = "바코드"
        UltraGridColumn1.Header.VisiblePosition = 0
        Appearance43.FontData.BoldAsString = "False"
        UltraGridColumn2.Header.Appearance = Appearance43
        UltraGridColumn2.Header.Caption = "생성일"
        UltraGridColumn2.Header.VisiblePosition = 1
        Appearance44.FontData.BoldAsString = "False"
        UltraGridColumn3.Header.Appearance = Appearance44
        UltraGridColumn3.Header.Caption = "도서명"
        UltraGridColumn3.Header.VisiblePosition = 2
        Appearance45.FontData.BoldAsString = "False"
        UltraGridColumn4.Header.Appearance = Appearance45
        UltraGridColumn4.Header.Caption = "저자명"
        UltraGridColumn4.Header.VisiblePosition = 3
        Appearance46.FontData.BoldAsString = "False"
        UltraGridColumn5.Header.Appearance = Appearance46
        UltraGridColumn5.Header.Caption = "출판사"
        UltraGridColumn5.Header.VisiblePosition = 4
        UltraGridBand1.Columns.AddRange(New Object() {UltraGridColumn1, UltraGridColumn2, UltraGridColumn3, UltraGridColumn4, UltraGridColumn5})
        Me.ugList.DisplayLayout.BandsSerializer.Add(UltraGridBand1)
        Me.ugList.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Me.ugList.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.[False]
        Appearance38.BackColor = System.Drawing.SystemColors.ActiveBorder
        Appearance38.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance38.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Appearance38.BorderColor = System.Drawing.SystemColors.Window
        Me.ugList.DisplayLayout.GroupByBox.Appearance = Appearance38
        Appearance39.ForeColor = System.Drawing.SystemColors.GrayText
        Me.ugList.DisplayLayout.GroupByBox.BandLabelAppearance = Appearance39
        Me.ugList.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Appearance40.BackColor = System.Drawing.SystemColors.ControlLightLight
        Appearance40.BackColor2 = System.Drawing.SystemColors.Control
        Appearance40.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance40.ForeColor = System.Drawing.SystemColors.GrayText
        Me.ugList.DisplayLayout.GroupByBox.PromptAppearance = Appearance40
        Me.ugList.DisplayLayout.MaxColScrollRegions = 1
        Me.ugList.DisplayLayout.MaxRowScrollRegions = 1
        Appearance29.BackColor = System.Drawing.SystemColors.Window
        Appearance29.ForeColor = System.Drawing.SystemColors.ControlText
        Me.ugList.DisplayLayout.Override.ActiveCellAppearance = Appearance29
        Appearance30.BackColor = System.Drawing.SystemColors.Highlight
        Appearance30.ForeColor = System.Drawing.SystemColors.HighlightText
        Me.ugList.DisplayLayout.Override.ActiveRowAppearance = Appearance30
        Me.ugList.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Dotted
        Me.ugList.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Dotted
        Appearance31.BackColor = System.Drawing.SystemColors.Window
        Me.ugList.DisplayLayout.Override.CardAreaAppearance = Appearance31
        Appearance32.BorderColor = System.Drawing.Color.Silver
        Appearance32.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter
        Me.ugList.DisplayLayout.Override.CellAppearance = Appearance32
        Me.ugList.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText
        Me.ugList.DisplayLayout.Override.CellPadding = 0
        Appearance33.BackColor = System.Drawing.SystemColors.Control
        Appearance33.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance33.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element
        Appearance33.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance33.BorderColor = System.Drawing.SystemColors.Window
        Me.ugList.DisplayLayout.Override.GroupByRowAppearance = Appearance33
        Appearance34.FontData.BoldAsString = "True"
        Appearance34.TextHAlignAsString = "Center"
        Me.ugList.DisplayLayout.Override.HeaderAppearance = Appearance34
        Me.ugList.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti
        Me.ugList.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.WindowsXPCommand
        Appearance35.BackColor = System.Drawing.SystemColors.Window
        Appearance35.BorderColor = System.Drawing.Color.Silver
        Me.ugList.DisplayLayout.Override.RowAppearance = Appearance35
        Me.ugList.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.[False]
        Appearance36.BackColor = System.Drawing.SystemColors.ControlLight
        Me.ugList.DisplayLayout.Override.TemplateAddRowAppearance = Appearance36
        Me.ugList.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill
        Me.ugList.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate
        Me.ugList.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.OutlookGroupBy
        Me.ugList.Dock = System.Windows.Forms.DockStyle.Right
        Me.ugList.Font = New System.Drawing.Font("Dotum", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ugList.Location = New System.Drawing.Point(152, 0)
        Me.ugList.Name = "ugList"
        Me.ugList.Size = New System.Drawing.Size(636, 517)
        Me.ugList.TabIndex = 1
        '
        'frmCalendarBarcode
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(788, 557)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.ToolStrip1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmCalendarBarcode"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Select Dates"
        Me.TopMost = True
        CType(Me.ultraMonthView, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ultraCalInfo, System.Configuration.IPersistComponentSettings).LoadComponentSettings()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        CType(Me.ugList, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ultraMonthView As Infragistics.Win.UltraWinSchedule.UltraMonthViewMulti
    Friend WithEvents ultraCalInfo As Infragistics.Win.UltraWinSchedule.UltraCalendarInfo
    Friend WithEvents ultraCalLook As Infragistics.Win.UltraWinSchedule.UltraCalendarLook
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents tsbtDelete As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents btnExit As System.Windows.Forms.ToolStripButton
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents ugList As Infragistics.Win.UltraWinGrid.UltraGrid
End Class
