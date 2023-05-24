namespace SchoolOfRobotics.Domain.Primitives.Results
{
	public class Error : IEquatable<Error>
	{
		public string Code { get; }
		public string Description { get; }
		public ErrorTypeEnum Type { get; }

		public Error(string code, string description, ErrorTypeEnum errorType) 
		{
			Code = code;
			Description = description;
			Type = errorType;
		}


		public override bool Equals(object? obj)
		{
			if (obj is not null && obj is Error otherErr)
			{
				return string.Equals(Code, otherErr.Code)
					&& string.Equals(Description, otherErr.Description)
					&& Type == otherErr.Type;
			}
			return false;
		}

		public bool Equals(Error? other)
		{
			return Equals(other);
		}

		public override int GetHashCode()
		{
			return Code.GetHashCode() ^ Description.GetHashCode() ^ Type.GetHashCode();
		}

		public static bool operator ==(Error? left, Error? right)
		{
			if (left is null && right is null)
			{
				return true;
			}
			if (left is null || right is null)
			{
				return false;
			}
			if (left is Error errOne && right is Error errTwo)
			{
				return errOne.Equals(errTwo);
			}
			return false;
		}

		public static bool operator !=(Error? left, Error? right)
		{
			return !(left == right);
		}


		public static Error None() => new(string.Empty, string.Empty, ErrorTypeEnum.None);

		public static Error Failure(string code, string description) => new(code, description, ErrorTypeEnum.Failure);

		public static Error Validation(string code, string description) => new(code, description, ErrorTypeEnum.Validation);

		public static Error NotFound(string code, string description) => new(code, description, ErrorTypeEnum.NotFound);

		public static Error Conflict(string code, string description) => new(code, description, ErrorTypeEnum.Conflict);
	}
}
