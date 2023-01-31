using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FinalProjectLibrary.Models;
[Table("SourceEntries")]
public class SourceEntry
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid UniqueId { get; set; }
    [Required]
    public string SourceId { get; set; }
    [Required]
    public DateTime EntryTime { get; set; }
    public IEnumerable<Measurement> Measurements { get; set; } = new List<Measurement>();
    public Source Source { get; set; } = null!;
}
