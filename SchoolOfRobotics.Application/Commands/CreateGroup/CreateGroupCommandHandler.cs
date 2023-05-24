using SchoolOfRobotics.Application.Abstractions.CommandComponents;
using SchoolOfRobotics.Application.Abstractions.Repositories;
using SchoolOfRobotics.Application.Abstractions.Services;
using SchoolOfRobotics.Domain.Errors;
using SchoolOfRobotics.Domain.Groups.Aggregates;
using SchoolOfRobotics.Domain.Identificators;
using SchoolOfRobotics.Domain.Primitives.Results;

namespace SchoolOfRobotics.Application.Commands.CreateGroup;

public class CreateGroupCommandHandler : ICommandHandler<CreateGroupCommand, CreateGroupCommandResponce>
{
	private readonly IUnitOfWork _unitOfWork;
	private readonly IGroupRepository _groupRepository;
	private readonly ICourseRepository _courseRepository;

	public CreateGroupCommandHandler(IUnitOfWork unitOfWork, IGroupRepository groupRepository, ICourseRepository courseRepository)
	{
		_unitOfWork = unitOfWork;
		_groupRepository = groupRepository;
		_courseRepository = courseRepository;
	}

	public async Task<Result<CreateGroupCommandResponce>> Handle(CreateGroupCommand request, CancellationToken cancellationToken)
	{
		var courseId = new CourseId(request.CourseId);
		var checkCourse = await _courseRepository.CheckCourseIdAsync(courseId, cancellationToken);

		if (checkCourse)
		{
			return Errors.Course.CourseNotFound;
		}
		else
		{
			var newGroup = Group.Create(
				courseId, 
				request.GroupName,
				request.MinAge,
				request.MaxAge,
				request.MinClassNumber,
				request.MaxClassNumber,
				request.RecruitmentStartDate,
				request.EnrollmentEndDate,
				request.ListenersCount);

			if (newGroup.IsFailure)
			{
				return newGroup.Error;
			}
			else
			{
				await _groupRepository.AddGroupAsync(newGroup.Value, cancellationToken);
				await _unitOfWork.SaveChangesAsync(cancellationToken);
				return new CreateGroupCommandResponce(newGroup.Value.Id);
			}
		}
	}
}
