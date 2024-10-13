using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepoLayer.Entity
{
    public class EmployeeClient
    {
        public int EmployeeId { get; set; }
        public Employee? Employee { get; set; }

        public int ClientId { get; set; }
        public Client? Client { get; set; }
    }

}
