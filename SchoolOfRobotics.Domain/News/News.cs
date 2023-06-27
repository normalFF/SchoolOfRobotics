using SchoolOfRobotics.Domain.Identificators;
using SchoolOfRobotics.Domain.Primitives;
using SchoolOfRobotics.Domain.Primitives.Results;

namespace SchoolOfRobotics.Domain.News;

public class News : AggregateRoot<NewsId>
{
	public NewsName Name { get; private set; }
	public NewsDescription Description { get; private set; }
	public DateTime CreateDate { get; private set; }


	private News(NewsId id, NewsName name, NewsDescription description, DateTime createDate)
		: base(id)
	{
		Name = name;
		Description = description;
		CreateDate = createDate;
	}


	#pragma warning disable CS8618
	private News(NewsId id)
		: base(id)
	{
	}
	#pragma warning restore CS8618


	internal static Result<News> Create(string name, string description)
	{
		var newDescription = NewsDescription.Create(description);
		var newName = NewsName.Create(name);

		if (newName.IsFailure) return newName.Error;
		else if (newDescription.IsFailure) return newDescription.Error;
		else
		{
			return new News(new NewsId(Guid.NewGuid()), newName.Value, newDescription.Value, DateTime.Now);
		}
	}

	internal Result SetDescription(string description)
	{
		var newDescription = NewsDescription.Create(description);

		if (newDescription.IsFailure) return newDescription.Error;
		else
		{
			Description = newDescription.Value;
			return Result.Success();
		}
	}

	internal Result SetName(string name)
	{
		var newName = NewsName.Create(name);

		if (newName.IsFailure) return newName.Error;
		else
		{
			Name = newName.Value;
			return Result.Success();
		}
	}
}
