using AutoMapper;
using FluentValidation;
using Microsoft.Extensions.Logging;
using WC.Library.BCryptPasswordHash;
using WC.Library.Domain.Services;
using WC.Service.Registration.Data.Models;
using WC.Service.Registration.Data.Repository;
using WC.Service.Registration.Domain.Exceptions;
using WC.Service.Registration.Domain.Models;
using WC.Service.Registration.gRPC;
using WC.Service.Registration.gRPC.Models;
using WC.Service.Registration.gRPC.Services;
using EmployeeRegistrationModel = WC.Service.Registration.Domain.Models.EmployeeRegistrationModel;

namespace WC.Service.Registration.Domain.Services;

public class EmployeeRegistrationManager : DataManagerBase<EmployeeRegistrationManager, IEmployeeRegistrationRepository,
        EmployeeRegistrationModel, EmployeeRegistrationEntity>,
    IEmployeeRegistrationManager
{
    private readonly IBCryptPasswordHasher _passwordHasher;
    private readonly IEmployeeRegistrationClient _client;

    public EmployeeRegistrationManager(IMapper mapper, ILogger<EmployeeRegistrationManager> logger,
        IEmployeeRegistrationRepository repository,
        IEnumerable<IValidator> validators, IBCryptPasswordHasher passwordHasher, IEmployeeRegistrationClient client) : base(mapper, logger, repository,
        validators)
    {
        _passwordHasher = passwordHasher;
        _client = client;
    }

    public async Task Register(RegistrationRequestModel registrationRequest,
        CancellationToken cancellationToken = default)
    {
        Validate(registrationRequest);

        var users = await Repository.Get(cancellationToken);
        var checkUser = users.SingleOrDefault(x => x.Email == registrationRequest.Email);

        if (checkUser != null)
        {
            throw new DuplicateEmployeeException(
                $"A user with the same {registrationRequest.Email} address already exists.");
        }

        var user = Mapper.Map<EmployeeRegistrationEntity>(registrationRequest);

        user.Password = _passwordHasher.Hash(user.Password);

        user.CreatedAt = DateTime.UtcNow;
        
        await _client.RegisterEmployeeAsync(Mapper.Map<EmployeeRegistrationRequestModel>(user), cancellationToken);

        //await Repository.Create(user, cancellationToken);
    }
}