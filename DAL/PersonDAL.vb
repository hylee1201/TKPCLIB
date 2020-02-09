Imports System.Data.SqlClient
Imports System.Text

Namespace TKPC.DAL
    Public Class PersonDAL
        Private Shared Instance As PersonDAL

        Protected Sub New()
        End Sub

        'To make this DAL singleton to use memory efficiently
        Public Shared Function getInstance() As PersonDAL
            ' initialize if not already done
            If Instance Is Nothing Then
                Instance = New PersonDAL
            End If
            ' return the initialized instance of the Singleton Class
            Return Instance
        End Function 'Instance
        'This function is to get Person data
        Public Function getListForRent(ByVal flag As Integer, ByVal searchWords As String) As DataSet
            Dim sql As String = String.Empty
            Dim cn As SqlConnection = Nothing
            Dim cmd As SqlCommand = Nothing
            Dim da As SqlDataAdapter = Nothing
            Dim sb As StringBuilder = New StringBuilder
            Dim name As String = "%" + searchWords.ToUpper + "%"
            Dim name1 As String = String.Empty

            If flag = 1 Then 'Name
                If searchWords <> String.Empty And searchWords.Length >= 3 Then
                    name1 = "%" + searchWords.Substring(1, 2) + "%"
                End If
            End If

            getListForRent = New DataSet
            da = New SqlDataAdapter()

            If flag = 0 Then
                With sb
                    .Append("SELECT [Person ID] AS [ID], ")
                    .Append("       [Name] AS [이름], ")
                    .Append("       [Person Title].[Person Title] AS [직분], ")
                    .Append("       CASE WHEN [Gender]='M' THEN '남' ELSE '여' END AS [성별],")
                    .Append("       [Home Tel] AS [집 전화], ")
                    .Append("       [Other Tel] AS [다른 전화] ")
                    .Append("FROM [Person], [Person Title] ")
                    .Append("WHERE [Person].[Person Title ID] = [Person Title].[Person Title ID] ")
                    .Append("AND ([Person].[Home Tel] LIKE @HomeTel OR [Person].[Other Tel] LIKE @OtherTel OR [Person Title].[Person Title] LIKE @HomeTel) ")
                    .Append("ORDER BY [Person].[Name]")
                End With
            ElseIf flag = 1 Then '이름
                With sb
                    .Append("SELECT [Person ID] AS [ID], ")
                    .Append("       [Name] AS [이름], ")
                    .Append("       [Person Title].[Person Title] AS [직분], ")
                    .Append("       CASE WHEN [Gender]='M' THEN '남' ELSE '여' END AS [성별],")
                    .Append("       [Home Tel] AS [집 전화], ")
                    .Append("       [Other Tel] AS [다른 전화] ")
                    .Append("FROM [Person], [Person Title] ")
                    .Append("WHERE [Person].[Person Title ID] = [Person Title].[Person Title ID] ")
                    .Append("AND ([Person].[Name] LIKE @Name OR [Person].[Name] LIKE @Name1 OR [Person Title].[Person Title] LIKE @Name OR [Person].[Note] LIKE @Name) ")
                    .Append("ORDER BY CHARINDEX(@Name, UPPER([Name])), [Name] ")
                End With
            ElseIf flag = 2 Then
                With sb
                    .Append("SELECT [Person ID] AS [ID], ")
                    .Append("       [Name] AS [이름], ")
                    .Append("       [Person Title].[Person Title] AS [직분], ")
                    .Append("       CASE WHEN [Gender]='M' THEN '남' ELSE '여' END AS [성별],")
                    .Append("       [Home Tel] AS [집 전화], ")
                    .Append("       [Other Tel] AS [다른 전화] ")
                    .Append("FROM [Person], [Person Title] ")
                    .Append("WHERE [Person].[Person Title ID] = [Person Title].[Person Title ID] ")
                    .Append("AND ([Person].[Person ID] = @PersonID) ")
                    .Append("ORDER BY [Person].[Name]")
                End With
            Else
                With sb
                    .Append("SELECT [Person ID] AS [ID], ")
                    .Append("       [Name] AS [이름], ")
                    .Append("       [Person Title].[Person Title] AS [직분], ")
                    .Append("       CASE WHEN [Gender]='M' THEN '남' ELSE '여' END AS [성별],")
                    .Append("       [Home Tel] AS [집 전화], ")
                    .Append("       [Other Tel] AS [다른 전화] ")
                    .Append("FROM [Person], [Person Title] ")
                    .Append("WHERE [Person].[Person Title ID] = [Person Title].[Person Title ID] ")
                    .Append("AND [Person].[Note] LIKE @Name ")
                    .Append("ORDER BY [Person].[Name]")
                End With
            End If

            sql = sb.ToString()

            Try
                cn = New SqlConnection(m_Constant.SQL_CONSTR)

                'provider to be used when working with access database
                cn.Open()
                cmd = New SqlCommand(sql, cn)
                cmd.CommandTimeout = 0

                If flag = 0 Then
                    If searchWords <> "" Then
                        cmd.Parameters.Add(New SqlParameter("@HomeTel", SqlDbType.NVarChar)).Value = searchWords.ToUpper
                        cmd.Parameters.Add(New SqlParameter("@OtherTel", SqlDbType.NVarChar)).Value = searchWords.ToUpper
                    End If
                ElseIf flag = 1 Then
                    If searchWords <> "" Then
                        cmd.Parameters.Add(New SqlParameter("@Name", SqlDbType.NVarChar)).Value = name
                        cmd.Parameters.Add(New SqlParameter("@Name1", SqlDbType.NVarChar)).Value = name1
                    End If
                ElseIf flag = 2 Then
                    If searchWords <> "" Then
                        cmd.Parameters.Add(New SqlParameter("@PersonID", SqlDbType.Int)).Value = searchWords.ToUpper
                    End If
                Else
                    If searchWords <> "" Then
                        cmd.Parameters.Add(New SqlParameter("@Name", SqlDbType.NVarChar)).Value = name
                    End If
                End If

                da.SelectCommand = cmd
                da.Fill(getListForRent, "getListForRent")

            Catch ex As Exception
                MessageBox.Show("Error at PersonDAL.getListForRent : " + ex.Message)
            Finally
                m_DBUtil.closeConnection(da, cn, cmd)
                sb = Nothing
            End Try
            Return getListForRent
        End Function

        'This function is to get Person data
        Public Function getList(ByVal flag As Integer, ByVal searchWords As String, ByVal personID As String) As DataSet
            Dim sql As String = String.Empty
            Dim cn As SqlConnection = Nothing
            Dim cmd As SqlCommand = Nothing
            Dim da As SqlDataAdapter = Nothing
            Dim sb As StringBuilder = New StringBuilder

            getList = New DataSet
            da = New SqlDataAdapter()

            If flag = 0 Then
                With sb
                    .Append("SELECT [Person ID] AS [ID], ")
                    .Append("       [Name] AS [이름], ")
                    .Append("       CASE WHEN [Gender]='M' THEN '남' ELSE '여' END AS [성별], ")
                    .Append("       [Person Title].[Person Title] AS [직분], ")
                    .Append("       [Home Tel] AS [집 전화], ")
                    .Append("       [Other Tel] AS [다른 전화], ")
                    .Append("       [Street] AS [거리명], ")
                    .Append("       [City] AS [도시명], ")
                    .Append("       [Zip Code] AS [우편번호], ")
                    .Append("       [Email] AS [이메일], ")
                    .Append("       [Registration Date] AS [등록일], ")
                    .Append("       [Note] AS [비고], ")
                    .Append("       [Last Update Date] AS [데이터 저장일] ")
                    .Append("FROM [Person], [Person Title] ")
                    .Append("WHERE [Person].[Person Title ID] = [Person Title].[Person Title ID] ")
                    .Append("ORDER BY [Person].[Name] ")
                End With
            ElseIf flag = 1 Then
                With sb
                    .Append("SELECT ")
                    .Append("      [Person ID] AS [ID], ")
                    .Append("      [Name] AS [이름], ")
                    .Append("      [Person Title].[Person Title] AS [직분], ")
                    .Append("      CASE WHEN [Gender]='M' THEN '남' ELSE '여' END AS [성별], ")
                    .Append("      [Home Tel] AS [집 전화], ")
                    .Append("      [Other Tel] AS [다른 전화], ")
                    .Append("      [Street] AS [거리명], ")
                    .Append("      [City] AS [도시명], ")
                    .Append("      [Zip Code] AS [우편번호], ")
                    .Append("      [Email] AS [이메일], ")
                    .Append("      [Note] AS [비고], ")
                    .Append("      [Registration Date] AS [등록일], ")
                    .Append("      [Login ID], ")
                    .Append("      [Login PWD], ")
                    .Append("      [Login Level] ")
                    .Append("FROM [Person], [Person Title] ")
                    .Append("WHERE [Person].[Person Title ID] = [Person Title].[Person Title ID] ")
                End With
                If searchWords <> "" Then
                    sb.Append("AND UPPER([Person].[Home Tel]) LIKE @HomeTel ")
                End If
                sb.Append("ORDER BY [Name] ")
            ElseIf flag = 2 Then
                With sb
                    .Append("SELECT [Person ID] AS [ID], ")
                    .Append("       [Name] AS [이름], ")
                    .Append("       [Person Title].[Person Title] AS [직분], ")
                    .Append("       CASE WHEN [Gender]='M' THEN '남' ELSE '여' END AS [성별],")
                    .Append("       [Home Tel] AS [집 전화], ")
                    .Append("       [Other Tel] AS [다른 전화] ")
                    .Append("FROM [Person], [Person Title] ")
                    .Append("WHERE [Person].[Person Title ID] = [Person Title].[Person Title ID] ")
                End With
                If searchWords <> "" Then
                    sb.Append("AND [Person].[Person ID] = @PersonID ")
                End If
            ElseIf flag = 3 Then
                With sb
                    .Append("SELECT ")
                    .Append("      [Person ID] AS [ID], ")
                    .Append("      [Name] AS [이름], ")
                    .Append("      [Person Title].[Person Title] AS [직분], ")
                    .Append("      CASE WHEN [Gender]='M' THEN '남' ELSE '여' END AS [성별], ")
                    .Append("      [Home Tel] AS [집 전화], ")
                    .Append("      [Other Tel] AS [다른 전화], ")
                    .Append("      [Street] AS [거리명], ")
                    .Append("      [City] AS [도시명], ")
                    .Append("      [Zip Code] AS [우편번호], ")
                    .Append("      [Email] AS [이메일], ")
                    .Append("      [Note] AS [비고], ")
                    .Append("      [Registration Date] AS [등록일] ")
                    .Append("FROM [Person], [Person Title] ")
                    .Append("WHERE [Person].[Person Title ID] = [Person Title].[Person Title ID] ")
                End With

                If searchWords <> "" Then
                    sb.Append("AND [Person].[Street] LIKE @Street ")
                End If

            ElseIf flag = 4 Then
                With sb
                    .Append("SELECT ")
                    .Append("      [Person ID] AS [ID], ")
                    .Append("      [Name] AS [이름], ")
                    .Append("      [Person Title].[Person Title] AS [직분], ")
                    .Append("      CASE WHEN [Gender]='M' THEN '남' ELSE '여' END AS [성별], ")
                    .Append("      [Home Tel] AS [집 전화], ")
                    .Append("      [Other Tel] AS [다른 전화], ")
                    .Append("      [Street] AS [거리명], ")
                    .Append("      [City] AS [도시명], ")
                    .Append("      [Zip Code] AS [우편번호], ")
                    .Append("      [Email] AS [이메일], ")
                    .Append("      [Note] AS [비고], ")
                    .Append("      [Registration Date] AS [등록일] ")
                    .Append("FROM [Person], [Person Title] ")
                    .Append("WHERE [Person].[Person Title ID] = [Person Title].[Person Title ID] ")
                End With

                If searchWords <> "" Then
                    sb.Append("AND [Person].[Name] LIKE @Name ")
                End If

            ElseIf flag = 5 Then 'No email person
                With sb
                    .Append("SELECT [Person ID] AS [ID], ")
                    .Append("       [Name] AS [이름], ")
                    .Append("       CASE WHEN [Gender]='M' THEN '남' ELSE '여' END AS [성별], ")
                    .Append("       [Person Title].[Person Title] AS [직분], ")
                    .Append("       [Home Tel] AS [집 전화], ")
                    .Append("       [Other Tel] AS [다른 전화], ")
                    .Append("       [Street] AS [거리명], ")
                    .Append("       [City] AS [도시명], ")
                    .Append("       [City] AS [도시명], ")
                    .Append("       [Zip Code] AS [우편번호], ")
                    .Append("       [Email] AS [이메일], ")
                    .Append("       [Registration Date] AS [등록일], ")
                    .Append("       [Note] AS [비고], ")
                    .Append("       [Last Update Date] AS [데이터 저장일] ")
                    .Append("FROM [Person], [Person Title] ")
                    .Append("WHERE [Person].[Person Title ID] = [Person Title].[Person Title ID] ")
                    .Append("AND [Person].[Email] IS NULL ")
                End With
            ElseIf flag = 6 Then
                With sb
                    .Append("SELECT [Person ID] AS [ID], ")
                    .Append("       [Name] AS [이름], ")
                    .Append("       CASE WHEN [Gender]='M' THEN '남' ELSE '여' END AS [성별], ")
                    .Append("       [Person Title].[Person Title] AS [직분], ")
                    .Append("       [Home Tel] AS [집 전화], ")
                    .Append("       [Other Tel] AS [다른 전화], ")
                    .Append("       [Street] AS [거리명], ")
                    .Append("       [City] AS [도시명], ")
                    .Append("       [City] AS [도시명], ")
                    .Append("       [Zip Code] AS [우편번호], ")
                    .Append("       [Email] AS [이메일], ")
                    .Append("       [Registration Date] AS [등록일], ")
                    .Append("       [Note] AS [비고], ")
                    .Append("       [Last Update Date] AS [데이터 저장일] ")
                    .Append("FROM [Person], [Person Title] ")
                    .Append("WHERE [Person].[Person Title ID] = [Person Title].[Person Title ID] ")
                    .Append("ORDER BY [Person].[Name] ")
                End With
            ElseIf flag = 7 Then
                With sb
                    .Append("SELECT [Person ID] AS [ID], ")
                    .Append("       [Name] AS [이름], ")
                    .Append("       [Person Title].[Person Title] AS [직분], ")
                    .Append("       CASE WHEN [Gender]='M' THEN '남' ELSE '여' END AS [성별],")
                    .Append("       [Home Tel] AS [집 전화], ")
                    .Append("       [Other Tel] AS [다른 전화] ")
                    .Append("FROM [Person], [Person Title] ")
                    .Append("WHERE [Person].[Person Title ID] = [Person Title].[Person Title ID] ")
                    .Append("AND ([Person].[Home Tel] LIKE @HomeTel OR [Person].[Other Tel] LIKE @OtherTel OR [Person].[Name] LIKE @Name OR [Person].[Person ID] LIKE @PersonID) ")
                End With
            End If
            sql = sb.ToString

            Try
                cn = New SqlConnection(m_Constant.SQL_CONSTR)

                'provider to be used when working with access database
                cn.Open()
                cmd = New SqlCommand(sql, cn)
                cmd.CommandTimeout = 0

                If flag = 1 Then
                    If searchWords <> "" Then
                        cmd.Parameters.Add(New SqlParameter("@HomeTel", SqlDbType.NVarChar)).Value = searchWords.ToUpper
                    End If
                ElseIf flag = 2 Then
                    If searchWords <> "" Then
                        cmd.Parameters.Add(New SqlParameter("@PersonID", SqlDbType.NVarChar)).Value = searchWords.ToUpper
                    End If
                ElseIf flag = 3 Then
                    If searchWords <> "" Then
                        cmd.Parameters.Add(New SqlParameter("@Street", SqlDbType.NVarChar)).Value = searchWords.ToUpper
                    End If
                ElseIf flag = 4 Then
                    If searchWords <> "" Then
                        cmd.Parameters.Add(New SqlParameter("@Name", SqlDbType.NVarChar)).Value = searchWords.ToUpper
                    End If
                ElseIf flag = 7 Then
                    If searchWords <> "" Then
                        cmd.Parameters.Add(New SqlParameter("@HomeTel", SqlDbType.NVarChar)).Value = searchWords.ToUpper
                        cmd.Parameters.Add(New SqlParameter("@OtherTel", SqlDbType.NVarChar)).Value = searchWords.ToUpper
                        cmd.Parameters.Add(New SqlParameter("@Name", SqlDbType.NVarChar)).Value = searchWords.ToUpper
                        cmd.Parameters.Add(New SqlParameter("@PersonID", SqlDbType.NVarChar)).Value = searchWords.ToUpper
                    End If
                End If

                da.SelectCommand = cmd
                da.Fill(getList, "getList")

            Catch ex As Exception
                MessageBox.Show("Error at PersonDAL.getList : " + ex.Message)
            Finally
                m_DBUtil.closeConnection(da, cn, cmd)
                sb = Nothing
            End Try
            Return getList
        End Function
        Public Function getListByName(ByVal searchWords As String, ByVal personID As String) As DataSet
            Dim sql As String = String.Empty
            Dim cn As SqlConnection = Nothing
            Dim cmd As SqlCommand = Nothing
            Dim da As SqlDataAdapter = Nothing
            Dim sb As StringBuilder = New StringBuilder
            Dim name As String = "%" + searchWords.ToUpper + "%"
            Dim name1 As String = String.Empty
            If searchWords <> String.Empty And searchWords.Length >= 3 Then
                name1 = "%" + searchWords.Substring(1, 2) + "%"
            End If

            getListByName = New DataSet
            da = New SqlDataAdapter()

            With sb
                .Append("SELECT ")
                .Append("      [Person ID] AS [ID], ")
                .Append("      [Name] AS [이름], ")
                .Append("      [Person Title].[Person Title] AS [직분], ")
                .Append("      CASE WHEN [Gender]='M' THEN '남' ELSE '여' END AS [성별], ")
                .Append("      [Home Tel] AS [집 전화], ")
                .Append("      [Other Tel] AS [다른 전화], ")
                .Append("      [Street] AS [거리명], ")
                .Append("      [City] AS [도시명], ")
                .Append("      [Zip Code] AS [우편번호], ")
                .Append("      [Email] AS [이메일], ")
                .Append("      [Note] AS [비고], ")
                .Append("      [Registration Date] AS [등록일], ")
                .Append("      [Login ID], ")
                .Append("      [Login PWD], ")
                .Append("      [Login Level] ")
                .Append("FROM [Person], [Person Title] ")
                .Append("WHERE [Person].[Person Title ID] = [Person Title].[Person Title ID] ")
            End With

            If searchWords <> "" Then
                sb.Append("AND ([Person].[Name] LIKE @Name OR [Person].[Name] LIKE @Name1)")                
            End If
            sb.Append("ORDER BY CHARINDEX(@Name, UPPER([Name])), [Name] ")

            sql = sb.ToString

            Try
                cn = New SqlConnection(m_Constant.SQL_CONSTR)

                'provider to be used when working with access database
                cn.Open()
                cmd = New SqlCommand(sql, cn)
                cmd.CommandTimeout = 0

                If searchWords <> "" Then
                    cmd.Parameters.Add(New SqlParameter("@Name", SqlDbType.NVarChar)).Value = name
                    cmd.Parameters.Add(New SqlParameter("@Name1", SqlDbType.NVarChar)).Value = name1
                End If

                da.SelectCommand = cmd
                da.Fill(getListByName, "getListByName")

            Catch ex As Exception
                MessageBox.Show("Error at PersonDAL.getListByName : " + ex.Message)
            Finally
                m_DBUtil.closeConnection(da, cn, cmd)
                sb = Nothing
            End Try
            Return getListByName
        End Function

        Public Function getRefList(ByVal searchWords As String, ByVal personID As String) As DataSet
            Dim sql As String = String.Empty
            Dim cn As SqlConnection = Nothing
            Dim cmd As SqlCommand = Nothing
            Dim da As SqlDataAdapter = Nothing
            Dim sb As StringBuilder = New StringBuilder

            getRefList = New DataSet
            da = New SqlDataAdapter()

            With sb
                .Append("SELECT ")
                .Append("      Selected AS [선택], ")
                .Append("      [Person ID] AS [ID], ")
                .Append("      [Name] AS [이름], ")
                .Append("      [Person Title].[Person Title] AS [직분], ")
                .Append("      CASE WHEN [Gender]='M' THEN '남' ELSE '여' END AS [성별], ")
                .Append("      [Home Tel] AS [집 전화], ")
                .Append("      [Other Tel] AS [다른 전화], ")
                .Append("      [Street] AS [거리명], ")
                .Append("      [City] AS [도시명], ")
                .Append("      [Zip Code] AS [우편번호], ")
                .Append("      [Email] AS [이메일], ")
                .Append("      [Note] AS [비고], ")
                .Append("      [Registration Date] AS [등록일] ")
                .Append("FROM [Person], [Person Title] ")
                .Append("WHERE [Person].[Person Title ID] = [Person Title].[Person Title ID] ")
                .Append("AND ([Person].[Home Tel] = @HomeTel) AND ([Person].[Person ID] != @PersonID) ")
                .Append("ORDER BY [Person].[Name]")
            End With

            sql = sb.ToString

            Try
                cn = New SqlConnection(m_Constant.SQL_CONSTR)

                'provider to be used when working with access database
                cn.Open()
                cmd = New SqlCommand(sql, cn)
                cmd.CommandTimeout = 0

                If searchWords <> "" Then
                    cmd.Parameters.Add(New SqlParameter("@HomeTel", SqlDbType.NVarChar)).Value = searchWords.ToUpper
                    cmd.Parameters.Add(New SqlParameter("@PersonID", SqlDbType.Int)).Value = personID
                End If

                da.SelectCommand = cmd
                da.Fill(getRefList, "getRefList")

            Catch ex As Exception
                MessageBox.Show("Error at PersonDAL.getRefList : " + ex.Message)
            Finally
                m_DBUtil.closeConnection(da, cn, cmd)
                sb = Nothing
            End Try
            Return getRefList
        End Function

        Public Function getCityList(ByVal searchWords As String) As DataSet
            Dim sql As String = String.Empty
            Dim cn As SqlConnection = Nothing
            Dim cmd As SqlCommand = Nothing
            Dim da As SqlDataAdapter = Nothing
            Dim sb As StringBuilder = New StringBuilder
            getCityList = New DataSet
            da = New SqlDataAdapter()

            With sb
                .Append("SELECT [City].[Name] AS [City Name] FROM [City] ")
            End With

            If searchWords <> "" Then
                sb.Append("WHERE [City].[Name] LIKE @Name ")
            End If
            sb.Append("ORDER BY [City].[Name]")
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
                da.Fill(getCityList, "getList")

            Catch ex As Exception
                MessageBox.Show("Error at PersonDAL.getCityList : " + ex.Message)
            Finally
                m_DBUtil.closeConnection(da, cn, cmd)
                sb = Nothing
            End Try
            Return getCityList
        End Function

        Public Function getNameList() As DataSet
            Dim cn As SqlConnection = Nothing
            Dim cmd As SqlCommand = Nothing
            Dim da As SqlDataAdapter = Nothing
            getNameList = New DataSet
            da = New SqlDataAdapter()

            Dim sb As StringBuilder = New StringBuilder
            With sb
                .Append("SELECT Name AS [이름], ")
                .Append("             [Gender] AS [성별], ")
                .Append("             [Person Title] AS [직분], ")
                .Append("             [Home Tel] AS [집 전화], ")
                .Append("             [Other Tel] AS [다른 전화], ")
                .Append("             [Person ID] AS [ID] ")
                .Append("FROM [Person], [Person Title] ")
                .Append("WHERE [Person].[Person Title ID] = [Person Title].[Person Title ID] ")
                .Append("ORDER BY Name")
            End With

            Try
                cn = New SqlConnection(m_Constant.SQL_CONSTR)

                'provider to be used when working with access database
                cn.Open()
                cmd = New SqlCommand(sb.ToString, cn)
                cmd.CommandTimeout = 0

                da.SelectCommand = cmd
                da.Fill(getNameList, "getNameList")

            Catch ex As Exception
                MessageBox.Show("Error at PersonDAL.getNameList : " + ex.Message)
            Finally
                m_DBUtil.closeConnection(da, cn, cmd)
                sb = Nothing
            End Try
            Return getNameList
        End Function

        Public Function getNameList2(ByVal bookID As String) As DataSet
            Dim cn As SqlConnection = Nothing
            Dim cmd As SqlCommand = Nothing
            Dim da As SqlDataAdapter = Nothing
            getNameList2 = New DataSet
            da = New SqlDataAdapter()

            Dim sb As StringBuilder = New StringBuilder
            With sb
                .Append("SELECT Name AS [이름], ")
                .Append("       [Gender] AS [성별], ")
                .Append("       [Person Title] AS [직분], ")
                .Append("       [Home Tel] AS [집 전화], ")
                .Append("       [Other Tel] AS [다른 전화], ")
                .Append("       [Person ID] AS [ID] ")
                .Append("FROM [Person], [Person Title] ")
                .Append("WHERE [Person].[Person Title ID] = [Person Title].[Person Title ID] ")
                .Append("AND [Person].[Person ID] NOT IN (SELECT [Person ID] FROM [Reserve Book] WHERE [Book ID] = @bookID) ")
                .Append("ORDER BY Name ")
            End With

            Try
                cn = New SqlConnection(m_Constant.SQL_CONSTR)

                'provider to be used when working with access database
                cn.Open()
                cmd = New SqlCommand(sb.ToString, cn)
                cmd.CommandTimeout = 0

                cmd.Parameters.Add(New SqlParameter("@bookID", SqlDbType.NVarChar)).Value = bookID

                da.SelectCommand = cmd
                da.Fill(getNameList2, "getNameList2")

            Catch ex As Exception
                MessageBox.Show("Error at PersonDAL.getNameList : " + ex.Message)
            Finally
                m_DBUtil.closeConnection(da, cn, cmd)
                sb = Nothing
            End Try
            Return getNameList2
        End Function

        Public Function getRecordByID(ByVal personID As String) As TKPC.Entity.PersonEnt
            Dim sql As String = String.Empty
            Dim cn As SqlConnection = Nothing
            Dim cmd As SqlCommand = Nothing
            Dim dr As SqlDataReader = Nothing
            Dim sb As StringBuilder = New StringBuilder
            getRecordByID = New TKPC.Entity.PersonEnt

            With sb
                .Append("SELECT [Person ID] AS [ID], ")
                .Append("       [Name] AS [이름], ")
                .Append("       CASE WHEN [Gender]='M' THEN '남' ELSE '여' END AS [성별], ")
                .Append("       [Person Title].[Person Title] AS [직분], ")
                .Append("       [Home Tel] AS [집 전화], ")
                .Append("       [Other Tel] AS [다른 전화], ")
                .Append("       [Street] AS [거리명], ")
                .Append("       [City] AS [도시명], ")
                .Append("       [City] AS [도시명], ")
                .Append("       [Zip Code] AS [우편번호], ")
                .Append("       [Email] AS [이메일], ")
                .Append("       [Registration Date] AS [등록일], ")
                .Append("       [Note] AS [비고], ")
                .Append("       [Last Update Date] AS [데이터 저장일], ")
                .Append("       [Login ID], ")
                .Append("       [Login PWD], ")
                .Append("       [Login Level] ")
                .Append("FROM [Person], [Person Title] ")
                .Append("WHERE [Person].[Person Title ID] = [Person Title].[Person Title ID] ")
                .Append(" AND [Person].[Person ID] = @PersonID")
            End With
            sql = sb.ToString

            Try
                cn = New SqlConnection(m_Constant.SQL_CONSTR)

                'provider to be used when working with access database
                cn.Open()

                cmd = New SqlCommand(sql, cn)
                cmd.CommandTimeout = 0
                cmd.Parameters.Add(New SqlParameter("@PersonID", SqlDbType.NVarChar)).Value = personID

                dr = cmd.ExecuteReader()

                If dr.Read() Then
                    If IsDBNull(dr("ID")) Then
                        getRecordByID.personID = ""
                    Else
                        getRecordByID.personID = dr("ID")
                    End If

                    If IsDBNull(dr("이름")) Then
                        getRecordByID.name = ""
                    Else
                        getRecordByID.name = dr("이름")
                    End If

                    If IsDBNull(dr("성별")) Then
                        getRecordByID.gender = ""
                    Else
                        getRecordByID.gender = dr("성별")
                    End If

                    If IsDBNull(dr("직분")) Then
                        getRecordByID.personTitle = ""
                    Else
                        getRecordByID.personTitle = dr("직분")
                    End If

                    If IsDBNull(dr("집 전화")) Then
                        getRecordByID.homeTel = ""
                    Else
                        getRecordByID.homeTel = dr("집 전화")
                    End If

                    If IsDBNull(dr("다른 전화")) Then
                        getRecordByID.otherTel = ""
                    Else
                        getRecordByID.otherTel = dr("다른 전화")
                    End If

                    If IsDBNull(dr("거리명")) Then
                        getRecordByID.street = ""
                    Else
                        getRecordByID.street = dr("거리명")
                    End If

                    If IsDBNull(dr("도시명")) Then
                        getRecordByID.city = ""
                    Else
                        getRecordByID.city = dr("도시명")
                    End If

                    If IsDBNull(dr("우편번호")) Then
                        getRecordByID.zipCode = ""
                    Else
                        getRecordByID.zipCode = dr("우편번호")
                    End If

                    If IsDBNull(dr("이메일")) Then
                        getRecordByID.email = ""
                    Else
                        getRecordByID.email = dr("이메일")
                    End If

                    If IsDBNull(dr("등록일")) Then
                        getRecordByID.registrationDate = ""
                    Else
                        getRecordByID.registrationDate = dr("등록일")
                    End If

                    If IsDBNull(dr("비고")) Then
                        getRecordByID.note = ""
                    Else
                        getRecordByID.note = dr("비고")
                    End If

                    If IsDBNull(dr("데이터 저장일")) Then
                        getRecordByID.lastUpdateDate = ""
                    Else
                        getRecordByID.lastUpdateDate = dr("데이터 저장일")
                    End If

                    If IsDBNull(dr("Login ID")) Then
                        getRecordByID.loginID = ""
                    Else
                        getRecordByID.loginID = dr("Login ID")
                    End If

                    If IsDBNull(dr("Login PWD")) Then
                        getRecordByID.loginPassword = ""
                    Else
                        getRecordByID.loginPassword = dr("Login PWD")
                    End If

                    If IsDBNull(dr("Login Level")) Then
                        getRecordByID.loginLevel = ""
                    Else
                        getRecordByID.loginLevel = dr("Login Level")
                    End If
                End If

            Catch ex As Exception
                MessageBox.Show("Error at PersonDAL.getRecordByID : " + ex.Message)
            Finally
                m_DBUtil.closeConnection(dr, cmd, cn)
                sb = Nothing
            End Try
            Return getRecordByID
        End Function
        Public Function getRecordByHomeTel(ByVal flag As Integer, ByVal HomeTel As String) As Boolean
            Dim sql As String = String.Empty
            Dim cn As SqlConnection = Nothing
            Dim cmd As SqlCommand = Nothing
            Dim dr As SqlDataReader = Nothing
            Dim sb As StringBuilder = New StringBuilder

            With sb
                .Append("SELECT [Person ID] AS [ID], ")
                .Append("       [Name] AS [이름], ")
                .Append("       CASE WHEN [Gender]='M' THEN '남' ELSE '여' END AS [성별], ")
                .Append("       [Person Title].[Person Title] AS [직분], ")
                .Append("       [Home Tel] AS [집 전화], ")
                .Append("       [Other Tel] AS [다른 전화], ")
                .Append("       [Street] AS [거리명], ")
                .Append("       [City] AS [도시명], ")
                .Append("       [City] AS [도시명], ")
                .Append("       [Zip Code] AS [우편번호], ")
                .Append("       [Email] AS [이메일], ")
                .Append("       [Registration Date] AS [등록일], ")
                .Append("       [Note] AS [비고], ")
                .Append("       [Last Update Date] AS [데이터 저장일] ")
                .Append("FROM [Person], [Person Title] ")
                .Append("WHERE [Person].[Person Title ID] = [Person Title].[Person Title ID] ")
                .Append("AND [Person].[Home Tel] = @HomeTel ")
            End With
            sql = sb.ToString

            getRecordByHomeTel = False

            Try
                cn = New SqlConnection(m_Constant.SQL_CONSTR)

                'provider to be used when working with access database
                cn.Open()

                cmd = New SqlCommand(sql, cn)
                cmd.CommandTimeout = 0
                cmd.Parameters.Add(New SqlParameter("@HomeTel", SqlDbType.NVarChar)).Value = HomeTel

                dr = cmd.ExecuteReader()

                If dr.Read() Then
                    getRecordByHomeTel = True
                End If

            Catch ex As Exception
                MessageBox.Show("Error at PersonDAL.getRecordByHomeTel : " + ex.Message)
            Finally
                m_DBUtil.closeConnection(dr, cmd, cn)
                sb = Nothing
            End Try
            Return getRecordByHomeTel
        End Function

        Public Function getDataTable() As ArrayList
            Dim sql As String = String.Empty
            Dim cn As SqlConnection = Nothing
            Dim cmd As SqlCommand = Nothing
            Dim dr As SqlDataReader = Nothing
            Dim sb As StringBuilder = New StringBuilder
            getDataTable = New ArrayList
            Dim dt As DataTable

            Try
                cn = New SqlConnection(m_Constant.SQL_CONSTR)

                'provider to be used when working with access database
                cn.Open()

                With sb
                    .Append("SELECT [Person Title] AS Name, [Person Title ID] AS Value ")
                    .Append("FROM [Person Title] ")
                    .Append("ORDER BY [Person Title] ")
                End With
                sql = sb.ToString

                cmd = New SqlCommand(sql, cn)
                cmd.CommandTimeout = 0
                dr = cmd.ExecuteReader

                dt = New DataTable
                dt.Load(dr)
                dt.Columns(0).ColumnName = "Name"
                dt.Columns(1).ColumnName = "Value"

                getDataTable.Add(dt)

            Catch ex As Exception
                MessageBox.Show("Error at PersonDAL.getDataTable : " + ex.Message)
            Finally
                m_DBUtil.closeConnection(dr, cmd, cn)
                sb = Nothing
            End Try
            Return getDataTable
        End Function

        'This function is to delete a Boom record
        Public Function deleteRecordByID(ByVal personID As String) As Integer
            Dim sql As String = String.Empty
            Dim cn As SqlConnection = Nothing
            Dim cmd As SqlCommand = Nothing
            Dim ta As SqlTransaction = Nothing
            Dim sb As StringBuilder = New StringBuilder
            deleteRecordByID = 0

            With sb
                .Append("DELETE FROM [Person] ")
                .Append("WHERE [Person].[Person ID] = @PersonID ")
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

                cmd.Parameters.Add(New SqlParameter("@PersonID", SqlDbType.NVarChar)).Value = personID
                deleteRecordByID = cmd.ExecuteNonQuery()
                ta.Commit()

            Catch ex As Exception
                ta.Rollback()
                deleteRecordByID = 0
                MessageBox.Show("Error at PersonDAL.deleteRecordByID : " + ex.Message)
            Finally
                m_DBUtil.closeConnection(cmd, cn, ta)
                sb = Nothing
            End Try
            Return deleteRecordByID
        End Function

        Public Function insertRecord(ByVal personEnt As TKPC.Entity.PersonEnt) As Integer
            Dim sql As String = String.Empty
            Dim cn As SqlConnection = Nothing
            Dim cmd As SqlCommand = Nothing
            Dim ta As SqlTransaction = Nothing
            Dim sb As StringBuilder = New StringBuilder
            insertRecord = 0

            With sb
                .Append("INSERT INTO [Person] ")
                .Append("( ")
                .Append("     [Person].Name, ")
                .Append("     [Person].Gender, ")
                .Append("     [Person].[Person Title ID], ")
                .Append("     [Person].Street, ")
                .Append("     [Person].City, ")
                .Append("     [Person].[Zip Code], ")
                .Append("     [Person].[Home Tel], ")
                .Append("     [Person].[Other Tel], ")
                .Append("     [Person].Email, ")
                .Append("     [Person].[Registration Date], ")
                .Append("     [Person].Note, ")
                .Append("     [Person].[Last Update Date] ")
                .Append(" ) ")
                .Append("VALUES ")
                .Append("(@Name,@Gender,@PersonTitleID,@Street,@City,@ZipCode,@HomeTel,@OtherTel,@Email,@RegistrationDate,")
                .Append(" @Note,@LastUpdateDate) ")
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

                If personEnt.name = "" Then
                    cmd.Parameters.Add(New SqlParameter("@Name", SqlDbType.NVarChar, personEnt.name.Length, "Name")).Value = DBNull.Value
                Else
                    cmd.Parameters.Add(New SqlParameter("@Name", SqlDbType.NVarChar, personEnt.name.Length, "Name")).Value = personEnt.name
                End If

                If personEnt.gender = "" Then
                    cmd.Parameters.Add(New SqlParameter("@Gender", SqlDbType.NVarChar, personEnt.gender.Length, "Gender")).Value = DBNull.Value
                Else
                    cmd.Parameters.Add(New SqlParameter("@Gender", SqlDbType.NVarChar, personEnt.gender.Length, "Gender")).Value = personEnt.gender
                End If

                cmd.Parameters.Add(New SqlParameter("@PersonTitleID", SqlDbType.NVarChar, personEnt.personTitleID.Length, "Person Title ID")).Value = personEnt.personTitleID

                If personEnt.street = "" Then
                    cmd.Parameters.Add(New SqlParameter("@Street", SqlDbType.NVarChar, personEnt.street.Length, "Street")).Value = DBNull.Value
                Else
                    cmd.Parameters.Add(New SqlParameter("@Street", SqlDbType.NVarChar, personEnt.street.Length, "Street")).Value = personEnt.street
                End If

                If personEnt.city = "" Then
                    cmd.Parameters.Add(New SqlParameter("@City", SqlDbType.NVarChar, personEnt.city.Length, "City")).Value = DBNull.Value
                Else
                    cmd.Parameters.Add(New SqlParameter("@City", SqlDbType.NVarChar, personEnt.city.Length, "City")).Value = personEnt.city
                End If

                If personEnt.zipCode = "" Then
                    cmd.Parameters.Add(New SqlParameter("@ZipCode", SqlDbType.NVarChar, personEnt.zipCode.Length, "Zip Code")).Value = DBNull.Value
                Else
                    cmd.Parameters.Add(New SqlParameter("@ZipCode", SqlDbType.NVarChar, personEnt.zipCode.Length, "Zip Code")).Value = personEnt.zipCode
                End If

                If personEnt.homeTel = "" Then
                    cmd.Parameters.Add(New SqlParameter("@HomeTel", SqlDbType.NVarChar, personEnt.homeTel.Length, "Home Tel")).Value = DBNull.Value
                Else
                    cmd.Parameters.Add(New SqlParameter("@HomeTel", SqlDbType.NVarChar, personEnt.homeTel.Length, "Home Tel")).Value = personEnt.homeTel
                End If

                If personEnt.otherTel = "" Then
                    cmd.Parameters.Add(New SqlParameter("@OtherTel", SqlDbType.NVarChar, personEnt.otherTel.Length, "Other Tel")).Value = DBNull.Value
                Else
                    cmd.Parameters.Add(New SqlParameter("@OtherTel", SqlDbType.NVarChar, personEnt.otherTel.Length, "Other Tel")).Value = personEnt.otherTel
                End If

                If personEnt.email = "" Then
                    cmd.Parameters.Add(New SqlParameter("@Email", SqlDbType.NVarChar, personEnt.email.Length, "Email")).Value = DBNull.Value
                Else
                    cmd.Parameters.Add(New SqlParameter("@Email", SqlDbType.NVarChar, personEnt.email.Length, "Email")).Value = personEnt.email
                End If

                If personEnt.registrationDate = "" Then
                    cmd.Parameters.Add(New SqlParameter("@RegistrationDate", SqlDbType.DateTime, personEnt.registrationDate.Length, "Registration Date")).Value = DBNull.Value
                Else
                    cmd.Parameters.Add(New SqlParameter("@RegistrationDate", SqlDbType.DateTime, personEnt.registrationDate.Length, "Registration Date")).Value = personEnt.registrationDate
                End If

                If personEnt.note = "" Then
                    cmd.Parameters.Add(New SqlParameter("@Note", SqlDbType.NText, personEnt.note.Length, "Note")).Value = DBNull.Value
                Else
                    cmd.Parameters.Add(New SqlParameter("@Note", SqlDbType.NText, personEnt.note.Length, "Note")).Value = personEnt.gender
                End If

                If personEnt.lastUpdateDate = "" Then
                    cmd.Parameters.Add(New SqlParameter("@LastUpdateDate", SqlDbType.DateTime, personEnt.lastUpdateDate.Length, "Last Update Date")).Value = DBNull.Value
                Else
                    cmd.Parameters.Add(New SqlParameter("@LastUpdateDate", SqlDbType.DateTime, personEnt.lastUpdateDate.Length, "Last Update Date")).Value = personEnt.lastUpdateDate
                End If

                insertRecord = cmd.ExecuteNonQuery()
                ta.Commit()

            Catch ex As Exception
                ta.Rollback()
                MessageBox.Show("Error at PersonDAL.insertRecord : " + ex.Message)
            Finally
                m_DBUtil.closeConnection(cmd, cn, ta)
                sb = Nothing
            End Try
            Return insertRecord
        End Function

        Public Function updateRecord(ByVal personEnt As TKPC.Entity.PersonEnt) As Integer
            Dim sql As String = String.Empty
            Dim cn As SqlConnection = Nothing
            Dim cmd As SqlCommand = Nothing
            Dim ta As SqlTransaction = Nothing
            Dim sb As StringBuilder = New StringBuilder
            updateRecord = 0

            With sb
                .Append("UPDATE [Person] ")
                .Append("SET  ")
                .Append("     [Person].Name = @Name, ")
                .Append("     [Person].Gender = @Gender, ")
                .Append("     [Person].[Person Title ID] = @PersonTitleID, ")
                .Append("     [Person].Street = @Street, ")
                .Append("     [Person].City = @City, ")
                .Append("     [Person].[Zip Code] = @ZipCode, ")
                .Append("     [Person].[Home Tel] = @HomeTel, ")
                .Append("     [Person].[Other Tel] = @OtherTel, ")
                .Append("     [Person].Email = @Email, ")
                .Append("     [Person].[Registration Date] = @RegistrationDate, ")
                .Append("     [Person].Note = @Note, ")
                .Append("     [Person].[Last Update Date] = @LastUpdateDate ")
                .Append("WHERE [Person ID] = @PersonID ")
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

                If personEnt.name = "" Then
                    cmd.Parameters.Add(New SqlParameter("@Name", SqlDbType.NVarChar, personEnt.name.Length, "Name")).Value = DBNull.Value
                Else
                    cmd.Parameters.Add(New SqlParameter("@Name", SqlDbType.NVarChar, personEnt.name.Length, "Name")).Value = personEnt.name
                End If

                If personEnt.gender = "" Then
                    cmd.Parameters.Add(New SqlParameter("@Gender", SqlDbType.NVarChar, personEnt.gender.Length, "Gender")).Value = DBNull.Value
                Else
                    cmd.Parameters.Add(New SqlParameter("@Gender", SqlDbType.NVarChar, personEnt.gender.Length, "Gender")).Value = personEnt.gender
                End If

                cmd.Parameters.Add(New SqlParameter("@PersonTitleID", SqlDbType.NVarChar, personEnt.personTitleID.Length, "Person Title ID")).Value = personEnt.personTitleID

                If personEnt.street = "" Then
                    cmd.Parameters.Add(New SqlParameter("@Street", SqlDbType.NVarChar, personEnt.street.Length, "Street")).Value = DBNull.Value
                Else
                    cmd.Parameters.Add(New SqlParameter("@Street", SqlDbType.NVarChar, personEnt.street.Length, "Street")).Value = personEnt.street
                End If

                If personEnt.city = "" Then
                    cmd.Parameters.Add(New SqlParameter("@City", SqlDbType.NVarChar, personEnt.city.Length, "City")).Value = DBNull.Value
                Else
                    cmd.Parameters.Add(New SqlParameter("@City", SqlDbType.NVarChar, personEnt.city.Length, "City")).Value = personEnt.city
                End If

                If personEnt.zipCode = "" Then
                    cmd.Parameters.Add(New SqlParameter("@ZipCode", SqlDbType.NVarChar, personEnt.zipCode.Length, "Zip Code")).Value = DBNull.Value
                Else
                    cmd.Parameters.Add(New SqlParameter("@ZipCode", SqlDbType.NVarChar, personEnt.zipCode.Length, "Zip Code")).Value = personEnt.zipCode
                End If

                If personEnt.homeTel = "" Then
                    cmd.Parameters.Add(New SqlParameter("@HomeTel", SqlDbType.NVarChar, personEnt.homeTel.Length, "Home Tel")).Value = DBNull.Value
                Else
                    cmd.Parameters.Add(New SqlParameter("@HomeTel", SqlDbType.NVarChar, personEnt.homeTel.Length, "Home Tel")).Value = personEnt.homeTel
                End If

                If personEnt.otherTel = "" Then
                    cmd.Parameters.Add(New SqlParameter("@OtherTel", SqlDbType.NVarChar, personEnt.otherTel.Length, "Other Tel")).Value = DBNull.Value
                Else
                    cmd.Parameters.Add(New SqlParameter("@OtherTel", SqlDbType.NVarChar, personEnt.otherTel.Length, "Other Tel")).Value = personEnt.otherTel
                End If

                If personEnt.email = "" Then
                    cmd.Parameters.Add(New SqlParameter("@Email", SqlDbType.NVarChar, personEnt.email.Length, "Email")).Value = DBNull.Value
                Else
                    cmd.Parameters.Add(New SqlParameter("@Email", SqlDbType.NVarChar, personEnt.email.Length, "Email")).Value = personEnt.email
                End If

                If personEnt.registrationDate = "" Then
                    cmd.Parameters.Add(New SqlParameter("@RegistrationDate", SqlDbType.DateTime, personEnt.registrationDate.Length, "Registration Date")).Value = DBNull.Value
                Else
                    cmd.Parameters.Add(New SqlParameter("@RegistrationDate", SqlDbType.DateTime, personEnt.registrationDate.Length, "Registration Date")).Value = personEnt.registrationDate
                End If

                If personEnt.note = "" Then
                    cmd.Parameters.Add(New SqlParameter("@Note", SqlDbType.NText, personEnt.note.Length, "Note")).Value = DBNull.Value
                Else
                    cmd.Parameters.Add(New SqlParameter("@Note", SqlDbType.NText, personEnt.note.Length, "Note")).Value = personEnt.note
                End If

                If personEnt.lastUpdateDate = "" Then
                    cmd.Parameters.Add(New SqlParameter("@LastUpdateDate", SqlDbType.DateTime, personEnt.lastUpdateDate.Length, "Last Update Date")).Value = DBNull.Value
                Else
                    cmd.Parameters.Add(New SqlParameter("@LastUpdateDate", SqlDbType.DateTime, personEnt.lastUpdateDate.Length, "Last Update Date")).Value = personEnt.lastUpdateDate
                End If

                cmd.Parameters.Add(New SqlParameter("@PersonID", SqlDbType.NVarChar, personEnt.personID.Length, "Person ID")).Value = personEnt.personID

                updateRecord = cmd.ExecuteNonQuery()
                ta.Commit()

            Catch ex As Exception
                ta.Rollback()
                MessageBox.Show("Error at PersonDAL.updateRecord : " + ex.Message)
            Finally
                m_DBUtil.closeConnection(cmd, cn, ta)
                sb = Nothing
            End Try
            Return updateRecord
        End Function

        Public Function validateLoginUser(ByVal ID As String, ByVal PWD As String) As TKPC.Entity.PersonEnt
            Dim sql As String = String.Empty
            Dim cn As SqlConnection = Nothing
            Dim cmd As SqlCommand = Nothing
            Dim dr As SqlDataReader = Nothing
            Dim sb As StringBuilder = New StringBuilder
            validateLoginUser = New TKPC.Entity.PersonEnt

            With sb
                .Append("SELECT [Person ID] AS [ID], ")
                .Append("       [Name] AS [이름], ")
                .Append("       [Login Level] ")
                .Append("FROM [Person] ")
                .Append("WHERE [Person].[Login ID] = @ID ")
                .Append("AND [Person].[Login PWD] = @PWD ")
            End With
            sql = sb.ToString

            Try
                cn = New SqlConnection(m_Constant.SQL_CONSTR)

                'If (cn.State = ConnectionState.Closed) Then
                'MessageBox.Show("Connection State at PersonDAL.validateLoginUser : Closed")
                'End
                'End If

                'provider to be used when working with access database
                cn.Open()

                cmd = New SqlCommand(sql, cn)
                cmd.CommandTimeout = 0
                cmd.Parameters.Add(New SqlParameter("@ID", SqlDbType.NVarChar)).Value = ID
                cmd.Parameters.Add(New SqlParameter("@PWD", SqlDbType.NVarChar)).Value = PWD

                dr = cmd.ExecuteReader()

                If dr.Read() Then
                    If IsDBNull(dr("ID")) Then
                        validateLoginUser.personID = ""
                    Else
                        validateLoginUser.personID = dr("ID")
                    End If

                    If IsDBNull(dr("이름")) Then
                        validateLoginUser.name = ""
                    Else
                        validateLoginUser.name = dr("이름")
                    End If

                    If IsDBNull(dr("Login Level")) Then
                        validateLoginUser.loginLevel = ""
                    Else
                        validateLoginUser.loginLevel = dr("Login Level")
                    End If
                End If

            Catch ex As Exception
                MessageBox.Show("Error at PersonDAL.validateLoginUser : " + ex.Message)
            Finally
                m_DBUtil.closeConnection(dr, cmd, cn)
                sb = Nothing
            End Try
        End Function

        Public Function validateLoginID(ByVal ID As String) As TKPC.Entity.PersonEnt
            Dim sql As String = String.Empty
            Dim cn As SqlConnection = Nothing
            Dim cmd As SqlCommand = Nothing
            Dim dr As SqlDataReader = Nothing
            Dim sb As StringBuilder = New StringBuilder
            validateLoginID = New TKPC.Entity.PersonEnt

            With sb
                .Append("SELECT [Person ID] AS [ID], ")
                .Append("       [Name] AS [이름], ")
                .Append("       [Login Level] ")
                .Append("FROM [Person] ")
                .Append("WHERE [Person].[Login ID] = @ID ")
            End With
            sql = sb.ToString

            Try
                cn = New SqlConnection(m_Constant.SQL_CONSTR)

                'provider to be used when working with access database
                cn.Open()

                cmd = New SqlCommand(sql, cn)
                cmd.CommandTimeout = 0
                cmd.Parameters.Add(New SqlParameter("@ID", SqlDbType.NVarChar)).Value = ID

                dr = cmd.ExecuteReader()

                If dr.Read() Then
                    If IsDBNull(dr("ID")) Then
                        validateLoginID.personID = ""
                    Else
                        validateLoginID.personID = dr("ID")
                    End If

                    If IsDBNull(dr("이름")) Then
                        validateLoginID.name = ""
                    Else
                        validateLoginID.name = dr("이름")
                    End If

                    If IsDBNull(dr("Login Level")) Then
                        validateLoginID.loginLevel = ""
                    Else
                        validateLoginID.loginLevel = dr("Login Level")
                    End If
                End If

            Catch ex As Exception
                MessageBox.Show("Error at PersonDAL.validateLoginID : " + ex.Message)
            Finally
                m_DBUtil.closeConnection(dr, cmd, cn)
                sb = Nothing
            End Try
        End Function

        Public Function updateLoginInfo(ByVal personEnt As TKPC.Entity.PersonEnt) As Integer
            Dim sql As String = String.Empty
            Dim cn As SqlConnection = Nothing
            Dim cmd As SqlCommand = Nothing
            Dim ta As SqlTransaction = Nothing
            Dim sb As StringBuilder = New StringBuilder
            updateLoginInfo = 0

            With sb
                .Append("UPDATE [Person] ")
                .Append("SET ")
                .Append("   [Login ID] = @LoginID, ")
                .Append("   [Login Level] = @LoginLevel, ")
                .Append("   [Login PWD] = @LoginPWD ")
                .Append("WHERE [Person].[Person ID] = @ID ")
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

                cmd.Parameters.Add(New SqlParameter("@ID", SqlDbType.NVarChar)).Value = personEnt.personID
                cmd.Parameters.Add(New SqlParameter("@LoginPWD", SqlDbType.NVarChar)).Value = CytographyPassword.EncryptText(personEnt.loginPassword)
                cmd.Parameters.Add(New SqlParameter("@LoginID", SqlDbType.NVarChar)).Value = personEnt.loginID
                cmd.Parameters.Add(New SqlParameter("@LoginLevel", SqlDbType.NVarChar)).Value = personEnt.loginLevel

                updateLoginInfo = cmd.ExecuteNonQuery()
                ta.Commit()

            Catch ex As Exception
                MessageBox.Show("Error at PersonDAL.updateLoginInfo : " + ex.Message)
            Finally
                m_DBUtil.closeConnection(cmd, cn, ta)
                sb = Nothing
            End Try
        End Function
    End Class
End Namespace


