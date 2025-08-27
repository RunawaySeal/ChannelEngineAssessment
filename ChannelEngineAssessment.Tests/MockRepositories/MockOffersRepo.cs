using ChannelEngineAssessment.Domain.Models.ApiResponses;
using ChannelEngineAssessment.Domain.Models.Offers;
using ChannelEngineAssessment.Domain.Repositories.Offers;

namespace ChannelEngineAssessment.Tests.MockRepositories
{
  internal class MockOffersRepo : IOffersRepo
  {
    public Task<UpdateResponse<StockUpdateResult>?> UpdateStock(IEnumerable<ProductStockUpdate>? productStockUpdate)
    {
      // Not needed at the moment. We can test this once we have list products functinality implemented.
      throw new NotImplementedException();
    }
  }
}
