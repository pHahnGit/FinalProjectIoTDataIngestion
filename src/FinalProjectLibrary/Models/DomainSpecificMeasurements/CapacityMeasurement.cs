using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FinalProjectLibrary.Models.DomainSpecificMeasurements;
[Table("CapacityMeasurements")]
public class CapacityMeasurement : Measurement
{
    public int TotalCapacity { get; set; }

    [Required]
    public int Available { get; set; }
}
