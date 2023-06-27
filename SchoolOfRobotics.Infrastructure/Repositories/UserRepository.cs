using Microsoft.EntityFrameworkCore;
using SchoolOfRobotics.Application.Abstractions.Repositories;
using SchoolOfRobotics.Domain.Identificators;
using SchoolOfRobotics.Domain.Users;
using SchoolOfRobotics.Infrastructure.Context;

namespace SchoolOfRobotics.Infrastructure.Repositories;

public class UserRepository : IUserRepository
{
	private readonly ApplicationDbContext _context;

	public UserRepository(ApplicationDbContext context)
	{
		_context = context;
	}

	public void CreateUser(User user)
	{
		_context.Users.Add(user);
	}

	public Task<User?> GetUserByEmailAsync(Email email, CancellationToken cancellationToken)
	{
		return _context.Users
			.SingleOrDefaultAsync(user => user.Email == email, cancellationToken);
	}

	public Task<User?> GetUserByIdAsync(UserId id, CancellationToken cancellationToken)
	{
		return _context.Users
			.SingleOrDefaultAsync(user => user.Id == id, cancellationToken);
	}
}
