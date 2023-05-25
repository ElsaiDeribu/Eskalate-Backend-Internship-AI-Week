
using Application.Contracts.Persistence;
using Application.Features.Task.CQRS.Queries;
using Application.Features.Task.DTOs;
using Application.Responses;
using AutoMapper;
using MediatR;

namespace Application.Features.Task.CQRS.Handlers
{
    public class GetTaskListQueryHandler : IRequestHandler<GetTaskListQuery, Result<List<TaskDto>>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetTaskListQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;

        }
        public async Task<Result<List<TaskDto>>> Handle(GetTaskListQuery request, CancellationToken cancellationToken)
        {
            
            var response = new Result<List<TaskDto>>();
            var tasks = await _unitOfWork.TaskRepository.GetAllTasks();


            response.Success = true;
            response.Message = "Fetch Success";
            response.Value = _mapper.Map<List<TaskDto>>(tasks);

            return response;
        }
    }
}
