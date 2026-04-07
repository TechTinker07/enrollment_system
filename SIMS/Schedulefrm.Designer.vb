<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class ScheduleFrm
    Inherits System.Windows.Forms.Form

    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    Private components As System.ComponentModel.IContainer

    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.dgvSchedules = New System.Windows.Forms.DataGridView()
        Me.lblTitle = New System.Windows.Forms.Label()
        Me.pnlHeader = New System.Windows.Forms.Panel()
        Me.cmbSubject = New System.Windows.Forms.ComboBox()
        Me.cmbCourse = New System.Windows.Forms.ComboBox()
        Me.txtRoom = New System.Windows.Forms.TextBox()
        Me.txtSection = New System.Windows.Forms.TextBox()
        Me.txtDays = New System.Windows.Forms.TextBox()
        Me.dtpStart = New System.Windows.Forms.DateTimePicker()
        Me.dtpEnd = New System.Windows.Forms.DateTimePicker()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.lblSubj = New System.Windows.Forms.Label()
        Me.lblTime = New System.Windows.Forms.Label()
        CType(Me.dgvSchedules, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlHeader.SuspendLayout()
        Me.SuspendLayout()
        '
        'dgvSchedules
        '
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(CType(CType(248, Byte), Integer), CType(CType(250, Byte), Integer), CType(CType(252, Byte), Integer))
        Me.dgvSchedules.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvSchedules.BackgroundColor = System.Drawing.Color.White
        Me.dgvSchedules.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.dgvSchedules.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(CType(CType(242, Byte), Integer), CType(CType(245, Byte), Integer), CType(CType(248, Byte), Integer))
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.dgvSchedules.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.dgvSchedules.ColumnHeadersHeight = 40
        Me.dgvSchedules.EnableHeadersVisualStyles = False
        Me.dgvSchedules.Location = New System.Drawing.Point(30, 240)
        Me.dgvSchedules.Name = "dgvSchedules"
        Me.dgvSchedules.RowHeadersVisible = False
        Me.dgvSchedules.Size = New System.Drawing.Size(740, 240)
        Me.dgvSchedules.TabIndex = 0
        '
        'lblTitle
        '
        Me.lblTitle.AutoSize = True
        Me.lblTitle.Font = New System.Drawing.Font("Segoe UI Semibold", 18.0!)
        Me.lblTitle.ForeColor = System.Drawing.Color.White
        Me.lblTitle.Location = New System.Drawing.Point(20, 15)
        Me.lblTitle.Name = "lblTitle"
        Me.lblTitle.Size = New System.Drawing.Size(265, 32)
        Me.lblTitle.TabIndex = 0
        Me.lblTitle.Text = "Schedule Management"
        '
        'pnlHeader
        '
        Me.pnlHeader.BackColor = System.Drawing.Color.FromArgb(CType(CType(45, Byte), Integer), CType(CType(52, Byte), Integer), CType(CType(54, Byte), Integer))
        Me.pnlHeader.Controls.Add(Me.lblTitle)
        Me.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlHeader.Location = New System.Drawing.Point(0, 0)
        Me.pnlHeader.Name = "pnlHeader"
        Me.pnlHeader.Size = New System.Drawing.Size(800, 70)
        Me.pnlHeader.TabIndex = 1
        '
        'cmbSubject
        '
        Me.cmbSubject.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmbSubject.Location = New System.Drawing.Point(30, 115)
        Me.cmbSubject.Name = "cmbSubject"
        Me.cmbSubject.Size = New System.Drawing.Size(220, 23)
        Me.cmbSubject.TabIndex = 2
        '
        'cmbCourse
        '
        Me.cmbCourse.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmbCourse.Location = New System.Drawing.Point(265, 115)
        Me.cmbCourse.Name = "cmbCourse"
        Me.cmbCourse.Size = New System.Drawing.Size(120, 23)
        Me.cmbCourse.TabIndex = 3
        '
        'txtRoom
        '
        Me.txtRoom.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.txtRoom.Location = New System.Drawing.Point(340, 185)
        Me.txtRoom.Name = "txtRoom"
        Me.txtRoom.Size = New System.Drawing.Size(100, 25)
        Me.txtRoom.TabIndex = 8
        '
        'txtSection
        '
        Me.txtSection.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.txtSection.Location = New System.Drawing.Point(400, 115)
        Me.txtSection.Name = "txtSection"
        Me.txtSection.Size = New System.Drawing.Size(80, 25)
        Me.txtSection.TabIndex = 4
        '
        'txtDays
        '
        Me.txtDays.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.txtDays.Location = New System.Drawing.Point(30, 185)
        Me.txtDays.Name = "txtDays"
        Me.txtDays.Size = New System.Drawing.Size(80, 25)
        Me.txtDays.TabIndex = 5
        '
        'dtpStart
        '
        Me.dtpStart.CustomFormat = "hh:mm tt"
        Me.dtpStart.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpStart.Location = New System.Drawing.Point(125, 185)
        Me.dtpStart.Name = "dtpStart"
        Me.dtpStart.ShowUpDown = True
        Me.dtpStart.Size = New System.Drawing.Size(95, 23)
        Me.dtpStart.TabIndex = 6
        '
        'dtpEnd
        '
        Me.dtpEnd.CustomFormat = "hh:mm tt"
        Me.dtpEnd.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpEnd.Location = New System.Drawing.Point(230, 185)
        Me.dtpEnd.Name = "dtpEnd"
        Me.dtpEnd.ShowUpDown = True
        Me.dtpEnd.Size = New System.Drawing.Size(95, 23)
        Me.dtpEnd.TabIndex = 7
        '
        'btnSave
        '
        Me.btnSave.BackColor = System.Drawing.Color.SteelBlue
        Me.btnSave.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnSave.FlatAppearance.BorderSize = 0
        Me.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSave.ForeColor = System.Drawing.Color.White
        Me.btnSave.Location = New System.Drawing.Point(460, 183)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(130, 32)
        Me.btnSave.TabIndex = 9
        Me.btnSave.Text = "+ Add Schedule"
        Me.btnSave.UseVisualStyleBackColor = False
        '
        'lblSubj
        '
        Me.lblSubj.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.lblSubj.ForeColor = System.Drawing.Color.Gray
        Me.lblSubj.Location = New System.Drawing.Point(30, 90)
        Me.lblSubj.Name = "lblSubj"
        Me.lblSubj.Size = New System.Drawing.Size(100, 23)
        Me.lblSubj.TabIndex = 10
        Me.lblSubj.Text = "SUBJECT, COURSE & SECTION"
        '
        'lblTime
        '
        Me.lblTime.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.lblTime.ForeColor = System.Drawing.Color.Gray
        Me.lblTime.Location = New System.Drawing.Point(30, 160)
        Me.lblTime.Name = "lblTime"
        Me.lblTime.Size = New System.Drawing.Size(100, 23)
        Me.lblTime.TabIndex = 11
        Me.lblTime.Text = "DAYS, TIME SLOT & ROOM"
        '
        'Schedulefrm
        '
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(800, 520)
        Me.Controls.Add(Me.dgvSchedules)
        Me.Controls.Add(Me.pnlHeader)
        Me.Controls.Add(Me.cmbSubject)
        Me.Controls.Add(Me.cmbCourse)
        Me.Controls.Add(Me.txtSection)
        Me.Controls.Add(Me.txtDays)
        Me.Controls.Add(Me.dtpStart)
        Me.Controls.Add(Me.dtpEnd)
        Me.Controls.Add(Me.txtRoom)
        Me.Controls.Add(Me.btnSave)
        Me.Controls.Add(Me.lblSubj)
        Me.Controls.Add(Me.lblTime)
        Me.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Name = "Schedulefrm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Schedule Management"
        CType(Me.dgvSchedules, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlHeader.ResumeLayout(False)
        Me.pnlHeader.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    ' Declarations
    Friend WithEvents dgvSchedules As System.Windows.Forms.DataGridView
    Friend WithEvents lblTitle As System.Windows.Forms.Label
    Friend WithEvents pnlHeader As System.Windows.Forms.Panel
    Friend WithEvents cmbSubject As System.Windows.Forms.ComboBox
    Friend WithEvents cmbCourse As System.Windows.Forms.ComboBox
    Friend WithEvents txtRoom As System.Windows.Forms.TextBox
    Friend WithEvents txtSection As System.Windows.Forms.TextBox
    Friend WithEvents txtDays As System.Windows.Forms.TextBox
    Friend WithEvents dtpStart As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtpEnd As System.Windows.Forms.DateTimePicker
    Friend WithEvents btnSave As System.Windows.Forms.Button
    Friend WithEvents lblSubj As System.Windows.Forms.Label
    Friend WithEvents lblTime As System.Windows.Forms.Label
End Class