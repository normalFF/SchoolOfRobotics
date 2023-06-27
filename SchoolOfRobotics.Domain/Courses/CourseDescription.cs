using SchoolOfRobotics.Domain.Primitives;
using SchoolOfRobotics.Domain.Primitives.Results;

namespace SchoolOfRobotics.Domain.Courses;

public class CourseDescription : ValueObject
{
    public static readonly int MaxLength = 5000;

    public string Value { get; private set; }

    private CourseDescription(string description)
    {
        Value = description;
    }

    public static Result<CourseDescription> Create(string description)
    {
        if (string.IsNullOrWhiteSpace(description)) return Errors.Errors.Course.EmptyCourseDescription;
        else if (description.Length > MaxLength) return Errors.Errors.Course.CourseDescriptionMaxLength(MaxLength);
        else
        {
            return new CourseDescription(description);
        }
    }

    public override IEnumerable<object> GetAtomicValues()
    {
        yield return Value;
    }
}
