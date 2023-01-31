using FinalProjectLibrary.Models;

namespace FinalProjectLibrary.Repository.TypeRepository
{
    public interface ISourceRepository : IGenericRepository<Source>
    {

        //Here we can add the custom interface methods of the repository. The implementation is in the repository

        /// <summary>
        /// Returns the source including the domain Source tyoe
        /// </summary>
        /// <param name="id"> Dev EUI of the source</param>
        /// <returns>The source including the targets </returns>
        Task<Source> GetByIdIncludeTargets(string id);
    }
}
