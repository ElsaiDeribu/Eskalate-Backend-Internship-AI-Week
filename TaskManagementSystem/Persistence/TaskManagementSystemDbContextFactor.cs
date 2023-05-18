

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace Persistence
{
    public class TaskManagementSystemDbContextFactor : IDesignTimeDbContextFactory<TaskManagementSystemDbContext>
    {
        public TaskManagementSystemDbContext CreateDbContext(string[] args)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            var builder = new DbContextOptionsBuilder<TaskManagementSystemDbContext>();
            var connectionString = configuration.GetConnectionString("TaskManagementSystemConnectionString");

            builder.UseNpgsql(connectionString);

            return new TaskManagementSystemDbContext(builder.Options);
        }
    }
}