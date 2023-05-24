using MediatR;
using SchoolOfRobotics.Domain.Primitives.Results;

namespace SchoolOfRobotics.Application.Abstractions.CommandComponents;

public interface IQuery<TResponce> : IRequest<Result<TResponce>>
{
}
