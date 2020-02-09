Imports System.Text.RegularExpressions
Imports System.IO

Public Class frmPersonAdd
    Public viewMode As Integer
    Public personEnt As TKPC.Entity.PersonEnt
    Public callingForm As frmPersonList
    Private Const GENDER_TYPE_MAN = "M"
    Private Const GENDER_TYPE_MAN2 = "남"
    Private Const GENDER_TYPE_WOMAN = "F"
    Private Const GENDER_TYPE_WOMAN2 = "여"
    Private CITY_ROW_INDEX As Integer = 0
    Private TEL_ROW_INDEX As Integer = 0
    Private closingMode As Boolean = False
    Public fromWhichForm As Integer = 0
    Public keyPressedName As Integer = 0
    Private emptyDS As DataSet
    Private refStorage As Hashtable = New Hashtable

    Private Function setEntityValue() As TKPC.Entity.PersonEnt
        setEntityValue = New TKPC.Entity.PersonEnt

        setEntityValue.personID = lblID.Text
        setEntityValue.name = txtName.Text
        setEntityValue.personTitle = cbTitle.Text
        setEntityValue.personTitleID = cbTitle.SelectedValue

        If rbtMan.Checked = True Then
            setEntityValue.gender = GENDER_TYPE_MAN
        Else
            setEntityValue.gender = GENDER_TYPE_WOMAN
        End If

        setEntityValue.homeTel = txtHomeTel.Text
        setEntityValue.otherTel = txtOtherTel.Text
        setEntityValue.street = txtStreet.Text
        setEntityValue.city = txtCity.Text
        setEntityValue.zipCode = txtZipCode.Text
        setEntityValue.email = txtEmail.Text

        If udtReg.Value Is Nothing Then
            setEntityValue.registrationDate = ""
        Else
            setEntityValue.registrationDate = udtReg.Value
        End If

        setEntityValue.note = txtNote.Text
        setEntityValue.lastUpdateDate = Today.Date

    End Function

    Public Sub tsbtSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbtSave.Click
        'whichIME = SwitchIME(hEnLayoutId, KbdEn)
        Dim personDAL As TKPC.DAL.PersonDAL

        If txtName.Text = String.Empty Then
            MessageBox.Show("Please enter a person's name.")
            txtName.Focus()
            Exit Sub
        End If

        If txtHomeTel.Text = String.Empty Then
            MessageBox.Show("Please enter a person's home telephone number.")
            txtHomeTel.Focus()
            Exit Sub
        Else
            Dim myMatch As Match = System.Text.RegularExpressions.Regex.Match(txtHomeTel.Text, TEL_REGEX)
            If Not myMatch.Success Then
                MessageBox.Show("Please enter a valid 'Home' telephone number in 999-999-9999 format.")
                txtHomeTel.Focus()
                Exit Sub
            End If
        End If

        If txtOtherTel.Text <> "" Then
            Dim myMatch As Match = System.Text.RegularExpressions.Regex.Match(txtOtherTel.Text, TEL_REGEX)
            If Not myMatch.Success Then
                MessageBox.Show("Please enter a valid 'Other' telephone number in 999-999-9999 format.")
                txtOtherTel.Focus()
                Exit Sub
            End If
        End If

        Dim flag As Boolean = setZipCode()
        If flag = True Then
            Exit Sub
        End If

        If txtEmail.Text <> "" Then
            Dim myMatch As Match = System.Text.RegularExpressions.Regex.Match(txtEmail.Text, EMAIL_REGEX)
            If Not myMatch.Success Then
                MessageBox.Show("Please enter a valid email address in aaa@aaa.aaa format.")
                txtEmail.Focus()
                Exit Sub
            End If
        End If

        makeGridVisible(False)
        makeFirstUpperCase(txtStreet.Text)
        makeFirstUpperCase(txtCity.Text)

        Try
            Cursor.Current = Cursors.WaitCursor
            personDAL = TKPC.DAL.PersonDAL.getInstance()
            Dim numberOfUpdatedRow As Integer = 0

            If viewMode = VIEW_MODE_ADD_NEW Then
                numberOfUpdatedRow = personDAL.insertRecord(setEntityValue())
            Else
                numberOfUpdatedRow = personDAL.updateRecord(setEntityValue())
            End If

            If numberOfUpdatedRow = 1 Then
                MessageBox.Show("Person record has been successfully saved.")
                personEnt = setEntityValue()
                viewMode = VIEW_MODE_DETAIL
                If lblID.Text = "ID" Then
                    lblID.Text = m_DBUtil.getMaxNumber("Person", "Person ID")
                    personEnt.personID = lblID.Text
                End If
                init()
                ugTitle.Visible = False

                'If list form is open, refresh the list form
                'If PersonListLoadedFlag = True Then
                '    frmPersonList.tsbtRefresh_Click(sender, e)
                'End If

                If fromWhichForm = 99 Then
                    frmRentAdd.personInfoAddedNow = True
                    If frmRentAdd.txtPersonName.Text.Trim.Length = 0 Then
                        frmRentAdd.txtPersonName.Text = txtName.Text
                    End If
                    Me.Close()
                    Me.Dispose()
                Else
                    If closingMode = False Then
                        Dim message As String = "Do you want to add another person?"
                        Dim Result As DialogResult
                        Dim caption As String = "Add New?"
                        Dim buttons As MessageBoxButtons = MessageBoxButtons.YesNo

                        Result = MessageBox.Show(message, caption, buttons)
                        If Result = System.Windows.Forms.DialogResult.Yes Then
                            enableControls(False)
                            resetControls()
                            txtName.Focus()
                            viewMode = VIEW_MODE_ADD_NEW
                            setPanelMenuEnabled(False, False)
                        End If
                    End If
                End If
            Else
                MessageBox.Show("Person record was not saved. ")
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            personDAL = Nothing
            Cursor.Current = Cursors.Default
        End Try

    End Sub
    Private Sub makeFirstUpperCase(ByRef s As String)
        If s <> String.Empty And s <> "" Then
            Dim oneUnitOfStreet As String() = s.Trim.Split(" ")
            Dim street As String = String.Empty

            For i As Integer = 0 To oneUnitOfStreet.Length - 1
                street += UppercaseFirst(oneUnitOfStreet(i)) + " "
            Next

            If street <> String.Empty Then
                s = street.Trim
            End If
        End If
    End Sub
    Private Function setZipCode() As Boolean
        setZipCode = False

        If txtZipCode.Text <> "" Then
            Dim myMatch As Match = System.Text.RegularExpressions.Regex.Match(txtZipCode.Text, ZIP_WITHOUT_SPACE_REGEX)
            If Not myMatch.Success Then
                myMatch = System.Text.RegularExpressions.Regex.Match(txtZipCode.Text, ZIP_WITH_SPACE_REGEX)
                If Not myMatch.Success Then
                    MessageBox.Show("Please enter a valid postal code in A9A 9A9 format.")
                    txtZipCode.Focus()
                    setZipCode = True
                End If
            Else
                Dim zip As String = txtZipCode.Text
                zip = zip.Substring(0, 3) + " " + zip.Substring(3, 3)
                txtZipCode.Text = zip
            End If
        End If
    End Function
    Public Sub makeGridVisible(ByVal flag)
        ugCity.Visible = flag
        ugName.Visible = flag
        ugTitle.Visible = flag
    End Sub

    Private Sub frmPersonAdd_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        If fromWhichForm <> FROM_RENT_ADD Then
            setPanelMenuEnabled(True, True)
        End If
        personEnt = Nothing
        emptyDS = Nothing
        refStorage = Nothing
        Dispose()
    End Sub
    Private Sub frmPersonAdd_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        If compareFields() <> "" Then
            Dim theMsg As String = String.Empty
            If compareFields.Trim.EndsWith(",") Then
                theMsg = compareFields.Substring(0, compareFields.Length - 2)
            End If

            Dim response As MsgBoxResult = MsgBox("The following fields have been changed without saving. " + vbNewLine & _
                                                  theMsg + vbNewLine & _
                                                  "Do you want to save them first?", MsgBoxStyle.YesNoCancel, "Confirmation before Closing")
            If response = MsgBoxResult.Yes Then
                closingMode = True
                tsbtSave_Click(sender, e)
                e.Cancel = False

            ElseIf response = MsgBoxResult.Cancel Then
                e.Cancel = True

            Else
                e.Cancel = False
            End If
        End If
    End Sub

    Private Sub frmPersonAdd_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Show()
        setCombo()
        init()
        setPanelMenuEnabled(False, False)
        ''Retrieves current handle to the keyboard layout
        'OriginalLayoutId = GetKeyboardLayout(0)
        ''creates a buffers
        'OriginalLayoutName = New String("", KL_NAMELENGTH - 1)
        ''Retrieves current name of the active keyboard layout
        'GetKeyboardLayoutName(OriginalLayoutName)
        ''MsgBox("Current keyboard layout is => " & OriginalLayoutName)
    End Sub
    Private Sub init()
        setRefGrid()
        If viewMode = VIEW_MODE_DETAIL Then
            enableControls(True)
            setValuesToControls()
            setPicture(picPerson, personEnt.personID)
            populateRefDropdown(txtHomeTel.Text, lblID.Text)
        Else
            enableControls(False)
            txtName.Focus()
            lblID.Text = "ID"
            udtReg.Value = Today
            setPicture(picPerson, "0")
            If emptyDS IsNot Nothing Then
                ugRef.DataSource = emptyDS.Tables(0)
                setRefGrid()
            Else
                populateRefDropdown("0", "0")
            End If
        End If
    End Sub

    Private Sub setCombo()
        Dim personDAL As TKPC.DAL.PersonDAL = TKPC.DAL.PersonDAL.getInstance()
        Dim aList As ArrayList = personDAL.getDataTable()
        Dim dt As DataTable

        Try
            dt = aList(0)

            If dt IsNot Nothing Then
                cbTitle.DataSource = dt
                cbTitle.DisplayMember = "Name"
                cbTitle.ValueMember = "Value"
            End If
            cbTitle.SelectedIndex = 4
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            personDAL = Nothing
            dt = Nothing
            aList = Nothing
        End Try
    End Sub
    Private Sub setRefGrid()
        With ugRef
            .DisplayLayout.Bands(0).Columns("선택").Width = 28
            .DisplayLayout.Bands(0).Columns("ID").Width = 30
            .DisplayLayout.Bands(0).Columns("이름").Width = 40
            .DisplayLayout.Bands(0).Columns("직분").Width = 30
            .DisplayLayout.Bands(0).Columns("성별").Width = 25
            .DisplayLayout.Bands(0).Columns("집 전화").Width = 60
            .DisplayLayout.Bands(0).Columns("다른 전화").Width = 60
            .DisplayLayout.Bands(0).Columns("이메일").Width = 65
            .DisplayLayout.Bands(0).Columns("거리명").Hidden = True
            .DisplayLayout.Bands(0).Columns("도시명").Hidden = True
            .DisplayLayout.Bands(0).Columns("우편번호").Hidden = True
            .DisplayLayout.Bands(0).Columns("비고").Hidden = True
            .DisplayLayout.Bands(0).Columns("등록일").Hidden = True
            .DisplayLayout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.ResizeAllColumns
        End With
    End Sub

    Private Sub enableControls(ByVal flag As Boolean)
        tsbtDelete.Enabled = flag
        'tsbtAdd.Enabled = flag
        tsbtHistory.Enabled = flag
        tsbtRent.Enabled = flag
        btAdd.Enabled = flag

        If loginAccess = "1" Then
            tsbtAuthenticate.Enabled = flag
        End If
    End Sub

    Private Sub setValuesToControls()
        lblID.Text = personEnt.personID
        txtName.Text = personEnt.name
        cbTitle.Text = personEnt.personTitle

        If personEnt.gender = GENDER_TYPE_MAN Or personEnt.gender = GENDER_TYPE_MAN2 Then
            rbtMan.Checked = True
        Else
            rbtWoman.Checked = True
        End If

        txtHomeTel.Text = personEnt.homeTel
        txtOtherTel.Text = personEnt.otherTel
        txtStreet.Text = personEnt.street
        txtCity.Text = personEnt.city
        txtZipCode.Text = personEnt.zipCode
        txtEmail.Text = personEnt.email

        udtReg.Value = personEnt.registrationDate
        txtNote.Text = personEnt.note
        lblLoginID.Text = personEnt.loginID
        lblLoginPWD.Text = personEnt.loginPassword
        lblLoginLevel.Text = personEnt.loginLevel

        If loginAccess = "1" Then
            If lblLoginID.Text <> "ID" And lblLoginID.Text <> "" Then
                tsbtAuthenticate.BackColor = Color.ForestGreen
            Else
                tsbtAuthenticate.BackColor = Color.LightSteelBlue
            End If
        End If
    End Sub
    Private Sub resetControls()
        lblID.Text = "ID"
        txtName.Text = String.Empty

        txtHomeTel.Text = String.Empty
        txtOtherTel.Text = String.Empty
        txtStreet.Text = String.Empty
        txtCity.Text = String.Empty
        txtZipCode.Text = String.Empty
        txtEmail.Text = String.Empty
        txtNote.Text = String.Empty
        cbTitle.SelectedIndex = 4
        rbtMan.Checked = True
        lblLoginID.Text = String.Empty
        lblLoginLevel.Text = String.Empty
        lblLoginPWD.Text = String.Empty

        If emptyDS IsNot Nothing Then
            ugRef.DataSource = emptyDS.Tables(0)
            setRefGrid()
        Else
            populateRefDropdown("0", "0")
        End If
    End Sub

    Private Sub tsbtDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbtDelete.Click
        'whichIME = SwitchIME(hEnLayoutId, KbdEn)
        If MsgBox("Do you want to delete the record?", MsgBoxStyle.YesNo, "Delete") = MsgBoxResult.Yes Then
            Dim personDAL As TKPC.DAL.PersonDAL

            Try
                Cursor.Current = Cursors.WaitCursor
                personDAL = TKPC.DAL.PersonDAL.getInstance()
                Dim numberOfDeletedRow As Integer = 0

                numberOfDeletedRow = personDAL.deleteRecordByID(lblID.Text)

                If numberOfDeletedRow = 1 Then
                    MessageBox.Show("Person record has been successfully deleted.")
                    clearControls()

                    'If list form is open, refresh the list form
                    If PersonListLoadedFlag = True Then
                        frmPersonList.tsbtRefresh_Click(sender, e)
                    End If
                End If
            Catch ex As Exception
                MessageBox.Show(ex.Message)
            Finally
                personDAL = Nothing
                Cursor.Current = Cursors.Default
                setPanelMenuEnabled(True, True)
            End Try

        End If
    End Sub

    Private Sub clearControls()
        clearControlsOnPanel(pnMain)
        clearControlsOnGroupBox(ugbAddress)
        clearControlsOnGroupBox(ugbTel)
        makeGridVisible(False)
        viewMode = VIEW_MODE_ADD_NEW
        init()
    End Sub

    Private Function compareFields() As String
        compareFields = String.Empty

        If viewMode = VIEW_MODE_DETAIL Then
            If txtName.Text.Trim.ToUpper <> personEnt.name.Trim.ToUpper Then
                compareFields += "이름, "
            End If

            If cbTitle.Text.Trim.ToUpper <> personEnt.personTitle.Trim.ToUpper Then
                compareFields += "직분, "
            End If

            If txtHomeTel.Text.Trim.ToUpper <> personEnt.homeTel.Trim.ToUpper Then
                compareFields += "집 전화번호, "
            End If

            If txtOtherTel.Text.Trim.ToUpper <> personEnt.otherTel.Trim.ToUpper Then
                compareFields += "다른 전화번호, "
            End If

            If txtStreet.Text.Trim.ToUpper <> personEnt.street.Trim.ToUpper Then
                compareFields += "Street, "
            End If

            If txtCity.Text.Trim.ToUpper <> personEnt.city.Trim.ToUpper Then
                compareFields += "City, "
            End If

            If txtZipCode.Text.Trim.ToUpper <> personEnt.zipCode.Trim.ToUpper Then
                compareFields += "Zip Code, "
            End If

            If txtEmail.Text.Trim.ToUpper <> personEnt.email.Trim.ToUpper Then
                compareFields += "이메일, "
            End If

            If txtNote.Text.Trim.ToUpper <> personEnt.note.Trim.ToUpper Then
                compareFields += "비고, "
            End If

            If personEnt.gender = GENDER_TYPE_MAN Or personEnt.gender = GENDER_TYPE_MAN2 Then
                If rbtMan.Checked = False Then
                    compareFields += "성별, "
                End If
            Else
                If rbtWoman.Checked = False Then
                    compareFields += "성별, "
                End If
            End If

            If personEnt.registrationDate <> "" Then
                If udtReg.Value <> personEnt.registrationDate Then
                    compareFields += "회원등록일, "
                End If
            End If
        Else
            If txtName.Text.Trim <> String.Empty And txtHomeTel.Text.Trim <> String.Empty Then
                compareFields += "이름, "

                'If cbTitle.Text.Trim <> "" Then
                '    compareFields += "Person Title, "
                'End If

                If txtHomeTel.Text.Trim <> String.Empty Then
                    compareFields += "집 전화번호, "
                End If

                If txtOtherTel.Text.Trim <> String.Empty Then
                    compareFields += "다른 전화번호, "
                End If

                If txtStreet.Text.Trim <> String.Empty Then
                    compareFields += "Street, "
                End If

                If txtCity.Text.Trim <> String.Empty Then
                    compareFields += "City, "
                End If

                If txtZipCode.Text.Trim <> String.Empty Then
                    compareFields += "Zip Code, "
                End If

                If txtEmail.Text.Trim <> String.Empty Then
                    compareFields += "이메일, "
                End If

                If txtNote.Text.Trim <> String.Empty Then
                    compareFields += "비고, "
                End If
            End If
        End If
    End Function

    Public Sub tsbtAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbtAdd.Click
        'whichIME = SwitchIME(hEnLayoutId, KbdEn)
        setPanelMenuEnabled(False, False)
        If compareFields() <> "" Then
            Dim theMsg As String = String.Empty

            If compareFields.Trim.EndsWith(",") Then
                theMsg = compareFields.Substring(0, compareFields.Length - 2)
            End If

            Dim response As MsgBoxResult = MsgBox("The following fields have been changed without saving. " + vbNewLine & _
                                                  theMsg + vbNewLine & _
                                                  "Do you want to save them first?", MsgBoxStyle.YesNoCancel, "Confirmation before Add New")

            If response = MsgBoxResult.Yes Then
                tsbtSave_Click(sender, e)
                clearControls()

            ElseIf response = MsgBoxResult.No Then
                clearControls()
            Else
                'Do nothing in case of Cancel
            End If
        Else
            clearControls()
        End If
    End Sub

    Private Sub txtCity_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtCity.GotFocus
        HighlightControl(txtCity)
        makeGridVisible(False)
    End Sub

    Private Sub txtCity_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtCity.KeyDown
        If e.KeyCode = Keys.Tab Then
            txtZipCode.Focus()

        ElseIf e.KeyCode = Keys.Down Then
            If ugCity.Visible = True Then
                ugCity.Focus()
                ugCity.Rows(0).Selected = True
            End If
        End If
    End Sub

    Private Sub txtCity_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtCity.KeyUp
        If txtCity.Text <> "" Then
            If e.KeyCode <> Keys.Tab And e.KeyCode <> Keys.Down Then
                populateCityDropdown()
            End If
        Else
            ugCity.DataSource = Nothing
            makeGridVisible(False)
        End If
    End Sub

    Private Sub txtCity_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtCity.LostFocus
        UnHighlightControl(txtCity)
        If ugCity.Visible = True And ugCity.Rows.Count = 1 Then
            txtCity.Text = ugCity.Rows(0).Cells(0).Value
            ugCity.Visible = False
        End If
    End Sub

    Private Sub txtEmail_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtEmail.GotFocus
        HighlightControl(txtEmail)
        whichIME = SwitchIME(hEnLayoutId, KbdEn)
    End Sub

    Private Sub txtEmail_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtEmail.KeyDown
        If e.KeyCode = Keys.Tab Then
            udtReg.Focus()
        End If
    End Sub

    Private Sub txtEmail_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtEmail.LostFocus
        UnHighlightControl(txtEmail)
    End Sub

    Private Sub txtHomeTel_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtHomeTel.GotFocus
        HighlightControl(txtHomeTel)
        makeGridVisible(False)
    End Sub

    'Private Sub txtHomeTel_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtHomeTel.KeyPress
    '    'makeItNumericWithDash(sender, txtHomeTel, e)
    'End Sub

    Private Sub txtHomeTel_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtHomeTel.LostFocus
        UnHighlightControl(txtHomeTel)
    End Sub

    Private Sub txtName_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtName.GotFocus
        HighlightControl(txtName)

        If whichIME = 0 Then
            whichIME = SwitchIME(hKrLayoutId, KbdKr)
        End If
    End Sub

    Private Sub txtName_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtName.KeyDown
        If e.KeyCode = Keys.Tab Then
            cbTitle.Focus()
        ElseIf e.KeyCode = Keys.Down Then
            If ugName.Visible = True Then
                ugName.Focus()
                ugName.Rows(0).Selected = True
            End If
        Else
            keyPressedName = 1
        End If
    End Sub

    'Private Sub languageChange(ByVal sender As Object, ByVal e As InputLanguageChangedEventArgs) Handles MyBase.InputLanguageChanged
    '    If e.InputLanguage.Culture.TwoLetterISOLanguageName.Equals("ja") = True Then
    '        txtName.ImeMode = System.Windows.Forms.ImeMode.Katakana
    '    End If
    'End Sub

    Private Sub txtName_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtName.KeyUp
        If txtName.Text <> "" Then
            If keyPressedName = 1 Then
                populateNameDropdown()
            End If
        Else
            ugName.DataSource = Nothing
            makeGridVisible(False)
        End If
    End Sub

    Private Sub txtName_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtName.LostFocus
        UnHighlightControl(txtName)
        keyPressedName = 0
    End Sub

    Private Sub txtNote_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtNote.GotFocus
        HighlightControl(txtNote)
    End Sub

    Private Sub txtNote_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtNote.LostFocus
        UnHighlightControl(txtNote)
    End Sub

    Private Sub txtOtherTel_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtOtherTel.GotFocus
        HighlightControl(txtOtherTel)
        makeGridVisible(False)
    End Sub

    Private Sub txtOtherTel_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtOtherTel.KeyDown
        If e.KeyCode = Keys.Tab Then
            txtStreet.Focus()
        End If
    End Sub

    Private Sub txtOtherTel_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtOtherTel.KeyUp
        setAutoTelAreaCode(txtOtherTel, e)
    End Sub

    'Private Sub txtOtherTel_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtOtherTel.KeyPress
    '    'makeItNumericWithDash(sender, txtOtherTel, e)
    'End Sub

    Private Sub txtOtherTel_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtOtherTel.LostFocus
        UnHighlightControl(txtOtherTel)
    End Sub

    Private Sub txtStreet_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtStreet.GotFocus
        HighlightControl(txtStreet)
        makeGridVisible(False)
    End Sub

    Private Sub txtStreet_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtStreet.KeyDown
        If e.KeyCode = Keys.Tab Then
            txtCity.Focus()
        End If
    End Sub

    'Private Sub txtStreet_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtStreet.KeyUp
    '    'populateAddressDropdown()
    'End Sub

    Private Sub txtStreet_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtStreet.LostFocus
        UnHighlightControl(txtStreet)
    End Sub

    Private Sub txtZipCode_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtZipCode.GotFocus
        HighlightControl(txtZipCode)
    End Sub

    Private Sub txtZipCode_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtZipCode.KeyDown
        If e.KeyCode = Keys.Tab Then
            txtEmail.Focus()
        End If
    End Sub

    Private Sub txtZipCode_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtZipCode.LostFocus
        UnHighlightControl(txtZipCode)
    End Sub

    Private Sub udtReg_EditorButtonClick(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinEditors.EditorButtonEventArgs) Handles udtReg.EditorButtonClick
        udtReg.Value = Nothing
    End Sub

    Private Sub udtReg_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles udtReg.GotFocus
        HighlightControl(udtReg)
    End Sub

    Private Sub udtReg_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles udtReg.KeyDown
        If e.KeyCode = Keys.Tab Then
            txtNote.Focus()
        End If
    End Sub

    Private Sub udtReg_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles udtReg.LostFocus
        UnHighlightControl(udtReg)
    End Sub

    Private Sub btnExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExit.Click
        Me.Close()
    End Sub

    'Private Sub txtHomeTel_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtHomeTel.TextChanged
    '    'populateTelDropdown()
    'End Sub

    'Private Sub txtStreet_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtStreet.TextChanged
    '    'populateAddressDropdown()
    'End Sub

    Private Sub txtHomeTel_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtHomeTel.KeyUp
        If txtHomeTel.Text <> "" Then
            setAutoTelAreaCode(txtHomeTel, e)
            populateTelDropdown()
        Else
            ugTitle.DataSource = Nothing
            makeGridVisible(False)
        End If
    End Sub

    Private Sub populateTelDropdown()
        Dim personDAL As TKPC.DAL.PersonDAL = TKPC.DAL.PersonDAL.getInstance()
        Dim searchWords As String = String.Empty
        Dim ds As DataSet = Nothing

        Try
            If txtHomeTel.Text.Trim <> "" Then
                searchWords = txtHomeTel.Text + "%"
                ds = personDAL.getList(PARTIAL_LIST1, searchWords, String.Empty)

                If ds.Tables(0).Rows.Count = 0 Then
                    makeGridVisible(False)
                    ugTitle.DataSource = Nothing
                Else
                    With ugTitle
                        .DataSource = ds.Tables(0)
                        .DisplayLayout.Bands(0).Columns("ID").Hidden = True
                        .DisplayLayout.Bands(0).Columns("직분").Hidden = True
                        .DisplayLayout.Bands(0).Columns("성별").Hidden = True
                        .DisplayLayout.Bands(0).Columns("이메일").Hidden = True
                        .DisplayLayout.Bands(0).Columns("비고").Hidden = True
                        .DisplayLayout.Bands(0).Columns("등록일").Hidden = True
                        .DisplayLayout.Bands(0).Columns("Login ID").Hidden = True
                        .DisplayLayout.Bands(0).Columns("Login PWD").Hidden = True
                        .DisplayLayout.Bands(0).Columns("Login Level").Hidden = True
                        .DisplayLayout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.ResizeAllColumns
                        .Visible = True
                    End With
                End If
            Else
                makeGridVisible(False)
                ugTitle.DataSource = Nothing
            End If

        Catch ex As Exception
            MessageBox.Show("Error at populateTelDropdown() : " + ex.Message())
        Finally
            personDAL = Nothing
            ds = Nothing
        End Try
    End Sub
    Private Sub populateNameDropdown()
        Dim personDAL As TKPC.DAL.PersonDAL = TKPC.DAL.PersonDAL.getInstance()
        Dim searchWords As String = String.Empty
        Dim ds As DataSet = Nothing

        Try
            If txtName.Text.Trim <> "" Then
                searchWords = txtName.Text
                ds = personDAL.getListByName(searchWords, String.Empty)

                If ds.Tables(0).Rows.Count = 0 Then
                    makeGridVisible(False)
                    ugName.DataSource = Nothing
                Else
                    With ugName
                        .DataSource = ds.Tables(0)
                        .DisplayLayout.Bands(0).Columns("ID").Hidden = True
                        .DisplayLayout.Bands(0).Columns("이름").Width = 65
                        .DisplayLayout.Bands(0).Columns("성별").Width = 50
                        .DisplayLayout.Bands(0).Columns("직분").Hidden = False
                        .DisplayLayout.Bands(0).Columns("직분").Width = 60
                        .DisplayLayout.Bands(0).Columns("성별").Hidden = False
                        .DisplayLayout.Bands(0).Columns("집 전화").Width = 100
                        .DisplayLayout.Bands(0).Columns("다른 전화").Width = 100
                        .DisplayLayout.Bands(0).Columns("거리명").Hidden = True
                        .DisplayLayout.Bands(0).Columns("도시명").Hidden = True
                        .DisplayLayout.Bands(0).Columns("우편번호").Hidden = True
                        .DisplayLayout.Bands(0).Columns("이메일").Hidden = True
                        .DisplayLayout.Bands(0).Columns("비고").Hidden = True
                        .DisplayLayout.Bands(0).Columns("등록일").Hidden = True
                        .DisplayLayout.Bands(0).Columns("Login ID").Hidden = True
                        .DisplayLayout.Bands(0).Columns("Login PWD").Hidden = True
                        .DisplayLayout.Bands(0).Columns("Login Level").Hidden = True
                        .DisplayLayout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.ResizeAllColumns
                        .Visible = True
                    End With
                End If
            Else
                makeGridVisible(False)
                ugName.DataSource = Nothing
            End If

        Catch ex As Exception
            MessageBox.Show("Error at populateNameDropdown() : " + ex.Message())
        Finally
            personDAL = Nothing
            ds = Nothing
        End Try
    End Sub
    Private Sub populateCityDropdown()
        Dim personDAL As TKPC.DAL.PersonDAL = TKPC.DAL.PersonDAL.getInstance()
        Dim searchWords As String = String.Empty
        Dim ds As DataSet = Nothing

        Try
            If txtCity.Text.Trim <> "" Then
                searchWords = txtCity.Text + "%"
                ds = personDAL.getCityList(searchWords)

                If ds.Tables(0).Rows.Count = 0 Then
                    makeGridVisible(False)
                    ugCity.DataSource = Nothing
                Else
                    With ugCity
                        .DataSource = ds.Tables(0)
                        .DisplayLayout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.ResizeAllColumns
                        .DisplayLayout.Bands(0).ColHeadersVisible = False
                        .DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.False
                        .Visible = True
                    End With
                End If
            Else
                makeGridVisible(False)
                ugCity.DataSource = Nothing
            End If

        Catch ex As Exception
            MessageBox.Show("Error at populateCityDropdown() : " + ex.Message())
        Finally
            personDAL = Nothing
            ds = Nothing
        End Try
    End Sub
    Private Sub populateRefDropdown(ByVal homeTel As String, ByVal personID As String)
        Dim personDAL As TKPC.DAL.PersonDAL = TKPC.DAL.PersonDAL.getInstance()
        Dim searchWords As String = String.Empty
        Dim ds As DataSet = Nothing

        Try
            'If txtHomeTel.Text.Trim <> "" Then
            searchWords = homeTel
            ds = personDAL.getRefList(searchWords, personID)

            'If ds.Tables(0).Rows.Count = 0 Then
            '    makeGridVisible(False)
            'Else
            With ugRef
                .DataSource = ds.Tables(0)
            End With
            setRefGrid()
            If homeTel = "0" And personID = "0" Then
                emptyDS = ds
            End If
            'End If
            'Else
            '    makeGridVisible(False)
            '    ugRef.DataSource = Nothing
            '    setRefGrid()
            'End If

        Catch ex As Exception
            MessageBox.Show("Error at populateRefDropdown() : " + ex.Message())
        Finally
            personDAL = Nothing
            ds = Nothing
        End Try
    End Sub

    Private Sub pnMain_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles pnMain.Click
        makeGridVisible(False)
    End Sub

    Private Sub ugbTel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ugbTel.Click
        makeGridVisible(False)
    End Sub

    Private Sub ugbAddress_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ugbAddress.Click
        makeGridVisible(False)
    End Sub

    Private Sub tsbtRent_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbtRent.Click
        'whichIME = SwitchIME(hEnLayoutId, KbdEn)
        With frmRentAdd
            .lblPersonID.Text = lblID.Text
            .txtPersonName.Text = txtName.Text
            .viewMode = VIEW_MODE_ADD_NEW
            .fromWhichForm = FROM_PERSON_ADD
            .MdiParent = MDITKPC
            .Activate()
            .Show()
        End With
    End Sub

    Private Sub tsbtHistory_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbtHistory.Click
        'whichIME = SwitchIME(hEnLayoutId, KbdEn)
        'openForm(Me, frmPersonRentHistory)
        makeGridVisible(False)
        With frmPersonRentHistory
            .caption = txtName.Text + " (" + txtHomeTel.Text + ") "
            .personID = lblID.Text
            .ShowDialog()
        End With
    End Sub

    Private Sub cbTitle_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbTitle.GotFocus
        If viewMode = VIEW_MODE_ADD_NEW Then
            makeGridVisible(False)
            'cbTitle.DroppedDown = True
        End If
    End Sub

    Private Sub cbTitle_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cbTitle.KeyDown
        If e.KeyCode = Keys.Tab Then
            rbtMan.Focus()
        End If
    End Sub

    Private Sub txtHomeTel_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtHomeTel.KeyDown
        If e.KeyCode = Keys.Tab Then
            txtOtherTel.Focus()
        ElseIf e.KeyCode = Keys.Down Then
            If ugTitle.Visible = True Then
                ugTitle.Focus()
                ugTitle.Rows(0).Selected = True
            End If
        End If
    End Sub

    Private Sub rbtMan_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles rbtMan.KeyDown
        If e.KeyCode = Keys.Tab Then
            rbtWoman.Focus()
        End If
    End Sub

    Private Sub rbtWoman_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles rbtWoman.KeyDown
        If e.KeyCode = Keys.Tab Then
            txtHomeTel.Focus()
        End If
    End Sub

    Private Sub ugTitle_DoubleClickRow(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinGrid.DoubleClickRowEventArgs) Handles ugTitle.DoubleClickRow
        If txtName.Text <> String.Empty Then
            If ugTitle.ActiveRow IsNot Nothing Then
                txtHomeTel.Text = ugTitle.ActiveRow.Cells(4).Value

                If ugTitle.ActiveRow.Cells(5).Value IsNot DBNull.Value Then
                    txtOtherTel.Text = ugTitle.ActiveRow.Cells(5).Value
                Else
                    txtOtherTel.Text = ""
                End If

                If ugTitle.ActiveRow.Cells(6).Value IsNot DBNull.Value Then
                    txtStreet.Text = ugTitle.ActiveRow.Cells(6).Value
                Else
                    txtStreet.Text = ""
                End If

                If ugTitle.ActiveRow.Cells(7).Value IsNot DBNull.Value Then
                    txtCity.Text = ugTitle.ActiveRow.Cells(7).Value
                Else
                    txtCity.Text = ""
                End If

                If ugTitle.ActiveRow.Cells(8).Value IsNot DBNull.Value Then
                    txtZipCode.Text = ugTitle.ActiveRow.Cells(8).Value
                Else
                    txtZipCode.Text = ""
                End If
                txtOtherTel.Focus()
            End If
        Else
            If ugTitle.ActiveRow IsNot Nothing Then
                viewMode = VIEW_MODE_DETAIL
                fillFieldsFromGrid(ugTitle)
                init()
            End If
        End If
        makeGridVisible(False)
    End Sub

    Private Sub ugTitle_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles ugTitle.KeyDown
        If e.KeyCode = Keys.Enter Then
            If txtName.Text <> String.Empty Then
                If ugTitle.ActiveRow IsNot Nothing Then
                    txtHomeTel.Text = ugTitle.ActiveRow.Cells(4).Value

                    If ugTitle.ActiveRow.Cells(5).Value IsNot DBNull.Value Then
                        txtOtherTel.Text = ugTitle.ActiveRow.Cells(5).Value
                    Else
                        txtOtherTel.Text = ""
                    End If

                    If ugTitle.ActiveRow.Cells(6).Value IsNot DBNull.Value Then
                        txtStreet.Text = ugTitle.ActiveRow.Cells(6).Value
                    Else
                        txtStreet.Text = ""
                    End If

                    If ugTitle.ActiveRow.Cells(7).Value IsNot DBNull.Value Then
                        txtCity.Text = ugTitle.ActiveRow.Cells(7).Value
                    Else
                        txtCity.Text = ""
                    End If

                    If ugTitle.ActiveRow.Cells(8).Value IsNot DBNull.Value Then
                        txtZipCode.Text = ugTitle.ActiveRow.Cells(8).Value
                    Else
                        txtZipCode.Text = ""
                    End If
                    txtOtherTel.Focus()
                End If
            Else
                If ugTitle.ActiveRow IsNot Nothing Then
                    viewMode = VIEW_MODE_DETAIL
                    fillFieldsFromGrid(ugTitle)
                    init()
                End If
            End If
            makeGridVisible(False)
        End If
    End Sub
    Private Sub fillFieldsFromGrid(ByVal grid As Infragistics.Win.UltraWinGrid.UltraGrid)
        personEnt = New TKPC.Entity.PersonEnt

        With grid.ActiveRow
            personEnt.personID = .Cells("ID").Value
            personEnt.name = .Cells("이름").Value
            personEnt.gender = .Cells("성별").Value
            personEnt.personTitle = .Cells("직분").Value
            personEnt.homeTel = .Cells("집 전화").Value

            If .Cells("다른 전화").Value IsNot DBNull.Value Then
                personEnt.otherTel = .Cells("다른 전화").Value
            Else
                personEnt.otherTel = ""
            End If

            If .Cells("거리명").Value IsNot DBNull.Value Then
                personEnt.street = .Cells("거리명").Value
            Else
                personEnt.street = ""
            End If

            If .Cells("도시명").Value IsNot DBNull.Value Then
                personEnt.city = .Cells("도시명").Value
            Else
                personEnt.city = ""
            End If

            If .Cells("우편번호").Value IsNot DBNull.Value Then
                personEnt.zipCode = .Cells("우편번호").Value
            Else
                personEnt.zipCode = ""
            End If

            If .Cells("이메일").Value IsNot DBNull.Value Then
                personEnt.email = .Cells("이메일").Value
            Else
                personEnt.email = ""
            End If

            If .Cells("비고").Value IsNot DBNull.Value Then
                personEnt.note = .Cells("비고").Value
            Else
                personEnt.note = ""
            End If

            If .Cells("등록일").Value IsNot DBNull.Value Then
                personEnt.registrationDate = .Cells("등록일").Value
            Else
                personEnt.registrationDate = ""
            End If

            If .Cells("Login ID").Value IsNot DBNull.Value Then
                personEnt.loginID = .Cells("Login ID").Value
            Else
                personEnt.loginID = ""
            End If

            If .Cells("Login PWD").Value IsNot DBNull.Value Then
                personEnt.loginPassword = .Cells("Login PWD").Value
            Else
                personEnt.loginPassword = ""
            End If

            If .Cells("Login Level").Value IsNot DBNull.Value Then
                personEnt.loginLevel = .Cells("Login Level").Value
            Else
                personEnt.loginLevel = ""
            End If

            setPicture(picPerson, personEnt.personID)
        End With
    End Sub

    Private Sub ugCity_DoubleClickRow(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinGrid.DoubleClickRowEventArgs) Handles ugCity.DoubleClickRow
        If ugCity.ActiveRow IsNot Nothing Then
            txtCity.Text = ugCity.ActiveRow.Cells(0).Value
            txtZipCode.Focus()
        End If
        makeGridVisible(False)
    End Sub

    Private Sub ugCity_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles ugCity.KeyDown
        If e.KeyCode = Keys.Enter Then
            If ugCity.ActiveRow IsNot Nothing Then
                txtCity.Text = ugCity.ActiveRow.Cells(0).Value
                txtZipCode.Focus()
            End If
            makeGridVisible(False)
        End If
    End Sub

    Private Sub ugName_DoubleClickRow(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinGrid.DoubleClickRowEventArgs) Handles ugName.DoubleClickRow
        If ugName.ActiveRow IsNot Nothing Then
            viewMode = VIEW_MODE_DETAIL
            fillFieldsFromGrid(ugName)
            init()
        End If
        makeGridVisible(False)
        cbTitle.Focus()
    End Sub

    Private Sub ugName_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles ugName.KeyDown
        If e.KeyCode = Keys.Enter Then
            If ugName.ActiveRow IsNot Nothing Then
                viewMode = VIEW_MODE_DETAIL
                fillFieldsFromGrid(ugName)
                init()
            End If
            makeGridVisible(False)
            cbTitle.Focus()
        End If
    End Sub

    Private Sub ugRef_CellChange(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinGrid.CellEventArgs) Handles ugRef.CellChange
        Dim headerName As String = e.Cell.Column.Header.Caption
        If headerName = "선택" Then
            If e.Cell.Text <> "" And e.Cell.Text IsNot DBNull.Value Then
                Dim ID As String = ugRef.ActiveRow.Cells("ID").Value
                If e.Cell.Text = True Then
                    If refStorage.ContainsKey(ID) = False Then
                        refStorage.Add(ID, ID)
                    End If
                Else
                    If refStorage.ContainsKey(ID) = True Then
                        refStorage.Remove(ID)
                    End If
                End If
            End If

            If refStorage.Count > 0 Then
                btDrop.Enabled = True
            Else
                btDrop.Enabled = False
            End If
        End If
    End Sub

    Private Sub ugRef_MouseDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles ugRef.MouseDoubleClick
        If ugRef.ActiveRow IsNot Nothing Then
            If ugRef.ActiveCell.Column.Header.Caption <> "선택" Then
                viewMode = VIEW_MODE_DETAIL
                fillFieldsFromGrid(ugRef)
                init()
            End If
        End If
    End Sub

    Private Sub txtName_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtName.TextChanged
        If txtName.Text = String.Empty Then
            tsbtHistory.Enabled = False
        Else
            tsbtHistory.Enabled = True
        End If
    End Sub

    Private Sub tsbtAuthenticate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbtAuthenticate.Click
        makeGridVisible(False)
        With frmLoginAdd
            .lblPersonID.Text = lblID.Text

            If lblLoginLevel.Text <> String.Empty Then
                .cbLevel.SelectedIndex = lblLoginLevel.Text
            Else
                .cbLevel.SelectedIndex = 0
            End If

            If lblLoginID.Text <> String.Empty Then
                .txtID.Text = lblLoginID.Text
            Else
                .txtID.Text = String.Empty
            End If

            If lblLoginPWD.Text <> String.Empty Then
                .txtPWD.Text = CytographyPassword.DecryptText(lblLoginPWD.Text)
                .txtPWD2.Text = CytographyPassword.DecryptText(lblLoginPWD.Text)
            Else
                .txtPWD.Text = String.Empty
            End If

            .ShowDialog()
        End With
    End Sub
    Private Sub lblID_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles lblID.TextChanged
        If viewMode = VIEW_MODE_DETAIL Then
            tsbtReserve.Visible = True
        Else
            tsbtReserve.Visible = False
        End If
    End Sub

    Private Sub tsbtReserve_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbtReserve.Click
        With frmPersonReserve
            .flag = 3
            .personID = lblID.Text
            .personName = txtName.Text
            .ShowDialog()
        End With
    End Sub

    Private Sub ugName_MouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles ugName.MouseClick
        If ugName.ActiveRow IsNot Nothing Then
            viewMode = VIEW_MODE_DETAIL
            fillFieldsFromGrid(ugName)
            init()
        End If
        makeGridVisible(False)
        cbTitle.Focus()
    End Sub

    Private Sub ugName_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles ugName.MouseEnter
        ugName.Focus()
    End Sub

    Private Sub ugTitle_MouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles ugTitle.MouseClick
        If txtName.Text <> String.Empty Then
            If ugTitle.ActiveRow IsNot Nothing Then
                txtHomeTel.Text = ugTitle.ActiveRow.Cells(4).Value

                If ugTitle.ActiveRow.Cells(5).Value IsNot DBNull.Value Then
                    txtOtherTel.Text = ugTitle.ActiveRow.Cells(5).Value
                Else
                    txtOtherTel.Text = ""
                End If

                If ugTitle.ActiveRow.Cells(6).Value IsNot DBNull.Value Then
                    txtStreet.Text = ugTitle.ActiveRow.Cells(6).Value
                Else
                    txtStreet.Text = ""
                End If

                If ugTitle.ActiveRow.Cells(7).Value IsNot DBNull.Value Then
                    txtCity.Text = ugTitle.ActiveRow.Cells(7).Value
                Else
                    txtCity.Text = ""
                End If

                If ugTitle.ActiveRow.Cells(8).Value IsNot DBNull.Value Then
                    txtZipCode.Text = ugTitle.ActiveRow.Cells(8).Value
                Else
                    txtZipCode.Text = ""
                End If
                txtOtherTel.Focus()
            End If
        Else
            If ugTitle.ActiveRow IsNot Nothing Then
                viewMode = VIEW_MODE_DETAIL
                fillFieldsFromGrid(ugTitle)
                init()
            End If
        End If
        makeGridVisible(False)
    End Sub

    Private Sub ugTitle_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles ugTitle.MouseEnter
        ugTitle.Focus()
    End Sub

    Private Sub ugCity_MouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles ugCity.MouseClick
        If ugCity.ActiveRow IsNot Nothing Then
            txtCity.Text = ugCity.ActiveRow.Cells(0).Value
            txtZipCode.Focus()
        End If
        makeGridVisible(False)
    End Sub

    Private Sub ugCity_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles ugCity.MouseEnter
        ugCity.Focus()
    End Sub
End Class
