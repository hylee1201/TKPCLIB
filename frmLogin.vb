Imports System
Imports System.ServiceProcess

Public Class frmLogin

    Private Sub txtID_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtID.TextChanged
        If txtID.Text = String.Empty Or txtPWD.Text = String.Empty Then
            btEnter.Enabled = False
        Else
            btEnter.Enabled = True
        End If
    End Sub

    Private Sub frmLogin_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        txtID.Focus()
    End Sub

    Private Sub txtPWD_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtPWD.KeyDown
        If e.KeyCode = Keys.Enter Then
            If txtID.Text <> String.Empty And txtPWD.Text <> String.Empty Then
                authenticateUser()
            Else
                MessageBox.Show("Please enter ID and Password.")
                If txtID.Text = String.Empty Then
                    txtID.Focus()
                Else
                    txtPWD.Focus()
                End If
            End If
        End If
    End Sub

    Private Sub txtPWD_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtPWD.TextChanged
        If txtID.Text = String.Empty Or txtPWD.Text = String.Empty Then
            btEnter.Enabled = False
        Else
            btEnter.Enabled = True
        End If
    End Sub

    Private Sub btCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btCancel.Click
        Me.Close()
        Me.Dispose()
    End Sub

    Private Sub authenticateUser()
        Dim personDAL As TKPC.DAL.PersonDAL = TKPC.DAL.PersonDAL.getInstance
        Dim personEnt As TKPC.Entity.PersonEnt = New TKPC.Entity.PersonEnt

        Try
            startDB("MSSQL$SQLEXPRESS")
            startDB("MSSQL$TKPCDB")
            Cursor.Current = Cursors.WaitCursor
            personEnt = personDAL.validateLoginUser(txtID.Text, CytographyPassword.EncryptText(txtPWD.Text))

            If personEnt.personID IsNot Nothing Then
                With personEnt
                    loginUserName = .name
                    loginUserID = .personID
                    loginAccess = .loginLevel
                End With
                MDITKPC.Show()
                Me.Close()
                Me.Dispose()
            Else
                MessageBox.Show("You have entered the invalid ID and Password." + vbNewLine + "Please try again.")
                txtID.Text = String.Empty
                txtPWD.Text = String.Empty
                txtID.Focus()
            End If

        Catch ex As Exception
            MessageBox.Show("Error at Login: " + ex.Message)
        Finally
            personDAL = Nothing
            personEnt = Nothing
            Cursor.Current = Cursors.Default
        End Try
    End Sub
    Private Sub startDB(ByVal serviceName As String)
        Dim myServiceName As String = serviceName 'service name of SQL Server Expressrin
        Dim status As String  'service status (For example, Running or Stopped)
        Dim mySC As ServiceController

        ulblStatus.Text = "Service: " & myServiceName

        'display service status: For example, Running, Stopped, or Paused
        mySC = New ServiceController(myServiceName)
        Try
            status = mySC.Status.ToString
        Catch ex As Exception
            ulblStatus.Text = "Service not found. It is probably not installed. [exception=" & ex.Message & "]"
            End
        End Try
        ulblStatus.Text = "Service status : " & status

        'if service is Stopped or StopPending, you can run it with the following code.
        If mySC.Status.Equals(ServiceControllerStatus.Stopped) Or mySC.Status.Equals(ServiceControllerStatus.StopPending) Then
            Try
                ulblStatus.Text = "Starting the service..."
                mySC.Start()
                mySC.WaitForStatus(ServiceControllerStatus.Running)
                ulblStatus.Text = "The service is now " & mySC.Status.ToString

            Catch ex As Exception
                MessageBox.Show("Error in starting the service: " & ex.Message)
            End Try
        Else
            ulblStatus.Text = "Service already started."
        End If
    End Sub

    Private Sub btEnter_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btEnter.Click
        authenticateUser()
    End Sub

    Private Sub cn_InfoMessage(ByVal sender As System.Object, ByVal e As System.Data.SqlClient.SqlInfoMessageEventArgs)

    End Sub
End Class