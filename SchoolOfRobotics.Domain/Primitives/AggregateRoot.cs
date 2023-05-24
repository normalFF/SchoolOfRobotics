namespace SchoolOfRobotics.Domain.Primitives
{
	public abstract class AggregateRoot<TId> : Entity<TId>
		where TId : IIdentificator
	{
		private readonly List<IDomainEvent> _domainEvents;

		protected AggregateRoot(TId id)
			: base(id) 
		{
			_domainEvents = new();
		}

		public IReadOnlyCollection<IDomainEvent> GetDomainEvents() => _domainEvents.ToList();

		public void ClearDomainEvents() => _domainEvents.Clear();

		protected void RaiseDomainEvent(IDomainEvent domainEvent)
		{
			_domainEvents.Add(domainEvent);
		}
	}
}
