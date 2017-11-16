

using Microsoft.EntityFrameworkCore;
using TEST.TestContext.Inits;
using TEST.TestContext.Models;

namespace TEST.TestContext
{
    public class TestDbContext : DbContext
    {
        public TestDbContext(DbContextOptions<TestDbContext> options)
        : base(options)
        {
        }

        public DbSet<TestModel> TableModelTests { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.AddTableModel();
            modelBuilder.AddUser();
            modelBuilder.AddEmployee();
        }
    }
}
