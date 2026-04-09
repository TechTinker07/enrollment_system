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
    Friend WithEvents lblHeader As Label

    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.pnlInputContainer = New System.Windows.Forms.Panel()
        Me.btnClear = New System.Windows.Forms.Button()
        Me.btnPost = New System.Windows.Forms.Button()
        Me.lblMsg = New System.Windows.Forms.Label()
        Me.txtMessage = New System.Windows.Forms.TextBox()
        Me.lblTarget = New System.Windows.Forms.Label()
        Me.cmbRecipient = New System.Windows.Forms.ComboBox()
        Me.lblTitle = New System.Windows.Forms.Label()
        Me.txtTitle = New System.Windows.Forms.TextBox()
        Me.lblHeader = New System.Windows.Forms.Label()
        Me.dgvAnnouncements = New System.Windows.Forms.DataGridView()
        Me.pnlInputContainer.SuspendLayout()
        CType(Me.dgvAnnouncements, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'pnlInputContainer
        '
        Me.pnlInputContainer.BackColor = System.Drawing.Color.White
        Me.pnlInputContainer.Controls.Add(Me.btnClear)
        Me.pnlInputContainer.Controls.Add(Me.btnPost)
        Me.pnlInputContainer.Controls.Add(Me.lblMsg)
        Me.pnlInputContainer.Controls.Add(Me.txtMessage)
        Me.pnlInputContainer.Controls.Add(Me.lblTarget)
        Me.pnlInputContainer.Controls.Add(Me.cmbRecipient)
        Me.pnlInputContainer.Controls.Add(Me.lblTitle)
        Me.pnlInputContainer.Controls.Add(Me.txtTitle)
        Me.pnlInputContainer.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlInputContainer.Location = New System.Drawing.Point(20, 20)
        Me.pnlInputContainer.Name = "pnlInputContainer"
        Me.pnlInputContainer.Size = New System.Drawing.Size(760, 220)
        Me.pnlInputContainer.TabIndex = 0
        '
        'btnClear
        '
        Me.btnClear.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnClear.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.btnClear.Location = New System.Drawing.Point(515, 175)
        Me.btnClear.Name = "btnClear"
        Me.btnClear.Size = New System.Drawing.Size(100, 35)
        Me.btnClear.TabIndex = 0
        Me.btnClear.Text = "Clear"
        '
        'btnPost
        '
        Me.btnPost.BackColor = System.Drawing.Color.FromArgb(CType(CType(107, Byte), Integer), CType(CType(26, Byte), Integer), CType(CType(42, Byte), Integer))
        Me.btnPost.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnPost.Font = New System.Drawing.Font("Segoe UI Semibold", 10.0!)
        Me.btnPost.ForeColor = System.Drawing.Color.White
        Me.btnPost.Location = New System.Drawing.Point(625, 175)
        Me.btnPost.Name = "btnPost"
        Me.btnPost.Size = New System.Drawing.Size(120, 35)
        Me.btnPost.TabIndex = 1
        Me.btnPost.Text = "Post Now"
        Me.btnPost.UseVisualStyleBackColor = False
        '
        'lblMsg
        '
        Me.lblMsg.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lblMsg.Location = New System.Drawing.Point(15, 75)
        Me.lblMsg.Name = "lblMsg"
        Me.lblMsg.Size = New System.Drawing.Size(150, 20)
        Me.lblMsg.TabIndex = 2
        Me.lblMsg.Text = "Message Details"
        '
        'txtMessage
        '
        Me.txtMessage.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.txtMessage.Location = New System.Drawing.Point(15, 98)
        Me.txtMessage.Multiline = True
        Me.txtMessage.Name = "txtMessage"
        Me.txtMessage.Size = New System.Drawing.Size(730, 70)
        Me.txtMessage.TabIndex = 3
        '
        'lblTarget
        '
        Me.lblTarget.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lblTarget.Location = New System.Drawing.Point(430, 15)
        Me.lblTarget.Name = "lblTarget"
        Me.lblTarget.Size = New System.Drawing.Size(150, 20)
        Me.lblTarget.TabIndex = 4
        Me.lblTarget.Text = "Send To (Section/Subject)"
        '
        'cmbRecipient
        '
        Me.cmbRecipient.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbRecipient.Font = New System.Drawing.Font("Segoe UI", 11.0!)
        Me.cmbRecipient.Items.AddRange(New Object() {"All Sections", "BSIT 1-A", "BSIT 2-B", "CPE 3-C"})
        Me.cmbRecipient.Location = New System.Drawing.Point(430, 38)
        Me.cmbRecipient.Name = "cmbRecipient"
        Me.cmbRecipient.Size = New System.Drawing.Size(315, 28)
        Me.cmbRecipient.TabIndex = 5
        '
        'lblTitle
        '
        Me.lblTitle.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lblTitle.Location = New System.Drawing.Point(15, 15)
        Me.lblTitle.Name = "lblTitle"
        Me.lblTitle.Size = New System.Drawing.Size(150, 20)
        Me.lblTitle.TabIndex = 6
        Me.lblTitle.Text = "Announcement Title"
        '
        'txtTitle
        '
        Me.txtTitle.Font = New System.Drawing.Font("Segoe UI", 11.0!)
        Me.txtTitle.Location = New System.Drawing.Point(15, 38)
        Me.txtTitle.Name = "txtTitle"
        Me.txtTitle.Size = New System.Drawing.Size(400, 27)
        Me.txtTitle.TabIndex = 7
        '
        'lblHeader
        '
        Me.lblHeader.AutoSize = True
        Me.lblHeader.Font = New System.Drawing.Font("Segoe UI Semibold", 18.0!, System.Drawing.FontStyle.Bold)
        Me.lblHeader.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lblHeader.Location = New System.Drawing.Point(20, 15)
        Me.lblHeader.Name = "lblHeader"
        Me.lblHeader.Size = New System.Drawing.Size(260, 32)
        Me.lblHeader.TabIndex = 1
        Me.lblHeader.Text = "Create Announcement"
        '
        'dgvAnnouncements
        '
        Me.dgvAnnouncements.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dgvAnnouncements.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(245, Byte), Integer), CType(CType(245, Byte), Integer), CType(CType(245, Byte), Integer))
        Me.dgvAnnouncements.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.dgvAnnouncements.ColumnHeadersHeight = 35
        Me.dgvAnnouncements.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.dgvAnnouncements.Location = New System.Drawing.Point(20, 300)
        Me.dgvAnnouncements.Name = "dgvAnnouncements"
        Me.dgvAnnouncements.RowHeadersVisible = False
        Me.dgvAnnouncements.Size = New System.Drawing.Size(760, 220)
        Me.dgvAnnouncements.TabIndex = 0
        '
        'announcementform
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(240, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(240, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(800, 540)
        Me.Controls.Add(Me.dgvAnnouncements)
        Me.Controls.Add(Me.pnlInputContainer)
        Me.Controls.Add(Me.lblHeader)
        Me.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Name = "announcementform"
        Me.Padding = New System.Windows.Forms.Padding(20)
        Me.Text = "Announcement Manager"
        Me.pnlInputContainer.ResumeLayout(False)
        Me.pnlInputContainer.PerformLayout()
        CType(Me.dgvAnnouncements, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
End Class