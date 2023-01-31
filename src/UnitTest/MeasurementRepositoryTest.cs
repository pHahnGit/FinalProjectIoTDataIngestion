using FinalProjectLibrary.Models;
using FinalProjectLibrary.Models.DomainSpecificMeasurements;
using FinalProjectLibrary.Repository.TypeRepository;

namespace UnitTest
{
    public class MeasurementRepositoryTest : IClassFixture<TestDatabaseFixture>
    {
        public MeasurementRepositoryTest(TestDatabaseFixture fixture)
            => Fixture = fixture;

        public TestDatabaseFixture Fixture { get; }

        [Fact]
        public async void InsertMeasurement()
        {
            var ok = false;
            try
            {
                using var context = Fixture.CreateContext();
                var repository = new SourceEntryRepository(context);

                SourceEntry m = new SourceEntry
                {
                    EntryTime = DateTime.UtcNow,
                    SourceId = "1234",
                    Measurements = new List<Measurement>() {
                        new OccupancyMeasurement {Occupied = false },
                        new TemperatureMeasurement {Value = 34m, Unit ="Celsius" }
                }
                };
                repository.Add(m);
                ok = true;
            }
            catch (Exception)
            {

                throw;
            }

            Assert.True(ok);
        }
    }


}
