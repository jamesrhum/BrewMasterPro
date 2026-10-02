using BrewMaster.Core.Models;
using BrewMaster.Core.Services;

namespace BrewMaster.Tests
{
    public class PaymentServiceTests
    {
        [Fact]
        public void TryProcessPayment_ReturnsFalse_WhenPaidLessThanTotal()
        {
            // Arrange
            var service = new PaymentService();
            decimal total = 10.00m;
            decimal paid = 5.00m;

            // Act
            var result = service.TryProcessPayment(total, paid, out var change);

            // Assert
            Assert.False(result);
            Assert.Equal(0m, change);
        }

        [Fact]
        public void TryProcessPayment_ReturnsTrueAndZeroChange_WhenPaidEqualsTotal()
        {
            // Arrange
            var service = new PaymentService();
            decimal total = 10.00m;
            decimal paid = 10.00m;

            // Act
            var result = service.TryProcessPayment(total, paid, out var change);

            // Assert
            Assert.True(result);
            Assert.Equal(0m, change);
        }

        [Fact]
        public void TryProcessPayment_ReturnsTrueAndCorrectChange_WhenPaidGreaterThanTotal()
        {
            // Arrange
            var service = new PaymentService();
            decimal total = 8.75m;
            decimal paid = 10.00m;

            // Act
            var result = service.TryProcessPayment(total, paid, out var change);

            // Assert
            Assert.True(result);
            Assert.Equal(1.25m, change);
        }
    }
}