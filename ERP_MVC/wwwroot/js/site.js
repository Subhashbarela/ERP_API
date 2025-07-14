// wwwroot/js/site.js

$(document).ready(function () {
    $('[data-toggle="collapse"]').on('click', function () {
        var target = $(this).attr('data-target');
        if ($(target).length) {
            $(target).collapse('toggle');
        } else {
            console.warn('Collapse target not found:', target);
        }
    });

    // To toggle password field
    var togglePassword = document.getElementById('togglePassword');
    if (togglePassword) {
        togglePassword.addEventListener('click', function (e) {
            const passwordInput = document.getElementById('passwordInput');
            if (passwordInput) {
                const type = passwordInput.getAttribute('type') === 'password' ? 'text' : 'password';
                passwordInput.setAttribute('type', type);
            }

            const icon = this.querySelector('i');
            if (icon) {
                icon.classList.toggle('fa-eye');
                icon.classList.toggle('fa-eye-slash');
            }
        });
    }

    // Access Profile Images
    function previewAndSubmit() {
        const fileInput = document.getElementById('profilePicInput');
        if (!fileInput) {
            console.error('profilePicInput not found');
            return;
        }
        const file = fileInput.files[0];
        if (file) {
            const reader = new FileReader();
            reader.onload = function (e) {
                const img = document.querySelector('img.rounded-circle');
                if (img) {
                    img.src = e.target.result;
                }
                const form = document.getElementById('profilePicForm');
                if (form) {
                    form.submit();
                }
            };
            reader.readAsDataURL(file);
        } else {
            console.log('No file selected');
        }
    }
});
