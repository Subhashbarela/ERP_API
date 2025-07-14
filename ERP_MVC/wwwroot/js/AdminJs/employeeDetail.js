function showEmployeeDetail(employee) {
    var html = `
        <table class="table table-striped">
            <tr><th>Id</th><td>${employee.id}</td></tr>
            <tr><th>Username</th><td>${employee.username}</td></tr>
            <tr><th>FirstName</th><td>${employee.firstName}</td></tr>
            <tr><th>MiddleName</th><td>${employee.middleName}</td></tr>
            <tr><th>LastName</th><td>${employee.lastName}</td></tr>
            <tr><th>MobileNo</th><td>${employee.mobileNo}</td></tr>
            <tr><th>Education</th><td>${employee.education}</td></tr>
            <tr><th>Designation</th><td>${employee.designation}</td></tr>
            <tr><th>ProfilePicture</th><td><img src="${employee.profilePicture}" alt="Profile Picture" width="100" height="100"></td></tr>
            <tr><th>Address</th><td>${employee.address}</td></tr>
            <tr><th>State</th><td>${employee.state}</td></tr>
            <tr><th>Country</th><td>${employee.country}</td></tr>
            <tr><th>Email</th><td>${employee.email}</td></tr>
            <tr><th>Password</th><td>${employee.password}</td></tr>
            <tr><th>Postcode</th><td>${employee.postcode}</td></tr>
            <tr><th>ClientId</th><td>${employee.clientId}</td></tr>
            <tr><th>RoleId</th><td>${employee.roleId}</td></tr>
            <tr><th>CreatedOn</th><td>${employee.createdOn}</td></tr>
            <tr><th>CreatedBy</th><td>${employee.createdBy}</td></tr>
            <tr><th>ModifiedOn</th><td>${employee.modifiedOn}</td></tr>
            <tr><th>ModifiedBy</th><td>${employee.modifiedBy}</td></tr>
            <tr><th>IsDeleted</th><td>${employee.isDeleted}</td></tr>
        </table>
    `;
    $('#employee-detail-body').html(html);
    var modal = new bootstrap.Modal(document.getElementById('employeeDetailModal'));
    modal.show();
}