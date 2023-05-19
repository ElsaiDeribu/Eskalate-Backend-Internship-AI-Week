

using Application.Contracts.Persistence;
using Application.Features.Task.CQRS.Commands;
using Application.Features.Task.CQRS.Handlers;
using Application.Profiles;
using Application.Responses;
using AutoMapper;
using Moq;
using Shouldly;
using UnitTest.Mocks;

namespace UnitTest.TaskTest.Command
{
    public class DeleteTaskCommandHandlerTest
    {

        private readonly IMapper _mapper;
        private readonly Mock<IUnitOfWork> _mockRepo;
        private readonly DeleteTaskCommandHandler _handler;
        
        public DeleteTaskCommandHandlerTest()
        {
            _mockRepo = MockUnitOfWork.GetUnitOfWork();
            var mapperConfig = new MapperConfiguration(c =>
            {
                c.AddProfile<MappingProfile>();
            });
            _mapper = mapperConfig.CreateMapper();

            _handler = new DeleteTaskCommandHandler(_mockRepo.Object, _mapper);
        }


        [Fact]

        public async Task DeleteTaskCommandHandler_Success()
        {
            var result = await _handler.Handle(new DeleteTaskCommand { Id = 1 }, CancellationToken.None);
            result.ShouldBeOfType<Result<int>>();

            var tasks = await _mockRepo.Object.TaskRepository.GetAll();
            tasks.Count.ShouldBe(1);
        }

        [Fact]

        public async Task DeleteTaskCommandHandler_Fail()
        {
            var result = await _handler.Handle(new DeleteTaskCommand { Id = 3 }, CancellationToken.None);
            result.ShouldBeOfType<Result<int>>();
            result.Success.ShouldBeFalse();

            var tasks = await _mockRepo.Object.TaskRepository.GetAll();
            tasks.Count.ShouldBe(2);
        }
        
    }
}