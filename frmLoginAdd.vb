Public Class frmLoginAdd

    Private Sub btClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btClose.Click
        Me.Close()
        Me.Dispose()
    End Sub

    Private Sub frmLoginAdd_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
    End Sub

    Private Sub btSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btSave.Click
        If txtPWD.Text.Trim = String.Empty Then
            MessageBox.Show("Please enter the password.")
            txtPWD.Focus()
            Exit Sub
        End If

        If txtID.Text.Trim = String.Empty Then
            MessageBox.Show("Please enter the ID.")
            txtID.Focus()
            Exit Sub
        End If

        If txtPWD2.Text.Trim = String.Empty Then
            MessageBox.Show("Please enter the confirmation password.")
            txtPWD2.Focus()
            Exit Sub
        End If

        If txtPWD.Text.Trim <> txtPWD2.Text.Trim Then
            MessageBox.Show("Please confirm the password.")
            txtPWD2.Focus()
            Exit Sub
        End If

        Dim personEnt As TKPC.Entity.PersonEnt
        Dim personEnt2 As TKPC.Entity.PersonEnt
        Dim personDAL As TKPC.DAL.PersonDAL

        Try
            personDAL = TKPC.DAL.PersonDAL.getInstance
            personEnt = New TKPC.Entity.PersonEnt
            personEnt2 = New TKPC.Entity.PersonEnt
            With personEnt
                .loginID = txtID.Text
                .personID = lblPersonID.Text
                .loginPassword = txtPWD.Text
                .loginLevel = cbLevel.SelectedIndex
            End With

            personEnt2 = personDAL.validateLoginID(txtID.Text)
            If personEnt2.loginID <> "" And personEnt2.personID <> lblPersonID.Text Then
                MessageBox.Show("The login ID has been already registered. " + vbNewLine + "Please use another one.")
                txtID.Text = ""
                txtID.Focus()
            Else
                Dim affectedRows As Integer = 0
                affectedRows = personDAL.updateLoginInfo(personEnt)
                If affectedRows = 1 Then
                    MessageBox.Show("The login access has been successfully set up.")
                Else
                    MessageBox.Show("The login access was not saved.")
                End If
            End If

        Catch ex As Exception
        Finally '
            personEnt = Nothing
            personDAL = Nothing
        End Try
    End Sub

    Private Sub txtID_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtID.GotFocus
        HighlightControl(txtID)
    End Sub

    Private Sub txtID_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtID.LostFocus
        UnHighlightControl(txtID)
    End Sub

    Private Sub txtPWD_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtPWD.GotFocus
        HighlightControl(txtPWD)
    End Sub

    Private Sub txtPWD_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtPWD.LostFocus
        UnHighlightControl(txtPWD)
    End Sub

    Private Sub txtPWD2_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtPWD2.GotFocus
        HighlightControl(txtPWD2)
    End Sub

    Private Sub txtPWD2_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtPWD2.KeyDown
        If e.KeyCode = Keys.Enter Then
            btSave_Click(sender, e)
        End If
    End Sub

    Private Sub txtPWD2_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtPWD2.LostFocus
        UnHighlightControl(txtPWD2)
    End Sub
End Class