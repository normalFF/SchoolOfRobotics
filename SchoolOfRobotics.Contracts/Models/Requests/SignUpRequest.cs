namespace SchoolOfRobotics.Contracts.Models.Requests
{
	public sealed record SignUpRequest(
		string FirstName,
		string LastName,
		string Patronymic,
		string Email,
		string Password);
}
