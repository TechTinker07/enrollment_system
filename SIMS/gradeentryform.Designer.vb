<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class gradeentryform
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
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

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.pnlSidebar = New System.Windows.Forms.Panel()
        Me.lblTitle = New System.Windows.Forms.Label()
        Me.lblEnrollID = New System.Windows.Forms.Label()
        Me.txtEnrollmentID = New System.Windows.Forms.TextBox()
        Me.lblSubject = New System.Windows.Forms.Label()
        Me.cboSubject = New System.Windows.Forms.ComboBox()
        Me.lblGrade = New System.Windows.Forms.Label()
        Me.txtGrade = New System.Windows.Forms.TextBox()
        Me.lblRemarks = New System.Windows.Forms.Label()
        Me.txtRemarks = New System.Windows.Forms.TextBox()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.btnDelete = New System.Windows.Forms.Button()
        Me.btnClear = New System.Windows.Forms.Button()
        Me.lblSearch = New System.Windows.Forms.Label()
        Me.txtSearch = New System.Windows.Forms.TextBox()
        Me.dgvGrades = New System.Windows.Forms.DataGridView()
        Me.pnlSidebar.SuspendLayout()
        CType(Me.dgvGrades, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'pnlSidebar
        '
        Me.pnlSidebar.BackColor = System.Drawing.Color.White
        Me.pnlSidebar.Controls.Add(Me.lblTitle)
        Me.pnlSidebar.Controls.Add(Me.lblEnrollID)
        Me.pnlSidebar.Controls.Add(Me.txtEnrollmentID)
        Me.pnlSidebar.Controls.Add(Me.lblSubject)
        Me.pnlSidebar.Controls.Add(Me.cboSubject)
        Me.pnlSidebar.Controls.Add(Me.lblGrade)
        Me.pnlSidebar.Controls.Add(Me.txtGrade)
        Me.pnlSidebar.Controls.Add(Me.lblRemarks)
        Me.pnlSidebar.Controls.Add(Me.txtRemarks)
        Me.pnlSidebar.Controls.Add(Me.btnSave)
        Me.pnlSidebar.Controls.Add(Me.btnDelete)
        Me.pnlSidebar.Controls.Add(Me.btnClear)
        Me.pnlSidebar.Dock = System.Windows.Forms.DockStyle.Left
        Me.pnlSidebar.Location = New System.Drawing.Point(0, 0)
        Me.pnlSidebar.Name = "pnlSidebar"
        Me.pnlSidebar.Size = New System.Drawing.Size(280, 600)
        Me.pnlSidebar.TabIndex = 3
        '
        'lblTitle
        '
        Me.lblTitle.Font = New System.Drawing.Font("Segoe UI Semibold", 16.0!)
        Me.lblTitle.Location = New System.Drawing.Point(20, 20)
        Me.lblTitle.Name = "lblTitle"
        Me.lblTitle.Size = New System.Drawing.Size(240, 40)
        Me.lblTitle.TabIndex = 0
        Me.lblTitle.Text = "Grade Management"
        '
        'lblEnrollID
        '
        Me.lblEnrollID.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!)
        Me.lblEnrollID.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lblEnrollID.Location = New System.Drawing.Point(20, 80)
        Me.lblEnrollID.Name = "lblEnrollID"
        Me.lblEnrollID.Size = New System.Drawing.Size(100, 23)
        Me.lblEnrollID.TabIndex = 1
        Me.lblEnrollID.Text = "ENROLLMENT ID"
        '
        'txtEnrollmentID
        '
        Me.txtEnrollmentID.Location = New System.Drawing.Point(20, 98)
        Me.txtEnrollmentID.Name = "txtEnrollmentID"
        Me.txtEnrollmentID.Size = New System.Drawing.Size(240, 20)
        Me.txtEnrollmentID.TabIndex = 2
        '
        'lblSubject
        '
        Me.lblSubject.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!)
        Me.lblSubject.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lblSubject.Location = New System.Drawing.Point(20, 140)
        Me.lblSubject.Name = "lblSubject"
        Me.lblSubject.Size = New System.Drawing.Size(100, 23)
        Me.lblSubject.TabIndex = 3
        Me.lblSubject.Text = "SELECT SUBJECT"
        '
        'cboSubject
        '
        Me.cboSubject.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboSubject.Location = New System.Drawing.Point(20, 158)
        Me.cboSubject.Name = "cboSubject"
        Me.cboSubject.Size = New System.Drawing.Size(240, 21)
        Me.cboSubject.TabIndex = 4
        '
        'lblGrade
        '
        Me.lblGrade.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!)
        Me.lblGrade.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lblGrade.Location = New System.Drawing.Point(20, 200)
        Me.lblGrade.Name = "lblGrade"
        Me.lblGrade.Size = New System.Drawing.Size(100, 23)
        Me.lblGrade.TabIndex = 5
        Me.lblGrade.Text = "NUMERIC GRADE (1.0 - 5.0)"
        '
        'txtGrade
        '
        Me.txtGrade.Location = New System.Drawing.Point(20, 218)
        Me.txtGrade.Name = "txtGrade"
        Me.txtGrade.Size = New System.Drawing.Size(240, 20)
        Me.txtGrade.TabIndex = 6
        '
        'lblRemarks
        '
        Me.lblRemarks.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!)
        Me.lblRemarks.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lblRemarks.Location = New System.Drawing.Point(20, 260)
        Me.lblRemarks.Name = "lblRemarks"
        Me.lblRemarks.Size = New System.Drawing.Size(100, 23)
        Me.lblRemarks.TabIndex = 7
        Me.lblRemarks.Text = "SYSTEM REMARKS"
        '
        'txtRemarks
        '
        Me.txtRemarks.Location = New System.Drawing.Point(20, 278)
        Me.txtRemarks.Name = "txtRemarks"
        Me.txtRemarks.ReadOnly = True
        Me.txtRemarks.Size = New System.Drawing.Size(240, 20)
        Me.txtRemarks.TabIndex = 8
        '
        'btnSave
        '
        Me.btnSave.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(215, Byte), Integer))
        Me.btnSave.FlatAppearance.BorderSize = 0
        Me.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSave.ForeColor = System.Drawing.Color.White
        Me.btnSave.Location = New System.Drawing.Point(20, 330)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(240, 40)
        Me.btnSave.TabIndex = 9
        Me.btnSave.Text = "SAVE GRADE"
        Me.btnSave.UseVisualStyleBackColor = False
        '
        'btnDelete
        '
        Me.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnDelete.ForeColor = System.Drawing.Color.FromArgb(CType(CType(231, Byte), Integer), CType(CType(76, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.btnDelete.Location = New System.Drawing.Point(20, 385)
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.Size = New System.Drawing.Size(115, 30)
        Me.btnDelete.TabIndex = 10
        Me.btnDelete.Text = "Delete"
        '
        'btnClear
        '
        Me.btnClear.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnClear.Location = New System.Drawing.Point(145, 385)
        Me.btnClear.Name = "btnClear"
        Me.btnClear.Size = New System.Drawing.Size(115, 30)
        Me.btnClear.TabIndex = 11
        Me.btnClear.Text = "Clear"
        '
        'lblSearch
        '
        Me.lblSearch.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!)
        Me.lblSearch.Location = New System.Drawing.Point(310, 25)
        Me.lblSearch.Name = "lblSearch"
        Me.lblSearch.Size = New System.Drawing.Size(100, 23)
        Me.lblSearch.TabIndex = 2
        Me.lblSearch.Text = "SEARCH STUDENT OR SUBJECT:"
        '
        'txtSearch
        '
        Me.txtSearch.Location = New System.Drawing.Point(520, 22)
        Me.txtSearch.Name = "txtSearch"
        Me.txtSearch.Size = New System.Drawing.Size(420, 20)
        Me.txtSearch.TabIndex = 1
        '
        'dgvGrades
        '
        Me.dgvGrades.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dgvGrades.BackgroundColor = System.Drawing.Color.White
        Me.dgvGrades.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.dgvGrades.Location = New System.Drawing.Point(310, 75)
        Me.dgvGrades.Name = "dgvGrades"
        Me.dgvGrades.ReadOnly = True
        Me.dgvGrades.RowHeadersVisible = False
        Me.dgvGrades.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvGrades.Size = New System.Drawing.Size(630, 485)
        Me.dgvGrades.TabIndex = 0
        '
        'gradeentryform
        '
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(242, Byte), Integer), CType(CType(245, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(980, 600)
        Me.Controls.Add(Me.dgvGrades)
        Me.Controls.Add(Me.txtSearch)
        Me.Controls.Add(Me.lblSearch)
        Me.Controls.Add(Me.pnlSidebar)
        Me.Name = "gradeentryform"
        Me.pnlSidebar.ResumeLayout(False)
        Me.pnlSidebar.PerformLayout()
        CType(Me.dgvGrades, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    ' Declarations
    Friend WithEvents pnlSidebar As Panel
    Friend WithEvents lblTitle, lblEnrollID, lblSubject, lblGrade, lblRemarks, lblSearch As Label
    Friend WithEvents txtEnrollmentID, txtGrade, txtRemarks, txtSearch As TextBox
    Friend WithEvents cboSubject As ComboBox
    Friend WithEvents btnSave, btnDelete, btnClear As Button
    Friend WithEvents dgvGrades As DataGridView
End Class