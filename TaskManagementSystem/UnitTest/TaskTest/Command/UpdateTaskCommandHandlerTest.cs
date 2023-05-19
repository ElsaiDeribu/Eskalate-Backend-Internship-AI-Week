
using Application.Contracts.Persistence;
using Application.Features.Task.CQRS.Commands;
using Application.Features.Task.CQRS.Handlers;
using Application.Features.Task.DTOs;
using Application.Profiles;
using Application.Responses;
using AutoMapper;
using MediatR;
using Moq;
using Shouldly;
using UnitTest.Mocks;

namespace UnitTest.TaskTest.Command
{
    public class UpdateTaskCommandHandlerTest
    {
        private readonly IMapper _mapper;
        private readonly Mock<IUnitOfWork> _mockRepo;
        private readonly UpdateTaskDto _taskDto;
        private readonly UpdateTaskCommandHandler _handler;

        public UpdateTaskCommandHandlerTest()
        {
            _mockRepo = MockUnitOfWork.GetUnitOfWork();

            var mapperConfig = new MapperConfiguration(c =>
            {
                c.AddProfile<MappingProfile>();
            });
            _mapper = mapperConfig.CreateMapper();

            _taskDto = new UpdateTaskDto
            {
                Id = 1,
                Title = "Task update",
                Description = "Description update",
                StartDate = DateTime.Now,
                EndDate = DateTime.Now.AddDays(1),
                Status = false
            };

            _handler = new UpdateTaskCommandHandler(_mockRepo.Object, _mapper);
        }

        [Fact]
        

        public async Task UpdateTaskCommandHandler_Success()
        {
            var result = await _handler.Handle(new UpdateTaskCommand { TaskDto = _taskDto }, CancellationToken.None);
            result.ShouldBeOfType<Result<Unit>>();

            var task = await _mockRepo.Object.TaskRepository.Get(_taskDto.Id);
            task.Title.ShouldBe(_taskDto.Title);
            task.Description.ShouldBe(_taskDto.Description);
            task.StartDate.Equals(_taskDto.StartDate);
            task.EndDate.Equals(_taskDto.EndDate);
            task.Status.Equals(_taskDto.Status);

        }

        [Fact]

        public async Task UpdateTaskCommandHandler_Fail()
        {
            _taskDto.Id = 3;
            var result = await _handler.Handle(new UpdateTaskCommand { TaskDto = _taskDto }, CancellationToken.None);
            result.ShouldBeNull();

            var tasks = await _mockRepo.Object.TaskRepository.GetAll();
            tasks.Count.ShouldBe(2);
        }



    }
}