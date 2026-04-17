Imports MySql.Data.MySqlClient

Public Class courselist
    ' Ito ang magsasabi kung nag-e-edit tayo o nag-a-add ng bago
    Dim selectedID As Integer = 0

    Private Sub courselist_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadCourses()
    End Sub

    ' 1. READ: Hinahatak ang lahat ng courses mula sa database patungong Grid
    Private Sub LoadCourses()
        Try
            openConn()
            Dim query As String = "SELECT course_id AS 'ID', course_code AS 'Course Code', " &
                                 "course_name AS 'Course Name', description AS 'Description' " &
                                 "FROM courses ORDER BY course_id DESC"

            Dim da As New MySqlDataAdapter(query, conn)
            Dim dt As New DataTable
            da.Fill(dt)
            dgvCourses.DataSource = dt

            ' Optional: Itago ang ID column para mas malinis ang grid
            dgvCourses.Columns("ID").Visible = False
        Catch ex As Exception
            MsgBox("Error loading courses: " & ex.Message, MsgBoxStyle.Critical)
        Finally
            closeConn()
        End Try
    End Sub

    ' 2. CREATE & UPDATE: Isang button para sa dalawang function
    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        ' Validation: Bawal ang empty fields sa Code at Name
        If String.IsNullOrWhiteSpace(txtCode.Text) Or String.IsNullOrWhiteSpace(txtName.Text) Then
            MsgBox("Please fill in the Course Code and Name.", MsgBoxStyle.Exclamation)
            Return
        End If

        Try
            openConn()
            Dim query As String = ""

            If selectedID = 0 Then
                ' Add New Mode
                query = "INSERT INTO courses (course_code, course_name, description) " &
                        "VALUES (@code, @name, @desc)"
            Else
                ' Update Mode
                query = "UPDATE courses SET course_code=@code, course_name=@name, " &
                        "description=@desc WHERE course_id=@id"
            End If

            Dim mysqlCmd As MySqlCommand = cmd(query)
            mysqlCmd.Parameters.AddWithValue("@code", txtCode.Text.Trim())
            mysqlCmd.Parameters.AddWithValue("@name", txtName.Text.Trim())
            mysqlCmd.Parameters.AddWithValue("@desc", txtDescription.Text.Trim())

            ' Idagdag lang ang ID parameter kung tayo ay nasa Update mode
            If selectedID <> 0 Then
                mysqlCmd.Parameters.AddWithValue("@id", selectedID)
            End If

            mysqlCmd.ExecuteNonQuery()
            MsgBox("Course saved successfully!", MsgBoxStyle.Information)

            ClearFields()
            LoadCourses()
        Catch ex As Exception
            ' Ang error na ito ay karaniwang lumalabas kapag DUPLICATE ang Course Code
            MsgBox("Error saving course: " & ex.Message, MsgBoxStyle.Critical)
        Finally
            closeConn()
        End Try
    End Sub

    ' 3. DELETE: Pagtanggal ng record
    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        If selectedID = 0 Then
            MsgBox("Please select a course from the list to delete.", MsgBoxStyle.Exclamation)
            Return
        End If

        Dim confirm As DialogResult = MsgBox("Are you sure you want to delete this course?",
                                           MsgBoxStyle.YesNo + MsgBoxStyle.Question)

        If confirm = DialogResult.Yes Then
            Try
                openConn()
                Dim mysqlCmd As MySqlCommand = cmd("DELETE FROM courses WHERE course_id=@id")
                mysqlCmd.Parameters.AddWithValue("@id", selectedID)
                mysqlCmd.ExecuteNonQuery()

                MsgBox("Course deleted.", MsgBoxStyle.Information)
                ClearFields()
                LoadCourses()
            Catch ex As Exception
                ' Hindi ito basta-basta ma-de-delete kung may students na naka-enroll dito (Foreign Key constraint)
                MsgBox("Cannot delete this course. It might be linked to existing student records.", MsgBoxStyle.Critical)
            Finally
                closeConn()
            End Try
        End If
    End Sub

    ' 4. SELECT: Pag-click sa grid para mapunta ang data sa textboxes
    Private Sub dgvCourses_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvCourses.CellClick
        If e.RowIndex >= 0 Then
            Dim row As DataGridViewRow = dgvCourses.Rows(e.RowIndex)

            selectedID = Convert.ToInt32(row.Cells("ID").Value)
            txtCode.Text = row.Cells("Course Code").Value.ToString()
            txtName.Text = row.Cells("Course Name").Value.ToString()
            txtDescription.Text = row.Cells("Description").Value.ToString()

            btnSave.Text = "Update Course" ' Palitan ang label para alam ng user na Edit mode na
        End If
    End Sub

    ' 5. HELPER: Linisin ang form para sa bagong input
    Private Sub btnClear_Click(sender As Object, e As EventArgs) Handles btnClear.Click
        ClearFields()
    End Sub

    Private Sub ClearFields()
        selectedID = 0
        txtCode.Clear()
        txtName.Clear()
        txtDescription.Clear()
        btnSave.Text = "Save Course"
        txtCode.Focus()
    End Sub

    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles Label1.Click

    End Sub
End Class