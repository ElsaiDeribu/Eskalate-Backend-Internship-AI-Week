using Application.Contracts.Persistence;

namespace Persistence.Repositories
{
    public class TaskRepository: GenericRepository<Domain.Task>, ITaskRepository
    {
        private readonly TaskManagementSystemDbContext _dbContext;
        public TaskRepository(TaskManagementSystemDbContext context) : base(context)
        {
            _dbContext = context;
            
        }
    }
}