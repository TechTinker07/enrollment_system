Public Class Adminfrm

    ' 1. INITIALIZATION & WIRING
    Private Sub Adminfrm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' MANUALLY CONNECT BUTTONS TO SUBS (Fixed BC30506)
        AddHandler btnDashboard.Click, AddressOf btnDashboard_Click
        AddHandler btnStudentInfo.Click, AddressOf btnStudentInfo_Click
        AddHandler btnUserMgmt.Click, AddressOf btnUserMgmt_Click
        AddHandler btnCourseMgmt.Click, AddressOf btnCourseMgmt_Click
        AddHandler btnSubjects.Click, AddressOf btnSubjects_Click
        AddHandler btnSchedules.Click, AddressOf btnSchedules_Click
        AddHandler btnAnnouncements.Click, AddressOf btnAnnouncements_Click
        AddHandler btnLogout.Click, AddressOf btnLogout_Click

        ' DEFAULT VIEW: Ipakita agad ang Dashboard pagka-load
        OpenChildForm(New dashboardadmin())
    End Sub

    ' 2. CHILD FORM MANAGER (The Engine)
    Private Sub OpenChildForm(ByVal childForm As Form)
        If pnlMain.Controls.Count > 0 Then
            For Each ctrl As Control In pnlMain.Controls
                If TypeOf ctrl Is Form Then
                    DirectCast(ctrl, Form).Close()
                    ctrl.Dispose()
                End If
            Next
            pnlMain.Controls.Clear()
        End If

        childForm.TopLevel = False
        childForm.FormBorderStyle = FormBorderStyle.None
        childForm.Dock = DockStyle.Fill

        pnlMain.Controls.Add(childForm)
        childForm.Show()
    End Sub

    ' 3. BUTTON ACTIONS (Removed 'Handles' to stop the errors)

    Private Sub btnDashboard_Click(sender As Object, e As EventArgs)
        OpenChildForm(New dashboardadmin())
    End Sub

    Private Sub btnStudentInfo_Click(sender As Object, e As EventArgs)
        OpenChildForm(New Studentinfofrm())
    End Sub

    Private Sub btnUserMgmt_Click(sender As Object, e As EventArgs)
        OpenChildForm(New Usermngmtfrm())
    End Sub

    Private Sub btnCourseMgmt_Click(sender As Object, e As EventArgs)
        OpenChildForm(New courselist())
    End Sub

    Private Sub btnSubjects_Click(sender As Object, e As EventArgs)
        OpenChildForm(New subjectlist())
    End Sub

    Private Sub btnSchedules_Click(sender As Object, e As EventArgs)
        OpenChildForm(New ScheduleFrm())
    End Sub

    Private Sub btnAnnouncements_Click(sender As Object, e As EventArgs)
        OpenChildForm(New Announcementfrm())
    End Sub

    Private Sub btnLogout_Click(sender As Object, e As EventArgs)
        Dim result As DialogResult = MessageBox.Show("Are you sure you want to logout?", "Logout", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If result = DialogResult.Yes Then
            loginfrm.Show()
            Me.Close()
        End If
    End Sub

End Class