

using Application.Contracts.Persistence;
using Moq;

namespace UnitTest.Mocks
{
    public static class MockUnitOfWork
    {
        public static Mock<IUnitOfWork> GetUnitOfWork()
        {
            var mockUow = new Mock<IUnitOfWork>();
            var mockTaskRepo = MockTaskRepository.GetTaskRepository();
            var mockCheckListRepo = MockCheckListRepository.GetCheckListRepository();

            mockUow.Setup(t => t.TaskRepository).Returns(mockTaskRepo.Object);
            mockUow.Setup(c => c.CheckListRepository).Returns(mockCheckListRepo.Object);



            return mockUow;
            
        }
        
    }
}