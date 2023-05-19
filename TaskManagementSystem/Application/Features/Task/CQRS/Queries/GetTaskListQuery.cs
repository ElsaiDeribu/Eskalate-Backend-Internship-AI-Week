using Application.Features.Task.DTOs;
using MediatR;
using Application.Responses;
namespace Application.Features.Task.CQRS.Queries
{
    public class GetTaskListQuery : IRequest<Result<List<TaskDto>>>
    {
    }
}
