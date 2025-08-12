using ChannelEngineAssessment.Domain.ApplicationServices.Orders;
using ChannelEngineAssessment.Domain.Enums;
using ChannelEngineAssessment.Domain.Models.Orders;

namespace ChannelEngineAssessment.Tests.Orders
{
  public class OrderServiceTests
  {
    [Fact]
    public async Task GetOrdersAsync_WithInProgressFilter_ReturnsFilteredOrders()
    {
      // Arrange
      var mockOrderRepo = new MockOrderRepo();
      var orderService = new OrderService(null, mockOrderRepo);

      var orderFilters = new OrderFilters
      {
        Statuses = [OrderStatus.IN_PROGRESS]
      };

      // Act
      var result = await orderService.GetOrdersAsync(orderFilters);

      // Assert
      Assert.NotNull(result);
      Assert.True(result.Success);
      Assert.Equal(3, result.Count);
      Assert.Equal(3, result.Content.Count());

      var orders = result.Content.ToList();

      // Verify all returned orders have IN_PROGRESS status
      Assert.All(orders, order => Assert.Equal(OrderStatus.IN_PROGRESS, order.Status));

      // Verify specific order details
      var firstOrder = orders.First(o => o.Id == 1);
      Assert.Equal("Test Channel 1", firstOrder.ChannelName);
      Assert.Equal(3, firstOrder.Lines.Count);
      Assert.Contains(firstOrder.Lines, line => line.Description == "Product A" && line.Quantity == 20);

      var secondOrder = orders.First(o => o.Id == 2);
      Assert.Equal("Test Channel 2", secondOrder.ChannelName);
      Assert.Equal(4, secondOrder.Lines.Count);
      Assert.Contains(secondOrder.Lines, line => line.Description == "Product A" && line.Quantity == 30);

      var thirdOrder = orders.First(o => o.Id == 3);
      Assert.Equal("Test Channel 3", thirdOrder.ChannelName);
      Assert.Equal(2, thirdOrder.Lines.Count);
      Assert.Contains(thirdOrder.Lines, line => line.Description == "Product C" && line.Quantity == 20);
    }
  }
}
