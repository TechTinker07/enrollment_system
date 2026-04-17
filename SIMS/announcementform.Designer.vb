<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class announcementform
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

    ' UI Controls
    Friend WithEvents pnlInputContainer As Panel
    Friend WithEvents txtTitle As TextBox
    Friend WithEvents txtMessage As TextBox
    Friend WithEvents cmbRecipient As ComboBox
    Friend WithEvents btnPost As Button
    Friend WithEvents btnClear As Button
    Friend WithEvents dgvAnnouncements As DataGridView
    Friend WithEvents lblTitle As Label
    Friend WithEvents lblMsg As Label
    Friend WithEvents lblTarget As Label

    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(announcementform))
        Me.pnlInputContainer = New System.Windows.Forms.Panel()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.DateTimePicker1 = New System.Windows.Forms.DateTimePicker()
        Me.ComboBox2 = New System.Windows.Forms.ComboBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.ComboBox1 = New System.Windows.Forms.ComboBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.btnClear = New System.Windows.Forms.Button()
        Me.btnPost = New System.Windows.Forms.Button()
        Me.lblMsg = New System.Windows.Forms.Label()
        Me.txtMessage = New System.Windows.Forms.TextBox()
        Me.lblTarget = New System.Windows.Forms.Label()
        Me.cmbRecipient = New System.Windows.Forms.ComboBox()
        Me.lblTitle = New System.Windows.Forms.Label()
        Me.txtTitle = New System.Windows.Forms.TextBox()
        Me.dgvAnnouncements = New System.Windows.Forms.DataGridView()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.pnlPosted = New System.Windows.Forms.Panel()
        Me.lblPostedText = New System.Windows.Forms.Label()
        Me.lblPostedCount = New System.Windows.Forms.Label()
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.pnlUrgent = New System.Windows.Forms.Panel()
        Me.PictureBox4 = New System.Windows.Forms.PictureBox()
        Me.lblUrgentText = New System.Windows.Forms.Label()
        Me.lblUrgentCount = New System.Windows.Forms.Label()
        Me.pnlRecipients = New System.Windows.Forms.Panel()
        Me.PictureBox3 = New System.Windows.Forms.PictureBox()
        Me.lblRecipientsText = New System.Windows.Forms.Label()
        Me.lblRecipientsCount = New System.Windows.Forms.Label()
        Me.Panel5 = New System.Windows.Forms.Panel()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.pnlInputContainer.SuspendLayout()
        CType(Me.dgvAnnouncements, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlPosted.SuspendLayout()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlUrgent.SuspendLayout()
        CType(Me.PictureBox4, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlRecipients.SuspendLayout()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel5.SuspendLayout()
        Me.SuspendLayout()
        '
        'pnlInputContainer
        '
        Me.pnlInputContainer.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pnlInputContainer.BackColor = System.Drawing.Color.FromArgb(CType(CType(252, Byte), Integer), CType(CType(247, Byte), Integer), CType(CType(248, Byte), Integer))
        Me.pnlInputContainer.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.pnlInputContainer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlInputContainer.Controls.Add(Me.Label6)
        Me.pnlInputContainer.Controls.Add(Me.DateTimePicker1)
        Me.pnlInputContainer.Controls.Add(Me.ComboBox2)
        Me.pnlInputContainer.Controls.Add(Me.Label5)
        Me.pnlInputContainer.Controls.Add(Me.ComboBox1)
        Me.pnlInputContainer.Controls.Add(Me.Label4)
        Me.pnlInputContainer.Controls.Add(Me.btnClear)
        Me.pnlInputContainer.Controls.Add(Me.btnPost)
        Me.pnlInputContainer.Controls.Add(Me.lblMsg)
        Me.pnlInputContainer.Controls.Add(Me.txtMessage)
        Me.pnlInputContainer.Controls.Add(Me.lblTarget)
        Me.pnlInputContainer.Controls.Add(Me.cmbRecipient)
        Me.pnlInputContainer.Controls.Add(Me.lblTitle)
        Me.pnlInputContainer.Controls.Add(Me.txtTitle)
        Me.pnlInputContainer.Location = New System.Drawing.Point(24, 239)
        Me.pnlInputContainer.Name = "pnlInputContainer"
        Me.pnlInputContainer.Size = New System.Drawing.Size(1260, 232)
        Me.pnlInputContainer.TabIndex = 0
        '
        'Label6
        '
        Me.Label6.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label6.ForeColor = System.Drawing.Color.FromArgb(CType(CType(107, Byte), Integer), CType(CType(26, Byte), Integer), CType(CType(42, Byte), Integer))
        Me.Label6.Location = New System.Drawing.Point(872, 80)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(150, 20)
        Me.Label6.TabIndex = 13
        Me.Label6.Text = "Valid Until"
        '
        'DateTimePicker1
        '
        Me.DateTimePicker1.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DateTimePicker1.Location = New System.Drawing.Point(872, 105)
        Me.DateTimePicker1.Name = "DateTimePicker1"
        Me.DateTimePicker1.Size = New System.Drawing.Size(300, 25)
        Me.DateTimePicker1.TabIndex = 12
        '
        'ComboBox2
        '
        Me.ComboBox2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBox2.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ComboBox2.Items.AddRange(New Object() {"General", "Academic", "Finance", "Events"})
        Me.ComboBox2.Location = New System.Drawing.Point(470, 105)
        Me.ComboBox2.Name = "ComboBox2"
        Me.ComboBox2.Size = New System.Drawing.Size(320, 25)
        Me.ComboBox2.TabIndex = 11
        '
        'Label5
        '
        Me.Label5.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label5.ForeColor = System.Drawing.Color.FromArgb(CType(CType(107, Byte), Integer), CType(CType(26, Byte), Integer), CType(CType(42, Byte), Integer))
        Me.Label5.Location = New System.Drawing.Point(470, 80)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(150, 20)
        Me.Label5.TabIndex = 10
        Me.Label5.Text = "Category"
        '
        'ComboBox1
        '
        Me.ComboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBox1.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ComboBox1.Items.AddRange(New Object() {"Normal", "Urgent", "Critical"})
        Me.ComboBox1.Location = New System.Drawing.Point(470, 37)
        Me.ComboBox1.Name = "ComboBox1"
        Me.ComboBox1.Size = New System.Drawing.Size(320, 25)
        Me.ComboBox1.TabIndex = 9
        '
        'Label4
        '
        Me.Label4.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label4.ForeColor = System.Drawing.Color.FromArgb(CType(CType(107, Byte), Integer), CType(CType(26, Byte), Integer), CType(CType(42, Byte), Integer))
        Me.Label4.Location = New System.Drawing.Point(470, 15)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(150, 20)
        Me.Label4.TabIndex = 8
        Me.Label4.Text = "Priority"
        '
        'btnClear
        '
        Me.btnClear.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnClear.BackColor = System.Drawing.Color.Transparent
        Me.btnClear.FlatAppearance.BorderSize = 0
        Me.btnClear.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnClear.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.btnClear.ForeColor = System.Drawing.Color.FromArgb(CType(CType(107, Byte), Integer), CType(CType(26, Byte), Integer), CType(CType(42, Byte), Integer))
        Me.btnClear.Location = New System.Drawing.Point(880, 179)
        Me.btnClear.Name = "btnClear"
        Me.btnClear.Size = New System.Drawing.Size(95, 35)
        Me.btnClear.TabIndex = 0
        Me.btnClear.Text = "Clear"
        Me.btnClear.UseVisualStyleBackColor = False
        '
        'btnPost
        '
        Me.btnPost.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnPost.BackColor = System.Drawing.Color.FromArgb(CType(CType(107, Byte), Integer), CType(CType(26, Byte), Integer), CType(CType(42, Byte), Integer))
        Me.btnPost.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnPost.Font = New System.Drawing.Font("Segoe UI Semibold", 10.0!)
        Me.btnPost.ForeColor = System.Drawing.Color.White
        Me.btnPost.Location = New System.Drawing.Point(1056, 179)
        Me.btnPost.Name = "btnPost"
        Me.btnPost.Size = New System.Drawing.Size(116, 35)
        Me.btnPost.TabIndex = 1
        Me.btnPost.Text = "Post Now"
        Me.btnPost.UseVisualStyleBackColor = False
        '
        'lblMsg
        '
        Me.lblMsg.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lblMsg.ForeColor = System.Drawing.Color.FromArgb(CType(CType(107, Byte), Integer), CType(CType(26, Byte), Integer), CType(CType(42, Byte), Integer))
        Me.lblMsg.Location = New System.Drawing.Point(20, 80)
        Me.lblMsg.Name = "lblMsg"
        Me.lblMsg.Size = New System.Drawing.Size(150, 20)
        Me.lblMsg.TabIndex = 2
        Me.lblMsg.Text = "Message Details"
        '
        'txtMessage
        '
        Me.txtMessage.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.txtMessage.Location = New System.Drawing.Point(20, 105)
        Me.txtMessage.Multiline = True
        Me.txtMessage.Name = "txtMessage"
        Me.txtMessage.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtMessage.Size = New System.Drawing.Size(390, 109)
        Me.txtMessage.TabIndex = 3
        '
        'lblTarget
        '
        Me.lblTarget.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lblTarget.ForeColor = System.Drawing.Color.FromArgb(CType(CType(107, Byte), Integer), CType(CType(26, Byte), Integer), CType(CType(42, Byte), Integer))
        Me.lblTarget.Location = New System.Drawing.Point(872, 15)
        Me.lblTarget.Name = "lblTarget"
        Me.lblTarget.Size = New System.Drawing.Size(150, 20)
        Me.lblTarget.TabIndex = 4
        Me.lblTarget.Text = "Send To (Section/Subject)"
        '
        'cmbRecipient
        '
        Me.cmbRecipient.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbRecipient.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbRecipient.Items.AddRange(New Object() {"All Students", "BSIT 1-A", "BSIT 2-B", "CPE 3-C", "Faculty"})
        Me.cmbRecipient.Location = New System.Drawing.Point(872, 37)
        Me.cmbRecipient.Name = "cmbRecipient"
        Me.cmbRecipient.Size = New System.Drawing.Size(300, 25)
        Me.cmbRecipient.TabIndex = 5
        '
        'lblTitle
        '
        Me.lblTitle.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lblTitle.ForeColor = System.Drawing.Color.FromArgb(CType(CType(107, Byte), Integer), CType(CType(26, Byte), Integer), CType(CType(42, Byte), Integer))
        Me.lblTitle.Location = New System.Drawing.Point(20, 15)
        Me.lblTitle.Name = "lblTitle"
        Me.lblTitle.Size = New System.Drawing.Size(150, 20)
        Me.lblTitle.TabIndex = 6
        Me.lblTitle.Text = "Announcement Title"
        '
        'txtTitle
        '
        Me.txtTitle.Font = New System.Drawing.Font("Segoe UI", 11.0!)
        Me.txtTitle.Location = New System.Drawing.Point(20, 37)
        Me.txtTitle.Name = "txtTitle"
        Me.txtTitle.Size = New System.Drawing.Size(390, 27)
        Me.txtTitle.TabIndex = 7
        '
        'dgvAnnouncements
        '
        Me.dgvAnnouncements.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvAnnouncements.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dgvAnnouncements.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(252, Byte), Integer), CType(CType(247, Byte), Integer), CType(CType(248, Byte), Integer))
        Me.dgvAnnouncements.BorderStyle = System.Windows.Forms.BorderStyle.None
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(CType(CType(245, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(234, Byte), Integer))
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        DataGridViewCellStyle1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(122, Byte), Integer), CType(CType(28, Byte), Integer), CType(CType(43, Byte), Integer))
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvAnnouncements.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvAnnouncements.ColumnHeadersHeight = 35
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        DataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvAnnouncements.DefaultCellStyle = DataGridViewCellStyle2
        Me.dgvAnnouncements.EnableHeadersVisualStyles = False
        Me.dgvAnnouncements.Location = New System.Drawing.Point(24, 466)
        Me.dgvAnnouncements.Name = "dgvAnnouncements"
        Me.dgvAnnouncements.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
        Me.dgvAnnouncements.RowHeadersVisible = False
        Me.dgvAnnouncements.Size = New System.Drawing.Size(1260, 220)
        Me.dgvAnnouncements.TabIndex = 0
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
        Me.Panel1.Size = New System.Drawing.Size(1318, 82)
        Me.Panel1.TabIndex = 1
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
        Me.Label2.Size = New System.Drawing.Size(226, 15)
        Me.Label2.TabIndex = 11
        Me.Label2.Text = "Post and manage school announcements"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Segoe UI Semibold", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(68, 18)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(226, 25)
        Me.Label1.TabIndex = 10
        Me.Label1.Text = "Announcement Manager"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'pnlPosted
        '
        Me.pnlPosted.BackColor = System.Drawing.Color.FromArgb(CType(CType(252, Byte), Integer), CType(CType(247, Byte), Integer), CType(CType(248, Byte), Integer))
        Me.pnlPosted.Controls.Add(Me.lblPostedText)
        Me.pnlPosted.Controls.Add(Me.lblPostedCount)
        Me.pnlPosted.Controls.Add(Me.PictureBox2)
        Me.pnlPosted.Location = New System.Drawing.Point(24, 92)
        Me.pnlPosted.Name = "pnlPosted"
        Me.pnlPosted.Size = New System.Drawing.Size(350, 90)
        Me.pnlPosted.TabIndex = 2
        '
        'lblPostedText
        '
        Me.lblPostedText.Font = New System.Drawing.Font("Segoe UI Semibold", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPostedText.ForeColor = System.Drawing.Color.Gray
        Me.lblPostedText.Location = New System.Drawing.Point(145, 58)
        Me.lblPostedText.Name = "lblPostedText"
        Me.lblPostedText.Size = New System.Drawing.Size(150, 20)
        Me.lblPostedText.TabIndex = 17
        Me.lblPostedText.Text = "Total Posted"
        '
        'lblPostedCount
        '
        Me.lblPostedCount.Font = New System.Drawing.Font("Segoe UI Semibold", 20.0!, System.Drawing.FontStyle.Bold)
        Me.lblPostedCount.ForeColor = System.Drawing.Color.FromArgb(CType(CType(107, Byte), Integer), CType(CType(26, Byte), Integer), CType(CType(42, Byte), Integer))
        Me.lblPostedCount.Location = New System.Drawing.Point(166, 20)
        Me.lblPostedCount.Name = "lblPostedCount"
        Me.lblPostedCount.Size = New System.Drawing.Size(49, 35)
        Me.lblPostedCount.TabIndex = 8
        Me.lblPostedCount.Text = "00"
        '
        'PictureBox2
        '
        Me.PictureBox2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.PictureBox2.Image = CType(resources.GetObject("PictureBox2.Image"), System.Drawing.Image)
        Me.PictureBox2.Location = New System.Drawing.Point(108, 26)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(28, 27)
        Me.PictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBox2.TabIndex = 16
        Me.PictureBox2.TabStop = False
        '
        'pnlUrgent
        '
        Me.pnlUrgent.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.pnlUrgent.BackColor = System.Drawing.Color.FromArgb(CType(CType(252, Byte), Integer), CType(CType(247, Byte), Integer), CType(CType(248, Byte), Integer))
        Me.pnlUrgent.Controls.Add(Me.PictureBox4)
        Me.pnlUrgent.Controls.Add(Me.lblUrgentText)
        Me.pnlUrgent.Controls.Add(Me.lblUrgentCount)
        Me.pnlUrgent.Location = New System.Drawing.Point(454, 92)
        Me.pnlUrgent.Name = "pnlUrgent"
        Me.pnlUrgent.Size = New System.Drawing.Size(350, 90)
        Me.pnlUrgent.TabIndex = 3
        '
        'PictureBox4
        '
        Me.PictureBox4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.PictureBox4.Image = CType(resources.GetObject("PictureBox4.Image"), System.Drawing.Image)
        Me.PictureBox4.Location = New System.Drawing.Point(109, 22)
        Me.PictureBox4.Name = "PictureBox4"
        Me.PictureBox4.Size = New System.Drawing.Size(28, 27)
        Me.PictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBox4.TabIndex = 19
        Me.PictureBox4.TabStop = False
        '
        'lblUrgentText
        '
        Me.lblUrgentText.Font = New System.Drawing.Font("Segoe UI Semibold", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblUrgentText.ForeColor = System.Drawing.Color.Gray
        Me.lblUrgentText.Location = New System.Drawing.Point(147, 58)
        Me.lblUrgentText.Name = "lblUrgentText"
        Me.lblUrgentText.Size = New System.Drawing.Size(150, 20)
        Me.lblUrgentText.TabIndex = 19
        Me.lblUrgentText.Text = "Urgent"
        '
        'lblUrgentCount
        '
        Me.lblUrgentCount.Font = New System.Drawing.Font("Segoe UI Semibold", 20.0!, System.Drawing.FontStyle.Bold)
        Me.lblUrgentCount.ForeColor = System.Drawing.Color.FromArgb(CType(CType(107, Byte), Integer), CType(CType(26, Byte), Integer), CType(CType(42, Byte), Integer))
        Me.lblUrgentCount.Location = New System.Drawing.Point(154, 18)
        Me.lblUrgentCount.Name = "lblUrgentCount"
        Me.lblUrgentCount.Size = New System.Drawing.Size(54, 35)
        Me.lblUrgentCount.TabIndex = 18
        Me.lblUrgentCount.Text = "00"
        '
        'pnlRecipients
        '
        Me.pnlRecipients.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pnlRecipients.BackColor = System.Drawing.Color.FromArgb(CType(CType(252, Byte), Integer), CType(CType(247, Byte), Integer), CType(CType(248, Byte), Integer))
        Me.pnlRecipients.Controls.Add(Me.PictureBox3)
        Me.pnlRecipients.Controls.Add(Me.lblRecipientsText)
        Me.pnlRecipients.Controls.Add(Me.lblRecipientsCount)
        Me.pnlRecipients.Location = New System.Drawing.Point(884, 92)
        Me.pnlRecipients.Name = "pnlRecipients"
        Me.pnlRecipients.Size = New System.Drawing.Size(350, 90)
        Me.pnlRecipients.TabIndex = 4
        '
        'PictureBox3
        '
        Me.PictureBox3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.PictureBox3.Image = CType(resources.GetObject("PictureBox3.Image"), System.Drawing.Image)
        Me.PictureBox3.Location = New System.Drawing.Point(108, 26)
        Me.PictureBox3.Name = "PictureBox3"
        Me.PictureBox3.Size = New System.Drawing.Size(28, 27)
        Me.PictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBox3.TabIndex = 18
        Me.PictureBox3.TabStop = False
        '
        'lblRecipientsText
        '
        Me.lblRecipientsText.Font = New System.Drawing.Font("Segoe UI Semibold", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblRecipientsText.ForeColor = System.Drawing.Color.Gray
        Me.lblRecipientsText.Location = New System.Drawing.Point(154, 58)
        Me.lblRecipientsText.Name = "lblRecipientsText"
        Me.lblRecipientsText.Size = New System.Drawing.Size(150, 20)
        Me.lblRecipientsText.TabIndex = 19
        Me.lblRecipientsText.Text = "Recipients"
        '
        'lblRecipientsCount
        '
        Me.lblRecipientsCount.Font = New System.Drawing.Font("Segoe UI Semibold", 20.0!, System.Drawing.FontStyle.Bold)
        Me.lblRecipientsCount.ForeColor = System.Drawing.Color.FromArgb(CType(CType(107, Byte), Integer), CType(CType(26, Byte), Integer), CType(CType(42, Byte), Integer))
        Me.lblRecipientsCount.Location = New System.Drawing.Point(168, 20)
        Me.lblRecipientsCount.Name = "lblRecipientsCount"
        Me.lblRecipientsCount.Size = New System.Drawing.Size(51, 35)
        Me.lblRecipientsCount.TabIndex = 18
        Me.lblRecipientsCount.Text = "00"
        '
        'Panel5
        '
        Me.Panel5.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel5.BackColor = System.Drawing.Color.FromArgb(CType(CType(235, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.Panel5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel5.Controls.Add(Me.Label3)
        Me.Panel5.Location = New System.Drawing.Point(24, 209)
        Me.Panel5.Name = "Panel5"
        Me.Panel5.Size = New System.Drawing.Size(1260, 32)
        Me.Panel5.TabIndex = 18
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Segoe UI", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.FromArgb(CType(CType(107, Byte), Integer), CType(CType(26, Byte), Integer), CType(CType(42, Byte), Integer))
        Me.Label3.Location = New System.Drawing.Point(11, 5)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(185, 20)
        Me.Label3.TabIndex = 16
        Me.Label3.Text = "Composed Announcement"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'announcementform
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(248, Byte), Integer), CType(CType(242, Byte), Integer), CType(CType(244, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(1318, 749)
        Me.Controls.Add(Me.Panel5)
        Me.Controls.Add(Me.pnlRecipients)
        Me.Controls.Add(Me.pnlUrgent)
        Me.Controls.Add(Me.pnlPosted)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.dgvAnnouncements)
        Me.Controls.Add(Me.pnlInputContainer)
        Me.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Name = "announcementform"
        Me.Padding = New System.Windows.Forms.Padding(20)
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Announcement Manager"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.pnlInputContainer.ResumeLayout(False)
        Me.pnlInputContainer.PerformLayout()
        CType(Me.dgvAnnouncements, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlPosted.ResumeLayout(False)
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlUrgent.ResumeLayout(False)
        CType(Me.PictureBox4, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlRecipients.ResumeLayout(False)
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel5.ResumeLayout(False)
        Me.Panel5.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Panel1 As Panel
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents pnlPosted As Panel
    Friend WithEvents pnlUrgent As Panel
    Friend WithEvents pnlRecipients As Panel
    Friend WithEvents lblPostedText As Label
    Friend WithEvents lblPostedCount As Label
    Friend WithEvents PictureBox2 As PictureBox
    Friend WithEvents PictureBox4 As PictureBox
    Friend WithEvents lblUrgentText As Label
    Friend WithEvents lblUrgentCount As Label
    Friend WithEvents PictureBox3 As PictureBox
    Friend WithEvents lblRecipientsText As Label
    Friend WithEvents lblRecipientsCount As Label
    Friend WithEvents Panel5 As Panel
    Friend WithEvents Label3 As Label
    Friend WithEvents ComboBox1 As ComboBox
    Friend WithEvents Label4 As Label
    Friend WithEvents ComboBox2 As ComboBox
    Friend WithEvents Label5 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents DateTimePicker1 As DateTimePicker
End Class
