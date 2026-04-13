Imports MySql.Data.MySqlClient

Public Class paymentfrm
    Dim selectedBillingID As Integer = 0

    ' Load pending bills on startup
    Private Sub paymentfrm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadBills()
    End Sub

    Private Sub LoadBills(Optional search As String = "")
        Try
            openConn()
            ' Join with students table to show names
            Dim query As String = "SELECT b.billing_id, s.student_id, s.last_name, s.first_name, " &
                                 "b.total_amount, b.paid_amount, b.balance " &
                                 "FROM billing b JOIN enrollments e ON b.enrollment_id = e.enrollment_id " &
                                 "JOIN students s ON e.student_id = s.student_id"

            If search <> "" Then
                query &= " WHERE s.student_id LIKE @s OR s.last_name LIKE @s"
            End If

            Dim adapter As New MySqlDataAdapter(query, conn)
            adapter.SelectCommand.Parameters.AddWithValue("@s", "%" & search & "%")
            Dim dt As New DataTable
            adapter.Fill(dt)
            dgvBills.DataSource = dt
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            closeConn()
        End Try
    End Sub

    ' Map selected grid row to payment fields
    Private Sub dgvBills_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvBills.CellClick
        If e.RowIndex >= 0 Then
            Dim row As DataGridViewRow = dgvBills.Rows(e.RowIndex)
            selectedBillingID = row.Cells("billing_id").Value
            lblBillID.Text = "Billing ID: " & selectedBillingID
            lblStudentName.Text = "Student: " & row.Cells("last_name").Value & ", " & row.Cells("first_name").Value
            lblCurrentBalance.Text = "Current Balance: ₱ " & FormatNumber(row.Cells("balance").Value, 2)
            txtAmountToPay.Text = row.Cells("balance").Value ' Default to Full Payment
        End If
    End Sub

    Private Sub btnProcessPayment_Click(sender As Object, e As EventArgs) Handles btnProcessPayment.Click
        If selectedBillingID = 0 Then
            MsgBox("Please select a bill first.")
            Return
        End If

        Dim paymentAmount As Decimal
        If Not Decimal.TryParse(txtAmountToPay.Text, paymentAmount) Then
            MsgBox("Please enter a valid payment amount.")
            Return
        End If

        If paymentAmount <= 0 Then
            MsgBox("Payment amount must be greater than zero.")
            Return
        End If

        If String.IsNullOrWhiteSpace(txtReferenceNo.Text) Then
            MsgBox("Please enter a reference number.")
            Return
        End If

        Dim currentBalance As Decimal = CDec(dgvBills.SelectedRows(0).Cells("balance").Value)

        If paymentAmount > currentBalance Then
            MsgBox("Payment amount cannot be greater than the current balance.")
            Return
        End If


        If selectedBillingID = 0 Or txtAmountToPay.Text = "" Then
            MsgBox("Please select a bill and enter an amount.")
            Return
        End If

        Try
            openConn()
            ' Start transaction
            Dim trans As MySqlTransaction = conn.BeginTransaction()

            Try
                ' 1. Insert into Payments Table
                Dim payQuery As String = "INSERT INTO payments (billing_id, amount_paid, payment_date, reference_no) " &
                         "VALUES (@bid, @amt, NOW(), @ref)"
                Dim payCmd = New MySqlCommand(payQuery, conn, trans)
                payCmd.Parameters.AddWithValue("@bid", selectedBillingID)
                payCmd.Parameters.AddWithValue("@amt", paymentAmount)
                payCmd.Parameters.AddWithValue("@ref", txtReferenceNo.Text)
                payCmd.ExecuteNonQuery()

                ' 2. Update Billing Table (Add the new payment to existing paid_amount)
                Dim billQuery As String = "UPDATE billing SET paid_amount = paid_amount + @amt WHERE billing_id = @bid"
                Dim billCmd = New MySqlCommand(billQuery, conn, trans)
                billCmd.Parameters.AddWithValue("@amt", paymentAmount)
                billCmd.Parameters.AddWithValue("@bid", selectedBillingID)
                billCmd.ExecuteNonQuery()

                trans.Commit()
                MsgBox("Payment Processed Successfully!", MsgBoxStyle.Information)

                ' Refresh UI
                txtAmountToPay.Clear()
                txtReferenceNo.Clear()
                LoadBills()
            Catch ex As Exception
                trans.Rollback()
                MsgBox("Transaction Failed: " & ex.Message)
            End Try
        Finally
            closeConn()
        End Try
    End Sub
End Class