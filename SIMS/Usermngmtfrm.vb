Imports MySql.Data.MySqlClient

Public Class Usermngmtfrm

    Private Sub Usermngmtfrm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Use AddHandler to link your UI to your code safely
        AddHandler btnApprove.Click, AddressOf btnApprove_Click
        AddHandler btnDelete.Click, AddressOf btnDelete_Click
        AddHandler txtSearch.TextChanged, AddressOf txtSearch_TextChanged

        LoadUserList()
    End Sub

    ' ==========================================================
    ' 1. LOAD DATA
    ' ==========================================================
    Public Sub LoadUserList(Optional searchTerm As String = "")
        Try
            openConn()

            Dim sql As String = "SELECT u.user_id, " &
                                   "IFNULL(CONCAT(s.first_name, ' ', s.last_name), 'SYSTEM STAFF') AS full_name, " &
                                   "u.username, u.role, u.status, u.created_at, " &
                                   "IFNULL(s.email, 'N/A') AS email " &
                                   "FROM users u " &
                                   "LEFT JOIN students s ON u.user_id = s.user_id "


            If Not String.IsNullOrEmpty(searchTerm) Then
                sql &= " WHERE u.username LIKE @search OR s.first_name LIKE @search OR s.last_name LIKE @search"
            End If

            sql &= " ORDER BY u.created_at DESC"

            Using command As MySqlCommand = cmd(sql)
                command.Parameters.AddWithValue("@search", "%" & searchTerm & "%")

                Dim adapter As New MySqlDataAdapter(command)
                Dim dt As New DataTable()
                adapter.Fill(dt)

                dgvUsers.DataSource = dt

                ' Header formatting
                If dgvUsers.Columns.Contains("user_id") Then dgvUsers.Columns("user_id").HeaderText = "ID"
                If dgvUsers.Columns.Contains("full_name") Then dgvUsers.Columns("full_name").HeaderText = "Full Name"

                lblStatusInfo.Text = $"Active Users: {dt.Rows.Count}"
            End Using

        Catch ex As Exception
            MsgBox("Error loading users: " & ex.Message, MsgBoxStyle.Critical)
        Finally
            closeConn()
        End Try
    End Sub

    ' ==========================================================
    ' 2. SEARCH LOGIC (No 'Handles' here)
    ' ==========================================================
    Private Sub txtSearch_TextChanged(sender As Object, e As EventArgs)
        LoadUserList(txtSearch.Text.Trim())
    End Sub

    ' ==========================================================
    ' 3. APPROVAL LOGIC (No 'Handles' here)
    ' ==========================================================
    Private Sub btnApprove_Click(sender As Object, e As EventArgs)
        If dgvUsers.SelectedRows.Count = 0 Then
            MsgBox("Pumili muna ng user sa listahan.", MsgBoxStyle.Exclamation)
            Return
        End If

        Dim userId As String = dgvUsers.SelectedRows(0).Cells("colID").Value.ToString()
        Dim userName As String = dgvUsers.SelectedRows(0).Cells("colName").Value.ToString()

        Dim ask = MsgBox($"Approve account for {userName}?", MsgBoxStyle.YesNo + MsgBoxStyle.Question, "Confirm Approval")

        If ask = MsgBoxResult.Yes Then
            Try
                openConn()
                Dim updateSql As String = "UPDATE users SET status = 'verified' WHERE user_id = @id"
                Using updateCmd As MySqlCommand = cmd(updateSql)
                    updateCmd.Parameters.AddWithValue("@id", userId)
                    updateCmd.ExecuteNonQuery()
                End Using

                MsgBox("User approved successfully!", MsgBoxStyle.Information)
                LoadUserList()
            Catch ex As Exception
                MsgBox("Update failed: " & ex.Message)
            Finally
                closeConn()
            End Try
        End If
    End Sub

    ' ==========================================================
    ' 4. DELETE LOGIC (No 'Handles' here)
    ' ==========================================================
    Private Sub btnDelete_Click(sender As Object, e As EventArgs)
        If dgvUsers.SelectedRows.Count = 0 Then Return

        Dim userId As String = dgvUsers.SelectedRows(0).Cells("colID").Value.ToString()

        Dim ask = MsgBox("Are you sure you want to delete this user?",
                         MsgBoxStyle.Critical + MsgBoxStyle.YesNo, "Warning")

        If ask = MsgBoxResult.Yes Then
            Try
                openConn()
                Dim deleteSql As String = "DELETE FROM users WHERE user_id = @id"
                Using deleteCmd As MySqlCommand = cmd(deleteSql)
                    deleteCmd.Parameters.AddWithValue("@id", userId)
                    deleteCmd.ExecuteNonQuery()
                End Using

                MsgBox("User deleted.", MsgBoxStyle.Information)
                LoadUserList()
            Catch ex As Exception
                MsgBox("Delete failed: " & ex.Message)
            Finally
                closeConn()
            End Try
        End If
    End Sub

    Private Sub lblSearch_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub dgvUsers_CellContentClick(sender As Object, e As DataGridViewCellEventArgs)

    End Sub

    Private Sub dgvUsers_CellContentClick_1(sender As Object, e As DataGridViewCellEventArgs)

    End Sub


End Class
