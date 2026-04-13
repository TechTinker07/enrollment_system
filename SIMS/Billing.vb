Imports MySql.Data.MySqlClient

Public Class Billing
    Private selectedBillingID As Integer = 0

    Private Sub Billing_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadBillingData()
    End Sub

    ' 1. LOAD BILLING DATA
    Public Sub LoadBillingData(Optional searchKeyword As String = "")
        Try
            openConn()
            Dim query As String = "SELECT b.billing_id, s.student_id, " &
                                 "CONCAT(s.first_name, ' ', s.last_name) AS student_name, " &
                                 "b.total_amount, b.paid_amount, b.balance, b.due_date " &
                                 "FROM billing b " &
                                 "JOIN enrollments e ON b.enrollment_id = e.enrollment_id " &
                                 "JOIN students s ON e.student_id = s.student_id "

            If Not String.IsNullOrEmpty(searchKeyword) Then
                query &= " WHERE s.student_id LIKE @search OR s.last_name LIKE @search"
            End If

            Dim adapter As New MySqlDataAdapter(query, conn)
            If Not String.IsNullOrEmpty(searchKeyword) Then
                adapter.SelectCommand.Parameters.AddWithValue("@search", "%" & searchKeyword & "%")
            End If

            Dim dt As New DataTable()
            adapter.Fill(dt)
            dgvBilling.DataSource = dt

            ' Reset UI after refresh
            lblSelectedStudent.Text = "STUDENT: ----"
            lblBalanceStatus.Text = "BALANCE: ₱ 0.00"
            selectedBillingID = 0
            txtPaymentInput.Clear()
            dgvPaymentHistory.DataSource = Nothing

        Catch ex As Exception
            MsgBox("Error loading data: " & ex.Message)
        Finally
            closeConn()
        End Try
    End Sub

    ' 2. SEARCH
    Private Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        LoadBillingData(txtSearch.Text)
    End Sub

    ' 3. ROW CLICK — load student info + payment history
    Private Sub dgvBilling_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvBilling.CellClick
        If e.RowIndex >= 0 Then
            Dim row As DataGridViewRow = dgvBilling.Rows(e.RowIndex)
            selectedBillingID = Convert.ToInt32(row.Cells("billing_id").Value)
            lblSelectedStudent.Text = "STUDENT: " & row.Cells("student_name").Value.ToString()
            lblBalanceStatus.Text = "BALANCE: ₱ " & FormatNumber(row.Cells("balance").Value, 2)
            txtPaymentInput.Clear()

            ' Load payment history ng selected student
            LoadPaymentHistory(selectedBillingID)
        End If
    End Sub

    ' 4. LOAD PAYMENT HISTORY
    Private Sub LoadPaymentHistory(billingID As Integer)
        Try
            openConn()
            Dim query As String = "SELECT payment_date AS 'Date', " &
                                 "amount_paid AS 'Amount Paid', " &
                                 "reference_no AS 'Reference No' " &
                                 "FROM payments " &
                                 "WHERE billing_id = @bid " &
                                 "ORDER BY payment_date DESC"

            Dim adapter As New MySqlDataAdapter(query, conn)
            adapter.SelectCommand.Parameters.AddWithValue("@bid", billingID)

            Dim dt As New DataTable()
            adapter.Fill(dt)
            dgvPaymentHistory.DataSource = dt

        Catch ex As Exception
            MsgBox("Error loading payment history: " & ex.Message)
        Finally
            closeConn()
        End Try
    End Sub

    ' 5. FULL PAYMENT
    Private Sub btnFullPay_Click(sender As Object, e As EventArgs) Handles btnFullPay.Click
        If selectedBillingID = 0 Then
            MsgBox("Please select a student record first.")
            Return
        End If

        If dgvBilling.SelectedRows.Count = 0 Then
            MsgBox("Please select a billing row first.")
            Return
        End If

        Dim currentBalance As Decimal = CDec(dgvBilling.SelectedRows(0).Cells("balance").Value)
        If currentBalance <= 0 Then
            MsgBox("This account is already fully paid.")
            Return
        End If

        txtPaymentInput.Text = currentBalance.ToString("F2")
        ProcessPayment(currentBalance, "Full Payment")
    End Sub

    ' 6. PARTIAL PAYMENT
    Private Sub btnPartialPay_Click(sender As Object, e As EventArgs) Handles btnPartialPay.Click
        If selectedBillingID = 0 Then
            MsgBox("Please select a student record first.")
            Return
        End If

        If dgvBilling.SelectedRows.Count = 0 Then
            MsgBox("Please select a billing row first.")
            Return
        End If

        Dim amount As Decimal
        If Not Decimal.TryParse(txtPaymentInput.Text, amount) Then
            MsgBox("Please enter a valid payment amount.")
            Return
        End If

        If amount <= 0 Then
            MsgBox("Payment amount must be greater than zero.")
            Return
        End If

        Dim currentBalance As Decimal = CDec(dgvBilling.SelectedRows(0).Cells("balance").Value)

        If amount > currentBalance Then
            MsgBox("Partial payment cannot be greater than the remaining balance!")
            Return
        End If

        ProcessPayment(amount, "Partial Payment")
    End Sub

    ' 7. PROCESS PAYMENT — FIX: balance nag-a-update na sa DB
    Private Sub ProcessPayment(payAmount As Decimal, type As String)
        Try
            openConn()
            Dim transaction = conn.BeginTransaction()

            Try
                ' balance is a generated column in the schema, so only paid_amount should be updated.
                Dim updateQuery As String = "UPDATE billing SET paid_amount = paid_amount + @amt WHERE billing_id = @bid"
                Dim updateCmd = New MySqlCommand(updateQuery, conn, transaction)
                updateCmd.Parameters.AddWithValue("@amt", payAmount)
                updateCmd.Parameters.AddWithValue("@bid", selectedBillingID)
                updateCmd.ExecuteNonQuery()

                ' Insert payment record
                Dim insertQuery As String = "INSERT INTO payments (billing_id, amount_paid, payment_date, reference_no) " &
                                           "VALUES (@bid, @amt, NOW(), @ref)"
                Dim insertCmd = New MySqlCommand(insertQuery, conn, transaction)
                insertCmd.Parameters.AddWithValue("@bid", selectedBillingID)
                insertCmd.Parameters.AddWithValue("@amt", payAmount)
                insertCmd.Parameters.AddWithValue("@ref", "REF-" & DateTime.Now.ToString("yyyyMMddHHmmss"))
                insertCmd.ExecuteNonQuery()

                transaction.Commit()
                MsgBox(type & " processed successfully!", MsgBoxStyle.Information)

                Dim currentBillingID As Integer = selectedBillingID
                LoadBillingData()
                selectedBillingID = currentBillingID
                LoadPaymentHistory(currentBillingID)

            Catch ex As Exception
                transaction.Rollback()
                MsgBox("Transaction failed: " & ex.Message)
            End Try

        Catch ex As Exception
            MsgBox("Connection error: " & ex.Message)
        Finally
            closeConn()
        End Try
    End Sub

    Private Sub dgvBilling_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvBilling.CellContentClick

    End Sub

    Private Sub txtSearch_Enter(sender As Object, e As EventArgs) Handles txtSearch.Enter
        If txtSearch.Text = "Search student name or ID" Then
            txtSearch.Text = ""
            txtSearch.ForeColor = Color.Black
        End If
    End Sub

    Private Sub txtSearch_Leave(sender As Object, e As EventArgs) Handles txtSearch.Leave
        If String.IsNullOrWhiteSpace(txtSearch.Text) Then
            txtSearch.Text = "Search student name or ID"
            txtSearch.ForeColor = Color.Gray
        End If
    End Sub
End Class
