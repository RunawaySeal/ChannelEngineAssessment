using ChannelEngineAssessment.Domain.Models.ApiResponses;
using ChannelEngineAssessment.Domain.Models.Products;
using Newtonsoft.Json;
using System.Net.Http.Json;

namespace ChannelEngineAssessment.Domain.Repositories.Products
{
  public class ProductRepo : BaseRepo, IProductRepo
  {
    public async Task<UpdateResponse<ProductCreationResult>?> UpdateProduct(ProductUpdate? product)
    {
      // Build the URL with the filters
      var updateProductApiUrl = $"{BaseUrl}/products";
      updateProductApiUrl += $"?apikey={ApiKey}";

      // Update the product attributes with the API
      using var httpClient = new HttpClient();
      var response = await httpClient.PatchAsync(updateProductApiUrl, JsonContent.Create(product));
      var productUpdateJson = await response.Content.ReadAsStringAsync();

      return JsonConvert.DeserializeObject<UpdateResponse<ProductCreationResult>>(productUpdateJson);
    }
  }
}
