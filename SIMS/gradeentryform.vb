Imports MySql.Data.MySqlClient

Public Class gradeentryform
    Private SelectedGradeID As Integer = 0

    Private Sub gradeentryform_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadStudents()
        LoadSubjects()
        LoadGradesTable()
        ClearForm()
    End Sub

    ' === VALIDATION LOGIC: Auto-Remarks ===
    Private Sub LoadStudents()
        Try
            openConn()
            Dim adp As New MySqlDataAdapter(
            "SELECT s.student_id, CONCAT(s.student_id, ' - ', s.last_name, ', ', s.first_name) AS display_name
             FROM students s
             JOIN enrollments e ON s.student_id = e.student_id
             WHERE e.status = 'enrolled'
             ORDER BY s.last_name ASC", conn)
            Dim dt As New DataTable
            adp.Fill(dt)
            cboStudent.DataSource = dt
            cboStudent.DisplayMember = "display_name"
            cboStudent.ValueMember = "student_id"
            cboStudent.SelectedIndex = -1
        Catch ex As Exception
            MsgBox("Error loading students: " & ex.Message, MsgBoxStyle.Critical)
        Finally
            closeConn()
        End Try
    End Sub
    Private Sub txtGrade_TextChanged(sender As Object, e As EventArgs) Handles txtGrade.TextChanged
        Dim val As Double
        If Double.TryParse(txtGrade.Text, val) Then
            ' Validation: Standard college grading (1.0 is highest, 3.0 is pass, 5.0 is fail)
            If val >= 1.0 And val <= 3.0 Then
                txtRemarks.Text = "PASSED"
                txtRemarks.ForeColor = Color.Green
            ElseIf val > 3.0 And val <= 5.0 Then
                txtRemarks.Text = "FAILED"
                txtRemarks.ForeColor = Color.Red
            Else
                txtRemarks.Text = "INVALID"
                txtRemarks.ForeColor = Color.Orange
            End If
        Else
            txtRemarks.Clear()
        End If
    End Sub

    ' === SAVE LOGIC with Database Validations ===
    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        ' 1. Client-side Validation
        If cboStudent.SelectedIndex = -1 OrElse cboStudent.SelectedValue Is Nothing Then
            MsgBox("Error: Please select a student.", MsgBoxStyle.Critical)
            Return
        End If

        If cboSubject.SelectedIndex = -1 Then
            MsgBox("Error: Please select a subject.", MsgBoxStyle.Exclamation)
            Return
        End If

        Dim gValue As Double
        If Not Double.TryParse(txtGrade.Text, gValue) OrElse gValue < 1.0 OrElse gValue > 5.0 Then
            MsgBox("Error: Please enter a valid grade between 1.0 and 5.0.", MsgBoxStyle.Exclamation)
            Return
        End If

        Try
            openConn()

            ' 2. Check if student is actually enrolled (txtEnrollmentID stores Student ID)
            Dim checkQuery As String = "SELECT enrollment_id FROM enrollments WHERE student_id = @sid AND status = 'enrolled' LIMIT 1"
            Dim checkCmd As New MySqlCommand(checkQuery, conn)
            checkCmd.Parameters.AddWithValue("@sid", cboStudent.SelectedValue)
            Dim enrollId = checkCmd.ExecuteScalar()

            If enrollId Is Nothing Then
                MsgBox("Validation Error: This Student ID is not currently enrolled.", MsgBoxStyle.Critical)
                Return
            End If

            ' Check if subject is part of student's enrolled subjects
            Dim subjectCheck As New MySqlCommand(
            "SELECT COUNT(*) FROM enrollment_details ed
             JOIN schedules sc ON ed.schedule_id = sc.schedule_id
             WHERE ed.enrollment_id = @eid
             AND sc.subject_id = @subid", conn)
            subjectCheck.Parameters.AddWithValue("@eid", enrollId)
            subjectCheck.Parameters.AddWithValue("@subid", cboSubject.SelectedValue)

            If Convert.ToInt32(subjectCheck.ExecuteScalar()) = 0 Then
                MsgBox("Validation Error: This subject is not part of the student's enrolled subjects.", MsgBoxStyle.Critical)
                Return
            End If

            If SelectedGradeID = 0 Then
                Dim duplicateCheck As New MySqlCommand("SELECT COUNT(*) FROM grades WHERE enrollment_id = @eid AND subject_id = @subid", conn)
                duplicateCheck.Parameters.AddWithValue("@eid", enrollId)
                duplicateCheck.Parameters.AddWithValue("@subid", cboSubject.SelectedValue)

                If Convert.ToInt32(duplicateCheck.ExecuteScalar()) > 0 Then
                    MsgBox("A grade for this subject already exists for the selected student.", MsgBoxStyle.Exclamation)
                    Return
                End If
            End If

            ' 3. Perform Insert/Update
            Dim sql As String = ""
            If SelectedGradeID = 0 Then
                sql = "INSERT INTO grades (enrollment_id, subject_id, grade_value, remarks) VALUES (@eid, @subid, @val, @rem)"
            Else
                sql = "UPDATE grades SET grade_value=@val, remarks=@rem WHERE grade_id=@gid"
            End If

            Dim cmdObj = cmd(sql)
            cmdObj.Parameters.AddWithValue("@eid", enrollId)
            cmdObj.Parameters.AddWithValue("@subid", cboSubject.SelectedValue)
            cmdObj.Parameters.AddWithValue("@val", gValue)
            cmdObj.Parameters.AddWithValue("@rem", txtRemarks.Text)
            If SelectedGradeID <> 0 Then cmdObj.Parameters.AddWithValue("@gid", SelectedGradeID)

            cmdObj.ExecuteNonQuery()
            MsgBox("Success: Grade has been recorded.", MsgBoxStyle.Information)

            ClearForm()
            LoadGradesTable()

        Catch ex As Exception
            MsgBox("System Error: " & ex.Message)
        Finally
            closeConn()
        End Try
    End Sub

    ' === Loading Data ===
    Private Sub LoadGradesTable(Optional filter As String = "")
        Try
            openConn()
            Dim sql As String = "SELECT g.grade_id, s.student_id, CONCAT(s.first_name, ' ', s.last_name) as student, " &
                               "sub.subject_title, g.grade_value, g.remarks " &
                               "FROM grades g " &
                               "JOIN enrollments e ON g.enrollment_id = e.enrollment_id " &
                               "JOIN students s ON e.student_id = s.student_id " &
                               "JOIN subjects sub ON g.subject_id = sub.subject_id"

            If filter <> "" Then sql &= " WHERE s.student_id LIKE @f OR s.last_name LIKE @f"

            Dim adp As New MySqlDataAdapter(sql, conn)
            If filter <> "" Then
                adp.SelectCommand.Parameters.AddWithValue("@f", "%" & filter & "%")
            End If
            Dim dt As New DataTable
            adp.Fill(dt)
            dgvGrades.DataSource = dt
            dgvGrades.Columns(0).Visible = False ' Hide grade_id
        Catch ex As Exception
            MsgBox("Error loading grades: " & ex.Message, MsgBoxStyle.Critical)
        Finally
            closeConn()
        End Try
    End Sub

    Private Sub LoadSubjects()
        Try
            openConn()
            Dim adp As New MySqlDataAdapter("SELECT subject_id, subject_title FROM subjects", conn)
            Dim dt As New DataTable
            adp.Fill(dt)
            cboSubject.DataSource = dt
            cboSubject.DisplayMember = "subject_title"
            cboSubject.ValueMember = "subject_id"
        Catch ex As Exception
            MsgBox("Error loading subjects: " & ex.Message, MsgBoxStyle.Critical)
        Finally
            closeConn()
        End Try
    End Sub

    Private Sub ClearForm()
        SelectedGradeID = 0
        cboStudent.SelectedIndex = -1
        txtGrade.Clear()
        txtRemarks.Clear()
        If cboSubject.Items.Count > 0 Then cboSubject.SelectedIndex = 0
        btnSave.Text = "SAVE GRADE"
    End Sub

    Private Sub dgvGrades_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvGrades.CellClick
        If e.RowIndex < 0 Then Return
        If dgvGrades.Rows(e.RowIndex).IsNewRow Then Return
        If dgvGrades.Rows(e.RowIndex).Cells("grade_id").Value Is Nothing Then Return

        Dim row = dgvGrades.Rows(e.RowIndex)
        SelectedGradeID = Convert.ToInt32(row.Cells("grade_id").Value)
        cboStudent.SelectedValue = row.Cells("student_id").Value.ToString() ' <-- updated
        cboSubject.Text = row.Cells("subject_title").Value.ToString()
        txtGrade.Text = row.Cells("grade_value").Value.ToString()
        txtRemarks.Text = row.Cells("remarks").Value.ToString()
        btnSave.Text = "UPDATE GRADE"
    End Sub

    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        If SelectedGradeID = 0 Then
            MsgBox("Please select a grade record first.", MsgBoxStyle.Exclamation)
            Return
        End If

        If MsgBox("Are you sure you want to delete this grade?", MsgBoxStyle.YesNo + MsgBoxStyle.Question) <> MsgBoxResult.Yes Then
            Return
        End If

        Try
            openConn()
            Dim delCmd As New MySqlCommand("DELETE FROM grades WHERE grade_id = @gid", conn)
            delCmd.Parameters.AddWithValue("@gid", SelectedGradeID)
            delCmd.ExecuteNonQuery()

            MsgBox("Grade deleted successfully.", MsgBoxStyle.Information)
            ClearForm()
            LoadGradesTable()
        Catch ex As Exception
            MsgBox("Error deleting grade: " & ex.Message, MsgBoxStyle.Critical)
        Finally
            closeConn()
        End Try
    End Sub

    Private Sub btnClear_Click(sender As Object, e As EventArgs) Handles btnClear.Click
        ClearForm()
    End Sub

    Private Sub txtSearch_TextChanged(sender As Object, e As EventArgs) Handles txtSearch.TextChanged
        LoadGradesTable(txtSearch.Text.Trim())
    End Sub
End Class
