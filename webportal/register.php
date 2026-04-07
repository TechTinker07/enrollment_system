<?php
require_once 'config.php';

$message = "";

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
                    $message = "Registration successful. Your account is pending admin verification.";
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
    <link rel="stylesheet" href="style.css">
</head>
<body>
    <div class="container">
        <h2>Student Registration</h2>

        <?php if (!empty($message)): ?>
            <p class="message"><?php echo htmlspecialchars($message); ?></p>
        <?php endif; ?>

        <form method="POST">
            <input type="text" name="student_id" placeholder="Student ID" required>
            <input type="text" name="first_name" placeholder="First Name" required>
            <input type="text" name="last_name" placeholder="Last Name" required>
            <input type="email" name="email" placeholder="Email">
            <input type="date" name="birthdate">
            <textarea name="address" placeholder="Address"></textarea>
            <input type="text" name="username" placeholder="Username" required>
            <input type="password" name="password" placeholder="Password" required>
            <input type="password" name="confirm_password" placeholder="Confirm Password" required>

            <button type="submit">Register</button>
        </form>

        <p><a href="login.php">Already have an account? Login here</a></p>
    </div>
</body>
</html>
