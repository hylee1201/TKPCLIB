Imports Infragistics.Win.UltraWinGrid
Imports Infragistics.Win.UltraWinDock
Public Class frmBookReserve
    Public callingForm As frmBookAdd
    Private totalNumberOfRows As Integer = 0
    Public telNumber As String = String.Empty
    Public flag As Integer = 0
    Public bookID As String = ""
    Public bookName As String = ""

    Private Sub frmBookReserve_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Show()
        With ugList
            .DisplayLayout.Bands(0).Columns("ID").Width = 50
            .DisplayLayout.Bands(0).Columns("이름").Width = 100
            .DisplayLayout.Bands(0).Columns("성별").Width = 50
            .DisplayLayout.Bands(0).Columns("직분").Width = 70
            .DisplayLayout.Bands(0).Columns("집 전화").Width = 110
            .DisplayLayout.Bands(0).Columns("다른 전화").Width = 110
        End With

        With ugList2
            .DisplayLayout.Bands(0).Columns("선택").Width = 50
            .DisplayLayout.Bands(0).Columns("ID").Width = 50
            .DisplayLayout.Bands(0).Columns("ID").Hidden = True
            .DisplayLayout.Bands(0).Columns("Book ID").Width = 50
            .DisplayLayout.Bands(0).Columns("Book ID").Hidden = True
            .DisplayLayout.Bands(0).Columns("Person ID").Width = 50
            .DisplayLayout.Bands(0).Columns("Person ID").Hidden = True
            .DisplayLayout.Bands(0).Columns("이름").Width = 80
            .DisplayLayout.Bands(0).Columns("집 전화").Width = 100
            .DisplayLayout.Bands(0).Columns("예약일").Width = 100
        End With
        lblBookName.Text = "예약 도서명: " + bookName
        init()
    End Sub
    Private Sub init()
        fillGrid()
        fillGrid2()
    End Sub
    Private Sub fillGrid()
        Dim personDAL As TKPC.DAL.PersonDAL = Nothing
        Dim ds As DataSet = Nothing

        Try
            personDAL = TKPC.DAL.PersonDAL.getInstance()
            ds = personDAL.getNameList2(bookID)

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
    Private Sub fillGrid2()
        Dim reserveBookDAL As TKPC.DAL.ReserveBookDAL = Nothing
        Dim ds As DataSet = Nothing

        Try
            reserveBookDAL = TKPC.DAL.ReserveBookDAL.getInstance()
            ds = reserveBookDAL.getReserveBookList(0, bookID)

            If ds IsNot Nothing Then
                totalNumberOfRows = ds.Tables(0).Rows.Count

                Dim bs As BindingSource = New BindingSource
                bs.DataSource = ds.Tables(0)
                ugList2.DataSource = bs
                If totalNumberOfRows > 0 Then
                    makeButtonEnabled(True)
                Else
                    makeButtonEnabled(False)
                End If
            End If
        Catch
        Finally
            reserveBookDAL = Nothing
            ds = Nothing
        End Try
    End Sub
    Public Sub makeGridVisible(ByVal flag)
        ugList.Visible = flag
        ugList2.Visible = flag
    End Sub
    Public Sub makeButtonEnabled(ByVal flag)
        tsbtDelete.Enabled = flag
        tsbtSave.Enabled = flag
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

    Private Sub btnExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExit.Click
        Me.Close()
        Me.Dispose()
    End Sub

    Private Sub ugList_InitializeLayout(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles ugList.InitializeLayout
        ugList.DisplayLayout.Override.AllowUpdate = Infragistics.Win.DefaultableBoolean.False
    End Sub

    Private Sub ugList_DoubleClickRow(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinGrid.DoubleClickRowEventArgs) Handles ugList.DoubleClickRow
        If e.Row.Index >= 0 Then
            If e.Row.Cells("ID").Value IsNot Nothing Then
                Dim addedRow As UltraGridRow = ugList2.DisplayLayout.Bands(0).AddNew()
                Dim newCells As CellsCollection = addedRow.Cells

                newCells("ID").Value = "0"
                newCells("선택").Value = True
                newCells("Book ID").Value = bookID
                newCells("Person ID").Value = Convert.ToString(e.Row.Cells("ID").Value)
                newCells("이름").Value = Convert.ToString(e.Row.Cells("이름").Value)
                newCells("집 전화").Value = Convert.ToString(e.Row.Cells("집 전화").Value)
                newCells("예약일").Value = Today.Date
                ugList2.Update()
                makeButtonEnabled(True)

                Dim rbEnt As TKPC.Entity.ReserveBookEnt = New TKPC.Entity.ReserveBookEnt
                With rbEnt
                    .bookID = bookID
                    .personID = newCells("Person ID").Value
                    .reserveDate = newCells("예약일").Value
                    .lastUpdateDate = Today.Date
                End With
                Dim List As ArrayList = New ArrayList()
                List.Add(rbEnt)
                updateRecord(List)
                init()
            End If
        End If
    End Sub
    Private Sub ugList2_AfterRowInsert(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinGrid.RowEventArgs) Handles ugList2.AfterRowInsert
        If ugList2.Rows.Count > 0 Then
            makeButtonEnabled(True)
        End If
    End Sub
    Private Sub ugList2_AfterRowsDeleted(ByVal sender As Object, ByVal e As System.EventArgs) Handles ugList2.AfterRowsDeleted
        If ugList2.Rows.Count = 0 Then
            makeButtonEnabled(False)
        Else
            makeButtonEnabled(True)
        End If
    End Sub

    Private Sub ugList2_DoubleClickRow(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinGrid.DoubleClickRowEventArgs) Handles ugList2.DoubleClickRow
        If e.Row.Index >= 0 Then
            If e.Row.Cells("ID").Value IsNot Nothing Then
                Dim name As String = e.Row.Cells("이름").Value
                Dim response As MsgBoxResult = MsgBox("Are you sure you want to delete " + name + " from the reservation list?", MsgBoxStyle.YesNo, "Delete Confirmation")
                If response = MsgBoxResult.Yes Then
                    Dim rbEnt As TKPC.Entity.ReserveBookEnt = New TKPC.Entity.ReserveBookEnt
                    With rbEnt
                        .bookID = e.Row.Cells("Book ID").Value
                        .personID = e.Row.Cells("Person ID").Value
                        .reserveDate = e.Row.Cells("예약일").Value
                        .lastUpdateDate = Today.Date
                    End With
                    Dim List As ArrayList = New ArrayList()
                    List.Add(rbEnt)
                    deleteRecord(List)
                End If
            End If
        End If
    End Sub
    Private Sub ugList2_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles ugList2.KeyUp
        If e.KeyCode = Keys.Delete Then
            If ugList2.Rows.Count > 0 Then
                'If ugList2.ActiveRow.Cells("ID").Value Is DBNull.Value Then
                ugList2.ActiveRow.Delete()
                'End If
            End If
        End If
    End Sub

    Private Sub tsbtDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbtDelete.Click
        Dim list As ArrayList = getReserveList(1)
        If list Is Nothing Or (list IsNot Nothing And list.Count = 0) Then
            MessageBox.Show("Please choose the person by checking in the checkbox. ")
            Exit Sub
        End If

        Dim response As MsgBoxResult = MsgBox("Are you sure you want to delete the record?", MsgBoxStyle.YesNo, "Delete Confirmation")
        If response = MsgBoxResult.Yes Then
            deleteRecord(list)
        End If
    End Sub
    Private Sub deleteRecord(ByVal List As ArrayList)
        Dim reserveBookDAL As TKPC.DAL.ReserveBookDAL = Nothing
        Dim rbEnt As TKPC.Entity.ReserveBookEnt = Nothing
        Dim deletedRecords As Integer = 0

        If List IsNot Nothing And List.Count > 0 Then
            Try
                reserveBookDAL = TKPC.DAL.ReserveBookDAL.getInstance()
                For i As Integer = 0 To List.Count - 1
                    rbEnt = List.Item(i)
                    deletedRecords += reserveBookDAL.deleteRecordByID(bookID, rbEnt.personID)
                Next

                If deletedRecords >= 1 Then
                    MessageBox.Show("The " + Convert.ToString(List.Count) + " record(s) has been successfully deleted.")
                End If

            Catch ex As Exception
                MessageBox.Show("Error at deleting a record. " + ex.Message)
            Finally
                init()
                List = Nothing
                reserveBookDAL = Nothing
            End Try
        End If
    End Sub
    Private Sub updateRecord(ByVal List As ArrayList)
        If List IsNot Nothing And List.Count > 0 Then
            Dim reserveBookDAL As TKPC.DAL.ReserveBookDAL = Nothing
            Dim rbEnt As TKPC.Entity.ReserveBookEnt = Nothing
            Dim savedRecord As Integer = 0
            Try
                reserveBookDAL = TKPC.DAL.ReserveBookDAL.getInstance()
                For i As Integer = 0 To List.Count - 1
                    rbEnt = List.Item(i)
                    savedRecord += reserveBookDAL.insertRecord(rbEnt)
                    rbEnt = Nothing
                Next

                If savedRecord >= 1 Then
                    MessageBox.Show("The " + Convert.ToString(List.Count) + " record(s) has been successfully saved.")
                End If

            Catch ex As Exception
                MessageBox.Show("Error at saving a record. " + ex.Message)
            Finally
                init()
                List = Nothing
                reserveBookDAL = Nothing
            End Try
        End If
    End Sub
    Private Function getReserveList(ByVal flag As Integer) As ArrayList
        getReserveList = New ArrayList()
        Dim rbEnt As TKPC.Entity.ReserveBookEnt

        Try
            For i As Integer = 0 To ugList2.Rows.Count - 1
                rbEnt = New TKPC.Entity.ReserveBookEnt
                If flag = 0 Then 'For insert
                    If ugList2.Rows(i).Cells("ID").Value = "0" Then
                        With rbEnt
                            .bookID = ugList2.Rows(i).Cells("Book ID").Value
                            .personID = ugList2.Rows(i).Cells("Person ID").Value
                            .reserveDate = ugList2.Rows(i).Cells("예약일").Value
                            .lastUpdateDate = Today.Date
                        End With
                        getReserveList.Add(rbEnt)
                    End If
                Else 'For delete
                    If ugList2.Rows(i).Cells("선택").Value IsNot DBNull.Value Then
                        If ugList2.Rows(i).Cells("선택").Value = True Then
                            With rbEnt
                                .bookID = ugList2.Rows(i).Cells("Book ID").Value
                                .personID = ugList2.Rows(i).Cells("Person ID").Value
                                .reserveDate = ugList2.Rows(i).Cells("예약일").Value
                                .lastUpdateDate = Today.Date
                            End With
                            getReserveList.Add(rbEnt)
                        End If
                    End If
                End If
            Next i
        Catch ex As Exception
            MessageBox.Show("Error at making a list. " + ex.Message)
        Finally
            rbEnt = Nothing
        End Try

        Return getReserveList
    End Function

    Private Sub tsbtSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbtSave.Click
        Dim list As ArrayList = getReserveList(0)
        updateRecord(list)
    End Sub
End Class
