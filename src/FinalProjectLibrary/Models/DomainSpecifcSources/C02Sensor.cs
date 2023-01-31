using FinalProjectLibrary.Models.DomainSpecificMeasurements;
using FinalProjectLibrary.Models.DomainSpecificTargets;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json;

namespace FinalProjectLibrary.Models.DomainSpecifcSources;
[Table("C02Sensors")]
public class C02Sensor : Source
{
    public string? HardwareVersion { get; set; }

    /// <summary>
    /// Creates a measurement for C02Sensor
    /// </summary>
    /// <param name="json">The json recieved from the http request</param>
    /// <param name="source">The source recieved from the database</param>
    /// <returns>A source entry</returns>
    public override SourceEntry? CreateMeasurement(JsonDocument json, DateTime entryTime)
    {
        var resultList = new List<Measurement>();

        //Retrieving the needed attributes for the measurement
        var c02 = Int32.Parse(json.RootElement.GetProperty("value").ToString());

        var sourceId = this.UniqueId;

        Target? target = null;
        foreach (ParkingLot lot in this.Targets)
        {

            target = lot;
            break;

        }

        resultList.Add(new C02Measurement()
        {
            MeasurementTime = DateTime.UtcNow,
            Source = this,
            Target = target,
            Value = c02
        });

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