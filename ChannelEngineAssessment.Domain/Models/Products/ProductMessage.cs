namespace ChannelEngineAssessment.Domain.Models.Products
{
  public class ProductMessage
  {
    public string? Name { get; set; }
    public string? Reference { get; set; }
    public string? KeyReference { get; set; }
    public IEnumerable<string>? Warnings { get; set; }
    public IEnumerable<string>? Errors { get; set; }
  }
}
