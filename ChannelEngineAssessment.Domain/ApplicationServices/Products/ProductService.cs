using ChannelEngineAssessment.Domain.Models.Orders;
using ChannelEngineAssessment.Domain.Models.Products;
using ChannelEngineAssessment.Domain.Repositories.Orders;
using ChannelEngineAssessment.Domain.Repositories.Products;
using Serilog;
using System.Net;

namespace ChannelEngineAssessment.Domain.ApplicationServices.Products
{
  public class ProductService(ILogger logger, IOrderRepo orderRepo, IProductRepo productRepo) : BaseService(logger)
  {
    private readonly IOrderRepo _orderRepo = orderRepo;
    private readonly IProductRepo _productRepo = productRepo;

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
                                        Name = ol.First().Description
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

    public async Task<ProductCreationResult?> SetProductStockAsync(List<Product> products, int stock)
    {
      try
      {
        // Basic Idea, might change when being used. 
        products.ForEach(p => p.Stock = 25);
        var productUpdateModel = new ProductUpdate()
        {
          PropertiesToUpdate = new List<string> { nameof(Product.Stock) },
          MerchantProductRequestModels = products
        };

        var response = await _productRepo.UpdateProduct(productUpdateModel);

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
