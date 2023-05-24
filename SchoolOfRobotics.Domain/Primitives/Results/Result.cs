namespace SchoolOfRobotics.Domain.Primitives.Results
{
	public class Result
	{
		public bool IsSuccess { get; }
		public bool IsFailure => !IsSuccess;
		public Error Error { get; }
		protected internal Result()
		{
			IsSuccess = true;
			Error = Error.None();
		}

		protected internal Result(Error error) 
		{
			if (error == Error.None())
			{
				IsSuccess = true;
			}
			else
			{
				IsSuccess = false;
			}
			Error = error;
		}

		public static Result Success() => new();

		public static implicit operator Result(Error error) => new(error);
	}
}
