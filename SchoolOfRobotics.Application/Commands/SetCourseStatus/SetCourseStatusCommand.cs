using SchoolOfRobotics.Application.Abstractions.CommandComponents;

namespace SchoolOfRobotics.Application.Commands.SetCourseStatus;

public sealed record SetCourseStatusCommand(Guid CourseId, int StatusValue) : ICommand<SetCourseStatusCommandResponce>;
