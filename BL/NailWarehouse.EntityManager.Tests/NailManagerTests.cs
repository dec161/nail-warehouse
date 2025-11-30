using FluentAssertions;
using Moq;
using NailWarehouse.Entities.Models;
using NailWarehouse.MemoryStorage.Contracts;

namespace NailWarehouse.EntityManager.Tests;

/// <summary>
/// Тесты для <see cref="NailManager"/>.
/// </summary>
public class NailManagerTests
{
    /// <summary>
    /// <see cref="NailManager.Add(Nail, CancellationToken)"/> должен работать.
    /// </summary>
    [Fact]
    public async Task AddShouldWork()
    {
        // Arrange
        var cancellationToken = CancellationToken.None;
        var nail = new Nail();
        var storage = Mock.Of<IStorage<Nail>>(
            mock => mock.Add(nail, cancellationToken) == Task.CompletedTask);
        var nailManager = new NailManager(storage);

        // Act
        await nailManager.Add(nail, cancellationToken);

        // Assert
        Mock.Get(storage).Verify(mock => mock.Add(nail, cancellationToken), Times.Once());
        Mock.Get(storage).VerifyNoOtherCalls();
    }

    /// <summary>
    /// <see cref="NailManager.Add(Nail, CancellationToken)"/> должен
    /// сгенерировать <see cref="OperationCanceledException"/>.
    /// </summary>
    [Fact]
    public async Task AddShouldThrowOperationCanceledException()
    {
        // Arrange
        var cancellationTokenSource = new CancellationTokenSource();
        cancellationTokenSource.Cancel();
        var cancelledCancellationToken = cancellationTokenSource.Token;
        var nail = new Nail();
        var mock = new Mock<IStorage<Nail>>();
        mock.Setup(storage => storage.Add(nail, cancelledCancellationToken))
            .ThrowsAsync(new OperationCanceledException());
        var nailManager = new NailManager(mock.Object);

        // Act
        var act = async () => await nailManager.Add(nail, cancelledCancellationToken);

        // Assert
        await act.Should().ThrowAsync<OperationCanceledException>();
    }

    /// <summary>
    /// <see cref="NailManager.Remove(Nail, CancellationToken)"/> должен работать.
    /// </summary>
    [Fact]
    public async Task RemoveShouldWork()
    {
        // Arrange
        var cancellationToken = CancellationToken.None;
        var nail = new Nail();
        var storage = Mock.Of<IStorage<Nail>>(
            mock => mock.Remove(nail, cancellationToken) == Task.CompletedTask);
        var nailManager = new NailManager(storage);

        // Act
        await nailManager.Remove(nail, cancellationToken);

        // Assert
        Mock.Get(storage).Verify(mock => mock.Remove(nail, cancellationToken), Times.Once());
        Mock.Get(storage).VerifyNoOtherCalls();
    }

    /// <summary>
    /// <see cref="NailManager.Remove(Nail, CancellationToken)"/> должен
    /// сгенерировать <see cref="OperationCanceledException"/>.
    /// </summary>
    [Fact]
    public async Task RemoveShouldThrowOperationCanceledException()
    {
        // Arrange
        var cancellationTokenSource = new CancellationTokenSource();
        cancellationTokenSource.Cancel();
        var cancelledCancellationToken = cancellationTokenSource.Token;
        var nail = new Nail();
        var mock = new Mock<IStorage<Nail>>();
        mock.Setup(storage => storage.Remove(nail, cancelledCancellationToken))
            .ThrowsAsync(new OperationCanceledException());
        var nailManager = new NailManager(mock.Object);

        // Act
        var act = async () => await nailManager.Remove(nail, cancelledCancellationToken);

        // Assert
        await act.Should().ThrowAsync<OperationCanceledException>();
    }

