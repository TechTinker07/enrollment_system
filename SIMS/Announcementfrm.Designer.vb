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
        Me.txtAnnouncementTitle = New System.Windows.Forms.TextBox()
        Me.txtContent = New System.Windows.Forms.TextBox()
        Me.btnPost = New System.Windows.Forms.Button()
        Me.dgvAnnouncements = New System.Windows.Forms.DataGridView()
        Me.lblSubTitle1 = New System.Windows.Forms.Label()
        Me.lblSubTitle2 = New System.Windows.Forms.Label()
        Me.pnlHeader.SuspendLayout()
        CType(Me.dgvAnnouncements, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'pnlHeader
        '
        Me.pnlHeader.BackColor = System.Drawing.Color.FromArgb(CType(CType(45, Byte), Integer), CType(CType(52, Byte), Integer), CType(CType(54, Byte), Integer))
        Me.pnlHeader.Controls.Add(Me.lblTitle)
        Me.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlHeader.Location = New System.Drawing.Point(0, 0)
        Me.pnlHeader.Name = "pnlHeader"
        Me.pnlHeader.Size = New System.Drawing.Size(800, 70)
        Me.pnlHeader.TabIndex = 0
        '
        'lblTitle
        '
        Me.lblTitle.AutoSize = True
        Me.lblTitle.Font = New System.Drawing.Font("Segoe UI Semibold", 18.0!)
        Me.lblTitle.ForeColor = System.Drawing.Color.White
        Me.lblTitle.Location = New System.Drawing.Point(20, 15)
        Me.lblTitle.Name = "lblTitle"
        Me.lblTitle.Size = New System.Drawing.Size(286, 32)
        Me.lblTitle.TabIndex = 0
        Me.lblTitle.Text = "Announcement Manager"
        '
        'txtAnnouncementTitle
        '
        Me.txtAnnouncementTitle.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.txtAnnouncementTitle.Location = New System.Drawing.Point(30, 115)
        Me.txtAnnouncementTitle.Name = "txtAnnouncementTitle"
        Me.txtAnnouncementTitle.Size = New System.Drawing.Size(550, 25)
        Me.txtAnnouncementTitle.TabIndex = 1
        '
        'txtContent
        '
        Me.txtContent.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.txtContent.Location = New System.Drawing.Point(30, 185)
        Me.txtContent.Multiline = True
        Me.txtContent.Name = "txtContent"
        Me.txtContent.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtContent.Size = New System.Drawing.Size(550, 120)
        Me.txtContent.TabIndex = 2
        '
        'btnPost
        '
        Me.btnPost.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(184, Byte), Integer), CType(CType(148, Byte), Integer))
        Me.btnPost.FlatAppearance.BorderSize = 0
        Me.btnPost.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnPost.Font = New System.Drawing.Font("Segoe UI Semibold", 10.0!)
        Me.btnPost.ForeColor = System.Drawing.Color.White
        Me.btnPost.Location = New System.Drawing.Point(600, 273)
        Me.btnPost.Name = "btnPost"
        Me.btnPost.Size = New System.Drawing.Size(170, 32)
        Me.btnPost.TabIndex = 3
        Me.btnPost.Text = "📢 Post Announcement"
        Me.btnPost.UseVisualStyleBackColor = False
        '
        'dgvAnnouncements
        '
        Me.dgvAnnouncements.AllowUserToAddRows = False
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
        Me.dgvAnnouncements.Location = New System.Drawing.Point(30, 330)
        Me.dgvAnnouncements.Name = "dgvAnnouncements"
        Me.dgvAnnouncements.RowHeadersVisible = False
        Me.dgvAnnouncements.Size = New System.Drawing.Size(740, 200)
        Me.dgvAnnouncements.TabIndex = 4
        '
        'lblSubTitle1
        '
        Me.lblSubTitle1.AutoSize = True
        Me.lblSubTitle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.lblSubTitle1.ForeColor = System.Drawing.Color.Gray
        Me.lblSubTitle1.Location = New System.Drawing.Point(30, 90)
        Me.lblSubTitle1.Name = "lblSubTitle1"
        Me.lblSubTitle1.Size = New System.Drawing.Size(145, 15)
        Me.lblSubTitle1.TabIndex = 5
        Me.lblSubTitle1.Text = "ANNOUNCEMENT TITLE"
        '
        'lblSubTitle2
        '
        Me.lblSubTitle2.AutoSize = True
        Me.lblSubTitle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.lblSubTitle2.ForeColor = System.Drawing.Color.Gray
        Me.lblSubTitle2.Location = New System.Drawing.Point(30, 160)
        Me.lblSubTitle2.Name = "lblSubTitle2"
        Me.lblSubTitle2.Size = New System.Drawing.Size(170, 15)
        Me.lblSubTitle2.TabIndex = 6
        Me.lblSubTitle2.Text = "ANNOUNCEMENT CONTENT"
        '
        'Announcementfrm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(800, 560)
        Me.Controls.Add(Me.lblSubTitle2)
        Me.Controls.Add(Me.lblSubTitle1)
        Me.Controls.Add(Me.dgvAnnouncements)
        Me.Controls.Add(Me.btnPost)
        Me.Controls.Add(Me.txtContent)
        Me.Controls.Add(Me.txtAnnouncementTitle)
        Me.Controls.Add(Me.pnlHeader)
        Me.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Name = "Announcementfrm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Announcement Management"
        Me.pnlHeader.ResumeLayout(False)
        Me.pnlHeader.PerformLayout()
        CType(Me.dgvAnnouncements, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents pnlHeader As System.Windows.Forms.Panel
    Friend WithEvents lblTitle As System.Windows.Forms.Label
    Friend WithEvents txtAnnouncementTitle As System.Windows.Forms.TextBox
    Friend WithEvents txtContent As System.Windows.Forms.TextBox
    Friend WithEvents btnPost As System.Windows.Forms.Button
    Friend WithEvents dgvAnnouncements As System.Windows.Forms.DataGridView
    Friend WithEvents lblSubTitle1 As System.Windows.Forms.Label
    Friend WithEvents lblSubTitle2 As System.Windows.Forms.Label
End Class