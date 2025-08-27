using ChannelEngineAssessment.Domain.ApplicationServices.Products;
using ChannelEngineAssessment.Domain.Enums;
using ChannelEngineAssessment.Domain.Models.Orders;
using ChannelEngineAssessment.Tests.MockRepositories;

namespace ChannelEngineAssessment.Tests.Products
{
  public class ProductServiceTests
  {
    [Fact]
    public async Task GetTopProductsAsync_ReturnsTop5ProductsOrderedByQuantityDescending()
    {
      // Arrange
      var mockOrderRepo = new MockOrderRepo();
      var mockOffersRepo = new MockOffersRepo();
      var productService = new ProductService(null, mockOrderRepo, mockOffersRepo);

      var orderFilters = new OrderFilters
      {
        Statuses = [OrderStatus.IN_PROGRESS]
      };

      // Act
      var result = await productService.GetTopProductsAsync(orderFilters, 5);

      // Assert
      Assert.NotNull(result);
      var products = result.ToList();
      Assert.Equal(5, products.Count);

      // Verify the products are ordered by total quantity sold in descending order
      Assert.Equal("Product A", products[0].Name);
      Assert.Equal(50, products[0].TotalQuantitySold);
      Assert.Equal("GTIN001", products[0].GTIN);

      Assert.Equal("Product B", products[1].Name);
      Assert.Equal(40, products[1].TotalQuantitySold);
      Assert.Equal("GTIN002", products[1].GTIN);

      Assert.Equal("Product C", products[2].Name);
      Assert.Equal(30, products[2].TotalQuantitySold);
      Assert.Equal("GTIN003", products[2].GTIN);

      Assert.Equal("Product D", products[3].Name);
      Assert.Equal(20, products[3].TotalQuantitySold);
      Assert.Equal("GTIN004", products[3].GTIN);

      Assert.Equal("Product E", products[4].Name);
      Assert.Equal(10, products[4].TotalQuantitySold);
      Assert.Equal("GTIN005", products[4].GTIN);
    }
  }
}
