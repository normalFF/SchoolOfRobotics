using SchoolOfRobotics.Domain.Identificators;
using SchoolOfRobotics.Domain.Primitives;

namespace SchoolOfRobotics.Domain.Users
{
    public sealed record ParentRegisteredDomainEvent(UserId Id) : IDomainEvent;
}
