using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MaxFit.Models.Dto
{
    public class UserAllQueryDTO
    {
        public string Identity { get; set; }
        public string IdentityType { get; set; }
        public string Name { get; set; }
        public string DateInscription { get; set; }
        public string DateExpired { get; set; }

    }
}
