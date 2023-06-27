using SchoolOfRobotics.Application.Abstractions.CommandComponents;
using SchoolOfRobotics.Application.Abstractions.Repositories;
using SchoolOfRobotics.Application.Abstractions.Services;
using SchoolOfRobotics.Domain.Courses;
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
		var createResult = CourseName.Create(request.CourseName);

		if (createResult.IsFailure)
		{
			return createResult.Error;
		}
		else
		{
			var checkResult = await _courseRepository.CheckCourseNameAsync(createResult.Value, cancellationToken);

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
					_courseRepository.AddCourse(newCourse.Value);
					await _unitOfWork.SaveChangesAsync(cancellationToken);
					return new CreateCourseCommandResponce(newCourse.Value.Id);
				}
			}
		}
	}
}
