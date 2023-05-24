using SchoolOfRobotics.Domain.Identificators;
using SchoolOfRobotics.Domain.Users.Aggregates;

namespace SchoolOfRobotics.Application.Abstractions.Services
{
    public interface IAuthenticationService
    {
        Task<User?> GetUserById(UserId userId);

        Task<User?> GetUserByEmail(string email, CancellationToken cancellationToken);
    }
}
