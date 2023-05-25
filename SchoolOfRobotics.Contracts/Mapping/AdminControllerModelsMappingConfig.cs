using Mapster;
using SchoolOfRobotics.Application.Commands.CreateCourse;
using SchoolOfRobotics.Application.Commands.CreateGroup;
using SchoolOfRobotics.Application.Commands.SetCourseStatus;
using SchoolOfRobotics.Application.Commands.TeacherRegistration;
using SchoolOfRobotics.Contracts.Models.Requests;
using SchoolOfRobotics.Contracts.Models.Responces;

namespace SchoolOfRobotics.Contracts.Mapping;

public class AdminControllerModelsMappingConfig : IRegister
{
	public void Register(TypeAdapterConfig config)
	{
		config.NewConfig<CreateCourseCommand, CreateCourseRequest>()
			.Map(dest => dest.CourseName, opt => opt.CourseName)
			.Map(dest => dest.CourseDescription, opt => opt.CourseDescription);

		config.NewConfig<CreateCourseCommandResponce, CreateCourseResponce>()
			.Map(dest => dest.CourseId, opt => opt.CourseId.Id);

		config.NewConfig<CreateGroupCommand, CreateGroupRequest>()
			.Map(dest => dest.CourseId, opt => opt.CourseId)
			.Map(dest => dest.MinAge, opt => opt.MinAge)
			.Map(dest => dest.MaxAge, opt => opt.MaxAge)
			.Map(dest => dest.MinClassNumber, opt => opt.MinClassNumber)
			.Map(dest => dest.MaxClassNumber, opt => opt.MaxClassNumber)
			.Map(dest => dest.ListenersCount, opt => opt.ListenersCount)
			.Map(dest => dest.GroupName, opt => opt.GroupName)
			.Map(dest => dest.EnrollmentEndDate, opt => opt.EnrollmentEndDate)
			.Map(dest => dest.RecruitmentStartDate, opt => opt.RecruitmentStartDate);

		config.NewConfig<CreateGroupCommandResponce, CreateGroupResponce>()
			.Map(dest => dest.GroupId, opt => opt.GroupId.Id);

		config.NewConfig<SetCourseStatusRequest, SetCourseStatusCommand>()
			.Map(dest => dest.StatusValue, opt => opt.StatusValue)
			.Map(dest => dest.CourseId, opt => opt.CourseId);

		config.NewConfig<SetCourseStatusCommandResponce, SetCourseStatusResponce>()
			.Map(dest => dest.StatusValue, opt => opt.StatusValue);

		config.NewConfig<TeacherRegistrationRequest, TeacherRegistrationCommand>()
			.Map(dest => dest.Email, opt => opt.Email)
			.Map(dest => dest.FirstName, opt => opt.FirstName)
			.Map(dest => dest.LastName, opt => opt.LastName)
			.Map(dest => dest.Patronymic, opt => opt.Patronymic)
			.Map(dest => dest.Password, opt => opt.Password);
	}
}