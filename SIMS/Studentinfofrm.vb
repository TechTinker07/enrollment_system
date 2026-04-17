Imports MySql.Data.MySqlClient

Public Class Studentinfofrm

    ' --- Load Event ---
    Private Sub Studentinfofrm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Rounded corners para sa Panel
        Dim pathPanel As New System.Drawing.Drawing2D.GraphicsPath()
        pathPanel.AddArc(0, 0, 20, 20, 180, 90)
        pathPanel.AddArc(pnlInfo.Width - 20, 0, 20, 20, 270, 90)
        pathPanel.AddArc(pnlInfo.Width - 20, pnlInfo.Height - 20, 20, 20, 0, 90)
        pathPanel.AddArc(0, pnlInfo.Height - 20, 20, 20, 90, 90)
        pathPanel.CloseFigure()
        pnlInfo.Region = New Region(pathPanel)

        ' Manually link the event to fix the BC30506 error
        AddHandler txtSearch.TextChanged, AddressOf txtSearch_TextChanged
        LoadStudentData()


    End Sub

    ' --- Fetch Data Function ---
    Public Sub LoadStudentData(Optional searchTerm As String = "")
        Try
            openConn()

            ' FIX: Use backticks (`) instead of square brackets ([]) for MariaDB/MySQL aliases
            Dim query As String = "SELECT student_id AS `ID`, " &
                                 "first_name AS `First Name`, " &
                                 "last_name AS `Last Name`, " &
                                 "email AS `Email`, " &
                                 "birthdate AS `Birthdate`, " &
                                 "address AS `Address` " &
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
                ' Note: MySqlDataAdapter doesn't need to be in a 'Using' block, 
                ' but it's good practice to clear the table before filling.
                dt.Clear()

                Dim da As New MySqlDataAdapter(sqlCmd)
                da.Fill(dt)
                lblCount.Text = dt.Rows.Count.ToString()
                dgvStudents.DataSource = dt
            End Using

        Catch ex As Exception
            MsgBox("Error loading students: " & ex.Message, MsgBoxStyle.Critical)
        Finally
            closeConn()
        End Try
    End Sub

    ' --- Search Logic ---
    Private Sub txtSearch_TextChanged(sender As Object, e As EventArgs)
        ' Calling the load function with the current text
        LoadStudentData(txtSearch.Text.Trim())
    End Sub


End Class
