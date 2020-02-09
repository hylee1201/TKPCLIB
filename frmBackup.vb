Imports Microsoft.SqlServer.Management.Smo
Imports Microsoft.SqlServer.Management.Common

Public Class frmBackup
    Dim WithEvents oBackup As New Backup
    Dim inserted As Integer = 0
    Dim totalNumberOfRows As Integer = 0

    Private Sub ProgressEventHandler(ByVal sender As Object, ByVal e As PercentCompleteEventArgs)
        pbTKPC.Value = e.Percent
        lblTKPC.Text = e.Percent.ToString + "%"
    End Sub

    Private Sub BackupSqlDatabase()
        'Dim conn As New ServerConnection("ADMIN-PC\SQLEXPRESS") ' -- set SQL server connection given the server name, user name and password
        'Dim oSQLServer As New Server(conn) '--create the SMO server object using connection

        'Dim OrigBackupPath As String = oSQLServer.Information.MasterDBPath.Replace("\DATA", "\Backup\TKPC_BACKUP.BAK") ' -- set the path where backup file will be stored
        'lblPath.Text = OrigBackupPath
        'Dim bkDevItem As New BackupDeviceItem(OrigBackupPath, DeviceType.File) ' -- create SMO.Backupdevice object

        'With oBackup ' Set the backup object property 
        '    .PercentCompleteNotification = 10
        '    .Action = BackupActionType.Database
        '    .Database = "TKPC"
        '    .Devices.Add(bkDevItem)
        '    .Initialize = True
        '    .Checksum = True
        '    .ContinueAfterError = True
        '    .Incremental = False
        '    .LogTruncation = BackupTruncateLogType.Truncate
        '    AddHandler .PercentComplete, AddressOf ProgressEventHandler
        '    .SqlBackup(oSQLServer) ' backup SQL database
        'End With

        Dim barcodePrintDAL As TKPC.DAL.BarcodePrintDAL = TKPC.DAL.BarcodePrintDAL.getInstance()
        Try
            barcodePrintDAL.deleteRecord()
            inserted = barcodePrintDAL.insertRecord2()
            pbTKPC.Visible = False

            Dim bookDAL As TKPC.DAL.BookDAL = TKPC.DAL.BookDAL.getInstance()
            Dim ds As DataSet = Nothing
            Dim bs As BindingSource = Nothing

            ds = bookDAL.getList(PARTIAL_LIST4, "Y")

            If ds IsNot Nothing Then
                bs = New BindingSource
                bs.DataSource = ds.Tables(0)
                totalNumberOfRows = ds.Tables(0).Rows.Count
            End If

        Catch ex As Exception
        Finally
            barcodePrintDAL = Nothing
        End Try
    End Sub

    Private Sub frmBackup_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
        System.Threading.Thread.Sleep(2000)
        Dim rentBookDAL As TKPC.DAL.RentBookDAL = TKPC.DAL.RentBookDAL.getInstance()

        Try
            With pbTKPC
                .Minimum = 0
                .Maximum = 100
            End With
            lblTKPC.Text = ""

            'Updated orphan status
            Dim updated As Integer = 0
            Dim updated2 As Integer = 0
            updated = rentBookDAL.updateRentBookStatus(0)
            updated2 = rentBookDAL.updateRentBookStatus(1)
            rentBookDAL.updateRentPerson()

            BackupSqlDatabase()
        Catch ex As Exception
            MessageBox.Show(ex.Message + "Error at backing up TKPC database.")
        Finally
            lblTKPC.Text = Convert.ToString(inserted) + " records out of " + Convert.ToString(totalNumberOfRows) + " have been newly inserted for print."
            btnClose.Visible = True
            rentBookDAL = Nothing
        End Try
    End Sub

    Private Sub btnClose_VisibleChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnClose.VisibleChanged
        If btnClose.Visible = True Then
            System.Threading.Thread.Sleep(4000)
        End If
    End Sub

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.Close()
        Me.Dispose()
    End Sub

    Private Sub frmBackup_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub
End Class