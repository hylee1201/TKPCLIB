<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmBookList
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmBookList))
        Dim Appearance165 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance166 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraGridBand1 As Infragistics.Win.UltraWinGrid.UltraGridBand = New Infragistics.Win.UltraWinGrid.UltraGridBand("Band 0", -1)
        Dim UltraGridColumn1 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Barcode ID")
        Dim UltraGridColumn2 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Book ID")
        Dim UltraGridColumn3 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("선택")
        Dim UltraGridColumn4 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("현재상태")
        Dim Appearance167 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraGridColumn5 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("바코드")
        Dim Appearance168 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraGridColumn6 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("책 번호")
        Dim Appearance169 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance170 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraGridColumn7 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("도서명", -1, Nothing, 0, Infragistics.Win.UltraWinGrid.SortIndicator.Descending, False)
        Dim Appearance171 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraGridColumn8 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("소제목")
        Dim Appearance172 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance173 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraGridColumn9 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("저자")
        Dim Appearance174 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance175 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraGridColumn10 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("책 분류명")
        Dim Appearance176 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance177 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraGridColumn11 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("출판사")
        Dim Appearance178 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance179 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraGridColumn12 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("구매가격")
        Dim UltraGridColumn13 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("구매/기증")
        Dim Appearance180 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance181 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraGridColumn14 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("구매/기증일")
        Dim Appearance182 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance183 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraGridColumn15 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("구매/기증 경로")
        Dim Appearance184 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance185 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraGridColumn16 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("비고")
        Dim Appearance186 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance187 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraGridColumn17 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("데이터 저장일")
        Dim Appearance188 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance189 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraGridColumn18 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Book Type ID")
        Dim UltraGridColumn19 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("대출자")
        Dim Appearance190 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraGridColumn20 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("대출일")
        Dim Appearance191 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraGridColumn21 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("데이터 생성일")
        Dim Appearance192 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance193 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance194 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance195 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance196 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance197 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance198 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance199 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance200 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance201 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance202 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance203 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance204 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance205 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance206 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance207 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
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
        Me.tsbtAdd = New System.Windows.Forms.ToolStripButton
        Me.tsbtDelete = New System.Windows.Forms.ToolStripButton
        Me.tsbtRefresh = New System.Windows.Forms.ToolStripButton
        Me.tsbtReset = New System.Windows.Forms.ToolStripButton
        Me.tsbtPrint = New System.Windows.Forms.ToolStripButton
        Me.tsbtBarcode = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator
        Me.tsddbtBooks = New System.Windows.Forms.ToolStripDropDownButton
        Me.BooksOnRentToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.BooksAvailableToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.AllBooksToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.NewBookToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.NewBookListToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.BarcodeToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ugList = New Infragistics.Win.UltraWinGrid.UltraGrid
        Me.ugExcel = New Infragistics.Win.UltraWinGrid.ExcelExport.UltraGridExcelExporter(Me.components)
        Me.uppdRent = New Infragistics.Win.Printing.UltraPrintPreviewDialog(Me.components)
        Me.ugpdRent = New Infragistics.Win.UltraWinGrid.UltraGridPrintDocument(Me.components)
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
        Me.bnList.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BindingNavigatorMoveFirstItem, Me.BindingNavigatorMovePreviousItem, Me.BindingNavigatorSeparator, Me.BindingNavigatorPositionItem, Me.BindingNavigatorCountItem, Me.BindingNavigatorSeparator1, Me.BindingNavigatorMoveNextItem, Me.BindingNavigatorMoveLastItem, Me.BindingNavigatorSeparator2, Me.BindingNavigatorAddNewItem, Me.BindingNavigatorDeleteItem, Me.tsbtExcel, Me.btnExit, Me.tsbtAdd, Me.tsbtDelete, Me.tsbtRefresh, Me.tsbtReset, Me.tsbtPrint, Me.tsbtBarcode, Me.ToolStripSeparator1, Me.tsddbtBooks})
        Me.bnList.Location = New System.Drawing.Point(0, 0)
        Me.bnList.MoveFirstItem = Me.BindingNavigatorMoveFirstItem
        Me.bnList.MoveLastItem = Me.BindingNavigatorMoveLastItem
        Me.bnList.MoveNextItem = Me.BindingNavigatorMoveNextItem
        Me.bnList.MovePreviousItem = Me.BindingNavigatorMovePreviousItem
        Me.bnList.Name = "bnList"
        Me.bnList.PositionItem = Me.BindingNavigatorPositionItem
        Me.bnList.Size = New System.Drawing.Size(1165, 38)
        Me.bnList.TabIndex = 4
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
        'tsbtAdd
        '
        Me.tsbtAdd.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tsbtAdd.Image = Global.TKPC.My.Resources.Resources._new
        Me.tsbtAdd.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.tsbtAdd.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbtAdd.Name = "tsbtAdd"
        Me.tsbtAdd.Size = New System.Drawing.Size(79, 35)
        Me.tsbtAdd.Text = "Add New"
        '
        'tsbtDelete
        '
        Me.tsbtDelete.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tsbtDelete.Image = Global.TKPC.My.Resources.Resources.delete2
        Me.tsbtDelete.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.tsbtDelete.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbtDelete.Name = "tsbtDelete"
        Me.tsbtDelete.Size = New System.Drawing.Size(65, 35)
        Me.tsbtDelete.Text = "Delete"
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
        'tsbtReset
        '
        Me.tsbtReset.Enabled = False
        Me.tsbtReset.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tsbtReset.Image = Global.TKPC.My.Resources.Resources.reset
        Me.tsbtReset.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.tsbtReset.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbtReset.Name = "tsbtReset"
        Me.tsbtReset.Size = New System.Drawing.Size(60, 35)
        Me.tsbtReset.Text = "Reset"
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
        'tsbtBarcode
        '
        Me.tsbtBarcode.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tsbtBarcode.Image = Global.TKPC.My.Resources.Resources.Barcode_Scan_2
        Me.tsbtBarcode.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbtBarcode.Name = "tsbtBarcode"
        Me.tsbtBarcode.Size = New System.Drawing.Size(112, 35)
        Me.tsbtBarcode.Text = "Print Barcode"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 38)
        '
        'tsddbtBooks
        '
        Me.tsddbtBooks.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BooksOnRentToolStripMenuItem, Me.BooksAvailableToolStripMenuItem, Me.AllBooksToolStripMenuItem, Me.NewBookToolStripMenuItem, Me.NewBookListToolStripMenuItem, Me.BarcodeToolStripMenuItem})
        Me.tsddbtBooks.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tsddbtBooks.Image = Global.TKPC.My.Resources.Resources.list
        Me.tsddbtBooks.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.tsddbtBooks.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsddbtBooks.Name = "tsddbtBooks"
        Me.tsddbtBooks.Size = New System.Drawing.Size(67, 35)
        Me.tsddbtBooks.Text = "View"
        '
        'BooksOnRentToolStripMenuItem
        '
        Me.BooksOnRentToolStripMenuItem.Name = "BooksOnRentToolStripMenuItem"
        Me.BooksOnRentToolStripMenuItem.Size = New System.Drawing.Size(299, 22)
        Me.BooksOnRentToolStripMenuItem.Text = "현재 대출중인 도서 목록"
        '
        'BooksAvailableToolStripMenuItem
        '
        Me.BooksAvailableToolStripMenuItem.Name = "BooksAvailableToolStripMenuItem"
        Me.BooksAvailableToolStripMenuItem.Size = New System.Drawing.Size(299, 22)
        Me.BooksAvailableToolStripMenuItem.Text = "대출 가능한 도서 목록"
        '
        'AllBooksToolStripMenuItem
        '
        Me.AllBooksToolStripMenuItem.Name = "AllBooksToolStripMenuItem"
        Me.AllBooksToolStripMenuItem.Size = New System.Drawing.Size(299, 22)
        Me.AllBooksToolStripMenuItem.Text = "모든 도서 목록"
        '
        'NewBookToolStripMenuItem
        '
        Me.NewBookToolStripMenuItem.Name = "NewBookToolStripMenuItem"
        Me.NewBookToolStripMenuItem.Size = New System.Drawing.Size(299, 22)
        Me.NewBookToolStripMenuItem.Text = "최근에 새로 입력한 도서 목록"
        '
        'NewBookListToolStripMenuItem
        '
        Me.NewBookListToolStripMenuItem.Name = "NewBookListToolStripMenuItem"
        Me.NewBookListToolStripMenuItem.Size = New System.Drawing.Size(299, 22)
        Me.NewBookListToolStripMenuItem.Text = "최근에 새로 입력한 도서 목록 (주보용)"
        '
        'BarcodeToolStripMenuItem
        '
        Me.BarcodeToolStripMenuItem.Name = "BarcodeToolStripMenuItem"
        Me.BarcodeToolStripMenuItem.Size = New System.Drawing.Size(299, 22)
        Me.BarcodeToolStripMenuItem.Text = "바코드 찍을 신간도서 목록"
        '
        'ugList
        '
        Appearance165.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.ugList.DisplayLayout.AddNewBox.Appearance = Appearance165
        Appearance166.BackColor = System.Drawing.SystemColors.Window
        Appearance166.BorderColor = System.Drawing.SystemColors.InactiveCaption
        Appearance166.TextVAlignAsString = "Middle"
        Me.ugList.DisplayLayout.Appearance = Appearance166
        UltraGridColumn1.Header.VisiblePosition = 0
        UltraGridColumn1.Width = 64
        UltraGridColumn2.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
        UltraGridColumn2.Header.VisiblePosition = 1
        UltraGridColumn3.Header.VisiblePosition = 2
        UltraGridColumn4.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
        Appearance167.TextHAlignAsString = "Center"
        UltraGridColumn4.Header.Appearance = Appearance167
        UltraGridColumn4.Header.VisiblePosition = 5
        UltraGridColumn5.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
        UltraGridColumn5.FilterClearButtonVisible = Infragistics.Win.DefaultableBoolean.[False]
        Appearance168.TextHAlignAsString = "Center"
        UltraGridColumn5.Header.Appearance = Appearance168
        UltraGridColumn5.Header.VisiblePosition = 4
        UltraGridColumn6.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
        Appearance169.FontData.Name = "Tahoma"
        Appearance169.TextVAlignAsString = "Middle"
        UltraGridColumn6.CellAppearance = Appearance169
        Appearance170.TextHAlignAsString = "Center"
        UltraGridColumn6.Header.Appearance = Appearance170
        UltraGridColumn6.Header.VisiblePosition = 8
        UltraGridColumn7.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
        Appearance171.TextHAlignAsString = "Center"
        UltraGridColumn7.Header.Appearance = Appearance171
        UltraGridColumn7.Header.VisiblePosition = 3
        UltraGridColumn8.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
        Appearance172.TextVAlignAsString = "Middle"
        UltraGridColumn8.CellAppearance = Appearance172
        Appearance173.TextHAlignAsString = "Center"
        UltraGridColumn8.Header.Appearance = Appearance173
        UltraGridColumn8.Header.VisiblePosition = 9
        UltraGridColumn9.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
        Appearance174.TextVAlignAsString = "Middle"
        UltraGridColumn9.CellAppearance = Appearance174
        Appearance175.TextHAlignAsString = "Center"
        UltraGridColumn9.Header.Appearance = Appearance175
        UltraGridColumn9.Header.VisiblePosition = 10
        UltraGridColumn10.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
        Appearance176.TextVAlignAsString = "Middle"
        UltraGridColumn10.CellAppearance = Appearance176
        Appearance177.TextHAlignAsString = "Center"
        UltraGridColumn10.Header.Appearance = Appearance177
        UltraGridColumn10.Header.VisiblePosition = 11
        UltraGridColumn11.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
        Appearance178.TextVAlignAsString = "Middle"
        UltraGridColumn11.CellAppearance = Appearance178
        Appearance179.TextHAlignAsString = "Center"
        UltraGridColumn11.Header.Appearance = Appearance179
        UltraGridColumn11.Header.VisiblePosition = 12
        UltraGridColumn12.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
        UltraGridColumn12.Header.VisiblePosition = 13
        UltraGridColumn13.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
        Appearance180.TextVAlignAsString = "Middle"
        UltraGridColumn13.CellAppearance = Appearance180
        Appearance181.TextHAlignAsString = "Center"
        UltraGridColumn13.Header.Appearance = Appearance181
        UltraGridColumn13.Header.VisiblePosition = 14
        UltraGridColumn14.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
        Appearance182.FontData.Name = "Tahoma"
        Appearance182.TextVAlignAsString = "Middle"
        UltraGridColumn14.CellAppearance = Appearance182
        Appearance183.TextHAlignAsString = "Center"
        UltraGridColumn14.Header.Appearance = Appearance183
        UltraGridColumn14.Header.VisiblePosition = 15
        UltraGridColumn14.MaskInput = "{LOC}mm/dd/yyyy"
        UltraGridColumn15.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
        Appearance184.TextVAlignAsString = "Middle"
        UltraGridColumn15.CellAppearance = Appearance184
        Appearance185.TextHAlignAsString = "Center"
        UltraGridColumn15.Header.Appearance = Appearance185
        UltraGridColumn15.Header.VisiblePosition = 16
        UltraGridColumn16.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
        Appearance186.TextVAlignAsString = "Middle"
        UltraGridColumn16.CellAppearance = Appearance186
        Appearance187.TextHAlignAsString = "Center"
        UltraGridColumn16.Header.Appearance = Appearance187
        UltraGridColumn16.Header.VisiblePosition = 17
        UltraGridColumn17.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
        Appearance188.FontData.Name = "Tahoma"
        Appearance188.TextVAlignAsString = "Middle"
        UltraGridColumn17.CellAppearance = Appearance188
        Appearance189.TextHAlignAsString = "Center"
        UltraGridColumn17.Header.Appearance = Appearance189
        UltraGridColumn17.Header.VisiblePosition = 18
        UltraGridColumn17.MaskInput = "{LOC}mm/dd/yyyy"
        UltraGridColumn18.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
        UltraGridColumn18.Header.VisiblePosition = 19
        UltraGridColumn19.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
        Appearance190.TextHAlignAsString = "Center"
        UltraGridColumn19.Header.Appearance = Appearance190
        UltraGridColumn19.Header.VisiblePosition = 6
        UltraGridColumn20.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
        Appearance191.TextHAlignAsString = "Center"
        UltraGridColumn20.Header.Appearance = Appearance191
        UltraGridColumn20.Header.VisiblePosition = 7
        UltraGridColumn20.MaskInput = "{LOC}yyyy/mm/dd"
        UltraGridColumn21.Header.VisiblePosition = 20
        UltraGridBand1.Columns.AddRange(New Object() {UltraGridColumn1, UltraGridColumn2, UltraGridColumn3, UltraGridColumn4, UltraGridColumn5, UltraGridColumn6, UltraGridColumn7, UltraGridColumn8, UltraGridColumn9, UltraGridColumn10, UltraGridColumn11, UltraGridColumn12, UltraGridColumn13, UltraGridColumn14, UltraGridColumn15, UltraGridColumn16, UltraGridColumn17, UltraGridColumn18, UltraGridColumn19, UltraGridColumn20, UltraGridColumn21})
        Appearance192.TextVAlignAsString = "Middle"
        UltraGridBand1.Header.Appearance = Appearance192
        Me.ugList.DisplayLayout.BandsSerializer.Add(UltraGridBand1)
        Me.ugList.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Me.ugList.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.[True]
        Appearance193.BackColor = System.Drawing.SystemColors.ActiveBorder
        Appearance193.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance193.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Appearance193.BorderColor = System.Drawing.SystemColors.Window
        Me.ugList.DisplayLayout.GroupByBox.Appearance = Appearance193
        Appearance194.ForeColor = System.Drawing.SystemColors.GrayText
        Me.ugList.DisplayLayout.GroupByBox.BandLabelAppearance = Appearance194
        Me.ugList.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Appearance195.BackColor = System.Drawing.SystemColors.ControlLightLight
        Appearance195.BackColor2 = System.Drawing.SystemColors.Control
        Appearance195.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance195.ForeColor = System.Drawing.SystemColors.GrayText
        Me.ugList.DisplayLayout.GroupByBox.PromptAppearance = Appearance195
        Appearance196.BackColor = System.Drawing.SystemColors.Window
        Appearance196.ForeColor = System.Drawing.SystemColors.ControlText
        Me.ugList.DisplayLayout.Override.ActiveCellAppearance = Appearance196
        Appearance197.BackColor = System.Drawing.SystemColors.Highlight
        Appearance197.ForeColor = System.Drawing.SystemColors.HighlightText
        Me.ugList.DisplayLayout.Override.ActiveRowAppearance = Appearance197
        Me.ugList.DisplayLayout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.[True]
        Me.ugList.DisplayLayout.Override.AllowUpdate = Infragistics.Win.DefaultableBoolean.[True]
        Me.ugList.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Dotted
        Me.ugList.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Dotted
        Appearance198.BackColor = System.Drawing.SystemColors.Window
        Me.ugList.DisplayLayout.Override.CardAreaAppearance = Appearance198
        Appearance199.BorderColor = System.Drawing.Color.Silver
        Appearance199.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter
        Me.ugList.DisplayLayout.Override.CellAppearance = Appearance199
        Me.ugList.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText
        Me.ugList.DisplayLayout.Override.CellPadding = 0
        Appearance200.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.ugList.DisplayLayout.Override.FilterOperatorAppearance = Appearance200
        Me.ugList.DisplayLayout.Override.FilterOperatorDefaultValue = Infragistics.Win.UltraWinGrid.FilterOperatorDefaultValue.Contains
        Me.ugList.DisplayLayout.Override.FilterOperatorLocation = Infragistics.Win.UltraWinGrid.FilterOperatorLocation.AboveOperand
        Appearance201.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.ugList.DisplayLayout.Override.FilterRowAppearance = Appearance201
        Appearance202.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.ugList.DisplayLayout.Override.FilterRowSelectorAppearance = Appearance202
        Me.ugList.DisplayLayout.Override.FilterUIType = Infragistics.Win.UltraWinGrid.FilterUIType.FilterRow
        Appearance203.TextVAlignAsString = "Middle"
        Me.ugList.DisplayLayout.Override.FixedHeaderAppearance = Appearance203
        Appearance204.BackColor = System.Drawing.SystemColors.Control
        Appearance204.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance204.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element
        Appearance204.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance204.BorderColor = System.Drawing.SystemColors.Window
        Me.ugList.DisplayLayout.Override.GroupByRowAppearance = Appearance204
        Appearance205.TextHAlignAsString = "Left"
        Appearance205.TextVAlignAsString = "Middle"
        Me.ugList.DisplayLayout.Override.HeaderAppearance = Appearance205
        Me.ugList.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti
        Me.ugList.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.WindowsXPCommand
        Appearance206.BackColor = System.Drawing.SystemColors.Window
        Appearance206.BorderColor = System.Drawing.Color.Silver
        Appearance206.TextVAlignAsString = "Middle"
        Me.ugList.DisplayLayout.Override.RowAppearance = Appearance206
        Me.ugList.DisplayLayout.Override.RowSelectorHeaderStyle = Infragistics.Win.UltraWinGrid.RowSelectorHeaderStyle.ColumnChooserButton
        Me.ugList.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.[True]
        Me.ugList.DisplayLayout.Override.SelectTypeCell = Infragistics.Win.UltraWinGrid.SelectType.[Single]
        Me.ugList.DisplayLayout.Override.SelectTypeCol = Infragistics.Win.UltraWinGrid.SelectType.ExtendedAutoDrag
        Me.ugList.DisplayLayout.Override.SelectTypeRow = Infragistics.Win.UltraWinGrid.SelectType.ExtendedAutoDrag
        Appearance207.BackColor = System.Drawing.SystemColors.ControlLight
        Me.ugList.DisplayLayout.Override.TemplateAddRowAppearance = Appearance207
        Me.ugList.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill
        Me.ugList.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate
        Me.ugList.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.OutlookGroupBy
        Me.ugList.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ugList.ExitEditModeOnLeave = False
        Me.ugList.Font = New System.Drawing.Font("Dotum", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ugList.ImeMode = System.Windows.Forms.ImeMode.Hangul
        Me.ugList.Location = New System.Drawing.Point(0, 38)
        Me.ugList.Name = "ugList"
        Me.ugList.RowUpdateCancelAction = Infragistics.Win.UltraWinGrid.RowUpdateCancelAction.RetainDataAndActivation
        Me.ugList.Size = New System.Drawing.Size(1165, 621)
        Me.ugList.TabIndex = 5
        Me.ugList.Text = "모든 도서 목록"
        Me.ugList.UpdateMode = Infragistics.Win.UltraWinGrid.UpdateMode.OnCellChange
        '
        'uppdRent
        '
        Me.uppdRent.Document = Me.ugpdRent
        Me.uppdRent.Name = "uppdRent"
        '
        'ugpdRent
        '
        Me.ugpdRent.Grid = Me.ugList
        '
        'frmBookList
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoScroll = True
        Me.AutoSize = True
        Me.BackColor = System.Drawing.Color.LightSteelBlue
        Me.ClientSize = New System.Drawing.Size(1165, 659)
        Me.Controls.Add(Me.ugList)
        Me.Controls.Add(Me.bnList)
        Me.Name = "frmBookList"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "도서목록"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
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
    Friend WithEvents tsbtAdd As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsbtRefresh As System.Windows.Forms.ToolStripButton
    Friend WithEvents ugList As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents ugExcel As Infragistics.Win.UltraWinGrid.ExcelExport.UltraGridExcelExporter
    Friend WithEvents tsbtPrint As System.Windows.Forms.ToolStripButton
    Friend WithEvents uppdRent As Infragistics.Win.Printing.UltraPrintPreviewDialog
    Friend WithEvents ugpdRent As Infragistics.Win.UltraWinGrid.UltraGridPrintDocument
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents tsddbtBooks As System.Windows.Forms.ToolStripDropDownButton
    Friend WithEvents BooksOnRentToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents BooksAvailableToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AllBooksToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents NewBookToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsbtBarcode As System.Windows.Forms.ToolStripButton
    Friend WithEvents NewBookListToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsbtReset As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsbtDelete As System.Windows.Forms.ToolStripButton
    Friend WithEvents BarcodeToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
End Class
