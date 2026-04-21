<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Billing
    Inherits System.Windows.Forms.Form

    ' Form overrides dispose to clean up the component list.
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

    ' UI Elements
    Friend WithEvents pnlHeader As Panel
    Friend WithEvents txtSearch As TextBox
    Friend WithEvents btnSearch As Button
    Friend WithEvents dgvBilling As DataGridView
    Friend WithEvents pnlPaymentArea As Panel
    Friend WithEvents lblSelectedStudent As Label
    Friend WithEvents lblBalanceStatus As Label
    Friend WithEvents txtPaymentInput As TextBox
    Friend WithEvents btnPartialPay As Button
    Friend WithEvents btnFullPay As Button
    Friend WithEvents lblInstruction As Label

    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Billing))
        Dim DataGridViewCellStyle13 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle14 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle15 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle16 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle17 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle18 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.pnlHeader = New System.Windows.Forms.Panel()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtSearch = New System.Windows.Forms.TextBox()
        Me.btnSearch = New System.Windows.Forms.Button()
        Me.dgvBilling = New System.Windows.Forms.DataGridView()
        Me.pnlPaymentArea = New System.Windows.Forms.Panel()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.lblStuds = New System.Windows.Forms.Label()
        Me.lblSelectedStudent = New System.Windows.Forms.Label()
        Me.lblBalanceStatus = New System.Windows.Forms.Label()
        Me.txtPaymentInput = New System.Windows.Forms.TextBox()
        Me.btnPartialPay = New System.Windows.Forms.Button()
        Me.btnFullPay = New System.Windows.Forms.Button()
        Me.lblInstruction = New System.Windows.Forms.Label()
        '  Me.dgvPaymentHistory = New System.Windows.Forms.DataGridView()
        Me.pnlHeader.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvBilling, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlPaymentArea.SuspendLayout()
        Me.SuspendLayout()
        '
        'pnlHeader
        '
        Me.pnlHeader.BackColor = System.Drawing.Color.FromArgb(CType(CType(107, Byte), Integer), CType(CType(26, Byte), Integer), CType(CType(42, Byte), Integer))
        Me.pnlHeader.Controls.Add(Me.PictureBox1)
        Me.pnlHeader.Controls.Add(Me.Label2)
        Me.pnlHeader.Controls.Add(Me.Label1)
        Me.pnlHeader.Controls.Add(Me.txtSearch)
        Me.pnlHeader.Controls.Add(Me.btnSearch)
        Me.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlHeader.Location = New System.Drawing.Point(0, 0)
        Me.pnlHeader.Name = "pnlHeader"
        Me.pnlHeader.Size = New System.Drawing.Size(934, 70)
        Me.pnlHeader.TabIndex = 0
        '
        'PictureBox1
        '
        Me.PictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(7, 18)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(28, 27)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBox1.TabIndex = 18
        Me.PictureBox1.TabStop = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Gray
        Me.Label2.Location = New System.Drawing.Point(55, 43)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(178, 15)
        Me.Label2.TabIndex = 17
        Me.Label2.Text = "Student Payment and Collection"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Segoe UI Semibold", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(53, 12)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(185, 25)
        Me.Label1.TabIndex = 16
        Me.Label1.Text = "Billing Management"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'txtSearch
        '
        Me.txtSearch.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtSearch.BackColor = System.Drawing.Color.FromArgb(CType(CType(253, Byte), Integer), CType(CType(236, Byte), Integer), CType(CType(234, Byte), Integer))
        Me.txtSearch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtSearch.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSearch.ForeColor = System.Drawing.Color.Gray
        Me.txtSearch.Location = New System.Drawing.Point(650, 23)
        Me.txtSearch.Name = "txtSearch"
        Me.txtSearch.Size = New System.Drawing.Size(200, 25)
        Me.txtSearch.TabIndex = 1
        Me.txtSearch.Text = "Search student name or ID"
        Me.txtSearch.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'btnSearch
        '
        Me.btnSearch.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnSearch.BackColor = System.Drawing.Color.FromArgb(CType(CType(107, Byte), Integer), CType(CType(26, Byte), Integer), CType(CType(42, Byte), Integer))
        Me.btnSearch.FlatAppearance.BorderSize = 0
        Me.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSearch.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.btnSearch.ForeColor = System.Drawing.Color.White
        Me.btnSearch.Location = New System.Drawing.Point(860, 22)
        Me.btnSearch.Name = "btnSearch"
        Me.btnSearch.Size = New System.Drawing.Size(75, 27)
        Me.btnSearch.TabIndex = 2
        Me.btnSearch.Text = "Search"
        Me.btnSearch.UseVisualStyleBackColor = False
        '
        'dgvBilling
        '
        Me.dgvBilling.AllowUserToAddRows = False
        DataGridViewCellStyle13.ForeColor = System.Drawing.Color.FromArgb(CType(CType(253, Byte), Integer), CType(CType(247, Byte), Integer), CType(CType(248, Byte), Integer))
        Me.dgvBilling.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle13
        Me.dgvBilling.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvBilling.BackgroundColor = System.Drawing.Color.White
        Me.dgvBilling.BorderStyle = System.Windows.Forms.BorderStyle.None
        DataGridViewCellStyle14.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle14.BackColor = System.Drawing.Color.FromArgb(CType(CType(245, Byte), Integer), CType(CType(232, Byte), Integer), CType(CType(235, Byte), Integer))
        DataGridViewCellStyle14.Font = New System.Drawing.Font("Segoe UI", 12.0!)
        DataGridViewCellStyle14.ForeColor = System.Drawing.Color.FromArgb(CType(CType(107, Byte), Integer), CType(CType(26, Byte), Integer), CType(CType(42, Byte), Integer))
        DataGridViewCellStyle14.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle14.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle14.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvBilling.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle14
        Me.dgvBilling.EnableHeadersVisualStyles = False
        Me.dgvBilling.GridColor = System.Drawing.Color.FromArgb(CType(CType(240, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(228, Byte), Integer))
        Me.dgvBilling.Location = New System.Drawing.Point(20, 90)
        Me.dgvBilling.MultiSelect = False
        Me.dgvBilling.Name = "dgvBilling"
        Me.dgvBilling.ReadOnly = True
        DataGridViewCellStyle15.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle15.BackColor = System.Drawing.Color.FromArgb(CType(CType(245, Byte), Integer), CType(CType(232, Byte), Integer), CType(CType(235, Byte), Integer))
        DataGridViewCellStyle15.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        DataGridViewCellStyle15.ForeColor = System.Drawing.Color.FromArgb(CType(CType(61, Byte), Integer), CType(CType(14, Byte), Integer), CType(CType(24, Byte), Integer))
        DataGridViewCellStyle15.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle15.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle15.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvBilling.RowHeadersDefaultCellStyle = DataGridViewCellStyle15
        Me.dgvBilling.RowHeadersVisible = False
        Me.dgvBilling.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvBilling.Size = New System.Drawing.Size(894, 370)
        Me.dgvBilling.TabIndex = 1
        '
        'pnlPaymentArea
        '
        Me.pnlPaymentArea.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pnlPaymentArea.BackColor = System.Drawing.Color.FromArgb(CType(CType(248, Byte), Integer), CType(CType(249, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.pnlPaymentArea.Controls.Add(Me.Label4)
        Me.pnlPaymentArea.Controls.Add(Me.Label3)
        Me.pnlPaymentArea.Controls.Add(Me.lblStuds)
        Me.pnlPaymentArea.Controls.Add(Me.lblSelectedStudent)
        Me.pnlPaymentArea.Controls.Add(Me.lblBalanceStatus)
        Me.pnlPaymentArea.Controls.Add(Me.txtPaymentInput)
        Me.pnlPaymentArea.Controls.Add(Me.btnPartialPay)
        Me.pnlPaymentArea.Controls.Add(Me.btnFullPay)
        Me.pnlPaymentArea.Location = New System.Drawing.Point(20, 475)
        Me.pnlPaymentArea.Name = "pnlPaymentArea"
        Me.pnlPaymentArea.Size = New System.Drawing.Size(894, 180)
        Me.pnlPaymentArea.TabIndex = 2
        '
        'Label4
        '
        Me.Label4.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Segoe UI", 13.0!, System.Drawing.FontStyle.Bold)
        Me.Label4.ForeColor = System.Drawing.Color.FromArgb(CType(CType(198, Byte), Integer), CType(CType(40, Byte), Integer), CType(CType(40, Byte), Integer))
        Me.Label4.Location = New System.Drawing.Point(631, 20)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(121, 25)
        Me.Label4.TabIndex = 7
        Me.Label4.Text = "BALANCE: ₱ "
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.FromArgb(CType(CType(107, Byte), Integer), CType(CType(26, Byte), Integer), CType(CType(42, Byte), Integer))
        Me.Label3.Location = New System.Drawing.Point(38, 60)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(167, 17)
        Me.Label3.TabIndex = 6
        Me.Label3.Text = "ENTER PAYMENT AMOUNT"
        '
        'lblStuds
        '
        Me.lblStuds.AutoSize = True
        Me.lblStuds.Font = New System.Drawing.Font("Segoe UI Semibold", 11.0!)
        Me.lblStuds.ForeColor = System.Drawing.Color.FromArgb(CType(CType(61, Byte), Integer), CType(CType(14, Byte), Integer), CType(CType(24, Byte), Integer))
        Me.lblStuds.Location = New System.Drawing.Point(38, 20)
        Me.lblStuds.Name = "lblStuds"
        Me.lblStuds.Size = New System.Drawing.Size(83, 20)
        Me.lblStuds.TabIndex = 5
        Me.lblStuds.Text = "STUDENT: "
        '
        'lblSelectedStudent
        '
        Me.lblSelectedStudent.AutoSize = True
        Me.lblSelectedStudent.Font = New System.Drawing.Font("Segoe UI Semibold", 11.0!)
        Me.lblSelectedStudent.ForeColor = System.Drawing.Color.FromArgb(CType(CType(61, Byte), Integer), CType(CType(14, Byte), Integer), CType(CType(24, Byte), Integer))
        Me.lblSelectedStudent.Location = New System.Drawing.Point(127, 20)
        Me.lblSelectedStudent.Name = "lblSelectedStudent"
        Me.lblSelectedStudent.Size = New System.Drawing.Size(37, 20)
        Me.lblSelectedStudent.TabIndex = 0
        Me.lblSelectedStudent.Text = " ----"
        '
        'lblBalanceStatus
        '
        Me.lblBalanceStatus.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblBalanceStatus.AutoSize = True
        Me.lblBalanceStatus.Font = New System.Drawing.Font("Segoe UI", 13.0!, System.Drawing.FontStyle.Bold)
        Me.lblBalanceStatus.ForeColor = System.Drawing.Color.FromArgb(CType(CType(198, Byte), Integer), CType(CType(40, Byte), Integer), CType(CType(40, Byte), Integer))
        Me.lblBalanceStatus.Location = New System.Drawing.Point(748, 20)
        Me.lblBalanceStatus.Name = "lblBalanceStatus"
        Me.lblBalanceStatus.Size = New System.Drawing.Size(52, 25)
        Me.lblBalanceStatus.TabIndex = 1
        Me.lblBalanceStatus.Text = " 0.00"
        '
        'txtPaymentInput
        '
        Me.txtPaymentInput.Font = New System.Drawing.Font("Segoe UI Semibold", 12.0!, System.Drawing.FontStyle.Bold)
        Me.txtPaymentInput.ForeColor = System.Drawing.Color.Black
        Me.txtPaymentInput.Location = New System.Drawing.Point(39, 91)
        Me.txtPaymentInput.Name = "txtPaymentInput"
        Me.txtPaymentInput.Size = New System.Drawing.Size(310, 29)
        Me.txtPaymentInput.TabIndex = 2
        '
        'btnPartialPay
        '
        Me.btnPartialPay.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnPartialPay.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(248, Byte), Integer), CType(CType(225, Byte), Integer))
        Me.btnPartialPay.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(130, Byte), Integer))
        Me.btnPartialPay.ForeColor = System.Drawing.Color.FromArgb(CType(CType(180, Byte), Integer), CType(CType(83, Byte), Integer), CType(CType(9, Byte), Integer))
        Me.btnPartialPay.Location = New System.Drawing.Point(634, 81)
        Me.btnPartialPay.Name = "btnPartialPay"
        Me.btnPartialPay.Size = New System.Drawing.Size(120, 40)
        Me.btnPartialPay.TabIndex = 3
        Me.btnPartialPay.Text = "PARTIAL"
        Me.btnPartialPay.UseVisualStyleBackColor = False
        '
        'btnFullPay
        '
        Me.btnFullPay.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnFullPay.BackColor = System.Drawing.Color.FromArgb(CType(CType(232, Byte), Integer), CType(CType(245, Byte), Integer), CType(CType(233, Byte), Integer))
        Me.btnFullPay.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(200, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(201, Byte), Integer))
        Me.btnFullPay.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnFullPay.ForeColor = System.Drawing.Color.FromArgb(CType(CType(46, Byte), Integer), CType(CType(125, Byte), Integer), CType(CType(50, Byte), Integer))
        Me.btnFullPay.Location = New System.Drawing.Point(764, 81)
        Me.btnFullPay.Name = "btnFullPay"
        Me.btnFullPay.Size = New System.Drawing.Size(120, 40)
        Me.btnFullPay.TabIndex = 4
        Me.btnFullPay.Text = "FULL"
        Me.btnFullPay.UseVisualStyleBackColor = False
        '
        'lblInstruction
        '
        Me.lblInstruction.Location = New System.Drawing.Point(0, 0)
        Me.lblInstruction.Name = "lblInstruction"
        Me.lblInstruction.Size = New System.Drawing.Size(100, 23)
        Me.lblInstruction.TabIndex = 0
        '
        'Billing
        '
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(248, Byte), Integer), CType(CType(249, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(934, 698)
        Me.Controls.Add(Me.pnlHeader)
        Me.Controls.Add(Me.dgvBilling)
        Me.Controls.Add(Me.pnlPaymentArea)
        Me.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.Name = "Billing"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "SIMS - Billing & Collection"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.pnlHeader.ResumeLayout(False)
        Me.pnlHeader.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvBilling, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlPaymentArea.ResumeLayout(False)
        Me.pnlPaymentArea.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents lblStuds As Label
    Friend WithEvents Label4 As Label
End Class
