Imports MySql.Data.MySqlClient

Public Class dashboardteacher

    ' This is the EXACT method the Designer is looking for.
    ' It must be Private or Public, and must be inside this class.
    Private Sub SetupWebCard(pnl As Panel, count As Label, title As Label, titleText As String, accentColor As Color)
        pnl.Size = New Size(250, 100)
        pnl.BackColor = Color.White
        pnl.Margin = New Padding(0, 0, 20, 0)

        title.Text = titleText
        title.Font = New Font("Segoe UI", 8.5!, FontStyle.Bold)
        title.ForeColor = Color.DarkGray
        title.Location = New Point(15, 15)
        title.AutoSize = True

        count.Font = New Font("Segoe UI", 22.0!, FontStyle.Bold)
        count.ForeColor = accentColor
        count.Location = New Point(12, 35)
        count.AutoSize = True

        pnl.Controls.Add(title)
        pnl.Controls.Add(count)
    End Sub

    Private Sub dashboardteacher_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        RefreshDashboard()
    End Sub

    Public Sub RefreshDashboard()
        Try
            openConn() ' From your Module

            ' Update Cards
            Using cmdS = cmd("SELECT COUNT(*) FROM students")
                lblCountStudents.Text = cmdS.ExecuteScalar().ToString()
            End Using

            Using cmdC = cmd("SELECT COUNT(*) FROM courses")
                lblCountCourses.Text = cmdC.ExecuteScalar().ToString()
            End Using

            ' Update Grid
            Dim sql = "SELECT s.student_id, s.first_name, s.last_name, c.course_name FROM students s " &
                      "LEFT JOIN enrollments e ON s.student_id = e.student_id " &
                      "LEFT JOIN courses c ON e.course_id = c.course_id"

            Dim adapter As New MySqlDataAdapter(cmd(sql))
            Dim dt As New DataTable()
            adapter.Fill(dt)
            dgvModern.DataSource = dt

        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            closeConn()
        End Try
    End Sub
End Class