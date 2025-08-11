namespace ChannelEngineAssessment.Domain.Models.ApiResponses
{
  // Basic response object that allows you to return a list of type as well and the total results. 
  // This can be used for pagination or other additional information.
  public class ListResponse<T>
  {
    public int Count { get; set; }
    public int TotalCount { get; set; }
    public int ItemsPerPage { get; set; }
    public IEnumerable<T> Content { get; set; } = Enumerable.Empty<T>();
    public bool Success { get; set; } = false;
  }
}
