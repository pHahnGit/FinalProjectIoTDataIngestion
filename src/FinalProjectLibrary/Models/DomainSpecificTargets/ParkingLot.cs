using FinalProjectLibrary.Models.DomainSpecificMeasurements;
using System.ComponentModel.DataAnnotations.Schema;

namespace FinalProjectLibrary.Models.DomainSpecificTargets;
[Table("ParkingLots")]
public class ParkingLot : Target
{
    public int? TotalCapacity { get; set; }
    public int? FreeSpaces { get; set; }
    public bool? HasLiveData { get; set; }
    public ICollection<ParkingSpace>? ParkingSpaces { get; set; }
    public string? Name { get; set; }
    public int? C02Level { get; set; }

    /// <summary>
    /// Updates the Available attribute from the data found in the measurement
    /// </summary>
    /// <param name="sourceEntry"></param>
    public override void UpdateValues(Measurement measurement)
    {
        if (measurement is CapacityMeasurement)
        {
            //Casting to ensure that it is a Capacity measurement and to be able
            //to access the derived object
            CapacityMeasurement castItem = (CapacityMeasurement)measurement;
            this.FreeSpaces = castItem.Available;
        }
        // Update if it is a co2 measurement
        else if (measurement is C02Measurement)
        {
            //Casting to ensure that it is a Capacity measurement and to be able to access the derived object
            C02Measurement castItem = (C02Measurement)measurement;
            //Assing the value to the the parkinglot
            this.C02Level = castItem.Value;

            //Gimmick for the presentation
            if (castItem.Value > 1000)
            {
                Console.WriteLine();
                Console.WriteLine("Dangerous C02 levels detected - Activating ventilation system...");
                System.Threading.Thread.Sleep(1000);
                Console.WriteLine(".");
                System.Threading.Thread.Sleep(1000);
                Console.WriteLine(".");
                System.Threading.Thread.Sleep(1000);
                Console.WriteLine(".");
                System.Threading.Thread.Sleep(1000);
                Console.WriteLine(".");
                System.Threading.Thread.Sleep(1000);
                Console.WriteLine(".");
                System.Threading.Thread.Sleep(1000);
                Console.WriteLine(".");
                System.Threading.Thread.Sleep(1000);
                Console.WriteLine(".");
                System.Threading.Thread.Sleep(1000);
                Console.WriteLine("Ventilation system activated.");
                Console.WriteLine();
            }
        }

    }
}
