using ChannelEngineAssessment.Domain.ApplicationServices.Orders;
using ChannelEngineAssessment.Domain.Enums;
using ChannelEngineAssessment.Domain.Models.Orders;
using ChannelEngineAssessment.WebApp.Models.Orders;
using Microsoft.AspNetCore.Mvc;

namespace ChannelEngineAssessment.WebApp.Controllers
{
  public class OrdersController(ILogger<OrdersController> logger, OrderService orderService) : Controller
  {
    private readonly ILogger<OrdersController> _logger = logger;
    private readonly OrderService _orderService = orderService;

    public IActionResult Index()
    {
      return View();
    }

    public async Task<IActionResult> List(int status)
    {
      try
      {
        var orderFilters = new OrderFilters { Statuses = new[] { (OrderStatus)status } };
        var ordersResponse = await _orderService.GetOrdersAsync(orderFilters);

        if (_orderService.HasError)
        {
          ViewBag.Error = $"Error fetching orders: {_orderService.LastErrorMessage}";
          return View();
        }

        if (ordersResponse?.Content == null || !ordersResponse.Content.Any())
        {
          ViewBag.Message = "No orders found";
          return View();
        }

        var viewModel = new OrdersViewModel(ordersResponse.Content.ToList(), orderFilters);

        return PartialView("_OrderList", viewModel);
      }
      catch (Exception ex)
      {
        _logger.LogError(ex, "Error occurred while fetching top products");
        ViewBag.Error = "An unexpected error occurred";
        return View();
      }
    }
  }
}
