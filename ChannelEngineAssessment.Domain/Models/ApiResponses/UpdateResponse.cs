namespace ChannelEngineAssessment.Domain.Models.ApiResponses
{
  public class UpdateResponse<T>
  {
    public T Content { get; set; }
    public bool Success { get; set; } = false;
  }
}
