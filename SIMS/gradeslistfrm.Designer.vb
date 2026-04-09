<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class gradeslistfrm
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.pnlHeader = New System.Windows.Forms.Panel()
        Me.lblTitle = New System.Windows.Forms.Label()
        Me.lblSubTitle = New System.Windows.Forms.Label()
        Me.btnRefresh = New System.Windows.Forms.Button()
        Me.pnlSearchBg = New System.Windows.Forms.Panel()
        Me.txtSearch = New System.Windows.Forms.TextBox()
        Me.lblSearchIcon = New System.Windows.Forms.Label()
        Me.pnlFilter = New System.Windows.Forms.Panel()
        Me.cboSubjectFilter = New System.Windows.Forms.ComboBox()
        Me.lblFilterLabel = New System.Windows.Forms.Label()
        Me.dgvGradesList = New System.Windows.Forms.DataGridView()
        Me.pnlContainer = New System.Windows.Forms.Panel()
        Me.pnlHeader.SuspendLayout()
        Me.pnlSearchBg.SuspendLayout()
        Me.pnlFilter.SuspendLayout()
        CType(Me.dgvGradesList, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlContainer.SuspendLayout()
        Me.SuspendLayout()
        '
        'pnlHeader
        '
        Me.pnlHeader.BackColor = System.Drawing.Color.White
        Me.pnlHeader.Controls.Add(Me.lblTitle)
        Me.pnlHeader.Controls.Add(Me.lblSubTitle)
        Me.pnlHeader.Controls.Add(Me.btnRefresh)
        Me.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlHeader.Location = New System.Drawing.Point(0, 0)
        Me.pnlHeader.Name = "pnlHeader"
        Me.pnlHeader.Size = New System.Drawing.Size(1050, 85)
        Me.pnlHeader.TabIndex = 2
        '
        'lblTitle
        '
        Me.lblTitle.AutoSize = True
        Me.lblTitle.Font = New System.Drawing.Font("Segoe UI Semibold", 18.0!)
        Me.lblTitle.ForeColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(54, Byte), Integer), CType(CType(72, Byte), Integer))
        Me.lblTitle.Location = New System.Drawing.Point(25, 15)
        Me.lblTitle.Name = "lblTitle"
        Me.lblTitle.Size = New System.Drawing.Size(204, 32)
        Me.lblTitle.TabIndex = 0
        Me.lblTitle.Text = "Grades Masterlist"
        '
        'lblSubTitle
        '
        Me.lblSubTitle.AutoSize = True
        Me.lblSubTitle.Font = New System.Drawing.Font("Segoe UI", 9.5!)
        Me.lblSubTitle.ForeColor = System.Drawing.Color.FromArgb(CType(CType(112, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(144, Byte), Integer))
        Me.lblSubTitle.Location = New System.Drawing.Point(27, 48)
        Me.lblSubTitle.Name = "lblSubTitle"
        Me.lblSubTitle.Size = New System.Drawing.Size(297, 17)
        Me.lblSubTitle.TabIndex = 1
        Me.lblSubTitle.Text = "View and manage student academic performance"
        '
        'btnRefresh
        '
        Me.btnRefresh.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(215, Byte), Integer))
        Me.btnRefresh.FlatAppearance.BorderSize = 0
        Me.btnRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnRefresh.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!)
        Me.btnRefresh.ForeColor = System.Drawing.Color.White
        Me.btnRefresh.Location = New System.Drawing.Point(900, 25)
        Me.btnRefresh.Name = "btnRefresh"
        Me.btnRefresh.Size = New System.Drawing.Size(120, 35)
        Me.btnRefresh.TabIndex = 2
        Me.btnRefresh.Text = "Refresh Data"
        Me.btnRefresh.UseVisualStyleBackColor = False
        '
        'pnlSearchBg
        '
        Me.pnlSearchBg.BackColor = System.Drawing.Color.FromArgb(CType(CType(245, Byte), Integer), CType(CType(247, Byte), Integer), CType(CType(251, Byte), Integer))
        Me.pnlSearchBg.Controls.Add(Me.txtSearch)
        Me.pnlSearchBg.Location = New System.Drawing.Point(25, 12)
        Me.pnlSearchBg.Name = "pnlSearchBg"
        Me.pnlSearchBg.Size = New System.Drawing.Size(350, 36)
        Me.pnlSearchBg.TabIndex = 0
        '
        'txtSearch
        '
        Me.txtSearch.BackColor = System.Drawing.Color.FromArgb(CType(CType(245, Byte), Integer), CType(CType(247, Byte), Integer), CType(CType(251, Byte), Integer))
        Me.txtSearch.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtSearch.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.txtSearch.Location = New System.Drawing.Point(15, 9)
        Me.txtSearch.Name = "txtSearch"
        Me.txtSearch.Size = New System.Drawing.Size(320, 18)
        Me.txtSearch.TabIndex = 0
        '
        'lblSearchIcon
        '
        Me.lblSearchIcon.Location = New System.Drawing.Point(0, 0)
        Me.lblSearchIcon.Name = "lblSearchIcon"
        Me.lblSearchIcon.Size = New System.Drawing.Size(100, 23)
        Me.lblSearchIcon.TabIndex = 0
        '
        'pnlFilter
        '
        Me.pnlFilter.BackColor = System.Drawing.Color.White
        Me.pnlFilter.Controls.Add(Me.pnlSearchBg)
        Me.pnlFilter.Controls.Add(Me.cboSubjectFilter)
        Me.pnlFilter.Controls.Add(Me.lblFilterLabel)
        Me.pnlFilter.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlFilter.Location = New System.Drawing.Point(0, 85)
        Me.pnlFilter.Name = "pnlFilter"
        Me.pnlFilter.Padding = New System.Windows.Forms.Padding(25, 10, 25, 10)
        Me.pnlFilter.Size = New System.Drawing.Size(1050, 60)
        Me.pnlFilter.TabIndex = 1
        '
        'cboSubjectFilter
        '
        Me.cboSubjectFilter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboSubjectFilter.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cboSubjectFilter.Location = New System.Drawing.Point(760, 16)
        Me.cboSubjectFilter.Name = "cboSubjectFilter"
        Me.cboSubjectFilter.Size = New System.Drawing.Size(220, 21)
        Me.cboSubjectFilter.TabIndex = 1
        '
        'lblFilterLabel
        '
        Me.lblFilterLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!)
        Me.lblFilterLabel.ForeColor = System.Drawing.Color.FromArgb(CType(CType(112, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(144, Byte), Integer))
        Me.lblFilterLabel.Location = New System.Drawing.Point(650, 22)
        Me.lblFilterLabel.Name = "lblFilterLabel"
        Me.lblFilterLabel.Size = New System.Drawing.Size(100, 23)
        Me.lblFilterLabel.TabIndex = 2
        Me.lblFilterLabel.Text = "FILTER SUBJECT:"
        '
        'dgvGradesList
        '
        Me.dgvGradesList.AllowUserToAddRows = False
        Me.dgvGradesList.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dgvGradesList.BackgroundColor = System.Drawing.Color.White
        Me.dgvGradesList.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.dgvGradesList.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal
        Me.dgvGradesList.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
        Me.dgvGradesList.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvGradesList.ColumnHeadersHeight = 45
        Me.dgvGradesList.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvGradesList.EnableHeadersVisualStyles = False
        Me.dgvGradesList.Location = New System.Drawing.Point(25, 25)
        Me.dgvGradesList.Name = "dgvGradesList"
        Me.dgvGradesList.RowHeadersVisible = False
        Me.dgvGradesList.RowTemplate.Height = 40
        Me.dgvGradesList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvGradesList.Size = New System.Drawing.Size(1000, 505)
        Me.dgvGradesList.TabIndex = 0
        '
        'pnlContainer
        '
        Me.pnlContainer.BackColor = System.Drawing.Color.FromArgb(CType(CType(245, Byte), Integer), CType(CType(247, Byte), Integer), CType(CType(251, Byte), Integer))
        Me.pnlContainer.Controls.Add(Me.dgvGradesList)
        Me.pnlContainer.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlContainer.Location = New System.Drawing.Point(0, 145)
        Me.pnlContainer.Name = "pnlContainer"
        Me.pnlContainer.Padding = New System.Windows.Forms.Padding(25)
        Me.pnlContainer.Size = New System.Drawing.Size(1050, 555)
        Me.pnlContainer.TabIndex = 0
        '
        'gradeslistfrm
        '
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(245, Byte), Integer), CType(CType(247, Byte), Integer), CType(CType(251, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(1050, 700)
        Me.Controls.Add(Me.pnlContainer)
        Me.Controls.Add(Me.pnlFilter)
        Me.Controls.Add(Me.pnlHeader)
        Me.Name = "gradeslistfrm"
        Me.Text = "SIS | Master Grades List"
        Me.pnlHeader.ResumeLayout(False)
        Me.pnlHeader.PerformLayout()
        Me.pnlSearchBg.ResumeLayout(False)
        Me.pnlSearchBg.PerformLayout()
        Me.pnlFilter.ResumeLayout(False)
        CType(Me.dgvGradesList, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlContainer.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents pnlHeader, pnlFilter, pnlContainer, pnlSearchBg As Panel
    Friend WithEvents lblTitle, lblSubTitle, lblFilterLabel, lblSearchIcon As Label
    Friend WithEvents txtSearch As TextBox
    Friend WithEvents cboSubjectFilter As ComboBox
    Friend WithEvents dgvGradesList As DataGridView
    Friend WithEvents btnRefresh As Button
End Class
