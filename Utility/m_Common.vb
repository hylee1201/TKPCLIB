Imports System.IO

Module m_Common
    Public BookListLoadedFlag As Boolean
    Public PersonListLoadedFlag As Boolean
    Public RentListLoadedFlag As Boolean
    Public prevForm As Form
    Public boxScanCode As String = ""
    Public mainFrm As New frmBarcodeMain
    Public RentAddLoadedFlag As Boolean
    Public bookListRowIndex As Integer = 0
    Public loginUserID As Integer = 0
    Public loginUserName As String = ""
    Public loginAccess As String = "1"
    Public bookListViewID As Integer = 0
    '******************  For automatic IME switch  ********************************
    'Private Const KL_NAMELENGTH As Long = 9
    'Public OriginalLayoutId As Long
    'Public OriginalLayoutName As String
    Public hKrLayoutId As Long
    Public hEnLayoutId As Long
    Public whichIME As Integer = 0
    '**********************************************************************************
    Public returnAddFormOpened As Integer = 0
    Public returnAddFormSaved As Integer = 0

    Public Sub openForm(ByVal mdiForm As Windows.Forms.Form, ByRef frm As Windows.Forms.Form)
        Cursor.Current = Cursors.WaitCursor
        'Dim f As Windows.Forms.Form
        'For Each f In mdiForm.MdiChildren
        '    If Not (frm Is f) Then
        '        Windows.Forms.Application.DoEvents()
        '        f.Close()
        '    End If
        'Next
        'frm.MdiParent = mdiForm
        ''frm.WindowState = winState
        'frm.Show()
        'frm.BringToFront()

        frm.WindowState = FormWindowState.Maximized
        frm.MdiParent = MDITKPC
        frm.Show()
        frm.BringToFront()
        Cursor.Current = Cursors.Default
        ''
    End Sub
    Public Sub openForm2(ByVal mdiForm As Windows.Forms.Form, ByRef frm As Windows.Forms.Form)
        Cursor.Current = Cursors.WaitCursor
        'Dim f As Windows.Forms.Form
        'For Each f In mdiForm.MdiChildren
        '    If Not (frm Is f) Then
        '        Windows.Forms.Application.DoEvents()
        '        f.Close()
        '    End If
        'Next
        'frm.MdiParent = mdiForm
        ''frm.WindowState = winState
        'frm.Show()
        'frm.BringToFront()

        frm.WindowState = FormWindowState.Maximized
        frm.MdiParent = MDITKPC
        frm.Show()
        Cursor.Current = Cursors.Default
        ''
    End Sub
    Public Sub openFormDialog(ByRef frm As Windows.Forms.Form)
        Cursor.Current = Cursors.WaitCursor
        'Dim f As Windows.Forms.Form
        'For Each f In mdiForm.MdiChildren
        '    If Not (frm Is f) Then
        '        Windows.Forms.Application.DoEvents()
        '        f.Close()
        '    End If
        'Next
        'frm.MdiParent = mdiForm
        ''frm.WindowState = winState
        'frm.Show()
        'frm.BringToFront()

        frm.WindowState = FormWindowState.Maximized
        frm.ShowDialog()
        Cursor.Current = Cursors.Default
        ''
    End Sub
    Public Sub releaseObject(ByVal obj As Object)
        Try
            System.Runtime.InteropServices.Marshal.ReleaseComObject(obj)
            obj = Nothing
        Catch ex As Exception
            obj = Nothing
        Finally
            GC.Collect()
        End Try
    End Sub
    'Public Sub openExcelFile(ByVal theFile As String)
    '    Try
    '        If File.Exists(theFile) Then

    '            Dim xlApp As Excel.Application
    '            Dim xlWorkBook As Excel.Workbook

    '            xlApp = New Excel.ApplicationClass
    '            xlWorkBook = xlApp.Workbooks.Open(theFile)
    '            xlApp.Visible = True
    '            xlWorkBook.Activate()
    '            releaseObject(xlApp)
    '            releaseObject(xlWorkBook)

    '        End If

    '    Catch ex As Exception
    '        MessageBox.Show("Error at generating excel file..." + ex.Message)
    '    Finally
    '    End Try
    'End Sub
    Public Sub closeForm(ByVal theForm As Form)
        theForm.Close()
        theForm.Dispose()
    End Sub

    Public Sub clearControlsOnPanel(ByVal thePanel As Panel)
        Dim ctrl As Control
        Dim txt As TextBox
        Dim cb As ComboBox
        Dim chk As CheckBox

        For Each ctrl In thePanel.Controls
            If (ctrl.GetType() Is GetType(TextBox)) Then
                txt = CType(ctrl, TextBox)
                txt.Clear()

            ElseIf (ctrl.GetType() Is GetType(ComboBox)) Then
                cb = CType(ctrl, ComboBox)
                cb.Text = ""

            ElseIf (ctrl.GetType() Is GetType(CheckBox)) Then
                chk = CType(ctrl, CheckBox)
                chk.Checked = False

            End If
        Next
    End Sub
    Public Sub clearControlsOnGroupBox(ByVal theGroupBox As Infragistics.Win.Misc.UltraGroupBox)
        Dim ctrl As Control
        Dim txt As TextBox
        Dim cb As ComboBox
        Dim chk As CheckBox

        For Each ctrl In theGroupBox.Controls
            If (ctrl.GetType() Is GetType(TextBox)) Then
                txt = CType(ctrl, TextBox)
                txt.Clear()

            ElseIf (ctrl.GetType() Is GetType(ComboBox)) Then
                cb = CType(ctrl, ComboBox)
                cb.SelectedIndex = 0

            ElseIf (ctrl.GetType() Is GetType(CheckBox)) Then
                chk = CType(ctrl, CheckBox)
                chk.Checked = False

            End If
        Next
    End Sub

    Public Sub HighlightControl(ByVal ctl As Control)
        ctl.BackColor = System.Drawing.Color.BlanchedAlmond
        ctl.Select()
    End Sub

    Public Sub UnHighlightControl(ByVal ctl As Control)
        ctl.BackColor = System.Drawing.Color.White
    End Sub

    Public Sub makeItNumericWithDot(ByVal sender As System.Object, ByVal theTextBox As TextBox, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        Dim tb As TextBox = CType(sender, TextBox)
        Dim chr As Char = e.KeyChar
        If IsNumeric(e.KeyChar) And Not e.KeyChar = "-" Then
            'If adding the character to the end of the current TextBox value results in
            ' a numeric value, go on. Otherwise, set e.Handled to True, and don't let
            ' the character to be added.
            e.Handled = Not IsNumeric(tb.Text & e.KeyChar)
        ElseIf e.KeyChar = "." Then
            'For the decimal character (.) we need a different rule:
            'If adding a decimal to the end of the current value of the TextBox results
            ' in a numeric value, it can be added. If not, this means we already have a
            ' decimal in the TextBox value, so we only allow the new decimal to sit in
            ' when it is overwriting the previous decimal.
            If Not (tb.SelectedText = "." Or IsNumeric(tb.Text & e.KeyChar)) Then
                e.Handled = True
            End If
        ElseIf e.KeyChar = "-" Then
            'A negative sign is prevented if the "-" key is pressed in any location
            ' other than the begining of the number, or if the number already has a
            ' negative sign
            If tb.SelectionStart <> 0 Or Microsoft.VisualBasic.Left(tb.Text, 1) = "-" Then
                e.Handled = True
            End If
        ElseIf Not Char.IsControl(e.KeyChar) Then
            'IsControl is checked, because without that, keys like BackSpace couldn't
            ' work correctly.
            e.Handled = True
        End If
    End Sub

    Public Sub makeItNumericWithDash(ByVal sender As System.Object, ByVal theTextBox As TextBox, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        Dim tb As TextBox = CType(sender, TextBox)
        Dim chr As Char = e.KeyChar
        If IsNumeric(e.KeyChar) And Not e.KeyChar = "-" Then
            'If adding the character to the end of the current TextBox value results in
            ' a numeric value, go on. Otherwise, set e.Handled to True, and don't let
            ' the character to be added.
            e.Handled = Not IsNumeric(tb.Text & e.KeyChar)
        ElseIf e.KeyChar = "-" Then
            'A negative sign is prevented if the "-" key is pressed in any location
            ' other than the begining of the number, or if the number already has a
            ' negative sign
            If tb.SelectionStart = 0 And Microsoft.VisualBasic.Left(tb.Text, 1) = "-" Then
                e.Handled = False
            End If
        ElseIf Not Char.IsControl(e.KeyChar) Then
            'IsControl is checked, because without that, keys like BackSpace couldn't
            ' work correctly.
            e.Handled = True
        End If
    End Sub

    Public Sub makeItNumericOnly(ByVal theTextBox As TextBox, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        If IsNumeric(e.KeyChar) = True Then
            e.Handled = False
        Else
            If Asc(e.KeyChar) = 8 Then
                e.Handled = False
            Else
                e.Handled = True
            End If
        End If
    End Sub
    Public Sub changeFindButtonText(ByVal theFindButton As Button, ByVal ugGrid As Infragistics.Win.UltraWinGrid.UltraGrid)
        If ugGrid.Visible = True Then
            theFindButton.Text = "Hide"
        Else
            theFindButton.Text = "Find"
        End If
    End Sub
    Public Function getComboValueToUpdate(ByVal theCombo As ComboBox) As String
        getComboValueToUpdate = ""
        If theCombo.SelectedValue Is Nothing Then
            getComboValueToUpdate = theCombo.Text
        Else
            If theCombo.SelectedValue.ToString.Trim.ToUpper <> theCombo.Text.Trim.ToUpper Then
                getComboValueToUpdate = theCombo.Text
            Else
                getComboValueToUpdate = theCombo.SelectedValue
            End If
        End If

        If getComboValueToUpdate = "System.Data.DataRowView" Then
            getComboValueToUpdate = ""
        End If
    End Function
    Public Sub setPanelMenuEnabled(ByVal flag As Boolean, ByVal rentGroupFlag As Boolean)
        'MDITKPC.utexMDI.Groups(0).Enabled = flag
        'MDITKPC.utexMDI.Groups(1).Enabled = flag
        'MDITKPC.utexMDI.Groups(2).Enabled = rentGroupFlag
    End Sub

    Public Sub setCombo(ByVal cbType As ComboBox)
        Dim bookDAL As TKPC.DAL.BookDAL = TKPC.DAL.BookDAL.getInstance()
        Dim aList As ArrayList
        Dim dt As DataTable

        Try
            aList = bookDAL.getDataTable()
            dt = aList(0)

            If dt IsNot Nothing Then
                cbType.DataSource = dt
                cbType.DisplayMember = "Name"
                cbType.ValueMember = "Value"
            End If
        Catch ex As Exception
        Finally
            bookDAL = Nothing
            aList = Nothing
            dt = Nothing
        End Try
    End Sub

    Public Function UppercaseFirst(ByVal s As String) As String
        UppercaseFirst = String.Empty
        If s = String.Empty Or s = "" Or IsDBNull(s) Then
            Exit Function
        End If

        Dim a As Array = s.Trim.ToCharArray()
        For i As Integer = 0 To a.Length - 1
            If i = 0 Then
                a(i) = Char.ToUpper(a(i))
            Else
                a(i) = Char.ToLower(a(i))
            End If
        Next

        UppercaseFirst = New String(a)

        Return UppercaseFirst
    End Function

    Public Declare Function LoadKeyboardLayout Lib "user32" Alias "LoadKeyboardLayoutA" ( _
        ByVal pwszKLID As String, ByVal Flags As Long) As Long

    Public Declare Function UnloadKeyboardLayout Lib "user32" ( _
        ByVal HKL As Long) As Long

    Public Declare Function ActivateKeyboardLayout Lib "user32" ( _
        ByVal HKL As Long, ByVal Flags As Long) As Long

    Public Declare Function GetKeyboardLayout Lib "user32" ( _
        ByVal dwLayout As Long) As Long

    Public Declare Function GetKeyboardLayoutName Lib "user32" Alias "GetKeyboardLayoutNameA" ( _
        ByVal pwszKLID As String) As Long

    Public Function SwitchIME(ByRef hLayoutId As Long, ByRef KbdId As String) As Integer
        '//Loading Keyboard requires string identifier
        SwitchIME = 0
        hLayoutId = LoadKeyboardLayout(KbdId, 0)
        ActivateKeyboardLayout(hLayoutId, 0)
        If KbdId = KbdKr Then
            SwitchIME = 1
        End If
    End Function

    Public Sub setAutoTelAreaCode(ByVal txt As TextBox, ByVal e As System.Windows.Forms.KeyEventArgs)
        'If txt.Text.Trim.Length = 1 Then
        '    If e.KeyCode = Keys.NumPad4 Or e.KeyCode = Keys.D4 Then
        '        txt.Text = "416-"
        '        txt.SelectionStart = txt.Text.Length
        '    ElseIf e.KeyCode = Keys.NumPad9 Or e.KeyCode = Keys.D9 Then
        '        txt.Text = "905-"
        '        txt.SelectionStart = txt.Text.Length
        '    ElseIf e.KeyCode = Keys.NumPad5 Or e.KeyCode = Keys.D5 Then
        '        txt.Text = "519-"
        '        txt.SelectionStart = txt.Text.Length
        '    ElseIf e.KeyCode = Keys.NumPad6 Or e.KeyCode = Keys.D6 Then
        '        txt.Text = "647-"
        '        txt.SelectionStart = txt.Text.Length
        '    End If
        'End If
    End Sub

    Public Sub setPicture(ByRef picPerson As PictureBox, ByVal personID As String)
        Dim IMAGE_DIR As String = My.Application.Info.DirectoryPath.ToString

        'For deployment
        Dim IMAGE_PATH As String = IMAGE_DIR + "\Images\people\"
        'Dim idx As Integer = IMAGE_DIR.IndexOf("\bin\Debug")
        'Dim IMAGE_PATH As String = IMAGE_DIR.Substring(0, idx) + "\Images\people\"
        Dim imageRoot As String = "p" + personID
        Dim imageJPG As String = IMAGE_PATH + imageRoot + ".jpg"
        Dim imageJPG2 As String = IMAGE_PATH + imageRoot + ".JPG"
        Dim imageTIF As String = IMAGE_PATH + imageRoot + ".tif"
        Dim imageTIF2 As String = IMAGE_PATH + imageRoot + ".TIF"
        Dim imageGIF As String = IMAGE_PATH + imageRoot + ".gif"
        Dim imageGIF2 As String = IMAGE_PATH + imageRoot + ".GIF"
        Dim imageBMP As String = IMAGE_PATH + imageRoot + ".bmp"
        Dim imageBMP2 As String = IMAGE_PATH + imageRoot + ".BMP"
        Dim flag As Integer = 0

        If File.Exists(imageJPG) = True Then
            picPerson.Image = Image.FromFile(imageJPG)
            flag = 1
        ElseIf File.Exists(imageJPG2) = True Then
            picPerson.Image = Image.FromFile(imageJPG2)
            flag = 1
        ElseIf File.Exists(imageGIF) = True Then
            picPerson.Image = Image.FromFile(imageGIF)
            flag = 1
        ElseIf File.Exists(imageGIF2) = True Then
            picPerson.Image = Image.FromFile(imageGIF2)
            flag = 1
        ElseIf File.Exists(imageTIF) = True Then
            picPerson.Image = Image.FromFile(imageTIF)
            flag = 1
        ElseIf File.Exists(imageTIF2) = True Then
            picPerson.Image = Image.FromFile(imageTIF2)
            flag = 1
        ElseIf File.Exists(imageBMP) = True Then
            picPerson.Image = Image.FromFile(imageBMP)
            flag = 1
        ElseIf File.Exists(imageBMP2) = True Then
            picPerson.Image = Image.FromFile(imageBMP2)
            flag = 1
        End If

        If flag = 0 Then
            If File.Exists(IMAGE_PATH + "p0.JPG") = True Then
                picPerson.Image = Image.FromFile(IMAGE_PATH + "p0.JPG")
            End If
        End If
    End Sub

End Module
