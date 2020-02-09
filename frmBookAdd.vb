Imports System.Text.RegularExpressions
Imports Infragistics.Win.UltraWinGrid

Public Class frmBookAdd
    Public viewMode As Integer
    Public bookEnt As TKPC.Entity.BookEnt
    Public callingForm As frmBookList
    Private closingMode As Boolean = False
    Public fromWhichForm As Integer
    Public keyPressedName As Integer = 0
    Private emptyDS As DataSet
    Private addDate As String = ""

    Private Function setEntityValue() As TKPC.Entity.BookEnt
        setEntityValue = New TKPC.Entity.BookEnt

        setEntityValue.bookID = lblID.Text
        setEntityValue.title = txtTitle.Text
        setEntityValue.subtitle = txtSubtitle.Text
        setEntityValue.author = txtAuthor.Text
        setEntityValue.publisher = txtPublisher.Text
        setEntityValue.bookTypeID = cbType.SelectedValue
        setEntityValue.bookType = cbType.Text
        setEntityValue.note = txtNote.Text
        setEntityValue.lastUpdateDate = Today.Date
        If viewMode = VIEW_MODE_ADD_NEW Or viewMode = VIEW_MODE_DUPLICATE Then
            setEntityValue.addDate = Today.Date
        End If
        setEntityValue.ISBN = txtISBN.Text
        setEntityValue.compiler = txtCompiler.Text
    End Function

    Private Sub frmBookAdd_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        If fromWhichForm <> FROM_RENT_ADD Then
            setPanelMenuEnabled(True, True)
        End If
        bookEnt = Nothing
        emptyDS = Nothing
        Dispose()
    End Sub

    Private Sub frmBookAdd_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        If compareFields() <> "" Then
            Dim theMsg As String = String.Empty
            If compareFields.Trim.EndsWith(",") Then
                theMsg = compareFields.Substring(0, compareFields.Length - 2)
            End If

            Dim response As MsgBoxResult = MsgBox("The following fields have been changed without saving. " + vbNewLine & _
                                                  theMsg + vbNewLine & _
                                                  "Do you want to save them first?", MsgBoxStyle.YesNoCancel, "Confirmation before Closing")
            If response = MsgBoxResult.Yes Then
                closingMode = True
                tsbtSave_Click(sender, e)
                e.Cancel = False

            ElseIf response = MsgBoxResult.Cancel Then
                e.Cancel = True

            Else
                e.Cancel = False
            End If
        End If
    End Sub
    Private Function compareFields() As String
        compareFields = String.Empty

        If viewMode = VIEW_MODE_DETAIL Then
            If txtTitle.Text.Trim.ToUpper <> bookEnt.title.Trim.ToUpper Then
                compareFields += "책 제목, "
            End If

            If txtSubtitle.Text.Trim.ToUpper <> bookEnt.subtitle.Trim.ToUpper Then
                compareFields += "소제목, "
            End If

            If txtAuthor.Text.Trim.ToUpper <> bookEnt.author.Trim.ToUpper Then
                compareFields += "저자, "
            End If

            If txtCompiler.Text.Trim.ToUpper <> bookEnt.compiler.Trim.ToUpper Then
                compareFields += "엮은이, "
            End If

            If txtPublisher.Text.Trim.ToUpper <> bookEnt.publisher.Trim.ToUpper Then
                compareFields += "출판사, "
            End If

            If cbType.SelectedValue <> bookEnt.bookTypeID Then
                compareFields += "분류, "
            End If

            If txtNote.Text.Trim.ToUpper <> bookEnt.note.Trim.ToUpper Then
                compareFields += "비고, "
            End If

            If txtISBN.Text.Trim <> bookEnt.ISBN.Trim Then
                compareFields += "ISBN, "
            End If
        Else
            If txtTitle.Text.Trim <> String.Empty And txtAuthor.Text.Trim <> String.Empty Then
                If txtTitle.Text.Trim <> String.Empty Then
                    compareFields += "책 제목 "
                End If

                If txtSubtitle.Text.Trim <> String.Empty Then
                    compareFields += "소제목, "
                End If

                If txtAuthor.Text.Trim <> String.Empty Then
                    compareFields += "저자, "
                End If

                If txtCompiler.Text.Trim <> String.Empty Then
                    compareFields += "엮은이, "
                End If

                If txtPublisher.Text.Trim <> String.Empty Then
                    compareFields += "출판사, "
                End If

                If txtNote.Text.Trim <> String.Empty Then
                    compareFields += "비고, "
                End If

                If txtISBN.Text.Trim <> String.Empty Then
                    compareFields += "ISBN, "
                End If
            End If
        End If
    End Function

    Private Sub frmBookAdd2_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Show()
        m_Common.setCombo(cbType)
        init()
        'setPanelMenuEnabled(False, False)
    End Sub
    Private Sub init()
        'Dim onPaste As New c_TextOnPaste(Me.txtPrice)
        If viewMode = VIEW_MODE_DETAIL Then
            enableControls(True)
            setValuesToControls()
            populateDetailGrid()
        ElseIf viewMode = VIEW_MODE_ADD_NEW Then
            enableControls(False)
            If emptyDS IsNot Nothing Then
                ugDetail.DataSource = emptyDS.Tables(0)
            Else
                populateDetailGrid()
            End If
            txtISBN.Focus()
        ElseIf viewMode = VIEW_MODE_DUPLICATE Then
            enableControls(False)
            txtISBN.Focus()
            setValuesToControls()
            populateDetailGrid()
        End If
        cbFind.SelectedIndex = 0
    End Sub

    Private Sub enableControls(ByVal flag As Boolean)
        tsbtDelete.Enabled = flag
        tsbtDuplicate.Enabled = flag
        tsbtHistory.Enabled = flag
        btAdd.Enabled = flag
        tsbtReserve.Enabled = flag
    End Sub

    Private Sub setValuesToControls()
        If viewMode = VIEW_MODE_DETAIL Then
            lblID.Text = bookEnt.bookID
            txtISBN.Text = bookEnt.ISBN
            txtUpdateDate.Text = bookEnt.lastUpdateDate
            If bookEnt.addDate <> String.Empty And bookEnt.addDate <> "" Then
                txtAddDate.Text = bookEnt.addDate
            Else
                txtAddDate.Text = addDate
            End If
        End If

        txtTitle.Text = bookEnt.title
        txtSubtitle.Text = bookEnt.subtitle
        cbType.SelectedValue = bookEnt.bookTypeID
        txtAuthor.Text = bookEnt.author
        txtCompiler.Text = bookEnt.compiler
        txtPublisher.Text = bookEnt.publisher
        txtNote.Text = bookEnt.note
    End Sub

    Private Sub txtTitle_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtTitle.GotFocus
        HighlightControl(txtTitle)
        If whichIME = 0 Then
            whichIME = SwitchIME(hKrLayoutId, KbdKr)
        End If
        ugPublisher.Visible = False
        ugAuthor.Visible = False
        ugISBN.Visible = False
    End Sub

    Private Sub txtTitle_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtTitle.KeyDown
        If e.KeyCode = Keys.Tab Then
            txtSubtitle.Focus()
        ElseIf e.KeyCode = Keys.Down Then
            If ugTitle.Visible = True Then
                ugTitle.Focus()
                ugTitle.Rows(0).Selected = True
            End If
        Else
            keyPressedName = 1
        End If
    End Sub

    Private Sub txtTitle_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtTitle.KeyUp
        If keyPressedName = 1 Then
            If e.KeyCode = Keys.Escape Then
                ugTitle.DataSource = Nothing
                makeGridVisible(False)
            Else
                populateDropdown()
            End If
        Else
            ugTitle.DataSource = Nothing
            makeGridVisible(False)
        End If
    End Sub

    Private Sub txtTitle_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtTitle.LostFocus
        UnHighlightControl(txtTitle)
        keyPressedName = 0
    End Sub

    Private Sub btnExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExit.Click
        Me.Close()
    End Sub

    Private Sub populateDropdown()
        Dim bookDAL As TKPC.DAL.BookDAL = TKPC.DAL.BookDAL.getInstance()
        Dim searchWords As String = String.Empty
        Dim ds As DataSet

        Try
            If txtTitle.Text.Trim <> "" Then
                searchWords = txtTitle.Text.ToUpper
                ds = bookDAL.getListByTitle(searchWords)

                If ds.Tables(0).Rows.Count = 0 Then
                    makeGridVisible(False)
                    ugTitle.DataSource = Nothing
                Else
                    With ugTitle
                        .Visible = True
                        .DataSource = ds.Tables(0)
                        .DisplayLayout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.ResizeAllColumns
                        .DisplayLayout.Bands(0).Columns("Book ID").Hidden = True
                        .DisplayLayout.Bands(0).Columns("Barcode ID").Hidden = True
                        .DisplayLayout.Bands(0).Columns("ISBN").Hidden = True
                        .DisplayLayout.Bands(0).Columns("선택").Hidden = True
                        .DisplayLayout.Bands(0).Columns("현재상태").Hidden = True
                        .DisplayLayout.Bands(0).Columns("소제목").Hidden = True
                        .DisplayLayout.Bands(0).Columns("바코드").Width = 55
                        .DisplayLayout.Bands(0).Columns("바코드").CellActivation = Activation.NoEdit
                        .DisplayLayout.Bands(0).Columns("도서명").Width = 160
                        .DisplayLayout.Bands(0).Columns("도서명").CellActivation = Activation.NoEdit
                        .DisplayLayout.Bands(0).Columns("책 분류명").Width = 65
                        .DisplayLayout.Bands(0).Columns("책 분류명").CellActivation = Activation.NoEdit
                        .DisplayLayout.Bands(0).Columns("저자").Width = 60
                        .DisplayLayout.Bands(0).Columns("저자").CellActivation = Activation.NoEdit
                        .DisplayLayout.Bands(0).Columns("출판사").Width = 60
                        .DisplayLayout.Bands(0).Columns("출판사").CellActivation = Activation.NoEdit
                        .DisplayLayout.Bands(0).Columns("비고").Hidden = True
                        .DisplayLayout.Bands(0).Columns("구매/기증").Hidden = True
                        .DisplayLayout.Bands(0).Columns("구매/기증일").Hidden = True
                        .DisplayLayout.Bands(0).Columns("구매/기증 경로").Hidden = True
                        .DisplayLayout.Bands(0).Columns("저장일").Hidden = False
                        .DisplayLayout.Bands(0).Columns("저장일").Width = 60
                        .DisplayLayout.Bands(0).Columns("Book Type ID").Hidden = True
                        .DisplayLayout.Bands(0).Columns("구매가격").Hidden = True
                        .DisplayLayout.Bands(0).Columns("비고").Hidden = True
                        .DisplayLayout.Bands(0).Columns("대출자").Hidden = True
                        .DisplayLayout.Bands(0).Columns("대출일").Hidden = True
                        .DisplayLayout.Bands(0).Columns("엮은이").Hidden = True
                        .DisplayLayout.Bands(0).Columns("생성일").Hidden = True
                    End With
                End If
            Else
                makeGridVisible(False)
                ugTitle.DataSource = Nothing
            End If

        Catch ex As Exception
            MessageBox.Show("Error at populateDropdown() : " + ex.Message())
        Finally
            bookDAL = Nothing
            ds = Nothing
        End Try
    End Sub
    Private Sub populateISBNDropdown()
        Dim bookDAL As TKPC.DAL.BookDAL = TKPC.DAL.BookDAL.getInstance()
        Dim searchWords As String = String.Empty
        Dim ds As DataSet

        Try
            If txtISBN.Text.Trim <> "" Then
                searchWords = txtISBN.Text.ToUpper
                ds = bookDAL.getListByISBN(searchWords)

                If ds.Tables(0).Rows.Count = 0 Then
                    makeGridVisible(False)
                    ugISBN.DataSource = Nothing
                Else
                    With ugISBN
                        .Visible = True
                        .DataSource = ds.Tables(0)
                        .DisplayLayout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.ResizeAllColumns
                        .DisplayLayout.Bands(0).Columns("Book ID").Hidden = True
                        .DisplayLayout.Bands(0).Columns("Barcode ID").Hidden = True
                        .DisplayLayout.Bands(0).Columns("ISBN").Width = 90
                        .DisplayLayout.Bands(0).Columns("ISBN").CellActivation = Activation.NoEdit
                        .DisplayLayout.Bands(0).Columns("선택").Hidden = True
                        .DisplayLayout.Bands(0).Columns("현재상태").Hidden = True
                        .DisplayLayout.Bands(0).Columns("소제목").Hidden = True
                        .DisplayLayout.Bands(0).Columns("바코드").Hidden = True
                        .DisplayLayout.Bands(0).Columns("도서명").Width = 200
                        .DisplayLayout.Bands(0).Columns("도서명").CellActivation = Activation.NoEdit
                        .DisplayLayout.Bands(0).Columns("책 분류명").Hidden = True
                        .DisplayLayout.Bands(0).Columns("저자").Width = 80
                        .DisplayLayout.Bands(0).Columns("저자").CellActivation = Activation.NoEdit
                        .DisplayLayout.Bands(0).Columns("출판사").Hidden = True
                        .DisplayLayout.Bands(0).Columns("비고").Hidden = True
                        .DisplayLayout.Bands(0).Columns("구매/기증").Hidden = True
                        .DisplayLayout.Bands(0).Columns("구매/기증일").Hidden = True
                        .DisplayLayout.Bands(0).Columns("구매/기증 경로").Hidden = True
                        .DisplayLayout.Bands(0).Columns("저장일").Hidden = True
                        .DisplayLayout.Bands(0).Columns("Book Type ID").Hidden = True
                        .DisplayLayout.Bands(0).Columns("구매가격").Hidden = True
                        .DisplayLayout.Bands(0).Columns("비고").Hidden = True
                        .DisplayLayout.Bands(0).Columns("대출자").Hidden = True
                        .DisplayLayout.Bands(0).Columns("대출일").Hidden = True
                        .DisplayLayout.Bands(0).Columns("엮은이").Hidden = True
                        .DisplayLayout.Bands(0).Columns("생성일").Hidden = False
                        .DisplayLayout.Bands(0).Columns("생성일").Width = 70
                    End With
                End If
            Else
                makeGridVisible(False)
                ugISBN.DataSource = Nothing
            End If

        Catch ex As Exception
            MessageBox.Show("Error at populateISBNDropdown() : " + ex.Message())
        Finally
            bookDAL = Nothing
            ds = Nothing
        End Try
    End Sub
    Public Sub populateDetailGrid()
        Dim bookDAL As TKPC.DAL.BookDAL = TKPC.DAL.BookDAL.getInstance()
        Dim ds As DataSet
        Dim bookID As String = lblID.Text
        If lblID.Text = "ID" Then
            bookID = "0"
        End If

        Try
            ds = bookDAL.getBookBarcodeList(bookID)

            If bookID = "0" Then
                emptyDS = ds
            End If

            With ugDetail
                .DataSource = ds.Tables(0)
                .DisplayLayout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.ResizeAllColumns
                '.DisplayLayout.Bands(0).Columns("선택").Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Button
                .DisplayLayout.Bands(0).Columns("선택").Hidden = True
                .DisplayLayout.Bands(0).Columns("Barcode ID").Hidden = True
                .DisplayLayout.Bands(0).Columns("바코드").Width = 85
                .DisplayLayout.Bands(0).Columns("현재상태").Width = 90
                .DisplayLayout.Bands(0).Columns("대출자").Width = 85
                .DisplayLayout.Bands(0).Columns("대출일").Width = 75
                .DisplayLayout.Bands(0).Columns("Book ID").Width = 60
                .DisplayLayout.Bands(0).Columns("Book ID").Hidden = True
                .DisplayLayout.Bands(0).Columns("Person ID").Hidden = True
                .DisplayLayout.Bands(0).Columns("구매/기증").Hidden = True
                .DisplayLayout.Bands(0).Columns("등록일").Hidden = False
                .DisplayLayout.Bands(0).Columns("등록일").Width = 75
                .DisplayLayout.Bands(0).Columns("구매/기증 출처").Hidden = True
                .DisplayLayout.Bands(0).Columns("비고").Width = 135
                .DisplayLayout.Bands(0).Columns("저장일").Width = 75
                .DisplayLayout.Bands(0).Columns("저장일").Hidden = True
                .DisplayLayout.Bands(0).Columns("구매가격").Hidden = True
            End With

        Catch ex As Exception
            MessageBox.Show("Error at populateDetailGrid() : " + ex.Message())
        Finally
            bookDAL = Nothing
            ds = Nothing
        End Try
    End Sub

    Public Sub makeGridVisible(ByVal flag)
        ugPublisher.Visible = flag
        ugTitle.Visible = flag
        ugISBN.Visible = flag
        ugAuthor.Visible = flag
    End Sub

    Private Sub txtSubtitle_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtSubtitle.GotFocus
        'SwitchIME(hKrLayoutId, KbdKr)
        makeGridVisible(False)
        HighlightControl(txtSubtitle)
    End Sub

    Private Sub txtSubtitle_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtSubtitle.KeyDown
        If e.KeyCode = Keys.Tab Then
            txtAuthor.Focus()
        End If
    End Sub

    Private Sub txtSubtitle_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtSubtitle.LostFocus
        UnHighlightControl(txtSubtitle)
    End Sub

    Private Sub txtAuthor_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtAuthor.GotFocus
        'SwitchIME(hKrLayoutId, KbdKr)
        HighlightControl(txtAuthor)
        ugTitle.Visible = False
        ugPublisher.Visible = False
        ugISBN.Visible = False
    End Sub

    Private Sub txtAuthor_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtAuthor.KeyDown
        If e.KeyCode = Keys.Tab Then
            btView.Focus()
        ElseIf e.KeyCode = Keys.Down Then
            If ugAuthor.Visible = True Then
                ugAuthor.Focus()
                ugAuthor.Rows(0).Selected = True
            End If
        Else
            keyPressedName = 1
        End If
    End Sub

    Private Sub txtAuthor_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtAuthor.KeyUp
        If keyPressedName = 1 Then
            If e.KeyCode = Keys.Escape Then
                ugAuthor.DataSource = Nothing
                makeGridVisible(False)
            Else
                populateAuthorDropdown()
            End If
        Else
            ugAuthor.DataSource = Nothing
            makeGridVisible(False)
        End If
    End Sub

    Private Sub txtAuthor_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtAuthor.LostFocus
        UnHighlightControl(txtAuthor)
        makeGridVisible(False)
        cbFind.DroppedDown = False
    End Sub

    Private Sub txtPublisher_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtPublisher.GotFocus
        'SwitchIME(hKrLayoutId, KbdKr)
        HighlightControl(txtPublisher)
        'If whichIME = 0 Then
        '    whichIME = SwitchIME(hKrLayoutId, KbdKr)
        'End If
        ugTitle.Visible = False
        ugAuthor.Visible = False
        ugISBN.Visible = False
    End Sub

    Private Sub txtPublisher_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtPublisher.KeyDown
        If e.KeyCode = Keys.Tab Then
            txtNote.Focus()

        ElseIf e.KeyCode = Keys.Down Then
            If ugPublisher.Visible = True Then
                ugPublisher.Focus()
                ugPublisher.Rows(0).Selected = True
                txtPublisher.Text = ugPublisher.ActiveRow.Cells(0).Text
            End If
        End If
    End Sub

    Private Sub txtPublisher_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtPublisher.KeyUp
        If txtPublisher.Text <> "" Then
            If e.KeyCode <> Keys.Tab And e.KeyCode <> Keys.Down And e.KeyCode <> Keys.Escape Then
                populatePublisherDropdown()
            Else
                ugPublisher.DataSource = Nothing
                makeGridVisible(False)
            End If
        Else
            ugPublisher.DataSource = Nothing
            makeGridVisible(False)
        End If
    End Sub

    Private Sub txtPublisher_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtPublisher.LostFocus
        'UnHighlightControl(txtPublisher)
        'If ugPublisher.Visible = True And ugPublisher.Rows.Count >= 1 Then
        '    txtPublisher.Text = ugPublisher.Rows(0).Cells(0).Value
        'End If
    End Sub

    Private Sub txtNote_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtNote.GotFocus
        'SwitchIME(hKrLayoutId, KbdKr)
        HighlightControl(txtNote)
        makeGridVisible(False)
    End Sub

    Private Sub txtNote_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtNote.LostFocus
        UnHighlightControl(txtNote)
    End Sub

    Private Sub populatePublisherDropdown()
        Dim bookDAL As TKPC.DAL.BookDAL = TKPC.DAL.BookDAL.getInstance()
        Dim searchWords As String = String.Empty
        Dim ds As DataSet = Nothing

        Try
            If txtPublisher.Text.Trim <> "" Then
                searchWords = txtPublisher.Text + "%"
                ds = bookDAL.getPublisherList(searchWords)

                If ds.Tables(0).Rows.Count = 0 Then
                    makeGridVisible(False)
                    ugPublisher.DataSource = Nothing
                Else
                    With ugPublisher
                        .DataSource = ds.Tables(0)
                        .DisplayLayout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.ResizeAllColumns
                        .DisplayLayout.Bands(0).ColHeadersVisible = False
                        .DisplayLayout.Bands(0).Columns(0).CellActivation = Activation.NoEdit
                        .DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.False
                        .Visible = True
                    End With
                End If
            Else
                makeGridVisible(False)
                ugPublisher.DataSource = Nothing
            End If

        Catch ex As Exception
            MessageBox.Show("Error at populatePublisherDropdown() : " + ex.Message())
        Finally
            bookDAL = Nothing
            ds = Nothing
        End Try
    End Sub
    Private Function populateAuthorDropdown() As Integer
        Dim bookDAL As TKPC.DAL.BookDAL = TKPC.DAL.BookDAL.getInstance()
        Dim searchWords As String = String.Empty
        Dim ds As DataSet = Nothing
        populateAuthorDropdown = 0

        Try
            If txtAuthor.Text.Trim <> "" Then
                Dim authors As String() = txtAuthor.Text.Split(",")
                For i As Integer = 0 To authors.Length - 1
                    searchWords += authors(0)
                    If i <> authors.Length - 1 Then
                        searchWords += ","
                    End If
                Next
                ds = bookDAL.getAuthorBookList(searchWords)

                If ds.Tables(0).Rows.Count = 0 Then
                    makeGridVisible(False)
                    ugAuthor.DataSource = Nothing
                Else
                    With ugAuthor
                        .Visible = True
                        .DataSource = ds.Tables(0)
                        .DisplayLayout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.ResizeAllColumns
                        .DisplayLayout.Bands(0).Columns("Book ID").Hidden = True
                        .DisplayLayout.Bands(0).Columns("Barcode ID").Hidden = True
                        .DisplayLayout.Bands(0).Columns("ISBN").Hidden = True
                        .DisplayLayout.Bands(0).Columns("선택").Hidden = True
                        .DisplayLayout.Bands(0).Columns("현재상태").Hidden = True
                        .DisplayLayout.Bands(0).Columns("소제목").Hidden = True
                        .DisplayLayout.Bands(0).Columns("바코드").Width = 55
                        .DisplayLayout.Bands(0).Columns("도서명").Width = 160
                        .DisplayLayout.Bands(0).Columns("책 분류명").Width = 65
                        .DisplayLayout.Bands(0).Columns("저자").Width = 60
                        .DisplayLayout.Bands(0).Columns("출판사").Width = 60
                        .DisplayLayout.Bands(0).Columns("비고").Hidden = True
                        .DisplayLayout.Bands(0).Columns("구매/기증").Hidden = True
                        .DisplayLayout.Bands(0).Columns("구매/기증일").Hidden = True
                        .DisplayLayout.Bands(0).Columns("구매/기증 경로").Hidden = True
                        .DisplayLayout.Bands(0).Columns("저장일").Hidden = False
                        .DisplayLayout.Bands(0).Columns("저장일").Width = 70
                        .DisplayLayout.Bands(0).Columns("Book Type ID").Hidden = True
                        .DisplayLayout.Bands(0).Columns("구매가격").Hidden = True
                        .DisplayLayout.Bands(0).Columns("비고").Hidden = True
                        .DisplayLayout.Bands(0).Columns("대출자").Hidden = True
                        .DisplayLayout.Bands(0).Columns("대출일").Hidden = True
                        .DisplayLayout.Bands(0).Columns("엮은이").Hidden = True
                        .DisplayLayout.Bands(0).Columns("생성일").Hidden = False
                        .DisplayLayout.Bands(0).Columns("생성일").Width = 70
                    End With
                    populateAuthorDropdown = 1
                End If
            Else
                makeGridVisible(False)
                ugAuthor.DataSource = Nothing
            End If

        Catch ex As Exception
            MessageBox.Show("Error at populateAuthorDropdown() : " + ex.Message())
        Finally
            bookDAL = Nothing
            ds = Nothing
        End Try
    End Function
    Private Sub ugTitle_DoubleClickCell(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinGrid.DoubleClickCellEventArgs) Handles ugTitle.DoubleClickCell
        If ugTitle.ActiveRow IsNot Nothing Then
            viewMode = VIEW_MODE_DETAIL
            fillFieldsFromGrid(ugTitle)
            init()
            tsbtDuplicate.Enabled = True
        End If
        ugTitle.Visible = False
        txtSubtitle.Focus()
    End Sub

    Private Sub ugTitle_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles ugTitle.KeyDown
        If e.KeyCode = Keys.Enter Then
            If ugTitle.ActiveRow IsNot Nothing Then
                viewMode = VIEW_MODE_DETAIL
                fillFieldsFromGrid(ugTitle)
                init()
                tsbtDuplicate.Enabled = True
            End If
            ugTitle.Visible = False
            txtSubtitle.Focus()
        ElseIf e.KeyCode = Keys.Escape Then
            ugTitle.Visible = False
            txtSubtitle.Focus()
        End If
    End Sub

    Private Sub fillFieldsFromGrid(ByVal grid As Infragistics.Win.UltraWinGrid.UltraGrid)
        bookEnt = New TKPC.Entity.BookEnt

        With grid.ActiveRow
            bookEnt.bookID = .Cells("Book ID").Value
            If .Cells("ISBN").Value IsNot DBNull.Value Then
                bookEnt.ISBN = .Cells("ISBN").Value
            Else
                bookEnt.ISBN = ""
            End If

            If .Cells("도서명").Value IsNot DBNull.Value Then
                bookEnt.title = .Cells("도서명").Value
            Else
                bookEnt.title = ""
            End If

            If .Cells("소제목").Value IsNot DBNull.Value Then
                bookEnt.subtitle = .Cells("소제목").Value
            Else
                bookEnt.subtitle = ""
            End If

            If .Cells("저자").Value IsNot DBNull.Value Then
                bookEnt.author = .Cells("저자").Value
            Else
                bookEnt.author = ""
            End If

            If .Cells("책 분류명").Value IsNot DBNull.Value Then
                bookEnt.bookType = .Cells("책 분류명").Value
            Else
                bookEnt.bookType = ""
            End If

            If .Cells("출판사").Value IsNot DBNull.Value Then
                bookEnt.publisher = .Cells("출판사").Value
            Else
                bookEnt.publisher = ""
            End If

            If .Cells("비고").Value IsNot DBNull.Value Then
                bookEnt.note = .Cells("비고").Value
            Else
                bookEnt.note = ""
            End If

            If .Cells("저장일").Value IsNot DBNull.Value Then
                bookEnt.lastUpdateDate = .Cells("저장일").Value
            Else
                bookEnt.lastUpdateDate = ""
            End If

            If .Cells("Book Type ID").Value IsNot DBNull.Value Then
                bookEnt.bookTypeID = .Cells("Book Type ID").Value
            Else
                bookEnt.bookTypeID = ""
            End If

            If .Cells("엮은이").Value IsNot DBNull.Value Then
                bookEnt.compiler = .Cells("엮은이").Value
            Else
                bookEnt.compiler = ""
            End If

            If .Cells("생성일").Value IsNot DBNull.Value Then
                bookEnt.addDate = .Cells("생성일").Value
            Else
                bookEnt.addDate = ""
            End If
        End With
    End Sub

    Private Sub cbType_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbType.GotFocus
        ugTitle.Visible = False
        If viewMode = VIEW_MODE_ADD_NEW And cbType.DroppedDown = False Then
            cbType.DroppedDown = True
            ugPublisher.Visible = False
        End If
    End Sub

    'Private Sub lblID_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles lblID.TextChanged
    '    populateDetailGrid()
    'End Sub

    Public Sub btAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btAdd.Click
        frmBookBarcodeAdd.viewMode = VIEW_MODE_ADD_NEW
        openBookBarcodeScreen()
    End Sub

    Public Sub openBookBarcodeScreen()
        With frmBookBarcodeAdd
            .txtTitle.Text = txtTitle.Text
            .lblBookID.Text = lblID.Text
            .BookTypeID = cbType.SelectedValue
            .ShowDialog()
        End With
    End Sub

    Private Sub ugDetail_DoubleClickRow(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinGrid.DoubleClickRowEventArgs) Handles ugDetail.DoubleClickRow
        If e.Row.Index >= 0 Then
            Dim bookBarcodeEnt As TKPC.Entity.BookBarcodeEnt
            If e.Row.Cells("Barcode ID").Value IsNot DBNull.Value Then
                bookBarcodeEnt = New TKPC.Entity.BookBarcodeEnt

                Try
                    bookBarcodeEnt.barcodeID = e.Row.Cells("Barcode ID").Value

                    If e.Row.Cells("구매가격").Value IsNot DBNull.Value Then
                        bookBarcodeEnt.price = e.Row.Cells("구매가격").Value
                    Else
                        bookBarcodeEnt.price = String.Empty
                    End If

                    If e.Row.Cells("Person ID").Value IsNot DBNull.Value Then
                        bookBarcodeEnt.rentPersonID = e.Row.Cells("Person ID").Value
                    Else
                        bookBarcodeEnt.rentPersonID = String.Empty
                    End If

                    If e.Row.Cells("현재상태").Value IsNot DBNull.Value Then
                        bookBarcodeEnt.status = e.Row.Cells("현재상태").Value
                    Else
                        bookBarcodeEnt.status = String.Empty
                    End If

                    If e.Row.Cells("구매/기증").Value IsNot DBNull.Value Then
                        bookBarcodeEnt.purchaseOrDonate = e.Row.Cells("구매/기증").Value
                    Else
                        bookBarcodeEnt.purchaseOrDonate = String.Empty
                    End If

                    If e.Row.Cells("등록일").Value IsNot DBNull.Value Then
                        bookBarcodeEnt.purchaseOrDonateDate = e.Row.Cells("등록일").Value
                    Else
                        bookBarcodeEnt.purchaseOrDonateDate = String.Empty
                    End If

                    If e.Row.Cells("구매/기증 출처").Value IsNot DBNull.Value Then
                        bookBarcodeEnt.purchaseOrDonateSource = e.Row.Cells("구매/기증 출처").Value
                    Else
                        bookBarcodeEnt.purchaseOrDonateSource = String.Empty
                    End If

                    If e.Row.Cells("바코드").Value IsNot DBNull.Value Then
                        bookBarcodeEnt.barcode = e.Row.Cells("바코드").Value
                    Else
                        bookBarcodeEnt.barcode = String.Empty
                    End If

                    If e.Row.Cells("비고").Value IsNot DBNull.Value Then
                        bookBarcodeEnt.note = e.Row.Cells("비고").Value
                    Else
                        bookBarcodeEnt.note = String.Empty
                    End If

                    If e.Row.Cells("저장일").Value IsNot DBNull.Value Then
                        bookBarcodeEnt.lastUpdateDate = e.Row.Cells("저장일").Value
                    Else
                        bookBarcodeEnt.lastUpdateDate = String.Empty
                    End If

                    If e.Row.Cells("Book ID").Value IsNot DBNull.Value Then
                        bookBarcodeEnt.bookID = e.Row.Cells("Book ID").Value
                    Else
                        bookBarcodeEnt.bookID = String.Empty
                    End If

                    makeGridVisible(False)
                    With frmBookBarcodeAdd
                        .viewMode = VIEW_MODE_DETAIL
                        .lblID.Text = bookBarcodeEnt.barcodeID
                        .lblBarcode.Text = bookBarcodeEnt.barcode
                        .BookBarcodeEnt = bookBarcodeEnt
                        openBookBarcodeScreen()
                    End With
                Catch ex As Exception
                    MessageBox.Show("Error at opening barcode detail page..." + ex.Message)
                Finally
                    bookBarcodeEnt = Nothing
                End Try
            End If
        End If
    End Sub

    Public Sub tsbtSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbtSave.Click
        'whichIME = SwitchIME(hEnLayoutId, KbdEn)
        If txtTitle.Text = "" Then
            MessageBox.Show("Please enter a book title.")
            txtTitle.Focus()
            Exit Sub
        End If

        Dim bookDAL As TKPC.DAL.BookDAL

        Try
            Cursor.Current = Cursors.WaitCursor
            bookDAL = TKPC.DAL.BookDAL.getInstance()
            Dim numberOfUpdatedRow As Integer = 0

            If viewMode = VIEW_MODE_ADD_NEW Or viewMode = VIEW_MODE_DUPLICATE Then
                populateISBNDropdown()
                If ugISBN.Visible = True Then
                    MessageBox.Show("The book has been already registered. Please register the barcode only.")
                    Exit Sub
                End If

                If viewMode = VIEW_MODE_DUPLICATE Then
                    populateDropdown()
                    If ugTitle.Visible = True Then
                        Dim response As MsgBoxResult = MsgBox("One of the registered books has the same title." + vbNewLine + "Are you sure you want to register this book as a new book?", MsgBoxStyle.YesNo, "Registration Confirmation")
                        If response = MsgBoxResult.Yes Then
                            numberOfUpdatedRow = bookDAL.insertRecord(setEntityValue())
                        Else
                            bookDAL = Nothing
                            Cursor.Current = Cursors.Default
                            makeGridVisible(False)
                            Exit Sub
                        End If
                    End If
                Else
                    numberOfUpdatedRow = bookDAL.insertRecord(setEntityValue())
                End If
            Else
                numberOfUpdatedRow = bookDAL.updateRecord(setEntityValue())
            End If

            If numberOfUpdatedRow = 1 Then
                If viewMode = VIEW_MODE_ADD_NEW Or viewMode = VIEW_MODE_DUPLICATE Then
                    If lblID.Text = "ID" Then
                        lblID.Text = m_DBUtil.getMaxNumber("Book", "Book ID")
                    End If

                    Dim bookBarcodeEnt As TKPC.Entity.BookBarcodeEnt = New TKPC.Entity.BookBarcodeEnt
                    With bookBarcodeEnt
                        .barcode = m_DBUtil.getBarcode(cbType.SelectedValue, "")
                        .bookID = lblID.Text
                        .status = BOOK_STATUS_A
                        .price = "0"
                        .purchaseOrDonate = BOOK_TYPE_PURCHASE
                        .purchaseOrDonateDate = Today.Date
                        .purchaseOrDonateSource = String.Empty
                        .lastUpdateDate = Today.Date
                        .note = String.Empty
                    End With

                    numberOfUpdatedRow = bookDAL.insertBookBarcodeRecord(bookBarcodeEnt)

                    If numberOfUpdatedRow = 1 Then
                        If txtPublisher.Focused Or cbType.Focused Or txtISBN.Focused Then
                            lblID.Focus()
                        End If

                        MessageBox.Show("Book record has been successfully saved.")
                        viewMode = VIEW_MODE_DETAIL
                        bookEnt = setEntityValue()
                        init()
                        lblMsg.Text = ""

                        If closingMode = False Then
                            Dim message As String = "Do you want to add another book?"
                            Dim Result As DialogResult
                            Dim caption As String = "Add New?"
                            Dim buttons As MessageBoxButtons = MessageBoxButtons.YesNo

                            Result = MessageBox.Show(message, caption, buttons)
                            If Result = System.Windows.Forms.DialogResult.Yes Then
                                resetControls(VIEW_MODE_ADD_NEW)
                                'setPanelMenuEnabled(False, False)
                            Else
                                txtNote.Focus()
                            End If
                        End If
                    Else
                        MessageBox.Show("Book record was not saved. ")  'Delete the book orphan record without a barcode
                        bookDAL.deleteRecordByID(lblID.Text, "", "")
                        resetControls(VIEW_MODE_ADD_NEW)
                    End If
                Else
                    If txtPublisher.Focused Or cbType.Focused Or txtISBN.Focused Then
                        lblID.Focus()
                    End If

                    MessageBox.Show("Book record has been successfully saved.")
                    viewMode = VIEW_MODE_DETAIL
                    bookEnt = setEntityValue()
                    init()
                End If
            Else
                MessageBox.Show("Book record was not saved." + vbNewLine + "Please contact the system administrator.")
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            bookDAL = Nothing
            Cursor.Current = Cursors.Default
            makeGridVisible(False)
            'MDITKPC.utexMDI.Enabled = True
        End Try
    End Sub

    Private Sub resetControls(ByVal resetMode As String)
        If resetMode = VIEW_MODE_ADD_NEW Then
            txtTitle.Text = String.Empty
            txtISBN.Text = String.Empty
            txtSubtitle.Text = String.Empty
            txtAuthor.Text = String.Empty
            txtPublisher.Text = String.Empty
            txtNote.Text = String.Empty
            txtCompiler.Text = String.Empty
            lblID.Text = "ID"
            cbType.SelectedIndex = 0
            viewMode = resetMode
            txtUpdateDate.Text = String.Empty
            txtAddDate.Text = String.Empty
            txtBarcode.Text = String.Empty
            lblMsg.Visible = False
            init()
            makeGridVisible(False)
        Else
            lblID.Text = "ID"
            viewMode = VIEW_MODE_DUPLICATE
            txtUpdateDate.Text = String.Empty
            txtAddDate.Text = String.Empty
            txtBarcode.Text = String.Empty
            lblMsg.Visible = False
            init()
            makeGridVisible(False)
        End If
    End Sub

    Public Sub tsbtAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbtAdd.Click
        resetControls(VIEW_MODE_ADD_NEW)
    End Sub

    Private Sub ugPublisher_DoubleClickCell(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinGrid.DoubleClickCellEventArgs) Handles ugPublisher.DoubleClickCell
        If ugPublisher.ActiveRow IsNot Nothing Then
            txtPublisher.Text = ugPublisher.ActiveRow.Cells(0).Value
            txtNote.Focus()
        End If
        makeGridVisible(False)
    End Sub

    Private Sub ugPublisher_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles ugPublisher.KeyDown
        If e.KeyCode = Keys.Enter Then
            If ugPublisher.ActiveRow IsNot Nothing Then
                txtPublisher.Text = ugPublisher.ActiveRow.Cells(0).Value
                cbType.Focus()
            End If
            makeGridVisible(False)
            'ElseIf e.KeyCode = Keys.Up Or e.KeyCode = Keys.Down Then
            '    If ugPublisher.ActiveRow IsNot Nothing Then
            '        txtPublisher.Text = ugPublisher.ActiveRow.Cells(0).Text
            '    End If
        ElseIf e.KeyCode = Keys.Escape Then
            ugPublisher.Visible = False
            txtNote.Focus()
        End If
    End Sub

    Private Sub cbType_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cbType.KeyDown
        If e.KeyCode = Keys.Enter Then
            txtNote.Focus()
        End If
    End Sub

    Private Sub txtBarcode_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtBarcode.GotFocus
        HighlightControl(txtBarcode)
        If cbFind.SelectedIndex = 1 Then
            If whichIME = 0 Then
                whichIME = SwitchIME(hKrLayoutId, KbdKr)
            End If
        End If
    End Sub

    Private Sub txtBarcode_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtBarcode.KeyDown
        If e.KeyCode = Keys.Tab Then
            txtISBN.Focus()
        ElseIf e.KeyCode = Keys.Enter Then
            If cbFind.SelectedIndex = 1 And txtBarcode.Text <> String.Empty Then
                With frmBookFind
                    .author = txtBarcode.Text
                    .ShowDialog()
                End With
            End If
        End If
    End Sub

    Private Sub txtBarcode_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtBarcode.LostFocus
        UnHighlightControl(txtBarcode)
    End Sub

    Private Sub txtBarcode_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtBarcode.TextChanged
        If cbFind.SelectedIndex = 0 Then
            If (txtBarcode.Text <> String.Empty And Len(txtBarcode.Text) >= 7) Then
                lblMsg.Visible = False
                Dim barcodeNumber As String = txtBarcode.Text
                Dim myMatch As Match = System.Text.RegularExpressions.Regex.Match(txtBarcode.Text, BARCODE_REGEX)
                If myMatch.Success Then
                    Dim bookDAL As TKPC.DAL.BookDAL = TKPC.DAL.BookDAL.getInstance()

                    Try
                        bookEnt = bookDAL.getRecordByBarcode(txtBarcode.Text.Trim)
                        If bookEnt Is Nothing Or bookEnt.bookID = Nothing Then
                            resetControls(VIEW_MODE_ADD_NEW)
                            lblMsg.Text = "The barcode can't be found. Please register the book."
                            lblMsg.Visible = True
                            txtISBN.Focus()
                        Else
                            lblMsg.Text = txtBarcode.Text.Trim
                            lblMsg.Visible = True
                            viewMode = VIEW_MODE_DETAIL
                            init()
                            txtBarcode.Text = ""
                            txtBarcode.Focus()
                        End If
                    Catch ex As Exception
                    Finally
                        bookDAL = Nothing
                    End Try
                    'Else
                    '    resetControls(VIEW_MODE_ADD_NEW)
                    '    lblMsg.Text = "Please enter a valid barcode."
                    '    lblMsg.Visible = True
                    '    txtBarcode.Text = ""
                    '    txtBarcode.Focus()
                End If
            End If
        End If
    End Sub

    Private Sub txtISBN_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtISBN.GotFocus
        HighlightControl(txtISBN)
        ugTitle.Visible = False
        ugAuthor.Visible = False
        ugPublisher.Visible = False
    End Sub

    Private Sub txtISBN_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtISBN.KeyDown
        If e.KeyCode = Keys.Tab Then
            txtTitle.Focus()
        ElseIf e.KeyCode = Keys.Down Then
            If ugISBN.Visible = True Then
                ugISBN.Focus()
                ugISBN.Rows(0).Selected = True
            End If
        Else
            keyPressedName = 1
        End If
    End Sub

    Private Sub txtISBN_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtISBN.KeyUp
        If keyPressedName = 1 Then
            If e.KeyCode = Keys.Escape Then
                ugISBN.DataSource = Nothing
                makeGridVisible(False)
            Else
                populateISBNDropdown()
            End If
        Else
            ugISBN.DataSource = Nothing
            makeGridVisible(False)
        End If
    End Sub

    Private Sub txtISBN_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtISBN.LostFocus
        UnHighlightControl(txtISBN)
    End Sub

    Private Sub tsbtDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbtDelete.Click
        If ugDetail.Rows.Count <= 1 Then
            Dim rentBookDAL As TKPC.DAL.RentBookDAL = TKPC.DAL.RentBookDAL.getInstance
            Dim bookDAL As TKPC.DAL.BookDAL = TKPC.DAL.BookDAL.getInstance

            Try
                If ugDetail.Rows.Count = 1 Then
                    Dim barcode As String = ugDetail.Rows(0).Cells("바코드").Value
                    Dim barcodeID As String = ugDetail.Rows(0).Cells("Barcode ID").Value
                    Dim ds As DataSet = rentBookDAL.getRentBookListByBarcode(0, barcode)
                    If ds.Tables(0).Rows.Count = 0 Or ds Is Nothing Then
                        Dim response As MsgBoxResult = MsgBox("Are you sure you want to delete the record?", MsgBoxStyle.YesNo, "Delete Confirmation")
                        If response = MsgBoxResult.Yes Then
                            Dim deletedRecord As Integer = bookDAL.deleteRecordByID(lblID.Text, barcode, barcodeID)
                            If deletedRecord >= 1 Then
                                MessageBox.Show("The book record has been successfully deleted.")
                                resetControls(VIEW_MODE_ADD_NEW)
                            Else
                                MessageBox.Show("The book record was not deleted.")
                            End If
                        End If
                    Else
                        MessageBox.Show("The barcode information can't be deleted because rent records were made by the barcode.")
                    End If
                Else
                    Dim response As MsgBoxResult = MsgBox("Are you sure you want to delete the record?", MsgBoxStyle.YesNo, "Delete Confirmation")
                    If response = MsgBoxResult.Yes Then
                        Dim deletedRecord As Integer = bookDAL.deleteRecordByID(lblID.Text, "", "")
                        If deletedRecord >= 1 Then
                            MessageBox.Show("The book record has been successfully deleted.")
                            resetControls(VIEW_MODE_ADD_NEW)
                        Else
                            MessageBox.Show("The book record was not deleted.")
                        End If
                    End If
                End If
            Catch ex As Exception
            Finally
                rentBookDAL = Nothing
                bookDAL = Nothing
            End Try
        Else
            MessageBox.Show("To delete the book record, please delete barcodes one by one first.")
        End If
    End Sub

    Private Sub tsbtHistory_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbtHistory.Click
        With frmBookRentHistory
            .flag = 3
            .bookID = lblID.Text
            .ShowDialog()
        End With
    End Sub

    Private Sub ugISBN_DoubleClickCell(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinGrid.DoubleClickCellEventArgs) Handles ugISBN.DoubleClickCell
        If ugISBN.ActiveRow IsNot Nothing Then
            viewMode = VIEW_MODE_DETAIL
            fillFieldsFromGrid(ugISBN)
            init()
            tsbtDuplicate.Enabled = True
        End If
        ugISBN.Visible = False
        txtSubtitle.Focus()
    End Sub

    Private Sub ugISBN_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles ugISBN.KeyDown
        If e.KeyCode = Keys.Enter Then
            If ugISBN.ActiveRow IsNot Nothing Then
                viewMode = VIEW_MODE_DETAIL
                fillFieldsFromGrid(ugISBN)
                init()
                tsbtDuplicate.Enabled = True
            End If
            ugISBN.Visible = False
            txtSubtitle.Focus()
        ElseIf e.KeyCode = Keys.Escape Then
            ugISBN.Visible = False
            txtSubtitle.Focus()
        End If
    End Sub

    Private Sub btView_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btView.Click
        If ugAuthor.Visible = False Then
            If populateAuthorDropdown() = 1 Then
                ugAuthor.Focus()
                ugAuthor.Rows(0).Selected = True
            Else
                MessageBox.Show("Can't find any books written by " + txtAuthor.Text)
            End If
        Else
            ugAuthor.Visible = False
        End If
    End Sub

    Private Sub txtAuthor_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtAuthor.TextChanged
        If txtAuthor.Text <> String.Empty Then
            btView.Enabled = True
        Else
            btView.Enabled = False
        End If
    End Sub

    Private Sub ugAuthor_DoubleClickCell(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinGrid.DoubleClickCellEventArgs) Handles ugAuthor.DoubleClickCell
        If ugAuthor.ActiveRow IsNot Nothing Then
            viewMode = VIEW_MODE_DETAIL
            fillFieldsFromGrid(ugAuthor)
            init()
            tsbtDuplicate.Enabled = True
        End If
        ugAuthor.Visible = False
        txtCompiler.Focus()
    End Sub

    Private Sub ugAuthor_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles ugAuthor.KeyDown
        If e.KeyCode = Keys.Enter Then
            If ugAuthor.ActiveRow IsNot Nothing Then
                viewMode = VIEW_MODE_DETAIL
                fillFieldsFromGrid(ugAuthor)
                init()
                tsbtDuplicate.Enabled = True
            End If
            ugAuthor.Visible = False
            txtCompiler.Focus()
        ElseIf e.KeyCode = Keys.Escape Then
            ugAuthor.Visible = False
            txtCompiler.Focus()
        End If
    End Sub

    Private Sub txtCompiler_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtCompiler.GotFocus
        HighlightControl(txtCompiler)
    End Sub

    Private Sub txtCompiler_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtCompiler.KeyDown
        If e.KeyCode = Keys.Tab Then
            txtPublisher.Focus()
        End If
    End Sub

    Private Sub txtCompiler_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtCompiler.LostFocus
        UnHighlightControl(txtCompiler)
    End Sub

    Private Sub pnMain_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles pnMain.Click
        makeGridVisible(False)
    End Sub

    Private Sub txtAddDate_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtAddDate.TextChanged
        If txtAddDate.Text <> String.Empty Then
            addDate = txtAddDate.Text
        End If
    End Sub

    Private Sub tsbtDuplicate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbtDuplicate.Click
        resetControls(VIEW_MODE_DUPLICATE)
    End Sub

    Private Sub cbFind_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbFind.LostFocus
        cbFind.DroppedDown = False
    End Sub

    Private Sub cbFind_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbFind.SelectedIndexChanged
        txtBarcode.Focus()
    End Sub

    Private Sub tsbtReserve_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbtReserve.Click
        With frmBookReserve
            .flag = 3
            .bookID = lblID.Text
            .bookName = txtTitle.Text
            .ShowDialog()
        End With
    End Sub

    Private Sub lblID_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles lblID.TextChanged
        If viewMode = VIEW_MODE_DETAIL Then
            tsbtReserve.Visible = True
        Else
            tsbtReserve.Visible = False
        End If
    End Sub

    'If viewMode = VIEW_MODE_ADD_NEW Then
    'txtBarcode.Text = m_DBUtil.getBarcode(cbType.SelectedValue, "")

    Private Sub txtISBN_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtISBN.TextChanged
        If viewMode = VIEW_MODE_ADD_NEW Then
            If txtISBN.TextLength = 13 Then
                txtTitle.Focus()
            ElseIf txtISBN.TextLength = 7 Or txtISBN.TextLength = 8 Then
                lblMsg.Visible = False
                Dim barcodeNumber As String = txtBarcode.Text
                Dim myMatch As Match = System.Text.RegularExpressions.Regex.Match(txtISBN.Text, BARCODE_REGEX)
                If myMatch.Success Then
                    Dim bookDAL As TKPC.DAL.BookDAL = TKPC.DAL.BookDAL.getInstance()

                    Try
                        bookEnt = bookDAL.getRecordByBarcode(txtISBN.Text)
                        If bookEnt Is Nothing Or bookEnt.bookID = Nothing Then
                            resetControls(VIEW_MODE_ADD_NEW)
                            lblMsg.Visible = True
                            txtISBN.Text = ""
                            txtISBN.Focus()
                        Else
                            lblMsg.Visible = False
                            viewMode = VIEW_MODE_DETAIL
                            init()
                            txtBarcode.Focus()
                        End If
                    Catch ex As Exception
                    Finally
                        bookDAL = Nothing
                    End Try
                End If
            End If
        End If
    End Sub

    Private Sub ugPublisher_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles ugPublisher.KeyUp
        If e.KeyCode = Keys.Up Or e.KeyCode = Keys.Down Then
            If ugPublisher.ActiveRow IsNot Nothing Then
                txtPublisher.Text = ugPublisher.ActiveRow.Cells(0).Text
            End If
        End If
    End Sub
End Class