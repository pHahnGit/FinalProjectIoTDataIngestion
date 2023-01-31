using FinalProjectLibrary.Models.DomainSpecificMeasurements;
using FinalProjectLibrary.Models.DomainSpecificTargets;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json;

namespace FinalProjectLibrary.Models.DomainSpecifcSources;

[Table("SilkeBorgEntryExits")]
public class CoilEntryExit : Source
{
    public string? Name { get; set; }
    public string? SoftwareVersion { get; set; }
    /// <summary>
    /// Reads a JsonDocument and creates a measurement for each target that exist 
    /// in both the raw data and in source. If no relationship, it skips the measurement
    /// </summary>
    /// <param name="json">The Raw Data </param>
    /// <returns>A source entry</returns>
    public override SourceEntry? CreateMeasurement(JsonDocument json, DateTime entryTime)
    {
        var payload = json.RootElement.GetProperty("measurements");

        //Get an enumerator of the Json Array elements
        var enumerator = payload.EnumerateArray();
        var resultList = new List<Measurement>();
        foreach (JsonElement item in enumerator)
        {
            var jsonName = item.GetProperty("properties").GetProperty("name")
                .ToString();
            Target? target = null;
            foreach (ParkingLot lot in this.Targets)
            {
                if (lot.Name == jsonName)
                {
                    target = lot;
                    break;
                }
            }
            resultList.Add(new CapacityMeasurement()
            {
                SourceId = this.UniqueId,
                Target = target,
                // CoilEntry does not provide a time value of when the measurements have been made,
                // so the entry time is used
                MeasurementTime = entryTime,
                Available = Int32.Parse(item.GetProperty("properties")
                    .GetProperty("parkingfree").ToString()),
                TotalCapacity = Int32.Parse(item.GetProperty("properties")
                    .GetProperty("parkingcapacity").ToString())
            });
        }
        //Parent Measurement
        var sourceEntry = new SourceEntry()
        {
            EntryTime = entryTime,
            SourceId = this.UniqueId,
            Measurements = resultList
        };

        return sourceEntry;
    }
}
