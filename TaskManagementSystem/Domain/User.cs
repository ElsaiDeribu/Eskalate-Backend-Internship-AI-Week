using Domain.Common;
using Microsoft.AspNetCore.Identity;

namespace Domain
{
    public class User : IdentityUser
    {

        public string FullName { get; set; }

        public ICollection<Task> Tasks { get; set; } = new List<Task>();
        
    }
}