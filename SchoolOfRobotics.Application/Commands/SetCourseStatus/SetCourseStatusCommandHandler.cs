using SchoolOfRobotics.Application.Abstractions.CommandComponents;
using SchoolOfRobotics.Application.Abstractions.Repositories;
using SchoolOfRobotics.Application.Abstractions.Services;
using SchoolOfRobotics.Domain.Enums;
using SchoolOfRobotics.Domain.Errors;
using SchoolOfRobotics.Domain.Identificators;
using SchoolOfRobotics.Domain.Primitives.Results;

namespace SchoolOfRobotics.Application.Commands.SetCourseStatus;

public class SetCourseStatusCommandHandler : ICommandHandler<SetCourseStatusCommand, SetCourseStatusCommandResponce>
{
	private readonly IUnitOfWork _unitOfWork;
	private readonly ICourseRepository _courseRepository;

	public SetCourseStatusCommandHandler(IUnitOfWork unitOfWork, ICourseRepository courseRepository)
	{
		_courseRepository = courseRepository;
		_unitOfWork = unitOfWork;
	}

	public async Task<Result<SetCourseStatusCommandResponce>> Handle(SetCourseStatusCommand request, CancellationToken cancellationToken)
	{
		var status = CourseStatusEnum.FromValue(request.StatusValue);
		if (status is null)
		{
			return Errors.Course.InvalidStatus;
		}
		else 
		{
			var groupId = new CourseId(request.CourseId);
			var group = await _courseRepository.GetCourseByIdAsync(groupId, cancellationToken);

			if (group is null)
			{
				return Errors.Course.CourseNotFound;
			}
			else
			{
				group.ReplaseStatus(status);
				await _unitOfWork.SaveChangesAsync(cancellationToken);
				return new SetCourseStatusCommandResponce(status.Value);
			}
		}
	}
}
