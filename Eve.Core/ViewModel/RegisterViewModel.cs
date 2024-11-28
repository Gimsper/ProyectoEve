using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Eve.Core.Models.Entities
{
    public class RegisterViewModel
    {
                [Required(ErrorMessage = "El campo es requerido")]
        [MaxLength(100, ErrorMessage = "Solo se permite 100 caracteres")]
        [DisplayName("Usuario")]
        public string Username { get; set; }

        [Required(ErrorMessage = "El campo es requerido")]
        [MaxLength(100, ErrorMessage = "Solo se permite 100 caracteres")]
        [DisplayName("Contraseña")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required(ErrorMessage = "El campo es requerido")]
        [MaxLength(100, ErrorMessage = "Solo se permite 100 caracteres")]
        [Compare("Password", ErrorMessage = "Las contraseñas no coinciden")]
        [DisplayName("Confirmar contraseña")]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }

        [Required(ErrorMessage = "El campo es requerido")]
        [MaxLength(100, ErrorMessage = "Solo se permite 100 caracteres")]
        [DisplayName("Email")]
        [DataType(DataType.EmailAddress, ErrorMessage = "El formato del correo no coincide")]
        public string Email { get; set; }
    }
}
