namespace SchoolOfRobotics.Contracts.Models.Requests;

public sealed record SetCourseStatusRequest(Guid CourseId, int StatusValue);
