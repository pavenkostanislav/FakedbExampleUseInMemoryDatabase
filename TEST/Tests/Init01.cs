using Xunit;
using System.Linq;
using TEST.CoreContext.Inits;
using TEST.TestContext.Models;
using TEST.TestContext.Inits;
using Microsoft.EntityFrameworkCore;
using System;

namespace TEST.Tests
{
    public class Init01
    {
        [Fact(DisplayName = "Init01 MemoryTesting")]
        public void Init01_MemoryTesting()
        {
            using (var context = InitTestDbContext.CreateTestDbContext("OrderByListTest01_MemoryTesting"))
            {
                var count = 5;
                context.CreateTestModels(count);

                var testModel = context.Set<TestModel>()
                    .Include(i => i.User)
                    .Include(i => i.UserNull)
                    .Include(i => i.Employee)
                    .Include(i => i.EmployeeNull)
                    .FirstOrDefault();
                var user = context.Set<User>().Find(testModel.UserId);
                Assert.Equal(testModel.User, user);

                ArgumentNullException exForUserNull = Assert.Throws<ArgumentNullException> (() => context.Set<User>().Find(testModel.UserNullId));
                Assert.NotNull(exForUserNull.Message);
                Assert.Equal(testModel.UserNull, null);

                var employee = context.Set<Employee>().Find(testModel.EmployeeId);
                Assert.Equal(testModel.Employee, employee);

                ArgumentNullException exForEmployeeNull = Assert.Throws<ArgumentNullException>(() => context.Set<Employee>().Find(testModel.EmployeeNullId));
                Assert.NotNull(exForEmployeeNull.Message);
                Assert.Equal(testModel.EmployeeNull, null);
            }
        }
    }
}
