<?php
require_once 'config.php';

$message = "";
$message_type = "";

if ($_SERVER["REQUEST_METHOD"] == "POST") {
    $username = trim($_POST['username']);
    $password = trim($_POST['password']);

    if (empty($username) || empty($password)) {
        $message = "Please enter both username and password.";
        $message_type = "error";
    } else {
        $stmt = $conn->prepare("SELECT user_id, username, role, status, password FROM users WHERE username = ?");
        $stmt->bind_param("s", $username);
        $stmt->execute();
        $result = $stmt->get_result();

        if ($row = $result->fetch_assoc()) {
            if ($row['password'] !== $password) {
                $message = "Invalid username or password.";
                $message_type = "error";
            } elseif ($row['role'] !== 'student') {
                $message = "This portal is for student accounts only.";
                $message_type = "error";
            } elseif ($row['status'] === 'blocked') {
                $message = "Your account is blocked. Please contact the admin.";
                $message_type = "error";
            } elseif ($row['status'] !== 'verified') {
                $message = "Your account is still pending verification by the admin.";
                $message_type = "warning";
            } else {
				$_SESSION['user_id']  = $row['user_id'];
				$_SESSION['username'] = $row['username'];
				$_SESSION['role']     = $row['role'];

				// Fetch student details
				$sStmt = $conn->prepare("
					SELECT s.student_id, c.course_code, e.semester
					FROM students s
					LEFT JOIN enrollments e ON s.student_id = e.student_id
					LEFT JOIN courses c ON e.course_id = c.course_id
					WHERE s.user_id = ?
					ORDER BY e.enrollment_id DESC
					LIMIT 1
				");
				$sStmt->bind_param("i", $row['user_id']);
				$sStmt->execute();
				$sRow = $sStmt->get_result()->fetch_assoc();
				$sStmt->close();

				$_SESSION['student_id'] = $sRow['student_id'] ?? '';
				$_SESSION['course']     = $sRow['course_code'] ?? '';
				$_SESSION['year_level'] = $sRow['semester']    ?? '';

				header("Location: dashboard.php");
				exit;
			}
        } else {
            $message = "Invalid username or password.";
            $message_type = "error";
        }

        $stmt->close();
    }
}
?>
<!DOCTYPE html>
<html lang="en">
<head>
  <meta charset="UTF-8">
  <meta name="viewport" content="width=device-width, initial-scale=1.0">
  <title>Student Login — SIMS Portal</title>
  <link rel="preconnect" href="https://fonts.googleapis.com">
  <link rel="preconnect" href="https://fonts.gstatic.com" crossorigin>
  <link href="https://fonts.googleapis.com/css2?family=Inter:wght@400;500;600;700&display=swap" rel="stylesheet">
  <style>
    *, *::before, *::after { box-sizing: border-box; margin: 0; padding: 0; }

    :root {
      --maroon:       #800000;
      --maroon-hover: #a00000;
      --maroon-pale:  #fdf0f0;
      --maroon-border:#c0000033;
      --gray-100: #f3f4f6;
      --gray-200: #e5e7eb;
      --gray-300: #d1d5db;
      --gray-400: #9ca3af;
      --gray-500: #6b7280;
      --gray-700: #374151;
      --gray-900: #111827;
    }

    html, body {
      height: 100%;
      font-family: 'Inter', sans-serif;
      background: #fff;
      color: var(--gray-900);
    }

    /* ── Layout ── */
    .page {
      display: flex;
      min-height: 100vh;
      overflow: hidden;
    }

    /* ── LEFT PANEL ── */
    .left-panel {
      flex: 1;
      position: relative;
      overflow: hidden;
      background: linear-gradient(135deg, #ffffff 0%, #f9f5f5 60%, #fdeaea 100%);
      display: flex;
      align-items: center;
      justify-content: center;
    }

    .hex-grid {
      position: relative;
      width: 780px;
      height: 660px;
    }

    /* Hexagon clip using CSS polygon (pointy-top) */
    .hex {
      position: absolute;
      clip-path: polygon(50% 0%, 100% 25%, 100% 75%, 50% 100%, 0% 75%, 0% 25%);
      overflow: hidden;
    }

    .hex img {
      width: 100%;
      height: 100%;
      object-fit: cover;
      filter: saturate(0.85) brightness(0.95);
      display: block;
    }

    .hex-tint {
      position: absolute;
      inset: 0;
      background: rgba(128, 0, 0, 0.12);
      mix-blend-mode: multiply;
      pointer-events: none;
    }


    .hex-outline {
      position: absolute;
    }

    .hex-outline svg {
      display: block;
    }

    .hex-fill-maroon {
      position: absolute;
      clip-path: polygon(50% 0%, 100% 25%, 100% 75%, 50% 100%, 0% 75%, 0% 25%);
      background: #800000;
      opacity: .85;
    }

    .hex-fill-pale {
      position: absolute;
      clip-path: polygon(50% 0%, 100% 25%, 100% 75%, 50% 100%, 0% 75%, 0% 25%);
      background: #f5e0e0;
      opacity: .70;
    }

    .panel-footer {
      position: absolute;
      bottom: 1.5rem;
      left: 2.5rem;
      z-index: 10;
    }

    .panel-footer .municipality {
      font-size: 14px;
      font-weight: 700;
      letter-spacing: .12em;
      text-transform: uppercase;
      color: var(--maroon);
      margin-bottom: 3px;
    }

    .panel-footer .system {
      font-size: 12px;
      color: var(--gray-400);
    }

    /* ── RIGHT PANEL ── */
    .right-panel {
      flex: 1; /* Binago: Gawin itong flex: 1 para kainin ang natitirang space */
      min-width: 450px; /* Minimum width para hindi masyadong maliit sa mobile */
      display: flex;
      flex-direction: column;
      justify-content: center;
      align-items: center; /* Idagdag: Para mag-center ang form sa loob ng 800px+ space */
      padding: 3.5rem 3rem;
      position: relative;
      background: #fff;
      border-left: 2px solid #f0e8e8;
      box-shadow: -8px 0 40px rgba(128,0,0,.06);
    }

    .right-panel::before {
      content: '';
      position: absolute;
      top: 0; left: 0; right: 0;
      height: 5px;
      background: var(--maroon);
    }
    .right-panel > * {
      width: 100%;
      max-width: 750px; /* Eto ang "magic number" para magmukhang professional ang login */
    }

    /* Logo */
    .logo-row {
      display: flex;
      align-items: center;
      gap: .75rem;
      margin-bottom: 1.25rem;
      justify-content: flex-start; /* Panatilihing nasa left ng form ang logo */
    }

    .logo-icon {
      width: 50px; 
      height: 50px;
      border-radius: 10px;
      background: var(--maroon); /* Pwedeng alisin 'to kung may bg na yung logo image mo */
      display: flex; 
      align-items: center; 
      justify-content: center;
      flex-shrink: 0;
      overflow: hidden; /* Para hindi lumabas ang image sa kanto */
    }

    .logo-icon img {
      width: 100%;
      height: 100%;
      object-fit: contain; /* Para hindi ma-squash yung logo */
    }
    .logo-text .abbr {
      font-size: 20px;
      font-weight: 700;
      letter-spacing: .14em;
      text-transform: uppercase;
      color: var(--maroon);
      line-height: 1;
    }

    .logo-text .full {
      font-size: 16px;
      color: var(--gray-400);
      margin-top: 2px;
    }

    .heading { font-size: 2.5rem; font-weight: 700; color: var(--gray-900); margin-bottom: 4px; }
    .subheading { font-size: 1rem; color: var(--gray-400); margin-bottom: 2rem; }

    /* Alert */
    .alert {
      border-radius: 10px;
      padding: .75rem 1rem;
      font-size: .8125rem;
      margin-bottom: 1.25rem;
      display: flex;
      align-items: flex-start;
      gap: .5rem;
    }

    .alert.error {
      background: #fef2f2;
      border: 1px solid #fca5a5;
      color: #991b1b;
    }

    .alert.warning {
      background: #fffbeb;
      border: 1px solid #fcd34d;
      color: #92400e;
    }

    /* Form */
    .form-group { margin-bottom: 3rem; }

    .form-label {
      display: block;
      font-size: 14px;
      font-weight: 600;
      letter-spacing: .1em;
      text-transform: uppercase;
      color: var(--gray-500);
      margin-bottom: 12px;
    }

    .input-wrap {
      display: flex;
      align-items: center;
      border: 1.5px solid var(--gray-200);
      border-radius: 10px;
      background: #fff;
      transition: border-color .15s, box-shadow .15s;
    }

    .input-wrap:focus-within {
      border-color: var(--maroon);
      box-shadow: 0 0 0 3px rgba(128,0,0,.1);
    }

    .input-wrap .icon {
      padding: 0 .5rem 0 .875rem;
      color: var(--gray-300);
      flex-shrink: 0;
      display: flex;
      align-items: center;
    }

    .input-wrap input {
      flex: 1;
      border: none;
      outline: none;
      font-size: 1rem;
      color: var(--gray-900);
      padding: .80rem .875rem .75rem 0;
      background: transparent;
      font-family: 'Inter', sans-serif;
    }

    .input-wrap input::placeholder { color: var(--gray-300); }

    .toggle-pw {
      background: none;
      border: none;
      cursor: pointer;
      padding: 0 .875rem 0 .5rem;
      color: var(--gray-300);
      display: flex;
      align-items: center;
      transition: color .15s;
    }

    .toggle-pw:hover { color: var(--gray-500); }

    /* Button */
    .btn-signin {
      width: 100%;
      padding: .875rem 1rem;
      border-radius: 10px;
      background: var(--maroon);
      color: #fff;
      font-size: 1rem;
      font-weight: 600;
      letter-spacing: .04em;
      border: none;
      cursor: pointer;
      display: flex;
      align-items: center;
      justify-content: center;
      gap: .5rem;
      margin-top: .25rem;
      margin-bottom: 1rem;
      transition: background .15s;
      box-shadow: 0 4px 14px rgba(128,0,0,.35);
    }

    .btn-signin:hover { background: var(--maroon-hover); }

    /* Divider */
    .divider {
      display: flex;
      align-items: center;
      gap: 1rem;
      margin-bottom: 1rem;
      color: var(--gray-400);
      font-size: 1rem;
    }

    .divider::before, .divider::after {
      content: '';
      flex: 1;
      height: 1px;
      background: var(--gray-100);
    }

    /* Register link */
    .register-text {
      text-align: center;
      font-size: 1rem;
      color: var(--gray-400);
      margin-bottom: 2rem;
    }

    .register-text a {
      color: var(--maroon);
      font-weight: 600;
      text-decoration: none;
    }

    .register-text a:hover { color: var(--maroon-hover); }

    /* Info box */
    .info-box {
      background: var(--maroon-pale);
      border: 1px solid var(--maroon-border);
      border-radius: 12px;
      padding: 1rem 1rem;
      display: flex;
      align-items: flex-start;
      gap: .75rem;
    }

    .info-box svg { flex-shrink: 0; margin-top: 1px; }

    .info-box p {
      font-size: .82rem;
      color: var(--gray-500);
      line-height: 1.5;
    }

    /* Copyright */
    .copyright {
      text-align: center;
      font-size: 12px;
      color: var(--gray-400);
      margin-top: 3rem;
    }

    /* Responsive fallback */
    @media (max-width: 768px) {
      .left-panel { display: none; }
      .right-panel { width: 100%; }
    }
  </style>
</head>
<body>
<div class="page">

  <!-- ── LEFT: Hexagon mosaic ── -->
  <div class="left-panel">
    <div class="hex-grid">

      <!-- Column 0 (no offset) -->
      <!-- [0,0] outline -->
      <div class="hex-outline" style="left:-20px; top:-20px; width:180px; height:208px;">
        <svg width="180" height="208" viewBox="0 0 180 208" fill="none">
          <polygon points="90,5 175,47 175,161 90,203 5,161 5,47" stroke="#800000" stroke-width="2" fill="none" opacity="0.2"/>
        </svg>
      </div>

      
      <div class="hex" style="left:-20px; top:192px; width:180px; height:208px;">
        <img src="learn.jpg" alt="School Building"
             onerror="this.style.display='none'; this.parentElement.style.background='#f5e0e0';">
        <div class="hex-tint"></div>
      </div>

      <!-- [0,2] outline -->
      <div class="hex-outline" style="left:-20px; top:404px; width:180px; height:208px;">
        <svg width="180" height="208" viewBox="0 0 180 208" fill="none">
          <polygon points="90,5 175,47 175,161 90,203 5,161 5,47" stroke="#800000" stroke-width="2" fill="none" opacity="0.2"/>
        </svg>
      </div>

      <!-- Column 1 (offset down by 108px) -->
      <div class="hex" style="left:164px; top:88px; width:180px; height:208px;">
        <img src="open.jpg" alt="Students"
             onerror="this.style.display='none'; this.parentElement.style.background='#f5e0e0';">
        <div class="hex-tint"></div>
      </div>

      <!-- [1,1] pale fill -->
      <div class="hex-fill-pale" style="left:164px; top:300px; width:180px; height:208px;"></div>

      <!-- [1,2] maroon fill -->
      <div class="hex-fill-maroon" style="left:164px; top:512px; width:180px; height:208px;"></div>

      <!-- Column 2 (no offset) -->
      <!-- [2,0] outline -->
      <div class="hex-outline" style="left:348px; top:-20px; width:180px; height:208px;">
        <svg width="180" height="208" viewBox="0 0 180 208" fill="none">
          <polygon points="90,5 175,47 175,161 90,203 5,161 5,47" stroke="#800000" stroke-width="2" fill="none" opacity="0.2"/>
        </svg>
      </div>

      <div class="hex" style="left:348px; top:192px; width:180px; height:208px;">
        <img src="library.jpg" alt="Classroom"
             onerror="this.style.display='none'; this.parentElement.style.background='#f5e0e0';">
        <div class="hex-tint"></div>
      </div>

      <!-- [2,2] outline -->
      <div class="hex-outline" style="left:348px; top:404px; width:180px; height:208px;">
        <svg width="180" height="208" viewBox="0 0 180 208" fill="none">
          <polygon points="90,5 175,47 175,161 90,203 5,161 5,47" stroke="#800000" stroke-width="2" fill="none" opacity="0.2"/>
        </svg>
      </div>

      <!-- Column 3 (offset down by 108px) -->
      <!-- [3,0] pale fill -->
      <div class="hex-fill-pale" style="left:532px; top:88px; width:180px; height:208px;"></div>

      <div class="hex" style="left:532px; top:300px; width:180px; height:208px;">
        <img src="students.jpg" alt="Graduation"
             onerror="this.style.display='none'; this.parentElement.style.background='#f5e0e0';">
        <div class="hex-tint"></div>
      </div>

      <!-- [3,2] outline -->
      <div class="hex-outline" style="left:532px; top:512px; width:180px; height:208px;">
        <svg width="180" height="208" viewBox="0 0 180 208" fill="none">
          <polygon points="90,5 175,47 175,161 90,203 5,161 5,47" stroke="#800000" stroke-width="2" fill="none" opacity="0.2"/>
        </svg>
      </div>

    </div><!-- /hex-grid -->

    <div class="panel-footer">
      <p class="municipality">College of Lycem</p>
      <p class="system">Student Information Management System</p>
    </div>
  </div><!-- /left-panel -->


  <!-- ── RIGHT: Login form ── -->
  <div class="right-panel">

    <!-- Logo -->
    <div class="logo-row">
      <div class="logo-icon">
        <img src="logo.jpg" alt="Logo" style="width: 100%; height: 100%; object-fit: contain; border-radius: 8px;">
      </div>
      <div class="logo-text">
        <div class="abbr">SIMS</div>
        <div class="full">Student Information Portal</div>
      </div>
    </div>

    <h1 class="heading">Welcome back!</h1>
    <p class="subheading">Sign in to your student account to continue.</p>

    <?php if (!empty($message)): ?>
      <div class="alert <?php echo htmlspecialchars($message_type); ?>">
        <?php if ($message_type === 'error'): ?>
          <svg width="15" height="15" viewBox="0 0 24 24" fill="none" style="flex-shrink:0;margin-top:1px"><circle cx="12" cy="12" r="10" stroke="currentColor" stroke-width="2"/><line x1="12" y1="8" x2="12" y2="12" stroke="currentColor" stroke-width="2" stroke-linecap="round"/><circle cx="12" cy="16" r="1" fill="currentColor"/></svg>
        <?php else: ?>
          <svg width="15" height="15" viewBox="0 0 24 24" fill="none" style="flex-shrink:0;margin-top:1px"><path d="M10.29 3.86L1.82 18a2 2 0 001.71 3h16.94a2 2 0 001.71-3L13.71 3.86a2 2 0 00-3.42 0z" stroke="currentColor" stroke-width="2"/><line x1="12" y1="9" x2="12" y2="13" stroke="currentColor" stroke-width="2" stroke-linecap="round"/><circle cx="12" cy="17" r="1" fill="currentColor"/></svg>
        <?php endif; ?>
        <?php echo htmlspecialchars($message); ?>
      </div>
    <?php endif; ?>

    <form method="POST" action="">

      <div class="form-group">
        <label class="form-label">Username</label>
        <div class="input-wrap">
          <span class="icon">
            <svg width="16" height="16" viewBox="0 0 24 24" fill="none"><path d="M20 21v-2a4 4 0 00-4-4H8a4 4 0 00-4 4v2" stroke="currentColor" stroke-width="1.8" stroke-linecap="round"/><circle cx="12" cy="7" r="4" stroke="currentColor" stroke-width="1.8"/></svg>
          </span>
          <input type="text" name="username" placeholder="Enter your username"
                 value="<?php echo isset($_POST['username']) ? htmlspecialchars($_POST['username']) : ''; ?>"
                 required autocomplete="username">
        </div>
      </div>

      <div class="form-group">
        <label class="form-label">Password</label>
        <div class="input-wrap">
          <span class="icon">
            <svg width="16" height="16" viewBox="0 0 24 24" fill="none"><rect x="3" y="11" width="18" height="11" rx="2" stroke="currentColor" stroke-width="1.8"/><path d="M7 11V7a5 5 0 0110 0v4" stroke="currentColor" stroke-width="1.8" stroke-linecap="round"/></svg>
          </span>
          <input type="password" name="password" id="password-field" placeholder="Enter your password" required autocomplete="current-password">
          <button type="button" class="toggle-pw" onclick="togglePassword()" title="Show/hide password">
            <svg id="eye-icon" width="16" height="16" viewBox="0 0 24 24" fill="none"><path d="M1 12s4-8 11-8 11 8 11 8-4 8-11 8-11-8-11-8z" stroke="currentColor" stroke-width="1.8"/><circle cx="12" cy="12" r="3" stroke="currentColor" stroke-width="1.8"/></svg>
          </button>
        </div>
      </div>

      <button type="submit" class="btn-signin">
        <svg width="15" height="15" viewBox="0 0 24 24" fill="none"><path d="M15 3h4a2 2 0 012 2v14a2 2 0 01-2 2h-4" stroke="white" stroke-width="2" stroke-linecap="round"/><polyline points="10 17 15 12 10 7" stroke="white" stroke-width="2" stroke-linecap="round" stroke-linejoin="round"/><line x1="15" y1="12" x2="3" y2="12" stroke="white" stroke-width="2" stroke-linecap="round"/></svg>
        Sign In
      </button>

    </form>

    <div class="divider">or</div>

    <p class="register-text">
      Don't have an account? <a href="register.php">Create student account</a>
    </p>

    <div class="info-box">
      <svg width="14" height="14" viewBox="0 0 24 24" fill="none">
        <circle cx="12" cy="12" r="10" stroke="#800000" stroke-width="1.8" opacity="0.6"/>
        <line x1="12" y1="8" x2="12" y2="8" stroke="#800000" stroke-width="2" stroke-linecap="round"/>
        <line x1="12" y1="12" x2="12" y2="16" stroke="#800000" stroke-width="1.8" stroke-linecap="round" opacity="0.7"/>
      </svg>
      <p>New accounts require admin verification before first login. Contact the registrar's office for assistance.</p>
    </div>

    <p class="copyright">© 2026 College of Lycem  &middot; All rights reserved</p>
  </div><!-- /right-panel -->

</div><!-- /page -->

<script>
  function togglePassword() {
    const field = document.getElementById('password-field');
    const icon  = document.getElementById('eye-icon');
    if (field.type === 'password') {
      field.type = 'text';
      icon.innerHTML = '<path d="M17.94 17.94A10.07 10.07 0 0112 20c-7 0-11-8-11-8a18.45 18.45 0 015.06-5.94M9.9 4.24A9.12 9.12 0 0112 4c7 0 11 8 11 8a18.5 18.5 0 01-2.16 3.19M1 1l22 22" stroke="currentColor" stroke-width="1.8" stroke-linecap="round"/>';
    } else {
      field.type = 'password';
      icon.innerHTML = '<path d="M1 12s4-8 11-8 11 8 11 8-4 8-11 8-11-8-11-8z" stroke="currentColor" stroke-width="1.8"/><circle cx="12" cy="12" r="3" stroke="currentColor" stroke-width="1.8"/>';
    }
  }
</script>
</body>
</html>
