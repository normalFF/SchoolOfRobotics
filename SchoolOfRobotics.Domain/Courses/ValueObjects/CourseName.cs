using SchoolOfRobotics.Domain.Primitives;
using SchoolOfRobotics.Domain.Primitives.Results;

namespace SchoolOfRobotics.Domain.Courses.ValueObjects;

public class CourseName : ValueObject
{
	public static readonly int MaxLength = 30;

	public string Value { get; private set; }

	private CourseName(string name)
	{
		Value = name;
	}

	public static Result<CourseName> Create(string name)
	{
		if (string.IsNullOrWhiteSpace(name)) return Errors.Errors.Course.EmptyCourseName;
		else if (name.Length > MaxLength) return Errors.Errors.Course.CourseNameMaxLength(MaxLength);
		else
		{
			return new CourseName(name);
		}
	}

	public override IEnumerable<object> GetAtomicValues()
	{
		yield return Value;
	}
}
