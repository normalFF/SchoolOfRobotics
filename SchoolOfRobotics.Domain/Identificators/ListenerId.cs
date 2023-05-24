using SchoolOfRobotics.Domain.Primitives;

namespace SchoolOfRobotics.Domain.Identificators
{
    public sealed record ListenerId(Guid Id) : IIdentificator;
}
