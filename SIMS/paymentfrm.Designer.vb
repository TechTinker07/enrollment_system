<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class paymentfrm
    Inherits System.Windows.Forms.Form

    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then components.Dispose()
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    Private components As System.ComponentModel.IContainer

    ' UI Controls
    Friend WithEvents pnlHeader As Panel
    Friend WithEvents txtSearchStudent As TextBox
    Friend WithEvents btnFindBill As Button
    Friend WithEvents dgvBills As DataGridView
    Friend WithEvents grpPayment As GroupBox
    Friend WithEvents lblBillID As Label
    Friend WithEvents lblStudentName As Label
    Friend WithEvents lblCurrentBalance As Label
    Friend WithEvents txtAmountToPay As TextBox
    Friend WithEvents txtReferenceNo As TextBox
    Friend WithEvents btnProcessPayment As Button
    Friend WithEvents lblRefLabel As Label
    Friend WithEvents lblAmtLabel As Label

    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(paymentfrm))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.pnlHeader = New System.Windows.Forms.Panel()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtSearchStudent = New System.Windows.Forms.TextBox()
        Me.btnFindBill = New System.Windows.Forms.Button()
        Me.dgvBills = New System.Windows.Forms.DataGridView()
        Me.grpPayment = New System.Windows.Forms.GroupBox()
        Me.lblcurrentbalholder = New System.Windows.Forms.Label()
        Me.lblholdrnmae = New System.Windows.Forms.Label()
        Me.lblidname = New System.Windows.Forms.Label()
        Me.lblBillID = New System.Windows.Forms.Label()
        Me.lblStudentName = New System.Windows.Forms.Label()
        Me.lblCurrentBalance = New System.Windows.Forms.Label()
        Me.lblAmtLabel = New System.Windows.Forms.Label()
        Me.txtAmountToPay = New System.Windows.Forms.TextBox()
        Me.lblRefLabel = New System.Windows.Forms.Label()
        Me.txtReferenceNo = New System.Windows.Forms.TextBox()
        Me.btnProcessPayment = New System.Windows.Forms.Button()
        Me.pnlHeader.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvBills, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grpPayment.SuspendLayout()
        Me.SuspendLayout()
        '
        'pnlHeader
        '
        Me.pnlHeader.BackColor = System.Drawing.Color.FromArgb(CType(CType(107, Byte), Integer), CType(CType(26, Byte), Integer), CType(CType(42, Byte), Integer))
        Me.pnlHeader.Controls.Add(Me.PictureBox1)
        Me.pnlHeader.Controls.Add(Me.Label1)
        Me.pnlHeader.Controls.Add(Me.Label3)
        Me.pnlHeader.Controls.Add(Me.txtSearchStudent)
        Me.pnlHeader.Controls.Add(Me.btnFindBill)
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
        Me.PictureBox1.TabIndex = 21
        Me.PictureBox1.TabStop = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Gray
        Me.Label1.Location = New System.Drawing.Point(55, 43)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(158, 15)
        Me.Label1.TabIndex = 20
        Me.Label1.Text = "Fee Payment and Processing"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Segoe UI Semibold", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.White
        Me.Label3.Location = New System.Drawing.Point(53, 12)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(189, 25)
        Me.Label3.TabIndex = 19
        Me.Label3.Text = "Payment Transaction"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'txtSearchStudent
        '
        Me.txtSearchStudent.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtSearchStudent.BackColor = System.Drawing.Color.FromArgb(CType(CType(253, Byte), Integer), CType(CType(236, Byte), Integer), CType(CType(234, Byte), Integer))
        Me.txtSearchStudent.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtSearchStudent.Font = New System.Drawing.Font("Segoe UI", 9.75!)
        Me.txtSearchStudent.ForeColor = System.Drawing.Color.Gray
        Me.txtSearchStudent.Location = New System.Drawing.Point(597, 23)
        Me.txtSearchStudent.Name = "txtSearchStudent"
        Me.txtSearchStudent.Size = New System.Drawing.Size(200, 25)
        Me.txtSearchStudent.TabIndex = 1
        Me.txtSearchStudent.Text = "Search student name or ID"
        Me.txtSearchStudent.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'btnFindBill
        '
        Me.btnFindBill.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnFindBill.FlatAppearance.BorderSize = 0
        Me.btnFindBill.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnFindBill.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.btnFindBill.ForeColor = System.Drawing.Color.White
        Me.btnFindBill.Location = New System.Drawing.Point(807, 22)
        Me.btnFindBill.Name = "btnFindBill"
        Me.btnFindBill.Size = New System.Drawing.Size(100, 30)
        Me.btnFindBill.TabIndex = 2
        Me.btnFindBill.Text = "Search Bill"
        '
        'dgvBills
        '
        Me.dgvBills.AllowUserToAddRows = False
        DataGridViewCellStyle1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(253, Byte), Integer), CType(CType(247, Byte), Integer), CType(CType(248, Byte), Integer))
        Me.dgvBills.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvBills.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvBills.BackgroundColor = System.Drawing.Color.White
        Me.dgvBills.BorderStyle = System.Windows.Forms.BorderStyle.None
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(CType(CType(245, Byte), Integer), CType(CType(232, Byte), Integer), CType(CType(235, Byte), Integer))
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        DataGridViewCellStyle2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(107, Byte), Integer), CType(CType(26, Byte), Integer), CType(CType(42, Byte), Integer))
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvBills.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.dgvBills.EnableHeadersVisualStyles = False
        Me.dgvBills.GridColor = System.Drawing.Color.FromArgb(CType(CType(240, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(228, Byte), Integer))
        Me.dgvBills.Location = New System.Drawing.Point(20, 90)
        Me.dgvBills.MultiSelect = False
        Me.dgvBills.Name = "dgvBills"
        Me.dgvBills.ReadOnly = True
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(CType(CType(245, Byte), Integer), CType(CType(232, Byte), Integer), CType(CType(235, Byte), Integer))
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        DataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(CType(CType(61, Byte), Integer), CType(CType(14, Byte), Integer), CType(CType(24, Byte), Integer))
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvBills.RowHeadersDefaultCellStyle = DataGridViewCellStyle3
        Me.dgvBills.RowHeadersVisible = False
        Me.dgvBills.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvBills.Size = New System.Drawing.Size(894, 324)
        Me.dgvBills.TabIndex = 1
        '
        'grpPayment
        '
        Me.grpPayment.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grpPayment.BackColor = System.Drawing.Color.FromArgb(CType(CType(248, Byte), Integer), CType(CType(249, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.grpPayment.Controls.Add(Me.lblcurrentbalholder)
        Me.grpPayment.Controls.Add(Me.lblholdrnmae)
        Me.grpPayment.Controls.Add(Me.lblidname)
        Me.grpPayment.Controls.Add(Me.lblBillID)
        Me.grpPayment.Controls.Add(Me.lblStudentName)
        Me.grpPayment.Controls.Add(Me.lblCurrentBalance)
        Me.grpPayment.Controls.Add(Me.lblAmtLabel)
        Me.grpPayment.Controls.Add(Me.txtAmountToPay)
        Me.grpPayment.Controls.Add(Me.lblRefLabel)
        Me.grpPayment.Controls.Add(Me.txtReferenceNo)
        Me.grpPayment.Controls.Add(Me.btnProcessPayment)
        Me.grpPayment.ForeColor = System.Drawing.Color.FromArgb(CType(CType(61, Byte), Integer), CType(CType(14, Byte), Integer), CType(CType(24, Byte), Integer))
        Me.grpPayment.Location = New System.Drawing.Point(20, 433)
        Me.grpPayment.Name = "grpPayment"
        Me.grpPayment.Padding = New System.Windows.Forms.Padding(0)
        Me.grpPayment.Size = New System.Drawing.Size(894, 183)
        Me.grpPayment.TabIndex = 4
        Me.grpPayment.TabStop = False
        Me.grpPayment.Text = "Payment Details"
        '
        'lblcurrentbalholder
        '
        Me.lblcurrentbalholder.Font = New System.Drawing.Font("Segoe UI", 9.75!)
        Me.lblcurrentbalholder.ForeColor = System.Drawing.Color.FromArgb(CType(CType(107, Byte), Integer), CType(CType(26, Byte), Integer), CType(CType(42, Byte), Integer))
        Me.lblcurrentbalholder.Location = New System.Drawing.Point(49, 96)
        Me.lblcurrentbalholder.Name = "lblcurrentbalholder"
        Me.lblcurrentbalholder.Size = New System.Drawing.Size(130, 23)
        Me.lblcurrentbalholder.TabIndex = 10
        Me.lblcurrentbalholder.Text = "CURRENT BALANCE:"
        '
        'lblholdrnmae
        '
        Me.lblholdrnmae.Font = New System.Drawing.Font("Segoe UI", 9.75!)
        Me.lblholdrnmae.ForeColor = System.Drawing.Color.FromArgb(CType(CType(107, Byte), Integer), CType(CType(26, Byte), Integer), CType(CType(42, Byte), Integer))
        Me.lblholdrnmae.Location = New System.Drawing.Point(49, 64)
        Me.lblholdrnmae.Name = "lblholdrnmae"
        Me.lblholdrnmae.Size = New System.Drawing.Size(79, 23)
        Me.lblholdrnmae.TabIndex = 9
        Me.lblholdrnmae.Text = "STUDENT: "
        '
        'lblidname
        '
        Me.lblidname.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblidname.ForeColor = System.Drawing.Color.FromArgb(CType(CType(107, Byte), Integer), CType(CType(26, Byte), Integer), CType(CType(42, Byte), Integer))
        Me.lblidname.Location = New System.Drawing.Point(49, 35)
        Me.lblidname.Name = "lblidname"
        Me.lblidname.Size = New System.Drawing.Size(79, 23)
        Me.lblidname.TabIndex = 8
        Me.lblidname.Text = "BILLING ID: "
        '
        'lblBillID
        '
        Me.lblBillID.Font = New System.Drawing.Font("Segoe UI Semibold", 10.0!, System.Drawing.FontStyle.Bold)
        Me.lblBillID.Location = New System.Drawing.Point(134, 35)
        Me.lblBillID.Name = "lblBillID"
        Me.lblBillID.Size = New System.Drawing.Size(78, 23)
        Me.lblBillID.TabIndex = 0
        Me.lblBillID.Text = "------"
        '
        'lblStudentName
        '
        Me.lblStudentName.Font = New System.Drawing.Font("Segoe UI Semibold", 10.0!, System.Drawing.FontStyle.Bold)
        Me.lblStudentName.Location = New System.Drawing.Point(133, 63)
        Me.lblStudentName.Name = "lblStudentName"
        Me.lblStudentName.Size = New System.Drawing.Size(79, 23)
        Me.lblStudentName.TabIndex = 1
        Me.lblStudentName.Text = "-----"
        '
        'lblCurrentBalance
        '
        Me.lblCurrentBalance.Font = New System.Drawing.Font("Segoe UI Semibold", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCurrentBalance.ForeColor = System.Drawing.Color.Red
        Me.lblCurrentBalance.Location = New System.Drawing.Point(53, 126)
        Me.lblCurrentBalance.Name = "lblCurrentBalance"
        Me.lblCurrentBalance.Size = New System.Drawing.Size(100, 23)
        Me.lblCurrentBalance.TabIndex = 2
        Me.lblCurrentBalance.Text = "0.00"
        '
        'lblAmtLabel
        '
        Me.lblAmtLabel.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblAmtLabel.Font = New System.Drawing.Font("Segoe UI", 9.75!)
        Me.lblAmtLabel.ForeColor = System.Drawing.Color.FromArgb(CType(CType(107, Byte), Integer), CType(CType(26, Byte), Integer), CType(CType(42, Byte), Integer))
        Me.lblAmtLabel.Location = New System.Drawing.Point(400, 35)
        Me.lblAmtLabel.Name = "lblAmtLabel"
        Me.lblAmtLabel.Size = New System.Drawing.Size(118, 23)
        Me.lblAmtLabel.TabIndex = 3
        Me.lblAmtLabel.Text = "AMOUNT TO PAY: "
        '
        'txtAmountToPay
        '
        Me.txtAmountToPay.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtAmountToPay.Font = New System.Drawing.Font("Segoe UI Semibold", 12.0!, System.Drawing.FontStyle.Bold)
        Me.txtAmountToPay.Location = New System.Drawing.Point(400, 55)
        Me.txtAmountToPay.Name = "txtAmountToPay"
        Me.txtAmountToPay.Size = New System.Drawing.Size(200, 29)
        Me.txtAmountToPay.TabIndex = 4
        '
        'lblRefLabel
        '
        Me.lblRefLabel.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblRefLabel.Font = New System.Drawing.Font("Segoe UI", 9.75!)
        Me.lblRefLabel.ForeColor = System.Drawing.Color.FromArgb(CType(CType(107, Byte), Integer), CType(CType(26, Byte), Integer), CType(CType(42, Byte), Integer))
        Me.lblRefLabel.Location = New System.Drawing.Point(400, 100)
        Me.lblRefLabel.Name = "lblRefLabel"
        Me.lblRefLabel.Size = New System.Drawing.Size(150, 23)
        Me.lblRefLabel.TabIndex = 5
        Me.lblRefLabel.Text = "REFERENCE NO (OR#):"
        '
        'txtReferenceNo
        '
        Me.txtReferenceNo.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtReferenceNo.Font = New System.Drawing.Font("Segoe UI Semibold", 12.0!, System.Drawing.FontStyle.Bold)
        Me.txtReferenceNo.Location = New System.Drawing.Point(400, 120)
        Me.txtReferenceNo.Name = "txtReferenceNo"
        Me.txtReferenceNo.Size = New System.Drawing.Size(200, 29)
        Me.txtReferenceNo.TabIndex = 6
        '
        'btnProcessPayment
        '
        Me.btnProcessPayment.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnProcessPayment.BackColor = System.Drawing.Color.FromArgb(CType(CType(232, Byte), Integer), CType(CType(245, Byte), Integer), CType(CType(233, Byte), Integer))
        Me.btnProcessPayment.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(200, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(201, Byte), Integer))
        Me.btnProcessPayment.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnProcessPayment.ForeColor = System.Drawing.Color.FromArgb(CType(CType(46, Byte), Integer), CType(CType(125, Byte), Integer), CType(CType(50, Byte), Integer))
        Me.btnProcessPayment.Location = New System.Drawing.Point(660, 85)
        Me.btnProcessPayment.Name = "btnProcessPayment"
        Me.btnProcessPayment.Size = New System.Drawing.Size(161, 64)
        Me.btnProcessPayment.TabIndex = 7
        Me.btnProcessPayment.Text = "CONFIRM PAYMENT"
        Me.btnProcessPayment.UseVisualStyleBackColor = False
        '
        'paymentfrm
        '
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(934, 698)
        Me.Controls.Add(Me.pnlHeader)
        Me.Controls.Add(Me.dgvBills)
        Me.Controls.Add(Me.grpPayment)
        Me.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Name = "paymentfrm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "SIMS - Process Payment"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.pnlHeader.ResumeLayout(False)
        Me.pnlHeader.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvBills, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grpPayment.ResumeLayout(False)
        Me.grpPayment.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents lblidname As Label
    Friend WithEvents lblholdrnmae As Label
    Friend WithEvents lblcurrentbalholder As Label
End Class