Imports System.Data.Odbc
Imports System.Data.SqlClient
Imports System.Text

Namespace TKPC.DAL
    Public Class BarcodePrintDAL
        Private Shared Instance As BarcodePrintDAL

        Protected Sub New()
        End Sub

        'To make this DAL singleton to use memory efficiently
        Public Shared Function getInstance() As BarcodePrintDAL
            ' initialize if not already done
            If Instance Is Nothing Then
                Instance = New BarcodePrintDAL
            End If
            ' return the initialized instance of the Singleton Class
            Return Instance
        End Function 'Instance

        Public Function getRecordByBookTypeID(ByVal bookTypeID As String) As TKPC.Entity.BarcodePrintEnt
            Dim sql As String = String.Empty
            Dim cn As SqlConnection = Nothing
            Dim cmd As SqlCommand = Nothing
            Dim dr As SqlDataReader = Nothing
            Dim sb As StringBuilder = New StringBuilder

            getRecordByBookTypeID = New TKPC.Entity.BarcodePrintEnt

            With sb
                .Append("SELECT [Book Type ID], ")
                .Append("              [Start], ")
                .Append("              [Last Update Date] ")
                .Append("FROM [Barcode Print] ")
                .Append("WHERE [Book Type ID] = @BookTypeID ")
            End With
            sql = sb.ToString

            Try
                cn = New SqlConnection(m_Constant.SQL_CONSTR)

                'provider to be used when working with access database
                cn.Open()

                cmd = New SqlCommand(sql, cn)
                cmd.CommandTimeout = 0
                cmd.Parameters.Add(New SqlParameter("@BookTypeID", SqlDbType.NVarChar)).Value = bookTypeID

                dr = cmd.ExecuteReader()

                If dr.Read() Then
                    If IsDBNull(dr("Book Type ID")) Then
                        getRecordByBookTypeID.bookTypeID = ""
                    Else
                        getRecordByBookTypeID.bookTypeID = dr("Book Type ID")
                    End If

                    If IsDBNull(dr("Start")) Then
                        getRecordByBookTypeID.start = ""
                    Else
                        getRecordByBookTypeID.start = dr("Start")
                    End If

                    If IsDBNull(dr("Last Update Date")) Then
                        getRecordByBookTypeID.lastUpdateDate = ""
                    Else
                        getRecordByBookTypeID.lastUpdateDate = dr("Last Update Date")
                    End If
                End If

            Catch ex As Exception
                MessageBox.Show("Error at BarcodeDAL.getRecordByBookTypeID : " + ex.Message)
            Finally
                m_DBUtil.closeConnection(dr, cmd, cn)
                sb = Nothing
            End Try
            Return getRecordByBookTypeID
        End Function
        Public Function insertRecord(ByRef barcodePrintEnt As TKPC.Entity.BarcodePrintEnt) As Integer
            Dim sql As String = String.Empty
            Dim cn As SqlConnection = Nothing
            Dim cmd As SqlCommand = Nothing
            Dim ta As SqlTransaction = Nothing
            Dim sb As StringBuilder = New StringBuilder

            insertRecord = 0

            With sb
                .Append("INSERT INTO [Barcode Print] ")
                .Append("( ")
                .Append("     [Barcode Print].[Book Type ID], ")
                .Append("     [Barcode Print].Start, ")
                .Append("     [Book].[Last Update Date] ")
                .Append(" ) ")
                .Append("VALUES ")
                .Append("(@BookTypeID,@Start,@LastUpdateDate) ")
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

                If barcodePrintEnt.bookTypeID = String.Empty Then
                    cmd.Parameters.Add(New SqlParameter("@BookTypeID", SqlDbType.Int, barcodePrintEnt.bookTypeID.Length, "Book Type ID")).Value = DBNull.Value
                Else
                    cmd.Parameters.Add(New SqlParameter("@BookTypeID", SqlDbType.Int, barcodePrintEnt.bookTypeID.Length, "Book Type ID")).Value = barcodePrintEnt.bookTypeID
                End If

                If barcodePrintEnt.start = String.Empty Then
                    cmd.Parameters.Add(New SqlParameter("@Start", SqlDbType.Int, barcodePrintEnt.start.Length, "Start")).Value = DBNull.Value
                Else
                    cmd.Parameters.Add(New SqlParameter("@Start", SqlDbType.Int, barcodePrintEnt.start.Length, "Start")).Value = barcodePrintEnt.start
                End If

                If barcodePrintEnt.lastUpdateDate = String.Empty Then
                    cmd.Parameters.Add(New SqlParameter("@LastUpdateDate", SqlDbType.DateTime, barcodePrintEnt.lastUpdateDate.Length, "Last Update Date")).Value = DBNull.Value
                Else
                    cmd.Parameters.Add(New SqlParameter("@LastUpdateDate", SqlDbType.DateTime, barcodePrintEnt.lastUpdateDate.Length, "Last Update Date")).Value = barcodePrintEnt.lastUpdateDate
                End If

                insertRecord = cmd.ExecuteNonQuery()

                ta.Commit()

            Catch ex As Exception
                ta.Rollback()
                insertRecord = -1
                MessageBox.Show("Error at BarcodePrintDAL.insertRecord : " + ex.Message)
            Finally
                m_DBUtil.closeConnection(cmd, cn, ta)
                sb = Nothing
            End Try
            Return insertRecord
        End Function

        'This function is to delete Barcode For Print record
        Public Function deleteRecord() As Integer
            Dim sql As String = String.Empty
            Dim cn As SqlConnection = Nothing
            Dim cmd As SqlCommand = Nothing
            Dim ta As SqlTransaction = Nothing
            Dim sb As StringBuilder = New StringBuilder()

            deleteRecord = 0

            With sb
                .Append("DELETE FROM [Barcode For Print] ")
                .Append("WHERE CONVERT(VARCHAR(10), [Add Date], 120) = CONVERT(VARCHAR(10), getdate(), 120) ")
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
                deleteRecord = cmd.ExecuteNonQuery()
                ta.Commit()

            Catch ex As Exception
                ta.Rollback()
                deleteRecord = 0
                MessageBox.Show("Error at BarcodePrintDAL.deleteRecord : " + ex.Message)
            Finally
                m_DBUtil.closeConnection(cmd, cn, ta)
                sb = Nothing
            End Try
            Return deleteRecord
        End Function

        'This function is to delete Barcode For Print record
        Public Function deleteRecordFromBarcodeForPrint(ByVal barcode As String) As Integer
            Dim sql As String = String.Empty
            Dim cn As SqlConnection = Nothing
            Dim cmd As SqlCommand = Nothing
            Dim ta As SqlTransaction = Nothing
            Dim sb As StringBuilder = New StringBuilder()

            deleteRecordFromBarcodeForPrint = 0

            With sb
                .Append("DELETE FROM [Barcode For Print] ")
                .Append("WHERE Barcode = @barcode")
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

                cmd.Parameters.Add(New SqlParameter("@barcode", SqlDbType.NVarChar)).Value = barcode

                deleteRecordFromBarcodeForPrint = cmd.ExecuteNonQuery()
                ta.Commit()

            Catch ex As Exception
                ta.Rollback()
                deleteRecordFromBarcodeForPrint = 0
                MessageBox.Show("Error at BarcodePrintDAL.deleteRecordFromBarcodeForPrint : " + ex.Message)
            Finally
                m_DBUtil.closeConnection(cmd, cn, ta)
                sb = Nothing
            End Try
            Return deleteRecord()
        End Function

        Public Function insertRecord2() As Integer
            Dim sql As String = String.Empty
            Dim cn As SqlConnection = Nothing
            Dim cmd As SqlCommand = Nothing
            Dim ta As SqlTransaction = Nothing
            Dim sb As StringBuilder = New StringBuilder

            insertRecord2 = 0

            With sb
                .Append("INSERT INTO [Barcode For Print](Barcode, Status, [Add Date]) ")
                .Append("   SELECT Barcode, 0, getdate() FROM [Book Barcode] ")
                .Append("   WHERE CONVERT(VARCHAR(10), [Book Barcode].[Purchase Or Donation Date], 120) = CONVERT(VARCHAR(10), getdate(), 120) AND selected2 IS NULL ")
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

                insertRecord2 = cmd.ExecuteNonQuery()

                ta.Commit()

            Catch ex As Exception
                ta.Rollback()
                insertRecord2 = -1
                MessageBox.Show("Error at BarcodePrintDAL.insertRecord2 : " + ex.Message)
            Finally
                m_DBUtil.closeConnection(cmd, cn, ta)
                sb = Nothing
            End Try
            Return insertRecord2
        End Function

        Public Function updateRecord(ByRef barcodePrintEnt As TKPC.Entity.BarcodePrintEnt) As Integer
            Dim sql As String = String.Empty
            Dim cn As SqlConnection = Nothing
            Dim cmd As SqlCommand = Nothing
            Dim ta As SqlTransaction = Nothing
            Dim sb As StringBuilder = New StringBuilder()
            updateRecord = 0

            With sb
                .Append("UPDATE [Barcode Print] ")
                .Append("SET  ")
                .Append("     [Barcode Print].Start = @Start, ")
                .Append("     [Barcode Print].[Last Update Date] = @LastUpdateDate ")
                .Append("WHERE [Book Type ID] = @BookTypeID ")
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

                If barcodePrintEnt.start = String.Empty Then
                    cmd.Parameters.Add(New SqlParameter("@Start", SqlDbType.NVarChar, barcodePrintEnt.start.Length, "Start")).Value = DBNull.Value
                Else
                    cmd.Parameters.Add(New SqlParameter("@Start", SqlDbType.NVarChar, barcodePrintEnt.start.Length, "Start")).Value = barcodePrintEnt.start
                End If

                If barcodePrintEnt.lastUpdateDate = String.Empty Then
                    cmd.Parameters.Add(New SqlParameter("@LastUpdateDate", SqlDbType.DateTime, barcodePrintEnt.lastUpdateDate.Length, "Last Update Date")).Value = DBNull.Value
                Else
                    cmd.Parameters.Add(New SqlParameter("@LastUpdateDate", SqlDbType.DateTime, barcodePrintEnt.lastUpdateDate.Length, "Last Update Date")).Value = barcodePrintEnt.lastUpdateDate
                End If

                cmd.Parameters.Add(New SqlParameter("@BookTypeID", SqlDbType.NVarChar, barcodePrintEnt.bookTypeID.Length, "")).Value = barcodePrintEnt.bookTypeID

                updateRecord = cmd.ExecuteNonQuery()
                ta.Commit()

            Catch ex As Exception
                ta.Rollback()
                MessageBox.Show("Error at BarcodePrintDAL.updateRecord : " + ex.Message)
            Finally
                m_DBUtil.closeConnection(cmd, cn, ta)
                sb = Nothing
            End Try
            Return updateRecord
        End Function

    End Class
End Namespace
