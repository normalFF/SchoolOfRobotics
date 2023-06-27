using Microsoft.EntityFrameworkCore;
using SchoolOfRobotics.Application.Abstractions.Repositories;
using SchoolOfRobotics.Domain.Courses;
using SchoolOfRobotics.Domain.Identificators;
using SchoolOfRobotics.Infrastructure.Context;

namespace SchoolOfRobotics.Infrastructure.Repositories;

public class CourseRepository : ICourseRepository
{
	private readonly ApplicationDbContext _context;

	public CourseRepository(ApplicationDbContext context)
	{
		_context = context;
	}

	public void AddCourse(Course course)
	{
		_context.Courses.Add(course);
	}

	public Task<bool> CheckCourseIdAsync(CourseId courseId, CancellationToken cancellationToken)
	{
		return _context.Courses
			.Select(p => p.Id)
			.ContainsAsync(courseId, cancellationToken);
	}

	public Task<bool> CheckCourseNameAsync(CourseName name, CancellationToken cancellationToken)
	{
		return _context.Courses
			.Select(p => p.Name)
			.ContainsAsync(name, cancellationToken);
	}

	public Task<Course?> GetCourseByIdAsync(CourseId courseId, CancellationToken cancellationToken)
	{
		return _context.Courses
			.SingleOrDefaultAsync(p => p.Id == courseId, cancellationToken);
	}
}
