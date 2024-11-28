using Eve.Core.Models.Entities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace Eve.Core.ViewModel
{
    public class SourceViewModel
    {
        [Required(ErrorMessage = "El campo es requerido")]
        [MaxLength(255, ErrorMessage = "Solo se permite 255 caracteres")]
        [DisplayName("Nombre de recurso")]
        public string Name { get; set; }

        [Required(ErrorMessage = "El campo es requerido")]
        [MaxLength(255, ErrorMessage = "Solo se permite 255 caracteres")]
        [DisplayName("Descripción del recurso")]
        public string Description { get; set; }

        [Required(ErrorMessage = "El campo es requerido")]
        [DisplayName("Tipo de recurso")]
        public SourceType SourceType { get; set; }

        [Required(ErrorMessage = "El campo es requerido")]
        [DisplayName("Categoría")]
        public int CategoryId { get; set; }
    }
}