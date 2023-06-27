using SchoolOfRobotics.Domain.Primitives;
using SchoolOfRobotics.Domain.Primitives.Results;

namespace SchoolOfRobotics.Domain.News;

public class NewsDescription : ValueObject
{
	public string Value { get; private set; }

	private NewsDescription(string value)
	{
		Value = value;
	}

	public static Result<NewsDescription> Create(string description)
	{
		if (string.IsNullOrWhiteSpace(description)) return Errors.Errors.News.NewsDescriptionEmpty;
		else
		{
			return new NewsDescription(description);
		}
	}

	public override IEnumerable<object> GetAtomicValues()
	{
		yield return Value;
	}
}