using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Eve.Core.ViewModel
{
    public class UserDataViewModel
    {
        [Required(ErrorMessage = "El campo es requerido")]
        [MaxLength(100, ErrorMessage = "Solo se permite 100 caracteres")]
        [DisplayName("Usuario")]
        public string? Username { get; set; }

        [Required(ErrorMessage = "El campo es requerido")]
        [MaxLength(100, ErrorMessage = "Solo se permite 100 caracteres")]
        [DisplayName("Contraseña")]
        [DataType(DataType.Password)]
        public string? Password { get; set; }
    }
}
