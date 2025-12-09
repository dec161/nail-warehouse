using Microsoft.EntityFrameworkCore;
using NailWarehouse.Entities.Models;
using NailWarehouse.MemoryStorage.Contracts;

namespace NailWarehouse.DatabaseStorage;

/// <summary>
/// Хранилище в виде базы данных.
/// </summary>
public class NailDatabaseStorage : IStorage<Nail>
{
    public async Task Add(Nail item, CancellationToken cancellationToken = default)
    {
        using var database = new NailDatabaseContext();
        await database.Nails.AddAsync(item, cancellationToken);
        await database.SaveChangesAsync(cancellationToken);
    }

    public async Task<IEnumerable<Nail>> GetAll(CancellationToken cancellationToken = default)
    {
        using var database = new NailDatabaseContext();
        var nails = await database.Nails.AsNoTracking().ToListAsync(cancellationToken);
        return nails;
    }

    public async Task Remove(Nail item, CancellationToken cancellationToken = default)
    {
        using var database = new NailDatabaseContext();
        database.Remove(item);
        await database.SaveChangesAsync(cancellationToken);
    }

    public async Task Update(Nail item, CancellationToken cancellationToken = default)
    {
        using var database = new NailDatabaseContext();
        database.Nails.Update(item);
        await database.SaveChangesAsync(cancellationToken);

    }
}
