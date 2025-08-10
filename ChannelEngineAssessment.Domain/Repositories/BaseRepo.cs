namespace ChannelEngineAssessment.Domain.Repositories
{
  public abstract class BaseRepo
  {
    public string BaseUrl { get; set; } = string.Empty;
    public string ApiKey { get; set; } = string.Empty;
  }
}
