using SchoolOfRobotics.Domain.Groups.Aggregates;
using SchoolOfRobotics.Domain.Identificators;

namespace SchoolOfRobotics.Application.Abstractions.Repositories
{
	public interface IGroupRepository
	{
		Task AddGroupAsync(Group group, CancellationToken cancellationToken);

		Task<Group?> GetGroupByIdAsync(GroupId group, CancellationToken cancellationToken);
	}
}
