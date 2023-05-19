using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Common;

namespace Domain
{
    public class User : BaseDomainEntity 
    {
        public string FullName { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }

        
    }
}