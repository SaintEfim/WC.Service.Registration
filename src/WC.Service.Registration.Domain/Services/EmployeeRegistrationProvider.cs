using AutoMapper;
using Microsoft.Extensions.Logging;
using WC.Library.Domain.Services;
using WC.Service.Registration.Domain.Models;
using WC.Service.Registration.gRPC.Models;
using WC.Service.Registration.gRPC.Services;

namespace WC.Service.Registration.Domain.Services;

public class EmployeeRegistrationProvider :
    DataProviderBase<EmployeeRegistrationProvider, IEmployeeRegistrationClient, EmployeeRegistrationModel,
        EmployeeServiceClientModel>,
    IEmployeeRegistrationProvider
{
    public EmployeeRegistrationProvider(IMapper mapper, ILogger<EmployeeRegistrationProvider> logger,
        IEmployeeRegistrationClient client) : base(mapper, logger, client)
    {
    }
}