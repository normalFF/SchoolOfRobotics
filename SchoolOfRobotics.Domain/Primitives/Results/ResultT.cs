namespace SchoolOfRobotics.Domain.Primitives.Results
{
	public class Result<TValue> : Result
	{
		private readonly TValue? _value;
		
		protected internal Result(TValue? value)
			: base()
		{
			_value = value;
		}

		protected internal Result(Error error)
			: base (error) 
		{
		}

		public TValue Value => IsSuccess
			? _value!
			: throw new InvalidOperationException("У ошибочного запроса не может быть объекта результата");

		public static implicit operator Result<TValue>(TValue? value) => new Result<TValue>(value);

		public static implicit operator Result<TValue>(Error error) => new Result<TValue>(error);
	}
}
