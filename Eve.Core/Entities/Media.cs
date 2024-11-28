using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Eve.Core.Models.Entities
{
    public class Media
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int MediaId { get; set; }

        [ForeignKey("SourceId")]
        public int SourceId { get; set; }

        [Required]
        [MaxLength(100)]
        public string Title { get; set; }

        [Required]
        public string Route { get; set; }

        [Required]
        public TypeMedia Type { get; set; }

        public virtual Source Source { get; set; }
    }

    public enum TypeMedia
    {
        mp4,
        png,
        jpg,
        svg,
        jpeg,
        wav
    }
}
