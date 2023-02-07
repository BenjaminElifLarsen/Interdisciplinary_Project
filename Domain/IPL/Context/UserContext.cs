using Domain.DL.Models.UserModels;
using Microsoft.EntityFrameworkCore;

namespace Domain.IPL.Context;
public sealed class UserContext : DbContext
{
    public UserContext(DbContextOptions<UserContext> options) : base(options)
    {
    }

    internal DbSet<User> Users { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Value objects
        modelBuilder.Entity<User>()
            .OwnsOne(e => e.Name);
        modelBuilder.Entity<User>()
            .OwnsMany(e => e.Likes, e => { e.ToTable("User_Likes"); });
        modelBuilder.Entity<User>()
            .OwnsMany(e => e.Messages, e => { e.ToTable("User_Messages"); });
        // Indexes
    }
}
