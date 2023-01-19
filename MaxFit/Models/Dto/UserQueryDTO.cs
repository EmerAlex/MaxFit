using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MaxFit.Models.Dto
{
    public class UserQueryDTO
    {
        public string Identity { get; set; }
        public string IdentityType { get; set; }
        public string Name { get; set; }
        public DateTime DateInscription { get; set; }
        public DateTime DateExpired { get; set; }

    }
}
