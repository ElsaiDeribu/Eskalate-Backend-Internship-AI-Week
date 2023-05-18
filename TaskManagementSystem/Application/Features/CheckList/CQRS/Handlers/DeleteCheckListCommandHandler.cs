

using Application.Contracts.Persistence;
using Application.Features.CheckList.CQRS.Commands;
using Application.Responses;
using AutoMapper;
using MediatR;

namespace Application.Features.CheckList.CQRS.Handlers
{
    public class DeleteCheckListCommandHandler : IRequestHandler<DeleteCheckListCommand, Result<int>>
    {

        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public DeleteCheckListCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<Result<int>> Handle(DeleteCheckListCommand request, CancellationToken cancellationToken)
        {
            var response = new Result<int>();
            var checkList = await _unitOfWork.CheckListRepository.Get(request.Id);


            if (checkList is null)
            {
                response.Success = false;
                response.Message = "Delete Failed";
            }
            else
            {
                await _unitOfWork.CheckListRepository.Delete(checkList);

                if (await _unitOfWork.Save() > 0)
                {
                    response.Success = true;
                    response.Message = "Delete Successful";
                    response.Value = checkList.Id;
                }
                else
                {
                    response.Success = false;
                    response.Message = "Delete Failed";
                }
            }

            return response;

        }
    }
}
