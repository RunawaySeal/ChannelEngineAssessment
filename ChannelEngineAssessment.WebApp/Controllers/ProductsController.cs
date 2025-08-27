using ChannelEngineAssessment.Domain.ApplicationServices.Products;
using ChannelEngineAssessment.Domain.Models.Offers;
using ChannelEngineAssessment.Domain.Models.Products;
using Microsoft.AspNetCore.Mvc;

namespace ChannelEngineAssessment.WebApp.Controllers
{
  public class ProductsController(ILogger<ProductsController> logger, ProductService productService) : Controller
  {
    private readonly ILogger<ProductsController> _logger = logger;
    private readonly ProductService _productService = productService;

    [HttpPost]
    public async Task<ContentResult> UpdateStock(string merchantProductNo, int stockLocationId, int quantity)
    {
      try
      {
        var product = new Product
        {
          MerchantProductNo = merchantProductNo,
          StockLocation = new StockLocation
          {
            StockLocationId = stockLocationId,
            Stock = quantity
          }
        };

        var updateResult = await _productService.SetProductStockAsync([product]);

        if (_productService.HasError)
        {
          return Content($"Error updating stock: {_productService.LastErrorMessage}");
        }
        else
        {
          return Content($"Stock updated to {quantity} successfully!");
        }
      }
      catch (Exception ex)
      {
        _logger.LogError(ex, "Error occurred while updating stock");
        TempData["Error"] = "An unexpected error occurred while updating stock";
        return Content(ex.Message);
      }
      
    }
  }
}