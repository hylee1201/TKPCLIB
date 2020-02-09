Public Class frmBookRentHistory
    Private totalNumberOfRows As Integer = 0
    Public barcode As String = String.Empty
    Public bookFlag As String = "B"
    Public flag As Integer = 3
    Public bookID As String = String.Empty
    Public fromWhere As String = String.Empty

    Private Sub frmBookRentHistory_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        RentListLoadedFlag = False
    End Sub

    Private Sub frmBookRentHistory_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Show()
        fillGrid(bookID)
        RentListLoadedFlag = True
    End Sub
    Private Sub fillGrid(ByVal searchWord As String)
        Dim rentBookDAL As TKPC.DAL.RentBookDAL = TKPC.DAL.RentBookDAL.getInstance()
        Dim ds As DataSet
        Dim bs As BindingSource
        totalNumberOfRows = 0

        Try
            ds = rentBookDAL.getRentBookList(flag, searchWord)

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
                    .DisplayLayout.Bands(0).Columns("소제목").Hidden = True
                    .DisplayLayout.Bands(0).Columns("책 분류명").Hidden = True
                    .DisplayLayout.Bands(0).Columns("대출일").Width = 80
                    If fromWhere = "frmReturnAdd" Then
                        .DisplayLayout.Bands(0).Columns("반납일").Hidden = True
                    End If
                    .DisplayLayout.Bands(0).Columns("반납일").Width = 80
                    .DisplayLayout.Bands(0).Columns("선택").Hidden = True
                    .DisplayLayout.Bands(0).Columns("바코드").Width = 60
                    .DisplayLayout.Bands(0).Columns("대출자").Width = 60
                    .DisplayLayout.Bands(0).Columns("도서명").Width = 150
                    .DisplayLayout.Bands(0).Columns("저자").Hidden = True
                    .DisplayLayout.Bands(0).Columns("출판사").Hidden = True
                    .DisplayLayout.Bands(0).Columns("분실").Width = 50
                    .DisplayLayout.Bands(0).Columns("벌금").Width = 50
                    .DisplayLayout.Bands(0).Columns("비고").Width = 150
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

    Public Sub tsbtRefresh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbtRefresh.Click
        flag = 4
        fillGrid("")
    End Sub

    Private Sub ugList_DoubleClickRow(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinGrid.DoubleClickRowEventArgs) Handles ugList.DoubleClickRow
        If fromWhere = "frmReturnAdd" Then
            If e.Row.Index >= 0 Then
                If e.Row.Cells("바코드").Value IsNot Nothing Then
                    frmReturnAdd.txtBarcode.Text = e.Row.Cells("바코드").Value
                    frmRentAdd.txtBarcode.Focus()
                    closeForm(Me)
                End If
            End If
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
        uppdRent.ShowDialog()
    End Sub
End Class