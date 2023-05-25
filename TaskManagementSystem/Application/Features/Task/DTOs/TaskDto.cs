using Application.Features.CheckList.DTOs;
using Application.Features.Common;



namespace Application.Features.Task.DTOs
{
    public class TaskDto : BaseDto, ITaskDto
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public bool? Status { get; set; }
        public string ownerName { get; set; }
        public List<CheckListDto> CheckList { get; set; }



    }
}
