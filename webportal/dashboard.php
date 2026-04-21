<?php
require_once 'config.php';

if (!isset($_SESSION['user_id']) || $_SESSION['role'] !== 'student') {
    header("Location: login.php");
    exit;
}

$username   = $_SESSION['username'] ?? 'Student';
$student_id = $_SESSION['student_id'] ?? '';  //
$course     = $_SESSION['course'] ?? '';
$year_level = $_SESSION['year_level'] ?? '';
$user_id    = $_SESSION['user_id'];           

// ── STATS QUERIES ──
// 1. Enrolled Units
$uStmt = $conn->prepare("
    SELECT COALESCE(SUM(sub.units), 0) AS total_units
    FROM students s
    JOIN enrollments e ON s.student_id = e.student_id
    JOIN enrollment_details ed ON e.enrollment_id = ed.enrollment_id
    JOIN schedules sc ON ed.schedule_id = sc.schedule_id
    JOIN subjects sub ON sc.subject_id = sub.subject_id
    WHERE s.user_id = ? AND e.status = 'enrolled'
");
$uStmt->bind_param("i", $user_id);
$uStmt->execute();
$units = $uStmt->get_result()->fetch_assoc()['total_units'] ?? 0;
$uStmt->close();

// 2. Outstanding Balance
$bStmt = $conn->prepare("
    SELECT COALESCE(SUM(b.balance), 0) AS total_balance
    FROM students s
    JOIN enrollments e ON s.student_id = e.student_id
    JOIN billing b ON e.enrollment_id = b.enrollment_id
    WHERE s.user_id = ?
");
$bStmt->bind_param("i", $user_id);
$bStmt->execute();
$balRow = $bStmt->get_result()->fetch_assoc();
$balance = '₱' . number_format($balRow['total_balance'] ?? 0, 2);
$bStmt->close();

// 3. GWA
$gStmt = $conn->prepare("
    SELECT ROUND(AVG(g.grade_value), 2) AS gwa
    FROM students s
    JOIN enrollments e ON s.student_id = e.student_id
    JOIN grades g ON e.enrollment_id = g.enrollment_id
    WHERE s.user_id = ?
");
$gStmt->bind_param("i", $user_id);
$gStmt->execute();
$gwaRow = $gStmt->get_result()->fetch_assoc();
$gwa = $gwaRow['gwa'] ?? '—';
$gStmt->close();

// 4. Unread Announcements
$uqStmt = $conn->prepare("
    SELECT COUNT(*) as unread_count
    FROM announcements a
    WHERE a.announcement_id NOT IN (
        SELECT ar.announcement_id
        FROM announcement_reads ar
        JOIN students s ON ar.student_id = s.student_id
        WHERE s.user_id = ?
    )
");
$uqStmt->bind_param("i", $user_id);
$uqStmt->execute();
$unread = $uqStmt->get_result()->fetch_assoc()['unread_count'] ?? 0;
$uqStmt->close();
?>
<!DOCTYPE html>
<html lang="en">
<head>
  <meta charset="UTF-8">
  <meta name="viewport" content="width=device-width, initial-scale=1.0">
  <title>Dashboard — SIMS Portal</title>
  <link rel="preconnect" href="https://fonts.googleapis.com">
  <link rel="preconnect" href="https://fonts.gstatic.com" crossorigin>
  <link href="https://fonts.googleapis.com/css2?family=Inter:wght@400;500;600;700&display=swap" rel="stylesheet">
  <style>
    *, *::before, *::after { box-sizing: border-box; margin: 0; padding: 0; }

    :root {
      --maroon:       #800000;
      --maroon-hover: #a00000;
      --maroon-pale:  #fdf0f0;
      --maroon-border:#f0dede;
      --bg:           #f9f5f5;
      --white:        #ffffff;
      --border:       #f0e8e8;
      --text:         #1a1a1a;
      --text-sub:     #888;
      --text-muted:   #bbb;
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
      padding: 24px 24px 22px;
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

    .logo-text .full { font-size: 14px; color: var(--text-muted); margin-top: 1px; }

    /* Student chip */
    .student-chip {
      margin: 14px 16px;
      background: var(--maroon-pale);
      border: 1px solid var(--maroon-border);
      border-radius: 10px;
      padding: 10px 12px;
    }

    .student-chip .name  { font-size: 13px; font-weight: 600; color: var(--text); }
    .student-chip .id    { font-size: 12px; color: var(--text-sub); margin-top: 2px; }
    .student-chip .extra { font-size: 12px; color: var(--text-muted); margin-top: 4px; }

    /* Nav links */
    .nav-links { list-style: none; padding: 12px 12px; flex: 1; }
    .nav-links li { margin-bottom: 2px; }

    .nav-links a {
      display: flex; align-items: center; gap: 10px;
      padding: 10px 12px; border-radius: 8px;
      text-decoration: none; color: #555; font-weight: 400; font-size: 14px;
      transition: background .15s, color .15s;
    }

    .nav-links a:hover { background: var(--maroon-pale); color: var(--maroon); }
    .nav-links a:hover svg { stroke: var(--maroon); }
    .nav-links a.active  { background: var(--maroon-pale); color: var(--maroon); font-weight: 600; }
    .nav-links a.active svg { stroke: var(--maroon); }
    .nav-links a svg { stroke: #ccc; transition: stroke .15s; }

    .sidebar-bottom {
      padding: 12px 12px 16px;
      border-top: 1px solid #f5eded;
    }

    .logout-link {
      display: flex; align-items: center; gap: 10px;
      padding: 10px 12px; border-radius: 8px;
      text-decoration: none; color: #cc3333; font-size: 13.5px; font-weight: 500;
      transition: background .15s;
    }

    .logout-link:hover { background: #fff5f5; }
    .logout-link svg { stroke: #cc3333; }

    /* ── MAIN ── */
    main {
      margin-left: 240px;
      flex: 1;
      padding: 36px 40px;
      overflow-y: auto;
    }

    /* Welcome banner */
    .welcome-banner {
      background: var(--maroon);
      border-radius: 16px;
      padding: 28px 32px;
      margin-bottom: 24px;
      position: relative;
      overflow: hidden;
    }

    .welcome-banner::before {
      content: '';
      position: absolute;
      right: -30px; top: -40px;
      width: 180px; height: 180px;
      border-radius: 50%;
      background: rgba(255,255,255,0.05);
    }

    .welcome-banner::after {
      content: '';
      position: absolute;
      right: 70px; bottom: -55px;
      width: 130px; height: 130px;
      border-radius: 50%;
      background: rgba(255,255,255,0.04);
    }

    .welcome-banner .eyebrow {
      font-size: 16px; color: rgba(255,255,255,0.5);
      letter-spacing: .04em; margin-bottom: 5px;
      position: relative; z-index: 1;
    }

    .welcome-banner h1 {
      font-size: 26px; font-weight: 700; color: #fff;
      margin-bottom: 2px;
      position: relative; z-index: 1;
    }

    .welcome-banner .meta {
      font-size: 14px; color: rgba(255,255,255,0.55);
      position: relative; z-index: 1;
    }

    /* Stats grid */
    .stats-grid {
      display: grid;
      grid-template-columns: repeat(4, 1fr);
      gap: 16px;
      margin-bottom: 24px;
    }

    .stat-card {
      background: var(--white);
      border: 1px solid var(--border);
      border-radius: 12px;
      padding: 20px 20px 16px;
    }

    .stat-card .value { font-size: 22px; font-weight: 700; color: var(--maroon); margin-bottom: 4px; }
    .stat-card .label { font-size: 14px; font-weight: 600; color: #333; margin-bottom: 2px; }
    .stat-card .sub   { font-size: 12px; color: var(--text-muted); }

    /* Bottom row */
    .bottom-grid {
      display: grid;
      grid-template-columns: 1fr 280px;
      gap: 20px;
    }

    /* Announcements panel */
    .announcements-panel {
      background: var(--white);
      border: 1px solid var(--border);
      border-radius: 14px;
      overflow: hidden;
    }

    .panel-header {
      display: flex; align-items: center; justify-content: space-between;
      padding: 18px 22px;
      border-bottom: 1px solid #f5eded;
    }

    .panel-header .title { font-weight: 600; font-size: 16px; }
    .panel-header a { font-size: 14px; color: var(--maroon); font-weight: 500; text-decoration: none; }
    .panel-header a:hover { text-decoration: underline; }

    .announcement-item {
      display: flex; align-items: flex-start; gap: 14px;
      padding: 14px 22px;
      border-bottom: 1px solid #fdf8f8;
    }

    .announcement-item:last-child { border-bottom: none; }

    .ann-icon {
      width: 38px; height: 38px; border-radius: 10px;
      background: var(--maroon-pale);
      display: flex; align-items: center; justify-content: center;
      font-size: 16px; flex-shrink: 0;
    }

    .ann-title { font-size: 13.5px; font-weight: 500; color: #222; margin-bottom: 5px; }

    .ann-meta { display: flex; align-items: center; gap: 8px; }

    .ann-tag {
      font-size: 12px; font-weight: 600; letter-spacing: .06em;
      color: var(--maroon); background: var(--maroon-pale);
      border: 1px solid var(--maroon-border);
      border-radius: 4px; padding: 2px 7px; text-transform: uppercase;
    }

    .ann-date { font-size: 12px; color: var(--text-muted); }

    /* Quick links */
    .quick-links { display: flex; flex-direction: column; gap: 12px; }

    .quick-link {
      display: flex; align-items: center; gap: 12px;
      background: var(--white);
      border: 1px solid var(--border);
      border-radius: 12px;
      padding: 14px 16px;
      text-decoration: none;
      transition: border-color .15s, box-shadow .15s;
    }

    .quick-link:hover { border-color: var(--maroon); box-shadow: 0 2px 12px rgba(128,0,0,0.08); }

    .quick-link-icon {
      width: 36px; height: 36px; border-radius: 9px;
      background: var(--maroon-pale);
      display: flex; align-items: center; justify-content: center;
      flex-shrink: 0;
    }

    .quick-link-icon svg { stroke: var(--maroon); }

    .quick-link-label { font-size: 14px; font-weight: 500; color: #333; flex: 1; }
    .quick-link-arrow { color: #ddd; font-size: 18px; line-height: 1; }

    @media (max-width: 900px) {
      nav { width: 70px; }
      .logo-text, .student-chip, .nav-links a span { display: none; }
      main { margin-left: 70px; }
      .stats-grid { grid-template-columns: repeat(2, 1fr); }
      .bottom-grid { grid-template-columns: 1fr; }
      .quick-links { display: none; }
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
        <div class="full">Student Portal</div>
      </div>
    </div>

    <?php if (!empty($student_id) || !empty($course)): ?>
    <div class="student-chip">
      <div class="name"><?php echo htmlspecialchars($username); ?></div>
      <?php if (!empty($student_id)): ?><div class="id"><?php echo htmlspecialchars($student_id); ?></div><?php endif; ?>
      <?php if (!empty($year_level) || !empty($course)): ?>
        <div class="extra"><?php echo htmlspecialchars(trim($year_level . ($year_level && $course ? ' · ' : '') . $course)); ?></div>
      <?php endif; ?>
    </div>
    <?php endif; ?>

    <ul class="nav-links">
      <li>
        <a href="dashboard.php" class="active">
          <svg width="15" height="15" viewBox="0 0 24 24" fill="none" stroke-width="1.8"><rect x="3" y="3" width="7" height="7" rx="1.5"/><rect x="14" y="3" width="7" height="7" rx="1.5"/><rect x="3" y="14" width="7" height="7" rx="1.5"/><rect x="14" y="14" width="7" height="7" rx="1.5"/></svg>
          <span>Dashboard</span>
        </a>
      </li>
      <li>
        <a href="announcements.php">
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
  <main>

    <!-- Welcome banner -->
    <div class="welcome-banner">
      <p class="eyebrow">Welcome back,</p>
      <h1><?php echo htmlspecialchars($username); ?> 👋</h1>
      <p class="meta">
        <?php
		$meta = array_filter([$course, $year_level, $student_id]);
          echo htmlspecialchars(implode(' · ', $meta));
        ?>
      </p>
    </div>

    <!-- Stats grid -->
    <div class="stats-grid">
      <div class="stat-card">
        <div class="value"><?php echo $units; ?></div>
        <div class="label">Enrolled Units</div>
        <div class="sub">this semester</div>
      </div>
      <div class="stat-card">
        <div class="value"><?php echo $balance; ?></div>
        <div class="label">Outstanding Balance</div>
        <div class="sub">as of today</div>
      </div>
      <div class="stat-card">
        <div class="value"><?php echo $gwa; ?></div>
        <div class="label">GWA</div>
        <div class="sub">last semester</div>
      </div>
      <div class="stat-card">
        <div class="value"><?php echo $unread; ?></div>
        <div class="label">Unread Notices</div>
        <div class="sub">new announcements</div>
      </div>
    </div>

    <!-- Bottom row -->
    <div class="bottom-grid">

      <!-- Announcements preview -->
      <div class="announcements-panel">
        <div class="panel-header">
          <span class="title">Recent Announcements</span>
          <a href="announcements.php">View all</a>
        </div>

        <?php
        $ann_stmt = $conn->prepare("
            SELECT title, category, date_posted
            FROM announcements
            ORDER BY date_posted DESC
            LIMIT 3
        ");
        $ann_stmt->execute();
        $announcements = $ann_stmt->get_result()->fetch_all(MYSQLI_ASSOC);
        $ann_stmt->close();

        if (empty($announcements)):
        ?>
          <div style="padding: 32px 22px; text-align: center; color: #bbb; font-size: 13px;">
            No announcements yet.
          </div>
        <?php else: ?>
          <?php foreach ($announcements as $ann): ?>
            <div class="announcement-item">
              <div class="ann-icon">📢</div>
              <div>
                <div class="ann-title"><?php echo htmlspecialchars($ann['title']); ?></div>
                <div class="ann-meta">
                  <?php if (!empty($ann['category'])): ?>
                    <span class="ann-tag"><?php echo htmlspecialchars($ann['category']); ?></span>
                  <?php endif; ?>
                  <span class="ann-date"><?php echo date('M j, Y', strtotime($ann['date_posted'])); ?></span>
                </div>
              </div>
            </div>
          <?php endforeach; ?>
        <?php endif; ?>
      </div>

    </div>
  </main>

</div>
</body>
</html>	