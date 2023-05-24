using SchoolOfRobotics.Domain.Primitives;

namespace SchoolOfRobotics.Domain.Identificators
{
    public sealed record UserId(Guid Id) : IIdentificator;
}
