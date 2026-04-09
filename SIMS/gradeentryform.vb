Imports MySql.Data.MySqlClient

Public Class gradeentryform
    Private SelectedGradeID As Integer = 0

    Private Sub gradeentryform_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadSubjects()
        LoadGradesTable()
    End Sub

    ' === VALIDATION LOGIC: Auto-Remarks ===
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
        If String.IsNullOrWhiteSpace(txtEnrollmentID.Text) Then
            MsgBox("Error: Student ID is required.", MsgBoxStyle.Critical)
            Return
        End If

        Dim gValue As Double
        If Not Double.TryParse(txtGrade.Text, gValue) OrElse gValue < 1.0 OrElse gValue > 5.0 Then
            MsgBox("Error: Please enter a valid grade between 1.0 and 5.0.", MsgBoxStyle.Exclamation)
            Return
        End If

        Try
            openConn()

            ' 2. Check if student is actually enrolled (Database Validation)
            Dim checkQuery As String = "SELECT enrollment_id FROM enrollments WHERE student_id = @sid AND status = 'enrolled' LIMIT 1"
            Dim checkCmd As New MySqlCommand(checkQuery, conn)
            checkCmd.Parameters.AddWithValue("@sid", txtEnrollmentID.Text)
            Dim enrollId = checkCmd.ExecuteScalar()

            If enrollId Is Nothing Then
                MsgBox("Validation Error: This Student ID is not currently enrolled.", MsgBoxStyle.Critical)
                Return
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
            adp.SelectCommand.Parameters.AddWithValue("@f", "%" & filter & "%")
            Dim dt As New DataTable
            adp.Fill(dt)
            dgvGrades.DataSource = dt
            dgvGrades.Columns(0).Visible = False ' Hide grade_id
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
        Finally
            closeConn()
        End Try
    End Sub

    Private Sub ClearForm()
        SelectedGradeID = 0
        txtEnrollmentID.Clear()
        txtGrade.Clear()
        txtRemarks.Clear()
        btnSave.Text = "SAVE GRADE"
    End Sub

    Private Sub dgvGrades_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvGrades.CellContentClick

    End Sub
End Class