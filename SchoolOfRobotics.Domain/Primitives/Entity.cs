namespace SchoolOfRobotics.Domain.Primitives
{
	public abstract class Entity<TId> : IEquatable<Entity<TId>>
		where TId : notnull
	{
		public TId Id { get; private init; }

		protected Entity(TId id)
		{
			Id = id;
		}

		public override bool Equals(object? obj)
		{
			return obj is Entity<TId> entity && Equals(entity.Id);
		}

		public override int GetHashCode()
		{
			return Id.GetHashCode();
		}

		public bool Equals(Entity<TId>? other)
		{
			return Equals((object?)other);
		}

		public static bool operator ==(Entity<TId> entityOne, Entity<TId> entityTwo) => entityOne.Equals(entityTwo);

		public static bool operator !=(Entity<TId> entityOne, Entity<TId> entityTwo) => !entityOne.Equals(entityTwo);
	}
}
