<?php
require_once 'config.php';

if (!isset($_SESSION['user_id']) || $_SESSION['role'] !== 'student') {
    header("Location: login.php");
    exit;
}

$username = $_SESSION['username'];
?>

<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Student Dashboard</title>
    <link rel="stylesheet" href="style.css">
</head>
<body>
    <div class="container">
        <h2>Welcome, <?php echo htmlspecialchars($username); ?></h2>

        <p>Select what you want to view:</p>

        <ul>
            <li><a href="announcements.php">View Announcements</a></li>
            <li><a href="subjects.php">View Enrolled Subjects</a></li>
            <li><a href="balance.php">View Balance</a></li>
            <li><a href="logout.php">Logout</a></li>
            <li><a href="grades.php">View Grades</a></li>

        </ul>
    </div>
</body>
</html>
