Imports Infragistics.Win.UltraWinGrid

Public Class frmBookReserveList
    Private totalNumberOfRows As Integer = 0
    Public bookID As String = ""
    Public bookName As String = ""
    Public personID As String = ""
    Public parentName As String = ""
    Public barcode As String = ""

    Private Sub fromBookReserveList_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        With ugList
            .DisplayLayout.Bands(0).Columns("ID").Width = 50
            .DisplayLayout.Bands(0).Columns("ID").Hidden = True
            .DisplayLayout.Bands(0).Columns("Book ID").Width = 50
            .DisplayLayout.Bands(0).Columns("Book ID").Hidden = True
            .DisplayLayout.Bands(0).Columns("Person ID").Width = 50
            .DisplayLayout.Bands(0).Columns("Person ID").Hidden = True
            .DisplayLayout.Bands(0).Columns("이름").Width = 80
            .DisplayLayout.Bands(0).Columns("이름").CellActivation = Activation.NoEdit
            .DisplayLayout.Bands(0).Columns("집 전화").Width = 100
            .DisplayLayout.Bands(0).Columns("집 전화").CellActivation = Activation.NoEdit
            .DisplayLayout.Bands(0).Columns("예약일").Width = 100
            .DisplayLayout.Bands(0).Columns("예약일").CellActivation = Activation.NoEdit
            .Text = bookName + " (예약자 명단)"
        End With
        fillGrid()
    End Sub

    Private Sub fillGrid()
        Dim reserveBookDAL As TKPC.DAL.ReserveBookDAL = Nothing
        Dim ds As DataSet = Nothing

        Try
            reserveBookDAL = TKPC.DAL.ReserveBookDAL.getInstance()
            ds = reserveBookDAL.getReserveBookList(0, bookID)

            If ds IsNot Nothing Then
                totalNumberOfRows = ds.Tables(0).Rows.Count

                Dim bs As BindingSource = New BindingSource
                bs.DataSource = ds.Tables(0)
                ugList.DataSource = bs
            End If
        Catch
        Finally
            reserveBookDAL = Nothing
            ds = Nothing
        End Try
    End Sub

    Private Sub btnExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExit.Click
        closeForm(Me)
    End Sub
End Class