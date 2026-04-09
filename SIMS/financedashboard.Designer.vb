<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class financedashboard
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

    ' These declarations MUST be here for the logic code to work
    Friend WithEvents pnlHeader As Panel
    Friend WithEvents lblTitle As Label
    Friend WithEvents flowKPILayouter As FlowLayoutPanel
    Friend WithEvents lblRevValue As Label
    Friend WithEvents lblCollValue As Label
    Friend WithEvents lblBalValue As Label
    Friend WithEvents chartFinance As DataVisualization.Charting.Chart
    Friend WithEvents dgvPayments As DataGridView
    Friend WithEvents lblTableTitle As Label

    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim ChartArea1 As New System.Windows.Forms.DataVisualization.Charting.ChartArea()
        Dim Series1 As New System.Windows.Forms.DataVisualization.Charting.Series()

        Me.pnlHeader = New Panel()
        Me.lblTitle = New Label()
        Me.flowKPILayouter = New FlowLayoutPanel()
        Me.chartFinance = New System.Windows.Forms.DataVisualization.Charting.Chart()
        Me.dgvPayments = New DataGridView()
        Me.lblTableTitle = New Label()

        ' Form Setup
        Me.ClientSize = New System.Drawing.Size(1150, 750)
        Me.Text = "SIMS Finance Dashboard"
        Me.BackColor = System.Drawing.Color.FromArgb(244, 247, 252)

        ' Header
        Me.pnlHeader.Dock = DockStyle.Top
        Me.pnlHeader.Height = 70
        Me.pnlHeader.BackColor = System.Drawing.Color.FromArgb(34, 45, 50)
        Me.lblTitle.Text = "FINANCIAL ANALYTICS"
        Me.lblTitle.ForeColor = System.Drawing.Color.White
        Me.lblTitle.Font = New System.Drawing.Font("Segoe UI", 18, FontStyle.Bold)
        Me.lblTitle.Location = New System.Drawing.Point(25, 18)
        Me.pnlHeader.Controls.Add(Me.lblTitle)

        ' KPI Layout
        Me.flowKPILayouter.Location = New System.Drawing.Point(20, 90)
        Me.flowKPILayouter.Size = New System.Drawing.Size(1100, 160)

        ' Create Labels manually for logic access
        Me.lblRevValue = New Label()
        Me.lblCollValue = New Label()
        Me.lblBalValue = New Label()

        ' Add Cards via Helper (aligned in FlowLayout)
        Me.flowKPILayouter.Controls.Add(CreateKPICard("TOTAL REVENUE", lblRevValue, Color.DodgerBlue))
        Me.flowKPILayouter.Controls.Add(CreateKPICard("TOTAL COLLECTED", lblCollValue, Color.SeaGreen))
        Me.flowKPILayouter.Controls.Add(CreateKPICard("OUTSTANDING BALANCE", lblBalValue, Color.Crimson))

        ' Chart
        ChartArea1.Name = "MainArea"
        Me.chartFinance.ChartAreas.Add(ChartArea1)
        Me.chartFinance.Location = New System.Drawing.Point(30, 270)
        Me.chartFinance.Size = New System.Drawing.Size(530, 420)
        Series1.Name = "CollectionTrend"
        Series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Column
        Me.chartFinance.Series.Add(Series1)

        ' Table
        Me.lblTableTitle.Text = "RECENT TRANSACTIONS"
        Me.lblTableTitle.Location = New System.Drawing.Point(580, 270)
        Me.lblTableTitle.Font = New Font("Segoe UI", 11, FontStyle.Bold)

        Me.dgvPayments.Location = New System.Drawing.Point(580, 305)
        Me.dgvPayments.Size = New System.Drawing.Size(530, 385)
        Me.dgvPayments.BackgroundColor = Color.White
        Me.dgvPayments.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill

        Me.Controls.Add(Me.dgvPayments)
        Me.Controls.Add(Me.lblTableTitle)
        Me.Controls.Add(Me.chartFinance)
        Me.Controls.Add(Me.flowKPILayouter)
        Me.Controls.Add(Me.pnlHeader)
    End Sub

    Private Function CreateKPICard(title As String, valLbl As Label, clr As Color) As Panel
        Dim p As New Panel With {.Size = New Size(345, 130), .BackColor = Color.White, .Margin = New Padding(0, 0, 15, 0)}
        Dim lLine As New Panel With {.Dock = DockStyle.Top, .Height = 4, .BackColor = clr}

        Dim lTitle As New Label With {.Text = title, .Location = New Point(20, 30), .AutoSize = True, .ForeColor = Color.Gray}
        valLbl.Text = "₱ 0.00"
        valLbl.Font = New Font("Segoe UI", 22, FontStyle.Bold)
        valLbl.Location = New Point(20, 60)
        valLbl.AutoSize = True

        p.Controls.Add(lLine)
        p.Controls.Add(lTitle)
        p.Controls.Add(valLbl)
        Return p
    End Function
End Class