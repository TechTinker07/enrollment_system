Imports MySql.Data.MySqlClient
Imports System.Windows.Forms.DataVisualization.Charting

Public Class registrardashboard

    ' Triggered kapag nagbukas ang form
    Private Sub registrardashboard_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        RefreshDashboard()
    End Sub

    Public Sub RefreshDashboard()
        Try
            ' Buksan ang connection (Siguraduhin na ang openConn ay nasa Module mo)
            openConn()

            ' 1. Cards Logic
            LoadStats()

            ' 2. Chart: Course Distribution
            LoadCourseChart()

            ' 3. Chart: Enrollment Trends (Monthly)
            LoadTrendsChart()

            ' 4. Table: Recent Enrollees
            LoadRecentEnrollments()

        Catch ex As Exception
            MsgBox("Error sa pag-update ng dashboard: " & ex.Message, MsgBoxStyle.Critical)
        Finally
            closeConn()
        End Try
    End Sub

    ' Logic para sa Total Students at Revenue
    Private Sub LoadStats()
        ' Get Total Students
        Dim cmdStudents As New MySqlCommand("SELECT COUNT(*) FROM students", conn)
        lblStatStudents.Text = cmdStudents.ExecuteScalar().ToString()

        ' Get Total Revenue (Pwedeng i-join sa payments para mas accurate)
        Dim cmdRevenue As New MySqlCommand("SELECT SUM(amount_paid) FROM payments", conn)
        Dim rev = cmdRevenue.ExecuteScalar()
        lblStatRevenue.Text = If(IsDBNull(rev), "₱0", "₱" & Format(rev, "#,##0.00"))
    End Sub

    ' Logic para sa Doughnut Chart (Course Popularity)
    Private Sub LoadCourseChart()
        Dim query As String = "SELECT c.course_code, COUNT(e.enrollment_id) as total " &
                              "FROM courses c " &
                              "LEFT JOIN enrollments e ON c.course_id = e.course_id " &
                              "GROUP BY c.course_code"

        Dim adapter As New MySqlDataAdapter(query, conn)
        Dim dt As New DataTable()
        adapter.Fill(dt)

        chartCourses.Series.Clear()
        Dim series = chartCourses.Series.Add("Courses")
        series.ChartType = SeriesChartType.Doughnut
        series.IsValueShownAsLabel = True ' Ipakita ang number sa loob ng pie

        For Each row As DataRow In dt.Rows
            series.Points.AddXY(row("course_code").ToString(), row("total"))
        Next
    End Sub

    ' Logic para sa Bar Chart (Monthly Enrollment Growth)
    Private Sub LoadTrendsChart()
        ' Kinukuha nito ang bilang ng enrollees kada buwan para sa kasalukuyang taon
        Dim query As String = "SELECT MONTHNAME(enrollment_date) as buwan, COUNT(*) as total " &
                              "FROM enrollments " &
                              "WHERE YEAR(enrollment_date) = YEAR(CURDATE()) " &
                              "GROUP BY MONTH(enrollment_date) " &
                              "ORDER BY MONTH(enrollment_date)"

        Dim adapter As New MySqlDataAdapter(query, conn)
        Dim dt As New DataTable()
        adapter.Fill(dt)

        chartTrends.Series.Clear()
        Dim series = chartTrends.Series.Add("Monthly Enrollees")
        series.ChartType = SeriesChartType.Column ' Bar chart style

        For Each row As DataRow In dt.Rows
            series.Points.AddXY(row("buwan").ToString(), row("total"))
        Next
    End Sub

    ' Logic para sa DataGridView (Recent Enrollees)
    Private Sub LoadRecentEnrollments()
        Dim query As String = "SELECT e.student_id AS 'Student ID', " &
                              "CONCAT(s.last_name, ', ', s.first_name) AS 'Full Name', " &
                              "c.course_code AS 'Course', " &
                              "e.enrollment_date AS 'Date Enrolled', " &
                              "e.status AS 'Status' " &
                              "FROM enrollments e " &
                              "JOIN students s ON e.student_id = s.student_id " &
                              "JOIN courses c ON e.course_id = c.course_id " &
                              "ORDER BY e.enrollment_date DESC LIMIT 15"

        Dim adapter As New MySqlDataAdapter(query, conn)
        Dim dt As New DataTable()
        adapter.Fill(dt)
        dgvRecent.DataSource = dt

        ' Design Polish para sa Table
        With dgvRecent
            .AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(245, 246, 248)
            .ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(0, 120, 215)
            .ColumnHeadersDefaultCellStyle.ForeColor = Color.White
            .EnableHeadersVisualStyles = False
            .AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        End With
    End Sub

End Class