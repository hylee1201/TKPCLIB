Imports System.Text.RegularExpressions

Public Class frmBookBarcodeAdd
    Public viewMode As Integer
    Public BookBarcodeEnt As TKPC.Entity.BookBarcodeEnt
    Private closingMode As Boolean = False
    Public BookTypeID As Integer = 1
    Private totalNumberOfRows As Integer = 0

    Private Sub frmBookBarcodeAdd_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        BookBarcodeEnt = Nothing
    End Sub

    Private Sub frmBookBarcodeAdd_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Show()
        init()
    End Sub

    Private Sub init()
        If viewMode = VIEW_MODE_ADD_NEW Then
            txtBarcode.Text = m_DBUtil.getBarcode(BookTypeID, "")
            txtBarcode.Focus()
            udtReg.Value = Today
            enableControls(False)
        Else
            setValuesToControls()
            enableControls(True)
            Dim rentBookDAL As TKPC.DAL.RentBookDAL = TKPC.DAL.RentBookDAL.getInstance
            Dim ds As DataSet = rentBookDAL.getRentBookListByBarcode(0, txtBarcode.Text)
            If ds.Tables(0).Rows.Count > 0 Then
                tsbtDelete.Enabled = False
                txtBarcode.Enabled = False
                txtBarcode.ReadOnly = True
                btEdit.Enabled = False
            End If
        End If
        cbType.SelectedIndex = 0
        'If loginAccess = "1" Then
        '    btEdit.Enabled = True
        'Else
        '    btEdit.Enabled = False
        'End If
    End Sub
    Private Sub enableControls(ByVal flag As Boolean)
        tsbtDelete.Enabled = flag
        tsbtDuplicate.Enabled = flag
        btEdit.Enabled = flag
    End Sub
    Private Sub setValuesToControls()
        txtBarcode.Text = BookBarcodeEnt.barcode
        Dim status As String = BookBarcodeEnt.status
        If status = "A" Or status = "대출가능" Then
            status = "대출가능"
        ElseIf status = "R" Or status = "대출중" Then
            status = "대출중"
        Else
            status = "분실"
        End If

        txtStatus.Text = status
        If BookBarcodeEnt.status = "분실" Then
            chkLost.Checked = True
        End If
        ucPrice.Value = BookBarcodeEnt.price
        If BookBarcodeEnt.purchaseOrDonate = BOOK_TYPE_PURCHASE Then
            rbtPurchase.Checked = True
        Else
            rbtDonate.Checked = True
        End If
        txtSource.Text = BookBarcodeEnt.purchaseOrDonateSource
        udtReg.Value = BookBarcodeEnt.purchaseOrDonateDate
        txtNote.Text = BookBarcodeEnt.note
    End Sub
    Private Sub btnExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExit.Click
        Me.Close()
        Me.Dispose()
    End Sub
    Private Function setEntityValue() As TKPC.Entity.BookBarcodeEnt
        setEntityValue = New TKPC.Entity.BookBarcodeEnt
        setEntityValue.barcodeID = lblID.Text
        setEntityValue.bookID = lblBookID.Text
        setEntityValue.barcode = txtBarcode.Text

        If txtStatus.Text = "대출가능" Then
            setEntityValue.status = BOOK_STATUS_A
        ElseIf txtStatus.Text = "대출중" Then
            setEntityValue.status = BOOK_STATUS_R
        Else
            setEntityValue.status = BOOK_STATUS_L
        End If

        If chkLost.Checked = True Then
            setEntityValue.status = BOOK_STATUS_L 'Lost
        Else
            setEntityValue.status = BOOK_STATUS_A  'Available
        End If

        setEntityValue.price = ucPrice.Value
        If rbtPurchase.Checked = True Then
            setEntityValue.purchaseOrDonate = BOOK_TYPE_PURCHASE
        Else
            setEntityValue.purchaseOrDonate = BOOK_TYPE_DONATE
        End If
        setEntityValue.purchaseOrDonateSource = txtSource.Text
        setEntityValue.purchaseOrDonateDate = udtReg.Value
        setEntityValue.note = txtNote.Text
        setEntityValue.lastUpdateDate = Today.Date
    End Function
    Private Sub tsbtSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbtSave.Click
        If txtBarcode.Text = String.Empty Then
            MessageBox.Show("Error! Please enter a barcode.")
            txtBarcode.Focus()
            Exit Sub
        End If

        Dim myMatch As Match = System.Text.RegularExpressions.Regex.Match(txtBarcode.Text, BARCODE_REGEX)
        If myMatch.Success = False Then
            MessageBox.Show("Error! Please enter a valid barcode.")
            txtBarcode.Focus()
            Exit Sub
        End If

        Dim bookDAL As TKPC.DAL.BookDAL
        Dim bookPrintDAL As TKPC.DAL.BarcodePrintDAL

        Try
            Cursor.Current = Cursors.WaitCursor
            bookDAL = TKPC.DAL.BookDAL.getInstance()
            bookPrintDAL = TKPC.DAL.BarcodePrintDAL.getInstance()
            Dim numberOfUpdatedRow As Integer = 0

            If viewMode = VIEW_MODE_ADD_NEW Then
                Dim barcode As String = setEntityValue().barcode
                Dim barcodeAlreadyExisted As Integer = bookDAL.checkIfBarcodeExists(barcode)

                If barcodeAlreadyExisted = 0 Then
                    numberOfUpdatedRow = bookDAL.insertBookBarcodeRecord(setEntityValue())
                    'Just in case that a barcode was already saved in [Barcode For Print] table.
                    bookPrintDAL.deleteRecordFromBarcodeForPrint(barcode)
                Else
                    MessageBox.Show("The generated barcode already was created in database. Please change it again.")
                End If

            Else
                numberOfUpdatedRow = bookDAL.updateBookBarcodeRecord(setEntityValue())
            End If

            If numberOfUpdatedRow = 1 Then
                MessageBox.Show("Barcode record has been successfully saved.")

                If lblID.Text = "ID" Then
                    lblID.Text = m_DBUtil.getMaxNumber("Book Barcode", "ID")
                End If

                If viewMode = VIEW_MODE_ADD_NEW Then
                    If closingMode = False Then
                        Dim message As String = "Do you want to add another barcode?"
                        Dim Result As DialogResult
                        Dim caption As String = "Add New?"
                        Dim buttons As MessageBoxButtons = MessageBoxButtons.YesNo

                        Result = MessageBox.Show(message, caption, buttons)
                        If Result = System.Windows.Forms.DialogResult.Yes Then
                            viewMode = VIEW_MODE_ADD_NEW
                            resetControls()
                            init()
                            setPanelMenuEnabled(False, False)
                        Else
                            Me.Close()
                        End If
                        frmBookAdd.populateDetailGrid()
                    End If
                Else
                    Me.Close()
                    frmBookAdd.populateDetailGrid()
                End If
            Else
                MessageBox.Show("Barcode record was not saved. ")
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            bookDAL = Nothing
            Cursor.Current = Cursors.Default
            'MDITKPC.utexMDI.Enabled = True
        End Try
    End Sub
    Private Sub resetControls()
        txtBarcode.Text = String.Empty
        lblID.Text = "ID"
        ucPrice.Text = "0"
        txtNote.Text = String.Empty
        txtSource.Text = String.Empty
        txtStatus.Text = String.Empty
    End Sub
    Private Sub ucPrice_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles ucPrice.GotFocus
        HighlightControl(ucPrice)
    End Sub

    Private Sub ucPrice_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles ucPrice.LostFocus
        UnHighlightControl(ucPrice)
    End Sub

    Private Sub txtSource_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtSource.GotFocus
        HighlightControl(txtSource)
        If whichIME = 0 Then
            whichIME = SwitchIME(hKrLayoutId, KbdKr)
        End If
    End Sub

    Private Sub txtSource_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtSource.LostFocus
        UnHighlightControl(txtSource)
    End Sub

    Private Sub txtNote_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtNote.GotFocus
        HighlightControl(txtNote)
    End Sub

    Private Sub txtNote_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtNote.LostFocus
        UnHighlightControl(txtNote)
    End Sub

    Private Sub btEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btEdit.Click
        If viewMode = VIEW_MODE_DETAIL Then
            txtBarcode.Text = m_DBUtil.getBarcode(BookTypeID, "")
        End If
    End Sub

    Private Sub fillGrid()
        Dim rentBookDAL As TKPC.DAL.RentBookDAL = TKPC.DAL.RentBookDAL.getInstance()
        Dim ds As DataSet

        Try
            ds = rentBookDAL.getRentBookListByBarcode(cbType.SelectedIndex, txtBarcode.Text)

            If ds IsNot Nothing Then
                Dim bs As BindingSource = New BindingSource
                bs.DataSource = ds.Tables(0)

                totalNumberOfRows = ds.Tables(0).Rows.Count

                If totalNumberOfRows > 0 Then
                    MDITKPC.tspbMDI.Maximum = ds.Tables(0).Rows.Count
                    MDITKPC.tspbMDI.Visible = True
                End If

                resetGrid()
                ugList.DataSource = bs

                'tsbtExcel.Enabled = True
            Else
                'tsbtExcel.Enabled = False
            End If
        Catch ex As Exception
        Finally
            rentBookDAL = Nothing
            ds = Nothing
        End Try
    End Sub

    Private Sub resetGrid()
        With ugList
            .DisplayLayout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.ResizeAllColumns
            .DisplayLayout.Bands(0).Columns("Rent Book ID").Hidden = True
            .DisplayLayout.Bands(0).Columns("Barcode ID").Hidden = True
            .DisplayLayout.Bands(0).Columns("Person ID").Hidden = True
            .DisplayLayout.Bands(0).Columns("Book ID").Hidden = True
            .DisplayLayout.Bands(0).Columns("선택").Hidden = True
            .DisplayLayout.Bands(0).Columns("반납일").Width = 60
            .DisplayLayout.Bands(0).Columns("대출일").Width = 60
            .DisplayLayout.Bands(0).Columns("대출자").Width = 60
            .DisplayLayout.Bands(0).Columns("바코드").Width = 60
            .DisplayLayout.Bands(0).Columns("바코드").Hidden = True
            .DisplayLayout.Bands(0).Columns("도서명").Width = 150
            .DisplayLayout.Bands(0).Columns("도서명").Hidden = True
            .DisplayLayout.Bands(0).Columns("책 분류명").Width = 90
            .DisplayLayout.Bands(0).Columns("책 분류명").Hidden = True
            .DisplayLayout.Bands(0).Columns("소제목").Hidden = True
            .DisplayLayout.Bands(0).Columns("저자").Width = 110
            .DisplayLayout.Bands(0).Columns("저자").Hidden = True
            .DisplayLayout.Bands(0).Columns("출판사").Width = 80
            .DisplayLayout.Bands(0).Columns("출판사").Hidden = True
            .DisplayLayout.Bands(0).Columns("분실").Width = 50
            .DisplayLayout.Bands(0).Columns("벌금").Width = 50
            .DisplayLayout.Bands(0).Columns("비고").Width = 150
        End With
    End Sub

    Private Sub chkLost_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkLost.Click
        If chkLost.Checked = True Then
            txtStatus.Text = "분실"
        Else
            txtStatus.Text = "대출가능"
        End If
    End Sub

    Private Sub cbType_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbType.SelectedIndexChanged
        fillGrid()
    End Sub

    Private Sub btPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btPrint.Click
        ugpdRent.Header.TextCenter = txtTitle.Text + " (" + txtBarcode.Text + ") " + cbType.SelectedText
        ugpdRent.Header.Appearance.FontData.Underline = Infragistics.Win.DefaultableBoolean.True
        ugpdRent.Header.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True
        uppdRent.ShowDialog()
    End Sub

    Private Sub btExcel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btExcel.Click
        Cursor.Current = Cursors.WaitCursor
        Try
            Dim theFile As String = Application.StartupPath + "\\" + BOOK_LIST_EXCEL
            Me.ugExcel.Export(Me.ugList, theFile)
            Process.Start(theFile)

        Catch ex As Exception
            MessageBox.Show(ex.Message + " If the file called " + BOOK_LIST_EXCEL + " is open, please close it and try again.")
        Finally
            Cursor.Current = Cursors.Default
        End Try
    End Sub

    Private Sub tsbtDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbtDelete.Click
        Dim rentBookDAL As TKPC.DAL.RentBookDAL = TKPC.DAL.RentBookDAL.getInstance
        Dim bookDAL As TKPC.DAL.BookDAL = TKPC.DAL.BookDAL.getInstance

        Try
            Dim ds As DataSet = rentBookDAL.getRentBookListByBarcode(0, lblBarcode.Text)
            If ds.Tables(0).Rows.Count = 0 Or ds Is Nothing Then
                Dim response As MsgBoxResult = MsgBox("Are you sure you want to delete the record?", MsgBoxStyle.YesNo, "Delete Confirmation")
                If response = MsgBoxResult.Yes Then
                    Dim deletedRecord As Integer = bookDAL.deleteBookBarcodeRecordByBarcode(lblBarcode.Text, lblID.Text)
                    If deletedRecord >= 1 Then
                        MessageBox.Show("The barcode record has been successfully deleted.")
                        frmBookAdd.populateDetailGrid()
                        Me.Close()
                        'viewMode = VIEW_MODE_ADD_NEW
                        'init()
                    Else
                        MessageBox.Show("The barcode record was not deleted.")
                    End If
                End If
            Else
                MessageBox.Show("The barcode information can't be deleted because rent records were made by the barcode.")
            End If
        Catch ex As Exception
        Finally
            rentBookDAL = Nothing
        End Try
    End Sub
End Class