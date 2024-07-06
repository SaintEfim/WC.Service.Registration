using AutoMapper;
using FluentValidation;
using WC.Library.BCryptPasswordHash;
using WC.Library.Domain.Models;
using WC.Library.Domain.Validators;
using WC.Library.Domain.Services.Validators;
using WC.Service.Employees.gRPC.Client.Clients;
using WC.Service.Employees.gRPC.Client.Models.Employee;
using WC.Service.Employees.gRPC.Client.Models.Position;
using WC.Service.Registration.Domain.Models;

namespace WC.Service.Registration.Domain.Services;

public class EmployeeRegistrationManager : ValidatorBase<EmployeeRegistrationModel>, IEmployeeRegistrationManager
{
    private readonly IBCryptPasswordHasher _passwordHasher;
    private readonly IMapper _mapper;
    private readonly IGreeterEmployeesClient _employeesClient;
    private readonly IGreeterPositionsClient _positionsClient;

    public EmployeeRegistrationManager(IMapper mapper,
        IEnumerable<IValidator> validators, IBCryptPasswordHasher passwordHasher,
        IGreeterEmployeesClient employeesClient, IGreeterPositionsClient positionsClient) : base(validators)
    {
        _mapper = mapper;
        _passwordHasher = passwordHasher;
        _employeesClient = employeesClient;
        _positionsClient = positionsClient;
    }

    public async Task<CreateResultModel> Register(EmployeeRegistrationModel model,
        CancellationToken cancellationToken)
    {
        Validate<IDomainCreateValidator>(model, cancellationToken);

        var positionId = await _positionsClient.SearchPosition(new SearchPositionRequestModel
        {
            Name = model.Position
        }, cancellationToken);

        var employee = _mapper.Map<EmployeeCreateModel>(model);

        if (Guid.Parse(positionId.Id.ToString()) == Guid.Empty)
        {
            throw new InvalidOperationException("The employee does not have a position");
        }

        employee.PositionId = Guid.Parse(positionId.Id.ToString());
        employee.Password = _passwordHasher.Hash(employee.Password);

        return await _employeesClient.Create(employee, cancellationToken);
    }
}