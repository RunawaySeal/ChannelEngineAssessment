using ChannelEngineAssessment.Domain.Models.ApiResponses;
using ChannelEngineAssessment.Domain.Models.Orders;

namespace ChannelEngineAssessment.Domain.Repositories.Orders
{
  public interface IOrderRepo
  {
    public Task<ListResponse<Order>?> GetOrdersAsync(OrderFilters? filters);
  }
}
