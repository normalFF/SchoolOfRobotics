using SchoolOfRobotics.Domain.Enums;
using SchoolOfRobotics.Domain.Groups.ValueObjects;
using SchoolOfRobotics.Domain.Identificators;
using SchoolOfRobotics.Domain.Primitives;
using SchoolOfRobotics.Domain.Primitives.Results;

namespace SchoolOfRobotics.Domain.Groups.Aggregates;

public sealed class Group : AggregateRoot<GroupId>
{
	public CourseId CourseId { get; private set; }
	public GroupName Name { get; private set; }
	public int MinAge { get; private set; }
	public int MaxAge { get; private set; }
	public ClassNumberEnum MinClassNumber { get; private set; }
	public ClassNumberEnum MaxClassNumber { get; private set; }
	public DateTime RecruitmentStartDate { get; private set; }
	public DateTime EnrollmentEndDate { get; private set; }
	public GroupStatusEnum Status { get; private set; }
	public int ListenersCount { get; private set; }


#pragma warning disable CS8618
	private Group(GroupId id)
		: base(id)
	{
	}
#pragma warning restore CS8618


	private Group(
		GroupId id,
		CourseId courseId,
		GroupName name,
		int minAge,
		int maxAge,
		ClassNumberEnum minClassNumber,
		ClassNumberEnum maxClassNumber,
		DateTime recruitmentStartDate,
		DateTime enrollmentEndDate,
		GroupStatusEnum status,
		int countListeners)
		: base(id)
	{
		CourseId = courseId;
		Name = name;
		MinAge = minAge;
		MaxAge = maxAge;
		MinClassNumber = minClassNumber;
		MaxClassNumber = maxClassNumber;
		RecruitmentStartDate = recruitmentStartDate;
		EnrollmentEndDate = enrollmentEndDate;
		Status = status;
		ListenersCount = countListeners;
	}

	public static Result<Group> Create(
		CourseId courseId,
		string name,
		int minAge,
		int maxAge,
		int minClassNumber,
		int maxClassNumber,
		DateTime recruitmentStartDate,
		DateTime enrollmentEndDate,
		int countListeners)
	{
		if (minAge < 1)
		{
			return Errors.Errors.Groups.AgeCannotBeNegative;
		}
		if (maxAge < minAge)
		{
			return Errors.Errors.Groups.MinAgeMoreMaxAge;
		}

		var minClass = ClassNumberEnum.FromValue(minClassNumber);
		var maxClass = ClassNumberEnum.FromValue(maxClassNumber);

		if (minClass is null || maxClass is null)
		{
			return Errors.Errors.Groups.IncorrectClassStatusEnumValue;
		}
		if (minClass > maxClass)
		{
			return Errors.Errors.Groups.MinClassNumberMoreMaxClassNumber;
		}
		if (countListeners < 1)
		{
			return Errors.Errors.Groups.MinListenersCount(1);
		}
		if (recruitmentStartDate > enrollmentEndDate)
		{
			return Errors.Errors.Groups.DateTimeDiapasonInvalid;
		}

		var groupName = GroupName.Create(name);

		if (groupName.IsFailure)
		{
			return groupName.Error;
		}

		return new Group(
			new GroupId(Guid.NewGuid()),
			courseId,
			groupName.Value,
			minAge,
			maxAge,
			minClass,
			maxClass,
			recruitmentStartDate,
			enrollmentEndDate,
			GroupStatusEnum.Open,
			countListeners);
	}

	public Result SetDate(DateTime beginDate, DateTime endDate)
	{
		if (Status == GroupStatusEnum.Completed)
		{
			return Errors.Errors.Groups.SetDateCompletedCourse;
		}
		if (beginDate <= endDate)
		{
			return Errors.Errors.Groups.SetDateTimeInvalid;
		}
		else
		{
			RecruitmentStartDate = beginDate;
			EnrollmentEndDate = endDate;
			return Result.Success();
		}
	}

	public Result SetStatus(GroupStatusEnum status)
	{
		if (Status == GroupStatusEnum.Completed)
		{
			return Errors.Errors.Groups.SetStatusInvalid;
		}
		else
		{
			Status = status;
			return Result.Success();
		}
	}

	public Result SetAge(int minAge, int maxAge)
	{
		if (minAge > maxAge) return Errors.Errors.Groups.MinAgeMoreMaxAge;
		else
		{
			MinAge = minAge;
			MaxAge = maxAge;
			return Result.Success();
		}
	}

	public Result SetClassNumber(ClassNumberEnum minClass, ClassNumberEnum maxClass)
	{
		if (minClass.Value > maxClass.Value)
		{
			return Errors.Errors.Groups.MinClassNumberMoreMaxClassNumber;
		}
		else
		{
			MinClassNumber = minClass;
			MaxClassNumber = maxClass;
			return Result.Success();
		}
	}

	public Result SetName(string name)
	{
		var newName = GroupName.Create(name);
		if (newName.IsFailure) return newName.Error;
		else
		{
			Name = newName.Value;
			return Result.Success();
		}
	}

	public Result SetListenersCount(int listenersCount)
	{
		if (listenersCount < 1)
		{
			return Errors.Errors.Groups.IncorrectListenersCount;
		}
		else
		{
			ListenersCount = listenersCount;
			return Result.Success();
		}
	}
}
