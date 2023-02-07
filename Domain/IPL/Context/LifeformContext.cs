using Domain.DL.Models.LifeformModels;
using Microsoft.EntityFrameworkCore;

namespace Domain.IPL.Context;
public sealed class LifeformContext : DbContext
{
    public LifeformContext(DbContextOptions<LifeformContext> options) : base(options)
    {
    }
    internal DbSet<Animalia> Animalia { get; set; }
    internal DbSet<Plantae> Plantae { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Eukaryote>().UseTpcMappingStrategy();
        //modelBuilder.Entity<Plantae>().UseTpcMappingStrategy();

        // Value objects
        modelBuilder.Entity<Plantae>()
            .OwnsMany(e => e.Messages, e => { e.ToTable("Plantae_Messages"); });
        modelBuilder.Entity<Animalia>()
            .OwnsMany(e => e.Messages, e => { e.ToTable("Animalia_Messages"); });

        // Indexes
    }
}
