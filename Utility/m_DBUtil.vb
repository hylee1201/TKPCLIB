Imports System.Data.SqlClient
Imports System.Data.Odbc
Imports System.Data.OleDb
Imports System.Text

Module m_DBUtil
    Dim cn As SqlConnection
    Dim cmd As SqlCommand
    Dim dr As SqlDataReader
    Dim da As SqlDataAdapter
    Dim ta As SqlTransaction

    'This procedure is for closing DB connection, command and resultset.
    Public Sub closeConnection(ByRef dr As SqlDataReader, ByRef cmd As SqlCommand, ByRef cn As SqlConnection)
        If dr IsNot Nothing Then
            dr.Close()
            dr = Nothing  'release this object from memory
        End If
        If cmd IsNot Nothing Then
            cmd.Dispose()
            cmd = Nothing  'release this object from memory
        End If
        If cn IsNot Nothing Then
            cn.Close()
            cn.Dispose()
            cn = Nothing  'release this object from memory
        End If
    End Sub


    'This procedure is for closing DB connection, command and resultset.
    Public Sub closeConnection(ByRef da As SqlDataAdapter, ByRef cn As SqlConnection)
        If da IsNot Nothing Then
            da.Dispose()
            da = Nothing  'release this object from memory
        End If
        If cn IsNot Nothing Then
            cn.Close()
            cn.Dispose()
            cn = Nothing  'release this object from memory
        End If
    End Sub

    'This procedure is for closing DB connection, command and resultset.
    Public Sub closeConnection(ByRef da As SqlDataAdapter, ByRef cn As SqlConnection, ByRef cmd As SqlCommand)
        If da IsNot Nothing Then
            da.Dispose()
            da = Nothing  'release this object from memory
        End If
        If cn IsNot Nothing Then
            cn.Close()
            cn.Dispose()
            cn = Nothing  'release this object from memory
        End If

        If cmd IsNot Nothing Then
            cmd.Dispose()
            cmd = Nothing  'release this object from memory
        End If
    End Sub

    Public Sub closeConnection(ByRef da As SqlDataAdapter, ByRef cn As SqlConnection, ByRef ta As SqlTransaction)
        If da IsNot Nothing Then
            da.Dispose()
            da = Nothing  'release this object from memory
        End If

        If cn IsNot Nothing Then
            cn.Close()
            cn.Dispose()
            cn = Nothing  'release this object from memory
        End If

        If ta IsNot Nothing Then
            ta.Dispose()
            ta = Nothing
        End If
    End Sub
    Public Sub closeConnection(ByRef cmd As SqlCommand, ByRef cn As SqlConnection, ByRef ta As SqlTransaction)
        If cmd IsNot Nothing Then
            cmd.Dispose()
            cmd = Nothing  'release this object from memory
        End If

        If cn IsNot Nothing Then
            cn.Close()
            cn.Dispose()
            cn = Nothing  'release this object from memory
        End If

        If ta IsNot Nothing Then
            ta.Dispose()
            ta = Nothing
        End If
    End Sub

    'This function is to generate a serial number
    Public Function generateNumber(ByVal bookTypeID As String) As String
        Dim sql As String = ""
        generateNumber = ""
        Dim firstNum As String = ""
        Dim secNum As String = ""
        Dim sb As StringBuilder = New StringBuilder

        Try
            cn = New SqlConnection(m_Constant.SQL_CONSTR)
            cn.Open()

            'sql = "SELECT RIGHT('00000' + LTRIM(STR(ISNULL(MAX(CAST(SUBSTRING(Number, 1, { fn LENGTH(Number) }) AS int)), 0) + 1)), 5) AS Number " & _
            '        "FROM Book " & _
            '        "WHERE (IsNumeric(Number) = 1) AND ([Book Type ID] = ?) "

            'Check if there is a missing number at the first row.
            'If there is one, use it
            'sql = "SELECT  ISNULL(MIN(Number), - 1) + 1 AS Expr1 " & _
            '        "FROM Book AS y " & _
            '        "WHERE  ([Book Type ID] = @BookTypeID) AND (NOT EXISTS " & _
            '        "              (SELECT 1 AS Expr1 " & _
            '        "               FROM  Book AS i " & _
            '        "               WHERE (Number = y.Number + 1))) AND ((Number + 1) NOT IN " & _
            '        "                            (SELECT Number FROM Book AS Book_1)) " & _
            '        "UNION ALL " & _
            '        "SELECT ISNULL(MAX(Number),0)+1 AS Expr1 " & _
            '        "FROM Book " & _
            '        "WHERE ([Book Type ID] = @BookTypeID) "

            With sb
                '.Append("SELECT ISNULL(MIN(CAST(SUBSTRING(Barcode, CHARINDEX('-',Barcode)+1, 6) AS int)),-1)+1 AS Expr1 ")
                '.Append("FROM [Book Barcode] y ")
                '.Append("WHERE SUBSTRING(Barcode, 0, CHARINDEX('-',Barcode)) = @BookTypeID ")
                '.Append("AND (NOT EXISTS (SELECT 1 AS Expr1 ")
                '.Append("                                FROM [Book Barcode]  AS i ")
                '.Append("WHERE (CAST(SUBSTRING(Barcode, CHARINDEX('-',Barcode)+1, 6) AS int) = CAST(SUBSTRING(y.Barcode, CHARINDEX('-',y.Barcode)+1, 6) AS int) + 1)) ")
                '.Append("AND (CAST(SUBSTRING(Barcode, CHARINDEX('-',Barcode)+1, 6) AS int) + 1) NOT IN (SELECT CAST(SUBSTRING(Barcode, CHARINDEX('-',Barcode)+1, 6) AS int) FROM [Book Barcode] AS Book_1)) ")
                '.Append("UNION ")
                '.Append("SELECT ISNULL(MAX(CAST(SUBSTRING(Barcode, CHARINDEX('-',Barcode)+1, 6) AS int)),0)+1 AS Expr1 ")
                '.Append("FROM [Book Barcode] y ")
                '.Append("WHERE SUBSTRING(Barcode, 0, CHARINDEX('-',Barcode)) = @BookTypeID ")
                .Append("SELECT ISNULL(MIN(No), 0) AS Expr1 ")
                .Append("FROM Copy_T ")
                .Append("WHERE (NOT EXISTS ")
                .Append("                     (SELECT 1 AS Expr1 ")
                .Append("                         FROM [Book Barcode] ")
                .Append("                        WHERE (Copy_T.No = CAST(SUBSTRING(Barcode, CHARINDEX('-', Barcode) + 1, 6) AS int)) ")
                .Append("                            AND (SUBSTRING(Barcode, 0, CHARINDEX('-', Barcode)) = @BookTypeID))) ")
                .Append("UNION ")
                .Append("SELECT ISNULL(MAX(CAST(SUBSTRING(Barcode, CHARINDEX('-',Barcode)+1, 6) AS int)),0)+1 AS Expr1 ")
                .Append("FROM [Book Barcode] y ")
                .Append("WHERE SUBSTRING(Barcode, 0, CHARINDEX('-',Barcode)) = @BookTypeID ")
            End With
            sql = sb.ToString

            cmd = New SqlCommand(sql, cn)
            cmd.CommandTimeout = 0
            cmd.Parameters.Add(New SqlParameter("@BookTypeID", SqlDbType.NVarChar)).Value = bookTypeID
            dr = cmd.ExecuteReader()

            Dim cnt As Integer = 0
            While dr.Read()
                If cnt = 0 Then
                    firstNum = dr(0)
                Else
                    secNum = dr(0)
                End If
                cnt = cnt + 1
            End While

            If firstNum = "0" Then
                generateNumber = secNum
            Else
                generateNumber = firstNum
            End If

        Catch ex As Exception
            Console.WriteLine("Error at m_DBUtil.generateNumber : " + ex.Message)
        Finally
            closeConnection(dr, cmd, cn)
            sb = Nothing
        End Try
        Return generateNumber
    End Function

    'This function is to generate a serial number
    Public Function getMaxNumber(ByVal tabName As String, ByVal colName As String) As String
        Dim sql As String = ""
        getMaxNumber = ""

        Try
            cn = New SqlConnection(m_Constant.SQL_CONSTR)
            cn.Open()

            sql = "SELECT MAX([" + colName + "]) " & _
                   "FROM " + tabName

            cmd = New SqlCommand(sql, cn)
            cmd.CommandTimeout = 0
            dr = cmd.ExecuteReader()

            If dr.Read() Then
                getMaxNumber = dr(0)
            End If

        Catch ex As Exception
            Console.WriteLine("Error at m_DBUtil.getMaxNumber : " + ex.Message)
        Finally
            closeConnection(dr, cmd, cn)
        End Try
        Return getMaxNumber
    End Function

    Public Function getNextNumber(ByVal tabName As String, ByVal colName As String) As String
        Dim sql As String = ""
        getNextNumber = ""

        Try
            cn = New SqlConnection(m_Constant.SQL_CONSTR)
            cn.Open()

            sql = "SELECT ISNULL(MAX([" + colName + "]),0)+1 " & _
                     "FROM " + tabName

            cmd = New SqlCommand(sql, cn)
            cmd.CommandTimeout = 0
            dr = cmd.ExecuteReader()

            If dr.Read() Then
                getNextNumber = dr(0)
            End If

        Catch ex As Exception
            Console.WriteLine("Error at m_DBUtil.getNextNumber : " + ex.Message)
        Finally
            closeConnection(dr, cmd, cn)
        End Try
        Return getNextNumber
    End Function

    Public Function getBarcode(ByVal bookTypeID As String, ByVal number As String) As String
        getBarcode = ""
        Dim pid As String = "0"
        Dim i As String = ""

        If number = String.Empty Or number = "" Or number = "0" Then
            i = generateNumber(bookTypeID)
        Else
            i = number
        End If

        'Do the same thing for the page number (well, techically not page number -- but document ID)
        If Len(i) < 5 Then
            Select Case 5 - Len(i)
                Case 1
                    pid = "0" & i
                Case 2
                    pid = "00" & i
                Case 3
                    pid = "000" & i
                Case 4
                    pid = "0000" & i
            End Select
        Else
            pid = i
        End If

        'Set the barcode "code" with what we created
        getBarcode = bookTypeID & "-" & pid
    End Function

    Public Function checkDBConnection() As Integer
        Dim sql As String = ""
        checkDBConnection = 0

        Try
            cn = New SqlConnection(m_Constant.SQL_CONSTR)
            cn.Open()

        Catch ex As Exception
            checkDBConnection = -1
        Finally
            cn.Close()
            cn.Dispose()
        End Try
        Return checkDBConnection
    End Function

End Module




