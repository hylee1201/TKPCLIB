Public Class frmCalendar

    Private Sub frmCalendar_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Show()
        umCalMulti.ResizeMode = Infragistics.Win.UltraWinSchedule.ResizeMode.BaseOnControlSize
    End Sub

    Private Sub btnExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExit.Click
        Me.Close()
    End Sub

    Private Sub tsbtPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbtPrint.Click
        uppdCal.ShowDialog()
    End Sub
End Class