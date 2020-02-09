Imports System.Data.Odbc
Imports System.Data.SqlClient
Imports System.Text

Namespace TKPC.DAL
    Public Class BookDAL
        Private Shared Instance As BookDAL

        Protected Sub New()
        End Sub

        'To make this DAL singleton to use memory efficiently
        Public Shared Function getInstance() As BookDAL
            ' initialize if not already done
            If Instance Is Nothing Then
                Instance = New BookDAL
            End If
            ' return the initialized instance of the Singleton Class
            Return Instance
        End Function 'Instance

        'This function is to get Book data
        Public Function getList(ByVal flag As Integer, ByVal searchWords As String) As DataSet
            Dim sql As String = String.Empty
            getList = New DataSet
            Dim cn As SqlConnection = Nothing
            Dim cmd As SqlCommand = Nothing
            Dim da As SqlDataAdapter = Nothing
            Dim sb As StringBuilder = New StringBuilder

            da = New SqlDataAdapter()

            With sb
                .Append("SELECT [Book Barcode].[Barcode ID], [Book].[Book ID], ")
                .Append("       [Book Barcode].[Selected] AS [선택], ")
                .Append("       CASE WHEN [Book Barcode].Status='A' THEN '대출가능' WHEN [Book Barcode].Status='R' THEN '대출중' ELSE '분실' END AS [현재상태], ")
                .Append("       [Book Barcode].[Barcode] AS [바코드], ")
                .Append("       [Title] AS [도서명], ")
                .Append("       [Subtitle] AS [소제목], ")
                .Append("       [Author] AS [저자], ")
                .Append("       [Book Type].[Book Type] AS [책 분류명], ")
                .Append("       [Publisher] AS [출판사], ")
                .Append("       CASE WHEN [Purchase Or Donation]='P' THEN '구매' ELSE '기증' END AS [구매/기증], ")
                .Append("       [Purchase Or Donation Date] AS [구매/기증일], ")
                .Append("       [Purchase Or Donation Source] AS [구매/기증 경로], ")
                .Append("       [Book Barcode].[Note] AS [비고], ")
                .Append("       [Book Barcode].[Last Update Date] AS [데이터 저장일],")
                .Append("       Price AS [구매가격], ")
                .Append("       [Book Type].[Book Type ID], ")
                .Append("       (SELECT name FROM Person WHERE [Book Barcode].[Person ID]=[Person ID]) AS [대출자], ")
                .Append("       [Last Rent Date] AS [대출일], ")
                .Append("       [Book Barcode].[Last Update Date] AS [데이터 생성일] ")
            End With

            Select Case flag
                Case 1
                    If searchWords <> "" Then
                        With sb
                            .Append("FROM [Book], [Book Type], [Book Barcode] ")
                            .Append("WHERE [Book].[Book Type ID] = [Book Type].[Book Type ID] ")
                            .Append("AND [Book].[Book ID] = [Book Barcode].[Book ID] ")
                            .Append("AND UPPER([Book].[Title]) LIKE @Title ")
                        End With
                    End If
                Case 2
                    If searchWords <> "" Then
                        With sb
                            .Append("FROM [Book], [Book Type], [Book Barcode] ")
                            .Append("WHERE [Book].[Book Type ID] = [Book Type].[Book Type ID] ")
                            .Append("AND [Book].[Book ID] = [Book Barcode].[Book ID] ")
                            .Append("AND Status = @Rented ")
                        End With
                    End If
                Case 3
                    With sb
                        .Append("FROM [Book], [Book Type], [Book Barcode] ")
                        .Append("WHERE [Book].[Book Type ID] = [Book Type].[Book Type ID] ")
                        .Append("AND [Book].[Book ID] = [Book Barcode].[Book ID] ")
                        .Append("AND [Book Barcode].[Purchase Or Donation Date] IN (SELECT MAX([Purchase Or Donation Date]) FROM [Book Barcode]) ")
                    End With
                Case 4
                    With sb
                        .Append("FROM [Book], [Book Type], [Book Barcode], [Barcode For Print] ")
                        .Append("WHERE [Book].[Book Type ID] = [Book Type].[Book Type ID] ")
                        .Append("AND [Book].[Book ID] = [Book Barcode].[Book ID] ")
                        .Append("AND [Book Barcode].[Barcode] = [Barcode For Print].[Barcode] ")
                    End With
                Case Else
                    With sb
                        .Append("FROM [Book], [Book Type], [Book Barcode] ")
                        .Append("WHERE [Book].[Book Type ID] = [Book Type].[Book Type ID] ")
                        .Append("AND [Book].[Book ID] = [Book Barcode].[Book ID] ")
                    End With
            End Select

            sb.Append("ORDER BY [Book].Title")
            sql = sb.ToString

            Try
                cn = New SqlConnection(m_Constant.SQL_CONSTR)

                'provider to be used when working with access database
                cn.Open()
                cmd = New SqlCommand(sql, cn)
                cmd.CommandTimeout = 0

                Select Case flag
                    Case 1
                        If searchWords <> "" Then
                            cmd.Parameters.Add(New SqlParameter("@Title", SqlDbType.NVarChar)).Value = searchWords.ToUpper
                        End If
                    Case 2
                        If searchWords <> "" Then
                            cmd.Parameters.Add(New SqlParameter("@Rented", SqlDbType.NVarChar)).Value = searchWords.ToUpper
                        End If
                    Case 3
                End Select

                da.SelectCommand = cmd
                da.Fill(getList, "getList")

            Catch ex As Exception
                MessageBox.Show("Error at BookDAL.getList : " + ex.Message)
            Finally
                m_DBUtil.closeConnection(da, cn, cmd)
                sb = Nothing
            End Try
            Return getList
        End Function
        'This function is to get Book data
        Public Function getListByTitle(ByVal searchWords As String) As DataSet
            Dim sql As String = String.Empty
            getListByTitle = New DataSet
            Dim cn As SqlConnection = Nothing
            Dim cmd As SqlCommand = Nothing
            Dim da As SqlDataAdapter = Nothing
            Dim sb As StringBuilder = New StringBuilder
            'Dim Title As String = "%" + searchWords.ToUpper + "%"
            Dim TitleArr() As String = searchWords.ToUpper.Trim.Split(" ")
            Dim Title1 As String = searchWords.ToUpper.Trim
            Dim Title2 As String = TitleArr(0).ToUpper.Trim
            Dim arrLen As Integer = TitleArr.Length

            da = New SqlDataAdapter()

            With sb
                .Append("SELECT [Book Barcode].[Barcode ID], [Book].[Book ID], ")
                .Append("       [Book Barcode].[Selected] AS [선택], ")
                .Append("       CASE WHEN Status='A' THEN '대출가능' WHEN Status='R' THEN '대출중' ELSE '분실' END AS [현재상태], ")
                .Append("       [Book Barcode].[Barcode] AS [바코드], ")
                .Append("       [Title] AS [도서명], ")
                .Append("       [Subtitle] AS [소제목], ")
                .Append("       [Author] AS [저자], ")
                .Append("       [Compiler] AS [엮은이], ")
                .Append("       [ISBN] AS [ISBN], ")
                .Append("       [Book Type].[Book Type] AS [책 분류명], ")
                .Append("       [Publisher] AS [출판사], ")
                .Append("       CASE WHEN [Purchase Or Donation]='P' THEN '구매' ELSE '기증' END AS [구매/기증], ")
                .Append("       [Purchase Or Donation Date] AS [구매/기증일], ")
                .Append("       [Purchase Or Donation Source] AS [구매/기증 경로], ")
                .Append("       [Book Barcode].[Note] AS [비고], ")
                .Append("       [Book Barcode].[Last Update Date] AS [저장일],")
                .Append("       Price AS [구매가격], ")
                .Append("       [Book Type].[Book Type ID], ")
                .Append("       (SELECT name FROM Person WHERE [Book Barcode].[Person ID]=[Person ID]) AS [대출자], ")
                .Append("       [Last Rent Date] AS [대출일], ")
                .Append("       [Add Date] AS [생성일] ")
                .Append("FROM [Book], [Book Type], [Book Barcode] ")
                .Append("WHERE [Book].[Book Type ID] = [Book Type].[Book Type ID] ")
                .Append("AND [Book].[Book ID] = [Book Barcode].[Book ID] ")
                .Append("AND (")

                For i As Integer = 0 To arrLen - 1
                    .Append("REPLACE(UPPER([Book].[Title]), ' ', '') LIKE @Title_" + Convert.ToString(i))
                    If i < arrLen - 1 Then
                        .Append(" OR ")
                    End If
                Next

                .Append(") ")
                .Append("ORDER BY CASE WHEN CHARINDEX(@Title1, UPPER([Book].[Title]))=0 THEN 9999999 ELSE CHARINDEX(@Title1, REPLACE(UPPER([Book].[Title]), ' ', '')) END, CASE WHEN CHARINDEX(@Title2, REPLACE(UPPER([Book].[Title]), ' ', ''))=0 THEN 9999999 ELSE CHARINDEX(@Title2, REPLACE(UPPER([Book].[Title]), ' ', '')) END, [Book].[Title] ")
            End With

            sql = sb.ToString

            Try
                cn = New SqlConnection(m_Constant.SQL_CONSTR)

                'provider to be used when working with access database
                cn.Open()
                cmd = New SqlCommand(sql, cn)
                cmd.CommandTimeout = 0

                For j As Integer = 0 To arrLen - 1
                    cmd.Parameters.Add(New SqlParameter("@Title_" + Convert.ToString(j), SqlDbType.NVarChar)).Value = "%" + TitleArr(j) + "%"
                Next

                cmd.Parameters.Add(New SqlParameter("@Title1", SqlDbType.NVarChar)).Value = Title1
                cmd.Parameters.Add(New SqlParameter("@Title2", SqlDbType.NVarChar)).Value = Title2

                da.SelectCommand = cmd
                da.Fill(getListByTitle, "getListByTitle")

            Catch ex As Exception
                MessageBox.Show("Error at BookDAL.getListByTitle : " + ex.Message)
            Finally
                m_DBUtil.closeConnection(da, cn, cmd)
                sb = Nothing
            End Try
            Return getListByTitle
        End Function
        Public Function getListByISBN(ByVal searchWords As String) As DataSet
            Dim sql As String = String.Empty
            getListByISBN = New DataSet
            Dim cn As SqlConnection = Nothing
            Dim cmd As SqlCommand = Nothing
            Dim da As SqlDataAdapter = Nothing
            Dim sb As StringBuilder = New StringBuilder
            Dim Title As String = searchWords.ToUpper + "%"

            da = New SqlDataAdapter()

            With sb
                .Append("SELECT NULL AS [Barcode ID], [Book].[Book ID], ")
                .Append("       NULL AS [선택], ")
                .Append("       NULL AS [현재상태], ")
                .Append("       NULL AS [바코드], ")
                .Append("       [ISBN] AS [ISBN], ")
                .Append("       [Title] AS [도서명], ")
                .Append("       [Subtitle] AS [소제목], ")
                .Append("       [Author] AS [저자], ")
                .Append("       [Compiler] AS [엮은이], ")
                .Append("       [Book Type].[Book Type] AS [책 분류명], ")
                .Append("       [Publisher] AS [출판사], ")
                .Append("       NULL AS [구매/기증], ")
                .Append("       NULL AS [구매/기증일], ")
                .Append("       NULL AS [구매/기증 경로], ")
                .Append("       NULL AS [비고], ")
                .Append("       NULL AS [저장일],")
                .Append("       NULL AS [구매가격], ")
                .Append("       [Book Type].[Book Type ID], ")
                .Append("       NULL AS [대출자], ")
                .Append("       NULL AS [대출일], ")
                .Append("       [Add Date] AS [생성일] ")
                .Append("FROM [Book], [Book Type] ")
                .Append("WHERE [Book].[Book Type ID] = [Book Type].[Book Type ID] ")
                .Append("AND UPPER([Book].[ISBN]) LIKE @ISBN ")
                .Append("ORDER BY [Book].[ISBN] ")
            End With

            sql = sb.ToString

            Try
                cn = New SqlConnection(m_Constant.SQL_CONSTR)

                'provider to be used when working with access database
                cn.Open()
                cmd = New SqlCommand(sql, cn)
                cmd.CommandTimeout = 0

                cmd.Parameters.Add(New SqlParameter("@ISBN", SqlDbType.NVarChar)).Value = Title

                da.SelectCommand = cmd
                da.Fill(getListByISBN, "getListByISBN")

            Catch ex As Exception
                MessageBox.Show("Error at BookDAL.getListByISBN : " + ex.Message)
            Finally
                m_DBUtil.closeConnection(da, cn, cmd)
                sb = Nothing
            End Try
            Return getListByISBN
        End Function

        'This function is to get Book data
        Public Function getBookBarcodeList(ByVal bookID As String) As DataSet
            Dim sql As String = String.Empty
            getBookBarcodeList = New DataSet
            Dim cn As SqlConnection = Nothing
            Dim cmd As SqlCommand = Nothing
            Dim da As SqlDataAdapter = Nothing
            Dim sb As StringBuilder = New StringBuilder

            With sb
                .Append("SELECT [Barcode ID] AS [Barcode ID], [Book ID] AS [Book ID], [Barcode] AS [바코드], [Price] AS [구매가격], ")
                .Append("             CASE WHEN Status='A' THEN '대출가능' WHEN Status='R' THEN '대출중' ELSE '분실' END AS [현재상태], ")
                .Append("             Selected AS [선택], Note AS [비고], ")
                .Append("             [Purchase Or Donation] AS [구매/기증], ")
                .Append("             [Purchase Or Donation Date] AS [등록일], ")
                .Append("             [Purchase Or Donation Source] AS [구매/기증 출처], ")
                .Append("             [Person ID] AS [Person ID], ")
                .Append("             [Last Update Date] AS [저장일], ")
                .Append("            (SELECT name FROM Person WHERE [Book Barcode].[Person ID]=[Person ID]) AS [대출자], ")
                .Append("             [Last Rent Date] AS [대출일] ")
                .Append("FROM [Book Barcode] ")
                .Append("WHERE [Book ID] = @BookID ")
                .Append("ORDER BY Barcode ")
            End With
            sql = sb.ToString

            da = New SqlDataAdapter()

            Try
                cn = New SqlConnection(m_Constant.SQL_CONSTR)

                'provider to be used when working with access database
                cn.Open()
                cmd = New SqlCommand(sql, cn)
                cmd.CommandTimeout = 0

                cmd.Parameters.Add(New SqlParameter("@BookID", SqlDbType.NVarChar)).Value = bookID

                da.SelectCommand = cmd
                da.Fill(getBookBarcodeList, "getList")

            Catch ex As Exception
                MessageBox.Show("Error at BookDAL.getBookBarcodeList : " + ex.Message)
            Finally
                m_DBUtil.closeConnection(da, cn, cmd)
                sb = Nothing
            End Try
            Return getBookBarcodeList
        End Function
        'This function is to get Book data
        Public Function getAuthorBookList(ByVal searchWords As String) As DataSet
            Dim sql As String = String.Empty
            getAuthorBookList = New DataSet
            Dim cn As SqlConnection = Nothing
            Dim cmd As SqlCommand = Nothing
            Dim da As SqlDataAdapter = Nothing
            Dim sb As StringBuilder = New StringBuilder
            Dim Author As String = searchWords.ToUpper

            da = New SqlDataAdapter()

            With sb
                .Append("SELECT [Book Barcode].[Barcode ID], [Book].[Book ID], ")
                .Append("       [Book Barcode].[Selected] AS [선택], ")
                .Append("       CASE WHEN Status='A' THEN '대출가능' WHEN Status='R' THEN '대출중' ELSE '분실' END AS [현재상태], ")
                .Append("       [Book Barcode].[Barcode] AS [바코드], ")
                .Append("       [Title] AS [도서명], ")
                .Append("       [Subtitle] AS [소제목], ")
                .Append("       [Author] AS [저자], ")
                .Append("       [Compiler] AS [엮은이], ")
                .Append("       [ISBN] AS [ISBN], ")
                .Append("       [Book Type].[Book Type] AS [책 분류명], ")
                .Append("       [Publisher] AS [출판사], ")
                .Append("       CASE WHEN [Purchase Or Donation]='P' THEN '구매' ELSE '기증' END AS [구매/기증], ")
                .Append("       [Purchase Or Donation Date] AS [구매/기증일], ")
                .Append("       [Purchase Or Donation Source] AS [구매/기증 경로], ")
                .Append("       [Book Barcode].[Note] AS [비고], ")
                .Append("       [Book Barcode].[Last Update Date] AS [저장일],")
                .Append("       Price AS [구매가격], ")
                .Append("       [Book Type].[Book Type ID], ")
                .Append("       (SELECT name FROM Person WHERE [Book Barcode].[Person ID]=[Person ID]) AS [대출자], ")
                .Append("       [Last Rent Date] AS [대출일], ")
                .Append("       [Book].[Add Date] AS [생성일] ")
                .Append("FROM [Book], [Book Type], [Book Barcode] ")
                .Append("WHERE [Book].[Book Type ID] = [Book Type].[Book Type ID] ")
                .Append("AND [Book].[Book ID] = [Book Barcode].[Book ID] ")
                .Append("AND UPPER([Book].[Author]) IN (@Author) ")
                .Append("ORDER BY [Book].[Title] ")
            End With

            sql = sb.ToString

            Try
                cn = New SqlConnection(m_Constant.SQL_CONSTR)

                'provider to be used when working with access database
                cn.Open()
                cmd = New SqlCommand(sql, cn)
                cmd.CommandTimeout = 0

                cmd.Parameters.Add(New SqlParameter("@Author", SqlDbType.NVarChar)).Value = Author

                da.SelectCommand = cmd
                da.Fill(getAuthorBookList, "getAuthorBookList")

            Catch ex As Exception
                MessageBox.Show("Error at BookDAL.getAuthorBookList : " + ex.Message)
            Finally
                m_DBUtil.closeConnection(da, cn, cmd)
                sb = Nothing
            End Try
            Return getAuthorBookList
        End Function
        'This function is to get Book data
        Public Function getBookListForBarcodes() As ArrayList
            Dim sql As String = String.Empty
            Dim sb As StringBuilder = New StringBuilder
            Dim cn As SqlConnection = Nothing
            Dim cmd As SqlCommand = Nothing
            Dim da As SqlDataAdapter = Nothing
            Dim dr As SqlDataReader = Nothing
            getBookListForBarcodes = New ArrayList

            da = New SqlDataAdapter()

            With sb
                .Append("SELECT [Barcode For Print].Barcode FROM [Barcode For Print], [Book Barcode] ")
                .Append("WHERE [Barcode For Print].Barcode = [Book Barcode].Barcode ")
                .Append("AND [Book Barcode].[Selected2] IS NULL ")
                .Append("ORDER BY [Barcode For Print].Barcode ")
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
                    If IsDBNull(dr("Barcode")) = False Then
                        getBookListForBarcodes.Add(dr("Barcode"))
                    End If
                End While


            Catch ex As Exception
                MessageBox.Show("Error at BookDAL.getBookListForBarcodes : " + ex.Message)
            Finally
                m_DBUtil.closeConnection(da, cn, cmd)
                sb = Nothing
            End Try
            Return getBookListForBarcodes
        End Function
        Public Function getRecordByBarcode(ByVal barcode As String) As TKPC.Entity.BookEnt
            Dim sql As String = String.Empty
            Dim cn As SqlConnection = Nothing
            Dim cmd As SqlCommand = Nothing
            Dim dr As SqlDataReader = Nothing
            Dim sb As StringBuilder = New StringBuilder

            With sb
                .Append("SELECT [Book ID], ")
                .Append("       [Title], ")
                .Append("       [Subtitle], ")
                .Append("       [Author], ")
                .Append("       [Book Type].[Book Type ID], ")
                .Append("       [Book Type].[Book Type], ")
                .Append("       [Publisher], ")
                .Append("       [Note], ")
                .Append("       [ISBN], ")
                .Append("       [Compiler], ")
                .Append("       [Last Update Date] ")
                .Append("FROM [Book], [Book Type] ")
                .Append("WHERE [Book].[Book Type ID] = [Book Type].[Book Type ID] ")
                .Append("AND [Book].[Book ID] IN (SELECT [Book ID] FROM [Book Barcode] WHERE Barcode = @Barcode) ")
            End With
            sql = sb.ToString

            getRecordByBarcode = New TKPC.Entity.BookEnt

            Try
                cn = New SqlConnection(m_Constant.SQL_CONSTR)

                'provider to be used when working with access database
                cn.Open()

                cmd = New SqlCommand(sql, cn)
                cmd.CommandTimeout = 0
                cmd.Parameters.Add(New SqlParameter("@Barcode", SqlDbType.NVarChar)).Value = barcode

                dr = cmd.ExecuteReader()

                If dr.Read() Then
                    If IsDBNull(dr("Book ID")) Then
                        getRecordByBarcode.bookID = ""
                    Else
                        getRecordByBarcode.bookID = dr("Book ID")
                    End If

                    If IsDBNull(dr("Title")) Then
                        getRecordByBarcode.title = ""
                    Else
                        getRecordByBarcode.title = dr("Title")
                    End If

                    If IsDBNull(dr("Subtitle")) Then
                        getRecordByBarcode.subtitle = ""
                    Else
                        getRecordByBarcode.subtitle = dr("Subtitle")
                    End If

                    If IsDBNull(dr("Author")) Then
                        getRecordByBarcode.author = ""
                    Else
                        getRecordByBarcode.author = dr("Author")
                    End If

                    If IsDBNull(dr("Book Type ID")) Then
                        getRecordByBarcode.bookTypeID = "1"
                    Else
                        getRecordByBarcode.bookTypeID = dr("Book Type ID")
                    End If

                    If IsDBNull(dr("Book Type")) Then
                        getRecordByBarcode.bookType = ""
                    Else
                        getRecordByBarcode.bookType = dr("Book Type")
                    End If

                    If IsDBNull(dr("Publisher")) Then
                        getRecordByBarcode.publisher = ""
                    Else
                        getRecordByBarcode.publisher = dr("Publisher")
                    End If

                    If IsDBNull(dr("Note")) Then
                        getRecordByBarcode.note = ""
                    Else
                        getRecordByBarcode.note = dr("Note")
                    End If

                    If IsDBNull(dr("ISBN")) Then
                        getRecordByBarcode.ISBN = ""
                    Else
                        getRecordByBarcode.ISBN = dr("ISBN")
                    End If

                    If IsDBNull(dr("Compiler")) Then
                        getRecordByBarcode.compiler = ""
                    Else
                        getRecordByBarcode.compiler = dr("Compiler")
                    End If

                    If IsDBNull(dr("Last Update Date")) Then
                        getRecordByBarcode.lastUpdateDate = ""
                    Else
                        getRecordByBarcode.lastUpdateDate = dr("Last Update Date")
                    End If
                End If

            Catch ex As Exception
                MessageBox.Show("Error at BookDAL.getRecordByBarcode : " + ex.Message)
            Finally
                m_DBUtil.closeConnection(dr, cmd, cn)
                sb = Nothing
            End Try
            Return getRecordByBarcode
        End Function

        Public Function getRecordByID(ByVal bookID As String) As TKPC.Entity.BookEnt
            Dim sql As String = String.Empty
            Dim cn As SqlConnection = Nothing
            Dim cmd As SqlCommand = Nothing
            Dim dr As SqlDataReader = Nothing
            Dim sb As StringBuilder = New StringBuilder

            getRecordByID = New TKPC.Entity.BookEnt

            With sb
                .Append("SELECT [Book ID], ")
                .Append("              ISBN, ")
                .Append("              [Title], ")
                .Append("              [Subtitle], ")
                .Append("              [Author], ")
                .Append("              [Compiler], ")
                .Append("              [Book Type].[Book Type], ")
                .Append("              [Book Type].[Book Type ID], ")
                .Append("              [Publisher], ")
                .Append("              [Note], ")
                .Append("              [Last Update Date], ")
                .Append("              [Add Date] ")
                .Append("FROM [Book], [Book Type] ")
                .Append("WHERE [Book].[Book Type ID] = [Book Type].[Book Type ID] ")
                .Append("AND [Book].[Book ID] = @BookID ")
            End With
            sql = sb.ToString

            Try
                cn = New SqlConnection(m_Constant.SQL_CONSTR)

                'provider to be used when working with access database
                cn.Open()

                cmd = New SqlCommand(sql, cn)
                cmd.CommandTimeout = 0
                cmd.Parameters.Add(New SqlParameter("@BookID", SqlDbType.NVarChar)).Value = bookID

                dr = cmd.ExecuteReader()

                If dr.Read() Then
                    If IsDBNull(dr("Book ID")) Then
                        getRecordByID.bookID = ""
                    Else
                        getRecordByID.bookID = dr("Book ID")
                    End If

                    'If IsDBNull(dr("Rented")) Then
                    '    getRecordByID.rented = "N"
                    'Else
                    '    getRecordByID.rented = dr("Rented")

                    '    If IsDBNull(dr("Person ID")) = False And dr("Person ID") <> 0 Then
                    '        Dim personDAL As TKPC.DAL.PersonDAL = personDAL.getInstance()
                    '        Dim personEnt As TKPC.Entity.PersonEnt = New TKPC.Entity.PersonEnt
                    '        Try
                    '            personEnt = personDAL.getRecordByID(dr("Person ID"))
                    '            If personEnt IsNot Nothing Then
                    '                getRecordByID.rentPersonID = personEnt.personID
                    '                getRecordByID.rentPersonName = personEnt.name
                    '                getRecordByID.rentPersonTitle = personEnt.personTitle
                    '            End If
                    '        Catch
                    '        Finally
                    '            personDAL = Nothing
                    '            personEnt = Nothing
                    '        End Try
                    '    End If
                    'End If

                    If IsDBNull(dr("ISBN")) Then
                        getRecordByID.ISBN = ""
                    Else
                        getRecordByID.ISBN = dr("ISBN")
                    End If

                    If IsDBNull(dr("Title")) Then
                        getRecordByID.title = ""
                    Else
                        getRecordByID.title = dr("Title")
                    End If

                    If IsDBNull(dr("Subtitle")) Then
                        getRecordByID.subtitle = ""
                    Else
                        getRecordByID.subtitle = dr("Subtitle")
                    End If

                    If IsDBNull(dr("Author")) Then
                        getRecordByID.author = ""
                    Else
                        getRecordByID.author = dr("Author")
                    End If

                    If IsDBNull(dr("Compiler")) Then
                        getRecordByID.compiler = ""
                    Else
                        getRecordByID.compiler = dr("Compiler")
                    End If

                    If IsDBNull(dr("Publisher")) Then
                        getRecordByID.publisher = ""
                    Else
                        getRecordByID.publisher = dr("Publisher")
                    End If

                    If IsDBNull(dr("Book Type")) Then
                        getRecordByID.bookType = ""
                    Else
                        getRecordByID.bookType = dr("Book Type")
                    End If

                    If IsDBNull(dr("Book Type ID")) Then
                        getRecordByID.bookTypeID = ""
                    Else
                        getRecordByID.bookTypeID = dr("Book Type ID")
                    End If

                    If IsDBNull(dr("Note")) Then
                        getRecordByID.note = ""
                    Else
                        getRecordByID.note = dr("Note")
                    End If

                    If IsDBNull(dr("Last Update Date")) Then
                        getRecordByID.lastUpdateDate = ""
                    Else
                        getRecordByID.lastUpdateDate = dr("Last Update Date")
                    End If

                    If IsDBNull(dr("Add Date")) Then
                        getRecordByID.addDate = ""
                    Else
                        getRecordByID.addDate = dr("Add Date")
                    End If
                End If

            Catch ex As Exception
                MessageBox.Show("Error at BookDAL.getRecordByID : " + ex.Message)
            Finally
                m_DBUtil.closeConnection(dr, cmd, cn)
                sb = Nothing
            End Try
            Return getRecordByID
        End Function

        Public Function getDataTable() As ArrayList
            Dim sql As String = String.Empty
            Dim cn As SqlConnection = Nothing
            Dim cmd As SqlCommand = Nothing
            Dim dr As SqlDataReader = Nothing
            Dim sb As StringBuilder = New StringBuilder

            getDataTable = New ArrayList
            Dim dt As DataTable

            With sb
                .Append("SELECT [Book Type] + ' (' + [Description] + ')' AS Name, [Book Type ID] AS Value ")
                .Append("FROM [Book Type] ")
                .Append("ORDER BY CAST([Book Type ID] AS int) ")
            End With
            sql = sb.ToString

            Try
                cn = New SqlConnection(m_Constant.SQL_CONSTR)

                'provider to be used when working with access database
                cn.Open()

                cmd = New SqlCommand(sql, cn)
                cmd.CommandTimeout = 0
                dr = cmd.ExecuteReader()

                dt = New DataTable
                dt.Load(dr)
                dt.Columns(0).ColumnName = "Name"
                dt.Columns(1).ColumnName = "Value"

                getDataTable.Add(dt)

            Catch ex As Exception
                MessageBox.Show("Error at BookDAL.getDataTable : " + ex.Message)
            Finally
                m_DBUtil.closeConnection(dr, cmd, cn)
                sb = Nothing
            End Try
            Return getDataTable
        End Function
        Public Function getBookList2(ByVal personID As String) As DataSet
            Dim cn As SqlConnection = Nothing
            Dim cmd As SqlCommand = Nothing
            Dim da As SqlDataAdapter = Nothing
            getBookList2 = New DataSet
            da = New SqlDataAdapter()

            Dim sb As StringBuilder = New StringBuilder
            With sb
                .Append("SELECT Title AS [도서명], ")
                .Append("       Publisher AS [출판사], ")
                .Append("       Author AS [저자], ")
                .Append("       [Book Barcode].Barcode AS [바코드], ")
                .Append("       [Book].[Book ID] AS [ID] ")
                .Append("FROM [Book], [Book Barcode] ")
                .Append("WHERE [Book].[Book ID] = [Book Barcode].[Book ID] ")
                .Append("AND [Book].[Book ID] NOT IN (SELECT [Book ID] FROM [Reserve Book] WHERE [Person ID] = @personID) ")
                .Append("ORDER BY Title ")
            End With

            Try
                cn = New SqlConnection(m_Constant.SQL_CONSTR)

                'provider to be used when working with access database
                cn.Open()
                cmd = New SqlCommand(sb.ToString, cn)
                cmd.CommandTimeout = 0

                cmd.Parameters.Add(New SqlParameter("@personID", SqlDbType.NVarChar)).Value = personID

                da.SelectCommand = cmd
                da.Fill(getBookList2, "getBookList2")

            Catch ex As Exception
                MessageBox.Show("Error at BookDAL.getBookList2 : " + ex.Message)
            Finally
                m_DBUtil.closeConnection(da, cn, cmd)
                sb = Nothing
            End Try
            Return getBookList2
        End Function
        Public Function getBookList(ByVal number As String, ByVal flag As Integer) As DataTable
            Dim sql As String = String.Empty
            Dim cn As SqlConnection = Nothing
            Dim cmd As SqlCommand = Nothing
            Dim dr As SqlDataReader = Nothing
            Dim sb As StringBuilder = New StringBuilder()

            getBookList = New DataTable

            With sb
                .Append("SELECT [Barcode] AS [Number], [Title], [Book Type], ")
                .Append("              [Book ID] AS [ID], ")
                .Append("              [Barcode] AS [ISBN], ")
                .Append("              [Author], [Publisher] ")
                .Append("FROM [Book],[Book Type] ")
                .Append("WHERE [Rented] != 'Y' ")
                .Append("AND [Book].[Book Type ID] = [Book Type].[Book Type ID] ")
            End With

            If number <> "" And number IsNot DBNull.Value Then
                sb.Append(" AND [Book].[Number] = @Number ")
            End If
            sb.Append("ORDER BY [Title] ")

            sql = sb.ToString

            Try
                cn = New SqlConnection(SQL_CONSTR)

                'provider to be used when working with access database
                cn.Open()

                cmd = New SqlCommand(sql, cn)
                cmd.CommandTimeout = 0
                If number <> "" Then
                    cmd.Parameters.Add(New SqlParameter("@Number", SqlDbType.NVarChar)).Value = number
                End If
                dr = cmd.ExecuteReader

                With getBookList
                    .Load(dr)
                    .Columns(0).ColumnName = "Number"
                    .Columns(1).ColumnName = "Title"
                    .Columns(2).ColumnName = "Book Type"
                    .Columns(3).ColumnName = "ID"
                End With

            Catch ex As Exception
                MessageBox.Show("Error at BookDAL.getBookList : " + ex.Message)
            Finally
                m_DBUtil.closeConnection(dr, cmd, cn)
                sb = Nothing
            End Try
            Return getBookList
        End Function

        'This function is to delete a Boom record
        Public Function deleteRecordByID(ByVal bookID As String, ByVal oneBarcode As String, ByVal barcodeID As String) As Integer
            Dim sql As String = String.Empty
            Dim cn As SqlConnection = Nothing
            Dim cmd As SqlCommand = Nothing
            Dim ta As SqlTransaction = Nothing
            Dim sb As StringBuilder = New StringBuilder()

            deleteRecordByID = 0

            With sb
                .Append("DELETE FROM [Book] WHERE [Book].[Book ID] = @BookID ")
            End With
            sql = sb.ToString()

            Try
                cn = New SqlConnection(m_Constant.SQL_CONSTR)

                'provider to be used when working with access database
                cn.Open()
                ta = cn.BeginTransaction()

                cmd = New SqlCommand(sql, cn)
                cmd.CommandTimeout = 0
                cmd.Transaction = ta

                cmd.Parameters.Add(New SqlParameter("@BookID", SqlDbType.Int)).Value = bookID
                deleteRecordByID = cmd.ExecuteNonQuery()
                If oneBarcode <> "" Then
                    If deleteRecordByID >= 1 Then
                        deleteRecordByID = deleteBookBarcodeRecordByBarcode(oneBarcode, barcodeID)
                    End If
                End If
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
        'This function is to delete a Boom record
        Public Function deleteBookBarcodeRecordByBarcode(ByVal barcode As String, ByVal barcodeID As String) As Integer
            Dim sql As String = String.Empty
            Dim cn As SqlConnection = Nothing
            Dim cmd As SqlCommand = Nothing
            Dim ta As SqlTransaction = Nothing
            Dim sb As StringBuilder = New StringBuilder()

            deleteBookBarcodeRecordByBarcode = 0

            With sb
                .Append("DELETE FROM [Book Barcode] WHERE [Book Barcode].[Barcode] = @Barcode ")
            End With
            sql = sb.ToString()

            Try
                cn = New SqlConnection(m_Constant.SQL_CONSTR)

                'provider to be used when working with access database
                cn.Open()
                ta = cn.BeginTransaction()

                cmd = New SqlCommand(sql, cn)
                cmd.CommandTimeout = 0
                cmd.Transaction = ta

                cmd.Parameters.Add(New SqlParameter("@Barcode", SqlDbType.NVarChar)).Value = barcode
                deleteBookBarcodeRecordByBarcode = cmd.ExecuteNonQuery()
                If deleteBookBarcodeRecordByBarcode >= 1 Then
                    Dim rentBookDAL As TKPC.DAL.RentBookDAL = TKPC.DAL.RentBookDAL.getInstance
                    Dim deleteRentRecords As Integer = 0
                    deleteRentRecords = rentBookDAL.deleteRecordByBarcodeID(barcodeID, False)
                End If
                ta.Commit()

            Catch ex As Exception
                ta.Rollback()
                deleteBookBarcodeRecordByBarcode = 0
                MessageBox.Show("Error at BookDAL.deleteBookBarcodeRecordByBarcode : " + ex.Message)
            Finally
                m_DBUtil.closeConnection(cmd, cn, ta)
                sb = Nothing
            End Try
            Return deleteBookBarcodeRecordByBarcode
        End Function
        Public Function insertRecord(ByRef bookEnt As TKPC.Entity.BookEnt) As Integer
            Dim sql As String = String.Empty
            Dim cn As SqlConnection = Nothing
            Dim cmd As SqlCommand = Nothing
            Dim ta As SqlTransaction = Nothing
            Dim sb As StringBuilder = New StringBuilder

            insertRecord = 0

            With sb
                .Append("INSERT INTO [Book] ")
                .Append("( ")
                .Append("     [Book].ISBN, ")
                .Append("     [Book].Title, ")
                .Append("     [Book].Subtitle, ")
                .Append("     [Book].Author, ")
                .Append("     [Book].Compiler, ")
                .Append("     [Book].Publisher, ")
                .Append("     [Book].[Book Type ID], ")
                .Append("     [Book].[Note], ")
                .Append("     [Book].[Last Update Date], ")
                .Append("     [Book].[Add Date] ")
                .Append(" ) ")
                .Append("VALUES ")
                .Append("(@ISBN,@Title,@Subtitle,@Author,@Compiler,@Publisher,@BookTypeID,@Note,@LastUpdateDate,@AddDate) ")
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

                If bookEnt.ISBN = String.Empty Then
                    cmd.Parameters.Add(New SqlParameter("@ISBN", SqlDbType.NVarChar, bookEnt.ISBN.Length, "ISBN")).Value = DBNull.Value
                Else
                    cmd.Parameters.Add(New SqlParameter("@ISBN", SqlDbType.NVarChar, bookEnt.ISBN.Length, "ISBN")).Value = bookEnt.ISBN
                End If

                If bookEnt.title = String.Empty Then
                    cmd.Parameters.Add(New SqlParameter("@Title", SqlDbType.NVarChar, bookEnt.title.Length, "Title")).Value = DBNull.Value
                Else
                    cmd.Parameters.Add(New SqlParameter("@Title", SqlDbType.NVarChar, bookEnt.title.Length, "Title")).Value = bookEnt.title
                End If

                If bookEnt.subtitle = String.Empty Then
                    cmd.Parameters.Add(New SqlParameter("@Subtitle", SqlDbType.NVarChar, bookEnt.subtitle.Length, "Subtitle")).Value = DBNull.Value
                Else
                    cmd.Parameters.Add(New SqlParameter("@Subtitle", SqlDbType.NVarChar, bookEnt.subtitle.Length, "Subtitle")).Value = bookEnt.subtitle
                End If

                If bookEnt.author = String.Empty Then
                    cmd.Parameters.Add(New SqlParameter("@Author", SqlDbType.NVarChar, bookEnt.author.Length, "Author")).Value = DBNull.Value
                Else
                    cmd.Parameters.Add(New SqlParameter("@Author", SqlDbType.NVarChar, bookEnt.author.Length, "Author")).Value = bookEnt.author
                End If

                If bookEnt.compiler = String.Empty Then
                    cmd.Parameters.Add(New SqlParameter("@Compiler", SqlDbType.NVarChar, bookEnt.compiler.Length, "Compiler")).Value = DBNull.Value
                Else
                    cmd.Parameters.Add(New SqlParameter("@Compiler", SqlDbType.NVarChar, bookEnt.compiler.Length, "Compiler")).Value = bookEnt.compiler
                End If

                If bookEnt.publisher = String.Empty Then
                    cmd.Parameters.Add(New SqlParameter("@Publisher", SqlDbType.NVarChar, bookEnt.publisher.Length, "Publisher")).Value = DBNull.Value
                Else
                    cmd.Parameters.Add(New SqlParameter("@Publisher", SqlDbType.NVarChar, bookEnt.publisher.Length, "Publisher")).Value = bookEnt.publisher
                End If

                If bookEnt.bookTypeID = String.Empty Then
                    cmd.Parameters.Add(New SqlParameter("@BookTypeID", SqlDbType.Int, bookEnt.bookTypeID.Length, "Book Type ID")).Value = DBNull.Value
                Else
                    cmd.Parameters.Add(New SqlParameter("@BookTypeID", SqlDbType.Int, bookEnt.bookTypeID.Length, "Book Type ID")).Value = bookEnt.bookTypeID
                End If

                If bookEnt.note = String.Empty Then
                    cmd.Parameters.Add(New SqlParameter("@Note", SqlDbType.NText, bookEnt.note.Length, "Note")).Value = DBNull.Value
                Else
                    cmd.Parameters.Add(New SqlParameter("@Note", SqlDbType.NText, bookEnt.note.Length, "Note")).Value = bookEnt.note
                End If

                If bookEnt.lastUpdateDate = String.Empty Then
                    cmd.Parameters.Add(New SqlParameter("@LastUpdateDate", SqlDbType.DateTime, bookEnt.lastUpdateDate.Length, "Last Update Date")).Value = DBNull.Value
                Else
                    cmd.Parameters.Add(New SqlParameter("@LastUpdateDate", SqlDbType.DateTime, bookEnt.lastUpdateDate.Length, "Last Update Date")).Value = bookEnt.lastUpdateDate
                End If

                If bookEnt.addDate = String.Empty Then
                    cmd.Parameters.Add(New SqlParameter("@AddDate", SqlDbType.DateTime, bookEnt.addDate.Length, "Add Date")).Value = DBNull.Value
                Else
                    cmd.Parameters.Add(New SqlParameter("@AddDate", SqlDbType.DateTime, bookEnt.addDate.Length, "Add Date")).Value = bookEnt.addDate
                End If

                insertRecord = cmd.ExecuteNonQuery()

                ta.Commit()

            Catch ex As Exception
                ta.Rollback()
                insertRecord = -1
                MessageBox.Show("Error at BookDAL.insertRecord : " + ex.Message)
            Finally
                m_DBUtil.closeConnection(cmd, cn, ta)
                sb = Nothing
            End Try
            Return insertRecord
        End Function
        Public Function insertBookBarcodeRecord(ByRef bookBarcodeEnt As TKPC.Entity.BookBarcodeEnt) As Integer
            Dim sql As String = String.Empty
            Dim cn As SqlConnection = Nothing
            Dim cmd As SqlCommand = Nothing
            Dim ta As SqlTransaction = Nothing
            Dim sb As StringBuilder = New StringBuilder

            insertBookBarcodeRecord = 0

            With sb
                .Append("INSERT INTO [Book Barcode] ")
                .Append("( ")
                .Append("     [Book Barcode].[Book ID], ")
                .Append("     [Book Barcode].Barcode, ")
                .Append("     [Book Barcode].[Purchase Or Donation Date], ")
                .Append("     [Book Barcode].[Purchase Or Donation], ")
                .Append("     [Book Barcode].[Purchase Or Donation Source], ")
                .Append("     [Book Barcode].[Status], ")
                .Append("     [Book Barcode].[Price], ")
                .Append("     [Book Barcode].[Note], ")
                .Append("     [Book Barcode].[Selected], ")
                .Append("     [Book Barcode].[Last Update Date] ")
                .Append(" ) ")
                .Append("VALUES ")
                .Append("(@BookID,@Barcode,@PDDate,@PD,@PDSource,@Status,@Price,@Note,@Selected,@LastUpdateDate) ")
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

                If bookBarcodeEnt.bookID = String.Empty Then
                    cmd.Parameters.Add(New SqlParameter("@BookID", SqlDbType.NVarChar, bookBarcodeEnt.bookID.Length, "BookID")).Value = DBNull.Value
                Else
                    cmd.Parameters.Add(New SqlParameter("@BookID", SqlDbType.NVarChar, bookBarcodeEnt.bookID.Length, "BookID")).Value = bookBarcodeEnt.bookID
                End If

                If bookBarcodeEnt.barcode = String.Empty Then
                    cmd.Parameters.Add(New SqlParameter("@Barcode", SqlDbType.NVarChar, bookBarcodeEnt.barcode.Length, "Barcode")).Value = DBNull.Value
                Else
                    cmd.Parameters.Add(New SqlParameter("@Barcode", SqlDbType.NVarChar, bookBarcodeEnt.barcode.Length, "Barcode")).Value = bookBarcodeEnt.barcode
                End If

                If bookBarcodeEnt.purchaseOrDonateDate = String.Empty Then
                    cmd.Parameters.Add(New SqlParameter("@PDDate", SqlDbType.DateTime, bookBarcodeEnt.purchaseOrDonateDate.Length, "PDDate")).Value = DBNull.Value
                Else
                    cmd.Parameters.Add(New SqlParameter("@PDDate", SqlDbType.DateTime, bookBarcodeEnt.purchaseOrDonateDate.Length, "PDDate")).Value = bookBarcodeEnt.purchaseOrDonateDate
                End If

                cmd.Parameters.Add(New SqlParameter("@PD", SqlDbType.NChar, 1, "Purchase Or Donate")).Value = bookBarcodeEnt.purchaseOrDonate

                If bookBarcodeEnt.purchaseOrDonateSource = String.Empty Then
                    cmd.Parameters.Add(New SqlParameter("@PDSource", SqlDbType.NVarChar, bookBarcodeEnt.purchaseOrDonateSource.Length, "PDSource")).Value = DBNull.Value
                Else
                    cmd.Parameters.Add(New SqlParameter("@PDSource", SqlDbType.NVarChar, bookBarcodeEnt.purchaseOrDonateSource.Length, "PDSource")).Value = bookBarcodeEnt.purchaseOrDonateSource
                End If

                If bookBarcodeEnt.status = String.Empty Then
                    cmd.Parameters.Add(New SqlParameter("@Status", SqlDbType.NVarChar, bookBarcodeEnt.status.Length, "Status")).Value = DBNull.Value
                Else
                    cmd.Parameters.Add(New SqlParameter("@Status", SqlDbType.NVarChar, bookBarcodeEnt.status.Length, "Status")).Value = bookBarcodeEnt.status
                End If

                cmd.Parameters.Add(New SqlParameter("@Price", SqlDbType.Decimal, bookBarcodeEnt.price.Length, "Price")).Value = bookBarcodeEnt.price

                If bookBarcodeEnt.note = String.Empty Then
                    cmd.Parameters.Add(New SqlParameter("@Note", SqlDbType.NText, bookBarcodeEnt.note.Length, "Note")).Value = DBNull.Value
                Else
                    cmd.Parameters.Add(New SqlParameter("@Note", SqlDbType.NText, bookBarcodeEnt.note.Length, "Note")).Value = bookBarcodeEnt.note
                End If

                cmd.Parameters.Add(New SqlParameter("@Selected", SqlDbType.Bit, 1, "Selected")).Value = 0

                If bookBarcodeEnt.lastUpdateDate = String.Empty Then
                    cmd.Parameters.Add(New SqlParameter("@LastUpdateDate", SqlDbType.DateTime, bookBarcodeEnt.lastUpdateDate.Length, "Last Update Date")).Value = DBNull.Value
                Else
                    cmd.Parameters.Add(New SqlParameter("@LastUpdateDate", SqlDbType.DateTime, bookBarcodeEnt.lastUpdateDate.Length, "Last Update Date")).Value = bookBarcodeEnt.lastUpdateDate
                End If

                insertBookBarcodeRecord = cmd.ExecuteNonQuery()
                ta.Commit()

            Catch ex As Exception
                ta.Rollback()
                insertBookBarcodeRecord = -1
                MessageBox.Show("Error at BookDAL.insertBookBarcodeRecord : " + ex.Message)
            Finally
                m_DBUtil.closeConnection(cmd, cn, ta)
                sb = Nothing
            End Try
            Return insertBookBarcodeRecord
        End Function

        Public Function updateRecord(ByRef bookEnt As TKPC.Entity.BookEnt) As Integer
            Dim sql As String = String.Empty
            Dim cn As SqlConnection = Nothing
            Dim cmd As SqlCommand = Nothing
            Dim ta As SqlTransaction = Nothing
            Dim sb As StringBuilder = New StringBuilder()
            updateRecord = 0

            With sb
                .Append("UPDATE [Book] ")
                .Append("SET  ")
                .Append("     [Book].ISBN = @ISBN, ")
                .Append("     [Book].Title = @Title, ")
                .Append("     [Book].Subtitle = @Subtitle, ")
                .Append("     [Book].Author = @Author, ")
                .Append("     [Book].Compiler = @Compiler, ")
                .Append("     [Book].Publisher = @Publisher, ")
                .Append("     [Book].[Book Type ID] = @BookTypeID, ")
                .Append("     [Book].Note = @Note, ")
                .Append("     [Book].[Last Update Date] = @LastUpdateDate ")
                .Append("WHERE [Book ID] = @BookID ")
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

                If bookEnt.ISBN = String.Empty Then
                    cmd.Parameters.Add(New SqlParameter("@ISBN", SqlDbType.NVarChar, bookEnt.ISBN.Length, "ISBN")).Value = DBNull.Value
                Else
                    cmd.Parameters.Add(New SqlParameter("@ISBN", SqlDbType.NVarChar, bookEnt.ISBN.Length, "ISBN")).Value = bookEnt.ISBN
                End If

                If bookEnt.title = String.Empty Then
                    cmd.Parameters.Add(New SqlParameter("@Title", SqlDbType.NVarChar, bookEnt.title.Length, "Title")).Value = DBNull.Value
                Else
                    cmd.Parameters.Add(New SqlParameter("@Title", SqlDbType.NVarChar, bookEnt.title.Length, "Title")).Value = bookEnt.title
                End If

                If bookEnt.subtitle = "" Then
                    cmd.Parameters.Add(New SqlParameter("@Subtitle", SqlDbType.NVarChar, bookEnt.subtitle.Length, "Subtitle")).Value = DBNull.Value
                Else
                    cmd.Parameters.Add(New SqlParameter("@Subtitle", SqlDbType.NVarChar, bookEnt.subtitle.Length, "Subtitle")).Value = bookEnt.subtitle
                End If

                If bookEnt.author = "" Then
                    cmd.Parameters.Add(New SqlParameter("@Author", SqlDbType.NVarChar, bookEnt.author.Length, "Author")).Value = DBNull.Value
                Else
                    cmd.Parameters.Add(New SqlParameter("@Author", SqlDbType.NVarChar, bookEnt.author.Length, "Author")).Value = bookEnt.author
                End If

                If bookEnt.compiler = "" Then
                    cmd.Parameters.Add(New SqlParameter("@Compiler", SqlDbType.NVarChar, bookEnt.compiler.Length, "Compiler")).Value = DBNull.Value
                Else
                    cmd.Parameters.Add(New SqlParameter("@Compiler", SqlDbType.NVarChar, bookEnt.compiler.Length, "Compiler")).Value = bookEnt.compiler
                End If

                If bookEnt.publisher = "" Then
                    cmd.Parameters.Add(New SqlParameter("@Publisher", SqlDbType.NVarChar, bookEnt.publisher.Length, "Publisher")).Value = DBNull.Value
                Else
                    cmd.Parameters.Add(New SqlParameter("@Publisher", SqlDbType.NVarChar, bookEnt.publisher.Length, "Publisher")).Value = bookEnt.publisher
                End If

                If bookEnt.bookTypeID = String.Empty Then
                    cmd.Parameters.Add(New SqlParameter("@BookTypeID", SqlDbType.NVarChar, bookEnt.bookTypeID.Length, "Book Type ID")).Value = DBNull.Value
                Else
                    cmd.Parameters.Add(New SqlParameter("@BookTypeID", SqlDbType.NVarChar, bookEnt.bookTypeID.Length, "Book Type ID")).Value = bookEnt.bookTypeID
                End If

                If bookEnt.note = String.Empty Then
                    cmd.Parameters.Add(New SqlParameter("@Note", SqlDbType.NText, bookEnt.note.Length, "Note")).Value = DBNull.Value
                Else
                    cmd.Parameters.Add(New SqlParameter("@Note", SqlDbType.NText, bookEnt.note.Length, "Note")).Value = bookEnt.note
                End If

                If bookEnt.lastUpdateDate = String.Empty Then
                    cmd.Parameters.Add(New SqlParameter("@LastUpdateDate", SqlDbType.DateTime, bookEnt.lastUpdateDate.Length, "Last Update Date")).Value = DBNull.Value
                Else
                    cmd.Parameters.Add(New SqlParameter("@LastUpdateDate", SqlDbType.DateTime, bookEnt.lastUpdateDate.Length, "Last Update Date")).Value = bookEnt.lastUpdateDate
                End If

                cmd.Parameters.Add(New SqlParameter("@BookID", SqlDbType.NVarChar, bookEnt.bookID.Length, "")).Value = bookEnt.bookID

                updateRecord = cmd.ExecuteNonQuery()
                ta.Commit()

            Catch ex As Exception
                ta.Rollback()
                MessageBox.Show("Error at BookDAL.updateRecord : " + ex.Message)
            Finally
                m_DBUtil.closeConnection(cmd, cn, ta)
                sb = Nothing
            End Try
            Return updateRecord
        End Function
        Public Function updateBookBarcodeRecord(ByRef bookBarcodeEnt As TKPC.Entity.BookBarcodeEnt) As Integer
            Dim sql As String = String.Empty
            Dim cn As SqlConnection = Nothing
            Dim cmd As SqlCommand = Nothing
            Dim ta As SqlTransaction = Nothing
            Dim sb As StringBuilder = New StringBuilder()
            updateBookBarcodeRecord = 0

            With sb
                .Append("UPDATE [Book Barcode] ")
                .Append("SET  ")
                .Append("     [Book Barcode].[Book ID] = @BookID, ")
                .Append("     [Book Barcode].Barcode = @Barcode, ")
                .Append("     [Book Barcode].[Purchase Or Donation Date] = @PDDate, ")
                .Append("     [Book Barcode].[Purchase Or Donation] = @PD, ")
                .Append("     [Book Barcode].[Purchase Or Donation Source] = @PDSource, ")
                .Append("     [Book Barcode].Status = @Status, ")
                .Append("     [Book Barcode].Note = @Note, ")
                .Append("     [Book Barcode].[Last Update Date] = @LastUpdateDate, ")
                .Append("     [Book Barcode].[Price] = @Price ")
                .Append("WHERE [Barcode ID] = @BarcodeID ")
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

                cmd.Parameters.Add(New SqlParameter("@BookID", SqlDbType.NVarChar, bookBarcodeEnt.bookID.Length, "")).Value = bookBarcodeEnt.bookID

                If bookBarcodeEnt.barcode = String.Empty Then
                    cmd.Parameters.Add(New SqlParameter("@Barcode", SqlDbType.NVarChar, bookBarcodeEnt.barcode.Length, "Barcode")).Value = DBNull.Value
                Else
                    cmd.Parameters.Add(New SqlParameter("@Barcode", SqlDbType.NVarChar, bookBarcodeEnt.barcode.Length, "Barcode")).Value = bookBarcodeEnt.barcode
                End If

                If bookBarcodeEnt.purchaseOrDonateDate = String.Empty Then
                    cmd.Parameters.Add(New SqlParameter("@PDDate", SqlDbType.DateTime, bookBarcodeEnt.purchaseOrDonateDate.Length, "Purchase Or Donation Date")).Value = DBNull.Value
                Else
                    cmd.Parameters.Add(New SqlParameter("@PDDate", SqlDbType.DateTime, bookBarcodeEnt.purchaseOrDonateDate.Length, "Purchase Or Donation Date")).Value = bookBarcodeEnt.purchaseOrDonateDate
                End If

                cmd.Parameters.Add(New SqlParameter("@PD", SqlDbType.NChar, 1, "Purchase Or Donation")).Value = bookBarcodeEnt.purchaseOrDonate

                If bookBarcodeEnt.purchaseOrDonateSource = String.Empty Then
                    cmd.Parameters.Add(New SqlParameter("@PDSource", SqlDbType.NVarChar, bookBarcodeEnt.purchaseOrDonateSource.Length, "Purchase Or Donation Source")).Value = DBNull.Value
                Else
                    cmd.Parameters.Add(New SqlParameter("@PDSource", SqlDbType.NVarChar, bookBarcodeEnt.purchaseOrDonateSource.Length, "Purchase Or Donation Source")).Value = bookBarcodeEnt.purchaseOrDonateSource
                End If

                If bookBarcodeEnt.status = String.Empty Then
                    cmd.Parameters.Add(New SqlParameter("@Status", SqlDbType.NVarChar, bookBarcodeEnt.status.Length, "Status")).Value = DBNull.Value
                Else
                    cmd.Parameters.Add(New SqlParameter("@Status", SqlDbType.NVarChar, bookBarcodeEnt.status.Length, "Status")).Value = bookBarcodeEnt.status
                End If

                If bookBarcodeEnt.note = String.Empty Then
                    cmd.Parameters.Add(New SqlParameter("@Note", SqlDbType.NText, bookBarcodeEnt.note.Length, "Note")).Value = DBNull.Value
                Else
                    cmd.Parameters.Add(New SqlParameter("@Note", SqlDbType.NText, bookBarcodeEnt.note.Length, "Note")).Value = bookBarcodeEnt.note
                End If

                If bookBarcodeEnt.lastUpdateDate = String.Empty Then
                    cmd.Parameters.Add(New SqlParameter("@LastUpdateDate", SqlDbType.DateTime, bookBarcodeEnt.lastUpdateDate.Length, "Last Update Date")).Value = DBNull.Value
                Else
                    cmd.Parameters.Add(New SqlParameter("@LastUpdateDate", SqlDbType.DateTime, bookBarcodeEnt.lastUpdateDate.Length, "Last Update Date")).Value = bookBarcodeEnt.lastUpdateDate
                End If

                cmd.Parameters.Add(New SqlParameter("@Price", SqlDbType.Decimal, bookBarcodeEnt.price.Length, "Price")).Value = bookBarcodeEnt.price
                cmd.Parameters.Add(New SqlParameter("@BarcodeID", SqlDbType.NVarChar, bookBarcodeEnt.barcodeID.Length, "")).Value = bookBarcodeEnt.barcodeID

                updateBookBarcodeRecord = cmd.ExecuteNonQuery()
                ta.Commit()

                If updateBookBarcodeRecord >= 1 Then
                    Dim rentDAL As TKPC.DAL.RentBookDAL = TKPC.DAL.RentBookDAL.getInstance
                    Try
                        Dim flag As Integer = 0
                        If bookBarcodeEnt.status = "L" Then
                            flag = 1
                        Else
                            flag = 0
                        End If
                        Dim updateRentBookRecord As Integer = 0
                        updateRentBookRecord = rentDAL.updateRentBookFlags(flag, bookBarcodeEnt.barcodeID)
                    Catch ex As Exception
                    Finally
                        rentDAL = Nothing
                    End Try
                End If

            Catch ex As Exception
                ta.Rollback()
                MessageBox.Show("Error at BookDAL.updateBookBarcodeRecord : " + ex.Message)
            Finally
                m_DBUtil.closeConnection(cmd, cn, ta)
                sb = Nothing
            End Try
            Return updateBookBarcodeRecord
        End Function
        Public Function updateRecord(ByVal barcodeID As String, ByVal Status As String, ByVal Selected As Integer, ByVal personID As String) As Integer
            Dim sql As String = String.Empty
            Dim cn As SqlConnection = Nothing
            Dim cmd As SqlCommand = Nothing
            Dim ta As SqlTransaction = Nothing
            Dim sb As StringBuilder = New StringBuilder()
            updateRecord = 0

            With sb
                .Append("UPDATE [Book Barcode] ")
                .Append("SET  ")
                .Append("     [Book Barcode].[Status] = @Status, ")
                '.Append("     [Book Barcode].[Selected] = @Selected, ")
                .Append("     [Book Barcode].[Person ID] = @PersonID, ")
                .Append("     [Book Barcode].[Last Update Date] = @LastUpdateDate, ")
                .Append("     [Book Barcode].[Last Rent Date] = @LastRentDate ")
                .Append("WHERE [Barcode ID] = @BarcodeID ")
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

                cmd.Parameters.Add(New SqlParameter("@Status", SqlDbType.NChar)).Value = Status
                'cmd.Parameters.Add(New SqlParameter("@Selected", SqlDbType.Int)).Value = Selected
                cmd.Parameters.Add(New SqlParameter("@LastUpdateDate", SqlDbType.DateTime)).Value = Today.Date
                cmd.Parameters.Add(New SqlParameter("@LastRentDate", SqlDbType.DateTime)).Value = Today.Date
                cmd.Parameters.Add(New SqlParameter("@BarcodeID", SqlDbType.NVarChar)).Value = barcodeID
                cmd.Parameters.Add(New SqlParameter("@PersonID", SqlDbType.Int)).Value = personID

                updateRecord = cmd.ExecuteNonQuery()
                ta.Commit()

            Catch ex As Exception
                ta.Rollback()
                MessageBox.Show("Error at BookDAL.updateRecord into [Book Barcode] Table : " + ex.Message)
            Finally
                m_DBUtil.closeConnection(cmd, cn, ta)
                sb = Nothing
            End Try
            Return updateRecord
        End Function

        Public Function updateBookFlags(ByVal flag As Integer, ByVal IDs As String) As Integer
            Dim sql As String = String.Empty
            Dim cn As SqlConnection = Nothing
            Dim cmd As SqlCommand = Nothing
            Dim ta As SqlTransaction = Nothing
            Dim sb As StringBuilder = New StringBuilder
            updateBookFlags = 0

            If flag = 0 Then
                With sb
                    .Append("UPDATE [Book Barcode] ")
                    .Append("SET  ")
                    .Append("     [Book Barcode].[Status] = 'A', ")
                    .Append("     [Book Barcode].[Selected] = 0, ")
                    .Append("     [Book Barcode].[Last Update Date] = @LastUpdateDate ")
                    .Append("WHERE ID IN (@ID) ")
                End With
            Else
                With sb
                    .Append("UPDATE [Book Barcode] ")
                    .Append("SET  ")
                    .Append("     [Book Barcode].[Selected] = 0 ")
                End With
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

                If flag = 0 Then
                    cmd.Parameters.Add(New SqlParameter("@LastUpdateDate", SqlDbType.DateTime)).Value = Today.Date
                    cmd.Parameters.Add(New SqlParameter("@ID", SqlDbType.NVarChar)).Value = IDs
                End If

                updateBookFlags = cmd.ExecuteNonQuery()
                ta.Commit()

            Catch ex As Exception
                ta.Rollback()
                MessageBox.Show("Error at BookDAL.updateBookFlags : " + ex.Message)
            Finally
                m_DBUtil.closeConnection(cmd, cn, ta)
                sb = Nothing
            End Try
            Return updateBookFlags
        End Function

        Public Function updateRecord(ByVal flag As Integer, ByVal barcodeID As String, ByVal Selected As Integer) As Integer
            Dim sql As String = String.Empty
            Dim cn As SqlConnection = Nothing
            Dim cmd As SqlCommand = Nothing
            Dim ta As SqlTransaction = Nothing
            Dim sb As StringBuilder = New StringBuilder
            updateRecord = 0


            With sb
                .Append("UPDATE [Book Barcode] ")
                .Append("SET  ")
                .Append("     [Book Barcode].[Selected] = @Selected ")
                .Append("WHERE [Barcode ID] = @BarcodeID ")
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

                cmd.Parameters.Add(New SqlParameter("@Selected", SqlDbType.Bit)).Value = Selected
                cmd.Parameters.Add(New SqlParameter("@BarcodeID", SqlDbType.NVarChar)).Value = barcodeID

                updateRecord = cmd.ExecuteNonQuery()
                ta.Commit()

            Catch ex As Exception
                ta.Rollback()
                MessageBox.Show("Error at BookDAL.updateRecord : " + ex.Message)
            Finally
                m_DBUtil.closeConnection(cmd, cn, ta)
                sb = Nothing
            End Try
            Return updateRecord
        End Function

        Public Function updateRecordBarcodePrintStatus(ByVal barcodes As String) As Integer
            Dim sql As String = String.Empty
            Dim cn As SqlConnection = Nothing
            Dim cmd As SqlCommand = Nothing
            Dim ta As SqlTransaction = Nothing
            Dim sb As StringBuilder = New StringBuilder
            updateRecordBarcodePrintStatus = 0

            With sb
                .Append("DELETE FROM [Barcode For Print] ")
                '.Append("WHERE Barcode IN (@barcodes) ")
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

                'cmd.Parameters.Add(New SqlParameter("@barcodes", SqlDbType.NVarChar)).Value = barcodes

                updateRecordBarcodePrintStatus = cmd.ExecuteNonQuery()
                ta.Commit()

            Catch ex As Exception
                ta.Rollback()
                MessageBox.Show("Error at BookDAL.updateRecordBarcodePrintStatus : " + ex.Message)
            Finally
                m_DBUtil.closeConnection(cmd, cn, ta)
                sb = Nothing
            End Try
            Return updateRecordBarcodePrintStatus
        End Function
        Public Function getPublisherList(ByVal searchWords As String) As DataSet
            Dim sql As String = String.Empty
            Dim cn As SqlConnection = Nothing
            Dim cmd As SqlCommand = Nothing
            Dim da As SqlDataAdapter = Nothing
            getPublisherList = New DataSet
            da = New SqlDataAdapter()
            Dim sb As StringBuilder = New StringBuilder()

            With sb
                .Append("SELECT DISTINCT [Book].Publisher FROM [Book] ")
            End With

            If searchWords <> "" Then
                sb.Append("WHERE [Book].[Publisher] LIKE @Name ")
            End If
            sb.Append("ORDER BY [Book].[Publisher]")
            sql = sb.ToString

            Try
                cn = New SqlConnection(m_Constant.SQL_CONSTR)

                'provider to be used when working with access database
                cn.Open()
                cmd = New SqlCommand(sql, cn)
                cmd.CommandTimeout = 0

                If searchWords <> "" Then
                    cmd.Parameters.Add(New SqlParameter("@Name", SqlDbType.NVarChar)).Value = searchWords.ToUpper
                End If

                da.SelectCommand = cmd
                da.Fill(getPublisherList, "getList")

            Catch ex As Exception
                MessageBox.Show("Error at BookDAL.getPublisherList : " + ex.Message)
            Finally
                m_DBUtil.closeConnection(da, cn, cmd)
                sb = Nothing
            End Try
            Return getPublisherList
        End Function

        Public Function checkIfBarcodeExists(ByVal barcode As String) As Integer
            Dim sql As String = String.Empty
            Dim cn As SqlConnection = Nothing
            Dim cmd As SqlCommand = Nothing
            Dim dr As SqlDataReader = Nothing
            Dim sb As StringBuilder = New StringBuilder
            checkIfBarcodeExists = 0

            With sb
                .Append("SELECT COUNT([Barcode]) AS cnt ")
                .Append("FROM [Book Barcode] ")
                .Append("WHERE Barcode = @Barcode ")
            End With
            sql = sb.ToString

            Try
                cn = New SqlConnection(m_Constant.SQL_CONSTR)

                'provider to be used when working with access database
                cn.Open()

                cmd = New SqlCommand(sql, cn)
                cmd.CommandTimeout = 0
                cmd.Parameters.Add(New SqlParameter("@Barcode", SqlDbType.NVarChar)).Value = barcode

                dr = cmd.ExecuteReader()

                If dr.Read() Then
                    checkIfBarcodeExists = dr("cnt")
                End If

            Catch ex As Exception
                MessageBox.Show("Error at BookDAL.checkIfBarcodeExists : " + ex.Message)
            Finally
                m_DBUtil.closeConnection(dr, cmd, cn)
                sb = Nothing
            End Try
            Return checkIfBarcodeExists

        End Function

        Public Function insertCopyTRecord(ByVal seq As Integer) As Integer
            Dim sql As String = String.Empty
            Dim cn As SqlConnection = Nothing
            Dim cmd As SqlCommand = Nothing
            Dim ta As SqlTransaction = Nothing
            Dim sb As StringBuilder = New StringBuilder

            insertCopyTRecord = 0

            With sb
                .Append("INSERT INTO [Copy_T] ")
                .Append("( ")
                .Append("     [Copy_T].[No] ")
                .Append(" ) ")
                .Append("VALUES ")
                .Append("(@No) ")
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

                cmd.Parameters.Add(New SqlParameter("@No", SqlDbType.Int, 1, "No")).Value = seq

                insertCopyTRecord = cmd.ExecuteNonQuery()
                ta.Commit()

            Catch ex As Exception
                ta.Rollback()
                insertCopyTRecord = -1
                MessageBox.Show("Error at BookDAL.insertCopyTRecord : " + ex.Message)
            Finally
                m_DBUtil.closeConnection(cmd, cn, ta)
                sb = Nothing
            End Try
            Return insertCopyTRecord
        End Function

    End Class
End Namespace

