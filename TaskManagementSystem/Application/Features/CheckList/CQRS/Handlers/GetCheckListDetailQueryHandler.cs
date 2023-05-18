
using Application.Contracts.Persistence;
using Application.Features.CheckList.CQRS.Queries;
using Application.Features.CheckList.DTOs;
using Application.Responses;
using AutoMapper;
using MediatR;

namespace Application.Features.CheckList.CQRS.Handlers
{
    public class GetCheckListDetailQueryHandler : IRequestHandler<GetCheckListDetailQuery, Result<CheckListDto>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetCheckListDetailQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;

        }
        public async Task<Result<CheckListDto>> Handle(GetCheckListDetailQuery request, CancellationToken cancellationToken)
        {
            var response = new Result<CheckListDto>();
            var checkList = await _unitOfWork.CheckListRepository.Get(request.Id);
            response.Success = true;
            response.Message = "Fetch Successful";
            response.Value = _mapper.Map<CheckListDto>(checkList);

            return response;
        }
    }
}
