Imports MySql.Data.MySqlClient

Public Class ScheduleFrm

    ' === LOAD DATA ON FORM START ===
    Private Sub ScheduleFrm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadCourses()
        LoadSubjects()
        RefreshGrid()
    End Sub

    ' === POPULATE COURSES COMBOBOX ===
    Private Sub LoadCourses()
        Try
            openConn()
            Dim dt As New DataTable
            Dim adapter As New MySqlDataAdapter(cmd("SELECT course_id, course_name FROM courses"))
            adapter.Fill(dt)

            cmbCourse.DataSource = dt
            cmbCourse.DisplayMember = "course_name"
            cmbCourse.ValueMember = "course_id"
        Catch ex As Exception
            MsgBox("Error loading courses: " & ex.Message)
        Finally
            closeConn()
        End Try
    End Sub

    ' === POPULATE SUBJECTS COMBOBOX ===
    Private Sub LoadSubjects()
        Try
            openConn()
            Dim dt As New DataTable
            Dim adapter As New MySqlDataAdapter(cmd("SELECT subject_id, subject_title FROM subjects"))
            adapter.Fill(dt)

            cmbSubject.DataSource = dt
            cmbSubject.DisplayMember = "subject_title"
            cmbSubject.ValueMember = "subject_id"
        Catch ex As Exception
            MsgBox("Error loading subjects: " & ex.Message)
        Finally
            closeConn()
        End Try
    End Sub

    ' === REFRESH DATAGRIDVIEW ===
    Private Sub RefreshGrid()
        Try
            openConn()
            Dim dt As New DataTable
            ' Joining schedules with subjects to show the Title instead of just the ID
            Dim query As String = "SELECT s.schedule_id as ID, sub.subject_title as Subject, " &
                                 "s.section as Section, s.days as Days, " &
                                 "s.time_start as Start, s.time_end as End, s.room as Room " &
                                 "FROM schedules s " &
                                 "INNER JOIN subjects sub ON s.subject_id = sub.subject_id"

            Dim adapter As New MySqlDataAdapter(cmd(query))
            adapter.Fill(dt)
            dgvSchedules.DataSource = dt
        Catch ex As Exception
            MsgBox("Error refreshing grid: " & ex.Message)
        Finally
            closeConn()
        End Try
    End Sub

    ' === SAVE BUTTON LOGIC ===
    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        ' Basic Validation
        If cmbSubject.SelectedIndex = -1 Or String.IsNullOrWhiteSpace(txtRoom.Text) Or txtRoom.Text = "Room No." Then
            MsgBox("Please fill in all required fields (Subject and Room).", MsgBoxStyle.Exclamation)
            Return
        End If

        Try
            openConn()
            ' Match exactly with your SQL table: schedules (subject_id, section, days, time_start, time_end, room)
            Dim sql As String = "INSERT INTO schedules (subject_id, section, days, time_start, time_end, room) " &
                                "VALUES (@subId, @sec, @days, @tstart, @tend, @room)"

            Dim run = cmd(sql)
            run.Parameters.AddWithValue("@subId", cmbSubject.SelectedValue)
            run.Parameters.AddWithValue("@sec", txtSection.Text)
            run.Parameters.AddWithValue("@days", txtDays.Text)
            run.Parameters.AddWithValue("@tstart", dtpStart.Value.ToString("HH:mm:ss"))
            run.Parameters.AddWithValue("@tend", dtpEnd.Value.ToString("HH:mm:ss"))
            run.Parameters.AddWithValue("@room", txtRoom.Text)

            run.ExecuteNonQuery()
            MsgBox("Schedule successfully added!", MsgBoxStyle.Information)

            ' Clear inputs and refresh table
            ClearFields()
            RefreshGrid()

        Catch ex As Exception
            MsgBox("Failed to save schedule: " & ex.Message)
        Finally
            closeConn()
        End Try
    End Sub

    ' === HELPER: CLEAR FIELDS ===
    Private Sub ClearFields()
        txtSection.Clear()
        txtDays.Clear()
        txtRoom.Clear()
        cmbSubject.SelectedIndex = -1
        dtpStart.Value = DateTime.Now
        dtpEnd.Value = DateTime.Now
    End Sub

End Class