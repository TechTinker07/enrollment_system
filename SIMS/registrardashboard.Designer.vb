<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class registrardashboard
    Inherits System.Windows.Forms.Form

    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then components.Dispose()
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    ' Controls Declaration
    Private components As System.ComponentModel.IContainer
    Friend WithEvents pnlHeader As System.Windows.Forms.Panel
    Friend WithEvents lblTitle As System.Windows.Forms.Label
    Friend WithEvents pnlMainScroll As System.Windows.Forms.Panel
    Friend WithEvents cardStudents As System.Windows.Forms.Panel
    Friend WithEvents cardRevenue As System.Windows.Forms.Panel
    Friend WithEvents cardStatus As System.Windows.Forms.Panel
    Friend WithEvents chartCourses As System.Windows.Forms.DataVisualization.Charting.Chart
    Friend WithEvents chartTrends As System.Windows.Forms.DataVisualization.Charting.Chart
    Friend WithEvents dgvRecent As System.Windows.Forms.DataGridView
    Friend WithEvents lblLabelStudents, lblStatStudents As System.Windows.Forms.Label
    Friend WithEvents lblLabelRevenue, lblStatRevenue As System.Windows.Forms.Label
    Friend WithEvents lblChart1Title, lblChart2Title, lblTableTitle As System.Windows.Forms.Label

    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim ChartArea1 As New System.Windows.Forms.DataVisualization.Charting.ChartArea()
        Dim ChartArea2 As New System.Windows.Forms.DataVisualization.Charting.ChartArea()

        Me.pnlHeader = New System.Windows.Forms.Panel()
        Me.lblTitle = New System.Windows.Forms.Label()
        Me.pnlMainScroll = New System.Windows.Forms.Panel()

        ' 1. Header Styling
        Me.pnlHeader.BackColor = System.Drawing.Color.White
        Me.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlHeader.Height = 70
        Me.lblTitle.Text = "Registrar Analytics Dashboard"
        Me.lblTitle.Font = New System.Drawing.Font("Segoe UI Semibold", 18.0!)
        Me.lblTitle.Location = New System.Drawing.Point(25, 20)
        Me.pnlHeader.Controls.Add(Me.lblTitle)

        ' 2. Main Scrollable Panel
        Me.pnlMainScroll.AutoScroll = True
        Me.pnlMainScroll.BackColor = System.Drawing.Color.FromArgb(240, 242, 245)
        Me.pnlMainScroll.Dock = System.Windows.Forms.DockStyle.Fill

        ' --- STAT CARDS ---
        ' Card 1: Students
        Me.cardStudents = CreateCard(30, 30, System.Drawing.Color.FromArgb(0, 120, 215))
        lblLabelStudents = CreateCardLabel("TOTAL STUDENTS", 15, 15)
        lblStatStudents = CreateStatLabel("1,284", 12, 45)
        Me.cardStudents.Controls.AddRange({lblLabelStudents, lblStatStudents})

        ' Card 2: Revenue
        Me.cardRevenue = CreateCard(330, 30, System.Drawing.Color.FromArgb(40, 167, 69))
        lblLabelRevenue = CreateCardLabel("TOTAL REVENUE", 15, 15)
        lblStatRevenue = CreateStatLabel("₱458K", 12, 45)
        Me.cardRevenue.Controls.AddRange({lblLabelRevenue, lblStatRevenue})

        ' --- GRAPHS SECTION ---
        ' Chart 1 Label & Box
        Me.lblChart1Title = CreateSectionLabel("Student Distribution by Course", 30, 180)
        Me.chartCourses = New System.Windows.Forms.DataVisualization.Charting.Chart()
        Me.chartCourses.Location = New System.Drawing.Point(30, 215)
        Me.chartCourses.Size = New System.Drawing.Size(540, 300)
        Me.chartCourses.ChartAreas.Add(ChartArea1)

        ' Chart 2 Label & Box
        Me.lblChart2Title = CreateSectionLabel("Monthly Enrollment Trends", 600, 180)
        Me.chartTrends = New System.Windows.Forms.DataVisualization.Charting.Chart()
        Me.chartTrends.Location = New System.Drawing.Point(600, 215)
        Me.chartTrends.Size = New System.Drawing.Size(540, 300)
        Me.chartTrends.ChartAreas.Add(ChartArea2)

        ' --- TABLE SECTION ---
        Me.lblTableTitle = CreateSectionLabel("Recent Enrollees List", 30, 540)
        Me.dgvRecent = New System.Windows.Forms.DataGridView()
        Me.dgvRecent.Location = New System.Drawing.Point(30, 575)
        Me.dgvRecent.Size = New System.Drawing.Size(1110, 400) ' Height of 400 for scrolling
        Me.dgvRecent.BackgroundColor = System.Drawing.Color.White
        Me.dgvRecent.BorderStyle = System.Windows.Forms.BorderStyle.None

        ' Adding to Main Panel
        Me.pnlMainScroll.Controls.AddRange({Me.cardStudents, Me.cardRevenue, Me.lblChart1Title, Me.chartCourses, Me.lblChart2Title, Me.chartTrends, Me.lblTableTitle, Me.dgvRecent})

        ' Form Setup
        Me.ClientSize = New System.Drawing.Size(1200, 850)
        Me.Controls.Add(Me.pnlMainScroll)
        Me.Controls.Add(Me.pnlHeader)
        Me.Text = "Student Information System"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
    End Sub

    ' Helper Functions para malinis ang code
    Private Function CreateCard(x As Integer, y As Integer, bg As System.Drawing.Color) As System.Windows.Forms.Panel
        Dim p As New System.Windows.Forms.Panel With {.Location = New System.Drawing.Point(x, y), .Size = New System.Drawing.Size(280, 120), .BackColor = bg}
        Return p
    End Function

    Private Function CreateCardLabel(txt As String, x As Integer, y As Integer) As System.Windows.Forms.Label
        Return New System.Windows.Forms.Label With {.Text = txt, .Location = New System.Drawing.Point(x, y), .ForeColor = System.Drawing.Color.White, .Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!)}
    End Function

    Private Function CreateStatLabel(txt As String, x As Integer, y As Integer) As System.Windows.Forms.Label
        Return New System.Windows.Forms.Label With {.Text = txt, .Location = New System.Drawing.Point(x, y), .ForeColor = System.Drawing.Color.White, .Font = New System.Drawing.Font("Segoe UI", 24.0!, System.Drawing.FontStyle.Bold), .AutoSize = True}
    End Function

    Private Function CreateSectionLabel(txt As String, x As Integer, y As Integer) As System.Windows.Forms.Label
        Return New System.Windows.Forms.Label With {.Text = txt, .Location = New System.Drawing.Point(x, y), .Font = New System.Drawing.Font("Segoe UI Semibold", 12.0!), .AutoSize = True}
    End Function
End Class