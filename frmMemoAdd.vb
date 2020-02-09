Public Class frmMemoAdd
    Dim memoEnt As TKPC.Entity.MemoEnt
    Public viewMode As Integer

    Private Sub btnExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExit.Click
        closeForm(Me)
    End Sub

    Private Sub tsbtSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbtSave.Click
        Dim memoDAL As TKPC.DAL.MemoDAL = TKPC.DAL.MemoDAL.getInstance()
        Try
            Cursor.Current = Cursors.WaitCursor
            Dim numberOfUpdatedRow As Integer = 0
            memoEnt.note = utxtMemo.Text
            memoEnt.type = MEMO_TYPE_BOOK

            If viewMode = VIEW_MODE_ADD_NEW Then
                numberOfUpdatedRow = memoDAL.insertRecord(memoEnt)
            Else
                numberOfUpdatedRow = memoDAL.updateRecord(memoEnt)
            End If

            If numberOfUpdatedRow = 0 Then
                MessageBox.Show("Memo record was not saved. ")
            Else
                MessageBox.Show("Memo record has been successfully saved.")
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            memoDAL = Nothing
            Cursor.Current = Cursors.Default
        End Try

    End Sub

    Private Sub frmMemoAdd_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim memoDAL As TKPC.DAL.MemoDAL = TKPC.DAL.MemoDAL.getInstance()
        memoEnt = memoDAL.getMemo(MEMO_TYPE_BOOK)
        If memoEnt.note Is Nothing Then
            viewMode = VIEW_MODE_ADD_NEW
        Else
            viewMode = VIEW_MODE_DETAIL
        End If
        utxtMemo.Text = memoEnt.note
    End Sub

    Private Sub utxtMemo_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles utxtMemo.GotFocus
        If whichIME = 0 Then
            whichIME = SwitchIME(hKrLayoutId, KbdKr)
        End If
    End Sub
End Class