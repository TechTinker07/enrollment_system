Imports MySql.Data.MySqlClient

Public Class loginfrm

    Private Sub btnLogin_Click(sender As Object, e As EventArgs) Handles btnLogin.Click
        ' 1. Check if empty ang fields
        If String.IsNullOrWhiteSpace(txtUsername.Text) OrElse String.IsNullOrWhiteSpace(txtPassword.Text) Then
            MsgBox("Please enter both username and password.", MsgBoxStyle.Exclamation, "Input Required")
            Exit Sub
        End If

        Try
            ' 2. Buksan ang connection gamit ang sub sa Module mo
            openConn()

            ' 3. Prepare Query - siguradong tugma sa columns sa image (username, password)
            Dim query As String = "SELECT * FROM users WHERE username = @user AND password = @pass"

            ' Gagamit tayo ng 'Using' para sa sqlCmd para kusa itong mag-close/dispose
            Using sqlCmd As MySqlCommand = cmd(query)
                sqlCmd.Parameters.AddWithValue("@user", txtUsername.Text)
                sqlCmd.Parameters.AddWithValue("@pass", txtPassword.Text)

                ' 4. Execute at Read
                dr = sqlCmd.ExecuteReader()

                If dr.Read() Then
                    ' Kunin ang 'role' galing sa database column mo
                    Dim userRole As String = dr("role").ToString()

                    MsgBox("Login Successful! Welcome, " & txtUsername.Text, MsgBoxStyle.Information, "Access Granted")

                    ' 5. Itago ang login form
                    Me.Hide()

                    ' 6. Navigation base sa role sa database
                    ' Paalala: Siguraduhin na ang "Admin" o "Student" ay kapareho ng nasa database rows mo
                    If userRole.ToLower() = "admin" Then
                        ' AdminDashboard.Show() ' Palitan mo ito ng tamang pangalan ng Admin Form mo
                        MsgBox("Opening Admin Dashboard...", MsgBoxStyle.Information)
                        Adminfrm.Show()
                    ElseIf userRole.ToLower() = "student" Then
                        ' StudentDashboard.Show() ' Palitan mo ito ng tamang pangalan ng Student Form mo
                        MsgBox("Opening Student Dashboard...", MsgBoxStyle.Information)

                    Else
                        ' Sakaling may ibang role (e.g. Staff, Teacher)
                        MsgBox("Role not recognized. Please contact admin.", MsgBoxStyle.Exclamation)
                        Me.Show()
                    End If
                Else
                    ' Kapag walang nahanap na match na user/pass
                    MsgBox("Invalid Username or Password.", MsgBoxStyle.Critical, "Access Denied")
                End If
            End Using

        Catch ex As Exception
            MsgBox("An error occurred: " & ex.Message, MsgBoxStyle.Critical)
        Finally
            ' 7. Siguraduhing laging sarado ang reader at connection
            If dr IsNot Nothing AndAlso Not dr.IsClosed Then dr.Close()
            closeConn()
        End Try
    End Sub

    Private Sub loginfrm_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class