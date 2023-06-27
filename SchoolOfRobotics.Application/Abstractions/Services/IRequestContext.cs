using SchoolOfRobotics.Domain.Users;

namespace SchoolOfRobotics.Application.Abstractions.Services
{
    public interface IRequestContext
	{
		public User? GetCurrentUser();
	}
}
