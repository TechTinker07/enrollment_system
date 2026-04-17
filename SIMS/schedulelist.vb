Imports MySql.Data.MySqlClient

Public Class schedulelist
    Private subjectDict As New Dictionary(Of String, Integer)
    Private selectedDays As New List(Of Button)

    Private Sub schedulelist_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadStaticOptions()
        LoadSubjects()
        DisplaySchedules()
        ClearInputs()
    End Sub

    Private Sub LoadStaticOptions()
        cmbSection.Items.Clear()
        cmbSection.Items.AddRange(New Object() {"BSIT 1-A", "BSIT 1-B", "BSIT 2-A", "BSTM 1-A"})

        cmbRoom.Items.Clear()
        cmbRoom.Items.AddRange(New Object() {"ROOM 101", "ROOM 102", "LAB 1", "LAB 2", "ROOM 210"})
    End Sub

    Private Sub LoadSubjects()
        Try
            openConn()
            Using cmdSubj As New MySqlCommand("SELECT subject_id, subject_title FROM subjects ORDER BY subject_title ASC", conn)
                Using reader = cmdSubj.ExecuteReader()
                    cmbSubjects.Items.Clear()
                    subjectDict.Clear()

                    While reader.Read()
                        Dim id As Integer = reader.GetInt32("subject_id")
                        Dim title As String = reader.GetString("subject_title")

                        cmbSubjects.Items.Add(title)
                        If Not subjectDict.ContainsKey(title) Then
                            subjectDict.Add(title, id)
                        End If
                    End While
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("Error loading subjects: " & ex.Message, "Schedule Management", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            closeConn()
        End Try
    End Sub

    Private Sub DisplaySchedules(Optional search As String = "")
        Try
            openConn()

            Dim query As String = "SELECT s.schedule_id AS 'ID', " &
                     "sub.subject_title AS 'Subject', " &
                     "s.section AS 'Section', " &
                     "s.days AS 'Days', " &
                     "TIME_FORMAT(s.time_start, '%h:%i %p') AS 'Start Time', " &
                     "TIME_FORMAT(s.time_end, '%h:%i %p') AS 'End Time', " &
                     "s.room AS 'Room' " &
                     "FROM schedules s " &
                     "INNER JOIN subjects sub ON s.subject_id = sub.subject_id"

            If Not String.IsNullOrWhiteSpace(search) Then
                query &= " WHERE sub.subject_title LIKE @search OR s.section LIKE @search OR s.days LIKE @search OR s.room LIKE @search"
            End If

            query &= " ORDER BY sub.subject_title ASC, s.section ASC"

            Using cmdSched As New MySqlCommand(query, conn)
                If Not String.IsNullOrWhiteSpace(search) Then
                    cmdSched.Parameters.AddWithValue("@search", "%" & search.Trim() & "%")
                End If

                Dim dt As New DataTable()
                Using adapter As New MySqlDataAdapter(cmdSched)
                    adapter.Fill(dt)
                    dgvSchedules.DataSource = dt
                End Using
            End Using

            If dgvSchedules.Columns.Contains("ID") Then
                dgvSchedules.Columns("ID").Visible = False
            End If

            If dgvSchedules.Columns.Contains("Subject") Then
                dgvSchedules.Columns("Subject").AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            End If

        Catch ex As Exception
            MessageBox.Show("Error displaying schedules: " & ex.Message, "Schedule Management", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            closeConn()
        End Try
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        If cmbSubjects.SelectedIndex = -1 Then
            MessageBox.Show("Please select a subject.")
            Return
        End If

        If String.IsNullOrWhiteSpace(cmbSection.Text) Then
            MessageBox.Show("Please select or enter a section.")
            Return
        End If

        If String.IsNullOrWhiteSpace(cmbRoom.Text) Then
            MessageBox.Show("Please select or enter a room.")
            Return
        End If

        If selectedDays.Count = 0 Then
            MessageBox.Show("Please select at least one day.")
            Return
        End If

        If dtpEnd.Value <= dtpStart.Value Then
            MessageBox.Show("End time must be later than start time.")
            Return
        End If

        Dim dayTexts As New List(Of String)

        For Each btn As Button In selectedDays
            dayTexts.Add(btn.Text)
        Next

        Dim days As String = String.Join(", ", dayTexts)

        Try
            openConn()

            Dim query As String = "INSERT INTO schedules (subject_id, section, days, time_start, time_end, room) " &
                                  "VALUES (@sid, @sec, @days, @tstart, @tend, @room)"

            Using cmdSave As New MySqlCommand(query, conn)
                cmdSave.Parameters.AddWithValue("@sid", subjectDict(cmbSubjects.SelectedItem.ToString()))
                cmdSave.Parameters.AddWithValue("@sec", cmbSection.Text.Trim())
                cmdSave.Parameters.AddWithValue("@days", days)
                cmdSave.Parameters.AddWithValue("@tstart", dtpStart.Value.ToString("HH:mm:ss"))
                cmdSave.Parameters.AddWithValue("@tend", dtpEnd.Value.ToString("HH:mm:ss"))
                cmdSave.Parameters.AddWithValue("@room", cmbRoom.Text.Trim())
                cmdSave.ExecuteNonQuery()
            End Using

            MessageBox.Show("Schedule saved successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
            ClearInputs()
            DisplaySchedules()

        Catch ex As Exception
            MessageBox.Show("Failed to save: " & ex.Message, "Schedule Management", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            closeConn()
        End Try
    End Sub

    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        If dgvSchedules.SelectedRows.Count = 0 Then
            MessageBox.Show("Please select a schedule to delete.")
            Return
        End If

        Dim res = MessageBox.Show("Are you sure you want to delete this schedule?", "Confirm Action", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)
        If res <> DialogResult.Yes Then Return

        Try
            Dim scheduleId As Integer = Convert.ToInt32(dgvSchedules.SelectedRows(0).Cells("ID").Value)

            openConn()
            Using cmdDel As New MySqlCommand("DELETE FROM schedules WHERE schedule_id = @id", conn)
                cmdDel.Parameters.AddWithValue("@id", scheduleId)
                cmdDel.ExecuteNonQuery()
            End Using

            Dim searchText As String = txtSearch.Text.Trim()
            If searchText = "Search schedules..." Then
                searchText = ""
            End If

            DisplaySchedules(searchText)
            ClearInputs()

        Catch ex As Exception
            MessageBox.Show("Error deleting record: " & ex.Message, "Schedule Management", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            closeConn()
        End Try
    End Sub

    Private Sub ClearInputs()
        cmbSubjects.SelectedIndex = -1
        cmbSection.SelectedIndex = -1
        cmbSection.Text = ""
        cmbRoom.SelectedIndex = -1
        cmbRoom.Text = ""
        dtpStart.Value = DateTime.Now
        dtpEnd.Value = DateTime.Now.AddHours(1)
        ClearDays()
    End Sub

    Private Sub ToggleDay(btn As Button)
        If selectedDays.Contains(btn) Then
            selectedDays.Remove(btn)
            btn.BackColor = Color.White
            btn.ForeColor = ColorTranslator.FromHtml("#AAAAAA")
            btn.FlatAppearance.BorderColor = ColorTranslator.FromHtml("#B0B0B0")
        Else
            selectedDays.Add(btn)
            btn.BackColor = ColorTranslator.FromHtml("#7A0C22")
            btn.ForeColor = Color.White
            btn.FlatAppearance.BorderColor = ColorTranslator.FromHtml("#5A0918")
        End If
    End Sub

    Private Sub ClearDays()
        For Each btn As Button In selectedDays.ToList()
            btn.BackColor = Color.White
            btn.ForeColor = ColorTranslator.FromHtml("#AAAAAA")
            btn.FlatAppearance.BorderColor = ColorTranslator.FromHtml("#B0B0B0")
        Next
        selectedDays.Clear()
    End Sub

    Private Sub btnMon_Click(sender As Object, e As EventArgs) Handles btnMon.Click
        ToggleDay(btnMon)
    End Sub

    Private Sub btnTues_Click(sender As Object, e As EventArgs) Handles btnTues.Click
        ToggleDay(btnTues)
    End Sub

    Private Sub btnWed_Click(sender As Object, e As EventArgs) Handles btnWed.Click
        ToggleDay(btnWed)
    End Sub

    Private Sub btnThurs_Click(sender As Object, e As EventArgs) Handles btnThurs.Click
        ToggleDay(btnThurs)
    End Sub

    Private Sub btnFri_Click(sender As Object, e As EventArgs) Handles btnFri.Click
        ToggleDay(btnFri)
    End Sub

    Private Sub btnSat_Click(sender As Object, e As EventArgs) Handles btnSat.Click
        ToggleDay(btnSat)
    End Sub

    Private Sub txtSearch_Enter(sender As Object, e As EventArgs) Handles txtSearch.Enter
        If txtSearch.Text = "Search schedules..." Then
            txtSearch.Text = ""
        End If
    End Sub

    Private Sub txtSearch_Leave(sender As Object, e As EventArgs) Handles txtSearch.Leave
        If String.IsNullOrWhiteSpace(txtSearch.Text) Then
            txtSearch.Text = "Search schedules..."
        End If
    End Sub

    Private Sub txtSearch_TextChanged(sender As Object, e As EventArgs) Handles txtSearch.TextChanged
        If txtSearch.Text = "Search schedules..." Then Return
        DisplaySchedules(txtSearch.Text)
    End Sub
End Class
