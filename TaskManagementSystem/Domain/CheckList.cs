using Domain.Common;

namespace Domain
{
    public class CheckList : BaseDomainEntity
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public bool Status { get; set; }
        public Task Task { get; set; }

    }
}