using ChannelEngineAssessment.Domain.Models.Orders;
using ChannelEngineAssessment.Domain.Models.Products;
using ChannelEngineAssessment.Domain.Repositories.Orders;
using Serilog;
using System.Net;

namespace ChannelEngineAssessment.Domain.ApplicationServices.Products
{
  public class ProductService(ILogger logger, IOrderRepo orderRepo) : BaseService(logger)
  {
    private readonly IOrderRepo _orderRepo = orderRepo;

    public async Task<IEnumerable<Product>?> GetTopProductsAsync(OrderFilters? filters = null, int count = 5)
    {
      try
      {
        var orders = await _orderRepo.GetOrdersAsync(filters);
        var products = orders?.Content.SelectMany(o => o.Lines)
                                      .GroupBy(ol => ol.MerchantProductNo)
                                      .Select(ol => new Product()
                                      {
                                        TotalQuantitySold = ol.Sum(item => item.Quantity),
                                        MerchantProductNo = ol.Key,
                                        Name = ol.First().Description
                                      })
                                      .OrderBy(p => p.TotalQuantitySold)
                                      .Take(count);

        return products;
      }
      catch (Exception ex)
      {
        SetDomainError(HttpStatusCode.NotFound, ex.Message);
        return default;
      }
    }
  }
}
