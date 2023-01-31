namespace FinalProjectLibrary.Models.ColdModels;

public class ColdStorageMeasurement
{
    public Guid UniqueId { get; set; }

    public string SourceId { get; set; }

    public Guid? TargetId { get; set; }

    public DateTime? EntryTime { get; set; }

    public string RawData { get; set; }

    public Source Source { get; set; } = null!;
}
