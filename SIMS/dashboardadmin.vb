Imports MySql.Data.MySqlClient

Public Class dashboardadmin

    Private Sub dashboardadmin_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Initial load of data
        LoadDashboardMetrics()
    End Sub

    ''' <summary>
    ''' Central logic to fetch decision-making data using the 'dbconnections' module.
    ''' </summary>
    Private Sub LoadDashboardMetrics()
        Try
            ' 1. Open the global connection from your Module
            openConn()

            ' --- METRIC 1: Total Students ---
            Using cmdStudents As MySqlCommand = cmd("SELECT COUNT(*) FROM students")
                lblStudentVal.Text = cmdStudents.ExecuteScalar().ToString()
            End Using

            ' --- METRIC 2: Total Revenue (Sum of Payments) ---
            Using cmdRevenue As MySqlCommand = cmd("SELECT SUM(amount_paid) FROM payments")
                Dim result = cmdRevenue.ExecuteScalar()
                lblRevenueVal.Text = String.Format("₱{0:N2}", If(IsDBNull(result), 0, result))
            End Using

            ' --- METRIC 3: Pending Admissions (Enrollments) ---
            Using cmdPending As MySqlCommand = cmd("SELECT COUNT(*) FROM enrollments WHERE status = 'pending'")
                lblPendingVal.Text = cmdPending.ExecuteScalar().ToString()
            End Using

            ' --- METRIC 4: Pending User Accounts (NEW) ---
            ' Decision Insight: Important for Admin to verify new registrations immediately.
            Using cmdUsers As MySqlCommand = cmd("SELECT COUNT(*) FROM users WHERE status = 'pending'")
                lblUserVal.Text = cmdUsers.ExecuteScalar().ToString()
            End Using

            ' --- METRIC 5: Total Courses (NEW) ---
            ' Decision Insight: Overview of academic offerings.
            Using cmdCourses As MySqlCommand = cmd("SELECT COUNT(*) FROM courses")
                lblCourseVal.Text = cmdCourses.ExecuteScalar().ToString()
            End Using

            ' --- DATA GRID: Recent Transactions ---
            Dim queryGrid As String = "SELECT p.payment_date AS 'Date', " &
                                    "CONCAT(s.last_name, ', ', s.first_name) AS 'Student Name', " &
                                    "p.amount_paid AS 'Amount', " &
                                    "p.reference_no AS 'Ref #' " &
                                    "FROM payments p " &
                                    "JOIN billing b ON p.billing_id = b.billing_id " &
                                    "JOIN enrollments e ON b.enrollment_id = e.enrollment_id " &
                                    "JOIN students s ON e.student_id = s.student_id " &
                                    "ORDER BY p.payment_date DESC LIMIT 10"

            Using da As New MySqlDataAdapter(queryGrid, conn)
                Dim dt As New DataTable()
                da.Fill(dt)
                dgvRecentPayments.DataSource = dt
            End Using

        Catch ex As Exception
            MsgBox("Decision Error: Could not retrieve system metrics. " & ex.Message, MsgBoxStyle.Critical)
        Finally
            ' 2. Always close the connection via your Module
            closeConn()
        End Try
    End Sub

    ' Optional: Refresh button logic
    Private Sub btnRefresh_Click(sender As Object, e As EventArgs)
        LoadDashboardMetrics()
    End Sub

End Class