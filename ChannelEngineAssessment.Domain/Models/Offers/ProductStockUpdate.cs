namespace ChannelEngineAssessment.Domain.Models.Offers
{
  public class ProductStockUpdate
  {
    public string MerchantProductNo { get; set; }
    public IEnumerable<StockLocation> StockLocations { get; set; }
  }
}
