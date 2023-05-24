using Mapster;
using SchoolOfRobotics.Application.Commands.ParentRegistration;
using SchoolOfRobotics.Contracts.Models.Requests;

namespace SchoolOfRobotics.Contracts.Mapping;

public class AuthenticationControllerModelsMappingConfig : IRegister
{
	public void Register(TypeAdapterConfig config)
	{
		config.NewConfig<SignUpRequest, ParentRegistrationCommand>()
			.Map(dest => dest.Email, opt => opt.Email)
			.Map(dest => dest.FirstName, opt => opt.FirstName)
			.Map(dest => dest.LastName, opt => opt.LastName)
			.Map(dest => dest.Patronymic, opt => opt.Patronymic)
			.Map(dest => dest.Password, opt => opt.Password);
	}
}
