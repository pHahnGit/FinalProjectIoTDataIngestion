using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FinalProjectLibrary.Models.DomainSpecificMeasurements;

[Table("OccupancyMeasurements")]
public class OccupancyMeasurement : Measurement
{
    [Required]
    public bool Occupied { get; set; }
}
