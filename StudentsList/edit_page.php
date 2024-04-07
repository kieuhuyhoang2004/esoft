<?php
$_servername = "localhost";
$_username = "root";
$_password = "";
$_dbname = "btec-database";

// Create connection
$connection = new mysqli($_servername, $_username, $_password, $_dbname);

$id = "";
$fullname = "";
$email = "";
$password = "";
$masv = "";

$errorMessage = "";
$successMessage = "";

// Check if ID parameter is provided in the URL
if (isset($_GET['id'])) {
    $id = $_GET['id'];

    // Retrieve student information from the database
    $query = "SELECT * FROM users WHERE id = '$id'";
    $result = $connection->query($query);

    if ($result->num_rows > 0) {
        $row = $result->fetch_assoc();
        $fullname = $row['fullname'];
        $email = $row['email'];
        $masv = $row['masv'];
    } else {
        $errorMessage = "Student not found with ID: $id";
    }
}

if ($_SERVER['REQUEST_METHOD'] === 'POST') {
    $id = $_POST['id'];
    $fullname = $_POST['fullname'];
    $email = $_POST['email'];
    $password = $_POST['password'];
    $masv = $_POST['masv'];

    // Hash password
    $hashed_password = password_hash($password, PASSWORD_DEFAULT);

    $check_sql = "SELECT * FROM users WHERE email = '$email'";
    $check_result = $connection->query($check_sql);

    if ($check_result->num_rows > 0) {
        $errorMessage = "Error: Email already exists in the system.";
    } else {
        if (empty($id) || empty($fullname) || empty($email) || empty($password) || empty($masv)) {
            $errorMessage = "Complete student information is required";
        } else {
            // Update student information in the database
            $sql = "UPDATE users SET fullname = '$fullname', email = '$email', password = '$hashed_password', masv = '$masv' WHERE id = '$id'";
            $result = $connection->query($sql);

            if (!$result) {
                $errorMessage = "Invalid query: " . $connection->error;
            } else {
                $id = "";
                $fullname = "";
                $email = "";
                $password = "";
                $masv = "";

                $successMessage = "Student information updated correctly";
                header("location: /StudentsList/home_page.php");
                exit;
            }
        }
    }
}
?>
<!DOCTYPE html>
<html lang="en">

<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Update Student</title>
    <link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/tailwindcss@2.2.19/dist/tailwind.min.css">
</head>

<body class="flex items-center justify-center min-h-screen bg-gradient-to-r from-purple-400 via-pink-500 to-red-500">
<div class="bg-white max-w-lg w-full p-8 rounded shadow-md">
    <h2 class="text-2xl font-bold mb-4 text-center">Update Student</h2>
    <form method="POST" action="edit_page.php">
        <div class="mb-4">
            <label for="id" class="block mb-2 font-bold">ID:</label>
            <input type="text" name="id" class="border border-gray-300 rounded px-4 py-2 w-full"
                value="<?php echo htmlspecialchars($id); ?>">
        </div>

        <div class="mb-4">
            <label for="fullname" class="block mb-2 font-bold">Full Name:</label>
            <input type="text" name="fullname" class="border border-gray-300 rounded px-4 py-2 w-full"
                value="<?php echo htmlspecialchars($fullname); ?>">
        </div>

        <div class="mb-4">
            <label for="email" class="block mb-2 font-bold">Email:</label>
            <input type="email" name="email" class="border border-gray-300 rounded px-4 py-2 w-full"
                value="<?php echo htmlspecialchars($email); ?>">
        </div>

        <div class="mb-4">
            <label for="password" class="block mb-2 font-bold">Password:</label>
            <input type="password" name="password" class="border border-gray-300 rounded px-4 py-2 w-full">
        </div>

        <div class="mb-4">
            <label for="masv" class="block mb-2 font-bold">MaSV:</label>
            <input type="masv" name="masv" class="border border-gray-300 rounded px-4 py-2 w-full"
                value="<?php echo htmlspecialchars($masv); ?>">
        </div>

        <div class="flex justify-between">
            <input type="submit" value="Update Student" class="bg-blue-500 text-white px-4 py-2 rounded cursor-pointer hover:bg-blue-600">

            <a href="/StudentsList/home_page.php" class="bg-gray-300 text-black px-4 py-2 rounded cursor-pointer hover:bg-gray-400">Cancel</a>
            </div>
    </form>

    <?php
    if (!empty($errorMessage)) {
        echo '<p class="text-red-500 mt-4 text-center">' . $errorMessage . '</p>';
    }

    if (!empty($successMessage)) {
        echo '<p class="text-green-500 mt-4 text-center">' . $successMessage . '</p>';
    }
    ?>
</div>
</body>

</html>