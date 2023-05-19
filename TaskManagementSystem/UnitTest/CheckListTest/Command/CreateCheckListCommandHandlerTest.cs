
using Application.Contracts.Persistence;
using Application.Features.CheckList.CQRS.Commands;
using Application.Features.CheckList.CQRS.Handlers;
using Application.Features.CheckList.DTOs;
using Application.Profiles;
using Application.Responses;
using AutoMapper;
using Moq;
using Shouldly;
using UnitTest.Mocks;

namespace UnitTest.CheckListTest.Command
{
    public class CreateCheckListCommandHandlerTest
    {

        private readonly IMapper _mapper;

        private readonly Mock<IUnitOfWork> _mockRepo;

        private readonly CreateCheckListDto _checkListDto;

        private readonly CreateCheckListCommandHandler _handler;

        public CreateCheckListCommandHandlerTest()
        {
            _mockRepo = MockUnitOfWork.GetUnitOfWork();

            var mapperConfig = new MapperConfiguration(c =>
          {
              c.AddProfile<MappingProfile>();
          });
            _mapper = mapperConfig.CreateMapper();

            _checkListDto = new CreateCheckListDto
            {
                Title = "title",
                Description = "description",
                Status = false
            };
            _handler = new CreateCheckListCommandHandler(_mockRepo.Object, _mapper);
        }

        [Fact]

        public async Task CreateCheckListCommandHandler_Success()
        {
            var result = await _handler.Handle(new CreateCheckListCommand { CheckListDto = _checkListDto }, CancellationToken.None);
            result.ShouldBeOfType<Result<int>>();

            var checkLists = await _mockRepo.Object.CheckListRepository.GetAll();
            checkLists.Count.ShouldBe(3);

        }

        [Fact]
        public async Task CreateCheckListCommandHandler_Fail()
        {
            _checkListDto.Title = null;
            var result = await _handler.Handle(new CreateCheckListCommand { CheckListDto = _checkListDto }, CancellationToken.None);

            result.ShouldBeOfType<Result<int>>();
            result.Success.ShouldBeFalse();
            result.Errors.ShouldNotBeEmpty();

            var checkLists = await _mockRepo.Object.CheckListRepository.GetAll();
            checkLists.Count.ShouldBe(2);
        }

    }
}