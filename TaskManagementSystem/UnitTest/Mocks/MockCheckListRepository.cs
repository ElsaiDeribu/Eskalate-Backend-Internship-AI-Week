

using Domain;
using Application.Contracts.Persistence;
using Moq;

namespace UnitTest.Mocks
{
    public static class MockCheckListRepository
    {
        public static Mock<ICheckListRepository> GetCheckListRepository()
        {

            var checkLists = new List<CheckList>
            {
            new CheckList{
                Id = 1,
                Title = "CheckList 1",
                Description = "CheckList 1 Description",
                DateCreated = DateTime.Now,
                LastModifiedDate = DateTime.Now,
                Status = false
            },
            new CheckList{
                Id = 2,
                Title = "CheckList 2",
                Description = "CheckList 2 Description",
                DateCreated = DateTime.Now,
                LastModifiedDate = DateTime.Now,
                Status = true
            }

        };


            var mockRepo = new Mock<ICheckListRepository>();

            mockRepo.Setup(c => c.GetAll()).ReturnsAsync(checkLists);

            mockRepo.Setup(c => c.Add(It.IsAny<CheckList>())).ReturnsAsync((CheckList checkList) =>
            {
                checkList.Id = checkLists.Count() + 1;
                checkLists.Add(checkList);
                return checkList;
            });

            mockRepo.Setup(c => c.Update(It.IsAny<CheckList>())).Callback((CheckList checkList) =>
            {
                var newCheckLists = checkLists.Where((c) => c.Id != checkList.Id);
                checkLists = newCheckLists.ToList();
                checkLists.Add(checkList);
            });

            mockRepo.Setup(c => c.Delete(It.IsAny<CheckList>())).Callback((CheckList checkList) =>
            {
                checkLists.Remove(checkList);

            });

            mockRepo.Setup(c => c.Get(It.IsAny<int>())).ReturnsAsync((int id) =>
                {
                    return checkLists.FirstOrDefault((c) => c.Id == id);
                });

            return mockRepo;
        }


    }

}
