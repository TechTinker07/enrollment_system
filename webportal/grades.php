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

/* Collect rows & compute GWA */
$rows        = [];
$grade_sum   = 0;
$grade_count = 0;

if ($result && $result->num_rows > 0) {
    while ($row = $result->fetch_assoc()) {
        $rows[] = $row;
        if (is_numeric($row['grade_value'])) {
            $grade_sum  += (float) $row['grade_value'];
            $grade_count++;
        }
    }
}

$gwa = ($grade_count > 0) ? number_format($grade_sum / $grade_count, 2) : null;

if ($gwa !== null) {
    $gwa_float = (float) $gwa;
    if ($gwa_float <= 1.5)      { $gwa_label = "With Honors";       $gwa_class = "standing-honors"; }
    elseif ($gwa_float <= 3.0)  { $gwa_label = "Passing";            $gwa_class = "standing-pass";   }
    else                        { $gwa_label = "Needs Attention";    $gwa_class = "standing-fail";   }
}
?>
<!DOCTYPE html>
<html lang="en">
<head>
  <meta charset="UTF-8">
  <meta name="viewport" content="width=device-width, initial-scale=1.0">
  <title>My Grades — SIMS Portal</title>
  <link rel="preconnect" href="https://fonts.googleapis.com">
  <link rel="preconnect" href="https://fonts.gstatic.com" crossorigin>
  <link href="https://fonts.googleapis.com/css2?family=Inter:wght@400;500;600;700;800&display=swap" rel="stylesheet">
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
      --green:         #166534;
      --green-bg:      #f0fdf4;
      --green-border:  #bbf7d0;
      --red:           #c53030;
      --red-bg:        #fff5f5;
      --red-border:    #fca5a5;
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
      width: 36px; height: 36px; background: var(--maroon);
      border-radius: 10px; display: flex; align-items: center; justify-content: center;
      flex-shrink: 0;
    }

    .logo-icon svg { display: block; }
    .logo-abbr { font-size: 18px; font-weight: 700; color: var(--maroon); letter-spacing: .1em; text-transform: uppercase; }
    .logo-sub  { font-size: 14px; color: var(--text-muted); margin-top: 1px; }

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
    .nav-links a:hover  { background: var(--maroon-pale); color: var(--maroon); }
    .nav-links a:hover svg { stroke: var(--maroon); }
    .nav-links a.active { background: var(--maroon-pale); color: var(--maroon); font-weight: 600; }
    .nav-links a.active svg { stroke: var(--maroon); }

    .sidebar-bottom { padding: 12px 12px 16px; border-top: 1px solid #f5eded; }

    .logout-link {
      display: flex; align-items: center; gap: 10px;
      padding: 10px 12px; border-radius: 8px;
      text-decoration: none; color: #cc3333; font-size: 13.5px; font-weight: 500;
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

    .page-body { padding: 36px 40px; }

    .page-header { margin-bottom: 28px; }
    .page-header h1 { font-size: 22px; font-weight: 700; color: var(--text); margin-bottom: 4px; }
    .page-header p  { font-size: 14px; color: var(--text-muted); }

    /* ── GWA CARD ── */
    .gwa-card {
      border-radius: 14px; padding: 20px 28px;
      display: flex; align-items: center; justify-content: space-between;
      margin-bottom: 24px;
    }

    .standing-honors { background: var(--green-bg);   border: 1px solid var(--green-border); }
    .standing-pass   { background: var(--maroon-pale); border: 1px solid var(--maroon-border); }
    .standing-fail   { background: var(--red-bg);      border: 1px solid var(--red-border); }

    .gwa-left { display: flex; align-items: center; gap: 16px; }
    .gwa-emoji { font-size: 36px; }

    .gwa-label {
      font-size: 12px; font-weight: 700;
      text-transform: uppercase; letter-spacing: .06em; margin-bottom: 2px;
    }

    .gwa-value { font-size: 34px; font-weight: 800; line-height: 1; }

    .standing-honors .gwa-label,
    .standing-honors .gwa-value { color: var(--green); }

    .standing-pass .gwa-label,
    .standing-pass .gwa-value   { color: var(--maroon); }

    .standing-fail .gwa-label,
    .standing-fail .gwa-value   { color: var(--red); }

    .gwa-standing {
      background: #fff; border-radius: 10px; padding: 10px 20px; text-align: center;
    }

    .standing-honors .gwa-standing { border: 1px solid var(--green-border); }
    .standing-pass   .gwa-standing { border: 1px solid var(--maroon-border); }
    .standing-fail   .gwa-standing { border: 1px solid var(--red-border); }

    .standing-sub  { font-size: 12px; color: var(--text-muted); margin-bottom: 2px; }

    .standing-honors .standing-text { font-size: 14px; font-weight: 700; color: var(--green); }
    .standing-pass   .standing-text { font-size: 14px; font-weight: 700; color: var(--maroon); }
    .standing-fail   .standing-text { font-size: 14px; font-weight: 700; color: var(--red); }

    /* ── TABLE CARD ── */
    .table-card {
      background: var(--white);
      border: 1px solid var(--border);
      border-radius: 14px; overflow: hidden;
      box-shadow: 0 1px 6px rgba(128,0,0,0.05);
    }

    .table-card-header {
      padding: 16px 24px; border-bottom: 1px solid var(--border);
      display: flex; align-items: center; gap: 8px;
    }

    .table-card-header .title { font-size: 14px; font-weight: 600; color: var(--text); }
    .table-card-header .count { margin-left: auto; font-size: 12px; color: var(--text-muted); }

    .data-table { width: 100%; border-collapse: collapse; }
    .data-table thead tr { background: #fdf8f8; }

    .data-table th {
      padding: 12px 16px; text-align: left;
      font-size: 12px; font-weight: 700;
      color: var(--maroon); text-transform: uppercase; letter-spacing: .05em;
      border-bottom: 2px solid var(--maroon-border);
    }

    .data-table tbody tr { border-bottom: 1px solid #fdf0f0; }
    .data-table tbody tr:nth-child(even) { background: #fffafa; }

    .data-table td { padding: 14px 16px; font-size: 13.5px; color: var(--text-sub); vertical-align: middle; }

    .td-num   { font-size: 14px; color: var(--text-muted); font-weight: 500; }
    .td-code  { font-weight: 700; color: var(--maroon); font-family: monospace; font-size: 13px; }
    .td-title { color: var(--text); }

    .grade-wrap { display: flex; align-items: center; gap: 8px; }

    .grade-num   { font-size: 17px; font-weight: 800; }
    .grade-bar-track {
      width: 50px; height: 5px; border-radius: 99px;
      background: #f0e8e8; overflow: hidden;
    }
    .grade-bar-fill { height: 100%; border-radius: 99px; }

    .grade-honors { color: var(--green); }
    .grade-pass   { color: var(--maroon); }
    .grade-fail   { color: var(--red); }

    .bar-honors { background: #16a34a; }
    .bar-pass   { background: var(--maroon); }
    .bar-fail   { background: #dc2626; }

    /* Remarks badge */
    .badge {
      display: inline-block; border-radius: 999px;
      padding: 4px 12px; font-size: 12px; font-weight: 600;
    }
    .badge-passed-honors { background: var(--green-bg);   color: var(--green); border: 1px solid var(--green-border); }
    .badge-passed        { background: var(--maroon-pale); color: var(--maroon); border: 1px solid var(--maroon-border); }
    .badge-failed        { background: var(--red-bg);      color: var(--red);   border: 1px solid var(--red-border); }

    /* Empty state */
    .empty-state {
      background: var(--maroon-pale); border: 1px solid var(--maroon-border);
      border-radius: 12px; padding: 24px;
      font-size: 14px; color: var(--maroon);
    }

    /* Back */
    .btn-back {
      display: inline-flex; align-items: center; gap: 6px;
      margin-top: 20px; padding: 9px 18px; border-radius: 8px;
      font-size: 14px; font-weight: 500; text-decoration: none;
      color: var(--maroon); background: var(--maroon-pale);
      border: 1px solid var(--maroon-border); transition: background .15s;
    }
    .btn-back:hover { background: #f9e0e0; }

    @media (max-width: 900px) {
      nav { width: 70px; }
      .logo-abbr, .logo-sub, .nav-links a span, .logout-link span { display: none; }
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
      <div>
        <div class="logo-abbr">SIMS</div>
        <div class="logo-sub">Student Portal</div>
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
        <a href="grades.php" class="active">
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

    <div class="topbar">
      <div class="topbar-crumb">
        <a href="dashboard.php">Dashboard</a>
        &nbsp;›&nbsp;
        <span class="current">My Grades</span>
      </div>
    </div>

    <div class="page-body">

      <div class="page-header">
        <h1>My Grades</h1>
        <p>Academic performance for the current semester.</p>
      </div>

      <?php if (!empty($rows)): ?>

        <!-- ── GWA CARD ── -->
        <?php if ($gwa !== null): ?>
        <div class="gwa-card <?php echo $gwa_class; ?>">
          <div class="gwa-left">
            <div class="gwa-emoji">🎓</div>
            <div>
              <div class="gwa-label">General Weighted Average</div>
              <div class="gwa-value"><?php echo $gwa; ?></div>
            </div>
          </div>
          <div class="gwa-standing">
            <div class="standing-sub">Standing</div>
            <div class="standing-text"><?php echo $gwa_label; ?></div>
          </div>
        </div>
        <?php endif; ?>

        <!-- ── TABLE ── -->
        <div class="table-card">
          <div class="table-card-header">
            <svg width="15" height="15" viewBox="0 0 24 24" fill="none" stroke="#800000" stroke-width="1.8" stroke-linecap="round"><path d="M14 2H6a2 2 0 00-2 2v16a2 2 0 002 2h12a2 2 0 002-2V8z"/><path d="M14 2v6h6M16 13H8M16 17H8M10 9H8"/></svg>
            <span class="title">Grade Sheet</span>
            <span class="count"><?php echo count($rows); ?> subject<?php echo count($rows) !== 1 ? 's' : ''; ?></span>
          </div>

          <table class="data-table">
            <thead>
              <tr>
                <th>#</th>
                <th>Subject Code</th>
                <th>Subject Title</th>
                <th>Grade</th>
                <th>Remarks</th>
              </tr>
            </thead>
            <tbody>
              <?php foreach ($rows as $i => $row):
                $g          = is_numeric($row['grade_value']) ? (float) $row['grade_value'] : null;
                $isPassed   = strtolower(trim($row['remarks'])) === 'passed';
                $isHonors   = $g !== null && $g <= 1.5 && $isPassed;
                $barPct     = ($g !== null) ? max(0, min(100, (int) round((5 - $g) / 4 * 100))) : 0;

                if (!$isPassed)       { $gradeClass = 'grade-fail';   $barClass = 'bar-fail'; }
                elseif ($isHonors)    { $gradeClass = 'grade-honors'; $barClass = 'bar-honors'; }
                else                  { $gradeClass = 'grade-pass';   $barClass = 'bar-pass'; }

                if ($isHonors)        $badgeClass = 'badge-passed-honors';
                elseif ($isPassed)    $badgeClass = 'badge-passed';
                else                  $badgeClass = 'badge-failed';
              ?>
              <tr>
                <td class="td-num"><?php echo str_pad($i + 1, 2, '0', STR_PAD_LEFT); ?></td>
                <td class="td-code"><?php echo htmlspecialchars($row['subject_code']); ?></td>
                <td class="td-title"><?php echo htmlspecialchars($row['subject_title']); ?></td>
                <td>
                  <div class="grade-wrap">
                    <span class="grade-num <?php echo $gradeClass; ?>">
                      <?php echo htmlspecialchars($row['grade_value']); ?>
                    </span>
                    <?php if ($g !== null): ?>
                    <div class="grade-bar-track">
                      <div class="grade-bar-fill <?php echo $barClass; ?>"
                           style="width:<?php echo $barPct; ?>%;"></div>
                    </div>
                    <?php endif; ?>
                  </div>
                </td>
                <td>
                  <span class="badge <?php echo $badgeClass; ?>">
                    <?php echo $isHonors ? '✦ ' : ''; ?>
                    <?php echo htmlspecialchars($row['remarks']); ?>
                  </span>
                </td>
              </tr>
              <?php endforeach; ?>
            </tbody>
          </table>
        </div>

      <?php else: ?>
        <div class="empty-state">No grades available yet.</div>
      <?php endif; ?>

      <a href="dashboard.php" class="btn-back">← Back to Dashboard</a>

    </div>
  </div>
</div>
</body>
</html>
