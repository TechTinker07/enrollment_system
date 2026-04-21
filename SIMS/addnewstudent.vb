Imports MySql.Data.MySqlClient

Public Class addnewstudent

    ' 1. Clear fields when the form loads
    Private Sub addnewstudent_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ClearFields()
    End Sub

    ' === AUTO-GENERATE STUDENT ID ===
    Private Function GenerateStudentID() As String
        Try
            openConn()
            Dim year As String = DateTime.Now.Year.ToString()
            Dim countCmd As New MySqlCommand(
                "SELECT COUNT(*) FROM students WHERE student_id LIKE @year", conn)
            countCmd.Parameters.AddWithValue("@year", year & "%")
            Dim count As Integer = Convert.ToInt32(countCmd.ExecuteScalar()) + 1
            Return year & "-" & count.ToString("D4") ' e.g. 2026-0001
        Catch ex As Exception
            Return DateTime.Now.Year.ToString() & "-0001" ' fallback
        Finally
            closeConn()
        End Try
    End Function

    ' 2. Save Button Logic
    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        If String.IsNullOrWhiteSpace(txtStudentID.Text) OrElse
           String.IsNullOrWhiteSpace(txtFirstName.Text) OrElse
           String.IsNullOrWhiteSpace(txtLastName.Text) Then
            MsgBox("Please fill in the Student ID, First Name, and Last Name.", MsgBoxStyle.Exclamation, "Required Fields")
            Exit Sub
        End If

        Try
            openConn()
            Dim query As String = "INSERT INTO students (student_id, first_name, last_name, email, birthdate, address) " &
                                 "VALUES (@sid, @fname, @lname, @email, @bday, @addr)"
            Dim mysqlCmd As MySqlCommand = cmd(query)
            mysqlCmd.Parameters.AddWithValue("@sid", txtStudentID.Text.Trim())
            mysqlCmd.Parameters.AddWithValue("@fname", txtFirstName.Text.Trim())
            mysqlCmd.Parameters.AddWithValue("@lname", txtLastName.Text.Trim())
            mysqlCmd.Parameters.AddWithValue("@email", txtEmail.Text.Trim())
            mysqlCmd.Parameters.AddWithValue("@bday", dtpBirthdate.Value.ToString("yyyy-MM-dd"))
            mysqlCmd.Parameters.AddWithValue("@addr", txtAddress.Text.Trim())
            mysqlCmd.ExecuteNonQuery()

            MsgBox("Student successfully registered!", MsgBoxStyle.Information, "Success")

            If Application.OpenForms().OfType(Of Studentinforeg).Any Then
                Studentinforeg.LoadStudentData()
            End If

            Me.Close()
        Catch ex As MySqlException When ex.Number = 1062
            MsgBox("Error: Student ID or Email already exists in the database.", MsgBoxStyle.Critical)
        Catch ex As Exception
            MsgBox("An error occurred: " & ex.Message, MsgBoxStyle.Critical)
        Finally
            closeConn()
        End Try
    End Sub

    ' 3. Cancel Button Logic
    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub

    ' Helper method para linisin ang form
    Private Sub ClearFields()
        txtStudentID.Text = GenerateStudentID() ' Auto-generate agad
        txtStudentID.ReadOnly = True            ' Hindi na kailangan i-type
        txtFirstName.Clear()
        txtLastName.Clear()
        txtEmail.Clear()
        txtAddress.Clear()
        dtpBirthdate.Value = DateTime.Now
    End Sub

    Private Sub pnlContainer_Paint(sender As Object, e As PaintEventArgs) Handles pnlContainer.Paint
        Dim pathPanel As New System.Drawing.Drawing2D.GraphicsPath()
        pathPanel.AddArc(0, 0, 20, 20, 180, 90)
        pathPanel.AddArc(pnlContainer.Width - 20, 0, 20, 20, 270, 90)
        pathPanel.AddArc(pnlContainer.Width - 20, pnlContainer.Height - 20, 20, 20, 0, 90)
        pathPanel.AddArc(0, pnlContainer.Height - 20, 20, 20, 90, 90)
        pathPanel.CloseFigure()
        pnlContainer.Region = New Region(pathPanel)
    End Sub

End Class