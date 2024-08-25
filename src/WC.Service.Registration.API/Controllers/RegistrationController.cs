using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using NSwag.Annotations;
using WC.Library.Web.Controllers;
using WC.Library.Web.Models;
using WC.Service.Registration.API.Models;
using WC.Service.Registration.API.Models.Authentication;
using WC.Service.Registration.Domain.Services;
using static Microsoft.AspNetCore.Http.StatusCodes;

namespace WC.Service.Registration.API.Controllers;

/// <summary>
///     The registration type management controller.
/// </summary>
[Route("api/v1/registration")]
public class RegistrationController : ApiControllerBase<RegistrationController>
{
    private readonly IRegistrationManager _manager;

    /// <inheritdoc/>
    public RegistrationController(
        IMapper mapper,
        ILogger<RegistrationController> logger,
        IRegistrationManager manager)
        : base(mapper, logger)
    {
        _manager = manager;
    }

    /// <summary>
    ///     Creates a new employee registration.
    /// </summary>
    /// <param name="payload">The registration request data.</param>
    /// <param name="cancellationToken">The operation cancellation token.</param>
    [HttpPost("register")]
    [OpenApiOperation(nameof(Register))]
    [SwaggerResponse(Status201Created, typeof(AuthenticationLoginResponseDto))]
    [SwaggerResponse(Status409Conflict, typeof(ErrorDto))]
    public async Task<IActionResult> Register(
        [FromBody] RegistrationCreateDto payload,
        CancellationToken cancellationToken = default)
    {
        return Ok(await _manager.Register(Mapper.Map<RegistrationCreatePayloadModel>(payload),
            cancellationToken: cancellationToken));
    }
}
