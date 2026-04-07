Imports MySql.Data.MySqlClient

Public Class adduserform

    ' Save Button Logic
    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        ' 1. Validate Inputs
        If String.IsNullOrWhiteSpace(txtUsername.Text) OrElse
           String.IsNullOrWhiteSpace(txtPassword.Text) OrElse
           cboRole.SelectedIndex = -1 Then
            MsgBox("Please fill in all fields.", MsgBoxStyle.Exclamation, "Validation Error")
            Return
        End If

        ' 2. Check Password Match
        If txtPassword.Text <> txtConfirmPassword.Text Then
            MsgBox("Passwords do not match!", MsgBoxStyle.Critical, "Error")
            Return
        End If

        Try
            ' 3. Open Connection from your Module
            openConn()

            ' 4. Check for existing username
            Dim checkQuery As String = "SELECT COUNT(*) FROM users WHERE username = @user"
            Using checkCmd As New MySqlCommand(checkQuery, conn)
                checkCmd.Parameters.AddWithValue("@user", txtUsername.Text.Trim())
                If Convert.ToInt32(checkCmd.ExecuteScalar()) > 0 Then
                    MsgBox("Username is already taken.", MsgBoxStyle.Information, "Duplicate")
                    Return
                End If
            End Using

            ' 5. Insert New User
            Dim insertQuery As String = "INSERT INTO users (username, password, role) VALUES (@user, @pass, @role)"
            Using saveCmd As New MySqlCommand(insertQuery, conn)
                ' We use Parameters to match your DB schema (username, password, role)
                saveCmd.Parameters.AddWithValue("@user", txtUsername.Text.Trim())
                saveCmd.Parameters.AddWithValue("@pass", txtPassword.Text) ' Plain text per your current schema
                saveCmd.Parameters.AddWithValue("@role", cboRole.Text.ToLower())

                saveCmd.ExecuteNonQuery()
                MsgBox("User account created successfully!", MsgBoxStyle.Information, "Success")

                Me.DialogResult = DialogResult.OK
                Me.Close()
            End Using

        Catch ex As Exception
            MsgBox("Error saving user: " & ex.Message)
        Finally
            ' 6. Always close connection using your Module sub
            closeConn()
        End Try
    End Sub

    ' Cancel Button Logic
    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub

End Class