Imports System.Data.SqlClient
Imports MySql.Data.MySqlClient

Public Class Billing
    Private selectedBillingID As Integer = 0

    Private Sub Billing_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadBillingData()
    End Sub

    Public Sub LoadBillingData(Optional searchKeyword As String = "")
        Try
            openConn()

            Dim query As String =
                "SELECT b.billing_id, s.student_id, " &
                "CONCAT(s.first_name, ' ', s.last_name) AS student_name, " &
                "b.total_amount, b.paid_amount, b.balance, b.due_date " &
                "FROM billing b " &
                "JOIN enrollments e ON b.enrollment_id = e.enrollment_id " &
                "JOIN students s ON e.student_id = s.student_id "

            If Not String.IsNullOrWhiteSpace(searchKeyword) AndAlso searchKeyword <> "Search student name or ID" Then
                query &= "WHERE s.student_id LIKE @search OR s.last_name LIKE @search OR s.first_name LIKE @search "
            End If

            query &= "ORDER BY b.billing_id DESC"

            Dim adapter As New MySqlDataAdapter(query, conn)
            If query.Contains("@search") Then
                adapter.SelectCommand.Parameters.AddWithValue("@search", "%" & searchKeyword.Trim() & "%")
            End If

            Dim dt As New DataTable()
            adapter.Fill(dt)
            dgvBilling.DataSource = dt

            lblSelectedStudent.Text = "STUDENT: ----"
            lblBalanceStatus.Text = "BALANCE: P 0.00"
            selectedBillingID = 0
            txtPaymentInput.Clear()
            dgvPaymentHistory.DataSource = Nothing

        Catch ex As Exception
            MsgBox("Error loading data: " & ex.Message)
        Finally
            closeConn()
        End Try
    End Sub

    Private Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        LoadBillingData(txtSearch.Text)
    End Sub

    Private Sub dgvBilling_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvBilling.CellClick
        If e.RowIndex >= 0 Then
            Dim row As DataGridViewRow = dgvBilling.Rows(e.RowIndex)
            selectedBillingID = Convert.ToInt32(row.Cells("billing_id").Value)
            lblSelectedStudent.Text = "STUDENT: " & row.Cells("student_name").Value.ToString()
            lblBalanceStatus.Text = "BALANCE: P " & FormatNumber(row.Cells("balance").Value, 2)
            txtPaymentInput.Clear()
            LoadPaymentHistory(selectedBillingID)
        End If
    End Sub

    Private Sub LoadPaymentHistory(billingID As Integer)
        Try
            openConn()

            Dim query As String =
                "SELECT payment_date AS 'Date', amount_paid AS 'Amount Paid', reference_no AS 'OR Number' " &
                "FROM payments WHERE billing_id = @bid ORDER BY payment_date DESC"

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

    Private Sub btnFullPay_Click(sender As Object, e As EventArgs) Handles btnFullPay.Click
        If selectedBillingID = 0 OrElse dgvBilling.SelectedRows.Count = 0 Then
            MsgBox("Please select a student record first.")
            Return
        End If

        Dim currentBalance As Decimal = CDec(dgvBilling.SelectedRows(0).Cells("balance").Value)
        If currentBalance <= 0 Then
            MsgBox("This account is already fully paid.")
            Return
        End If

        txtPaymentInput.Text = currentBalance.ToString("F2")
    End Sub

    Private Sub btnPartialPay_Click(sender As Object, e As EventArgs) Handles btnPartialPay.Click
        If selectedBillingID = 0 Then
            MsgBox("Please select a student record first.")
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

        If dgvBilling.SelectedRows.Count = 0 Then
            MsgBox("Please select a billing row first.")
            Return
        End If

        Dim currentBalance As Decimal = CDec(dgvBilling.SelectedRows(0).Cells("balance").Value)

        If amount > currentBalance Then
            MsgBox("Partial payment cannot be greater than the remaining balance!")
            Return
        End If

        MsgBox("Use the cashier payment form to post the actual payment with OR number.", MsgBoxStyle.Information)
    End Sub
End Class
