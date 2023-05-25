using Application.Contracts.Persistence;
using AutoMapper;

namespace Persistence.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly TaskManagementSystemDbContext _dbContext;
        private ITaskRepository _taskRepository;
        private ICheckListRepository _checkListRepository;

        private IMapper _mapper;
        public UnitOfWork(TaskManagementSystemDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }


        public ITaskRepository TaskRepository
        {
            get
            {
                if (_taskRepository == null)
                {
                    _taskRepository = new TaskRepository(_dbContext, _mapper);
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