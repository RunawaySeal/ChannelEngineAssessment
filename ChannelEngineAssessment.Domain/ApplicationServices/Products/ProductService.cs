using ChannelEngineAssessment.Domain.Models.Offers;
using ChannelEngineAssessment.Domain.Models.Orders;
using ChannelEngineAssessment.Domain.Models.Products;
using ChannelEngineAssessment.Domain.Repositories.Offers;
using ChannelEngineAssessment.Domain.Repositories.Orders;
using Serilog;
using System.Net;

namespace ChannelEngineAssessment.Domain.ApplicationServices.Products
{
  public class ProductService(ILogger logger, IOrderRepo orderRepo, IOffersRepo offersRepo) : BaseService(logger)
  {
    private readonly IOrderRepo _orderRepo = orderRepo;
    private readonly IOffersRepo _offersRepo = offersRepo;

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
                                        GTIN = ol.FirstOrDefault()?.Gtin,
                                        Name = ol.FirstOrDefault()?.Description ?? string.Empty,
                                        StockLocation = ol.FirstOrDefault()?.StockLocation
                                      })
                                      .OrderByDescending(p => p.TotalQuantitySold)
                                      .Take(count);

        return products;
      }
      catch (Exception ex)
      {
        SetDomainError(HttpStatusCode.NotFound, ex.Message);
        return default;
      }
    }

    public async Task<StockUpdateResult?> SetProductStockAsync(IEnumerable<Product> products)
    {
      try
      {
        var productUpdateModel = products.Select(p => new ProductStockUpdate()
        {
          MerchantProductNo = p.MerchantProductNo,
          StockLocations = new List<StockLocation>()
          {
            p.StockLocation
          }
        });

        var response = await _offersRepo.UpdateStock(productUpdateModel);

        return response.Content;
      }
      catch (Exception ex)
      {
        SetDomainError(HttpStatusCode.NotFound, ex.Message);
        return default;
      }
    }
  }
}
