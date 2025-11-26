namespace NailWarehouse.EntityManager.Contracts;

/// <summary>
/// Статистика.
/// </summary>
public class NailStatistics
{
    /// <summary>
    /// Общее количество товарных позиций.
    /// </summary>
    public int TotalRows { get; init; }

    /// <summary>
    /// Общая сумма товаров без НДС.
    /// </summary>
    public decimal TotalPrice { get; init; }

    /// <summary>
    /// Общая сумма товаров с НДС.
    /// </summary>
    public decimal TaxedTotalPrice { get; init; }

    /// <summary>
    /// Процент НДС, использованный в расчётах.
    /// </summary>
    public decimal Tax { get; init; }
}
