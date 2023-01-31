using FinalProjectLibrary.Repository.TypeRepository;

namespace FinalProjectLibrary.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        ISourceRepository Source
        {
            get;
        }
        ISourceEntryRepository SourceEntry
        {
            get;
        }

        Task<int> Save();
    }
}