using SchoolOfRobotics.Domain.Primitives;

namespace SchoolOfRobotics.Domain.Identificators
{
    public sealed record TeacherId(Guid Id) : IIdentificator;
}
