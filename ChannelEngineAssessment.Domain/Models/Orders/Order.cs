using ChannelEngineAssessment.Domain.Enums;

namespace ChannelEngineAssessment.Domain.Models.Orders
{
  public class Order
  {
    public int Id { get; set; }
    public int ChannelId { get; set; }
    public int GlobalChannelId { get; set; }
    public string ChannelName { get; set; }
    public string GlobalChannelName { get; set; }
    public OrderStatus Status { get; set; }
    public List<OrderLine> Lines { get; set; } = new List<OrderLine>();
  }
}
