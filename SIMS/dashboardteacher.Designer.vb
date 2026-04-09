<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class dashboardteacher
    Inherits System.Windows.Forms.Form

    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.pnlHeader = New Panel()
        Me.lblTitle = New Label()
        Me.flowCards = New FlowLayoutPanel()
        Me.card1 = New Panel()
        Me.lblCountStudents = New Label()
        Me.lblTitleStudents = New Label()
        Me.card2 = New Panel()
        Me.lblCountCourses = New Label()
        Me.lblTitleCourses = New Label()
        Me.dgvModern = New DataGridView()

        ' Header Setup
        Me.pnlHeader.BackColor = Color.FromArgb(31, 41, 55)
        Me.pnlHeader.Dock = DockStyle.Top
        Me.pnlHeader.Height = 60

        ' Card Layout
        Me.flowCards.Dock = DockStyle.Top
        Me.flowCards.Height = 140
        Me.flowCards.BackColor = Color.FromArgb(243, 244, 246)
        Me.flowCards.Padding = New Padding(20)

        ' CALLING THE METHOD
        ' Ensure the logic file (Part 1) is saved before running this
        Me.SetupWebCard(card1, lblCountStudents, lblTitleStudents, "TOTAL STUDENTS", Color.DodgerBlue)
        Me.SetupWebCard(card2, lblCountCourses, lblTitleCourses, "TOTAL COURSES", Color.SeaGreen)

        ' Grid Setup
        Me.dgvModern.Dock = DockStyle.Fill
        Me.dgvModern.BackgroundColor = Color.White
        Me.dgvModern.BorderStyle = BorderStyle.None

        ' Form
        Me.ClientSize = New Size(1000, 600)
        Me.Controls.Add(Me.dgvModern)
        Me.Controls.Add(Me.flowCards)
        Me.Controls.Add(Me.pnlHeader)
        Me.flowCards.Controls.Add(card1)
        Me.flowCards.Controls.Add(card2)
    End Sub

    Friend WithEvents pnlHeader As Panel
    Friend WithEvents lblTitle As Label
    Friend WithEvents flowCards As FlowLayoutPanel
    Friend WithEvents card1 As Panel
    Friend WithEvents lblCountStudents As Label
    Friend WithEvents lblTitleStudents As Label
    Friend WithEvents card2 As Panel
    Friend WithEvents lblCountCourses As Label
    Friend WithEvents lblTitleCourses As Label
    Friend WithEvents dgvModern As DataGridView
End Class