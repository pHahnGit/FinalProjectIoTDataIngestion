using FinalProjectLibrary.Contexts;
using Microsoft.EntityFrameworkCore;

public class TestDatabaseFixture
{
    // The connection string for the development database used to test if it can be accessed
    private const string ConnectionString = @"Host=100.90.1.48;Database=IngestionWarm;Port=5432;username=postgres;password=postgres";

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