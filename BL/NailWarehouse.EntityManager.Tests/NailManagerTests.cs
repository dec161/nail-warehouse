using FluentAssertions;
using Moq;
using NailWarehouse.Entities.Models;
using NailWarehouse.MemoryStorage.Contracts;

namespace NailWarehouse.EntityManager.Tests;

public class NailManagerTests
{
    public class SingleItemOperations
    {
        private readonly CancellationToken cancellationToken = CancellationToken.None;
        private readonly Nail nail = new();
        private readonly Mock<IStorage<Nail>> mock = new();
        private readonly Task expected = Task.CompletedTask;
        private readonly NailManager nailManager;

        public SingleItemOperations() =>
            nailManager = new(mock.Object);

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

    public class CollectionOperations
    {
        private readonly CancellationToken cancellationToken = CancellationToken.None;
        private readonly Mock<IStorage<Nail>> mock = new();
        private readonly NailManager nailManager;

        public CollectionOperations() =>
            nailManager = new(mock.Object);

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
