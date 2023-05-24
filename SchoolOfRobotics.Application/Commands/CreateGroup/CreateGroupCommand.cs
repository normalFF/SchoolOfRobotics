using SchoolOfRobotics.Application.Abstractions.CommandComponents;

namespace SchoolOfRobotics.Application.Commands.CreateGroup;

public sealed record CreateGroupCommand(
	Guid CourseId,
	string GroupName,
	int MinAge,
	int MaxAge,
	int MinClassNumber,
	int MaxClassNumber,
	DateTime RecruitmentStartDate,
	DateTime EnrollmentEndDate,
	int ListenersCount) : ICommand<CreateGroupCommandResponce>;
