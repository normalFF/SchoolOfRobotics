using Newtonsoft.Json;
using SchoolOfRobotics.Application.Abstractions.Services;
using SchoolOfRobotics.Domain.OutBoxMessages;
using SchoolOfRobotics.Domain.Primitives;
using SchoolOfRobotics.Infrastructure.Context;

namespace SchoolOfRobotics.Infrastructure.Persistence
{
    internal class UnitOfWork : IUnitOfWork
	{
		private readonly ApplicationDbContext _dbContext;

		public UnitOfWork(ApplicationDbContext dbContext)
		{
			_dbContext = dbContext;
		}

		public Task SaveChangesAsync(CancellationToken cancellationToken)
		{
			ConvertDomainEventsToOutBoxMessages();
			return _dbContext.SaveChangesAsync(cancellationToken);
		}

		private void ConvertDomainEventsToOutBoxMessages()
		{
			var outBoxMessages = _dbContext.ChangeTracker
				.Entries<AggregateRoot<IIdentificator>>()
				.Select(x => x.Entity)
				.SelectMany(x =>
				{
					var events = x.GetDomainEvents();
					x.ClearDomainEvents();
					return events;
				})
				.Select(events => new OutBoxMessage
				{
					Id = Guid.NewGuid(),
					OccurredDate = DateTime.UtcNow,
					Type = events.GetType().Name,
					Content = JsonConvert.SerializeObject(events, new JsonSerializerSettings
					{
						TypeNameHandling = TypeNameHandling.All
					}),
				})
				.ToList();

			_dbContext.Set<OutBoxMessage>().AddRange(outBoxMessages);
		}
	}
}
