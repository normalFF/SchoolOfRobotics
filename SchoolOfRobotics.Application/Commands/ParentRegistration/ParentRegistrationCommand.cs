using SchoolOfRobotics.Application.Abstractions.CommandComponents;

namespace SchoolOfRobotics.Application.Commands.ParentRegistration;

public sealed record ParentRegistrationCommand(
		string FirstName,
		string LastName,
		string Patronymic,
		string Email,
		string Phone,
		string Password
	) : ICommand;
