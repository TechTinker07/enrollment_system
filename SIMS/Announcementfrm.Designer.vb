<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Announcementfrm
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.pnlHeader = New System.Windows.Forms.Panel()
        Me.lblTitle = New System.Windows.Forms.Label()
        Me.lblHeaderSub = New System.Windows.Forms.Label()
        Me.pnlStatPosted = New System.Windows.Forms.Panel()
        Me.lblPostedCaption = New System.Windows.Forms.Label()
        Me.lblPostedCount = New System.Windows.Forms.Label()
        Me.pnlStatUrgent = New System.Windows.Forms.Panel()
        Me.lblUrgentCaption = New System.Windows.Forms.Label()
        Me.lblUrgentCount = New System.Windows.Forms.Label()
        Me.pnlStatRecipients = New System.Windows.Forms.Panel()
        Me.lblRecipientCaption = New System.Windows.Forms.Label()
        Me.lblRecipientCount = New System.Windows.Forms.Label()
        Me.pnlCompose = New System.Windows.Forms.Panel()
        Me.lblComposeHeader = New System.Windows.Forms.Label()
        Me.lblSectionFooter = New System.Windows.Forms.Label()
        Me.txtAnnouncementTitle = New System.Windows.Forms.TextBox()
        Me.txtContent = New System.Windows.Forms.TextBox()
        Me.btnPost = New System.Windows.Forms.Button()
        Me.btnClear = New System.Windows.Forms.Button()
        Me.pnlList = New System.Windows.Forms.Panel()
        Me.lblPostedHeader = New System.Windows.Forms.Label()
        Me.txtSearch = New System.Windows.Forms.TextBox()
        Me.dgvAnnouncements = New System.Windows.Forms.DataGridView()
        Me.lblSubTitle1 = New System.Windows.Forms.Label()
        Me.lblSubTitle2 = New System.Windows.Forms.Label()
        Me.pnlHeader.SuspendLayout()
        Me.pnlStatPosted.SuspendLayout()
        Me.pnlStatUrgent.SuspendLayout()
        Me.pnlStatRecipients.SuspendLayout()
        Me.pnlCompose.SuspendLayout()
        Me.pnlList.SuspendLayout()
        CType(Me.dgvAnnouncements, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'pnlHeader
        '
        Me.pnlHeader.BackColor = System.Drawing.Color.FromArgb(CType(CType(122, Byte), Integer), CType(CType(28, Byte), Integer), CType(CType(43, Byte), Integer))
        Me.pnlHeader.Controls.Add(Me.lblHeaderSub)
        Me.pnlHeader.Controls.Add(Me.lblTitle)
        Me.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlHeader.Location = New System.Drawing.Point(0, 0)
        Me.pnlHeader.Name = "pnlHeader"
        Me.pnlHeader.Size = New System.Drawing.Size(1200, 82)
        Me.pnlHeader.TabIndex = 0
        '
        'lblTitle
        '
        Me.lblTitle.AutoSize = True
        Me.lblTitle.Font = New System.Drawing.Font("Segoe UI Semibold", 18.0!)
        Me.lblTitle.ForeColor = System.Drawing.Color.White
        Me.lblTitle.Location = New System.Drawing.Point(24, 12)
        Me.lblTitle.Name = "lblTitle"
        Me.lblTitle.Size = New System.Drawing.Size(286, 32)
        Me.lblTitle.TabIndex = 0
        Me.lblTitle.Text = "Announcement Manager"
        '
        'lblHeaderSub
        '
        Me.lblHeaderSub.AutoSize = True
        Me.lblHeaderSub.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.lblHeaderSub.ForeColor = System.Drawing.Color.FromArgb(CType(CType(237, Byte), Integer), CType(CType(214, Byte), Integer), CType(CType(219, Byte), Integer))
        Me.lblHeaderSub.Location = New System.Drawing.Point(27, 47)
        Me.lblHeaderSub.Name = "lblHeaderSub"
        Me.lblHeaderSub.Size = New System.Drawing.Size(234, 19)
        Me.lblHeaderSub.TabIndex = 1
        Me.lblHeaderSub.Text = "Post and manage school announcements"
        '
        'pnlStatPosted
        '
        Me.pnlStatPosted.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pnlStatPosted.BackColor = System.Drawing.Color.White
        Me.pnlStatPosted.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlStatPosted.Controls.Add(Me.lblPostedCaption)
        Me.pnlStatPosted.Controls.Add(Me.lblPostedCount)
        Me.pnlStatPosted.Location = New System.Drawing.Point(22, 101)
        Me.pnlStatPosted.Name = "pnlStatPosted"
        Me.pnlStatPosted.Size = New System.Drawing.Size(364, 86)
        Me.pnlStatPosted.TabIndex = 1
        '
        'lblPostedCaption
        '
        Me.lblPostedCaption.AutoSize = True
        Me.lblPostedCaption.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.lblPostedCaption.ForeColor = System.Drawing.Color.DimGray
        Me.lblPostedCaption.Location = New System.Drawing.Point(20, 49)
        Me.lblPostedCaption.Name = "lblPostedCaption"
        Me.lblPostedCaption.Size = New System.Drawing.Size(76, 19)
        Me.lblPostedCaption.TabIndex = 1
        Me.lblPostedCaption.Text = "Total Posted"
        '
        'lblPostedCount
        '
        Me.lblPostedCount.AutoSize = True
        Me.lblPostedCount.Font = New System.Drawing.Font("Segoe UI", 18.0!, System.Drawing.FontStyle.Bold)
        Me.lblPostedCount.ForeColor = System.Drawing.Color.FromArgb(CType(CType(122, Byte), Integer), CType(CType(28, Byte), Integer), CType(CType(43, Byte), Integer))
        Me.lblPostedCount.Location = New System.Drawing.Point(18, 14)
        Me.lblPostedCount.Name = "lblPostedCount"
        Me.lblPostedCount.Size = New System.Drawing.Size(44, 32)
        Me.lblPostedCount.TabIndex = 0
        Me.lblPostedCount.Text = "00"
        '
        'pnlStatUrgent
        '
        Me.pnlStatUrgent.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pnlStatUrgent.BackColor = System.Drawing.Color.White
        Me.pnlStatUrgent.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlStatUrgent.Controls.Add(Me.lblUrgentCaption)
        Me.pnlStatUrgent.Controls.Add(Me.lblUrgentCount)
        Me.pnlStatUrgent.Location = New System.Drawing.Point(412, 101)
        Me.pnlStatUrgent.Name = "pnlStatUrgent"
        Me.pnlStatUrgent.Size = New System.Drawing.Size(364, 86)
        Me.pnlStatUrgent.TabIndex = 2
        '
        'lblUrgentCaption
        '
        Me.lblUrgentCaption.AutoSize = True
        Me.lblUrgentCaption.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.lblUrgentCaption.ForeColor = System.Drawing.Color.DimGray
        Me.lblUrgentCaption.Location = New System.Drawing.Point(20, 49)
        Me.lblUrgentCaption.Name = "lblUrgentCaption"
        Me.lblUrgentCaption.Size = New System.Drawing.Size(48, 19)
        Me.lblUrgentCaption.TabIndex = 1
        Me.lblUrgentCaption.Text = "Urgent"
        '
        'lblUrgentCount
        '
        Me.lblUrgentCount.AutoSize = True
        Me.lblUrgentCount.Font = New System.Drawing.Font("Segoe UI", 18.0!, System.Drawing.FontStyle.Bold)
        Me.lblUrgentCount.ForeColor = System.Drawing.Color.FromArgb(CType(CType(122, Byte), Integer), CType(CType(28, Byte), Integer), CType(CType(43, Byte), Integer))
        Me.lblUrgentCount.Location = New System.Drawing.Point(18, 14)
        Me.lblUrgentCount.Name = "lblUrgentCount"
        Me.lblUrgentCount.Size = New System.Drawing.Size(44, 32)
        Me.lblUrgentCount.TabIndex = 0
        Me.lblUrgentCount.Text = "00"
        '
        'pnlStatRecipients
        '
        Me.pnlStatRecipients.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pnlStatRecipients.BackColor = System.Drawing.Color.White
        Me.pnlStatRecipients.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlStatRecipients.Controls.Add(Me.lblRecipientCaption)
        Me.pnlStatRecipients.Controls.Add(Me.lblRecipientCount)
        Me.pnlStatRecipients.Location = New System.Drawing.Point(802, 101)
        Me.pnlStatRecipients.Name = "pnlStatRecipients"
        Me.pnlStatRecipients.Size = New System.Drawing.Size(364, 86)
        Me.pnlStatRecipients.TabIndex = 3
        '
        'lblRecipientCaption
        '
        Me.lblRecipientCaption.AutoSize = True
        Me.lblRecipientCaption.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.lblRecipientCaption.ForeColor = System.Drawing.Color.DimGray
        Me.lblRecipientCaption.Location = New System.Drawing.Point(20, 49)
        Me.lblRecipientCaption.Name = "lblRecipientCaption"
        Me.lblRecipientCaption.Size = New System.Drawing.Size(68, 19)
        Me.lblRecipientCaption.TabIndex = 1
        Me.lblRecipientCaption.Text = "Recipients"
        '
        'lblRecipientCount
        '
        Me.lblRecipientCount.AutoSize = True
        Me.lblRecipientCount.Font = New System.Drawing.Font("Segoe UI", 18.0!, System.Drawing.FontStyle.Bold)
        Me.lblRecipientCount.ForeColor = System.Drawing.Color.FromArgb(CType(CType(122, Byte), Integer), CType(CType(28, Byte), Integer), CType(CType(43, Byte), Integer))
        Me.lblRecipientCount.Location = New System.Drawing.Point(18, 14)
        Me.lblRecipientCount.Name = "lblRecipientCount"
        Me.lblRecipientCount.Size = New System.Drawing.Size(44, 32)
        Me.lblRecipientCount.TabIndex = 0
        Me.lblRecipientCount.Text = "00"
        '
        'pnlCompose
        '
        Me.pnlCompose.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right)), System.Windows.Forms.AnchorStyles)
        Me.pnlCompose.BackColor = System.Drawing.Color.White
        Me.pnlCompose.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlCompose.Controls.Add(Me.lblComposeHeader)
        Me.pnlCompose.Controls.Add(Me.lblSectionFooter)
        Me.pnlCompose.Controls.Add(Me.lblSubTitle1)
        Me.pnlCompose.Controls.Add(Me.txtAnnouncementTitle)
        Me.pnlCompose.Controls.Add(Me.lblSubTitle2)
        Me.pnlCompose.Controls.Add(Me.txtContent)
        Me.pnlCompose.Controls.Add(Me.btnClear)
        Me.pnlCompose.Controls.Add(Me.btnPost)
        Me.pnlCompose.Location = New System.Drawing.Point(22, 208)
        Me.pnlCompose.Name = "pnlCompose"
        Me.pnlCompose.Size = New System.Drawing.Size(1144, 291)
        Me.pnlCompose.TabIndex = 4
        '
        'lblComposeHeader
        '
        Me.lblComposeHeader.BackColor = System.Drawing.Color.FromArgb(CType(CType(247, Byte), Integer), CType(CType(236, Byte), Integer), CType(CType(239, Byte), Integer))
        Me.lblComposeHeader.Dock = System.Windows.Forms.DockStyle.Top
        Me.lblComposeHeader.Font = New System.Drawing.Font("Segoe UI Semibold", 11.25!, System.Drawing.FontStyle.Bold)
        Me.lblComposeHeader.ForeColor = System.Drawing.Color.FromArgb(CType(CType(122, Byte), Integer), CType(CType(28, Byte), Integer), CType(CType(43, Byte), Integer))
        Me.lblComposeHeader.Location = New System.Drawing.Point(0, 0)
        Me.lblComposeHeader.Name = "lblComposeHeader"
        Me.lblComposeHeader.Padding = New System.Windows.Forms.Padding(16, 0, 0, 0)
        Me.lblComposeHeader.Size = New System.Drawing.Size(1142, 38)
        Me.lblComposeHeader.TabIndex = 0
        Me.lblComposeHeader.Text = "COMPOSE ANNOUNCEMENT"
        Me.lblComposeHeader.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblSectionFooter
        '
        Me.lblSectionFooter.AutoSize = True
        Me.lblSectionFooter.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lblSectionFooter.ForeColor = System.Drawing.Color.Silver
        Me.lblSectionFooter.Location = New System.Drawing.Point(25, 255)
        Me.lblSectionFooter.Name = "lblSectionFooter"
        Me.lblSectionFooter.Size = New System.Drawing.Size(171, 15)
        Me.lblSectionFooter.TabIndex = 7
        Me.lblSectionFooter.Text = "All fields are required before posting."
        '
        'txtAnnouncementTitle
        '
        Me.txtAnnouncementTitle.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.txtAnnouncementTitle.Location = New System.Drawing.Point(28, 89)
        Me.txtAnnouncementTitle.Name = "txtAnnouncementTitle"
        Me.txtAnnouncementTitle.Size = New System.Drawing.Size(620, 25)
        Me.txtAnnouncementTitle.TabIndex = 1
        '
        'txtContent
        '
        Me.txtContent.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtContent.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.txtContent.Location = New System.Drawing.Point(28, 151)
        Me.txtContent.Multiline = True
        Me.txtContent.Name = "txtContent"
        Me.txtContent.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtContent.Size = New System.Drawing.Size(1086, 84)
        Me.txtContent.TabIndex = 2
        '
        'btnPost
        '
        Me.btnPost.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnPost.BackColor = System.Drawing.Color.FromArgb(CType(CType(122, Byte), Integer), CType(CType(28, Byte), Integer), CType(CType(43, Byte), Integer))
        Me.btnPost.FlatAppearance.BorderSize = 0
        Me.btnPost.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnPost.Font = New System.Drawing.Font("Segoe UI Semibold", 10.0!)
        Me.btnPost.ForeColor = System.Drawing.Color.White
        Me.btnPost.Location = New System.Drawing.Point(950, 246)
        Me.btnPost.Name = "btnPost"
        Me.btnPost.Size = New System.Drawing.Size(164, 32)
        Me.btnPost.TabIndex = 3
        Me.btnPost.Text = "Post Now"
        Me.btnPost.UseVisualStyleBackColor = False
        '
        'btnClear
        '
        Me.btnClear.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnClear.BackColor = System.Drawing.Color.White
        Me.btnClear.FlatAppearance.BorderColor = System.Drawing.Color.Gainsboro
        Me.btnClear.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnClear.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.btnClear.ForeColor = System.Drawing.Color.Gray
        Me.btnClear.Location = New System.Drawing.Point(772, 246)
        Me.btnClear.Name = "btnClear"
        Me.btnClear.Size = New System.Drawing.Size(164, 32)
        Me.btnClear.TabIndex = 4
        Me.btnClear.Text = "Clear"
        Me.btnClear.UseVisualStyleBackColor = False
        '
        'pnlList
        '
        Me.pnlList.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pnlList.BackColor = System.Drawing.Color.White
        Me.pnlList.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlList.Controls.Add(Me.lblPostedHeader)
        Me.pnlList.Controls.Add(Me.txtSearch)
        Me.pnlList.Controls.Add(Me.dgvAnnouncements)
        Me.pnlList.Location = New System.Drawing.Point(22, 520)
        Me.pnlList.Name = "pnlList"
        Me.pnlList.Size = New System.Drawing.Size(1144, 208)
        Me.pnlList.TabIndex = 5
        '
        'lblPostedHeader
        '
        Me.lblPostedHeader.AutoSize = True
        Me.lblPostedHeader.Font = New System.Drawing.Font("Segoe UI Semibold", 11.25!, System.Drawing.FontStyle.Bold)
        Me.lblPostedHeader.ForeColor = System.Drawing.Color.FromArgb(CType(CType(122, Byte), Integer), CType(CType(28, Byte), Integer), CType(CType(43, Byte), Integer))
        Me.lblPostedHeader.Location = New System.Drawing.Point(24, 18)
        Me.lblPostedHeader.Name = "lblPostedHeader"
        Me.lblPostedHeader.Size = New System.Drawing.Size(173, 20)
        Me.lblPostedHeader.TabIndex = 0
        Me.lblPostedHeader.Text = "POSTED ANNOUNCEMENTS"
        '
        'txtSearch
        '
        Me.txtSearch.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtSearch.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.txtSearch.ForeColor = System.Drawing.Color.Gray
        Me.txtSearch.Location = New System.Drawing.Point(223, 15)
        Me.txtSearch.Name = "txtSearch"
        Me.txtSearch.Size = New System.Drawing.Size(891, 25)
        Me.txtSearch.TabIndex = 1
        Me.txtSearch.Text = "Search announcements..."
        '
        'dgvAnnouncements
        '
        Me.dgvAnnouncements.AllowUserToAddRows = False
        Me.dgvAnnouncements.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(CType(CType(248, Byte), Integer), CType(CType(250, Byte), Integer), CType(CType(252, Byte), Integer))
        Me.dgvAnnouncements.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvAnnouncements.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dgvAnnouncements.BackgroundColor = System.Drawing.Color.White
        Me.dgvAnnouncements.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.dgvAnnouncements.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(CType(CType(242, Byte), Integer), CType(CType(245, Byte), Integer), CType(CType(248, Byte), Integer))
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvAnnouncements.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.dgvAnnouncements.ColumnHeadersHeight = 40
        Me.dgvAnnouncements.EnableHeadersVisualStyles = False
        Me.dgvAnnouncements.Location = New System.Drawing.Point(28, 56)
        Me.dgvAnnouncements.Name = "dgvAnnouncements"
        Me.dgvAnnouncements.RowHeadersVisible = False
        Me.dgvAnnouncements.Size = New System.Drawing.Size(1086, 130)
        Me.dgvAnnouncements.TabIndex = 4
        '
        'lblSubTitle1
        '
        Me.lblSubTitle1.AutoSize = True
        Me.lblSubTitle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.lblSubTitle1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(122, Byte), Integer), CType(CType(28, Byte), Integer), CType(CType(43, Byte), Integer))
        Me.lblSubTitle1.Location = New System.Drawing.Point(25, 66)
        Me.lblSubTitle1.Name = "lblSubTitle1"
        Me.lblSubTitle1.Size = New System.Drawing.Size(145, 15)
        Me.lblSubTitle1.TabIndex = 5
        Me.lblSubTitle1.Text = "ANNOUNCEMENT TITLE"
        '
        'lblSubTitle2
        '
        Me.lblSubTitle2.AutoSize = True
        Me.lblSubTitle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.lblSubTitle2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(122, Byte), Integer), CType(CType(28, Byte), Integer), CType(CType(43, Byte), Integer))
        Me.lblSubTitle2.Location = New System.Drawing.Point(25, 127)
        Me.lblSubTitle2.Name = "lblSubTitle2"
        Me.lblSubTitle2.Size = New System.Drawing.Size(170, 15)
        Me.lblSubTitle2.TabIndex = 6
        Me.lblSubTitle2.Text = "ANNOUNCEMENT CONTENT"
        '
        'Announcementfrm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(252, Byte), Integer), CType(CType(247, Byte), Integer), CType(CType(248, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(1200, 740)
        Me.Controls.Add(Me.pnlList)
        Me.Controls.Add(Me.pnlCompose)
        Me.Controls.Add(Me.pnlStatRecipients)
        Me.Controls.Add(Me.pnlStatUrgent)
        Me.Controls.Add(Me.pnlStatPosted)
        Me.Controls.Add(Me.pnlHeader)
        Me.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable
        Me.Name = "Announcementfrm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = " "
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.pnlHeader.ResumeLayout(False)
        Me.pnlHeader.PerformLayout()
        Me.pnlStatPosted.ResumeLayout(False)
        Me.pnlStatPosted.PerformLayout()
        Me.pnlStatUrgent.ResumeLayout(False)
        Me.pnlStatUrgent.PerformLayout()
        Me.pnlStatRecipients.ResumeLayout(False)
        Me.pnlStatRecipients.PerformLayout()
        Me.pnlCompose.ResumeLayout(False)
        Me.pnlCompose.PerformLayout()
        Me.pnlList.ResumeLayout(False)
        Me.pnlList.PerformLayout()
        CType(Me.dgvAnnouncements, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents pnlHeader As System.Windows.Forms.Panel
    Friend WithEvents lblTitle As System.Windows.Forms.Label
    Friend WithEvents lblHeaderSub As Label
    Friend WithEvents pnlStatPosted As Panel
    Friend WithEvents lblPostedCaption As Label
    Friend WithEvents lblPostedCount As Label
    Friend WithEvents pnlStatUrgent As Panel
    Friend WithEvents lblUrgentCaption As Label
    Friend WithEvents lblUrgentCount As Label
    Friend WithEvents pnlStatRecipients As Panel
    Friend WithEvents lblRecipientCaption As Label
    Friend WithEvents lblRecipientCount As Label
    Friend WithEvents pnlCompose As Panel
    Friend WithEvents lblComposeHeader As Label
    Friend WithEvents lblSectionFooter As Label
    Friend WithEvents txtAnnouncementTitle As System.Windows.Forms.TextBox
    Friend WithEvents txtContent As System.Windows.Forms.TextBox
    Friend WithEvents btnPost As System.Windows.Forms.Button
    Friend WithEvents btnClear As Button
    Friend WithEvents pnlList As Panel
    Friend WithEvents lblPostedHeader As Label
    Friend WithEvents txtSearch As TextBox
    Friend WithEvents dgvAnnouncements As System.Windows.Forms.DataGridView
    Friend WithEvents lblSubTitle1 As System.Windows.Forms.Label
    Friend WithEvents lblSubTitle2 As System.Windows.Forms.Label
End Class
