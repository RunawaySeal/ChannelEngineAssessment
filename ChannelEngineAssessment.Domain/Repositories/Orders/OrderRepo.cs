using ChannelEngineAssessment.Domain.Models.ApiResponses;
using ChannelEngineAssessment.Domain.Models.Orders;
using Newtonsoft.Json;

namespace ChannelEngineAssessment.Domain.Repositories.Orders
{
  public class OrderRepo : BaseRepo, IOrderRepo
  {
    public async Task<ListResponse<Order>?> GetOrdersAsync(OrderFilters? filters)
    {
      // Build the URL with the filters
      var orderApiUrl = $"{BaseUrl}/orders";
      orderApiUrl += $"?apikey={ApiKey}";
      if(filters is not null)
      {
        orderApiUrl += $"&statuses={string.Join(',', filters.Statuses.Select(s => s.ToString()))}";
      }

      // Get Orders from the API
      using var httpClient = new HttpClient();
      var orderJson = await httpClient.GetStringAsync(orderApiUrl);

      return JsonConvert.DeserializeObject<ListResponse<Order>>(orderJson);
    }
  }
}
