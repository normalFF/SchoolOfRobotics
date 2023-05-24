namespace SchoolOfRobotics.Domain.Primitives
{
	public abstract class ValueObject : IEquatable<ValueObject>
	{
		public abstract IEnumerable<object> GetAtomicValues();

		private bool ValuesAreEquals(ValueObject val)
		{
			return GetAtomicValues().SequenceEqual(val.GetAtomicValues());
		}

		public bool Equals(ValueObject? other)
		{
			return other is not null && ValuesAreEquals(other);
		}

		public override bool Equals(object? obj)
		{
			return obj is ValueObject val && ValuesAreEquals(val);
		}

		public override int GetHashCode()
		{
			return GetAtomicValues().Select(x => x?.GetHashCode() ?? 0).Aggregate((x, y) => x ^ y);
		}
	}
}
