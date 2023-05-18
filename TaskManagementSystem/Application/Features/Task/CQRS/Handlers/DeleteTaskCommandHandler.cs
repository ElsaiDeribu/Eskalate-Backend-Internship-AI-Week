

using Application.Features.Task.CQRS.Commands;
using Application.Contracts.Persistence;
using Application.Responses;
using MediatR;
using AutoMapper;

namespace Application.Features.Task.CQRS.Handlers
{
    public class DeleteTaskCommandHandler : IRequestHandler<DeleteTaskCommand, Result<int>>
    {

        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public DeleteTaskCommandHandler(IUnitOfWork unitOfWorking, IMapper mapper)
        {
            _unitOfWork = unitOfWorking;
            _mapper = mapper;
        }


        public async Task<Result<int>> Handle(DeleteTaskCommand request, CancellationToken cancellationToken)
        {
            var response = new Result<int>();

            var task = await _unitOfWork.TaskRepository.Get(request.Id);


            if (task == null)
            {
                response.Success = false;
                response.Message = "Delete Failed";
            }
            else
            {
                await _unitOfWork.TaskRepository.Delete(task);

                if (await _unitOfWork.Save() > 0)
                {
                    response.Success = true;
                    response.Message = "Delete Successful";
                    response.Value = task.Id;
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
