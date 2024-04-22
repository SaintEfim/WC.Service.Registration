using System.Security.Claims;
using AutoMapper;
using FluentValidation;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using WC.Library.Domain.Services;
using WC.Service.Registration.Data.Models;
using WC.Service.Registration.Data.Repository;
using WC.Service.Registration.Domain.Exceptions;
using WC.Service.Registration.Domain.Helpers;
using WC.Service.Registration.Domain.Models;
using WC.Service.Registration.Domain.Models.Requests;

namespace WC.Service.Registration.Domain.Services;

public class UserCredentialManager : DataManagerBase<UserCredentialManager, IUserCredentialRepository,
        UserCredentialModel, UserCredentialEntity>,
    IUserCredentialManager
{
    private readonly IJwtHelper _jwtHelper;
    private readonly IHashHelper _hashHelper;
    private readonly ILogger<UserCredentialManager> _logger;
    private readonly string _tokenType;
    private readonly string _accessHours;
    private readonly string _refreshHours;
    private readonly string _accessSecretKey;
    private readonly string _refreshSecretKey;

    public UserCredentialManager(IMapper mapper, ILogger<UserCredentialManager> logger,
        IUserCredentialRepository repository,
        IEnumerable<IValidator> validators,
        IConfiguration config,
        IJwtHelper jwtHelper, IHashHelper hashHelper) : base(mapper, logger, repository, validators)
    {
        _logger = logger;
        _jwtHelper = jwtHelper;
        _hashHelper = hashHelper;
        _tokenType = config.GetValue<string>("Token:TokenType")!;
        _accessHours = config.GetValue<string>("HoursSettings:AccessHours")!;
        _refreshHours = config.GetValue<string>("HoursSettings:RefreshHours")!;
        _accessSecretKey = config.GetValue<string>("ApiSettings:AccessSecret")!;
        _refreshSecretKey = config.GetValue<string>("ApiSettings:RefreshSecret")!;
    }

    public async Task Register(RegistrationRequestModel registrationRequest,
        CancellationToken cancellationToken = default)
    {
        Validate(registrationRequest);

        if (await IsUniqueUser(registrationRequest.Email, cancellationToken))
        {
            throw new DuplicateUserException(
                $"A user with the same {registrationRequest.Email} address already exists.");
        }

        var user = Mapper.Map<UserCredentialEntity>(registrationRequest);

        user.Email = _hashHelper.Hash(user.Email);
        user.Password = _hashHelper.Hash(user.Password);

        user.CreatedAt = DateTime.UtcNow;

        await Repository.Create(user, cancellationToken);
    }

    private async Task<(string UserId, string UserRole)> DecodeRefreshToken(string refreshToken,
        CancellationToken cancellationToken = default)
    {
        ArgumentException.ThrowIfNullOrEmpty(refreshToken);

        var user = await _jwtHelper.DecodeToken(refreshToken, _refreshSecretKey, cancellationToken);
        var userId = user.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        var userRole = user.FindFirst(ClaimTypes.Role)?.Value;

        if (userId != null && userRole != null) return (userId, userRole);
        _logger.LogError("Invalid token. Missing required claims.");
        throw new Exception("An error occurred while processing your request.");
    }

    private async Task<bool> IsUniqueUser(string email, CancellationToken cancellationToken = default)
    {
        ArgumentException.ThrowIfNullOrEmpty(email);

        var userExists = await Repository.Get(cancellationToken);
        var result = userExists.SingleOrDefault(u => _hashHelper.Verify(email, u.Email));

        return result != null;
    }

    private async Task<UserCredentialEntity?> GetUserByEmail(string email,
        CancellationToken cancellationToken = default)
    {
        ArgumentException.ThrowIfNullOrEmpty(email);

        var userExists = await Repository.Get(cancellationToken);
        var user = userExists.SingleOrDefault(u => _hashHelper.Verify(email, u.Email));

        return user;
    }
}