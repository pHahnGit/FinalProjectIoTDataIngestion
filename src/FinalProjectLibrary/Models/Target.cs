using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FinalProjectLibrary.Models;

[Table("Targets")]
public class Target
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid UniqueId { get; set; }
    public decimal? Latitude { get; set; }
    public decimal? Longitude { get; set; }
    public ICollection<Measurement>? Measurements { get; set; }
    public ICollection<Source>? Sources { get; set; }

    /// <summary>
    /// Takes in a measurement and updates the targets properties if overrided in the 
    /// domain specific targets
    /// </summary>
    /// <param name="measurement"></param>
    /// <exception cref="Exception"></exception>
    public virtual void UpdateValues(Measurement measurement)
    {
        Console.WriteLine("No Domain specific target associated to the ID ");
    }
}
