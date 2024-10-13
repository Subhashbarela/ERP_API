using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RepoLayer.Entity.Enum;
using RepoLayer.Entity;

namespace RepoLayer.ViewModels
{
    public class LeaveDetailsViewModel
    {
        [Key]
        public int LeaveDetailsID { get; set; }       
        [Required]
        [EnumDataType(typeof(LeaveTypeEnum))]
        public LeaveTypeEnum LeaveTypeEnum { get; set; }
        [Required]
        [DataType(DataType.Date)]
        public DateTime StartDate { get; set; }
        [Required]
        [DataType(DataType.Date)]
        public DateTime EndDate { get; set; }
        public int NoOfDays { get; set; }
        public string? Reason { get; set; }
        public string? AdminStatus { get; set; } = "Pending";
        public string? HRStatus { get; set; } = "Pending";
        [ForeignKey("Employee")]
        public int EmployeeID { get; set; }
        public int RoleId { get; set; }

    }   
}
