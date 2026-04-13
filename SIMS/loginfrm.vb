Imports System.Windows.Forms.VisualStyles.VisualStyleElement
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

                    dr.Close()
                    MsgBox("Login Successful! Welcome, " & txtUsername.Text, MsgBoxStyle.Information, "Access Granted")



                    If userRole.ToLower() = "admin" Then
                        MsgBox("Opening Admin Dashboard...", MsgBoxStyle.Information)
                        Me.Hide()
                        Adminfrm.Show()

                    ElseIf userRole.ToLower() = "registrar" Then
                        MsgBox("Opening Registrar Dashboard...", MsgBoxStyle.Information)
                        Me.Hide()
                        registrarfrm.Show()

                    ElseIf userRole.ToLower() = "accounting" Then
                        MsgBox("Opening Finance Dashboard...", MsgBoxStyle.Information)
                        Me.Hide()
                        Financefrm.Show()

                    ElseIf userRole.ToLower() = "teacher" OrElse userRole.ToLower() = "faculty" Then
                        MsgBox("Opening Faculty Dashboard...", MsgBoxStyle.Information)
                        Me.Hide()
                        teacherfrm.Show()

                    ElseIf userRole.ToLower() = "student" Then
                        MsgBox("Students must log in through the web portal.", MsgBoxStyle.Exclamation)

                        Me.Show()

                    Else
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
        ' Circle para sa PictureBox
        Dim pathPic As New System.Drawing.Drawing2D.GraphicsPath()
        pathPic.AddEllipse(0, 0, PictureBox1.Width, PictureBox1.Height)
        PictureBox1.Region = New Region(pathPic)

        ' Rounded corners para sa Panel
        Dim pathPanel As New System.Drawing.Drawing2D.GraphicsPath()
        pathPanel.AddArc(0, 0, 20, 20, 180, 90)
        pathPanel.AddArc(pnlContainer.Width - 20, 0, 20, 20, 270, 90)
        pathPanel.AddArc(pnlContainer.Width - 20, pnlContainer.Height - 20, 20, 20, 0, 90)
        pathPanel.AddArc(0, pnlContainer.Height - 20, 20, 20, 90, 90)
        pathPanel.CloseFigure()
        pnlContainer.Region = New Region(pathPanel)
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim result As DialogResult = MessageBox.Show("Are you sure you want to exit?", "Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Question)

        If result = DialogResult.Yes Then
            Application.Exit()
        End If
    End Sub

    Private Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox1.CheckedChanged
        If CheckBox1.Checked Then
            txtPassword.PasswordChar = Chr(0)
        Else
            txtPassword.PasswordChar = "●"
        End If
    End Sub

    Private Sub pnlContainer_Paint(sender As Object, e As PaintEventArgs) Handles pnlContainer.Paint

    End Sub
End Class