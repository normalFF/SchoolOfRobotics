using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authorization.Infrastructure;
using SchoolOfRobotics.Application.Abstractions.Services;
using SchoolOfRobotics.Domain.Users.Aggregates;
using System.IdentityModel.Tokens.Jwt;

namespace SchoolOfRobotics.Infrastructure.Authentication;

public class TokenAuthorizationHandler : AuthorizationHandler<RolesAuthorizationRequirement>
{
	private readonly IAuthenticationService _authentication;
	
	public TokenAuthorizationHandler(IAuthenticationService authentication)
	{
		_authentication = authentication;
	}

	protected override async Task HandleRequirementAsync(AuthorizationHandlerContext context, RolesAuthorizationRequirement requirement)
	{
		string? userId = context.User.Claims.FirstOrDefault(x => x.Type == JwtRegisteredClaimNames.Sub)?.Value;

		if (!Guid.TryParse(userId, out Guid parsedUserId))
		{
			context.Fail();
		}
		else
		{
			User? user = await _authentication.GetUserById(new(parsedUserId));

			if (user is not null && requirement.AllowedRoles.Any(i => i == user.Role.Name))
			{
				context.Succeed(requirement);
			}
			context.Fail();
		}
	}
}
