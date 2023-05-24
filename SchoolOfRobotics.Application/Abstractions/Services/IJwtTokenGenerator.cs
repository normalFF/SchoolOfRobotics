using SchoolOfRobotics.Domain.Users.Aggregates;

namespace SchoolOfRobotics.Application.Abstractions.Services
{
    public interface IJwtTokenGenerator
	{
		string GenerateToken(User user);
	}
}
