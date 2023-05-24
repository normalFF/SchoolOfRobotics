namespace SchoolOfRobotics.Contracts.Models.Requests;

public sealed record AddTeachersInCourseRequest(
	Guid CourseId,
	Guid[] Teachers);
