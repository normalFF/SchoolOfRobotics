using System.Reflection;

namespace SchoolOfRobotics.Domain.Primitives
{
	public abstract class Enumeration<TEnum> : IEquatable<Enumeration<TEnum>>
		where TEnum : Enumeration<TEnum>
	{
		private static readonly Dictionary<int, TEnum> Enumerations = CreateEnumerations();

		public int Value { get; protected init; }
		public string Name { get; protected init; } = string.Empty;

		protected Enumeration(int value, string name)
		{
			Value = value;
			Name = name;
		}

		public static TEnum? FromValue(int value)
		{
			return Enumerations.TryGetValue(
				value,
				out TEnum? enumeration) ? enumeration : default;
		}

		public static TEnum? FromName(string name)
		{
			return Enumerations.Values.SingleOrDefault(i => i.Name == name);
		}

		public bool Equals(Enumeration<TEnum>? other)
		{
			return other is not null
				&& other.GetType() == GetType() 
				&& other.Value == Value;
		}

		private static Dictionary<int, TEnum> CreateEnumerations()
		{
			var currentType = typeof(TEnum);

			var currentFields = currentType
				.GetFields(BindingFlags.Public | BindingFlags.Static | BindingFlags.FlattenHierarchy)
				.Where(f => currentType.IsAssignableFrom(f.FieldType))
				.Select(f => (TEnum)f.GetValue(default)!);

			return currentFields.ToDictionary(x => x.Value);
		}

		public override bool Equals(object? obj)
		{
			return obj is Enumeration<TEnum> other
				&& Equals(other);
		}

		public override int GetHashCode()
		{
			return Value.GetHashCode() + Name.GetHashCode();
		}

		public override string ToString()
		{
			return Name;
		}

		public static bool operator >(Enumeration<TEnum> firstObj, Enumeration<TEnum> lastObj)
		{
			return firstObj.Value > lastObj.Value;
		}

		public static bool operator <(Enumeration<TEnum> firstObj, Enumeration<TEnum> lastObj)
		{
			return firstObj.Value < lastObj.Value;
		}
	}
}
