using Microsoft.Extensions.Configuration;

namespace WC.Service.Registration.Domain;

public class PositionsesClientConfiguration : IPositionsClientConfiguration
{
    private readonly Lazy<string> _baseUrl;

    public PositionsesClientConfiguration(IConfiguration config)
    {
        _baseUrl = new Lazy<string>(() => config.GetValue<string>("PositionService:Url") ??
                                          throw new InvalidOperationException(
                                              "Position REST API service URL must be specified"));
    }

    public string GetBaseUrl()
    {
        return _baseUrl.Value;
    }
}