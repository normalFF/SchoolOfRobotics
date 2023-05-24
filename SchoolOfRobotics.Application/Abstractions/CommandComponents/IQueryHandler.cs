using MediatR;
using SchoolOfRobotics.Domain.Primitives.Results;

namespace SchoolOfRobotics.Application.Abstractions.CommandComponents;

public interface IQueryHandler<TQuery, TResponce> : IRequestHandler<TQuery, Result<TResponce>>
	where TQuery : IQuery<TResponce>
{
}
