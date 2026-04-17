<?php
require_once 'config.php';

$message = "";

if ($_SERVER["REQUEST_METHOD"] == "POST") {
    $username = trim($_POST['username']);
    $password = trim($_POST['password']);

    if (empty($username) || empty($password)) {
        $message = "Please enter both username and password.";
    } else {
        $stmt = $conn->prepare("SELECT user_id, username, role, status, password FROM users WHERE username = ?");
        $stmt->bind_param("s", $username);
        $stmt->execute();
        $result = $stmt->get_result();

        if ($row = $result->fetch_assoc()) {
            if ($row['password'] !== $password) {
                $message = "Invalid username or password.";
            } elseif ($row['role'] !== 'student') {
                $message = "This portal is for student accounts only.";
            } elseif ($row['status'] !== 'verified') {
                $message = "Your account is still pending verification by the admin.";
            } else {
                $_SESSION['user_id'] = $row['user_id'];
                $_SESSION['username'] = $row['username'];
                $_SESSION['role'] = $row['role'];

                header("Location: dashboard.php");
                exit;
            }
        } else {
            $message = "Invalid username or password.";
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
    <title>Student Login</title>
    <link rel="stylesheet" href="style.css?v=<?php echo filemtime('style.css'); ?>">
</head>
<body>
<div class="auth-page">
  <div class="auth-card">
    <div class="auth-panel">
      <div class="auth-visuals" aria-hidden="true">
        <div class="hex hex-outline hex-top"></div>
        <div class="hex hex-fill hex-mid"></div>
        <div class="hex hex-outline hex-right"></div>
        <div class="hex hex-photo hex-photo-one"></div>
        <div class="hex hex-photo hex-photo-two"></div>
        <div class="hex hex-fill hex-bottom"></div>
      </div>

      <div class="auth-panel-content">
        <div class="auth-panel-logo">&#127891;</div>
        <div class="auth-panel-kicker">SIMS Portal</div>
        <div class="auth-panel-title">Student Enrollment System</div>
        <div class="auth-panel-desc">Access your records, grades, and enrollment updates in one place.</div>
        <div class="auth-panel-pills">
          <span>Student Access</span>
          <span>Secure Login</span>
         
        </div>
      </div>

      <div class="auth-panel-footer">&#169; 2025 &middot; Enrollment Portal</div>
    </div>

    <div class="auth-form-panel">
      <div class="portal-badge"><div class="dot"></div> Student Portal</div>
      <div class="auth-heading">Welcome back</div>
      <div class="auth-subheading">Sign in to continue to your student dashboard</div>

      <?php if (!empty($message)): ?>
        <div class="alert alert-error">&#9888; <?php echo htmlspecialchars($message); ?></div>
      <?php endif; ?>

      <form method="POST">
        <div class="form-group">
          <label class="form-label">Username</label>
          <input class="form-input" type="text" name="username" placeholder="Enter your username" required>
        </div>

        <div class="form-group">
          <label class="form-label">Password</label>
          <input class="form-input" type="password" name="password" placeholder="Enter your password" required>
        </div>

        <button type="submit" class="btn btn-primary btn-full btn-lg">Sign In &rarr;</button>
      </form>

      <div class="divider">or</div>
      <p class="text-center font-sm">Don't have an account? <a href="register.php">Create student account</a></p>
    </div>
  </div>
</div>
</body>
</html>
