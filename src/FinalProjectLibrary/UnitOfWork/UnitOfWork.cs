using FinalProjectLibrary.Contexts;
using FinalProjectLibrary.Repository.TypeRepository;

namespace FinalProjectLibrary.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private WarmFinalProjectContext context;

        public UnitOfWork(WarmFinalProjectContext context)
        {
            this.context = context;
            Source = new SourceRepository(this.context);
            SourceEntry = new SourceEntryRepository(this.context);
        }

        public ISourceRepository Source { get; private set; }
        public ISourceEntryRepository SourceEntry { get; private set; }

        public void Dispose()
        {
            context.Dispose();
        }

        public async Task<int> Save()
        {
            return await context.SaveChangesAsync();
        }
    }
}