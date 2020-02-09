Imports Infragistics.Win.UltraWinGrid
Imports Infragistics.Win.UltraWinDock
Imports System.Text.RegularExpressions

Public Class frmReturnAdd

    Public viewMode As Integer
    Public rentBookEnt As TKPC.Entity.RentBookEnt
    Public callingForm As frmRentList
    Private closingMode As Boolean = False
    Dim cellChanged As Boolean = False
    Private totalNumberOfRows As Integer = 0
    Public fromWhichForm As Integer = 0
    Private barcodeStorage As Hashtable = New Hashtable()
    Private cellPersonID As String = String.Empty
    Private emptyDS As DataSet

    Private Sub frmReturnAdd_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        txtBarcode.Focus()
    End Sub

    Private Sub frmReturnAdd_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        setPanelMenuEnabled(True, True)
        rentBookEnt = Nothing
        returnAddFormOpened = 0
    End Sub

    Private Sub frmReturnAdd_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Show()
        'setPanelMenuEnabled(True, True)
        setupGridView()
        returnAddFormOpened = 1

        With ugRent
            .Focus()
            .DisplayLayout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.False
            .DisplayLayout.Override.AllowDelete = Infragistics.Win.DefaultableBoolean.True
        End With

        With ugHistory
            .Focus()
            .DisplayLayout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.False
            .DisplayLayout.Override.AllowDelete = Infragistics.Win.DefaultableBoolean.True
        End With
        fillGrid()
        txtBarcode.Focus()
    End Sub
    Private Sub fillGrid()
        Dim rentBookDAL As TKPC.DAL.RentBookDAL = TKPC.DAL.RentBookDAL.getInstance()
        Dim ds As DataSet = Nothing
        Dim bs As BindingSource = Nothing

        Try
            ds = rentBookDAL.getRentBookList(2, txtBarcode.Text)

            bs = New BindingSource
            bs.DataSource = ds.Tables(0)

            With ugRent
                .DataSource = bs
            End With

            With ugHistory
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

                .DisplayLayout.Bands(0).Columns("선택").Width = 70
                .DisplayLayout.Bands(0).Columns("선택").Hidden = True
                .DisplayLayout.Bands(0).Columns("대출자").Width = 100
                .DisplayLayout.Bands(0).Columns("대출일").Width = 120
                .DisplayLayout.Bands(0).Columns("바코드").Width = 90
                .DisplayLayout.Bands(0).Columns("도서명").Width = 330
                .DisplayLayout.Bands(0).Columns("분실여부").Width = 100
                .DisplayLayout.Bands(0).Columns("분실여부").Hidden = False
                .DisplayLayout.Bands(0).Columns("벌금").Width = 100
                .DisplayLayout.Bands(0).Columns("벌금").Hidden = True
                .DisplayLayout.Bands(0).Columns("반납일").Width = 120
                .DisplayLayout.Bands(0).Columns("반납일").Hidden = True
                .DisplayLayout.Bands(0).Columns("비고").Width = 200

                .DisplayLayout.Bands(0).Columns("Rent Book ID").Hidden = True
                .DisplayLayout.Bands(0).Columns("Person ID").Hidden = True
                .DisplayLayout.Bands(0).Columns("Book ID").Hidden = True
                .DisplayLayout.Bands(0).Columns("Barcode ID").Hidden = True
                .DisplayLayout.Bands(0).Columns("소제목").Hidden = True
                .DisplayLayout.Bands(0).Columns("책 분류명").Hidden = True
                .DisplayLayout.Bands(0).Columns("저자").Hidden = True
                .DisplayLayout.Bands(0).Columns("출판사").Hidden = True
                .DisplayLayout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.True
                .DisplayLayout.Override.AllowAddNew = AllowAddNew.Default
            End With

            With ugHistory
                .DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns

                .DisplayLayout.Bands(0).Columns("선택").Width = 70
                .DisplayLayout.Bands(0).Columns("선택").Hidden = True
                .DisplayLayout.Bands(0).Columns("대출자").Width = 100
                .DisplayLayout.Bands(0).Columns("대출일").Width = 120
                .DisplayLayout.Bands(0).Columns("바코드").Width = 90
                .DisplayLayout.Bands(0).Columns("도서명").Width = 330
                .DisplayLayout.Bands(0).Columns("분실여부").Width = 50
                .DisplayLayout.Bands(0).Columns("벌금").Width = 100
                .DisplayLayout.Bands(0).Columns("벌금").Hidden = True
                .DisplayLayout.Bands(0).Columns("반납일").Width = 120
                .DisplayLayout.Bands(0).Columns("비고").Width = 200

                .DisplayLayout.Bands(0).Columns("Rent Book ID").Hidden = True
                .DisplayLayout.Bands(0).Columns("Person ID").Hidden = True
                .DisplayLayout.Bands(0).Columns("Book ID").Hidden = True
                .DisplayLayout.Bands(0).Columns("Barcode ID").Hidden = True
                .DisplayLayout.Bands(0).Columns("소제목").Hidden = True
                .DisplayLayout.Bands(0).Columns("책 분류명").Hidden = True
                .DisplayLayout.Bands(0).Columns("저자").Hidden = True
                .DisplayLayout.Bands(0).Columns("출판사").Hidden = True
                .DisplayLayout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.True
                .DisplayLayout.Override.AllowAddNew = AllowAddNew.Default
            End With

        Catch ex As Exception
            MessageBox.Show("frmReturnAdd.setupGridView() : " + ex.Message)
        Finally
        End Try
    End Sub
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
    Private Function getBookArrayList() As ArrayList
        getBookArrayList = New ArrayList()

        Try
            Dim rbEnt As TKPC.Entity.RentBookEnt
            For i As Integer = 0 To ugRent.Rows.Count - 1
                rbEnt = New TKPC.Entity.RentBookEnt
                If ugRent.Rows(i).Cells("Rent Book ID").Value IsNot DBNull.Value Then
                    rbEnt.rentBookID = ugRent.Rows(i).Cells("Rent Book ID").Value
                Else
                    rbEnt.rentBookID = ""
                End If

                If ugRent.Rows(i).Cells("Book ID").Value IsNot DBNull.Value Then
                    rbEnt.bookID = ugRent.Rows(i).Cells("Book ID").Value
                Else
                    rbEnt.bookID = ""
                End If

                If ugRent.Rows(i).Cells("Barcode ID").Value IsNot DBNull.Value Then
                    rbEnt.barcodeID = ugRent.Rows(i).Cells("Barcode ID").Value
                Else
                    rbEnt.barcodeID = ""
                End If

                If ugRent.Rows(i).Cells("Person ID").Value IsNot DBNull.Value Then
                    rbEnt.personID = ugRent.Rows(i).Cells("Person ID").Value
                Else
                    rbEnt.personID = ""
                End If

                rbEnt.lost = ugRent.Rows(i).Cells("분실여부").Value

                If ugRent.Rows(i).Cells("벌금").Value IsNot DBNull.Value Then
                    rbEnt.penalty = ugRent.Rows(i).Cells("벌금").Value
                Else
                    rbEnt.penalty = False
                End If

                rbEnt.returnDate = Today.Date

                If ugRent.Rows(i).Cells("비고").Value IsNot DBNull.Value Then
                    rbEnt.note = ugRent.Rows(i).Cells("비고").Value
                Else
                    rbEnt.note = ""
                End If

                rbEnt.lastUpdateDate = Today.Date
                rbEnt.flag = 1

                getBookArrayList.Add(rbEnt)
            Next i
        Catch ex As Exception
        Finally
        End Try

        Return getBookArrayList
    End Function
    Private Sub frmReturnAdd_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        'If Me.bgwRent.IsBusy Then Me.bgwRent.CancelAsync()

        If compareFields() <> "" Then
            Dim theMsg As String = String.Empty
            If compareFields.Trim.EndsWith(",") Then
                theMsg = compareFields.Substring(0, compareFields.Length - 2)
            End If

            If returnAddFormSaved = 1 Then
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
        End If
    End Sub
    Private Sub btnExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExit.Click
        Me.Close()
        'setPanelMenuEnabled(True, True)
    End Sub

    Private Sub txtBarcode_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtBarcode.TextChanged
        getRentList(ugRent, 0)
    End Sub

    Private Sub getRentList(ByRef ugGrid As UltraGrid, ByVal flag As Integer)
        If txtBarcode.Text.Trim <> "" And Len(txtBarcode.Text.Trim) >= 7 Then
            Dim myMatch As Match = System.Text.RegularExpressions.Regex.Match(txtBarcode.Text.Trim, BARCODE_REGEX)
            If myMatch.Success Then
                Dim rentBookDAL As TKPC.DAL.RentBookDAL = TKPC.DAL.RentBookDAL.getInstance()
                Dim rentBookEnt As TKPC.Entity.RentBookEnt = New TKPC.Entity.RentBookEnt
                Dim rentBookList As ArrayList = New ArrayList

                Try
                    rentBookList = rentBookDAL.getReturnRecordByBarcode(1, txtBarcode.Text.Trim)

                    For i As Integer = 0 To rentBookList.Count - 1

                        'If rentBookList.Count > 1 Then
                        '    MsgBox("You can update the record now. " + vbNewLine + "However there are more than 2 duplicate records. " + vbNewLine + "Please close this window and scan the barcode again or contact the database administrator.")
                        'End If

                        rentBookEnt = rentBookList(i)

                        If rentBookEnt IsNot Nothing And rentBookEnt.rentBookID <> "0" And rentBookEnt.rentBookID IsNot Nothing Then
                            If rentBookEnt.returnDate = "" Then
                                Dim barcodeKey As String = txtBarcode.Text.Trim + rentBookEnt.personName

                                If barcodeStorage.ContainsKey(barcodeKey) = False Then
                                    Dim addedRow As UltraGridRow = ugRent.DisplayLayout.Bands(0).AddNew()
                                    Dim newCells As CellsCollection = addedRow.Cells
                                    newCells("선택").Value = rentBookEnt.flag
                                    newCells("Rent Book ID").Value = Convert.ToInt32(rentBookEnt.rentBookID)
                                    newCells("Book ID").Value = rentBookEnt.bookID
                                    newCells("Barcode ID").Value = Convert.ToInt32(rentBookEnt.barcodeID)
                                    newCells("Person ID").Value = Convert.ToInt32(rentBookEnt.personID)
                                    newCells("대출자").Value = rentBookEnt.personName
                                    newCells("대출일").Value = rentBookEnt.rentDate
                                    newCells("바코드").Value = rentBookEnt.barcode
                                    newCells("도서명").Value = rentBookEnt.bookTitle
                                    newCells("반납일").Value = rentBookEnt.returnDate
                                    newCells("분실여부").Value = 0
                                    newCells("벌금").Value = 0
                                    newCells("비고").Value = ""
                                    ugRent.Update()

                                    barcodeStorage.Add(barcodeKey, txtBarcode.Text.Trim)
                                    tsbtHistory.Enabled = True
                                    getAllRentedBookList(rentBookEnt.personID)
                                    cellPersonID = rentBookEnt.personID
                                    lblNote.Visible = False
                                    returnAddFormSaved = 1
                                    tsbtToday.Enabled = False
                                    lblNote.Text = "Total: " + barcodeStorage.Count.ToString
                                Else
                                    lblNote.Text = "The book has been already scanned. Please scan another one."
                                    lblNote.Visible = True
                                End If
                            Else
                                lblNote.Text = "The book has been already returned. Please try another one."
                                lblNote.Visible = True
                            End If
                        Else
                            lblNote.Text = "The book has not ever been rented. Please try another one."
                            lblNote.Visible = True
                        End If
                    Next i

                Catch ex As Exception
                Finally
                    rentBookDAL = Nothing
                    rentBookEnt = Nothing
                    txtBarcode.Text = String.Empty
                    txtBarcode.Focus()
                End Try
            End If
        End If
    End Sub
    Private Sub getAllRentedBookList(ByVal personID As String)

        If personID <> "" Then
            Dim rentBookDAL As TKPC.DAL.RentBookDAL = TKPC.DAL.RentBookDAL.getInstance()
            Dim ds As DataSet = Nothing
            Dim bs As BindingSource = Nothing

            Try
                ds = rentBookDAL.getRentBookList(1, personID)
                bs = New BindingSource
                bs.DataSource = ds.Tables(0)

                With ugHistory
                    .DataSource = bs
                End With

            Catch ex As Exception

            Finally
                rentBookDAL = Nothing
                bs = Nothing
                ds = Nothing
            End Try
        End If
    End Sub

    Public Sub tsbtSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbtSave.Click
        If ugRent.Rows.Count = 0 Then
            MessageBox.Show("Please scan a book.")
            txtBarcode.Focus()
            Exit Sub
        End If

        Dim rentBookDAL As TKPC.DAL.RentBookDAL = TKPC.DAL.RentBookDAL.getInstance()
        Dim rbEnt As TKPC.Entity.RentBookEnt = New TKPC.Entity.RentBookEnt

        Try
            Cursor.Current = Cursors.WaitCursor
            Dim savedRecord As Integer = 0
            Dim cnt As Integer = 0
            Dim list As ArrayList = getBookArrayList()

            If list IsNot Nothing And list.Count > 0 Then
                cnt = getBookArrayList.Count
                For i As Integer = 0 To cnt - 1
                    rbEnt = getBookArrayList(i)
                    savedRecord += rentBookDAL.updateRecord(rbEnt)
                    rbEnt = Nothing
                Next i
            End If

            If savedRecord >= 1 Then
                MessageBox.Show("The " + Convert.ToString(list.Count) + " record(s) has been successfully saved.")
                viewMode = VIEW_MODE_ADD_MORE
                cellChanged = False
                getAllRentedBookList(cellPersonID)
                returnAddFormSaved = 0
                lblNote.Text = "Total: " + barcodeStorage.Count.ToString
                tsbtToday.Enabled = True
            Else
                MessageBox.Show("The record was not saved.")
                viewMode = VIEW_MODE_ADD_NEW
            End If


        Catch ex As Exception
            MessageBox.Show("Error at saving a record. " + ex.Message)
        Finally
            Cursor.Current = Cursors.Default
            rentBookDAL = Nothing
            rbEnt = Nothing
            txtBarcode.Focus()
        End Try
    End Sub

    Private Sub tsbtRent_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbtRent.Click
        If returnAddFormOpened = 1 And returnAddFormSaved = 1 Then
            Dim response As MsgBoxResult = MsgBox("The returned books was NOT saved yet. " + vbNewLine & _
                                                  vbNewLine & _
                                                  "Do you want to save them first?", MsgBoxStyle.YesNo, "Confirmation before Closing")
            If response = MsgBoxResult.Yes Then
                tsbtSave_Click(sender, e)
                openForm(Me, frmRentAdd)
            Else
                openForm(Me, frmRentAdd)
            End If
        Else
            openForm(Me, frmRentAdd)
        End If
    End Sub

    Private Sub ugRent_AfterRowActivate(ByVal sender As Object, ByVal e As System.EventArgs) Handles ugRent.AfterRowActivate
        If ugRent.Rows.Count > 0 Then
            If ugRent.ActiveRow.Cells("Person ID").Value IsNot DBNull.Value And ugRent.ActiveRow.Cells("Person ID").Value IsNot String.Empty Then
                getAllRentedBookList(ugRent.ActiveRow.Cells("Person ID").Value)
                cellPersonID = ugRent.ActiveRow.Cells("Person ID").Value
            End If
        End If
    End Sub

    Private Sub ugRent_InitializeRow(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinGrid.InitializeRowEventArgs) Handles ugRent.InitializeRow
        If e.Row.Cells("반납일").Text = "" Or e.Row.Cells("반납일").Text = "0001/01/01" Then
            e.Row.CellAppearance.BackColor = Color.White
        Else
            e.Row.CellAppearance.BackColor = Color.LightCyan
        End If
    End Sub

    Private Sub ugRent_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles ugRent.KeyDown
        If e.KeyCode = Keys.Down Then
            ugRent.ActiveRowScrollRegion.Scroll(Infragistics.Win.UltraWinGrid.RowScrollAction.LineDown)
        ElseIf e.KeyCode = Keys.Up Then
            ugRent.ActiveRowScrollRegion.Scroll(Infragistics.Win.UltraWinGrid.RowScrollAction.LineUp)
        ElseIf e.KeyCode = Keys.PageDown Then
            ugRent.ActiveRowScrollRegion.Scroll(Infragistics.Win.UltraWinGrid.RowScrollAction.PageDown)
        ElseIf e.KeyCode = Keys.PageUp Then
            ugRent.ActiveRowScrollRegion.Scroll(Infragistics.Win.UltraWinGrid.RowScrollAction.PageUp)
        End If
    End Sub

    Private Sub ugRent_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles ugRent.KeyUp
        If e.KeyCode = Keys.Delete Then
            If ugRent.Rows.Count > 0 Then
                If ugRent.ActiveRow.Cells("대출일").Value IsNot DBNull.Value Then
                    Dim barcodeKey As String = ugRent.ActiveRow.Cells("바코드").Value + ugRent.ActiveRow.Cells("대출자").Value
                    If barcodeKey <> String.Empty And barcodeKey <> "0" Then
                        ugRent.ActiveRow.Delete()
                        getAllRentedBookList(0)
                        barcodeStorage.Remove(barcodeKey)
                        lblNote.Text = "Total: " + barcodeStorage.Count.ToString
                    Else
                        MessageBox.Show("Generate the barcode for the book at Book Add screen.")
                    End If
                End If
            End If
        End If
    End Sub

    Private Sub ugRent_MouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles ugRent.MouseClick
        If ugRent.Rows.Count > 0 Then
            If ugRent.ActiveRow.Cells("Person ID").Value IsNot DBNull.Value And ugRent.ActiveRow.Cells("Person ID").Value IsNot String.Empty Then
                getAllRentedBookList(ugRent.ActiveRow.Cells("Person ID").Value)
                cellPersonID = ugRent.ActiveRow.Cells("Person ID").Value
            End If
        End If
    End Sub

    'Private Sub btList_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    Dim ds As DataSet

    '    Dim rentBookDAL As TKPC.DAL.RentBookDAL = TKPC.DAL.RentBookDAL.getInstance()

    '    Try
    '        ds = rentBookDAL.getRentBookList(4, "")

    '    Catch ex As Exception
    '        MessageBox.Show("Error at frmReturnAdd.btList_Click : " + ex.Message)
    '    Finally
    '    End Try
    'End Sub

    Private Sub btFind_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btFind.Click
        With frmBookRentHistory
            .flag = 4
            .bookID = String.Empty
            .tsbtRefresh.Visible = False
            .fromWhere = Me.Name
            .ShowDialog()
            txtBarcode.Focus()
        End With
    End Sub

    Private Sub tsbtHistory_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbtHistory.Click
        With frmBookRentHistory
            .flag = 4
            .bookID = String.Empty
            .tsbtRefresh.Visible = False
            .fromWhere = Me.Name
            .ShowDialog()
            txtBarcode.Focus()
        End With
    End Sub
    Private Sub ugRent_AfterRowsDeleted(ByVal sender As Object, ByVal e As System.EventArgs) Handles ugRent.AfterRowsDeleted
        If ugRent.Rows.Count = 0 Then
            enableButtons(False)
            getAllRentedBookList(-1)
        Else
            enableButtons(True)
        End If
        txtBarcode.Focus()
    End Sub
    Private Sub enableButtons(ByVal flag As Boolean)
        tsbtSave.Enabled = flag
    End Sub

    Private Sub tsbtToday_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbtToday.Click
        Dim rentBookDAL As TKPC.DAL.RentBookDAL = TKPC.DAL.RentBookDAL.getInstance()
        Dim ds As DataSet = Nothing
        Dim bs As BindingSource = Nothing

        Try
            ds = rentBookDAL.getRentBookList(9, "")
            bs = New BindingSource
            bs.DataSource = ds.Tables(0)

            With ugRent
                .DataSource = bs
            End With

            barcodeStorage.Clear()
            If ds.Tables(0) IsNot Nothing Then
                Dim barcode As String = String.Empty
                For i As Integer = 0 To ds.Tables(0).Rows.Count - 1
                    barcode = ds.Tables(0).Rows(i).Item("바코드").ToString
                    If barcodeStorage.ContainsKey(barcode.Trim) = False Then
                        barcodeStorage.Add(barcode, barcode.Trim)
                    End If
                Next
                lblNote.Text = "Total: " + ds.Tables(0).Rows.Count.ToString
                returnAddFormSaved = 0
            Else
                MsgBox("There is no returned book today yet. Please scan a barcode.")
            End If

            txtBarcode.Focus()

        Catch ex As Exception
            MessageBox.Show("Error at tsbtToday_Click : " + ex.Message)
        Finally
            rentBookDAL = Nothing
            bs = Nothing
            ds = Nothing
        End Try
    End Sub

    Private Sub ugRent_DoubleClickRow(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinGrid.DoubleClickRowEventArgs) Handles ugRent.DoubleClickRow
        If e.Row.Index >= 0 Then
            If e.Row.Cells("대출자").Value IsNot Nothing Then
                Cursor.Current = Cursors.WaitCursor
                Dim personDAL As TKPC.DAL.PersonDAL = TKPC.DAL.PersonDAL.getInstance()
                Dim personEnt As TKPC.Entity.PersonEnt = New TKPC.Entity.PersonEnt
                Dim personID As String = e.Row.Cells("Person ID").Value

                Try
                    personEnt = personDAL.getRecordByID(personID)

                    With frmRentAdd
                        .lblPersonID.Text = personID
                        .txtID.Text = personID
                        .txtName.Text = personEnt.name
                        .txtTel.Text = personEnt.homeTel
                        .txtPersonName.Text = e.Row.Cells("대출자").Value
                        .fromWhichForm = FROM_RETURN_ADD
                    End With

                    openForm(MDITKPC, frmRentAdd)
                    frmRentAdd.ugTitle.Hide()
                    Cursor.Current = Cursors.Default
                Catch ex As Exception
                    MessageBox.Show("Error at opening a rent from." + ex.Message)
                Finally
                    personDAL = Nothing
                    personEnt = Nothing
                End Try
            End If
        End If
    End Sub

    Private Sub frmReturnAdd_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.GotFocus
        txtBarcode.Focus()
    End Sub

    Private Sub frmReturnAdd_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Enter
        txtBarcode.Focus()
    End Sub
End Class