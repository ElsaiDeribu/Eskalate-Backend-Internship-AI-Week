

using Application.Contracts.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Persistence.Repositories;

namespace Persistence
{
    public static class PersistenceServicesRegistration
    {
        public static IServiceCollection ConfigurePersistenceServices(this IServiceCollection services, IConfiguration configuration)
        {


            services.AddEntityFrameworkNpgsql()
            .AddDbContext<TaskManagementSystemDbContext>(opt =>
            opt.UseNpgsql(configuration.GetConnectionString("TaskManagementSystemConnectionString")));


            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<ITaskRepository, TaskRepository>();
            services.AddScoped<ICheckListRepository, CheckListRepository>();

            return services;

        }
    }
}