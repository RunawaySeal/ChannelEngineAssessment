using ChannelEngineAssessment.Domain.Enums;
using ChannelEngineAssessment.Domain.Models.Orders;
using System.Diagnostics.Metrics;

namespace ChannelEngineAssessment.WebApp.Models.Orders
{
  public class OrdersViewModel
  {
    public List<Order> Orders { get; set; }
    public OrderFilters SearchFilters { get; set; }

    public OrdersViewModel(List<Order> orders, OrderFilters searchFilters)
    {
      Orders = orders;
      SearchFilters = searchFilters;
    }
  }
}
