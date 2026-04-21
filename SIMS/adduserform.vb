Imports System.Data.SqlClient
Imports MySql.Data.MySqlClient

Public Class adduserform

    Private Sub adduserform_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        cboRole.Items.Clear()
        cboRole.Items.AddRange(New Object() {"admin", "registrar", "cashier", "faculty"})
        If cboRole.Items.Count > 0 Then cboRole.SelectedIndex = 0
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        If String.IsNullOrWhiteSpace(txtUsername.Text) OrElse
           String.IsNullOrWhiteSpace(txtPassword.Text) OrElse
           String.IsNullOrWhiteSpace(txtConfirmPassword.Text) OrElse
           cboRole.SelectedIndex = -1 Then
            MsgBox("Please fill in all fields.", MsgBoxStyle.Exclamation, "Validation Error")
            Return
        End If

        If txtPassword.Text <> txtConfirmPassword.Text Then
            MsgBox("Passwords do not match!", MsgBoxStyle.Critical, "Error")
            Return
        End If

        Try
            openConn()

            Using checkCmd As New MySqlCommand("SELECT COUNT(*) FROM users WHERE username = @user", conn)
                checkCmd.Parameters.AddWithValue("@user", txtUsername.Text.Trim())
                If Convert.ToInt32(checkCmd.ExecuteScalar()) > 0 Then
                    MsgBox("Username is already taken.", MsgBoxStyle.Information, "Duplicate")
                    Return
                End If
            End Using

            Dim insertQuery As String = "INSERT INTO users (username, password, role, status) VALUES (@user, @pass, @role, 'verified')"

            Using saveCmd As New MySqlCommand(insertQuery, conn)
                saveCmd.Parameters.AddWithValue("@user", txtUsername.Text.Trim())
                saveCmd.Parameters.AddWithValue("@pass", txtPassword.Text.Trim())
                saveCmd.Parameters.AddWithValue("@role", cboRole.Text.Trim().ToLower())
                saveCmd.ExecuteNonQuery()
            End Using

            MsgBox("User account created successfully!", MsgBoxStyle.Information, "Success")
            Me.DialogResult = DialogResult.OK
            Me.Close()

        Catch ex As Exception
            MsgBox("Error saving user: " & ex.Message)
        Finally
            closeConn()
        End Try
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub
End Class
