using Application.Contracts.Persistence;

namespace Persistence.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
       private readonly TaskManagementSystemDbContext _dbContext;
       private ITaskRepository _taskRepository;
       private ICheckListRepository _checkListRepository;


         public UnitOfWork(TaskManagementSystemDbContext dbContext)
         {
              _dbContext = dbContext;
         }


        public ITaskRepository TaskRepository
        {
            get
            {
                if (_taskRepository == null)
                {
                    _taskRepository = new TaskRepository(_dbContext);
                }

                return _taskRepository;
            }
        }


        public ICheckListRepository CheckListRepository
        {
            get
            {
                if (_checkListRepository == null)
                {
                    _checkListRepository = new CheckListRepository(_dbContext);
                }

                return _checkListRepository;
            }
        }

        public void Dispose()
        {
            _dbContext.Dispose();
            GC.SuppressFinalize(this);
        }

        public async Task<int> Save()
        {
              return await _dbContext.SaveChangesAsync();

        }
    }
}