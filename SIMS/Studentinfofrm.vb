Imports MySql.Data.MySqlClient

Public Class Studentinfofrm

    ' --- Load Event ---
    Private Sub Studentinfofrm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Manually link the event to fix the BC30506 error
        AddHandler txtSearch.TextChanged, AddressOf txtSearch_TextChanged

        LoadStudentData()
    End Sub

    ' --- Fetch Data Function ---
    Public Sub LoadStudentData(Optional searchTerm As String = "")
        Try
            openConn()

            ' Selecting specific columns for the DataGridView
            Dim query As String = "SELECT student_id AS [ID], first_name AS [First Name], " &
                                 "last_name AS [Last Name], email AS [Email], " &
                                 "birthdate AS [Birthdate], address AS [Address] " &
                                 "FROM students "

            ' Add filtering logic if search term is provided
            If Not String.IsNullOrEmpty(searchTerm) Then
                query &= "WHERE student_id LIKE @search " &
                         "OR first_name LIKE @search " &
                         "OR last_name LIKE @search " &
                         "OR email LIKE @search"
            End If

            ' Using 'Using' ensures the command is disposed of properly
            Using sqlCmd As MySqlCommand = cmd(query)
                sqlCmd.Parameters.AddWithValue("@search", "%" & searchTerm & "%")

                Dim dt As New DataTable()
                Dim da As New MySqlDataAdapter(sqlCmd)

                dt.Clear()
                da.Fill(dt)

                dgvStudents.DataSource = dt
            End Using

        Catch ex As Exception
            MsgBox("Error loading students: " & ex.Message, MsgBoxStyle.Critical)
        Finally
            closeConn()
        End Try
    End Sub

    ' --- Search Logic (Removed 'Handles' to resolve error) ---
    Private Sub txtSearch_TextChanged(sender As Object, e As EventArgs)
        LoadStudentData(txtSearch.Text.Trim())
    End Sub

End Class