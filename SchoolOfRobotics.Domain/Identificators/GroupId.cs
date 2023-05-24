using SchoolOfRobotics.Domain.Primitives;

namespace SchoolOfRobotics.Domain.Identificators
{
    public sealed record GroupId(Guid Id) : IIdentificator;
}
