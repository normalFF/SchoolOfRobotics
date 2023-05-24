using SchoolOfRobotics.Domain.Primitives;

namespace SchoolOfRobotics.Domain.Identificators
{
	public sealed record LessonId(Guid Id) : IIdentificator;
}
