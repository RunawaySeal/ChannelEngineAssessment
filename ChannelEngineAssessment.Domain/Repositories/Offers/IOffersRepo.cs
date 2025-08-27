using ChannelEngineAssessment.Domain.Models.ApiResponses;
using ChannelEngineAssessment.Domain.Models.Offers;

namespace ChannelEngineAssessment.Domain.Repositories.Offers
{
  public interface IOffersRepo
  {
    public Task<UpdateResponse<StockUpdateResult>?> UpdateStock(IEnumerable<ProductStockUpdate>? productStockUpdate);
  }
}
