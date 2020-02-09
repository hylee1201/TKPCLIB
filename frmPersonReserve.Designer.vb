<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmPersonReserve
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
        Dim Appearance19 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance20 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraGridBand1 As Infragistics.Win.UltraWinGrid.UltraGridBand = New Infragistics.Win.UltraWinGrid.UltraGridBand("Band 0", -1)
        Dim UltraGridColumn1 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("도서명")
        Dim Appearance21 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraGridColumn2 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("바코드", 0, Nothing, 0, Infragistics.Win.UltraWinGrid.SortIndicator.Ascending, False)
        Dim Appearance22 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraGridColumn3 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("출판사", 1)
        Dim Appearance23 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraGridColumn4 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("저자", 2)
        Dim Appearance24 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance25 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraGridColumn5 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("ID", 3)
        Dim Appearance28 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance29 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance30 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance31 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance32 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance33 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance34 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance35 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance56 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance57 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance58 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmPersonReserve))
        Dim UltraDataColumn1 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("ID")
        Dim UltraDataColumn2 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("이름")
        Dim UltraDataColumn3 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("예약일")
        Dim UltraDataColumn4 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("집 전화")
        Dim Appearance1 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance2 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraGridBand2 As Infragistics.Win.UltraWinGrid.UltraGridBand = New Infragistics.Win.UltraWinGrid.UltraGridBand("Band 0", -1)
        Dim UltraGridColumn6 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("ID")
        Dim UltraGridColumn7 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Book ID")
        Dim UltraGridColumn8 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Person ID")
        Dim UltraGridColumn9 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("선택")
        Dim Appearance3 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraGridColumn10 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("도서명")
        Dim Appearance4 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraGridColumn11 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("바코드")
        Dim Appearance5 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance6 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraGridColumn12 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("예약일")
        Dim Appearance7 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance8 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance9 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance10 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance11 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance12 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance13 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance14 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance15 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance16 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance17 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance18 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Me.ugList = New Infragistics.Win.UltraWinGrid.UltraGrid
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
        Me.tsbtSave = New System.Windows.Forms.ToolStripButton
        Me.tsbtRefresh = New System.Windows.Forms.ToolStripButton
        Me.btnExit = New System.Windows.Forms.ToolStripButton
        Me.tsbtDelete = New System.Windows.Forms.ToolStripButton
        Me.UltraDataSource1 = New Infragistics.Win.UltraWinDataSource.UltraDataSource(Me.components)
        Me.lblPersonName = New System.Windows.Forms.Label
        Me.ugList2 = New Infragistics.Win.UltraWinGrid.UltraGrid
        CType(Me.ugList, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.bnList, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.bnList.SuspendLayout()
        CType(Me.UltraDataSource1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ugList2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ugList
        '
        Appearance19.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.ugList.DisplayLayout.AddNewBox.Appearance = Appearance19
        Appearance20.BackColor = System.Drawing.SystemColors.Window
        Appearance20.BorderColor = System.Drawing.SystemColors.InactiveCaption
        Appearance20.TextVAlignAsString = "Middle"
        Me.ugList.DisplayLayout.Appearance = Appearance20
        Me.ugList.DisplayLayout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.ResizeAllColumns
        UltraGridColumn1.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
        Appearance21.TextHAlignAsString = "Center"
        UltraGridColumn1.Header.Appearance = Appearance21
        UltraGridColumn1.Header.VisiblePosition = 1
        UltraGridColumn1.Width = 21
        UltraGridColumn2.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
        Appearance22.TextHAlignAsString = "Center"
        UltraGridColumn2.Header.Appearance = Appearance22
        UltraGridColumn2.Header.VisiblePosition = 3
        UltraGridColumn2.Width = 164
        UltraGridColumn3.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
        Appearance23.TextHAlignAsString = "Center"
        UltraGridColumn3.Header.Appearance = Appearance23
        UltraGridColumn3.Header.VisiblePosition = 2
        UltraGridColumn3.Width = 158
        UltraGridColumn4.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
        Appearance24.FontData.Name = "Tahoma"
        UltraGridColumn4.CellAppearance = Appearance24
        Appearance25.TextHAlignAsString = "Center"
        UltraGridColumn4.Header.Appearance = Appearance25
        UltraGridColumn4.Header.VisiblePosition = 4
        UltraGridColumn4.Width = 82
        UltraGridColumn5.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
        UltraGridColumn5.Header.VisiblePosition = 0
        UltraGridColumn5.Width = 16
        UltraGridBand1.Columns.AddRange(New Object() {UltraGridColumn1, UltraGridColumn2, UltraGridColumn3, UltraGridColumn4, UltraGridColumn5})
        Me.ugList.DisplayLayout.BandsSerializer.Add(UltraGridBand1)
        Me.ugList.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Me.ugList.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.[True]
        Appearance28.BackColor = System.Drawing.SystemColors.ActiveBorder
        Appearance28.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance28.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Appearance28.BorderColor = System.Drawing.SystemColors.Window
        Me.ugList.DisplayLayout.GroupByBox.Appearance = Appearance28
        Appearance29.ForeColor = System.Drawing.SystemColors.GrayText
        Me.ugList.DisplayLayout.GroupByBox.BandLabelAppearance = Appearance29
        Me.ugList.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Me.ugList.DisplayLayout.GroupByBox.Hidden = True
        Appearance30.BackColor = System.Drawing.SystemColors.ControlLightLight
        Appearance30.BackColor2 = System.Drawing.SystemColors.Control
        Appearance30.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance30.ForeColor = System.Drawing.SystemColors.GrayText
        Me.ugList.DisplayLayout.GroupByBox.PromptAppearance = Appearance30
        Me.ugList.DisplayLayout.MaxColScrollRegions = 1
        Me.ugList.DisplayLayout.MaxRowScrollRegions = 1
        Appearance31.BackColor = System.Drawing.SystemColors.Window
        Appearance31.ForeColor = System.Drawing.SystemColors.ControlText
        Me.ugList.DisplayLayout.Override.ActiveCellAppearance = Appearance31
        Appearance32.BackColor = System.Drawing.SystemColors.Highlight
        Appearance32.ForeColor = System.Drawing.SystemColors.HighlightText
        Me.ugList.DisplayLayout.Override.ActiveRowAppearance = Appearance32
        Me.ugList.DisplayLayout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.[True]
        Me.ugList.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Dotted
        Me.ugList.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Dotted
        Appearance33.BackColor = System.Drawing.SystemColors.Window
        Me.ugList.DisplayLayout.Override.CardAreaAppearance = Appearance33
        Appearance34.BorderColor = System.Drawing.Color.Silver
        Appearance34.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter
        Me.ugList.DisplayLayout.Override.CellAppearance = Appearance34
        Me.ugList.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText
        Me.ugList.DisplayLayout.Override.CellPadding = 0
        Me.ugList.DisplayLayout.Override.FilterUIType = Infragistics.Win.UltraWinGrid.FilterUIType.FilterRow
        Appearance35.BackColor = System.Drawing.SystemColors.Control
        Appearance35.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance35.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element
        Appearance35.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance35.BorderColor = System.Drawing.SystemColors.Window
        Me.ugList.DisplayLayout.Override.GroupByRowAppearance = Appearance35
        Appearance56.TextHAlignAsString = "Left"
        Me.ugList.DisplayLayout.Override.HeaderAppearance = Appearance56
        Me.ugList.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti
        Me.ugList.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.WindowsXPCommand
        Appearance57.BackColor = System.Drawing.SystemColors.Window
        Appearance57.BorderColor = System.Drawing.Color.Silver
        Me.ugList.DisplayLayout.Override.RowAppearance = Appearance57
        Me.ugList.DisplayLayout.Override.RowSelectorHeaderStyle = Infragistics.Win.UltraWinGrid.RowSelectorHeaderStyle.ColumnChooserButton
        Me.ugList.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.[False]
        Appearance58.BackColor = System.Drawing.SystemColors.ControlLight
        Me.ugList.DisplayLayout.Override.TemplateAddRowAppearance = Appearance58
        Me.ugList.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill
        Me.ugList.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate
        Me.ugList.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.OutlookGroupBy
        Me.ugList.Dock = System.Windows.Forms.DockStyle.Left
        Me.ugList.Font = New System.Drawing.Font("Dotum", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ugList.ImeMode = System.Windows.Forms.ImeMode.Hangul
        Me.ugList.Location = New System.Drawing.Point(0, 38)
        Me.ugList.Name = "ugList"
        Me.ugList.Size = New System.Drawing.Size(443, 441)
        Me.ugList.TabIndex = 18
        Me.ugList.Text = "Book List"
        '
        'bnList
        '
        Me.bnList.AddNewItem = Me.BindingNavigatorAddNewItem
        Me.bnList.AutoSize = False
        Me.bnList.CountItem = Me.BindingNavigatorCountItem
        Me.bnList.DeleteItem = Me.BindingNavigatorDeleteItem
        Me.bnList.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bnList.ImageScalingSize = New System.Drawing.Size(18, 18)
        Me.bnList.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BindingNavigatorMoveFirstItem, Me.BindingNavigatorMovePreviousItem, Me.BindingNavigatorSeparator, Me.BindingNavigatorPositionItem, Me.BindingNavigatorCountItem, Me.BindingNavigatorSeparator1, Me.BindingNavigatorMoveNextItem, Me.BindingNavigatorMoveLastItem, Me.BindingNavigatorSeparator2, Me.BindingNavigatorAddNewItem, Me.tsbtSave, Me.tsbtRefresh, Me.BindingNavigatorDeleteItem, Me.btnExit, Me.tsbtDelete})
        Me.bnList.Location = New System.Drawing.Point(0, 0)
        Me.bnList.MoveFirstItem = Me.BindingNavigatorMoveFirstItem
        Me.bnList.MoveLastItem = Me.BindingNavigatorMoveLastItem
        Me.bnList.MoveNextItem = Me.BindingNavigatorMoveNextItem
        Me.bnList.MovePreviousItem = Me.BindingNavigatorMovePreviousItem
        Me.bnList.Name = "bnList"
        Me.bnList.PositionItem = Me.BindingNavigatorPositionItem
        Me.bnList.Size = New System.Drawing.Size(876, 38)
        Me.bnList.TabIndex = 19
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
        'tsbtSave
        '
        Me.tsbtSave.Enabled = False
        Me.tsbtSave.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tsbtSave.Image = Global.TKPC.My.Resources.Resources.save
        Me.tsbtSave.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.tsbtSave.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbtSave.Name = "tsbtSave"
        Me.tsbtSave.Size = New System.Drawing.Size(56, 35)
        Me.tsbtSave.Text = "Save"
        Me.tsbtSave.ToolTipText = "새로만들기"
        '
        'tsbtRefresh
        '
        Me.tsbtRefresh.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tsbtRefresh.Image = CType(resources.GetObject("tsbtRefresh.Image"), System.Drawing.Image)
        Me.tsbtRefresh.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.tsbtRefresh.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbtRefresh.Name = "tsbtRefresh"
        Me.tsbtRefresh.Size = New System.Drawing.Size(75, 35)
        Me.tsbtRefresh.Text = "Refresh"
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
        'tsbtDelete
        '
        Me.tsbtDelete.Enabled = False
        Me.tsbtDelete.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tsbtDelete.Image = Global.TKPC.My.Resources.Resources.delete2
        Me.tsbtDelete.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.tsbtDelete.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbtDelete.Name = "tsbtDelete"
        Me.tsbtDelete.Size = New System.Drawing.Size(65, 35)
        Me.tsbtDelete.Text = "Delete"
        '
        'UltraDataSource1
        '
        Me.UltraDataSource1.Band.Columns.AddRange(New Object() {UltraDataColumn1, UltraDataColumn2, UltraDataColumn3, UltraDataColumn4})
        '
        'lblPersonName
        '
        Me.lblPersonName.AutoSize = True
        Me.lblPersonName.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPersonName.Location = New System.Drawing.Point(436, 10)
        Me.lblPersonName.Name = "lblPersonName"
        Me.lblPersonName.Size = New System.Drawing.Size(47, 14)
        Me.lblPersonName.TabIndex = 21
        Me.lblPersonName.Text = "Label1"
        '
        'ugList2
        '
        Appearance1.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.ugList2.DisplayLayout.AddNewBox.Appearance = Appearance1
        Appearance2.BackColor = System.Drawing.SystemColors.Window
        Appearance2.BorderColor = System.Drawing.SystemColors.InactiveCaption
        Appearance2.TextVAlignAsString = "Middle"
        Me.ugList2.DisplayLayout.Appearance = Appearance2
        Me.ugList2.DisplayLayout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.ResizeAllColumns
        UltraGridColumn6.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
        UltraGridColumn6.Header.VisiblePosition = 0
        UltraGridColumn6.Width = 14
        UltraGridColumn7.Header.VisiblePosition = 1
        UltraGridColumn7.Width = 24
        UltraGridColumn8.Header.VisiblePosition = 3
        UltraGridColumn8.Width = 63
        Appearance3.TextHAlignAsString = "Center"
        UltraGridColumn9.Header.Appearance = Appearance3
        UltraGridColumn9.Header.VisiblePosition = 2
        UltraGridColumn9.Width = 94
        UltraGridColumn10.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
        Appearance4.TextHAlignAsString = "Center"
        UltraGridColumn10.Header.Appearance = Appearance4
        UltraGridColumn10.Header.VisiblePosition = 4
        UltraGridColumn10.Width = 79
        UltraGridColumn11.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
        Appearance5.FontData.Name = "Tahoma"
        UltraGridColumn11.CellAppearance = Appearance5
        Appearance6.TextHAlignAsString = "Center"
        UltraGridColumn11.Header.Appearance = Appearance6
        UltraGridColumn11.Header.VisiblePosition = 5
        UltraGridColumn11.Width = 66
        UltraGridColumn12.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
        Appearance7.TextHAlignAsString = "Center"
        UltraGridColumn12.Header.Appearance = Appearance7
        UltraGridColumn12.Header.VisiblePosition = 6
        UltraGridColumn12.Width = 87
        UltraGridBand2.Columns.AddRange(New Object() {UltraGridColumn6, UltraGridColumn7, UltraGridColumn8, UltraGridColumn9, UltraGridColumn10, UltraGridColumn11, UltraGridColumn12})
        Me.ugList2.DisplayLayout.BandsSerializer.Add(UltraGridBand2)
        Me.ugList2.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Me.ugList2.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.[True]
        Appearance8.BackColor = System.Drawing.SystemColors.ActiveBorder
        Appearance8.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance8.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Appearance8.BorderColor = System.Drawing.SystemColors.Window
        Me.ugList2.DisplayLayout.GroupByBox.Appearance = Appearance8
        Appearance9.ForeColor = System.Drawing.SystemColors.GrayText
        Me.ugList2.DisplayLayout.GroupByBox.BandLabelAppearance = Appearance9
        Me.ugList2.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Me.ugList2.DisplayLayout.GroupByBox.Hidden = True
        Appearance10.BackColor = System.Drawing.SystemColors.ControlLightLight
        Appearance10.BackColor2 = System.Drawing.SystemColors.Control
        Appearance10.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance10.ForeColor = System.Drawing.SystemColors.GrayText
        Me.ugList2.DisplayLayout.GroupByBox.PromptAppearance = Appearance10
        Me.ugList2.DisplayLayout.MaxColScrollRegions = 1
        Me.ugList2.DisplayLayout.MaxRowScrollRegions = 1
        Appearance11.BackColor = System.Drawing.SystemColors.Window
        Appearance11.ForeColor = System.Drawing.SystemColors.ControlText
        Me.ugList2.DisplayLayout.Override.ActiveCellAppearance = Appearance11
        Appearance12.BackColor = System.Drawing.SystemColors.Highlight
        Appearance12.ForeColor = System.Drawing.SystemColors.HighlightText
        Me.ugList2.DisplayLayout.Override.ActiveRowAppearance = Appearance12
        Me.ugList2.DisplayLayout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.[False]
        Me.ugList2.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Dotted
        Me.ugList2.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Dotted
        Appearance13.BackColor = System.Drawing.SystemColors.Window
        Me.ugList2.DisplayLayout.Override.CardAreaAppearance = Appearance13
        Appearance14.BorderColor = System.Drawing.Color.Silver
        Appearance14.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter
        Me.ugList2.DisplayLayout.Override.CellAppearance = Appearance14
        Me.ugList2.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText
        Me.ugList2.DisplayLayout.Override.CellPadding = 0
        Me.ugList2.DisplayLayout.Override.FilterUIType = Infragistics.Win.UltraWinGrid.FilterUIType.FilterRow
        Appearance15.BackColor = System.Drawing.SystemColors.Control
        Appearance15.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance15.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element
        Appearance15.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance15.BorderColor = System.Drawing.SystemColors.Window
        Me.ugList2.DisplayLayout.Override.GroupByRowAppearance = Appearance15
        Appearance16.TextHAlignAsString = "Left"
        Me.ugList2.DisplayLayout.Override.HeaderAppearance = Appearance16
        Me.ugList2.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti
        Me.ugList2.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.WindowsXPCommand
        Appearance17.BackColor = System.Drawing.SystemColors.Window
        Appearance17.BorderColor = System.Drawing.Color.Silver
        Me.ugList2.DisplayLayout.Override.RowAppearance = Appearance17
        Me.ugList2.DisplayLayout.Override.RowSelectorHeaderStyle = Infragistics.Win.UltraWinGrid.RowSelectorHeaderStyle.None
        Me.ugList2.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.[False]
        Appearance18.BackColor = System.Drawing.SystemColors.ControlLight
        Me.ugList2.DisplayLayout.Override.TemplateAddRowAppearance = Appearance18
        Me.ugList2.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill
        Me.ugList2.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate
        Me.ugList2.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.OutlookGroupBy
        Me.ugList2.Dock = System.Windows.Forms.DockStyle.Right
        Me.ugList2.Font = New System.Drawing.Font("Dotum", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ugList2.ImeMode = System.Windows.Forms.ImeMode.Hangul
        Me.ugList2.Location = New System.Drawing.Point(447, 38)
        Me.ugList2.Name = "ugList2"
        Me.ugList2.Size = New System.Drawing.Size(429, 441)
        Me.ugList2.TabIndex = 22
        Me.ugList2.Text = "Reservation List"
        '
        'frmPersonReserve
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(876, 479)
        Me.Controls.Add(Me.ugList2)
        Me.Controls.Add(Me.lblPersonName)
        Me.Controls.Add(Me.ugList)
        Me.Controls.Add(Me.bnList)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmPersonReserve"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Book Reservation Screen"
        CType(Me.ugList, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.bnList, System.ComponentModel.ISupportInitialize).EndInit()
        Me.bnList.ResumeLayout(False)
        Me.bnList.PerformLayout()
        CType(Me.UltraDataSource1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ugList2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ugList As Infragistics.Win.UltraWinGrid.UltraGrid
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
    Friend WithEvents tsbtSave As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsbtRefresh As System.Windows.Forms.ToolStripButton
    Friend WithEvents btnExit As System.Windows.Forms.ToolStripButton
    Friend WithEvents UltraDataSource1 As Infragistics.Win.UltraWinDataSource.UltraDataSource
    Friend WithEvents tsbtDelete As System.Windows.Forms.ToolStripButton
    Friend WithEvents lblPersonName As System.Windows.Forms.Label
    Friend WithEvents ugList2 As Infragistics.Win.UltraWinGrid.UltraGrid
End Class
