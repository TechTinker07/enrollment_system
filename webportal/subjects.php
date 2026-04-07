<?php
require_once 'config.php';

if (!isset($_SESSION['user_id']) || $_SESSION['role'] !== 'student') {
    header("Location: login.php");
    exit;
}

$user_id = $_SESSION['user_id'];

$query = "SELECT s.student_id, sub.subject_code, sub.subject_title, sub.units,
                 sch.section, sch.days, sch.time_start, sch.time_end
          FROM students s
          JOIN users u ON s.user_id = u.user_id
          JOIN enrollments e ON s.student_id = e.student_id
          JOIN enrollment_details ed ON e.enrollment_id = ed.enrollment_id
          JOIN schedules sch ON ed.schedule_id = sch.schedule_id
          JOIN subjects sub ON sch.subject_id = sub.subject_id
          WHERE u.user_id = ?
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
    <title>Enrolled Subjects</title>
    <link rel="stylesheet" href="style.css">
</head>
<body>
    <div class="container">
        <h2>My Enrolled Subjects</h2>

        <?php if ($result && $result->num_rows > 0): ?>
            <table border="1" width="100%" cellpadding="8">
                <tr>
                    <th>Code</th>
                    <th>Title</th>
                    <th>Units</th>
                    <th>Section</th>
                    <th>Days</th>
                    <th>Time</th>
                </tr>
                <?php while ($row = $result->fetch_assoc()): ?>
                    <tr>
                        <td><?php echo htmlspecialchars($row['subject_code']); ?></td>
                        <td><?php echo htmlspecialchars($row['subject_title']); ?></td>
                        <td><?php echo htmlspecialchars($row['units']); ?></td>
                        <td><?php echo htmlspecialchars($row['section']); ?></td>
                        <td><?php echo htmlspecialchars($row['days']); ?></td>
                        <td>
                            <?php echo htmlspecialchars($row['time_start'] . " - " . $row['time_end']); ?>
                        </td>
                    </tr>
                <?php endwhile; ?>
            </table>
        <?php else: ?>
            <p>No enrolled subjects found.</p>
        <?php endif; ?>

        <p><a href="dashboard.php">Back to Dashboard</a></p>
    </div>
</body>
</html>
