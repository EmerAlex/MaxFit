using System.ComponentModel.DataAnnotations;

namespace MaxFit.Models.Dto
{
    public class UserSubmitDTO
    {

        public string Identity { get; set; }
        public string IdentityType { get; set; }
        public string Name { get; set; }
        public string Subscription { get; set; }
    }
}
