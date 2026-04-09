Public Class Financefrm

    ' 1. INITIALIZATION & DEFAULT VIEW
    Private Sub Financefrm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' I-link ang mga buttons
        AddHandler btnDashboard.Click, AddressOf btnDashboard_Click
        AddHandler btnBilling.Click, AddressOf btnBilling_Click
        AddHandler btnPayments.Click, AddressOf btnPayments_Click
        AddHandler btnReports.Click, AddressOf btnReports_Click
        AddHandler btnLogout.Click, AddressOf btnLogout_Click

        ' GAWIN MONG DEFAULT: I-load agad ang Dashboard pagkabukas ng Form
        LoadDashboard()
    End Sub

    ' Reusable logic para sa Dashboard para hindi paulit-ulit
    Private Sub LoadDashboard()
        ' Palitan ang "financedashboard" sa actual name ng Form file mo
        OpenFinanceChild(New financedashboard())
        lblHeader.Text = "Finance Dashboard Overview"
    End Sub

    ' 2. THE ENGINE: SWAPPING FORMS
    Private Sub OpenFinanceChild(ByVal childForm As Form)
        ' Siguraduhin na malinis ang panel at na-dispose ang lumang forms (Memory Management)
        If pnlMain.Controls.Count > 0 Then
            For Each ctrl As Control In pnlMain.Controls.Cast(Of Control)().ToList()
                If TypeOf ctrl Is Form Then
                    DirectCast(ctrl, Form).Close()
                    ctrl.Dispose()
                End If
            Next
            pnlMain.Controls.Clear()
        End If

        ' Setup the child form
        childForm.TopLevel = False
        childForm.FormBorderStyle = FormBorderStyle.None
        childForm.Dock = DockStyle.Fill

        pnlMain.Controls.Add(childForm)
        pnlMain.Tag = childForm
        childForm.Show()

        lblHeader.Text = "Finance - " & childForm.Text
    End Sub

    ' 3. BUTTON ACTIONS
    Private Sub btnDashboard_Click(sender As Object, e As EventArgs)
        LoadDashboard()
    End Sub

    Private Sub btnBilling_Click(sender As Object, e As EventArgs)
        OpenFinanceChild(New Billing())
    End Sub

    Private Sub btnPayments_Click(sender As Object, e As EventArgs)
        OpenFinanceChild(New paymentfrm())
    End Sub

    Private Sub btnReports_Click(sender As Object, e As EventArgs)
        OpenFinanceChild(New reports())
    End Sub

    Private Sub btnLogout_Click(sender As Object, e As EventArgs)
        If MessageBox.Show("Are you sure you want to logout?", "Logout", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
            loginfrm.Show()
            Me.Close()
        End If
    End Sub

    Private Sub PictureBox5_Click(sender As Object, e As EventArgs) Handles PictureBox5.Click

    End Sub
End Class
