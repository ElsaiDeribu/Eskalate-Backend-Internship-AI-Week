

namespace Application.Features.CheckList.DTOs
{
    public interface ICheckListDto
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public bool Status { get; set; }
    }
}
