using ChannelEngineAssessment.Domain.Models;
using ChannelEngineAssessment.Domain.Models.Products;
using System.Net.Http.Json;

namespace ChannelEngineAssessment.Domain.Repositories.Products
{
  public class ProductRepo : BaseRepo, IProductRepo
  {
    public async Task<Response<ProductCreationResult>?> UpdateProduct(ProductUpdate? product)
    {
      // Build the URL with the filters
      var updateProductApiUrl = $"{BaseUrl}/products";
      updateProductApiUrl += $"?apikey={ApiKey}";

      // Get Orders from the API
      using var httpClient = new HttpClient();
      var response = await httpClient.PatchAsync(updateProductApiUrl, JsonContent.Create(product));
      var productUpdateJson = await response.Content.ReadFromJsonAsync<Response<ProductCreationResult>>();

      return productUpdateJson ?? default;
    }
  }
}
