using DbCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
namespace DbCore;

public class DbCoreContextFactory : IDesignTimeDbContextFactory<DbCoreContext>
{
   
        public DbCoreContext CreateDbContext(string[] args)
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", true)
                .AddEnvironmentVariables()
                .AddCommandLine(args)
                .Build();

            var optionsBuilder = new DbContextOptionsBuilder<DbCoreContext>();
            optionsBuilder.UseSqlServer(configuration.GetValue<string>("ConnectionStrings:DefaultConnection"));
            return new DbCoreContext(optionsBuilder.Options);
        }
}