using SchoolOfRobotics.Domain.Courses.Aggregates;
using SchoolOfRobotics.Domain.Courses.ValueObjects;
using SchoolOfRobotics.Domain.Identificators;

namespace SchoolOfRobotics.Application.Abstractions.Repositories;

public interface ICourseRepository
{
	Task<Course?> GetCourseByIdAsync(CourseId courseId, CancellationToken cancellationToken);

	Task<bool> CheckCourseNameAsync(CourseName name, CancellationToken cancellationToken);

	Task<bool> CheckCourseIdAsync(CourseId courseId, CancellationToken cancellationToken);

	void AddCourse(Course course);
}
