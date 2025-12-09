using NailWarehouse.Entities.Models;

namespace NailWarehouse.EntityManager.Contracts;

/// <summary>
/// Интерфейс для управления хранилищем.
/// </summary>
public interface INailManager
{
    /// <summary>
    /// Добавляет товар во внутреннее хранилище.
    /// </summary>
    Task Add(Nail nail, CancellationToken cancellationToken = default);

    /// <summary>
    /// Получает список всех товаров в хранилище.
    /// </summary>
    Task<IEnumerable<Nail>> GetAll(CancellationToken cancellationToken = default);

    /// <summary>
    /// Удаляет товар из внутреннего хранилища.
    /// </summary>
    Task Remove(Nail nail, CancellationToken cancellationToken = default);

    /// <summary>
    /// Получает статистику о товарах.
    /// </summary>
    Task<NailStatistics> GetStatistics(CancellationToken cancellationToken = default);

    /// <summary>
    /// Обновляет товар во внутреннем хранилище.
    /// </summary>
    Task Update(Nail nail, CancellationToken cancellationToken = default);
}
