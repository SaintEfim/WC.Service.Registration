using System.Collections.Immutable;
using AutoMapper;
using FluentValidation;
using WC.Library.BCryptPasswordHash;
using WC.Library.Domain.Models;
using WC.Library.Domain.Validators;
using WC.Service.Registration.gRPC.Client.GrpcClients;
using WC.Service.Registration.gRPC.Client.Models;
using EmployeeRegistrationModel = WC.Service.Registration.Domain.Models.EmployeeRegistrationModel;

namespace WC.Service.Registration.Domain.Services;

public class EmployeeRegistrationManager : IEmployeeRegistrationManager
{
    private readonly IBCryptPasswordHasher _passwordHasher;
    private readonly IEnumerable<IValidator> _validators;
    private readonly IMapper _mapper;
    private readonly IEmployeeClient _client;

    public EmployeeRegistrationManager(IMapper mapper,
        IEnumerable<IValidator> validators, IBCryptPasswordHasher passwordHasher,
        IEmployeeClient client)
    {
        _mapper = mapper;
        _validators = validators;
        _passwordHasher = passwordHasher;
        _client = client;
    }

    public async Task<CreateResultModel> Register(EmployeeRegistrationModel model,
        CancellationToken cancellationToken = default)
    {
        await Validate<IDomainCreateValidator>(model);

        var employee = _mapper.Map<EmployeeCreateModel>(model);

        employee.Password = _passwordHasher.Hash(employee.Password);

        var createResult = await _client.Create(employee, cancellationToken);

        return createResult;
    }

    private async Task Validate<TV>(EmployeeRegistrationModel model)
    {
        var validationSet = _validators.Where(v => v.GetType().IsAssignableTo(typeof(TV))).Cast<IValidator<EmployeeRegistrationModel>>();
        await Validate(model, validationSet);
    }

    private static async Task Validate<TPayload>(
        TPayload model,
        IEnumerable<IValidator<TPayload>> source,
        CancellationToken cancellationToken = default)
        where TPayload : class
    {
        var validationTasks = source.Select(x => x.ValidateAsync(model, cancellationToken));
        var results = await Task.WhenAll(validationTasks);

        var failures = results.SelectMany(x => x.Errors)
            .Where(x => x != null)
            .ToImmutableList();

        if (!failures.IsEmpty)
        {
            throw new ValidationException(failures);
        }
    }
}
