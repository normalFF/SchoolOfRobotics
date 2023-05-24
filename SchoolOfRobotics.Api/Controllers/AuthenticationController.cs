using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SchoolOfRobotics.Application.Commands.ParentRegistration;
using SchoolOfRobotics.Application.Queries.Login;
using SchoolOfRobotics.Contracts.Models.Requests;

namespace SchoolOfRobotics.Api.Controllers;

[ApiController]
[Route("api/auth")]
[AllowAnonymous]
public class AuthenticationController : ApiController
{
    public AuthenticationController(ISender sender, IMapper mapper)
        : base(sender, mapper)
    {
    }

    public async Task<IActionResult> Login([FromBody] LoginRequest request, CancellationToken cancellationToken)
    {
        LoginQuery command = _mapper.Map<LoginQuery>(request);
        var result = await _sender.Send(command, cancellationToken);
        return result.IsSuccess ? Ok(result.Value) : Problem(result);
    }

    public async Task<IActionResult> SignUp([FromBody] SignUpRequest request, CancellationToken cancellationToken)
    {
        var command = _mapper.Map<ParentRegistrationCommand>(request);
        var result = await _sender.Send(command, cancellationToken);
        return result.IsSuccess ? Ok() : Problem(result);
    }
}