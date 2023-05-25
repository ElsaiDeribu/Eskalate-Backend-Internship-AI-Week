using Application.Contracts.Identity;
using Application.Contracts.Persistence;
using Application.Features.Task.CQRS.Commands;
using Application.Features.Task.DTOs.Validators;
using Application.Responses;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.Task.CQRS.Handlers
{
    public class CreateTaskCommandHandler : IRequestHandler<CreateTaskCommand, Result<int>>
    {

        private readonly IUnitOfWork _unitOfWork;

        private readonly IMapper _mapper;

        private readonly IUserAccessor _userAccessor;
        private readonly UserManager<Domain.User> _userManager;

        public CreateTaskCommandHandler(IUnitOfWork unitOfWork, IMapper mapper, IUserAccessor userAccessor, UserManager<Domain.User> userManager)
        {
            _userAccessor = userAccessor;
            _userManager = userManager;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }



        public async Task<Result<int>> Handle(CreateTaskCommand request, CancellationToken cancellationToken)
        {

            var user = await _userManager.Users.FirstOrDefaultAsync(x =>
            x.UserName == _userAccessor.GetUserName());


            var response = new Result<int>();
            var validator = new CreateTaskDtoValidator();
            var validationResult = validator.Validate(request.TaskDto);

            if (validationResult.IsValid == false)
            {
                response.Success = false;
                response.Message = "Creation Failed";
                response.Errors = validationResult.Errors.Select(q => q.ErrorMessage).ToList();
            }

            else
            {
                var task = _mapper.Map<Domain.Task>(request.TaskDto);
                task.Owner = user;

                task = await _unitOfWork.TaskRepository.Add(task);


                if (await _unitOfWork.Save() > 0)
                {
                    response.Success = true;
                    response.Message = "Creation Successful";
                    response.Value = task.Id;
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
