<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class schedulelist
    Inherits System.Windows.Forms.Form

    Private components As System.ComponentModel.IContainer

    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle9 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle10 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(schedulelist))
        Me.pnlInputs = New System.Windows.Forms.Panel()
        Me.lblTo = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.btnSat = New System.Windows.Forms.Button()
        Me.btnFri = New System.Windows.Forms.Button()
        Me.btnThurs = New System.Windows.Forms.Button()
        Me.btnWed = New System.Windows.Forms.Button()
        Me.btnTues = New System.Windows.Forms.Button()
        Me.btnMon = New System.Windows.Forms.Button()
        Me.lblDay = New System.Windows.Forms.Label()
        Me.lblRoom = New System.Windows.Forms.Label()
        Me.cmbRoom = New System.Windows.Forms.ComboBox()
        Me.lblSection = New System.Windows.Forms.Label()
        Me.cmbSection = New System.Windows.Forms.ComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.lblSubj = New System.Windows.Forms.Label()
        Me.cmbSubjects = New System.Windows.Forms.ComboBox()
        Me.lblTime = New System.Windows.Forms.Label()
        Me.dtpStart = New System.Windows.Forms.DateTimePicker()
        Me.dtpEnd = New System.Windows.Forms.DateTimePicker()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.btnDelete = New System.Windows.Forms.Button()
        Me.txtRoom = New System.Windows.Forms.TextBox()
        Me.dgvSchedules = New System.Windows.Forms.DataGridView()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtSearch = New System.Windows.Forms.TextBox()
        Me.pnlInputs.SuspendLayout()
        CType(Me.dgvSchedules, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'pnlInputs
        '
        Me.pnlInputs.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.pnlInputs.BackColor = System.Drawing.Color.White
        Me.pnlInputs.Controls.Add(Me.lblTo)
        Me.pnlInputs.Controls.Add(Me.Label8)
        Me.pnlInputs.Controls.Add(Me.btnSat)
        Me.pnlInputs.Controls.Add(Me.btnFri)
        Me.pnlInputs.Controls.Add(Me.btnThurs)
        Me.pnlInputs.Controls.Add(Me.btnWed)
        Me.pnlInputs.Controls.Add(Me.btnTues)
        Me.pnlInputs.Controls.Add(Me.btnMon)
        Me.pnlInputs.Controls.Add(Me.lblDay)
        Me.pnlInputs.Controls.Add(Me.lblRoom)
        Me.pnlInputs.Controls.Add(Me.cmbRoom)
        Me.pnlInputs.Controls.Add(Me.lblSection)
        Me.pnlInputs.Controls.Add(Me.cmbSection)
        Me.pnlInputs.Controls.Add(Me.Label3)
        Me.pnlInputs.Controls.Add(Me.Label4)
        Me.pnlInputs.Controls.Add(Me.lblSubj)
        Me.pnlInputs.Controls.Add(Me.cmbSubjects)
        Me.pnlInputs.Controls.Add(Me.lblTime)
        Me.pnlInputs.Controls.Add(Me.dtpStart)
        Me.pnlInputs.Controls.Add(Me.dtpEnd)
        Me.pnlInputs.Controls.Add(Me.btnSave)
        Me.pnlInputs.Controls.Add(Me.btnDelete)
        Me.pnlInputs.Location = New System.Drawing.Point(0, 82)
        Me.pnlInputs.Name = "pnlInputs"
        Me.pnlInputs.Padding = New System.Windows.Forms.Padding(30)
        Me.pnlInputs.Size = New System.Drawing.Size(359, 598)
        Me.pnlInputs.TabIndex = 1
        '
        'lblTo
        '
        Me.lblTo.ForeColor = System.Drawing.Color.FromArgb(CType(CType(136, Byte), Integer), CType(CType(136, Byte), Integer), CType(CType(136, Byte), Integer))
        Me.lblTo.Location = New System.Drawing.Point(160, 390)
        Me.lblTo.Name = "lblTo"
        Me.lblTo.Size = New System.Drawing.Size(22, 21)
        Me.lblTo.TabIndex = 33
        Me.lblTo.Text = "TO"
        '
        'Label8
        '
        Me.Label8.ForeColor = System.Drawing.Color.FromArgb(CType(CType(107, Byte), Integer), CType(CType(114, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.Label8.Location = New System.Drawing.Point(22, 363)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(100, 20)
        Me.Label8.TabIndex = 32
        Me.Label8.Text = "TIME"
        '
        'btnSat
        '
        Me.btnSat.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnSat.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(176, Byte), Integer), CType(CType(176, Byte), Integer), CType(CType(176, Byte), Integer))
        Me.btnSat.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSat.ForeColor = System.Drawing.Color.FromArgb(CType(CType(170, Byte), Integer), CType(CType(170, Byte), Integer), CType(CType(170, Byte), Integer))
        Me.btnSat.Location = New System.Drawing.Point(273, 251)
        Me.btnSat.Name = "btnSat"
        Me.btnSat.Size = New System.Drawing.Size(44, 23)
        Me.btnSat.TabIndex = 31
        Me.btnSat.Text = "S"
        Me.btnSat.UseVisualStyleBackColor = True
        '
        'btnFri
        '
        Me.btnFri.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnFri.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(176, Byte), Integer), CType(CType(176, Byte), Integer), CType(CType(176, Byte), Integer))
        Me.btnFri.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnFri.ForeColor = System.Drawing.Color.FromArgb(CType(CType(170, Byte), Integer), CType(CType(170, Byte), Integer), CType(CType(170, Byte), Integer))
        Me.btnFri.Location = New System.Drawing.Point(223, 251)
        Me.btnFri.Name = "btnFri"
        Me.btnFri.Size = New System.Drawing.Size(44, 23)
        Me.btnFri.TabIndex = 30
        Me.btnFri.Text = "F"
        Me.btnFri.UseVisualStyleBackColor = True
        '
        'btnThurs
        '
        Me.btnThurs.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnThurs.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(176, Byte), Integer), CType(CType(176, Byte), Integer), CType(CType(176, Byte), Integer))
        Me.btnThurs.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnThurs.ForeColor = System.Drawing.Color.FromArgb(CType(CType(170, Byte), Integer), CType(CType(170, Byte), Integer), CType(CType(170, Byte), Integer))
        Me.btnThurs.Location = New System.Drawing.Point(173, 251)
        Me.btnThurs.Name = "btnThurs"
        Me.btnThurs.Size = New System.Drawing.Size(44, 23)
        Me.btnThurs.TabIndex = 29
        Me.btnThurs.Text = "TH"
        Me.btnThurs.UseVisualStyleBackColor = True
        '
        'btnWed
        '
        Me.btnWed.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnWed.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(176, Byte), Integer), CType(CType(176, Byte), Integer), CType(CType(176, Byte), Integer))
        Me.btnWed.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnWed.ForeColor = System.Drawing.Color.FromArgb(CType(CType(170, Byte), Integer), CType(CType(170, Byte), Integer), CType(CType(170, Byte), Integer))
        Me.btnWed.Location = New System.Drawing.Point(123, 251)
        Me.btnWed.Name = "btnWed"
        Me.btnWed.Size = New System.Drawing.Size(44, 23)
        Me.btnWed.TabIndex = 28
        Me.btnWed.Text = "W"
        Me.btnWed.UseVisualStyleBackColor = True
        '
        'btnTues
        '
        Me.btnTues.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnTues.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(176, Byte), Integer), CType(CType(176, Byte), Integer), CType(CType(176, Byte), Integer))
        Me.btnTues.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnTues.ForeColor = System.Drawing.Color.FromArgb(CType(CType(170, Byte), Integer), CType(CType(170, Byte), Integer), CType(CType(170, Byte), Integer))
        Me.btnTues.Location = New System.Drawing.Point(73, 251)
        Me.btnTues.Name = "btnTues"
        Me.btnTues.Size = New System.Drawing.Size(44, 23)
        Me.btnTues.TabIndex = 27
        Me.btnTues.Text = "T"
        Me.btnTues.UseVisualStyleBackColor = True
        '
        'btnMon
        '
        Me.btnMon.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnMon.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(176, Byte), Integer), CType(CType(176, Byte), Integer), CType(CType(176, Byte), Integer))
        Me.btnMon.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnMon.ForeColor = System.Drawing.Color.FromArgb(CType(CType(170, Byte), Integer), CType(CType(170, Byte), Integer), CType(CType(170, Byte), Integer))
        Me.btnMon.Location = New System.Drawing.Point(22, 251)
        Me.btnMon.Name = "btnMon"
        Me.btnMon.Size = New System.Drawing.Size(44, 23)
        Me.btnMon.TabIndex = 26
        Me.btnMon.Text = "M"
        Me.btnMon.UseVisualStyleBackColor = True
        '
        'lblDay
        '
        Me.lblDay.ForeColor = System.Drawing.Color.FromArgb(CType(CType(107, Byte), Integer), CType(CType(114, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.lblDay.Location = New System.Drawing.Point(22, 225)
        Me.lblDay.Name = "lblDay"
        Me.lblDay.Size = New System.Drawing.Size(100, 23)
        Me.lblDay.TabIndex = 25
        Me.lblDay.Text = "DAY"
        '
        'lblRoom
        '
        Me.lblRoom.ForeColor = System.Drawing.Color.FromArgb(CType(CType(107, Byte), Integer), CType(CType(114, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.lblRoom.Location = New System.Drawing.Point(22, 152)
        Me.lblRoom.Name = "lblRoom"
        Me.lblRoom.Size = New System.Drawing.Size(100, 23)
        Me.lblRoom.TabIndex = 23
        Me.lblRoom.Text = "ROOM"
        '
        'cmbRoom
        '
        Me.cmbRoom.BackColor = System.Drawing.Color.FromArgb(CType(CType(253, Byte), Integer), CType(CType(247, Byte), Integer), CType(CType(248, Byte), Integer))
        Me.cmbRoom.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmbRoom.Font = New System.Drawing.Font("Segoe UI", 11.0!)
        Me.cmbRoom.Location = New System.Drawing.Point(25, 178)
        Me.cmbRoom.Name = "cmbRoom"
        Me.cmbRoom.Size = New System.Drawing.Size(305, 28)
        Me.cmbRoom.TabIndex = 24
        '
        'lblSection
        '
        Me.lblSection.ForeColor = System.Drawing.Color.FromArgb(CType(CType(107, Byte), Integer), CType(CType(114, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.lblSection.Location = New System.Drawing.Point(209, 65)
        Me.lblSection.Name = "lblSection"
        Me.lblSection.Size = New System.Drawing.Size(100, 23)
        Me.lblSection.TabIndex = 22
        Me.lblSection.Text = "SECTION"
        '
        'cmbSection
        '
        Me.cmbSection.BackColor = System.Drawing.Color.FromArgb(CType(CType(253, Byte), Integer), CType(CType(247, Byte), Integer), CType(CType(248, Byte), Integer))
        Me.cmbSection.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmbSection.Font = New System.Drawing.Font("Segoe UI", 11.0!)
        Me.cmbSection.Location = New System.Drawing.Point(185, 91)
        Me.cmbSection.Name = "cmbSection"
        Me.cmbSection.Size = New System.Drawing.Size(145, 28)
        Me.cmbSection.TabIndex = 21
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.FromArgb(CType(CType(107, Byte), Integer), CType(CType(26, Byte), Integer), CType(CType(42, Byte), Integer))
        Me.Label3.Location = New System.Drawing.Point(12, 38)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(331, 15)
        Me.Label3.TabIndex = 20
        Me.Label3.Text = "———————————————————————————"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.FromArgb(CType(CType(107, Byte), Integer), CType(CType(26, Byte), Integer), CType(CType(42, Byte), Integer))
        Me.Label4.Location = New System.Drawing.Point(23, 14)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(137, 21)
        Me.Label4.TabIndex = 19
        Me.Label4.Text = "Schedule Details"
        '
        'lblSubj
        '
        Me.lblSubj.ForeColor = System.Drawing.Color.FromArgb(CType(CType(107, Byte), Integer), CType(CType(114, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.lblSubj.Location = New System.Drawing.Point(22, 66)
        Me.lblSubj.Name = "lblSubj"
        Me.lblSubj.Size = New System.Drawing.Size(100, 23)
        Me.lblSubj.TabIndex = 1
        Me.lblSubj.Text = "SUBJECT"
        '
        'cmbSubjects
        '
        Me.cmbSubjects.BackColor = System.Drawing.Color.FromArgb(CType(CType(253, Byte), Integer), CType(CType(247, Byte), Integer), CType(CType(248, Byte), Integer))
        Me.cmbSubjects.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmbSubjects.Font = New System.Drawing.Font("Segoe UI", 11.0!)
        Me.cmbSubjects.Location = New System.Drawing.Point(22, 91)
        Me.cmbSubjects.Name = "cmbSubjects"
        Me.cmbSubjects.Size = New System.Drawing.Size(125, 28)
        Me.cmbSubjects.TabIndex = 2
        '
        'lblTime
        '
        Me.lblTime.ForeColor = System.Drawing.Color.FromArgb(CType(CType(107, Byte), Integer), CType(CType(114, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.lblTime.Location = New System.Drawing.Point(24, 297)
        Me.lblTime.Name = "lblTime"
        Me.lblTime.Size = New System.Drawing.Size(100, 23)
        Me.lblTime.TabIndex = 4
        Me.lblTime.Text = "Schedule Details"
        '
        'dtpStart
        '
        Me.dtpStart.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpStart.Format = System.Windows.Forms.DateTimePickerFormat.Time
        Me.dtpStart.Location = New System.Drawing.Point(21, 386)
        Me.dtpStart.Name = "dtpStart"
        Me.dtpStart.ShowUpDown = True
        Me.dtpStart.Size = New System.Drawing.Size(126, 25)
        Me.dtpStart.TabIndex = 6
        '
        'dtpEnd
        '
        Me.dtpEnd.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpEnd.Format = System.Windows.Forms.DateTimePickerFormat.Time
        Me.dtpEnd.Location = New System.Drawing.Point(188, 386)
        Me.dtpEnd.Name = "dtpEnd"
        Me.dtpEnd.ShowUpDown = True
        Me.dtpEnd.Size = New System.Drawing.Size(131, 25)
        Me.dtpEnd.TabIndex = 7
        '
        'btnSave
        '
        Me.btnSave.BackColor = System.Drawing.Color.FromArgb(CType(CType(122, Byte), Integer), CType(CType(12, Byte), Integer), CType(CType(34, Byte), Integer))
        Me.btnSave.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnSave.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(90, Byte), Integer), CType(CType(9, Byte), Integer), CType(CType(24, Byte), Integer))
        Me.btnSave.FlatAppearance.BorderSize = 0
        Me.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSave.Font = New System.Drawing.Font("Segoe UI Semibold", 10.5!)
        Me.btnSave.ForeColor = System.Drawing.Color.White
        Me.btnSave.Location = New System.Drawing.Point(21, 440)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(300, 45)
        Me.btnSave.TabIndex = 8
        Me.btnSave.Text = "Save Schedule"
        Me.btnSave.UseVisualStyleBackColor = False
        '
        'btnDelete
        '
        Me.btnDelete.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(160, Byte), Integer), CType(CType(168, Byte), Integer))
        Me.btnDelete.FlatAppearance.BorderSize = 0
        Me.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnDelete.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.btnDelete.ForeColor = System.Drawing.Color.FromArgb(CType(CType(122, Byte), Integer), CType(CType(12, Byte), Integer), CType(CType(34, Byte), Integer))
        Me.btnDelete.Location = New System.Drawing.Point(21, 511)
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.Size = New System.Drawing.Size(300, 35)
        Me.btnDelete.TabIndex = 9
        Me.btnDelete.Text = "Delete Selection"
        '
        'txtRoom
        '
        Me.txtRoom.Location = New System.Drawing.Point(0, 0)
        Me.txtRoom.Name = "txtRoom"
        Me.txtRoom.Size = New System.Drawing.Size(100, 20)
        Me.txtRoom.TabIndex = 0
        '
        'dgvSchedules
        '
        DataGridViewCellStyle6.BackColor = System.Drawing.Color.FromArgb(CType(CType(252, Byte), Integer), CType(CType(249, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.dgvSchedules.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle6
        Me.dgvSchedules.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvSchedules.BackgroundColor = System.Drawing.Color.White
        Me.dgvSchedules.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.dgvSchedules.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal
        Me.dgvSchedules.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle7.BackColor = System.Drawing.Color.FromArgb(CType(CType(250, Byte), Integer), CType(CType(245, Byte), Integer), CType(CType(246, Byte), Integer))
        DataGridViewCellStyle7.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        DataGridViewCellStyle7.ForeColor = System.Drawing.Color.FromArgb(CType(CType(107, Byte), Integer), CType(CType(26, Byte), Integer), CType(CType(42, Byte), Integer))
        DataGridViewCellStyle7.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(245, Byte), Integer), CType(CType(232, Byte), Integer), CType(CType(235, Byte), Integer))
        DataGridViewCellStyle7.SelectionForeColor = System.Drawing.Color.FromArgb(CType(CType(61, Byte), Integer), CType(CType(14, Byte), Integer), CType(CType(24, Byte), Integer))
        Me.dgvSchedules.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle7
        Me.dgvSchedules.ColumnHeadersHeight = 38
        Me.dgvSchedules.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        DataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle8.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle8.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        DataGridViewCellStyle8.ForeColor = System.Drawing.Color.FromArgb(CType(CType(55, Byte), Integer), CType(CType(65, Byte), Integer), CType(CType(81, Byte), Integer))
        DataGridViewCellStyle8.SelectionBackColor = System.Drawing.Color.SteelBlue
        DataGridViewCellStyle8.SelectionForeColor = System.Drawing.Color.White
        DataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvSchedules.DefaultCellStyle = DataGridViewCellStyle8
        Me.dgvSchedules.EnableHeadersVisualStyles = False
        Me.dgvSchedules.GridColor = System.Drawing.Color.FromArgb(CType(CType(236, Byte), Integer), CType(CType(236, Byte), Integer), CType(CType(236, Byte), Integer))
        Me.dgvSchedules.Location = New System.Drawing.Point(362, 136)
        Me.dgvSchedules.Name = "dgvSchedules"
        DataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle9.BackColor = System.Drawing.Color.FromArgb(CType(CType(253, Byte), Integer), CType(CType(247, Byte), Integer), CType(CType(248, Byte), Integer))
        DataGridViewCellStyle9.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        DataGridViewCellStyle9.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle9.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle9.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvSchedules.RowHeadersDefaultCellStyle = DataGridViewCellStyle9
        Me.dgvSchedules.RowHeadersVisible = False
        DataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.dgvSchedules.RowsDefaultCellStyle = DataGridViewCellStyle10
        Me.dgvSchedules.RowTemplate.Height = 30
        Me.dgvSchedules.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvSchedules.Size = New System.Drawing.Size(735, 540)
        Me.dgvSchedules.TabIndex = 0
        '
        'Panel1
        '
        Me.Panel1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(107, Byte), Integer), CType(CType(26, Byte), Integer), CType(CType(42, Byte), Integer))
        Me.Panel1.Controls.Add(Me.PictureBox1)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1100, 82)
        Me.Panel1.TabIndex = 10
        '
        'PictureBox1
        '
        Me.PictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(22, 24)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(28, 27)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBox1.TabIndex = 15
        Me.PictureBox1.TabStop = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Gray
        Me.Label2.Location = New System.Drawing.Point(70, 49)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(240, 15)
        Me.Label2.TabIndex = 11
        Me.Label2.Text = "Class Schedules and Time Slot Management"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Segoe UI Semibold", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(68, 18)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(209, 25)
        Me.Label1.TabIndex = 10
        Me.Label1.Text = "Schedule Management"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'txtSearch
        '
        Me.txtSearch.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtSearch.BackColor = System.Drawing.Color.FromArgb(CType(CType(253, Byte), Integer), CType(CType(247, Byte), Integer), CType(CType(248, Byte), Integer))
        Me.txtSearch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtSearch.ForeColor = System.Drawing.Color.FromArgb(CType(CType(107, Byte), Integer), CType(CType(114, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.txtSearch.Location = New System.Drawing.Point(365, 94)
        Me.txtSearch.Name = "txtSearch"
        Me.txtSearch.Size = New System.Drawing.Size(260, 23)
        Me.txtSearch.TabIndex = 11
        Me.txtSearch.Text = " ? Search schedules...."
        '
        'schedulelist
        '
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(243, Byte), Integer), CType(CType(244, Byte), Integer), CType(CType(246, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(1100, 680)
        Me.Controls.Add(Me.txtSearch)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.dgvSchedules)
        Me.Controls.Add(Me.pnlInputs)
        Me.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Name = "schedulelist"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Schedule Management System"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.pnlInputs.ResumeLayout(False)
        Me.pnlInputs.PerformLayout()
        CType(Me.dgvSchedules, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents pnlInputs As Panel
    Friend WithEvents lblSubj As Label
    Friend WithEvents lblTime As Label
    Friend WithEvents cmbSubjects As ComboBox
    Friend WithEvents dtpStart As DateTimePicker
    Friend WithEvents dtpEnd As DateTimePicker
    Friend WithEvents txtRoom As TextBox
    Friend WithEvents btnSave As Button
    Friend WithEvents btnDelete As Button
    Friend WithEvents dgvSchedules As DataGridView
    Friend WithEvents Panel1 As Panel
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents cmbSection As ComboBox
    Friend WithEvents lblRoom As Label
    Friend WithEvents cmbRoom As ComboBox
    Friend WithEvents lblSection As Label
    Friend WithEvents btnSat As Button
    Friend WithEvents btnFri As Button
    Friend WithEvents btnThurs As Button
    Friend WithEvents btnWed As Button
    Friend WithEvents btnTues As Button
    Friend WithEvents btnMon As Button
    Friend WithEvents lblDay As Label
    Friend WithEvents lblTo As Label
    Friend WithEvents Label8 As Label
    Private WithEvents txtSearch As TextBox
End Class



