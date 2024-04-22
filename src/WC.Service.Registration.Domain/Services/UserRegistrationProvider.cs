using AutoMapper;
using Microsoft.Extensions.Logging;
using WC.Library.Domain.Services;
using WC.Service.Registration.Data.Models;
using WC.Service.Registration.Data.Repository;
using WC.Service.Registration.Domain.Models;

namespace WC.Service.Registration.Domain.Services;

public class UserRegistrationProvider :
    DataProviderBase<UserRegistrationProvider, IUserRegistrationRepository, UserRegistrationModel,
        UserRegistrationEntity>,
    IUserRegistrationProvider
{
    public UserRegistrationProvider(IMapper mapper, ILogger<UserRegistrationProvider> logger,
        IUserRegistrationRepository repository) : base(mapper, logger, repository)
    {
    }
}