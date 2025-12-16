using NailWarehouse.Entities.Models;
using NailWarehouse.EntityManager.Contracts;

namespace NailWarehouse.MvcApp.Models;

/// <summary>
/// Модель презентации для главной страницы.
/// </summary>
public class IndexViewModel
{
    /// <summary>
    /// Список объектов для отображения.
    /// </summary>
    public required IEnumerable<Nail> Nails { get; init; }

    /// <summary>
    /// Статистика.
    /// </summary>
    public required NailStatistics Statistics { get; init; }
}
