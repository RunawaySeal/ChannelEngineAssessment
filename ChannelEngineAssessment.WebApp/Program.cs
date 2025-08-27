using ChannelEngineAssessment.Domain.ApplicationServices.Orders;
using ChannelEngineAssessment.Domain.ApplicationServices.Products;
using ChannelEngineAssessment.Domain.Repositories.Orders;
using ChannelEngineAssessment.Domain.Repositories.Products;
using Serilog;

var builder = WebApplication.CreateBuilder(args);
var baseUrl = "https://api-dev.channelengine.net/api/v2";
var apiKey = "541b989ef78ccb1bad630ea5b85c6ebff9ca3322";

// Add services to the container.
builder.Services.AddControllersWithViews();

// Register HttpClient with configuration for ChannelEngine API
builder.Services.AddHttpClient("ChannelEngine", client =>
{
  client.BaseAddress = new Uri("https://api-dev.channelengine.net/api/v2/");
  client.DefaultRequestHeaders.Add("User-Agent", "ChannelEngineAssessment/1.0");
  // Add any other default headers or timeout configurations here
  client.Timeout = TimeSpan.FromSeconds(30);
});

// Register repositories with configuration
builder.Services.AddScoped<IOrderRepo>(provider =>
{
  var httpClientFactory = provider.GetRequiredService<IHttpClientFactory>();
  var httpClient = httpClientFactory.CreateClient("ChannelEngine");

  var repo = new OrderRepo(httpClient) { ApiKey = apiKey };
  return repo;
});
builder.Services.AddScoped<IProductRepo>(provider =>
{
  var httpClientFactory = provider.GetRequiredService<IHttpClientFactory>();
  var httpClient = httpClientFactory.CreateClient("ChannelEngine");

  var repo = new ProductRepo(httpClient) { ApiKey = apiKey };
  return repo;
});

// Register application services
builder.Services.AddScoped<OrderService>();
builder.Services.AddScoped<ProductService>();
builder.Services.AddSingleton(Log.Logger);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
  app.UseExceptionHandler("/Home/Error");
  // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
  app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();


app.Run();
