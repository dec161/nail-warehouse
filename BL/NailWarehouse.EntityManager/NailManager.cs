using NailWarehouse.Constants;
using NailWarehouse.Entities.Models;
using NailWarehouse.EntityManager.Contracts;
using NailWarehouse.MemoryStorage.Contracts;

namespace NailWarehouse.EntityManager;

/// <summary>
/// Класс для управления хранилищем.
/// </summary>
public class NailManager(IStorage<Nail> storage) : INailManager
{
    private IStorage<Nail> Storage { get; } = storage;

    public Task Add(Nail nail, CancellationToken cancellationToken = default) =>
        Storage.Add(nail, cancellationToken);

    public Task<IEnumerable<Nail>> GetAll(CancellationToken cancellationToken = default) =>
        Storage.GetAll(cancellationToken);

    public Task Remove(Nail nail, CancellationToken cancellationToken = default) =>
        Storage.Remove(nail, cancellationToken);

    public async Task<NailStatistics> GetStatistics(CancellationToken cancellationToken = default)
    {
        var nails = await GetAll(cancellationToken);

        var count = nails.Count();
        var totalPrice = nails.Sum(CalculateTotalPrice);
        var taxedTotalPrice = (1 + NailConstants.Tax) * totalPrice;

        return new NailStatistics()
        {
            TotalRows = count,
            TotalPrice = totalPrice,
            TaxedTotalPrice = taxedTotalPrice,
            Tax = NailConstants.Tax
        };
    }

    /// <summary>
    /// Считает общую сумму товара.
    /// </summary>
    public static decimal CalculateTotalPrice(Nail item) =>
        item.Amount * item.Price;
}
