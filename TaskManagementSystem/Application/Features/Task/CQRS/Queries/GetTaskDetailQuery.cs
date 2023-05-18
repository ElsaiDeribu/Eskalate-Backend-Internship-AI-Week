using Application.Features.Task.DTOs;
using MediatR;
using Application.Responses;

namespace Application.Features.Task.CQRS.Queries
{
    public class GetTaskDetailQuery : IRequest<Result<TaskDto>>
    {
        public int Id { get; set; }
    }
}
