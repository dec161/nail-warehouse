using NailWarehouse.Entities.Models;

namespace NailWarehouse.EntityExtensions;

/// <summary>
/// Расширения для <see cref="Nail"/>.
/// </summary>
public static class NailExtensions
{
    /// <summary>
    /// Считает общую сумму товара.
    /// </summary>
    public static decimal CalculateTotalPrice(this Nail nail) =>
        nail.Amount * nail.Price;
}
