namespace NailWarehouse.MemoryStorage.Contracts;

/// <summary>
/// Предоставляет асинхронные методы для
/// совершения операций с хранилищем.
/// </summary>
public interface IStorage<T>
{
    /// <summary>
    /// Добавляет предмет в хранилище.
    /// </summary>
    Task Add(T item, CancellationToken cancellationToken = default);

    /// <summary>
    /// Получает список всех предметов в хранилище.
    /// </summary>
    Task<IEnumerable<T>> GetAll(CancellationToken cancellationToken = default);

    /// <summary>
    /// Получает предмет по его идентификатору.
    /// </summary>
    /// <returns>
    /// Объект <see cref="T"/> с идентификатором, равным <paramref name="id"/>,
    /// если такой есть в хранилище; <c>null</c> иначе.
    /// </returns>
    Task<T?> Get(Guid id, CancellationToken cancellationToken = default);

    /// <summary>
    /// Удаляет предмет из хранилища.
    /// </summary>
    Task Remove(T item, CancellationToken cancellationToken = default);

    /// <summary>
    /// Обновляет предмет в хранилище.
    /// </summary>
    Task Update(T item, CancellationToken cancellationToken = default);
}
