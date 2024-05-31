using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using WC.Library.Web.Controllers;
using WC.Library.Web.Models;
using WC.Service.Registration.API.Models;
using WC.Service.Registration.Domain.Models;
using WC.Service.Registration.Domain.Services;
using static Microsoft.AspNetCore.Http.StatusCodes;

namespace WC.Service.Registration.API.Controllers;

/// <summary>
///     The employee type management controller.
/// </summary>
[Route("api/[controller]")]
public class EmployeeRegistrationController : CrudApiControllerBase<EmployeeRegistrationController, IEmployeeRegistrationManager,
    IEmployeeRegistrationProvider, EmployeeRegistrationModel, EmployeeRegistrationDto>
{
    /// <inheritdoc/>
    public EmployeeRegistrationController(
        IMapper mapper,
        ILogger<EmployeeRegistrationController> logger,
        IEnumerable<IValidator> validators,
        IEmployeeRegistrationManager manager,
        IEmployeeRegistrationProvider provider)
        : base(mapper, logger, validators, manager, provider)
    {
    }

    /// <summary>
    ///     Retrieves a list of employee registration.
    /// </summary>
    /// <param name="cancellationToken">The operation cancellation token.</param>
    [HttpGet]
    [SwaggerOperation(OperationId = nameof(EmployeeRegistrationGet))]
    [SwaggerResponse(Status200OK, Type = typeof(List<EmployeeRegistrationDto>))]
    public async Task<ActionResult<List<EmployeeRegistrationDto>>> EmployeeRegistrationGet(
        CancellationToken cancellationToken = default)
    {
        return Ok(await GetMany(cancellationToken));
    }

    /// <summary>
    ///     Registers a new employee registration.
    /// </summary>
    /// <param name="registrationRequest">The registration request data.</param>
    /// <param name="cancellationToken">The operation cancellation token.</param>
    [HttpPost("register")]
    [SwaggerOperation(OperationId = nameof(EmployeeRegistrationRegister))]
    [SwaggerResponse(Status200OK)]
    [SwaggerResponse(Status409Conflict, Type = typeof(ErrorDto))]
    public async Task<IActionResult> EmployeeRegistrationRegister(RegistrationRequestDto registrationRequest,
        CancellationToken cancellationToken = default)
    {
        Validate(registrationRequest);
        await Manager.Register(Mapper.Map<RegistrationRequestModel>(registrationRequest), cancellationToken);
        return Ok();
    }

    /// <summary>
    ///     Deletes the specified employee registration.
    /// </summary>
    /// <param name="id">The unique identifier of the employee registration to delete.</param>
    /// <param name="cancellationToken">The operation cancellation token.</param>
    [HttpDelete("{id:guid}")]
    [SwaggerOperation(OperationId = nameof(EmployeeRegistrationDelete))]
    [SwaggerResponse(Status204NoContent)]
    [SwaggerResponse(Status404NotFound, Type = typeof(ErrorDto))]
    [SwaggerResponse(Status400BadRequest, Type = typeof(ErrorDto))]
    [SwaggerResponse(Status409Conflict, Type = typeof(ErrorDto))]
    public async Task<IActionResult> EmployeeRegistrationDelete(
        Guid id,
        CancellationToken cancellationToken = default)
    {
        return await Delete(id, cancellationToken);
    }
}