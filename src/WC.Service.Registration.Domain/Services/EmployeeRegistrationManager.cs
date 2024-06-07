using AutoMapper;
using FluentValidation;
using WC.Library.BCryptPasswordHash;
using WC.Service.Registration.Domain.Exceptions;
using WC.Service.Registration.gRPC.Models;
using WC.Service.Registration.gRPC.Services;
using EmployeeRegistrationModel = WC.Service.Registration.Domain.Models.EmployeeRegistrationModel;

namespace WC.Service.Registration.Domain.Services;

public class EmployeeRegistrationManager : IEmployeeRegistrationManager
{
    private readonly IBCryptPasswordHasher _passwordHasher;
    private readonly IEnumerable<IValidator> _validators;
    private readonly IMapper _mapper;
    private readonly IEmployeeRegistrationClient _client;

    public EmployeeRegistrationManager(IMapper mapper,
        IEmployeeRegistrationClient client,
        IEnumerable<IValidator> validators, IBCryptPasswordHasher passwordHasher)
    {
        _mapper = mapper;
        _client = client;
        _validators = validators;
        _passwordHasher = passwordHasher;
    }

    public async Task<Guid> Register(EmployeeRegistrationModel model,
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

        var employee = _mapper.Map<EmployeeServiceClientModel>(model);

        employee.Id = Guid.NewGuid();

        employee.Password = _passwordHasher.Hash(employee.Password);

        employee.CreatedAt = DateTime.UtcNow;

        return await _client.Create(employee, cancellationToken);
    }

    private void Validate<T>(T model)
    {
        var errors = _validators.OfType<IValidator<T>>()
            .Select(validator => validator.Validate(model))
            .SelectMany(result => result.Errors)
            .ToList();

        if (errors.Count > 0)
        {
            throw new ValidationException(errors);
        }
    }
}