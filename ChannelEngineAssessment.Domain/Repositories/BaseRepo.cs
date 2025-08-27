using System.Net.Http;

namespace ChannelEngineAssessment.Domain.Repositories
{
  public abstract class BaseRepo(HttpClient httpClient)
  {
    protected readonly HttpClient _httpClient = httpClient;
    public string ApiKey { get; set; } = string.Empty;
  }
}
