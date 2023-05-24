using MediatR;
using SchoolOfRobotics.Domain.Primitives.Results;

namespace SchoolOfRobotics.Application.Abstractions.CommandComponents;

public interface ICommandHandler<TCommand> : IRequestHandler<TCommand, Result>
	where TCommand : ICommand
{
}

public interface ICommandHandler<TCommand, TResponce> : IRequestHandler<TCommand, Result<TResponce>>
	where TCommand : ICommand<TResponce>
{
}