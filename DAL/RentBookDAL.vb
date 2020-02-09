Imports System.Data.SqlClient
Imports System.Text.StringBuilder
Imports System.Text

Namespace TKPC.DAL
    Public Class RentBookDAL
        Private Shared Instance As RentBookDAL

        Protected Sub New()
        End Sub

        'To make this DAL singleton to use memory efficiently
        Public Shared Function getInstance() As RentBookDAL
            ' initialize if not already done
            If Instance Is Nothing Then
                Instance = New RentBookDAL
            End If
            ' return the initialized instance of the Singleton Class
            Return Instance
        End Function 'Instance

        'This function is for a binding purpose
        Public Function getRentBookList(ByVal flag As Integer, ByVal PersonIDOrBarcode As String) As DataSet
            Dim sql As String = String.Empty
            Dim cn As SqlConnection = Nothing
            Dim cmd As SqlCommand = Nothing
            Dim da As SqlDataAdapter = Nothing
            Dim sb As StringBuilder = New StringBuilder

            getRentBookList = New DataSet
            da = New SqlDataAdapter()

            With sb
                .Append("SELECT  [Rent Book].Flag AS [선택], ")
                .Append("              [Rent Book].[Rent Book ID], ")
                .Append("              [Book Barcode].[Barcode ID], ")
                .Append("              [Person].[Person ID], ")
                .Append("              [Book].[Book ID], ")
                .Append("              [Person].[Name] AS [대출자], ")
                .Append("              [Rent Book].[Rent Date] AS [대출일], ")
                .Append("              [Book Barcode].[Barcode] AS [바코드], ")
                .Append("              [Book].[Title] AS [도서명], ")
                .Append("              [Book].[Subtitle] AS [소제목], ")
                .Append("              [Book Type].[Book Type] AS [책 분류명], ")
                .Append("              [Book].[Author] AS [저자], ")
                .Append("              [Book].[Publisher] AS [출판사], ")
                .Append("              [Return Date] AS [반납일], ")
                .Append("              [Lost] AS [분실여부], ")
                .Append("              [Penalty] AS [벌금], ")
                .Append("              [Rent Book].[Note] AS [비고] ")
                .Append("FROM [Rent Book], [Book Barcode], [Person], [Book], [Book Type] ")
                .Append("WHERE [Rent Book].[Barcode ID] = [Book Barcode].[Barcode ID] ")
                .Append("AND [Rent Book].[Person ID] = [Person].[Person ID] ")
                .Append("AND [Book Barcode].[Book ID] = [Book].[Book ID] ")
                .Append("AND [Book].[Book Type ID] = [Book Type].[Book Type ID] ")
            End With

            Select Case flag
                Case 0
                    sb.Append("AND [Rent Book].[Rent Book ID] = @RentBookID ")
                Case 1
                    sb.Append("AND [Rent Book].[Return Date] IS NULL AND [Rent Book].[Lost] = 0 AND [Person].[Person ID] = @PersonID ")
                Case 2
                    sb.Append("AND [Rent Book].[Return Date] IS NULL AND [Book Barcode].[Barcode] = @Barcode ")
                Case 3
                    sb.Append("AND [Book].[Book ID] = @BookID ")
                Case 4
                    sb.Append("AND [Rent Book].[Return Date] IS NULL ")
                Case 5
                    sb.Append("AND [Rent Book].[Return Date] IS NOT NULL ")
                Case 6
                    sb.Append("AND [Rent Book].[Return Date] IS NULL AND DATEDIFF(week, [Rent Book].[Rent Date], GETDATE()) > 3 ")
                Case 7
                    sb.Append("AND [Rent Book].[Return Date] IS NULL AND DATEDIFF(week, [Rent Book].[Rent Date], GETDATE()) <= 3 ")
                Case 8
                    sb.Append("AND DATEDIFF(day, [Rent Book].[Last Update Date], GETDATE()) = 0 ")
                Case 9
                    sb.Append("AND DATEDIFF(day, [Rent Book].[Return Date], GETDATE()) = 0 ")

            End Select
            sb.Append("ORDER BY [Book].[Title] ")

            sql = sb.ToString


            Try
                cn = New SqlConnection(m_Constant.SQL_CONSTR)

                'provider to be used when working with access database
                cn.Open()
                cmd = New SqlCommand(sql, cn)
                cmd.CommandTimeout = 0

                PersonIDOrBarcode = PersonIDOrBarcode.Trim

                Select Case flag
                    Case 0
                        cmd.Parameters.Add(New SqlParameter("@RentBookID", SqlDbType.VarChar)).Value = PersonIDOrBarcode
                    Case 1
                        cmd.Parameters.Add(New SqlParameter("@PersonID", SqlDbType.VarChar)).Value = PersonIDOrBarcode
                    Case 2
                        cmd.Parameters.Add(New SqlParameter("@Barcode", SqlDbType.VarChar)).Value = PersonIDOrBarcode
                    Case 3
                        cmd.Parameters.Add(New SqlParameter("@BookID", SqlDbType.VarChar)).Value = PersonIDOrBarcode
                End Select

                da.SelectCommand = cmd
                da.Fill(getRentBookList, "getRentBookList")

            Catch ex As Exception
                MessageBox.Show("Error at RentBookDAL.getRentBookList : " + ex.Message)
            Finally
                m_DBUtil.closeConnection(da, cn, cmd)
                sb = Nothing
            End Try
            Return getRentBookList
        End Function

        'This function is for a binding purpose
        Public Function getRentBookList2(ByVal flag As Integer, ByVal PersonIDOrBarcode As String) As DataSet
            Dim sql As String = String.Empty
            Dim cn As SqlConnection = Nothing
            Dim cmd As SqlCommand = Nothing
            Dim da As SqlDataAdapter = Nothing
            Dim sb As StringBuilder = New StringBuilder

            getRentBookList2 = New DataSet
            da = New SqlDataAdapter()

            With sb
                .Append("SELECT  [Rent Book].Flag AS [선택], ")
                .Append("              [Rent Book].[Rent Book ID], ")
                .Append("              [Book Barcode].[Barcode ID], ")
                .Append("              [Person].[Person ID], ")
                .Append("              [Book].[Book ID], ")
                .Append("              [Person].[Name] AS [대출자], ")
                .Append("              [Person].[Home Tel] AS [전화번호], ")
                .Append("              [Rent Book].[Rent Date] AS [대출일], ")
                .Append("              [Book Barcode].[Barcode] AS [바코드], ")
                .Append("              [Book].[Title] AS [도서명], ")
                .Append("              [Book].[Subtitle] AS [소제목], ")
                .Append("              [Book Type].[Book Type] AS [책 분류명], ")
                .Append("              [Book].[Author] AS [저자], ")
                .Append("              [Book].[Publisher] AS [출판사], ")
                .Append("              [Return Date] AS [반납일], ")
                .Append("              [Lost] AS [분실여부], ")
                .Append("              [Penalty] AS [벌금], ")
                .Append("              [Rent Book].[Note] AS [비고] ")
                .Append("FROM [Rent Book], [Book Barcode], [Person], [Book], [Book Type] ")
                .Append("WHERE [Rent Book].[Barcode ID] = [Book Barcode].[Barcode ID] ")
                .Append("AND [Rent Book].[Person ID] = [Person].[Person ID] ")
                .Append("AND [Book Barcode].[Book ID] = [Book].[Book ID] ")
                .Append("AND [Book].[Book Type ID] = [Book Type].[Book Type ID] ")
            End With

            Select Case flag
                Case 0
                    sb.Append("AND [Rent Book].[Rent Book ID] = @RentBookID ")
                Case 1
                    sb.Append("AND [Rent Book].[Return Date] IS NULL AND [Rent Book].[Lost] = 0 AND [Person].[Person ID] = @PersonID ")
                Case 2
                    sb.Append("AND [Rent Book].[Return Date] IS NULL AND [Book Barcode].[Barcode] = @Barcode ")
                Case 3
                    sb.Append("AND [Book].[Book ID] = @BookID ")
                Case 4
                    sb.Append("AND [Rent Book].[Return Date] IS NULL AND [Rent Book].[Lost] = 0 ")
                Case 5
                    sb.Append("AND [Rent Book].[Return Date] IS NOT NULL ")
                Case 6
                    sb.Append("AND [Rent Book].[Return Date] IS NULL AND [Rent Book].[Lost] = 0 AND DATEDIFF(day, [Rent Book].[Rent Date], GETDATE()) > 23 ")
                Case 7
                    sb.Append("AND [Rent Book].[Return Date] IS NULL AND [Rent Book].[Lost] = 0 AND DATEDIFF(week, [Rent Book].[Rent Date], GETDATE()) <= 3 ")
                Case 8
                    sb.Append("AND DATEDIFF(day, [Rent Book].[Last Update Date], GETDATE()) = 0 ")
                Case 9
                    sb.Append("AND DATEDIFF(day, [Rent Book].[Return Date], GETDATE()) = 0 ")

            End Select
            sb.Append("ORDER BY [Book].[Title] ")

            sql = sb.ToString


            Try
                cn = New SqlConnection(m_Constant.SQL_CONSTR)

                'provider to be used when working with access database
                cn.Open()
                cmd = New SqlCommand(sql, cn)
                cmd.CommandTimeout = 0

                PersonIDOrBarcode = PersonIDOrBarcode.Trim

                Select Case flag
                    Case 0
                        cmd.Parameters.Add(New SqlParameter("@RentBookID", SqlDbType.VarChar)).Value = PersonIDOrBarcode
                    Case 1
                        cmd.Parameters.Add(New SqlParameter("@PersonID", SqlDbType.VarChar)).Value = PersonIDOrBarcode
                    Case 2
                        cmd.Parameters.Add(New SqlParameter("@Barcode", SqlDbType.VarChar)).Value = PersonIDOrBarcode
                    Case 3
                        cmd.Parameters.Add(New SqlParameter("@BookID", SqlDbType.VarChar)).Value = PersonIDOrBarcode
                End Select

                da.SelectCommand = cmd
                da.Fill(getRentBookList2, "getRentBookList2")

            Catch ex As Exception
                MessageBox.Show("Error at RentBookDAL.getRentBookList2 : " + ex.Message)
            Finally
                m_DBUtil.closeConnection(da, cn, cmd)
                sb = Nothing
            End Try
            Return getRentBookList2
        End Function

        'This function is for a binding purpose
        Public Function getRentBookListByPersonID(ByVal flag As Integer, ByVal PersonID As String) As DataSet
            Dim sql As String = String.Empty
            Dim cn As SqlConnection = Nothing
            Dim cmd As SqlCommand = Nothing
            Dim da As SqlDataAdapter = Nothing
            Dim sb As StringBuilder = New StringBuilder

            getRentBookListByPersonID = New DataSet
            da = New SqlDataAdapter()

            With sb
                .Append("SELECT  [Rent Book].Flag AS [선택], ")
                .Append("              [Rent Book].[Rent Book ID], ")
                .Append("              [Book Barcode].[Barcode ID], ")
                .Append("              [Person].[Person ID], ")
                .Append("              [Book].[Book ID], ")
                .Append("              [Person].[Name] AS [대출자], ")
                .Append("              [Rent Book].[Rent Date] AS [대출일], ")
                .Append("              [Book Barcode].[Barcode] AS [바코드], ")
                .Append("              [Book].[Title] AS [도서명], ")
                .Append("              [Book].[Subtitle] AS [소제목], ")
                .Append("              [Book Type].[Book Type] AS [책 분류명], ")
                .Append("              [Book].[Author] AS [저자], ")
                .Append("              [Book].[Publisher] AS [출판사], ")
                .Append("              [Return Date] AS [반납일], ")
                .Append("              [Lost] AS [분실], ")
                .Append("              [Penalty] AS [벌금], ")
                .Append("              [Rent Book].[Note] AS [비고] ")
                .Append("FROM [Rent Book], [Book Barcode], [Person], [Book], [Book Type] ")
                .Append("WHERE [Rent Book].[Barcode ID] = [Book Barcode].[Barcode ID] ")
                .Append("AND [Rent Book].[Person ID] = [Person].[Person ID] ")
                .Append("AND [Book Barcode].[Book ID] = [Book].[Book ID] ")
                .Append("AND [Book].[Book Type ID] = [Book Type].[Book Type ID] ")
            End With

            If flag = 1 Then '미반납 도서 목록
                sb.Append("AND [Rent Book].[Return Date] IS NULL ")
            End If

            With sb
                .Append("AND [Person].[Person ID] = @PersonID ")
                .Append("ORDER BY [Rent Book].[Rent Book ID] ")
            End With

            sql = sb.ToString

            Try
                cn = New SqlConnection(m_Constant.SQL_CONSTR)

                'provider to be used when working with access database
                cn.Open()
                cmd = New SqlCommand(sql, cn)
                cmd.CommandTimeout = 0

                cmd.Parameters.Add(New SqlParameter("@PersonID", SqlDbType.VarChar)).Value = PersonID

                da.SelectCommand = cmd
                da.Fill(getRentBookListByPersonID, "getRentBookListByPersonID")

            Catch ex As Exception
                MessageBox.Show("Error at RentBookDAL.getRentBookListByPersonID : " + ex.Message)
            Finally
                m_DBUtil.closeConnection(da, cn, cmd)
                sb = Nothing
            End Try
            Return getRentBookListByPersonID
        End Function
        Public Function getRentBookListByBarcode(ByVal flag As Integer, ByVal Barcode As String) As DataSet
            Dim sql As String = String.Empty
            Dim cn As SqlConnection = Nothing
            Dim cmd As SqlCommand = Nothing
            Dim da As SqlDataAdapter = Nothing
            Dim sb As StringBuilder = New StringBuilder

            getRentBookListByBarcode = New DataSet
            da = New SqlDataAdapter()

            With sb
                .Append("SELECT  [Rent Book].Flag AS [선택], ")
                .Append("              [Rent Book].[Rent Book ID], ")
                .Append("              [Book Barcode].[Barcode ID], ")
                .Append("              [Person].[Person ID], ")
                .Append("              [Book].[Book ID], ")
                .Append("              [Person].[Name] AS [대출자], ")
                .Append("              [Rent Book].[Rent Date] AS [대출일], ")
                .Append("              [Book Barcode].[Barcode] AS [바코드], ")
                .Append("              [Book].[Title] AS [도서명], ")
                .Append("              [Book].[Subtitle] AS [소제목], ")
                .Append("              [Book Type].[Book Type] AS [책 분류명], ")
                .Append("              [Book].[Author] AS [저자], ")
                .Append("              [Book].[Publisher] AS [출판사], ")
                .Append("              [Return Date] AS [반납일], ")
                .Append("              [Lost] AS [분실], ")
                .Append("              [Penalty] AS [벌금], ")
                .Append("              [Rent Book].[Note] AS [비고] ")
                .Append("FROM [Rent Book], [Book Barcode], [Person], [Book], [Book Type] ")
                .Append("WHERE [Rent Book].[Barcode ID] = [Book Barcode].[Barcode ID] ")
                .Append("AND [Rent Book].[Person ID] = [Person].[Person ID] ")
                .Append("AND [Book Barcode].[Book ID] = [Book].[Book ID] ")
                .Append("AND [Book].[Book Type ID] = [Book Type].[Book Type ID] ")
            End With

            If flag = 0 Then '미반납 도서 목록
                sb.Append("AND [Rent Book].[Return Date] IS NULL ")
            End If

            With sb
                .Append("AND [Book Barcode].[Barcode] = @Barcode ")
                .Append("ORDER BY [Rent Book].[Rent Date] ")
            End With

            sql = sb.ToString

            Try
                cn = New SqlConnection(m_Constant.SQL_CONSTR)

                'provider to be used when working with access database
                cn.Open()
                cmd = New SqlCommand(sql, cn)
                cmd.CommandTimeout = 0

                cmd.Parameters.Add(New SqlParameter("@Barcode", SqlDbType.VarChar)).Value = Barcode.Trim

                da.SelectCommand = cmd
                da.Fill(getRentBookListByBarcode, "getRentBookListByBarcode")

            Catch ex As Exception
                MessageBox.Show("Error at RentBookDAL.getRentBookListByBarcode : " + ex.Message)
            Finally
                m_DBUtil.closeConnection(da, cn, cmd)
                sb = Nothing
            End Try
            Return getRentBookListByBarcode
        End Function

        Public Function getReturnRecordByBarcode(ByVal flag As Integer, ByVal barcode As String) As ArrayList
            Dim sql As String = String.Empty
            Dim cn As SqlConnection = Nothing
            Dim cmd As SqlCommand = Nothing
            Dim dr As SqlDataReader = Nothing
            Dim sb As StringBuilder = New StringBuilder

            getReturnRecordByBarcode = New ArrayList

            With sb
                If flag = 0 Then 'Rent
                    .Append("SELECT  [Book Barcode].Status AS [선택], ")
                    .Append("              NULL AS [Rent Book ID], ")
                    .Append("              [Book Barcode].[Barcode ID], ")
                    .Append("              NULL AS [Person ID], ")
                    .Append("              [Book].[Book ID], ")
                    .Append("              NULL AS [대출자], ")
                    .Append("              NULL AS [대출일], ")
                    .Append("              [Book Barcode].[Barcode] AS [바코드], ")
                    .Append("              [Book].[Title] AS [도서명], ")
                    .Append("              [Book].[Subtitle] AS [소제목], ")
                    .Append("              [Book Type].[Book Type] AS [책 분류명], ")
                    .Append("              [Book].[Author] AS [저자], ")
                    .Append("              [Book].[Publisher] AS [출판사], ")
                    .Append("              NULL AS [반납일], ")
                    .Append("              NULL AS [분실여부], ")
                    .Append("              NULL AS [벌금], ")
                    .Append("              NULL AS [비고] ")
                    .Append("FROM [Book Barcode], [Book], [Book Type] ")
                    .Append("WHERE [Book Barcode].[Book ID] = [Book].[Book ID] ")
                    .Append("AND [Book].[Book Type ID] = [Book Type].[Book Type ID] ")
                    .Append("AND [Book Barcode].[Barcode] = @Barcode")
                    '.Append("AND [Book Barcode].Status != 'R' ")
                Else 'Return
                    .Append("SELECT  [Book Barcode].Status AS [선택], ")
                    .Append("              [Rent Book].[Rent Book ID] AS [Rent Book ID], ")
                    .Append("              [Book Barcode].[Barcode ID], ")
                    .Append("              [Person].[Person ID] AS [Person ID], ")
                    .Append("              [Book].[Book ID], ")
                    .Append("              [Person].Name AS [대출자], ")
                    .Append("              [Rent Book].[Rent Date] AS [대출일], ")
                    .Append("              [Book Barcode].[Barcode] AS [바코드], ")
                    .Append("              [Book].[Title] AS [도서명], ")
                    .Append("              [Book].[Subtitle] AS [소제목], ")
                    .Append("              [Book Type].[Book Type] AS [책 분류명], ")
                    .Append("              [Book].[Author] AS [저자], ")
                    .Append("              [Book].[Publisher] AS [출판사], ")
                    .Append("              [Rent Book].[Return Date] AS [반납일], ")
                    .Append("              [Rent Book].Lost AS [분실여부], ")
                    .Append("              [Rent Book].Penalty AS [벌금], ")
                    .Append("              [Rent Book].Note AS [비고] ")
                    .Append("FROM [Book Barcode], [Book], [Book Type], [Rent Book], [Person] ")
                    .Append("WHERE [Book Barcode].[Book ID] = [Book].[Book ID] ")
                    .Append("AND [Book].[Book Type ID] = [Book Type].[Book Type ID] ")
                    .Append("AND [Rent Book].[Person ID] = [Person].[Person ID] ")
                    .Append("AND [Rent Book].[Barcode ID] = [Book Barcode].[Barcode ID] ")
                    .Append("AND [Book Barcode].[Barcode] = @Barcode ")
                    .Append("AND [Rent Book].[Return Date] IS NULL ")
                End If
            End With
            sql = sb.ToString

            Try
                cn = New SqlConnection(m_Constant.SQL_CONSTR)

                'provider to be used when working with access database
                cn.Open()
                cmd = New SqlCommand(sql, cn)
                cmd.CommandTimeout = 0

                cmd.Parameters.Add(New SqlParameter("@Barcode", SqlDbType.VarChar)).Value = barcode.Trim

                dr = cmd.ExecuteReader()

                While dr.Read()
                    Dim bookRentEnt As TKPC.Entity.RentBookEnt = New TKPC.Entity.RentBookEnt
                    If IsDBNull(dr("선택")) Then
                        bookRentEnt.status = ""
                    Else
                        bookRentEnt.status = dr("선택")
                    End If

                    If IsDBNull(dr("Rent Book ID")) Then
                        bookRentEnt.rentBookID = ""
                    Else
                        bookRentEnt.rentBookID = dr("Rent Book ID")
                    End If

                    If IsDBNull(dr("Barcode ID")) Then
                        bookRentEnt.barcodeID = ""
                    Else
                        bookRentEnt.barcodeID = dr("Barcode ID")
                    End If

                    If IsDBNull(dr("Book ID")) Then
                        bookRentEnt.bookID = ""
                    Else
                        bookRentEnt.bookID = dr("Book ID")
                    End If

                    If IsDBNull(dr("Person ID")) Then
                        bookRentEnt.personID = ""
                    Else
                        bookRentEnt.personID = dr("Person ID")
                    End If

                    If IsDBNull(dr("대출일")) Then
                        bookRentEnt.rentDate = ""
                    Else
                        bookRentEnt.rentDate = dr("대출일")
                    End If

                    If IsDBNull(dr("대출자")) Then
                        bookRentEnt.personName = ""
                    Else
                        bookRentEnt.personName = dr("대출자")
                    End If

                    If IsDBNull(dr("바코드")) Then
                        bookRentEnt.barcode = ""
                    Else
                        bookRentEnt.barcode = dr("바코드")
                    End If

                    If IsDBNull(dr("도서명")) Then
                        bookRentEnt.bookTitle = ""
                    Else
                        bookRentEnt.bookTitle = dr("도서명")
                    End If

                    If IsDBNull(dr("소제목")) Then
                        bookRentEnt.bookSubtitle = ""
                    Else
                        bookRentEnt.bookSubtitle = dr("소제목")
                    End If

                    If IsDBNull(dr("책 분류명")) Then
                        bookRentEnt.bookType = ""
                    Else
                        bookRentEnt.bookType = dr("책 분류명")
                    End If

                    If IsDBNull(dr("저자")) Then
                        bookRentEnt.bookAuthor = ""
                    Else
                        bookRentEnt.bookAuthor = dr("저자")
                    End If

                    If IsDBNull(dr("출판사")) Then
                        bookRentEnt.bookPublisher = ""
                    Else
                        bookRentEnt.bookPublisher = dr("출판사")
                    End If

                    If IsDBNull(dr("반납일")) Then
                        bookRentEnt.returnDate = ""
                    Else
                        bookRentEnt.returnDate = dr("반납일")
                    End If

                    getReturnRecordByBarcode.Add(bookRentEnt)
                End While

            Catch ex As Exception
                MessageBox.Show("Error at RentBookDAL.getReturnRecordByBarcode : " + ex.Message)
            Finally
                m_DBUtil.closeConnection(dr, cmd, cn)
                sb = Nothing
            End Try
            Return getReturnRecordByBarcode
        End Function


        'This function is to delete a Rent Book record
        Public Function deleteRecordByID(ByVal rentBookID As String) As Integer
            Dim sql As String = String.Empty
            Dim cn As SqlConnection = Nothing
            Dim cmd As SqlCommand = Nothing
            Dim ta As SqlTransaction = Nothing
            Dim sb As StringBuilder = New StringBuilder

            deleteRecordByID = 0

            With sb
                .Append("DELETE FROM [Rent Book] WHERE [Rent Book].[Rent Book ID] = @RentBookID ")
            End With
            sql = sb.ToString

            Try
                cn = New SqlConnection(m_Constant.SQL_CONSTR)

                'provider to be used when working with access database
                cn.Open()
                ta = cn.BeginTransaction()

                cmd = New SqlCommand(sql, cn)
                cmd.CommandTimeout = 0
                cmd.Transaction = ta

                cmd.Parameters.Add(New SqlParameter("@RentBookID", SqlDbType.NVarChar)).Value = rentBookID
                deleteRecordByID = cmd.ExecuteNonQuery()
                ta.Commit()

            Catch ex As Exception
                ta.Rollback()
                deleteRecordByID = 0
                MessageBox.Show("Error at BookDAL.deleteRecordByID : " + ex.Message)
            Finally
                m_DBUtil.closeConnection(cmd, cn, ta)
                sb = Nothing
            End Try
            Return deleteRecordByID
        End Function
        Public Function getBookIDsByFlag(ByVal rentID As String) As String
            Dim sql As String = String.Empty
            Dim cn As SqlConnection = Nothing
            Dim cmd As SqlCommand = Nothing
            Dim dr As SqlDataReader = Nothing
            Dim sb As StringBuilder = New StringBuilder

            getBookIDsByFlag = String.Empty

            With sb
                .Append("SELECT [Book ID] FROM [Rent Book] WHERE [Rent Book].[Rent ID] = @RentID AND Flag = 0 ")
            End With
            sql = sb.ToString

            Try
                cn = New SqlConnection(m_Constant.SQL_CONSTR)

                'provider to be used when working with access database
                cn.Open()

                cmd = New SqlCommand(sql, cn)
                cmd.CommandTimeout = 0

                cmd.Parameters.Add(New SqlParameter("@RentID", SqlDbType.NVarChar)).Value = rentID
                dr = cmd.ExecuteReader()

                While dr.Read()
                    getBookIDsByFlag += dr("Book ID") + ","
                End While

                If getBookIDsByFlag.EndsWith(",") Then
                    getBookIDsByFlag = getBookIDsByFlag.Substring(0, getBookIDsByFlag.Length - 2)
                End If

            Catch ex As Exception
                getBookIDsByFlag = "Error"
                MessageBox.Show("Error at BookDAL.getBookIDsByFlag : " + ex.Message)
            Finally
                m_DBUtil.closeConnection(dr, cmd, cn)
                sb = Nothing
            End Try
            Return getBookIDsByFlag
        End Function

        Public Function deleteRecordByRentID(ByVal rentID As String, ByVal partialDelete As Boolean) As Integer
            Dim sql As String = String.Empty
            Dim cn As SqlConnection = Nothing
            Dim cmd As SqlCommand = Nothing
            Dim ta As SqlTransaction = Nothing
            Dim sb As StringBuilder = New StringBuilder

            deleteRecordByRentID = 0

            With sb
                .Append("DELETE FROM [Rent Book] WHERE [Rent Book].[Rent ID] = @RentID ")
            End With

            If partialDelete = True Then
                sb.Append("AND [Rent Book].[Flag] = 0")
            End If

            sql = sb.ToString

            Try
                cn = New SqlConnection(m_Constant.SQL_CONSTR)

                'provider to be used when working with access database
                cn.Open()
                ta = cn.BeginTransaction()

                cmd = New SqlCommand(sql, cn)
                cmd.CommandTimeout = 0
                cmd.Transaction = ta

                cmd.Parameters.Add(New SqlParameter("@RentID", SqlDbType.NVarChar)).Value = rentID
                deleteRecordByRentID = cmd.ExecuteNonQuery()
                ta.Commit()

            Catch ex As Exception
                ta.Rollback()
                deleteRecordByRentID = -1
                MessageBox.Show("Error at BookDAL.deleteRecordByRentID : " + ex.Message)
            Finally
                m_DBUtil.closeConnection(cmd, cn, ta)
                sb = Nothing
            End Try
            Return deleteRecordByRentID
        End Function
        Public Function deleteRecordByBarcodeID(ByVal barcodeID As String, ByVal partialDelete As Boolean) As Integer
            Dim sql As String = String.Empty
            Dim cn As SqlConnection = Nothing
            Dim cmd As SqlCommand = Nothing
            Dim ta As SqlTransaction = Nothing
            Dim sb As StringBuilder = New StringBuilder

            deleteRecordByBarcodeID = 0

            With sb
                .Append("DELETE FROM [Rent Book] WHERE [Rent Book].[Barcode ID] = @BarcodeID ")
            End With

            If partialDelete = True Then
                sb.Append("AND [Rent Book].[Flag] = 0")
            End If

            sql = sb.ToString

            Try
                cn = New SqlConnection(m_Constant.SQL_CONSTR)

                'provider to be used when working with access database
                cn.Open()
                ta = cn.BeginTransaction()

                cmd = New SqlCommand(sql, cn)
                cmd.CommandTimeout = 0
                cmd.Transaction = ta

                cmd.Parameters.Add(New SqlParameter("@BarcodeID", SqlDbType.NVarChar)).Value = barcodeID
                deleteRecordByBarcodeID = cmd.ExecuteNonQuery()
                ta.Commit()

            Catch ex As Exception
                ta.Rollback()
                deleteRecordByBarcodeID = -1
                MessageBox.Show("Error at BookDAL.deleteRecordByBarcodeID : " + ex.Message)
            Finally
                m_DBUtil.closeConnection(cmd, cn, ta)
                sb = Nothing
            End Try
            Return deleteRecordByBarcodeID
        End Function

        Public Function insertRecord(ByVal rbEnt As TKPC.Entity.RentBookEnt) As Integer
            Dim sql As String = String.Empty
            Dim cn As SqlConnection = Nothing
            Dim cmd As SqlCommand = Nothing
            Dim ta As SqlTransaction = Nothing
            insertRecord = 0
            Dim sb As StringBuilder = New StringBuilder

            With sb
                .Append("INSERT INTO [Rent Book] ")
                .Append("( ")
                .Append("     [Rent Book].[Barcode ID], ")
                .Append("     [Rent Book].[Person ID], ")
                .Append("     [Rent Book].[Return Date], ")
                .Append("     [Rent Book].Lost, ")
                .Append("     [Rent Book].Penalty, ")
                .Append("     [Rent Book].Note, ")
                .Append("     [Rent Book].[Last Update Date], ")
                .Append("     [Rent Book].[Flag], ")
                .Append("     [Rent Book].[Rent Date] ")
                .Append(" ) ")
                .Append("VALUES ")
                .Append("(@BarcodeID,@PersonID,@ReturnDate,@Lost,@Penalty,@Note,@LastUpdateDate,@Flag, @RentDate) ")
            End With

            sql = sb.ToString


            Try
                cn = New SqlConnection(m_Constant.SQL_CONSTR)

                'provider to be used when working with access database
                cn.Open()
                ta = cn.BeginTransaction()
                cmd = New SqlCommand(sql, cn)
                cmd.CommandTimeout = 0
                cmd.Transaction = ta

                If rbEnt.barcodeID = "" Or rbEnt.barcodeID = "0" Then
                    cmd.Parameters.Add(New SqlParameter("@BarcodeID", SqlDbType.NVarChar, rbEnt.barcodeID.Length, "Barcode ID")).Value = DBNull.Value
                Else
                    cmd.Parameters.Add(New SqlParameter("@BarcodeID", SqlDbType.NVarChar, rbEnt.barcodeID.Length, "Barcode ID")).Value = rbEnt.barcodeID
                End If

                If rbEnt.personID = "" Or rbEnt.personID = "0" Then
                    cmd.Parameters.Add(New SqlParameter("@PersonID", SqlDbType.NVarChar, rbEnt.personID.Length, "Person ID")).Value = DBNull.Value
                Else
                    cmd.Parameters.Add(New SqlParameter("@PersonID", SqlDbType.NVarChar, rbEnt.personID.Length, "Person ID")).Value = rbEnt.personID
                End If

                If rbEnt.returnDate = "" Or rbEnt.returnDate = String.Empty Then
                    cmd.Parameters.Add(New SqlParameter("@ReturnDate", SqlDbType.DateTime, rbEnt.returnDate.Length, "Return Date")).Value = DBNull.Value
                Else
                    cmd.Parameters.Add(New SqlParameter("@ReturnDate", SqlDbType.DateTime, rbEnt.returnDate.Length, "Return Date")).Value = rbEnt.returnDate
                End If

                cmd.Parameters.Add(New SqlParameter("@Lost", SqlDbType.Bit, 1, "Lost")).Value = rbEnt.lost

                If rbEnt.penalty = "" Then
                    cmd.Parameters.Add(New SqlParameter("@Penalty", SqlDbType.NVarChar, rbEnt.penalty.Length, "Penalty")).Value = DBNull.Value
                Else
                    cmd.Parameters.Add(New SqlParameter("@Penalty", SqlDbType.NVarChar, rbEnt.penalty.Length, "Penalty")).Value = rbEnt.penalty
                End If

                If rbEnt.note = "" Then
                    cmd.Parameters.Add(New SqlParameter("@Note", SqlDbType.NText, rbEnt.note.Length, "Note")).Value = DBNull.Value
                Else
                    cmd.Parameters.Add(New SqlParameter("@Note", SqlDbType.NText, rbEnt.note.Length, "Note")).Value = rbEnt.note
                End If

                If rbEnt.lastUpdateDate = "" Then
                    cmd.Parameters.Add(New SqlParameter("@LastUpdateDate", SqlDbType.DateTime, rbEnt.lastUpdateDate.Length, "Last Update Date")).Value = DBNull.Value
                Else
                    cmd.Parameters.Add(New SqlParameter("@LastUpdateDate", SqlDbType.DateTime, rbEnt.lastUpdateDate.Length, "Last Update Date")).Value = rbEnt.lastUpdateDate
                End If

                cmd.Parameters.Add(New SqlParameter("@Flag", SqlDbType.Bit, 1, "Flag")).Value = rbEnt.flag

                If rbEnt.rentDate = "" Or rbEnt.rentDate = String.Empty Then
                    cmd.Parameters.Add(New SqlParameter("@RentDate", SqlDbType.DateTime, rbEnt.rentDate.Length, "Rent Date")).Value = DBNull.Value
                Else
                    cmd.Parameters.Add(New SqlParameter("@RentDate", SqlDbType.DateTime, rbEnt.rentDate.Length, "Rent Date")).Value = rbEnt.rentDate
                End If

                insertRecord = cmd.ExecuteNonQuery()
                ta.Commit()

                If insertRecord = 1 Then
                    Dim bookDAL As TKPC.DAL.BookDAL = bookDAL.getInstance()
                    Dim updateRecord As Integer = 0
                    Try
                        Dim status As String = BOOK_STATUS_R

                        If rbEnt.lost = True Then
                            status = BOOK_STATUS_L
                        End If

                        updateRecord = bookDAL.updateRecord(rbEnt.barcodeID, status, 1, rbEnt.personID)

                    Catch ex As Exception
                        insertRecord = -1
                        MessageBox.Show("Error at RentBookDAL.insertRecord.bookDAL.updateRecord : " + ex.Message)
                    Finally
                        bookDAL = Nothing
                    End Try
                Else
                    insertRecord = -1
                End If

            Catch ex As Exception
                ta.Rollback()
                insertRecord = -1
                MessageBox.Show("Error at RentBookDAL.insertRecord : " + ex.Message)
            Finally
                m_DBUtil.closeConnection(cmd, cn, ta)
                sb = Nothing
            End Try
            Return insertRecord
        End Function

        Public Function updateRecord(ByVal rbEnt As TKPC.Entity.RentBookEnt) As Integer
            Dim sql As String = String.Empty
            Dim cn As SqlConnection = Nothing
            Dim cmd As SqlCommand = Nothing
            Dim ta As SqlTransaction = Nothing
            Dim sb As StringBuilder = New StringBuilder
            updateRecord = 0

            With sb
                .Append("UPDATE [Rent Book] ")
                .Append("SET  ")
                .Append("     [Rent Book].[Barcode ID] = @BarcodeID, ")
                .Append("     [Rent Book].[Person ID] = @PersonID, ")
                .Append("     [Rent Book].[Return Date] = @ReturnDate, ")
                .Append("     [Rent Book].Lost = @Lost, ")
                .Append("     [Rent Book].Penalty = @Penalty, ")
                .Append("     [Rent Book].Note = @Note, ")
                .Append("     [Rent Book].[Last Update Date] = @LastUpdateDate, ")
                .Append("     [Rent Book].[Flag] = @Flag ")
                .Append("WHERE [Rent Book ID] = @RentBookID ")
            End With

            sql = sb.ToString

            Try
                cn = New SqlConnection(m_Constant.SQL_CONSTR)

                'provider to be used when working with access database
                cn.Open()
                ta = cn.BeginTransaction()
                cmd = New SqlCommand(sql, cn)
                cmd.CommandTimeout = 0
                cmd.Transaction = ta

                If rbEnt.barcodeID = "" Or rbEnt.barcodeID = "0" Then
                    cmd.Parameters.Add(New SqlParameter("@BarcodeID", SqlDbType.NVarChar, rbEnt.barcodeID.Length, "Barcode ID")).Value = DBNull.Value
                Else
                    cmd.Parameters.Add(New SqlParameter("@BarcodeID", SqlDbType.NVarChar, rbEnt.barcodeID.Length, "Barcode ID")).Value = rbEnt.barcodeID.Trim
                End If

                If rbEnt.personID = "" Or rbEnt.personID = "0" Then
                    cmd.Parameters.Add(New SqlParameter("@PersonID", SqlDbType.NVarChar, rbEnt.personID.Length, "Person ID")).Value = DBNull.Value
                Else
                    cmd.Parameters.Add(New SqlParameter("@PersonID", SqlDbType.NVarChar, rbEnt.personID.Length, "Person ID")).Value = rbEnt.personID
                End If

                If rbEnt.returnDate = "" Then
                    cmd.Parameters.Add(New SqlParameter("@ReturnDate", SqlDbType.DateTime, rbEnt.returnDate.Length, "Return Date")).Value = DBNull.Value
                Else
                    cmd.Parameters.Add(New SqlParameter("@ReturnDate", SqlDbType.DateTime, rbEnt.returnDate.Length, "Return Date")).Value = rbEnt.returnDate
                End If

                cmd.Parameters.Add(New SqlParameter("@Lost", SqlDbType.Bit, 1, "Lost")).Value = rbEnt.lost

                If rbEnt.penalty = "" Then
                    cmd.Parameters.Add(New SqlParameter("@Penalty", SqlDbType.NVarChar, rbEnt.penalty.Length, "Penalty")).Value = DBNull.Value
                Else
                    cmd.Parameters.Add(New SqlParameter("@Penalty", SqlDbType.NVarChar, rbEnt.penalty.Length, "Penalty")).Value = rbEnt.penalty
                End If

                If rbEnt.note = "" Then
                    cmd.Parameters.Add(New SqlParameter("@Note", SqlDbType.NText, rbEnt.note.Length, "Note")).Value = DBNull.Value
                Else
                    cmd.Parameters.Add(New SqlParameter("@Note", SqlDbType.NText, rbEnt.note.Length, "Note")).Value = rbEnt.note
                End If

                If rbEnt.lastUpdateDate = "" Then
                    cmd.Parameters.Add(New SqlParameter("@LastUpdateDate", SqlDbType.DateTime, rbEnt.lastUpdateDate.Length, "Last Update Date")).Value = DBNull.Value
                Else
                    cmd.Parameters.Add(New SqlParameter("@LastUpdateDate", SqlDbType.DateTime, rbEnt.lastUpdateDate.Length, "Last Update Date")).Value = rbEnt.lastUpdateDate
                End If

                cmd.Parameters.Add(New SqlParameter("@Flag", SqlDbType.Bit, 1, "Flag")).Value = rbEnt.flag

                cmd.Parameters.Add(New SqlParameter("@RentBookID", SqlDbType.NVarChar, rbEnt.rentBookID.Length, "Rent Book ID")).Value = rbEnt.rentBookID

                updateRecord = cmd.ExecuteNonQuery()
                ta.Commit()

                If updateRecord = 1 Then
                    Dim bookDAL As TKPC.DAL.BookDAL = bookDAL.getInstance()
                    Dim updateRecordBook As Integer = 0
                    Try
                        Dim status As String = BOOK_STATUS_A
                        If rbEnt.lost = True Then
                            status = BOOK_STATUS_L
                        End If

                        updateRecordBook = bookDAL.updateRecord(rbEnt.barcodeID, status, 0, 0)

                    Catch ex As Exception
                        updateRecord = -1
                        MessageBox.Show("Error at RentBookDAL.updateRecord.bookDAL.updateRecord : " + ex.Message)
                    Finally
                        bookDAL = Nothing
                    End Try
                Else
                    updateRecord = -1
                End If

            Catch ex As Exception
                ta.Rollback()
                updateRecord = -1
                MessageBox.Show("Error at RentBookDAL.updateRecord : " + ex.Message)
            Finally
                m_DBUtil.closeConnection(cmd, cn, ta)
                sb = Nothing
            End Try
            Return updateRecord
        End Function

        Public Function updateRentBookFlags(ByVal flag As Integer, ByVal ID As String) As Integer
            Dim sql As String = String.Empty
            Dim cn As SqlConnection = Nothing
            Dim cmd As SqlCommand = Nothing
            Dim ta As SqlTransaction = Nothing
            Dim sb As StringBuilder = New StringBuilder
            updateRentBookFlags = 0

            With sb
                .Append("UPDATE [Rent Book] ")
                .Append("SET  ")
                .Append("     [Lost] = @flag ")
                .Append("WHERE [Barcode ID] = @ID ")
            End With

            sql = sb.ToString

            Try
                cn = New SqlConnection(m_Constant.SQL_CONSTR)

                'provider to be used when working with access database
                cn.Open()
                ta = cn.BeginTransaction()
                cmd = New SqlCommand(sql, cn)
                cmd.CommandTimeout = 0
                cmd.Transaction = ta

                cmd.Parameters.Add(New SqlParameter("@flag", SqlDbType.Bit)).Value = flag
                cmd.Parameters.Add(New SqlParameter("@ID", SqlDbType.NVarChar)).Value = ID

                updateRentBookFlags = cmd.ExecuteNonQuery()
                ta.Commit()

            Catch ex As Exception
                ta.Rollback()
                MessageBox.Show("Error at RentBookDAL.updateRentBookFlags : " + ex.Message)
            Finally
                m_DBUtil.closeConnection(cmd, cn, ta)
                sb = Nothing
            End Try
            Return updateRentBookFlags
        End Function

        'Check orphan records for backup
        Public Function updateRentBookStatus(ByVal flag As Integer) As Integer
            Dim sql As String = String.Empty
            Dim cn As SqlConnection = Nothing
            Dim cmd As SqlCommand = Nothing
            Dim ta As SqlTransaction = Nothing
            Dim sb As StringBuilder = New StringBuilder

            updateRentBookStatus = 0

            With sb
                If flag = 0 Then
                    .Append("update [Book Barcode] set status = 'R' ")
                    .Append("where [Barcode ID] IN ( ")
                    .Append("       select [Barcode ID] from [Rent Book] where [Return Date] is NULL) ")
                    .Append("and status != 'R' ")
                ElseIf flag = 1 Then
                    .Append("update [Book Barcode] set status = 'A' ")
                    .Append("where [Barcode ID] NOT IN ( ")
                    .Append("       select [Barcode ID] from [Rent Book] where [Return Date] is NULL) ")
                    .Append("and (status = 'R') ")
                End If
            End With
            sql = sb.ToString

            Try
                cn = New SqlConnection(m_Constant.SQL_CONSTR)
                cn.Open()
                ta = cn.BeginTransaction()
                cmd = New SqlCommand(sql, cn)
                cmd.CommandTimeout = 0
                cmd.Transaction = ta

                updateRentBookStatus = cmd.ExecuteNonQuery()
                ta.Commit()

            Catch ex As Exception
                ta.Rollback()
                MessageBox.Show("Error at RentBookDAL.updateRentBookStatus : " + ex.Message)
            Finally
                m_DBUtil.closeConnection(cmd, cn, ta)
                sb = Nothing
            End Try
            Return updateRentBookStatus
        End Function

        Public Sub updateRentPerson()
            Dim sql As String = String.Empty
            Dim cn As SqlConnection = Nothing
            Dim cmd As SqlCommand = Nothing
            Dim cmd2 As SqlCommand = Nothing
            Dim ta As SqlTransaction = Nothing
            Dim dr As SqlDataReader = Nothing
            Dim sb As StringBuilder = New StringBuilder
            Dim sb2 As StringBuilder = New StringBuilder

            With sb
                .Append("select [Book Barcode].[Barcode ID], [Rent Book].[Person ID] ")
                .Append("from [Book Barcode], [Rent Book], [Book], [Person] ")
                .Append("where [Book Barcode].[Barcode ID] = [Rent Book].[Barcode ID] ")
                .Append("and [Book Barcode].[Person ID] = '0' ")
                .Append("and [Rent Book].[Person ID] = [Person].[Person ID] ")
                .Append("and [Book Barcode].[Book ID] = [Book].[Book ID] ")
                .Append("and [Rent Book].[Return Date] IS NULL ")
            End With

            sql = sb.ToString

            Try
                cn = New SqlConnection(m_Constant.SQL_CONSTR)

                'provider to be used when working with access database
                cn.Open()
                cmd = New SqlCommand(sql, cn)
                cmd.CommandTimeout = 0

                dr = cmd.ExecuteReader()

                While dr.Read()
                    If IsDBNull(dr("Barcode ID")) = False And IsDBNull(dr("Person ID")) = False Then
                        updateRentPersonStatus(dr("Barcode ID"), dr("Person ID"))
                    End If
                End While

            Catch ex As Exception
                MessageBox.Show("Error at RentBookDAL.updateRentPerson : " + ex.Message)
            Finally
                m_DBUtil.closeConnection(dr, cmd, cn)
                sb = Nothing
                sb2 = Nothing
            End Try
        End Sub

        'Check orphan records for backup
        Public Function updateRentPersonStatus(ByVal barcodeID As String, ByVal personID As String) As Integer
            Dim sql As String = String.Empty
            Dim cn As SqlConnection = Nothing
            Dim cmd As SqlCommand = Nothing
            Dim ta As SqlTransaction = Nothing
            Dim sb As StringBuilder = New StringBuilder

            updateRentPersonStatus = 0

            With sb
                .Append("update [Book Barcode] set [Person ID] = @PersonID where [Barcode ID] = @BarcodeID")
            End With
            sql = sb.ToString

            Try
                cn = New SqlConnection(m_Constant.SQL_CONSTR)
                cn.Open()
                ta = cn.BeginTransaction()
                cmd = New SqlCommand(sql, cn)
                cmd.CommandTimeout = 0
                cmd.Transaction = ta

                cmd.Parameters.Add(New SqlParameter("@PersonID", SqlDbType.Int)).Value = personID
                cmd.Parameters.Add(New SqlParameter("@BarcodeID", SqlDbType.Int)).Value = barcodeID

                updateRentPersonStatus = cmd.ExecuteNonQuery()
                ta.Commit()

            Catch ex As Exception
                ta.Rollback()
                MessageBox.Show("Error at RentBookDAL.updateRentPersonStatus : " + ex.Message)
            Finally
                m_DBUtil.closeConnection(cmd, cn, ta)
                sb = Nothing
            End Try
            Return updateRentPersonStatus
        End Function
    End Class
End Namespace




