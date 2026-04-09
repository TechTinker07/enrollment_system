Imports MySql.Data.MySqlClient

Public Class announcementform

    ' Sub para i-load ang mga anunsyo sa DataGridView
    Private Sub LoadAnnouncements()
        Try
            openConn()
            ' Kukunin natin ang title, content, at date para i-display
            Dim query As String = "SELECT title, content, date_posted FROM announcements ORDER BY date_posted DESC"
            Dim adapter As New MySqlDataAdapter(query, conn)
            Dim dt As New DataTable()
            adapter.Fill(dt)

            dgvAnnouncements.DataSource = dt

            ' Ayusin ang headers ng Grid para magmukhang professional
            dgvAnnouncements.Columns(0).HeaderText = "Subject/Title"
            dgvAnnouncements.Columns(1).HeaderText = "Announcement Content"
            dgvAnnouncements.Columns(2).HeaderText = "Date Posted"
        Catch ex As Exception
            MsgBox("Error loading announcements: " & ex.Message)
        Finally
            closeConn()
        End Try
    End Sub

    ' Event pagka-load ng form
    Private Sub announcementform_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadAnnouncements()
        ' I-set ang default value ng ComboBox kung kinakailangan
        If cmbRecipient.Items.Count > 0 Then cmbRecipient.SelectedIndex = 0
    End Sub

    ' Logic para sa POST button
    Private Sub btnPost_Click(sender As Object, e As EventArgs) Handles btnPost.Click
        ' Validation: Siguraduhin na may laman ang fields
        If String.IsNullOrWhiteSpace(txtTitle.Text) Or String.IsNullOrWhiteSpace(txtMessage.Text) Then
            MsgBox("Please fill in both Title and Message details.", MsgBoxStyle.Exclamation)
            Return
        End If

        Try
            openConn()
            ' Ang posted_by ay pansamantalang naka-null muna o i-set base sa logged in user ID
            Dim query As String = "INSERT INTO announcements (title, content, date_posted) VALUES (@title, @content, NOW())"

            Using sqlCmd As MySqlCommand = cmd(query)
                ' Gamit ang Parameters para iwas SQL Injection
                sqlCmd.Parameters.AddWithValue("@title", "[" & cmbRecipient.Text & "] " & txtTitle.Text)
                sqlCmd.Parameters.AddWithValue("@content", txtMessage.Text)

                sqlCmd.ExecuteNonQuery()
                MsgBox("Announcement posted successfully!", MsgBoxStyle.Information)
            End Using

            ' Refresh ang listahan at linisin ang form
            LoadAnnouncements()
            ClearFields()

        Catch ex As Exception
            MsgBox("Error posting announcement: " & ex.Message)
        Finally
            closeConn()
        End Try
    End Sub

    ' Logic para sa CLEAR button
    Private Sub btnClear_Click(sender As Object, e As EventArgs) Handles btnClear.Click
        ClearFields()
    End Sub

    ' Helper function para linisin ang UI
    Private Sub ClearFields()
        txtTitle.Clear()
        txtMessage.Clear()
        If cmbRecipient.Items.Count > 0 Then cmbRecipient.SelectedIndex = 0
    End Sub

End Class