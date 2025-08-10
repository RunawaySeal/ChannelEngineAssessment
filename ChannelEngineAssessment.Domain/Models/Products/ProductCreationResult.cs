namespace ChannelEngineAssessment.Domain.Models.Products
{
  public class ProductCreationResult
  {
    public int RejectedCount { get; set; }
    public int AcceptedCount { get; set; }
    public IEnumerable<ProductMessage>? ProductMessages { get; set; }
  }
}
