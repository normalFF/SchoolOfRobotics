namespace SchoolOfRobotics.Contracts.Models.Requests;

public sealed record TeacherRegistrationRequest(
	string FirstName,
	string LastName,
	string Patronymic,
	string Email,
	string Password);
