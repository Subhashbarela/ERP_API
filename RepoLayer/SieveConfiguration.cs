using RepoLayer.Entity;
using Sieve.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepoLayer
{
    public class SieveConfiguration : ISieveConfiguration
    {
        public void Configure(SievePropertyMapper mapper)
        {
            mapper.Property<Employee>(e => e.FirstName)
                  .CanFilter()
                  .CanSort();
            // Configure other properties as needed
        }
    }
}
