using FinalProjectLibrary.Contexts;
using FinalProjectLibrary.Models;
using Microsoft.EntityFrameworkCore;

namespace FinalProjectLibrary.Repository.TypeRepository
{
    public class SourceRepository : GenericRepository<Source>, ISourceRepository
    {
        public SourceRepository(WarmFinalProjectContext context) : base(context) { }

        //Here we can add the code for the extended methods
        public async Task<Source> GetByIdIncludeTargets(string id)
        {
            return await context.Sources
                .Include(s => s.Targets)
                .FirstOrDefaultAsync(s => s.UniqueId == id);
        }
    }
}
