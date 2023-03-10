using Domain.DL.Models.MessageModels;
using Microsoft.EntityFrameworkCore;

namespace Domain.IPL.Context;
public sealed class MessageContext : DbContext
{
    public MessageContext(DbContextOptions<MessageContext> options) : base(options)
    {
    }

    internal DbSet<Message> Messages { get; set; }
    internal DbSet<Author> Authors { get; set; }
    internal DbSet<Lifeform> Eukaryotes { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Value objects
        modelBuilder.Entity<Message>()
            .OwnsMany(e => e.Likes, e => { e.ToTable("Message_Likes"); });
        modelBuilder.Entity<Message>()
            .OwnsOne(e => e.Data);
        modelBuilder.Entity<Message>()
            .OwnsMany(e => e.Likes);
        modelBuilder.Entity<Author>()
            .OwnsMany(e => e.Likes);

        // Primary Key
        modelBuilder.Entity<Author>()
            .Property(e => e.Id)
            .ValueGeneratedNever();
        modelBuilder.Entity<Lifeform>()
            .Property(e => e.Id)
            .ValueGeneratedNever();
    }
}
