namespace ChannelEngineAssessment.Domain.Models.Products
{
  public class ProductUpdate
  {
    // String list of properties to update from the Product object.
    public IEnumerable<string> PropertiesToUpdate { get; set; }

    //List of Product objects that contain the MerchantProductNo and new values.
    public IEnumerable<Product> MerchantProductRequestModels { get; set; }
  }
}
