using SchoolOfRobotics.Domain.Primitives.Results;
using FluentValidation;
using MediatR;

namespace SchoolOfRobotics.Application.Abstractions.CommandComponents
{
	public class ValidationBehavior<TRequest, TResponce>
		: IPipelineBehavior<TRequest, TResponce>
		where TRequest : IQuery<TResponce>
		where TResponce : Result
	{
		private readonly IEnumerable<IValidator<TRequest>> _validators;

        public ValidationBehavior(IEnumerable<IValidator<TRequest>> validators)
        {
            _validators = validators;
        }

		public async Task<TResponce> Handle(TRequest request, RequestHandlerDelegate<TResponce> next, CancellationToken cancellationToken)
		{
			if (!_validators.Any())
			{
				return await next();
			}

			Error[] errors = _validators
				.Select(v => v.Validate(request))
				.SelectMany(v => v.Errors)
				.Where(f => f is not null)
				.Select(f => new Error(f.PropertyName, f.ErrorMessage, ErrorTypeEnum.Validation))
				.Distinct()
				.ToArray();

			if (errors.Any())
			{
				return CreateValidationResult<TResponce>(errors);
			}
			else
			{
				return await next();
			}
		}

		private static TResult CreateValidationResult<TResult>(Error[] errors)
			where TResult : Result
		{
			if (typeof(TResult) == typeof(Result))
			{
				return (ValidationResult.Create(errors) as TResult)!;
			}
			else
			{
				object result = typeof(ValidationResult<>)
					.GetGenericTypeDefinition()
					.MakeGenericType(typeof(TResult).GenericTypeArguments[0])
					.GetMethod(nameof(ValidationResult.Create))!
					.Invoke(null, new object?[] { errors })!;

				return (TResult)result;
			}
		}
	}
}
