using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FinalProjectLibrary.Models
{
    [Table("Measurements")]
    public class Measurement
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid UniqueId { get; set; }
        public Guid? TargetId { get; set; }
        [Required]
        public string SourceId { get; set; }
        [Required]
        public DateTime MeasurementTime { get; set; }
        public Target? Target { get; set; }
        public Source Source { get; set; } = null!;
    }
}
