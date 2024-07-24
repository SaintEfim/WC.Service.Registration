﻿using AutoMapper;
using FluentValidation;
using WC.Library.Domain.Models;
using WC.Library.Domain.Services.Validators;
using WC.Library.Domain.Validators;
using WC.Library.Employee.Shared.Exceptions;
using WC.Library.Shared.Exceptions;
using WC.Service.Authentication.gRPC.Client.Clients;
using WC.Service.Authentication.gRPC.Client.Models;
using WC.Service.Employees.gRPC.Client.Clients;
using WC.Service.Employees.gRPC.Client.Models.Employee;
using WC.Service.Employees.gRPC.Client.Models.Position;
using WC.Service.Registration.Domain.Models;

namespace WC.Service.Registration.Domain.Services;

public class EmployeeRegistrationManager
    : ValidatorBase<ModelBase>,
        IEmployeeRegistrationManager
{
    private readonly IGreeterAuthenticationClient _authenticationClient;
    private readonly IGreeterEmployeesClient _employeesClient;
    private readonly IMapper _mapper;
    private readonly IGreeterPositionsClient _positionsClient;

    public EmployeeRegistrationManager(
        IMapper mapper,
        IEnumerable<IValidator> validators,
        IGreeterEmployeesClient employeesClient,
        IGreeterPositionsClient positionsClient,
        IGreeterAuthenticationClient authenticationClient)
        : base(validators)
    {
        _mapper = mapper;
        _employeesClient = employeesClient;
        _positionsClient = positionsClient;
        _authenticationClient = authenticationClient;
    }

    public async Task<LoginResponseModel> Register(
        EmployeeRegistrationModel employeeRegistration,
        CancellationToken cancellationToken = default)
    {
        Validate<EmployeeRegistrationModel, IDomainCreateValidator>(employeeRegistration, cancellationToken);

        var positionId = await _positionsClient.GetOneByName(
            new GetOneByNamePositionRequestModel { Name = employeeRegistration.Position }, cancellationToken);

        var employee = _mapper.Map<EmployeeCreateRequestModel>(employeeRegistration);

        if (positionId.Id == Guid.Empty)
        {
            throw new NotFoundException("The employee does not have a position");
        }

        employee.PositionId = Guid.Parse(positionId.Id.ToString());

        try
        {
            await _employeesClient.Create(employee, cancellationToken);
            var loginResponse = await _authenticationClient.GetLoginResponse(
                new LoginRequestModel
                {
                    Email = employeeRegistration.Email,
                    Password = employeeRegistration.Password
                }, cancellationToken);

            return loginResponse;
        }
        catch (Exception)
        {
            throw new RegistrationFailedException("An error occurred during the employee registration process.");
        }
    }
}
