namespace SchoolOfRobotics.Contracts.Models.Requests;

public sealed record RemoveTeachersInCourseRequest(
	Guid CourseId,
	Guid[] Teachers);
