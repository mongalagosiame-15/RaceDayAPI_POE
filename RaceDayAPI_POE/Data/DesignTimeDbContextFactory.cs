using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace RaceDayAPI.Data
{
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<ApplicationDbContext>
    {
        public ApplicationDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();

            // Replace with your local SQLite connection string or ensure appsettings.json has it
            optionsBuilder.UseSqlite("Data Source=raceday.db");

            return new ApplicationDbContext(optionsBuilder.Options);
        }
    }
}
