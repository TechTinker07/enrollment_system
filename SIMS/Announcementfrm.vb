Imports MySql.Data.MySqlClient

Public Class Announcementfrm

    ' Change this to a real User ID from your login session if you have one.
    ' Since it's a foreign key to the 'users' table, '1' must exist in that table.
    Private currentUserId As Integer = 1

    Private Sub Announcementfrm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        RefreshAnnouncements()
    End Sub

    ' === POST NEW ANNOUNCEMENT ===
    Private Sub btnPost_Click(sender As Object, e As EventArgs) Handles btnPost.Click
        ' Validation
        If String.IsNullOrWhiteSpace(txtAnnouncementTitle.Text) Or String.IsNullOrWhiteSpace(txtContent.Text) Then
            MsgBox("Please provide both a title and content for the announcement.", MsgBoxStyle.Exclamation)
            Return
        End If

        Try
            openConn()

            ' Matches your SQL schema: title, content, posted_by
            Dim sql As String = "INSERT INTO announcements (title, content, posted_by, date_posted) " &
                                "VALUES (@title, @content, @user, CURRENT_TIMESTAMP)"

            Dim run = cmd(sql)
            run.Parameters.AddWithValue("@title", txtAnnouncementTitle.Text.Trim())
            run.Parameters.AddWithValue("@content", txtContent.Text.Trim())
            run.Parameters.AddWithValue("@user", currentUserId)

            run.ExecuteNonQuery()
            MsgBox("Announcement posted successfully!", MsgBoxStyle.Information)

            ' Clean up UI
            txtAnnouncementTitle.Clear()
            txtContent.Clear()
            RefreshAnnouncements()

        Catch ex As Exception
            MsgBox("Error posting announcement: " & ex.Message, MsgBoxStyle.Critical)
        Finally
            closeConn()
        End Try
    End Sub

    ' === LOAD ANNOUNCEMENTS INTO GRID ===
    Private Sub RefreshAnnouncements()
        Try
            openConn()
            Dim dt As New DataTable

            ' Join with users table to show the name of the person who posted it
            Dim query As String = "SELECT a.announcement_id as ID, a.title as Title, " &
                                 "a.date_posted as 'Date Posted', u.username as 'Posted By' " &
                                 "FROM announcements a " &
                                 "LEFT JOIN users u ON a.posted_by = u.user_id " &
                                 "ORDER BY a.date_posted DESC"

            Dim adapter As New MySqlDataAdapter(cmd(query))
            adapter.Fill(dt)
            dgvAnnouncements.DataSource = dt

            ' Formatting the grid slightly
            If dgvAnnouncements.Columns.Count > 0 Then
                dgvAnnouncements.Columns("ID").Width = 50
            End If

        Catch ex As Exception
            MsgBox("Error loading history: " & ex.Message)
        Finally
            closeConn()
        End Try
    End Sub

End Class