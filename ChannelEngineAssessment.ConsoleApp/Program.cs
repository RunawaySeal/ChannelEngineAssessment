using ChannelEngineAssessment.Domain.ApplicationServices.Orders;
using ChannelEngineAssessment.Domain.ApplicationServices.Products;
using ChannelEngineAssessment.Domain.Enums;
using ChannelEngineAssessment.Domain.Models.Orders;
using ChannelEngineAssessment.Domain.Repositories.Orders;
using ChannelEngineAssessment.Domain.Repositories.Products;

var apiKey = "541b989ef78ccb1bad630ea5b85c6ebff9ca3322";
var baseUrl = "https://api-dev.channelengine.net/api/v2";

//Repositories
var orderRepo = new OrderRepo() { ApiKey = apiKey, BaseUrl = baseUrl };
var productsRepo = new ProductRepo() { ApiKey = apiKey, BaseUrl = baseUrl };


//Services
var orderService = new OrderService(null, orderRepo);
var productService = new ProductService(null, orderRepo, productsRepo);

var orderFilters = new OrderFilters
{
  Statuses = [OrderStatus.IN_PROGRESS]
};

//List All In-Progress Orders
var orders = await orderService.GetOrdersAsync(orderFilters);
Console.WriteLine($"Orders");
foreach (var order in orders.Content)
{
  Console.WriteLine($"-{order.Id}, {order.GlobalChannelName}, {order.Status}");
  foreach (var line in order.Lines)
  {
    Console.WriteLine($"-- Product: {line.Description}, Quantity: {line.Quantity}");
  } 
}

Console.WriteLine($"------------------------------------------------------");

//List Top 5 Products Sold based on In-Progress Orders
var products = await productService.GetTopProductsAsync(orderFilters, 5);
Console.WriteLine($"Top Products");
foreach (var product in products)
{
  Console.WriteLine($"-{product.Name}, GTIN: {product.GTIN}, Total Sold: {product.TotalQuantitySold}");
}

Console.WriteLine($"------------------------------------------------------");