using SchoolOfRobotics.Domain.Primitives;

namespace SchoolOfRobotics.Domain.Identificators;

public sealed record StockId(Guid Id) : IIdentificator;