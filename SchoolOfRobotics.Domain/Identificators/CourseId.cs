using SchoolOfRobotics.Domain.Primitives;

namespace SchoolOfRobotics.Domain.Identificators
{
    public sealed record CourseId(Guid Id) : IIdentificator;
}
