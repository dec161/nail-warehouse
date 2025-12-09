using Microsoft.Extensions.Logging;
using NailWarehouse.Constants;
using NailWarehouse.Entities.Models;
using NailWarehouse.EntityExtensions;
using NailWarehouse.EntityManager.Contracts;
using NailWarehouse.MemoryStorage.Contracts;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace NailWarehouse.EntityManager;

/// <summary>
/// Класс для управления хранилищем.
/// </summary>
public class NailManager(IStorage<Nail> storage, ILoggerFactory loggerFactory) : INailManager
{
    private const string LogMessageTemplate = "Метод {MethodName} выполнен за {ElapsedMilliseconds} мс";

    private IStorage<Nail> Storage { get; } = storage;

    private ILogger Logger { get; } = loggerFactory.CreateLogger<NailManager>();

    public Task Add(Nail nail, CancellationToken cancellationToken = default) =>
        LogPerformance(() => Storage.Add(nail, cancellationToken));

    public Task<IEnumerable<Nail>> GetAll(CancellationToken cancellationToken = default) =>
        LogPerformance(() => Storage.GetAll(cancellationToken));

    public Task Remove(Nail nail, CancellationToken cancellationToken = default) =>
        LogPerformance(() => Storage.Remove(nail, cancellationToken));

    public Task<NailStatistics> GetStatistics(CancellationToken cancellationToken = default) =>
        LogPerformanceAsync(async () =>
        {
            var nails = await GetAll(cancellationToken);

            var count = nails.Count();
            var totalPrice = nails.Sum(nail => nail.CalculateTotalPrice());
            var taxedTotalPrice = (1 + NailConstants.Tax) * totalPrice;

            return new NailStatistics()
            {
                TotalRows = count,
                TotalPrice = totalPrice,
                TaxedTotalPrice = taxedTotalPrice,
                Tax = NailConstants.Tax
            };
        });

    public Task Update(Nail nail, CancellationToken cancellationToken = default) =>
        LogPerformance(() => Storage.Update(nail, cancellationToken));

    private T LogPerformance<T>(Func<T> func,
        [CallerMemberName] string callerMemberName = "")
    {
        var stopwatch = Stopwatch.StartNew();
        var result = func();
        stopwatch.Stop();

        Logger.LogInformation(LogMessageTemplate,
            callerMemberName,
            stopwatch.Elapsed.TotalMilliseconds);

        return result;
    }

    private async Task<T> LogPerformanceAsync<T>(Func<Task<T>> func,
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
