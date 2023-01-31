using FinalProjectLibrary.Models;
using FinalProjectLibrary.Models.DomainSpecifcSources;
using FinalProjectLibrary.Models.DomainSpecificMeasurements;
using FinalProjectLibrary.Models.DomainSpecificTargets;
using Microsoft.EntityFrameworkCore;

namespace FinalProjectLibrary.Contexts
{
    public class WarmFinalProjectContext : DbContext
    {

        public WarmFinalProjectContext(DbContextOptions<WarmFinalProjectContext> options) : base(options)
        {
        }
        public DbSet<CapacityMeasurement> CapacityMeasurements { get; set; }
        public DbSet<SourceEntry> SourceEntries { get; set; }
        public DbSet<Measurement> Measurements { get; set; }
        public DbSet<OccupancyMeasurement> OccupancyMeasurements { get; set; }
        public DbSet<C02Measurement> C02Measurements { get; set; }
        public DbSet<ParkingLot> Parkinglots { get; set; }
        public DbSet<ParkingSpace> ParkingSpaces { get; set; }
        public DbSet<RoadPoint> RoadPoints { get; set; }
        public DbSet<CoilEntryExit> SilkeborgEntryExits { get; set; }
        public DbSet<C02Sensor> C02Sensors { get; set; }
        public DbSet<Source> Sources { get; set; }
        public DbSet<Target> Targets { get; set; }
        public DbSet<TemperatureMeasurement> TemperatureMeasurements { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Source>().HasData(
                new Source { UniqueId = "1234NoAbstractSource", CreationDate = DateTime.UtcNow }
                );
            modelBuilder.Entity<C02Sensor>().HasData(
                new C02Sensor { UniqueId = "c02sensor" });
            modelBuilder.Entity<Target>().HasData(
                //A generic target with out any domain specifc data
                new Target() { UniqueId = new Guid("cb74010f-1f78-4c62-a835-9565e574b2b4") },
                new Target() { UniqueId = new Guid("6d64e842-bf2d-43ad-96e6-034d1793253c") }
                );
            modelBuilder.Entity<CoilEntryExit>().HasData(
                new CoilEntryExit()
                {
                    UniqueId = "ParkeringspladserCoil",
                    Name = "Silkeborg",
                    CreationDate = DateTime.UtcNow
                }
                );
            modelBuilder.Entity<ParkingLot>().HasData(
                new ParkingLot()
                {
                    UniqueId = new Guid("f5c6004d-1d0f-445c-ae25-6c52ca752c74"),
                    Name = "TestLot"
                },
                //Silkeborg Parkinglots for Silkeborg Entry Exit
                new ParkingLot()
                {
                    UniqueId = new Guid("060af6e4-0aa5-46ff-a567-a111d7a1f0fc"),
                    Name = "Banegård - vest"
                },
                new ParkingLot()
                {
                    UniqueId = new Guid("bbbe8963-4b35-4296-b65c-b59dc56d9ce4"),
                    Name = "Bindslevs Plads, p-kælder + nord + kantsten"
                },
                new ParkingLot()
                {
                    UniqueId = new Guid("d6a9d08d-89de-494c-9407-bfb41c127326"),
                    Name = "Bios Gård"
                },
                new ParkingLot()
                {
                    UniqueId = new Guid("5b6ad768-f117-4479-961f-e3b1ac78a551"),
                    Name = "Estrups Gård"
                },
                new ParkingLot()
                {
                    UniqueId = new Guid("9786c861-8af0-430f-9fc1-a0ae5414680b"),
                    Name = "Jyske Banks parkering"
                },
                new ParkingLot()
                {
                    UniqueId = new Guid("b195d8f5-10ee-4929-ae20-2c321572095c"),
                    Name = "Kornmods Gård"
                },
                new ParkingLot()
                {
                    UniqueId = new Guid("8fc01bc7-0167-432e-9249-a84165eeaa59"),
                    Name = "Mejerigården"
                },
                new ParkingLot()
                {
                    UniqueId = new Guid("eaec4d67-1df5-49a7-8b05-0762b074317a"),
                    Name = "Rådhus - øst"
                },
                new ParkingLot()
                {
                    UniqueId = new Guid("644a17ab-3272-4f64-baeb-e0c4d6cb148c"),
                    Name = "Rådhus - vest"
                },
                new ParkingLot()
                {
                    UniqueId = new Guid("69da3b5b-8112-49d6-a8e9-c8d5ebf7b61a"),
                    Name = "Søgade"
                },
                new ParkingLot()
                {
                    UniqueId = new Guid("e19b29bd-5902-48b8-b62a-94f248e85dac"),
                    Name = "Torvet, p-kælder"
                },
                new ParkingLot()
                {
                    UniqueId = new Guid("78bd5e26-d9e2-46b0-9cb0-3ec9d8c7875b"),
                    Name = "Torvecenteret",
                    Latitude = 12.33m,
                    Longitude = 33.2m
                }
                );
            modelBuilder.Entity<ParkingSpace>().HasData(
                new ParkingSpace()
                {
                    UniqueId = new Guid("d3feb151-25bb-47ea-bd43-d86499b2b59f"),
                    ParkingLotId = Guid.Parse("f5c6004d-1d0f-445c-ae25-6c52ca752c74")
                },
                new ParkingSpace() { UniqueId = new Guid("20325fa9-adea-4871-bfed-07743e92c48e") }
                );
            modelBuilder.Entity<Source>()
                .HasMany(p => p.Targets)
                .WithMany(p => p.Sources)
                .UsingEntity(j => j.ToTable("SourceTargetJoin")
                .HasData(
                //Co2Sensor
                new { SourcesUniqueId = "c02sensor", TargetsUniqueId = new Guid("e19b29bd-5902-48b8-b62a-94f248e85dac") },
                // Other joins
                new { SourcesUniqueId = "1234NoAbstractSource", TargetsUniqueId = new Guid("cb74010f-1f78-4c62-a835-9565e574b2b4") },
                // SilkeborgEntryExitJoins
                new
                {
                    SourcesUniqueId = "ParkeringspladserCoil",
                    TargetsUniqueId = new Guid("060af6e4-0aa5-46ff-a567-a111d7a1f0fc")
                },
                new
                {
                    SourcesUniqueId = "ParkeringspladserCoil",
                    TargetsUniqueId = new Guid("bbbe8963-4b35-4296-b65c-b59dc56d9ce4")
                },
                new
                {
                    SourcesUniqueId = "ParkeringspladserCoil",
                    TargetsUniqueId = new Guid("d6a9d08d-89de-494c-9407-bfb41c127326")
                },
                new
                {
                    SourcesUniqueId = "ParkeringspladserCoil",
                    TargetsUniqueId = new Guid("5b6ad768-f117-4479-961f-e3b1ac78a551")
                },
                new
                {
                    SourcesUniqueId = "ParkeringspladserCoil",
                    TargetsUniqueId = new Guid("9786c861-8af0-430f-9fc1-a0ae5414680b")
                },
                new
                {
                    SourcesUniqueId = "ParkeringspladserCoil",
                    TargetsUniqueId = new Guid("b195d8f5-10ee-4929-ae20-2c321572095c")
                },
                new
                {
                    SourcesUniqueId = "ParkeringspladserCoil",
                    TargetsUniqueId = new Guid("8fc01bc7-0167-432e-9249-a84165eeaa59")
                },
                new
                {
                    SourcesUniqueId = "ParkeringspladserCoil",
                    TargetsUniqueId = new Guid("eaec4d67-1df5-49a7-8b05-0762b074317a")
                },
                new
                {
                    SourcesUniqueId = "ParkeringspladserCoil",
                    TargetsUniqueId = new Guid("644a17ab-3272-4f64-baeb-e0c4d6cb148c")
                },
                new
                {
                    SourcesUniqueId = "ParkeringspladserCoil",
                    TargetsUniqueId = new Guid("69da3b5b-8112-49d6-a8e9-c8d5ebf7b61a")
                },
                new
                {
                    SourcesUniqueId = "ParkeringspladserCoil",
                    TargetsUniqueId = new Guid("e19b29bd-5902-48b8-b62a-94f248e85dac")
                },
                new
                {
                    SourcesUniqueId = "ParkeringspladserCoil",
                    TargetsUniqueId = new Guid("78bd5e26-d9e2-46b0-9cb0-3ec9d8c7875b")
                }
                ))
                ;
        }
    }
}