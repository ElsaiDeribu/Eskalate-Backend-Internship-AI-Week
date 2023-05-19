using MediatR;
using Application.Responses;
using Application.Features.Task.DTOs;


namespace Application.Features.Task.CQRS.Commands
{
    public class UpdateTaskCommand : IRequest<Result<Unit>>
    {
        public UpdateTaskDto TaskDto { get; set; }
    }
}
