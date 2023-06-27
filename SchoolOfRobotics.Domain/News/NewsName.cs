using SchoolOfRobotics.Domain.Primitives;
using SchoolOfRobotics.Domain.Primitives.Results;

namespace SchoolOfRobotics.Domain.News;

public class NewsName : ValueObject
{
	public string Value { get; private set; }

	private NewsName(string value) 
	{
		Value = value;
	}

	public static Result<NewsName> Create(string newsName)
	{
		if (string.IsNullOrWhiteSpace(newsName)) return Errors.Errors.News.NewsNameEmpty;
		else
		{
			return new NewsName(newsName);
		}
	}

	public override IEnumerable<object> GetAtomicValues()
	{
		yield return Value;
	}
}
