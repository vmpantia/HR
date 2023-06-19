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
    }
}
