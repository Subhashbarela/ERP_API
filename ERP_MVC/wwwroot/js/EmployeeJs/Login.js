$(document).ready(function () {
    $("#btnlogin").click(function () {
        Login();
    });
    $("#EmployeeProfile").click(function () {

        fetchEmployeeData();
    });

    $('#updateEmployee').click(function () {      
        UpdateEmployee();
    });

});

function Login() {
    var userName = $("#username").val();
    var password = $("#password").val();
    var st = { "UserName": userName, "Password": password };
    $.ajax({
        url: "https://localhost:7279/api/UserManager/Login",
        method: "POST",
        contentType: "application/json",
        data: JSON.stringify(st),
        success: function (response) {           
            console.log(response);
            if (response) {
                localStorage.setItem('authToken', response);
                var roleName = GetRoleNameFromToken(response);
                RedirectToDashboard(roleName);
            } else {
                console.error("Token not found in the response");
            }
        },
        error: function (resp) {
            console.log(resp);
        }
    });
}

function GetRoleNameFromToken(token) {
    try {
        var base64Url = token.split('.')[1];
        var base64 = base64Url.replace(/-/g, '+').replace(/_/g, '/');
        var jsonPayload = decodeURIComponent(atob(base64).split('').map(function (c) {
            return '%' + ('00' + c.charCodeAt(0).toString(16)).slice(-2);
        }).join(''));

        var payloadObj = JSON.parse(jsonPayload);
        var role = payloadObj["http://schemas.microsoft.com/ws/2008/06/identity/claims/role"];
        console.log(role);
        return role;
    } catch (error) {
        console.error("Error extracting role name from token:", error);
        return null;
    }
}


//Based on Role it Redirect to that Dashboard
    function RedirectToDashboard(roleName)
    {
        var roleMappings = {
            "HR":       { area: "HR", controller: "HR", action: "HRDashboard" },
            "Admin":    { area: "Admin", controller: "Admin", action: "Index" },
            "Employee": { area: "Employees", controller: "Employee", action: "Index" },
            "Client":   { area: "Clients", controller: "Client", action: "ClientDashboard" }
        };

        if (roleName in roleMappings) {
            var mapping = roleMappings[roleName];
            var url = "/" + mapping.area + "/" + mapping.controller + "/" + mapping.action;
            window.location.href = url;
        } else {
            window.location.href = "/Home/Login";
        }
    }


// Fetch Employee Data

function fetchEmployeeData() {    
    var token = localStorage.getItem("authToken");
    var roleName = GetRoleNameFromToken(token);
    if (roleName == "Employee")
    {
        var userId = GetUserIdFromToken(token);
        debugger;
        var apiUrl = 'https://localhost:7279/api/Employee/' + userId;
        $.ajax({
            url: apiUrl,
            type: 'GET',
            beforeSend: function (xhr) {
                xhr.setRequestHeader('Authorization', 'Bearer ' + token); // Add token as Authorization header
            },
            dataType: 'json',
            contentType:'application/json;charset=utf-8',
            success: function (result, textStatus, xhr) {
                debugger;
                console.log(result);
                if (xhr.status == 200 && result) {
                    $('#Id').val(result.id);
                    $("#firstName").val(result.firstName);
                    $('#lastName').val(result.lastName);
                    $('#education').val(result.education);
                    $('#profilePicInput').val(result.profilePicture);
                    $('#state').val(result.state);
                    $('#createdOn').val(result.createdOn);
                    $('#modifiedOn').val(result.modifiedOn);
                    $('#email').val(result.email);
                    $('#clientId').val(result.clientId);
                    $('#postcode').val(result.postcode);
                    $('#username').val(result.username);
                    $('#middleName').val(result.middleName);
                    $('#mobileNo').val(result.mobileNo);
                    $('#designation').val(result.designation);
                    $('#address').val(result.address);
                    $('#country').val(result.country);
                    $('#createdBy').val(result.createdBy);
                    $('#modifiedBy').val(result.modifiedBy);
                    $('#passwordInput').val(result.password);
                    $('#roleId').val(result.roleId);
                    $('#isDeleted').val(result.isDeleted);                  


                    // Function to generate profile URL
                    var profileUrl = generateProfileUrl(); 
                    if (profileUrl) {
                        window.location.href = profileUrl;
                    } else {
                        console.error('Profile URL is not available.');
                    }
                }
                else if (xhr.status === 404) {
                    console.log('Employee not found');
                }
                else {
                    console.log('Unexpected status code:', xhr.status);
                }
            },
            error: function (err) {
                alert('Error fetching data');
            }
        });
    }
    else {
        console.log('Unexpected status code:', xhr.status);
    }
}

//fetch userid from localStorage
    function GetUserIdFromToken(token)
    {
        try {
            var base64Url = token.split('.')[1];
            var base64 = base64Url.replace(/-/g, '+').replace(/_/g, '/');
            var jsonPayload = decodeURIComponent(atob(base64).split('').map(function (c) {
                return '%' + ('00' + c.charCodeAt(0).toString(16)).slice(-2);
            }).join(''));

            var payloadObj = JSON.parse(jsonPayload);
            var userId = payloadObj["UserId"];
           // var userId = payloadObj["http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier"];
            console.log(userId);
            return userId;
        } catch (error) {
            console.error("Error extracting user ID from token:", error);
            return null;
        }
}

        function generateProfileUrl()
        {   
            return 'https://localhost:44341/Employees/Profile/Index';
        }
    function UpdateEmployee()
    {
       
            var formData = new FormData($('#employeeForm')[0]);
            debugger;
            $.ajax({
                url: 'https://localhost:7279/api/Employee',
                type: 'Put',
                data: formData,
                contentType: false,
                processData: false,
                success: function (response) {
                    debugger;
                    if (response.success) {
                        alert('Employee updated successfully');
                    }
                    else {
                        alert('Error updating employee');
                    }
                },
                error: function (xhr, status, error) {
                    console.error(xhr.responseText);
                    alert('An error occurred while updating employee');
                }
            });
        }
