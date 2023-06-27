using MediatR;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Quartz;
using SchoolOfRobotics.Domain.OutBoxMessages;
using SchoolOfRobotics.Domain.Primitives;
using SchoolOfRobotics.Infrastructure.Context;

namespace SchoolOfRobotics.Infrastructure.BackgroundProcess
{
    [DisallowConcurrentExecution]
	public class ProcessOutBoxMessages : IJob
	{
		private readonly ApplicationDbContext _context;
		private readonly IPublisher _publisher;

		public ProcessOutBoxMessages(ApplicationDbContext context, IPublisher publisher)
		{
			_context = context;
			_publisher = publisher;
		}

		public async Task Execute(IJobExecutionContext context)
		{
			var messages = await _context
				.Set<OutBoxMessage>()
				.Where(m => m.ProcessedDate == null)
				.Take(10)
				.ToListAsync(context.CancellationToken);

			foreach (var messageItem in messages)
			{
				var domainEvent = JsonConvert
					.DeserializeObject<IDomainEvent>(messageItem.Content);

				if (domainEvent is null) continue;
				else
				{

					try
					{
						await _publisher.Publish(domainEvent, context.CancellationToken);
						messageItem.ProcessedDate = DateTime.UtcNow;
					}
					catch (Exception ex)
					{
						messageItem.Error = ex.ToString();
						messageItem.ProcessedDate = DateTime.UtcNow;
					}
				}
			}

			await _context.SaveChangesAsync();
		}
	}
}
