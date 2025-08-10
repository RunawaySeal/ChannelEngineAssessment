namespace ChannelEngineAssessment.Domain.Models.Orders
{
  public class OrderLine
  {
    public int Id { get; set; }
    public string Status { get; set; }
    public string Gtin { get; set; }
    public string ChannelOrderLineNo { get; set; }
    public string ChannelProductNo { get; set; }
    public string MerchantProductNo { get; set; }
    public string Description { get; set; }
    public int Quantity { get; set; }
  }
}
