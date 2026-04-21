<?php
require_once 'config.php';

if (!isset($_SESSION['user_id'])) {
    header("Location: login.php");
    exit;
}

$student_id      = $_SESSION['student_id'] ?? '';
$announcement_id = (int) ($_GET['id'] ?? 0);

if ($announcement_id === 0) {
    header("Location: announcements.php");
    exit;
}

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
$ann    = $result->fetch_assoc();

if (!$ann) {
    header("Location: announcements.php");
    exit;
}
?>
<!DOCTYPE html>
<html lang="en">
<head>
  <meta charset="UTF-8">
  <meta name="viewport" content="width=device-width, initial-scale=1.0">
  <title><?php echo htmlspecialchars($ann['title']); ?> — SIMS Portal</title>
  <link rel="preconnect" href="https://fonts.googleapis.com">
  <link rel="preconnect" href="https://fonts.gstatic.com" crossorigin>
  <link href="https://fonts.googleapis.com/css2?family=Inter:wght@400;500;600;700&display=swap" rel="stylesheet">
  <style>
    *, *::before, *::after { box-sizing: border-box; margin: 0; padding: 0; }

    :root {
      --maroon:        #800000;
      --maroon-dark:   #5a0000;
      --maroon-pale:   #fdf0f0;
      --maroon-border: #f0dede;
      --bg:            #f9f5f5;
      --white:         #ffffff;
      --border:        #f0e8e8;
      --text:          #1a1a1a;
      --text-sub:      #333;
      --text-muted:    #aaa;
    }

    html, body { min-height: 100%; font-family: 'Inter', sans-serif; background: var(--bg); color: var(--text); }

    .page { display: flex; min-height: 100vh; }

    /* ── SIDEBAR ── */
    nav {
      width: 240px; background: var(--white);
      border-right: 1px solid var(--border);
      display: flex; flex-direction: column;
      position: fixed; height: 100vh; z-index: 10;
    }

    .sidebar-logo {
      display: flex; align-items: center; gap: 10px;
      padding: 24px 24px 20px; border-bottom: 1px solid #f5eded;
    }

    .logo-icon {
      width: 40px; height: 40px; background: var(--maroon);
      border-radius: 10px; display: flex; align-items: center; justify-content: center;
      flex-shrink: 0;
    }

    .logo-icon svg { display: block; }
    .logo-abbr { font-size: 14px; font-weight: 700; color: var(--maroon); letter-spacing: .1em; text-transform: uppercase; }
    .logo-sub  { font-size: 12px; color: var(--text-muted); margin-top: 1px; }

    .nav-links { list-style: none; padding: 14px 12px; flex: 1; }
    .nav-links li { margin-bottom: 2px; }

    .nav-links a {
      display: flex; align-items: center; gap: 10px;
      padding: 10px 12px; border-radius: 8px;
      text-decoration: none; color: #555;
      font-size: 14px; font-weight: 400;
      transition: background .15s, color .15s;
    }
    .nav-links a svg { stroke: #ccc; transition: stroke .15s; }
    .nav-links a:hover     { background: var(--maroon-pale); color: var(--maroon); }
    .nav-links a:hover svg { stroke: var(--maroon); }
    .nav-links a.active    { background: var(--maroon-pale); color: var(--maroon); font-weight: 600; }
    .nav-links a.active svg{ stroke: var(--maroon); }

    .sidebar-bottom { padding: 12px 12px 16px; border-top: 1px solid #f5eded; }
    .logout-link {
      display: flex; align-items: center; gap: 10px;
      padding: 10px 12px; border-radius: 8px;
      text-decoration: none; color: #cc3333; font-size: 14px; font-weight: 500;
      transition: background .15s;
    }
    .logout-link:hover { background: #fff5f5; }
    .logout-link svg { stroke: #cc3333; }

    /* ── MAIN ── */
    .main-content { margin-left: 240px; flex: 1; display: flex; flex-direction: column; }

    .topbar {
      background: var(--white); border-bottom: 1px solid var(--border);
      padding: 13px 40px; display: flex; align-items: center;
      position: sticky; top: 0; z-index: 5;
    }

    .topbar-crumb { font-size: 14px; color: var(--text-muted); }
    .topbar-crumb a { color: var(--text-muted); text-decoration: none; }
    .topbar-crumb a:hover { color: var(--maroon); }
    .topbar-crumb .current { color: var(--maroon); font-weight: 500; }

    .page-body { padding: 36px 40px; max-width: 820px; }

    /* ── BACK BUTTON ── */
    .btn-back {
      display: inline-flex; align-items: center; gap: 6px;
      padding: 8px 16px; border-radius: 8px;
      font-size: 14px; font-weight: 500; text-decoration: none;
      color: var(--maroon); background: var(--maroon-pale);
      border: 1px solid var(--maroon-border); transition: background .15s;
      margin-bottom: 24px;
    }
    .btn-back:hover { background: #f9e0e0; }

    .btn-back-bottom { margin-top: 20px; margin-bottom: 0; }

    /* ── ARTICLE CARD ── */
    .article-card {
      background: var(--white);
      border: 1px solid var(--border);
      border-radius: 16px; overflow: hidden;
      box-shadow: 0 2px 12px rgba(128,0,0,0.06);
      animation: fadeUp .35s ease both;
    }

    @keyframes fadeUp {
      from { opacity: 0; transform: translateY(10px); }
      to   { opacity: 1; transform: translateY(0); }
    }

    /* Maroon hero header */
    .article-hero {
      background: linear-gradient(135deg, var(--maroon) 0%, var(--maroon-dark) 100%);
      padding: 32px 36px;
      position: relative;
      overflow: hidden;
    }

    .article-hero::before {
      content: '';
      position: absolute;
      top: -30px; right: -30px;
      width: 120px; height: 120px;
      border-radius: 50%;
      background: rgba(255,255,255,0.05);
    }

    .article-hero::after {
      content: '';
      position: absolute;
      bottom: -20px; right: 60px;
      width: 80px; height: 80px;
      border-radius: 50%;
      background: rgba(255,255,255,0.04);
    }

    .ann-type-badge {
      display: inline-flex; align-items: center; gap: 6px;
      background: rgba(255,255,255,0.12);
      border-radius: 999px; padding: 4px 12px;
      font-size: 12px; font-weight: 600;
      color: rgba(255,255,255,0.85);
      margin-bottom: 14px;
      letter-spacing: .04em;
      position: relative; z-index: 1;
    }

    .article-title {
      font-size: 24px; font-weight: 700;
      color: #fff; line-height: 1.4;
      position: relative; z-index: 1;
    }

    /* Meta strip */
    .article-meta {
      display: flex; align-items: center; gap: 20;
      padding: 14px 36px;
      border-bottom: 1px solid #f5eded;
      background: #fffafa;
      gap: 20px;
    }

    .meta-item {
      display: flex; align-items: center; gap: 8px;
    }

    .meta-avatar {
      width: 30px; height: 30px; border-radius: 50%;
      background: var(--maroon-pale);
      border: 1px solid var(--maroon-border);
      display: flex; align-items: center; justify-content: center;
      flex-shrink: 0;
    }

    .meta-label { font-size: 12px; color: var(--text-muted); font-weight: 500; }
    .meta-value { font-size: 14px; font-weight: 600; color: var(--maroon); }

    .meta-divider { width: 1px; height: 32px; background: var(--maroon-border); }

    .read-badge {
      margin-left: auto;
      background: var(--maroon-pale); color: var(--maroon);
      border: 1px solid var(--maroon-border);
      border-radius: 999px; padding: 4px 12px;
      font-size: 12px; font-weight: 600;
    }

    /* Content body */
    .article-body {
      padding: 30px 36px 36px;
    }

    .article-content {
      font-size: 16px;
      color: var(--text-sub);
      line-height: 1.85;
      white-space: pre-wrap;
    }

    @media (max-width: 900px) {
      nav { width: 70px; }
      .logo-abbr, .logo-sub, .nav-links a span, .logout-link span { display: none; }
      .main-content { margin-left: 70px; }
      .page-body { padding: 24px 20px; }
      .article-hero, .article-meta, .article-body { padding-left: 22px; padding-right: 22px; }
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
      <div>
        <div class="logo-abbr">SIMS</div>
        <div class="logo-sub">Student Portal</div>
      </div>
    </div>

    <ul class="nav-links">
      <li>
        <a href="dashboard.php">
          <svg width="15" height="15" viewBox="0 0 24 24" fill="none" stroke-width="1.8"><rect x="3" y="3" width="7" height="7" rx="1.5"/><rect x="14" y="3" width="7" height="7" rx="1.5"/><rect x="3" y="14" width="7" height="7" rx="1.5"/><rect x="14" y="14" width="7" height="7" rx="1.5"/></svg>
          <span>Dashboard</span>
        </a>
      </li>
      <li>
        <a href="announcements.php" class="active">
          <svg width="15" height="15" viewBox="0 0 24 24" fill="none" stroke-width="1.8" stroke-linecap="round"><path d="M22 12h-4M6 8H4a2 2 0 00-2 2v4a2 2 0 002 2h2M18 8l-12 4M18 16l-12-4"/><path d="M6 8v8"/></svg>
          <span>Announcements</span>
        </a>
      </li>
      <li>
        <a href="subjects.php">
          <svg width="15" height="15" viewBox="0 0 24 24" fill="none" stroke-width="1.8" stroke-linecap="round"><path d="M4 19.5A2.5 2.5 0 016.5 17H20"/><path d="M6.5 2H20v20H6.5A2.5 2.5 0 014 19.5v-15A2.5 2.5 0 016.5 2z"/></svg>
          <span>Enrolled Subjects</span>
        </a>
      </li>
      <li>
        <a href="balance.php">
          <svg width="15" height="15" viewBox="0 0 24 24" fill="none" stroke-width="1.8" stroke-linecap="round"><path d="M20 7H4a2 2 0 00-2 2v10a2 2 0 002 2h16a2 2 0 002-2V9a2 2 0 00-2-2z"/><path d="M16 13h.01"/><path d="M16 3l-4 4-4-4"/></svg>
          <span>View Balance</span>
        </a>
      </li>
      <li>
        <a href="grades.php">
          <svg width="15" height="15" viewBox="0 0 24 24" fill="none" stroke-width="1.8" stroke-linecap="round"><path d="M14 2H6a2 2 0 00-2 2v16a2 2 0 002 2h12a2 2 0 002-2V8z"/><path d="M14 2v6h6M16 13H8M16 17H8M10 9H8"/></svg>
          <span>View Grades</span>
        </a>
      </li>
    </ul>

    <div class="sidebar-bottom">
      <a href="logout.php" class="logout-link">
        <svg width="15" height="15" viewBox="0 0 24 24" fill="none" stroke-width="1.8" stroke-linecap="round" stroke-linejoin="round"><path d="M9 21H5a2 2 0 01-2-2V5a2 2 0 012-2h4"/><polyline points="16 17 21 12 16 7"/><line x1="21" y1="12" x2="9" y2="12"/></svg>
        <span>Logout</span>
      </a>
    </div>
  </nav>

  <!-- ── MAIN ── -->
  <div class="main-content">

    <div class="topbar">
      <div class="topbar-crumb">
        <a href="dashboard.php">Dashboard</a>
        &nbsp;›&nbsp;
        <a href="announcements.php">Announcements</a>
        &nbsp;›&nbsp;
        <span class="current">View</span>
      </div>
    </div>

    <div class="page-body">

     

      <div class="article-card">

        <!-- Maroon hero -->
        <div class="article-hero">
          <div class="ann-type-badge">
            <svg width="11" height="11" viewBox="0 0 24 24" fill="none" stroke="white" stroke-width="2" stroke-linecap="round"><path d="M22 12h-4M6 8H4a2 2 0 00-2 2v4a2 2 0 002 2h2M18 8l-12 4M18 16l-12-4"/><path d="M6 8v8"/></svg>
            Announcement
          </div>
          <h1 class="article-title"><?php echo htmlspecialchars($ann['title']); ?></h1>
        </div>

        <!-- Meta strip -->
        <div class="article-meta">
          <div class="meta-item">
            <div class="meta-avatar">
              <svg width="13" height="13" viewBox="0 0 24 24" fill="none">
                <circle cx="12" cy="8" r="4" stroke="#800000" stroke-width="1.8"/>
                <path d="M4 20c0-4 3.6-7 8-7s8 3 8 7" stroke="#800000" stroke-width="1.8" stroke-linecap="round"/>
              </svg>
            </div>
            <div>
              <div class="meta-label">Posted by</div>
              <div class="meta-value"><?php echo htmlspecialchars($ann['posted_by'] ?? 'Unknown'); ?></div>
            </div>
          </div>

          <div class="meta-divider"></div>

          <div class="meta-item">
            <div class="meta-avatar">
              <svg width="13" height="13" viewBox="0 0 24 24" fill="none">
                <rect x="3" y="4" width="18" height="18" rx="2" stroke="#800000" stroke-width="1.8"/>
                <path d="M16 2v4M8 2v4M3 10h18" stroke="#800000" stroke-width="1.8" stroke-linecap="round"/>
              </svg>
            </div>
            <div>
              <div class="meta-label">Date Posted</div>
              <div class="meta-value"><?php echo htmlspecialchars($ann['date_posted']); ?></div>
            </div>
          </div>

          <span class="read-badge">✓ Read</span>
        </div>

        <!-- Content -->
        <div class="article-body">
          <div class="article-content">
            <?php echo nl2br(htmlspecialchars($ann['content'])); ?>
          </div>
        </div>

      </div>

      <a href="announcements.php" class="btn-back btn-back-bottom">← Back to Announcements</a>

    </div>
  </div>
</div>
</body>
</html>
