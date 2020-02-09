Imports Infragistics.Win.UltraWinGrid

Public Class frmReserveList

    Private Sub frmReserveList_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Show()
        With ugList
            .DisplayLayout.Bands(0).Columns("ID").Hidden = True
            .DisplayLayout.Bands(0).Columns("Book ID").Hidden = True
            .DisplayLayout.Bands(0).Columns("Person ID").Hidden = True
            .DisplayLayout.Bands(0).Columns("이름").Width = 50
            .DisplayLayout.Bands(0).Columns("이름").CellActivation = Activation.NoEdit
            .DisplayLayout.Bands(0).Columns("성별").Width = 30
            .DisplayLayout.Bands(0).Columns("성별").CellActivation = Activation.NoEdit
            .DisplayLayout.Bands(0).Columns("직분").Width = 40
            .DisplayLayout.Bands(0).Columns("직분").CellActivation = Activation.NoEdit
            .DisplayLayout.Bands(0).Columns("집 전화").Width = 100
            .DisplayLayout.Bands(0).Columns("집 전화").CellActivation = Activation.NoEdit
            .DisplayLayout.Bands(0).Columns("도서명").Width = 400
            .DisplayLayout.Bands(0).Columns("도서명").CellActivation = Activation.NoEdit
            .DisplayLayout.Bands(0).Columns("바코드").Width = 80
            .DisplayLayout.Bands(0).Columns("바코드").CellActivation = Activation.NoEdit
            .DisplayLayout.Bands(0).Columns("출판사").Width = 150
            .DisplayLayout.Bands(0).Columns("출판사").CellActivation = Activation.NoEdit
            .DisplayLayout.Bands(0).Columns("저자").Width = 150
            .DisplayLayout.Bands(0).Columns("저자").CellActivation = Activation.NoEdit
            .DisplayLayout.Bands(0).Columns("예약일").Width = 90
            .DisplayLayout.Bands(0).Columns("예약일").CellActivation = Activation.NoEdit
            .DisplayLayout.Override.RowAppearance.TextVAlign = Infragistics.Win.VAlign.Middle
        End With
        fillGrid()
    End Sub

    Private Sub fillGrid()
        Dim reserveBookDAL As TKPC.DAL.ReserveBookDAL = TKPC.DAL.ReserveBookDAL.getInstance()
        Dim ds As DataSet
        Dim bs As BindingSource
        Dim totalNumberOfRows As Integer = 0

        Try
            ds = reserveBookDAL.getReserveList()

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
                    .DataSource = bs
                End With

                tsbtExcel.Enabled = True
            Else
                tsbtExcel.Enabled = False
            End If
        Catch ex As Exception
        Finally
            ds = Nothing
            reserveBookDAL = Nothing
            bs = Nothing
        End Try
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

    Private Sub btnExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExit.Click
        closeForm(Me)
    End Sub

    Private Sub tsbtExcel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbtExcel.Click
        Cursor.Current = Cursors.WaitCursor
        Try
            Dim theFile As String = Application.StartupPath + "\\" + RESERVE_LIST_EXCEL
            Me.ugExcel.Export(Me.ugList, theFile)
            Process.Start(theFile)

        Catch ex As Exception
            MessageBox.Show(ex.Message + " If the file called " + RESERVE_LIST_EXCEL + " is open, please close it and try again.")
        Finally
            Cursor.Current = Cursors.Default
        End Try
    End Sub

    Private Sub tsbtPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbtPrint.Click
        ugpdRent.Header.TextCenter = ugList.Text
        ugpdRent.Header.Appearance.FontData.Underline = Infragistics.Win.DefaultableBoolean.True
        ugpdRent.Header.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True
        uppdRent.ShowDialog()
    End Sub

    Private Sub tsbtRefresh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbtRefresh.Click
        fillGrid()
    End Sub
End Class