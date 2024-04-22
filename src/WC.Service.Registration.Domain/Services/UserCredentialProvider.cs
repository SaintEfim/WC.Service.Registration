using AutoMapper;
using Microsoft.Extensions.Logging;
using WC.Library.Domain.Services;
using WC.Service.Registration.Data.Models;
using WC.Service.Registration.Data.Repository;
using WC.Service.Registration.Domain.Models;

namespace WC.Service.Registration.Domain.Services;

public class UserCredentialProvider :
    DataProviderBase<UserCredentialProvider, IUserCredentialRepository, UserCredentialModel, UserCredentialEntity>,
    IUserCredentialProvider
{
    public UserCredentialProvider(IMapper mapper, ILogger<UserCredentialProvider> logger,
        IUserCredentialRepository repository) : base(mapper, logger, repository)
    {
    }
}