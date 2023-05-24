namespace SchoolOfRobotics.Domain.Primitives.Results;

public interface IValidationResult
{
	protected static Error ValidationError => Error.Validation(code: "Ошибка проверки", description: "Ошибки при проверке входящих данных");

	Error[] Errors { get; }
}
