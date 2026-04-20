Imports System.Data.SqlClient
Imports MySql.Data.MySqlClient

Public Class reports

    Private Sub reports_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        cmbReportType.Items.Clear()
        cmbReportType.Items.AddRange(New Object() {
            "Official Enrollment List",
            "Subject Enrollment Summary",
            "Student Billing Statement",
            "Daily Payment Collection Report",
            "Class List per Subject",
            "Grade Submission Summary",
            "Enrollment Statistics Report",
            "Financial Summary Report"
        })
        cmbReportType.SelectedIndex = 0
        RefreshMetrics()
    End Sub

    Private Sub RefreshMetrics()
        Try
            openConn()

            Dim totalCol = New MySqlCommand("SELECT IFNULL(SUM(amount_paid),0) FROM payments", conn).ExecuteScalar()
            lblTotalCollections.Text = "Total Collected: P " & FormatNumber(totalCol, 2)

            Dim totalBal = New MySqlCommand("SELECT IFNULL(SUM(balance),0) FROM billing", conn).ExecuteScalar()
            lblPendingBalance.Text = "Total Receivables: P " & FormatNumber(totalBal, 2)

        Catch ex As Exception
            MsgBox("Error updating metrics: " & ex.Message)
        Finally
            closeConn()
        End Try
    End Sub

    Private Sub btnGenerate_Click(sender As Object, e As EventArgs) Handles btnGenerate.Click
        Dim sql As String = ""

        Select Case cmbReportType.Text
            Case "Official Enrollment List"
                sql =
                    "SELECT e.enrollment_id, e.student_id, CONCAT(s.last_name, ', ', s.first_name) AS student_name, c.course_code, e.school_year, e.semester, e.status " &
                    "FROM enrollments e " &
                    "JOIN students s ON s.student_id = e.student_id " &
                    "JOIN courses c ON c.course_id = e.course_id " &
                    "ORDER BY e.enrollment_date DESC"

            Case "Subject Enrollment Summary"
                sql =
                    "SELECT sub.subject_code, sub.subject_title, COUNT(ed.detail_id) AS total_enrolled " &
                    "FROM enrollment_details ed " &
                    "JOIN schedules sch ON sch.schedule_id = ed.schedule_id " &
                    "JOIN subjects sub ON sub.subject_id = sch.subject_id " &
                    "GROUP BY sub.subject_id, sub.subject_code, sub.subject_title " &
                    "ORDER BY total_enrolled DESC"

            Case "Student Billing Statement"
                sql =
                    "SELECT s.student_id, CONCAT(s.last_name, ', ', s.first_name) AS student_name, b.total_amount, b.paid_amount, b.balance, b.due_date " &
                    "FROM billing b " &
                    "JOIN enrollments e ON e.enrollment_id = b.enrollment_id " &
                    "JOIN students s ON s.student_id = e.student_id " &
                    "ORDER BY s.last_name, s.first_name"

            Case "Daily Payment Collection Report"
                sql =
                    "SELECT DATE(p.payment_date) AS payment_day, p.reference_no AS or_number, s.student_id, CONCAT(s.last_name, ', ', s.first_name) AS student_name, p.amount_paid " &
                    "FROM payments p " &
                    "JOIN billing b ON b.billing_id = p.billing_id " &
                    "JOIN enrollments e ON e.enrollment_id = b.enrollment_id " &
                    "JOIN students s ON s.student_id = e.student_id " &
                    "ORDER BY p.payment_date DESC"

            Case "Class List per Subject"
                sql =
                    "SELECT sub.subject_code, sub.subject_title, sch.section, s.student_id, CONCAT(s.last_name, ', ', s.first_name) AS student_name " &
                    "FROM enrollment_details ed " &
                    "JOIN enrollments e ON e.enrollment_id = ed.enrollment_id " &
                    "JOIN students s ON s.student_id = e.student_id " &
                    "JOIN schedules sch ON sch.schedule_id = ed.schedule_id " &
                    "JOIN subjects sub ON sub.subject_id = sch.subject_id " &
                    "ORDER BY sub.subject_code, sch.section, s.last_name"

            Case "Grade Submission Summary"
                sql =
                    "SELECT sub.subject_code, sub.subject_title, COUNT(g.grade_id) AS grades_encoded, AVG(g.grade_value) AS average_grade " &
                    "FROM grades g " &
                    "JOIN subjects sub ON sub.subject_id = g.subject_id " &
                    "GROUP BY sub.subject_id, sub.subject_code, sub.subject_title " &
                    "ORDER BY sub.subject_code"

            Case "Enrollment Statistics Report"
                sql =
                    "SELECT c.course_code, c.course_name, COUNT(e.enrollment_id) AS total_enrollees " &
                    "FROM courses c " &
                    "LEFT JOIN enrollments e ON e.course_id = c.course_id " &
                    "GROUP BY c.course_id, c.course_code, c.course_name " &
                    "ORDER BY total_enrollees DESC"

            Case "Financial Summary Report"
                sql =
                    "SELECT " &
                    "(SELECT IFNULL(SUM(total_amount),0) FROM billing) AS total_assessed, " &
                    "(SELECT IFNULL(SUM(paid_amount),0) FROM billing) AS total_paid, " &
                    "(SELECT IFNULL(SUM(balance),0) FROM billing) AS total_receivables"

            Case Else
                MsgBox("Please select a report type.")
                Exit Sub
        End Select

        Try
            openConn()
            Dim adapter As New MySqlDataAdapter(sql, conn)
            Dim dt As New DataTable()
            adapter.Fill(dt)
            dgvReportTable.DataSource = dt
            RefreshMetrics()
        Catch ex As Exception
            MsgBox("Query error: " & ex.Message)
        Finally
            closeConn()
        End Try
    End Sub

End Class
