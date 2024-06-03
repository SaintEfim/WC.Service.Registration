using AutoMapper;
using FluentValidation;
using Microsoft.Extensions.Logging;
using WC.Library.BCryptPasswordHash;
using WC.Library.Domain.Services;
using WC.Service.Registration.Domain.Exceptions;
using WC.Service.Registration.gRPC.Models;
using WC.Service.Registration.gRPC.Services;
using EmployeeRegistrationModel = WC.Service.Registration.Domain.Models.EmployeeRegistrationModel;

namespace WC.Service.Registration.Domain.Services;

public class EmployeeRegistrationManager : DataManagerBase<EmployeeRegistrationManager, IEmployeeRegistrationClient,
        EmployeeRegistrationModel, EmployeeServiceClientModel>,
    IEmployeeRegistrationManager
{
    private readonly IBCryptPasswordHasher _passwordHasher;
    private readonly IEmployeeRegistrationClient _client;

    public EmployeeRegistrationManager(IMapper mapper, ILogger<EmployeeRegistrationManager> logger,
        IEmployeeRegistrationClient client,
        IEnumerable<IValidator> validators, IBCryptPasswordHasher passwordHasher) : base(mapper, logger, client,
        validators)
    {
        _passwordHasher = passwordHasher;
        _client = client;
    }

    public async Task Register(EmployeeRegistrationModel model,
        CancellationToken cancellationToken = default)
    {
        Validate(model);

        var employees = await _client.Get(cancellationToken);
        var checkEmployee = employees.SingleOrDefault(x => x.Email == model.Email);

        if (checkEmployee != null)
        {
            throw new DuplicateEmployeeException(
                $"A user with the same {model.Email} address already exists.");
        }

        var employee = Mapper.Map<EmployeeServiceClientModel>(model);

        employee.Id = Guid.NewGuid();

        employee.Password = _passwordHasher.Hash(employee.Password);

        employee.CreatedAt = DateTime.UtcNow;

        await _client.Create(employee, cancellationToken);
    }
}