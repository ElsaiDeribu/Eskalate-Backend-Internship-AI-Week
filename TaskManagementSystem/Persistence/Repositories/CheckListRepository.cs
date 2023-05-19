using Application.Contracts.Persistence;
using Domain;

namespace Persistence.Repositories
{
    public class CheckListRepository : GenericRepository<CheckList>, ICheckListRepository
    {
        private readonly TaskManagementSystemDbContext _dbContext;
        public CheckListRepository(TaskManagementSystemDbContext context) : base(context)
        {
            _dbContext = context;
        }
    }
}