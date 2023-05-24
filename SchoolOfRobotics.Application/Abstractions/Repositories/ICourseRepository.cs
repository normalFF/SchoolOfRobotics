using SchoolOfRobotics.Domain.Courses.Aggregates;
using SchoolOfRobotics.Domain.Identificators;

namespace SchoolOfRobotics.Application.Abstractions.Repositories;

public interface ICourseRepository
{
	Task<Course?> GetCourseByIdAsync(CourseId courseId, CancellationToken cancellationToken);

	Task<bool> CheckCourseNameAsync(string name, CancellationToken cancellationToken);

	Task<bool> CheckCourseIdAsync(CourseId courseId, CancellationToken cancellationToken);

	Task AddCourseAsync(Course course, CancellationToken cancellationToken);
}
