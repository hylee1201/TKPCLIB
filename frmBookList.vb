Public Class frmBookList

    Private totalNumberOfRows As Integer = 0
    Private printHeader As String = "모든 도서 목록"
    Private cellChanged As Boolean = False

    Private Sub frmBookList_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        'tsbtRefresh_Click(sender, e)
        fillGrid(m_Common.bookListViewID, "")
        If m_Common.bookListRowIndex >= 26 Then
            ugList.ActiveRowScrollRegion.ScrollPosition = m_Common.bookListRowIndex
        End If
        If whichIME = 0 Then
            whichIME = SwitchIME(hKrLayoutId, KbdKr)
        End If
    End Sub

    'Private Sub frmBookList_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
    '    BookListLoadedFlag = False
    '    Dim bookDAL As TKPC.DAL.BookDAL = Nothing
    '    Try
    '        bookDAL = TKPC.DAL.BookDAL.getInstance()
    '        bookDAL.updateBookFlags(1, "")
    '    Catch ex As Exception
    '    Finally
    '        bookDAL = Nothing
    '        m_Common.bookListRowIndex = 0
    '    End Try
    'End Sub

    Private Sub frmBookList_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Show()
        With ugList
            .DisplayLayout.Bands(0).Columns("Barcode ID").Hidden = True
            .DisplayLayout.Bands(0).Columns("Book ID").Hidden = True
            .DisplayLayout.Bands(0).Columns("선택").Width = 40
            .DisplayLayout.Bands(0).Columns("현재상태").Width = 70
            .DisplayLayout.Bands(0).Columns("책 번호").Width = 55
            .DisplayLayout.Bands(0).Columns("책 번호").Hidden = True
            .DisplayLayout.Bands(0).Columns("도서명").Width = 350
            .DisplayLayout.Bands(0).Columns("소제목").Width = 60
            .DisplayLayout.Bands(0).Columns("대출자").Width = 80
            .DisplayLayout.Bands(0).Columns("대출일").Width = 70
            .DisplayLayout.Bands(0).Columns("저자").Width = 120
            .DisplayLayout.Bands(0).Columns("책 분류명").Width = 90
            .DisplayLayout.Bands(0).Columns("출판사").Width = 120
            .DisplayLayout.Bands(0).Columns("바코드").Width = 70
            .DisplayLayout.Bands(0).Columns("구매가격").Hidden = True
            .DisplayLayout.Bands(0).Columns("구매/기증일").Width = 80
            .DisplayLayout.Bands(0).Columns("구매/기증일").Hidden = True
            .DisplayLayout.Bands(0).Columns("구매/기증").Width = 35
            .DisplayLayout.Bands(0).Columns("구매/기증").Hidden = True
            .DisplayLayout.Bands(0).Columns("구매/기증 경로").Width = 100
            .DisplayLayout.Bands(0).Columns("구매/기증 경로").Hidden = True
            .DisplayLayout.Bands(0).Columns("비고").Width = 250
            .DisplayLayout.Bands(0).Columns("비고").Hidden = True
            .DisplayLayout.Bands(0).Columns("데이터 저장일").Width = 80
            .DisplayLayout.Bands(0).Columns("데이터 저장일").Hidden = True
            .DisplayLayout.Bands(0).Columns("Book Type ID").Hidden = True
            .DisplayLayout.Bands(0).Columns("데이터 생성일").Width = 80
            .DisplayLayout.Bands(0).Columns("데이터 생성일").Hidden = True
            .DisplayLayout.Override.RowAppearance.TextVAlign = Infragistics.Win.VAlign.Middle
        End With


        'fillGrid(WHOLE_LIST, "")
        'BookListLoadedFlag = True
    End Sub

    Private Sub fillGrid(ByVal flag As Integer, ByVal searchWords As String)
        Dim bookDAL As TKPC.DAL.BookDAL = TKPC.DAL.BookDAL.getInstance()
        Dim ds As DataSet = Nothing
        Dim bs As BindingSource = Nothing

        Try
            ds = bookDAL.getList(flag, searchWords)

            If ds IsNot Nothing Then
                bs = New BindingSource
                bs.DataSource = ds.Tables(0)
                totalNumberOfRows = ds.Tables(0).Rows.Count

                If totalNumberOfRows > 0 Then
                    MDITKPC.tspbMDI.Maximum = totalNumberOfRows
                    MDITKPC.tspbMDI.Visible = True
                End If

                bnList.BindingSource = bs

                With ugList
                    .DataSource = bs
                End With
                tsbtExcel.Enabled = True

            Else
                tsbtExcel.Enabled = False
            End If
        Catch ex As Exception
        Finally
            ds = Nothing
            bs = Nothing
            bookDAL = Nothing
        End Try
    End Sub

    Private Sub tsbtExcel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles tsbtExcel.Click
        Cursor.Current = Cursors.WaitCursor
        Try
            Dim theFile As String = "C:\users\admin\desktop\" + BOOK_LIST_EXCEL 'Application.StartupPath + "\\" + BOOK_LIST_EXCEL
            Me.ugExcel.Export(Me.ugList, theFile)
            Process.Start(theFile)

        Catch ex As Exception
            MessageBox.Show(ex.Message + " If the file called " + BOOK_LIST_EXCEL + " is open, please close it and try again.")
        Finally
            Cursor.Current = Cursors.Default
        End Try
    End Sub

    Private Sub ugList_CellChange(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinGrid.CellEventArgs) Handles ugList.CellChange
        Dim headerName As String = e.Cell.Column.Header.Caption
        If headerName = "선택" Then
            Dim bookDAL As TKPC.DAL.BookDAL = TKPC.DAL.BookDAL.getInstance()
            Dim theBarcodeID As String = ""

            If e.Cell.Row.Cells("Barcode ID").Value IsNot DBNull.Value Then
                theBarcodeID = e.Cell.Row.Cells("Barcode ID").Value
            End If

            If e.Cell.Text <> "" And e.Cell.Text IsNot DBNull.Value Then
                If e.Cell.Text = True Then
                    'e.Cell.Row.CellAppearance.BackColor = Color.LightSkyBlue
                    bookDAL.updateRecord(1, theBarcodeID, 1)
                    cellChanged = True
                    tsbtReset.Enabled = True
                Else
                    'e.Cell.Row.CellAppearance.BackColor = Color.White
                    bookDAL.updateRecord(1, theBarcodeID, 0)
                    cellChanged = False
                    tsbtReset.Enabled = False
                End If
            End If
        End If
    End Sub

    Private Sub ugList_DoubleClickRow(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinGrid.DoubleClickRowEventArgs) Handles ugList.DoubleClickRow
        If e.Row.Index >= 0 Then
            If e.Row.Cells("Book ID").Value IsNot Nothing Then
                m_Common.bookListRowIndex = e.Row.VisibleIndex - 1
                Dim bookID As String = e.Row.Cells("Book ID").Value
                Dim bookEnt As TKPC.Entity.BookEnt = New TKPC.Entity.BookEnt
                Dim bookDAL As TKPC.DAL.BookDAL = TKPC.DAL.BookDAL.getInstance()

                Try
                    bookEnt = bookDAL.getRecordByID(bookID)

                    'With frmBookAdd
                    '    .Width = 951
                    '    .Height = 695
                    '    .WindowState = FormWindowState.Normal
                    '    .viewMode = VIEW_MODE_DETAIL
                    '    .bookEnt = bookEnt
                    '    .ShowDialog()
                    'End With
                    frmBookAdd.Dispose()
                    With frmBookAdd
                        .bookEnt = bookEnt
                        .viewMode = VIEW_MODE_DETAIL
                        .fromWhichForm = FROM_BOOK_LIST_OR_MDI
                        .callingForm = Me
                        openForm(Me, frmBookAdd)
                    End With
                    'frmBookAdd.bookEnt = bookEnt
                    'frmBookAdd.viewMode = VIEW_MODE_DETAIL
                    'frmBookAdd.fromWhichForm = FROM_BOOK_LIST_OR_MDI
                    'frmBookAdd.callingForm = Me
                    'openForm(Me, frmBookAdd)
                Catch
                Finally
                    bookEnt = Nothing
                    bookDAL = Nothing
                End Try
            End If
        End If
    End Sub

    Private Sub btnExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExit.Click        
        closeForm(Me)
    End Sub

    Private Sub tsbtAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbtAdd.Click
        With frmBookAdd
            .Dispose()
            .viewMode = VIEW_MODE_ADD_NEW
            openForm(Me, frmBookAdd)
        End With
    End Sub

    Public Sub tsbtRefresh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbtRefresh.Click
        fillGrid(WHOLE_LIST, "")
    End Sub

    Private Sub ugList_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles ugList.Enter
        If whichIME = 0 Then
            whichIME = SwitchIME(hKrLayoutId, KbdKr)
        End If
    End Sub

    Private Sub ugList_InitializeRow(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinGrid.InitializeRowEventArgs) Handles ugList.InitializeRow
        If totalNumberOfRows > 0 Then
            If e.Row.Cells("현재상태").Text = "대출중" Then
                e.Row.CellAppearance.BackColor = Color.LightSkyBlue
            End If

            MDITKPC.tspbMDI.Value += 1

            If MDITKPC.tspbMDI.Value = totalNumberOfRows Then
                MDITKPC.tspbMDI.Visible = False
                MDITKPC.tspbMDI.Value = 0
                totalNumberOfRows = 0
            End If
        End If
    End Sub

    Private Sub ugList_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles ugList.KeyDown
        If e.KeyCode = Keys.Down Then
            ugList.ActiveRowScrollRegion.Scroll(Infragistics.Win.UltraWinGrid.RowScrollAction.LineDown)
        ElseIf e.KeyCode = Keys.Up Then
            ugList.ActiveRowScrollRegion.Scroll(Infragistics.Win.UltraWinGrid.RowScrollAction.LineUp)
        ElseIf e.KeyCode = Keys.PageDown Then
            ugList.ActiveRowScrollRegion.Scroll(Infragistics.Win.UltraWinGrid.RowScrollAction.PageDown)
        ElseIf e.KeyCode = Keys.PageUp Then
            ugList.ActiveRowScrollRegion.Scroll(Infragistics.Win.UltraWinGrid.RowScrollAction.PageUp)
        End If
    End Sub

    Private Sub tsbtPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbtPrint.Click
        With ugpdRent
            .Header.TextCenter = printHeader
            .Header.Appearance.FontData.Underline = Infragistics.Win.DefaultableBoolean.True
            .Header.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True
            uppdRent.ShowDialog()
        End With
    End Sub

    Private Sub BooksOnRentToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BooksOnRentToolStripMenuItem.Click
        printHeader = "현재 대출중인 도서 목록"
        ugList.Text = "현재 대출중인 도서 목록"
        m_Common.bookListViewID = 2
        fillGrid(PARTIAL_LIST2, BOOK_STATUS_R)
        resetGrid(False)
    End Sub

    Private Sub BooksAvailableToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BooksAvailableToolStripMenuItem.Click
        printHeader = "대출 가능한 도서 목록"
        ugList.Text = "대출 가능한 도서 목록"
        m_Common.bookListViewID = 2
        fillGrid(PARTIAL_LIST2, BOOK_STATUS_A)
        resetGrid(False)
    End Sub

    Private Sub AllBooksToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AllBooksToolStripMenuItem.Click
        printHeader = "모든 도서 목록"
        ugList.Text = "모든 도서 목록"
        m_Common.bookListViewID = 0
        fillGrid(WHOLE_LIST, "")
        resetGrid(False)
    End Sub

    Private Sub NewBookToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NewBookToolStripMenuItem.Click
        printHeader = "최근에 새로 입력한 도서 목록"
        ugList.Text = "최근에 새로 입력한 도서 목록"
        m_Common.bookListViewID = 3
        fillGrid(PARTIAL_LIST3, "N")
        resetGrid(False)
    End Sub

    Private Sub tsbtBarcode_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbtBarcode.Click
        Dim bookDAL As TKPC.DAL.BookDAL
        Dim barcodePrintDAL As TKPC.DAL.BarcodePrintDAL

        Try
            barcodePrintDAL = TKPC.DAL.BarcodePrintDAL.getInstance()
            barcodePrintDAL.deleteRecord()
            barcodePrintDAL.insertRecord2()

            bookDAL = TKPC.DAL.BookDAL.getInstance()
            Dim bookListForBarcode As ArrayList = bookDAL.getBookListForBarcodes()
            Dim bookList As String = ""
            For i As Integer = 0 To bookListForBarcode.Count - 1
                bookList += bookListForBarcode.Item(i)
                If i <> bookListForBarcode.Count - 1 Then
                    bookList += ","
                End If
            Next

            With frmBarcodeMain
                .barcodeListStr = bookList
                .barcodesList = bookListForBarcode
                openFormDialog(frmBarcodeMain)
            End With

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            barcodePrintDAL = Nothing
            bookDAL = Nothing
        End Try
    End Sub

    Private Sub NewBookListToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NewBookListToolStripMenuItem.Click
        printHeader = "최근에 새로 입력한 도서 목록"
        ugList.Text = "최근에 새로 입력한 도서 목록"
        m_Common.bookListViewID = 3
        fillGrid(PARTIAL_LIST4, "N")

        resetGrid(True)
        tsbtExcel_Click(sender, e)
    End Sub

    Private Sub resetGrid(ByVal flag As Boolean)
        With ugList
            .DisplayLayout.Bands(0).Columns("Barcode ID").Hidden = True
            .DisplayLayout.Bands(0).Columns("Book ID").Hidden = True
            .DisplayLayout.Bands(0).Columns("선택").Width = 40
            .DisplayLayout.Bands(0).Columns("선택").Hidden = flag
            .DisplayLayout.Bands(0).Columns("현재상태").Width = 70
            .DisplayLayout.Bands(0).Columns("현재상태").Hidden = flag
            .DisplayLayout.Bands(0).Columns("대출자").Width = 80
            .DisplayLayout.Bands(0).Columns("대출자").Hidden = flag
            .DisplayLayout.Bands(0).Columns("대출일").Width = 70
            .DisplayLayout.Bands(0).Columns("대출일").Hidden = flag
            .DisplayLayout.Bands(0).Columns("도서명").Width = 350
            .DisplayLayout.Bands(0).Columns("소제목").Width = 60
            .DisplayLayout.Bands(0).Columns("소제목").Hidden = flag
            .DisplayLayout.Bands(0).Columns("저자").Width = 120
            .DisplayLayout.Bands(0).Columns("책 분류명").Width = 90
            .DisplayLayout.Bands(0).Columns("책 분류명").Hidden = flag
            .DisplayLayout.Bands(0).Columns("출판사").Width = 120
            .DisplayLayout.Bands(0).Columns("출판사").Hidden = flag
            .DisplayLayout.Bands(0).Columns("바코드").Width = 100
            .DisplayLayout.Bands(0).Columns("바코드").Hidden = flag
            .DisplayLayout.Bands(0).Columns("구매가격").Hidden = True
            .DisplayLayout.Bands(0).Columns("구매/기증일").Width = 80
            .DisplayLayout.Bands(0).Columns("구매/기증일").Hidden = True
            .DisplayLayout.Bands(0).Columns("구매/기증").Width = 35
            .DisplayLayout.Bands(0).Columns("구매/기증").Hidden = True
            .DisplayLayout.Bands(0).Columns("구매/기증 경로").Width = 100
            .DisplayLayout.Bands(0).Columns("구매/기증 경로").Hidden = True
            .DisplayLayout.Bands(0).Columns("비고").Width = 250
            .DisplayLayout.Bands(0).Columns("비고").Hidden = True
            .DisplayLayout.Bands(0).Columns("데이터 저장일").Width = 80
            .DisplayLayout.Bands(0).Columns("데이터 저장일").Hidden = True
            .DisplayLayout.Bands(0).Columns("Book Type ID").Hidden = True
        End With
    End Sub

    Private Sub tsbtReset_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbtReset.Click
        Dim response As MsgBoxResult = MsgBox("Are you sure you want to reset all the checked record?", MsgBoxStyle.OkCancel, "Reset Confirmation")
        If response = MsgBoxResult.Ok Then
            BookListLoadedFlag = False
            Dim bookDAL As TKPC.DAL.BookDAL = Nothing
            Try
                bookDAL = TKPC.DAL.BookDAL.getInstance()
                bookDAL.updateBookFlags(1, "")
            Catch ex As Exception
            Finally
                bookDAL = Nothing
                tsbtRefresh_Click(sender, e)
                tsbtReset.Enabled = False
            End Try
        End If
    End Sub

    Private Sub tsbtDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbtDelete.Click
        Dim response As MsgBoxResult = MsgBox("Are you sure you want to delete the record?", MsgBoxStyle.YesNo, "Delete Confirmation")
        If response = MsgBoxResult.Yes Then
            'Dim bookDAL As TKPC.DAL.BookDAL
            'Try
            '    bookDAL = TKPC.DAL.BookDAL.getInstance()
            '    Dim bookListForBarcode As ArrayList = bookDAL.getBookListForBarcodes()
            'Catch ex As Exception
            'Finally
            '    bookDAL = Nothing
            'End Try
        End If
    End Sub

    Private Sub BarcodeToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BarcodeToolStripMenuItem.Click
        printHeader = "바코드 찍을 신간 도서 목록"
        ugList.Text = "바코드 찍을 신간 도서 목록"
        m_Common.bookListViewID = 4
        fillGrid(PARTIAL_LIST4, "Y")
        resetGrid(False)
    End Sub
End Class