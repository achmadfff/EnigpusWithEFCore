using EnigpusEFCore.Entities;
using Microsoft.EntityFrameworkCore;

namespace EnigpusEFCore.Repositories;

public class EnigpusDBContext : DbContext
{
    public DbSet<Novel> Novels { get; set; }
    public DbSet<Magazine> Magazines { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        string connString = @"Server=DESKTOP-J65MPJ3;Database=EnigpusDB;Trusted_Connection=True;TrustServerCertificate=True;";
        optionsBuilder.UseSqlServer(connString);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {   
        modelBuilder.Entity<Novel>(entity =>
        {
            entity.HasIndex(novel => novel.Code).IsUnique();
        });
        modelBuilder.Entity<Magazine>(entity =>
        {
            entity.HasIndex(magazine => magazine.Code).IsUnique();
        });
    }
}