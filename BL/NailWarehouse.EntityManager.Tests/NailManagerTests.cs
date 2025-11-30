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
    /// Операции с одним предметом.
    /// </summary>
    public class SingleItemOperations
    {
        private readonly CancellationToken cancellationToken = CancellationToken.None;
        private readonly Nail nail = new();
        private readonly Mock<IStorage<Nail>> mock = new();
        private readonly Task expected = Task.CompletedTask;
        private readonly NailManager nailManager;

        /// <summary>
        /// Создаёт объект <see cref="SingleItemOperations"/>.
        /// </summary>
        public SingleItemOperations() =>
            nailManager = new(mock.Object);

        /// <summary>
        /// <see cref="NailManager.Add(Nail, CancellationToken)"/> должен возвращать
        /// результат вызова <see cref="IStorage{T}.Add(T, CancellationToken)"/>.
        /// </summary>
        [Fact]
        public void AddReturnsAddTask()
        {
            // Arrange
            mock.Setup(storage => storage.Add(nail, cancellationToken))
                .Returns(expected);

            // Act
            var actual = nailManager.Add(nail, cancellationToken);

            // Assert
            actual.Should().BeSameAs(expected);
            mock.Verify(storage => storage.Add(nail, cancellationToken), Times.Once());
            mock.VerifyNoOtherCalls();
        }

        /// <summary>
        /// <see cref="NailManager.Remove(Nail, CancellationToken)"/> должен возвращать
        /// результат вызова <see cref="IStorage{T}.Remove(T, CancellationToken)"/>.
        /// </summary>
        [Fact]
        public void RemoveReturnsRemoveTask()
        {
            // Arrange
            mock.Setup(storage => storage.Remove(nail, cancellationToken))
                .Returns(expected);

            // Act
            var actual = nailManager.Remove(nail, cancellationToken);

            // Assert
            actual.Should().BeSameAs(expected);
            mock.Verify(storage => storage.Remove(nail, cancellationToken), Times.Once());
            mock.VerifyNoOtherCalls();
        }
    }

    /// <summary>
    /// Операции над всей коллекцией.
    /// </summary>
    public class CollectionOperations
    {
        private readonly CancellationToken cancellationToken = CancellationToken.None;
        private readonly Mock<IStorage<Nail>> mock = new();
        private readonly NailManager nailManager;

        /// <summary>
        /// Создаёт объект <see cref="CollectionOperations"/>.
        /// </summary>
        public CollectionOperations() =>
            nailManager = new(mock.Object);

        /// <summary>
        /// <see cref="NailManager.GetAll(CancellationToken)"/> должен возвращать
        /// результат вызова <see cref="IStorage{T}.GetAll(CancellationToken)"/>.
        /// </summary>
        [Fact]
        public void GetAllReturnsGetAllTask()
        {
            // Arrange
            var enumerable = new List<Nail>().AsEnumerable();
            var expected = Task.FromResult(enumerable);
            mock.Setup(storage => storage.GetAll(cancellationToken))
                .Returns(expected);

            // Act
            var actual = nailManager.GetAll(cancellationToken);

            // Assert
            actual.Should().BeSameAs(expected);
            mock.Verify(storage => storage.GetAll(cancellationToken), Times.Once());
            mock.VerifyNoOtherCalls();
        }

        /// <summary>
        /// <see cref="NailManager.GetStatistics(CancellationToken)"/>
        /// должен считать статистику верно.
        /// </summary>
        [Fact]
        public async Task GetStatisticsCalculatesStatisticsCorrectly()
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
                },
            };
            mock.Setup(storage => storage.GetAll(cancellationToken))
                .Returns(Task.FromResult(list.AsEnumerable()));
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
    }
}
