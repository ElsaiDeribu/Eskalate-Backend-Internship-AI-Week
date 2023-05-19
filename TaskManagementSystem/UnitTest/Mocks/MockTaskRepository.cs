
using Application.Contracts.Persistence;
using Moq;

namespace UnitTest.Mocks
{
    public static class MockTaskRepository
    {
        public static Mock<ITaskRepository> GetTaskRepository()
        {
            var tasks = new List<Domain.Task>
            {
                new Domain.Task
                {
                    Id = 1,
                    Title = "Task 1",
                    Description = "Task 1 Description",
                    StartDate = DateTime.Now,
                    EndDate = DateTime.Now,
                    LastModifiedDate = DateTime.Now,
                    DateCreated = DateTime.Now,
                    Status = false
                },
                new Domain.Task
                {
                    Id = 2,
                    Title = "Task 2",
                    Description = "Task 2 Description",
                    StartDate = DateTime.Now,
                    EndDate = DateTime.Now,
                    LastModifiedDate = DateTime.Now,
                    DateCreated = DateTime.Now,
                    Status = false
                }
            };

            var mockRepo = new Mock<ITaskRepository>();

            mockRepo.Setup(t => t.GetAll()).ReturnsAsync(tasks);

            mockRepo.Setup(t => t.Add(It.IsAny<Domain.Task>())).ReturnsAsync((Domain.Task task) =>
            {
                task.Id = tasks.Count() + 1;
                tasks.Add(task);
                return task;
            });

            mockRepo.Setup(t => t.Update(It.IsAny<Domain.Task>())).Callback((Domain.Task task) =>
            {
                var newTasks = tasks.Where((t) => t.Id != task.Id);
                tasks = newTasks.ToList();
                tasks.Add(task);
            });

            mockRepo.Setup(t => t.Delete(It.IsAny<Domain.Task>())).Callback((Domain.Task task) =>
            {
               tasks.Remove(task);
            });

            mockRepo.Setup(t => t.Get(It.IsAny<int>())).ReturnsAsync((int id) =>
            {
                return tasks.FirstOrDefault((t) => t.Id == id);
            });

            return mockRepo;
        }
    }
}