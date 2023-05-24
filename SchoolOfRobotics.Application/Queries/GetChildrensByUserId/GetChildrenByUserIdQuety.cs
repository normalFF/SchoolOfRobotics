using SchoolOfRobotics.Application.Abstractions.CommandComponents;

namespace SchoolOfRobotics.Application.Queries.GetChildrensByUserId
{
	public sealed record GetChildrenByUserIdQuety(Guid UserId) : IQuery<GetChildrenByUserIdResponce>;
}
