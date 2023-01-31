using FinalProjectLibrary.Models.DomainSpecificMeasurements;
using System.ComponentModel.DataAnnotations.Schema;

namespace FinalProjectLibrary.Models.DomainSpecificTargets;

[Table("ParkingSpaces")]
public class ParkingSpace : Target
{
    [ForeignKey("ParkingLot")]
    public Guid? ParkingLotId { get; set; }
    public string? Type { get; set; }
    public ParkingLot? ParkingLot { get; set; } = null!;
    public bool? Occupied { get; set; }

    public override void UpdateValues(Measurement measurement)
    {
        if (measurement is OccupancyMeasurement)
        {
            OccupancyMeasurement castItem = (OccupancyMeasurement)measurement;
            this.Occupied = castItem.Occupied;

        }
    }
}
