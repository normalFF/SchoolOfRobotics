using SchoolOfRobotics.Domain.Enums;
using SchoolOfRobotics.Domain.Identificators;
using SchoolOfRobotics.Domain.Primitives;

namespace SchoolOfRobotics.Domain.CoursesTeachers.Entities;

public class Teacher : Entity<TeacherId>
{
	public UserId UserId { get; private set; }
	public CourseId CourseId { get; private set; }
	public TeacherStatusEnum Status { get; private set; }
	public DateTime UpdateStatusDate { get; private set; }


	#pragma warning disable CS8618
	private Teacher(TeacherId id)
		: base(id)
	{
	}
	#pragma warning restore CS8618


	private Teacher(TeacherId id, UserId userId, CourseId groupId, TeacherStatusEnum status, DateTime updateStatusDate)
		: base(id)
	{
		UserId = userId;
		CourseId = groupId;
		Status = status;
		UpdateStatusDate = updateStatusDate;
	}


	internal static Teacher Create(UserId userId, CourseId groupId)
	{
		return new Teacher(new(Guid.NewGuid()), userId, groupId, TeacherStatusEnum.Included, DateTime.Now);
	}

	internal void SetStatus(TeacherStatusEnum status)
	{
		if (status != Status)
		{
			Status = status;
			UpdateStatusDate = DateTime.Now;
		}
	}
}
