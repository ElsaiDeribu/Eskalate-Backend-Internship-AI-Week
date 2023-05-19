

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
    public class GetTaskDetailQueryHandlerTest
    {
        private readonly IMapper _mapper;
        private readonly Mock<IUnitOfWork> _mockRepo;
        private readonly GetTaskDetailQueryHandler _handler;

        public GetTaskDetailQueryHandlerTest()
        {
            _mockRepo = MockUnitOfWork.GetUnitOfWork();

            var mapperConfig = new MapperConfiguration(c =>
            {
                c.AddProfile<MappingProfile>();
            });
            _mapper = mapperConfig.CreateMapper();

            _handler = new GetTaskDetailQueryHandler(_mockRepo.Object, _mapper);
        }


        [Fact]

        public async Task GetTaskDetailQueryHandler_Success()
        {
            var result = await _handler.Handle(new GetTaskDetailQuery { Id = 1 }, CancellationToken.None);
            result.ShouldBeOfType<Result<TaskDto>>();
            result.Success.ShouldBeTrue();
            result.Value.ShouldBeOfType<TaskDto>();
        }


        [Fact]

        public async Task GetTaskDetailQueryHandler_Fail()
        {
            var result = await _handler.Handle(new GetTaskDetailQuery { Id = 3 }, CancellationToken.None);
            result.ShouldBeOfType<Result<TaskDto>>();
            result.Success.ShouldBeTrue();
            result.Value.ShouldBeNull();
        }

    }
}