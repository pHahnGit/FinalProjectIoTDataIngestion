using FinalProjectLibrary.Contexts;
using FinalProjectLibrary.Models;

namespace FinalProjectLibrary.Repository.TypeRepository
{
    public class SourceEntryRepository : GenericRepository<SourceEntry>, ISourceEntryRepository
    {
        public SourceEntryRepository(WarmFinalProjectContext context) : base(context) { }
    }
}
