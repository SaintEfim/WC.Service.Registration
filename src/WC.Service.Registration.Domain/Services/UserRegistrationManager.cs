using AutoMapper;
using FluentValidation;
using Microsoft.Extensions.Logging;
using WC.Library.Domain.Services;
using WC.Service.Registration.Data.Models;
using WC.Service.Registration.Data.Repository;
using WC.Service.Registration.Domain.Exceptions;
using WC.Service.Registration.Domain.Helpers;
using WC.Service.Registration.Domain.Models;
using WC.Service.Registration.Domain.Models.Requests;

namespace WC.Service.Registration.Domain.Services;

public class UserRegistrationManager : DataManagerBase<UserRegistrationManager, IUserRegistrationRepository,
        UserRegistrationModel, UserRegistrationEntity>,
    IUserRegistrationManager
{
    private readonly IHashHelper _hashHelper;

    public UserRegistrationManager(IMapper mapper, ILogger<UserRegistrationManager> logger,
        IUserRegistrationRepository repository,
        IEnumerable<IValidator> validators, IHashHelper hashHelper) : base(mapper, logger, repository, validators)
    {
        _hashHelper = hashHelper;
    }

    public async Task Register(RegistrationRequestModel registrationRequest,
        CancellationToken cancellationToken = default)
    {
        Validate(registrationRequest);

        if (await GetUserByEmail(registrationRequest.Email, cancellationToken) != null)
        {
            throw new DuplicateUserException(
                $"A user with the same {registrationRequest.Email} address already exists.");
        }

        var user = Mapper.Map<UserRegistrationEntity>(registrationRequest);

        user.Email = _hashHelper.Hash(user.Email);
        user.Password = _hashHelper.Hash(user.Password);

        user.CreatedAt = DateTime.UtcNow;

        await Repository.Create(user, cancellationToken);
    }

    private async Task<UserRegistrationEntity?> GetUserByEmail(string email,
        CancellationToken cancellationToken = default)
    {
        ArgumentException.ThrowIfNullOrEmpty(email);

        var userExists = await Repository.Get(cancellationToken);
        var user = userExists.SingleOrDefault(u => _hashHelper.Verify(email, u.Email));

        return user;
    }
}