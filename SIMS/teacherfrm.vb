Public Class teacherfrm
    ' Variable para subaybayan ang kasalukuyang active form
    Private currentChildForm As Form = Nothing

    Private Sub teacherfrm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        OpenChildForm(New dashboardteacher())

    End Sub

    Private Sub OpenChildForm(childForm As Form)
        If currentChildForm IsNot Nothing Then
            currentChildForm.Close()
            currentChildForm.Dispose()
        End If

        Me.pnlMain.Controls.Clear()

        currentChildForm = childForm
        childForm.TopLevel = False
        childForm.FormBorderStyle = FormBorderStyle.None
        childForm.Dock = DockStyle.Fill

        Me.pnlMain.Controls.Add(childForm)
        Me.pnlMain.Tag = childForm
        childForm.BringToFront()
        childForm.Show()
    End Sub

    Private Sub btnDashboard_Click(sender As Object, e As EventArgs) Handles btnDashboard.Click
        OpenChildForm(New dashboardteacher())

    End Sub

    Private Sub btnGradeEntry_Click(sender As Object, e As EventArgs) Handles btnGradeEntry.Click
        OpenChildForm(New gradeentryform())

    End Sub

    Private Sub btnGradeList_Click(sender As Object, e As EventArgs) Handles btnGradeList.Click
        OpenChildForm(New gradeslistfrm())

    End Sub

    Private Sub btnAnnouncements_Click(sender As Object, e As EventArgs) Handles btnAnnouncements.Click
        OpenChildForm(New announcementform())
    End Sub

    Private Sub btnLogout_Click(sender As Object, e As EventArgs)
        If MessageBox.Show("Are you sure you want to logout?", "Logout", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
            loginfrm.txtUsername.Clear()
            loginfrm.txtPassword.Clear()
            Me.Close()
            loginfrm.Show()
        End If
    End Sub

End Class
