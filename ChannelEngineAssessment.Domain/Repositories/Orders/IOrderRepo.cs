using ChannelEngineAssessment.Domain.Models;
using ChannelEngineAssessment.Domain.Models.Orders;

namespace ChannelEngineAssessment.Domain.Repositories.Orders
{
  public interface IOrderRepo
  {
    public Task<Response<Order>?> GetOrdersAsync(OrderFilters? filters);
  }
}
