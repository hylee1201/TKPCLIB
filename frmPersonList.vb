Imports Infragistics.Win.UltraWinGrid

Public Class frmPersonList
    Private totalNumberOfRows As Integer = 0
    Private printHeader As String = ""

    Private Sub frmPersonList_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        tsbtRefresh_Click(sender, e)
        If whichIME = 0 Then
            whichIME = SwitchIME(hKrLayoutId, KbdKr)
        End If
    End Sub

    Private Sub frmPersonList_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        PersonListLoadedFlag = False
    End Sub

    Private Sub frmPersonList_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Show()
        With ugList
            .DisplayLayout.Bands(0).Columns("ID").Width = 40
            .DisplayLayout.Bands(0).Columns("ID").CellActivation = Activation.NoEdit
            .DisplayLayout.Bands(0).Columns("이름").Width = 65
            .DisplayLayout.Bands(0).Columns("이름").CellActivation = Activation.NoEdit
            .DisplayLayout.Bands(0).Columns("성별").Width = 40
            .DisplayLayout.Bands(0).Columns("성별").CellActivation = Activation.NoEdit
            .DisplayLayout.Bands(0).Columns("직분").Width = 40
            .DisplayLayout.Bands(0).Columns("직분").CellActivation = Activation.NoEdit
            .DisplayLayout.Bands(0).Columns("집 전화").Width = 100
            .DisplayLayout.Bands(0).Columns("집 전화").CellActivation = Activation.NoEdit
            .DisplayLayout.Bands(0).Columns("다른 전화").Width = 100
            .DisplayLayout.Bands(0).Columns("다른 전화").CellActivation = Activation.NoEdit
            .DisplayLayout.Bands(0).Columns("거리명").Width = 250
            .DisplayLayout.Bands(0).Columns("거리명").CellActivation = Activation.NoEdit
            .DisplayLayout.Bands(0).Columns("도시명").Width = 110
            .DisplayLayout.Bands(0).Columns("도시명").CellActivation = Activation.NoEdit
            .DisplayLayout.Bands(0).Columns("이메일").Width = 200
            .DisplayLayout.Bands(0).Columns("이메일").CellActivation = Activation.NoEdit
            .DisplayLayout.Bands(0).Columns("우편번호").Width = 70
            .DisplayLayout.Bands(0).Columns("우편번호").CellActivation = Activation.NoEdit
            .DisplayLayout.Bands(0).Columns("등록일").Width = 80
            .DisplayLayout.Bands(0).Columns("등록일").Hidden = True
            .DisplayLayout.Bands(0).Columns("비고").Width = 250
            .DisplayLayout.Bands(0).Columns("비고").Hidden = True
            .DisplayLayout.Bands(0).Columns("데이터 저장일").Width = 120
            .DisplayLayout.Bands(0).Columns("데이터 저장일").Hidden = True
            .DisplayLayout.Override.RowAppearance.TextVAlign = Infragistics.Win.VAlign.Middle
        End With

        fillGrid(WHOLE_LIST, "")
        PersonListLoadedFlag = True
    End Sub

    Private Sub fillGrid(ByVal flag As Integer, ByVal searchWord As String)
        Dim personDAL As TKPC.DAL.PersonDAL = TKPC.DAL.PersonDAL.getInstance()

        Dim ds As DataSet = Nothing
        Dim bs As BindingSource = Nothing

        Try
            ds = personDAL.getList(flag, searchWord, String.Empty)

            If ds IsNot Nothing Then
                bs = New BindingSource
                bs.DataSource = ds.Tables(0)

                totalNumberOfRows = ds.Tables(0).Rows.Count

                If totalNumberOfRows > 0 Then
                    MDITKPC.tspbMDI.Maximum = totalNumberOfRows
                    MDITKPC.tspbMDI.Visible = True
                End If

                bnList.BindingSource = bs
                ugList.DataSource = bs
                tsbtExcel.Enabled = True
            Else
                tsbtExcel.Enabled = False
            End If

        Catch ex As Exception
        Finally
            ds = Nothing
            bs = Nothing
            personDAL = Nothing
        End Try
    End Sub

    Private Sub tsbtExcel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles tsbtExcel.Click
        Cursor.Current = Cursors.WaitCursor
        Try
            Dim theFile As String = Application.StartupPath + "\\" + PERSON_LIST_EXCEL
            Me.ugExcel.Export(Me.ugList, theFile)
            Process.Start(theFile)

        Catch ex As Exception
            MessageBox.Show(ex.Message + " If the file called " + PERSON_LIST_EXCEL + " is open, please close it and try again.")
        Finally
            Cursor.Current = Cursors.Default
        End Try
    End Sub

    Private Sub ugList_DoubleClickRow(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinGrid.DoubleClickRowEventArgs) Handles ugList.DoubleClickRow
        If e.Row.Index >= 0 Then
            If e.Row.Cells("ID").Value IsNot Nothing Then
                Dim personID As String = e.Row.Cells("ID").Value
                Dim personEnt As TKPC.Entity.PersonEnt = New TKPC.Entity.PersonEnt
                Dim personDAL As TKPC.DAL.PersonDAL = TKPC.DAL.PersonDAL.getInstance()

                Try
                    personEnt = personDAL.getRecordByID(personID)

                    frmPersonAdd.Dispose()
                    With frmPersonAdd
                        .personEnt = personEnt
                        .viewMode = VIEW_MODE_DETAIL
                        .callingForm = Me
                        openForm(Me, frmPersonAdd)
                    End With
                    'With frmPersonAdd
                    '    .Width = 851
                    '    .Height = 695
                    '    .WindowState = FormWindowState.Normal
                    '    .viewMode = VIEW_MODE_DETAIL
                    '    .personEnt = personEnt
                    '    .ShowDialog()
                    'End With
                Catch
                Finally
                    personEnt = Nothing
                    personDAL = Nothing
                End Try
            End If
        End If
    End Sub

    Private Sub btnExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExit.Click
        closeForm(Me)
    End Sub

    Private Sub tsbtAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbtAdd.Click
        frmPersonAdd.viewMode = VIEW_MODE_ADD_NEW
        frmPersonAdd.Dispose()
        openForm(Me, frmPersonAdd)
    End Sub

    Public Sub tsbtRefresh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbtRefresh.Click
        fillGrid(WHOLE_LIST, "")
    End Sub

    Private Sub ugList_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles ugList.Enter
        If whichIME = 0 Then
            whichIME = SwitchIME(hKrLayoutId, KbdKr)
        End If
    End Sub

    Private Sub ugList_InitializeLayout(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles ugList.InitializeLayout
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
        ugpdRent.Header.TextCenter = printHeader
        ugpdRent.Header.Appearance.FontData.Underline = Infragistics.Win.DefaultableBoolean.True
        ugpdRent.Header.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True
        uppdRent.ShowDialog()
    End Sub

    Private Sub NoEmailToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NoEmailToolStripMenuItem.Click
        printHeader = "이메일이 없는 회원 목록"
        ugList.Text = "이메일이 없는 회원 목록"
        fillGrid(5, "")
    End Sub

    Private Sub AllPersonToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AllPersonToolStripMenuItem.Click
        fillGrid(WHOLE_LIST, "")
        ugList.Text = "모든 회원 목록"
    End Sub
End Class