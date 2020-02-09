Imports System.Data.SqlClient
Imports System.Text

Namespace TKPC.DAL
    Public Class MemoDAL
        Private Shared Instance As MemoDAL

        Protected Sub New()
        End Sub

        'To make this DAL singleton to use memory efficiently
        Public Shared Function getInstance() As MemoDAL
            ' initialize if not already done
            If Instance Is Nothing Then
                Instance = New MemoDAL
            End If
            ' return the initialized instance of the Singleton Class
            Return Instance
        End Function 'Instance

        Public Function getMemo(ByVal Type As String) As TKPC.Entity.MemoEnt
            Dim sql As String = String.Empty
            Dim cn As SqlConnection = Nothing
            Dim cmd As SqlCommand = Nothing
            Dim dr As SqlDataReader = Nothing
            Dim sb As StringBuilder = New StringBuilder
            getMemo = New TKPC.Entity.MemoEnt

            With sb
                .Append("SELECT [Memo].[Note] AS [Note] ")
                .Append("FROM [Memo] WHERE [Memo].Type = @Type")
            End With
            sql = sb.ToString

            Try
                cn = New SqlConnection(m_Constant.SQL_CONSTR)

                'provider to be used when working with access database
                cn.Open()

                cmd = New SqlCommand(sql, cn)
                cmd.CommandTimeout = 0
                cmd.Parameters.Add(New SqlParameter("@Type", SqlDbType.NVarChar)).Value = Type

                dr = cmd.ExecuteReader()

                If dr.Read() Then
                    If IsDBNull(dr("Note")) Then
                        getMemo.note = ""
                    Else
                        getMemo.note = dr("Note")
                    End If
                End If

            Catch ex As Exception
                MessageBox.Show("Error at MemoDAL.getMemo : " + ex.Message)
            Finally
                m_DBUtil.closeConnection(dr, cmd, cn)
                sb = Nothing
            End Try
            Return getMemo
        End Function
        Public Function insertRecord(ByVal memoEnt As TKPC.Entity.MemoEnt) As Integer
            Dim sql As String = String.Empty
            Dim cn As SqlConnection = Nothing
            Dim cmd As SqlCommand = Nothing
            Dim ta As SqlTransaction = Nothing
            Dim sb As StringBuilder = New StringBuilder
            insertRecord = 0

            With sb
                .Append("INSERT INTO [Memo] ")
                .Append("([Memo].Note, [Memo].Type) ")
                .Append("VALUES ")
                .Append("(@Note, @Type)")
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

                If memoEnt.note = "" Then
                    cmd.Parameters.Add(New SqlParameter("@Note", SqlDbType.NVarChar, memoEnt.note.Length, "Note")).Value = DBNull.Value
                Else
                    cmd.Parameters.Add(New SqlParameter("@Note", SqlDbType.NVarChar, memoEnt.note.Length, "Note")).Value = memoEnt.note
                End If

                If memoEnt.type = "" Then
                    cmd.Parameters.Add(New SqlParameter("@Type", SqlDbType.NVarChar, memoEnt.type.Length, "Type")).Value = DBNull.Value
                Else
                    cmd.Parameters.Add(New SqlParameter("@Type", SqlDbType.NVarChar, memoEnt.type.Length, "Type")).Value = memoEnt.type
                End If

                insertRecord = cmd.ExecuteNonQuery()
                ta.Commit()

            Catch ex As Exception
                ta.Rollback()
                MessageBox.Show("Error at MemoDAL.insertRecord : " + ex.Message)
            Finally
                m_DBUtil.closeConnection(cmd, cn, ta)
                sb = Nothing
            End Try
            Return insertRecord
        End Function

        Public Function updateRecord(ByVal memoEnt As TKPC.Entity.MemoEnt) As Integer
            Dim sql As String = String.Empty
            Dim cn As SqlConnection = Nothing
            Dim cmd As SqlCommand = Nothing
            Dim ta As SqlTransaction = Nothing
            Dim sb As StringBuilder = New StringBuilder
            updateRecord = 0

            With sb
                .Append("UPDATE [Memo] ")
                .Append("SET [Memo].Note = @Note WHERE [Memo].Type = @Type ")

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

                If memoEnt.note = "" Then
                    cmd.Parameters.Add(New SqlParameter("@Note", SqlDbType.NVarChar, memoEnt.note.Length, "Note")).Value = DBNull.Value
                Else
                    cmd.Parameters.Add(New SqlParameter("@Note", SqlDbType.NVarChar, memoEnt.note.Length, "Note")).Value = memoEnt.note
                End If

                If memoEnt.type = "" Then
                    cmd.Parameters.Add(New SqlParameter("@Type", SqlDbType.NVarChar, memoEnt.type.Length, "Type")).Value = DBNull.Value
                Else
                    cmd.Parameters.Add(New SqlParameter("@Type", SqlDbType.NVarChar, memoEnt.type.Length, "Type")).Value = memoEnt.type
                End If

                updateRecord = cmd.ExecuteNonQuery()
                ta.Commit()

            Catch ex As Exception
                ta.Rollback()
                MessageBox.Show("Error at MemoDAL.updateRecord : " + ex.Message)
            Finally
                m_DBUtil.closeConnection(cmd, cn, ta)
                sb = Nothing
            End Try
            Return updateRecord
        End Function


    End Class
End Namespace



