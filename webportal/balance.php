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

/* ✅ TODAY (ilabas sa loop para efficient) */
$today = date('Y-m-d');
?>

<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Balance Inquiry</title>
    <link rel="stylesheet" href="style.css?v=<?php echo filemtime('style.css'); ?>">
</head>
<body>
    <div class="dashboard-layout">

        <!-- Sidebar -->
        <aside class="sidebar">
            <div class="sidebar-header">
                <div class="sidebar-logo">Enrollment System</div>
                <div class="sidebar-tagline">Student Portal</div>
            </div>

            <nav class="sidebar-nav">
                <a href="dashboard.php">Dashboard</a>
                <a href="balance.php" class="active">Balance</a>
            </nav>
        </aside>

        <!-- Main -->
        <div class="main-content">

            <!-- Topbar -->
            <div class="topbar">
                <div class="topbar-title">Balance Inquiry</div>
            </div>

            <!-- Page Body -->
            <div class="page-body">

                <div class="page-header">
                    <h1>My Balance</h1>
                    <p>View your billing and payment status</p>
                </div>

                <?php if ($result && $result->num_rows > 0): ?>
                    <div class="card">
                        <div class="table-wrapper">
                            <table class="data-table">
                                <thead>
                                    <tr>
                                        <th>Billing ID</th>
                                        <th>Total Amount</th>
                                        <th>Paid</th>
                                        <th>Balance</th>
                                        <th>Status</th> <!-- ✅ FIXED -->
                                        <th>Due Date</th>
                                    </tr>
                                </thead>
                                <tbody>

                                <?php while ($row = $result->fetch_assoc()): ?>

                                    <?php
                                    /* ✅ Overdue logic */
                                    $isOverdue = ($row['balance'] > 0 && $row['due_date'] < $today);
                                    ?>

                                    <tr>
                                        <td><?php echo htmlspecialchars($row['billing_id']); ?></td>

                                        <td>₱ <?php echo number_format($row['total_amount'], 2); ?></td>

                                        <td class="text-success">
                                            ₱ <?php echo number_format($row['paid_amount'], 2); ?>
                                        </td>

                                        <td class="<?php echo ($row['balance'] > 0) ? 'text-danger fw-bold' : 'text-success fw-bold'; ?>">
                                            ₱ <?php echo number_format($row['balance'], 2); ?>
                                        </td>

                                        <!-- ✅ STATUS -->
                                        <td>
                                            <?php if ($isOverdue): ?>
                                                <span class="badge badge-danger">Overdue</span>
                                            <?php elseif ($row['balance'] > 0): ?>
                                                <span class="badge badge-warning">Pending</span>
                                            <?php else: ?>
                                                <span class="badge badge-success">Paid</span>
                                            <?php endif; ?>
                                        </td>

                                        <!-- ✅ DUE DATE -->
                                        <td>
                                            <span class="badge <?php echo $isOverdue ? 'badge-danger' : 'badge-info'; ?>">
                                                <?php echo htmlspecialchars($row['due_date']); ?>
                                            </span>
                                        </td>
                                    </tr>

                                <?php endwhile; ?>

                                </tbody>
                            </table>
                        </div>
                    </div>
                <?php else: ?>
                    <div class="alert alert-info">
                        No billing record found.
                    </div>
                <?php endif; ?>

                <a href="dashboard.php" class="btn btn-secondary mt-2">
                    ← Back to Dashboard
                </a>

            </div>
        </div>
    </div>
</body>
</html>
