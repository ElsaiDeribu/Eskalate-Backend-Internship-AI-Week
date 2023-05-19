using Domain.Common;

namespace Domain
{
    public class Task : BaseDomainEntity
    {
        public string Title { get; private set; }
        public string Description { get; private set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public bool Status { get; set; }

        public ICollection<CheckList>? CheckList { get; set; }

    }
}