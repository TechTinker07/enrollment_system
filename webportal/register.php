<?php
require_once 'config.php';

$message = "";
$message_type = "error";

if ($_SERVER["REQUEST_METHOD"] == "POST") {
    $student_id = trim($_POST['student_id']);
    $first_name = trim($_POST['first_name']);
    $last_name = trim($_POST['last_name']);
    $email = trim($_POST['email']);
    $birthdate = trim($_POST['birthdate']);
    $address = trim($_POST['address']);
    $username = trim($_POST['username']);
    $password = trim($_POST['password']);
    $confirm_password = trim($_POST['confirm_password']);

    if (
        empty($student_id) || empty($first_name) || empty($last_name) ||
        empty($username) || empty($password) || empty($confirm_password)
    ) {
        $message = "Please fill in all required fields.";
    } elseif ($password !== $confirm_password) {
        $message = "Passwords do not match.";
    } else {
        $checkUser = $conn->prepare("SELECT user_id FROM users WHERE username = ?");
        $checkUser->bind_param("s", $username);
        $checkUser->execute();
        $checkUser->store_result();

        if ($checkUser->num_rows > 0) {
            $message = "Username already exists.";
        } else {
            $checkStudent = $conn->prepare("SELECT student_id FROM students WHERE student_id = ? OR email = ?");
            $checkStudent->bind_param("ss", $student_id, $email);
            $checkStudent->execute();
            $checkStudent->store_result();

            if ($checkStudent->num_rows > 0) {
                $message = "Student ID or email already exists.";
            } else {
                $conn->begin_transaction();

                try {
                    $role = "student";
                    $status = "pending";

                    $insertUser = $conn->prepare("INSERT INTO users (username, password, role, status) VALUES (?, ?, ?, ?)");
                    $insertUser->bind_param("ssss", $username, $password, $role, $status);
                    $insertUser->execute();

                    $user_id = $conn->insert_id;

                    $insertStudent = $conn->prepare("INSERT INTO students (student_id, user_id, first_name, last_name, email, birthdate, address) VALUES (?, ?, ?, ?, ?, ?, ?)");
                    $insertStudent->bind_param("sisssss", $student_id, $user_id, $first_name, $last_name, $email, $birthdate, $address);
                    $insertStudent->execute();

                    $conn->commit();
                    $message = "Registration successful! Your account is pending admin verification. You may login once approved.";
                    $message_type = "success";
                } catch (Exception $e) {
                    $conn->rollback();
                    $message = "Registration failed: " . $e->getMessage();
                }
            }

            $checkStudent->close();
        }

        $checkUser->close();
    }
}
?>
<!DOCTYPE html>
<html lang="en">
<head>
  <meta charset="UTF-8">
  <meta name="viewport" content="width=device-width, initial-scale=1.0">
  <title>Student Registration — SIMS Portal</title>
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
      --text:          #1a1a1a;
      --text-sub:      #444;
      --text-muted:    #aaa;
    }

    html, body {
      min-height: 100%;
      font-family: 'Inter', sans-serif;
      background: var(--bg);
      color: var(--text);
    }

    .page-wrap {
      min-height: 100vh;
      display: flex;
      align-items: flex-start;
      justify-content: center;
      padding: 40px 24px;
    }

    .reg-card {
      display: flex;
      width: 100%;
      max-width: 960px;
      border-radius: 20px;
      overflow: hidden;
      box-shadow: 0 8px 40px rgba(128,0,0,0.10);
      min-height: 640px;
    }

    /* ── LEFT PANEL ── */
    .panel-left {
      flex: 0 0 280px;
      background: linear-gradient(160deg, var(--maroon) 0%, var(--maroon-dark) 100%);
      padding: 40px 28px;
      display: flex;
      flex-direction: column;
      justify-content: space-between;
      position: relative;
      overflow: hidden;
    }

    .panel-left::before {
      content: '';
      position: absolute;
      top: -40px; right: -40px;
      width: 160px; height: 160px;
      border-radius: 50%;
      background: rgba(255,255,255,0.05);
    }

    .panel-left::after {
      content: '';
      position: absolute;
      bottom: -30px; left: -30px;
      width: 120px; height: 120px;
      border-radius: 50%;
      background: rgba(255,255,255,0.04);
    }

    .panel-content { position: relative; z-index: 1; }

    .panel-emoji { font-size: 36px; margin-bottom: 18px; }

    .panel-title {
      font-size: 22px;
      font-weight: 700;
      color: #fff;
      line-height: 1.3;
      margin-bottom: 10px;
    }

    .panel-desc {
      font-size: 13px;
      color: rgba(255,255,255,0.65);
      line-height: 1.65;
      margin-bottom: 28px;
    }

    .steps { display: flex; flex-direction: column; gap: 14px; }

    .step {
      display: flex;
      align-items: center;
      gap: 10px;
      font-size: 13px;
      color: rgba(255,255,255,0.75);
    }

    .step-num {
      width: 28px; height: 28px;
      border-radius: 50%;
      background: rgba(255,255,255,0.15);
      display: flex; align-items: center; justify-content: center;
      font-size: 12px; font-weight: 700;
      color: #fff;
      flex-shrink: 0;
    }

    .panel-footer {
      position: relative; z-index: 1;
      font-size: 11px;
      color: rgba(255,255,255,0.3);
      margin-top: 24px;
    }

    /* ── RIGHT FORM ── */
    .panel-right {
      flex: 1;
      background: var(--white);
      padding: 36px 40px;
      overflow-y: auto;
    }

    .portal-badge {
      display: inline-flex;
      align-items: center;
      gap: 6px;
      background: var(--maroon-pale);
      border: 1px solid var(--maroon-border);
      border-radius: 999px;
      padding: 5px 12px;
      font-size: 11.5px;
      font-weight: 600;
      color: var(--maroon);
      margin-bottom: 16px;
      letter-spacing: 0.03em;
    }

    .badge-dot {
      width: 6px; height: 6px;
      border-radius: 50%;
      background: var(--maroon);
      display: inline-block;
    }

    .form-heading {
      font-size: 22px;
      font-weight: 700;
      color: var(--text);
      margin-bottom: 4px;
    }

    .form-subheading {
      font-size: 13px;
      color: var(--text-muted);
      margin-bottom: 22px;
    }

    /* Alert */
    .alert {
      display: flex;
      align-items: flex-start;
      gap: 8px;
      border-radius: 10px;
      padding: 12px 16px;
      font-size: 13px;
      margin-bottom: 18px;
    }

    .alert-error {
      background: #fff5f5;
      border: 1px solid #fdd;
      color: #cc2222;
    }

    .alert-success {
      background: var(--maroon-pale);
      border: 1px solid var(--maroon-border);
      color: var(--maroon);
    }

    /* Section divider */
    .section-label {
      font-size: 11px;
      font-weight: 700;
      text-transform: uppercase;
      letter-spacing: 0.06em;
      color: var(--maroon);
      border-bottom: 2px solid #f3c6c6;
      padding-bottom: 6px;
      margin-bottom: 14px;
    }

    .section-label + .section-label,
    .form-row + .section-label,
    .form-group + .section-label {
      margin-top: 10px;
    }

    /* Form grid */
    .form-row {
      display: grid;
      grid-template-columns: 1fr 1fr;
      gap: 0 18px;
    }

    .form-group { margin-bottom: 14px; }

    .form-label {
      display: block;
      font-size: 12.5px;
      font-weight: 600;
      color: var(--text-sub);
      margin-bottom: 5px;
    }

    .required { color: var(--maroon); }

    .form-input {
      width: 100%;
      padding: 10px 12px;
      border: 1px solid var(--maroon-border);
      border-radius: 8px;
      font-size: 13.5px;
      color: var(--text);
      font-family: inherit;
      background: #fff;
      transition: border-color .15s, box-shadow .15s;
      outline: none;
    }

    .form-input:focus {
      border-color: var(--maroon);
      box-shadow: 0 0 0 3px rgba(128,0,0,0.08);
    }

    .form-input::placeholder { color: #ccc; }

    .form-hint {
      font-size: 11.5px;
      color: var(--text-muted);
      margin-top: 4px;
    }

    /* Submit */
    .btn-submit {
      width: 100%;
      margin-top: 6px;
      padding: 13px;
      background: var(--maroon);
      color: #fff;
      border: none;
      border-radius: 10px;
      font-family: inherit;
      font-size: 15px;
      font-weight: 600;
      cursor: pointer;
      letter-spacing: 0.01em;
      transition: background .15s;
    }

    .btn-submit:hover { background: var(--maroon-dark); }

    /* Divider */
    .divider {
      display: flex;
      align-items: center;
      gap: 12px;
      margin: 20px 0 14px;
      color: #ccc;
      font-size: 12px;
    }

    .divider::before,
    .divider::after {
      content: '';
      flex: 1;
      height: 1px;
      background: #f0e8e8;
    }

    .text-center { text-align: center; }
    .font-sm { font-size: 13px; color: #888; }

    .font-sm a {
      color: var(--maroon);
      font-weight: 600;
      text-decoration: none;
    }

    .font-sm a:hover { text-decoration: underline; }

    @media (max-width: 700px) {
      .panel-left { display: none; }
      .reg-card { border-radius: 14px; }
      .form-row { grid-template-columns: 1fr; }
      .panel-right { padding: 28px 22px; }
    }
  </style>
</head>
<body>
<div class="page-wrap">
  <div class="reg-card">

    <!-- ── LEFT PANEL ── -->
    <div class="panel-left">
      <div class="panel-content">
        <div class="panel-emoji">🎓</div>
        <div class="panel-title">Create Your<br>Student Account</div>
        <div class="panel-desc">
          Fill in your details to register. Your account will be reviewed and activated by the admin.
        </div>

        <div class="steps">
          <div class="step">
            <span class="step-num">1</span>
            Fill in the registration form
          </div>
          <div class="step">
            <span class="step-num">2</span>
            Wait for admin verification
          </div>
          <div class="step">
            <span class="step-num">3</span>
            Login once approved
          </div>
        </div>
      </div>
      <div class="panel-footer">© 2025 · Enrollment Portal</div>
    </div>

    <!-- ── RIGHT FORM ── -->
    <div class="panel-right">
      <div class="portal-badge">
        <span class="badge-dot"></span>
        New Student Registration
      </div>

      <div class="form-heading">Student Registration</div>
      <div class="form-subheading">
        Fields marked with <span class="required">*</span> are required
      </div>

      <?php if (!empty($message)): ?>
        <div class="alert alert-<?php echo $message_type; ?>">
          <?php echo $message_type === 'success' ? '✔' : '⚠'; ?>
          <?php echo htmlspecialchars($message); ?>
        </div>
      <?php endif; ?>

      <form method="POST" autocomplete="off">

        <div class="section-label">Student Information</div>

        <div class="form-row">
          <div class="form-group">
            <label class="form-label">Student ID <span class="required">*</span></label>
            <input class="form-input" type="text" name="student_id"
                   placeholder="e.g. 2024-00001"
                   value="<?php echo isset($_POST['student_id']) ? htmlspecialchars($_POST['student_id']) : ''; ?>"
                   required>
          </div>
          <div class="form-group">
            <label class="form-label">Email Address</label>
            <input class="form-input" type="email" name="email"
                   placeholder="student@email.com"
                   value="<?php echo isset($_POST['email']) ? htmlspecialchars($_POST['email']) : ''; ?>">
          </div>
        </div>

        <div class="form-row">
          <div class="form-group">
            <label class="form-label">First Name <span class="required">*</span></label>
            <input class="form-input" type="text" name="first_name"
                   placeholder="Juan"
                   value="<?php echo isset($_POST['first_name']) ? htmlspecialchars($_POST['first_name']) : ''; ?>"
                   required>
          </div>
          <div class="form-group">
            <label class="form-label">Last Name <span class="required">*</span></label>
            <input class="form-input" type="text" name="last_name"
                   placeholder="Dela Cruz"
                   value="<?php echo isset($_POST['last_name']) ? htmlspecialchars($_POST['last_name']) : ''; ?>"
                   required>
          </div>
        </div>

        <div class="form-row">
          <div class="form-group">
            <label class="form-label">Birthdate</label>
            <input class="form-input" type="date" name="birthdate"
                   value="<?php echo isset($_POST['birthdate']) ? htmlspecialchars($_POST['birthdate']) : ''; ?>">
          </div>
          <div class="form-group">
            <label class="form-label">Address</label>
            <input class="form-input" type="text" name="address"
                   placeholder="City, Province"
                   value="<?php echo isset($_POST['address']) ? htmlspecialchars($_POST['address']) : ''; ?>">
          </div>
        </div>

        <div class="section-label">Account Credentials</div>

        <div class="form-group">
          <label class="form-label">Username <span class="required">*</span></label>
          <input class="form-input" type="text" name="username"
                 placeholder="Choose a unique username"
                 value="<?php echo isset($_POST['username']) ? htmlspecialchars($_POST['username']) : ''; ?>"
                 required autocomplete="new-password">
          <div class="form-hint">This will be used to log in to your account.</div>
        </div>

        <div class="form-row">
          <div class="form-group">
            <label class="form-label">Password <span class="required">*</span></label>
            <input class="form-input" type="password" name="password"
                   placeholder="Create a password" required autocomplete="new-password">
          </div>
          <div class="form-group">
            <label class="form-label">Confirm Password <span class="required">*</span></label>
            <input class="form-input" type="password" name="confirm_password"
                   placeholder="Re-enter your password" required>
          </div>
        </div>

        <button type="submit" class="btn-submit">Create Account →</button>

      </form>

      <div class="divider">or</div>
      <p class="text-center font-sm">
        Already have an account? <a href="login.php">Login here</a>
      </p>
    </div>

  </div>
</div>
</body>
</html>
