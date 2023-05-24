namespace SchoolOfRobotics.Contracts.Models.Requests;

public sealed record AddChildrenRequest(
	Guid userId,
	string FirstName,
	string LastName,
	int ClassNumber,
	DateTime DateOfBirth);
