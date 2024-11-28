using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Eve.Core.Models.Entities
{
    public class Rol
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int RolId { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        [Required]
        public ActionType Actions { get; set; }
        
        public virtual ICollection<UserLogin> Users { get; set; }
    }

    public enum ActionType
    {
        Low,
        Mid,
        High,
        God
    }
}
