using SchoolOfRobotics.Domain.Primitives;

namespace SchoolOfRobotics.Domain.Identificators;

public sealed record NewsId(Guid Id) : IIdentificator;