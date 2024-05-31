using AutoMapper;
using Microsoft.Extensions.Logging;
using WC.Library.Domain.Services;
using WC.Service.Registration.Data.Models;
using WC.Service.Registration.Data.Repository;
using WC.Service.Registration.Domain.Models;

namespace WC.Service.Registration.Domain.Services;

public class EmployeeRegistrationProvider :
    DataProviderBase<EmployeeRegistrationProvider, IEmployeeRegistrationRepository, EmployeeRegistrationModel,
        EmployeeRegistrationEntity>,
    IEmployeeRegistrationProvider
{
    public EmployeeRegistrationProvider(IMapper mapper, ILogger<EmployeeRegistrationProvider> logger,
        IEmployeeRegistrationRepository repository) : base(mapper, logger, repository)
    {
    }
}