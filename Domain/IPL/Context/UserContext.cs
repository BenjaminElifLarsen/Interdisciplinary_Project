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
        // Indexes
    }
}
