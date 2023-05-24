namespace SchoolOfRobotics.Domain.Primitives.Results
{
	public class ValidationResult<TValue> : Result<TValue>, IValidationResult
	{
		private ValidationResult(Error[] errors) 
			: base(IValidationResult.ValidationError)
		{
			Errors = errors;
		}

		public Error[] Errors { get; }

		public ValidationResult<TValue> Create(Error[] errors) => new(errors);
	}
}
