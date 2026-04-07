<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Usermngmtfrm
    Inherits System.Windows.Forms.Form

    ' Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    ' Clean up any resources being used.
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

    ' Windows Form Designer component declarations
    Private lblHeader As Label
    Private pnlHeader As Panel
    Private pnlDivider As Panel
    Private pnlToolbar As Panel
    Private lblSearch As Label
    Private txtSearch As TextBox
    Private btnAdd As Button
    Private btnEdit As Button
    Private btnApprove As Button
    Private btnDelete As Button
    Private dgvUsers As DataGridView
    Private statusStrip1 As StatusStrip
    Private lblStatusInfo As ToolStripStatusLabel

    ' DataGridView Columns (Aligned to simsdb)
    Private colID As DataGridViewTextBoxColumn
    Private colName As DataGridViewTextBoxColumn
    Private colUsername As DataGridViewTextBoxColumn
    Private colEmail As DataGridViewTextBoxColumn
    Private colRole As DataGridViewTextBoxColumn
    Private colDateAdded As DataGridViewTextBoxColumn

    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.lblHeader = New System.Windows.Forms.Label()
        Me.pnlHeader = New System.Windows.Forms.Panel()
        Me.pnlDivider = New System.Windows.Forms.Panel()
        Me.pnlToolbar = New System.Windows.Forms.Panel()
        Me.lblSearch = New System.Windows.Forms.Label()
        Me.txtSearch = New System.Windows.Forms.TextBox()
        Me.btnAdd = New System.Windows.Forms.Button()
        Me.btnEdit = New System.Windows.Forms.Button()
        Me.btnApprove = New System.Windows.Forms.Button()
        Me.btnDelete = New System.Windows.Forms.Button()
        Me.dgvUsers = New System.Windows.Forms.DataGridView()
        Me.colID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colUsername = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colEmail = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colRole = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colDateAdded = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.statusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.lblStatusInfo = New System.Windows.Forms.ToolStripStatusLabel()
        Me.pnlHeader.SuspendLayout()
        Me.pnlToolbar.SuspendLayout()
        CType(Me.dgvUsers, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.statusStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'lblHeader
        '
        Me.lblHeader.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblHeader.Font = New System.Drawing.Font("Segoe UI", 15.0!, System.Drawing.FontStyle.Bold)
        Me.lblHeader.ForeColor = System.Drawing.Color.White
        Me.lblHeader.Location = New System.Drawing.Point(0, 0)
        Me.lblHeader.Name = "lblHeader"
        Me.lblHeader.Padding = New System.Windows.Forms.Padding(18, 0, 0, 0)
        Me.lblHeader.Size = New System.Drawing.Size(1100, 60)
        Me.lblHeader.TabIndex = 0
        Me.lblHeader.Text = "👤  User Management Control Center"
        Me.lblHeader.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'pnlHeader
        '
        Me.pnlHeader.BackColor = System.Drawing.Color.FromArgb(CType(CType(24, Byte), Integer), CType(CType(95, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.pnlHeader.Controls.Add(Me.lblHeader)
        Me.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlHeader.Location = New System.Drawing.Point(0, 0)
        Me.pnlHeader.Name = "pnlHeader"
        Me.pnlHeader.Size = New System.Drawing.Size(1100, 60)
        Me.pnlHeader.TabIndex = 3
        '
        'pnlDivider
        '
        Me.pnlDivider.BackColor = System.Drawing.Color.FromArgb(CType(CType(181, Byte), Integer), CType(CType(212, Byte), Integer), CType(CType(244, Byte), Integer))
        Me.pnlDivider.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlDivider.Location = New System.Drawing.Point(0, 60)
        Me.pnlDivider.Name = "pnlDivider"
        Me.pnlDivider.Size = New System.Drawing.Size(1100, 2)
        Me.pnlDivider.TabIndex = 2
        '
        'pnlToolbar
        '
        Me.pnlToolbar.BackColor = System.Drawing.Color.FromArgb(CType(CType(247, Byte), Integer), CType(CType(250, Byte), Integer), CType(CType(253, Byte), Integer))
        Me.pnlToolbar.Controls.Add(Me.lblSearch)
        Me.pnlToolbar.Controls.Add(Me.txtSearch)
        Me.pnlToolbar.Controls.Add(Me.btnAdd)
        Me.pnlToolbar.Controls.Add(Me.btnEdit)
        Me.pnlToolbar.Controls.Add(Me.btnApprove)
        Me.pnlToolbar.Controls.Add(Me.btnDelete)
        Me.pnlToolbar.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlToolbar.Location = New System.Drawing.Point(0, 62)
        Me.pnlToolbar.Name = "pnlToolbar"
        Me.pnlToolbar.Size = New System.Drawing.Size(1100, 56)
        Me.pnlToolbar.TabIndex = 1
        '
        'lblSearch
        '
        Me.lblSearch.Location = New System.Drawing.Point(0, 0)
        Me.lblSearch.Name = "lblSearch"
        Me.lblSearch.Size = New System.Drawing.Size(100, 23)
        Me.lblSearch.TabIndex = 0
        '
        'txtSearch
        '
        Me.txtSearch.Location = New System.Drawing.Point(120, 15)
        Me.txtSearch.Name = "txtSearch"
        Me.txtSearch.Size = New System.Drawing.Size(250, 20)
        Me.txtSearch.TabIndex = 1
        Me.txtSearch.Text = "Search users..."
        '
        'btnAdd
        '
        Me.btnAdd.BackColor = System.Drawing.Color.FromArgb(CType(CType(24, Byte), Integer), CType(CType(95, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnAdd.ForeColor = System.Drawing.Color.White
        Me.btnAdd.Location = New System.Drawing.Point(385, 13)
        Me.btnAdd.Name = "btnAdd"
        Me.btnAdd.Size = New System.Drawing.Size(100, 30)
        Me.btnAdd.TabIndex = 2
        Me.btnAdd.Text = "+ Add"
        Me.btnAdd.UseVisualStyleBackColor = False
        '
        'btnEdit
        '
        Me.btnEdit.Location = New System.Drawing.Point(0, 0)
        Me.btnEdit.Name = "btnEdit"
        Me.btnEdit.Size = New System.Drawing.Size(75, 23)
        Me.btnEdit.TabIndex = 3
        '
        'btnApprove
        '
        Me.btnApprove.BackColor = System.Drawing.Color.FromArgb(CType(CType(151, Byte), Integer), CType(CType(196, Byte), Integer), CType(CType(89, Byte), Integer))
        Me.btnApprove.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnApprove.ForeColor = System.Drawing.Color.White
        Me.btnApprove.Location = New System.Drawing.Point(495, 13)
        Me.btnApprove.Name = "btnApprove"
        Me.btnApprove.Size = New System.Drawing.Size(100, 30)
        Me.btnApprove.TabIndex = 4
        Me.btnApprove.Text = "✓ Approve"
        Me.btnApprove.UseVisualStyleBackColor = False
        '
        'btnDelete
        '
        Me.btnDelete.BackColor = System.Drawing.Color.FromArgb(CType(CType(240, Byte), Integer), CType(CType(149, Byte), Integer), CType(CType(149, Byte), Integer))
        Me.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnDelete.ForeColor = System.Drawing.Color.White
        Me.btnDelete.Location = New System.Drawing.Point(605, 13)
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.Size = New System.Drawing.Size(100, 30)
        Me.btnDelete.TabIndex = 5
        Me.btnDelete.Text = "🗑 Delete"
        Me.btnDelete.UseVisualStyleBackColor = False
        '
        'dgvUsers
        '
        Me.dgvUsers.AllowUserToAddRows = False
        Me.dgvUsers.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dgvUsers.BackgroundColor = System.Drawing.Color.White
        Me.dgvUsers.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.dgvUsers.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colID, Me.colName, Me.colUsername, Me.colEmail, Me.colRole, Me.colDateAdded})
        Me.dgvUsers.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvUsers.Location = New System.Drawing.Point(0, 118)
        Me.dgvUsers.MultiSelect = False
        Me.dgvUsers.Name = "dgvUsers"
        Me.dgvUsers.RowHeadersVisible = False
        Me.dgvUsers.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvUsers.Size = New System.Drawing.Size(1100, 540)
        Me.dgvUsers.TabIndex = 0
        '
        'colID
        '
        Me.colID.DataPropertyName = "user_id"
        Me.colID.Name = "colID"
        Me.colID.Visible = False
        '
        'colName
        '
        Me.colName.DataPropertyName = "full_name"
        Me.colName.HeaderText = "Full Name / Student"
        Me.colName.Name = "colName"
        '
        'colUsername
        '
        Me.colUsername.DataPropertyName = "username"
        Me.colUsername.HeaderText = "Username"
        Me.colUsername.Name = "colUsername"
        '
        'colEmail
        '
        Me.colEmail.DataPropertyName = "email"
        Me.colEmail.HeaderText = "Email Address"
        Me.colEmail.Name = "colEmail"
        '
        'colRole
        '
        Me.colRole.DataPropertyName = "role"
        Me.colRole.HeaderText = "Role"
        Me.colRole.Name = "colRole"
        '
        'colDateAdded
        '
        Me.colDateAdded.DataPropertyName = "created_at"
        Me.colDateAdded.HeaderText = "Registration Date"
        Me.colDateAdded.Name = "colDateAdded"
        '
        'statusStrip1
        '
        Me.statusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.lblStatusInfo})
        Me.statusStrip1.Location = New System.Drawing.Point(0, 658)
        Me.statusStrip1.Name = "statusStrip1"
        Me.statusStrip1.Size = New System.Drawing.Size(1100, 22)
        Me.statusStrip1.TabIndex = 4
        '
        'lblStatusInfo
        '
        Me.lblStatusInfo.Name = "lblStatusInfo"
        Me.lblStatusInfo.Size = New System.Drawing.Size(0, 17)
        '
        'Usermngmtfrm
        '
        Me.ClientSize = New System.Drawing.Size(1100, 680)
        Me.Controls.Add(Me.dgvUsers)
        Me.Controls.Add(Me.pnlToolbar)
        Me.Controls.Add(Me.pnlDivider)
        Me.Controls.Add(Me.pnlHeader)
        Me.Controls.Add(Me.statusStrip1)
        Me.Name = "Usermngmtfrm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "User Management"
        Me.pnlHeader.ResumeLayout(False)
        Me.pnlToolbar.ResumeLayout(False)
        Me.pnlToolbar.PerformLayout()
        CType(Me.dgvUsers, System.ComponentModel.ISupportInitialize).EndInit()
        Me.statusStrip1.ResumeLayout(False)
        Me.statusStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
End Class