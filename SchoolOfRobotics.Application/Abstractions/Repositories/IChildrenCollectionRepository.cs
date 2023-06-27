using SchoolOfRobotics.Domain.Childrens;
using SchoolOfRobotics.Domain.Identificators;

namespace SchoolOfRobotics.Application.Abstractions.Repositories;

public interface IChildrenCollectionRepository
{
	Task<ChildrenCollection?> GetChildrenCollectionById(UserId id, CancellationToken cancellationToken);
}
