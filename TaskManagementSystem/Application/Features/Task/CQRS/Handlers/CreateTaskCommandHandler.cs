using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Contracts.Persistence;
using Application.Features.Task.CQRS.Commands;
using Application.Features.Task.DTOs.Validators;
using Application.Responses;
using AutoMapper;
using MediatR;

namespace Application.Features.Task.CQRS.Handlers
{
    public class CreateTaskCommandHandler : IRequestHandler<CreateTaskCommand, Result<int>>
    {

        private readonly IUnitOfWork _unitOfWork;

        private readonly IMapper _mapper;


        public CreateTaskCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }



        public async Task<Result<int>> Handle(CreateTaskCommand request, CancellationToken cancellationToken)
        {
            var response = new Result<int>();
            var validator = new CreateTaskDtoValidator();
            var validationResult = validator.Validate(request.TaskDto);

            if (validationResult.IsValid == false)
            {
                response.Success = false;
                response.Message = "Creation Failed";
                response.Errors = validationResult.Errors.Select(q => q.ErrorMessage).ToList();
            }

            else{
                var task = _mapper.Map<Domain.Task>(request.TaskDto);

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
