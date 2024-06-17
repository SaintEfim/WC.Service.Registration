using AutoMapper;
using FluentValidation;
using WC.Library.BCryptPasswordHash;
using WC.Library.Domain.Models;
using WC.Service.Registration.gRPC.Client.GrpcClients;
using WC.Service.Registration.gRPC.Client.Models;
using EmployeeRegistrationModel = WC.Service.Registration.Domain.Models.EmployeeRegistrationModel;

namespace WC.Service.Registration.Domain.Services;

public class EmployeeRegistrationManager : IEmployeeRegistrationManager
{
    private readonly IBCryptPasswordHasher _passwordHasher;
    private readonly IEnumerable<IValidator> _validators;
    private readonly IMapper _mapper;
    private readonly IEmployeeClientManager _clientManager;
    // private readonly IEmployeeClientProvider _clientProvider;

    public EmployeeRegistrationManager(IMapper mapper,
        IEnumerable<IValidator> validators, IBCryptPasswordHasher passwordHasher,
        IEmployeeClientManager clientManager)
    {
        _mapper = mapper;
        _validators = validators;
        _passwordHasher = passwordHasher;
        _clientManager = clientManager;
    }

    public async Task<CreateResultModel> Register(EmployeeRegistrationModel model,
        CancellationToken cancellationToken = default)
    {
        Validate(model);

        // var employees = await _clientProvider.Get(cancellationToken);
        // var checkEmployee = employees.SingleOrDefault(x => x.Email == model.Email);
        //
        // if (checkEmployee != null)
        // {
        //     throw new DuplicateEmployeeException(
        //         $"A user with the same {model.Email} address already exists.");
        // }

        var employee = _mapper.Map<EmployeeCreateModel>(model);

        employee.Password = _passwordHasher.Hash(employee.Password);

        var createResult = await _clientManager.Create(employee, cancellationToken);

        return createResult;
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