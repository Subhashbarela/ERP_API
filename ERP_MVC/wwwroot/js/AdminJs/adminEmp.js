$(document).ready(function () {
    $('#ShowEmployeeList').click(function () {
        ShowEmpList();
    });
});

function populateEmployeeTable(employees) {
    debugger;
    var $tableBody = $('#emp-table');
    $tableBody.empty(); 
    employees.forEach(function (employee) {
        var $row = $('<tr>');
        $row.append($('<td>').text(employee.id));
        $row.append($('<td>').text(employee.username));
        $row.append($('<td>').text(employee.firstName));
        $row.append($('<td>').text(employee.middleName));
        $row.append($('<td>').text(employee.lastName));
        $row.append($('<td>').text(employee.mobileNo));
        $row.append($('<td>').text(employee.education));
        $row.append($('<td>').text(employee.designation));
        $row.append($('<td>').html('<img src="' + employee.profilePicture + '" alt="Profile Picture" width="50" height="50">'));
        $row.append($('<td>').text(employee.address));
        $row.append($('<td>').text(employee.state));
        $row.append($('<td>').text(employee.country));
        $row.append($('<td>').text(employee.email));
        $row.append($('<td>').text(employee.password));
        $row.append($('<td>').text(employee.postcode));
        $row.append($('<td>').text(employee.clientId));
        $row.append($('<td>').text(employee.roleId));
        $row.append($('<td>').text(employee.createdOn));
        $row.append($('<td>').text(employee.createdBy));
        $row.append($('<td>').text(employee.modifiedOn));
        $row.append($('<td>').text(employee.modifiedBy));
        $row.append($('<td>').text(employee.isDeleted));
        $row.append($('<td>').html('<button class="btn btn-primary">Edit</button> <button class="btn btn-danger">Delete</button>'));

        $tableBody.append($row);
    });
}

function ShowEmpList() {
    debugger;
    var token = localStorage.getItem("authToken");
    var roleName = GetRoleNameFromToken(token);
    if (roleName == "Admin") {

        var apiUrl = 'https://localhost:7279/api/Employee/';
        $.ajax({
            url: apiUrl,
            type: 'GET',
            beforeSend: function (xhr) {
                xhr.setRequestHeader('Authorization', 'Bearer ' + token);
            },
            dataType: 'json',
            contentType: 'application/json;charset=utf-8',
            success: function (result, textStatus, xhr)
            {
                debugger;
                if (xhr.status == 200 && result)
                {
                    populateEmployeeTable([result]); 

                } else if (xhr.status === 404) {
                    console.log('Employee not found');
                } else {
                    console.log('Unexpected status code:', xhr.status);
                }
            },
            error: function (err) {
                alert('Error fetching data');
            }
        });
    } else {
        console.log('Unexpected status code:', xhr.status);
    }
}


