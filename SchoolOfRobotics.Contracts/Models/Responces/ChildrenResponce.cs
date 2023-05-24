namespace SchoolOfRobotics.Contracts.Models.Responces;

public sealed record ChildrenResponce(
	Guid Id,
	Guid UserId,
	string FirstName,
	string LastName,
	DateTime DateOfBirth,
	int ClassNumber);