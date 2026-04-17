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
    <link rel="stylesheet" href="style.css?v=<?php echo filemtime('style.css'); ?>">
</head>
<body>
    <div class="dashboard-layout">

        <!-- Sidebar (optional kung meron ka na sa ibang pages) -->
        <aside class="sidebar">
            <div class="sidebar-header">
                <div class="sidebar-logo">Enrollment System</div>
                <div class="sidebar-tagline">Student Portal</div>
            </div>

            <nav class="sidebar-nav">
                <a href="dashboard.php">Dashboard</a>
                <a href="announcements.php" class="active">Announcements</a>
            </nav>
        </aside>

        <!-- Main Content -->
        <div class="main-content">

            <!-- Topbar -->
            <div class="topbar">
                <div class="topbar-title">Announcements</div>
            </div>

            <!-- Page Body -->
            <div class="page-body">

                <div class="page-header">
                    <h1>Latest Announcements</h1>
                    <p>Stay updated with important notices</p>
                </div>

                <?php if ($result && $result->num_rows > 0): ?>
                    <?php while ($row = $result->fetch_assoc()): ?>
                        <div class="card">
                            <div class="card-header">
                                <div>
                                    <div class="card-title">
                                        <?php echo htmlspecialchars($row['title']); ?>
                                    </div>
                                    <div class="card-subtitle">
                                        Posted by: <?php echo htmlspecialchars($row['posted_by'] ?? 'Unknown'); ?>
                                    </div>
                                </div>
                                <span class="badge badge-maroon">
                                    <?php echo htmlspecialchars($row['date_posted']); ?>
                                </span>
                            </div>

                            <p style="white-space: pre-line;">
                                <?php echo nl2br(htmlspecialchars($row['content'])); ?>
                            </p>
                        </div>
                    <?php endwhile; ?>
                <?php else: ?>
                    <div class="alert alert-info">
                        No announcements available.
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
