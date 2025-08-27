using Newtonsoft.Json;

namespace ChannelEngineAssessment.Domain.Models.Offers
{
  public class StockLocation
  {
    public int Stock { get; set; }
    [JsonProperty("Id")]
    public int StockLocationId { get; set; }
  }
}
