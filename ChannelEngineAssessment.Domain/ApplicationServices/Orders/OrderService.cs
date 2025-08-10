using ChannelEngineAssessment.Domain.Models;
using ChannelEngineAssessment.Domain.Models.Orders;
using ChannelEngineAssessment.Domain.Repositories.Orders;
using Serilog;
using System.Net;

namespace ChannelEngineAssessment.Domain.ApplicationServices.Orders
{
  public class OrderService(ILogger logger, IOrderRepo orderRepo) : BaseService(logger)
  {
    private readonly IOrderRepo _orderRepo = orderRepo;

    public async Task<Response<Order>?> GetOrdersAsync(OrderFilters filters)
    {
      try
      {
        return await _orderRepo.GetOrdersAsync(filters);
      }
      catch (Exception ex)
      {
        SetDomainError(HttpStatusCode.NotFound, ex.Message);
        return default;
      }
    }
  }
}
