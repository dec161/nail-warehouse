using FluentAssertions;
using Microsoft.Extensions.Logging;
using Moq;
using NailWarehouse.Entities.Models;
using NailWarehouse.EntityManager.Contracts;
using NailWarehouse.MemoryStorage.Contracts;

namespace NailWarehouse.EntityManager.Tests;

/// <summary>
/// Тесты для <see cref="NailManager"/>.
/// </summary>
public class NailManagerTests
{
    private readonly CancellationToken cancellationToken = CancellationToken.None;
    private readonly Mock<IStorage<Nail>> storageMock = new();
    private readonly NailManager nailManager;

    /// <summary>
    /// Создаёт объект <see cref="NailManagerTests"/>.
    /// </summary>
    public NailManagerTests()
    {
        var loggerFactory = Mock.Of<ILoggerFactory>(
            factory => factory.CreateLogger(It.IsAny<string>()) == Mock.Of<ILogger>());
        nailManager = new(storageMock.Object, loggerFactory);
    }

    /// <summary>
    /// <see cref="NailManager.Add(Nail, CancellationToken)"/> должен работать.
    /// </summary>
    [Fact]
    public async Task AddShouldWork()
    {
        // Arrange
        var nail = new Nail();

        // Act
        await nailManager.Add(nail, cancellationToken);

        // Assert
        storageMock.Verify(mock => mock.Add(nail, cancellationToken), Times.Once());
        storageMock.VerifyNoOtherCalls();
    }

    /// <summary>
    /// <see cref="NailManager.Remove(Nail, CancellationToken)"/> должен работать.
    /// </summary>
    [Fact]
    public async Task RemoveShouldWork()
    {
        // Arrange
        var nail = new Nail();

        // Act
        await nailManager.Remove(nail, cancellationToken);

        // Assert
        storageMock.Verify(mock => mock.Remove(nail, cancellationToken), Times.Once());
        storageMock.VerifyNoOtherCalls();
    }

    /// <summary>
    /// <see cref="NailManager.GetAll(CancellationToken)"/>
    /// должен вернуть пустой <see cref="IEnumerable{T}"/>.
    /// </summary>
    [Fact]
    public async Task GetAllShouldReturnEmpty()
    {
        // Arrange
        storageMock.Setup(mock => mock.GetAll(cancellationToken))
            .ReturnsAsync([]);

        // Act
        var actual = await nailManager.GetAll(cancellationToken);

        // Assert
        actual.Should().BeEmpty();
    }

    /// <summary>
    /// <see cref="NailManager.GetAll(CancellationToken)"/>
    /// должен вернуть <see cref="IEnumerable{T}"/> со значением.
    /// </summary>
    [Fact]
    public async Task GetAllShouldReturnValue()
    {
        // Arrange
        var expected = new List<Nail>()
        {
            new()
        };
        storageMock.Setup(mock => mock.GetAll(cancellationToken))
            .ReturnsAsync(expected);

        // Act
        var actual = await nailManager.GetAll(cancellationToken);

        // Assert
        actual.Should().BeEquivalentTo(expected);
    }

    /// <summary>
    /// <see cref="NailManager.GetStatistics(CancellationToken)"/> должен работать.
    /// </summary>
    [Fact]
    public async Task GetStatisticsShouldWork()
    {
        // Arrange
        var list = new List<Nail>()
        {
            new()
            {
                Amount = 2u,
                Price = 3m
            },
            new()
            {
                Amount = 5u,
                Price = 7m
            }
        };
        storageMock.Setup(mock => mock.GetAll(cancellationToken))
            .ReturnsAsync(list);
        var expected = new NailStatistics()
        {
            TotalRows = 2,
            TotalPrice = 41m,
            TaxedTotalPrice = 49.2m,
            Tax = 0.2m
        };

        // Act
        var actual = await nailManager.GetStatistics(cancellationToken);

        // Assert
        actual.Should().BeEquivalentTo(expected);
    }
}