    /// <summary>
    /// <see cref="NailManager.GetAll(CancellationToken)"/>
    /// должен вернуть пустой <see cref="IEnumerable{T}"/>.
    /// </summary>
    [Fact]
    public async Task GetAllShouldReturnEmpty()
    {
        // Arrange
        var cancellationToken = CancellationToken.None;
        var enumerable = new List<Nail>().AsEnumerable();
        var storage = Mock.Of<IStorage<Nail>>(
            mock => mock.GetAll(cancellationToken) == Task.FromResult(enumerable));
        var nailManager = new NailManager(storage);

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
        var cancellationToken = CancellationToken.None;
        var expected = new List<Nail>()
        {
            new()
        }.AsEnumerable();
        var storage = Mock.Of<IStorage<Nail>>(
            mock => mock.GetAll(cancellationToken) == Task.FromResult(expected));
        var nailManager = new NailManager(storage);

        // Act
        var actual = await nailManager.GetAll(cancellationToken);

        // Assert
        actual.Should().BeEquivalentTo(expected);
    }

    /// <summary>
    /// <see cref="NailManager.GetAll(CancellationToken)"/> должен
    /// сгенерировать <see cref="OperationCanceledException"/>.
    /// </summary>
    [Fact]
    public async Task GetAllShouldThrowOperationCanceledException()
    {
        // Arrange
        var cancellationTokenSource = new CancellationTokenSource();
        cancellationTokenSource.Cancel();
        var cancelledCancellationToken = cancellationTokenSource.Token;
        var mock = new Mock<IStorage<Nail>>();
        mock.Setup(storage => storage.GetAll(cancelledCancellationToken))
            .ThrowsAsync(new OperationCanceledException());
        var nailManager = new NailManager(mock.Object);

        // Act
        var act = async () => await nailManager.GetAll(cancelledCancellationToken);

        // Assert
        await act.Should().ThrowAsync<OperationCanceledException>();
    }

    /// <summary>
    /// <see cref="NailManager.GetStatistics(CancellationToken)"/>
    /// не должен генерировать исключение.
    /// </summary>
    [Fact]
    public async Task GetStatisticsShouldNotThrow()
    {
        // Arrange
        var cancellationToken = CancellationToken.None;
        var list = new List<Nail>();
        var storage = Mock.Of<IStorage<Nail>>(
            mock => mock.GetAll(cancellationToken) == Task.FromResult(list.AsEnumerable()));
        var nailManager = new NailManager(storage);

        // Act
        var act = async () => await nailManager.GetStatistics(cancellationToken);

        // Assert
        await act.Should().NotThrowAsync();
    }

    /// <summary>
    /// <see cref="NailManager.GetStatistics(CancellationToken)"/> должен работать.
    /// </summary>
    [Fact]
    public async Task GetStatisticsShouldWork()
    {
        // Arrange
        var cancellationToken = CancellationToken.None;
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
                },
            };
        var storage = Mock.Of<IStorage<Nail>>(
            mock => mock.GetAll(cancellationToken) == Task.FromResult(list.AsEnumerable()));
        var nailManager = new NailManager(storage);
        var expectedTotalRows = 2;
        var expectedTotalPrice = 41m;
        var expectedTaxedTotalPrice = 49.2m;
        var expectedTax = 0.2m;

        // Act
        var actual = await nailManager.GetStatistics(cancellationToken);

        // Assert
        actual.TotalRows.Should().Be(expectedTotalRows);
        actual.TotalPrice.Should().Be(expectedTotalPrice);
        actual.TaxedTotalPrice.Should().Be(expectedTaxedTotalPrice);
        actual.Tax.Should().Be(expectedTax);
    }

    /// <summary>
    /// <see cref="NailManager.GetStatistics(CancellationToken)"/> должен
    /// сгенерировать <see cref="OperationCanceledException"/>.
    /// </summary>
    [Fact]
    public async Task GetStatisticsShouldThrowOperationCanceledException()
    {
        // Arrange
        var cancellationTokenSource = new CancellationTokenSource();
        cancellationTokenSource.Cancel();
        var cancelledCancellationToken = cancellationTokenSource.Token;
        var mock = new Mock<IStorage<Nail>>();
        mock.Setup(storage => storage.GetAll(cancelledCancellationToken))
            .ThrowsAsync(new OperationCanceledException());
        var nailManager = new NailManager(mock.Object);

        // Act
        var act = async () => await nailManager.GetStatistics(cancelledCancellationToken);

        // Assert
        await act.Should().ThrowAsync<OperationCanceledException>();
    }
}
