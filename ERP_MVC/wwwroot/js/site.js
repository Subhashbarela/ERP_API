// wwwroot/js/site.js

$(document).ready(function () {
    $('[data-toggle="collapse"]').on('click', function () {
        var target = $(this).attr('data-target');
        $(target).collapse('toggle');
    });

    // To toggle password field
    document.getElementById('togglePassword').addEventListener('click', function (e) {
        // Toggle the type attribute
        const passwordInput = document.getElementById('passwordInput');
        const type = passwordInput.getAttribute('type') === 'password' ? 'text' : 'password';
        passwordInput.setAttribute('type', type);

        // Toggle the eye slash icon
        this.querySelector('i').classList.toggle('fa-eye');
        this.querySelector('i').classList.toggle('fa-eye-slash');
    });

    // Access Profile Images
    function previewAndSubmit() {
        const fileInput = document.getElementById('profilePicInput');
        const file = fileInput.files[0];
        if (file) {
            const reader = new FileReader();
            reader.onload = function (e) {
                document.querySelector('img.rounded-circle').src = e.target.result;
                document.getElementById('profilePicForm').submit();
            };
            reader.readAsDataURL(file);
        } else {
            // If no file is selected, do nothing or handle as necessary
            console.log('No file selected');
        }
    }
});
