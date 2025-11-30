using Microsoft.Extensions.Logging;
using NailWarehouse.Entities.Models;
using NailWarehouse.EntityManager.Contracts;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace NailWarehouse.EntityManager;

/// <summary>
/// Обёртка для <see cref="INailManager"/>,
/// логирующая производительность методов.
/// </summary>
public class TimedNailManager(INailManager nailManager, ILogger<TimedNailManager> logger) : INailManager
{
    private const string LogMessageTemplate = "Метод {MethodName} выполнен за {ElapsedMilliseconds} мс";

    private INailManager NailManager { get; } = nailManager;

    private ILogger Logger { get; } = logger;

    public Task Add(Nail nail, CancellationToken cancellationToken = default) =>
        LogPerformance(() => NailManager.Add(nail, cancellationToken));

    public Task<IEnumerable<Nail>> GetAll(CancellationToken cancellationToken = default) =>
        LogPerformance(() => NailManager.GetAll(cancellationToken));

    public Task<NailStatistics> GetStatistics(CancellationToken cancellationToken = default) =>
        LogPerformance(() => NailManager.GetStatistics(cancellationToken));

    public Task Remove(Nail nail, CancellationToken cancellationToken = default) =>
        LogPerformance(() => NailManager.Remove(nail, cancellationToken));

    private async Task LogPerformance(Func<Task> func,
        [CallerMemberName] string callerMemberName = "")
    {
        var stopwatch = Stopwatch.StartNew();
        await func();
        stopwatch.Stop();

        Logger.LogInformation(LogMessageTemplate,
            callerMemberName,
            stopwatch.Elapsed.TotalMilliseconds);
    }

    private async Task<T> LogPerformance<T>(Func<Task<T>> func,
        [CallerMemberName] string callerMemberName = "")
    {
        var stopwatch = Stopwatch.StartNew();
        var result = await func();
        stopwatch.Stop();

        Logger.LogInformation(LogMessageTemplate,
            callerMemberName,
            stopwatch.Elapsed.TotalMilliseconds);

        return result;
    }
}
