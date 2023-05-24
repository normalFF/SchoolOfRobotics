using SchoolOfRobotics.Application.Abstractions.CommandComponents;

namespace SchoolOfRobotics.Application.Commands.CreateCourse;

public sealed record CreateCourseCommand(string CourseName, string CourseDescription) : ICommand<CreateCourseCommandResponce>;
