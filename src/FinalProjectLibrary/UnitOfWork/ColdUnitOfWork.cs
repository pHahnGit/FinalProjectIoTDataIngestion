using FinalProjectLibrary.Repository.TypeRepository;

namespace FinalProjectLibrary.UnitOfWork
{
    public class ColdUnitOfWork : IColdUnitOfWork
    {
        private ColdFinalProjectContext context;

        public ColdUnitOfWork(ColdFinalProjectContext context)
        {
            this.context = context;
            ColdMeasurement = new ColdMeasurementRepository(this.context);
        }

        public IColdMeasurementRepository ColdMeasurement { get; private set; }

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