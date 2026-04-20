<?php
require_once 'config.php';

if (!isset($_SESSION['user_id'])) {
    header("Location: login.php");
    exit;
}

$student_id = $_SESSION['student_id'];
$announcement_id = $_GET['id'] ?? 0;

/* MARK AS READ */
$stmt = $conn->prepare("
INSERT IGNORE INTO announcement_reads (announcement_id, student_id)
VALUES (?, ?)
");
$stmt->bind_param("is", $announcement_id, $student_id);
$stmt->execute();

/* GET ANNOUNCEMENT */
$stmt = $conn->prepare("
SELECT a.*, u.username AS posted_by
FROM announcements a
LEFT JOIN users u ON a.posted_by = u.user_id
WHERE a.announcement_id = ?
");
$stmt->bind_param("i", $announcement_id);
$stmt->execute();
$result = $stmt->get_result();
$ann = $result->fetch_assoc();
?>
<h1><?php echo htmlspecialchars($ann['title']); ?></h1>

<p><?php echo nl2br(htmlspecialchars($ann['content'])); ?></p>

<small>
Posted by: <?php echo htmlspecialchars($ann['posted_by']); ?>
</small>