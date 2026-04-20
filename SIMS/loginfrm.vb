Imports System.Data.SqlClient
Imports MySql.Data.MySqlClient

Public Class loginfrm

    Private Sub btnLogin_Click(sender As Object, e As EventArgs) Handles btnLogin.Click
        If String.IsNullOrWhiteSpace(txtUsername.Text) OrElse String.IsNullOrWhiteSpace(txtPassword.Text) Then
            MsgBox("Please enter both username and password.", MsgBoxStyle.Exclamation, "Input Required")
            Exit Sub
        End If

        Try
            openConn()

            Dim query As String = "SELECT user_id, username, password, role, status FROM users WHERE username = @user LIMIT 1"

            Using sqlCmd As MySqlCommand = cmd(query)
                sqlCmd.Parameters.AddWithValue("@user", txtUsername.Text.Trim())

                dr = sqlCmd.ExecuteReader()

                If dr.Read() Then
                    Dim dbPassword As String = dr("password").ToString()
                    Dim userRole As String = dr("role").ToString().ToLower()
                    Dim userStatus As String = dr("status").ToString().ToLower()

                    dr.Close()

                    If dbPassword <> txtPassword.Text Then
                        MsgBox("Invalid Username or Password.", MsgBoxStyle.Critical, "Access Denied")
                        Return
                    End If

                    If userStatus = "blocked" Then
                        MsgBox("Your account is blocked. Please contact the admin.", MsgBoxStyle.Critical, "Access Denied")
                        Return
                    End If

                    If userStatus = "pending" AndAlso userRole <> "student" Then
                        MsgBox("Your staff account is still pending verification.", MsgBoxStyle.Exclamation, "Access Pending")
                        Return
                    End If

                    If userRole = "student" Then
                        MsgBox("Students must log in through the web portal.", MsgBoxStyle.Exclamation)
                        Return
                    End If

                    MsgBox("Login Successful! Welcome, " & txtUsername.Text, MsgBoxStyle.Information, "Access Granted")

                    Me.Hide()

                    Select Case userRole
                        Case "admin"
                            Adminfrm.Show()
                        Case "registrar"
                            registrarfrm.Show()
                        Case "cashier", "accounting"
                            Financefrm.Show()
                        Case "faculty", "teacher"
                            teacherfrm.Show()
                        Case Else
                            MsgBox("Role not recognized. Please contact admin.", MsgBoxStyle.Exclamation)
                            Me.Show()
                    End Select
                Else
                    MsgBox("Invalid Username or Password.", MsgBoxStyle.Critical, "Access Denied")
                End If
            End Using

        Catch ex As Exception
            MsgBox("An error occurred: " & ex.Message, MsgBoxStyle.Critical)
        Finally
            If dr IsNot Nothing AndAlso Not dr.IsClosed Then dr.Close()
            closeConn()
        End Try
    End Sub



    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim result As DialogResult = MessageBox.Show("Exit application?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question)

        If result = DialogResult.Yes Then
            Application.Exit()
        End If
    End Sub

    Private Sub chkShowPassword_CheckedChanged(sender As Object, e As EventArgs) Handles chkShowPassword.CheckedChanged
        If chkShowPassword.Checked Then
            txtPassword.UseSystemPasswordChar = False
        Else
            txtPassword.UseSystemPasswordChar = True
        End If
    End Sub


End Class
