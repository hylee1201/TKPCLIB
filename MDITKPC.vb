Imports System.Windows.Forms

Public Class MDITKPC
    Private m_ChildFormNumber As Integer

    Private Sub ShowNewForm(ByVal sender As Object, ByVal e As EventArgs)
        ' Create a new instance of the child form.
        Dim ChildForm As New System.Windows.Forms.Form
        ' Make it a child of this MDI form before showing it.
        ChildForm.MdiParent = Me

        m_ChildFormNumber += 1
        ChildForm.Text = "Window " & m_ChildFormNumber

        ChildForm.Show()
    End Sub

    Private Sub OpenFile(ByVal sender As Object, ByVal e As EventArgs)
        Dim OpenFileDialog As New OpenFileDialog
        OpenFileDialog.InitialDirectory = My.Computer.FileSystem.SpecialDirectories.MyDocuments
        OpenFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*"
        If (OpenFileDialog.ShowDialog(Me) = System.Windows.Forms.DialogResult.OK) Then
            Dim FileName As String = OpenFileDialog.FileName
            ' TODO: Add code here to open the file.
        End If
    End Sub

    Private Sub SaveAsToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
        Dim SaveFileDialog As New SaveFileDialog
        SaveFileDialog.InitialDirectory = My.Computer.FileSystem.SpecialDirectories.MyDocuments
        SaveFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*"

        If (SaveFileDialog.ShowDialog(Me) = System.Windows.Forms.DialogResult.OK) Then
            Dim FileName As String = SaveFileDialog.FileName
            ' TODO: Add code here to save the current contents of the form to a file.
        End If
    End Sub


    Private Sub ExitToolsStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
        Me.Close()
    End Sub

    Private Sub CutToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles CutToolStripMenuItem.Click
        ' Use My.Computer.Clipboard to insert the selected text or images into the clipboard
        Dim activeChild As Form = Me.ActiveMdiChild

        If (Not activeChild Is Nothing) Then
            Try
                Clipboard.SetDataObject(CType(activeChild.ActiveControl, TextBox).SelectedText)
                CType(activeChild.ActiveControl, TextBox).SelectedText = String.Empty
            Catch
                MessageBox.Show("Please select a text field box.")
            End Try
        End If
    End Sub

    Private Sub CopyToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles CopyToolStripMenuItem.Click
        ' Use My.Computer.Clipboard to insert the selected text or images into the clipboard
        Dim activeChild As Form = Me.ActiveMdiChild

        If (Not activeChild Is Nothing) Then
            Try
                Clipboard.SetDataObject(CType(activeChild.ActiveControl, TextBox).SelectedText)
            Catch
                MessageBox.Show("Please select a text field box.")
            End Try
        End If
    End Sub

    Private Sub PasteToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles PasteToolStripMenuItem.Click
        'Use My.Computer.Clipboard.GetText() or My.Computer.Clipboard.GetData to retrieve information from the clipboard.
        Dim activeChild As Form = Me.ActiveMdiChild

        If (Not activeChild Is Nothing) Then
            Try
                Dim oDataObject As IDataObject
                oDataObject = Clipboard.GetDataObject()
                If oDataObject.GetDataPresent(DataFormats.UnicodeText) Then
                    CType(activeChild.ActiveControl, TextBox).SelectedText = CType(oDataObject.GetData(DataFormats.UnicodeText), String)
                End If
            Catch
                MessageBox.Show("Please select a text field box.")
            End Try
        End If
    End Sub

    Private Sub CascadeToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
        Me.LayoutMdi(MdiLayout.Cascade)
    End Sub

    Private Sub TileVerticalToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
        Me.LayoutMdi(MdiLayout.TileVertical)
    End Sub

    Private Sub TileHorizontalToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
        Me.LayoutMdi(MdiLayout.TileHorizontal)
    End Sub

    Private Sub ArrangeIconsToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
        Me.LayoutMdi(MdiLayout.ArrangeIcons)
    End Sub

    Private Sub CloseAllToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
        ' Close all child forms of the parent.
        For Each ChildForm As Form In Me.MdiChildren
            ChildForm.Close()
        Next
    End Sub

    Private Sub 입력ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        With frmBookAdd
            .MdiParent = Me
            .Show()
        End With
    End Sub

    Private Sub 대출기록ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        frmPersonAdd.viewMode = VIEW_MODE_ADD_NEW
        openForm(Me, frmPersonAdd)
    End Sub

    Private Sub 입력ToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        openForm(Me, frmRentAdd)
    End Sub

    Private Sub utexMDI_ItemClick(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinExplorerBar.ItemEventArgs) Handles utexMDI.ItemClick
        Select Case e.Item.Key
            Case "BookAdd"
                With frmBookAdd
                    .MdiParent = Me
                    .Show()
                    .BringToFront()
                    .makeGridVisible(False)
                End With
            Case "BookList"
                openForm(Me, frmBookList)
            Case "ReservedBookList"
                openForm(Me, frmReserveList)
            Case "PersonAdd"
                With frmPersonAdd
                    .MdiParent = Me
                    .Show()
                    .BringToFront()
                    .makeGridVisible(False)
                End With
            Case "PersonList"
                openForm(Me, frmPersonList)
            Case "ReservedPersonList"
                openForm(Me, frmReserveList)
            Case "RentAdd"
                If returnAddFormOpened = 1 And returnAddFormSaved = 1 Then
                    Dim response As MsgBoxResult = MsgBox("The returned books were NOT saved yet. " + vbNewLine & _
                                                          vbNewLine & _
                                                          "Do you want to save them first?", MsgBoxStyle.YesNo, "Confirmation before Closing")
                    If response = MsgBoxResult.Yes Then
                        frmReturnAdd.tsbtSave_Click(sender, e)
                        openForm(Me, frmRentAdd)
                    Else
                        openForm(Me, frmRentAdd)
                    End If
                Else
                    openForm(Me, frmRentAdd)
                End If
            Case "ReturnAdd"
                openForm(Me, frmReturnAdd)
            Case "RentList"
                openForm(Me, frmRentList)
            Case "Calendar"
                openForm(Me, frmCalendar)
            Case "Calculator"
                frmCalculator.Show()
            Case "Barcode"
                With frmBarcodeMain
                    .txtCustomBarcode.Visible = True
                    .ShowDialog()
                End With
            Case "Memo"
                With frmMemoAdd
                    .Show()
                End With
            Case "About"
                frmAboutBox.ShowDialog()
        End Select
    End Sub

    Private Sub MDITKPC_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        'If m_Constant.SQL_CONSTR.Contains("TKPC") = True Then
        '    Try
        '        frmBackup.ShowDialog()
        '    Catch ex As Exception
        '        MessageBox.Show("Error at Backup database : " + ex.Message)
        '    End Try
        'End If
    End Sub

    'Private Sub MDITKPC_Disposed(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Disposed
    '    Dim bookDAL As TKPC.DAL.BookDAL = Nothing
    '    Try
    '        bookDAL = TKPC.DAL.BookDAL.getInstance()
    '        bookDAL.updateBookFlags(1, "")
    '    Catch ex As Exception
    '    Finally
    '        bookDAL = Nothing
    '    End Try
    'End Sub

    Private Sub MDITKPC_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Show()
        lblToday.Text = "Today: " + FormatDateTime(Today, DateFormat.LongDate)
        lblLoginUser.Text = "현재 사용자: " + loginUserName
        SwitchIME(hEnLayoutId, KbdEn)
        openForm2(Me, frmRentAdd)
        openForm(Me, frmReturnAdd)
    End Sub

    Private Sub ExitToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.Close()
        Me.Dispose()
    End Sub

    Private Sub chkMenu_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkMenu.CheckedChanged
        If chkMenu.Checked = True Then
            utexMDI.Hide()
        Else
            utexMDI.Show()
        End If
    End Sub

    Private Sub UndoToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UndoToolStripMenuItem.Click
        Dim activeChild As Form = Me.ActiveMdiChild

        If (Not activeChild Is Nothing) Then
            Try
                'CType(activeChild.ActiveControl, TextBox).Text = CType(activeChild.ActiveControl, TextBox).Tag
                'SendMessageLong(CType(activeChild.ActiveControl, TextBox).Handle, EM_UNDO, 0, 0)
                CType(activeChild.ActiveControl, TextBox).Undo()
            Catch
                MessageBox.Show("Please select a text field box.")
            End Try
        End If
    End Sub

    Private Sub SaveToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SaveToolStripMenuItem.Click
        Dim activeChild As Form = Me.ActiveMdiChild

        If (Not activeChild Is Nothing) Then
            Try
                If activeChild.Name = "frmPersonAdd" Then
                    frmPersonAdd.tsbtSave_Click(sender, e)
                ElseIf activeChild.Name = "frmBookAdd" Then
                    frmBookAdd.tsbtSave_Click(sender, e)
                ElseIf activeChild.Name = "frmBookAdd2" Then
                    frmBookAdd.tsbtSave_Click(sender, e)
                ElseIf activeChild.Name = "frmRentAdd" Then
                    frmRentAdd.tsbtSave_Click(sender, e)
                ElseIf activeChild.Name = "frmReturnAdd" Then
                    frmReturnAdd.tsbtSave_Click(sender, e)
                End If
            Catch

            End Try
        End If
    End Sub

    Private Sub AddNewToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AddNewToolStripMenuItem.Click
        Dim activeChild As Form = Me.ActiveMdiChild

        If (Not activeChild Is Nothing) Then
            Try
                If activeChild.Name = "frmPersonAdd" Then
                    frmPersonAdd.tsbtAdd_Click(sender, e)
                ElseIf activeChild.Name = "frmBookAdd" Then
                    frmBookAdd.tsbtAdd_Click(sender, e)
                ElseIf activeChild.Name = "frmBookAdd2" Then
                    frmBookAdd.tsbtAdd_Click(sender, e)
                ElseIf activeChild.Name = "frmRentAdd" Then
                    frmRentAdd.tsbtAdd_Click(sender, e)
                End If
            Catch ex As Exception
                MessageBox.Show(ex.ToString)
            End Try
        End If
    End Sub

    Private Sub 도서ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 도서ToolStripMenuItem.Click
        With frmBookAdd
            .MdiParent = Me
            .Show()
        End With
    End Sub

    Private Sub 도서목록ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 도서목록ToolStripMenuItem.Click
        openForm(Me, frmBookList)
    End Sub

    Private Sub 회원ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 회원ToolStripMenuItem.Click
        With frmPersonAdd
            .MdiParent = Me
            .Show()
        End With
    End Sub

    Private Sub 회원목록ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 회원목록ToolStripMenuItem.Click
        openForm(Me, frmPersonList)
    End Sub

    Private Sub 대출입력ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 대출입력ToolStripMenuItem.Click
        openForm(Me, frmRentAdd)
    End Sub

    Private Sub 반납입력ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 반납입력ToolStripMenuItem.Click
        openForm(Me, frmReturnAdd)
    End Sub

    Private Sub 대출반납목록ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 대출반납목록ToolStripMenuItem.Click
        openForm(Me, frmRentList)
    End Sub

    Private Sub 달력ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 달력ToolStripMenuItem.Click
        openForm(Me, frmCalendar)
    End Sub

    Private Sub 계산기ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 계산기ToolStripMenuItem.Click
        frmCalculator.Show()
    End Sub
End Class
