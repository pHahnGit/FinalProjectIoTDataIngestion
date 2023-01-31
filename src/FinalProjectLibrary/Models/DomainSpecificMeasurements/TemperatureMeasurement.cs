using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FinalProjectLibrary.Models.DomainSpecificMeasurements;
[Table("TemperatureMeasurements")]
public class TemperatureMeasurement : Measurement
{
    [Required]
    public decimal Value { get; set; }

    [Required]
    public string Unit { get; set; }
}
