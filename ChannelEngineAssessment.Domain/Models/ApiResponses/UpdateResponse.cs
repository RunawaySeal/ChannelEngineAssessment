namespace ChannelEngineAssessment.Domain.Models.ApiResponses
{
  public class UpdateResponse<T>
  {
    public int Count { get; set; }
    public int TotalCount { get; set; }
    public int ItemsPerPage { get; set; }
    public T Content { get; set; }
    public bool Success { get; set; } = false;
  }
}
