Imports System.Net.Mail

Public Class frmRentList
    Private totalNumberOfRows As Integer = 0
    Private printHeader As String = "모든 대출 목록"

    Private Sub frmRentList_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        'tsbtRefresh_Click(sender, e)
    End Sub

    Private Sub frmRentList_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        RentListLoadedFlag = False
    End Sub

    Private Sub frmRentList_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Show()
        fillGrid(8, "")
        RentListLoadedFlag = True
        printHeader = "오늘 대출/반납한 도서 목록"
        ugList.Text = "오늘 대출/반납한 도서 목록"
    End Sub
    Private Sub fillGrid(ByVal flag As Integer, ByVal searchWord As String)
        Dim rentBookDAL As TKPC.DAL.RentBookDAL = TKPC.DAL.RentBookDAL.getInstance()
        Dim ds As DataSet
        Dim bs As BindingSource
        totalNumberOfRows = 0

        Try
            ds = rentBookDAL.getRentBookList2(flag, searchWord)

            If ds IsNot Nothing Then
                bs = New BindingSource
                bs.DataSource = ds.Tables(0)

                totalNumberOfRows = ds.Tables(0).Rows.Count

                If totalNumberOfRows > 0 Then
                    MDITKPC.tspbMDI.Maximum = ds.Tables(0).Rows.Count
                    MDITKPC.tspbMDI.Visible = True
                End If

                bnList.BindingSource = bs

                With ugList
                    .DisplayLayout.Bands(0).Columns("Rent Book ID").Hidden = True
                    .DisplayLayout.Bands(0).Columns("Book ID").Hidden = True
                    .DisplayLayout.Bands(0).Columns("Person ID").Hidden = True
                    .DisplayLayout.Bands(0).Columns("Barcode ID").Hidden = True
                    .DisplayLayout.Bands(0).Columns("대출일").Width = 80
                    .DisplayLayout.Bands(0).Columns("전화번호").Width = 100
                    .DisplayLayout.Bands(0).Columns("반납일").Width = 80
                    .DisplayLayout.Bands(0).Columns("선택").Hidden = True
                    .DisplayLayout.Bands(0).Columns("바코드").Width = 80
                    .DisplayLayout.Bands(0).Columns("대출자").Width = 60
                    .DisplayLayout.Bands(0).Columns("도서명").Width = 300
                    .DisplayLayout.Bands(0).Columns("저자").Width = 100
                    .DisplayLayout.Bands(0).Columns("출판사").Width = 100
                    .DisplayLayout.Bands(0).Columns("책 분류명").Width = 100
                    .DisplayLayout.Bands(0).Columns("소제목").Width = 80
                    .DisplayLayout.Bands(0).Columns("분실여부").Width = 40
                    .DisplayLayout.Bands(0).Columns("벌금").Width = 60
                    .DisplayLayout.Override.RowAppearance.TextVAlign = Infragistics.Win.VAlign.Middle
                    .DataSource = bs
                End With
                tsbtExcel.Enabled = True
            Else
                tsbtExcel.Enabled = False
            End If
        Catch ex As Exception
        Finally
            ds = Nothing
            rentBookDAL = Nothing
            bs = Nothing
        End Try
    End Sub

    Private Sub tsbtExcel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles tsbtExcel.Click
        Cursor.Current = Cursors.WaitCursor
        Try
            Dim theFile As String = Application.StartupPath + "\\" + RENT_LIST_EXCEL
            Me.ugExcel.Export(Me.ugList, theFile)
            Process.Start(theFile)

        Catch ex As Exception
            MessageBox.Show(ex.Message + " If the file called " + RENT_LIST_EXCEL + " is open, please close it and try again.")
        Finally
            Cursor.Current = Cursors.Default
        End Try
    End Sub

    Private Sub btnExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExit.Click
        closeForm(Me)
    End Sub

    Private Sub tsbtAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbtAdd.Click
        frmRentAdd.viewMode = VIEW_MODE_ADD_NEW
        openForm(Me, frmRentAdd)
    End Sub

    Public Sub tsbtRefresh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbtRefresh.Click
        fillGrid(-1, "")
        ugList.Text = "모든 대출 목록"
        setReturnDateColumnVisible(False)
    End Sub

    Private Sub ugList_DoubleClickCell(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinGrid.DoubleClickCellEventArgs) Handles ugList.DoubleClickCell
        If e.Cell.Column.Header.Caption = "도서명" Or e.Cell.Column.Header.Caption = "저자" Or e.Cell.Column.Header.Caption = "출판사" Then
            Dim bookID As String = e.Cell.Row.Cells("Book ID").Value
            Dim bookEnt As TKPC.Entity.BookEnt = New TKPC.Entity.BookEnt
            Dim bookDAL As TKPC.DAL.BookDAL = TKPC.DAL.BookDAL.getInstance()

            Try
                bookEnt = bookDAL.getRecordByID(bookID)

                With frmBookAdd
                    .bookEnt = bookEnt
                    .viewMode = VIEW_MODE_DETAIL
                    openForm(Me, frmBookAdd)
                End With
            Catch exx As Exception
                MessageBox.Show("Error at DoubleClickCell of book " + exx.Message)
            Finally
                bookEnt = Nothing
                bookDAL = Nothing
            End Try

        ElseIf e.Cell.Column.Header.Caption = "대출자" Or e.Cell.Column.Header.Caption = "이메일" Or e.Cell.Column.Header.Caption = "집 전화번호" Then
            Dim personID As String = e.Cell.Row.Cells("Person ID").Value
            Dim personEnt As TKPC.Entity.PersonEnt = New TKPC.Entity.PersonEnt
            Dim personDAL As TKPC.DAL.PersonDAL = TKPC.DAL.PersonDAL.getInstance()

            Try
                personEnt = personDAL.getRecordByID(personID)

                With frmPersonAdd
                    .personEnt = personEnt
                    .viewMode = VIEW_MODE_DETAIL
                    openForm(Me, frmPersonAdd)
                End With
            Catch ex As Exception
                MessageBox.Show("Error at DoubleClickCell of person " + ex.Message)
            Finally
                personEnt = Nothing
                personDAL = Nothing
            End Try
        End If
    End Sub

    Private Sub ugList_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles ugList.Enter
        If whichIME = 0 Then
            whichIME = SwitchIME(hKrLayoutId, KbdKr)
        End If
    End Sub

    Private Sub ugList_InitializeLayout(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles ugList.InitializeLayout
        ugList.DisplayLayout.Override.AllowUpdate = Infragistics.Win.DefaultableBoolean.False
    End Sub
    Private Sub ugList_InitializeRow(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinGrid.InitializeRowEventArgs) Handles ugList.InitializeRow
        If totalNumberOfRows > 0 Then
            MDITKPC.tspbMDI.Value += 1

            If MDITKPC.tspbMDI.Value = totalNumberOfRows Then
                MDITKPC.tspbMDI.Visible = False
                MDITKPC.tspbMDI.Value = 0
                totalNumberOfRows = 0
            End If

            If printHeader = "모든 대출 목록" Then
                If e.Row.Cells("반납일").Text = String.Empty Then
                    e.Row.CellAppearance.BackColor = Color.LightSkyBlue
                End If
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
        ugpdRent.Header.TextCenter = printHeader
        ugpdRent.Header.Appearance.FontData.Underline = Infragistics.Win.DefaultableBoolean.True
        ugpdRent.Header.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True
        uppdRent.ShowDialog()
    End Sub

    Private Sub BooksOnRentToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BooksOnRentToolStripMenuItem.Click
        fillGrid(6, "")
        printHeader = "반납 기간 (3주)이 지난 대출 목록"
        ugList.Text = "반납 기간 (3주)이 지난 대출 목록"
        If totalNumberOfRows > 0 Then
            tsbtEmail.Visible = True
        Else
            tsbtEmail.Visible = False
        End If
        setReturnDateColumnVisible(True)
    End Sub

    Private Sub AllBooksToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AllBooksToolStripMenuItem1.Click
        tsbtEmail.Visible = False
        printHeader = "모든 대출 목록"
        ugList.Text = "모든 대출 목록"
        fillGrid(-1, "")
        setReturnDateColumnVisible(False)
    End Sub

    Private Sub BooksToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BooksToolStripMenuItem.Click
        tsbtEmail.Visible = False
        printHeader = "반납 기간이 아직 지나지 않은 대출 목록"
        ugList.Text = "반납 기간이 아직 지나지 않은 대출 목록"
        fillGrid(7, "")
        setReturnDateColumnVisible(True)
    End Sub

    Private Sub AllBooksToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AllBooksToolStripMenuItem.Click
        tsbtEmail.Visible = False
        printHeader = "반납 완료 대출 목록"
        ugList.Text = "반납 완료 대출 목록"
        fillGrid(5, "")
        setReturnDateColumnVisible(False)
    End Sub

    Private Sub OneWeekAgoRentToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OneWeekAgoRentToolStripMenuItem.Click
        tsbtEmail.Visible = False
        printHeader = "미반납 도서 목록"
        ugList.Text = "미반납 도서 목록"
        fillGrid(4, "")
        setReturnDateColumnVisible(True)
    End Sub

    Private Sub tsbtEmail_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbtEmail.Click
        Dim mail As New MailMessage()

        Try        
            'set the addresses
            mail.From = New MailAddress("hylee1201@hanmail.net")
            mail.To.Add("hylee1201@hanmail.net")

            'set the content
            mail.Subject = "This is an email"
            mail.Body = "this is a sample body"

            'send the message
            Dim smtp As New SmtpClient("smtp.broadband.rogers.com") 'smtp.broadband.rogers.com"
            With smtp
                .Host = "smtp.broadband.rogers.com"
                .UseDefaultCredentials = False
                .DeliveryMethod = SmtpDeliveryMethod.PickupDirectoryFromIis
                .Send(mail)
            End With

            MessageBox.Show("Email has been successfully sent.")

        Catch exception As Exception
            MessageBox.Show(exception.Message)
        Finally
        End Try
    End Sub

    Private Sub 오늘대출한도서목록ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 오늘대출한도서목록ToolStripMenuItem.Click
        tsbtEmail.Visible = False
        printHeader = "오늘 대출/반납한 도서 목록"
        ugList.Text = "오늘 대출/반납한 도서 목록"
        fillGrid(8, "")
        setReturnDateColumnVisible(False)
    End Sub

    Private Sub setReturnDateColumnVisible(ByVal flag As Boolean)
        With ugList
            .DisplayLayout.Bands(0).Columns("반납일").Hidden = flag
        End With
    End Sub
End Class