using SchoolOfRobotics.Application.Abstractions.CommandComponents;
using SchoolOfRobotics.Application.Abstractions.Repositories;
using SchoolOfRobotics.Application.Abstractions.Services;
using SchoolOfRobotics.Domain.Courses.Aggregates;
using SchoolOfRobotics.Domain.Errors;
using SchoolOfRobotics.Domain.Primitives.Results;

namespace SchoolOfRobotics.Application.Commands.CreateCourse;

public class CreateCourseCommandHandler : ICommandHandler<CreateCourseCommand, CreateCourseCommandResponce>
{
	private readonly ICourseRepository _courseRepository;
	private readonly IUnitOfWork _unitOfWork;

	public CreateCourseCommandHandler(ICourseRepository courseRepository, IUnitOfWork unitOfWork)
	{
		_courseRepository = courseRepository;
		_unitOfWork = unitOfWork;
	}

	public async Task<Result<CreateCourseCommandResponce>> Handle(CreateCourseCommand request, CancellationToken cancellationToken)
	{
		var checkResult = await _courseRepository.CheckCourseNameAsync(request.CourseName, cancellationToken);

		if (checkResult)
		{
			return Errors.Course.CourseNameAlreabyExist;
		}
		else
		{
			var newCourse = Course.Create(request.CourseName, request.CourseDescription);
			if (newCourse.IsFailure)
			{
				return newCourse.Error;
			}
			else
			{
				await _courseRepository.AddCourseAsync(newCourse.Value, cancellationToken);
				await _unitOfWork.SaveChangesAsync(cancellationToken);
				return new CreateCourseCommandResponce(newCourse.Value.Id);
			}
		}
	}
}
