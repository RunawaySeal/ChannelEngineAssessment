using ChannelEngineAssessment.Domain.Models.Orders;
using ChannelEngineAssessment.Domain.Models.Products;

namespace ChannelEngineAssessment.WebApp.Models.Orders
{
  public class OrdersViewModel(List<Order> orders, OrderFilters searchFilters)
  {
    public List<Order> Orders { get; set; } = orders;
    public OrderFilters SearchFilters { get; set; } = searchFilters;
    public List<Product> TopProducts => Orders.SelectMany(o => o.Lines)
                                              .GroupBy(ol => ol.MerchantProductNo)
                                              .Select(ol => new Product()
                                               {
                                                  TotalQuantitySold = ol.Sum(item => item.Quantity),
                                                  MerchantProductNo = ol.Key,
                                                  GTIN = ol.FirstOrDefault()?.Gtin,
                                                  Name = ol.FirstOrDefault()?.Description ?? string.Empty,
                                                  StockLocation = ol.FirstOrDefault()?.StockLocation
                                              })
                                              .OrderByDescending(p => p.TotalQuantitySold)
                                              .Take(5)
                                              .ToList();
  }
}
