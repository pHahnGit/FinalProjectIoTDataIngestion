using FinalProjectLibrary.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

public class WarmFinalProjectContextFactory : IDesignTimeDbContextFactory<WarmFinalProjectContext>
{
    public WarmFinalProjectContextFactory()
    {

    }

    private readonly IConfiguration Configuration;
    public WarmFinalProjectContextFactory(IConfiguration configuration)
    {
        Configuration = configuration;
    }
    public WarmFinalProjectContext CreateDbContext(string[] args)
    {

        string filePath = Directory.GetCurrentDirectory() + @"..\appsettings.json";
        //@"C:\Users\PHahn\source\Repos\finalProject\src\SensadeLibrary\appsettings.json";

        IConfiguration Configuration = new ConfigurationBuilder()
        .SetBasePath(Path.GetDirectoryName(filePath))
           .AddJsonFile("appsettings.json")
           .Build();


        var optionsBuilder = new DbContextOptionsBuilder<WarmFinalProjectContext>();
        optionsBuilder.UseNpgsql(Configuration.GetConnectionString("LocalDBWarm"));

        return new WarmFinalProjectContext(optionsBuilder.Options);
    }
}