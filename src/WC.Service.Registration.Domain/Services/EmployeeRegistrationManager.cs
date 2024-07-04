using AutoMapper;
using FluentValidation;
using WC.Library.BCryptPasswordHash;
using WC.Library.Domain.Models;
using WC.Library.Domain.Validators;
using WC.Library.Domain.Services.Validators;
using WC.Service.Registration.gRPC.Client.Clients;
using WC.Service.Registration.gRPC.Client.Models.Employee;
using EmployeeRegistrationModel = WC.Service.Registration.Domain.Models.EmployeeRegistrationModel;

namespace WC.Service.Registration.Domain.Services;

public class EmployeeRegistrationManager : ValidatorBase<EmployeeRegistrationModel>, IEmployeeRegistrationManager
{
    private readonly IBCryptPasswordHasher _passwordHasher;
    private readonly IMapper _mapper;
    private readonly IGreeterEmployeesClient _client;

    public EmployeeRegistrationManager(IMapper mapper,
        IEnumerable<IValidator> validators, IBCryptPasswordHasher passwordHasher,
        IGreeterEmployeesClient client) : base(validators)
    {
        _mapper = mapper;
        _passwordHasher = passwordHasher;
        _client = client;
    }

    public async Task<CreateResultModel> Register(EmployeeRegistrationModel model,
        CancellationToken cancellationToken = default)
    {
        Validate<IDomainCreateValidator>(model, cancellationToken);

        var employee = _mapper.Map<EmployeeCreateModel>(model);

        employee.Password = _passwordHasher.Hash(employee.Password);

        var createResult = await _client.Create(employee, cancellationToken);

        return createResult;
    }
}