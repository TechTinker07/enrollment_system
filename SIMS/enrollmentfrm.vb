Imports System.Data.SqlClient
Imports MySql.Data.MySqlClient

Public Class enrollmentfrm

    Private Sub enrollmentfrm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadStudents()
        LoadCourses()
        LoadSchedules()
    End Sub

    Private Sub LoadStudents()
        Try
            openConn()
            Dim da As New MySqlDataAdapter(cmd("SELECT student_id, CONCAT(last_name, ', ', first_name) AS name FROM students ORDER BY last_name, first_name"))
            Dim dt As New DataTable
            da.Fill(dt)
            cmbStudent.DataSource = dt
            cmbStudent.DisplayMember = "name"
            cmbStudent.ValueMember = "student_id"
        Catch ex As Exception
            MsgBox("Error loading students: " & ex.Message)
        Finally
            closeConn()
        End Try
    End Sub

    Private Sub LoadCourses()
        Try
            openConn()
            Dim da As New MySqlDataAdapter(cmd("SELECT course_id, course_name FROM courses ORDER BY course_name"))
            Dim dt As New DataTable
            da.Fill(dt)
            cmbCourse.DataSource = dt
            cmbCourse.DisplayMember = "course_name"
            cmbCourse.ValueMember = "course_id"
        Catch ex As Exception
            MsgBox("Error loading courses: " & ex.Message)
        Finally
            closeConn()
        End Try
    End Sub

    Private Sub LoadSchedules()
        Try
            openConn()
            Dim query As String =
                "SELECT s.schedule_id, sub.subject_code, sub.subject_title, sub.units, s.section, s.days, s.time_start, s.time_end, s.room " &
                "FROM schedules s " &
                "JOIN subjects sub ON s.subject_id = sub.subject_id " &
                "ORDER BY s.section, sub.subject_code"

            Dim da As New MySqlDataAdapter(cmd(query))
            Dim dt As New DataTable
            da.Fill(dt)
            dgvSchedules.DataSource = dt

            If dgvSchedules.Columns("select_col") Is Nothing Then
                Dim chk As New DataGridViewCheckBoxColumn()
                chk.Name = "select_col"
                chk.HeaderText = "Select"
                dgvSchedules.Columns.Insert(0, chk)
            End If
        Catch ex As Exception
            MsgBox("Error loading schedules: " & ex.Message)
        Finally
            closeConn()
        End Try
    End Sub

    Private Function DaysOverlap(dayA As String, dayB As String) As Boolean
        Dim days1 = dayA.Split(","c).Select(Function(x) x.Trim().ToLower()).ToList()
        Dim days2 = dayB.Split(","c).Select(Function(x) x.Trim().ToLower()).ToList()
        Return days1.Intersect(days2).Any()
    End Function

    Private Function TimeOverlap(startA As TimeSpan, endA As TimeSpan, startB As TimeSpan, endB As TimeSpan) As Boolean
        Return startA < endB AndAlso startB < endA
    End Function

    Private Sub btnConfirmEnroll_Click(sender As Object, e As EventArgs) Handles btnConfirmEnroll.Click
        If cmbStudent.SelectedIndex = -1 OrElse cmbCourse.SelectedIndex = -1 Then
            MsgBox("Please select a student and a course.")
            Exit Sub
        End If

        If String.IsNullOrWhiteSpace(txtSchoolYear.Text) OrElse String.IsNullOrWhiteSpace(cmbSemester.Text) Then
            MsgBox("Please enter school year and semester.")
            Exit Sub
        End If

        Dim selectedRows As New List(Of DataGridViewRow)
        For Each row As DataGridViewRow In dgvSchedules.Rows
            If row.Cells("select_col").Value IsNot Nothing AndAlso Convert.ToBoolean(row.Cells("select_col").Value) Then
                selectedRows.Add(row)
            End If
        Next

        If selectedRows.Count = 0 Then
            MsgBox("Please select at least one subject.")
            Exit Sub
        End If

        Dim firstSection As String = selectedRows(0).Cells("section").Value.ToString()
        Dim subjectCodes As New HashSet(Of String)(StringComparer.OrdinalIgnoreCase)

        For i As Integer = 0 To selectedRows.Count - 1
            Dim rowA = selectedRows(i)

            If rowA.Cells("section").Value.ToString() <> firstSection Then
                MsgBox("All selected schedules must belong to the same section.", MsgBoxStyle.Exclamation)
                Exit Sub
            End If

            Dim subjectCode As String = rowA.Cells("subject_code").Value.ToString()
            If subjectCodes.Contains(subjectCode) Then
                MsgBox("Duplicate subject detected: " & subjectCode, MsgBoxStyle.Exclamation)
                Exit Sub
            End If
            subjectCodes.Add(subjectCode)

            For j As Integer = i + 1 To selectedRows.Count - 1
                Dim rowB = selectedRows(j)

                Dim daysA As String = rowA.Cells("days").Value.ToString()
                Dim daysB As String = rowB.Cells("days").Value.ToString()

                Dim startA As TimeSpan = CType(rowA.Cells("time_start").Value, TimeSpan)
                Dim endA As TimeSpan = CType(rowA.Cells("time_end").Value, TimeSpan)
                Dim startB As TimeSpan = CType(rowB.Cells("time_start").Value, TimeSpan)
                Dim endB As TimeSpan = CType(rowB.Cells("time_end").Value, TimeSpan)

                If DaysOverlap(daysA, daysB) AndAlso TimeOverlap(startA, endA, startB, endB) Then
                    MsgBox("Schedule conflict detected between selected subjects.", MsgBoxStyle.Critical)
                    Exit Sub
                End If
            Next
        Next

        Try
            openConn()

            Dim checkQuery As String = "SELECT COUNT(*) FROM enrollments WHERE student_id = @sid AND school_year = @sy AND semester = @sem AND status <> 'dropped'"
            Using checkCmd As MySqlCommand = cmd(checkQuery)
                checkCmd.Parameters.AddWithValue("@sid", cmbStudent.SelectedValue)
                checkCmd.Parameters.AddWithValue("@sy", txtSchoolYear.Text.Trim())
                checkCmd.Parameters.AddWithValue("@sem", cmbSemester.Text.Trim())

                If Convert.ToInt32(checkCmd.ExecuteScalar()) > 0 Then
                    MsgBox("This student already has an enrollment record for the selected term.", MsgBoxStyle.Exclamation)
                    Exit Sub
                End If
            End Using

            Dim transaction As MySqlTransaction = conn.BeginTransaction()

            Try
                Dim enrollQuery As String =
                    "INSERT INTO enrollments (student_id, course_id, school_year, semester, enrollment_date, status) " &
                    "VALUES (@sid, @cid, @sy, @sem, CURDATE(), 'enrolled'); SELECT LAST_INSERT_ID();"

                Dim newEnrollID As Integer
                Using enrollCmd As MySqlCommand = New MySqlCommand(enrollQuery, conn, transaction)
                    enrollCmd.Parameters.AddWithValue("@sid", cmbStudent.SelectedValue)
                    enrollCmd.Parameters.AddWithValue("@cid", cmbCourse.SelectedValue)
                    enrollCmd.Parameters.AddWithValue("@sy", txtSchoolYear.Text.Trim())
                    enrollCmd.Parameters.AddWithValue("@sem", cmbSemester.Text.Trim())
                    newEnrollID = Convert.ToInt32(enrollCmd.ExecuteScalar())
                End Using

                Dim totalUnits As Integer = 0
                For Each row As DataGridViewRow In selectedRows
                    Using detailCmd As New MySqlCommand("INSERT INTO enrollment_details (enrollment_id, schedule_id) VALUES (@eid, @sid)", conn, transaction)
                        detailCmd.Parameters.AddWithValue("@eid", newEnrollID)
                        detailCmd.Parameters.AddWithValue("@sid", Convert.ToInt32(row.Cells("schedule_id").Value))
                        detailCmd.ExecuteNonQuery()
                    End Using

                    totalUnits += Convert.ToInt32(row.Cells("units").Value)
                Next

                Dim tuitionPerUnit As Decimal = 500D
                Dim miscFee As Decimal = 1500D
                Dim totalAmount As Decimal = (totalUnits * tuitionPerUnit) + miscFee

                Using billCmd As New MySqlCommand("INSERT INTO billing (enrollment_id, total_amount, paid_amount, due_date) VALUES (@eid, @amt, 0.00, DATE_ADD(CURDATE(), INTERVAL 30 DAY))", conn, transaction)
                    billCmd.Parameters.AddWithValue("@eid", newEnrollID)
                    billCmd.Parameters.AddWithValue("@amt", totalAmount)
                    billCmd.ExecuteNonQuery()
                End Using

                transaction.Commit()
                MsgBox("Enrollment successful." & vbCrLf &
                       "Section: " & firstSection & vbCrLf &
                       "Units: " & totalUnits & vbCrLf &
                       "Total Assessment: P" & totalAmount.ToString("N2"), MsgBoxStyle.Information)
                Me.Close()

            Catch ex As Exception
                transaction.Rollback()
                MsgBox("Enrollment failed: " & ex.Message, MsgBoxStyle.Critical)
            End Try

        Catch ex As Exception
            MsgBox("Database error: " & ex.Message, MsgBoxStyle.Critical)
        Finally
            closeConn()
        End Try
    End Sub

End Class
