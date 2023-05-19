
using Application.Contracts.Persistence;
using Application.Features.Task.CQRS.Handlers;
using Application.Features.Task.CQRS.Queries;
using Application.Features.Task.DTOs;
using Application.Profiles;
using Application.Responses;
using AutoMapper;
using Moq;
using Shouldly;
using UnitTest.Mocks;

namespace UnitTest.TaskTest.Handler
{
    public class GetTaskListQueryHandlerTest
    {

        private readonly IMapper _mapper;
        private readonly Mock<IUnitOfWork> _mockRepo;
        private readonly GetTaskListQueryHandler _handler;

        public GetTaskListQueryHandlerTest()
        {
            _mockRepo = MockUnitOfWork.GetUnitOfWork();

            var mapperConfig = new MapperConfiguration(c =>
            {
                c.AddProfile<MappingProfile>();
            });
            _mapper = mapperConfig.CreateMapper();

            _handler = new GetTaskListQueryHandler(_mockRepo.Object, _mapper);
        }

        [Fact]

        public async Task GetTaskAsyncTaskListQueryHandler_Success()
        {
            var result = await _handler.Handle(new GetTaskListQuery(), CancellationToken.None);
            result.ShouldBeOfType<Result<List<TaskDto>>>();
            result.Success.ShouldBeTrue();
            result.Value.Count.ShouldBe(2);
        }
    }
}