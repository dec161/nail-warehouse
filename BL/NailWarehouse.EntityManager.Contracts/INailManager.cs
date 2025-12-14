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
    /// Получает товар по его идентификатору.
    /// </summary>
    /// <returns>
    /// Объект <see cref="Nail"/> с <see cref="Nail.Id"/>, равным <paramref name="id"/>,
    /// если такой есть в хранилище; <c>null</c> иначе.
    /// </returns>
    Task<Nail?> Get(Guid id, CancellationToken cancellationToken = default);

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
