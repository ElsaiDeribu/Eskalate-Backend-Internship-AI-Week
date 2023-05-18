using MediatR;
using Application.Responses;

namespace Application.Features.Task.CQRS.Commands
{
    public class DeleteTaskCommand : IRequest<Result<int>>
    {
        public int Id { get; set; }
    }
}
