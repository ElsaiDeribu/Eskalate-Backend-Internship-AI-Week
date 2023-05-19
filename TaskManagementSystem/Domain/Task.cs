using Domain.Common;

namespace Domain
{
    public class Task : BaseDomainEntity
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public bool Status { get; set; }

        // public ICollection<CheckList>? CheckList { get; set; }

    }
}