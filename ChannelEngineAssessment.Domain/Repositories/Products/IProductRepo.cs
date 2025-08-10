using ChannelEngineAssessment.Domain.Models;
using ChannelEngineAssessment.Domain.Models.Products;

namespace ChannelEngineAssessment.Domain.Repositories.Products
{
  public interface IProductRepo
  {  
    public Task<Response<ProductCreationResult>?> UpdateProduct(ProductUpdate? product);
  }
}
