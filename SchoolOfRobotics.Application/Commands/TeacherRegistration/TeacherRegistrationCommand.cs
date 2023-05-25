using SchoolOfRobotics.Application.Abstractions.CommandComponents;

namespace SchoolOfRobotics.Application.Commands.TeacherRegistration;

public sealed record TeacherRegistrationCommand(
		string FirstName,
		string LastName,
		string Patronymic,
		string Email,
		string Phone,
		string Password) : ICommand;
