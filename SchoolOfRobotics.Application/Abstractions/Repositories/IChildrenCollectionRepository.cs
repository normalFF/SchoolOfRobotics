using SchoolOfRobotics.Domain.Childrens.Aggregates;
using SchoolOfRobotics.Domain.Identificators;

namespace SchoolOfRobotics.Application.Abstractions.Repositories;

public interface IChildrenCollectionRepository
{
	Task<ChildrenCollection?> GetChildrenCollectionById(UserId id, CancellationToken cancellationToken);
}
