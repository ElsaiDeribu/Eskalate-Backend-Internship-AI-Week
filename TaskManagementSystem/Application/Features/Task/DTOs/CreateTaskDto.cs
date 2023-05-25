

using Application.Features.CheckList.DTOs;

namespace Application.Features.Task.DTOs
{
    public class CreateTaskDto : ITaskDto
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public bool? Status { get; set; }
        public ICollection<CreateCheckListDto> CheckList { get; set; } = new List<CreateCheckListDto>();

    }
}
