using FinalProjectLibrary.Repository.TypeRepository;

namespace FinalProjectLibrary.UnitOfWork
{
    public interface IColdUnitOfWork : IDisposable
    {
        IColdMeasurementRepository ColdMeasurement
        {
            get;
        }
        Task<int> Save();
    }
}