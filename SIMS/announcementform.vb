Imports System.Data.SqlClient
Imports System.Drawing.Drawing2D
Imports MySql.Data.MySqlClient

Public Class announcementform
    Private ReadOnly standaloneHeaderTop As Integer = 106
    Private ReadOnly embeddedHeaderTop As Integer = 106

    Private Sub LoadAnnouncements()
        Try
            openConn()
            Dim query As String =
                "SELECT title AS 'Title', priority AS 'Priority', category AS 'Category', " &
                "target_group AS 'Send To', valid_until AS 'Valid Until', date_posted AS 'Date Posted' " &
                "FROM announcements ORDER BY date_posted DESC"
            Dim adapter As New MySqlDataAdapter(query, conn)
            Dim dt As New DataTable()
            adapter.Fill(dt)
            dgvAnnouncements.DataSource = dt
        Catch ex As Exception
            MsgBox("Error loading announcements: " & ex.Message)
        Finally
            closeConn()
        End Try
    End Sub

    Private Sub announcementform_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadAnnouncements()

        cmbRecipient.Items.Clear()
        cmbRecipient.Items.AddRange(New Object() {"All Students", "BSIT 1-A", "BSIT 1-B", "BSIT 2-A", "BSTM 1-A", "Faculty"})
        If cmbRecipient.Items.Count > 0 Then cmbRecipient.SelectedIndex = 0
        If ComboBox1.Items.Count > 0 Then ComboBox1.SelectedIndex = 0
        If ComboBox2.Items.Count > 0 Then ComboBox2.SelectedIndex = 0
        DateTimePicker1.Value = DateTime.Today.AddDays(7)

        ApplyHostLayout()
        ApplyRoundedCardStyles()
        RefreshAnnouncementMetrics()
    End Sub

    Private Sub btnPost_Click(sender As Object, e As EventArgs) Handles btnPost.Click
        If String.IsNullOrWhiteSpace(txtTitle.Text) OrElse
           String.IsNullOrWhiteSpace(txtMessage.Text) OrElse
           ComboBox1.SelectedIndex = -1 OrElse
           ComboBox2.SelectedIndex = -1 OrElse
           cmbRecipient.SelectedIndex = -1 Then
            MsgBox("Please complete the title, message, priority, category, and recipient fields.", MsgBoxStyle.Exclamation)
            Return
        End If

        Try
            openConn()

            Dim postedBy As Object = DBNull.Value
            If loginfrm IsNot Nothing AndAlso Not String.IsNullOrWhiteSpace(loginfrm.txtUsername.Text) Then
                Using userCmd As New MySqlCommand("SELECT user_id FROM users WHERE username = @username LIMIT 1", conn)
                    userCmd.Parameters.AddWithValue("@username", loginfrm.txtUsername.Text.Trim())
                    Dim userId = userCmd.ExecuteScalar()
                    If userId IsNot Nothing Then
                        postedBy = userId
                    End If
                End Using
            End If

            Dim query As String =
                "INSERT INTO announcements (title, content, priority, category, target_group, valid_until, posted_by, date_posted) " &
                "VALUES (@title, @content, @priority, @category, @target, @validUntil, @postedBy, NOW())"

            Using sqlCmd As MySqlCommand = cmd(query)
                sqlCmd.Parameters.AddWithValue("@title", txtTitle.Text.Trim())
                sqlCmd.Parameters.AddWithValue("@content", txtMessage.Text.Trim())
                sqlCmd.Parameters.AddWithValue("@priority", ComboBox1.Text.Trim())
                sqlCmd.Parameters.AddWithValue("@category", ComboBox2.Text.Trim())
                sqlCmd.Parameters.AddWithValue("@target", cmbRecipient.Text.Trim())
                sqlCmd.Parameters.AddWithValue("@validUntil", DateTimePicker1.Value.ToString("yyyy-MM-dd"))
                sqlCmd.Parameters.AddWithValue("@postedBy", postedBy)
                sqlCmd.ExecuteNonQuery()
            End Using

            MsgBox("Announcement posted successfully!", MsgBoxStyle.Information)
            LoadAnnouncements()
            RefreshAnnouncementMetrics()
            ClearFields()

        Catch ex As Exception
            MsgBox("Error posting announcement: " & ex.Message)
        Finally
            closeConn()
        End Try
    End Sub

    Private Sub btnClear_Click(sender As Object, e As EventArgs) Handles btnClear.Click
        ClearFields()
    End Sub

    Private Sub ClearFields()
        txtTitle.Clear()
        txtMessage.Clear()
        If cmbRecipient.Items.Count > 0 Then cmbRecipient.SelectedIndex = 0
        If ComboBox1.Items.Count > 0 Then ComboBox1.SelectedIndex = 0
        If ComboBox2.Items.Count > 0 Then ComboBox2.SelectedIndex = 0
        DateTimePicker1.Value = DateTime.Today.AddDays(7)
    End Sub

    Private Sub announcementform_Resize(sender As Object, e As EventArgs) Handles MyBase.Resize
        ApplyHostLayout()
        ApplyRoundedCardStyles()
    End Sub

    Private Sub ApplyHostLayout()
        Panel1.Visible = True

        If Me.TopLevel Then
            pnlPosted.Top = standaloneHeaderTop
            pnlUrgent.Top = standaloneHeaderTop
            pnlRecipients.Top = standaloneHeaderTop
        Else
            Me.WindowState = FormWindowState.Normal
            pnlPosted.Top = embeddedHeaderTop
            pnlUrgent.Top = embeddedHeaderTop
            pnlRecipients.Top = embeddedHeaderTop
        End If

        Panel5.Top = 205
        pnlInputContainer.Top = 235
        dgvAnnouncements.Top = pnlInputContainer.Bottom + 20
        dgvAnnouncements.Height = Math.Max(180, Me.ClientSize.Height - dgvAnnouncements.Top - 24)
    End Sub

    Private Sub ApplyRoundedCardStyles()
        ApplyRoundedCorners(pnlPosted, 16)
        ApplyRoundedCorners(pnlUrgent, 16)
        ApplyRoundedCorners(pnlRecipients, 16)
    End Sub

    Private Sub RefreshAnnouncementMetrics()
        Try
            openConn()

            Using totalCmd As New MySqlCommand("SELECT COUNT(*) FROM announcements", conn)
                lblPostedCount.Text = Convert.ToString(totalCmd.ExecuteScalar())
            End Using

            Using urgentCmd As New MySqlCommand("SELECT COUNT(*) FROM announcements WHERE priority IN ('Urgent', 'Critical')", conn)
                lblUrgentCount.Text = Convert.ToString(urgentCmd.ExecuteScalar())
            End Using

            Using recipientCmd As New MySqlCommand("SELECT COUNT(DISTINCT target_group) FROM announcements", conn)
                lblRecipientsCount.Text = Convert.ToString(recipientCmd.ExecuteScalar())
            End Using
        Catch
            lblPostedCount.Text = "-"
            lblUrgentCount.Text = "-"
            lblRecipientsCount.Text = "-"
        Finally
            closeConn()
        End Try
    End Sub

    Private Sub ApplyRoundedCorners(targetPanel As Panel, radius As Integer)
        If targetPanel.Width <= 0 OrElse targetPanel.Height <= 0 Then Return

        Dim diameter As Integer = radius * 2
        Dim path As New GraphicsPath()

        path.StartFigure()
        path.AddArc(0, 0, diameter, diameter, 180, 90)
        path.AddArc(targetPanel.Width - diameter, 0, diameter, diameter, 270, 90)
        path.AddArc(targetPanel.Width - diameter, targetPanel.Height - diameter, diameter, diameter, 0, 90)
        path.AddArc(0, targetPanel.Height - diameter, diameter, diameter, 90, 90)
        path.CloseFigure()

        If targetPanel.Region IsNot Nothing Then
            targetPanel.Region.Dispose()
        End If

        targetPanel.Region = New Region(path)
        path.Dispose()
    End Sub
End Class
