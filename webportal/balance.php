<?php
require_once 'config.php';

if (!isset($_SESSION['user_id']) || $_SESSION['role'] !== 'student') {
    header("Location: login.php");
    exit;
}

$user_id = $_SESSION['user_id'];

$query = "SELECT b.billing_id, b.total_amount, b.paid_amount, b.balance, b.due_date
          FROM billing b
          JOIN enrollments e ON b.enrollment_id = e.enrollment_id
          JOIN students s ON e.student_id = s.student_id
          WHERE s.user_id = ?
          ORDER BY b.billing_id DESC";

$stmt = $conn->prepare($query);
$stmt->bind_param("i", $user_id);
$stmt->execute();
$result = $stmt->get_result();
?>

<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Balance Inquiry</title>
    <link rel="stylesheet" href="style.css">
</head>
<body>
    <div class="container">
        <h2>My Balance</h2>

        <?php if ($result && $result->num_rows > 0): ?>
            <table border="1" width="100%" cellpadding="8">
                <tr>
                    <th>Billing ID</th>
                    <th>Total Amount</th>
                    <th>Paid Amount</th>
                    <th>Balance</th>
                    <th>Due Date</th>
                </tr>
                <?php while ($row = $result->fetch_assoc()): ?>
                    <tr>
                        <td><?php echo htmlspecialchars($row['billing_id']); ?></td>
                        <td><?php echo htmlspecialchars(number_format($row['total_amount'], 2)); ?></td>
                        <td><?php echo htmlspecialchars(number_format($row['paid_amount'], 2)); ?></td>
                        <td><?php echo htmlspecialchars(number_format($row['balance'], 2)); ?></td>
                        <td><?php echo htmlspecialchars($row['due_date']); ?></td>
                    </tr>
                <?php endwhile; ?>
            </table>
        <?php else: ?>
            <p>No billing record found.</p>
        <?php endif; ?>

        <p><a href="dashboard.php">Back to Dashboard</a></p>
    </div>
</body>
</html>
