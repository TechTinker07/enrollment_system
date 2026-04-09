Public Class registrarfrm

    ' 1. INITIALIZATION: Pag-setup ng form pagkabukas
    Private Sub registrarfrm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Pag-link ng buttons sa kani-kanilang click events
        AddHandler btnDashboard.Click, AddressOf btnDashboard_Click
        AddHandler btnStudentInfo.Click, AddressOf btnStudentInforeg_Click
        AddHandler btnEnrollment.Click, AddressOf btnEnrollment_Click
        AddHandler btnEnrollmentList.Click, AddressOf btnEnrollmentList_Click
        AddHandler btnEnrollmentReview.Click, AddressOf btnEnrollmentReview_Click
        AddHandler btnCourseList.Click, AddressOf btnCourseList_Click
        AddHandler btnSubjectList.Click, AddressOf btnSubjectList_Click
        AddHandler btnScheduleList.Click, AddressOf btnScheduleList_Click
        AddHandler btnLogout.Click, AddressOf btnLogout_Click

        ' DEFAULT VIEW: Pagbukas ng form, automatic na Dashboard ang ipapakita
        OpenRegistrarChild(New registrardashboard())
    End Sub

    ' 2. THE ENGINE: Ang tagapalit ng mga forms sa loob ng pnlMain
    Private Sub OpenRegistrarChild(ByVal childForm As Form)
        ' STEP A: Linisin ang panel mula sa anumang controls o lumang forms
        For Each ctrl As Control In pnlMain.Controls.Cast(Of Control)().ToArray()
            If TypeOf ctrl Is Form Then
                Dim oldForm As Form = DirectCast(ctrl, Form)
                oldForm.Close()
                oldForm.Dispose()
            Else
                ' Itago ang welcome label o static controls kung mayroon man
                ctrl.Visible = False
            End If
        Next

        ' Siguraduhin na zero-out ang controls list para sa bagong form
        pnlMain.Controls.Clear()

        ' STEP B: I-setup ang bagong form bilang child control
        childForm.TopLevel = False
        childForm.FormBorderStyle = FormBorderStyle.None
        childForm.Dock = DockStyle.Fill

        ' STEP C: Ilagay sa panel at ipakita sa user
        pnlMain.Controls.Add(childForm)
        pnlMain.Tag = childForm
        childForm.Show()

        ' I-update ang header title base sa pangalan ng binuksang form
        lblHeader.Text = "Registrar - " & childForm.Text
    End Sub

    ' 3. BUTTON ACTIONS: Mga function na tatawag sa specific forms

    Private Sub btnDashboard_Click(sender As Object, e As EventArgs)
        ' Binabago nito ang view pabalik sa Dashboard
        OpenRegistrarChild(New registrardashboard())
    End Sub

    Private Sub btnStudentInforeg_Click(sender As Object, e As EventArgs)
        OpenRegistrarChild(New Studentinforeg())
    End Sub

    Private Sub btnEnrollment_Click(sender As Object, e As EventArgs)
        OpenRegistrarChild(New enrollmentfrm())
    End Sub

    Private Sub btnEnrollmentList_Click(sender As Object, e As EventArgs)
        OpenRegistrarChild(New enrollmentslist())
    End Sub

    Private Sub btnEnrollmentReview_Click(sender As Object, e As EventArgs)
        OpenRegistrarChild(New enrollmentreview())
    End Sub

    Private Sub btnCourseList_Click(sender As Object, e As EventArgs)
        OpenRegistrarChild(New courselist())
    End Sub

    Private Sub btnSubjectList_Click(sender As Object, e As EventArgs)
        OpenRegistrarChild(New subjectlist())
    End Sub

    Private Sub btnScheduleList_Click(sender As Object, e As EventArgs)
        OpenRegistrarChild(New ScheduleFrm())
    End Sub

    Private Sub btnLogout_Click(sender As Object, e As EventArgs)
        ' Siguraduhin muna bago i-logout ang user
        If MessageBox.Show("Are you sure you want to logout?", "Logout Notice", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
            loginfrm.Show()
            Me.Close() ' Isinasara ang form at tinatapos ang session
        End If
    End Sub

End Class