using ChannelEngineAssessment.Domain.Models.ApiResponses;
using ChannelEngineAssessment.Domain.Models.Products;
using Newtonsoft.Json;
using System.Net.Http.Json;

namespace ChannelEngineAssessment.Domain.Repositories.Products
{
  public class ProductRepo(HttpClient httpClient) : BaseRepo(httpClient), IProductRepo
  {
    public async Task<UpdateResponse<ProductCreationResult>?> UpdateProduct(ProductUpdate? product)
    {
      // Build the URL 
      var updateProductApiUrl = $"products?apikey={ApiKey}";

      // Update the product attributes with the API
      var response = await _httpClient.PatchAsync(updateProductApiUrl, JsonContent.Create(product));
      var productUpdateJson = await response.Content.ReadAsStringAsync();

      return JsonConvert.DeserializeObject<UpdateResponse<ProductCreationResult>>(productUpdateJson);
    }
  }
}
