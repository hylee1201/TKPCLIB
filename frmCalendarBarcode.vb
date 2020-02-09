Public Class frmCalendarBarcode

    Private Sub ultraMView_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub ultraMonthView_BeforeMonthScroll(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinSchedule.BeforeMonthScrollEventArgs) Handles ultraMonthView.BeforeMonthScroll

    End Sub

    Private Sub frmCalendarBarcode_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Show()
        With ugList
            .DisplayLayout.Bands(0).Columns("바코드").Width = 70
            .DisplayLayout.Bands(0).Columns("데이터 생성일").Width = 80
            .DisplayLayout.Bands(0).Columns("도서명").Width = 350
            .DisplayLayout.Bands(0).Columns("저자").Width = 120
            .DisplayLayout.Bands(0).Columns("출판사").Width = 120
            .DisplayLayout.Override.RowAppearance.TextVAlign = Infragistics.Win.VAlign.Middle
        End With
    End Sub

    Private Sub btnExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExit.Click
        closeForm(Me)
    End Sub
End Class