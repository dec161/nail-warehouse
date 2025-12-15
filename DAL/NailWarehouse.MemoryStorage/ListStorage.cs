using NailWarehouse.Entities.Models;
using NailWarehouse.MemoryStorage.Contracts;

namespace NailWarehouse.MemoryStorage;

/// <summary>
/// Хранилище в виде списка.
/// </summary>
public class ListStorage : IStorage<Nail>
{
    private List<Nail> List { get; } =
    [
        new()
        {
            Name = "Строительные гвозди",
            Size = new(3.5f, 90u),
            Material = Material.Chrome,
            Amount = 2u,
            MinAmount = 1u,
            Price = 3m
        },
        new()
        {
            Name = "Гвозди с потайной головкой",
            Size = new(4f, 100u),
            Material = Material.Steel,
            Amount = 4u,
            MinAmount = 2u,
            Price = 6m
        },
        new()
        {
            Name = "Ершеные гвозди",
            Size = new(2f, 150u),
            Material = Material.Iron,
            Amount = 5u,
            MinAmount = 2u,
            Price = 4.5m
        }
    ];

    public Task Add(Nail nail, CancellationToken cancellationToken = default)
    {
        List.Add(nail);
        return Task.CompletedTask;
    }

    public Task<IEnumerable<Nail>> GetAll(CancellationToken cancellationToken = default)
    {
        var result = List.AsEnumerable();
        return Task.FromResult(result);
    }

    public Task Remove(Nail nail, CancellationToken cancellationToken = default)
    {
        List.Remove(nail);
        return Task.CompletedTask;
    }
}
