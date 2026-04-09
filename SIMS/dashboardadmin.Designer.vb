<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class dashboardadmin
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
        Dim DataGridViewCellStyle1 As New System.Windows.Forms.DataGridViewCellStyle()
        Me.pnlHeader = New System.Windows.Forms.Panel()
        Me.lblTitle = New System.Windows.Forms.Label()
        Me.pnlMain = New System.Windows.Forms.Panel()
        Me.cardCourses = New System.Windows.Forms.Panel()
        Me.lblCourseVal = New System.Windows.Forms.Label()
        Me.lblCourseTitle = New System.Windows.Forms.Label()
        Me.cardUsers = New System.Windows.Forms.Panel()
        Me.lblUserVal = New System.Windows.Forms.Label()
        Me.lblUserTitle = New System.Windows.Forms.Label()
        Me.lblGridTitle = New System.Windows.Forms.Label()
        Me.dgvRecentPayments = New System.Windows.Forms.DataGridView()
        Me.cardPending = New System.Windows.Forms.Panel()
        Me.lblPendingVal = New System.Windows.Forms.Label()
        Me.lblPendingTitle = New System.Windows.Forms.Label()
        Me.cardRevenue = New System.Windows.Forms.Panel()
        Me.lblRevenueVal = New System.Windows.Forms.Label()
        Me.lblRevenueTitle = New System.Windows.Forms.Label()
        Me.cardStudents = New System.Windows.Forms.Panel()
        Me.lblStudentVal = New System.Windows.Forms.Label()
        Me.lblStudentTitle = New System.Windows.Forms.Label()
        Me.pnlHeader.SuspendLayout()
        Me.pnlMain.SuspendLayout()
        Me.cardCourses.SuspendLayout()
        Me.cardUsers.SuspendLayout()
        CType(Me.dgvRecentPayments, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.cardPending.SuspendLayout()
        Me.cardRevenue.SuspendLayout()
        Me.cardStudents.SuspendLayout()
        Me.SuspendLayout()
        '
        'pnlHeader
        '
        Me.pnlHeader.BackColor = System.Drawing.Color.White
        Me.pnlHeader.Controls.Add(Me.lblTitle)
        Me.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlHeader.Location = New System.Drawing.Point(0, 0)
        Me.pnlHeader.Name = "pnlHeader"
        Me.pnlHeader.Size = New System.Drawing.Size(1264, 70)
        Me.pnlHeader.TabIndex = 1
        '
        'lblTitle
        '
        Me.lblTitle.AutoSize = True
        Me.lblTitle.Font = New System.Drawing.Font("Segoe UI Semibold", 15.75!, System.Drawing.FontStyle.Bold)
        Me.lblTitle.ForeColor = System.Drawing.Color.FromArgb(64, 64, 64)
        Me.lblTitle.Location = New System.Drawing.Point(18, 20)
        Me.lblTitle.Name = "lblTitle"
        Me.lblTitle.Size = New System.Drawing.Size(288, 30)
        Me.lblTitle.TabIndex = 0
        Me.lblTitle.Text = "ADMINISTRATOR DASHBOARD"
        '
        'pnlMain
        '
        Me.pnlMain.BackColor = System.Drawing.Color.FromArgb(244, 246, 249)
        Me.pnlMain.Controls.Add(Me.cardCourses)
        Me.pnlMain.Controls.Add(Me.cardUsers)
        Me.pnlMain.Controls.Add(Me.lblGridTitle)
        Me.pnlMain.Controls.Add(Me.dgvRecentPayments)
        Me.pnlMain.Controls.Add(Me.cardPending)
        Me.pnlMain.Controls.Add(Me.cardRevenue)
        Me.pnlMain.Controls.Add(Me.cardStudents)
        Me.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlMain.Location = New System.Drawing.Point(0, 70)
        Me.pnlMain.Name = "pnlMain"
        Me.pnlMain.Padding = New System.Windows.Forms.Padding(20)
        Me.pnlMain.Size = New System.Drawing.Size(1264, 611)
        Me.pnlMain.TabIndex = 2
        '
        'cardCourses
        '
        Me.cardCourses.BackColor = System.Drawing.Color.FromArgb(23, 162, 184)
        Me.cardCourses.Controls.Add(Me.lblCourseVal)
        Me.cardCourses.Controls.Add(Me.lblCourseTitle)
        Me.cardCourses.Location = New System.Drawing.Point(1015, 23)
        Me.cardCourses.Name = "cardCourses"
        Me.cardCourses.Size = New System.Drawing.Size(230, 115)
        Me.cardCourses.TabIndex = 6
        '
        'lblCourseVal
        '
        Me.lblCourseVal.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblCourseVal.Font = New System.Drawing.Font("Segoe UI", 24.0!, System.Drawing.FontStyle.Bold)
        Me.lblCourseVal.ForeColor = System.Drawing.Color.White
        Me.lblCourseVal.Location = New System.Drawing.Point(0, 40)
        Me.lblCourseVal.Name = "lblCourseVal"
        Me.lblCourseVal.Size = New System.Drawing.Size(230, 75)
        Me.lblCourseVal.TabIndex = 1
        Me.lblCourseVal.Text = "0"
        Me.lblCourseVal.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblCourseTitle
        '
        Me.lblCourseTitle.Dock = System.Windows.Forms.DockStyle.Top
        Me.lblCourseTitle.Font = New System.Drawing.Font("Segoe UI", 11.25!, System.Drawing.FontStyle.Bold)
        Me.lblCourseTitle.ForeColor = System.Drawing.Color.White
        Me.lblCourseTitle.Location = New System.Drawing.Point(0, 0)
        Me.lblCourseTitle.Name = "lblCourseTitle"
        Me.lblCourseTitle.Padding = New System.Windows.Forms.Padding(0, 10, 0, 0)
        Me.lblCourseTitle.Size = New System.Drawing.Size(230, 40)
        Me.lblCourseTitle.TabIndex = 0
        Me.lblCourseTitle.Text = "TOTAL COURSES"
        Me.lblCourseTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'cardUsers
        '
        Me.cardUsers.BackColor = System.Drawing.Color.FromArgb(220, 53, 69)
        Me.cardUsers.Controls.Add(Me.lblUserVal)
        Me.cardUsers.Controls.Add(Me.lblUserTitle)
        Me.cardUsers.Location = New System.Drawing.Point(767, 23)
        Me.cardUsers.Name = "cardUsers"
        Me.cardUsers.Size = New System.Drawing.Size(230, 115)
        Me.cardUsers.TabIndex = 5
        '
        'lblUserVal
        '
        Me.lblUserVal.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblUserVal.Font = New System.Drawing.Font("Segoe UI", 24.0!, System.Drawing.FontStyle.Bold)
        Me.lblUserVal.ForeColor = System.Drawing.Color.White
        Me.lblUserVal.Location = New System.Drawing.Point(0, 40)
        Me.lblUserVal.Name = "lblUserVal"
        Me.lblUserVal.Size = New System.Drawing.Size(230, 75)
        Me.lblUserVal.TabIndex = 1
        Me.lblUserVal.Text = "0"
        Me.lblUserVal.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblUserTitle
        '
        Me.lblUserTitle.Dock = System.Windows.Forms.DockStyle.Top
        Me.lblUserTitle.Font = New System.Drawing.Font("Segoe UI", 11.25!, System.Drawing.FontStyle.Bold)
        Me.lblUserTitle.ForeColor = System.Drawing.Color.White
        Me.lblUserTitle.Location = New System.Drawing.Point(0, 0)
        Me.lblUserTitle.Name = "lblUserTitle"
        Me.lblUserTitle.Padding = New System.Windows.Forms.Padding(0, 10, 0, 0)
        Me.lblUserTitle.Size = New System.Drawing.Size(230, 40)
        Me.lblUserTitle.TabIndex = 0
        Me.lblUserTitle.Text = "PENDING USERS"
        Me.lblUserTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblGridTitle
        '
        Me.lblGridTitle.AutoSize = True
        Me.lblGridTitle.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold)
        Me.lblGridTitle.ForeColor = System.Drawing.Color.FromArgb(52, 58, 64)
        Me.lblGridTitle.Location = New System.Drawing.Point(23, 168)
        Me.lblGridTitle.Name = "lblGridTitle"
        Me.lblGridTitle.Size = New System.Drawing.Size(183, 21)
        Me.lblGridTitle.TabIndex = 4
        Me.lblGridTitle.Text = "Recent Collection Logs"
        '
        'dgvRecentPayments
        '
        Me.dgvRecentPayments.AllowUserToAddRows = False
        Me.dgvRecentPayments.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dgvRecentPayments.BackgroundColor = System.Drawing.Color.White
        Me.dgvRecentPayments.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.dgvRecentPayments.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Segoe UI", 9.75!)
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(0, 123, 255)
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False
        Me.dgvRecentPayments.DefaultCellStyle = DataGridViewCellStyle1
        Me.dgvRecentPayments.Location = New System.Drawing.Point(23, 203)
        Me.dgvRecentPayments.Name = "dgvRecentPayments"
        Me.dgvRecentPayments.ReadOnly = True
        Me.dgvRecentPayments.RowHeadersVisible = False
        Me.dgvRecentPayments.Size = New System.Drawing.Size(1222, 385)
        Me.dgvRecentPayments.TabIndex = 3
        '
        'cardPending
        '
        Me.cardPending.BackColor = System.Drawing.Color.FromArgb(255, 193, 7)
        Me.cardPending.Controls.Add(Me.lblPendingVal)
        Me.cardPending.Controls.Add(Me.lblPendingTitle)
        Me.cardPending.Location = New System.Drawing.Point(519, 23)
        Me.cardPending.Name = "cardPending"
        Me.cardPending.Size = New System.Drawing.Size(230, 115)
        Me.cardPending.TabIndex = 2
        '
        'lblPendingVal
        '
        Me.lblPendingVal.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblPendingVal.Font = New System.Drawing.Font("Segoe UI", 24.0!, System.Drawing.FontStyle.Bold)
        Me.lblPendingVal.ForeColor = System.Drawing.Color.FromArgb(52, 58, 64)
        Me.lblPendingVal.Location = New System.Drawing.Point(0, 40)
        Me.lblPendingVal.Name = "lblPendingVal"
        Me.lblPendingVal.Size = New System.Drawing.Size(230, 75)
        Me.lblPendingVal.TabIndex = 1
        Me.lblPendingVal.Text = "0"
        Me.lblPendingVal.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblPendingTitle
        '
        Me.lblPendingTitle.Dock = System.Windows.Forms.DockStyle.Top
        Me.lblPendingTitle.Font = New System.Drawing.Font("Segoe UI", 11.25!, System.Drawing.FontStyle.Bold)
        Me.lblPendingTitle.ForeColor = System.Drawing.Color.FromArgb(52, 58, 64)
        Me.lblPendingTitle.Location = New System.Drawing.Point(0, 0)
        Me.lblPendingTitle.Name = "lblPendingTitle"
        Me.lblPendingTitle.Padding = New System.Windows.Forms.Padding(0, 10, 0, 0)
        Me.lblPendingTitle.Size = New System.Drawing.Size(230, 40)
        Me.lblPendingTitle.TabIndex = 0
        Me.lblPendingTitle.Text = "PENDING ADMISSION"
        Me.lblPendingTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'cardRevenue
        '
        Me.cardRevenue.BackColor = System.Drawing.Color.FromArgb(40, 167, 69)
        Me.cardRevenue.Controls.Add(Me.lblRevenueVal)
        Me.cardRevenue.Controls.Add(Me.lblRevenueTitle)
        Me.cardRevenue.Location = New System.Drawing.Point(271, 23)
        Me.cardRevenue.Name = "cardRevenue"
        Me.cardRevenue.Size = New System.Drawing.Size(230, 115)
        Me.cardRevenue.TabIndex = 1
        '
        'lblRevenueVal
        '
        Me.lblRevenueVal.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblRevenueVal.Font = New System.Drawing.Font("Segoe UI", 20.25!, System.Drawing.FontStyle.Bold)
        Me.lblRevenueVal.ForeColor = System.Drawing.Color.White
        Me.lblRevenueVal.Location = New System.Drawing.Point(0, 40)
        Me.lblRevenueVal.Name = "lblRevenueVal"
        Me.lblRevenueVal.Size = New System.Drawing.Size(230, 75)
        Me.lblRevenueVal.TabIndex = 1
        Me.lblRevenueVal.Text = "₱0.00"
        Me.lblRevenueVal.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblRevenueTitle
        '
        Me.lblRevenueTitle.Dock = System.Windows.Forms.DockStyle.Top
        Me.lblRevenueTitle.Font = New System.Drawing.Font("Segoe UI", 11.25!, System.Drawing.FontStyle.Bold)
        Me.lblRevenueTitle.ForeColor = System.Drawing.Color.White
        Me.lblRevenueTitle.Location = New System.Drawing.Point(0, 0)
        Me.lblRevenueTitle.Name = "lblRevenueTitle"
        Me.lblRevenueTitle.Padding = New System.Windows.Forms.Padding(0, 10, 0, 0)
        Me.lblRevenueTitle.Size = New System.Drawing.Size(230, 40)
        Me.lblRevenueTitle.TabIndex = 0
        Me.lblRevenueTitle.Text = "TOTAL REVENUE"
        Me.lblRevenueTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'cardStudents
        '
        Me.cardStudents.BackColor = System.Drawing.Color.FromArgb(0, 123, 255)
        Me.cardStudents.Controls.Add(Me.lblStudentVal)
        Me.cardStudents.Controls.Add(Me.lblStudentTitle)
        Me.cardStudents.Location = New System.Drawing.Point(23, 23)
        Me.cardStudents.Name = "cardStudents"
        Me.cardStudents.Size = New System.Drawing.Size(230, 115)
        Me.cardStudents.TabIndex = 0
        '
        'lblStudentVal
        '
        Me.lblStudentVal.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblStudentVal.Font = New System.Drawing.Font("Segoe UI", 24.0!, System.Drawing.FontStyle.Bold)
        Me.lblStudentVal.ForeColor = System.Drawing.Color.White
        Me.lblStudentVal.Location = New System.Drawing.Point(0, 40)
        Me.lblStudentVal.Name = "lblStudentVal"
        Me.lblStudentVal.Size = New System.Drawing.Size(230, 75)
        Me.lblStudentVal.TabIndex = 1
        Me.lblStudentVal.Text = "0"
        Me.lblStudentVal.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblStudentTitle
        '
        Me.lblStudentTitle.Dock = System.Windows.Forms.DockStyle.Top
        Me.lblStudentTitle.Font = New System.Drawing.Font("Segoe UI", 11.25!, System.Drawing.FontStyle.Bold)
        Me.lblStudentTitle.ForeColor = System.Drawing.Color.White
        Me.lblStudentTitle.Location = New System.Drawing.Point(0, 0)
        Me.lblStudentTitle.Name = "lblStudentTitle"
        Me.lblStudentTitle.Padding = New System.Windows.Forms.Padding(0, 10, 0, 0)
        Me.lblStudentTitle.Size = New System.Drawing.Size(230, 40)
        Me.lblStudentTitle.TabIndex = 0
        Me.lblStudentTitle.Text = "TOTAL STUDENTS"
        Me.lblStudentTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'dashboardadmin
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1264, 681)
        Me.Controls.Add(Me.pnlMain)
        Me.Controls.Add(Me.pnlHeader)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Name = "dashboardadmin"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Admin Dashboard - SIMS"
        Me.pnlHeader.ResumeLayout(False)
        Me.pnlHeader.PerformLayout()
        Me.pnlMain.ResumeLayout(False)
        Me.pnlMain.PerformLayout()
        Me.cardCourses.ResumeLayout(False)
        Me.cardUsers.ResumeLayout(False)
        CType(Me.dgvRecentPayments, System.ComponentModel.ISupportInitialize).EndInit()
        Me.cardPending.ResumeLayout(False)
        Me.cardRevenue.ResumeLayout(False)
        Me.cardStudents.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents pnlHeader As System.Windows.Forms.Panel
    Friend WithEvents lblTitle As System.Windows.Forms.Label
    Friend WithEvents pnlMain As System.Windows.Forms.Panel
    Friend WithEvents cardStudents As System.Windows.Forms.Panel
    Friend WithEvents lblStudentVal As System.Windows.Forms.Label
    Friend WithEvents lblStudentTitle As System.Windows.Forms.Label
    Friend WithEvents cardPending As System.Windows.Forms.Panel
    Friend WithEvents lblPendingVal As System.Windows.Forms.Label
    Friend WithEvents lblPendingTitle As System.Windows.Forms.Label
    Friend WithEvents cardRevenue As System.Windows.Forms.Panel
    Friend WithEvents lblRevenueVal As System.Windows.Forms.Label
    Friend WithEvents lblRevenueTitle As System.Windows.Forms.Label
    Friend WithEvents dgvRecentPayments As System.Windows.Forms.DataGridView
    Friend WithEvents lblGridTitle As System.Windows.Forms.Label
    Friend WithEvents cardUsers As System.Windows.Forms.Panel
    Friend WithEvents lblUserVal As System.Windows.Forms.Label
    Friend WithEvents lblUserTitle As System.Windows.Forms.Label
    Friend WithEvents cardCourses As System.Windows.Forms.Panel
    Friend WithEvents lblCourseVal As System.Windows.Forms.Label
    Friend WithEvents lblCourseTitle As System.Windows.Forms.Label

End Class