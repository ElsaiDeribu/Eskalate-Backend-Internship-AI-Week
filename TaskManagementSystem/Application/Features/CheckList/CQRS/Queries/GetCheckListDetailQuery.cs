
using Application.Features.CheckList.DTOs;
using Application.Responses;
using MediatR;

namespace Application.Features.CheckList.CQRS.Queries
{
    public class GetCheckListDetailQuery : IRequest<Result<CheckListDto>>
    {
        public int Id { get; set; }
    }
}
