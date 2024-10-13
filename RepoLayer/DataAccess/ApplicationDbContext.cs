using RepoLayer.Entity.AuthEntity;
using RepoLayer.Entity;
using Microsoft.EntityFrameworkCore;

namespace RepoLayer.DataAccess
{
    using Microsoft.EntityFrameworkCore;

    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        // Define your DbSets
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Admin> Admins { get; set; }
        public DbSet<HRManager> HRManagers { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<LeaveDetails> LeaveDetails { get; set; }
        public DbSet<LeaveAllocation> LeaveAllocations { get; set; }
        public DbSet<Role> Roles { get; set; }

        // Optionally, override OnModelCreating to configure entity relationships
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Example of configuring relationships, constraints, etc.
            // modelBuilder.Entity<Employee>()
            //     .HasKey(e => e.EmployeeId);

            // modelBuilder.Entity<Employee>()
            //     .HasMany(e => e.LeaveDetails)
            //     .WithOne(ld => ld.Employee)
            //     .HasForeignKey(ld => ld.EmployeeId);

            base.OnModelCreating(modelBuilder);
        }
    }

}
