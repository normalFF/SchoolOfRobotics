using SchoolOfRobotics.Domain.CoursesTeachers.Entities;
using SchoolOfRobotics.Domain.Enums;
using SchoolOfRobotics.Domain.Identificators;
using SchoolOfRobotics.Domain.Primitives;
using SchoolOfRobotics.Domain.Primitives.Results;
using SchoolOfRobotics.Domain.Users;

namespace SchoolOfRobotics.Domain.CoursesTeachers.Aggregates;

public class TeacherCollection : AggregateRoot<CourseId>
{
	private readonly List<Teacher> _teachers;

	public IReadOnlyCollection<Teacher> Teachers => _teachers.AsReadOnly();


#pragma warning disable CS8618
	private TeacherCollection(CourseId id)
		: base(id)
	{
	}
#pragma warning restore CS8618


	private TeacherCollection(CourseId id, List<Teacher> teachers)
		: base(id)
	{
		_teachers = teachers;
	}

	public Result AddTeacher(User teacher)
	{
		if (teacher.Role.Value < UserRoleEnum.Teacher.Value) return Errors.Errors.Course.IncorrectTeacherRole;
		if (!Teachers.Select(i => i.UserId).Contains(teacher.Id))
		{
			_teachers.Add(Teacher.Create(teacher.Id, Id));
		}
		return Result.Success();
	}

	public Result RemoveTeacher(UserId id)
	{
		if (!_teachers.Select(i => i.UserId).Contains(id)) return Errors.Errors.Course.TeacherNotFound;
		else
		{
			_teachers.Remove(_teachers.First(i => i.UserId == id));
			return Result.Success();
		}
	}

	public Result RemoveTeacher(TeacherId id)
	{
		if (!_teachers.Select(i => i.Id).Contains(id)) return Errors.Errors.Course.TeacherNotFound;
		else
		{
			_teachers.Remove(_teachers.First(i => i.Id == id));
			return Result.Success();
		}
	}
}
