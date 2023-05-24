using SchoolOfRobotics.Domain.Primitives.Results;
using MediatR;
using Microsoft.Extensions.Logging;

namespace SchoolOfRobotics.Application.Abstractions.CommandComponents
{
	public class LoggingBehavior<TRequest, TResponce>
		: IPipelineBehavior<TRequest, TResponce>
		where TRequest : IQuery<TResponce>
		where TResponce : Result
	{
		private readonly ILogger<LoggingBehavior<TRequest, TResponce>> _logger;

		public LoggingBehavior(ILogger<LoggingBehavior<TRequest, TResponce>> logger)
		{
			_logger = logger;
		}

		public async Task<TResponce> Handle(TRequest request, RequestHandlerDelegate<TResponce> next, CancellationToken cancellationToken)
		{
			return await next();
		}
	}
}
