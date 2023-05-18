
using Application.Features.CheckList.DTOs;
using Application.Responses;
using MediatR;

namespace Application.Features.CheckList.CQRS.Commands
{
    public class CreateCheckListCommand : IRequest<Result<int>>
    {
        public CreateCheckListDto CheckListDto { get; set; }
    }
}
