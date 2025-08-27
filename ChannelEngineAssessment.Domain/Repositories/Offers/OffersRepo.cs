using ChannelEngineAssessment.Domain.Models.ApiResponses;
using ChannelEngineAssessment.Domain.Models.Offers;
using Newtonsoft.Json;
using System.Net.Http.Json;

namespace ChannelEngineAssessment.Domain.Repositories.Offers
{
  public class OffersRepo(HttpClient httpClient) : BaseRepo(httpClient), IOffersRepo
  {
    public async Task<UpdateResponse<StockUpdateResult>?> UpdateStock(IEnumerable<ProductStockUpdate>? productStockUpdate)
    {
      // Build the URL 
      var updateStockApiUrl = $"offer/stock?apikey={ApiKey}";

      // Update the product's stock with the API
      var response = await _httpClient.PutAsync(updateStockApiUrl, JsonContent.Create(productStockUpdate));
      var stockUpdateJson = await response.Content.ReadAsStringAsync();

      return JsonConvert.DeserializeObject<UpdateResponse<StockUpdateResult>>(stockUpdateJson);
    }
  }
}
