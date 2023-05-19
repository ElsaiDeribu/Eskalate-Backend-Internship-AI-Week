

using Application.Contracts.Persistence;
using Application.Features.Task.CQRS.Commands;
using Application.Features.Task.CQRS.Handlers;
using Application.Features.Task.DTOs;
using Application.Profiles;
using Application.Responses;
using AutoMapper;
using Moq;
using Shouldly;
using UnitTest.Mocks;

namespace UnitTest.TaskTest.Command
{
    public class CreateTaskCommandHandlerTest
    {
        private readonly IMapper _mapper;
        private readonly Mock<IUnitOfWork> _mockRepo;
        private readonly CreateTaskDto _taskDto;

        private readonly CreateTaskCommandHandler _handler;

        public CreateTaskCommandHandlerTest()
        {
            _mockRepo = MockUnitOfWork.GetUnitOfWork();

            var mapperConfig = new MapperConfiguration(c =>
            {
                c.AddProfile<MappingProfile>();
            });
            _mapper = mapperConfig.CreateMapper();

            _taskDto = new CreateTaskDto
            {
                Title = "Task 3",
                Description = "Task 3 Description",
                StartDate = DateTime.Now,
                EndDate = DateTime.Now.AddDays(1),
                Status = false
            };

            _handler = new CreateTaskCommandHandler(_mockRepo.Object, _mapper);
        }

        [Fact]

        public async Task CreateTaskCommandHandler_Success()
        {
            var result = await _handler.Handle(new CreateTaskCommand { TaskDto = _taskDto }, CancellationToken.None);
            result.ShouldBeOfType<Result<int>>();

            var tasks = await _mockRepo.Object.TaskRepository.GetAll();
            tasks.Count.ShouldBe(3);

        }

        [Fact]

        public async Task CreateTaskCommandHandler_Fail()
        {
            _taskDto.Title = null;
            var result = await _handler.Handle(new CreateTaskCommand { TaskDto = _taskDto }, CancellationToken.None);
            result.ShouldBeOfType<Result<int>>();
            result.Success.ShouldBeFalse();
            result.Errors.ShouldNotBeEmpty();

            var tasks = await _mockRepo.Object.TaskRepository.GetAll();
            tasks.Count.ShouldBe(2);
        }

    }
}