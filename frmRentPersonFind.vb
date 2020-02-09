Public Class frmRentPersonFind
    Public callingForm As frmRentAdd
    Private totalNumberOfRows As Integer = 0
    Public telNumber As String = String.Empty
    Public flag As Integer = 0

    Private Sub frmRentPersonFind_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Show()
        With ugList
            .DisplayLayout.Bands(0).Columns("ID").Width = 50
            .DisplayLayout.Bands(0).Columns("이름").Width = 100
            .DisplayLayout.Bands(0).Columns("성별").Width = 50
            .DisplayLayout.Bands(0).Columns("직분").Width = 70
            .DisplayLayout.Bands(0).Columns("집 전화").Width = 110
            .DisplayLayout.Bands(0).Columns("다른 전화").Width = 110
        End With

        fillGrid()
    End Sub

    Private Sub fillGrid()
        Dim personDAL As TKPC.DAL.PersonDAL = Nothing
        Dim ds As DataSet = Nothing

        Try
            personDAL = TKPC.DAL.PersonDAL.getInstance()
            ds = personDAL.getNameList()

            If ds IsNot Nothing Then
                totalNumberOfRows = ds.Tables(0).Rows.Count

                If totalNumberOfRows > 0 Then
                    MDITKPC.tspbMDI.Maximum = totalNumberOfRows
                    MDITKPC.tspbMDI.Visible = True
                End If

                Dim bs As BindingSource = New BindingSource
                bs.DataSource = ds.Tables(0)

                bnList.BindingSource = bs
                ugList.DataSource = bs
            End If
        Catch
        Finally
            personDAL = Nothing
            ds = Nothing
        End Try
    End Sub

    Private Sub ugList_DoubleClickRow(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinGrid.DoubleClickRowEventArgs) Handles ugList.DoubleClickRow
        If e.Row.Index >= 0 Then
            If e.Row.Cells("ID").Value IsNot Nothing Then
                callingForm.lblPersonID.Text = e.Row.Cells("ID").Value
                callingForm.txtPersonName.Text = e.Row.Cells("이름").Value
                callingForm.txtID.Text = e.Row.Cells("ID").Value
                callingForm.txtTel.Text = e.Row.Cells("집 전화").Value
                callingForm.txtName.Text = e.Row.Cells("이름").Value
                Me.Close()
            End If
        End If
    End Sub

    Private Sub btnExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExit.Click
        Me.Close()
    End Sub

    Private Sub tsbtRefresh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbtRefresh.Click
        fillGrid()
    End Sub

    Private Sub ugList_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles ugList.Enter
        If whichIME = 0 Then
            whichIME = SwitchIME(hKrLayoutId, KbdKr)
        End If
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

    Private Sub tsbtAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbtAdd.Click
        Me.Close()
        frmPersonAdd.fromWhichForm = FROM_RENT_ADD
        openForm(MDITKPC, frmPersonAdd)
    End Sub
End Class