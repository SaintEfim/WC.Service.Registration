using Microsoft.Extensions.Configuration;
using WC.Service.Authentication.gRPC.Client;

namespace WC.Service.Registration.Domain;

public class AuthenticationClientConfiguration : IAuthenticationClientConfiguration
{
    private readonly Lazy<string> _baseUrl;

    public AuthenticationClientConfiguration(
        IConfiguration config)
    {
        _baseUrl = new Lazy<string>(() => config.GetValue<string>("AuthenticationService:Url") ??
                                          throw new InvalidOperationException(
                                              "Authentication REST API service URL must be specified"));
    }

    public string GetBaseUrl()
    {
        return _baseUrl.Value;
    }
}
