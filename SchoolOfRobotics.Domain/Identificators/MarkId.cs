using SchoolOfRobotics.Domain.Primitives;

namespace SchoolOfRobotics.Domain.Identificators
{
	public sealed record MarkId(Guid Id) : IIdentificator;
}
