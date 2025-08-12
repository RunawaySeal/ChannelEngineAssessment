using ChannelEngineAssessment.Domain.Enums;
using ChannelEngineAssessment.Domain.Models.ApiResponses;
using ChannelEngineAssessment.Domain.Models.Orders;
using ChannelEngineAssessment.Domain.Repositories.Orders;

namespace ChannelEngineAssessment.Tests
{
  public class MockOrderRepo : IOrderRepo
  {
    public Task<ListResponse<Order>?> GetOrdersAsync(OrderFilters? filters)
    {
      var orders = new List<Order>
            {
                new() {
                    Id = 1,
                    Status = OrderStatus.IN_PROGRESS,
                    Lines =
                    [
                        new() { MerchantProductNo = "PROD001", Description = "Product A", Gtin = "GTIN001", Quantity = 20 },
                        new() { MerchantProductNo = "PROD002", Description = "Product B", Gtin = "GTIN002", Quantity = 15 },
                        new() { MerchantProductNo = "PROD003", Description = "Product C", Gtin = "GTIN003", Quantity = 10 }
                    ]
                },
                new() {
                    Id = 2,
                    Status = OrderStatus.IN_PROGRESS,
                    Lines =
                    [
                        new() { MerchantProductNo = "PROD001", Description = "Product A", Gtin = "GTIN001", Quantity = 30 }, // Total: 50
                        new() { MerchantProductNo = "PROD002", Description = "Product B", Gtin = "GTIN002", Quantity = 25 }, // Total: 40
                        new() { MerchantProductNo = "PROD004", Description = "Product D", Gtin = "GTIN004", Quantity = 20 },
                        new() { MerchantProductNo = "PROD005", Description = "Product E", Gtin = "GTIN005", Quantity = 10 }
                    ]
                },
                new() {
                    Id = 3,
                    Status = OrderStatus.IN_PROGRESS,
                    Lines = 
                    [
                        new() { MerchantProductNo = "PROD003", Description = "Product C", Gtin = "GTIN003", Quantity = 20 }, // Total: 30
                        new() { MerchantProductNo = "PROD006", Description = "Product F", Gtin = "GTIN006", Quantity = 5 }
                    ]
                }
            };

      var response = new ListResponse<Order>
      {
        Content = orders,
        Success = true,
        Count = orders.Count,
        TotalCount = orders.Count
      };

      return Task.FromResult<ListResponse<Order>?>(response);
    }
  }
}
