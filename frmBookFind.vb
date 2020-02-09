Public Class frmBookFind
    Public author As String = ""
    Private printHeader As String = "모든 도서 목록"

    Private Sub btnExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExit.Click
        Me.Close()
        Me.Dispose()
    End Sub

    Private Sub frmBookFind_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Show()
        printHeader += " (" + author + ")"
        setUpGrid()
        populateAuthorGrid()
    End Sub
    Private Sub setUpGrid()
        With ugAuthor
            .DisplayLayout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.ResizeAllColumns
            .DisplayLayout.Bands(0).Columns("Book ID").Hidden = True
            .DisplayLayout.Bands(0).Columns("Barcode ID").Hidden = True
            .DisplayLayout.Bands(0).Columns("ISBN").Hidden = True
            .DisplayLayout.Bands(0).Columns("선택").Hidden = True
            .DisplayLayout.Bands(0).Columns("현재상태").Hidden = True
            .DisplayLayout.Bands(0).Columns("소제목").Hidden = True
            .DisplayLayout.Bands(0).Columns("바코드").Width = 55
            .DisplayLayout.Bands(0).Columns("도서명").Width = 160
            .DisplayLayout.Bands(0).Columns("책 분류명").Width = 65
            .DisplayLayout.Bands(0).Columns("저자").Width = 60
            .DisplayLayout.Bands(0).Columns("출판사").Width = 60
            .DisplayLayout.Bands(0).Columns("비고").Hidden = True
            .DisplayLayout.Bands(0).Columns("구매/기증").Hidden = True
            .DisplayLayout.Bands(0).Columns("구매/기증일").Hidden = True
            .DisplayLayout.Bands(0).Columns("구매/기증 경로").Hidden = True
            .DisplayLayout.Bands(0).Columns("저장일").Hidden = False
            .DisplayLayout.Bands(0).Columns("저장일").Width = 70
            .DisplayLayout.Bands(0).Columns("Book Type ID").Hidden = True
            .DisplayLayout.Bands(0).Columns("구매가격").Hidden = True
            .DisplayLayout.Bands(0).Columns("비고").Hidden = True
            .DisplayLayout.Bands(0).Columns("대출자").Hidden = True
            .DisplayLayout.Bands(0).Columns("대출일").Hidden = True
            .DisplayLayout.Bands(0).Columns("엮은이").Hidden = True
            .DisplayLayout.Bands(0).Columns("생성일").Hidden = False
            .DisplayLayout.Bands(0).Columns("생성일").Width = 70
        End With
    End Sub

    Private Function populateAuthorGrid() As Integer
        Dim bookDAL As TKPC.DAL.BookDAL = TKPC.DAL.BookDAL.getInstance()
        Dim searchWords As String = String.Empty
        Dim ds As DataSet = Nothing

        Try
            If author <> "" Then
                Dim authors As String() = author.Split(",")
                For i As Integer = 0 To authors.Length - 1
                    searchWords += authors(0)
                    If i <> authors.Length - 1 Then
                        searchWords += ","
                    End If
                Next
                ds = bookDAL.getAuthorBookList(searchWords)

                If ds.Tables(0).Rows.Count = 0 Then
                    ugAuthor.DataSource = Nothing
                Else
                    ugAuthor.DataSource = ds
                End If
            Else
                ugAuthor.DataSource = Nothing
            End If

        Catch ex As Exception
            MessageBox.Show("Error at populateAuthorDropdown() : " + ex.Message())
        Finally
            bookDAL = Nothing
            ds = Nothing
        End Try
    End Function
    Private Sub ugAuthor_DoubleClickRow(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinGrid.DoubleClickRowEventArgs) Handles ugAuthor.DoubleClickRow
        If e.Row.Index >= 0 Then
            If e.Row.Cells("바코드").Value IsNot Nothing Then
                With frmBookAdd
                    .cbFind.SelectedIndex = 0
                    .txtBarcode.Text = e.Row.Cells("바코드").Value
                    .cbFind.SelectedIndex = 1
                    .txtBarcode.Text = String.Empty
                End With
                Me.Close()
            End If
        End If
    End Sub

    Private Sub tsbtExcel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbtExcel.Click
        Cursor.Current = Cursors.WaitCursor
        Try
            Dim theFile As String = Application.StartupPath + "\\" + BOOK_LIST_EXCEL
            Me.ugExcel.Export(Me.ugAuthor, theFile)
            Process.Start(theFile)

        Catch ex As Exception
            MessageBox.Show(ex.Message + " If the file called " + BOOK_LIST_EXCEL + " is open, please close it and try again.")
        Finally
            Cursor.Current = Cursors.Default
        End Try
    End Sub

    Private Sub tsbtPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbtPrint.Click
        With ugpdRent
            .Header.TextCenter = printHeader
            .Header.Appearance.FontData.Underline = Infragistics.Win.DefaultableBoolean.True
            .Header.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True
            uppdRent.ShowDialog()
        End With
    End Sub
End Class