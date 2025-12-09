using Microsoft.EntityFrameworkCore;
using NailWarehouse.Entities.Models;

namespace NailWarehouse.DatabaseStorage;

/// <inheritdoc/>
public class NailDatabaseContext : DbContext
{
    /// <summary>
    /// Сущность <see cref="Nail"/>.
    /// </summary>
    public DbSet<Nail> Nails { get; set; }

    /// <summary>
    /// Создаёт экземпляр <see cref="NailDatabaseContext"/>.
    /// </summary>
    public NailDatabaseContext() =>
        Database.EnsureCreated();

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) =>
        optionsBuilder.UseSqlServer(
            @"Server=(localdb)\mssqllocaldb;Database=NailDatabase;Trusted_Connection=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder) =>
        modelBuilder.Entity<Nail>(builder => builder.ComplexProperty(nail => nail.Size));
}
