<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class enrollmentfrm
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(enrollmentfrm))
        Me.pnlSide = New System.Windows.Forms.Panel()
        Me.lblHeader = New System.Windows.Forms.Label()
        Me.lblS1 = New System.Windows.Forms.Label()
        Me.cmbStudent = New System.Windows.Forms.ComboBox()
        Me.lblS2 = New System.Windows.Forms.Label()
        Me.cmbCourse = New System.Windows.Forms.ComboBox()
        Me.lblS3 = New System.Windows.Forms.Label()
        Me.txtSchoolYear = New System.Windows.Forms.TextBox()
        Me.lblS4 = New System.Windows.Forms.Label()
        Me.cmbSemester = New System.Windows.Forms.ComboBox()
        Me.btnConfirmEnroll = New System.Windows.Forms.Button()
        Me.dgvSchedules = New System.Windows.Forms.DataGridView()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.pnlSide.SuspendLayout()
        CType(Me.dgvSchedules, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'pnlSide
        '
        Me.pnlSide.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.pnlSide.BackColor = System.Drawing.Color.White
        Me.pnlSide.Controls.Add(Me.Label3)
        Me.pnlSide.Controls.Add(Me.lblHeader)
        Me.pnlSide.Controls.Add(Me.lblS1)
        Me.pnlSide.Controls.Add(Me.cmbStudent)
        Me.pnlSide.Controls.Add(Me.lblS2)
        Me.pnlSide.Controls.Add(Me.cmbCourse)
        Me.pnlSide.Controls.Add(Me.lblS3)
        Me.pnlSide.Controls.Add(Me.txtSchoolYear)
        Me.pnlSide.Controls.Add(Me.lblS4)
        Me.pnlSide.Controls.Add(Me.cmbSemester)
        Me.pnlSide.Controls.Add(Me.btnConfirmEnroll)
        Me.pnlSide.Location = New System.Drawing.Point(0, 80)
        Me.pnlSide.Name = "pnlSide"
        Me.pnlSide.Padding = New System.Windows.Forms.Padding(20)
        Me.pnlSide.Size = New System.Drawing.Size(320, 601)
        Me.pnlSide.TabIndex = 1
        '
        'lblHeader
        '
        Me.lblHeader.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold)
        Me.lblHeader.ForeColor = System.Drawing.Color.FromArgb(CType(CType(107, Byte), Integer), CType(CType(26, Byte), Integer), CType(CType(42, Byte), Integer))
        Me.lblHeader.Location = New System.Drawing.Point(20, 20)
        Me.lblHeader.Name = "lblHeader"
        Me.lblHeader.Size = New System.Drawing.Size(280, 26)
        Me.lblHeader.TabIndex = 0
        Me.lblHeader.Text = "New Enrollment"
        '
        'lblS1
        '
        Me.lblS1.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lblS1.ForeColor = System.Drawing.Color.Gray
        Me.lblS1.Location = New System.Drawing.Point(25, 80)
        Me.lblS1.Name = "lblS1"
        Me.lblS1.Size = New System.Drawing.Size(100, 23)
        Me.lblS1.TabIndex = 1
        Me.lblS1.Text = "SELECT STUDENT"
        '
        'cmbStudent
        '
        Me.cmbStudent.BackColor = System.Drawing.Color.FromArgb(CType(CType(253, Byte), Integer), CType(CType(247, Byte), Integer), CType(CType(248, Byte), Integer))
        Me.cmbStudent.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbStudent.Font = New System.Drawing.Font("Segoe UI", 10.5!)
        Me.cmbStudent.Location = New System.Drawing.Point(25, 100)
        Me.cmbStudent.Name = "cmbStudent"
        Me.cmbStudent.Size = New System.Drawing.Size(270, 27)
        Me.cmbStudent.TabIndex = 2
        '
        'lblS2
        '
        Me.lblS2.Font = Me.lblS1.Font
        Me.lblS2.ForeColor = System.Drawing.Color.Gray
        Me.lblS2.Location = New System.Drawing.Point(25, 150)
        Me.lblS2.Name = "lblS2"
        Me.lblS2.Size = New System.Drawing.Size(100, 23)
        Me.lblS2.TabIndex = 3
        Me.lblS2.Text = "SELECT COURSE"
        '
        'cmbCourse
        '
        Me.cmbCourse.BackColor = System.Drawing.Color.FromArgb(CType(CType(253, Byte), Integer), CType(CType(247, Byte), Integer), CType(CType(248, Byte), Integer))
        Me.cmbCourse.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbCourse.Font = Me.cmbStudent.Font
        Me.cmbCourse.Location = New System.Drawing.Point(25, 170)
        Me.cmbCourse.Name = "cmbCourse"
        Me.cmbCourse.Size = New System.Drawing.Size(270, 27)
        Me.cmbCourse.TabIndex = 4
        '
        'lblS3
        '
        Me.lblS3.Font = Me.lblS1.Font
        Me.lblS3.ForeColor = System.Drawing.Color.Gray
        Me.lblS3.Location = New System.Drawing.Point(25, 220)
        Me.lblS3.Name = "lblS3"
        Me.lblS3.Size = New System.Drawing.Size(100, 23)
        Me.lblS3.TabIndex = 5
        Me.lblS3.Text = "SCHOOL YEAR"
        '
        'txtSchoolYear
        '
        Me.txtSchoolYear.BackColor = System.Drawing.Color.FromArgb(CType(CType(253, Byte), Integer), CType(CType(247, Byte), Integer), CType(CType(248, Byte), Integer))
        Me.txtSchoolYear.Font = Me.cmbStudent.Font
        Me.txtSchoolYear.Location = New System.Drawing.Point(25, 240)
        Me.txtSchoolYear.Name = "txtSchoolYear"
        Me.txtSchoolYear.Size = New System.Drawing.Size(270, 26)
        Me.txtSchoolYear.TabIndex = 6
        Me.txtSchoolYear.Text = "2025-2026"
        '
        'lblS4
        '
        Me.lblS4.Font = Me.lblS1.Font
        Me.lblS4.ForeColor = System.Drawing.Color.Gray
        Me.lblS4.Location = New System.Drawing.Point(25, 290)
        Me.lblS4.Name = "lblS4"
        Me.lblS4.Size = New System.Drawing.Size(100, 17)
        Me.lblS4.TabIndex = 7
        Me.lblS4.Text = "SEMESTER"
        '
        'cmbSemester
        '
        Me.cmbSemester.BackColor = System.Drawing.Color.FromArgb(CType(CType(253, Byte), Integer), CType(CType(247, Byte), Integer), CType(CType(248, Byte), Integer))
        Me.cmbSemester.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbSemester.Font = Me.cmbStudent.Font
        Me.cmbSemester.Items.AddRange(New Object() {"1st Semester", "2nd Semester", "Summer"})
        Me.cmbSemester.Location = New System.Drawing.Point(25, 310)
        Me.cmbSemester.Name = "cmbSemester"
        Me.cmbSemester.Size = New System.Drawing.Size(270, 27)
        Me.cmbSemester.TabIndex = 8
        '
        'btnConfirmEnroll
        '
        Me.btnConfirmEnroll.BackColor = System.Drawing.Color.FromArgb(CType(CType(122, Byte), Integer), CType(CType(12, Byte), Integer), CType(CType(34, Byte), Integer))
        Me.btnConfirmEnroll.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(90, Byte), Integer), CType(CType(9, Byte), Integer), CType(CType(24, Byte), Integer))
        Me.btnConfirmEnroll.FlatAppearance.BorderSize = 0
        Me.btnConfirmEnroll.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnConfirmEnroll.Font = New System.Drawing.Font("Segoe UI Semibold", 10.5!)
        Me.btnConfirmEnroll.ForeColor = System.Drawing.Color.White
        Me.btnConfirmEnroll.Location = New System.Drawing.Point(25, 520)
        Me.btnConfirmEnroll.Name = "btnConfirmEnroll"
        Me.btnConfirmEnroll.Size = New System.Drawing.Size(270, 45)
        Me.btnConfirmEnroll.TabIndex = 9
        Me.btnConfirmEnroll.Text = "Confirm Enrollment"
        Me.btnConfirmEnroll.UseVisualStyleBackColor = False
        '
        'dgvSchedules
        '
        Me.dgvSchedules.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvSchedules.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(248, Byte), Integer), CType(CType(242, Byte), Integer), CType(CType(244, Byte), Integer))
        Me.dgvSchedules.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.dgvSchedules.ColumnHeadersHeight = 40
        Me.dgvSchedules.Location = New System.Drawing.Point(324, 119)
        Me.dgvSchedules.Name = "dgvSchedules"
        Me.dgvSchedules.RowTemplate.Height = 35
        Me.dgvSchedules.Size = New System.Drawing.Size(771, 558)
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
        Me.Panel1.TabIndex = 11
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
        Me.Label2.Size = New System.Drawing.Size(330, 15)
        Me.Label2.TabIndex = 11
        Me.Label2.Text = "For official use by the registrar to process student enrollment."
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Segoe UI Semibold", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(68, 18)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(227, 25)
        Me.Label1.TabIndex = 10
        Me.Label1.Text = "Student Enrollment Form"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.FromArgb(CType(CType(107, Byte), Integer), CType(CType(26, Byte), Integer), CType(CType(42, Byte), Integer))
        Me.Label3.Location = New System.Drawing.Point(8, 39)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(295, 15)
        Me.Label3.TabIndex = 21
        Me.Label3.Text = "————————————————————————"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'enrollmentfrm
        '
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(240, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(240, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(1100, 680)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.dgvSchedules)
        Me.Controls.Add(Me.pnlSide)
        Me.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Name = "enrollmentfrm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Student Enrollment System"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.pnlSide.ResumeLayout(False)
        Me.pnlSide.PerformLayout()
        CType(Me.dgvSchedules, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents pnlSide As System.Windows.Forms.Panel
    Friend WithEvents lblHeader As System.Windows.Forms.Label
    Friend WithEvents cmbStudent As System.Windows.Forms.ComboBox
    Friend WithEvents cmbCourse As System.Windows.Forms.ComboBox
    Friend WithEvents txtSchoolYear As System.Windows.Forms.TextBox
    Friend WithEvents cmbSemester As System.Windows.Forms.ComboBox
    Friend WithEvents btnConfirmEnroll As System.Windows.Forms.Button
    Friend WithEvents dgvSchedules As System.Windows.Forms.DataGridView
    Friend WithEvents lblS1 As System.Windows.Forms.Label
    Friend WithEvents lblS2 As System.Windows.Forms.Label
    Friend WithEvents lblS3 As System.Windows.Forms.Label
    Friend WithEvents lblS4 As System.Windows.Forms.Label
    Friend WithEvents Panel1 As Panel
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents Label3 As Label
End Class