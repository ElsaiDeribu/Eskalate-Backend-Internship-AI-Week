

namespace Application.Features.CheckList.DTOs
{
    public class CreateCheckListDto : ICheckListDto 
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public bool Status { get; set; }
    }
}
