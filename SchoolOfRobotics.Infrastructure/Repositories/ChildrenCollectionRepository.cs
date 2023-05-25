using Microsoft.EntityFrameworkCore;
using SchoolOfRobotics.Application.Abstractions.Repositories;
using SchoolOfRobotics.Domain.Childrens.Aggregates;
using SchoolOfRobotics.Domain.Identificators;
using SchoolOfRobotics.Infrastructure.Context;

namespace SchoolOfRobotics.Infrastructure.Repositories;

public class ChildrenCollectionRepository : IChildrenCollectionRepository
{
	private readonly ApplicationDbContext _context;

	public ChildrenCollectionRepository(ApplicationDbContext context)
	{
		_context = context;
	}

	public Task<ChildrenCollection?> GetChildrenCollectionById(UserId id, CancellationToken cancellationToken)
	{
		return _context.ChildrenCollections
			.SingleOrDefaultAsync(i => i.Id == id, cancellationToken);
	}
}
