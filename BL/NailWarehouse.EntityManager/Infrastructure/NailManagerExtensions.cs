using Microsoft.Extensions.Logging;
using NailWarehouse.EntityManager.Contracts;

namespace NailWarehouse.EntityManager.Infrastructure;

/// <summary>
/// Расширения для <see cref="NailManager"/>.
/// </summary>
public static class NailManagerExtensions
{
    /// <summary>
    /// Добавляет логирование производительности
    /// к методам <paramref name="nailManager"/>.
    /// </summary>
    public static INailManager WithPerformanceLogging(
        this INailManager nailManager,
        ILogger<TimedNailManager> logger) =>
        new TimedNailManager(nailManager, logger);
}
