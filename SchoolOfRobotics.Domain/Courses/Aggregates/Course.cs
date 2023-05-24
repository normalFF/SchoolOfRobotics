using SchoolOfRobotics.Domain.Courses.ValueObjects;
using SchoolOfRobotics.Domain.Enums;
using SchoolOfRobotics.Domain.Identificators;
using SchoolOfRobotics.Domain.Primitives;
using SchoolOfRobotics.Domain.Primitives.Results;

namespace SchoolOfRobotics.Domain.Courses.Aggregates;

public class Course : AggregateRoot<CourseId>
{
    public CourseStatusEnum Status { get; private set; }
    public CourseName Name { get; private set; }
    public CourseDescription Description { get; private set; }


    #pragma warning disable CS8618
	private Course(CourseId id)
		: base(id)
    {
    }
    #pragma warning restore CS8618

	private Course(CourseId id, CourseName name, CourseDescription description, CourseStatusEnum status)
		: base(id)
	{
        Name = name;
        Description = description;
        Status = status;
	}

    public static Result<Course> Create(string name, string description)
    {
        var courseName = CourseName.Create(name);
        var courseDescription = CourseDescription.Create(description);

        if (courseName.IsFailure) return courseName.Error;
        else if (courseDescription.IsFailure) return courseDescription.Error;
        else
        {
            return new Course(new(Guid.NewGuid()), courseName.Value, courseDescription.Value, CourseStatusEnum.Close);
        }
    }

	public void ReplaseStatus(CourseStatusEnum newStatus)
    {
        Status = newStatus;
	}

    public Result ReplaseName(string name)
    {
        var newName = CourseName.Create(name);
        if (newName.IsFailure) return newName.Error;
        else
        {
            Name = newName.Value;
            return Result.Success();
        }
    }

    public Result ReplaceDescription(string description)
    {
        var newDescription = CourseDescription.Create(description);
        if (newDescription.IsFailure) return newDescription.Error;
        else
        {
            Description = newDescription.Value;
            return Result.Success();
        }
    }
}