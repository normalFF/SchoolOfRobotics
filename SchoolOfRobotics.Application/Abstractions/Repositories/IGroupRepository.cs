using SchoolOfRobotics.Domain.Groups;
using SchoolOfRobotics.Domain.Identificators;

namespace SchoolOfRobotics.Application.Abstractions.Repositories
{
    public interface IGroupRepository
	{
		void AddGroup(Group group);

		Task<Group?> GetGroupByIdAsync(GroupId group, CancellationToken cancellationToken);
	}
}
