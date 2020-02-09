Public Class frmPersonRentHistory
    Private totalNumberOfRows As Integer = 0
    Public personID As String = String.Empty
    Public caption As String = String.Empty
    Public fromWhere As String = ""

    Private Sub frmPersonRentHistory_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        RentListLoadedFlag = False
    End Sub

    Private Sub frmPersonRentHistory_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Show()
        fillGrid(1, "")
        RentListLoadedFlag = True
        ugList.Text = caption + " - 미반납 대출 기록"
    End Sub
    Private Sub fillGrid(ByVal flag As Integer, ByVal searchWord As String)
        Dim rentBookDAL As TKPC.DAL.RentBookDAL = TKPC.DAL.RentBookDAL.getInstance()

        Dim ds As DataSet = rentBookDAL.getRentBookListByPersonID(flag, personID)

        If ds IsNot Nothing Then
            Dim bs As BindingSource = New BindingSource
            bs.DataSource = ds.Tables(0)

            totalNumberOfRows = ds.Tables(0).Rows.Count

            If totalNumberOfRows > 0 Then
                MDITKPC.tspbMDI.Maximum = ds.Tables(0).Rows.Count
                MDITKPC.tspbMDI.Visible = True
            End If

            bnList.BindingSource = bs

            With ugList
                .DisplayLayout.Bands(0).Columns("Rent Book ID").Hidden = True
                .DisplayLayout.Bands(0).Columns("Barcode ID").Hidden = True
                .DisplayLayout.Bands(0).Columns("Person ID").Hidden = True
                .DisplayLayout.Bands(0).Columns("Book ID").Hidden = True
                .DisplayLayout.Bands(0).Columns("대출자").Hidden = True
                If fromWhere = "frmRentAdd" Then
                    .DisplayLayout.Bands(0).Columns("선택").Hidden = True
                End If
                .DisplayLayout.Bands(0).Columns("반납일").Width = 76
                .DisplayLayout.Bands(0).Columns("대출일").Width = 76
                .DisplayLayout.Bands(0).Columns("바코드").Width = 60
                .DisplayLayout.Bands(0).Columns("도서명").Width = 150
                .DisplayLayout.Bands(0).Columns("책 분류명").Width = 90
                .DisplayLayout.Bands(0).Columns("저자").Width = 110
                .DisplayLayout.Bands(0).Columns("출판사").Width = 80
                .DisplayLayout.Bands(0).Columns("분실").Width = 50
                .DisplayLayout.Bands(0).Columns("벌금").Width = 50
                .DisplayLayout.Bands(0).Columns("비고").Width = 120
                .DataSource = bs
            End With
            tsbtExcel.Enabled = True
        Else
            tsbtExcel.Enabled = False
        End If
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
        ugList.Text = caption + " - 모든 대출 기록"
        fillGrid(0, "")
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

    Private Sub AllBooksToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AllBooksToolStripMenuItem.Click
        fillGrid(0, "")
        RentListLoadedFlag = True
        ugList.Text = caption + " - 모든 대출 기록"
    End Sub

    Private Sub 미반납대출기록ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 미반납대출기록ToolStripMenuItem.Click
        fillGrid(1, "")
        RentListLoadedFlag = True
        ugList.Text = caption + " - 미반납 대출 기록"
    End Sub
End Class