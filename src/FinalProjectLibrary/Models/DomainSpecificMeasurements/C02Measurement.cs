using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FinalProjectLibrary.Models.DomainSpecificMeasurements;
[Table("C02Measurements")]
public class C02Measurement : Measurement
{
    [Required]
    public int Value { get; set; }
}
