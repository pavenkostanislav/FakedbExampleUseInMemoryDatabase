
using Microsoft.EntityFrameworkCore;
using TEST.TestContext;
using TEST.TestContext.Inits;

namespace TEST.CoreContext.Inits
{
	public static class InitTestDbContext
    {
        public static TestDbContext CreateTestDbContext(string databaseName)
        {
            var builder = new DbContextOptionsBuilder<TestDbContext>();
            builder.UseInMemoryDatabase(databaseName: databaseName);
            var options = builder.Options;

            var context = new TestDbContext(options);

            return context;
        }
        public static TestDbContext CreateSimplyInit(this TestDbContext context, int count)
        {
            return context.CreateTestUsers(count).CreateTestEmployees(count).CreateTestModels(count);
        }
    }
}
