<?php
require_once 'config.php';

if (!isset($_SESSION['user_id']) || $_SESSION['role'] !== 'student') {
    header("Location: login.php");
    exit;
}

$query = "SELECT a.title, a.content, a.date_posted, u.username AS posted_by
          FROM announcements a
          LEFT JOIN users u ON a.posted_by = u.user_id
          ORDER BY a.date_posted DESC";

$result = $conn->query($query);
?>

<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Announcements</title>
    <link rel="stylesheet" href="style.css">
</head>
<body>
    <div class="container">
        <h2>Announcements</h2>

        <?php if ($result && $result->num_rows > 0): ?>
            <?php while ($row = $result->fetch_assoc()): ?>
                <div class="card">
                    <h3><?php echo htmlspecialchars($row['title']); ?></h3>
                    <p><?php echo nl2br(htmlspecialchars($row['content'])); ?></p>
                    <small>
                        Posted by: <?php echo htmlspecialchars($row['posted_by'] ?? 'Unknown'); ?>
                        | Date: <?php echo htmlspecialchars($row['date_posted']); ?>
                    </small>
                </div>
            <?php endwhile; ?>
        <?php else: ?>
            <p>No announcements available.</p>
        <?php endif; ?>

        <p><a href="dashboard.php">Back to Dashboard</a></p>
    </div>
</body>
</html>
