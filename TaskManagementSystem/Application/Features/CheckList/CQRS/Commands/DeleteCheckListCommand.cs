

using Application.Responses;
using MediatR;

namespace Application.Features.CheckList.CQRS.Commands
{
    public class DeleteCheckListCommand : IRequest<Result<int>>
    {
        public int Id { get; set; }
    }
}
