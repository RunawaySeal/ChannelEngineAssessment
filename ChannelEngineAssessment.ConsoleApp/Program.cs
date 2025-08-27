using ChannelEngineAssessment.Domain.ApplicationServices.Orders;
using ChannelEngineAssessment.Domain.ApplicationServices.Products;
using ChannelEngineAssessment.Domain.Enums;
using ChannelEngineAssessment.Domain.Models.Orders;
using ChannelEngineAssessment.Domain.Repositories.Orders;
using ChannelEngineAssessment.Domain.Repositories.Products;

var apiKey = "541b989ef78ccb1bad630ea5b85c6ebff9ca3322";
var baseUrl = "https://api-dev.channelengine.net/api/v2";

using var httpClient = new HttpClient();
httpClient.BaseAddress = new Uri(baseUrl);
httpClient.DefaultRequestHeaders.Add("User-Agent", "ChannelEngineAssessment/1.0");

//Repositories
var orderRepo = new OrderRepo(httpClient) { ApiKey = apiKey };
var productsRepo = new ProductRepo(httpClient) { ApiKey = apiKey };


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
Console.WriteLine($"Would you like to update the stock of Top Products to 25");
Console.WriteLine($"Press 'Y' to continue or any other key to exit.");

//If user agrees, update stock of top products to 25
if (Console.ReadLine().ToLower() == "y")
{
  var response = await productService.SetProductStockAsync(products.ToList(), 25);
  Console.WriteLine($"Stock Update Response: Accepted Changes: {response.AcceptedCount}, Rejected Changes: {response.RejectedCount}");
  foreach(var message in response.ProductMessages)
  {
    Console.WriteLine($"- {message.Name}");
    foreach(var error in message.Errors)
    {
      Console.WriteLine($"-- Error: {error}");
    }
  }
}
else
  Environment.Exit(0);