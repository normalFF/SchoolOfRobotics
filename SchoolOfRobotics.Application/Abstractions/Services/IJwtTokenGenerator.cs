using SchoolOfRobotics.Domain.Users;

namespace SchoolOfRobotics.Application.Abstractions.Services
{
    public interface IJwtTokenGenerator
	{
		string GenerateToken(User user);
	}
}
