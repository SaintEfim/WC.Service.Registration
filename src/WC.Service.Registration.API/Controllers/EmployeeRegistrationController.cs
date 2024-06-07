using AutoMapper;
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
public class EmployeeRegistrationController : ApiControllerBase<EmployeeRegistrationController>
{
    private readonly IEmployeeRegistrationManager _manager;

    /// <inheritdoc/>
    public EmployeeRegistrationController(
        IMapper mapper,
        ILogger<EmployeeRegistrationController> logger, IEmployeeRegistrationManager manager)
        : base(mapper, logger)
    {
        _manager = manager;
    }

    /// <summary>
    ///     Registers a new employee registration.
    /// </summary>
    /// <param name="payload">The registration request data.</param>
    /// <param name="cancellationToken">The operation cancellation token.</param>
    [HttpPost("register")]
    [SwaggerOperation(OperationId = nameof(EmployeeRegistrationRegister))]
    [SwaggerResponse(Status200OK)]
    [SwaggerResponse(Status409Conflict, Type = typeof(ErrorDto))]
    public async Task<IActionResult> EmployeeRegistrationRegister(
        [FromBody] EmployeeRegistrationDto payload,
        CancellationToken cancellationToken = default)
    {
        return Ok(await _manager.Register(Mapper.Map<EmployeeRegistrationModel>(payload), cancellationToken));
    }
}