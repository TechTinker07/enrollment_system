Imports MySql.Data.MySqlClient

Public Class gradeslistfrm

    ' I-load ang lahat ng kailangan pagbukas ng form
    Private Sub gradeslistfrm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadSubjectsToFilter()
        LoadMasterList()
    End Sub

    ' === 1. LOAD SUBJECTS TO DROPDOWN ===
    Private Sub LoadSubjectsToFilter()
        Try
            openConn()
            Dim dt As New DataTable
            ' Kumukuha tayo ng listahan ng subjects para sa filter
            Dim adp As New MySqlDataAdapter("SELECT subject_id, subject_title FROM subjects ORDER BY subject_title ASC", conn)
            adp.Fill(dt)

            ' Magdagdag ng "ALL SUBJECTS" option sa pinakataas
            Dim row As DataRow = dt.NewRow()
            row("subject_id") = 0
            row("subject_title") = "--- ALL SUBJECTS ---"
            dt.Rows.InsertAt(row, 0)

            cboSubjectFilter.DataSource = dt
            cboSubjectFilter.DisplayMember = "subject_title"
            cboSubjectFilter.ValueMember = "subject_id"
        Catch ex As Exception
            MsgBox("Error loading filters: " & ex.Message)
        Finally
            closeConn()
        End Try
    End Sub

    ' === 2. MAIN LOAD & SEARCH LOGIC ===
    ' Ginagamit natin ang JOINs base sa simsdb schema mo
    Private Sub LoadMasterList()
        Try
            openConn()
            Dim sql As String = "SELECT s.student_id AS 'Student ID', " &
                               "CONCAT(s.last_name, ', ', s.first_name) AS 'Full Name', " &
                               "sub.subject_code AS 'Code', " &
                               "sub.subject_title AS 'Subject', " &
                               "g.grade_value AS 'Grade', " &
                               "g.remarks AS 'Remarks' " &
                               "FROM grades g " &
                               "INNER JOIN enrollments e ON g.enrollment_id = e.enrollment_id " &
                               "INNER JOIN students s ON e.student_id = s.student_id " &
                               "INNER JOIN subjects sub ON g.subject_id = sub.subject_id " &
                               "WHERE 1=1" ' 1=1 is a trick to easily append AND conditions

            ' Filter by Search (Name or ID)
            If Not String.IsNullOrWhiteSpace(txtSearch.Text) Then
                sql &= " AND (s.student_id LIKE @search OR s.last_name LIKE @search OR s.first_name LIKE @search)"
            End If

            ' Filter by Subject Dropdown
            If cboSubjectFilter.SelectedValue IsNot Nothing AndAlso Val(cboSubjectFilter.SelectedValue) > 0 Then
                sql &= " AND sub.subject_id = @subid"
            End If

            Dim cmdObj As New MySqlCommand(sql, conn)
            cmdObj.Parameters.AddWithValue("@search", "%" & txtSearch.Text & "%")
            cmdObj.Parameters.AddWithValue("@subid", cboSubjectFilter.SelectedValue)

            Dim adp As New MySqlDataAdapter(cmdObj)
            Dim dt As New DataTable
            adp.Fill(dt)
            dgvGradesList.DataSource = dt

            ' Modern Header Styling (Rename or tweak columns if needed)
            dgvGradesList.Columns("Grade").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgvGradesList.Columns("Remarks").DefaultCellStyle.Font = New Font("Segoe UI Semibold", 9.5!)

        Catch ex As Exception
            MsgBox("Error loading list: " & ex.Message)
        Finally
            closeConn()
        End Try
    End Sub

    ' === 3. EVENT HANDLERS (Interaction) ===

    ' Kapag nag-type sa Search Bar
    Private Sub txtSearch_TextChanged(sender As Object, e As EventArgs) Handles txtSearch.TextChanged
        LoadMasterList()
    End Sub

    ' Kapag pumili ng subject sa Dropdown
    Private Sub cboSubjectFilter_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboSubjectFilter.SelectedIndexChanged
        ' Siguraduhin na hindi mag-eerror habang naglo-load pa lang ang form
        If cboSubjectFilter.Focused Then
            LoadMasterList()
        End If
    End Sub

    ' Refresh Button
    Private Sub btnRefresh_Click(sender As Object, e As EventArgs) Handles btnRefresh.Click
        txtSearch.Clear()
        cboSubjectFilter.SelectedIndex = 0
        LoadMasterList()
    End Sub

End Class