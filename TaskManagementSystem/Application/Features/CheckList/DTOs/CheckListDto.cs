using Application.Features.CheckList.DTOs;
using Application.Features.Common;

namespace Application.Features.CheckList.DTOs
{
    public class CheckListDto : BaseDto, ICheckListDto
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public bool Status { get; set; }
    }
}
