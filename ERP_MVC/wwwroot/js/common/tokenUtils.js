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

