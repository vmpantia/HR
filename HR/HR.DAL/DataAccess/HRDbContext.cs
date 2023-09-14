using HR.DAL.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace HR.DAL.DataAccess
{
    public class HRDbContext : DbContext
    {
        public HRDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Position> Positions { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Address> Addresses { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            #region Employee Relations
            modelBuilder.Entity<Employee>()
                .HasMany(data => data.Contacts)
                .WithOne(data => data.Employee)
                .HasForeignKey(data => data.EmployeeId);

            modelBuilder.Entity<Employee>()
                .HasMany(data => data.Addresses)
                .WithOne(data => data.Employee)
                .HasForeignKey(data => data.EmployeeId);

            modelBuilder.Entity<Employee>()
                .HasOne(data => data.Department)
                .WithMany(data => data.Employees)
                .HasForeignKey(data => data.DepartmentId);

            modelBuilder.Entity<Employee>()
                .HasOne(data => data.Position)
                .WithMany(data => data.Employees)
                .HasForeignKey(data => data.PositionId);
            #endregion

            #region Address Relation
            modelBuilder.Entity<Address>()
                .HasOne(data => data.Employee)
                .WithMany(data => data.Addresses)
                .HasForeignKey(data => data.EmployeeId);
            #endregion

            #region Contact Relation
            modelBuilder.Entity<Contact>()
                .HasOne(data => data.Employee)
                .WithMany(data => data.Contacts)
                .HasForeignKey(data => data.EmployeeId);
            #endregion

            #region Department Relation
            modelBuilder.Entity<Department>()
                .HasMany(data => data.Employees)
                .WithOne(data => data.Department)
                .HasForeignKey(data => data.DepartmentId);
            #endregion

            #region Position Relation
            modelBuilder.Entity<Position>()
                .HasMany(data => data.Employees)
                .WithOne(data => data.Position)
                .HasForeignKey(data => data.PositionId);
            #endregion
        }
    }
}
