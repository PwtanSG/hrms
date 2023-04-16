using HRMS.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace HRMS.Data
{
    public class HRMSDbContext : DbContext
    {
        public HRMSDbContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Employee> Employees { get; set; }
    }
}
