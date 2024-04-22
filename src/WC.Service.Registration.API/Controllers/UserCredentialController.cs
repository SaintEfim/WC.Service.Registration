using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using WC.Library.Web.Controllers;
using WC.Library.Web.Models;
using WC.Service.Registration.API.Models;
using WC.Service.Registration.Domain.Models;
using WC.Service.Registration.Domain.Models.Requests;
using WC.Service.Registration.Domain.Services;
using static Microsoft.AspNetCore.Http.StatusCodes;

namespace WC.Service.Registration.API.Controllers;

/// <summary>
///     The user type management controller.
/// </summary>
[Route("api/[controller]")]
public class UserCredentialController : CrudApiControllerBase<UserCredentialController, IUserCredentialManager,
    IUserCredentialProvider, UserCredentialModel, UserCredentialDto>
{
    /// <inheritdoc/>
    public UserCredentialController(
        IMapper mapper,
        ILogger<UserCredentialController> logger,
        IEnumerable<IValidator> validators,
        IUserCredentialManager manager,
        IUserCredentialProvider provider)
        : base(mapper, logger, validators, manager, provider)
    {
    }

    /// <summary>
    ///     Retrieves a list of user credentials.
    /// </summary>
    /// <param name="cancellationToken">The operation cancellation token.</param>
    [HttpGet]
    [SwaggerOperation(OperationId = nameof(UserCredentialGet))]
    [SwaggerResponse(Status200OK, Type = typeof(List<UserCredentialDto>))]
    public async Task<ActionResult<List<UserCredentialDto>>> UserCredentialGet(
        CancellationToken cancellationToken = default)
    {
        return Ok(await GetMany(cancellationToken));
    }

    /// <summary>
    ///     Registers a new user credential.
    /// </summary>
    /// <param name="registrationRequest">The registration request data.</param>
    /// <param name="cancellationToken">The operation cancellation token.</param>
    [HttpPost("register")]
    [SwaggerOperation(OperationId = nameof(UserCredentialRegister))]
    [SwaggerResponse(Status200OK)]
    [SwaggerResponse(Status409Conflict, Type = typeof(ErrorDto))]
    public async Task<IActionResult> UserCredentialRegister(RegistrationRequestDto registrationRequest,
        CancellationToken cancellationToken = default)
    {
        Validate(registrationRequest);
        await Manager.Register(Mapper.Map<RegistrationRequestModel>(registrationRequest), cancellationToken);
        return Ok();
    }

    /// <summary>
    ///     Deletes the specified user credential.
    /// </summary>
    /// <param name="id">The unique identifier of the user credential to delete.</param>
    /// <param name="cancellationToken">The operation cancellation token.</param>
    [HttpDelete("{id:guid}")]
    [SwaggerOperation(OperationId = nameof(UserCredentialDelete))]
    [SwaggerResponse(Status204NoContent)]
    [SwaggerResponse(Status404NotFound, Type = typeof(ErrorDto))]
    [SwaggerResponse(Status400BadRequest, Type = typeof(ErrorDto))]
    [SwaggerResponse(Status409Conflict, Type = typeof(ErrorDto))]
    public async Task<IActionResult> UserCredentialDelete(
        Guid id,
        CancellationToken cancellationToken = default)
    {
        return await Delete(id, cancellationToken);
    }
}