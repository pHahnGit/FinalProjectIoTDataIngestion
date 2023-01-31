using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json;

namespace FinalProjectLibrary.Models;

[Table("Sources")]
public class Source
{
    [Key]
    public string UniqueId { get; set; } = null!;
    public DateTime? CreationDate { get; set; }
    public decimal? Latitude { get; set; }
    public decimal? Longitude { get; set; }
    public ICollection<Measurement>? Measurements { get; set; }
    public ICollection<Target>? Targets { get; set; }
    public virtual SourceEntry? CreateMeasurement(JsonDocument Json, DateTime entryTime)
    {
        Console.WriteLine("No domain source found to override method");
        return null;
    }
}
