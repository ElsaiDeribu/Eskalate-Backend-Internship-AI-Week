

using Application.Features.Task.DTOs;

namespace Application.Contracts.Persistence
{
    public interface ITaskRepository : IGenericRepository<Domain.Task>
    {
        Task<IReadOnlyList<TaskDto>>GetAllTasks();
        
    }
}