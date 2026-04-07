Imports MySql.Data.MySqlClient

Public Class Subjects
    ' We store the ID of the clicked row here so we know WHICH subject to Edit or Delete
    Private selectedSubjectID As Integer = 0

    Private Sub Subjects_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Wire up events manually to fix the BC30506 / BC30451 errors
        AddHandler btnAdd.Click, AddressOf btnAdd_Click
        AddHandler btnEdit.Click, AddressOf btnEdit_Click
        AddHandler btnDelete.Click, AddressOf btnDelete_Click
        AddHandler txtSearch.TextChanged, AddressOf txtSearch_TextChanged
        AddHandler dgvSubjects.CellClick, AddressOf dgvSubjects_CellClick

        LoadSubjects()
    End Sub

    ' --- LOAD DATA ---
    Private Sub LoadSubjects(Optional search As String = "")
        Try
            openConn()
            Dim query As String = "SELECT subject_id, subject_code AS 'Code', subject_title AS 'Title', units AS 'Units' FROM subjects"

            If Not String.IsNullOrEmpty(search) Then
                query &= " WHERE subject_code LIKE @s OR subject_title LIKE @s"
            End If

            Using cmd As New MySqlCommand(query, conn)
                cmd.Parameters.AddWithValue("@s", "%" & search & "%")
                Dim adp As New MySqlDataAdapter(cmd)
                Dim dt As New DataTable()
                adp.Fill(dt)
                dgvSubjects.DataSource = dt

                ' Hide the numeric ID from the user (they don't need to see it)
                If dgvSubjects.Columns.Contains("subject_id") Then
                    dgvSubjects.Columns("subject_id").Visible = False
                End If
            End Using
        Catch ex As Exception
            MsgBox("Load Error: " & ex.Message)
        Finally
            closeConn()
        End Try
    End Sub

    ' --- ADD NEW SUBJECT ---
    Private Sub btnAdd_Click(sender As Object, e As EventArgs)
        If String.IsNullOrWhiteSpace(txtSubjectCode.Text) Or String.IsNullOrWhiteSpace(txtSubjectTitle.Text) Then
            MsgBox("Please fill in the Code and Title.")
            Exit Sub
        End If

        Try
            openConn()
            Dim query As String = "INSERT INTO subjects (subject_code, subject_title, units) VALUES (@code, @title, @units)"
            Using cmd As New MySqlCommand(query, conn)
                cmd.Parameters.AddWithValue("@code", txtSubjectCode.Text)
                cmd.Parameters.AddWithValue("@title", txtSubjectTitle.Text)
                cmd.Parameters.AddWithValue("@units", Val(txtUnits.Text))
                cmd.ExecuteNonQuery()
                MsgBox("Subject added successfully!")
                ClearFields()
            End Using
        Catch ex As Exception
            MsgBox("Insert Error: " & ex.Message)
        Finally
            closeConn()
        End Try
    End Sub

    ' --- EDIT EXISTING SUBJECT ---
    Private Sub btnEdit_Click(sender As Object, e As EventArgs)
        If selectedSubjectID = 0 Then
            MsgBox("Please select a subject from the list first.")
            Exit Sub
        End If

        Try
            openConn()
            Dim query As String = "UPDATE subjects SET subject_code=@code, subject_title=@title, units=@units WHERE subject_id=@id"
            Using cmd As New MySqlCommand(query, conn)
                cmd.Parameters.AddWithValue("@code", txtSubjectCode.Text)
                cmd.Parameters.AddWithValue("@title", txtSubjectTitle.Text)
                cmd.Parameters.AddWithValue("@units", Val(txtUnits.Text))
                cmd.Parameters.AddWithValue("@id", selectedSubjectID)
                cmd.ExecuteNonQuery()
                MsgBox("Subject updated!")
                ClearFields()
            End Using
        Catch ex As Exception
            MsgBox("Update Error: " & ex.Message)
        Finally
            closeConn()
        End Try
    End Sub

    ' --- DELETE SUBJECT ---
    Private Sub btnDelete_Click(sender As Object, e As EventArgs)
        If selectedSubjectID = 0 Then Exit Sub

        Dim result = MsgBox("Are you sure you want to delete this subject?", MsgBoxStyle.YesNo + MsgBoxStyle.Critical)
        If result = MsgBoxResult.Yes Then
            Try
                openConn()
                Dim query As String = "DELETE FROM subjects WHERE subject_id=@id"
                Using cmd As New MySqlCommand(query, conn)
                    cmd.Parameters.AddWithValue("@id", selectedSubjectID)
                    cmd.ExecuteNonQuery()
                    MsgBox("Subject removed.")
                    ClearFields()
                End Using
            Catch ex As Exception
                MsgBox("Delete Error: " & ex.Message)
            Finally
                closeConn()
            End Try
        End If
    End Sub

    ' --- HELPER: SEARCH ---
    Private Sub txtSearch_TextChanged(sender As Object, e As EventArgs)
        LoadSubjects(txtSearch.Text)
    End Sub

    ' --- HELPER: SELECT FROM GRID ---
    Private Sub dgvSubjects_CellClick(sender As Object, e As DataGridViewCellEventArgs)
        If e.RowIndex >= 0 Then
            Dim row As DataGridViewRow = dgvSubjects.Rows(e.RowIndex)
            selectedSubjectID = CInt(row.Cells("subject_id").Value)
            txtSubjectCode.Text = row.Cells("Code").Value.ToString()
            txtSubjectTitle.Text = row.Cells("Title").Value.ToString()
            txtUnits.Text = row.Cells("Units").Value.ToString()
        End If
    End Sub

    ' --- HELPER: CLEAR ---
    Private Sub ClearFields()
        txtSubjectCode.Clear()
        txtSubjectTitle.Clear()
        txtUnits.Clear()
        selectedSubjectID = 0
        LoadSubjects()
    End Sub
End Class