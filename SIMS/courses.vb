Imports MySql.Data.MySqlClient

Public Class courses

    ' --- INITIAL LOAD ---
    Private Sub courses_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        txtCourseID.ReadOnly = True

        ' MANUALLY WIRE UP EVENTS (Fixes BC30506)
        AddHandler btnAdd.Click, AddressOf btnAdd_Click
        AddHandler btnEdit.Click, AddressOf btnEdit_Click
        AddHandler btnDelete.Click, AddressOf btnDelete_Click
        AddHandler btnClear.Click, AddressOf btnClear_Click
        AddHandler txtSearch.TextChanged, AddressOf txtSearch_TextChanged
        AddHandler dgvCourses.CellClick, AddressOf dgvCourses_CellClick

        LoadCourses()
    End Sub

    ' --- REUSABLE LOAD FUNCTION ---
    Private Sub LoadCourses(Optional searchTerm As String = "")
        Try
            openConn()
            Dim query As String = "SELECT course_id AS 'ID', course_code AS 'Code', course_name AS 'Course Name' FROM courses"

            If Not String.IsNullOrEmpty(searchTerm) Then
                query &= " WHERE course_code LIKE @search OR course_name LIKE @search"
            End If

            Using command As New MySqlCommand(query, conn)
                If Not String.IsNullOrEmpty(searchTerm) Then
                    command.Parameters.AddWithValue("@search", "%" & searchTerm & "%")
                End If

                Dim adapter As New MySqlDataAdapter(command)
                Dim table As New DataTable()
                adapter.Fill(table)
                dgvCourses.DataSource = table
            End Using
        Catch ex As Exception
            MsgBox("Error loading data: " & ex.Message)
        Finally
            closeConn()
        End Try
    End Sub

    ' --- EVENT HANDLERS (Removed 'Handles' keyword) ---

    Private Sub btnAdd_Click(sender As Object, e As EventArgs)
        ' Logic remains the same...
        If String.IsNullOrWhiteSpace(txtCourseName.Text) Then
            MsgBox("Please enter a course name.")
            Exit Sub
        End If

        Try
            openConn()
            ' Note: course_id is AUTO_INCREMENT, so we only insert code and name
            Dim query As String = "INSERT INTO courses (course_code, course_name) VALUES (@code, @name)"
            Using command As New MySqlCommand(query, conn)
                ' Using a dummy code for now since your form lacks a Code textbox
                command.Parameters.AddWithValue("@code", "C-" & Now.Ticks.ToString().Substring(10))
                command.Parameters.AddWithValue("@name", txtCourseName.Text)

                command.ExecuteNonQuery()
                MsgBox("Course added successfully!")
                ClearFields()
            End Using
        Catch ex As Exception
            MsgBox("Insert failed: " & ex.Message)
        Finally
            closeConn()
        End Try
    End Sub

    Private Sub btnEdit_Click(sender As Object, e As EventArgs)
        If String.IsNullOrWhiteSpace(txtCourseID.Text) Then
            MsgBox("Select a course from the list to edit.")
            Exit Sub
        End If

        Try
            openConn()
            Dim query As String = "UPDATE courses SET course_name=@name WHERE course_id=@id"
            Using command As New MySqlCommand(query, conn)
                command.Parameters.AddWithValue("@name", txtCourseName.Text)
                command.Parameters.AddWithValue("@id", txtCourseID.Text)
                command.ExecuteNonQuery()
                MsgBox("Course updated!")
                LoadCourses()
            End Using
        Catch ex As Exception
            MsgBox("Update failed: " & ex.Message)
        Finally
            closeConn()
        End Try
    End Sub

    Private Sub btnDelete_Click(sender As Object, e As EventArgs)
        If String.IsNullOrWhiteSpace(txtCourseID.Text) Then Exit Sub

        If MsgBox("Are you sure?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
            Try
                openConn()
                Dim query As String = "DELETE FROM courses WHERE course_id=@id"
                Using command As New MySqlCommand(query, conn)
                    command.Parameters.AddWithValue("@id", txtCourseID.Text)
                    command.ExecuteNonQuery()
                    ClearFields()
                End Using
            Catch ex As Exception
                MsgBox("Delete failed: " & ex.Message)
            Finally
                closeConn()
            End Try
        End If
    End Sub

    Private Sub txtSearch_TextChanged(sender As Object, e As EventArgs)
        LoadCourses(txtSearch.Text)
    End Sub

    Private Sub dgvCourses_CellClick(sender As Object, e As DataGridViewCellEventArgs)
        If e.RowIndex >= 0 Then
            Dim row As DataGridViewRow = dgvCourses.Rows(e.RowIndex)
            txtCourseID.Text = row.Cells("ID").Value.ToString()
            txtCourseName.Text = row.Cells("Course Name").Value.ToString()
        End If
    End Sub

    Private Sub btnClear_Click(sender As Object, e As EventArgs)
        ClearFields()
    End Sub

    Private Sub ClearFields()
        txtCourseID.Clear()
        txtCourseName.Clear()
        txtSearch.Clear()
        LoadCourses()
    End Sub
End Class