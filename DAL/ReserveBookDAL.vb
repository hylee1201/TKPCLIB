Imports System.Data.SqlClient
Imports System.Text

Namespace TKPC.DAL
    Public Class ReserveBookDAL
        Private Shared Instance As ReserveBookDAL

        Protected Sub New()
        End Sub

        'To make this DAL singleton to use memory efficiently
        Public Shared Function getInstance() As ReserveBookDAL
            ' initialize if not already done
            If Instance Is Nothing Then
                Instance = New ReserveBookDAL
            End If
            ' return the initialized instance of the Singleton Class
            Return Instance
        End Function 'Instance

        'This function is for a binding purpose
        Public Function getReserveBookList(ByVal flag As Integer, ByVal BookID As String) As DataSet
            Dim sql As String = String.Empty
            Dim cn As SqlConnection = Nothing
            Dim cmd As SqlCommand = Nothing
            Dim da As SqlDataAdapter = Nothing
            Dim sb As StringBuilder = New StringBuilder

            getReserveBookList = New DataSet
            da = New SqlDataAdapter()

            With sb
                .Append("SELECT ID, [Reserve Book].[Selected] AS [선택], ")
                .Append("       [Reserve Book].[Book ID], [Reserve Book].[Person ID], ")
                .Append("       [Person].[Name] AS [이름], ")
                .Append("       [Person].[Home Tel] AS [집 전화], ")
                .Append("       [Reserve Date] AS [예약일] ")
                .Append("FROM [Reserve Book], [Person] ")
                .Append("WHERE [Reserve Book].[Person ID] = [Person].[Person ID] ")
            End With

            Select Case flag
                Case 0
                    sb.Append("AND [Reserve Book].[Book ID] = @ReserveBookID ")

            End Select
            sb.Append("ORDER BY [Reserve Date] ")

            sql = sb.ToString

            Try
                cn = New SqlConnection(m_Constant.SQL_CONSTR)

                'provider to be used when working with access database
                cn.Open()
                cmd = New SqlCommand(sql, cn)
                cmd.CommandTimeout = 0

                Select Case flag
                    Case 0
                        cmd.Parameters.Add(New SqlParameter("@ReserveBookID", SqlDbType.VarChar)).Value = BookID
                End Select

                da.SelectCommand = cmd
                da.Fill(getReserveBookList, "getReserveBookList")

            Catch ex As Exception
                MessageBox.Show("Error at ReserveDAL.getReserveBookList : " + ex.Message)
            Finally
                m_DBUtil.closeConnection(da, cn, cmd)
                sb = Nothing
            End Try
            Return getReserveBookList
        End Function
        'This function is for a binding purpose
        Public Function getReservePersonList(ByVal flag As Integer, ByVal PersonID As String) As DataSet
            Dim sql As String = String.Empty
            Dim cn As SqlConnection = Nothing
            Dim cmd As SqlCommand = Nothing
            Dim da As SqlDataAdapter = Nothing
            Dim sb As StringBuilder = New StringBuilder

            getReservePersonList = New DataSet
            da = New SqlDataAdapter()

            With sb
                .Append("SELECT ID, [Reserve Book].[Selected] AS [선택], ")
                .Append("       [Reserve Book].[Book ID], [Reserve Book].[Person ID], ")
                .Append("       [Book].[Title] AS [도서명], ")
                .Append("       [Book Barcode].Barcode AS [바코드], ")
                .Append("       [Reserve Date] AS [예약일] ")
                .Append("FROM [Reserve Book], [Book], [Book Barcode] ")
                .Append("WHERE [Reserve Book].[Book ID] = [Book].[Book ID] ")
                .Append("AND [Book].[Book ID] = [Book Barcode].[Book ID] ")
            End With

            Select Case flag
                Case 0
                    sb.Append("AND [Reserve Book].[Person ID] = @ReservePersonID ")

            End Select
            sb.Append("ORDER BY [Reserve Date] ")

            sql = sb.ToString

            Try
                cn = New SqlConnection(m_Constant.SQL_CONSTR)

                'provider to be used when working with access database
                cn.Open()
                cmd = New SqlCommand(sql, cn)
                cmd.CommandTimeout = 0

                Select Case flag
                    Case 0
                        cmd.Parameters.Add(New SqlParameter("@ReservePersonID", SqlDbType.VarChar)).Value = PersonID
                End Select

                da.SelectCommand = cmd
                da.Fill(getReservePersonList, "getReservePersonList")

            Catch ex As Exception
                MessageBox.Show("Error at ReserveDAL.getReservePersonList : " + ex.Message)
            Finally
                m_DBUtil.closeConnection(da, cn, cmd)
                sb = Nothing
            End Try
            Return getReservePersonList
        End Function
        Public Function getReserveBookPersonList(ByVal flag As Integer, ByVal BookID As String, ByVal PersonID As String) As DataSet
            Dim sql As String = String.Empty
            Dim cn As SqlConnection = Nothing
            Dim cmd As SqlCommand = Nothing
            Dim da As SqlDataAdapter = Nothing
            Dim sb As StringBuilder = New StringBuilder

            getReserveBookPersonList = New DataSet
            da = New SqlDataAdapter()

            With sb
                .Append("SELECT ID, [Reserve Book].[Selected] AS [선택], ")
                .Append("       [Reserve Book].[Book ID], [Reserve Book].[Person ID], ")
                .Append("       [Person].[Name] AS [이름], ")
                .Append("       [Person].[Home Tel] AS [집 전화], ")
                .Append("       [Reserve Date] AS [예약일] ")
                .Append("FROM [Reserve Book], [Person] ")
                .Append("WHERE [Reserve Book].[Person ID] = [Person].[Person ID] ")
            End With

            Select Case flag
                Case 0
                    sb.Append("AND [Reserve Book].[Person ID] = @ReservePersonID ")
                    sb.Append("AND [Reserve Book].[Book ID] = @ReserveBookID ")

            End Select
            sb.Append("ORDER BY [Reserve Date] ")

            sql = sb.ToString

            Try
                cn = New SqlConnection(m_Constant.SQL_CONSTR)

                'provider to be used when working with access database
                cn.Open()
                cmd = New SqlCommand(sql, cn)
                cmd.CommandTimeout = 0

                Select Case flag
                    Case 0
                        cmd.Parameters.Add(New SqlParameter("@ReserveBookID", SqlDbType.VarChar)).Value = BookID
                        cmd.Parameters.Add(New SqlParameter("@ReservePersonID", SqlDbType.VarChar)).Value = PersonID
                End Select

                da.SelectCommand = cmd
                da.Fill(getReserveBookPersonList, "getReserveBookPersonList")

            Catch ex As Exception
                MessageBox.Show("Error at ReserveDAL.getReserveBookPersonList : " + ex.Message)
            Finally
                m_DBUtil.closeConnection(da, cn, cmd)
                sb = Nothing
            End Try
            Return getReserveBookPersonList
        End Function
        'This function is for a binding purpose
        Public Function getReserveList() As DataSet
            Dim sql As String = String.Empty
            Dim cn As SqlConnection = Nothing
            Dim cmd As SqlCommand = Nothing
            Dim da As SqlDataAdapter = Nothing
            Dim sb As StringBuilder = New StringBuilder

            getReserveList = New DataSet
            da = New SqlDataAdapter()

            With sb
                .Append("SELECT ID, [Reserve Book].[Book ID], [Reserve Book].[Person ID], ")
                '.Append("       [Reserve Book].[Selected] AS [선택], ")
                .Append("       [Person].[Name] AS [이름], ")
                .Append("       [Person].[Gender] AS [성별], ")
                .Append("       [Person Title].[Person Title] AS [직분], ")
                .Append("       [Person].[Home Tel] AS [집 전화], ")
                .Append("       [Book].[Title] AS [도서명], ")
                .Append("       [Book Barcode].Barcode AS [바코드], ")
                .Append("       [Book].[Publisher] AS [출판사], ")
                .Append("       [Book].[Author] AS [저자], ")
                .Append("       [Reserve Date] AS [예약일] ")
                .Append("FROM [Reserve Book], [Book], [Book Barcode], [Person], [Person Title] ")
                .Append("WHERE [Reserve Book].[Book ID] = [Book].[Book ID] ")
                .Append("AND [Book].[Book ID] = [Book Barcode].[Book ID] ")
                .Append("AND [Book Barcode].[Book ID] = [Reserve Book].[Book ID]")
                .Append("AND [Reserve Book].[Person ID] = [Person].[Person ID] ")
                .Append("AND [Person].[Person Title ID] = [Person Title].[Person Title ID] ")
                .Append("ORDER BY [Reserve Date] ")
            End With

            sql = sb.ToString

            Try
                cn = New SqlConnection(m_Constant.SQL_CONSTR)

                'provider to be used when working with access database
                cn.Open()
                cmd = New SqlCommand(sql, cn)
                cmd.CommandTimeout = 0

                da.SelectCommand = cmd
                da.Fill(getReserveList, "getReserveList")

            Catch ex As Exception
                MessageBox.Show("Error at ReserveDAL.getReserveList : " + ex.Message)
            Finally
                m_DBUtil.closeConnection(da, cn, cmd)
                sb = Nothing
            End Try

            Return getReserveList
        End Function
        'This function is to delete a Rent Book record
        Public Function deleteRecordByID(ByVal bookID As String, ByVal personID As String) As Integer
            Dim sql As String = String.Empty
            Dim cn As SqlConnection = Nothing
            Dim cmd As SqlCommand = Nothing
            Dim ta As SqlTransaction = Nothing
            Dim sb As StringBuilder = New StringBuilder

            deleteRecordByID = 0

            With sb
                .Append("DELETE FROM [Reserve Book] WHERE [Book ID] = @bookID AND [Person ID] = @personID ")
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

                cmd.Parameters.Add(New SqlParameter("@bookID", SqlDbType.NVarChar)).Value = bookID
                cmd.Parameters.Add(New SqlParameter("@personID", SqlDbType.NVarChar)).Value = personID
                deleteRecordByID = cmd.ExecuteNonQuery()
                ta.Commit()

            Catch ex As Exception
                ta.Rollback()
                deleteRecordByID = 0
                MessageBox.Show("Error at ReserveBookDAL.deleteRecordByID : " + ex.Message)
            Finally
                m_DBUtil.closeConnection(cmd, cn, ta)
                sb = Nothing
            End Try
            Return deleteRecordByID
        End Function

        Public Function insertRecord(ByVal rbEnt As TKPC.Entity.ReserveBookEnt) As Integer
            Dim sql As String = String.Empty
            Dim cn As SqlConnection = Nothing
            Dim cmd As SqlCommand = Nothing
            Dim ta As SqlTransaction = Nothing
            insertRecord = 0
            Dim sb As StringBuilder = New StringBuilder

            With sb
                .Append("INSERT INTO [Reserve Book] ")
                .Append("( ")
                .Append("     [Reserve Book].[Book ID], ")
                .Append("     [Reserve Book].[Person ID], ")
                .Append("     Selected, ")
                .Append("     [Reserve Book].[Reserve Date], ")
                .Append("     [Rent Book].[Last Update Date] ")
                .Append(" ) ")
                .Append("VALUES ")
                .Append("(@BookID,@PersonID,0,@ReserveDate,@LastUpdateDate) ")
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

                If rbEnt.bookID = "" Or rbEnt.bookID = "0" Then
                    cmd.Parameters.Add(New SqlParameter("@BookID", SqlDbType.NVarChar, rbEnt.bookID.Length, "Book ID")).Value = DBNull.Value
                Else
                    cmd.Parameters.Add(New SqlParameter("@BookID", SqlDbType.NVarChar, rbEnt.bookID.Length, "Book ID")).Value = rbEnt.bookID
                End If

                If rbEnt.personID = "" Or rbEnt.personID = "0" Then
                    cmd.Parameters.Add(New SqlParameter("@PersonID", SqlDbType.NVarChar, rbEnt.personID.Length, "Person ID")).Value = DBNull.Value
                Else
                    cmd.Parameters.Add(New SqlParameter("@PersonID", SqlDbType.NVarChar, rbEnt.personID.Length, "Person ID")).Value = rbEnt.personID
                End If

                If rbEnt.reserveDate = "" Or rbEnt.reserveDate = String.Empty Then
                    cmd.Parameters.Add(New SqlParameter("@ReserveDate", SqlDbType.DateTime, rbEnt.reserveDate.Length, "Reserve Date")).Value = DBNull.Value
                Else
                    cmd.Parameters.Add(New SqlParameter("@ReserveDate", SqlDbType.DateTime, rbEnt.reserveDate.Length, "Reserve Date")).Value = rbEnt.reserveDate
                End If

                If rbEnt.lastUpdateDate = "" Then
                    cmd.Parameters.Add(New SqlParameter("@LastUpdateDate", SqlDbType.DateTime, rbEnt.lastUpdateDate.Length, "Last Update Date")).Value = DBNull.Value
                Else
                    cmd.Parameters.Add(New SqlParameter("@LastUpdateDate", SqlDbType.DateTime, rbEnt.lastUpdateDate.Length, "Last Update Date")).Value = rbEnt.lastUpdateDate
                End If

                insertRecord = cmd.ExecuteNonQuery()
                ta.Commit()

            Catch ex As Exception
                ta.Rollback()
                insertRecord = -1
                MessageBox.Show("Error at ReserveBookDAL.insertRecord : " + ex.Message)
            Finally
                m_DBUtil.closeConnection(cmd, cn, ta)
                sb = Nothing
            End Try
            Return insertRecord
        End Function
    End Class
End Namespace



