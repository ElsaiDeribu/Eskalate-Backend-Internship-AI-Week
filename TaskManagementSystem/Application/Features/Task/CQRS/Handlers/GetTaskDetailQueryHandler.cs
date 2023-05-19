
using Application.Contracts.Persistence;
using Application.Features.Task.CQRS.Queries;
using Application.Features.Task.DTOs;
using Application.Responses;
using AutoMapper;
using MediatR;

namespace Application.Features.Task.CQRS.Handlers
{
    public class GetTaskDetailQueryHandler : IRequestHandler<GetTaskDetailQuery, Result<TaskDto>>
    {

        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetTaskDetailQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;

        }
        public async Task<Result<TaskDto>> Handle(GetTaskDetailQuery request, CancellationToken cancellationToken)
        {
            var response = new Result<TaskDto>();
            var task = await _unitOfWork.TaskRepository.Get(request.Id);
            response.Success = true;
            response.Message = "Fetch Successful";
            response.Value = _mapper.Map<TaskDto>(task);
            return response;
        }
    }
}
