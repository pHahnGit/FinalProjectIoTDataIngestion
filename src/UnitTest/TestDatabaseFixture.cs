using FinalProjectLibrary.Contexts;
using FinalProjectLibrary.Models;
using Microsoft.EntityFrameworkCore;

namespace UnitTest;
public class TestDatabaseFixture
{   // The connection string to the test database that is created for the integration tests 
    private const string ConnectionString = "Host=100.90.1.48;Database=FinalProjectTest;Username=postgres;Password=postgres";

    private static readonly object _lock = new();
    private static bool _databaseInitialized;

    public TestDatabaseFixture()
    {
        lock (_lock)
        {
            if (!_databaseInitialized)
            {
                using (var context = CreateContext())
                {
                    context.Database.EnsureDeleted();
                    context.Database.EnsureCreated();
                    context.AddRange(
                        //The simplest Sources Possible
                        new Source { UniqueId = "SimpleSource1", CreationDate = DateTime.UtcNow.AddDays(-30), Latitude = 54.33m, Longitude = 53.33m },
                        new Source { UniqueId = "SimpleSource2", CreationDate = DateTime.UtcNow.AddDays(-20), Latitude = 55.33m, Longitude = 54.33m },
                        new Source { UniqueId = "SimpleSource3", CreationDate = DateTime.UtcNow.AddDays(-10), Latitude = 56.33m, Longitude = 55.33m },
                        new Source { UniqueId = "1234", Latitude = 54.33m, Longitude = 53.20m, CreationDate = DateTime.UtcNow },
                        new Target { Latitude = 54.33m, Longitude = 53.20m });
                    context.SaveChanges();
                }

                _databaseInitialized = true;
            }
        }
    }

    public WarmFinalProjectContext CreateContext()
        => new WarmFinalProjectContext(
            new DbContextOptionsBuilder<WarmFinalProjectContext>()
                .UseNpgsql(ConnectionString)
                .Options);
}