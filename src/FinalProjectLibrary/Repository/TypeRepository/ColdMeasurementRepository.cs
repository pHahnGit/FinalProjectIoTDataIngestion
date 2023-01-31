using FinalProjectLibrary.Models;
using FinalProjectLibrary.Models.ColdModels;
using System.Linq.Expressions;

namespace FinalProjectLibrary.Repository.TypeRepository
{
    public class ColdMeasurementRepository : IColdMeasurementRepository
    {
        private readonly ColdFinalProjectContext _context;

        public ColdMeasurementRepository(ColdFinalProjectContext context)
        {
            _context = context;
        }

        public Task<bool> InsertRaw(string data, Source source, DateTime entryTime)
        {
            ColdStorageMeasurement entity = new ColdStorageMeasurement();
            entity.SourceId = source.UniqueId;

            //TODO: this is a bit problematic as a source/target join can contain multiple relationships. Maybe we scrap the targetId in cold storage. We'l need to discuss
            if (source.Targets.Count < 0)
            {
                entity.TargetId = source.Targets.First().UniqueId;
            }

            entity.EntryTime = entryTime;
            entity.RawData = data;

            try
            {
                _context.Add(entity);
                _context.SaveChanges();
                return Task.FromResult(true);
            }
            catch (Exception ex)
            {
                return Task.FromResult(false);
            }
        }

        public void Insert(ColdStorageMeasurement entity)
        {
            throw new NotImplementedException();
        }

        public void Update(ColdStorageMeasurement entity)
        {
            throw new NotImplementedException();
        }


        public IEnumerable<ColdStorageMeasurement> GetAll()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ColdStorageMeasurement> Find(Expression<Func<ColdStorageMeasurement, bool>> expression)
        {
            throw new NotImplementedException();
        }

        public void Add(ColdStorageMeasurement entity)
        {
            throw new NotImplementedException();
        }

        public void AddRange(IEnumerable<ColdStorageMeasurement> entities)
        {
            throw new NotImplementedException();
        }

        public void Remove(ColdStorageMeasurement entity)
        {
            throw new NotImplementedException();
        }

        public void RemoveRange(IEnumerable<ColdStorageMeasurement> entities)
        {
            throw new NotImplementedException();
        }


    }
}
