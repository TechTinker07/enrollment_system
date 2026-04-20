Imports System.Data.SqlClient
Imports MySql.Data.MySqlClient

Public Class Usermngmtfrm

    Private Sub Usermngmtfrm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        AddHandler btnApprove.Click, AddressOf btnApprove_Click
        AddHandler btnDelete.Click, AddressOf btnDelete_Click
        AddHandler txtSearch.TextChanged, AddressOf txtSearch_TextChanged
        LoadUserList()
    End Sub

    Public Sub LoadUserList(Optional searchTerm As String = "")
        Try
            openConn()

            Dim sql As String =
                "SELECT u.user_id, " &
                "IFNULL(CONCAT(s.first_name, ' ', s.last_name), 'SYSTEM STAFF') AS full_name, " &
                "u.username, u.role, u.status, u.created_at, " &
                "IFNULL(s.email, 'N/A') AS email " &
                "FROM users u " &
                "LEFT JOIN students s ON u.user_id = s.user_id "

            If Not String.IsNullOrEmpty(searchTerm) Then
                sql &= "WHERE u.username LIKE @search OR s.first_name LIKE @search OR s.last_name LIKE @search "
            End If

            sql &= "ORDER BY u.created_at DESC"

            Using command As MySqlCommand = cmd(sql)
                If Not String.IsNullOrEmpty(searchTerm) Then
                    command.Parameters.AddWithValue("@search", "%" & searchTerm & "%")
                End If

                Dim adapter As New MySqlDataAdapter(command)
                Dim dt As New DataTable()
                adapter.Fill(dt)

                dgvUsers.Columns.Clear()
                dgvUsers.AutoGenerateColumns = False
                dgvUsers.DataSource = dt

                dgvUsers.Columns.Add(New DataGridViewTextBoxColumn() With {.DataPropertyName = "user_id", .HeaderText = "ID", .Name = "user_id", .Visible = False})
                dgvUsers.Columns.Add(New DataGridViewTextBoxColumn() With {.DataPropertyName = "full_name", .HeaderText = "Full Name", .Name = "full_name"})
                dgvUsers.Columns.Add(New DataGridViewTextBoxColumn() With {.DataPropertyName = "username", .HeaderText = "Username", .Name = "username"})
                dgvUsers.Columns.Add(New DataGridViewTextBoxColumn() With {.DataPropertyName = "role", .HeaderText = "Role", .Name = "role"})
                dgvUsers.Columns.Add(New DataGridViewTextBoxColumn() With {.DataPropertyName = "status", .HeaderText = "Status", .Name = "status"})
                dgvUsers.Columns.Add(New DataGridViewTextBoxColumn() With {.DataPropertyName = "email", .HeaderText = "Email", .Name = "email"})
                dgvUsers.Columns.Add(New DataGridViewTextBoxColumn() With {.DataPropertyName = "created_at", .HeaderText = "Created At", .Name = "created_at"})
                lblStatusInfo.Text = "Active Users: " & dt.Rows.Count
            End Using

        Catch ex As Exception
            MsgBox("Error loading users: " & ex.Message, MsgBoxStyle.Critical)
        Finally
            closeConn()
        End Try
    End Sub

    Private Sub txtSearch_TextChanged(sender As Object, e As EventArgs)
        LoadUserList(txtSearch.Text.Trim())
    End Sub

    Private Sub btnApprove_Click(sender As Object, e As EventArgs)
        If dgvUsers.SelectedRows.Count = 0 Then
            MsgBox("Pumili muna ng user sa listahan.", MsgBoxStyle.Exclamation)
            Return
        End If

        Dim row = dgvUsers.SelectedRows(0)
        Dim userId As Integer = Convert.ToInt32(row.Cells(0).Value)
        Dim userName As String = row.Cells("full_name").Value.ToString()
        Dim role As String = row.Cells("role").Value.ToString().ToLower()
        Dim status As String = row.Cells("status").Value.ToString().ToLower()

        If role <> "student" Then
            MsgBox("Approval is only for student portal accounts.", MsgBoxStyle.Exclamation)
            Return
        End If

        If status = "verified" Then
            MsgBox("This account is already verified.", MsgBoxStyle.Information)
            Return
        End If

        Dim ask = MsgBox("Approve account for " & userName & "?", MsgBoxStyle.YesNo + MsgBoxStyle.Question, "Confirm Approval")

        If ask = MsgBoxResult.Yes Then
            Try
                openConn()
                Using updateCmd As MySqlCommand = cmd("UPDATE users SET status = 'verified' WHERE user_id = @id")
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

    Private Sub btnDelete_Click(sender As Object, e As EventArgs)
        If dgvUsers.SelectedRows.Count = 0 Then Return

        Dim userId As Integer = Convert.ToInt32(dgvUsers.SelectedRows(0).Cells(0).Value)
        Dim ask = MsgBox("Are you sure you want to delete this user?", MsgBoxStyle.Critical + MsgBoxStyle.YesNo, "Warning")

        If ask = MsgBoxResult.Yes Then
            Try
                openConn()
                Using deleteCmd As MySqlCommand = cmd("DELETE FROM users WHERE user_id = @id")
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

End Class
