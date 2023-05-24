using MediatR;
using SchoolOfRobotics.Domain.Primitives.Results;

namespace SchoolOfRobotics.Application.Abstractions.CommandComponents;

public interface ICommand : IRequest<Result>
{

}

public interface ICommand<TResponce> : IRequest<Result<TResponce>>
{

}
