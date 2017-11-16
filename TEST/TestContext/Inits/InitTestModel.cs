using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using TEST.TestContext.Models;

namespace TEST.TestContext.Inits

{
	public static class InitTestModel
    {
        public static TestDbContext CreateTestModels(this TestDbContext context, int count)
        {
            context.CreateTestUsers(5).CreateTestEmployees(5);
            for (var i = 0; i < count; i++)
            {
                var model = InitTestModel.DbLoad(i);
                model = context.Add(model).Entity;
            }
            context.SaveChanges();
            return context;
        }
        public static System.Collections.Generic.List<TestModel> CreateTableModels(int count = 5)
        {
            var listTableModelTest = new System.Collections.Generic.List<TestModel>();
            for (var i = 0; i <= count; i++)
            {
                var tableTest = SimplyLoad(i);
                listTableModelTest.Add(tableTest);
            }
            return listTableModelTest;
        }

        public static TestModel SimplyLoad(int i)
        {
            var rand = new Random();
            return new TestModel
            {
                Id = i,
                Test = $"table test text {i.ToString()}",
                Date = DateTime.Now.AddDays(i),
                UserId = rand.Next(1, i > 0 ? i : 1),
                EmployeeId = rand.Next(1, i > 0 ? i : 1),
                User = InitUserTest.Load(i),
                IsBool = true,
                Decimal = (300.5m * i)
            };
        }

        public static TestModel DbLoad(int i)
        {
            var rand = new Random();
            return new TestModel
            {
                Test = $"table test text {i.ToString()}",
                Date = DateTime.Now.AddDays(i),
                UserId = rand.Next(1, i > 0 ? i : 1),
                EmployeeId = rand.Next(1, i > 0 ? i : 1),
                IsBool = true,
                Decimal = (300.5m * i)
            };
        }

        public static void AddTableModel(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TestModel>(entity =>
            {
                entity.ToTable("TableModelTest", "dbo");
                entity.HasKey(p => p.Id);
                entity.Property(e => e.Test);
                entity.Property(e => e.Date);
                entity.Property(e => e.DateNull).IsRequired(false);
                entity.Property(e => e.UserId);
                entity.Property(e => e.UserNullId).IsRequired(false);
                entity.Property(e => e.IsBool);
                entity.Property(e => e.IsBoolNull).IsRequired(false);
                entity.Property(e => e.Decimal);
                entity.Property(e => e.DecimalNull).IsRequired(false);
                entity.HasOne(p => p.User).WithMany().HasForeignKey("UserId").OnDelete(DeleteBehavior.Restrict);
                entity.HasOne(p => p.UserNull).WithMany().HasForeignKey("UserNullId").OnDelete(DeleteBehavior.Restrict).IsRequired(false); 
                entity.Property(p => p.DisplayName).HasComputedColumnSql("[Test]");
                entity.Property(e => e.DecimalNull).HasColumnName("DecimalNull").IsRequired(false);
                entity.Property(p => p.CreatedBy).HasDefaultValueSql("suser_sname()");
                entity.Property(p => p.CreatedDate).HasDefaultValueSql("sysdatetime()");
                entity.Property(p => p.LastUpdatedBy).HasDefaultValueSql("suser_sname()");
                entity.Property(p => p.LastUpdatedDate).HasDefaultValueSql("sysdatetime()");
            });
        }
    }
}
