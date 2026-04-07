<?php
require_once 'config.php';

if (!isset($_SESSION['user_id']) || $_SESSION['role'] !== 'student') {
    header("Location: login.php");
    exit;
}

$user_id = $_SESSION['user_id'];

$query = "SELECT sub.subject_code, sub.subject_title, g.grade_value, g.remarks
          FROM grades g
          JOIN enrollments e ON g.enrollment_id = e.enrollment_id
          JOIN students s ON e.student_id = s.student_id
          JOIN subjects sub ON g.subject_id = sub.subject_id
          WHERE s.user_id = ?
          ORDER BY sub.subject_code ASC";

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
    <title>My Grades</title>
    <link rel="stylesheet" href="style.css">
</head>
<body>
    <div class="container">
        <h2>My Grades</h2>

        <?php if ($result && $result->num_rows > 0): ?>
            <table border="1" width="100%" cellpadding="8">
                <tr>
                    <th>Subject Code</th>
                    <th>Subject Title</th>
                    <th>Grade</th>
                    <th>Remarks</th>
                </tr>
                <?php while ($row = $result->fetch_assoc()): ?>
                    <tr>
                        <td><?php echo htmlspecialchars($row['subject_code']); ?></td>
                        <td><?php echo htmlspecialchars($row['subject_title']); ?></td>
                        <td><?php echo htmlspecialchars($row['grade_value']); ?></td>
                        <td><?php echo htmlspecialchars($row['remarks']); ?></td>
                    </tr>
                <?php endwhile; ?>
            </table>
        <?php else: ?>
            <p>No grades available yet.</p>
        <?php endif; ?>

        <p><a href="dashboard.php">Back to Dashboard</a></p>
    </div>
</body>
</html>
