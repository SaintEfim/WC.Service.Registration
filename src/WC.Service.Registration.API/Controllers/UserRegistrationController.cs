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
public class UserRegistrationController : CrudApiControllerBase<UserRegistrationController, IUserRegistrationManager,
    IUserRegistrationProvider, UserRegistrationModel, UserRegistrationDto>
{
    /// <inheritdoc/>
    public UserRegistrationController(
        IMapper mapper,
        ILogger<UserRegistrationController> logger,
        IEnumerable<IValidator> validators,
        IUserRegistrationManager manager,
        IUserRegistrationProvider provider)
        : base(mapper, logger, validators, manager, provider)
    {
    }

    /// <summary>
    ///     Retrieves a list of user registration.
    /// </summary>
    /// <param name="cancellationToken">The operation cancellation token.</param>
    [HttpGet]
    [SwaggerOperation(OperationId = nameof(UserRegistrationGet))]
    [SwaggerResponse(Status200OK, Type = typeof(List<UserRegistrationDto>))]
    public async Task<ActionResult<List<UserRegistrationDto>>> UserRegistrationGet(
        CancellationToken cancellationToken = default)
    {
        return Ok(await GetMany(cancellationToken));
    }

    /// <summary>
    ///     Registers a new user registration.
    /// </summary>
    /// <param name="registrationRequest">The registration request data.</param>
    /// <param name="cancellationToken">The operation cancellation token.</param>
    [HttpPost("register")]
    [SwaggerOperation(OperationId = nameof(UserRegistrationRegister))]
    [SwaggerResponse(Status200OK)]
    [SwaggerResponse(Status409Conflict, Type = typeof(ErrorDto))]
    public async Task<IActionResult> UserRegistrationRegister(RegistrationRequestDto registrationRequest,
        CancellationToken cancellationToken = default)
    {
        Validate(registrationRequest);
        await Manager.Register(Mapper.Map<RegistrationRequestModel>(registrationRequest), cancellationToken);
        return Ok();
    }

    /// <summary>
    ///     Deletes the specified user registration.
    /// </summary>
    /// <param name="id">The unique identifier of the user registration to delete.</param>
    /// <param name="cancellationToken">The operation cancellation token.</param>
    [HttpDelete("{id:guid}")]
    [SwaggerOperation(OperationId = nameof(UserRegistrationDelete))]
    [SwaggerResponse(Status204NoContent)]
    [SwaggerResponse(Status404NotFound, Type = typeof(ErrorDto))]
    [SwaggerResponse(Status400BadRequest, Type = typeof(ErrorDto))]
    [SwaggerResponse(Status409Conflict, Type = typeof(ErrorDto))]
    public async Task<IActionResult> UserRegistrationDelete(
        Guid id,
        CancellationToken cancellationToken = default)
    {
        return await Delete(id, cancellationToken);
    }
}