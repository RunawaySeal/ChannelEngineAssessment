using ChannelEngineAssessment.Domain.Models.Orders;

namespace ChannelEngineAssessment.Domain.Models.Products
{
  public class Product
  {
    public string MerchantProductNo { get; set; }
    public string Name { get; set; }
    public int TotalQuantitySold { get; set; }
  }
}
