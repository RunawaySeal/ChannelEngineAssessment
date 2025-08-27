using ChannelEngineAssessment.Domain.Models.Offers;

namespace ChannelEngineAssessment.Domain.Models.Products
{
  public class Product
  {
    public string MerchantProductNo { get; set; }
    public string Name { get; set; }
    public string? GTIN { get; set; }
    public StockLocation? StockLocation { get; set; }
    public int TotalQuantitySold { get; set; }
  }
}
