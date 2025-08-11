using ChannelEngineAssessment.Domain.ApplicationServices.Orders;
using ChannelEngineAssessment.Domain.ApplicationServices.Products;
using ChannelEngineAssessment.Domain.Enums;
using ChannelEngineAssessment.Domain.Models.Orders;
using ChannelEngineAssessment.WebApp.Models.Products;
using Microsoft.AspNetCore.Mvc;

namespace ChannelEngineAssessment.WebApp.Controllers
{
  public class ProductsController(ILogger<ProductsController> logger, ProductService productService) : Controller
  {
    private readonly ILogger<ProductsController> _logger = logger;
    private readonly ProductService _productService = productService;

    [HttpPost]
    public async Task<ContentResult> UpdateStock(string merchantProductNo, int quantity)
    {
      try
      {
        var product = new Domain.Models.Products.Product
        {
          MerchantProductNo = merchantProductNo
        };

        var updateResult = await _productService.SetProductStockAsync([product], quantity);

        if (_productService.HasError || (updateResult?.RejectedCount ?? 0) > 0)
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