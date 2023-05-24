namespace SchoolOfRobotics.Domain.Primitives.Results;

public class ValidationResult : Result, IValidationResult
{
	private ValidationResult(Error[] errors)
		: base(IValidationResult.ValidationError)
	{
		Errors = errors;
	}

	public Error[] Errors { get; }

	public static ValidationResult Create(Error[] errors) => new ValidationResult(errors);
}
