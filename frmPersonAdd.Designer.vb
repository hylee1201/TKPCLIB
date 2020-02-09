<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmPersonAdd
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmPersonAdd))
        Dim Appearance15 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraGridBand1 As Infragistics.Win.UltraWinGrid.UltraGridBand = New Infragistics.Win.UltraWinGrid.UltraGridBand("Band 0", -1)
        Dim UltraGridColumn1 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("선택")
        Dim UltraGridColumn2 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("ID")
        Dim UltraGridColumn3 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("이름")
        Dim UltraGridColumn4 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("직분")
        Dim UltraGridColumn5 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("성별")
        Dim UltraGridColumn6 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("집 전화")
        Dim UltraGridColumn7 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("다른 전화")
        Dim UltraGridColumn8 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("이메일", -1, Nothing, 0, Infragistics.Win.UltraWinGrid.SortIndicator.Ascending, False)
        Dim UltraGridColumn9 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("비고")
        Dim UltraGridColumn10 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("등록일")
        Dim UltraGridColumn11 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("거리명")
        Dim UltraGridColumn12 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("도시명")
        Dim UltraGridColumn13 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("우편번호")
        Dim Appearance38 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance39 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance40 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance41 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance42 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance44 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance45 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance46 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance47 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance48 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance64 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance65 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance6 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraGridBand2 As Infragistics.Win.UltraWinGrid.UltraGridBand = New Infragistics.Win.UltraWinGrid.UltraGridBand("Band 0", -1)
        Dim UltraGridColumn14 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("ID")
        Dim UltraGridColumn15 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("이름", -1, Nothing, 0, Infragistics.Win.UltraWinGrid.SortIndicator.Ascending, False)
        Dim UltraGridColumn16 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("집 전화")
        Dim UltraGridColumn17 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("다른 전화")
        Dim UltraGridColumn18 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("거리명")
        Dim UltraGridColumn19 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("도시명")
        Dim UltraGridColumn20 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("우편번호")
        Dim UltraGridColumn21 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Login ID")
        Dim UltraGridColumn22 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Login PWD")
        Dim UltraGridColumn23 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Login Level")
        Dim Appearance17 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance18 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance19 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance20 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance21 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance22 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance23 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance24 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance30 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance37 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance43 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance1 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraGridBand3 As Infragistics.Win.UltraWinGrid.UltraGridBand = New Infragistics.Win.UltraWinGrid.UltraGridBand("Band 0", -1)
        Dim UltraGridColumn24 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("ID")
        Dim UltraGridColumn25 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("이름")
        Dim UltraGridColumn26 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("직분")
        Dim UltraGridColumn27 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("성별")
        Dim UltraGridColumn28 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("집 전화")
        Dim UltraGridColumn29 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("다른 전화")
        Dim UltraGridColumn30 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("거리명")
        Dim UltraGridColumn31 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("도시명")
        Dim UltraGridColumn32 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("우편번호")
        Dim UltraGridColumn33 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("이메일")
        Dim UltraGridColumn34 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("비고")
        Dim UltraGridColumn35 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("등록일")
        Dim UltraGridColumn36 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Login ID")
        Dim UltraGridColumn37 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Login PWD")
        Dim UltraGridColumn38 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Login Level")
        Dim Appearance2 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance3 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance4 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance5 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance7 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance8 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance9 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance10 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance11 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance12 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance14 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance25 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraGridBand4 As Infragistics.Win.UltraWinGrid.UltraGridBand = New Infragistics.Win.UltraWinGrid.UltraGridBand("Band 0", -1)
        Dim UltraGridColumn39 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("City Name")
        Dim Appearance26 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance27 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance28 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance29 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance31 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance32 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance33 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance34 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance35 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance16 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance36 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim EditorButton1 As Infragistics.Win.UltraWinEditors.EditorButton = New Infragistics.Win.UltraWinEditors.EditorButton
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip
        Me.tsbtAdd = New System.Windows.Forms.ToolStripButton
        Me.tsbtSave = New System.Windows.Forms.ToolStripButton
        Me.tsbtDelete = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator
        Me.tsbtRent = New System.Windows.Forms.ToolStripButton
        Me.tsbtHistory = New System.Windows.Forms.ToolStripButton
        Me.btnExit = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator
        Me.tsbtReserve = New System.Windows.Forms.ToolStripButton
        Me.tsbtAuthenticate = New System.Windows.Forms.ToolStripButton
        Me.Label10 = New System.Windows.Forms.Label
        Me.rbtMan = New System.Windows.Forms.RadioButton
        Me.rbtWoman = New System.Windows.Forms.RadioButton
        Me.Label9 = New System.Windows.Forms.Label
        Me.txtNote = New System.Windows.Forms.TextBox
        Me.Label8 = New System.Windows.Forms.Label
        Me.txtEmail = New System.Windows.Forms.TextBox
        Me.Label7 = New System.Windows.Forms.Label
        Me.pnMain = New System.Windows.Forms.Panel
        Me.lblLoginLevel = New System.Windows.Forms.Label
        Me.lblLoginPWD = New System.Windows.Forms.Label
        Me.lblLoginID = New System.Windows.Forms.Label
        Me.btDrop = New System.Windows.Forms.Button
        Me.btAdd = New System.Windows.Forms.Button
        Me.Label4 = New System.Windows.Forms.Label
        Me.ugRef = New Infragistics.Win.UltraWinGrid.UltraGrid
        Me.ugTitle = New Infragistics.Win.UltraWinGrid.UltraGrid
        Me.ugName = New Infragistics.Win.UltraWinGrid.UltraGrid
        Me.picPerson = New System.Windows.Forms.PictureBox
        Me.lblIDLabel = New System.Windows.Forms.Label
        Me.ugCity = New Infragistics.Win.UltraWinGrid.UltraGrid
        Me.lblID = New System.Windows.Forms.Label
        Me.udtReg = New Infragistics.Win.UltraWinEditors.UltraDateTimeEditor
        Me.ugbAddress = New Infragistics.Win.Misc.UltraGroupBox
        Me.txtZipCode = New System.Windows.Forms.TextBox
        Me.txtStreet = New System.Windows.Forms.TextBox
        Me.Label14 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label12 = New System.Windows.Forms.Label
        Me.txtCity = New System.Windows.Forms.TextBox
        Me.ugbTel = New Infragistics.Win.Misc.UltraGroupBox
        Me.txtHomeTel = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.txtOtherTel = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label11 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.cbTitle = New System.Windows.Forms.ComboBox
        Me.Panel2 = New System.Windows.Forms.Panel
        Me.txtName = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.ToolStrip1.SuspendLayout()
        Me.pnMain.SuspendLayout()
        CType(Me.ugRef, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ugTitle, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ugName, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picPerson, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ugCity, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.udtReg, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ugbAddress, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ugbAddress.SuspendLayout()
        CType(Me.ugbTel, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ugbTel.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'ToolStrip1
        '
        Me.ToolStrip1.AutoSize = False
        Me.ToolStrip1.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ToolStrip1.ImageScalingSize = New System.Drawing.Size(18, 18)
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsbtAdd, Me.tsbtSave, Me.tsbtDelete, Me.ToolStripSeparator1, Me.tsbtRent, Me.tsbtHistory, Me.btnExit, Me.ToolStripSeparator2, Me.tsbtReserve, Me.tsbtAuthenticate})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(843, 40)
        Me.ToolStrip1.TabIndex = 14
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'tsbtAdd
        '
        Me.tsbtAdd.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tsbtAdd.Image = Global.TKPC.My.Resources.Resources._new
        Me.tsbtAdd.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.tsbtAdd.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbtAdd.Name = "tsbtAdd"
        Me.tsbtAdd.Size = New System.Drawing.Size(79, 37)
        Me.tsbtAdd.Text = "Add &New"
        Me.tsbtAdd.ToolTipText = "새로만들기"
        '
        'tsbtSave
        '
        Me.tsbtSave.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tsbtSave.Image = Global.TKPC.My.Resources.Resources.save
        Me.tsbtSave.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.tsbtSave.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbtSave.Name = "tsbtSave"
        Me.tsbtSave.Size = New System.Drawing.Size(56, 37)
        Me.tsbtSave.Text = "&Save"
        '
        'tsbtDelete
        '
        Me.tsbtDelete.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tsbtDelete.Image = Global.TKPC.My.Resources.Resources.delete2
        Me.tsbtDelete.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.tsbtDelete.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbtDelete.Name = "tsbtDelete"
        Me.tsbtDelete.Size = New System.Drawing.Size(65, 37)
        Me.tsbtDelete.Text = "&Delete"
        Me.tsbtDelete.Visible = False
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 40)
        '
        'tsbtRent
        '
        Me.tsbtRent.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tsbtRent.Image = Global.TKPC.My.Resources.Resources.rent
        Me.tsbtRent.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.tsbtRent.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbtRent.Name = "tsbtRent"
        Me.tsbtRent.Size = New System.Drawing.Size(57, 37)
        Me.tsbtRent.Text = "&Rent"
        '
        'tsbtHistory
        '
        Me.tsbtHistory.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tsbtHistory.Image = Global.TKPC.My.Resources.Resources.list
        Me.tsbtHistory.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.tsbtHistory.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbtHistory.Name = "tsbtHistory"
        Me.tsbtHistory.Size = New System.Drawing.Size(73, 37)
        Me.tsbtHistory.Text = "&History"
        '
        'btnExit
        '
        Me.btnExit.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.btnExit.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnExit.Image = CType(resources.GetObject("btnExit.Image"), System.Drawing.Image)
        Me.btnExit.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnExit.Name = "btnExit"
        Me.btnExit.Size = New System.Drawing.Size(52, 37)
        Me.btnExit.Text = "Exit"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 40)
        '
        'tsbtReserve
        '
        Me.tsbtReserve.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tsbtReserve.Image = Global.TKPC.My.Resources.Resources.reserve
        Me.tsbtReserve.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.tsbtReserve.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbtReserve.Name = "tsbtReserve"
        Me.tsbtReserve.Size = New System.Drawing.Size(76, 37)
        Me.tsbtReserve.Text = "Reserve"
        Me.tsbtReserve.Visible = False
        '
        'tsbtAuthenticate
        '
        Me.tsbtAuthenticate.Enabled = False
        Me.tsbtAuthenticate.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tsbtAuthenticate.Image = Global.TKPC.My.Resources.Resources.tool2
        Me.tsbtAuthenticate.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.tsbtAuthenticate.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbtAuthenticate.Name = "tsbtAuthenticate"
        Me.tsbtAuthenticate.Size = New System.Drawing.Size(109, 37)
        Me.tsbtAuthenticate.Text = "&Authenticate"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Dotum", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(103, 455)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(40, 13)
        Me.Label10.TabIndex = 19
        Me.Label10.Text = "비고:"
        '
        'rbtMan
        '
        Me.rbtMan.AutoSize = True
        Me.rbtMan.Checked = True
        Me.rbtMan.Font = New System.Drawing.Font("Dotum", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbtMan.Location = New System.Drawing.Point(3, 5)
        Me.rbtMan.Name = "rbtMan"
        Me.rbtMan.Size = New System.Drawing.Size(39, 17)
        Me.rbtMan.TabIndex = 0
        Me.rbtMan.TabStop = True
        Me.rbtMan.Text = "남"
        Me.rbtMan.UseVisualStyleBackColor = True
        '
        'rbtWoman
        '
        Me.rbtWoman.AutoSize = True
        Me.rbtWoman.Font = New System.Drawing.Font("Dotum", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbtWoman.Location = New System.Drawing.Point(62, 5)
        Me.rbtWoman.Name = "rbtWoman"
        Me.rbtWoman.Size = New System.Drawing.Size(39, 17)
        Me.rbtWoman.TabIndex = 1
        Me.rbtWoman.Text = "여"
        Me.rbtWoman.UseVisualStyleBackColor = True
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Dotum", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(61, 416)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(82, 13)
        Me.Label9.TabIndex = 18
        Me.Label9.Text = "회원등록일:"
        '
        'txtNote
        '
        Me.txtNote.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNote.ImeMode = System.Windows.Forms.ImeMode.Hangul
        Me.txtNote.Location = New System.Drawing.Point(153, 451)
        Me.txtNote.MaxLength = 1000
        Me.txtNote.Multiline = True
        Me.txtNote.Name = "txtNote"
        Me.txtNote.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.txtNote.Size = New System.Drawing.Size(306, 68)
        Me.txtNote.TabIndex = 10
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(312, 415)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(106, 16)
        Me.Label8.TabIndex = 17
        Me.Label8.Text = "(mm/dd/yyyy)"
        '
        'txtEmail
        '
        Me.txtEmail.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtEmail.ImeMode = System.Windows.Forms.ImeMode.Alpha
        Me.txtEmail.Location = New System.Drawing.Point(152, 375)
        Me.txtEmail.MaxLength = 150
        Me.txtEmail.Name = "txtEmail"
        Me.txtEmail.Size = New System.Drawing.Size(306, 23)
        Me.txtEmail.TabIndex = 8
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Dotum", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(89, 380)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(54, 13)
        Me.Label7.TabIndex = 14
        Me.Label7.Text = "이메일:"
        '
        'pnMain
        '
        Me.pnMain.Controls.Add(Me.lblLoginLevel)
        Me.pnMain.Controls.Add(Me.lblLoginPWD)
        Me.pnMain.Controls.Add(Me.lblLoginID)
        Me.pnMain.Controls.Add(Me.btDrop)
        Me.pnMain.Controls.Add(Me.btAdd)
        Me.pnMain.Controls.Add(Me.Label4)
        Me.pnMain.Controls.Add(Me.ugRef)
        Me.pnMain.Controls.Add(Me.ugTitle)
        Me.pnMain.Controls.Add(Me.ugName)
        Me.pnMain.Controls.Add(Me.picPerson)
        Me.pnMain.Controls.Add(Me.lblIDLabel)
        Me.pnMain.Controls.Add(Me.ugCity)
        Me.pnMain.Controls.Add(Me.lblID)
        Me.pnMain.Controls.Add(Me.udtReg)
        Me.pnMain.Controls.Add(Me.ugbAddress)
        Me.pnMain.Controls.Add(Me.ugbTel)
        Me.pnMain.Controls.Add(Me.Label11)
        Me.pnMain.Controls.Add(Me.Label5)
        Me.pnMain.Controls.Add(Me.cbTitle)
        Me.pnMain.Controls.Add(Me.txtNote)
        Me.pnMain.Controls.Add(Me.Label10)
        Me.pnMain.Controls.Add(Me.Label9)
        Me.pnMain.Controls.Add(Me.Label8)
        Me.pnMain.Controls.Add(Me.txtEmail)
        Me.pnMain.Controls.Add(Me.Label7)
        Me.pnMain.Controls.Add(Me.Panel2)
        Me.pnMain.Controls.Add(Me.txtName)
        Me.pnMain.Controls.Add(Me.Label1)
        Me.pnMain.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnMain.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.pnMain.Location = New System.Drawing.Point(0, 0)
        Me.pnMain.Name = "pnMain"
        Me.pnMain.Size = New System.Drawing.Size(843, 661)
        Me.pnMain.TabIndex = 15
        '
        'lblLoginLevel
        '
        Me.lblLoginLevel.AutoSize = True
        Me.lblLoginLevel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblLoginLevel.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblLoginLevel.Location = New System.Drawing.Point(446, 68)
        Me.lblLoginLevel.Name = "lblLoginLevel"
        Me.lblLoginLevel.Size = New System.Drawing.Size(26, 20)
        Me.lblLoginLevel.TabIndex = 41
        Me.lblLoginLevel.Text = "ID"
        Me.lblLoginLevel.Visible = False
        '
        'lblLoginPWD
        '
        Me.lblLoginPWD.AutoSize = True
        Me.lblLoginPWD.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblLoginPWD.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblLoginPWD.Location = New System.Drawing.Point(382, 68)
        Me.lblLoginPWD.Name = "lblLoginPWD"
        Me.lblLoginPWD.Size = New System.Drawing.Size(26, 20)
        Me.lblLoginPWD.TabIndex = 40
        Me.lblLoginPWD.Text = "ID"
        Me.lblLoginPWD.Visible = False
        '
        'lblLoginID
        '
        Me.lblLoginID.AutoSize = True
        Me.lblLoginID.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblLoginID.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblLoginID.Location = New System.Drawing.Point(315, 68)
        Me.lblLoginID.Name = "lblLoginID"
        Me.lblLoginID.Size = New System.Drawing.Size(26, 20)
        Me.lblLoginID.TabIndex = 39
        Me.lblLoginID.Text = "ID"
        Me.lblLoginID.Visible = False
        '
        'btDrop
        '
        Me.btDrop.Enabled = False
        Me.btDrop.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btDrop.Image = Global.TKPC.My.Resources.Resources.delete2
        Me.btDrop.Location = New System.Drawing.Point(636, 504)
        Me.btDrop.Name = "btDrop"
        Me.btDrop.Size = New System.Drawing.Size(60, 23)
        Me.btDrop.TabIndex = 38
        Me.btDrop.Text = "Drop"
        Me.btDrop.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btDrop.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btDrop.UseVisualStyleBackColor = True
        '
        'btAdd
        '
        Me.btAdd.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btAdd.Image = Global.TKPC.My.Resources.Resources._new
        Me.btAdd.Location = New System.Drawing.Point(570, 504)
        Me.btAdd.Name = "btAdd"
        Me.btAdd.Size = New System.Drawing.Size(60, 23)
        Me.btAdd.TabIndex = 37
        Me.btAdd.Text = "Add"
        Me.btAdd.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btAdd.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btAdd.UseVisualStyleBackColor = True
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Dotum", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(88, 535)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(54, 13)
        Me.Label4.TabIndex = 36
        Me.Label4.Text = "참고인:"
        '
        'ugRef
        '
        Appearance15.BackColor = System.Drawing.SystemColors.Window
        Appearance15.BorderColor = System.Drawing.SystemColors.Highlight
        Me.ugRef.DisplayLayout.Appearance = Appearance15
        Me.ugRef.DisplayLayout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.ResizeAllColumns
        UltraGridColumn1.Header.VisiblePosition = 0
        UltraGridColumn1.Width = 68
        UltraGridColumn2.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
        UltraGridColumn2.Header.VisiblePosition = 1
        UltraGridColumn2.Width = 80
        UltraGridColumn3.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
        UltraGridColumn3.Header.VisiblePosition = 2
        UltraGridColumn3.Width = 14
        UltraGridColumn4.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
        UltraGridColumn4.Header.VisiblePosition = 3
        UltraGridColumn4.Width = 31
        UltraGridColumn5.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
        UltraGridColumn5.Header.VisiblePosition = 4
        UltraGridColumn5.Width = 23
        UltraGridColumn6.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
        UltraGridColumn6.Header.VisiblePosition = 5
        UltraGridColumn6.Width = 42
        UltraGridColumn7.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
        UltraGridColumn7.Header.VisiblePosition = 6
        UltraGridColumn7.Width = 42
        UltraGridColumn8.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
        UltraGridColumn8.Header.VisiblePosition = 7
        UltraGridColumn8.Width = 24
        UltraGridColumn9.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
        UltraGridColumn9.Header.VisiblePosition = 8
        UltraGridColumn9.Width = 24
        UltraGridColumn10.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
        UltraGridColumn10.Header.VisiblePosition = 9
        UltraGridColumn10.Width = 24
        UltraGridColumn11.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
        UltraGridColumn11.Header.VisiblePosition = 10
        UltraGridColumn11.Width = 50
        UltraGridColumn12.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
        UltraGridColumn12.Header.VisiblePosition = 11
        UltraGridColumn12.Width = 50
        UltraGridColumn13.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
        UltraGridColumn13.Header.VisiblePosition = 12
        UltraGridColumn13.Width = 50
        UltraGridBand1.Columns.AddRange(New Object() {UltraGridColumn1, UltraGridColumn2, UltraGridColumn3, UltraGridColumn4, UltraGridColumn5, UltraGridColumn6, UltraGridColumn7, UltraGridColumn8, UltraGridColumn9, UltraGridColumn10, UltraGridColumn11, UltraGridColumn12, UltraGridColumn13})
        Appearance38.TextVAlignAsString = "Middle"
        UltraGridBand1.Override.RowAppearance = Appearance38
        Me.ugRef.DisplayLayout.BandsSerializer.Add(UltraGridBand1)
        Me.ugRef.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Me.ugRef.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.[False]
        Appearance39.BackColor = System.Drawing.SystemColors.ActiveBorder
        Appearance39.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance39.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Appearance39.BorderColor = System.Drawing.SystemColors.Window
        Me.ugRef.DisplayLayout.GroupByBox.Appearance = Appearance39
        Appearance40.ForeColor = System.Drawing.SystemColors.GrayText
        Me.ugRef.DisplayLayout.GroupByBox.BandLabelAppearance = Appearance40
        Me.ugRef.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Appearance41.BackColor = System.Drawing.SystemColors.ControlLightLight
        Appearance41.BackColor2 = System.Drawing.SystemColors.Control
        Appearance41.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance41.ForeColor = System.Drawing.SystemColors.GrayText
        Me.ugRef.DisplayLayout.GroupByBox.PromptAppearance = Appearance41
        Me.ugRef.DisplayLayout.MaxColScrollRegions = 1
        Me.ugRef.DisplayLayout.MaxRowScrollRegions = 1
        Appearance42.BackColor = System.Drawing.SystemColors.Window
        Appearance42.ForeColor = System.Drawing.SystemColors.ControlText
        Me.ugRef.DisplayLayout.Override.ActiveCellAppearance = Appearance42
        Appearance44.BackColor = System.Drawing.SystemColors.Highlight
        Appearance44.ForeColor = System.Drawing.SystemColors.HighlightText
        Me.ugRef.DisplayLayout.Override.ActiveRowAppearance = Appearance44
        Me.ugRef.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Dotted
        Me.ugRef.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Dotted
        Appearance45.BackColor = System.Drawing.SystemColors.Window
        Me.ugRef.DisplayLayout.Override.CardAreaAppearance = Appearance45
        Appearance46.BorderColor = System.Drawing.Color.Silver
        Appearance46.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter
        Me.ugRef.DisplayLayout.Override.CellAppearance = Appearance46
        Me.ugRef.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText
        Me.ugRef.DisplayLayout.Override.CellPadding = 0
        Appearance47.BackColor = System.Drawing.SystemColors.Control
        Appearance47.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance47.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element
        Appearance47.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance47.BorderColor = System.Drawing.SystemColors.Window
        Me.ugRef.DisplayLayout.Override.GroupByRowAppearance = Appearance47
        Appearance48.TextHAlignAsString = "Left"
        Me.ugRef.DisplayLayout.Override.HeaderAppearance = Appearance48
        Me.ugRef.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti
        Me.ugRef.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.WindowsXPCommand
        Appearance64.BackColor = System.Drawing.SystemColors.Window
        Appearance64.BorderColor = System.Drawing.Color.Silver
        Me.ugRef.DisplayLayout.Override.RowAppearance = Appearance64
        Me.ugRef.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.[False]
        Me.ugRef.DisplayLayout.Override.SelectTypeRow = Infragistics.Win.UltraWinGrid.SelectType.Extended
        Appearance65.BackColor = System.Drawing.SystemColors.ControlLight
        Me.ugRef.DisplayLayout.Override.TemplateAddRowAppearance = Appearance65
        Me.ugRef.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill
        Me.ugRef.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate
        Me.ugRef.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ugRef.Location = New System.Drawing.Point(155, 533)
        Me.ugRef.Name = "ugRef"
        Me.ugRef.RowUpdateCancelAction = Infragistics.Win.UltraWinGrid.RowUpdateCancelAction.RetainDataAndActivation
        Me.ugRef.Size = New System.Drawing.Size(541, 100)
        Me.ugRef.TabIndex = 35
        Me.ugRef.Text = "UltraGrid1"
        Me.ugRef.UpdateMode = Infragistics.Win.UltraWinGrid.UpdateMode.OnCellChange
        '
        'ugTitle
        '
        Appearance6.BackColor = System.Drawing.SystemColors.Window
        Appearance6.BorderColor = System.Drawing.SystemColors.Highlight
        Me.ugTitle.DisplayLayout.Appearance = Appearance6
        Me.ugTitle.DisplayLayout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.ResizeAllColumns
        UltraGridColumn14.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
        UltraGridColumn14.Header.VisiblePosition = 0
        UltraGridColumn14.Width = 14
        UltraGridColumn15.Header.VisiblePosition = 1
        UltraGridColumn15.Width = 44
        UltraGridColumn16.Header.VisiblePosition = 2
        UltraGridColumn16.Width = 87
        UltraGridColumn17.Header.VisiblePosition = 3
        UltraGridColumn17.Width = 69
        UltraGridColumn18.Header.VisiblePosition = 4
        UltraGridColumn18.Width = 69
        UltraGridColumn19.Header.VisiblePosition = 5
        UltraGridColumn19.Width = 69
        UltraGridColumn20.Header.VisiblePosition = 6
        UltraGridColumn20.Width = 69
        UltraGridColumn21.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
        UltraGridColumn21.Header.VisiblePosition = 7
        UltraGridColumn21.Width = 42
        UltraGridColumn22.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
        UltraGridColumn22.Header.VisiblePosition = 8
        UltraGridColumn22.Width = 45
        UltraGridColumn23.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
        UltraGridColumn23.Header.VisiblePosition = 9
        UltraGridColumn23.Width = 46
        UltraGridBand2.Columns.AddRange(New Object() {UltraGridColumn14, UltraGridColumn15, UltraGridColumn16, UltraGridColumn17, UltraGridColumn18, UltraGridColumn19, UltraGridColumn20, UltraGridColumn21, UltraGridColumn22, UltraGridColumn23})
        Me.ugTitle.DisplayLayout.BandsSerializer.Add(UltraGridBand2)
        Me.ugTitle.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Me.ugTitle.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.[False]
        Appearance17.BackColor = System.Drawing.SystemColors.ActiveBorder
        Appearance17.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance17.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Appearance17.BorderColor = System.Drawing.SystemColors.Window
        Me.ugTitle.DisplayLayout.GroupByBox.Appearance = Appearance17
        Appearance18.ForeColor = System.Drawing.SystemColors.GrayText
        Me.ugTitle.DisplayLayout.GroupByBox.BandLabelAppearance = Appearance18
        Me.ugTitle.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Appearance19.BackColor = System.Drawing.SystemColors.ControlLightLight
        Appearance19.BackColor2 = System.Drawing.SystemColors.Control
        Appearance19.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance19.ForeColor = System.Drawing.SystemColors.GrayText
        Me.ugTitle.DisplayLayout.GroupByBox.PromptAppearance = Appearance19
        Me.ugTitle.DisplayLayout.MaxColScrollRegions = 1
        Me.ugTitle.DisplayLayout.MaxRowScrollRegions = 1
        Appearance20.BackColor = System.Drawing.SystemColors.Window
        Appearance20.ForeColor = System.Drawing.SystemColors.ControlText
        Me.ugTitle.DisplayLayout.Override.ActiveCellAppearance = Appearance20
        Me.ugTitle.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Dotted
        Me.ugTitle.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Dotted
        Appearance21.BackColor = System.Drawing.SystemColors.Window
        Me.ugTitle.DisplayLayout.Override.CardAreaAppearance = Appearance21
        Appearance22.BorderColor = System.Drawing.Color.Silver
        Appearance22.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter
        Me.ugTitle.DisplayLayout.Override.CellAppearance = Appearance22
        Me.ugTitle.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText
        Me.ugTitle.DisplayLayout.Override.CellPadding = 0
        Appearance23.BackColor = System.Drawing.SystemColors.Control
        Appearance23.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance23.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element
        Appearance23.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance23.BorderColor = System.Drawing.SystemColors.Window
        Me.ugTitle.DisplayLayout.Override.GroupByRowAppearance = Appearance23
        Appearance24.TextHAlignAsString = "Left"
        Me.ugTitle.DisplayLayout.Override.HeaderAppearance = Appearance24
        Me.ugTitle.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti
        Me.ugTitle.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.WindowsXPCommand
        Appearance30.BackColor = System.Drawing.SystemColors.Window
        Appearance30.BorderColor = System.Drawing.Color.Silver
        Me.ugTitle.DisplayLayout.Override.RowAppearance = Appearance30
        Me.ugTitle.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.[False]
        Appearance37.BackColor = System.Drawing.SystemColors.Highlight
        Appearance37.ForeColor = System.Drawing.Color.White
        Me.ugTitle.DisplayLayout.Override.SelectedRowAppearance = Appearance37
        Me.ugTitle.DisplayLayout.Override.SelectTypeRow = Infragistics.Win.UltraWinGrid.SelectType.Extended
        Appearance43.BackColor = System.Drawing.SystemColors.ControlLight
        Me.ugTitle.DisplayLayout.Override.TemplateAddRowAppearance = Appearance43
        Me.ugTitle.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill
        Me.ugTitle.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate
        Me.ugTitle.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ugTitle.Location = New System.Drawing.Point(150, 235)
        Me.ugTitle.Name = "ugTitle"
        Me.ugTitle.Size = New System.Drawing.Size(556, 163)
        Me.ugTitle.TabIndex = 31
        Me.ugTitle.Text = "UltraGrid1"
        Me.ugTitle.Visible = False
        '
        'ugName
        '
        Appearance1.BackColor = System.Drawing.SystemColors.Window
        Appearance1.BorderColor = System.Drawing.SystemColors.Highlight
        Me.ugName.DisplayLayout.Appearance = Appearance1
        Me.ugName.DisplayLayout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.ResizeAllColumns
        UltraGridColumn24.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
        UltraGridColumn24.Header.VisiblePosition = 0
        UltraGridColumn24.Width = 14
        UltraGridColumn25.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
        UltraGridColumn25.Header.VisiblePosition = 1
        UltraGridColumn25.Width = 14
        UltraGridColumn26.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
        UltraGridColumn26.Header.VisiblePosition = 2
        UltraGridColumn26.Width = 19
        UltraGridColumn27.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
        UltraGridColumn27.Header.VisiblePosition = 3
        UltraGridColumn27.Width = 107
        UltraGridColumn28.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
        UltraGridColumn28.Header.VisiblePosition = 4
        UltraGridColumn28.Width = 21
        UltraGridColumn29.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
        UltraGridColumn29.Header.VisiblePosition = 5
        UltraGridColumn29.Width = 24
        UltraGridColumn30.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
        UltraGridColumn30.Header.VisiblePosition = 6
        UltraGridColumn30.Width = 27
        UltraGridColumn31.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
        UltraGridColumn31.Header.VisiblePosition = 7
        UltraGridColumn31.Width = 17
        UltraGridColumn32.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
        UltraGridColumn32.Header.VisiblePosition = 8
        UltraGridColumn32.Width = 20
        UltraGridColumn33.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
        UltraGridColumn33.Header.VisiblePosition = 9
        UltraGridColumn33.Width = 20
        UltraGridColumn34.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
        UltraGridColumn34.Header.VisiblePosition = 10
        UltraGridColumn34.Width = 45
        UltraGridColumn35.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
        UltraGridColumn35.Header.VisiblePosition = 11
        UltraGridColumn35.Width = 22
        UltraGridColumn36.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
        UltraGridColumn36.Header.VisiblePosition = 12
        UltraGridColumn36.Width = 67
        UltraGridColumn37.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
        UltraGridColumn37.Header.VisiblePosition = 13
        UltraGridColumn37.Width = 67
        UltraGridColumn38.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
        UltraGridColumn38.Header.VisiblePosition = 14
        UltraGridColumn38.Width = 70
        UltraGridBand3.Columns.AddRange(New Object() {UltraGridColumn24, UltraGridColumn25, UltraGridColumn26, UltraGridColumn27, UltraGridColumn28, UltraGridColumn29, UltraGridColumn30, UltraGridColumn31, UltraGridColumn32, UltraGridColumn33, UltraGridColumn34, UltraGridColumn35, UltraGridColumn36, UltraGridColumn37, UltraGridColumn38})
        Me.ugName.DisplayLayout.BandsSerializer.Add(UltraGridBand3)
        Me.ugName.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Me.ugName.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.[False]
        Appearance2.BackColor = System.Drawing.SystemColors.ActiveBorder
        Appearance2.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance2.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Appearance2.BorderColor = System.Drawing.SystemColors.Window
        Me.ugName.DisplayLayout.GroupByBox.Appearance = Appearance2
        Appearance3.ForeColor = System.Drawing.SystemColors.GrayText
        Me.ugName.DisplayLayout.GroupByBox.BandLabelAppearance = Appearance3
        Me.ugName.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Appearance4.BackColor = System.Drawing.SystemColors.ControlLightLight
        Appearance4.BackColor2 = System.Drawing.SystemColors.Control
        Appearance4.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance4.ForeColor = System.Drawing.SystemColors.GrayText
        Me.ugName.DisplayLayout.GroupByBox.PromptAppearance = Appearance4
        Me.ugName.DisplayLayout.MaxColScrollRegions = 1
        Me.ugName.DisplayLayout.MaxRowScrollRegions = 1
        Appearance5.BackColor = System.Drawing.SystemColors.Window
        Appearance5.ForeColor = System.Drawing.SystemColors.ControlText
        Me.ugName.DisplayLayout.Override.ActiveCellAppearance = Appearance5
        Me.ugName.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Dotted
        Me.ugName.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Dotted
        Appearance7.BackColor = System.Drawing.SystemColors.Window
        Me.ugName.DisplayLayout.Override.CardAreaAppearance = Appearance7
        Appearance8.BorderColor = System.Drawing.Color.Silver
        Appearance8.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter
        Me.ugName.DisplayLayout.Override.CellAppearance = Appearance8
        Me.ugName.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText
        Me.ugName.DisplayLayout.Override.CellPadding = 0
        Appearance9.BackColor = System.Drawing.SystemColors.Control
        Appearance9.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance9.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element
        Appearance9.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance9.BorderColor = System.Drawing.SystemColors.Window
        Me.ugName.DisplayLayout.Override.GroupByRowAppearance = Appearance9
        Appearance10.TextHAlignAsString = "Left"
        Me.ugName.DisplayLayout.Override.HeaderAppearance = Appearance10
        Me.ugName.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti
        Me.ugName.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.WindowsXPCommand
        Appearance11.BackColor = System.Drawing.SystemColors.Window
        Appearance11.BorderColor = System.Drawing.Color.Silver
        Me.ugName.DisplayLayout.Override.RowAppearance = Appearance11
        Me.ugName.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.[False]
        Appearance12.BackColor = System.Drawing.SystemColors.Highlight
        Appearance12.ForeColor = System.Drawing.Color.White
        Me.ugName.DisplayLayout.Override.SelectedRowAppearance = Appearance12
        Me.ugName.DisplayLayout.Override.SelectTypeRow = Infragistics.Win.UltraWinGrid.SelectType.Extended
        Appearance14.BackColor = System.Drawing.SystemColors.ControlLight
        Me.ugName.DisplayLayout.Override.TemplateAddRowAppearance = Appearance14
        Me.ugName.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill
        Me.ugName.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate
        Me.ugName.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ugName.ImeMode = System.Windows.Forms.ImeMode.Hangul
        Me.ugName.Location = New System.Drawing.Point(150, 134)
        Me.ugName.Name = "ugName"
        Me.ugName.Size = New System.Drawing.Size(556, 124)
        Me.ugName.TabIndex = 32
        Me.ugName.Text = "UltraGrid1"
        Me.ugName.Visible = False
        '
        'picPerson
        '
        Me.picPerson.Location = New System.Drawing.Point(519, 112)
        Me.picPerson.Name = "picPerson"
        Me.picPerson.Size = New System.Drawing.Size(264, 285)
        Me.picPerson.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.picPerson.TabIndex = 34
        Me.picPerson.TabStop = False
        '
        'lblIDLabel
        '
        Me.lblIDLabel.AutoSize = True
        Me.lblIDLabel.Font = New System.Drawing.Font("Dotum", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblIDLabel.Location = New System.Drawing.Point(75, 75)
        Me.lblIDLabel.Name = "lblIDLabel"
        Me.lblIDLabel.Size = New System.Drawing.Size(68, 13)
        Me.lblIDLabel.TabIndex = 33
        Me.lblIDLabel.Text = "회원번호:"
        '
        'ugCity
        '
        Appearance25.BackColor = System.Drawing.SystemColors.Window
        Appearance25.BorderColor = System.Drawing.SystemColors.Highlight
        Me.ugCity.DisplayLayout.Appearance = Appearance25
        UltraGridColumn39.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
        UltraGridColumn39.Header.VisiblePosition = 0
        UltraGridBand4.Columns.AddRange(New Object() {UltraGridColumn39})
        Me.ugCity.DisplayLayout.BandsSerializer.Add(UltraGridBand4)
        Me.ugCity.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Me.ugCity.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.[False]
        Appearance26.BackColor = System.Drawing.SystemColors.ActiveBorder
        Appearance26.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance26.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Appearance26.BorderColor = System.Drawing.SystemColors.Window
        Me.ugCity.DisplayLayout.GroupByBox.Appearance = Appearance26
        Appearance27.ForeColor = System.Drawing.SystemColors.GrayText
        Me.ugCity.DisplayLayout.GroupByBox.BandLabelAppearance = Appearance27
        Me.ugCity.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Appearance28.BackColor = System.Drawing.SystemColors.ControlLightLight
        Appearance28.BackColor2 = System.Drawing.SystemColors.Control
        Appearance28.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance28.ForeColor = System.Drawing.SystemColors.GrayText
        Me.ugCity.DisplayLayout.GroupByBox.PromptAppearance = Appearance28
        Me.ugCity.DisplayLayout.MaxColScrollRegions = 1
        Me.ugCity.DisplayLayout.MaxRowScrollRegions = 1
        Appearance29.BackColor = System.Drawing.SystemColors.Window
        Appearance29.ForeColor = System.Drawing.SystemColors.ControlText
        Me.ugCity.DisplayLayout.Override.ActiveCellAppearance = Appearance29
        Me.ugCity.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Dotted
        Me.ugCity.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Dotted
        Appearance31.BackColor = System.Drawing.SystemColors.Window
        Me.ugCity.DisplayLayout.Override.CardAreaAppearance = Appearance31
        Appearance32.BorderColor = System.Drawing.Color.Silver
        Appearance32.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter
        Me.ugCity.DisplayLayout.Override.CellAppearance = Appearance32
        Me.ugCity.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText
        Me.ugCity.DisplayLayout.Override.CellPadding = 0
        Appearance33.BackColor = System.Drawing.SystemColors.Control
        Appearance33.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance33.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element
        Appearance33.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance33.BorderColor = System.Drawing.SystemColors.Window
        Me.ugCity.DisplayLayout.Override.GroupByRowAppearance = Appearance33
        Appearance34.TextHAlignAsString = "Left"
        Me.ugCity.DisplayLayout.Override.HeaderAppearance = Appearance34
        Me.ugCity.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti
        Me.ugCity.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.WindowsXPCommand
        Appearance35.BackColor = System.Drawing.SystemColors.Window
        Appearance35.BorderColor = System.Drawing.Color.Silver
        Me.ugCity.DisplayLayout.Override.RowAppearance = Appearance35
        Me.ugCity.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.[False]
        Appearance16.BackColor = System.Drawing.SystemColors.Highlight
        Appearance16.ForeColor = System.Drawing.Color.White
        Me.ugCity.DisplayLayout.Override.SelectedRowAppearance = Appearance16
        Appearance36.BackColor = System.Drawing.SystemColors.ControlLight
        Me.ugCity.DisplayLayout.Override.TemplateAddRowAppearance = Appearance36
        Me.ugCity.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill
        Me.ugCity.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate
        Me.ugCity.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ugCity.Location = New System.Drawing.Point(153, 346)
        Me.ugCity.Name = "ugCity"
        Me.ugCity.Size = New System.Drawing.Size(139, 62)
        Me.ugCity.TabIndex = 30
        Me.ugCity.Visible = False
        '
        'lblID
        '
        Me.lblID.AutoSize = True
        Me.lblID.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblID.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblID.Location = New System.Drawing.Point(150, 73)
        Me.lblID.Name = "lblID"
        Me.lblID.Size = New System.Drawing.Size(26, 20)
        Me.lblID.TabIndex = 29
        Me.lblID.Text = "ID"
        '
        'udtReg
        '
        EditorButton1.Text = "clear"
        Me.udtReg.ButtonsRight.Add(EditorButton1)
        Me.udtReg.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.udtReg.Location = New System.Drawing.Point(153, 412)
        Me.udtReg.MaskInput = "{LOC}mm/dd/yyyy"
        Me.udtReg.Name = "udtReg"
        Me.udtReg.Size = New System.Drawing.Size(156, 25)
        Me.udtReg.TabIndex = 9
        '
        'ugbAddress
        '
        Me.ugbAddress.Controls.Add(Me.txtZipCode)
        Me.ugbAddress.Controls.Add(Me.txtStreet)
        Me.ugbAddress.Controls.Add(Me.Label14)
        Me.ugbAddress.Controls.Add(Me.Label6)
        Me.ugbAddress.Controls.Add(Me.Label12)
        Me.ugbAddress.Controls.Add(Me.txtCity)
        Me.ugbAddress.Font = New System.Drawing.Font("Dotum", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ugbAddress.Location = New System.Drawing.Point(69, 260)
        Me.ugbAddress.Name = "ugbAddress"
        Me.ugbAddress.Size = New System.Drawing.Size(422, 102)
        Me.ugbAddress.TabIndex = 4
        Me.ugbAddress.Text = "주소"
        '
        'txtZipCode
        '
        Me.txtZipCode.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtZipCode.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtZipCode.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.txtZipCode.Location = New System.Drawing.Point(316, 62)
        Me.txtZipCode.MaxLength = 7
        Me.txtZipCode.Name = "txtZipCode"
        Me.txtZipCode.Size = New System.Drawing.Size(74, 23)
        Me.txtZipCode.TabIndex = 7
        '
        'txtStreet
        '
        Me.txtStreet.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtStreet.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.txtStreet.Location = New System.Drawing.Point(83, 26)
        Me.txtStreet.MaxLength = 150
        Me.txtStreet.Name = "txtStreet"
        Me.txtStreet.Size = New System.Drawing.Size(307, 23)
        Me.txtStreet.TabIndex = 5
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.Location = New System.Drawing.Point(246, 65)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(67, 16)
        Me.Label14.TabIndex = 26
        Me.Label14.Text = "Zip Code:"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(21, 30)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(55, 16)
        Me.Label6.TabIndex = 11
        Me.Label6.Text = "Street:"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(39, 65)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(38, 16)
        Me.Label12.TabIndex = 24
        Me.Label12.Text = "City:"
        '
        'txtCity
        '
        Me.txtCity.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCity.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.txtCity.Location = New System.Drawing.Point(83, 62)
        Me.txtCity.MaxLength = 50
        Me.txtCity.Name = "txtCity"
        Me.txtCity.Size = New System.Drawing.Size(140, 23)
        Me.txtCity.TabIndex = 6
        '
        'ugbTel
        '
        Me.ugbTel.Controls.Add(Me.txtHomeTel)
        Me.ugbTel.Controls.Add(Me.Label2)
        Me.ugbTel.Controls.Add(Me.txtOtherTel)
        Me.ugbTel.Controls.Add(Me.Label3)
        Me.ugbTel.Font = New System.Drawing.Font("Dotum", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ugbTel.Location = New System.Drawing.Point(69, 189)
        Me.ugbTel.Name = "ugbTel"
        Me.ugbTel.Size = New System.Drawing.Size(422, 61)
        Me.ugbTel.TabIndex = 3
        Me.ugbTel.Text = "전화번호"
        '
        'txtHomeTel
        '
        Me.txtHomeTel.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtHomeTel.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.txtHomeTel.Location = New System.Drawing.Point(81, 24)
        Me.txtHomeTel.MaxLength = 20
        Me.txtHomeTel.Name = "txtHomeTel"
        Me.txtHomeTel.Size = New System.Drawing.Size(125, 23)
        Me.txtHomeTel.TabIndex = 3
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Dotum", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(47, 28)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(26, 13)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "집:"
        '
        'txtOtherTel
        '
        Me.txtOtherTel.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtOtherTel.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.txtOtherTel.Location = New System.Drawing.Point(266, 24)
        Me.txtOtherTel.MaxLength = 20
        Me.txtOtherTel.Name = "txtOtherTel"
        Me.txtOtherTel.Size = New System.Drawing.Size(125, 23)
        Me.txtOtherTel.TabIndex = 4
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Dotum", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(219, 28)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(40, 13)
        Me.Label3.TabIndex = 5
        Me.Label3.Text = "기타:"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Dotum", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(103, 154)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(40, 13)
        Me.Label11.TabIndex = 22
        Me.Label11.Text = "성별:"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Dotum", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(269, 115)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(40, 13)
        Me.Label5.TabIndex = 21
        Me.Label5.Text = "직분:"
        '
        'cbTitle
        '
        Me.cbTitle.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbTitle.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbTitle.FormattingEnabled = True
        Me.cbTitle.Location = New System.Drawing.Point(315, 111)
        Me.cbTitle.Name = "cbTitle"
        Me.cbTitle.Size = New System.Drawing.Size(93, 23)
        Me.cbTitle.TabIndex = 1
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.rbtWoman)
        Me.Panel2.Controls.Add(Me.rbtMan)
        Me.Panel2.Location = New System.Drawing.Point(153, 145)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(121, 33)
        Me.Panel2.TabIndex = 2
        '
        'txtName
        '
        Me.txtName.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtName.ImeMode = System.Windows.Forms.ImeMode.Hangul
        Me.txtName.Location = New System.Drawing.Point(150, 111)
        Me.txtName.MaxLength = 10
        Me.txtName.Name = "txtName"
        Me.txtName.Size = New System.Drawing.Size(104, 23)
        Me.txtName.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Dotum", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(103, 114)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(40, 13)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "이름:"
        '
        'frmPersonAdd
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.LightSteelBlue
        Me.ClientSize = New System.Drawing.Size(843, 661)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Controls.Add(Me.pnMain)
        Me.ImeMode = System.Windows.Forms.ImeMode.HangulFull
        Me.Name = "frmPersonAdd"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "회원 입력창"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.pnMain.ResumeLayout(False)
        Me.pnMain.PerformLayout()
        CType(Me.ugRef, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ugTitle, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ugName, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picPerson, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ugCity, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.udtReg, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ugbAddress, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ugbAddress.ResumeLayout(False)
        Me.ugbAddress.PerformLayout()
        CType(Me.ugbTel, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ugbTel.ResumeLayout(False)
        Me.ugbTel.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents tsbtAdd As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsbtSave As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsbtDelete As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents tsbtRent As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsbtHistory As System.Windows.Forms.ToolStripButton
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents rbtMan As System.Windows.Forms.RadioButton
    Friend WithEvents rbtWoman As System.Windows.Forms.RadioButton
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents txtNote As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents txtEmail As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents pnMain As System.Windows.Forms.Panel
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents txtName As System.Windows.Forms.TextBox
    Friend WithEvents txtStreet As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtHomeTel As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtOtherTel As System.Windows.Forms.TextBox
    Friend WithEvents cbTitle As System.Windows.Forms.ComboBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents txtCity As System.Windows.Forms.TextBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents txtZipCode As System.Windows.Forms.TextBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents ugbTel As Infragistics.Win.Misc.UltraGroupBox
    Friend WithEvents ugbAddress As Infragistics.Win.Misc.UltraGroupBox
    Friend WithEvents udtReg As Infragistics.Win.UltraWinEditors.UltraDateTimeEditor
    Friend WithEvents lblID As System.Windows.Forms.Label
    Friend WithEvents btnExit As System.Windows.Forms.ToolStripButton
    Friend WithEvents ugCity As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents ugTitle As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents ugName As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents lblIDLabel As System.Windows.Forms.Label
    Friend WithEvents picPerson As System.Windows.Forms.PictureBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents ugRef As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents btAdd As System.Windows.Forms.Button
    Friend WithEvents btDrop As System.Windows.Forms.Button
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents tsbtAuthenticate As System.Windows.Forms.ToolStripButton
    Friend WithEvents lblLoginLevel As System.Windows.Forms.Label
    Friend WithEvents lblLoginPWD As System.Windows.Forms.Label
    Friend WithEvents lblLoginID As System.Windows.Forms.Label
    Friend WithEvents tsbtReserve As System.Windows.Forms.ToolStripButton
End Class
