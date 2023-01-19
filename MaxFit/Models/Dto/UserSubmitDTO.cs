using System.ComponentModel.DataAnnotations;

namespace MaxFit.Models.Dto
{
    public class UserSubmitDTO
    {
        [Required(ErrorMessage ="Para registrar un nuevo usuario se debe de agregar la Identificación")]
        public string Identity { get; set; }
        [Required(ErrorMessage ="Para registrar un nuevo usuario se debe de seleccionar in Tipo de Identificación")]
        public string IdentityType { get; set; }
        [Required(ErrorMessage = "Para registrar un nuevo usuario se debe de agregar un Nombre")]
        public string Name { get; set; }
        public string Subscription { get; set; }
    }
}
