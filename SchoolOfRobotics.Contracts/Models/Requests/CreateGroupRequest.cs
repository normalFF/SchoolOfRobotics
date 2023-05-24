namespace SchoolOfRobotics.Contracts.Models.Requests;

public sealed record CreateGroupRequest(
	Guid CourseId,
	string GroupName,
	int MinAge,
	int MaxAge,
	int MinClassNumber,
	int MaxClassNumber,
	DateTime RecruitmentStartDate,
	DateTime EnrollmentEndDate,
	int ListenersCount);
