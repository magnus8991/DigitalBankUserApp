using Microsoft.EntityFrameworkCore;
using UserApp.Models;

namespace UserApp.Data.Context;

public class UserDbContext(DbContextOptions<UserDbContext> options) : DbContext(options)
{
    public DbSet<User> Users => Set<User>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(u => u.Id);
            entity.Property(u => u.Name).IsRequired().HasMaxLength(100);
            entity.Property(u => u.BirthDate);
            entity.Property(u => u.Gender).IsRequired();
        });
    }
}