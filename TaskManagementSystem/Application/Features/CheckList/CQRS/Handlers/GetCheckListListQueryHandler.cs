

using Application.Contracts.Persistence;
using Application.Features.CheckList.CQRS.Queries;
using Application.Features.CheckList.DTOs;
using Application.Responses;
using AutoMapper;
using MediatR;

namespace Application.Features.CheckList.CQRS.Handlers
{
    public class GetCheckListListQueryHandler : IRequestHandler<GetCheckListListQuery, Result<List<CheckListDto>>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public GetCheckListListQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;

        }
        public async Task<Result<List<CheckListDto>>> Handle(GetCheckListListQuery request, CancellationToken cancellationToken)
        {
            var response = new Result<List<CheckListDto>>();
            var checkLists = await _unitOfWork.CheckListRepository.GetAll();

            response.Success = true;
            response.Message = "Fetch Successful";
            response.Value = _mapper.Map<List<CheckListDto>>(checkLists);

            return response;
        }
    }
}
