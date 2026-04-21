<?php
require_once 'config.php';

if (!isset($_SESSION['user_id']) || $_SESSION['role'] !== 'student') {
    header("Location: login.php");
    exit;
}

$query = "SELECT a.announcement_id, a.title, a.content, a.date_posted, u.username AS posted_by
          FROM announcements a
          LEFT JOIN users u ON a.posted_by = u.user_id
          ORDER BY a.date_posted DESC";
$result = $conn->query($query);

// Fetch read announcement IDs for the current student
$student_id = $_SESSION['student_id'];
$read_ids = [];
$read_query = "SELECT announcement_id FROM announcement_reads WHERE student_id = ?";
$stmt = $conn->prepare($read_query);
$stmt->bind_param("i", $student_id);
$stmt->execute();
$read_result = $stmt->get_result();
while ($r = $read_result->fetch_assoc()) {
    $read_ids[] = $r['announcement_id'];
}
$stmt->close();
?>
<!DOCTYPE html>
<html lang="en">
<head>
  <meta charset="UTF-8">
  <meta name="viewport" content="width=device-width, initial-scale=1.0">
  <title>Announcements — SIMS Portal</title>
  <link rel="preconnect" href="https://fonts.googleapis.com">
  <link rel="preconnect" href="https://fonts.gstatic.com" crossorigin>
  <link href="https://fonts.googleapis.com/css2?family=Inter:wght@400;500;600;700&display=swap" rel="stylesheet">
  <style>
    *, *::before, *::after { box-sizing: border-box; margin: 0; padding: 0; }

    :root {
      --maroon:        #800000;
      --maroon-hover:  #a00000;
      --maroon-pale:   #fdf0f0;
      --maroon-border: #f0dede;
      --bg:            #f9f5f5;
      --white:         #ffffff;
      --border:        #f0e8e8;
      --text:          #1a1a1a;
      --text-sub:      #888;
      --text-muted:    #bbb;
    }

    html, body {
      height: 100%;
      font-family: 'Inter', sans-serif;
      background: var(--bg);
      color: var(--text);
    }

    .page { display: flex; min-height: 100vh; }

    /* ── SIDEBAR ── */
    nav {
      width: 240px;
      background: var(--white);
      border-right: 1px solid var(--border);
      display: flex;
      flex-direction: column;
      position: fixed;
      height: 100vh;
      z-index: 10;
    }

    .sidebar-logo {
      display: flex;
      align-items: center;
      gap: 10px;
      padding: 24px 24px 20px;
      border-bottom: 1px solid #f5eded;
    }

    .logo-icon {
      width: 36px; height: 36px;
      background: var(--maroon);
      border-radius: 10px;
      display: flex; align-items: center; justify-content: center;
      flex-shrink: 0;
    }

    .logo-icon svg { display: block; }

    .logo-text .abbr {
      font-size: 18px; font-weight: 700;
      color: var(--maroon);
      letter-spacing: .1em; text-transform: uppercase;
    }

    .logo-text .sub { font-size: 14px; color: var(--text-muted); margin-top: 1px; }

    .nav-links { list-style: none; padding: 14px 12px; flex: 1; }
    .nav-links li { margin-bottom: 2px; }

    .nav-links a {
      display: flex; align-items: center; gap: 10px;
      padding: 10px 12px; border-radius: 8px;
      text-decoration: none; color: #555;
      font-weight: 400; font-size: 13.5px;
      transition: background .15s, color .15s;
    }

    .nav-links a svg { stroke: #ccc; transition: stroke .15s; }
    .nav-links a:hover { background: var(--maroon-pale); color: var(--maroon); }
    .nav-links a:hover svg { stroke: var(--maroon); }
    .nav-links a.active { background: var(--maroon-pale); color: var(--maroon); font-weight: 600; }
    .nav-links a.active svg { stroke: var(--maroon); }

    .sidebar-bottom {
      padding: 12px 12px 16px;
      border-top: 1px solid #f5eded;
    }

    .logout-link {
      display: flex; align-items: center; gap: 10px;
      padding: 10px 12px; border-radius: 8px;
      text-decoration: none; color: #cc3333;
      font-size: 14px; font-weight: 500;
      transition: background .15s;
    }

    .logout-link:hover { background: #fff5f5; }
    .logout-link svg { stroke: #cc3333; }

    /* ── MAIN ── */
    .main-content {
      margin-left: 240px;
      flex: 1;
      display: flex;
      flex-direction: column;
    }

    /* Topbar breadcrumb */
    .topbar {
      background: var(--white);
      border-bottom: 1px solid var(--border);
      padding: 13px 40px;
      display: flex;
      align-items: center;
      position: sticky;
      top: 0;
      z-index: 5;
    }

    .topbar-crumb {
      font-size: 14px;
      color: var(--text-muted);
    }

    .topbar-crumb a {
      color: var(--text-muted);
      text-decoration: none;
    }

    .topbar-crumb a:hover { color: var(--maroon); }
    .topbar-crumb .current { color: var(--maroon); font-weight: 500; }

    /* Page body */
    .page-body {
      padding: 36px 40px;
      max-width: 820px;
    }

    .page-header { margin-bottom: 28px; }

    .page-header h1 {
      font-size: 22px;
      font-weight: 700;
      color: var(--text);
      margin-bottom: 4px;
    }

    .page-header p { font-size: 14px; color: var(--text-muted); }

    /* Announcement card */
    .ann-card {
      background: var(--white);
      border: 1px solid var(--border);
      border-left: 4px solid var(--maroon);
      border-radius: 12px;
      padding: 20px 24px;
      margin-bottom: 14px;
      box-shadow: 0 1px 4px rgba(128,0,0,0.04);
      animation: fadeUp .3s ease both;
    }

    @keyframes fadeUp {
      from { opacity: 0; transform: translateY(8px); }
      to   { opacity: 1; transform: translateY(0); }
    }

    .ann-card:nth-child(1) { animation-delay: .04s; }
    .ann-card:nth-child(2) { animation-delay: .10s; }
    .ann-card:nth-child(3) { animation-delay: .16s; }
    .ann-card:nth-child(4) { animation-delay: .22s; }
    .ann-card:nth-child(5) { animation-delay: .28s; }

    .ann-card-header {
      display: flex;
      align-items: flex-start;
      justify-content: space-between;
      gap: 12px;
      margin-bottom: 10px;
    }

    .ann-title {
      font-size: 16px;
      font-weight: 600;
      color: var(--text);
      line-height: 2;
      margin-bottom: 3px;
    }

    .ann-meta { font-size: 14px; color: var(--text-muted); }
    .ann-meta strong { color: var(--text-sub); font-weight: 500; }

    .ann-badge {
      background: var(--maroon-pale);
      color: var(--maroon);
      border: 1px solid var(--maroon-border);
      border-radius: 6px;
      padding: 4px 10px;
      font-size: 12px;
      font-weight: 500;
      white-space: nowrap;
      flex-shrink: 0;
    }

    .ann-body {
      font-size: 14px;
      color: #555;
      line-height: 1.75;
    }

    /* Empty state */
    .empty-state {
      background: var(--maroon-pale);
      border: 1px solid var(--maroon-border);
      border-radius: 12px;
      padding: 24px;
      font-size: 14px;
      color: var(--maroon);
    }


    @media (max-width: 900px) {
      nav { width: 70px; }
      .logo-text, .nav-links a span, .logout-link span { display: none; }
      .main-content { margin-left: 70px; }
      .page-body { padding: 24px 20px; }
    }
  </style>
</head>
<body>
<div class="page">

  <!-- ── SIDEBAR ── -->
  <nav>
    <div class="sidebar-logo">
      <div class="logo-icon">
        <svg width="18" height="18" viewBox="0 0 24 24" fill="none">
          <path d="M12 14l9-5-9-5-9 5 9 5z" stroke="white" stroke-width="1.8" stroke-linejoin="round"/>
          <path d="M12 14l6.16-3.422a12.083 12.083 0 01.665 6.479A11.952 11.952 0 0112 20.055a11.952 11.952 0 01-6.824-2.998 12.078 12.078 0 01.665-6.479L12 14z" stroke="white" stroke-width="1.8" stroke-linejoin="round"/>
        </svg>
      </div>
      <div class="logo-text">
        <div class="abbr">SIMS</div>
        <div class="sub">Student Portal</div>
      </div>
    </div>

    <ul class="nav-links">
      <li>
        <a href="dashboard.php">
          <svg width="15" height="25" viewBox="0 0 24 24" fill="none" stroke-width="1.8"><rect x="3" y="3" width="7" height="7" rx="1.5"/><rect x="14" y="3" width="7" height="7" rx="1.5"/><rect x="3" y="14" width="7" height="7" rx="1.5"/><rect x="14" y="14" width="7" height="7" rx="1.5"/></svg>
          <span>Dashboard</span>
        </a>
      </li>
      <li>
        <a href="announcements.php" class="active">
          <svg width="15" height="25" viewBox="0 0 24 24" fill="none" stroke-width="1.8" stroke-linecap="round"><path d="M22 12h-4M6 8H4a2 2 0 00-2 2v4a2 2 0 002 2h2M18 8l-12 4M18 16l-12-4"/><path d="M6 8v8"/></svg>
          <span>Announcements</span>
        </a>
      </li>
      <li>
        <a href="subjects.php">
          <svg width="15" height="25" viewBox="0 0 24 24" fill="none" stroke-width="1.8" stroke-linecap="round"><path d="M4 19.5A2.5 2.5 0 016.5 17H20"/><path d="M6.5 2H20v20H6.5A2.5 2.5 0 014 19.5v-15A2.5 2.5 0 016.5 2z"/></svg>
          <span>Enrolled Subjects</span>
        </a>
      </li>
      <li>
        <a href="balance.php">
          <svg width="15" height="25" viewBox="0 0 24 24" fill="none" stroke-width="1.8" stroke-linecap="round"><path d="M20 7H4a2 2 0 00-2 2v10a2 2 0 002 2h16a2 2 0 002-2V9a2 2 0 00-2-2z"/><path d="M16 13h.01"/><path d="M16 3l-4 4-4-4"/></svg>
          <span>View Balance</span>
        </a>
      </li>
      <li>
        <a href="grades.php">
          <svg width="15" height="25" viewBox="0 0 24 24" fill="none" stroke-width="1.8" stroke-linecap="round"><path d="M14 2H6a2 2 0 00-2 2v16a2 2 0 002 2h12a2 2 0 002-2V8z"/><path d="M14 2v6h6M16 13H8M16 17H8M10 9H8"/></svg>
          <span>View Grades</span>
        </a>
      </li>
    </ul>

    <div class="sidebar-bottom">
      <a href="logout.php" class="logout-link">
        <svg width="15" height="25" viewBox="0 0 24 24" fill="none" stroke-width="1.8" stroke-linecap="round" stroke-linejoin="round"><path d="M9 21H5a2 2 0 01-2-2V5a2 2 0 012-2h4"/><polyline points="16 17 21 12 16 7"/><line x1="21" y1="12" x2="9" y2="12"/></svg>
        <span>Logout</span>
      </a>
    </div>
  </nav>

  <!-- ── MAIN ── -->
  <div class="main-content">

    <!-- Breadcrumb topbar -->
    <div class="topbar">
      <div class="topbar-crumb">
        <a href="dashboard.php">Dashboard</a>
        &nbsp;›&nbsp;
        <span class="current">Announcements</span>
      </div>
    </div>

    <!-- Page content -->
    <div class="page-body">
      <div class="page-header">
        <h1>Announcements</h1>
        <p>Stay updated with important notices from the school.</p>
      </div>

      <?php if ($result && $result->num_rows > 0): ?>
        <?php while ($row = $result->fetch_assoc()): ?>

<?php
$announcement_id = $row['announcement_id'];
$isRead = in_array($announcement_id, $read_ids);
?>

<a class="ann-card"
   href="announcement_view.php?id=<?php echo $announcement_id; ?>"
   style="text-decoration:none; display:block;
   border-left: 4px solid <?php echo $isRead ? '#ccc' : '#800000'; ?>;">

  <div class="ann-card-header">
    <div>
      <div class="ann-title">
        <?php echo htmlspecialchars($row['title']); ?>
      </div>

      <div class="ann-meta">
        Posted by:
        <strong><?php echo htmlspecialchars($row['posted_by'] ?? 'Unknown'); ?></strong>
      </div>
    </div>

    <span class="ann-badge">
      <?php echo date('M j, Y', strtotime($row['date_posted'])); ?>
    </span>
  </div>

  <div class="ann-body" style="white-space: pre-line;">
    <?php echo nl2br(htmlspecialchars($row['content'])); ?>
  </div>

</a>

<?php endwhile; ?>
      <?php else: ?>
        <div class="empty-state">No announcements available at this time.</div>
      <?php endif; ?>

     

  </div>
</div>
</body>
</html>