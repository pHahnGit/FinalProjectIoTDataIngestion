using FinalProjectLibrary.Models;

namespace FinalProjectLibrary.Repository.TypeRepository
{
    public interface IColdMeasurementRepository
    {
        public Task<bool> InsertRaw(string data, Source source, DateTime entryTime);
    }
}
