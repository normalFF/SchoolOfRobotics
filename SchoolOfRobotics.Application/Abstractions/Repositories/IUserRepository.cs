using SchoolOfRobotics.Domain.Identificators;
using SchoolOfRobotics.Domain.Users;

namespace SchoolOfRobotics.Application.Abstractions.Repositories
{
    public interface IUserRepository
	{
		Task<User?> GetUserByIdAsync(UserId id, CancellationToken cancellationToken);

		Task<User?> GetUserByEmailAsync(Email email, CancellationToken cancellationToken);

		void CreateUser(User user);
	}
}
