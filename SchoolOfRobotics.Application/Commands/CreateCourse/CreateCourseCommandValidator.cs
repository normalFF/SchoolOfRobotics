using FluentValidation;
using SchoolOfRobotics.Domain.Courses.ValueObjects;

namespace SchoolOfRobotics.Application.Commands.CreateCourse
{
	public class CreateCourseCommandValidator : AbstractValidator<CreateCourseCommand>
	{
		public CreateCourseCommandValidator()
		{
			RuleFor(p => p.CourseName).MaximumLength(CourseName.MaxLength).NotNull().NotEmpty();
			RuleFor(p => p.CourseDescription).MaximumLength(CourseDescription.MaxLength).NotNull().NotEmpty();
		}
	}
}
