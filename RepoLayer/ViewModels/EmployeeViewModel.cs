﻿using RepoLayer.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepoLayer.ViewModels
{
    public class EmployeeViewModel:BaseEntity
    {
        [Required(ErrorMessage = "Username is required")]
        public string? Username { get; set; }
        [Required(ErrorMessage = "First name is required")]
        public string? FirstName { get; set; }
        public string? MiddleName { get; set; }

        [Required(ErrorMessage = "Last name is required")]
        public string? LastName { get; set; }

        [RegularExpression(@"^\d{10}$", ErrorMessage = "Mobile number must be 10 digits")]
        public string? MobileNo { get; set; }
        public string? Education { get; set; }
        public string? Designation { get; set; }
        [Required(ErrorMessage = "Profile picture is required")]
        public string? ProfilePicture { get; set; }
        public string? Address { get; set; }
        public string? State { get; set; }
        public string? Country { get; set; }
        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Invalid email address")]
        public string? Email { get; set; }
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Password is required")]
        public string? Password { get; set; }

        [RegularExpression(@"^\d{5}(?:[-\s]\d{4})?$", ErrorMessage = "Invalid postcode")]
        public string? Postcode { get; set; }
        public int ClientId { get; set; }
        public int RoleId { get; set; }

    }
}
