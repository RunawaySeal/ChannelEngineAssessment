using Serilog;
using System.Net;

namespace ChannelEngineAssessment.Domain.ApplicationServices
{
  public abstract class BaseService
  {
    private readonly ILogger _logger;
    public bool HasError { get; private set; }
    public string LastErrorMessage { get; private set; } = string.Empty;
    public HttpStatusCode StatusCode { get; private set; } = HttpStatusCode.OK;

    public BaseService(ILogger logger)
    {
      _logger = logger;
    }

    public void SetDomainError(HttpStatusCode statusCode, string message)
    {
      _logger?.Error(message);

      HasError = true;
      StatusCode = statusCode;
      LastErrorMessage = message;
    }
  }
}
