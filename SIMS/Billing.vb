Imports System.Data.SqlClient
Imports MySql.Data.MySqlClient

Public Class Billing
    Private selectedBillingID As Integer = 0
    Private selectedEnrollmentID As Integer = 0

    Private gbAssessment As GroupBox
    Private lblTuition As Label
    Private lblMisc As Label
    Private lblAssessmentTotal As Label

    Private gbSchedule As GroupBox
    Private lblUponEnroll As Label
    Private lblPrelim As Label
    Private lblMidterm As Label
    Private lblFinal As Label

    Private Sub Billing_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        txtPaymentInput.Visible = False
        btnFullPay.Visible = False
        btnPartialPay.Visible = False
        Label3.Visible = False

        ' Create dynamic panels for Assessment and Payment Schedule
        gbAssessment = New GroupBox() With {.Text = "Assessment Breakdown", .Location = New Point(38, 45), .Size = New Size(250, 90), .Font = New Font("Segoe UI", 9, FontStyle.Bold), .ForeColor = Color.FromArgb(107, 26, 42)}
        lblTuition = New Label() With {.Location = New Point(10, 20), .AutoSize = True, .Font = New Font("Segoe UI", 8.5, FontStyle.Regular), .ForeColor = Color.Black}
        lblMisc = New Label() With {.Location = New Point(10, 40), .AutoSize = True, .Font = New Font("Segoe UI", 8.5, FontStyle.Regular), .ForeColor = Color.Black}
        lblAssessmentTotal = New Label() With {.Location = New Point(10, 60), .AutoSize = True, .Font = New Font("Segoe UI", 8.5, FontStyle.Bold), .ForeColor = Color.Black}
        gbAssessment.Controls.AddRange(New Control() {lblTuition, lblMisc, lblAssessmentTotal})

        gbSchedule = New GroupBox() With {.Text = "Payment Schedule", .Location = New Point(310, 45), .Size = New Size(300, 90), .Font = New Font("Segoe UI", 9, FontStyle.Bold), .ForeColor = Color.FromArgb(107, 26, 42)}
        lblUponEnroll = New Label() With {.Location = New Point(10, 20), .AutoSize = True, .Font = New Font("Segoe UI", 8.5, FontStyle.Regular), .ForeColor = Color.Black}
        lblPrelim = New Label() With {.Location = New Point(10, 40), .AutoSize = True, .Font = New Font("Segoe UI", 8.5, FontStyle.Regular), .ForeColor = Color.Black}
        lblMidterm = New Label() With {.Location = New Point(150, 20), .AutoSize = True, .Font = New Font("Segoe UI", 8.5, FontStyle.Regular), .ForeColor = Color.Black}
        lblFinal = New Label() With {.Location = New Point(150, 40), .AutoSize = True, .Font = New Font("Segoe UI", 8.5, FontStyle.Regular), .ForeColor = Color.Black}
        gbSchedule.Controls.AddRange(New Control() {lblUponEnroll, lblPrelim, lblMidterm, lblFinal})

        pnlPaymentArea.Controls.Add(gbAssessment)
        pnlPaymentArea.Controls.Add(gbSchedule)

        LoadBillingData()
    End Sub

    Public Sub LoadBillingData(Optional searchKeyword As String = "")
        Try
            openConn()

            Dim query As String =
                "SELECT b.billing_id, s.student_id, " &
                "CONCAT(s.first_name, ' ', s.last_name) AS student_name, " &
                "b.total_amount, b.paid_amount, b.balance, b.due_date, e.enrollment_id " &
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

            lblSelectedStudent.Text = "----"
            lblBalanceStatus.Text = "0.00"
            selectedBillingID = 0
            selectedEnrollmentID = 0
            ClearBreakdown()
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
            selectedEnrollmentID = Convert.ToInt32(row.Cells("enrollment_id").Value)
            lblSelectedStudent.Text = row.Cells("student_name").Value.ToString()
            lblBalanceStatus.Text = FormatNumber(row.Cells("balance").Value, 2)
            Try
                txtPaymentInput.Clear()
            Catch
            End Try
            
            Dim totalAmt As Decimal = Convert.ToDecimal(row.Cells("total_amount").Value)
            LoadBreakdown(selectedEnrollmentID, totalAmt)
        End If
    End Sub

    Private Sub ClearBreakdown()
        If lblTuition IsNot Nothing Then
            lblTuition.Text = "Tuition Fee: "
            lblMisc.Text = "Misc Fee: "
            lblAssessmentTotal.Text = "Total: "
            lblUponEnroll.Text = "Upon Enrollment: "
            lblPrelim.Text = "Prelim: "
            lblMidterm.Text = "Midterm: "
            lblFinal.Text = "Final: "
        End If
    End Sub

    Private Sub LoadBreakdown(enrollmentID As Integer, totalAmount As Decimal)
        Dim totalUnits As Integer = 0
        Try
            openConn()
            Dim query As String = "SELECT SUM(sub.units) FROM enrollment_details ed JOIN schedules s ON ed.schedule_id = s.schedule_id JOIN subjects sub ON s.subject_id = sub.subject_id WHERE ed.enrollment_id = @eid"
            Using cmd As New MySqlCommand(query, conn)
                cmd.Parameters.AddWithValue("@eid", enrollmentID)
                Dim obj As Object = cmd.ExecuteScalar()
                If obj IsNot DBNull.Value AndAlso obj IsNot Nothing Then
                    totalUnits = Convert.ToInt32(obj)
                End If
            End Using
        Catch ex As Exception
            ' Ignore error and use 0 units
        Finally
            closeConn()
        End Try

        Dim tuitionFee As Decimal = totalUnits * 500D
        Dim miscFee As Decimal = 1500D
        Dim otherFees As Decimal = totalAmount - (tuitionFee + miscFee)
        If otherFees < 0 Then otherFees = 0

        lblTuition.Text = "Tuition Fee: " & FormatCurrency(tuitionFee)
        lblMisc.Text = "Misc Fee: " & FormatCurrency(miscFee)
        
        If otherFees > 0 Then
            lblAssessmentTotal.Text = "Other Fees: " & FormatCurrency(otherFees) & " | Total: " & FormatCurrency(totalAmount)
        Else
            lblAssessmentTotal.Text = "Total Assessment: " & FormatCurrency(totalAmount)
        End If

        Dim uponEnroll As Decimal = totalAmount * 0.2D
        Dim prelim As Decimal = totalAmount * 0.2D
        Dim midterm As Decimal = totalAmount * 0.3D
        Dim final As Decimal = totalAmount * 0.3D

        lblUponEnroll.Text = "Upon Enrollment: " & FormatCurrency(uponEnroll)
        lblPrelim.Text = "Prelim: " & FormatCurrency(prelim)
        lblMidterm.Text = "Midterm: " & FormatCurrency(midterm)
        lblFinal.Text = "Final: " & FormatCurrency(final)
    End Sub

    Private Sub btnFullPay_Click(sender As Object, e As EventArgs) Handles btnFullPay.Click
        MsgBox("Payment functions are strictly restricted to the Cashier (Payment Module) to ensure proper segregation of duties." & vbCrLf & vbCrLf & "Please open the Payment form to process ORs and transactions.", MsgBoxStyle.Information, "Restricted Feature")
    End Sub

    Private Sub btnPartialPay_Click(sender As Object, e As EventArgs) Handles btnPartialPay.Click
        MsgBox("Payment functions are strictly restricted to the Cashier (Payment Module) to ensure proper segregation of duties." & vbCrLf & vbCrLf & "Please open the Payment form to process ORs and transactions.", MsgBoxStyle.Information, "Restricted Feature")
    End Sub
End Class
