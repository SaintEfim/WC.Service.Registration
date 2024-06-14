using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using NSwag.Annotations;
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
    private readonly IMapper _mapper;

    /// <inheritdoc/>
    public EmployeeRegistrationController(
        IMapper mapper,
        ILogger<EmployeeRegistrationController> logger, IEmployeeRegistrationManager manager)
        : base(mapper, logger)
    {
        _mapper = mapper;
        _manager = manager;
    }

    /// <summary>
    ///     Creates a new employee registration.
    /// </summary>
    /// <param name="payload">The registration request data.</param>
    /// <param name="cancellationToken">The operation cancellation token.</param>
    [HttpPost("register")]
    [OpenApiOperation(nameof(RegisterEmployee))]
    [SwaggerResponse(Status201Created, typeof(CreateActionResultDto))]
    [SwaggerResponse(Status409Conflict, typeof(ErrorDto))]
    public async Task<IActionResult> RegisterEmployee(
        [FromBody] EmployeeRegistrationCreateDto payload,
        CancellationToken cancellationToken = default)
    {
        var createResult = _mapper.Map<CreateActionResultDto>(
            await _manager.Register(Mapper.Map<EmployeeRegistrationModel>(payload), cancellationToken));

        return CreatedAtAction(nameof(RegisterEmployee), new { id = createResult.Id },
            _mapper.Map<CreateActionResultDto>(createResult));
    }
}