Imports System.Data.SqlClient
Imports MySql.Data.MySqlClient

Public Class paymentfrm
    Private selectedBillingID As Integer = 0

    Private Sub paymentfrm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadBills()
        GenerateOR() ' Auto-generate OR on load
    End Sub

    ' === AUTO-GENERATE OR NUMBER ===
    Private Sub GenerateOR()
        Dim orNumber As String = "OR-" & Format(Now, "yyyyMMdd") & "-" & CStr(Int(Rnd() * 90000) + 10000)
        txtReferenceNo.Text = orNumber
    End Sub

    Private Sub LoadBills(Optional search As String = "")
        Try
            openConn()

            Dim query As String =
                "SELECT b.billing_id, s.student_id, s.last_name, s.first_name, " &
                "b.total_amount, b.paid_amount, b.balance, b.due_date " &
                "FROM billing b " &
                "JOIN enrollments e ON b.enrollment_id = e.enrollment_id " &
                "JOIN students s ON e.student_id = s.student_id " &
                "WHERE b.balance > 0 " ' Only show unpaid/partial bills

            If Not String.IsNullOrWhiteSpace(search) Then
                query &= "AND (s.student_id LIKE @s OR s.last_name LIKE @s OR s.first_name LIKE @s) "
            End If

            query &= "ORDER BY b.due_date ASC"

            Dim adapter As New MySqlDataAdapter(query, conn)
            If Not String.IsNullOrWhiteSpace(search) Then
                adapter.SelectCommand.Parameters.AddWithValue("@s", "%" & search.Trim() & "%")
            End If

            Dim dt As New DataTable
            adapter.Fill(dt)
            dgvBills.DataSource = dt

        Catch ex As Exception
            MsgBox("Error loading bills: " & ex.Message, MsgBoxStyle.Critical)
        Finally
            closeConn()
        End Try
    End Sub

    Private Sub dgvBills_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvBills.CellClick
        If e.RowIndex < 0 Then Return
        If dgvBills.Rows(e.RowIndex).IsNewRow Then Return

        Dim row As DataGridViewRow = dgvBills.Rows(e.RowIndex)

        ' Validation: Check if balance is valid
        If row.Cells("balance").Value Is Nothing OrElse IsDBNull(row.Cells("balance").Value) Then
            MsgBox("Invalid billing record.", MsgBoxStyle.Exclamation)
            Return
        End If

        Dim balance As Decimal = CDec(row.Cells("balance").Value)

        If balance <= 0 Then
            MsgBox("This account is already fully paid.", MsgBoxStyle.Information)
            Return
        End If

        selectedBillingID = Convert.ToInt32(row.Cells("billing_id").Value)
        lblBillID.Text = selectedBillingID.ToString()
        lblStudentName.Text = row.Cells("last_name").Value.ToString() & ", " & row.Cells("first_name").Value.ToString()
        lblCurrentBalance.Text = "₱" & FormatNumber(balance, 2)
        txtAmountToPay.Text = balance.ToString("F2")

        ' Removed GenerateOR() from here so the OR number doesn't randomly change when clicking different rows.
        ' A new OR is generated only on Form Load and after a successful payment transaction.
    End Sub

    Private Sub btnProcessPayment_Click(sender As Object, e As EventArgs) Handles btnProcessPayment.Click
        ' === VALIDATIONS ===
        If selectedBillingID = 0 Then
            MsgBox("Please select a bill first.", MsgBoxStyle.Exclamation)
            Return
        End If

        Dim paymentAmount As Decimal
        If Not Decimal.TryParse(txtAmountToPay.Text, paymentAmount) Then
            MsgBox("Please enter a valid payment amount.", MsgBoxStyle.Exclamation)
            Return
        End If

        If paymentAmount <= 0 Then
            MsgBox("Payment amount must be greater than zero.", MsgBoxStyle.Exclamation)
            Return
        End If

        If String.IsNullOrWhiteSpace(txtReferenceNo.Text) Then
            MsgBox("OR Number is missing. Please regenerate.", MsgBoxStyle.Exclamation)
            GenerateOR()
            Return
        End If

        If dgvBills.SelectedRows.Count = 0 Then
            MsgBox("Please select a billing row first.", MsgBoxStyle.Exclamation)
            Return
        End If

        Dim currentBalance As Decimal = CDec(dgvBills.SelectedRows(0).Cells("balance").Value)

        If paymentAmount > currentBalance Then
            MsgBox("Payment amount (₱" & FormatNumber(paymentAmount, 2) & ") cannot exceed the current balance (₱" & FormatNumber(currentBalance, 2) & ").", MsgBoxStyle.Exclamation)
            Return
        End If

        ' === CONFIRM ===
        Dim confirm = MsgBox(
            "Confirm Payment?" & vbNewLine &
            "Amount: ₱" & FormatNumber(paymentAmount, 2) & vbNewLine &
            "OR Number: " & txtReferenceNo.Text,
            MsgBoxStyle.YesNo + MsgBoxStyle.Question, "Confirm Payment")

        If confirm <> MsgBoxResult.Yes Then Return

        ' === PROCESS ===
        Try
            openConn()
            Dim trans As MySqlTransaction = conn.BeginTransaction()

            Try
                ' Check duplicate OR
                Dim dupCheck As New MySqlCommand("SELECT COUNT(*) FROM payments WHERE reference_no = @ref", conn, trans)
                dupCheck.Parameters.AddWithValue("@ref", txtReferenceNo.Text.Trim())
                If Convert.ToInt32(dupCheck.ExecuteScalar()) > 0 Then
                    MsgBox("OR Number already exists. Regenerating...", MsgBoxStyle.Exclamation)
                    GenerateOR()
                    trans.Rollback()
                    Return
                End If

                ' Insert payment
                Dim payCmd As New MySqlCommand(
                    "INSERT INTO payments (billing_id, amount_paid, payment_date, reference_no) VALUES (@bid, @amt, NOW(), @ref)",
                    conn, trans)
                payCmd.Parameters.AddWithValue("@bid", selectedBillingID)
                payCmd.Parameters.AddWithValue("@amt", paymentAmount)
                payCmd.Parameters.AddWithValue("@ref", txtReferenceNo.Text.Trim())
                payCmd.ExecuteNonQuery()

                ' Update paid_amount in billing
                Dim billCmd As New MySqlCommand(
                    "UPDATE billing SET paid_amount = paid_amount + @amt WHERE billing_id = @bid",
                    conn, trans)
                billCmd.Parameters.AddWithValue("@amt", paymentAmount)
                billCmd.Parameters.AddWithValue("@bid", selectedBillingID)
                billCmd.ExecuteNonQuery()

                trans.Commit()
                MsgBox("Payment of ₱" & FormatNumber(paymentAmount, 2) & " processed successfully!" & vbNewLine & "OR: " & txtReferenceNo.Text, MsgBoxStyle.Information)

                ' Reset form
                ClearForm()
                LoadBills()

            Catch ex As Exception
                trans.Rollback()
                MsgBox("Transaction failed: " & ex.Message, MsgBoxStyle.Critical)
            End Try

        Catch ex As Exception
            MsgBox("Connection error: " & ex.Message, MsgBoxStyle.Critical)
        Finally
            closeConn()
        End Try
    End Sub

    Private Sub ClearForm()
        txtAmountToPay.Clear()
        selectedBillingID = 0
        lblBillID.Text = "Billing ID:"
        lblStudentName.Text = "Student:"
        lblCurrentBalance.Text = "Current Balance: ₱0.00"
        GenerateOR() ' Auto-generate new OR after each transaction
    End Sub

    Private Sub txtSearchStudent_TextChanged(sender As Object, e As EventArgs) Handles txtSearchStudent.TextChanged
        LoadBills(txtSearchStudent.Text)
    End Sub

    ' Manual regenerate OR button (optional)
    ' Private Sub btnGenerateOR_Click(sender As Object, e As EventArgs) Handles btnGenerateOR.Click
    '     GenerateOR()
    ' End Sub

End Class