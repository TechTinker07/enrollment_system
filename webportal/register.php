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
    <title>Student Registration</title>
    <link rel="stylesheet" href="style.css?v=<?php echo filemtime('style.css'); ?>">
</head>
<body>

<div class="auth-page" style="align-items: flex-start; padding: 2rem;">
    <div class="auth-card" style="max-width: 980px; margin: auto;">

        <!-- Left branding panel -->
        <div class="auth-panel" style="flex: 0 0 280px;">
            <div style="position: relative; z-index: 1;">
                <div class="auth-panel-logo">&#127891;</div>
                <div class="auth-panel-title">Create Your<br>Student Account</div>
                <div class="auth-panel-desc" style="margin-top: 0.75rem;">
                    Fill in your details to register. Your account will be reviewed and activated by the admin.
                </div>

                <div style="margin-top: 2rem; display: flex; flex-direction: column; gap: 14px;">
                    <div style="display: flex; align-items: center; gap: 10px; font-size: 13px; color: rgba(255,255,255,0.75);">
                        <span style="width: 28px; height: 28px; background: rgba(255,255,255,0.15); border-radius: 50%; display: flex; align-items: center; justify-content: center; font-size: 12px; font-weight: 700; flex-shrink: 0;">1</span>
                        Fill in the registration form
                    </div>
                    <div style="display: flex; align-items: center; gap: 10px; font-size: 13px; color: rgba(255,255,255,0.75);">
                        <span style="width: 28px; height: 28px; background: rgba(255,255,255,0.15); border-radius: 50%; display: flex; align-items: center; justify-content: center; font-size: 12px; font-weight: 700; flex-shrink: 0;">2</span>
                        Wait for admin verification
                    </div>
                    <div style="display: flex; align-items: center; gap: 10px; font-size: 13px; color: rgba(255,255,255,0.75);">
                        <span style="width: 28px; height: 28px; background: rgba(255,255,255,0.15); border-radius: 50%; display: flex; align-items: center; justify-content: center; font-size: 12px; font-weight: 700; flex-shrink: 0;">3</span>
                        Login once approved
                    </div>
                </div>
            </div>
            <div class="auth-panel-footer">&#169; 2025 &middot; Enrollment Portal</div>
        </div>

        <!-- Right form panel -->
        <div class="auth-form-panel" style="flex: 1; overflow-y: auto;">
            <div class="portal-badge"><div class="dot"></div> New Student Registration</div>
            <div class="auth-heading" style="font-size: 22px;">Student Registration</div>
            <div class="auth-subheading">Fields marked with <span style="color: #7b0020;">*</span> are required</div>

            <?php if (!empty($message)): ?>
                <div class="alert alert-<?php echo $message_type; ?>">
                    <?php echo $message_type === 'success' ? '&#10004;' : '&#9888;'; ?>
                    <?php echo htmlspecialchars($message); ?>
                </div>
            <?php endif; ?>

            <form method="POST" autocomplete="off">

                <!-- Section label -->
                <div style="font-size: 11px; font-weight: 700; text-transform: uppercase; letter-spacing: 0.6px; color: #7b0020; margin-bottom: 0.75rem; padding-bottom: 6px; border-bottom: 2px solid #f3c6ce;">
                    Student Information
                </div>

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

                <!-- Section label -->
                <div style="font-size: 11px; font-weight: 700; text-transform: uppercase; letter-spacing: 0.6px; color: #7b0020; margin: 0.5rem 0 0.75rem; padding-bottom: 6px; border-bottom: 2px solid #f3c6ce;">
                    Account Credentials
                </div>

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

                <button type="submit" class="btn btn-primary btn-full" style="margin-top: 0.25rem; padding: 13px; font-size: 15px;">
                    Create Account &#8594;
                </button>

            </form>

            <div class="divider">or</div>
            <p class="text-center font-sm">Already have an account? <a href="login.php">Login here</a></p>

        </div>
    </div>
</div>

</body>
</html>
