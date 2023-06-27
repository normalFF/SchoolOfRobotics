using Microsoft.EntityFrameworkCore;
using SchoolOfRobotics.Application.Abstractions.Repositories;
using SchoolOfRobotics.Domain.Groups;
using SchoolOfRobotics.Domain.Identificators;
using SchoolOfRobotics.Infrastructure.Context;

namespace SchoolOfRobotics.Infrastructure.Repositories;

public class GroupRepository : IGroupRepository
{
	private readonly ApplicationDbContext _context;

	public GroupRepository(ApplicationDbContext context)
	{
		_context = context;
	}

	public void AddGroup(Group group)
	{
		_context.Groups.Add(group);
	}

	public Task<Group?> GetGroupByIdAsync(GroupId groupId, CancellationToken cancellationToken)
	{
		return _context.Groups
			.SingleOrDefaultAsync(o => o.Id == groupId, cancellationToken);
	}
}
