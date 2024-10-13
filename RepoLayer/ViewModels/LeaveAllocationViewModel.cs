using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RepoLayer.Entity;

namespace RepoLayer.ViewModels
{
    public class LeaveAllocationViewModel
    {
        [Key]
        public int LeaveAllocationId { get; set; }

        [ForeignKey("Employee")]
        public int EmployeeId { get; set; }
        public int CasualLeave { get; set; }
        public int SickLeave { get; set; }
        public int MaternityLeave { get; set; }
        public int PaternityLeave { get; set; }
        public int TotalLeave { get; set; }
        public LeaveAllocationViewModel()
        {
            CasualLeave = 0;
            SickLeave = 0;
            MaternityLeave = 0;
            PaternityLeave = 0;
            TotalLeave = CasualLeave + SickLeave + MaternityLeave + PaternityLeave;
        }
    }
}
