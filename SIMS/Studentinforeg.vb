Imports MySql.Data.MySqlClient

Public Class Studentinforeg

    ' 1. Load data when the form opens
    Private Sub Studentinforeg_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadStudentData()
    End Sub

    ' 2. Main Sub to fetch students from simsdb
    Public Sub LoadStudentData(Optional searchKeyword As String = "")
        Try
            openConn() ' Using your global module function

            ' We select specific columns from your 'students' table schema
            Dim query As String = "SELECT student_id AS 'ID', first_name AS 'First Name', " &
                                 "last_name AS 'Last Name', email AS 'Email', " &
                                 "IFNULL(DATE_FORMAT(birthdate, '%Y-%m-%d'), 'N/A') AS `Birthdate`, " &
                                    "address As 'Address' FROM students"

            ' Add Search Logic
            If Not String.IsNullOrWhiteSpace(searchKeyword) AndAlso searchKeyword <> "Search by ID or Name..." Then
                query &= " WHERE student_id LIKE @key OR first_name LIKE @key OR last_name LIKE @key"
            End If

            ' Using your global 'cmd' function from dbconnections
            Dim mysqlCmd As MySqlCommand = cmd(query)
            mysqlCmd.Parameters.AddWithValue("@key", "%" & searchKeyword & "%")

            Dim adp As New MySqlDataAdapter(mysqlCmd)
            Dim dt As New DataTable()
            adp.Fill(dt)

            ' Bind to your DataGridView
            dgvStudents.DataSource = dt

        Catch ex As Exception
            MsgBox("Error loading students: " & ex.Message, MsgBoxStyle.Critical)
        Finally
            closeConn() ' Always close the connection
        End Try
    End Sub

    ' 3. Search as you type
    Private Sub txtSearch_TextChanged(sender As Object, e As EventArgs) Handles txtSearch.TextChanged
        ' Only filter if the user has actually typed something (not just the placeholder)
        If txtSearch.Focused Then
            LoadStudentData(txtSearch.Text)
        End If
    End Sub

    ' 4. Placeholder Effects for Modern UI
    Private Sub txtSearch_Enter(sender As Object, e As EventArgs) Handles txtSearch.Enter
        If txtSearch.Text = "Search by ID or Name..." Then
            txtSearch.Text = ""
            txtSearch.ForeColor = Color.Black
        End If
    End Sub

    Private Sub txtSearch_Leave(sender As Object, e As EventArgs) Handles txtSearch.Leave
        If txtSearch.Text = "" Then
            txtSearch.Text = "Search by ID or Name..."
            txtSearch.ForeColor = Color.Gray
            LoadStudentData() ' Refresh list to show all
        End If
    End Sub

    ' 5. Open the Add New Student Form
    Private Sub btnAddStudent_Click(sender As Object, e As EventArgs) Handles btnAddStudent.Click
        ' We show the form as a Dialog so the user must finish/cancel before returning
        addnewstudent.ShowDialog()
    End Sub

End Class