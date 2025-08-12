using ChannelEngineAssessment.Domain.Models.ApiResponses;
using ChannelEngineAssessment.Domain.Models.Products;
using ChannelEngineAssessment.Domain.Repositories.Products;

namespace ChannelEngineAssessment.Tests.MockRepositories
{
  public class MockProductRepo : IProductRepo
  {
    public Task<UpdateResponse<ProductCreationResult>?> UpdateProduct(ProductUpdate? product)
    {
      // Not needed at the moment. We can test this once we have list products functinality implemented.
      throw new NotImplementedException();
    }
  }
}
