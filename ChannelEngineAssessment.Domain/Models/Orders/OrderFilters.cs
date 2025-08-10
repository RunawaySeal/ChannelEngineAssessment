using ChannelEngineAssessment.Domain.Enums;

namespace ChannelEngineAssessment.Domain.Models.Orders
{
  public class OrderFilters
  {
    public IEnumerable<OrderStatus> Statuses { get; set; }
  }
}
