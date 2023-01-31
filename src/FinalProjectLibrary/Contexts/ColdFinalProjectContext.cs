using FinalProjectLibrary.Models.ColdModels;
using Microsoft.EntityFrameworkCore;

namespace FinalProjectLibrary;

public class ColdFinalProjectContext : DbContext
{
    public ColdFinalProjectContext(DbContextOptions<ColdFinalProjectContext> options) : base(options)
    {
    }

    public virtual DbSet<ColdStorageMeasurement> ColdStorages { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ColdStorageMeasurement>(entity =>
        {
            entity.HasKey(e => e.UniqueId).HasName("ColdStorage_pkey");

            entity.ToTable("ColdStorage");

            entity.Property(e => e.UniqueId)
                .HasDefaultValueSql("gen_random_uuid()")
                .HasColumnName("UniqueID");
            entity.Property(e => e.EntryTime).HasColumnType("timestamp with time zone");
            entity.Property(e => e.SourceId).HasColumnName("SourceID");
            entity.Property(e => e.TargetId).HasColumnName("TargetID");
        });
    }

}
