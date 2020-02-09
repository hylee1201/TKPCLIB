Imports Infragistics.Win.UltraWinGrid
Imports Infragistics.Win.UltraWinDock
Imports System.Text.RegularExpressions

Public Class frmRentAdd
    Public viewMode As Integer
    Public rentBookEnt As TKPC.Entity.RentBookEnt = Nothing
    Public callingForm As frmRentList
    Private closingMode As Boolean = False
    Private cellChanged As Boolean = False
    Private totalNumberOfRows As Integer = 0
    Public fromWhichForm As Integer = 0
    Private barcodeStorage As Hashtable = New Hashtable()
    Private keyPressedName As Integer = 0
    Private emptyDS As DataSet
    Private rowNumberDeleted As Integer = -1
    Private barcodeList As ArrayList = New ArrayList
    Public personInfoAddedNow As Boolean = False

    Private Function getBookArrayList() As ArrayList
        getBookArrayList = New ArrayList()
        Dim rbEnt As TKPC.Entity.RentBookEnt

        Try
            For i As Integer = 0 To ugRent.Rows.Count - 1
                rbEnt = New TKPC.Entity.RentBookEnt
                If ugRent.Rows(i).Cells("Rent Book ID").Value = "0" Then
                    With rbEnt
                        .rentBookID = ugRent.Rows(i).Cells("Rent Book ID").Value
                        .bookID = ugRent.Rows(i).Cells("Book ID").Value
                        .barcodeID = ugRent.Rows(i).Cells("Barcode ID").Value
                        .barcode = ugRent.Rows(i).Cells("바코드").Value
                        .bookTitle = ugRent.Rows(i).Cells("도서명").Value
                        .bookSubtitle = ugRent.Rows(i).Cells("소제목").Value
                        .bookType = ugRent.Rows(i).Cells("책 분류명").Value
                        .bookAuthor = ugRent.Rows(i).Cells("저자").Value
                        .bookPublisher = ugRent.Rows(i).Cells("출판사").Value
                        If lblPersonID.Text = "" Or lblPersonID.Text = "0" Or lblPersonID.Text = "-1" Then
                            If txtID.Text <> "" And txtID.Text <> "-1" And txtID.Text <> "0" Then
                                .personID = txtID.Text
                            End If
                        Else
                            .personID = lblPersonID.Text
                        End If
                        .lost = False
                        .penalty = 0
                        .returnDate = ""
                        .rentDate = Today.Date
                        .note = ""
                        .lastUpdateDate = Today.Date
                        .flag = 0
                    End With
                    getBookArrayList.Add(rbEnt)
                End If
            Next i
        Catch ex As Exception
        Finally
            rbEnt = Nothing
        End Try

        Return getBookArrayList
    End Function

    Private Sub frmRentAdd_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        fillGrid(1, lblPersonID.Text)
        populateGridWithBarcodes()
        'If whichIME = 0 Then
        '    whichIME = SwitchIME(hKrLayoutId, KbdKr)
        'End If
    End Sub
    Private Sub populateGridWithBarcodes()
        If barcodeStorage IsNot Nothing And barcodeStorage.Count <> 0 Then
            Dim rentBookEnt As TKPC.Entity.RentBookEnt = New TKPC.Entity.RentBookEnt

            Try
                If barcodeList.Count > 0 Then
                    For i As Integer = 0 To barcodeList.Count - 1
                        rentBookEnt = barcodeList(i)
                        Dim addedRow As UltraGridRow = ugRent.DisplayLayout.Bands(0).AddNew()
                        Dim newCells As CellsCollection = addedRow.Cells
                        newCells("선택").Value = rentBookEnt.flag
                        newCells("Rent Book ID").Value = 0
                        newCells("Book ID").Value = rentBookEnt.bookID
                        newCells("Barcode ID").Value = rentBookEnt.barcodeID
                        newCells("Person ID").Value = rentBookEnt.personID
                        newCells("바코드").Value = rentBookEnt.barcode
                        newCells("도서명").Value = rentBookEnt.bookTitle
                        newCells("소제목").Value = rentBookEnt.bookSubtitle
                        newCells("책 분류명").Value = rentBookEnt.bookType
                        newCells("저자").Value = rentBookEnt.bookAuthor
                        newCells("출판사").Value = rentBookEnt.bookPublisher
                        ugRent.Update()
                    Next
                End If
            Catch ex As Exception
            Finally
                rentBookEnt = Nothing
            End Try
        End If
    End Sub

    Private Sub frmRentAdd_Deactivate(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Deactivate
        barcodeList = getBookArrayList()
        If barcodeStorage IsNot Nothing Then
            barcodeStorage.Clear()
        End If
    End Sub

    Private Sub frmRentAdd_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        'setPanelMenuEnabled(True, True)
        rentBookEnt = Nothing
        barcodeStorage = Nothing
        RentAddLoadedFlag = False
        emptyDS = Nothing
        barcodeList = Nothing
    End Sub

    Private Sub frmRentAdd_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        'If Me.bgwRent.IsBusy Then Me.bgwRent.CancelAsync()

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

    Private Sub frmRentAdd_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Dim onPaste As New c_TextOnPaste(txtPeriod)
        Me.Show()
        init()
        'setPanelMenuEnabled(False, True)

        setupGridView()
        fillGrid(0, lblPersonID.Text)
        RentAddLoadedFlag = True
        cbType.SelectedIndex = 1
        setPicture(picPerson, "0")
    End Sub
    Private Sub fillGrid(ByVal flag As Integer, ByVal personID As String)
        Dim rentBookDAL As TKPC.DAL.RentBookDAL = TKPC.DAL.RentBookDAL.getInstance()
        Dim ds As DataSet = Nothing
        Dim bs As BindingSource = Nothing
        Try
            ds = rentBookDAL.getRentBookList(flag, personID)

            bs = New BindingSource
            bs.DataSource = ds.Tables(0)

            If ds.Tables(0) IsNot Nothing And ds.Tables(0).Rows.Count > 0 Then
                totalNumberOfRows = ds.Tables(0).Rows.Count
                lblTotal.Visible = True
                lblTotal.Text = "Total: " + totalNumberOfRows.ToString + " book(s)"

                If totalNumberOfRows > 0 Then
                    MDITKPC.tspbMDI.Maximum = totalNumberOfRows
                    MDITKPC.tspbMDI.Visible = True
                End If
            Else
                barcodeStorage.Clear()
            End If

            If flag = 0 Then
                emptyDS = ds
            End If

            With ugRent
                .DataSource = bs
            End With

        Catch ex As Exception
        Finally
            rentBookDAL = Nothing
            ds = Nothing
            bs = Nothing
        End Try
    End Sub
    Private Sub setupGridView()
        Try
            With ugRent
                .DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns

                .DisplayLayout.Bands(0).Columns("선택").Hidden = True
                .DisplayLayout.Bands(0).Columns("선택").Width = 50
                .DisplayLayout.Bands(0).Columns("바코드").Width = 80
                .DisplayLayout.Bands(0).Columns("도서명").Width = 300
                .DisplayLayout.Bands(0).Columns("소제목").Width = 110
                .DisplayLayout.Bands(0).Columns("책 분류명").Width = 90
                .DisplayLayout.Bands(0).Columns("대출일").Width = 100
                .DisplayLayout.Bands(0).Columns("저자").Width = 100
                .DisplayLayout.Bands(0).Columns("출판사").Width = 100

                .DisplayLayout.Bands(0).Columns("Rent Book ID").Hidden = True
                .DisplayLayout.Bands(0).Columns("Person ID").Hidden = True
                .DisplayLayout.Bands(0).Columns("Barcode ID").Hidden = True
                .DisplayLayout.Bands(0).Columns("Book ID").Hidden = True
                .DisplayLayout.Bands(0).Columns("대출자").Hidden = True
                .DisplayLayout.Bands(0).Columns("반납일").Hidden = True
                .DisplayLayout.Bands(0).Columns("분실여부").Hidden = True
                .DisplayLayout.Bands(0).Columns("벌금").Hidden = True
                .DisplayLayout.Bands(0).Columns("비고").Hidden = True
                .DisplayLayout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.True
                .DisplayLayout.Override.AllowAddNew = AllowAddNew.Default
                .DisplayLayout.Override.AllowDelete = Infragistics.Win.DefaultableBoolean.True
            End With
        Catch ex As Exception
            MessageBox.Show("frmRentAdd.setupGridView() : " + ex.Message)
        Finally
        End Try
    End Sub

    Private Sub btnExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExit.Click
        Me.Hide() 'Don't close because of frmReturnAdd doubleClickRow event 
        setPanelMenuEnabled(True, True)
    End Sub

    Private Sub txtPersonName_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtPersonName.GotFocus
        HighlightControl(txtPersonName)
        keyPressedName = 1
        'If ugRent.Rows.Count = 0 Then
        '    txtPersonName.Text = String.Empty
        '    lblPersonID.Text = "0"
        'End If

        If whichIME = 0 Then
            whichIME = SwitchIME(hKrLayoutId, KbdKr)
        End If
        If txtPersonName.Text <> String.Empty Then
            populateTelDropdown()
        End If
    End Sub

    Private Sub txtPersonName_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtPersonName.KeyDown
        If e.KeyCode = Keys.Tab Then
            btFind.Focus()
        ElseIf e.KeyCode = Keys.Down Then
            If ugTitle.Visible = True Then
                ugTitle.Focus()
                ugTitle.Rows(0).Selected = True
            End If
        Else
            keyPressedName = 1
        End If
    End Sub

    Private Sub txtPersonName_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtPersonName.KeyUp
        If keyPressedName = 1 Then
            'If cbType.SelectedIndex = 0 Then
            '    setAutoTelAreaCode(txtPersonName, e)
            'End If

            populateTelDropdown()
        End If
    End Sub

    Private Sub txtPersonName_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtPersonName.LostFocus
        UnHighlightControl(txtPersonName)
        keyPressedName = 0
    End Sub

    Public Sub tsbtSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbtSave.Click
        whichIME = SwitchIME(hEnLayoutId, KbdEn)
        If txtPersonName.Text = "" Then
            MessageBox.Show("Please enter a person first.")
            btFind_Click(sender, e)
            Exit Sub
        End If

        If ugRent.Rows.Count = 0 Then
            MessageBox.Show("Please scan a book.")
            ugRent.Focus()
            Exit Sub
        End If

        If txtPersonName.Text <> "" And txtPersonName.Text <> txtName.Text Then
            MessageBox.Show("The name was not fully searched. Please search...")
            txtPersonName.Focus()
            Exit Sub
        End If

        If lblPersonID.Text = "-1" Or lblPersonID.Text = "" Or lblPersonID.Text = "0" Then
            MessageBox.Show("The name was not fully searched. Please search the name again.")
            txtPersonName.Focus()
            Exit Sub
        End If

        Dim rentBookDAL As TKPC.DAL.RentBookDAL = TKPC.DAL.RentBookDAL.getInstance()
        Dim reserveBookDAL As TKPC.DAL.ReserveBookDAL = TKPC.DAL.ReserveBookDAL.getInstance()
        Dim rentBookEnt As TKPC.Entity.RentBookEnt
        Try
            Cursor.Current = Cursors.WaitCursor
            Dim savedRecord = 0
            Dim deletedRecord = 0
            Dim list As ArrayList = getBookArrayList()

            If list IsNot Nothing And list.Count > 0 Then
                For i As Integer = 0 To list.Count - 1
                    rentBookEnt = list(i)
                    If rentBookEnt.rentBookID = "0" Then
                        savedRecord += rentBookDAL.insertRecord(rentBookEnt)
                    End If
                    deletedRecord += reserveBookDAL.deleteRecordByID(rentBookEnt.bookID, lblPersonID.Text)
                    rentBookEnt = Nothing
                Next

                If savedRecord >= 1 Then
                    If deletedRecord >= 1 Then
                        MessageBox.Show("The " + Convert.ToString(list.Count) + " record(s) has been successfully saved and " + Convert.ToString(deletedRecord) + " reserved records were successfully deleted.")
                    Else
                        MessageBox.Show("The " + Convert.ToString(list.Count) + " record(s) has been successfully saved.")
                    End If
                    'viewMode = VIEW_MODE_ADD_MORE
                    'cellChanged = False
                    Dim response As MsgBoxResult = MsgBox("Do you want to create a new rent?", MsgBoxStyle.YesNo, "Confirmation before adding new record")
                    If response = MsgBoxResult.Yes Then
                        makeItAddNew()
                        rentBookDAL = Nothing
                        Cursor.Current = Cursors.Default
                    Else
                        lblPersonID_TextChanged(sender, e)
                    End If
                Else
                    MessageBox.Show("The record was not saved.")
                End If
                Else
                    MessageBox.Show("There is no new record to save.")
                    txtBarcode.Focus()
                    Cursor.Current = Cursors.Default
                End If
        Catch ex As Exception
            MessageBox.Show("Error at saving a record. " + ex.Message)
        Finally
            rentBookDAL = Nothing
            rentBookEnt = Nothing
        End Try
    End Sub

    Public Sub btFind_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btFind.Click
        With frmRentPersonFind
            .callingForm = Me
            .ShowDialog()
        End With
        txtBarcode.Focus()
    End Sub

    Private Sub populateTelDropdown()
        Dim personDAL As TKPC.DAL.PersonDAL = TKPC.DAL.PersonDAL.getInstance()
        Dim searchWords As String = String.Empty
        Dim ds As DataSet = Nothing
        Dim flag As Integer = 0

        Try
            If txtPersonName.Text.Trim <> String.Empty Then
                If cbType.SelectedIndex = 0 Then
                    searchWords = txtPersonName.Text + "%"
                ElseIf cbType.SelectedIndex = 3 Then
                    searchWords = txtPersonName.Text + "%"
                Else
                    searchWords = txtPersonName.Text
                    If cbType.SelectedIndex = 2 Then
                        If IsNumeric(searchWords) = False Then
                            Exit Sub
                        End If
                    End If
                End If
                flag = cbType.SelectedIndex

                ds = personDAL.getListForRent(flag, searchWords)

                If ds.Tables(0).Rows.Count = 0 Then
                    ugTitle.Visible = False
                    ugTitle.DataSource = Nothing
                    lblMsg.Visible = True
                    lblMsg.Text = "Person not found. Please register the person first."
                Else
                    With ugTitle
                        .DataSource = ds.Tables(0)
                        .DisplayLayout.Bands(0).Columns("ID").Width = 40
                        .DisplayLayout.Bands(0).Columns("ID").CellActivation = Activation.NoEdit
                        .DisplayLayout.Bands(0).Columns("이름").Width = 110
                        .DisplayLayout.Bands(0).Columns("이름").CellActivation = Activation.NoEdit
                        .DisplayLayout.Bands(0).Columns("직분").Width = 55S
                        .DisplayLayout.Bands(0).Columns("직분").CellActivation = Activation.NoEdit
                        .DisplayLayout.Bands(0).Columns("성별").Width = 50
                        .DisplayLayout.Bands(0).Columns("성별").CellActivation = Activation.NoEdit
                        .DisplayLayout.Bands(0).Columns("집 전화").Width = 150
                        .DisplayLayout.Bands(0).Columns("집 전화").CellActivation = Activation.NoEdit
                        .DisplayLayout.Bands(0).Columns("다른 전화").Width = 150
                        .DisplayLayout.Bands(0).Columns("다른 전화").CellActivation = Activation.NoEdit
                        .DisplayLayout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.ResizeAllColumns
                        .Visible = True
                        lblMsg.Text = String.Empty
                        lblMsg.Visible = False
                    End With
                End If
            Else
                ugTitle.Visible = False
                ugTitle.DataSource = Nothing
                lblMsg.Text = String.Empty
                lblMsg.Visible = False
            End If

        Catch ex As Exception
            MessageBox.Show("Error at populateTelDropdown() : " + ex.Message())
        Finally
            personDAL = Nothing
            ds = Nothing
        End Try
    End Sub

    Private Sub init()
        If viewMode = VIEW_MODE_ADD_NEW Then
            If fromWhichForm <> FROM_PERSON_ADD Then
                txtPersonName.Text = ""
            End If

            setupGridView()
            If emptyDS IsNot Nothing Then
                ugRent.DataSource = emptyDS.Tables(0)
            Else
                fillGrid(0, lblPersonID.Text)
            End If
            enableControls(False, True, True, True, False)
            setPicture(picPerson, lblPersonID.Text)
        End If

        lblTotal.Text = String.Empty
        If fromWhichForm = FROM_RETURN_ADD Then
            txtBarcode.Focus()
        Else
            txtPersonName.Focus()
        End If
        ''Retrieves current handle to the keyboard layout
        'OriginalLayoutId = GetKeyboardLayout(0)
        ''creates a buffers
        'OriginalLayoutName = New String("", KL_NAMELENGTH - 1)
        ''Retrieves current name of the active keyboard layout
        'GetKeyboardLayoutName(OriginalLayoutName)
        ''MsgBox("Current keyboard layout is => " & OriginalLayoutName)
    End Sub

    Private Sub enableControls(ByVal deleteFlag As Boolean, ByVal addFlag As Boolean, ByVal checkInFlag As Boolean, ByVal findFlag As Boolean, ByVal historyFlag As Boolean)
        tsbtDelete.Enabled = deleteFlag
        tsbtAdd.Enabled = addFlag
        btFind.Enabled = findFlag
        tsbtHistory.Enabled = historyFlag
        tsbtPerson.Enabled = historyFlag
    End Sub

    Public Sub tsbtAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbtAdd.Click
        checkBeforeAddNew()
    End Sub
    Private Sub checkBeforeAddNew()
        Try
            If compareFields() <> "" Then
                Dim theMsg As String = String.Empty
                If compareFields.Trim.EndsWith(",") Then
                    theMsg = compareFields.Substring(0, compareFields.Length - 2)
                End If

                Dim response As MsgBoxResult = MsgBox("The following fields have been changed without saving. " + vbNewLine & _
                                                      theMsg + vbNewLine & _
                                                      "Do you want to save first?", MsgBoxStyle.YesNoCancel, "Confirmation before adding new record")
                If response = MsgBoxResult.Yes Then
                    Dim rentBookDAL As TKPC.DAL.RentBookDAL = TKPC.DAL.RentBookDAL.getInstance()
                    Dim rentBookEnt As TKPC.Entity.RentBookEnt
                    Try
                        Cursor.Current = Cursors.WaitCursor
                        Dim savedRecord = 0
                        Dim list As ArrayList = getBookArrayList()

                        If list IsNot Nothing And list.Count > 0 Then
                            For i As Integer = 0 To list.Count - 1
                                rentBookEnt = list(i)
                                If rentBookEnt.rentBookID = "0" Then
                                    savedRecord = rentBookDAL.insertRecord(rentBookEnt)
                                End If
                            Next

                            If savedRecord = 1 Then
                                MessageBox.Show("The record has been successfully saved.")
                                makeItAddNew()
                            End If
                        End If
                    Catch ex As Exception
                        MessageBox.Show("Error at saving data: " + ex.Message())
                    Finally
                        rentBookDAL = Nothing
                        rentBookEnt = Nothing
                    End Try
                ElseIf response = MsgBoxResult.No Then
                    makeItAddNew()
                End If
            Else
                makeItAddNew()
            End If
        Catch ex As Exception
            MessageBox.Show("Error at adding new rent: " + ex.Message())
        End Try
    End Sub
    Private Sub makeItAddNew()
        viewMode = VIEW_MODE_ADD_NEW
        lblPersonID.Text = "-1"
        init()
        'btFind_Click(sender, e)
        resetRent()
        txtPersonName.Focus()
    End Sub

    Private Sub resetRent()
        barcodeStorage.Clear()
        lblMsg.Visible = False
        txtBarcode.Text = String.Empty
        txtBarcode.Focus()
        barcodeList.Clear()
        totalNumberOfRows = 0
        txtID.Text = String.Empty
        txtName.Text = String.Empty
        txtTel.Text = String.Empty
        lblPersonID.Text = "-1"
    End Sub
    Private Sub txtPersonName_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtPersonName.TextChanged
        If txtPersonName.Text.Trim.Length > 0 Then
            If cbType.SelectedIndex = 0 Then  'Telephone
                If txtPersonName.Text.IndexOf("-") > 0 And Len(txtPersonName.Text.Trim) >= 15 Then
                    lblMsg.Visible = True
                    lblMsg.Text = "Please enter a telephone number."
                    txtPersonName.Text = String.Empty
                Else
                    tsbtHistory.Enabled = True
                End If
            Else
                If txtPersonName.Text.IndexOf("-") > 0 And Len(txtPersonName.Text.Trim) >= 7 Then
                    lblMsg.Visible = True
                    lblMsg.Text = "Please enter a person name."
                    txtPersonName.Text = String.Empty
                Else
                    tsbtHistory.Enabled = True
                End If
            End If
        End If
    End Sub

    Private Sub tsbtDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbtDelete.Click
        'whichIME = SwitchIME(hEnLayoutId, KbdEn)
        'If MsgBox("Do you want to delete the record?", MsgBoxStyle.YesNo, "Delete") = MsgBoxResult.Yes Then
        '    Dim rentBookDAL As TKPC.DAL.RentBookDAL

        '    Try
        '        Cursor.Current = Cursors.WaitCursor
        '        rentBookDAL = TKPC.DAL.RentBookDAL.getInstance()
        '        Dim numberOfDeletedRow As Integer = 0
        '        Dim numberOfUpdatedRow As Integer = 0

        '        numberOfDeletedRow = rentBookDAL.deleteRecordByID(lblRentID.Text)
        '        Dim rbEnt As TKPC.Entity.RentBookEnt
        '        Dim bookDAL As TKPC.DAL.BookDAL = TKPC.DAL.BookDAL.getInstance()
        '        For i As Integer = 0 To getBookArrayList.Count - 1
        '            rbEnt = getBookArrayList.Item(i)
        '            numberOfUpdatedRow = bookDAL.updateRecord(0, rbEnt.bookID, 0)
        '        Next

        '        If numberOfDeletedRow = 1 Then
        '            MessageBox.Show("The record has been successfully deleted.")

        '            'If list form is open, refresh the list form
        '            If RentListLoadedFlag = True Then
        '                frmRentList.tsbtRefresh_Click(sender, e)
        '            End If

        '            viewMode = VIEW_MODE_ADD_NEW
        '            init()
        '        End If
        '    Catch ex As Exception
        '        MessageBox.Show(ex.Message)
        '    Finally
        '        rentDAL = Nothing
        '        Cursor.Current = Cursors.Default
        '    End Try
        'End If

    End Sub

    Private Sub tsbtHistory_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbtHistory.Click
        whichIME = SwitchIME(hEnLayoutId, KbdEn)
        If lblPersonID.Text <> "" And lblPersonID.Text <> "0" And lblPersonID.Text <> "-1" Then
            With frmPersonRentHistory
                .personID = lblPersonID.Text
                .fromWhere = Me.Name
                .ShowDialog()
            End With
        Else
            MessageBox.Show("Please find a person first.")
        End If
    End Sub

    Private Sub ugRent_AfterRowInsert(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinGrid.RowEventArgs) Handles ugRent.AfterRowInsert
        If ugRent.Rows.Count > 0 Then
            enableButtons(True)
        End If
    End Sub

    Private Sub ugRent_AfterRowsDeleted(ByVal sender As Object, ByVal e As System.EventArgs) Handles ugRent.AfterRowsDeleted
        If ugRent.Rows.Count = 0 Then
            enableButtons(False)
        Else
            enableButtons(True)
        End If
    End Sub
    Private Sub enableButtons(ByVal flag As Boolean)
        tsbtExcel.Enabled = flag
        tsbtSave.Enabled = flag
        tsbtPrint.Enabled = flag
    End Sub

    Private Sub ugRent_CellChange(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinGrid.CellEventArgs) Handles ugRent.CellChange
        Dim headerName As String = e.Cell.Column.Header.Caption
        If headerName = "선택" Then
            Dim bookDAL As TKPC.DAL.BookDAL = TKPC.DAL.BookDAL.getInstance()
            Dim theBookID As String = String.Empty

            If e.Cell.Row.Cells("Book ID").Value IsNot DBNull.Value Then
                theBookID = e.Cell.Row.Cells("Book ID").Value
            End If

            If e.Cell.Text <> "" And e.Cell.Text IsNot DBNull.Value Then
                If e.Cell.Text = True Then
                    e.Cell.Row.CellAppearance.BackColor = Color.LightSkyBlue
                    'bookDAL.updateRecord(theBookID, 1)
                Else
                    e.Cell.Row.CellAppearance.BackColor = Color.White
                    'bookDAL.updateRecord(theBookID, 0)

                    'If e.Cell.Row.Cells("Rent Book ID").Value IsNot DBNull.Value Then
                    '    Dim theRentBookID As String = e.Cell.Row.Cells("Rent Book ID").Value
                    '    Dim bookRentDAL As TKPC.DAL.RentBookDAL = TKPC.DAL.RentBookDAL.getInstance()
                    '    bookRentDAL.deleteRecordByID(theRentBookID)
                    'End If
                End If
                cellChanged = True
            End If
        End If
    End Sub

    Private Sub ugRent_DoubleClickCell(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinGrid.DoubleClickCellEventArgs) Handles ugRent.DoubleClickCell
        Dim headerName As String = e.Cell.Column.Header.Caption
        Dim theID As String = String.Empty

        If headerName <> "선택" Then
            If e.Cell.Row.Cells("Book ID").Value IsNot DBNull.Value Then
                theID = e.Cell.Row.Cells("Book ID").Value
                Dim bookEnt As TKPC.Entity.BookEnt = New TKPC.Entity.BookEnt
                Dim bookDAL As TKPC.DAL.BookDAL = TKPC.DAL.BookDAL.getInstance()

                bookEnt = bookDAL.getRecordByID(theID)

                frmBookAdd.Dispose()
                With frmBookAdd
                    .bookEnt = bookEnt
                    .fromWhichForm = FROM_RENT_ADD
                    .viewMode = VIEW_MODE_DETAIL
                    'frmNew.callingForm = Me
                    openForm(Me, frmBookAdd)
                End With
            End If
        End If
    End Sub

    'Private Sub bgwRent_DoWork(ByVal sender As Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles bgwRent.DoWork
    '    MDITKPC.tspbMDI.Visible = True
    '    For i As Integer = 1 To 100
    '        If Me.bgwRent.CancellationPending Then
    '            e.Cancel = True
    '            Return
    '        End If

    '        Dim myPercentage As Integer = (i / totalNumberOfRows) * 100
    '        bgwRent.ReportProgress(myPercentage)
    '        System.Threading.Thread.Sleep(20)
    '    Next
    'End Sub

    'Private Sub bgwRent_ProgressChanged(ByVal sender As Object, ByVal e As System.ComponentModel.ProgressChangedEventArgs) Handles bgwRent.ProgressChanged
    '    If e.ProgressPercentage <= MDITKPC.tspbMDI.Maximum Then
    '        MDITKPC.tspbMDI.Value = e.ProgressPercentage
    '    End If
    'End Sub

    'Private Sub bgwData_RunWorkerCompleted(ByVal sender As Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles bgwRent.RunWorkerCompleted
    '    MDITKPC.tspbMDI.Visible = False
    'End Sub

    Private Function compareFields() As String
        compareFields = String.Empty

        If viewMode = VIEW_MODE_DETAIL Or viewMode = VIEW_MODE_ADD_MORE Then
            If cellChanged = True Then
                compareFields += "Books "
            End If
        Else
            If getBookArrayList() IsNot Nothing And getBookArrayList.Count > 0 Then
                compareFields += "Books "
            End If
        End If
    End Function

    Private Sub ugRent_InitializeRow(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinGrid.InitializeRowEventArgs) Handles ugRent.InitializeRow
        If totalNumberOfRows > 0 Then
            MDITKPC.tspbMDI.Value += 1

            If MDITKPC.tspbMDI.Value = totalNumberOfRows Then
                MDITKPC.tspbMDI.Visible = False
                MDITKPC.tspbMDI.Value = 0
                totalNumberOfRows = 0
            End If

            Dim barcode As String = e.Row.Cells("바코드").Value

            If barcode IsNot DBNull.Value And barcode <> String.Empty Then
                If barcodeStorage.ContainsKey(barcode) = False Then
                    barcodeStorage.Add(barcode, barcode)
                End If
            End If

            'If e.Row.Cells("바코드").Text <> String.Empty And _
            '   e.Row.Cells("바코드").Text <> "0" And _
            '   e.Row.Cells("바코드").Text <> "" And _
            '   e.Row.Cells("바코드").Text IsNot DBNull.Value Then
            '    e.Row.CellAppearance.BackColor = Color.LightSkyBlue
            'End If
        End If
    End Sub

    Private Sub tsbtPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbtPrint.Click
        whichIME = SwitchIME(hEnLayoutId, KbdEn)
        uppdRent.ShowDialog()
    End Sub

    Private Sub tsbtExcel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbtExcel.Click
        whichIME = SwitchIME(hEnLayoutId, KbdEn)
        Cursor.Current = Cursors.WaitCursor
        Try
            Dim theFile As String = Application.StartupPath + "\\" + BOOL_LIST_AT_RENT_EXCEL
            Me.ugExcel.Export(Me.ugRent, theFile)
            Process.Start(theFile)

        Catch ex As Exception
            MessageBox.Show(ex.Message + " If the file called " + BOOL_LIST_AT_RENT_EXCEL + " is open, please close it and try again.")
        Finally
            Cursor.Current = Cursors.Default
        End Try
    End Sub

    Private Sub txtBarcode_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtBarcode.TextChanged
        If txtBarcode.Text.Trim <> String.Empty And Len(txtBarcode.Text.Trim) >= 7 Then
            Dim strArray As String() = txtBarcode.Text.Trim.Split("-")
            If strArray IsNot Nothing And txtBarcode.Text.Trim.IndexOf("-") = -1 Then
                lblMsg.Text = "You entered the wrong barcode. Please scan again. "
                lblMsg.Visible = True
                Exit Sub
            End If

            If strArray IsNot Nothing And Len(strArray(1)) <> 5 Then
                lblMsg.Text = "You entered the wrong barcode. Please scan again. "
                lblMsg.Visible = True
                Exit Sub
            End If

            lblMsg.Visible = False
            Dim barcodeNumber As String = txtBarcode.Text
            Dim myMatch As Match = System.Text.RegularExpressions.Regex.Match(txtBarcode.Text.Trim, BARCODE_REGEX)
            If myMatch.Success Then
                Dim rentBookDAL As TKPC.DAL.RentBookDAL = TKPC.DAL.RentBookDAL.getInstance()
                Dim rentBookEnt As TKPC.Entity.RentBookEnt = New TKPC.Entity.RentBookEnt
                Dim rentBookList As ArrayList = New ArrayList
                Dim reserveBookDAL As TKPC.DAL.ReserveBookDAL = TKPC.DAL.ReserveBookDAL.getInstance()
                Dim totalRowCnt As Integer = 0
                Try
                    rentBookList = rentBookDAL.getReturnRecordByBarcode(0, txtBarcode.Text.Trim)
                    If rentBookList.Count >= 2 Then
                        lblMsg.Text = "There are duplicate records. Please contact the database administrator."
                        Exit Sub
                    Else
                        rentBookEnt = rentBookList(0)
                    End If

                    Dim ds As DataSet = reserveBookDAL.getReserveBookList(0, rentBookEnt.bookID)
                    If ds IsNot Nothing Then
                        totalRowCnt = ds.Tables(0).Rows.Count
                        If totalRowCnt > 0 Then
                            Dim firstPersonID As String = ds.Tables(0).Rows.Item(0).Item(3).ToString()
                            If firstPersonID <> lblPersonID.Text Then
                                Dim response As MsgBoxResult = MsgBox("It was already reserved by someone else. Do you want to view the list?", MsgBoxStyle.OkCancel, "View Confirmation")
                                If response = MsgBoxResult.Ok Then
                                    With frmBookReserveList
                                        .bookID = rentBookEnt.bookID
                                        .bookName = rentBookEnt.bookTitle
                                        .barcode = barcodeNumber
                                        .parentName = Me.Name
                                        .ShowDialog()
                                    End With
                                    Exit Sub
                                End If
                            End If
                        End If
                    End If

                    If rentBookEnt IsNot Nothing And rentBookEnt.barcodeID <> String.Empty And rentBookEnt.barcodeID IsNot Nothing Then
                        If rentBookEnt.status <> "" And rentBookEnt.status.Trim = "A" Then
                            If barcodeStorage.ContainsKey(txtBarcode.Text) = False Then
                                Dim addedRow As UltraGridRow = ugRent.DisplayLayout.Bands(0).AddNew()
                                Dim newCells As CellsCollection = addedRow.Cells

                                newCells("선택").Value = rentBookEnt.flag
                                newCells("Rent Book ID").Value = 0
                                newCells("Book ID").Value = rentBookEnt.bookID
                                newCells("Barcode ID").Value = rentBookEnt.barcodeID
                                'newCells("Person ID").Value = rentBookEnt.personID
                                newCells("바코드").Value = rentBookEnt.barcode
                                newCells("도서명").Value = rentBookEnt.bookTitle
                                newCells("소제목").Value = rentBookEnt.bookSubtitle
                                newCells("책 분류명").Value = rentBookEnt.bookType
                                newCells("저자").Value = rentBookEnt.bookAuthor
                                newCells("출판사").Value = rentBookEnt.bookPublisher
                                ugRent.Update()

                                barcodeStorage.Add(txtBarcode.Text.Trim, txtBarcode.Text.Trim)
                                tsbtHistory.Enabled = True
                                lblMsg.Text = ""
                                lblMsg.Visible = False
                            Else
                                lblMsg.Text = "The barcode, " + barcodeNumber + " has been already scanned. "
                                lblMsg.Visible = True
                            End If
                        ElseIf rentBookEnt.status.Trim = "R" Then
                            rentBookList = rentBookDAL.getReturnRecordByBarcode(1, txtBarcode.Text.Trim)

                            If rentBookList.Count = 1 Then
                                rentBookEnt = rentBookList(0)
                            Else
                                lblMsg.Text = "There are duplicate records. Please contact the database administrator."
                                Exit Sub
                            End If

                            If rentBookEnt IsNot Nothing And rentBookEnt.barcodeID IsNot Nothing Then
                                lblMsg.Text = "The book has been already rented by " + rentBookEnt.personName + " on " + rentBookEnt.rentDate + "."
                            Else
                                lblMsg.Text = "The book has been already rented."
                            End If

                            lblMsg.Visible = True
                        Else
                            lblMsg.Text = "The book has been lost. if found, please change the status at Book Add Screen."
                            lblMsg.Visible = True
                        End If
                    Else
                        lblMsg.Text = "The barcode, " + barcodeNumber + " cannot be found in database. Please register it first."
                        lblMsg.Visible = True
                        'MessageBox.Show("The book was not registered. Please register it first.")
                    End If

                Catch ex As Exception
                Finally
                    rentBookDAL = Nothing
                    rentBookEnt = Nothing
                    txtBarcode.Text = String.Empty
                    txtBarcode.Focus()
                End Try
            Else
                lblMsg.Text = "You scanned the wrong barcode. Please scan again."
                lblMsg.Visible = True
                txtBarcode.Text = String.Empty
                txtBarcode.Focus()
            End If
        Else
            tsbtHistory.Enabled = False
        End If
    End Sub
    Private Sub txtBarcode_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtBarcode.GotFocus
        HighlightControl(txtBarcode)
    End Sub

    Private Sub txtBarcode_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtBarcode.LostFocus
        UnHighlightControl(txtBarcode)
    End Sub

    Private Sub ugRent_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles ugRent.KeyUp
        If e.KeyCode = Keys.Delete Then
            If ugRent.Rows.Count > 0 Then
                If ugRent.ActiveRow.Cells("대출일").Value Is DBNull.Value Then
                    Dim barcode As String = ugRent.ActiveRow.Cells("바코드").Value
                    If barcode <> String.Empty And barcode <> "0" Then
                        ugRent.ActiveRow.Delete()
                        barcodeStorage.Remove(barcode)
                    Else
                        MessageBox.Show("Generate the barcode for the book at Book Add screen.")
                    End If
                Else
                    MessageBox.Show("The row can't be deleted because it was already rented.")
                End If
                txtBarcode.Focus()
            End If
        End If
    End Sub

    Private Sub lblPersonID_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles lblPersonID.TextChanged
        fillGrid(1, lblPersonID.Text)
        setPicture(picPerson, lblPersonID.Text)
        If lblPersonID.Text <> "" And lblPersonID.Text <> "0" And lblPersonID.Text <> "-1" Then
            tsbtHistory.Enabled = True
            tsbtPerson.Enabled = True
        Else
            tsbtHistory.Enabled = False
            tsbtPerson.Enabled = False
        End If
    End Sub

    Private Sub tsbtReturn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbtReturn.Click
        whichIME = SwitchIME(hEnLayoutId, KbdEn)
        openForm(Me, frmReturnAdd)
    End Sub

    Public Sub getDataFromGrid()
        If ugTitle.Rows.Count > 0 Then
            If ugTitle.ActiveRow IsNot Nothing Then
                If lblPersonID.Text <> "0" And lblPersonID.Text <> "-1" And lblPersonID.Text <> "" Then
                    checkBeforeAddNew()
                End If
                lblPersonID.Text = ugTitle.ActiveRow.Cells(0).Value
                txtPersonName.Text = ugTitle.ActiveRow.Cells(1).Value
                txtName.Text = txtPersonName.Text
                txtTel.Text = ugTitle.ActiveRow.Cells(4).Value

                If personInfoAddedNow = False Then
                    If txtTel.Text.StartsWith("0") = True Then
                        MessageBox.Show("Please update the client's telephone number.")
                        viewPerson()
                    End If
                End If
                txtID.Text = lblPersonID.Text
                personInfoAddedNow = False
            End If
            ugTitle.Visible = False
            lblMsg.Text = String.Empty
            lblMsg.Visible = False
            tsbtPerson.Visible = True
            txtBarcode.Focus()
        End If
    End Sub

    Private Sub ugTitle_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles ugTitle.KeyDown
        If e.KeyCode = Keys.Enter Then
            getDataFromGrid()
        End If
    End Sub

    Private Sub cbType_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbType.SelectedIndexChanged
        resetRent()
        txtPersonName.Focus()
    End Sub

    Private Sub tsbtPersonAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbtPersonAdd.Click
        frmPersonAdd.Dispose()
        With frmPersonAdd
            .Width = 851
            .Height = 695
            .WindowState = FormWindowState.Normal
            .viewMode = VIEW_MODE_ADD_NEW
            .fromWhichForm = 99
            .ShowDialog()
        End With
    End Sub
    Private Sub viewPerson()
        If lblPersonID.Text <> "0" Then
            Dim personID As String = lblPersonID.Text
            Dim personEnt As TKPC.Entity.PersonEnt = New TKPC.Entity.PersonEnt
            Dim personDAL As TKPC.DAL.PersonDAL = TKPC.DAL.PersonDAL.getInstance()

            Try
                personEnt = personDAL.getRecordByID(personID)

                frmPersonAdd.Dispose()
                With frmPersonAdd
                    .Width = 851
                    .Height = 695
                    .WindowState = FormWindowState.Normal
                    .viewMode = VIEW_MODE_DETAIL
                    .personEnt = personEnt
                    .fromWhichForm = 99
                    .ShowDialog()
                End With
            Catch
            Finally
                personEnt = Nothing
                personDAL = Nothing
            End Try
        End If
    End Sub

    Private Sub tsbtPerson_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbtPerson.Click
        viewPerson()
    End Sub

    Private Sub Panel1_MouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Panel1.MouseClick
        ugTitle.Visible = False
    End Sub

    Private Sub ugTitle_MouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles ugTitle.MouseClick
        getDataFromGrid()
    End Sub

    Private Sub ugTitle_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles ugTitle.MouseEnter
        ugTitle.Focus()
    End Sub
End Class