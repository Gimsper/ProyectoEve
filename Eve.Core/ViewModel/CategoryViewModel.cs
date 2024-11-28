using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Eve.Core.ViewModel
{
    public class CategoryViewModel
    {
        [Required(ErrorMessage = "El campo es requerido")]
        [MaxLength(100, ErrorMessage = "Solo se permite 100 caracteres")]
        [DisplayName("Nombre de categoría")]
        public string Name { get; set; }
    }
}
