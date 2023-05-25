using Application.Contracts.Persistence;
using AutoMapper.QueryableExtensions;
using Application.Features.Task.DTOs;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System.Threading;

namespace Persistence.Repositories
{
    public class TaskRepository : GenericRepository<Domain.Task>, ITaskRepository
    {
        private readonly TaskManagementSystemDbContext _dbContext;
        private readonly IMapper _mapper;

        public TaskRepository(TaskManagementSystemDbContext context, IMapper mapper) : base(context)
        {
            _dbContext = context;
            _mapper = mapper;
        }

        public async Task<IReadOnlyList<TaskDto>> GetAllTasks()
        {

            return await _dbContext.Tasks.ProjectTo<TaskDto>(_mapper.ConfigurationProvider).ToListAsync();  

        }
    }
}