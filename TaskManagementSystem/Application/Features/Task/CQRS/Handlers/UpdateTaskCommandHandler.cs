﻿using Application.Contracts.Persistence;
using Application.Features.Task.CQRS.Commands;
using Application.Features.Task.DTOs.Validators;
using Application.Responses;
using AutoMapper;
using MediatR;

namespace Application.Features.Task.CQRS.Handlers
{
    public class UpdateTaskCommandHandler : IRequestHandler<UpdateTaskCommand, Result<Unit>>
    {

        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UpdateTaskCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Result<Unit>> Handle(UpdateTaskCommand request, CancellationToken cancellationToken)
        {
            var response = new Result<Unit>();

            var validator = new UpdateTaskDtoValidator();
            var validationResult = await validator.ValidateAsync(request.TaskDto);

            if (validationResult.IsValid == false)
            {
                response.Success = false;
                response.Message = "Update Failed";
                response.Errors = validationResult.Errors.Select(q => q.ErrorMessage).ToList();

            }
            else
            {

                var task = await _unitOfWork.TaskRepository.Get(request.TaskDto.Id);

                if (task == null)
                {
                    return null;
                }
                _mapper.Map(request.TaskDto, task);

                await _unitOfWork.TaskRepository.Update(task);
                if (await _unitOfWork.Save() > 0)
                {
                    response.Success = true;
                    response.Message = "Updated Successful";
                    response.Value = Unit.Value;
                }
                else
                {
                    response.Success = false;
                    response.Message = "Update Failed";
                }


            }

            return response;
        }
    }
}