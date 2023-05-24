using SchoolOfRobotics.Domain.Users.Aggregates;

namespace SchoolOfRobotics.Application.Abstractions.Services
{
    public interface IRequestContext
	{
		public User? GetCurrentUser();
	}
}
