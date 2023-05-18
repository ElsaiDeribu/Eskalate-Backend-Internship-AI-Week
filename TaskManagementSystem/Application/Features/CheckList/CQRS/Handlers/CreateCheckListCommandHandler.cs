

using Application.Contracts.Persistence;
using Application.Features.CheckList.CQRS.Commands;
using Application.Features.CheckList.DTOs.Validators;
using Application.Responses;
using AutoMapper;
using MediatR;
using Domain;
namespace Application.Features.CheckList.CQRS.Handlers
{
    public class CreateCheckListCommandHandler : IRequestHandler<CreateCheckListCommand, Result<int>>
    {

        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateCheckListCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Result<int>> Handle(CreateCheckListCommand request, CancellationToken cancellationToken)
        {
            var response = new Result<int>();
            var validator = new CreateCheckListDtoValidator();
            var validationResult = validator.Validate(request.CheckListDto);


            if (validationResult.IsValid == false)
            {
                response.Success = false;
                response.Message = "Creation Failed";
                response.Errors = validationResult.Errors.Select(q => q.ErrorMessage).ToList();
            }

            else
            {
                var checkList = _mapper.Map<Domain.CheckList>(request.CheckListDto);

                checkList = await _unitOfWork.CheckListRepository.Add(checkList);
                if (await _unitOfWork.Save() > 0)
                {
                    response.Success = true;
                    response.Message = "Creation Successful";
                    response.Value = checkList.Id;
                }
                else
                {
                    response.Success = false;
                    response.Message = "Creation Failed";

                }


            }
            return response;
        }
    }
}
