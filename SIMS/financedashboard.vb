Imports MySql.Data.MySqlClient

Public Class financedashboard

    Private Sub financedashboard_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        RefreshDashboardData()
    End Sub

    Public Sub RefreshDashboardData()
        Try
            openConn()

            ' 1. Calculate Totals for KPI Cards
            ' We use COALESCE to avoid errors if the table is empty
            Dim kpiQuery As String = "SELECT 
                COALESCE(SUM(total_amount), 0) as rev, 
                COALESCE(SUM(paid_amount), 0) as paid, 
                COALESCE(SUM(total_amount - paid_amount), 0) as bal 
                FROM billing"

            Using scmd = cmd(kpiQuery)
                dr = scmd.ExecuteReader()
                If dr.Read() Then
                    lblRevValue.Text = String.Format("₱ {0:N2}", dr("rev"))
                    lblCollValue.Text = String.Format("₱ {0:N2}", dr("paid"))
                    lblBalValue.Text = String.Format("₱ {0:N2}", dr("bal"))
                End If
                dr.Close()
            End Using

            ' 2. Load Chart: Collection by Course
            Dim chartQuery As String = "SELECT c.course_code, SUM(b.paid_amount) as total 
                FROM courses c 
                JOIN enrollments e ON c.course_id = e.course_id 
                JOIN billing b ON e.enrollment_id = b.enrollment_id 
                GROUP BY c.course_code"

            chartFinance.Series("CollectionTrend").Points.Clear()
            Using scmd = cmd(chartQuery)
                dr = scmd.ExecuteReader()
                While dr.Read()
                    chartFinance.Series("CollectionTrend").Points.AddXY(dr("course_code").ToString(), dr("total"))
                End While
                dr.Close()
            End Using

            ' 3. Load Table: Last 10 Payments
            Dim tableQuery As String = "SELECT 
                p.payment_date as 'Date', 
                CONCAT(s.last_name, ', ', s.first_name) as 'Student', 
                p.amount_paid as 'Amount' 
                FROM payments p 
                JOIN billing b ON p.billing_id = b.billing_id 
                JOIN enrollments e ON b.enrollment_id = e.enrollment_id 
                JOIN students s ON e.student_id = s.student_id 
                ORDER BY p.payment_date DESC LIMIT 10"

            Using scmd = cmd(tableQuery)
                Dim dt As New DataTable()
                dt.Load(scmd.ExecuteReader())
                dgvPayments.DataSource = dt
            End Using

        Catch ex As Exception
            MsgBox("Error updating dashboard: " & ex.Message, MsgBoxStyle.Critical)
        Finally
            closeConn()
        End Try
    End Sub

End Class