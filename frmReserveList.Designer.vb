<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmReserveList
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmReserveList))
        Dim Appearance1 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance2 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraGridBand1 As Infragistics.Win.UltraWinGrid.UltraGridBand = New Infragistics.Win.UltraWinGrid.UltraGridBand("Band 0", -1)
        Dim UltraGridColumn1 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("ID")
        Dim UltraGridColumn2 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Person ID")
        Dim UltraGridColumn3 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Book ID", -1, Nothing, 0, Infragistics.Win.UltraWinGrid.SortIndicator.Ascending, False)
        Dim UltraGridColumn4 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("선택")
        Dim UltraGridColumn5 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("이름")
        Dim Appearance3 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraGridColumn6 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("성별")
        Dim Appearance4 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraGridColumn7 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("직분")
        Dim Appearance5 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraGridColumn8 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("집 전화")
        Dim Appearance6 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance7 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraGridColumn9 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("도서명")
        Dim Appearance29 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraGridColumn10 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("바코드")
        Dim Appearance30 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraGridColumn11 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("출판사")
        Dim Appearance31 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraGridColumn12 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("저자")
        Dim Appearance32 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraGridColumn13 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("예약일")
        Dim Appearance33 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance34 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance35 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance36 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance37 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance38 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance39 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance40 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance41 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance42 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance43 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance44 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance45 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance46 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance47 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance48 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance49 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Me.bnList = New System.Windows.Forms.BindingNavigator(Me.components)
        Me.BindingNavigatorAddNewItem = New System.Windows.Forms.ToolStripButton
        Me.BindingNavigatorCountItem = New System.Windows.Forms.ToolStripLabel
        Me.BindingNavigatorDeleteItem = New System.Windows.Forms.ToolStripButton
        Me.BindingNavigatorMoveFirstItem = New System.Windows.Forms.ToolStripButton
        Me.BindingNavigatorMovePreviousItem = New System.Windows.Forms.ToolStripButton
        Me.BindingNavigatorSeparator = New System.Windows.Forms.ToolStripSeparator
        Me.BindingNavigatorPositionItem = New System.Windows.Forms.ToolStripTextBox
        Me.BindingNavigatorSeparator1 = New System.Windows.Forms.ToolStripSeparator
        Me.BindingNavigatorMoveNextItem = New System.Windows.Forms.ToolStripButton
        Me.BindingNavigatorMoveLastItem = New System.Windows.Forms.ToolStripButton
        Me.BindingNavigatorSeparator2 = New System.Windows.Forms.ToolStripSeparator
        Me.tsbtExcel = New System.Windows.Forms.ToolStripButton
        Me.btnExit = New System.Windows.Forms.ToolStripButton
        Me.tsbtRefresh = New System.Windows.Forms.ToolStripButton
        Me.tsbtPrint = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator
        Me.ugList = New Infragistics.Win.UltraWinGrid.UltraGrid
        Me.ugExcel = New Infragistics.Win.UltraWinGrid.ExcelExport.UltraGridExcelExporter(Me.components)
        Me.ugpdRent = New Infragistics.Win.UltraWinGrid.UltraGridPrintDocument(Me.components)
        Me.uppdRent = New Infragistics.Win.Printing.UltraPrintPreviewDialog(Me.components)
        CType(Me.bnList, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.bnList.SuspendLayout()
        CType(Me.ugList, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'bnList
        '
        Me.bnList.AddNewItem = Me.BindingNavigatorAddNewItem
        Me.bnList.AutoSize = False
        Me.bnList.CountItem = Me.BindingNavigatorCountItem
        Me.bnList.DeleteItem = Me.BindingNavigatorDeleteItem
        Me.bnList.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bnList.ImageScalingSize = New System.Drawing.Size(18, 18)
        Me.bnList.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BindingNavigatorMoveFirstItem, Me.BindingNavigatorMovePreviousItem, Me.BindingNavigatorSeparator, Me.BindingNavigatorPositionItem, Me.BindingNavigatorCountItem, Me.BindingNavigatorSeparator1, Me.BindingNavigatorMoveNextItem, Me.BindingNavigatorMoveLastItem, Me.BindingNavigatorSeparator2, Me.BindingNavigatorAddNewItem, Me.BindingNavigatorDeleteItem, Me.tsbtExcel, Me.btnExit, Me.tsbtRefresh, Me.tsbtPrint, Me.ToolStripSeparator1})
        Me.bnList.Location = New System.Drawing.Point(0, 0)
        Me.bnList.MoveFirstItem = Me.BindingNavigatorMoveFirstItem
        Me.bnList.MoveLastItem = Me.BindingNavigatorMoveLastItem
        Me.bnList.MoveNextItem = Me.BindingNavigatorMoveNextItem
        Me.bnList.MovePreviousItem = Me.BindingNavigatorMovePreviousItem
        Me.bnList.Name = "bnList"
        Me.bnList.PositionItem = Me.BindingNavigatorPositionItem
        Me.bnList.Size = New System.Drawing.Size(1137, 38)
        Me.bnList.TabIndex = 7
        Me.bnList.Text = "BindingNavigator1"
        '
        'BindingNavigatorAddNewItem
        '
        Me.BindingNavigatorAddNewItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BindingNavigatorAddNewItem.Image = CType(resources.GetObject("BindingNavigatorAddNewItem.Image"), System.Drawing.Image)
        Me.BindingNavigatorAddNewItem.Name = "BindingNavigatorAddNewItem"
        Me.BindingNavigatorAddNewItem.RightToLeftAutoMirrorImage = True
        Me.BindingNavigatorAddNewItem.Size = New System.Drawing.Size(23, 35)
        Me.BindingNavigatorAddNewItem.Text = "Add new"
        Me.BindingNavigatorAddNewItem.Visible = False
        '
        'BindingNavigatorCountItem
        '
        Me.BindingNavigatorCountItem.Name = "BindingNavigatorCountItem"
        Me.BindingNavigatorCountItem.Size = New System.Drawing.Size(41, 35)
        Me.BindingNavigatorCountItem.Text = "of {0}"
        Me.BindingNavigatorCountItem.ToolTipText = "Total number of items"
        '
        'BindingNavigatorDeleteItem
        '
        Me.BindingNavigatorDeleteItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BindingNavigatorDeleteItem.Image = CType(resources.GetObject("BindingNavigatorDeleteItem.Image"), System.Drawing.Image)
        Me.BindingNavigatorDeleteItem.Name = "BindingNavigatorDeleteItem"
        Me.BindingNavigatorDeleteItem.RightToLeftAutoMirrorImage = True
        Me.BindingNavigatorDeleteItem.Size = New System.Drawing.Size(23, 35)
        Me.BindingNavigatorDeleteItem.Text = "Delete"
        Me.BindingNavigatorDeleteItem.Visible = False
        '
        'BindingNavigatorMoveFirstItem
        '
        Me.BindingNavigatorMoveFirstItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BindingNavigatorMoveFirstItem.Image = CType(resources.GetObject("BindingNavigatorMoveFirstItem.Image"), System.Drawing.Image)
        Me.BindingNavigatorMoveFirstItem.Name = "BindingNavigatorMoveFirstItem"
        Me.BindingNavigatorMoveFirstItem.RightToLeftAutoMirrorImage = True
        Me.BindingNavigatorMoveFirstItem.Size = New System.Drawing.Size(23, 35)
        Me.BindingNavigatorMoveFirstItem.Text = "Move first"
        '
        'BindingNavigatorMovePreviousItem
        '
        Me.BindingNavigatorMovePreviousItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BindingNavigatorMovePreviousItem.Image = CType(resources.GetObject("BindingNavigatorMovePreviousItem.Image"), System.Drawing.Image)
        Me.BindingNavigatorMovePreviousItem.Name = "BindingNavigatorMovePreviousItem"
        Me.BindingNavigatorMovePreviousItem.RightToLeftAutoMirrorImage = True
        Me.BindingNavigatorMovePreviousItem.Size = New System.Drawing.Size(23, 35)
        Me.BindingNavigatorMovePreviousItem.Text = "Move previous"
        '
        'BindingNavigatorSeparator
        '
        Me.BindingNavigatorSeparator.Name = "BindingNavigatorSeparator"
        Me.BindingNavigatorSeparator.Size = New System.Drawing.Size(6, 38)
        '
        'BindingNavigatorPositionItem
        '
        Me.BindingNavigatorPositionItem.AccessibleName = "Position"
        Me.BindingNavigatorPositionItem.AutoSize = False
        Me.BindingNavigatorPositionItem.Name = "BindingNavigatorPositionItem"
        Me.BindingNavigatorPositionItem.Size = New System.Drawing.Size(50, 21)
        Me.BindingNavigatorPositionItem.Text = "0"
        Me.BindingNavigatorPositionItem.ToolTipText = "Current position"
        '
        'BindingNavigatorSeparator1
        '
        Me.BindingNavigatorSeparator1.Name = "BindingNavigatorSeparator1"
        Me.BindingNavigatorSeparator1.Size = New System.Drawing.Size(6, 38)
        '
        'BindingNavigatorMoveNextItem
        '
        Me.BindingNavigatorMoveNextItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BindingNavigatorMoveNextItem.Image = CType(resources.GetObject("BindingNavigatorMoveNextItem.Image"), System.Drawing.Image)
        Me.BindingNavigatorMoveNextItem.Name = "BindingNavigatorMoveNextItem"
        Me.BindingNavigatorMoveNextItem.RightToLeftAutoMirrorImage = True
        Me.BindingNavigatorMoveNextItem.Size = New System.Drawing.Size(23, 35)
        Me.BindingNavigatorMoveNextItem.Text = "Move next"
        '
        'BindingNavigatorMoveLastItem
        '
        Me.BindingNavigatorMoveLastItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BindingNavigatorMoveLastItem.Image = CType(resources.GetObject("BindingNavigatorMoveLastItem.Image"), System.Drawing.Image)
        Me.BindingNavigatorMoveLastItem.Name = "BindingNavigatorMoveLastItem"
        Me.BindingNavigatorMoveLastItem.RightToLeftAutoMirrorImage = True
        Me.BindingNavigatorMoveLastItem.Size = New System.Drawing.Size(23, 35)
        Me.BindingNavigatorMoveLastItem.Text = "Move last"
        '
        'BindingNavigatorSeparator2
        '
        Me.BindingNavigatorSeparator2.Name = "BindingNavigatorSeparator2"
        Me.BindingNavigatorSeparator2.Size = New System.Drawing.Size(6, 38)
        '
        'tsbtExcel
        '
        Me.tsbtExcel.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tsbtExcel.Image = Global.TKPC.My.Resources.Resources.excel
        Me.tsbtExcel.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.tsbtExcel.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbtExcel.Name = "tsbtExcel"
        Me.tsbtExcel.Size = New System.Drawing.Size(59, 35)
        Me.tsbtExcel.Text = "Excel"
        '
        'btnExit
        '
        Me.btnExit.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.btnExit.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnExit.Image = CType(resources.GetObject("btnExit.Image"), System.Drawing.Image)
        Me.btnExit.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnExit.Name = "btnExit"
        Me.btnExit.Size = New System.Drawing.Size(52, 35)
        Me.btnExit.Text = "Exit"
        '
        'tsbtRefresh
        '
        Me.tsbtRefresh.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tsbtRefresh.Image = Global.TKPC.My.Resources.Resources.refresh
        Me.tsbtRefresh.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.tsbtRefresh.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbtRefresh.Name = "tsbtRefresh"
        Me.tsbtRefresh.Size = New System.Drawing.Size(75, 35)
        Me.tsbtRefresh.Text = "Refresh"
        '
        'tsbtPrint
        '
        Me.tsbtPrint.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tsbtPrint.Image = Global.TKPC.My.Resources.Resources.print
        Me.tsbtPrint.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.tsbtPrint.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbtPrint.Name = "tsbtPrint"
        Me.tsbtPrint.Size = New System.Drawing.Size(59, 35)
        Me.tsbtPrint.Text = "Print"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 38)
        '
        'ugList
        '
        Appearance1.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.ugList.DisplayLayout.AddNewBox.Appearance = Appearance1
        Appearance2.BackColor = System.Drawing.SystemColors.Window
        Appearance2.BorderColor = System.Drawing.SystemColors.InactiveCaption
        Appearance2.TextVAlignAsString = "Middle"
        Me.ugList.DisplayLayout.Appearance = Appearance2
        UltraGridColumn1.Header.VisiblePosition = 0
        UltraGridColumn2.Header.VisiblePosition = 1
        UltraGridColumn3.Header.VisiblePosition = 2
        UltraGridColumn4.Header.VisiblePosition = 3
        Appearance3.TextHAlignAsString = "Center"
        UltraGridColumn5.Header.Appearance = Appearance3
        UltraGridColumn5.Header.VisiblePosition = 4
        Appearance4.TextHAlignAsString = "Center"
        UltraGridColumn6.Header.Appearance = Appearance4
        UltraGridColumn6.Header.VisiblePosition = 5
        UltraGridColumn6.Width = 40
        Appearance5.TextHAlignAsString = "Center"
        UltraGridColumn7.Header.Appearance = Appearance5
        UltraGridColumn7.Header.VisiblePosition = 6
        UltraGridColumn7.Width = 63
        Appearance6.FontData.Name = "Tahoma"
        UltraGridColumn8.CellAppearance = Appearance6
        Appearance7.TextHAlignAsString = "Center"
        UltraGridColumn8.Header.Appearance = Appearance7
        UltraGridColumn8.Header.VisiblePosition = 7
        Appearance29.TextHAlignAsString = "Center"
        UltraGridColumn9.Header.Appearance = Appearance29
        UltraGridColumn9.Header.VisiblePosition = 8
        Appearance30.TextHAlignAsString = "Center"
        UltraGridColumn10.Header.Appearance = Appearance30
        UltraGridColumn10.Header.VisiblePosition = 9
        Appearance31.TextHAlignAsString = "Center"
        UltraGridColumn11.Header.Appearance = Appearance31
        UltraGridColumn11.Header.VisiblePosition = 10
        Appearance32.TextHAlignAsString = "Center"
        UltraGridColumn12.Header.Appearance = Appearance32
        UltraGridColumn12.Header.VisiblePosition = 11
        Appearance33.TextHAlignAsString = "Center"
        UltraGridColumn13.Header.Appearance = Appearance33
        UltraGridColumn13.Header.VisiblePosition = 12
        UltraGridBand1.Columns.AddRange(New Object() {UltraGridColumn1, UltraGridColumn2, UltraGridColumn3, UltraGridColumn4, UltraGridColumn5, UltraGridColumn6, UltraGridColumn7, UltraGridColumn8, UltraGridColumn9, UltraGridColumn10, UltraGridColumn11, UltraGridColumn12, UltraGridColumn13})
        Appearance34.TextVAlignAsString = "Middle"
        UltraGridBand1.Header.Appearance = Appearance34
        Me.ugList.DisplayLayout.BandsSerializer.Add(UltraGridBand1)
        Me.ugList.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Appearance35.TextHAlignAsString = "Center"
        Me.ugList.DisplayLayout.CaptionAppearance = Appearance35
        Me.ugList.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.[True]
        Appearance36.BackColor = System.Drawing.SystemColors.ActiveBorder
        Appearance36.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance36.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Appearance36.BorderColor = System.Drawing.SystemColors.Window
        Me.ugList.DisplayLayout.GroupByBox.Appearance = Appearance36
        Appearance37.ForeColor = System.Drawing.SystemColors.GrayText
        Me.ugList.DisplayLayout.GroupByBox.BandLabelAppearance = Appearance37
        Me.ugList.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Appearance38.BackColor = System.Drawing.SystemColors.ControlLightLight
        Appearance38.BackColor2 = System.Drawing.SystemColors.Control
        Appearance38.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance38.ForeColor = System.Drawing.SystemColors.GrayText
        Me.ugList.DisplayLayout.GroupByBox.PromptAppearance = Appearance38
        Appearance39.BackColor = System.Drawing.SystemColors.Window
        Appearance39.ForeColor = System.Drawing.SystemColors.ControlText
        Me.ugList.DisplayLayout.Override.ActiveCellAppearance = Appearance39
        Appearance40.BackColor = System.Drawing.SystemColors.Highlight
        Appearance40.ForeColor = System.Drawing.SystemColors.HighlightText
        Me.ugList.DisplayLayout.Override.ActiveRowAppearance = Appearance40
        Me.ugList.DisplayLayout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.[True]
        Me.ugList.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Dotted
        Me.ugList.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Dotted
        Appearance41.BackColor = System.Drawing.SystemColors.Window
        Me.ugList.DisplayLayout.Override.CardAreaAppearance = Appearance41
        Appearance42.BorderColor = System.Drawing.Color.Silver
        Appearance42.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter
        Me.ugList.DisplayLayout.Override.CellAppearance = Appearance42
        Me.ugList.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText
        Me.ugList.DisplayLayout.Override.CellPadding = 0
        Appearance43.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.ugList.DisplayLayout.Override.FilterOperatorAppearance = Appearance43
        Me.ugList.DisplayLayout.Override.FilterOperatorLocation = Infragistics.Win.UltraWinGrid.FilterOperatorLocation.AboveOperand
        Appearance44.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.ugList.DisplayLayout.Override.FilterRowAppearance = Appearance44
        Appearance45.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.ugList.DisplayLayout.Override.FilterRowSelectorAppearance = Appearance45
        Me.ugList.DisplayLayout.Override.FilterUIType = Infragistics.Win.UltraWinGrid.FilterUIType.FilterRow
        Appearance46.BackColor = System.Drawing.SystemColors.Control
        Appearance46.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance46.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element
        Appearance46.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance46.BorderColor = System.Drawing.SystemColors.Window
        Me.ugList.DisplayLayout.Override.GroupByRowAppearance = Appearance46
        Appearance47.TextHAlignAsString = "Left"
        Me.ugList.DisplayLayout.Override.HeaderAppearance = Appearance47
        Me.ugList.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti
        Me.ugList.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.WindowsXPCommand
        Appearance48.BackColor = System.Drawing.SystemColors.Window
        Appearance48.BorderColor = System.Drawing.Color.Silver
        Me.ugList.DisplayLayout.Override.RowAppearance = Appearance48
        Me.ugList.DisplayLayout.Override.RowSelectorHeaderStyle = Infragistics.Win.UltraWinGrid.RowSelectorHeaderStyle.ColumnChooserButton
        Me.ugList.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.[True]
        Me.ugList.DisplayLayout.Override.SelectTypeCol = Infragistics.Win.UltraWinGrid.SelectType.ExtendedAutoDrag
        Me.ugList.DisplayLayout.Override.SelectTypeRow = Infragistics.Win.UltraWinGrid.SelectType.ExtendedAutoDrag
        Appearance49.BackColor = System.Drawing.SystemColors.ControlLight
        Me.ugList.DisplayLayout.Override.TemplateAddRowAppearance = Appearance49
        Me.ugList.DisplayLayout.Scrollbars = Infragistics.Win.UltraWinGrid.Scrollbars.Both
        Me.ugList.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill
        Me.ugList.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate
        Me.ugList.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.OutlookGroupBy
        Me.ugList.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ugList.Font = New System.Drawing.Font("Dotum", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ugList.ImeMode = System.Windows.Forms.ImeMode.Hangul
        Me.ugList.Location = New System.Drawing.Point(0, 38)
        Me.ugList.Name = "ugList"
        Me.ugList.Size = New System.Drawing.Size(1137, 623)
        Me.ugList.TabIndex = 8
        Me.ugList.Text = "도서 예약 목록"
        '
        'uppdRent
        '
        Me.uppdRent.Document = Me.ugpdRent
        Me.uppdRent.Name = "uppdRent"
        '
        'frmReserveList
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1137, 661)
        Me.Controls.Add(Me.ugList)
        Me.Controls.Add(Me.bnList)
        Me.Name = "frmReserveList"
        Me.Tag = " "
        Me.Text = "도서 예약 현황"
        CType(Me.bnList, System.ComponentModel.ISupportInitialize).EndInit()
        Me.bnList.ResumeLayout(False)
        Me.bnList.PerformLayout()
        CType(Me.ugList, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents bnList As System.Windows.Forms.BindingNavigator
    Friend WithEvents BindingNavigatorAddNewItem As System.Windows.Forms.ToolStripButton
    Friend WithEvents BindingNavigatorCountItem As System.Windows.Forms.ToolStripLabel
    Friend WithEvents BindingNavigatorDeleteItem As System.Windows.Forms.ToolStripButton
    Friend WithEvents BindingNavigatorMoveFirstItem As System.Windows.Forms.ToolStripButton
    Friend WithEvents BindingNavigatorMovePreviousItem As System.Windows.Forms.ToolStripButton
    Friend WithEvents BindingNavigatorSeparator As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents BindingNavigatorPositionItem As System.Windows.Forms.ToolStripTextBox
    Friend WithEvents BindingNavigatorSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents BindingNavigatorMoveNextItem As System.Windows.Forms.ToolStripButton
    Friend WithEvents BindingNavigatorMoveLastItem As System.Windows.Forms.ToolStripButton
    Friend WithEvents BindingNavigatorSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents tsbtExcel As System.Windows.Forms.ToolStripButton
    Friend WithEvents btnExit As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsbtRefresh As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsbtPrint As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ugList As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents ugExcel As Infragistics.Win.UltraWinGrid.ExcelExport.UltraGridExcelExporter
    Friend WithEvents ugpdRent As Infragistics.Win.UltraWinGrid.UltraGridPrintDocument
    Friend WithEvents uppdRent As Infragistics.Win.Printing.UltraPrintPreviewDialog
End Class
