using Domain.DL.Models.LifeformModels;
using Domain.DL.Models.MessageModels;
using Domain.DL.Models.UserModels;
using Microsoft.EntityFrameworkCore;

namespace Domain.IPL.Context;
public sealed class DomainContext : DbContext
{
    public DomainContext(DbContextOptions<DomainContext> options) : base(options)
    {
    }

    internal DbSet<Message> Messages { get; set; }
    internal DbSet<User> Users { get; set; }
    internal DbSet<Animalia> Animalia { get; set; }
    internal DbSet<Plantae> Plantae { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Value objects
        modelBuilder.Entity<Message>()
            .OwnsMany(e => e.Likes, e => { e.ToTable("Message_Likes"); });
        modelBuilder.Entity<Message>()
            .OwnsOne(e => e.Data);

        modelBuilder.Entity<User>()
            .OwnsOne(e => e.Name);

        // Indexes
    }
}
