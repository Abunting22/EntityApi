using Microsoft.EntityFrameworkCore;

namespace DemoAPI.Models
{
    public class EmployeeContext : DbContext //Required in Entity; Context object allows querying and saving data
    {
        public EmployeeContext(DbContextOptions<EmployeeContext> options)
            : base(options) 
        {
            Database.EnsureCreated(); //Db created through DbContext
        }

        public DbSet<Employee> Employees { get; set; }
    }
}
