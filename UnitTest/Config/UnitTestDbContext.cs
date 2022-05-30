using Microsoft.EntityFrameworkCore;
using Persistence.Database;

namespace UnitTest.Config
{
    public static class UnitTestDbContext
    {
        public static ApplicationDbContext Get()
        {

            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: $"UnitTestDB")
                .EnableSensitiveDataLogging()
                .Options;

            return new ApplicationDbContext(options);
        }
    }
}
